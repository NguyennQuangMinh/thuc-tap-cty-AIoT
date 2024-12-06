#define ESP_DRD_USE_SPIFFS true
#if CONFIG_FREERTOS_UNICORE
#define ARDUINO_RUNNING_CORE 0
#else
#define ARDUINO_RUNNING_CORE 1
#endif

#include <WiFi.h>
#include <PubSubClient.h>
#include <WiFiClientSecure.h>
#include <DHT.h>
#include <BLEDevice.h>
#include <BLEUtils.h>
#include <BLEServer.h>
#include <SPI.h>
#include <Ethernet.h>
#include <FS.h>
#include <SPIFFS.h>
#include <WiFiManager.h>
#include <ArduinoJson.h>
#include <WebServer.h>
#include <BluetoothSerial.h> 
#include <HardwareSerial.h>
#include <TaskScheduler.h>
#include <RTClib.h>

// khai bao chan
DHT dht(13, DHT11);
#define BUTTON_PIN 12
#define LED_PIN 14
unsigned long flag_button=0;
bool isEthernetConnected = false;

// LED status
int led_state = LOW;
int button_state;       // the current state of button
int last_button_state;  // the previous state of button

// dinh nghia file json
#define JSON_CONFIG_FILE "/test_config.json"
// dinh nghia cong Ethernet
#define ETHERNET_MAC "BA:E5:E3:B1:44:DD"
#define ETHERNET_IP "192.168.1.15"
#define ETHERNET_RESET_PIN -1
#define ETHERNET_CS_PIN 5


bool shouldSaveConfig = false;

WiFiManager wm;

char ssid[32];
char pass[64];

//Khai báo biến
BluetoothSerial SerialBT;
String message = ""; 
char incomingChar; 

float temperature = 0; 
float humidity = 0; 
unsigned long previousMillisDHT = 0;
unsigned long previousMillisRTC = 0;  
const long interval = 2000; 

// khai bao mqtt
WebServer server(80);
const char* mqtt_server = "mqtt.eclipseprojects.io";
const char* mqtt_username = "";
const char* mqtt_password = "";
const int mqtt_port = 1883;
const int max_retry = 10;
static int curRetry = 0;
const int max_retry_mqtt = 10;
static int curRetryMqtt = 0;
unsigned long lastMsg = 0;
static int ethConnectRetry=0;
static int ethRetry=0;


WiFiClient wifiClient;
EthernetClient ethClient;
PubSubClient client;
const char* led_Topic = "controlLed";
const char* temp_humid_Topic = "TempAndHum";
const char* reboot_Topic="reboot";

#define MSG_BUFFER_SIZE (50)
char msg[MSG_BUFFER_SIZE];

RTC_DS1307 DS1307_RTC;
char Week_days[7][12] = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};

static const char* root_ca PROGMEM = R"EOF(
-----BEGIN CERTIFICATE-----
MIIFazCCA1OgAwIBAgIRAIIQz7DSQONZRGPgu2OCiwAwDQYJKoZIhvcNAQELBQAw
...=
-----END CERTIFICATE-----
)EOF";


void connectMQTT() {
  while (!client.connected()) {
      Serial.print("Attempting MQTT connection…");
      String clientId = "ESP32Client-";
      clientId += String(random(0xffff), HEX);
      curRetryMqtt++;
      if (curRetryMqtt > 5) {
        Serial.print("MQTT connection failed");
        curRetryMqtt=0;
        break;
      }
      if (client.connect(clientId.c_str(), mqtt_username, mqtt_password,"lastWillTopic",2,true,"Offline")) {
        Serial.println("connected MQTT");
        client.subscribe(led_Topic);
        client.subscribe(temp_humid_Topic);
        client.subscribe(reboot_Topic);
        delay(3000);
        client.publish("lastWillTopic","Online");
      } else {
        Serial.print("failed, rc=");
        Serial.print(client.state());
        Serial.println(" try again in 3 seconds");
        delay(3000);
    }
  }
}

