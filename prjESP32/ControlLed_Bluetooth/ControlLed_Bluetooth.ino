#include <BluetoothSerial.h>

const int ledPin = 2; 

// Bluetooth configuration
BluetoothSerial SerialBT;
String message = "";

void setup() {
  pinMode(ledPin, OUTPUT);  // Set the LED pin as an output

  // Start Serial and Bluetooth
  Serial.begin(115200);
  SerialBT.begin("ESP32_bluetooth");
  Serial.println("ESP32_bluetooth\n");
  Serial.println("The device started, now you can pair it with Bluetooth!");
}

void loop() {
  ControlLed();
}

void processMessage(String msg) {
  if (msg == "led_on") {
    // Turn on the LED
    digitalWrite(ledPin, HIGH); // LED on
  } else if (msg == "led_off") {
    // Turn off the LED
    digitalWrite(ledPin, LOW); // LED off
  }
}

void ControlLed() {
  // Read received messages from Bluetooth
  if (SerialBT.available()) {
    char incomingChar = SerialBT.read();
    if (incomingChar != '\n') {
      message += String(incomingChar);
    } else {
      processMessage(message);
      message = "";
    }
    Serial.write(incomingChar);  // Debug: Echo received characters to Serial Monitor
  }

  // Optional: Read from Serial monitor if needed
  if (Serial.available() > 0) {
    String serialMessage = "";
    while (Serial.available() > 0) {
      char command = (byte)Serial.read();
      if (command == ':') {
        break;
      } else {
        serialMessage += command;
      }
      delay(1);
    }
    processMessage(serialMessage);
  }
  delay(20);
}
