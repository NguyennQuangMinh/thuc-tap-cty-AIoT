package com.example.hivemqtt.dht.auto;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

import androidx.annotation.Nullable;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class SetAutoTimeDatabase extends SQLiteOpenHelper {
    public static final String DATABASE_NAME = "SetAutoTimeDatabase";
    private static final String TABLE_NAME = "SetAutoTime";
    private static final String ID = "ID";
    private static final String MyDate = "MyDate";
    private static final String MyTime = "MyTime";
    private Context context;

    public SetAutoTimeDatabase(@Nullable Context context) {
        super(context, DATABASE_NAME, null, 1);
        this.context = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String sqlQuery = "CREATE TABLE " + TABLE_NAME + " (" +
                ID + " integer primary key  , " +
                MyDate + " TEXT, " +
                MyTime + " TEXT)";
        db.execSQL(sqlQuery);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + TABLE_NAME);
        onCreate(db);
    }
    public void addAuto(SetAutoTime setAutoTime) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(MyDate, setAutoTime.getSetdateAuto());
        values.put(MyTime, setAutoTime.getSettimeAuto());
        db.insert(TABLE_NAME, null, values);
        db.close();
    }
    public List<SetAutoTime> getAll() {
        List<SetAutoTime> arrayList = new ArrayList<>();
        String selectQuery = "SELECT * FROM " + TABLE_NAME + " ORDER BY " + MyDate + " ASC, " + MyTime + " DESC";

        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.rawQuery(selectQuery, null);

        if (cursor.moveToFirst()) {
            do {
                SetAutoTime setAutoTime = new SetAutoTime();
                setAutoTime.setSetAuto(cursor.getInt(0));
                setAutoTime.setSetdateAuto(cursor.getString(1));
                setAutoTime.setSettimeAuto(cursor.getString(2));
                arrayList.add(setAutoTime);
            } while (cursor.moveToNext());
        }

        cursor.close();
        db.close();
        return arrayList;
    }


    public void deleteAuto(int id) {
        SQLiteDatabase db = this.getWritableDatabase();
        db.delete(TABLE_NAME, ID + "=?", new String[]{String.valueOf(id)});
        db.close();
    }

    private void deleteFromSQLite(String id, String setdateTime) {
        SQLiteDatabase db = this.getWritableDatabase();
        String where = MyTime + " = '" + id + "' AND " + MyDate + " = '" + setdateTime + "'";
        db.delete(TABLE_NAME, where, null);
        db.close();
    }


    public void exportDatabaseToSqlFile(File file) {
        SQLiteDatabase db = this.getReadableDatabase();
        FileWriter fileWriter = null;

        try {
            fileWriter = new FileWriter(file);
            Cursor cursor = db.rawQuery("SELECT * FROM " + TABLE_NAME, null);

            if (cursor.moveToFirst()) {
                do {
                    String insertQuery = "INSERT INTO " + TABLE_NAME + " (" +
                            ID + ", " +
                            MyDate + ", " +
                            MyTime + ") VALUES ('" +
                            cursor.getString(0) + "', '" +
                            cursor.getString(1) + "', '" +
                            cursor.getString(2) + "');";
                    fileWriter.write(insertQuery + "\n");
                } while (cursor.moveToNext());
            }

            cursor.close();
            fileWriter.flush();
            Toast.makeText(context, "Xuất cơ sở dữ liệu thành công!", Toast.LENGTH_SHORT).show();
        } catch (IOException e) {
            Toast.makeText(context, "Lỗi xuất cơ sở dữ liệu: " + e.getMessage(), Toast.LENGTH_SHORT).show();
        } finally {
            if (fileWriter != null) {
                try {
                    fileWriter.close();
                } catch (IOException e) {
                    Toast.makeText(context, "Lỗi đóng file writer: " + e.getMessage(), Toast.LENGTH_SHORT).show();
                }
            }
            db.close();
        }
    }
    public void updateAuto(SetAutoTime date) {
        SQLiteDatabase db = this.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(MyDate, date.getSetdateAuto());
        values.put(MyTime, date.getSettimeAuto());

        String where = ID + " = '" +date.getSetAuto() + "'";
        db.update(TABLE_NAME, values, where, null);
        db.close();
    }
}
