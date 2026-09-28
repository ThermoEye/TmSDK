package kr.co.thermoeye.android;

import android.Manifest;
import android.content.Context;
import android.content.DialogInterface;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.MediaPlayer;
import android.os.Build;
import android.util.Log;
import android.os.Bundle;
import android.os.VibrationEffect;
import android.os.Vibrator;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.ViewModelProvider;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Objects;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import kr.co.thermoeye.android.databinding.FragmentCameraListBinding;
import kr.co.thermoeye.tmsdk.ColorOrder;
import kr.co.thermoeye.tmsdk.TempValueLoc;
import kr.co.thermoeye.tmsdk.TmCamera;
import kr.co.thermoeye.tmsdk.TmFrame;
import kr.co.thermoeye.tmsdk.TmLocalCamInfo;
import kr.co.thermoeye.tmsdk.TmRemoteCamInfo;
import kr.co.thermoeye.tmsdk.TmRoiManager;

public class CameraListFragment extends Fragment {
    private static final String TAG = "CameraList";
    private FragmentCameraListBinding bindingRemoteCamera;
    private CameraListAdapter adapter;
    private List<CameraListItem> itemList;
    private CameraViewModel cameraViewModel;
    private final Map<String, TmCamera> tmCameraMap = new HashMap<>();
    private int selectedSingleCameraId = -1;
    private static boolean vibe = false;
    private static boolean ring = false;
    private static final int REQ_USB_CAMERA_PERMISSION = 4101;
    private CameraListItem pendingUsbCamera;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        cameraViewModel = new ViewModelProvider(requireActivity()).get(CameraViewModel.class);
        itemList = new ArrayList<>();
        adapter = new CameraListAdapter(getContext(), itemList);
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        bindingRemoteCamera = FragmentCameraListBinding.inflate(inflater, container, false);

        itemList.clear();
        // Set up ListView adapter
        bindingRemoteCamera.listviewCamera.setAdapter(adapter);
        bindingRemoteCamera.listviewCamera.setChoiceMode(ListView.CHOICE_MODE_SINGLE);

        // Fetch camera information
        List<TmRemoteCamInfo> camInfoList = TmCamera.Companion.getRemoteCameraList();
        logRemoteCameraList(camInfoList);
        List<CameraListItem> connectedCameraList = cameraViewModel.getCameraList().getValue();
        if (connectedCameraList != null) {
            itemList.addAll(connectedCameraList);
        }

        for (TmRemoteCamInfo camInfo: camInfoList) {
            itemList.add(new CameraListItem(camInfo));
        }
        appendLocalCameras();

        // Item click listener to select a camera
        adapter.setOnItemClickListener(new CameraListAdapter.OnItemClickListener() {
            @Override
            public void onItemClick(View v, int pos) {
                CameraListItem selectedItem = (CameraListItem) adapter.getItem(pos);
                int cameraId = selectedItem.getId();

                // Highlight selected camera in MultiViewFragment
                Bundle bundle = new Bundle();
                bundle.putInt("cameraIndex", cameraId);
                MultiViewFragment multiViewFragment = (MultiViewFragment) requireActivity()
                        .getSupportFragmentManager()
                        .findFragmentByTag(MultiViewFragment.class.getSimpleName());
                if (multiViewFragment != null) {
                    multiViewFragment.setArguments(bundle);
                    multiViewFragment.changeImageViewBorder();
                }

                if (selectedItem.isConnected()) {
                    bindingRemoteCamera.buttonConnect.setText(R.string.disconnect);
                } else {
                    bindingRemoteCamera.buttonConnect.setText(R.string.connect);
                }
            }

        });

        // Long press listener to edit camera nickname
        adapter.setOnItemLongClickListener(new CameraListAdapter.OnItemLongClickListener() {
            @Override
            public void onItemLongClick(View v, int pos) {
                CameraListItem selectedItem = (CameraListItem) adapter.getItem(pos);
                editNicknameDialog(selectedItem);
            }
        });


