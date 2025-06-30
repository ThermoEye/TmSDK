package kr.co.thermoeye.android;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.DialogInterface;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.BaseExpandableListAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ExpandableListView;
import android.widget.Spinner;
import android.widget.Switch;
import android.widget.TextView;

import androidx.appcompat.app.AlertDialog;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import java.util.HashMap;
import java.util.List;
import java.util.Objects;

import kr.co.thermoeye.tmsdk.ColorMapTypes;
import kr.co.thermoeye.tmsdk.GainMode;
import kr.co.thermoeye.tmsdk.NetworkConfiguration;
import kr.co.thermoeye.tmsdk.RoiType;
import kr.co.thermoeye.tmsdk.TempUnit;
import kr.co.thermoeye.tmsdk.TmCamera;
import kr.co.thermoeye.tmsdk.TmControl;

/**
 * Adapter for managing an expandable list in the settings screen.
 * This adapter handles different setting categories and their respective child items.
 */
public class SettingExpandableListAdapter extends BaseExpandableListAdapter {
    private final Context context;
    private final List<String> listDataHeader;
    private final HashMap<String, List<String>> listChildData;
    private CameraViewModel cameraViewModel;
    private RemoteCameraListItem currentCamera;
    private TmCamera tmCamera;
    private TmControl tmCtrl;
    private final Fragment fragment;

    public SettingExpandableListAdapter(Context context, List<String> listDataHeader,
                                        HashMap<String, List<String>> listChildData,
                                        ExpandableListView expandableListView,
                                        CameraViewModel cameraViewModel, Fragment fragment) {
        this.context = context;
        this.listDataHeader = listDataHeader;
        this.listChildData = listChildData;
        this.cameraViewModel = cameraViewModel;
        this.fragment = fragment;
    }

    /**
     * Returns the number of groups (categories) in the expandable list.
     *
     * @return The total number of setting categories.
     */
    @Override
    public int getGroupCount() {
        return listDataHeader.size();
    }

    /**
     * Returns the number of children (setting options) within a specific group.
     *
     * @param groupPosition The position of the group.
     * @return The number of child items in the specified group.
     */
    @Override
    public int getChildrenCount(int groupPosition) {
        return Objects.requireNonNull(listChildData.get(listDataHeader.get(groupPosition))).size();
    }

    /**
     * Retrieves the group (category) at a given position.
     *
     * @param groupPosition The index of the group.
     * @return The group name as a String.
     */
    @Override
    public Object getGroup(int groupPosition) {
        return listDataHeader.get(groupPosition);
    }

    /**
     * Retrieves a child item at a given position within a group.
     *
     * @param groupPosition The index of the group.
     * @param childPosition The index of the child within the group.
     * @return The child item as a String.
     */
    @Override
    public Object getChild(int groupPosition, int childPosition) {
        return Objects.requireNonNull(listChildData.get(listDataHeader.get(groupPosition))).get(childPosition);
    }

