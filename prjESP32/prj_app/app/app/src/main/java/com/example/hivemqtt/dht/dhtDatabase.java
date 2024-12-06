package com.example.hivemqtt.dht;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.Nullable;

import java.util.ArrayList;
import java.util.List;

public class dhtDatabase extends SQLiteOpenHelper {
    public static final String DATABASE_NAME = "ListDHT36";
    private static final String TABLE_NAME = "dht";
    private static final String ID = "ID";
    private static final String MyTemperature = "MyTemperature";
    private static final String MyHumidity = "MyHumidity";
    private Context context;

    public dhtDatabase(@Nullable Context context) {
        super(context, DATABASE_NAME, null, 1);
        this.context = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String sqlQuery = "CREATE TABLE " + TABLE_NAME + " (" +
                ID + " integer primary key  , " +
                MyTemperature + " Float, " +
                MyHumidity + " Float)";
        db.execSQL(sqlQuery);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME);
        onCreate(db);
    }
    public void addlistDht(dht dht) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(MyTemperature, dht.getDhtNhietDo());
        values.put(MyHumidity, dht.getDhtDoAm());
        db.insert(TABLE_NAME, null, values);
        db.close();
    }
    public List<dht> getAll() {
        List<dht> arrayList = new ArrayList<>();
        String selectQuery = "SELECT  * FROM " + TABLE_NAME  ;

        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);

        if (cursor.moveToFirst()) {
            do {
                dht dht = new dht();
                dht.setSothutuDht(cursor.getInt(0));
                dht.setDhtNhietDo(cursor.getFloat(1));
                dht.setDhtDoAm(cursor.getFloat(2));
                arrayList.add(dht);
            } while (cursor.moveToNext());
        }
        cursor.close();
        db.close();
        return arrayList;
    }
    public dht getLastDht() {
        SQLiteDatabase db = this.getReadableDatabase();
        String selectQuery = "SELECT * FROM " + TABLE_NAME + " ORDER BY " + ID + " DESC LIMIT 1";
        Cursor cursor = db.rawQuery(selectQuery, null);

        dht lastDht = null;
        if (cursor.moveToFirst()) {
            lastDht = new dht();
            lastDht.setSothutuDht(cursor.getInt(0));
            lastDht.setDhtNhietDo(cursor.getFloat(1));
            lastDht.setDhtDoAm(cursor.getFloat(2));
        }
        cursor.close();
        db.close();
        return lastDht;
    }

}
