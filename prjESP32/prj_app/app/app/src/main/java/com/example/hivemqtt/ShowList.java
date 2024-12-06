package com.example.hivemqtt;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.util.Log;
import android.view.ContextMenu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.example.hivemqtt.dht.auto.SetAutoTime;
import com.example.hivemqtt.dht.auto.SetAutoTimeAdapter;
import com.example.hivemqtt.dht.auto.SetAutoTimeDatabase;
import com.example.hivemqtt.dht.auto.UpdateAuto;

import java.io.File;
import java.util.ArrayList;

public class ShowList extends AppCompatActivity {
    Button button, btex,btHenGio;
    ListView listView;

    private ArrayList<SetAutoTime> arrayList1;

    SetAutoTimeAdapter adapter;

    SetAutoTimeDatabase setAutoTimeDatabase = new SetAutoTimeDatabase(this);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_show_list);
        intView();
        arrayList1 = (ArrayList<SetAutoTime>) setAutoTimeDatabase.getAll();
        adapter = new SetAutoTimeAdapter(ShowList.this, R.layout.auto_item_aiot, arrayList1);
        listView.setAdapter(adapter);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(ShowList.this, MainActivity.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
                startActivity(intent);
            }
        });
//        btHenGio.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Intent intent= new Intent(ShowList.this, MainHenGio.class);
//                startActivity(intent);
//            }
//        });

        btex.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                AlertDialog.Builder builder = new AlertDialog.Builder(ShowList.this);
                builder.setTitle("Xuất cơ sở dữ liệu");
                builder.setMessage("Bạn có chắc muốn xuất cơ sở dữ liệu ra tệp SQL?");
                builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        exportDatabase();
                    }
                });
                builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // Do nothing
                    }
                });
                AlertDialog dialog = builder.create();
                dialog.show();
            }
        });

        registerForContextMenu(listView);
    }

    private void exportDatabase() {
        File exportDir = new File(getExternalFilesDir(null), "exports");
        if (!exportDir.exists()) {
            exportDir.mkdirs();
        }
        File file = new File(exportDir, "SetAutoTimeDatabase.sql");
        setAutoTimeDatabase.exportDatabaseToSqlFile(file);
        Toast.makeText(ShowList.this, "Cơ sở dữ liệu đã được xuất ra tệp: " + file.getAbsolutePath(), Toast.LENGTH_LONG).show();
        Log.d("ShowList", "Cơ sở dữ liệu đã được xuất ra tệp: " + file.getAbsolutePath());
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        if (requestCode == 1) {
            if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                Toast.makeText(this, "Quyền ghi vào bộ nhớ đã được cấp", Toast.LENGTH_SHORT).show();
            } else {
                Toast.makeText(this, "Quyền ghi vào bộ nhớ bị từ chối", Toast.LENGTH_SHORT).show();
            }
        }
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_listview, menu);
    }

    @Override
    public boolean onContextItemSelected(@NonNull MenuItem item) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
        int position = info.position;
        SetAutoTime time = arrayList1.get(position);
        int c = time.getSetAuto();
        String a = time.getSetdateAuto();
        String b = time.getSettimeAuto();
        if (item.getItemId() == R.id.menu_update001) {
            Intent intent = new Intent(ShowList.this, UpdateAuto.class);
            intent.putExtra("date10", a);
            intent.putExtra("time10", b);
            intent.putExtra("vitri", c);
            startActivity(intent);
        } else if (item.getItemId() == R.id.menu_delete001) {
            AlertDialog.Builder builder = new AlertDialog.Builder(ShowList.this);
            builder.setTitle("Thông báo xóa!!");
            builder.setIcon(R.drawable.img_6);
            builder.setMessage("Bạn có chắc muốn xóa phần tử này không?");
            builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                    Toast.makeText(ShowList.this, "đã xóa vị trí thứ " + position, Toast.LENGTH_SHORT).show();
                    setAutoTimeDatabase.deleteAuto(c);
                    arrayList1.remove(position);
                    adapter.notifyDataSetChanged();
                }
            });
            builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
                @Override
                public void onClick(DialogInterface dialog, int which) {
                }
            });
            AlertDialog dialog = builder.create();
            dialog.show();
        }
        return super.onContextItemSelected(item);
    }

//    @Override
//@Override
//public void onBackPressed() {
//    Intent intent = new Intent(ShowList.this, MainActivity.class);
//    intent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
//    startActivity(intent);
//    finish();
//}
    private void intView() {
        button = findViewById(R.id.ShowlistBack);
        listView = findViewById(R.id.listShow);
        btex = findViewById(R.id.Exportfile);
//        btHenGio = findViewById(R.id.btIntenHenGio);
    }
}
