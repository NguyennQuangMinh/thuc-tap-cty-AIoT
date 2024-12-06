package com.example.hivemqtt.dht.auto;

public class SetAutoTime {
    private int setAuto;
    private String setdateAuto, settimeAuto;
    private boolean gtSwich;

    public SetAutoTime(int setAuto, String setdateAuto, String settimeAuto) {
        this.setAuto = setAuto;
        this.setdateAuto = setdateAuto;
        this.settimeAuto = settimeAuto;
    }

    public SetAutoTime(String setdateAuto, String settimeAuto, boolean gtSwich) {
        this.setdateAuto = setdateAuto;
        this.settimeAuto = settimeAuto;
        this.gtSwich = gtSwich;
    }

    public SetAutoTime() {
    }

    public int getSetAuto() {
        return setAuto;
    }

    public void setSetAuto(int setAuto) {
        this.setAuto = setAuto;
    }

    public String getSetdateAuto() {
        return setdateAuto;
    }

    public void setSetdateAuto(String setdateAuto) {
        this.setdateAuto = setdateAuto;
    }

    public String getSettimeAuto() {
        return settimeAuto;
    }

    public void setSettimeAuto(String settimeAuto) {
        this.settimeAuto = settimeAuto;
    }

    public boolean isGtSwich() {
        return gtSwich;
    }

    public void setGtSwich(boolean gtSwich) {
        this.gtSwich = gtSwich;
    }
}
