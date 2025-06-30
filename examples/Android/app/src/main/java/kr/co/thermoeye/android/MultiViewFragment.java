package kr.co.thermoeye.android;

import android.annotation.SuppressLint;
import android.graphics.Color;
import android.graphics.drawable.GradientDrawable;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import java.util.List;
import java.util.Objects;

import kr.co.thermoeye.android.databinding.FragmentMultiViewBinding;

public class MultiViewFragment extends Fragment {
    private final int IMAGE_VIEW_CNT = 4;
    private final ImageView[] imageViews = new ImageView[IMAGE_VIEW_CNT];
    private CameraViewModel cameraViewModel;
    private int imageViewWidth = 0;
    private int imageViewHeight = 0;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        cameraViewModel = new ViewModelProvider(requireActivity()).get(CameraViewModel.class);
    }

    @SuppressLint("ClickableViewAccessibility")
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        FragmentMultiViewBinding bindingCameraView = FragmentMultiViewBinding.inflate(inflater, container, false);

        // Initialize the imageViews array with the image views from the binding layout
        imageViews[0] = bindingCameraView.imageView1;
        imageViews[1] = bindingCameraView.imageView2;
        imageViews[2] = bindingCameraView.imageView3;
        imageViews[3] = bindingCameraView.imageView4;

        // Set onTouchListener for each imageView to handle touch events
        for (int i = 0; i < IMAGE_VIEW_CNT; i++) {
            int finalI = i;
            imageViews[i].setOnTouchListener(new View.OnTouchListener() {
                private static final long DOUBLE_CLICK_TIME_DELTA = 300;
                private long lastClickTime = 0;

                @Override
                public boolean onTouch(View v, MotionEvent event) {
                    if (event.getAction() == MotionEvent.ACTION_UP) {
                        long clickTime = System.currentTimeMillis();
                        if (clickTime - lastClickTime < DOUBLE_CLICK_TIME_DELTA) {
                            // Handle double click: navigate to the SingleViewFragment
                            navigateToImageFragment(finalI);
                            v.performClick();
                        } else {
                            // Handle single click: update selected camera
                            int prevCameraId = Objects.requireNonNull(cameraViewModel.getSelectedCameraId().getValue());
                            if (prevCameraId >= 0 &&
                                    cameraViewModel.getRemoteCameraItem(finalI) != null &&
                                    cameraViewModel.getRemoteCameraItem(finalI).isConnected()) {
                                setImageViewBorder(imageViews[prevCameraId], R.color.back_ground);
                                cameraViewModel.setSelectedCameraId(finalI);
                            }
                        }
                        lastClickTime = clickTime;
                    }
                    return true;
                }
            });
        }

        // Observe the selected camera ID and update the border of the corresponding image view
        cameraViewModel.getBitmapFrame(0).observe(getViewLifecycleOwner(), bitmap -> {
            if (bitmap != null) {
                imageViews[0].setPadding(2, 1, 2, 1);
                imageViews[0].setImageBitmap(bitmap);
            }
        });
        cameraViewModel.getBitmapFrame(1).observe(getViewLifecycleOwner(), bitmap -> {
            if (bitmap != null) {
                imageViews[1].setPadding(2, 1, 2, 1);
                imageViews[1].setImageBitmap(bitmap);
            }
        });
        cameraViewModel.getBitmapFrame(2).observe(getViewLifecycleOwner(), bitmap -> {
            if (bitmap != null) {
                imageViews[2].setPadding(2, 1, 2, 1);
                imageViews[2].setImageBitmap(bitmap);
            }
        });
        cameraViewModel.getBitmapFrame(3).observe(getViewLifecycleOwner(), bitmap -> {
            if (bitmap != null) {
                imageViews[3].setPadding(2, 1, 2, 1);
                imageViews[3].setImageBitmap(bitmap);
            }
        });

        cameraViewModel.getSelectedCameraId().observe(getViewLifecycleOwner(), id -> {
            if (id > -1 && id < IMAGE_VIEW_CNT) {
                setImageViewBorder(imageViews[id], Color.GREEN);

            }
        });

        return bindingCameraView.getRoot();
    }

    public int getImageViewWidth() {
        return imageViewWidth;
    }

    public int getImageViewHeight() {
        return imageViewHeight;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        ImageView imageView = view.findViewById(R.id.imageView1);

        imageView.post(new Runnable() {
            @Override
            public void run() {
                imageViewWidth = imageView.getWidth();
                imageViewHeight = imageView.getHeight();
            }
        });
    }

    /**
     * Navigates to the SingleViewFragment and SettingFragment based on the given image index.
     *
     * @param imageIndex The index of the image (camera) to navigate to.
     */
    private void navigateToImageFragment(int imageIndex) {
        // Retrieve the list of remote camera items from the ViewModel.
        List<RemoteCameraListItem> cameraItems = cameraViewModel.getRemoteCameraList().getValue();
        if (cameraItems == null) {
            return;
        }
        // Check if the given image index corresponds to a connected camera.
        boolean connectedCamera = false;
        for (RemoteCameraListItem item: cameraItems) {
            if (item.getId() == imageIndex) {
                connectedCamera = true;
            }
        }

        if (!connectedCamera) {
            return;
        }

        // Create instances of SingleViewFragment and SettingFragment.
        SingleViewFragment singleViewFragment = new SingleViewFragment();
        SettingFragment settingFragment = new SettingFragment();
        // Create a bundle to pass the selected camera index.
        Bundle bundle = new Bundle();
        bundle.putInt("cameraIndex", imageIndex);
        // Set the bundle arguments for both fragments.
        singleViewFragment.setArguments(bundle);
        settingFragment.setArguments(bundle);

        // Update the ViewModel with the selected camera index.
        cameraViewModel.setSelectedSingleCameraId(imageIndex);

        // Begin a fragment transaction to replace the current fragments.
        getParentFragmentManager().beginTransaction()
                .replace(R.id.fragment_container_view, singleViewFragment, "SINGLE_VIEW_TAG")
                .replace(R.id.fragment_container_ctrl, settingFragment)
                .addToBackStack(null)
                .commit();
    }

    /**
     * Updates the border color of image views to indicate the selected camera.
     */
    public void changeImageViewBorder() {
        // Retrieve arguments passed to the fragment.
        Bundle bundle = getArguments();
        if (bundle != null) {
            // Get the selected camera index, defaulting to -1 if not found.
            int index = bundle.getInt("cameraIndex", -1);
            // Reset all image view borders to the default background color.
            GradientDrawable border = new GradientDrawable();
            for (int i = 0; i < IMAGE_VIEW_CNT; i++) {
                setImageViewBorder(imageViews[i], R.color.back_ground);
            }
            // If a valid camera index is provided, highlight it with a green border.
            if (index > -1) {
                setImageViewBorder(imageViews[index], Color.GREEN);
            }
        }
    }

    /**
     * Updates the border color of image views to indicate an alarm state.
     */
    public void alarmImageViewBorder() {
        Bundle bundle = getArguments();
        if (bundle != null) {
            int index = bundle.getInt("cameraIndex", -1);
            GradientDrawable border = new GradientDrawable();
            for (int i = 0; i < IMAGE_VIEW_CNT; i++) {
                setImageViewBorder(imageViews[i], R.color.back_ground);
            }
            if (index > -1) {
                setImageViewBorder(imageViews[index], Color.RED);
            }
        }
    }

    /**
     * Sets the border color of the given ImageView.
     *
     * @param imageView The ImageView whose border needs to be updated.
     * @param color The color to set for the border.
     */
    private void setImageViewBorder(ImageView imageView, int color) {
        GradientDrawable border = new GradientDrawable();
        border.setStroke(2, color);
        imageView.setBackground(border);
    }

}