package com.example.hivemqtt.dht.auto;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CompoundButton;
import android.widget.Switch;
import android.widget.TextView;

import com.example.hivemqtt.R;
import com.example.hivemqtt.dht.auto.LuuDuLieuHenGio.DatabaseHenGio;
import com.example.hivemqtt.dht.auto.LuuDuLieuHenGio.DuLieuHenGio;

import java.util.ArrayList;

public class SetAutoTimeAdapter extends BaseAdapter {
    private Context context;
    private int layout;
    private ArrayList<SetAutoTime> arrayList;
    private static int autoIncrementId = 0;

    public SetAutoTimeAdapter(Context context, int layout, ArrayList<SetAutoTime> arrayList) {
        this.context = context;
        this.layout = layout;
        this.arrayList = arrayList;
    }

    @Override
    public int getCount() {
        return arrayList.size();
    }

    @Override
    public Object getItem(int position) {
        return arrayList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        if (convertView == null) {
            convertView = inflater.inflate(layout, null);
        }

        TextView tvDate = convertView.findViewById(R.id.itemDateAuto);
        TextView tvTime = convertView.findViewById(R.id.itemTimeAuto);
        Switch aSwitch = convertView.findViewById(R.id.swItemTime);
        SetAutoTime setAutoTime = arrayList.get(position);
        tvDate.setText(setAutoTime.getSetdateAuto());
        tvTime.setText(setAutoTime.getSettimeAuto());
        aSwitch.setChecked(setAutoTime.isGtSwich());

        return convertView;
    }
}
