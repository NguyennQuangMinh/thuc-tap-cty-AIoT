package com.example.hivemqtt;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import android.Manifest;
import android.app.DatePickerDialog;
import android.app.ProgressDialog;
import android.app.TimePickerDialog;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import com.example.hivemqtt.dht.auto.LuuDuLieuHenGio.DatabaseHenGio;
import com.example.hivemqtt.dht.auto.LuuDuLieuHenGio.DuLieuHenGio;
import com.example.hivemqtt.dht.auto.SetAutoTime;
import com.example.hivemqtt.dht.auto.SetAutoTimeDatabase;
import com.example.hivemqtt.dht.ble.ListBle;
import com.example.hivemqtt.dht.dht;
import com.example.hivemqtt.dht.dhtDatabase;
import com.hivemq.client.mqtt.MqttClient;
import com.hivemq.client.mqtt.MqttClientState;
import com.hivemq.client.mqtt.datatypes.MqttQos;
import com.hivemq.client.mqtt.mqtt3.Mqtt3AsyncClient;

import java.io.IOException;
import java.io.InputStream;
import java.nio.charset.StandardCharsets;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.UUID;

public class MainActivity extends AppCompatActivity {
    private static final int MY_PERMISSIONS_REQUEST_BLUETOOTH = 1;
    ImageButton ImgBle,ImgMqtt,ImgReload;
    Mqtt3AsyncClient mqtt3AsyncClient;
    EditText edNhietdo, edDoam;
    ImageView img;
    Switch autoSwitch;
    Button buttonDate, ButtonTime, btAdd, btShowList, btLine, btshowdht,btDisBle;
    CheckBox autoCheckBox;
    TextView tvLed, tvNhietdo, tvDoAm, tvsetDate, tvsetTime, tvauto;
    boolean isConnected = false;
    boolean isConnectedBle = false;

    boolean isCheckBoxChecked = false;
    private static int autoIncrementId = 0;
    boolean isLedOn = false;
    SetAutoTimeDatabase setAutoTimeDatabase = new SetAutoTimeDatabase(this);
    dhtDatabase dhtDatabase = new dhtDatabase(this);
    DatabaseHenGio databaseHenGio = new DatabaseHenGio(this);

    private String previousHumidity = "";
    private String previousTemperature = "";
    private String receivedHumidity = "";
    private String receivedTemperature = "";
    private String Notification = "";
    private Handler handler;

    String address = null;
    private ProgressDialog progress;
    BluetoothAdapter myBluetooth = null;
    BluetoothSocket btSocket = null;
    private boolean isBtConnected = false;
    static final UUID myUUID = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB");


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        if (getSupportActionBar() != null) {
            getSupportActionBar().setDisplayShowCustomEnabled(true);
            getSupportActionBar().setCustomView(R.layout.custom_action_bar);
        }
        //Ble
        Intent newint = getIntent();
        address = newint.getStringExtra(ListBle.EXTRA_ADDRESS);
        isConnectedBle = newint.getBooleanExtra("Bool", false);
        Log.d("Bluetooth", "Received BLE address: " + address + " Is Connected: " + isConnectedBle);
        new ConnectBT().execute();

        initView();
        // Lên lịch để phương thức checkAutoTime chạy định kỳ
        handler = new Handler();
        Runnable runnable = new Runnable() {
            @Override
            public void run() {
                checkAutoTime();
                handler.postDelayed(this, 30000);
            }
        };
        handler.post(runnable);

        autoSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    tvLed.setText("On");
                    // Chỉ gửi dữ liệu qua MQTT nếu đã kết nối
                    if (isConnected) {
                        sendData("/topic/qos0", "ON");
                    } else {
                        // Thông báo cho người dùng nếu MQTT chưa kết nối
                        Log.d("MQTT", "MQTT client chưa kết nối, bỏ qua gửi dữ liệu MQTT");
                        Toast.makeText(MainActivity.this, "MQTT client chưa kết nối, đã bỏ qua gửi dữ liệu MQTT", Toast.LENGTH_SHORT).show();
                    }
                    if (btSocket != null) {
                        try {
                            btSocket.getOutputStream().write("led_on\n".getBytes());
                        } catch (IOException e) {
                            msg("Error");
                        }
                    }
                } else {
                    tvLed.setText("Off");
                    if (isConnected) {
                        sendData("/topic/qos0", "OFF");
                    } else {
                        // Thông báo cho người dùng nếu MQTT chưa kết nối
                        Log.d("MQTT", "MQTT client chưa kết nối, bỏ qua gửi dữ liệu MQTT");
                        Toast.makeText(MainActivity.this, "MQTT client chưa kết nối, đã bỏ qua gửi dữ liệu MQTT", Toast.LENGTH_SHORT).show();
                    }
                    if (btSocket != null) {
                        try {
                            btSocket.getOutputStream().write("led_off\n".getBytes());
                        } catch (IOException e) {
                            msg("Error");
                        }
                    }
                }
            }
        });

        ButtonTime.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Calendar calendar = Calendar.getInstance();
                int hour = calendar.get(Calendar.HOUR);
                int minute = calendar.get(Calendar.MINUTE);

                TimePickerDialog timePickerDialog = new TimePickerDialog(MainActivity.this, new TimePickerDialog.OnTimeSetListener() {
                    @Override
                    public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                        tvsetTime.setText(String.format("%d:%d", hourOfDay, minute));
                    }
                }, hour, minute, true);
                timePickerDialog.show();
            }
        });

        buttonDate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Calendar calendar = Calendar.getInstance();

                int year01 = calendar.get(Calendar.YEAR);
                int month01 = calendar.get(Calendar.MONTH);
                int day01 = calendar.get(Calendar.DAY_OF_MONTH);

                DatePickerDialog datePickerDialog = new DatePickerDialog(MainActivity.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                        tvsetDate.setText(String.format("%d/%d/%d", dayOfMonth, month + 1, year));
                    }
                }, year01, month01, day01);
                datePickerDialog.show();
            }
        });

        btLine.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(MainActivity.this, LineChartDHT.class);
                startActivity(intent);
            }

        });
        btAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String date = tvsetDate.getText().toString().trim();
                String time = tvsetTime.getText().toString().trim();
                if (!date.isEmpty() && !time.isEmpty()) {
                    int currentId = ++autoIncrementId;
                    SetAutoTime setAutoTime = new SetAutoTime(currentId,date,time);
                    setAutoTimeDatabase.addAuto(setAutoTime);
                    tvsetDate.setText("");
                    tvsetTime.setText("");
                } else {
                    Toast.makeText(MainActivity.this, "Vui lòng điền đầy đủ thông tin.", Toast.LENGTH_SHORT).show();
                }
            }
        });
        btShowList.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, ShowList.class);
                startActivity(intent);
            }
        });
