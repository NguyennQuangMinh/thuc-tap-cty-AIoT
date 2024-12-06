package com.example.hivemqtt.dht;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.hivemqtt.R;

import java.util.ArrayList;

public class dhtAdapter extends BaseAdapter {
    private Context context;
    private int layout;
    private ArrayList<dht> arrayList;

    public dhtAdapter(Context context, int layout, ArrayList<dht> arrayList) {
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
        convertView = inflater.inflate(layout, null);

        TextView tvNhietDo = convertView.findViewById(R.id.itemNhietDoShow);
        TextView tvDoAm = convertView.findViewById(R.id.itemDoAmShow);

        dht dht = arrayList.get(position);
        tvNhietDo.setText(dht.getDhtNhietDo()+"'C");
        tvDoAm.setText(dht.getDhtDoAm()+" %");
        return convertView;
    }
}