void callbackMQTT(char* topic, byte* payload, unsigned int length) {
    String incommingMessage = "";
    for (int i = 0; i < length; i++) incommingMessage += (char)payload[i];
    Serial.println("Message arrived [" + String(topic) + "] " + incommingMessage);

    if (strcmp(topic, led_Topic) == 0) {
        if (incommingMessage.equals("ON")) {
            digitalWrite(LED_PIN, HIGH);
        }
        if (incommingMessage.equals("OFF")) {
            digitalWrite(LED_PIN, LOW);
        }
    }
    if (strcmp(topic, reboot_Topic) == 0) {
      ESP.restart();
    }
}

// cac ham lien quan den BLE
void processMessage(String msg) {
  if (msg == "led_on") {
    digitalWrite(LED_PIN, HIGH);
    SerialBT.println("LED is ON");
  } else if (msg == "led_off") {
    digitalWrite(LED_PIN, LOW);
    SerialBT.println("LED is OFF"); 
  }else if (msg=="reboot"){
    ESP.restart();
  } 
  else if (msg.startsWith("dhtTemp : ")) {
    String tempValue = msg.substring(10); 
    temperature = tempValue.toFloat(); 
    SerialBT.printf("Temperature received: %.2f\n", temperature);
  } else if (msg.startsWith("dhtHum : ")) {
    String humValue = msg.substring(9); 
    humidity = humValue.toFloat();
    SerialBT.printf("Humidity received: %.2f\n", humidity); 
  } 
  else {
    SerialBT.print("Received unknown command: "); 
    SerialBT.println(msg); 
  }
}

void handleBluetoothCommunication() {
  if (SerialBT.available()) { 
    char incomingChar = SerialBT.read(); 
    if (incomingChar != '\n') { 
      message += String(incomingChar); 
    } else { 
      processMessage(message);
      message = ""; 
    }
    Serial.write(incomingChar); 
  }
}

void handleSerialCommunication() {
  if (Serial.available() > 0) { 
    String serialMessage = ""; 
    while (Serial.available() > 0) { 
      char command = (byte)Serial.read(); 
      if (command == '\n') { 
        SerialBT.print("Serial message: "); 
        SerialBT.println(serialMessage); 
        processMessage(serialMessage); 
        serialMessage = ""; 
      } else {
        serialMessage += command; 
      }
      vTaskDelay(1 / portTICK_PERIOD_MS); 
    }
  }
}

void sendDHTValuesBLE() {
  unsigned long currentMillis = millis(); 
  if (currentMillis - previousMillisDHT >= interval) { 
    previousMillisDHT = currentMillis; 

    float temp = dht.readTemperature();
    float hum = dht.readHumidity();
    
    if (isnan(temp) || isnan(hum)) { 
      Serial.println("Failed to read from DHT sensor!"); 
      return; 
    }

    float temperature = (float)temp;
    float humidity = (float)hum;

    String data = "dhtTemp : " + String(temperature) + " / dhtHum : " + String(humidity);
    SerialBT.println(data);

    Serial.printf("Sent Data: %s\n", data.c_str());

  }
}

// cac ham lien quan den Ethernet
void macCharArrayToBytes(const char* str, byte* bytes) {
    for (int i = 0; i < 6; i++) {
        bytes[i] = strtoul(str, NULL, 16);
        str = strchr(str, ':');
        if (str == NULL || *str == '\0') {
            break;
        }
        str++;
    }
}
void connectEthernet() {
  byte* mac = new byte[6];
  macCharArrayToBytes(ETHERNET_MAC, mac);
  Ethernet.init(ETHERNET_CS_PIN);
  Ethernet.begin(mac,500,500);
  delay(1000);
  while(Ethernet.linkStatus()!=LinkON){
    Serial.print(".");
    delay(1000);
    ethRetry++;
    if(ethRetry>2){
      ethRetry=0;
      break;
    }
  }
  if(Ethernet.linkStatus()==LinkON){
    Serial.print("Ethernet IP is: ");
    Serial.println(Ethernet.localIP());
    // client.setClient(ethClient);
    // client.setKeepAlive(1); 
    // ethClient.setTimeout(1000); 
    // client.setServer(mqtt_server, mqtt_port);
    // client.setCallback(callbackMQTT);
    // connectMQTT();
  }else{
    Serial.println("Mat ket noi ethernet");
  }
}

