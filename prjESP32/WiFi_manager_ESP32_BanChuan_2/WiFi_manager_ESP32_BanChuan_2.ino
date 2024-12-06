#define ESP_DRD_USE_SPIFFS true
#if CONFIG_FREERTOS_UNICORE
#define ARDUINO_RUNNING_CORE 0
#else
#define ARDUINO_RUNNING_CORE 1
#endif

// Include Libraries
#include <WiFi.h>
#include <FS.h>
#include <SPIFFS.h>
#include <WiFiManager.h>
#include <ArduinoJson.h>
#include <WebServer.h>

// Task declaration
void TaskBlink(void *pvParameters);
#define Led_Pin 2

// JSON configuration file
#define JSON_CONFIG_FILE "/test_config.json"

// Flag for saving data
bool shouldSaveConfig = false;

// Define WiFiManager Object
WiFiManager wm;

// Define WebServer Object on port 80
WebServer server(80);

// Timing variables for non-blocking LED blinking
unsigned long previousMillis = 0;
const long interval = 500;  // Interval at which to blink (milliseconds)
bool ledState = LOW;        // Current state of the LED

// Save the configuration file to SPIFFS
void saveConfigFile() {
  Serial.println(F("Saving configuration..."));

  StaticJsonDocument<512> json;
  File configFile = SPIFFS.open(JSON_CONFIG_FILE, "w");
  if (!configFile) {
    Serial.println("Failed to open config file for writing");
    return;
  }

  serializeJsonPretty(json, Serial);
  if (serializeJson(json, configFile) == 0) {
    Serial.println(F("Failed to write to file"));
  }

  configFile.close();
}

// Load the configuration file from SPIFFS
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

// WiFiManager Callbacks
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
}

void setupWiFi() {
  // Load configuration from SPIFFS
  if (!loadConfigFile()) {
    Serial.println(F("Forcing config mode as there is no saved config"));
  }

  WiFi.mode(WIFI_STA);

  // Uncomment to clear saved WiFi settings
  wm.resetSettings();

  wm.setSaveConfigCallback(saveConfigCallback);
  wm.setAPCallback(configModeCallback);

  if (!wm.autoConnect("ESP32_Manager_AP", "1234567890")) {
    Serial.println("Failed to connect and hit timeout");
  }

  Serial.println("WiFi connected");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());

  if (shouldSaveConfig) {
    saveConfigFile();
  }
}

// Reconnect WiFi
void WiFiStationDisconnected(WiFiEvent_t event, WiFiEventInfo_t info) {
  Serial.println("Disconnected from WiFi access point");
  Serial.print("WiFi lost connection. Reason: ");
  Serial.println(info.wifi_sta_disconnected.reason);
  Serial.println("Trying to Reconnect");
  if (!loadConfigFile()) {
    Serial.println(F("Forcing config mode as there is no saved config"));
  }
  WiFi.mode(WIFI_STA);
  wm.setSaveConfigCallback(saveConfigCallback);
  Serial.print("WiFi IP address: ");
  Serial.println(WiFi.localIP());
  if (shouldSaveConfig) {
    saveConfigFile();
  }
}

// Create task for LED blinking
void TaskBlink(void *pvParameters) {
  pinMode(Led_Pin, OUTPUT);
  // Code here runs once like setup()
  for (;;) {
    // Code here runs repeatedly like loop()
    digitalWrite(Led_Pin, HIGH);
    vTaskDelay(1000 / portTICK_PERIOD_MS);
    digitalWrite(Led_Pin, LOW);
    vTaskDelay(1000 / portTICK_PERIOD_MS);
  }
}

void setup() {
  Serial.begin(115200);
  delay(10);
  
  // Create task for LED blinking
  xTaskCreate(
    TaskBlink,
    "TaskBlink",   // Name for humans
    2048,  // Stack size in bytes
    NULL,
    2,  // Priority
    NULL
  );

  // Start WiFi setup
  setupWiFi();
  WiFi.onEvent(WiFiStationDisconnected, WiFiEvent_t::ARDUINO_EVENT_WIFI_STA_DISCONNECTED);
}

void loop() {
  // Empty loop
  delay(1000);
}