    @Override
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    @Override
    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }

    @Override
    public boolean hasStableIds() {
        return false;
    }

    /**
     * Generates and returns the view for a group (category) in the list.
     *
     * @param groupPosition The position of the group.
     * @param isExpanded Indicates whether the group is expanded or collapsed.
     * @param convertView The recycled view to populate.
     * @param parent The parent view that this view will be attached to.
     * @return The view representing the group item.
     */
    @Override
    public View getGroupView(int groupPosition, boolean isExpanded, View convertView, ViewGroup parent) {
        String headerTitle = (String) getGroup(groupPosition);
        if (convertView == null) {
            LayoutInflater inflater = (LayoutInflater) this.context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.setting_list_group, parent, false);
        }

        TextView lblListHeader = convertView.findViewById(R.id.textView_settingListGroup);
        lblListHeader.setText(headerTitle);

        return convertView;
    }

    /**
     * Generates and returns the view for a child item in the list.
     *
     * @param groupPosition The position of the group.
     * @param childPosition The position of the child within the group.
     * @param isLastChild Whether this child is the last item in the group.
     * @param convertView The recycled view to populate.
     * @param parent The parent view that this view will be attached to.
     * @return The view representing the child item.
     */
    @Override
    public View getChildView(int groupPosition, int childPosition, boolean isLastChild, View convertView, ViewGroup parent) {
        String groupName = listDataHeader.get(groupPosition);
        LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        cameraViewModel = new ViewModelProvider((FragmentActivity)context).get(CameraViewModel.class);
        currentCamera = cameraViewModel.getRemoteCameraItem();
        tmCamera = currentCamera.getTmCamera();
        tmCtrl = tmCamera.getTmControl();

        if (convertView == null || !isCorrectLayout(convertView, groupName)) {
            switch (groupName) {
                case "Temperature":
                    convertView = inflater.inflate(R.layout.setting_temperature, parent, false);
                    break;
                case "ColorMap":
                    convertView = inflater.inflate(R.layout.setting_colormap, parent, false);
                    break;
                case "Alarm":
                    convertView = inflater.inflate(R.layout.setting_alarm, parent, false);
                    break;
                case "ROI":
                    convertView = inflater.inflate(R.layout.setting_roi, parent, false);
                    break;
                case "Camera Configuration":
                    convertView = inflater.inflate(R.layout.setting_camera_config, parent, false);
                    break;
                case "Product Information":
                    convertView = inflater.inflate(R.layout.setting_product_information, parent, false);
                    break;
                case "Network Configuration":
                    convertView = inflater.inflate(R.layout.setting_network_config, parent, false);
                    break;
            }
        }


        if (groupName.equals("Temperature") && childPosition == 0) {
            handleTemperature(convertView, parent, inflater);
        } else if (groupName.equals("ColorMap") && childPosition == 0) {
            handleColorMap(convertView, parent, inflater);
        } else if (groupName.equals("Alarm") && childPosition == 0) {
            handleAlarm(convertView, parent, inflater);
        } else if (groupName.equals("ROI") && childPosition == 0) {
            handleRoi(convertView, parent, inflater);
        } else if (groupName.equals("Camera Configuration") && childPosition == 0) {
            handleCameraConfig(convertView, parent, inflater);
        } else if (groupName.equals("Product Information") && childPosition == 0) {
            handleProductInformation(convertView, parent, inflater);
        } else if (groupName.equals("Network Configuration") && childPosition == 0) {
            handleNetworkConfig(convertView, parent, inflater);
        }

        return convertView;
    }

    @Override
    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }

    public void updateTemperatureSettings() {
        notifyDataSetChanged();
    }

    /**
     * Checks if the given convertView matches the correct layout for the specified group.
     *
     * @param convertView The current view.
     * @param groupName The name of the group.
     * @return True if the view matches the expected layout, false otherwise.
     */
    private boolean isCorrectLayout(View convertView, String groupName) {
        if (groupName.equals("Temperature") && convertView.getId() != R.id.setting_temperature) {
            return false;
        } else if (groupName.equals("ColorMap") && convertView.getId() != R.id.setting_colormap) {
            return false;
        } else if (groupName.equals("Alarm") && convertView.getId() != R.id.setting_alarm) {
            return false;
        } else if (groupName.equals("ROI") && convertView.getId() != R.id.setting_roi) {
            return false;
        } else if (groupName.equals("Camera Configuration") && convertView.getId() != R.id.setting_camera_config) {
            return false;
        } else if (groupName.equals("Product Information") && convertView.getId() != R.id.setting_product_information) {
            return false;
        } else
            return !groupName.equals("Network Configuration") || convertView.getId() == R.id.setting_network_config;
    }

    /**
     * Handles the temperature settings UI within the given view.
     * This method initializes temperature-related UI components, observes temperature values,
     * and updates the displayed temperature information dynamically.
     *
     * @param convertView The view containing temperature-related UI elements.
     * @param parent The parent view that this view will be attached to.
     * @param inflater The layout inflater for inflating additional views if needed.
     */
    private void handleTemperature(View convertView, ViewGroup parent, LayoutInflater inflater) {
        TextView textViewMinTempVal = convertView.findViewById(R.id.textView_minTempVal);
        TextView textViewAvgTempVal = convertView.findViewById(R.id.textView_avgTempVal);
        TextView textViewMaxTempVal = convertView.findViewById(R.id.textView_maxTempVal);
        Spinner spinnerTemp = convertView.findViewById(R.id.spinner_temp);
        // Retrieve the current temperature unit from the camera
        TempUnit tempUnit = tmCamera.getTempUnit();
        assert tempUnit != null;
        spinnerTemp.setSelection(tempUnit.getTempUnit());

        // Observe and update the minimum temperature value dynamically
        cameraViewModel.getMinTempVal().observe((FragmentActivity) context, new Observer<Double>() {
            @SuppressLint("DefaultLocale")
            @Override
            public void onChanged(Double value) {
                String tempUnitSymbol = tmCamera.getTempUnitSymbol();
                textViewMinTempVal.setText(String.format("%.1f %s", value, tempUnitSymbol));
            }
        });
        // Observe and update the average temperature value dynamically
        cameraViewModel.getAvgTempVal().observe((FragmentActivity) context, new Observer<Double>() {
            @SuppressLint("DefaultLocale")
            @Override
            public void onChanged(Double value) {
                String tempUnitSymbol = tmCamera.getTempUnitSymbol();
                textViewAvgTempVal.setText(String.format("%.1f %s", value, tempUnitSymbol));
            }
        });
        // Observe and update the maximum temperature value dynamically
        cameraViewModel.getMaxTempVal().observe((FragmentActivity) context, new Observer<Double>() {
            @SuppressLint("DefaultLocale")
            @Override
            public void onChanged(Double value) {
                String tempUnitSymbol = tmCamera.getTempUnitSymbol();
                textViewMaxTempVal.setText(String.format("%.1f %s", value, tempUnitSymbol));
            }
        });

        // Handle temperature unit selection changes
        spinnerTemp.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                TempUnit tempUnit = TempUnit.Companion.fromInt(position);
                assert tempUnit != null;
                tmCamera.setTempUnit(tempUnit);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
    }

    /**
     * Handles the color map selection for the camera.
     * This method initializes the color map selection spinner, sets the current selection,
     * and updates the camera's color map settings when the user selects a different option.
     *
     * @param convertView The view containing the color map selection UI element.
     * @param parent The parent view that this view will be attached to.
     * @param inflater The layout inflater for inflating additional views if needed.
     */
    private void handleColorMap(View convertView, ViewGroup parent, LayoutInflater inflater) {
        Spinner spinnerColorMap = convertView.findViewById(R.id.spinner_colorMap);
        // Set the currently selected color map based on the camera's settings
        spinnerColorMap.setSelection(currentCamera.getColorMapTypes().getColorMapType());

        // Handle color map selection changes
        spinnerColorMap.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                String selectedItem = parent.getItemAtPosition(position).toString();
                ColorMapTypes type = ColorMapTypes.Companion.fromInt(position);
                assert type != null;
                // Update the camera's color map settings
                tmCamera.setColorMap(type);
                currentCamera.setColorMapTypes(type);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
    }

    /**
     * Handles the alarm settings for the camera.
     * This method initializes and manages the alarm toggle switch and temperature threshold input field.
     * It allows the user to enable or disable the alarm and set a temperature threshold.
     *
     * @param convertView The view containing the alarm settings UI elements.
     * @param parent The parent view that this view will be attached to.
     * @param inflater The layout inflater for inflating additional views if needed.
     */
    @SuppressLint({"DefaultLocale"})
    private void handleAlarm(View convertView, ViewGroup parent, LayoutInflater inflater) {
        @SuppressLint("UseSwitchCompatOrMaterialCode")
        Switch switchAlarm = convertView.findViewById(R.id.switch_alramOnOff);
        EditText editTextAlarmThresholdTemp = convertView.findViewById(R.id.editText_alarmThresholdTemperature);
        // Get the temperature unit symbol (e.g., °C or °F)
        String tempUnitSymbol = tmCamera.getTempUnitSymbol();
        editTextAlarmThresholdTemp.setText(String.format("%.2f %s", currentCamera.getAlarmTemp(), tempUnitSymbol));
        // Set the initial state of the alarm switch (enabled or disabled)
        switchAlarm.setChecked(currentCamera.getAlarmEnable());
        editTextAlarmThresholdTemp.setSelection(editTextAlarmThresholdTemp.getText().length());

        // Handle changes in the alarm switch state
        switchAlarm.setOnCheckedChangeListener((buttonView, isChecked) -> {
            if (isChecked) {
                switchAlarm.setText(R.string.on);
                currentCamera.setAlarmEnable(true);
            } else {
                switchAlarm.setText(R.string.off);
                currentCamera.setAlarmEnable(false);
            }
        });

        // Handle user input in the temperature threshold field
        editTextAlarmThresholdTemp.setOnEditorActionListener((v, actionId, event) -> {
            if (actionId == EditorInfo.IME_ACTION_DONE) {
                // When the "Done" button is pressed, clear focus from the EditText field
                editTextAlarmThresholdTemp.clearFocus();
                InputMethodManager imm = (InputMethodManager) ContextCompat.getSystemService(context, InputMethodManager.class);
                if (imm != null) {
                    imm.hideSoftInputFromWindow(editTextAlarmThresholdTemp.getWindowToken(), 0);
                }
                String input = editTextAlarmThresholdTemp.getText().toString();
                if (!input.isEmpty()) {
                    String numberString = input.replaceAll("[^0-9.]", "");
                    double value = Double.parseDouble(numberString);
                    currentCamera.setAlarmTemp(value);
                }
                return true;
            }
            return false;
        });
    }

    /**
     * Handles the Region of Interest (ROI) selection for the camera.
     * This method initializes and manages the ROI selection spinner and the "Remove All" button.
     * Users can select an ROI type from the spinner or clear all ROIs using the button.
     *
     * @param convertView The view containing the ROI settings UI elements.
     * @param parent The parent view that this view will be attached to.
     * @param inflater The layout inflater for inflating additional views if needed.
     */
    private void handleRoi(View convertView, ViewGroup parent, LayoutInflater inflater) {
        Spinner spinnerRoi = convertView.findViewById(R.id.spinner_roi);
        Button buttonRemoveAll = convertView.findViewById(R.id.button_removeAllRoi);

        // Observe changes in ROI action completion
        cameraViewModel.getRoiActionDone().observe((FragmentActivity) context, new Observer<Boolean>() {
            @Override
            public void onChanged(Boolean value) {
                Spinner spinnerRoi = convertView.findViewById(R.id.spinner_roi);
                spinnerRoi.setSelection(0);
            }
        });

        // Handle ROI selection changes in the spinner
        spinnerRoi.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                RoiType type = RoiType.Companion.fromInt(position);
                assert type != null;
                // Set the selected ROI type in the camera's ROI manager
                currentCamera.getTmRoiManager().setSelectedRoiType(type);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });

        // Handle "Remove All" button click to clear all ROIs
        buttonRemoveAll.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                currentCamera.getTmRoiManager().clear();
            }
        });
    }

    /**
     * Handles the camera gain mode configuration.
     * This method initializes the switch that allows users to toggle between HIGH and LOW gain modes.
     *
     * @param convertView The view containing the camera configuration UI elements.
     * @param parent The parent view that this view will be attached to.
     * @param inflater The layout inflater for inflating additional views if needed.
     */
    private void handleCameraConfig(View convertView, ViewGroup parent, LayoutInflater inflater) {
        @SuppressLint("UseSwitchCompatOrMaterialCode")
        Switch switchCameraConfig = convertView.findViewById(R.id.switch_gain_mode);
        // Get the current gain mode from the camera controller
        GainMode gainMode = tmCtrl.getGainMode();
        if (gainMode == GainMode.HIGH) {
            switchCameraConfig.setChecked(false);
        } else {
            switchCameraConfig.setChecked(true);
        }

        // Handle switch state change event
        switchCameraConfig.setOnCheckedChangeListener((buttonView, isChecked) -> {
            if (isChecked) {
                tmCtrl.setGainMode(GainMode.LOW);
            } else {
                tmCtrl.setGainMode(GainMode.HIGH);
            }
        });
    }

    /**
     * Handles the display of product information.
     * This method retrieves and displays various hardware and firmware details about the camera.
     *
     * @param convertView The view containing the product information UI elements.
     * @param parent The parent view that this view will be attached to.
     * @param inflater The layout inflater for inflating additional views if needed.
     */
    private void handleProductInformation(View convertView, ViewGroup parent, LayoutInflater inflater) {
        TextView modelName = convertView.findViewById(R.id.textView_productModelVal);
        TextView serial = convertView.findViewById(R.id.textView_productSerialVal);
        TextView hwVer = convertView.findViewById(R.id.textView_hwVersionVal);
        TextView blVer = convertView.findViewById(R.id.textView_bootloaderVersionVal);
        TextView fwVer = convertView.findViewById(R.id.textView_fwVersionVal);
        TextView sensorModel = convertView.findViewById(R.id.textView_sensorModelVal);
        TextView sensorSerial = convertView.findViewById(R.id.textView_sensorSerialVal);
        TextView sensorUptime = convertView.findViewById(R.id.textView_sensorUptimeVal);
        modelName.setText(tmCtrl.getProductModelName());
        serial.setText(tmCtrl.getProductSerialNumber());
        hwVer.setText(tmCtrl.getHardwareVersion());
        blVer.setText(tmCtrl.getBootloaderVersion());
        fwVer.setText(tmCtrl.getFirmwareVersion());
        sensorModel.setText(tmCtrl.getSensorModelName());
        sensorSerial.setText(tmCtrl.getSensorSerialNumber());
        sensorUptime.setText(tmCtrl.getSensorUptime());
    }

    /**
     * Handles the network configuration settings.
     * This method allows users to configure network settings such as IP address, gateway, and DNS.
     *
     * @param convertView The view containing the network configuration UI elements.
     * @param parent The parent view that this view will be attached to.
     * @param inflater The layout inflater for inflating additional views if needed.
     */
    private void handleNetworkConfig(View convertView, ViewGroup parent, LayoutInflater inflater) {
        EditText editTextMac = convertView.findViewById(R.id.editText_networkMacVal);
        Spinner spinnerIpAssign = convertView.findViewById(R.id.spinner_networkIpAssignment);
        EditText editTextIp = convertView.findViewById(R.id.editText_networkIpVal);
        EditText editTextGateway = convertView.findViewById(R.id.editText_networkGatewayVal);
        EditText editTextNetmask = convertView.findViewById(R.id.editText_networkNetmaskVal);
        EditText editTextDns1 = convertView.findViewById(R.id.editText_networkDns1Val);
        EditText editTextDns2 = convertView.findViewById(R.id.editText_networkDns2Val);
        Button buttonSave = convertView.findViewById(R.id.button_networkSet);

        NetworkConfiguration netConfig = tmCtrl.getNetworkConfig();

        editTextMac.setText(netConfig.getMac());
        spinnerIpAssign.setSelection(netConfig.getIpAssign().equals("DHCP") ? 0 : 1);
        editTextIp.setText(netConfig.getIp());
        editTextNetmask.setText(netConfig.getNetmask());
        editTextGateway.setText(netConfig.getGateway());
        editTextDns1.setText(netConfig.getDns());
        editTextDns2.setText(netConfig.getDns2());

        buttonSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                netConfig.setIpAssign(spinnerIpAssign.getSelectedItem().toString());
                netConfig.setIp(editTextIp.getText().toString());
                netConfig.setNetmask(editTextNetmask.getText().toString());
                netConfig.setGateway(editTextNetmask.getText().toString());
                netConfig.setDns(editTextDns1.getText().toString());
                netConfig.setDns2(editTextDns2.getText().toString());

                boolean ret = tmCtrl.setNetworkConfig(netConfig);
                if (ret) {
                    showAlertDialog();
                }
            }
        });
    }

    private void showAlertDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setTitle("Notice")
                .setMessage("Restart the camera to configure network settings.")
                .setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        tmCtrl.rebootDevice();
                        dialog.dismiss();
                        if (fragment != null) {
                            if (fragment instanceof SettingFragment) {
                                ((SettingFragment) fragment).disconnect();
                            }
                        }
                    }
                })
                .setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.dismiss();
                    }
                });

        AlertDialog alertDialog = builder.create();
        alertDialog.show();
    }
}
