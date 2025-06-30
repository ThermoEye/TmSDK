package kr.co.thermoeye.android;

import android.graphics.Bitmap;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.Transformations;
import androidx.lifecycle.ViewModel;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Objects;

import kr.co.thermoeye.tmsdk.ColorMapTypes;

public class CameraViewModel extends ViewModel {
    // LiveData to hold a list of remote camera items
    private final MutableLiveData<List<RemoteCameraListItem>> remoteCameraList = new MutableLiveData<>();
    // LiveData to hold the list of Bitmap frames for each camera
    private final MutableLiveData<List<Bitmap>> bitmapFrames = new MutableLiveData<>(new ArrayList<>(Collections.nCopies(9, null)));
    // LiveData to store the selected camera ID
    private final MutableLiveData<Integer> selectedCameraId = new MutableLiveData<>(-1);
    // LiveData to store the selected single camera ID
    private final MutableLiveData<Integer> selectedSingleCameraId = new MutableLiveData<>(-1);
    // LiveData to store the color map type of the selected single camera
    private final MutableLiveData<ColorMapTypes> selectedSingleCameraColorMap = new MutableLiveData<>(ColorMapTypes.GrayScale);
    // LiveData to store the minimum temperature value for camera data
    private final MutableLiveData<Double> minTempVal = new MutableLiveData<>(0.0);
    // LiveData to store the average temperature value for camera data
    private final MutableLiveData<Double> avgTempVal = new MutableLiveData<>(0.0);
    // LiveData to store the maximum temperature value for camera data
    private final MutableLiveData<Double> maxTempVal = new MutableLiveData<>(0.0);
    // LiveData to indicate whether the ROI (Region of Interest) action has been completed
    private final MutableLiveData<Boolean> roiActionDone = new MutableLiveData<>(false);

    public LiveData<Boolean> getRoiActionDone() {
        return roiActionDone;
    }

    public void setRoiActionDone(Boolean done) {
        roiActionDone.setValue(done);
    }

    public LiveData<List<RemoteCameraListItem>> getRemoteCameraList() {
        return remoteCameraList;
    }

    public void setRemoteCameraList(List<RemoteCameraListItem> list) {
        remoteCameraList.setValue(list);
    }

    public LiveData<Integer> getSelectedCameraId() {
        return selectedCameraId;
    }

    public void setSelectedCameraId(Integer id) {
        selectedCameraId.setValue(id);
    }

    public void addRemoteCamera(RemoteCameraListItem cameraInfo) {
        List<RemoteCameraListItem> currentList = remoteCameraList.getValue();
        if (currentList == null) {
            currentList = new ArrayList<>();
        }
        currentList.add(cameraInfo);
        remoteCameraList.setValue(currentList);
    }

    public void removeRemoteCamera(int id) {
        List<RemoteCameraListItem> currentList = remoteCameraList.getValue();
        if (currentList != null) {
            currentList.removeIf(camera -> camera.getId() == id);
            remoteCameraList.setValue(currentList);
        }
    }

    public LiveData<Bitmap> getBitmapFrame(int id) {
        return Transformations.map(bitmapFrames, bitmaps -> {
            if (bitmaps != null && id >= 0 && id < bitmaps.size()) {
                return bitmaps.get(id);
            }
            return null;
        });
    }

    public void updateBitmapFrame(int id, Bitmap bitmap) {
        List<Bitmap> currentBitmaps = bitmapFrames.getValue();
        if (currentBitmaps != null && id >= 0 && id < currentBitmaps.size()) {
            currentBitmaps.set(id, bitmap);
            bitmapFrames.postValue(currentBitmaps);
        }
    }

    public LiveData<Integer> getSelectedSingleCameraId() {
        return selectedSingleCameraId;
    }

    public void setSelectedSingleCameraId(Integer id) {
        selectedSingleCameraId.setValue(id);
    }

    public LiveData<ColorMapTypes> getSelectedSingleCameraColorMap() {
        return selectedSingleCameraColorMap;
    }

    public void setSelectedSingleCameraColorMap(ColorMapTypes colorMap) {
        selectedSingleCameraColorMap.setValue(colorMap);
    }

    public LiveData<Double> getMinTempVal() {
        return minTempVal;
    }

    public void setMinTempVal(Double temp) {
        minTempVal.postValue(temp);
    }

    public LiveData<Double> getAvgTempVal() {
        return avgTempVal;
    }

    public void setAvgTempVal(Double temp) {
        avgTempVal.postValue(temp);
    }

    public LiveData<Double> getMaxTempVal() {
        return maxTempVal;
    }

    public void setMaxTempVal(Double temp) {
        maxTempVal.postValue(temp);
    }

    public RemoteCameraListItem getRemoteCameraItem(int id) {
        for (RemoteCameraListItem item: Objects.requireNonNull(remoteCameraList.getValue())) {
            if (item.getId() == id) {
                return item;
            }
        }
        return null;
    }

    public RemoteCameraListItem getRemoteCameraItem() {
        for (RemoteCameraListItem item: Objects.requireNonNull(remoteCameraList.getValue())) {
            if (item.getId() == Objects.requireNonNull(selectedSingleCameraId.getValue())) {
                return item;
            }
        }
        return null;
    }
}