        // Observe changes in the selected camera ID from the ViewModel.
        cameraViewModel.getSelectedCameraId().observe(getViewLifecycleOwner(), id -> {
            if (id >= 0) {
                // Ensure the selected camera feed is visually highlighted with a green border.
                bindingRemoteCamera.listviewCamera.post(() -> {
                    int index = 0;
                    // Find the index of the selected camera item in the list.
                    for (CameraListItem item: adapter.getItemList()) {
                        if (item.getId() == id) {
                            break;
                        }
                        index++;
                    }

                    // Retrieve the corresponding view in the ListView and simulate a click event.
                    View selectedItemView = bindingRemoteCamera.listviewCamera.getChildAt(index);
                    if (selectedItemView != null) {
                        selectedItemView.performClick();
                    }
                });
            }
        });

        // Set a click listener for the Scan button to refresh the camera list.
        bindingRemoteCamera.buttonScan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Retrieve the list of available remote cameras from network.
                List<TmRemoteCamInfo> camInfoList = TmCamera.Companion.getRemoteCameraList();
                logRemoteCameraList(camInfoList);
                // Get the list of currently connected cameras from the ViewModel.
                List<CameraListItem> connectedCameraList = cameraViewModel.getCameraList().getValue();
                // Clear the current camera list before updating.
                itemList.clear();
                // Add connected cameras to the list if available.
                if (connectedCameraList != null) {
                    itemList.addAll(connectedCameraList);
                }

