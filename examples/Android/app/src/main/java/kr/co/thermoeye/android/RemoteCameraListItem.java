package kr.co.thermoeye.android;

import androidx.annotation.NonNull;

import java.util.Objects;
import kr.co.thermoeye.tmsdk.ColorMapTypes;
import kr.co.thermoeye.tmsdk.TempUnit;
import kr.co.thermoeye.tmsdk.TmCamera;
import kr.co.thermoeye.tmsdk.TmRoiManager;

public class RemoteCameraListItem {
    private String name;
    private String nickName = "";
    private String ip;
    private String mac;
    private String serial;
    private boolean isConnected;
    private Integer id = -1;
    private static final CameraManager cameraManager = new CameraManager();
    private ColorMapTypes colorMapTypes = ColorMapTypes.GrayScale;
    private TempUnit tempUnit = TempUnit.CELSIUS;
    private Double alarmTemp = 40.0;
    private Boolean alarmEnable = false;
    private TmCamera tmCamera = null;
    private TmRoiManager tmRoiManager = null;
    private int width = -1;
    private int height = -1;

    // Constructor
    public RemoteCameraListItem(String name, String ip, String mac, String serial) {
        this.name = name;
        this.nickName = name;
        this.ip = ip;
        this.mac = mac;
        this.serial = serial;
        this.isConnected = false;
    }

    public RemoteCameraListItem(String name, String ip, String mac, String serial, int id, boolean state) {
        this.name = name;
        this.nickName = name;
        this.ip = ip;
        this.mac = mac;
        this.serial = serial;
        this.id = id;
        this.isConnected = state;
    }

    public RemoteCameraListItem(String name, String ip, String mac, String serial, int id, boolean state, String nickName) {
        this.name = name;
        if (!nickName.isEmpty()) {
            this.nickName = nickName;
        }
        this.ip = ip;
        this.mac = mac;
        this.serial = serial;
        this.id = id;
        this.isConnected = state;
    }

    public int getId() {
        return id;
    }
    public TmCamera getTmCamera() {
        return tmCamera;
    }
    public void setTmCamera(TmCamera tmCamera) {
        this.tmCamera = tmCamera;
    }
    public TmRoiManager getTmRoiManager() { return tmRoiManager; }
    public void setTmRoiManager(TmRoiManager tmRoiManager) { this.tmRoiManager = tmRoiManager; }
    public String getName() { return name; }
    public String getNickName() { return nickName; }
    public String getIp() { return ip; }
    public String getMac() { return mac; }
    public String getSerial() { return serial; }
    public void setName(String name) { this.name = name; }
    public void setNickName(String nickName) { this.nickName = nickName; }
    public void setIp(String ip) { this.ip = ip; }
    public void setMac(String mac) { this.mac = mac; }
    public void setSerial(String serial) { this.serial = serial; }
    public boolean isConnected() { return isConnected; }
    public boolean setConnected(boolean connected) {
        if (connected) {
            this.id = cameraManager.getAvailableID();
            if (this.id == null) {
                return false;
            }
            isConnected = connected;
        } else {
            isConnected = connected;
            cameraManager.releaseId(this.id);
            this.id = -1;
        }
        return true;
    }

    public int getWidth() {
        return width;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }

    public TempUnit getTempUnit() {
        return tempUnit;
    }

    public void setTempUnit(TempUnit unit) {
        tempUnit = unit;
    }

    public ColorMapTypes getColorMapTypes() {
        return colorMapTypes;
    }

    public void setColorMapTypes(ColorMapTypes colorMap) {
        colorMapTypes = colorMap;
    }

    public Double getAlarmTemp() {
        return alarmTemp;
    }

    public void setAlarmTemp(Double temp) {
        alarmTemp = temp;
    }

    public Boolean getAlarmEnable() {
        return alarmEnable;
    }

    public void setAlarmEnable(Boolean enable) {
        alarmEnable = enable;
    }

    // toString method for easy string representation
    @NonNull
    @Override
    public String toString() {
        return "ListItem{" +
                "name='" + name + '\'' +
                ", ip='" + ip + '\'' +
                ", mac='" + mac + '\'' +
                ", serial='" + serial + '\'' +
                '}';
    }

    // equals and hashCode methods for correct comparison and hashing in collections
    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        RemoteCameraListItem listItem = (RemoteCameraListItem) o;
        return name.equals(listItem.name) &&
                ip.equals(listItem.ip) &&
                mac.equals(listItem.mac) &&
                serial.equals(listItem.serial);
    }

    @Override
    public int hashCode() {
        return Objects.hash(name, ip, mac, serial);
    }
}