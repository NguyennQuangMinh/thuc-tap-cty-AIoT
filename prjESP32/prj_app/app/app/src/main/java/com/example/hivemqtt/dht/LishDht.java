spackage com.example.hivemqtt.dht;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;

import com.example.hivemqtt.MainActivity;
import com.example.hivemqtt.R;

import java.util.ArrayList;

public class LishDht extends AppCompatActivity {
    ListView listView;
    Button btLine,btBack;
    dhtAdapter adapter;
    ArrayList<dht> arrayList;
    dhtDatabase database = new dhtDatabase(this);
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_lish_dht);
        intview();
        arrayList= (ArrayList<dht>) database.getAll();
//        Collections.sort(Collections.unmodifiableList(arrayList1));
        adapter = new dhtAdapter(LishDht.this, R.layout.layout_item_showdht, arrayList);
        listView.setAdapter(adapter);
//        dht a = new dht(30,40);
//        database.addlistDht(a);
        btBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(LishDht.this, MainActivity.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
                startActivity(intent);
            }
        });
        btLine.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(LishDht.this, MainActivity.class);
                startActivity(intent);
            }
        });

    }

    private void intview() {
        listView = findViewById(R.id.listShowDHT);
        btLine = findViewById(R.id.IntenLine);
        btBack = findViewById(R.id.ShowlistBackdht);
    }

}