// cac ham lien quan den ket noi WiFi
void saveConfigFile() {
  Serial.println(F("Saving configuration..."));
  StaticJsonDocument<512> json;
  
  File configFile = SPIFFS.open(JSON_CONFIG_FILE, "w");
  if (!configFile) {
    Serial.println("Failed to open config file for writing");
  }

  serializeJsonPretty(json, Serial);
  if (serializeJson(json, configFile) == 0) {
    Serial.println(F("Failed to write to file"));
  }
  configFile.close();
}

bool loadConfigFile() {
  Serial.println("Mounting File System...");

  if (SPIFFS.begin(false) || SPIFFS.begin(true)) {
    Serial.println("Mounted file system");
    if (SPIFFS.exists(JSON_CONFIG_FILE)) {
      Serial.println("Reading config file");
      File configFile = SPIFFS.open(JSON_CONFIG_FILE, "r");
      if (configFile) {
        Serial.println("Opened configuration file");
        StaticJsonDocument<512> json;
        DeserializationError error = deserializeJson(json, configFile);
        serializeJsonPretty(json, Serial);
        if (!error) {
          Serial.println("Parsing JSON");
          const char* savedSsid = json["ssid"];
          const char* savedPass = json["pass"];
          if (savedSsid && savedPass) {
            strncpy(ssid, savedSsid, sizeof(ssid));
            strncpy(pass, savedPass, sizeof(pass));
          }
          return true;
        } else {
          Serial.println("Failed to load JSON config");
        }
      }
    }
  } else {
    Serial.println("Failed to mount FS");
  }

  return false;
}

void saveConfigCallback() {
  Serial.println("Should save config");
  shouldSaveConfig = true;
}

void configModeCallback(WiFiManager *myWiFiManager) {
  Serial.println("Entered Configuration Mode");
  Serial.print("Config SSID: ");
  Serial.println(myWiFiManager->getConfigPortalSSID());
  Serial.print("Config IP Address: ");
  Serial.println(WiFi.softAPIP());

  if (ethConnectRetry==0){
    Serial.println(ethConnectRetry);
    byte* mac = new byte[6];
    macCharArrayToBytes(ETHERNET_MAC, mac);
    Ethernet.init(ETHERNET_CS_PIN);
    // Ethernet.begin(mac);
    delay(1000);
    // Serial.print("Ethernet IP is: ");
    // Serial.println(Ethernet.localIP());
    ethConnectRetry++;
  }
}

//set up WiFi
void setupWiFi(){
  bool forceConfig = false;
  bool spiffsSetup = loadConfigFile();
  if (!spiffsSetup) {
    Serial.println(F("Forcing config mode as there is no saved config"));
    forceConfig = true;
  }

  WiFi.mode(WIFI_STA);

  // Uncomment to clear saved WiFi settings
  wm.resetSettings();

  wm.setSaveConfigCallback(saveConfigCallback);
  wm.setAPCallback(configModeCallback);

  if (forceConfig) {
    if (!wm.startConfigPortal("NEWTEST_AP_1", "1234567890")) {
      Serial.println("Failed to connect and hit timeout");
    }
  } else {
    if (!wm.autoConnect("NEWTEST_AP_1", "1234567890")) {
      Serial.println("Failed to connect and hit timeout");
    }
  }

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());

  strncpy(ssid, wm.getWiFiSSID().c_str(), sizeof(ssid));
  strncpy(pass, wm.getWiFiPass().c_str(), sizeof(pass));
  Serial.print("SSID: ");
  Serial.println(ssid);
  Serial.print("Password: ");
  Serial.println(pass);

  if (shouldSaveConfig) {
    saveConfigFile();
  }
}