//        btshowdht.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                Intent intent = new Intent(MainActivity.this, LishDht.class);
//                startActivity(intent);
//            }
//        });
        autoCheckBox.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    String editNhietDo = edNhietdo.getText().toString();
                    String editDoAm = edDoam.getText().toString();
                    if (editNhietDo.isEmpty() || editDoAm.isEmpty()) {
                        Toast.makeText(MainActivity.this, "Vui lòng nhập giá trị ngưỡng nhiệt độ và độ ẩm.", Toast.LENGTH_SHORT).show();
                        autoCheckBox.setChecked(false);
                        return;
                    }
                    isCheckBoxChecked = true;
                    edNhietdo.setEnabled(false);
                    edDoam.setEnabled(false);
                    edNhietdo.setFocusable(false);
                    edDoam.setFocusable(false);
                    try {
                        tvauto.setText("auto mode");
                        String humidityStr = tvDoAm.getText().toString();
                        String temperatureStr = tvNhietdo.getText().toString();

                        float humidity = Float.parseFloat(humidityStr);
                        float temperature = Float.parseFloat(temperatureStr);
                        float nhietDoed = Float.parseFloat(editNhietDo);
                        float doAmed = Float.parseFloat(editDoAm);

                        if (temperature > nhietDoed || humidity > doAmed) {
                            sendData("/topic/qos0", "ON");
                            autoSwitch.setChecked(true);
                            tvLed.setText("On");
                            isLedOn = true;
                        } else {
//                            reference.child("Led").setValue("Off");
//                            autoSwitch.setChecked(false);
//                            tvLed.setText("Off");
//                            isLedOn = false;
                        }
                    } catch (NumberFormatException e) {
                        Log.e("Hivemq", "Giá trị nhiệt độ hoặc độ ẩm không hợp lệ", e);
                    }
                } else {
                    isCheckBoxChecked = false;
                    tvauto.setText("not auto");
                    edNhietdo.setEnabled(true);
                    edDoam.setEnabled(true);
                    edNhietdo.setFocusable(true);
                    edDoam.setFocusable(true);
                    edNhietdo.setFocusableInTouchMode(true);
                    edDoam.setFocusableInTouchMode(true);
                    if (isLedOn) {
                        new AlertDialog.Builder(MainActivity.this)
                                .setTitle("Thông báo")
                                .setMessage("Đèn đang trạng thái Bật, bạn có muốn tắt đi không?")
                                .setPositiveButton("Có", new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int which) {
                                        sendData("/topic/qos0", "OFF");
                                        autoSwitch.setChecked(false);
                                        tvLed.setText("Off");
                                        edNhietdo.setText("");
                                        edDoam.setText("");
                                        isLedOn = false;
                                    }
                                })
                                .setNegativeButton("Không", null)
                                .show();
                    }
                    else {
                        edNhietdo.setText("");
                        edDoam.setText("");
                    }
                }
            }
        });
        btDisBle.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Disconnect();
            }
        });
        ImgBle.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this, ListBle.class);
                startActivity(intent);
            }
        });
        ImgMqtt.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!isConnected) {
                    ImgMqtt.setImageResource(R.drawable.cloud_connect);
                    connectToMQTT();
                } else {
                    disconnectFromMQTT();
                    ImgMqtt.setImageResource(R.drawable.cloud_not_connect);
                }
            }
        });
        ImgReload.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(isConnectedBle == true || isConnected == true){
                    if(isConnected == true){
                        sendData("reboot","reboot");
                        Log.d("Reload","Đã gửi tín hiệu qua Mqtt");
                    }
                    else if (isConnectedBle == true){
                        if (btSocket != null) {
                            Log.d("Reload","Đã gửi tín hiệu qua Ble");
                            try {
                                btSocket.getOutputStream().write("reboot\n".getBytes());
                            } catch (IOException e) {
                                msg("Error");
                            }
                        }
                    }
                    else if (isConnected && isConnectedBle){
                        sendData("reboot","reboot");
                        if (btSocket != null) {
                            try {
                                btSocket.getOutputStream().write("reboot\n".getBytes());
                            } catch (IOException e) {
                                msg("Error");
                            }
                        }
                        Log.d("Reload","Đã gửi tín hiệu qua Ble và mqtt");

                    }
                }
                else {
                    Log.d("Reload","Chưa connect Ble hoặc Mqtt");
                    Toast.makeText(MainActivity.this,"Chưa connect Ble hoặc Mqtt",Toast.LENGTH_SHORT).show();
                }
            }
        });
    }
    public void add() {
        dht lastDht = dhtDatabase.getLastDht();
        if (lastDht != null) {
            // Nếu lần đầu nhận dữ liệu, lưu dữ liệu trước đó
            previousHumidity = String.valueOf(lastDht.getDhtDoAm());
            previousTemperature = String.valueOf(lastDht.getDhtNhietDo());

            Log.d("Hivemq", "Độ ẩm trước: " + previousHumidity);
            Log.d("Hivemq", "Nhiệt độ trước: " + previousTemperature);
        }

        float humidity = 0;
        float temperature = 0;

        try {
            humidity = Float.parseFloat(receivedHumidity);
            temperature = Float.parseFloat(receivedTemperature);
        } catch (NumberFormatException e) {
            Log.e("Hivemq", "Dữ liệu nhận không hợp lệ", e);
            return;
        }

        Log.d("Add", "Độ ẩm hiện tại: " + humidity);
        Log.d("Add", "Nhiệt độ hiện tại: " + temperature);
        Log.d("Add", "Độ ẩm trước khi so sánh: " + previousHumidity);
        Log.d("Add", "Nhiệt độ trước khi so sánh: " + previousTemperature);

        float prevHumidity = 0;
        float prevTemperature = 0;

        try {
            prevHumidity = Float.parseFloat(previousHumidity);
            prevTemperature = Float.parseFloat(previousTemperature);
        } catch (NumberFormatException e) {
            Log.e("Hivemq", "Dữ liệu trước không hợp lệ", e);
        }

        if (humidity != prevHumidity || temperature != prevTemperature) {
            // Chỉ thêm mục mới nếu có thay đổi
            dht newDht = new dht(temperature, humidity);
            dhtDatabase.addlistDht(newDht);
            previousHumidity = String.valueOf(humidity);
            previousTemperature = String.valueOf(temperature);
//            Toast.makeText(MainActivity.this, "Thêm thành công", Toast.LENGTH_SHORT).show();
            Log.d("Hivemq", "Dữ liệu mới được thêm: Độ ẩm: " + humidity + ", Nhiệt độ: " + temperature);

            String editNhietDo = edNhietdo.getText().toString();
            String editDoAm = edDoam.getText().toString();

            if (isCheckBoxChecked) {
                Log.d("Hivemq", "Hộp kiểm được chọn. Đang kiểm tra ngưỡng...");
                try {
                    float nhietDoed = Float.parseFloat(editNhietDo);
                    float doAmed = Float.parseFloat(editDoAm);

                    Log.d("Hivemq", "Ngưỡng nhiệt độ: " + nhietDoed);
                    Log.d("Hivemq", "Ngưỡng độ ẩm: " + doAmed);

                    if (temperature > nhietDoed || humidity > doAmed) {
                        Log.d("Hivemq", "Nhiệt độ hoặc độ ẩm vượt ngưỡng. Bật đèn LED.");
                        sendData("/topic/qos0", "OF");
                        autoSwitch.setChecked(true);
                        tvLed.setText("On");
                        isLedOn = true;
                    } else {
                        Log.d("Hivemq", "Nhiệt độ và độ ẩm trong ngưỡng. Tắt đèn LED.");
                        sendData("/topic/qos0", "OFF");
                        autoSwitch.setChecked(false);
                        tvLed.setText("Off");
                        isLedOn = false;
                    }
                } catch (NumberFormatException e) {
                    Log.e("Hivemq", "Giá trị ngưỡng nhiệt độ hoặc độ ẩm không hợp lệ", e);
                }
            } else {
                Log.d("Hivemq", "Hộp kiểm không được chọn. Không thực hiện hành động.");
            }
        } else {
            Log.d("Hivemq", "Dữ liệu không được thêm vì giá trị giống nhau: Độ ẩm: " + humidity + ", Nhiệt độ: " + temperature);
        }
    }

    private void initView() {
        img = findViewById(R.id.imageConnect01);
        autoSwitch = findViewById(R.id.swichAuto);
        autoCheckBox = findViewById(R.id.checkBoxAuto);
        tvLed = findViewById(R.id.tvOnOffAuto);
        tvNhietdo = findViewById(R.id.tvAutoNhietDo);
        tvDoAm = findViewById(R.id.tvAutoDoAm);
        buttonDate = findViewById(R.id.setDateAuto);
        ButtonTime = findViewById(R.id.setTimeAuto);
        tvsetDate = findViewById(R.id.tvsetdateAuto);
        tvsetTime = findViewById(R.id.tvSetTimeAuto);
        edNhietdo = findViewById(R.id.etNhietDoThreshold);
        edDoam = findViewById(R.id.etDoAmThreshold);
        btAdd = findViewById(R.id.btAddAuto);
        btShowList = findViewById(R.id.btShowList);
        tvauto = findViewById(R.id.tvAuto);
        ImgBle = findViewById(R.id.imageViewBle);
        ImgMqtt = findViewById(R.id.imageViewMqtt);
        btLine = findViewById(R.id.btLineChart);
//        btshowdht = findViewById(R.id.btShowListDHT);
        btDisBle = findViewById(R.id.btDisConnectBle);
        ImgReload = findViewById(R.id.imageReload);
        dht lastDht = dhtDatabase.getLastDht();
        if (lastDht != null) {
            // Nếu lần đầu nhận dữ liệu, lưu lại dữ liệu trước đó
            previousHumidity = String.valueOf(lastDht.getDhtDoAm());
            previousTemperature = String.valueOf(lastDht.getDhtNhietDo());
            tvNhietdo.setText(previousTemperature);
            tvDoAm.setText(previousHumidity);

            Log.d("Hivemq", "Độ ẩm trước đó: " + previousHumidity);
            Log.d("Hivemq", "Nhiệt độ trước đó: " + previousTemperature);
        }
    }
    private void checkAutoTime() {
        List<DuLieuHenGio> duLieuHenGioList = databaseHenGio.getAll();
        SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy HH:mm");
        long tolerance = 20000;

        for (DuLieuHenGio autoTime : duLieuHenGioList) {
            String dateStr = autoTime.getNgayHenGio() + " " + autoTime.getTimeHenGio();
            try {
                Date autoTimeDate = dateFormat.parse(dateStr);
                Date currentDate = new Date();

                System.out.println("Current Date: " + currentDate);
                System.out.println("Auto Time Date: " + autoTimeDate);

                long timeDifference = Math.abs(currentDate.getTime() - autoTimeDate.getTime());
                if (timeDifference <= tolerance) {
                    // Bật đèn LED
                    sendData("/topic/qos0", "ON");
                    autoSwitch.setChecked(true);
                    tvLed.setText("On");
                    isLedOn = true;
                    Toast.makeText(MainActivity.this,"Thời gian cài đặt gửi đã đến , đã thực hiện xong hoạt động đề ra !!",Toast.LENGTH_SHORT).show();
                    Toast.makeText(MainActivity.this, "Đã gửi tín hiệu đi.", Toast.LENGTH_SHORT).show();
                    new Handler().postDelayed(new Runnable() {
                        @Override
                        public void run() {
                            autoSwitch.setChecked(false);
                            tvLed.setText("Off");
                            isLedOn = false;
                            databaseHenGio.deleteHenGio(autoTime.getSttHenGio());
                        }
                    }, 7000);

                } else if (currentDate.after(autoTimeDate)) {
                    databaseHenGio.deleteHenGio(autoTime.getSttHenGio());
                }
            } catch (ParseException e) {
                e.printStackTrace();
            }
        }
    }

    private void msg(String s) {
        Toast.makeText(getApplicationContext(), s, Toast.LENGTH_LONG).show();
    }

    //Nhận luồng

    //Phần Mqtt --------------------------------------------------------------------------------------------
    private void connectToMQTT() {
        String serverHost = "mqtt.eclipseprojects.io";
        int serverPort = 8883;
        String username = "";
        String password = "";
        String clientId = "ClientID_" + System.currentTimeMillis();
        Log.e("Current ID:", clientId);
//        String serverHost = "5869f75f53024d41bb172fd5761739d6.s1.eu.hivemq.cloud";
//        int serverPort = 8883;
//        String username = "kkkkk";
//        String password = "Nhat.123";
//        String clientId = "ClientID_" + System.currentTimeMillis();
//        Log.e("Current ID:", clientId);

        mqtt3AsyncClient = MqttClient.builder()
                .useMqttVersion3()
                .serverHost(serverHost)
                .serverPort(serverPort)
                .useSslWithDefaultConfig()
                .buildAsync();

        mqtt3AsyncClient.connectWith()
                .simpleAuth()
                .username(username)
                .password(password.getBytes(StandardCharsets.UTF_8))
                .applySimpleAuth()
                .send()
                .whenComplete((connAck, throwable) -> {
                    if (throwable != null) {
                        Log.e("MQTT", "Connection failed", throwable);
                        runOnUiThread(() -> Toast.makeText(MainActivity.this, "Connection failed", Toast.LENGTH_SHORT).show());
                        isConnected = false;
                    } else {
                        Log.i("MQTT", "Connected successfully");
                        runOnUiThread(() -> Toast.makeText(MainActivity.this, "Connected successfully", Toast.LENGTH_SHORT).show());
                        subscribeAndReceive();
                        isConnected = true;
                    }
                });
    }
    private void disconnectFromMQTT() {
        mqtt3AsyncClient.disconnect()
                .whenComplete((mqtt3ConnAck, throwable) -> {
                    if (throwable != null) {
                        Log.e("MQTT", "Disconnect failed", throwable);
                        runOnUiThread(() -> Toast.makeText(MainActivity.this, "Disconnect failed", Toast.LENGTH_SHORT).show());
                    } else {
                        Log.i("MQTT", "Disconnected successfully");
                        runOnUiThread(() -> Toast.makeText(MainActivity.this, "Disconnected successfully", Toast.LENGTH_SHORT).show());
                    }
                    isConnected = false;
                });
    }
    private void sendData(String topicUser, String message) {
        mqtt3AsyncClient.publishWith()
                .topic(topicUser)
                .payload(message.getBytes(StandardCharsets.UTF_8))
                .send()
                .whenComplete((mqtt3Publish, throwable) -> {
                    if (throwable != null) {
                        Log.e("MQTT", "Gửi tin nhắn thất bại", throwable);
                        runOnUiThread(() -> Toast.makeText(MainActivity.this, "Gửi tin nhắn thất bại", Toast.LENGTH_SHORT).show());
                    } else {
                        Log.i("MQTT", "Gửi tin nhắn thành công đến " + topicUser);
                        runOnUiThread(() -> Toast.makeText(MainActivity.this, "Dữ liệu được gửi thành công", Toast.LENGTH_SHORT).show());
                    }
                });
    }
    // đăng ký nhận dữ liệu
    private void subscribeAndReceive() {
        // Đảm bảo kết nối MQTT đã được thiết lập
        if (mqtt3AsyncClient.getState() != MqttClientState.CONNECTED) {
            Log.e("MQTT", "Khách hàng chưa kết nối");
            return;
        }

        // Đăng ký nhận dữ liệu từ chủ đề dhtTemp
        mqtt3AsyncClient.subscribeWith()
                .topicFilter("dhtTemp")
                .callback(publish -> {
                    byte[] payload = publish.getPayloadAsBytes();
                    final String tempMessage = new String(payload, StandardCharsets.UTF_8);
                    Log.e("Nhận dhtTemp", tempMessage);
                    receivedTemperature = tempMessage;
                    runOnUiThread(() -> {
                        tvNhietdo.setText(tempMessage);
                        add(); // Thêm dữ liệu khi nhiệt độ thay đổi
                    });
                })
                .send()
                .whenComplete((subAck, throwable) -> {
                    if (throwable != null) {
                        Log.e("MQTT", "Đăng ký nhận dữ liệu từ dhtTemp thất bại", throwable);
                    } else {
                        Log.i("MQTT", "Đã đăng ký nhận dữ liệu từ dhtTemp");
                    }
                });

        // Đăng ký nhận dữ liệu từ chủ đề dhtHum
        mqtt3AsyncClient.subscribeWith()
                .topicFilter("dhtHum")
                .callback(publish -> {
                    byte[] payload = publish.getPayloadAsBytes();
                    final String humMessage = new String(payload, StandardCharsets.UTF_8);
                    Log.e("Nhận dhtHum", humMessage);
                    receivedHumidity = humMessage;
                    runOnUiThread(() -> {
                        tvDoAm.setText(humMessage);
                        add(); // Thêm dữ liệu khi độ ẩm thay đổi
                    });
                })
                .send()
                .whenComplete((subAck, throwable) -> {
                    if (throwable != null) {
                        Log.e("MQTT", "Đăng ký nhận dữ liệu từ dhtHum thất bại", throwable);
                    } else {
                        Log.i("MQTT", "Đã đăng ký nhận dữ liệu từ dhtHum");
                    }
                });
        mqtt3AsyncClient.subscribeWith()
                .topicFilter("lastWillTopic")
                .qos(MqttQos.AT_LEAST_ONCE)
                .callback(publish -> {
                    byte[] payload = publish.getPayloadAsBytes();
                    final String a03 = new String(payload, StandardCharsets.UTF_8);
                    Log.e("lastWillTopic", a03);
                    String notification = a03;
                    runOnUiThread(() -> {
                        Toast.makeText(MainActivity.this,notification,Toast.LENGTH_SHORT).show();
                        if ("Offline".equals(notification)) {
                            img.setImageResource(R.drawable.baseline_airplanemode_active_24);
                        } else if("Online".equals(notification)) {
                            img.setImageResource(R.drawable.baseline_airplanemode_inactive_24);
                        }
                        else{
                            Log.d("lastWillTopic","ko dữ liệu");
                        }
                    });
                })
                .send()
                .whenComplete((subAck, throwable) -> {
                    if (throwable != null) {
                        Log.e("MQTT", "Đăng ký nhận dữ liệu từ lastWillTopic thất bại", throwable);
                    } else {
                        Log.i("MQTT", "Đã đăng ký nhận dữ liệu từ lastWillTopic");
                    }
                });
        mqtt3AsyncClient.subscribeWith()
                .topicFilter("led_status")
//                .qos(MqttQos.AT_LEAST_ONCE)
                .callback(publish -> {
                    byte[] payload = publish.getPayloadAsBytes();
                    final String a04 = new String(payload, StandardCharsets.UTF_8);
                    Log.e("led_status", a04);
                    String notification = a04;
                    runOnUiThread(() -> {
                        if("ON".equals(a04)){
                            autoSwitch.setChecked(true);
                        }
                        else if ("OFF".equals(a04)){
                            autoSwitch.setChecked(false);
                        }
                        else {
                            Log.d("led_status","dữ liệu ko xác đinh :" + a04);
                        }
                    });
                })
                .send()
                .whenComplete((subAck, throwable) -> {
                    if (throwable != null) {
                        Log.e("MQTT", "Đăng ký nhận dữ liệu từ lastWillTopic thất bại", throwable);
                    } else {
                        Log.i("MQTT", "Đã đăng ký nhận dữ liệu từ lastWillTopic");
                    }
                });
    }

    //Hết Mqtt  --------------------------------------------------------------------------------------------


    //Phần Ble----------------------------------------------------------------------------------------------
    private void Disconnect() {
        if (btSocket != null) { // If the btSocket is busy
            try {
                isConnectedBle = false;
                btSocket.close(); // Close connection
            } catch (IOException e) {
                msg("Error");
            }
        }
        ImgBle.setImageResource(R.drawable.baseline_bluetooth_disabled_24);
    }
    private class ConnectBT extends AsyncTask<Void, Void, Void> {
        private boolean ConnectSuccess = true;

        @Override
        protected void onPreExecute() {
            progress = ProgressDialog.show(MainActivity.this, "Connecting...", "Please wait!!!");
        }

        @Override
        protected Void doInBackground(Void... devices) {
            try {
                if (btSocket == null || !isBtConnected) {
                    myBluetooth = BluetoothAdapter.getDefaultAdapter(); // Get the mobile bluetooth device
                    BluetoothDevice dispositivo = myBluetooth.getRemoteDevice(address); // Connects to the device's address and checks if it's available
                    btSocket = dispositivo.createInsecureRfcommSocketToServiceRecord(myUUID); // Create a RFCOMM (SPP) connection
                    BluetoothAdapter.getDefaultAdapter().cancelDiscovery();
                    btSocket.connect(); // Start connection
                }
            } catch (IOException e) {
                ConnectSuccess = false; // If the try failed, you can check the exception here
            }
            return null;
        }

        @Override
        protected void onPostExecute(Void result) {
            super.onPostExecute(result);
            if (!ConnectSuccess) {
                msg("Kết nối thất bại. Đây có phải là Bluetooth SPP không? Thử lại.");
                finish();
            } else {
                ImgBle.setImageResource(R.drawable.ble_connect);
                msg("Đã kết nối Ble.");
                isBtConnected = true;
                startListeningForData();
            }
            progress.dismiss();
        }
    }

    private void processReceivedData(String data) {
        // Split the received data by the delimiter (e.g., " / ")
        String[] dataParts = data.split(" / ");

        if (dataParts.length == 2) {
            try {
                String tempValue = dataParts[0].split(":")[1].trim();
                String humValue = dataParts[1].split(":")[1].trim();

                receivedTemperature = tempValue;
                receivedHumidity = humValue;

                add();  // Assuming add() processes both temperature and humidity

                tvNhietdo.setText(String.format("%.2f", Float.parseFloat(receivedTemperature)));
                tvDoAm.setText(String.format("%.2f", Float.parseFloat(receivedHumidity)));
            } catch (NumberFormatException | ArrayIndexOutOfBoundsException e) {
                // Handle invalid data format
//            msg("Invalid data received: " + data);
            }
        } else {
            // Handle invalid data format
//        msg("Received invalid data format: " + data);
        }
    }


    private void startListeningForData() {
        final InputStream inputStream;
        try {
            inputStream = btSocket.getInputStream();
        } catch (IOException e) {
            msg("Lỗi nhận luồng đầu vào");
            return;
        }

        new Thread(new Runnable() {
            @Override
            public void run() {
                byte[] buffer = new byte[256];
                int bytes;

                while (true) {
                    try {
                        bytes = inputStream.read(buffer);
                        final String receivedString = new String(buffer, 0, bytes).trim();
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                processReceivedData(receivedString);
                            }
                        });
                    } catch (IOException e) {
                        msg("Lỗi đọc từ luồng đầu vào");
                        break;
                    }
                }
            }
        }).start();
    }
    //Hết Ble--------------------------------------------------------------------------------------------------------
}
