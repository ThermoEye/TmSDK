#################################################################
# Company: Thermoeye, Inc
# Project: TmSDK
# File: FirmwareWorker.py
# Creation date: 2024-08-19
# Version: 1.0.0
#
# Description: This file contains the following implementations:
# - Get Flat Field Correction mode
# - Set Flat Field Correction mode
# - Run Flat Field Correction mode
# - Get flux parameters
# - Set flux parameters
# - Get Flat Field Correction parameters
# - Set Flat Field Correction parameters
# - Store sensor configuration
# - Restore sensor configuration
#
# History: 2024-08-19: Initial version.
#
#################################################################
from PyQt5.QtCore import *
from PyQt5.QtWidgets import *
from PyQt5 import uic
from PyQt5.QtGui import *

class SensorControl:
    def __init__(self, main_window, camera):
        self.main_window = main_window
        self.camera = camera
        
    def pushButton_GetFlatFieldCorrection_Clicked(self):
        ret, ffcMode = self.camera.tmCamera.tmControl.get_flat_field_correction_mode()
        if ret:
            if ffcMode==0: #Manual
                self.main_window.radioButton_FlatFieldCorrectionManual.setChecked(True)
                self.main_window.radioButton_FlatFieldCorrectionAutomatic.setChecked(False)
            else:
                self.main_window.radioButton_FlatFieldCorrectionManual.setChecked(False)
                self.main_window.radioButton_FlatFieldCorrectionAutomatic.setChecked(True)
                
    def pushButton_SetFlatFieldCorrection_Clicked(self):
        ffcMode=0
        if self.main_window.radioButton_FlatFieldCorrectionManual.isChecked():
            ffcMode=0
        elif self.main_window.radioButton_FlatFieldCorrectionAutomatic.isChecked():
            ffcMode=1
        self.camera.tmCamera.tmControl.set_flat_feild_correction_mode(ffcMode)
    
    def pushButton_RunFlatFieldCorrection_Clicked(self):
        ret = self.camera.tmCamera.tmControl.run_flat_field_correction()
        if ret:
            resBtn = QMessageBox.information(self.main_window, "Flat Field Correction", "Success to run Flat field Correction",QMessageBox.Ok)
        else:
            resBtn = QMessageBox.information(self.main_window, "Flat Field Correction", "Failed to run Flat field Correction",QMessageBox.Ok)
            
    def pushButton_GetFluexParams_Clicked(self):
        sceneEmissivity = 0
        atmosphericTransmittance = 0
        atmosphericTemperature = 0
        ambientReflectionTemp = 0
        distance = 0
        
        try:
            flux_params = self.camera.tmCamera.tmControl.get_flux_parameters(sceneEmissivity,
                                                                     atmosphericTransmittance,
                                                                     atmosphericTemperature,
                                                                     ambientReflectionTemp,
                                                                     distance)
            if len(flux_params) == 5:
                self.main_window.doubleSpinBox_FluexParamEmissivity.setValue(flux_params['scene_emissivity'])
                self.main_window.doubleSpinBox_FluexParamAtmosphericTransmittance.setValue(flux_params['atmospheric_transmission'])
                self.main_window.doubleSpinBox_FluexParamAtmosphericTemperature.setValue(flux_params['atmospheric_temperature'])
                self.main_window.doubleSpinBox_FluexParamAmbientReflectionTemp.setValue(flux_params['window_reflected_temperature'])
                self.main_window.doubleSpinBox_FluexParamDistance.setValue(flux_params['window_reflection'])        
                self.main_window.doubleSpinBox_FluexParamEmissivity.setEnabled(True)
                self.main_window.doubleSpinBox_FluexParamAtmosphericTransmittance.setEnabled(True)
                self.main_window.doubleSpinBox_FluexParamAtmosphericTemperature.setEnabled(True)
                self.main_window.doubleSpinBox_FluexParamAmbientReflectionTemp.setEnabled(True)
                self.main_window.doubleSpinBox_FluexParamDistance.setEnabled(True)
                self.main_window.pushButton_SetFluexParams.setEnabled(True)
            else:
                print("Error while getting flux parameters")
        except Exception as e:
                print(f'Error while opening camera: {str(e)}')     
    
    def pushButton_SetFluexParams_Clicked(self):
        sceneEmissivity = self.main_window.doubleSpinBox_FluexParamEmissivity.value()
        atmosphericTransmittance = self.main_window.doubleSpinBox_FluexParamAtmosphericTransmittance.value()
        atmosphericTemperature = self.main_window.doubleSpinBox_FluexParamAtmosphericTemperature.value()
        ambientReflectionTemp = self.main_window.doubleSpinBox_FluexParamAmbientReflectionTemp.value()
        distance = self.main_window.doubleSpinBox_FluexParamDistance.value()
        try:
            ret = self.camera.tmCamera.tmControl.set_flux_parameters(sceneEmissivity,
                                                                     atmosphericTransmittance,
                                                                     atmosphericTemperature,
                                                                     ambientReflectionTemp,
                                                                     distance)
            if ret is None:
                QMessageBox.warning(self.main_window, "Fluex parameters", "TmCamera object is not initialized!")
            elif ret:
                QMessageBox.information(self.main_window, "Fluex parameters", "Success in setting Fluex parameters")
            else:
                QMessageBox.warning(self.main_window, "Fluex parameters", "Failed to set Fluex parameters")
        except Exception as e:
            QMessageBox.critical(self.main_window, "Fluex parameters", f'Error while opening camera: {str(e)}')
            
    def pushButton_GetFFCParams_Clicked(self):
        try:
            success, maxInterval, autoTriggerThreshold = self.camera.tmCamera.tmControl.get_flat_feild_correction_parameters()
            if success:
                self.main_window.doubleSpinBox_FFCParam_MaxInterval.setValue(maxInterval)
                self.main_window.doubleSpinBox_FFCParamAutoTriggerThreshold.setValue(autoTriggerThreshold)
                self.main_window.doubleSpinBox_FFCParam_MaxInterval.setEnabled(True)
                self.main_window.doubleSpinBox_FFCParamAutoTriggerThreshold.setEnabled(True)
                self.main_window.pushButton_SetFFCParams.setEnabled(True)
            else:
                print("Error while getting FFC parameters")
        except Exception as e:
            print(f'An Error occured: {str(e)}')
            
    def pushButton_SetFFCParams_Clicked(self):
        maxInterval = self.main_window.doubleSpinBox_FFCParam_MaxInterval.value()
        autoTriggerThreshold = self.main_window.doubleSpinBox_FFCParamAutoTriggerThreshold.value()
        try:
            ret = self.camera.tmCamera.tmControl.set_flat_feild_correction_parameters(maxInterval,autoTriggerThreshold)
            if ret is None:
                QMessageBox.information(self.main_window, "FFC parameters", "Camera object is not initialized!")
            elif ret:
                QMessageBox.information(self.main_window, "FFC parameters", "Success in set FFC parameters")
            else:
                QMessageBox.information(self.main_window, "FFC parameters", "Failed to set FFC parameters")
        except Exception as e:
                QMessageBox.information(self.main_window, "FFC parameters", 'Fail to set FFC parameters')
                
    def pushButton_StoreUserSensorConfig_Clicked(self):
        try:
            ret = self.camera.tmCamera.tmControl.store_user_sensor_config()
            if ret:
                QMessageBox.information(self.main_window, "Sensor Control", "Success to store user sensor configurations")
            else:
                QMessageBox.information(self.main_window, "Sensor Control", "Fail to store user sensor configurations")
        except Exception as e:
            print(f'Error while opening camera: {str(e)}')
            
    def pushButton_RestoreDefaultSensorConfig_Clicked(self):
        self.main_window.pushButton_RestoreDefaultSensorConfig.setText('Wait...')
        self.main_window.pushButton_RestoreDefaultSensorConfig.setEnabled(False)
        if self.worker.isRunning():
            self.worker.stop()
            self.worker.wait()
        self.camera.tmCamera.tmControl.restore_default_sensor_config()
        self.camera.tmCamera.close()
        QThread.msleep(1000)
        QMessageBox.information(self.main_window,"TmSDK","Reboot... Reconnect camera device")
        self.main_window.groupBox_4.setEnabled(False)
        self.main_window.groupBox_5.setEnabled(False)
        self.main_window.groupBox_6.setEnabled(False)
        self.main_window.groupBox_7.setEnabled(False)
        self.main_window.pushButton_LocalCameraConnect.setText('Connect')
        self.main_window.pushButton_RemoteCameraConnect.setText('Connect')
        self.main_window.pushButton_LocalCameraConnect.setEnabled(True)
        self.main_window.pushButton_LocalCameraScan.setEnabled(True)
        self.main_window.pushButton_RemoteCameraScan.setEnabled(True)
        self.main_window.pushButton_RestoreDefaultSensorConfig.setEnabled(True)
        self.main_window.pushButton_RestoreDefaultSensorConfig.setText('Restore to Factory\n Default')
        self.main_window.pushButton_RestoreDefaultSensorConfig.setEnabled(True)
        
    def pushButton_GetFluxParameters_160E_Clicked(self):
        try:
            flux_params = self.camera.tmCamera.tmControl.get_flux_parameters(0, 0, 0, 0, 0, 0, 0, 0)
            
            if flux_params:
                self.main_window.doubleSpinBox_FluxParam160E_SceneEmissivity.setValue(flux_params['scene_emissivity'])
                self.main_window.doubleSpinBox_FluxParam160E_BackgroundTemperature.setValue(flux_params['background_temperature'])
                self.main_window.doubleSpinBox_FluxParam160E_WindowTransmission.setValue(flux_params['window_transmission'])
                self.main_window.doubleSpinBox_FluxParam160E_WindowTemperature.setValue(flux_params['window_temperature'])
                self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTransmission.setValue(flux_params['atmospheric_transmission'])
                self.main_window.doubleSpinBox_FluxParam160E_WindowReflection.setValue(flux_params['window_reflection'])
                self.main_window.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.setValue(flux_params['window_reflected_temperature'])
                self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTemperature.setValue(flux_params['atmospheric_temperature'])
               
                
                self.main_window.doubleSpinBox_FluxParam160E_SceneEmissivity.setEnabled(True)
                self.main_window.doubleSpinBox_FluxParam160E_BackgroundTemperature.setEnabled(True)
                self.main_window.doubleSpinBox_FluxParam160E_WindowTransmission.setEnabled(True)
                self.main_window.doubleSpinBox_FluxParam160E_WindowTemperature.setEnabled(True)
                self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTransmission.setEnabled(True)
                self.main_window.doubleSpinBox_FluxParam160E_WindowReflection.setEnabled(True)
                self.main_window.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.setEnabled(True)
                self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTemperature.setEnabled(True)
                self.main_window.pushButton_SetFluxParameters_160E.setEnabled(True)
            else:
                print("Error while getting flux parameters")
        except Exception as e:
                print(f'Error while opening camera: {str(e)}')
                
    def pushButton_SetFluxParameters_160E_Clicked(self):
        sceneEmissivity = self.main_window.doubleSpinBox_FluxParam160E_SceneEmissivity.value()
        backgroundTemperature = self.main_window.doubleSpinBox_FluxParam160E_BackgroundTemperature.value()
        windowTransmission = self.main_window.doubleSpinBox_FluxParam160E_WindowTransmission.value()
        windowTemperature = self.main_window.doubleSpinBox_FluxParam160E_WindowTemperature.value()
        atmosphericTransmission = self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTransmission.value()
        windowReflection = self.main_window.doubleSpinBox_FluxParam160E_WindowReflection.value()
        windowReflectedTemperature = self.main_window.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.value()
        atmosphericTemperature = self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTemperature.value()
        try:
            ret = self.camera.tmCamera.tmControl.set_flux_parameters(sceneEmissivity,
                                                                     atmosphericTransmission,
                                                                     atmosphericTemperature,
                                                                     windowReflectedTemperature,
                                                                     windowReflection,
                                                                     backgroundTemperature,
                                                                     windowTransmission,
                                                                     windowTemperature
                                                                     )
            if ret is None:
                QMessageBox.warning(self.main_window, "Flux parameters", "Camera object is not initialized!")
            elif ret:
                QMessageBox.information(self.main_window, "Flux parameters", "Success in setting Flux parameters")
            else:
                QMessageBox.warning(self.main_window, "Flux parameters", "Failed to set Flux parameters")
                
        except Exception as e:
            QMessageBox.critical(self.main_window, "Flux parameters", f'Error while opening camera: {str(e)}')
            
    def pushButton_GetGainModeState_160E_Clicked(self):
        ret, gainModeState_160E = self.camera.tmCamera.tmControl.get_gain_mode_state()
        if ret:
            if gainModeState_160E == 0: # High
                self.main_window.radioButton_GainModeStateHigh_160E.setChecked(True)
                self.main_window.radioButton_GainModeStateLow_160E.setChecked(False)
                self.main_window.radioButton_GainModeStateAuto_160E.setChecked(False)
            elif gainModeState_160E == 1: #low
                self.main_window.radioButton_GainModeStateHigh_160E.setChecked(False)
                self.main_window.radioButton_GainModeStateLow_160E.setChecked(True) 
                self.main_window.radioButton_GainModeStateAuto_160E.setChecked(False)
            elif gainModeState_160E == 2: #auto
                self.main_window.radioButton_GainModeStateHigh_160E.setChecked(False)
                self.main_window.radioButton_GainModeStateLow_160E.setChecked(False)
                self.main_window.radioButton_GainModeStateAuto_160E.setChecked(True)
            else:
                self.main_window.radioButton_GainModeStateHigh_160E.setChecked(False)
                self.main_window.radioButton_GainModeStateLow_160E.setChecked(False)
                self.main_window.radioButton_GainModeStateAuto_160E.setChecked(False)
                
                QMessageBox.information(self.main_window, "Gain Mode", "Fail to get Gain Mode State")
                
    def pushButton_SetGainModeState_160E_Clicked(self):
        gainModeState_160E=-1
        self.main_window.pushButton_SetGainModeState_160E.setText('Wait..')
        self.main_window.pushButton_SetGainModeState_160E.setEnabled(False)
        
        if (self.main_window.radioButton_GainModeStateHigh_160E.isChecked()==True and 
            self.main_window.radioButton_GainModeStateLow_160E.isChecked()==False and 
            self.main_window.radioButton_GainModeStateAuto_160E.isChecked()==False):
            gainModeState_160E=0
        elif (self.main_window.radioButton_GainModeStateHigh_160E.isChecked()==False and 
             self.main_window.radioButton_GainModeStateLow_160E.isChecked()==True and 
             self.main_window.radioButton_GainModeStateAuto_160E.isChecked()==False):
             gainModeState_160E=1
        elif (self.main_window.radioButton_GainModeStateHigh_160E.isChecked()==False and 
            self.main_window.radioButton_GainModeStateLow_160E.isChecked()==False and 
            self.main_window.radioButton_GainModeStateAuto_160E.isChecked()==True):
            gainModeState_160E=2
            
        if (gainModeState_160E!=-1 and self.camera.tmCamera.tmControl.set_gain_mode_state(gainModeState_160E)):
            QMessageBox.information(self.main_window, "Gain Mode", "Set Gain Mode State Success")
        else:
            QMessageBox.information(self.main_window,'Gain Mode', 'Fail to set Gain Mode State')
        self.main_window.pushButton_SetGainModeState_160E.setText('Set')
        self.main_window.pushButton_SetGainModeState_160E.setEnabled(True)
        
    def pushButton_GetFlatFieldCorrectionMode_160E_Clicked(self):
        _, ffcMode_160E = self.camera.tmCamera.tmControl.get_flat_field_correction_mode()
        if ffcMode_160E == 0: #Manual
            self.main_window.radioButton_FlatFieldCorrectionManual_160E.setChecked(True)
            self.main_window.radioButton_FlatFieldCorrectionAutomatic_160E.setChecked(False)
        elif ffcMode_160E == 1: #Automatic
            self.main_window.radioButton_FlatFieldCorrectionManual_160E.setChecked(False)
            self.main_window.radioButton_FlatFieldCorrectionAutomatic_160E.setChecked(True)
        else:
            self.main_window.radioButton_FlatFieldCorrectionManual_160E.setChecked(False)
            self.main_window.radioButton_FlatFieldCorrectionAutomatic_160E.setChecked(False)
            
            QMessageBox.information(self.main_window, "Flat Field Correction", "Fail to get Flat Field Correction Mode State")
            
    def pushButton_SetFlatFieldCorrectionMode_160E_Clicked(self):
        ffcModeSet_160E = -1
        if (self.main_window.radioButton_FlatFieldCorrectionManual_160E.isChecked() == True 
            and self.main_window.radioButton_FlatFieldCorrectionAutomatic_160E.isChecked() == False):
            ffcModeSet_160E = 0 #Manual
        elif (self.main_window.radioButton_FlatFieldCorrectionManual_160E.isChecked() == False
             and self.main_window.radioButton_FlatFieldCorrectionAutomatic_160E.isChecked() == True):
            ffcModeSet_160E = 1 #Automatic
        if (ffcModeSet_160E!=-1):
            self.camera.tmCamera.tmControl.set_flat_feild_correction_mode(ffcModeSet_160E)
        else:
            QMessageBox.information(self.main_window, "Flat Field Correction", "Fail to set Flat Field Correction Mode")
            
    def pushButton_RunFlatFieldCorrection_160E_Clicked(self):
        self.main_window.pushButton_RunFlatFieldCorrection_160E.setText("Wait..")
        self.main_window.pushButton_RunFlatFieldCorrection_160E.setEnabled(False)
        try:
            ret = self.camera.tmCamera.tmControl.run_flat_field_correction()
            if ret:
                QMessageBox.information(self.main_window, "Flat Field Correction", "Success to run Flat field Correction")
            else:
                QMessageBox.information(self.main_window, "Flat Field Correction", "Fail to run Flat field Correction")    
        except Exception as e:
            print(f'Error while running flat field correction: {str(e)}')
        self.main_window.pushButton_RunFlatFieldCorrection_160E.setText('Run')
        self.main_window.pushButton_RunFlatFieldCorrection_160E.setEnabled(True)  
        
    def pushButton_RestoreDefaultFluxParameters_160E_Clicked(self):
        success, params = self.camera.tmCamera.tmControl.set_flux_default_parameters()
        if success:
            self.main_window.doubleSpinBox_FluxParam160E_SceneEmissivity.setValue(params['scene_emissivity'])
            self.main_window.doubleSpinBox_FluxParam160E_BackgroundTemperature.setValue(params['background_temperature'])
            self.main_window.doubleSpinBox_FluxParam160E_WindowTransmission.setValue(params['window_transmission'])
            self.main_window.doubleSpinBox_FluxParam160E_WindowTemperature.setValue(params['window_temperature'])
            self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTransmission.setValue(params['atmospheric_transmission'])
            self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTemperature.setValue(params['atmospheric_temperature'])
            self.main_window.doubleSpinBox_FluxParam160E_WindowReflection.setValue(params['window_reflection'])
            self.main_window.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.setValue(params['window_reflected_temperature'])
            self.main_window.doubleSpinBox_FluxParam160E_SceneEmissivity.setEnabled(True)
            self.main_window.doubleSpinBox_FluxParam160E_BackgroundTemperature.setEnabled(True)
            self.main_window.doubleSpinBox_FluxParam160E_WindowTransmission.setEnabled(True)
            self.main_window.doubleSpinBox_FluxParam160E_WindowTemperature.setEnabled(True)
            self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTransmission.setEnabled(True)
            self.main_window.doubleSpinBox_FluxParam160E_AtmosphericTemperature.setEnabled(True)
            self.main_window.doubleSpinBox_FluxParam160E_WindowReflection.setEnabled(True)
            self.main_window.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.setEnabled(True)
            self.main_window.pushButton_SetFluxParameters_160E.setEnabled(True)

            QMessageBox.information(self.main_window,"Flux Parameters", "Success to restore Factory Default Flux Parameters.")
        else:
            QMessageBox.information(self.main_window,"Flux Parameters", "Fail to restore Factory Default Flux Parameters.")
            
    def pushButton_GetGainModeState_Clicked(self):
        ret, gainMode = self.camera.tmCamera.tmControl.get_gain_mode_state()
        if ret:
            if gainMode==0:
                self.main_window.radioButton_GainModeHigh.setChecked(False)
                self.main_window.radioButton_GainModeLow.setChecked(True)
            else:
                self.main_window.radioButton_GainModeHigh.setChecked(True)
                self.main_window.radioButton_GainModeLow.setChecked(False)
                
    def pushButton_SetGainModeState_Clicked(self):
        if (self.main_window.radioButton_GainModeHigh.isChecked() == True 
            and self.main_window.radioButton_GainModeLow.isChecked() == False):
            self.camera.tmCamera.tmControl.set_gain_mode_state(1)
        elif (self.main_window.radioButton_GainModeHigh.isChecked() == False 
              and self.main_window.radioButton_GainModeLow.isChecked() == True):
            self.camera.tmCamera.tmControl.set_gain_mode_state(0)
            
        