//danh sach cac task
// Task Reconnect Internet
void TaskReconnectInternet(void *pvParameters)
{
  for(;;){
    if( WiFi.status() == WL_CONNECTED || Ethernet.linkStatus() == LinkON )
    {
      Serial.println(".Internet");
      vTaskDelay(10000 / portTICK_PERIOD_MS);
    }
    if( WiFi.status() != WL_CONNECTED && Ethernet.linkStatus() != LinkON ){
      Serial.println("WiFi lost connection. Attempting to reconnect...");
      // Cố gắng kết nối lại WiFi
      WiFi.begin(ssid, pass);
      vTaskDelay(5000 / portTICK_PERIOD_MS);
      Serial.println("");
      Serial.print("WiFi IP: ");
      Serial.println(WiFi.localIP());
      // ko kết nối lại được WiFi sẽ cố gắng kết nối Ethernet
      while (WiFi.status() != WL_CONNECTED && Ethernet.linkStatus() != LinkON ) {
        byte* mac = new byte[6];
        macCharArrayToBytes(ETHERNET_MAC, mac);
        Ethernet.init(ETHERNET_CS_PIN);
        Ethernet.begin(mac);
        vTaskDelay(1000/portTICK_RATE_MS);
        while(Ethernet.linkStatus()!=LinkON){
          Serial.print(".");
          vTaskDelay(1000/portTICK_RATE_MS);
          ethRetry++;
          if(ethRetry>2){
            ethRetry=0;
            break;
          }
        }
        if(Ethernet.linkStatus()==LinkON){
          Serial.print("Ethernet IP is: ");
          Serial.println(Ethernet.localIP());
          // client.setClient(ethClient);
          // client.setKeepAlive(1); 
          // ethClient.setTimeout(1000); 
          // client.setServer(mqtt_server, mqtt_port);
          // client.setCallback(callbackMQTT);
          // connectMQTT();
        }else{
          Serial.println("Mat ket noi ethernet");
        }
        vTaskDelay(5000 / portTICK_PERIOD_MS);
      }

      // Nếu WiFi đã kết nối, cấu hình và kết nối đến MQTT
      // if (WiFi.status() == WL_CONNECTED) {
        // wifiClient.setTimeout(1000); // Đặt thời gian chờ cho WiFi client
        // client.setClient(wifiClient); // Đặt WiFi client cho MQTT client
        // client.setKeepAlive(1); // Đặt khoảng thời gian keep-alive cho MQTT client
        // client.setServer(mqtt_server, mqtt_port); // Đặt máy chủ và cổng MQTT
        // client.setCallback(callbackMQTT); // Đặt hàm callback cho MQTT
        // connectMQTT(); // Kết nối đến máy chủ MQTT
      // }
    } 
  }
}



// Task Button controlLed
void TaskButtonLed(void *pvParameters) {
  // button control LED
  pinMode(BUTTON_PIN, INPUT_PULLUP);
  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW); // Initialize LED to ON
  button_state = digitalRead(BUTTON_PIN);
  for(;;) {
    last_button_state = button_state;      // save the last state
    button_state = digitalRead(BUTTON_PIN); // read new state

    if (last_button_state == HIGH && button_state == LOW) {
      Serial.println("The button is pressed");
      // toggle state of LED
      led_state = !led_state;
      // control LED according to the toggled state
      digitalWrite(LED_PIN, led_state);
      // Send message over MQTT if WiFi is connected
      if (WiFi.status() == WL_CONNECTED || Ethernet.linkStatus() == LinkON) {
        if (led_state == LOW) {
          client.publish(led_Topic, "OFF");
        } else {
          client.publish(led_Topic, "ON");
        }
      }
    }
    vTaskDelay(20 / portTICK_PERIOD_MS); // Small delay to avoid button bouncing
  }
}

// Task BLE
void TaskBlE(void *pvParameters) {
  for (;;) {
    handleBluetoothCommunication(); 
    handleSerialCommunication(); 
    sendDHTValuesBLE();
    vTaskDelay(4000 / portTICK_PERIOD_MS);
  }
}