                // Add newly discovered remote cameras to the list.
                for (TmRemoteCamInfo camInfo: camInfoList) {
                    itemList.add(new CameraListItem(camInfo));
                }
                appendLocalCameras();
                // Notify the adapter that the data set has changed to refresh the UI.
                adapter.notifyDataSetChanged();
            }
        });

        // Set a click listener for the Connect button to handle camera connection and disconnection.
        bindingRemoteCamera.buttonConnect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Get the selected camera item from the adapter.
                CameraListItem selectedItem = adapter.getSelectedItem();
                if (selectedItem != null) {
                    if (!selectedItem.isConnected()) {
                        if (selectedItem.isLocal()) {
                            connectLocalCamera(selectedItem);
                            return;
                        }
                        // Create a new camera instance.
                        TmCamera tmCamera = new TmCamera();

                        // Attempt to connect to the remote camera.
                        boolean ret = tmCamera.openRemoteCamera(
                                selectedItem.getName(),
                                selectedItem.getSerial(),
                                selectedItem.getMac(),
                                selectedItem.getIp());
                        // If connection fails, display an error message and exit.
                        if (!ret) {
                            Toast.makeText(requireContext(), "Cannot connect to the camera!", Toast.LENGTH_SHORT).show();
                            return;
                        }

                        if (!selectedItem.setConnected(true)) {
                            Toast.makeText(requireContext(), "Can not added camera!" + selectedItem, Toast.LENGTH_SHORT).show();
                            // If adding the camera fails, disconnect it.
                            tmCamera.closeRemoteCamera();
                        } else {
                            // Update UI to reflect the connected status.
                            bindingRemoteCamera.buttonConnect.setText(R.string.disconnect);
                            adapter.notifyDataSetChanged();
                            // Highlight the selected camera's view.
                            selectImageView(selectedItem.getId());
                            // Assign camera-related objects.
                            selectedItem.setTmCamera(tmCamera);
                            selectedItem.setTmRoiManager(new TmRoiManager());
                            // Store the camera in the ViewModel and map.
                            cameraViewModel.addCamera(selectedItem);
                            tmCameraMap.put(selectedItem.getKey(), tmCamera);
                            // Start fetching frames from the camera.
                            startFrameFetch(selectedItem);
                        }
                    } else {
                        // Stop the fetch loop first. The worker closes the camera after the loop exits.
                        bindingRemoteCamera.buttonConnect.setText(R.string.connect);
                        adapter.notifyDataSetChanged();
                        CameraListItem item = cameraViewModel.getCameraItem(selectedItem.getId());
                        cameraViewModel.removeCamera(selectedItem.getId());
                        selectedItem.setConnected(false);
                        if (item != null) {
                            item.setConnected(false);
                        }
                        tmCameraMap.remove(selectedItem.getKey());
                    }
                }
            }
        });

        cameraViewModel.getSelectedSingleCameraId().observe(getViewLifecycleOwner(), id -> {
            selectedSingleCameraId = id;
        });

        return bindingRemoteCamera.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        // If the item list is not empty, automatically select the first camera in the list.
        if (!itemList.isEmpty()) {
            bindingRemoteCamera.listviewCamera.post(() -> {
                View firstItemView = bindingRemoteCamera.listviewCamera.getChildAt(0);
                if (firstItemView != null) {
                    firstItemView.performClick();
                    cameraViewModel.setSelectedCameraId(0);
                }
            });
        }
    }

    private void logRemoteCameraList(List<TmRemoteCamInfo> remoteList) {
        Log.d(TAG, "getRemoteCameraList size=" + remoteList.size());
        for (TmRemoteCamInfo cam : remoteList) {
            Log.d(TAG, "remote name=" + cam.getName()
                    + " part=" + cam.getPartNumber()
                    + " serial=" + cam.getSerialNumber()
                    + " mac=" + cam.getAddrMAC()
                    + " ip=" + cam.getAddrIP()
                    + " adapter=" + cam.getAdapterIP()
                    + " media=" + cam.getMediaSourcesList().size());
        }
    }

    /**
     * Append USB local cameras from getLocalCameraList to the on-screen list.
     */
    private void appendLocalCameras() {
        if (getContext() == null) {
            return;
        }
        List<TmLocalCamInfo> localList = TmCamera.Companion.getLocalCameraList(requireContext());
        Log.d(TAG, "getLocalCameraList size=" + localList.size());
        for (TmLocalCamInfo cam : localList) {
            Log.d(TAG, "local name=" + cam.getName()
                    + " vid=" + String.format(Locale.US, "%04X", cam.getVendorId())
                    + " pid=" + String.format(Locale.US, "%04X", cam.getProductId())
                    + " device=" + cam.getDeviceName()
                    + " serial=" + cam.getSerialNumber()
                    + " uvc=" + cam.getHasUvc()
                    + " cdc=" + cam.getHasCdc()
                    + " media=" + cam.getMediaSourcesList().size());
            boolean alreadyListed = false;
            for (CameraListItem existing : itemList) {
                if (existing.isLocal() && cam.getDeviceName().equals(existing.getKey())) {
                    alreadyListed = true;
                    break;
                }
            }
            if (alreadyListed) {
                continue;
            }
            itemList.add(new CameraListItem(cam));
        }
    }

    private void connectLocalCamera(CameraListItem selectedItem) {
        TmLocalCamInfo info = selectedItem.getLocalCamInfo();
        if (info == null) {
            Toast.makeText(requireContext(), "USB camera info is missing.", Toast.LENGTH_SHORT).show();
            return;
        }
        // Android grants USB access to UVC devices only when CAMERA is already granted.
        if (ContextCompat.checkSelfPermission(requireContext(), Manifest.permission.CAMERA)
                != PackageManager.PERMISSION_GRANTED) {
            pendingUsbCamera = selectedItem;
            Log.d(TAG, "CAMERA permission missing; requesting before USB permission");
            requestPermissions(new String[]{Manifest.permission.CAMERA}, REQ_USB_CAMERA_PERMISSION);
            return;
        }
        requestUsbPermissionAndOpen(selectedItem);
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        if (requestCode != REQ_USB_CAMERA_PERMISSION) {
            return;
        }
        CameraListItem item = pendingUsbCamera;
        pendingUsbCamera = null;
        boolean granted = grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED;
        Log.d(TAG, "CAMERA permission result granted=" + granted);
        if (!granted || item == null) {
            Toast.makeText(requireContext(), "Camera permission is required for USB cameras.", Toast.LENGTH_SHORT).show();
            return;
        }
        requestUsbPermissionAndOpen(item);
    }

    private void requestUsbPermissionAndOpen(CameraListItem selectedItem) {
        TmLocalCamInfo info = selectedItem.getLocalCamInfo();
        if (info == null) {
            return;
        }
        TmCamera tmCamera = new TmCamera();
        boolean permitted = tmCamera.hasUsbPermission(requireContext(), info);
        Log.d(TAG, "connect local hasUsbPermission=" + permitted
                + " name=" + info.getName()
                + " device=" + info.getDeviceName());
        if (!permitted) {
            tmCamera.registerUsbPermissionReceiver(requireContext(), granted -> requireActivity().runOnUiThread(() -> {
                Log.d(TAG, "USB permission callback granted=" + granted);
                tmCamera.unregisterUsbPermissionReceiver();
                if (!granted) {
                    Toast.makeText(requireContext(),
                            "USB permission denied. Allow camera access and turn off the camera privacy toggle.",
                            Toast.LENGTH_LONG).show();
                    return;
                }
                finishLocalConnect(selectedItem, tmCamera, info);
            }));
            boolean alreadyGranted = tmCamera.requestUsbPermission(requireContext(), info);
            Log.d(TAG, "requestUsbPermission returned alreadyGranted=" + alreadyGranted);
            if (alreadyGranted) {
                tmCamera.unregisterUsbPermissionReceiver();
                finishLocalConnect(selectedItem, tmCamera, info);
                return;
            }
            Toast.makeText(requireContext(), "Allow USB access for the camera.", Toast.LENGTH_SHORT).show();
            return;
        }
        finishLocalConnect(selectedItem, tmCamera, info);
    }

    private void finishLocalConnect(CameraListItem selectedItem, TmCamera tmCamera, TmLocalCamInfo info) {
        Log.d(TAG, "openLocalCamera name=" + info.getName() + " mediaIndex=" + info.getMediaIndex());
        boolean ret = tmCamera.openLocalCamera(requireContext(), info, info.getMediaIndex());
        Log.d(TAG, "openLocalCamera result=" + ret);
        if (!ret) {
            Toast.makeText(requireContext(), "Cannot connect to the USB camera!", Toast.LENGTH_SHORT).show();
            return;
        }
        if (!selectedItem.setConnected(true)) {
            Toast.makeText(requireContext(), "Can not added camera!" + selectedItem, Toast.LENGTH_SHORT).show();
            tmCamera.closeLocalCamera();
            return;
        }
        bindingRemoteCamera.buttonConnect.setText(R.string.disconnect);
        adapter.notifyDataSetChanged();
        selectImageView(selectedItem.getId());
        selectedItem.setTmCamera(tmCamera);
        selectedItem.setTmRoiManager(new TmRoiManager());
        cameraViewModel.addCamera(selectedItem);
        tmCameraMap.put(selectedItem.getKey(), tmCamera);
        startFrameFetch(selectedItem);
    }

    /**
     * Displays an alert dialog to edit the camera's nickname.
     */
    private void editNicknameDialog(CameraListItem item) {
        // Create an AlertDialog to edit the nickname of the selected camera.
        AlertDialog.Builder builder = new AlertDialog.Builder(requireActivity());
        builder.setTitle("Edit Nickname:" + item.getNickName())
                .setMessage("Camera Name:" + item.getName() + "  " + item.getSubtitle());

        final EditText input = new EditText(getActivity());
        builder.setView(input);

        // Set the "OK" button to save the new nickname.
        builder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                String nickname = input.getText().toString().trim();

                item.setNickName(nickname);
                if (item.isConnected()) {
                    cameraViewModel.getCameraItem(item.getId()).setNickName(nickname);
                }

                adapter.notifyDataSetChanged();
            }
        });

        builder.setNegativeButton("Cancel", null);

        builder.show();
    }

    public void selectImageView(int cameraId) {
        // Create a bundle to pass the selected camera ID.
        Bundle bundle = new Bundle();
        bundle.putInt("cameraIndex", cameraId);
        // Find the MultiViewFragment by its tag.
        MultiViewFragment multiViewFragment = (MultiViewFragment) requireActivity()
                .getSupportFragmentManager()
                .findFragmentByTag(MultiViewFragment.class.getSimpleName());


        if (multiViewFragment != null) {
            multiViewFragment.setArguments(bundle);
            // Update the UI to highlight the selected camera feed.
            multiViewFragment.changeImageViewBorder();
        }
    }

    /**
     * Continuously fetches frames from the remote camera while it remains connected.
     * If the selected camera is in single-view mode, it fetches frames with the appropriate resolution.
     * Otherwise, it fetches frames at the default resolution.
     * <p>
     * Once the camera disconnects, it releases resources and updates the UI with a "no signal" image.
     *
     * @param item The remote camera item to fetch frames from.
     */
    private void startFrameFetch(CameraListItem item) {
        int itemId = item.getId();
        ExecutorService executor = Executors.newSingleThreadExecutor();
        executor.execute(() -> {
            // Retrieve the corresponding camera instance from the map
            TmCamera tmCamera = tmCameraMap.get(item.getKey());
            if (tmCamera == null) {
                return;
            }
            TmFrame tmFrame = new TmFrame();

            // Continuously fetch frames while the camera is connected
            while (item.isConnected()) {
                boolean ret = false;
                try {
                    ret = tmCamera.queryFrame(tmFrame);
                } catch (RuntimeException e) {
                    Log.e(TAG, "queryFrame failed", e);
                    item.setConnected(false);
                    break;
                }

                if (ret) {
                    processMeasurements(tmCamera, tmFrame, item);
                } else {
                    try {
                        Thread.sleep(15);
                    } catch (InterruptedException e) {
                        break;
                    }
                }
            }
            tmFrame.releaseTmFrame();
            if (item.isLocal()) {
                tmCamera.closeLocalCamera();
            } else {
                tmCamera.closeRemoteCamera();
            }
            // Display a "no signal" image when the camera is disconnected
            Bitmap noSignalBitmap = BitmapFactory.decodeResource(getResources(), R.drawable.no_signal);
            cameraViewModel.updateBitmapFrame(itemId, noSignalBitmap);
        });
    }

    public Bitmap convertBitmap(byte[] byteArray, int width, int height) {
        int[] pixels = new int[width * height];
        int pixelIndex = 0;

        // Convert the byte array into an ARGB pixel array
        for (int i = 0; i < byteArray.length; i += 3) {
            int r = byteArray[i] & 0xFF;
            int g = byteArray[i + 1] & 0xFF;
            int b = byteArray[i + 2] & 0xFF;

            // Convert RGB to ARGB (A = 255)
            pixels[pixelIndex] = (255 << 24) | (r << 16) | (g << 8) | b;
            pixelIndex++;
        }
        return Bitmap.createBitmap(pixels, width, height, Bitmap.Config.ARGB_8888);
    }

    /**
     * Processes the frame data from the remote camera, updates the UI, and triggers alarms if necessary.
     * <p>
     * This method performs the following steps:
     * 1. Checks if the received frame is valid.
     * 2. Converts the raw data into a Bitmap and updates the ViewModel.
     * 3. Performs temperature measurement using the Region of Interest (ROI) manager.
     * 4. Retrieves the minimum, maximum, and average temperature values.
     * 5. Triggers an alarm if the maximum temperature exceeds the threshold.
     * 6. Updates the temperature values in the ViewModel if the camera is in single-view mode.
     *
     * @param tmCamera The remote camera instance.
     * @param tmFrame The frame received from the remote camera.
     * @param item The camera item associated with the frame.
     */
    public void processMeasurements(TmCamera tmCamera, TmFrame tmFrame, CameraListItem item) {
        // Validate the frame before processing
        if (tmFrame == null || tmFrame.getWidth() <= 0 || tmFrame.getHeight() <= 0) {
            return;
        }
        // Convert the raw data to a Bitmap and update the UI
//        Bitmap frameBitmap = tmFrame.getBitmap(ColorOrder.COLOR_RGB);
        byte[] frameBitmap = tmFrame.getBitmap(ColorOrder.COLOR_RGB);
        int width = tmFrame.getWidth();
        int height = tmFrame.getHeight();
        if (frameBitmap != null) {
            Bitmap bitmap = convertBitmap(frameBitmap, width, height);
            cameraViewModel.updateBitmapFrame(item.getId(), bitmap);
        }
        // Perform temperature measurement using the ROI manager
        tmFrame.doMeasure(item.getTmRoiManager());
        // Retrieve temperature values and location of min/max temperature from the frame
        TempValueLoc temp = tmFrame.getMinMaxLoc();
        assert temp != null;
        Double maxVal = tmCamera.getTemperature(temp.getMaxVal());
        // Check if an alarm needs to be triggered based on the maximum temperature
        if (item.getAlarmEnable() && maxVal > item.getAlarmTemp()) {
                // Trigger alarm and highlight the camera feed in red
                Bundle bundle = new Bundle();
                bundle.putInt("cameraIndex", item.getId());
                MultiViewFragment multiViewFragment = (MultiViewFragment) requireActivity()
                        .getSupportFragmentManager()
                        .findFragmentByTag(MultiViewFragment.class.getSimpleName());
                if (multiViewFragment != null) {
                    multiViewFragment.setArguments(bundle);
                    multiViewFragment.alarmImageViewBorder();
                }
            //vibrate(requireContext());
            playNotificationSound(requireContext(), R.raw.warning);
        }
        // Update temperature values in the ViewModel if this is the selected single-view camera
        int selectedSingleCameraId = Objects.requireNonNull(cameraViewModel.getSelectedSingleCameraId().getValue());
        if (item.getId() == selectedSingleCameraId) {
            Double minVal = tmCamera.getTemperature(temp.getMinVal());
            Double avgVal = tmCamera.getTemperature(temp.getAvgVal());
            cameraViewModel.setMinTempVal(minVal);
            cameraViewModel.setAvgTempVal(avgVal);
            cameraViewModel.setMaxTempVal(maxVal);
        }
    }

    public void vibrate(Context context) {
        Vibrator vibrator = (Vibrator) context.getSystemService(Context.VIBRATOR_SERVICE);
        long milliseconds = 500;
        ExecutorService executor = Executors.newSingleThreadExecutor();
        if (vibrator != null && !vibe) {
            executor.execute(() -> {
                vibe = true;
                try {
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                        // API 26 (Oreo) 이상에서는 VibrationEffect 사용
                        vibrator.vibrate(VibrationEffect.createOneShot(milliseconds, VibrationEffect.DEFAULT_AMPLITUDE));
                    } else {
                        // API 26 미만에서는 직접 진동 실행
                        vibrator.vibrate(milliseconds);
                    }
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    throw new RuntimeException(e);
                }
                vibe = false;
            });
        }
    }

    /**
     * Plays a notification sound when an alarm condition is met.
     */
    public void playNotificationSound(Context context, int soundResId) {
        if (!ring) {
            ring = true;
            ExecutorService executor = Executors.newSingleThreadExecutor();
            executor.execute(() -> {
                MediaPlayer mediaPlayer = MediaPlayer.create(context, R.raw.warning);

                if (mediaPlayer != null) {
                    mediaPlayer.setOnCompletionListener(MediaPlayer::release);
                    mediaPlayer.start();
                }
            });
            ring = false;
        }
    }
}