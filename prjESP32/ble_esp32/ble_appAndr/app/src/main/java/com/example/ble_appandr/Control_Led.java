package com.example.ble_appandr;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothGatt;
import android.bluetooth.BluetoothGattCallback;
import android.bluetooth.BluetoothGattCharacteristic;
import android.bluetooth.BluetoothGattService;
import android.bluetooth.BluetoothManager;
import android.bluetooth.BluetoothProfile;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;
import android.widget.Toast;

import java.util.UUID;

public class Control_Led extends Activity {

    private static final String TAG = "Control_Led";
    private BluetoothAdapter mBluetoothAdapter;
    private BluetoothGatt mGatt;
    private String deviceAddress;
    private BluetoothGattCharacteristic characteristic;
    private Button buttonON, buttonOFF, buttonDIS;

    private static final String SERVICE_UUID = "19b10000-e8f2-537e-4f6c-d104768a1214";
    private static final String LED_CHARACTERISTIC_UUID = "19b10002-e8f2-537e-4f6c-d104768a1214";

    private long lastToastTime = 0;
    private static final long TOAST_INTERVAL = 2000; // 2 seconds

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.control_led);

        // Get the device address from the intent
        Intent intent = getIntent();
        deviceAddress = intent.getStringExtra(MainActivity.EXTRA_ADDRESS);

        final BluetoothManager bluetoothManager =
                (BluetoothManager) getSystemService(Context.BLUETOOTH_SERVICE);
        mBluetoothAdapter = bluetoothManager.getAdapter();

        buttonON = findViewById(R.id.buttonON);
        buttonOFF = findViewById(R.id.buttonOFF);
        buttonDIS = findViewById(R.id.buttonDIS);

        // Connect to the device
        BluetoothDevice device = mBluetoothAdapter.getRemoteDevice(deviceAddress);
        mGatt = device.connectGatt(this, false, gattCallback);

        // Set button click listeners
        buttonON.setOnClickListener(v -> writeCharacteristic((byte) 1));
        buttonOFF.setOnClickListener(v -> writeCharacteristic((byte) 0));
        buttonDIS.setOnClickListener(v -> {
            disconnect();
            close();
        });
    }

    private final BluetoothGattCallback gattCallback = new BluetoothGattCallback() {
        @Override
        public void onConnectionStateChange(BluetoothGatt gatt, int status, int newState) {
            if (newState == BluetoothProfile.STATE_CONNECTED) {
                Log.i(TAG, "Connected to GATT server.");
                gatt.discoverServices();
            } else if (newState == BluetoothProfile.STATE_DISCONNECTED) {
                Log.i(TAG, "Disconnected from GATT server.");
                runOnUiThread(() -> showToast("Disconnected from GATT server"));
                finish(); // Close the activity when disconnected
            }
        }

        @Override
        public void onServicesDiscovered(BluetoothGatt gatt, int status) {
            if (status == BluetoothGatt.GATT_SUCCESS) {
                Log.i(TAG, "Services discovered.");
                // Get all services and log their UUIDs
                for (BluetoothGattService service : gatt.getServices()) {
                    Log.i(TAG, "Service UUID: " + service.getUuid().toString());
                }
                BluetoothGattService service = gatt.getService(UUID.fromString(SERVICE_UUID));
                if (service != null) {
                    characteristic = service.getCharacteristic(UUID.fromString(LED_CHARACTERISTIC_UUID));
                    if (characteristic == null) {
                        Log.e(TAG, "LED Characteristic not found.");
                    } else {
                        Log.i(TAG, "LED Characteristic found.");
                    }
                } else {
                    Log.e(TAG, "Service not found.");
                }
            } else {
                Log.w(TAG, "onServicesDiscovered received: " + status);
            }
        }

        @Override
        public void onCharacteristicWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status) {
            super.onCharacteristicWrite(gatt, characteristic, status);
            Log.i(TAG, "Characteristic write status: " + status);
            runOnUiThread(() -> showToast("Write Status: " + (status == BluetoothGatt.GATT_SUCCESS ? "Success" : "Failed")));
        }
    };

    private void writeCharacteristic(byte value) {
        if (characteristic != null) {
            characteristic.setValue(new byte[]{value});
            boolean result = mGatt.writeCharacteristic(characteristic);
            if (!result) {
                Log.e(TAG, "Failed to write characteristic");
                showToast("Failed to write characteristic");
            }
        } else {
            Log.e(TAG, "Characteristic is null");
            showToast("Characteristic not found");
        }
    }

    private void disconnect() {
        if (mGatt == null) {
            Log.w(TAG, "BluetoothGatt not initialized");
            return;
        }

        mGatt.disconnect();

    }

    private void close() {
        if (mGatt == null) {
            return;
        }
        mGatt.close();
        mGatt = null;
    }

    private void showToast(String message) {
        long currentTime = System.currentTimeMillis();
        if (currentTime - lastToastTime >= TOAST_INTERVAL) {
            Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
            lastToastTime = currentTime;
        }
    }
}
