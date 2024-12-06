package com.example.hivemqtt;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import com.example.hivemqtt.MainActivity;
import com.example.hivemqtt.R;
import com.example.hivemqtt.dht.dht;
import com.example.hivemqtt.dht.dhtDatabase;
import com.github.mikephil.charting.charts.LineChart;
import com.github.mikephil.charting.components.XAxis;
import com.github.mikephil.charting.components.YAxis;
import com.github.mikephil.charting.data.Entry;
import com.github.mikephil.charting.data.LineData;
import com.github.mikephil.charting.data.LineDataSet;
import com.github.mikephil.charting.formatter.ValueFormatter;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

public class LineChartDHT extends AppCompatActivity {

    dhtDatabase database = new dhtDatabase(this);
    private LineChart lineChart;
    private Button buttonBack;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_line_chart_dht);
        intview();

        List<Entry> temperatureEntries = new ArrayList<>();
        List<Entry> humidityEntries = new ArrayList<>();

        // Lấy tất cả các bản ghi từ cơ sở dữ liệu
        List<dht> dhtList = database.getAll();

        // Tạo các điểm dữ liệu từ các bản ghi
        for (int i = 0; i < dhtList.size(); i++) {
            dht currentDht = dhtList.get(i);
            float temp = currentDht.getDhtNhietDo();
            float humidity = currentDht.getDhtDoAm();
            temperatureEntries.add(new Entry(i, temp));
            humidityEntries.add(new Entry(i, humidity));
        }

        LineDataSet tempDataSet = new LineDataSet(temperatureEntries, "Temperature");
        tempDataSet.setColor(Color.RED); // Màu của đường nhiệt độ
        tempDataSet.setLineWidth(2.5f); // Tăng kích thước đường
        tempDataSet.setCircleColor(Color.RED); // Màu của dấu chấm nhiệt độ
        tempDataSet.setCircleRadius(5f); // Tăng kích thước dấu chấm
        tempDataSet.setValueTextColor(Color.RED); // Màu của giá trị nhiệt độ
        tempDataSet.setValueTextSize(12f); // Tăng kích thước văn bản của giá trị

        LineDataSet humidityDataSet = new LineDataSet(humidityEntries, "Humidity");
        humidityDataSet.setColor(Color.BLUE); // Màu của đường độ ẩm
        humidityDataSet.setLineWidth(2.5f); // Tăng kích thước đường
        humidityDataSet.setCircleColor(Color.BLUE); // Màu của dấu chấm độ ẩm
        humidityDataSet.setCircleRadius(5f); // Tăng kích thước dấu chấm
        humidityDataSet.setValueTextColor(Color.BLUE); // Màu của giá trị độ ẩm
        humidityDataSet.setValueTextSize(12f); // Tăng kích thước văn bản của giá trị

        LineData lineData = new LineData(tempDataSet, humidityDataSet);
        lineChart.setData(lineData);
        lineChart.invalidate();

        // Kích hoạt cuộn và zoom
        lineChart.setDragEnabled(true);
        lineChart.setScaleEnabled(true);
        lineChart.setScaleXEnabled(true);
        lineChart.setScaleYEnabled(true);
        lineChart.setPinchZoom(true); // Cho phép phóng to bằng cách chụm hai ngón tay

        // Cấu hình trục X để hiển thị chỉ số
        XAxis xAxis = lineChart.getXAxis();
        xAxis.setPosition(XAxis.XAxisPosition.BOTTOM);
        xAxis.setGranularity(1f); // Khoảng cách tối thiểu giữa các giá trị trục là 1
        xAxis.setValueFormatter(new ValueFormatter() {
            @Override
            public String getFormattedValue(float value) {
                return String.format(Locale.ENGLISH, "%02d", (int) value);
            }
        });

        // Cấu hình trục Y để hiển thị giá trị
        YAxis leftAxis = lineChart.getAxisLeft();
        leftAxis.setGranularity(1f); // Khoảng cách tối thiểu giữa các giá trị trục là 1
        leftAxis.setValueFormatter(new ValueFormatter() {
            @Override
            public String getFormattedValue(float value) {
                return String.format(Locale.ENGLISH, "%.1f", value);
            }
        });

        YAxis rightAxis = lineChart.getAxisRight();
        rightAxis.setEnabled(false); // Tắt trục Y bên phải

        // Đặt số lượng điểm hiển thị ban đầu trong khung nhìn
        lineChart.setVisibleXRangeMaximum(10);

        // Thiết lập ma sát kéo để kiểm soát độ mượt khi kéo
        lineChart.setDragDecelerationFrictionCoef(0.9f);

        // Cho phép cuộn ngang
        lineChart.setScaleXEnabled(true);

        buttonBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(LineChartDHT.this, MainActivity.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
                startActivity(intent);
            }
        });
    }

    private void intview() {
        lineChart = findViewById(R.id.lineChart);
        buttonBack = findViewById(R.id.buttonBack00);
    }
}
