package kr.co.thermoeye.android;

import androidx.annotation.NonNull;

import java.util.Locale;
import java.util.Objects;
import kr.co.thermoeye.tmsdk.ColorMapTypes;
import kr.co.thermoeye.tmsdk.TempUnit;
import kr.co.thermoeye.tmsdk.TmCamera;
import kr.co.thermoeye.tmsdk.TmLocalCamInfo;
import kr.co.thermoeye.tmsdk.TmRemoteCamInfo;
import kr.co.thermoeye.tmsdk.TmRoiManager;

public class CameraListItem {
    private String name;
    private String nickName = "";
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
    private TmRemoteCamInfo remoteCamInfo = null;
    private TmLocalCamInfo localCamInfo = null;
    private int width = -1;
    private int height = -1;

    public CameraListItem(TmRemoteCamInfo info) {
        this.remoteCamInfo = info;
        this.name = info.getName();
        this.nickName = info.getName();
        this.serial = info.getSerialNumber();
        this.isConnected = false;
    }

    public CameraListItem(TmLocalCamInfo info) {
        this.localCamInfo = info;
        this.name = info.getName();
        this.nickName = info.getName();
        this.serial = info.getSerialNumber();
        this.isConnected = false;
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
    public String getIp() {
        return remoteCamInfo != null ? remoteCamInfo.getAddrIP() : "";
    }
    public String getMac() {
        return remoteCamInfo != null ? remoteCamInfo.getAddrMAC() : "";
    }
    public String getSubtitle() {
        if (localCamInfo != null) {
            return String.format(Locale.US, "USB %04X:%04X", localCamInfo.getVendorId(), localCamInfo.getProductId());
        }
        return getIp();
    }
    public String getKey() {
        if (localCamInfo != null) {
            return localCamInfo.getDeviceName();
        }
        return getMac();
    }
    public String getSerial() { return serial; }
    public boolean isLocal() { return localCamInfo != null; }
    public TmLocalCamInfo getLocalCamInfo() { return localCamInfo; }
    public TmRemoteCamInfo getRemoteCamInfo() { return remoteCamInfo; }
    public void setName(String name) { this.name = name; }
    public void setNickName(String nickName) { this.nickName = nickName; }
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

    @NonNull
    @Override
    public String toString() {
        return "ListItem{" +
                "name='" + name + '\'' +
                ", subtitle='" + getSubtitle() + '\'' +
                ", key='" + getKey() + '\'' +
                ", serial='" + serial + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        CameraListItem listItem = (CameraListItem) o;
        return Objects.equals(name, listItem.name) &&
                Objects.equals(getKey(), listItem.getKey()) &&
                Objects.equals(serial, listItem.serial);
    }

    @Override
    public int hashCode() {
        return Objects.hash(name, getKey(), serial);
    }
}
