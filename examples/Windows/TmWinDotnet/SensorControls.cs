/******************************************************************
 * Project: TmSDK
 * File: SensorControl.cpp
 *
 * Description: This file contains the following implementations:
 * - Get Flat Field Correction mode
 * - Set Flat Field Correction mode
 * - Run Flat Field Correction mode
 * - Get flux parameters
 * - Set flux parameters
 * - Get Flat Field Correction parameters
 * - Set Flat Field Correction parameters
 * - Store sensor configuration
 * - Restore sensor configuration
 *
 * Version: 1.0.0
 * Copyright 2024. Thermoeye Inc. All rights reserved.
 *
 * History:
 *      2024-08-19: Initial version.
 ****************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TmSDK;

namespace TmWinDotNet
{
    public partial class MainForm
    {
        #region Sensor Control
        private void button_SensorControl_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && tmCamera != null && tmCamera.IsOpen)
            {
                switch (btn.Name)
                {
                    case "button_GetFluxParameters_160":
                        if (tmCamera.tmControl.GetFluxParameters160(out double sceneEmissivity, out double atmosphericTransmission,
                                                              out double atmosphericTemperature, out double windowReflectedTemperature,
                                                              out double windowReflection, out double backgroundTemperature,
                                                              out double windowTransmission, out double windowTemperature))
                        {
                            numericUpDown_FluxParam160_SceneEmissivity.Value = Convert.ToDecimal(sceneEmissivity);
                            numericUpDown_FluxParam160_BackgroundTemperature.Value = Convert.ToDecimal(backgroundTemperature);
                            numericUpDown_FluxParam160_WindowTransmission.Value = Convert.ToDecimal(windowTransmission);
                            numericUpDown_FluxParam160_WindowTemperature.Value = Convert.ToDecimal(windowTemperature);
                            numericUpDown_FluxParam160_AtmosphericTransmission.Value = Convert.ToDecimal(atmosphericTransmission);
                            numericUpDown_FluxParam160_AtmosphericTemperature.Value = Convert.ToDecimal(atmosphericTemperature);
                            numericUpDown_FluxParam160_WindowReflection.Value = Convert.ToDecimal(windowReflection);
                            numericUpDown_FluxParam160_WindowReflectedTemperature.Value = Convert.ToDecimal(windowReflectedTemperature);

                            numericUpDown_FluxParam160_SceneEmissivity.Enabled = true;
                            numericUpDown_FluxParam160_BackgroundTemperature.Enabled = true;
                            numericUpDown_FluxParam160_WindowTransmission.Enabled = true;
                            numericUpDown_FluxParam160_WindowTemperature.Enabled = true;
                            numericUpDown_FluxParam160_AtmosphericTransmission.Enabled = true;
                            numericUpDown_FluxParam160_AtmosphericTemperature.Enabled = true;
                            numericUpDown_FluxParam160_WindowReflection.Enabled = true;
                            numericUpDown_FluxParam160_WindowReflectedTemperature.Enabled = true;
                            textBox_FluxParam160_SceneEmissivityRange.Enabled = true;
                            textBox_FluxParam160_BackgroundTemperatureRange.Enabled = true;
                            textBox_FluxParam160_WindowTransmissionRange.Enabled = true;
                            textBox_FluxParam160_WindowTemperatureRange.Enabled = true;
                            textBox_FluxParam160_AtmosphericTransmissionRange.Enabled = true;
                            textBox_FluxParam160_AtmosphericTemperatureRange.Enabled = true;
                            textBox_FluxParam160_WindowReflectionRange.Enabled = true;
                            textBox_FluxParam160_WindowReflectedTemperatureRange.Enabled = true;
                            button_SetFluxParameters_160.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to get Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFluxParameters_160":
                        double sceneEmissivitySet = Convert.ToDouble(numericUpDown_FluxParam160_SceneEmissivity.Value);
                        double atmosphericTransmissionSet = Convert.ToDouble(numericUpDown_FluxParam160_AtmosphericTransmission.Value);
                        double atmosphericTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam160_AtmosphericTemperature.Value);
                        double windowReflectedTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam160_WindowReflectedTemperature.Value);
                        double windowReflectionSet = Convert.ToDouble(numericUpDown_FluxParam160_WindowReflection.Value);
                        double backgroundTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam160_BackgroundTemperature.Value);
                        double windowTransmissionSet = Convert.ToDouble(numericUpDown_FluxParam160_WindowTransmission.Value);
                        double windowTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam160_WindowTemperature.Value);

                        if (tmCamera.tmControl.SetFluxParameters(sceneEmissivitySet, atmosphericTransmissionSet,
                                                              atmosphericTemperatureSet, windowReflectedTemperatureSet,
                                                              windowReflectionSet, backgroundTemperatureSet,
                                                              windowTransmissionSet, windowTemperatureSet))
                        {
                            MessageBox.Show("Succes to set Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_GetGainModeState_160":
                        int gainModeState_160 = tmCamera.tmControl.GetGainModeState();

                        if (gainModeState_160 == 0) // High
                        {
                            radioButton_GainModeStateHigh_160.Checked = true;
                            radioButton_GainModeStateLow_160.Checked = false;
                            radioButton_GainModeStateAuto_160.Checked = false;
                        }
                        else if (gainModeState_160 == 1) // Low
                        {
                            radioButton_GainModeStateHigh_160.Checked = false;
                            radioButton_GainModeStateLow_160.Checked = true;
                            radioButton_GainModeStateAuto_160.Checked = false;
                        }
                        else if (gainModeState_160 == 2) // Auto
                        {
                            radioButton_GainModeStateHigh_160.Checked = false;
                            radioButton_GainModeStateLow_160.Checked = false;
                            radioButton_GainModeStateAuto_160.Checked = true;
                        }
                        else
                        {
                            radioButton_GainModeStateHigh_160.Checked = false;
                            radioButton_GainModeStateLow_160.Checked = false;
                            radioButton_GainModeStateAuto_160.Checked = false;

                            MessageBox.Show("Fail to get Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetGainModeState_160":
                        int gainModeStateSet_160 = -1;

                        button_SetGainModeState_160.Text = "Wait...";
                        button_SetGainModeState_160.Enabled = false;

                        if ((radioButton_GainModeStateHigh_160.Checked == true) && (radioButton_GainModeStateLow_160.Checked == false) && (radioButton_GainModeStateAuto_160.Checked == false))
                            gainModeStateSet_160 = 0; // High
                        else if ((radioButton_GainModeStateHigh_160.Checked == false) && (radioButton_GainModeStateLow_160.Checked == true) && (radioButton_GainModeStateAuto_160.Checked == false))
                            gainModeStateSet_160 = 1; // Low
                        else if ((radioButton_GainModeStateHigh_160.Checked == false) && (radioButton_GainModeStateLow_160.Checked == false) && (radioButton_GainModeStateAuto_160.Checked == true))
                            gainModeStateSet_160 = 2; // Auto

                        if ((gainModeStateSet_160 != -1) && tmCamera.tmControl.SetGainModeState(gainModeStateSet_160))
                        {
                            MessageBox.Show("Success to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        button_SetGainModeState_160.Text = "Set";
                        button_SetGainModeState_160.Enabled = true;

                        break;

                    case "button_GetFlatFieldCorrectionMode_160":
                        int ffcMode_160 = tmCamera.tmControl.GetFlatFieldCorrectionMode();

                        if (ffcMode_160 == 0) // Manual
                        {
                            radioButton_FlatFieldCorrectionManual_160.Checked = true;
                            radioButton_FlatFieldCorrectionAutomatic_160.Checked = false;
                        }
                        else if (ffcMode_160 == 1) // Automatic
                        {
                            radioButton_FlatFieldCorrectionManual_160.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_160.Checked = true;
                        }
                        else
                        {
                            radioButton_FlatFieldCorrectionManual_160.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_160.Checked = false;

                            MessageBox.Show("Fail to get Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFlatFieldCorrectionMode_160":
                        int ffcModeSet_160 = -1;

                        if ((radioButton_FlatFieldCorrectionManual_160.Checked == true) && (radioButton_FlatFieldCorrectionAutomatic_160.Checked == false))
                            ffcModeSet_160 = 0; // Manual
                        else if ((radioButton_FlatFieldCorrectionManual_160.Checked == false) && (radioButton_FlatFieldCorrectionAutomatic_160.Checked == true))
                            ffcModeSet_160 = 1; // Automatic

                        if (ffcModeSet_160 != -1)
                            tmCamera.tmControl.SetFlatFieldCorrectionMode(ffcModeSet_160);
                        else
                            MessageBox.Show("Fail to set Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);

                        break;

                    case "button_RunFlatFieldCorrection_160":
                        button_RunFlatFieldCorrection_160.Text = "Wait...";
                        button_RunFlatFieldCorrection_160.Enabled = false;

                        if (tmCamera.tmControl.RunFlatFieldCorrection())
                        {
                            MessageBox.Show("Success to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        button_RunFlatFieldCorrection_160.Text = "Run";
                        button_RunFlatFieldCorrection_160.Enabled = true;

                        break;

                    case "button_RestoreDefaultFluxParameters_160":
                        if (tmCamera.tmControl.SetDefaultFluxParameters(out double sceneEmissivityDef, out double atmosphericTransmissionDef,
                                                                     out double atmosphericTemperatureDef, out double windowReflectedTemperatureDef,
                                                                     out double windowReflectionDef, out double backgroundTemperatureDef,
                                                                     out double windowTransmissionDef, out double windowTemperatureDef))
                        {
                            numericUpDown_FluxParam160_SceneEmissivity.Value = Convert.ToDecimal(sceneEmissivityDef);
                            numericUpDown_FluxParam160_BackgroundTemperature.Value = Convert.ToDecimal(backgroundTemperatureDef);
                            numericUpDown_FluxParam160_WindowTransmission.Value = Convert.ToDecimal(windowTransmissionDef);
                            numericUpDown_FluxParam160_WindowTemperature.Value = Convert.ToDecimal(windowTemperatureDef);
                            numericUpDown_FluxParam160_AtmosphericTransmission.Value = Convert.ToDecimal(atmosphericTransmissionDef);
                            numericUpDown_FluxParam160_AtmosphericTemperature.Value = Convert.ToDecimal(atmosphericTemperatureDef);
                            numericUpDown_FluxParam160_WindowReflection.Value = Convert.ToDecimal(windowReflectionDef);
                            numericUpDown_FluxParam160_WindowReflectedTemperature.Value = Convert.ToDecimal(windowReflectedTemperatureDef);

                            numericUpDown_FluxParam160_SceneEmissivity.Enabled = true;
                            numericUpDown_FluxParam160_BackgroundTemperature.Enabled = true;
                            numericUpDown_FluxParam160_WindowTransmission.Enabled = true;
                            numericUpDown_FluxParam160_WindowTemperature.Enabled = true;
                            numericUpDown_FluxParam160_AtmosphericTransmission.Enabled = true;
                            numericUpDown_FluxParam160_AtmosphericTemperature.Enabled = true;
                            numericUpDown_FluxParam160_WindowReflection.Enabled = true;
                            numericUpDown_FluxParam160_WindowReflectedTemperature.Enabled = true;
                            textBox_FluxParam160_SceneEmissivityRange.Enabled = true;
                            textBox_FluxParam160_BackgroundTemperatureRange.Enabled = true;
                            textBox_FluxParam160_WindowTransmissionRange.Enabled = true;
                            textBox_FluxParam160_WindowTemperatureRange.Enabled = true;
                            textBox_FluxParam160_AtmosphericTransmissionRange.Enabled = true;
                            textBox_FluxParam160_AtmosphericTemperatureRange.Enabled = true;
                            textBox_FluxParam160_WindowReflectionRange.Enabled = true;
                            textBox_FluxParam160_WindowReflectedTemperatureRange.Enabled = true;
                            button_SetFluxParameters_160.Enabled = true;

                            MessageBox.Show("Succes to restore Factory Default Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to restore Factory Default Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_GetFluxParameters_256":
                        if (tmCamera.tmControl.GetFluxParameters256(out double emissivity, out double atmosphericTransmittance,
                                                              out double ambientAtmosphericTemperature, out double ambientReflectionTemperature,
                                                              out double distance, out double void0, out double void1, out double void2))
                        {
                            numericUpDown_FluxParam256_Emissivity.Value = Convert.ToDecimal(emissivity);
                            numericUpDown_FluxParam256_AtmosphericTransmittance.Value = Convert.ToDecimal(atmosphericTransmittance);
                            numericUpDown_FluxParam256_AtmosphericTemperature.Value = Convert.ToDecimal(ambientAtmosphericTemperature);
                            numericUpDown_FluxParam256_AmbientReflectionTemperature.Value = Convert.ToDecimal(ambientReflectionTemperature);
                            numericUpDown_FluxParam256_Distance.Value = Convert.ToDecimal(distance);

                            numericUpDown_FluxParam256_Emissivity.Enabled = true;
                            numericUpDown_FluxParam256_AtmosphericTransmittance.Enabled = true;
                            numericUpDown_FluxParam256_AtmosphericTemperature.Enabled = true;
                            numericUpDown_FluxParam256_AmbientReflectionTemperature.Enabled = true;
                            numericUpDown_FluxParam256_Distance.Enabled = true;
                            textBox_FluxParam256_EmissivityRange.Enabled = true;
                            textBox_FluxParam256_AtmosphericTransmittanceRange.Enabled = true;
                            textBox_FluxParam256_AtmosphericTemperatureRange.Enabled = true;
                            textBox_FluxParam256_AmbientReflectionTemperatureRange.Enabled = true;
                            textBox_FluxParam256_DistanceRange.Enabled = true;
                            button_SetFluxParameters_256.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to get Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFluxParameters_256":
                        double emissivitySet = Convert.ToDouble(numericUpDown_FluxParam256_Emissivity.Value);
                        double atmosphericTransmittanceSet = Convert.ToDouble(numericUpDown_FluxParam256_AtmosphericTransmittance.Value);
                        double ambientAtmosphericTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam256_AtmosphericTemperature.Value);
                        double ambientReflectionTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam256_AmbientReflectionTemperature.Value);
                        double distanceSet = Convert.ToDouble(numericUpDown_FluxParam256_Distance.Value);

                        if (tmCamera.tmControl.SetFluxParameters(emissivitySet, atmosphericTransmittanceSet,
                                                              ambientAtmosphericTemperatureSet, ambientReflectionTemperatureSet,
                                                              distanceSet))
                        {
                            MessageBox.Show("Succes to set Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_GetGainModeState_256":
                        int gainModeState_256 = tmCamera.tmControl.GetGainModeState();

                        if (gainModeState_256 == 0) // High
                        {
                            radioButton_GainModeStateHigh_256.Checked = true;
                            radioButton_GainModeStateLow_256.Checked = false;
                        }
                        else if (gainModeState_256 == 1) // Low
                        {
                            radioButton_GainModeStateHigh_256.Checked = false;
                            radioButton_GainModeStateLow_256.Checked = true;
                        }
                        else
                        {
                            radioButton_GainModeStateHigh_256.Checked = false;
                            radioButton_GainModeStateLow_256.Checked = false;

                            MessageBox.Show("Fail to get Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetGainModeState_256":
                        int gainModeStateSet_256 = -1;

                        button_SetGainModeState_256.Text = "Wait...";
                        button_SetGainModeState_256.Enabled = false;

                        if ((radioButton_GainModeStateHigh_256.Checked == true) && (radioButton_GainModeStateLow_256.Checked == false))
                            gainModeStateSet_256 = 0; // High
                        else if ((radioButton_GainModeStateHigh_256.Checked == false) && (radioButton_GainModeStateLow_256.Checked == true))
                            gainModeStateSet_256 = 1; // Low

                        if ((gainModeStateSet_256 != -1) && tmCamera.tmControl.SetGainModeState(gainModeStateSet_256))
                        {
                            MessageBox.Show("Success to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        button_SetGainModeState_256.Text = "Set";
                        button_SetGainModeState_256.Enabled = true;

                        break;

                    case "button_GetFFCParameters_256":
                        if (tmCamera.tmControl.GetFlatFieldCorrectionParameters(out double maxInterval, out double autoTriggerThreshold))
                        {
                            numericUpDown_FFCParam256_MaxInterval.Value = Convert.ToDecimal(maxInterval);
                            numericUpDown_FFCParam256_AutoTriggerThreshold.Value = Convert.ToDecimal(autoTriggerThreshold);

                            numericUpDown_FFCParam256_MaxInterval.Enabled = true;
                            numericUpDown_FFCParam256_AutoTriggerThreshold.Enabled = true;
                            textBox_FFCParam256_MaxIntervalRange.Enabled = true;
                            textBox_FFCParam256_AutoTriggerThresholdRange.Enabled = true;
                            button_SetFFCParameters_256.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to get FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFFCParameters_256":
                        double maxIntervalSet = Convert.ToDouble(numericUpDown_FFCParam256_MaxInterval.Value);
                        double autoTriggerThresholdSet = Convert.ToDouble(numericUpDown_FFCParam256_AutoTriggerThreshold.Value);

                        if (tmCamera.tmControl.SetFlatFieldCorrectionParameters(maxIntervalSet, autoTriggerThresholdSet))
                        {
                            MessageBox.Show("Succes to set FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_GetFlatFieldCorrectionMode_256":
                        int ffcMode_256 = tmCamera.tmControl.GetFlatFieldCorrectionMode();

                        if (ffcMode_256 == 0) // Manual
                        {
                            radioButton_FlatFieldCorrectionManual_256.Checked = true;
                            radioButton_FlatFieldCorrectionAutomatic_256.Checked = false;
                        }
                        else if (ffcMode_256 == 1) // Automatic
                        {
                            radioButton_FlatFieldCorrectionManual_256.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_256.Checked = true;
                        }
                        else
                        {
                            radioButton_FlatFieldCorrectionManual_256.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_256.Checked = false;

                            MessageBox.Show("Fail to get Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFlatFieldCorrectionMode_256":
                        int ffcModeSet_256 = -1;

                        if ((radioButton_FlatFieldCorrectionManual_256.Checked == true) && (radioButton_FlatFieldCorrectionAutomatic_256.Checked == false))
                            ffcModeSet_256 = 0; // Manual
                        else if ((radioButton_FlatFieldCorrectionManual_256.Checked == false) && (radioButton_FlatFieldCorrectionAutomatic_256.Checked == true))
                            ffcModeSet_256 = 1; // Automatic

                        if (ffcModeSet_256 != -1)
                            tmCamera.tmControl.SetFlatFieldCorrectionMode(ffcModeSet_256);
                        else
                            MessageBox.Show("Fail to set Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);

                        break;

                    case "button_RunFlatFieldCorrection_256":
                        button_RunFlatFieldCorrection_256.Text = "Wait...";
                        button_RunFlatFieldCorrection_256.Enabled = false;

                        if (tmCamera.tmControl.RunFlatFieldCorrection())
                        {
                            MessageBox.Show("Success to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        button_RunFlatFieldCorrection_256.Text = "Run";
                        button_RunFlatFieldCorrection_256.Enabled = true;

                        break;

                    case "button_StoreUserSensorConfig_256":
                        if (tmCamera.tmControl.StoreUserSensorConfig())
                        {
                            MessageBox.Show("Success to store user sensor configurations", "Sensor Control", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Sensor Control", MessageBoxButtons.OK);
                        }
                        break;

                    case "button_RestoreDefaultSensorConfig_256":
                        button_RestoreDefaultSensorConfig_256.Text = "Wait...";
                        button_RestoreDefaultSensorConfig_256.Enabled = false;

                        if (this.captureThread != null && this.captureThread.IsAlive)
                        {
                            // force to terminate frameThread
                            this.captureThread.Interrupt();
                            // Wait for frameThread to end.
                            this.captureThread.Join();

                            System.Threading.Thread.Sleep(1000);
                        }

                        tmCamera.tmControl.RestoreDefaultSensorConfig();

                        System.Threading.Thread.Sleep(1000);

                        tmCamera.Close();
                        tmCamera = null;

                        System.Threading.Thread.Sleep(1000);

                        Application.EnableVisualStyles();
                        DialogResult rebootDialog = MessageBox.Show("Reboot... Reconnect camera device.", "ThermoCamApp", MessageBoxButtons.OK);
                        switch (rebootDialog)
                        {
                            case DialogResult.OK:
                                tabControl_CameraConfig.Enabled = false;
                                tabControl_SensorConfig.Enabled = false;
                                comboBox_ColorMap.Enabled = false;
                                comboBox_TemperatureUnit.Enabled = false;
                                button_ConnectLocalCamera.Enabled = false;
                                button_ScanLocalCamera.Enabled = false;
                                button_ConnectRemoteCamera.Enabled = false;
                                button_ScanRemoteCamera.Enabled = false;
                                System.Threading.Thread.Sleep(2000);
                                button_ConnectLocalCamera.Text = "Connect";
                                button_ConnectLocalCamera.Enabled = true;
                                button_ScanLocalCamera.Enabled = true;
                                button_ConnectRemoteCamera.Text = "Connect";
                                button_ConnectRemoteCamera.Enabled = true;
                                button_ScanRemoteCamera.Enabled = true;
                                button_RestoreDefaultSensorConfig_256.Text = "Restore to Factory Default";
                                button_RestoreDefaultSensorConfig_256.Enabled = true;
                                break;
                        }

                        break;

                    case "button_GetGainModeState_256G":
                        int gainModeState_256G = tmCamera.tmControl.GetGainModeState();

                        if (gainModeState_256G == 0) // High
                        {
                            radioButton_GainModeStateHigh_256G.Checked = true;
                            radioButton_GainModeStateLow_256G.Checked = false;
                            radioButton_GainModeStateAuto_256G.Checked = false;
                        }
                        else if (gainModeState_256G == 1) // Low
                        {
                            radioButton_GainModeStateHigh_256G.Checked = false;
                            radioButton_GainModeStateLow_256G.Checked = true;
                            radioButton_GainModeStateAuto_256G.Checked = false;
                        }
                        else if (gainModeState_256G == 2) // Auto
                        {
                            radioButton_GainModeStateHigh_256G.Checked = false;
                            radioButton_GainModeStateLow_256G.Checked = false;
                            radioButton_GainModeStateAuto_256G.Checked = true;
                        }
                        else
                        {
                            radioButton_GainModeStateHigh_256G.Checked = false;
                            radioButton_GainModeStateLow_256G.Checked = false;
                            radioButton_GainModeStateAuto_256G.Checked = false;

                            MessageBox.Show("Fail to get Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetGainModeState_256G":
                        int gainModeStateSet_256G = -1;

                        button_SetGainModeState_256G.Text = "Wait...";
                        button_SetGainModeState_256G.Enabled = false;

                        if ((radioButton_GainModeStateHigh_256G.Checked == true) && (radioButton_GainModeStateLow_256G.Checked == false) && (radioButton_GainModeStateAuto_256G.Checked == false))
                            gainModeStateSet_256G = 0; // High
                        else if ((radioButton_GainModeStateHigh_256G.Checked == false) && (radioButton_GainModeStateLow_256G.Checked == true) && (radioButton_GainModeStateAuto_256G.Checked == false))
                            gainModeStateSet_256G = 1; // Low
                        else if ((radioButton_GainModeStateHigh_256G.Checked == false) && (radioButton_GainModeStateLow_256G.Checked == false) && (radioButton_GainModeStateAuto_256G.Checked == true))
                            gainModeStateSet_256G = 2; // Auto

                        if ((gainModeStateSet_256G != -1) && tmCamera.tmControl.SetGainModeState(gainModeStateSet_256G))
                        {
                            MessageBox.Show("Success to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        button_SetGainModeState_256G.Text = "Set";
                        button_SetGainModeState_256G.Enabled = true;

                        break;

                    case "button_GetFFCParameters_256G":
                        if (tmCamera.tmControl.GetFlatFieldCorrectionParameters(out double maxInterval_256G, out double autoTriggerThreshold_256G))
                        {
                            numericUpDown_FFCParam256G_MaxInterval.Value = Convert.ToDecimal(maxInterval_256G);

                            numericUpDown_FFCParam256G_MaxInterval.Enabled = true;
                            textBox_FFCParam256G_MaxIntervalRange.Enabled = true;
                            button_SetFFCParameters_256G.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to get FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFFCParameters_256G":
                        double maxIntervalSet_256G = Convert.ToDouble(numericUpDown_FFCParam256G_MaxInterval.Value);
                        double autoTriggerThresholdSet_256G = 0;

                        if (tmCamera.tmControl.SetFlatFieldCorrectionParameters(maxIntervalSet_256G, autoTriggerThresholdSet_256G))
                        {
                            MessageBox.Show("Succes to set FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }

                        break;


                    case "button_GetFlatFieldCorrectionMode_256G":
                        int ffcMode_256G = tmCamera.tmControl.GetFlatFieldCorrectionMode();

                        if (ffcMode_256G == 0) // Manual
                        {
                            radioButton_FlatFieldCorrectionManual_256G.Checked = true;
                            radioButton_FlatFieldCorrectionAutomatic_256G.Checked = false;
                        }
                        else if (ffcMode_256G == 1) // Automatic
                        {
                            radioButton_FlatFieldCorrectionManual_256G.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_256G.Checked = true;
                        }
                        else
                        {
                            radioButton_FlatFieldCorrectionManual_256G.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_256G.Checked = false;

                            MessageBox.Show("Fail to get Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFlatFieldCorrectionMode_256G":
                        int ffcModeSet_256G = -1;

                        if ((radioButton_FlatFieldCorrectionManual_256G.Checked == true) && (radioButton_FlatFieldCorrectionAutomatic_256G.Checked == false))
                            ffcModeSet_256G = 0; // Manual
                        else if ((radioButton_FlatFieldCorrectionManual_256G.Checked == false) && (radioButton_FlatFieldCorrectionAutomatic_256G.Checked == true))
                            ffcModeSet_256G = 1; // Automatic

                        if (ffcModeSet_256G != -1)
                            tmCamera.tmControl.SetFlatFieldCorrectionMode(ffcModeSet_256G);
                        else
                            MessageBox.Show("Fail to set Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);

                        break;

                    case "button_RunFlatFieldCorrection_256G":
                        button_RunFlatFieldCorrection_256G.Text = "Wait...";
                        button_RunFlatFieldCorrection_256G.Enabled = false;

                        if (tmCamera.tmControl.RunFlatFieldCorrection())
                        {
                            MessageBox.Show("Success to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        button_RunFlatFieldCorrection_256G.Text = "Run";
                        button_RunFlatFieldCorrection_256G.Enabled = true;

                        break;

                    case "button_StoreUserSensorConfig_256G":
                        if (tmCamera.tmControl.StoreUserSensorConfig())
                        {
                            MessageBox.Show("Success to store user sensor configurations", "Sensor Control", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Sensor Control", MessageBoxButtons.OK);
                        }
                        break;

                    case "button_RestoreDefaultSensorConfig_256G":
                        if (tmCamera.tmControl.RestoreDefaultSensorConfig())
                        {
                            MessageBox.Show("Success to restore user sensor configurations", "Sensor Control", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Sensor Control", MessageBoxButtons.OK);
                        }
                        break;
                }
            }
        }

        private void numericUpDown_FluxParam160_SceneEmissivity_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam160_BackgroundTemperature_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam160_WindowTransmission_ValueChanged(object sender, EventArgs e)
        {
            double windowTransmission = Convert.ToDouble(numericUpDown_FluxParam160_WindowTransmission.Value);
            double maxWindowReflection = 1.0d - windowTransmission;
            double windowReflection = Convert.ToDouble(numericUpDown_FluxParam160_WindowReflection.Value);
            if (windowReflection > maxWindowReflection)
                numericUpDown_FluxParam160_WindowReflection.Value = Convert.ToDecimal(maxWindowReflection);

            textBox_FluxParam160_WindowReflectionRange.Text = "0.00 ~ " + string.Format("{0:0.00}", maxWindowReflection);

            Refresh();
        }

        private void numericUpDown_FluxParam160_WindowTemperature_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam160_AtmosphericTransmission_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam160_AtmosphericTemperature_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam160_WindowReflection_ValueChanged(object sender, EventArgs e)
        {
            double windowTransmission = Convert.ToDouble(numericUpDown_FluxParam160_WindowTransmission.Value);
            double maxWindowReflection = 1.0d - windowTransmission;
            double windowReflection = Convert.ToDouble(numericUpDown_FluxParam160_WindowReflection.Value);
            if (windowReflection > maxWindowReflection)
                numericUpDown_FluxParam160_WindowReflection.Value = Convert.ToDecimal(maxWindowReflection);

            textBox_FluxParam160_WindowReflectionRange.Text = "0.00 ~ " + string.Format("{0:0.00}", maxWindowReflection);

            Refresh();
        }

        private void numericUpDown_FluxParam160_WindowReflectedTemperature_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256_Emissivity_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256_AtmosphericTransmittance_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256_AtmosphericTemperature_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256_ReflectionTemperature_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256_Distance_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FFCParam256_MaxInterval_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FFCParam256_AutoTriggerThreshold_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256G_Emissivity_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256G_AtmosphericTransmittance_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256G_AtmosphericTemperature_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256G_ReflectionTemperature_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FluxParam256G_Distance_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FFCParam256G_MaxInterval_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void numericUpDown_FFCParam256G_AutoTriggerThreshold_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }
        #endregion
    }
}
