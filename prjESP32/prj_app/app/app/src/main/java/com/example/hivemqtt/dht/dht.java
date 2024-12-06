package com.example.hivemqtt.dht;

public class dht {
    int sothutuDht;
    float dhtNhietDo,dhtDoAm;

    public dht(int sothutuDht, float dhtNhietDo, float dhtDoAm) {
        this.sothutuDht = sothutuDht;
        this.dhtNhietDo = dhtNhietDo;
        this.dhtDoAm = dhtDoAm;
    }

    public dht() {

    }

    public dht(float dhtNhietDo, float dhtDoAm) {
        this.dhtNhietDo = dhtNhietDo;
        this.dhtDoAm = dhtDoAm;
    }

    public int getSothutuDht() {
        return sothutuDht;
    }

    public void setSothutuDht(int sothutuDht) {
        this.sothutuDht = sothutuDht;
    }

    public float getDhtNhietDo() {
        return dhtNhietDo;
    }

    public void setDhtNhietDo(float dhtNhietDo) {
        this.dhtNhietDo = dhtNhietDo;
    }

    public float getDhtDoAm() {
        return dhtDoAm;
    }

    public void setDhtDoAm(float dhtDoAm) {
        this.dhtDoAm = dhtDoAm;
    }
}
