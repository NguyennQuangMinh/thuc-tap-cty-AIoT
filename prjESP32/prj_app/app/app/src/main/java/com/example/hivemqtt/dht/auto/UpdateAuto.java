package com.example.hivemqtt.dht.auto;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import com.example.hivemqtt.R;
import com.example.hivemqtt.ShowList;

import java.util.Calendar;

public class UpdateAuto extends AppCompatActivity {
    Button btUpdate,btBack,btSetTime,btSetDate;
    TextView tv1, tv2;
    String a,b;
    int c;
    SetAutoTimeDatabase setAutoTimeDatabase = new SetAutoTimeDatabase(this);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_auto);
        intView();
        btBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UpdateAuto.this, ShowList.class);
                startActivity(intent);
            }
        });
        btSetDate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Calendar calendar = Calendar.getInstance();

                int year01 = calendar.get(Calendar.YEAR);
                int month01 = calendar.get(Calendar.MONTH);
                int day01 = calendar.get(Calendar.DAY_OF_MONTH);

                DatePickerDialog datePickerDialog = new DatePickerDialog(UpdateAuto.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                        // Đặt ngày đã chọn cho TextView
                        tv1.setText(String.format("%d/%d/%d", dayOfMonth, month + 1, year));
                    }
                }, year01, month01, day01);
                datePickerDialog.show();
            }
        });
        btSetTime.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Calendar calendar = Calendar.getInstance();
                int hour = calendar.get(Calendar.HOUR);
                int minute = calendar.get(Calendar.MINUTE);

                TimePickerDialog timePickerDialog = new TimePickerDialog(UpdateAuto.this, new TimePickerDialog.OnTimeSetListener() {
                    @Override
                    public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                        tv2.setText(String.format("%d:%d",hourOfDay,minute));
                    }
                },hour,minute,true);
                timePickerDialog.show();
            }
        });
        btUpdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String a01 = tv1.getText().toString().trim();
                String a02 = tv2.getText().toString().trim();
                updateLocalDatabase(a01,a02);
                Intent intent = new Intent(UpdateAuto.this,ShowList.class);
                startActivity(intent);

            }
        });
    }
    private void updateLocalDatabase(String updateDate, String updateTime) {
        Log.d("Debug", "Updating local database...");
        SetAutoTime time = new SetAutoTime();
        time.setSetAuto(c);
        time.setSetdateAuto(updateDate);
        time.setSettimeAuto(updateTime);
        setAutoTimeDatabase.updateAuto(time);
    }

    private void intView() {
        btUpdate = findViewById(R.id.btUpdateAuto);
        btBack = findViewById(R.id.btBackAuto001);
        btSetDate = findViewById(R.id.setDateUpdateAuto);
        btSetTime = findViewById(R.id.setTimeUpdateAuto);
        tv1 = findViewById(R.id.tvsetdateAutoUpdate);
        tv2 = findViewById(R.id.tvSetTimeAutoUpdate);
        Bundle bundle = getIntent().getExtras();
        a = bundle.getString("date10");
        b = bundle.getString("time10");
        c = bundle.getInt("vitri");
        tv1.setText(a);
        tv2.setText(b);
        Toast.makeText(UpdateAuto.this,"vitri L"+c,Toast.LENGTH_SHORT).show();
    }

}