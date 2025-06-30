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

        private void button_SensorControl_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && tmCamera != null && tmCamera.IsOpen)
            {
                switch (btn.Name)
                {
                    case "button_GetFluxParameters_160E":
                        if (tmCamera.tmControl.GetFluxParameters160(out double sceneEmissivity, out double atmosphericTransmission,
                                                              out double atmosphericTemperature, out double windowReflectedTemperature,
                                                              out double windowReflection, out double backgroundTemperature,
                                                              out double windowTransmission, out double windowTemperature))
                        {
                            numericUpDown_FluxParam160E_SceneEmissivity.Value = Convert.ToDecimal(sceneEmissivity);
                            numericUpDown_FluxParam160E_BackgroundTemperature.Value = Convert.ToDecimal(backgroundTemperature);
                            numericUpDown_FluxParam160E_WindowTransmission.Value = Convert.ToDecimal(windowTransmission);
                            numericUpDown_FluxParam160E_WindowTemperature.Value = Convert.ToDecimal(windowTemperature);
                            numericUpDown_FluxParam160E_AtmosphericTransmission.Value = Convert.ToDecimal(atmosphericTransmission);
                            numericUpDown_FluxParam160E_AtmosphericTemperature.Value = Convert.ToDecimal(atmosphericTemperature);
                            numericUpDown_FluxParam160E_WindowReflection.Value = Convert.ToDecimal(windowReflection);
                            numericUpDown_FluxParam160E_WindowReflectedTemperature.Value = Convert.ToDecimal(windowReflectedTemperature);

                            numericUpDown_FluxParam160E_SceneEmissivity.Enabled = true;
                            numericUpDown_FluxParam160E_BackgroundTemperature.Enabled = true;
                            numericUpDown_FluxParam160E_WindowTransmission.Enabled = true;
                            numericUpDown_FluxParam160E_WindowTemperature.Enabled = true;
                            numericUpDown_FluxParam160E_AtmosphericTransmission.Enabled = true;
                            numericUpDown_FluxParam160E_AtmosphericTemperature.Enabled = true;
                            numericUpDown_FluxParam160E_WindowReflection.Enabled = true;
                            numericUpDown_FluxParam160E_WindowReflectedTemperature.Enabled = true;
                            textBox_FluxParam160E_SceneEmissivityRange.Enabled = true;
                            textBox_FluxParam160E_BackgroundTemperatureRange.Enabled = true;
                            textBox_FluxParam160E_WindowTransmissionRange.Enabled = true;
                            textBox_FluxParam160E_WindowTemperatureRange.Enabled = true;
                            textBox_FluxParam160E_AtmosphericTransmissionRange.Enabled = true;
                            textBox_FluxParam160E_AtmosphericTemperatureRange.Enabled = true;
                            textBox_FluxParam160E_WindowReflectionRange.Enabled = true;
                            textBox_FluxParam160E_WindowReflectedTemperatureRange.Enabled = true;
                            button_SetFluxParameters_160E.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to get Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFluxParameters_160E":
                        double sceneEmissivitySet = Convert.ToDouble(numericUpDown_FluxParam160E_SceneEmissivity.Value);
                        double atmosphericTransmissionSet = Convert.ToDouble(numericUpDown_FluxParam160E_AtmosphericTransmission.Value);
                        double atmosphericTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam160E_AtmosphericTemperature.Value);
                        double windowReflectedTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam160E_WindowReflectedTemperature.Value);
                        double windowReflectionSet = Convert.ToDouble(numericUpDown_FluxParam160E_WindowReflection.Value);
                        double backgroundTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam160E_BackgroundTemperature.Value);
                        double windowTransmissionSet = Convert.ToDouble(numericUpDown_FluxParam160E_WindowTransmission.Value);
                        double windowTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam160E_WindowTemperature.Value);

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

                    case "button_GetGainModeState_160E":
                        int gainModeState_160E = tmCamera.tmControl.GetGainModeState();

                        if (gainModeState_160E == 0) // High
                        {
                            radioButton_GainModeStateHigh_160E.Checked = true;
                            radioButton_GainModeStateLow_160E.Checked = false;
                            radioButton_GainModeStateAuto_160E.Checked = false;
                        }
                        else if (gainModeState_160E == 1) // Low
                        {
                            radioButton_GainModeStateHigh_160E.Checked = false;
                            radioButton_GainModeStateLow_160E.Checked = true;
                            radioButton_GainModeStateAuto_160E.Checked = false;
                        }
                        else if (gainModeState_160E == 2) // Auto
                        {
                            radioButton_GainModeStateHigh_160E.Checked = false;
                            radioButton_GainModeStateLow_160E.Checked = false;
                            radioButton_GainModeStateAuto_160E.Checked = true;
                        }
                        else
                        {
                            radioButton_GainModeStateHigh_160E.Checked = false;
                            radioButton_GainModeStateLow_160E.Checked = false;
                            radioButton_GainModeStateAuto_160E.Checked = false;

                            MessageBox.Show("Fail to get Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetGainModeState_160E":
                        int gainModeStateSet_160E = -1;

                        button_SetGainModeState_160E.Text = "Wait...";
                        button_SetGainModeState_160E.Enabled = false;

                        if ((radioButton_GainModeStateHigh_160E.Checked == true) && (radioButton_GainModeStateLow_160E.Checked == false) && (radioButton_GainModeStateAuto_160E.Checked == false))
                            gainModeStateSet_160E = 0; // High
                        else if ((radioButton_GainModeStateHigh_160E.Checked == false) && (radioButton_GainModeStateLow_160E.Checked == true) && (radioButton_GainModeStateAuto_160E.Checked == false))
                            gainModeStateSet_160E = 1; // Low
                        else if ((radioButton_GainModeStateHigh_160E.Checked == false) && (radioButton_GainModeStateLow_160E.Checked == false) && (radioButton_GainModeStateAuto_160E.Checked == true))
                            gainModeStateSet_160E = 2; // Auto

                        if ((gainModeStateSet_160E != -1) && tmCamera.tmControl.SetGainModeState(gainModeStateSet_160E))
                        {
                            MessageBox.Show("Success to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        button_SetGainModeState_160E.Text = "Set";
                        button_SetGainModeState_160E.Enabled = true;

                        break;

                    case "button_GetFlatFieldCorrectionMode_160E":
                        int ffcMode_160E = tmCamera.tmControl.GetFlatFieldCorrectionMode();

                        if (ffcMode_160E == 0) // Manual
                        {
                            radioButton_FlatFieldCorrectionManual_160E.Checked = true;
                            radioButton_FlatFieldCorrectionAutomatic_160E.Checked = false;
                        }
                        else if (ffcMode_160E == 1) // Automatic
                        {
                            radioButton_FlatFieldCorrectionManual_160E.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_160E.Checked = true;
                        }
                        else
                        {
                            radioButton_FlatFieldCorrectionManual_160E.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_160E.Checked = false;

                            MessageBox.Show("Fail to get Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFlatFieldCorrectionMode_160E":
                        int ffcModeSet_160E = -1;

                        if ((radioButton_FlatFieldCorrectionManual_160E.Checked == true) && (radioButton_FlatFieldCorrectionAutomatic_160E.Checked == false))
                            ffcModeSet_160E = 0; // Manual
                        else if ((radioButton_FlatFieldCorrectionManual_160E.Checked == false) && (radioButton_FlatFieldCorrectionAutomatic_160E.Checked == true))
                            ffcModeSet_160E = 1; // Automatic

                        if (ffcModeSet_160E != -1)
                            tmCamera.tmControl.SetFlatFieldCorrectionMode(ffcModeSet_160E);
                        else
                            MessageBox.Show("Fail to set Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);

                        break;

                    case "button_RunFlatFieldCorrection_160E":
                        button_RunFlatFieldCorrection_160E.Text = "Wait...";
                        button_RunFlatFieldCorrection_160E.Enabled = false;

                        if (tmCamera.tmControl.RunFlatFieldCorrection())
                        {
                            MessageBox.Show("Success to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        button_RunFlatFieldCorrection_160E.Text = "Run";
                        button_RunFlatFieldCorrection_160E.Enabled = true;

                        break;

                    case "button_RestoreDefaultFluxParameters_160E":
                        if (tmCamera.tmControl.SetDefaultFluxParameters(out double sceneEmissivityDef, out double atmosphericTransmissionDef,
                                                                     out double atmosphericTemperatureDef, out double windowReflectedTemperatureDef,
                                                                     out double windowReflectionDef, out double backgroundTemperatureDef,
                                                                     out double windowTransmissionDef, out double windowTemperatureDef))
                        {
                            numericUpDown_FluxParam160E_SceneEmissivity.Value = Convert.ToDecimal(sceneEmissivityDef);
                            numericUpDown_FluxParam160E_BackgroundTemperature.Value = Convert.ToDecimal(backgroundTemperatureDef);
                            numericUpDown_FluxParam160E_WindowTransmission.Value = Convert.ToDecimal(windowTransmissionDef);
                            numericUpDown_FluxParam160E_WindowTemperature.Value = Convert.ToDecimal(windowTemperatureDef);
                            numericUpDown_FluxParam160E_AtmosphericTransmission.Value = Convert.ToDecimal(atmosphericTransmissionDef);
                            numericUpDown_FluxParam160E_AtmosphericTemperature.Value = Convert.ToDecimal(atmosphericTemperatureDef);
                            numericUpDown_FluxParam160E_WindowReflection.Value = Convert.ToDecimal(windowReflectionDef);
                            numericUpDown_FluxParam160E_WindowReflectedTemperature.Value = Convert.ToDecimal(windowReflectedTemperatureDef);

                            numericUpDown_FluxParam160E_SceneEmissivity.Enabled = true;
                            numericUpDown_FluxParam160E_BackgroundTemperature.Enabled = true;
                            numericUpDown_FluxParam160E_WindowTransmission.Enabled = true;
                            numericUpDown_FluxParam160E_WindowTemperature.Enabled = true;
                            numericUpDown_FluxParam160E_AtmosphericTransmission.Enabled = true;
                            numericUpDown_FluxParam160E_AtmosphericTemperature.Enabled = true;
                            numericUpDown_FluxParam160E_WindowReflection.Enabled = true;
                            numericUpDown_FluxParam160E_WindowReflectedTemperature.Enabled = true;
                            textBox_FluxParam160E_SceneEmissivityRange.Enabled = true;
                            textBox_FluxParam160E_BackgroundTemperatureRange.Enabled = true;
                            textBox_FluxParam160E_WindowTransmissionRange.Enabled = true;
                            textBox_FluxParam160E_WindowTemperatureRange.Enabled = true;
                            textBox_FluxParam160E_AtmosphericTransmissionRange.Enabled = true;
                            textBox_FluxParam160E_AtmosphericTemperatureRange.Enabled = true;
                            textBox_FluxParam160E_WindowReflectionRange.Enabled = true;
                            textBox_FluxParam160E_WindowReflectedTemperatureRange.Enabled = true;
                            button_SetFluxParameters_160E.Enabled = true;

                            MessageBox.Show("Succes to restore Factory Default Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to restore Factory Default Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_GetFluxParameters_256E":
                        if (tmCamera.tmControl.GetFluxParameters256(out double emissivity, out double atmosphericTransmittance,
                                                              out double ambientAtmosphericTemperature, out double ambientReflectionTemperature,
                                                              out double distance, out double void0, out double void1, out double void2))
                        {
                            numericUpDown_FluxParam256E_Emissivity.Value = Convert.ToDecimal(emissivity);
                            numericUpDown_FluxParam256E_AtmosphericTransmittance.Value = Convert.ToDecimal(atmosphericTransmittance);
                            numericUpDown_FluxParam256E_AtmosphericTemperature.Value = Convert.ToDecimal(ambientAtmosphericTemperature);
                            numericUpDown_FluxParam256E_AmbientReflectionTemperature.Value = Convert.ToDecimal(ambientReflectionTemperature);
                            numericUpDown_FluxParam256E_Distance.Value = Convert.ToDecimal(distance);

                            numericUpDown_FluxParam256E_Emissivity.Enabled = true;
                            numericUpDown_FluxParam256E_AtmosphericTransmittance.Enabled = true;
                            numericUpDown_FluxParam256E_AtmosphericTemperature.Enabled = true;
                            numericUpDown_FluxParam256E_AmbientReflectionTemperature.Enabled = true;
                            numericUpDown_FluxParam256E_Distance.Enabled = true;
                            textBox_FluxParam256E_EmissivityRange.Enabled = true;
                            textBox_FluxParam256E_AtmosphericTransmittanceRange.Enabled = true;
                            textBox_FluxParam256E_AtmosphericTemperatureRange.Enabled = true;
                            textBox_FluxParam256E_AmbientReflectionTemperatureRange.Enabled = true;
                            textBox_FluxParam256E_DistanceRange.Enabled = true;
                            button_SetFluxParameters_256E.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to get Flux Parameters.", "Flux Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFluxParameters_256E":
                        double emissivitySet = Convert.ToDouble(numericUpDown_FluxParam256E_Emissivity.Value);
                        double atmosphericTransmittanceSet = Convert.ToDouble(numericUpDown_FluxParam256E_AtmosphericTransmittance.Value);
                        double ambientAtmosphericTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam256E_AtmosphericTemperature.Value);
                        double ambientReflectionTemperatureSet = Convert.ToDouble(numericUpDown_FluxParam256E_AmbientReflectionTemperature.Value);
                        double distanceSet = Convert.ToDouble(numericUpDown_FluxParam256E_Distance.Value);

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

                    case "button_GetGainModeState_256E":
                        int gainModeState_256E = tmCamera.tmControl.GetGainModeState();

                        if (gainModeState_256E == 0) // High
                        {
                            radioButton_GainModeStateHigh_256E.Checked = true;
                            radioButton_GainModeStateLow_256E.Checked = false;
                        }
                        else if (gainModeState_256E == 1) // Low
                        {
                            radioButton_GainModeStateHigh_256E.Checked = false;
                            radioButton_GainModeStateLow_256E.Checked = true;
                        }
                        else
                        {
                            radioButton_GainModeStateHigh_256E.Checked = false;
                            radioButton_GainModeStateLow_256E.Checked = false;

                            MessageBox.Show("Fail to get Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetGainModeState_256E":
                        int gainModeStateSet_256E = -1;

                        button_SetGainModeState_256E.Text = "Wait...";
                        button_SetGainModeState_256E.Enabled = false;

                        if ((radioButton_GainModeStateHigh_256E.Checked == true) && (radioButton_GainModeStateLow_256E.Checked == false))
                            gainModeStateSet_256E = 0; // High
                        else if ((radioButton_GainModeStateHigh_256E.Checked == false) && (radioButton_GainModeStateLow_256E.Checked == true))
                            gainModeStateSet_256E = 1; // Low

                        if ((gainModeStateSet_256E != -1) && tmCamera.tmControl.SetGainModeState(gainModeStateSet_256E))
                        {
                            MessageBox.Show("Success to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set Gain Mode State", "Gain Mode", MessageBoxButtons.OK);
                        }

                        button_SetGainModeState_256E.Text = "Set";
                        button_SetGainModeState_256E.Enabled = true;

                        break;

                    case "button_GetFFCParameters_256E":
                        if (tmCamera.tmControl.GetFlatFieldCorrectionParameters(out double maxInterval, out double autoTriggerThreshold))
                        {
                            numericUpDown_FFCParam256E_MaxInterval.Value = Convert.ToDecimal(maxInterval);
                            numericUpDown_FFCParam256E_AutoTriggerThreshold.Value = Convert.ToDecimal(autoTriggerThreshold);
                            numericUpDown_FFCParam256E_MaxInterval.Enabled = true;
                            numericUpDown_FFCParam256E_AutoTriggerThreshold.Enabled = true;
                            textBox_FFCParam256E_MaxIntervalRange.Enabled = true;
                            textBox_FFCParam256E_AutoTriggerThresholdRange.Enabled = true;
                            button_SetFFCParameters_256E.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to get FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFFCParameters_256E":
                        double maxIntervalSet = Convert.ToDouble(numericUpDown_FFCParam256E_MaxInterval.Value);
                        double autoTriggerThresholdSet = Convert.ToDouble(numericUpDown_FFCParam256E_AutoTriggerThreshold.Value);

                        if (tmCamera.tmControl.SetFlatFieldCorrectionParameters(maxIntervalSet, autoTriggerThresholdSet))
                        {
                            MessageBox.Show("Succes to set FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to set FFC Parameters.", "FFC Parameters", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_GetFlatFieldCorrectionMode_256E":
                        int ffcMode_256E = tmCamera.tmControl.GetFlatFieldCorrectionMode();

                        if (ffcMode_256E == 0) // Manual
                        {
                            radioButton_FlatFieldCorrectionManual_256E.Checked = true;
                            radioButton_FlatFieldCorrectionAutomatic_256E.Checked = false;
                        }
                        else if (ffcMode_256E == 1) // Automatic
                        {
                            radioButton_FlatFieldCorrectionManual_256E.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_256E.Checked = true;
                        }
                        else
                        {
                            radioButton_FlatFieldCorrectionManual_256E.Checked = false;
                            radioButton_FlatFieldCorrectionAutomatic_256E.Checked = false;

                            MessageBox.Show("Fail to get Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        break;

                    case "button_SetFlatFieldCorrectionMode_256E":
                        int ffcModeSet_256E = -1;

                        if ((radioButton_FlatFieldCorrectionManual_256E.Checked == true) && (radioButton_FlatFieldCorrectionAutomatic_256E.Checked == false))
                            ffcModeSet_256E = 0; // Manual
                        else if ((radioButton_FlatFieldCorrectionManual_256E.Checked == false) && (radioButton_FlatFieldCorrectionAutomatic_256E.Checked == true))
                            ffcModeSet_256E = 1; // Automatic

                        if (ffcModeSet_256E != -1)
                            tmCamera.tmControl.SetFlatFieldCorrectionMode(ffcModeSet_256E);
                        else
                            MessageBox.Show("Fail to set Flat Field Correction Mode", "Flat Field Correction", MessageBoxButtons.OK);

                        break;

                    case "button_RunFlatFieldCorrection_256E":
                        button_RunFlatFieldCorrection_256E.Text = "Wait...";
                        button_RunFlatFieldCorrection_256E.Enabled = false;

                        if (tmCamera.tmControl.RunFlatFieldCorrection())
                        {
                            MessageBox.Show("Success to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Flat Field Correction", MessageBoxButtons.OK);
                        }

                        button_RunFlatFieldCorrection_256E.Text = "Run";
                        button_RunFlatFieldCorrection_256E.Enabled = true;

                        break;

                    case "button_StoreUserSensorConfig_256E":
                        if (tmCamera.tmControl.StoreUserSensorConfig())
                        {
                            MessageBox.Show("Success to store user sensor configurations", "Sensor Control", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Fail to run Flat Field Correction", "Sensor Control", MessageBoxButtons.OK);
                        }
                        break;

                    case "button_RestoreDefaultSensorConfig_256E":
                        button_RestoreDefaultSensorConfig_256E.Text = "Wait...";
                        button_RestoreDefaultSensorConfig_256E.Enabled = false;

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
                                tabControl2.Enabled = false;
                                tabControl3.Enabled = false;
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
                                button_RestoreDefaultSensorConfig_256E.Text = "Restore to Factory Default";
                                button_RestoreDefaultSensorConfig_256E.Enabled = true;
                                break;
                        }

                        break;

                }
            }
        }
    }
}
