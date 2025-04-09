package kr.co.thermoeye.android;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ExpandableListView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * SettingFragment is a Fragment that manages the settings view for the camera.
 * It displays a list of settings in an expandable list view.
 */
public class SettingFragment extends Fragment {
    private List<String> listDataHeader;
    private HashMap<String, List<String>> listChildData;
    private CameraViewModel cameraViewModel;
    private RemoteCameraListItem currentCamera = null;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // Get the CameraViewModel associated with the activity
        cameraViewModel = new ViewModelProvider(requireActivity()).get(CameraViewModel.class);
    }

    /**
     * Inflates the layout for this fragment and sets up the expandable list view.
     * Also sets up the back button and updates the camera title.
     *
     * @param inflater LayoutInflater object to inflate the view.
     * @param container Parent view that this fragment's UI will be attached to.
     * @param savedInstanceState A Bundle object containing previous saved states.
     * @return The inflated view for this fragment.
     */
    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_setting, container, false);

        ExpandableListView expandableListView = view.findViewById(R.id.expandableListView_setting);
        setupList();
        SettingExpandableListAdapter adapter = new SettingExpandableListAdapter(getContext(), listDataHeader, listChildData, expandableListView, cameraViewModel, this);
        expandableListView.setAdapter(adapter);

        expandableListView.expandGroup(0);

        TextView textViewTitle = view.findViewById(R.id.expandableListView_title);
        String cameraNickName = cameraViewModel.getRemoteCameraItem().getNickName();
        String cameraIP = cameraViewModel.getRemoteCameraItem().getIp();
        String title = String.format("%s %s", cameraNickName, cameraIP);
        textViewTitle.setText(title);

        // Get the current camera object from the ViewModel
        currentCamera = cameraViewModel.getRemoteCameraItem();

        // Update temperature settings in the adapter
        adapter.updateTemperatureSettings();



        // Set up the back button to navigate back
        Button buttonBack = view.findViewById(R.id.button_back);

        buttonBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                cameraViewModel.setSelectedSingleCameraId(-1);
                getParentFragmentManager().popBackStack();
            }
        });

        return view;
    }

    /**
     * Initializes the list of headers and their corresponding child data for the expandable list view.
     */
    private void setupList() {
        listDataHeader = new ArrayList<>();
        listChildData = new HashMap<>();

        // Define the headers for the expandable list
        listDataHeader.add("Temperature");
        listDataHeader.add("ColorMap");
        listDataHeader.add("Alarm");
        listDataHeader.add("ROI");
        listDataHeader.add("Camera Configuration");
        listDataHeader.add("Product Information");
        listDataHeader.add("Network Configuration");

        List<String> temperature = new ArrayList<>();
        temperature.add("Temperature");
        List<String> colormap = new ArrayList<>();
        colormap.add("ColorMap");
        List<String> alarm = new ArrayList<>();
        alarm.add("Alarm");
        List<String> roi = new ArrayList<>();
        roi.add("ROI");
        List<String> cameraConfig = new ArrayList<>();
        cameraConfig.add("Camera Configuration");
        List<String> productInfo = new ArrayList<>();
        productInfo.add("Product Information");
        List<String> networkConfig = new ArrayList<>();
        networkConfig.add("Network Configuration");

        listChildData.put(listDataHeader.get(0), temperature);
        listChildData.put(listDataHeader.get(1), colormap);
        listChildData.put(listDataHeader.get(2), alarm);
        listChildData.put(listDataHeader.get(3), roi);
        listChildData.put(listDataHeader.get(4), cameraConfig);
        listChildData.put(listDataHeader.get(5), productInfo);
        listChildData.put(listDataHeader.get(6), networkConfig);
    }

    public void disconnect() {
        currentCamera.setConnected(false);
        cameraViewModel.setSelectedSingleCameraId(-1);
        getParentFragmentManager().popBackStack();
    }
}
