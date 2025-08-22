package kr.co.thermoeye.android;

import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.MediaPlayer;
import android.os.Build;
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
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.ViewModelProvider;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import kr.co.thermoeye.android.databinding.FragmentCameraListBinding;
import kr.co.thermoeye.tmsdk.ColorOrder;
import kr.co.thermoeye.tmsdk.TempValueLoc;
import kr.co.thermoeye.tmsdk.TmCamera;
import kr.co.thermoeye.tmsdk.TmFrame;
import kr.co.thermoeye.tmsdk.TmRemoteCamInfo;
import kr.co.thermoeye.tmsdk.TmRoiManager;

public class CameraListFragment extends Fragment {
    private FragmentCameraListBinding bindingRemoteCamera;
    private RemoteCameraAdapter adapter;
    private List<RemoteCameraListItem> itemList;
    private CameraViewModel cameraViewModel;
    private final Map<String, TmCamera> tmCameraMap = new HashMap<>();
    private int selectedSingleCameraId = -1;
    private static boolean vibe = false;
    private static boolean ring = false;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        cameraViewModel = new ViewModelProvider(requireActivity()).get(CameraViewModel.class);
        itemList = new ArrayList<>();
        adapter = new RemoteCameraAdapter(getContext(), itemList);
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
        List<RemoteCameraListItem> connectedCameraList = cameraViewModel.getRemoteCameraList().getValue();
        if (connectedCameraList != null) {
            itemList.addAll(connectedCameraList);
        }

        for (TmRemoteCamInfo camInfo: camInfoList) {
            itemList.add(new RemoteCameraListItem(camInfo.getName(), camInfo.getAddrIP(), camInfo.getAddrMAC(), camInfo.getSerialNumber()));
        }

        // Item click listener to select a camera
        adapter.setOnItemClickListener(new RemoteCameraAdapter.OnItemClickListener() {
            @Override
            public void onItemClick(View v, int pos) {
                RemoteCameraListItem selectedItem = (RemoteCameraListItem) adapter.getItem(pos);
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
        adapter.setOnItemLongClickListener(new RemoteCameraAdapter.OnItemLongClickListener() {
            @Override
            public void onItemLongClick(View v, int pos) {
                RemoteCameraListItem selectedItem = (RemoteCameraListItem) adapter.getItem(pos);
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
                    for (RemoteCameraListItem item: adapter.getItemList()) {
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
                // Get the list of currently connected cameras from the ViewModel.
                List<RemoteCameraListItem> connectedCameraList = cameraViewModel.getRemoteCameraList().getValue();
                // Clear the current camera list before updating.
                itemList.clear();
                // Add connected cameras to the list if available.
                if (connectedCameraList != null) {
                    itemList.addAll(connectedCameraList);
                }

                // Add newly discovered remote cameras to the list.
                for (TmRemoteCamInfo camInfo: camInfoList) {
                    itemList.add(new RemoteCameraListItem(
                            camInfo.getName(),
                            camInfo.getAddrIP(),
                            camInfo.getAddrMAC(),
                            camInfo.getSerialNumber()));
                }
                // Notify the adapter that the data set has changed to refresh the UI.
                adapter.notifyDataSetChanged();
            }
        });

        // Set a click listener for the Connect button to handle camera connection and disconnection.
        bindingRemoteCamera.buttonConnect.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Get the selected camera item from the adapter.
                RemoteCameraListItem selectedItem = adapter.getSelectedItem();
                if (selectedItem != null) {
                    if (!selectedItem.isConnected()) {
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
                            cameraViewModel.addRemoteCamera(selectedItem);
                            tmCameraMap.put(selectedItem.getMac(), tmCamera);
                            // Start fetching frames from the camera.
                            startFrameFetch(selectedItem);
                        }
                    } else {
                        // If the camera is already connected, disconnect it.
                        bindingRemoteCamera.buttonConnect.setText(R.string.connect);
                        adapter.notifyDataSetChanged();
                        // Remove the camera from the ViewModel.
                        RemoteCameraListItem item = cameraViewModel.getRemoteCameraItem(selectedItem.getId());
                        cameraViewModel.removeRemoteCamera(selectedItem.getId());
                        // Update the connection status.
                        selectedItem.setConnected(false);
                        item.setConnected(false);
                        tmCameraMap.remove(selectedItem.getMac());
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

    /**
     * Displays an alert dialog to edit the camera's nickname.
     */
    private void editNicknameDialog(RemoteCameraListItem item) {
        // Create an AlertDialog to edit the nickname of the selected camera.
        AlertDialog.Builder builder = new AlertDialog.Builder(requireActivity());
        builder.setTitle("Edit Nickname:" + item.getNickName())
                .setMessage("Camera Name:" + item.getName() + "  IP:" + item.getIp());

        final EditText input = new EditText(getActivity());
        builder.setView(input);

        // Set the "OK" button to save the new nickname.
        builder.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                String nickname = input.getText().toString().trim();

                item.setNickName(nickname);
                if (item.isConnected()) {
                    cameraViewModel.getRemoteCameraItem(item.getId()).setNickName(nickname);
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
    private void startFrameFetch(RemoteCameraListItem item) {
        int itemId = item.getId();
        ExecutorService executor = Executors.newSingleThreadExecutor();
        executor.execute(() -> {
            // Retrieve the corresponding camera instance from the map
            TmCamera tmCamera = tmCameraMap.get(item.getMac());
            if (tmCamera == null) {
                return;
            }
            TmFrame tmFrame = new TmFrame();

            // Continuously fetch frames while the camera is connected
            while (item.isConnected()) {
                boolean ret = false;

                // Get the SingleViewFragment to check if the selected camera should be displayed in full view
                FragmentManager fragmentManager = getParentFragmentManager();
                SingleViewFragment singleViewFragment = (SingleViewFragment) fragmentManager.findFragmentByTag("SINGLE_VIEW_TAG");

                // Adjust frame fetching based on whether the camera is in single view mode
                if (selectedSingleCameraId == item.getId() && singleViewFragment != null) {
                    int width = singleViewFragment.getImageViewWidth();
                    int height = singleViewFragment.getImageViewHeight();
                    ret = tmCamera.queryFrame(tmFrame, width, height);
                } else {
                    ret = tmCamera.queryFrame(tmFrame);
                }

                // If a frame is successfully fetched, process the measurements
                if (ret) {
                    processMeasurements(tmCamera, tmFrame, item);
                }
            }
            // Release resources once the loop exits
            tmFrame.releaseTmFrame();
            tmCamera.closeRemoteCamera();
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
    public void processMeasurements(TmCamera tmCamera, TmFrame tmFrame, RemoteCameraListItem item) {
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
        RemoteCameraListItem remoteCamera = cameraViewModel.getRemoteCameraItem(item.getId());
        if (remoteCamera != null) {
            if (remoteCamera.getAlarmEnable() && maxVal > remoteCamera.getAlarmTemp()) {
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