// task RTC_DS1307
void TaskRTC(void *pvParameters) {
  DS1307_RTC.begin();
  DS1307_RTC.adjust(DateTime(F(__DATE__), F(__TIME__)));
  for (;;) {
    DateTime nowRTC = DS1307_RTC.now();

    Serial.print(nowRTC.year(), DEC);
    Serial.print('/');
    Serial.print(nowRTC.month(), DEC);
    Serial.print('/');
    Serial.print(nowRTC.day(), DEC);
    Serial.print(" (");
    Serial.print(Week_days[nowRTC.dayOfTheWeek()]);
    Serial.print(") ");
    Serial.print(nowRTC.hour(), DEC);
    Serial.print(':');
    Serial.print(nowRTC.minute(), DEC);
    Serial.print(':');
    Serial.print(nowRTC.second(), DEC);
    Serial.println();
    vTaskDelay(4000 / portTICK_PERIOD_MS); // Small delay to avoid button bouncing
  }
}



void setup() {
  Serial.begin(115200);
  delay(10);
  dht.begin();

  //RTC
  xTaskCreatePinnedToCore(
    TaskRTC,
    "RTC Task",
    2048 ,
    NULL,
    2,
    NULL,
    ARDUINO_RUNNING_CORE // Core on which the task will run
  );

  //BLE
  SerialBT.begin("ESP32_Bluetooth"); 
  Serial.println("The device started, now you can pair it with Bluetooth!"); 
  xTaskCreatePinnedToCore(
    TaskBlE,
    "Ble Task",
    2048 ,
    NULL,
    2,
    NULL,
    ARDUINO_RUNNING_CORE // Core on which the task will run
  );

  // Create task for LED blinking
  xTaskCreatePinnedToCore(
    TaskButtonLed,
    "Task Button Control Led",   // Name for humans
    2048,  // Stack size in bytes
    NULL,
    2,  // Priority
    NULL,
    ARDUINO_RUNNING_CORE // Core on which the task will run
  );


  setupWiFi();
  if(WiFi.status() == WL_CONNECTED){
    client.setClient(wifiClient);
    client.setKeepAlive(1); 
    wifiClient.setTimeout(1000); 
    client.setServer(mqtt_server, mqtt_port);
    client.setCallback(callbackMQTT);
    connectMQTT();
  }
  // Create Task Reconnect Internet
  xTaskCreatePinnedToCore(
    TaskReconnectInternet,
    "Task Reconnect Internet",   // Name for humans
    4096,  // Stack size in bytes
    NULL,
    2,  // Priority
    NULL,
    ARDUINO_RUNNING_CORE // Core on which the task will run
  );
}

void loop() {
  // // Check both WiFi and Ethernet connection statuses
  if(WiFi.status() != WL_CONNECTED && ethConnectRetry<2){
    connectEthernet();
    ethConnectRetry++;
  }
  if (WiFi.status() == WL_CONNECTED || Ethernet.linkStatus() == LinkON) {
    client.loop();
  }

  // Send data to MQTT at intervals
  unsigned long now = millis();
  if (now - lastMsg > 3000) {
    lastMsg = now;
    float temp = dht.readTemperature();
    float humid = dht.readHumidity();

    String data = String(temp, 2) + "-" + String(humid, 2);

    if (client.connected()) {
      client.publish(temp_humid_Topic, data.c_str());
      client.publish("dhtTemp", String(temp).c_str());
      client.publish("dhtHum", String(humid).c_str());
    } else {
      Serial.println("Mat ket noi server");
      if(WiFi.status() == WL_CONNECTED){
        client.setClient(wifiClient);
        client.setKeepAlive(1); 
        wifiClient.setTimeout(1000); 
        client.setServer(mqtt_server, mqtt_port);
        client.setCallback(callbackMQTT);
      } else if ( Ethernet.linkStatus() == LinkON) {
        client.setClient(ethClient);
        client.setKeepAlive(1); 
        ethClient.setTimeout(1000); 
        client.setServer(mqtt_server, mqtt_port);
        client.setCallback(callbackMQTT);
      }
      connectMQTT();
    }
  delay(200);
  }
}

