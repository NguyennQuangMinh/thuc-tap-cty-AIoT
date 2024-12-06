#define ESP_DRD_USE_SPIFFS true

// Include Libraries
#include <WiFi.h>
#include <FS.h>
#include <SPIFFS.h>
#include <WiFiManager.h>
#include <ArduinoJson.h>
#include <WebServer.h>

// JSON configuration file
#define JSON_CONFIG_FILE "/test_config.json"

// Flag for saving data
bool shouldSaveConfig = false;

// Define WiFiManager Object
WiFiManager wm;

// Define WebServer Object on port 80
WebServer server(80);

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

// Web server handlers
void handleRoot() {
  server.send(200, "text/plain", "Hello, this is the root page. Use /led/on or /led/off to control the LED.");
}

void handleLedOn() {
  digitalWrite(2, HIGH);
  server.send(200, "text/plain", "LED is ON");
}

void handleLedOff() {
  digitalWrite(2, LOW);
  server.send(200, "text/plain", "LED is OFF");
}

void setupWiFi() {
  // Load configuration from SPIFFS
  if (!loadConfigFile()) {
    Serial.println(F("Forcing config mode as there is no saved config"));
  }

  WiFi.mode(WIFI_STA);

  // Uncomment to clear saved WiFi settings
  // wm.resetSettings();

  wm.setSaveConfigCallback(saveConfigCallback);
  wm.setAPCallback(configModeCallback);

  if (!wm.autoConnect("ESP32_Manager_AP", "1234567890")) {
    Serial.println("Failed to connect and hit timeout");
    delay(3000);
    ESP.restart();
    delay(5000);
  }

  Serial.println("WiFi connected");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());

  if (shouldSaveConfig) {
    saveConfigFile();
  }
}

void CheckingWiFiStatus() {
  static unsigned long lastCheck = 0;
  unsigned long interval = 8000; // 8 seconds interval

  if (millis() - lastCheck >= interval) {
    lastCheck = millis();
    // Kiểm tra trạng thái kết nối WiFi
    if (WiFi.status() != WL_CONNECTED) {
      Serial.println("WiFi connection lost. Reconnecting...");
      // Thử kết nối lại WiFi
      if (!wm.autoConnect("ESP32_Manager_AP", "1234567890")) {
        Serial.println("Failed to reconnect. Restarting...");
        delay(3000);
        ESP.restart();
        delay(5000);
      }
    } else {
      Serial.println("WiFi connected");
      Serial.print("IP address: ");
      Serial.println(WiFi.localIP());
    }
  }
}

void setupWebServer() {
  // Setup pin 2 as output for LED
  pinMode(2, OUTPUT);

  // Setup web server routes
  server.on("/", handleRoot);
  server.on("/led/on", handleLedOn);
  server.on("/led/off", handleLedOff);

  // Start the web server
  server.begin();
}

void setup() {
  Serial.begin(115200);
  delay(10);

  setupWiFi();
  setupWebServer();
}

void loop() {
  server.handleClient();
  CheckingWiFiStatus();
}
