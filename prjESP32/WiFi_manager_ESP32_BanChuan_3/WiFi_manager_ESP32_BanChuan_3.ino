#include <WiFi.h>
#include <FS.h>
#include <SPIFFS.h>
#include <WiFiManager.h>
#include <ArduinoJson.h>

#define JSON_CONFIG_FILE "/test_config.json"
#define ESP_DRD_USE_SPIFFS true

bool shouldSaveConfig = false;

WiFiManager wm;

char ssid[32];
char pass[64];

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
}

void setupWiFi(){
  bool forceConfig = false;
  bool spiffsSetup = loadConfigFile();
  if (!spiffsSetup) {
    Serial.println(F("Forcing config mode as there is no saved config"));
    forceConfig = true;
  }

  WiFi.mode(WIFI_STA);

  // Uncomment to clear saved WiFi settings
  // wm.resetSettings();

  wm.setSaveConfigCallback(saveConfigCallback);
  wm.setAPCallback(configModeCallback);

  if (forceConfig) {
    if (!wm.startConfigPortal("NEWTEST_AP", "1234567890")) {
      Serial.println("Failed to connect and hit timeout");
    }
  } else {
    if (!wm.autoConnect("NEWTEST_AP", "1234567890")) {
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

void reconnectWiFi(){
  Serial.println("WiFi lost connection. Attempting to reconnect...");
  WiFi.begin(ssid, pass);
  delay(3000);
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("Reconnected to WiFi");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
}

void setup() {
  Serial.begin(115200);
  delay(10);
  setupWiFi();
}

void loop() {
  if (WiFi.status() != WL_CONNECTED) {
    reconnectWiFi();
  }
}
