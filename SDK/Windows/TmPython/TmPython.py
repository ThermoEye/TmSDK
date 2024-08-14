# from asyncio import FIRST_COMPLETED
from math import e
from optparse import AmbiguousOptionError
import os, sys
from re import S
from sqlite3 import Row
import time
import ctypes
# from tkinter import N, SE, SEL, Frame
from turtle import mode
from unittest.mock import CallableMixin

# from matplotlib.pylab import disconnect, f
if sys.platform.startswith("linux"):
	sys.path.append("../../Shared/Python/")
elif os.name == "nt":
    sys.path.append(sys.path[0] + "\\..\\..\\" + "Modules\\Shared\\Managed\\Python")

print(f'1 = {os.name}')
print(f'2 = {sys.path[0]}')
print(f'3 = {sys.path}')

from PyQt5.QtCore import *
from PyQt5.QtWidgets import *
from PyQt5 import uic
from PyQt5.QtGui import *

from TmCore import *
from TmCore.TmTypes import *
from TmCore.TmRoi import *


uiForm = uic.loadUiType("mainwindow.ui")[0]

class FrameWorker(QThread):
    def __init__(self, parent):
        super().__init__();
        self.parent = parent

    def stop(self): 
        self.isRun = False


        
    def run(self):
        self.isRun = True

        while self.isRun:
            # tmFrame = TmFrame()
            # self.parent.tmCamera.query_frame(tmFrame, self.parent.label_Preview.width(), self.parent.label_Preview.width())
            tmFrame = self.parent.tmCamera.query_frame( self.parent.label_Preview.width(), self.parent.label_Preview.width())
            if tmFrame is not None:
                current_color_map=self.parent.comboBox_ColorMap.currentIndex()
                self.parent.tmCamera.set_color_map(current_color_map)
                image = tmFrame.to_bitmap(1)
                qimage = QImage(image, self.parent.label_Preview.width(), self.parent.label_Preview.height(), QImage.Format_RGB888)
                print('inside thread')
                minVal, avgVal, maxVal, minLoc, maxLoc = tmFrame.min_max_loc()
                print(f'minVal = {minVal}, avgVal = {avgVal}, maxVal = {maxVal}, minLoc = {minLoc.x},{minLoc.y}, maxLoc = {maxLoc.x},{maxLoc.y}')
                self.parent.comboBox_TemperatureUnit_Changed(minVal, avgVal, maxVal)
                cnt = self.parent.roiManager.get_roi_item_count()
                #print(f'item count = {cnt}')
                for i in range(cnt):
                    #print(f'roi type = {self.parent.roiManager.get_roi_type(i)}')
                    item = self.parent.roiManager.get_roi_item(i)
                    tmFrame.do_measure(item)
                    roiType = item.get_roi_type()
                   # print(f'roi type = {roiType} class type = {type(item)}')
                    if (roiType == RoiType.Rect):
                        roiRect = RoiRect(item)
                        print(f'========================================')
                        rect = roiRect.get_rectangle()
                        #print(f'RECT x = {rect.x}, y = {rect.y}, w = {rect.width}, h = {rect.height}')
                # DrawShapeObjects(image);
                

                pix = QPixmap.fromImage(qimage)
                self.parent.label_Preview.setPixmap(pix)
                self.parent.label_Preview.show()
               
                del tmFrame

class MainWindow(QMainWindow, uiForm):
    bar_signal = pyqtSignal(int)
    def __init__(self):
        super().__init__()
        self.tmCamera = TmCamera()
        self.roiManager = TmRoiManager()
        #self.tmControl=TmControl()
        self.setupUi(self)
        self.LocalCamList=[]
        self.RemoteCamList=[]
        self.radioButton_ShapeCursor.setChecked(True)
        # self.setWindowIcon(QIcon("QrPython.ico"))
        self.setWindowTitle("TmPython")
        self.init()
        self.scan_local_camera_list()
        self.scan_remote_camera_list()
        self.show()


    def init(self):
        self.worker = FrameWorker(self)
        self.worker.isRun = False
        #self.tempunitindex=TempUnit.CELSIUS
        #self.comboBox_TemperatureUnit.setCurrentIndex(self.tempunitindex)

        ### Roi Test Code
        
        
        cnt = self.roiManager.get_roi_item_count()
        print(f'item count = {cnt}')
        
        self.roiManager.add_item_xywh(RoiType.Rect, 10, 10, 50, 50)
        

        self.roiManager.set_selected_roi_type(RoiType.Line)
        pt = Point()
        pt.x = 10
        pt.y = 20
        self.roiManager.mouse_down(pt)
        pt.x = 100
        pt.y = 200
        self.roiManager.mouse_up(pt)
        #serial=self.tmCamera.SensorSerial()
        #print(f'Serial = {serial}') 
        
        cnt = self.roiManager.get_roi_item_count()
        print(f'item count = {cnt}')
        #hardwareversion=self.tmControl.GetHardwareVersion()
        #print(f'hardware version = {hardwareversion}')
        for i in range(cnt):
            print(f'roi type = {self.roiManager.get_roi_type(i)}')
            item = self.roiManager.get_roi_item(i)
            print(f'roi item type = {self.roiManager.get_roi_type(i)}')

    def scan_local_camera_list(self):
        self.lineEdit_LocalCameraName.setText("")
        self.lineEdit_LocalCameraPort.setText("")
        self.listWidget_LocalCameraList.clear()
        print("Doing scan local camera list...")
        for cam in self.LocalCamList:
            del cam
        self.LocalCamList.clear()    
        name, port, index, count = self.tmCamera.get_local_camera_list()
        for i in range(0, count):
            if name[i].startswith("TMC"):
                item = name[i] + '-' + port[i]
                self.listWidget_LocalCameraList.addItem(item)
                self.LocalCamList.append([name[i],port[i],index[i]])
                print(f'Local Camera List = {item}-{index[i]}')
        if self.LocalCamList:
            self.listWidget_LocalCameraList.setCurrentRow(0)
            camInfo=self.LocalCamList[0]
            self.lineEdit_LocalCameraName.setText(camInfo[0])
            self.lineEdit_LocalCameraPort.setText(camInfo[1])    

    def scan_remote_camera_list(self):
        self.lineEdit_RemoteCameraName.setText("")
        self.lineEdit_RemoteCameraSerial.setText("")
        self.lineEdit_RemoteCameraMac.setText("")
        self.lineEdit_RemoteCameraIp.setText("")
        for cam in self.RemoteCamList:
            del cam
        self.RemoteCamList.clear()    
        print("Not yet..")
        name, serial, mac, ip, count = self.tmCamera.get_remote_camera_list(20)
        for i in range(0, count):
            item = name[i] + '-' + ip[i]
            self.listWidget_RemoteCameraList.addItem(item)
            self.RemoteCamList.append([name[i],serial[i],mac[i],ip[i]])
            print(f'Remote Camera List = {item}')
        if self.RemoteCamList:
            camInfo=self.RemoteCamList[0]    
            self.lineEdit_RemoteCameraName.setText(camInfo[0])
            self.lineEdit_RemoteCameraSerial.setText(camInfo[1])
            self.lineEdit_RemoteCameraMac.setText(camInfo[2])
            self.lineEdit_RemoteCameraIp.setText(camInfo[3])

    def pushButton_LocalCameraConnect_Clicked(self):
        if (self.pushButton_LocalCameraConnect.text() == "Connect"):
            try:
            
                row=self.listWidget_LocalCameraList.currentRow()
                if row<0 or row>=len(self.LocalCamList):
                    print('No camera selected')
                    return
                ret = self.tmCamera.open_local_camera((self.LocalCamList[row])[0],(self.LocalCamList[row])[1],(self.LocalCamList[row])[2]);
                print(f"ret = {ret}")
                if ret:
                    print('Camera connected')
                    self.pushButton_LocalCameraConnect.setText("Disconnect")
                    self.worker=FrameWorker(self)
                    self.worker.start()
                    val = self.tmCamera.get_temp_unit()
                    print(f'temp unit = {val}')
                    if self.LocalCamList[row][0]=="TMC256B":
                        print('inside TMC256B')
                        self.tabWidget_Control.setCurrentIndex(0)
                        self.stackedWidget_SensorControl.setCurrentIndex(0)
                    elif (self.LocalCamList[row][0]=="TMC160B" or self.LocalCamList[row][0]=="TMC80B"):
                        print('inside TMC160B or TMC80B')
                        self.tabWidget_Control.setCurrentIndex(0)
                        self.stackedWidget_SensorControl.setCurrentIndex(1)
                    self.tmCamera.set_temp_unit(TempUnit.CELSIUS)
                    val = self.tmCamera.get_temp_unit()
                    print(f'temp unit = {val}')


                    name = self.tmCamera.get_product_model_name()
               # serial=self.tmCamera.SensorSerial()
               # print(f'Serial = {serial}')
                    print(f'Name = {name}')
        
                    tmRoiManager = TmRoiManager()
                    tmRoiManager.set_selected_roi_type(RoiType.Spot)
                    roiType = tmRoiManager.get_selected_roi_type()
                    print(f'roi type = {roiType}')
                   # self.worker.start()
            except Exception as e:
                print(f'Error while opening camera: {str(e)}')
        else:
            self.DisconnectCamera()
            self.pushButton_LocalCameraConnect.setText("Connect")
            

        # tmFrame = self.tmCamera.QueryFrame(self.label_Preview.width(), self.label_Preview.height())
        # print(f'tmFrame = {tmFrame}')
    def tabWidget_ConnectCamera_CurrentChanged(self):
        print("Not yet..")
    def pushButton_RemoteCameraConnect_Clicked(self):
        if (self.pushButton_RemoteCameraConnect.text() == "Connect"):
            try:
                row=self.listWidget_RemoteCameraList.currentRow()
                if row<0 or row>=len(self.RemoteCamList):
                    print('No camera selected')
                    return
                ret = self.tmCamera.open_remote_camera((self.RemoteCamList[row])[0], (self.RemoteCamList[row])[1], (self.RemoteCamList[row])[2], (self.RemoteCamList[row])[3])
                if ret:
                    print('Camera connected')
                    self.pushButton_RemoteCameraConnect.setText("Disconnect")
                    self.worker=FrameWorker(self)
                    self.worker.start()
                    if self.RemoteCamList[row][0]=="TMC256E":
                        self.tabWidget_Control.setCurrentIndex(0)
                        self.stackedWidget_SensorControl.setCurrentIndex(0)
                    elif (self.RemoteCamList[row][0]=="TMC160E" or self.RemoteCamList[row][0]=="TMC80E"):
                        self.tabWidget_Control.setCurrentIndex(0)
                        self.stackedWidget_SensorControl.setCurrentIndex(1)
            except Exception as e:
                print(f'Error while opening camera: {str(e)}')  
        else:       
                self.DisconnectCamera()
                self.pushButton_RemoteCameraConnect.setText("Connect")
    def listWidget_LocalCameraList_CurrentRowChanged(self):
        print("have to check..")
        row=self.listWidget_LocalCameraList.currentRow()
        camInfo=self.LocalCamList[row]
        self.lineEdit_LocalCameraName.setText(camInfo[0])
        self.lineEdit_LocalCameraPort.setText(camInfo[1]) 
    def listWidget_RemoteCameraList_CurrentRowChanged(self):
        print("have to check..")
        row=self.listWidget_RemoteCameraList.currentRow()
        CamInfo=self.RemoteCamList[row]
        self.lineEdit_RemoteCameraName.setText(CamInfo[0])
        self.lineEdit_RemoteCameraSerial.setText(CamInfo[1])
        self.lineEdit_RemoteCameraMac.setText(CamInfo[2])
        self.lineEdit_RemoteCameraIp.setText(CamInfo[3])
    def pushButton_GetProductInformation_Clicked(self):
        print("have to check..")
        modelName = self.tmCamera.get_product_model_name()
        serialNumber=self.tmCamera.get_product_serial()
        hardwareVersion=self.tmCamera.get_hardware_version()
        bootloaderVersion=self.tmCamera.get_bootloader_version()
        firmwareVersion=self.tmCamera.get_firmware_version()
        print(f'modelName = {modelName}')
        self.label_ProductModelName.setText(modelName)
        self.label_ProductSerialNumber.setText(serialNumber)
        self.label_HardwareVersion.setText(hardwareVersion)
        self.label_BootloaderVersion.setText(bootloaderVersion)
        self.label_FirmwareVersion.setText(firmwareVersion)
    def pushButton_GetGainModeState_Clicked(self):
        print("have to check..")
        ret, gainMode = self.tmCamera.get_gain_mode_state()
        if ret:
            if gainMode==0:
                self.radioButton_GainModeHigh.setChecked(False)
                self.radioButton_GainModeLow.setChecked(True)
            else:
                self.radioButton_GainModeHigh.setChecked(True)
                self.radioButton_GainModeLow.setChecked(False)
        
    def pushButton_GetGainModeState_160E_Clicked(self):
        ret, gainModeState_160E = self.tmCamera.get_gain_mode_state()
        if ret:
            if gainModeState_160E==0: # High
                self.radioButton_GainModeStateHigh_160E.setChecked(True)
                self.radioButton_GainModeStateLow_160E.setChecked(False)
                self.radioButton_GainModeStateAuto_160E.setChecked(False)
            elif gainModeState_160E==1: #low
                self.radioButton_GainModeStateHigh_160E.setChecked(False)
                self.radioButton_GainModeStateLow_160E.setChecked(True) 
                self.radioButton_GainModeStateAuto_160E.setChecked(False)
            elif gainModeState_160E==2: #auto
                self.radioButton_GainModeStateHigh_160E.setChecked(False)
                self.radioButton_GainModeStateLow_160E.setChecked(False)
                self.radioButton_GainModeStateAuto_160E.setChecked(True)
            else:
                self.radioButton_GainModeStateHigh_160E.setChecked(False)
                self.radioButton_GainModeStateLow_160E.setChecked(False)
                self.radioButton_GainModeStateAuto_160E.setChecked(False)
                
                QMessageBox.information(self, "Gain Mode", "Fail to get Gain Mode State")
    def pushButton_SetGainModeState_Clicked(self):       
        if (self.radioButton_GainModeHigh.isChecked()==True and self.radioButton_GainModeLow.isChecked()==False):
            self.tmCamera.set_gain_mode_state(1)
        elif (self.radioButton_GainModeHigh.isChecked()==False and self.radioButton_GainModeLow.isChecked()==True):
            self.tmCamera.set_gain_mode_state(0)
    def pushButton_SetGainModeState_160E_Clicked(self):
        gainModeState_160E=-1
        self.pushButton_SetGainModeState_160E.setText('Wait..')
        self.pushButton_SetGainModeState_160E.setEnabled(False)
        
        if (self.radioButton_GainModeStateHigh_160E.isChecked()==True and 
            self.radioButton_GainModeStateLow_160E.isChecked()==False and 
            self.radioButton_GainModeStateAuto_160E.isChecked()==False):
            gainModeState_160E=0
        elif (self.radioButton_GainModeStateHigh_160E.isChecked()==False and 
             self.radioButton_GainModeStateLow_160E.isChecked()==True and 
             self.radioButton_GainModeStateAuto_160E.isChecked()==False):
             gainModeState_160E=1
        elif (self.radioButton_GainModeStateHigh_160E.isChecked()==False and 
            self.radioButton_GainModeStateLow_160E.isChecked()==False and 
            self.radioButton_GainModeStateAuto_160E.isChecked()==True):
            gainModeState_160E=2
            
        if (gainModeState_160E!=-1 and self.tmCamera.set_gain_mode_state(gainModeState_160E)):
            QMessageBox.information(self, "Gain Mode", "Set Gain Mode State Success")
        else:
            QMessageBox.information(self,'Gain Mode', 'Fail to set Gain Mode State')
        self.pushButton_SetGainModeState_160E.setText('Set')
        self.pushButton_SetGainModeState_160E.setEnabled(True)
        
    def pushButton_GetNetworkConfiguration_Clicked(self):
        print("Not yet..")
    def pushButton_SystemReboot_Clicked():
        print("Not yet..")
    def pushButton_SetFlatFieldCorrectionMode_160E_Clicked(self):
        print("Not yet..")
    def pushButton_SetFlatFieldCorrectionMode_Clicked(self):
        print("Not yet..")    
    def radioButton_ShapeCursor_clicked(self):
        self.roiManager.set_selected_roi_type(RoiType.Hand)
        print("Not yet..")
    def radioButton_ShapeSpot_Clicked(self):
        self.roiManager.set_selected_roi_type(RoiType.Spot)
        print("Not yet..")
    def radioButton_ShapeLine_Clicked(self):
        self.roiManager.set_selected_roi_type(RoiType.Line)
        print("Not yet..")
    def radioButton_ShapeRectangle_Clicked(self):
        self.roiManager.set_selected_roi_type(RoiType.Rect)
        print("Not yet..")
    def radioButton_ShapeEllipse_Clicked(self):
        self.roiManager.set_selected_roi_type(RoiType.Ellipse)
        print("Not yet..")
    def pushButton_RemoveAllRoi_Clicked(self):
        self.roiManager.roi_clear()
        print("Not yet..")
    def pushButton_RemoteCameraScan_Clicked(self):
        print("Not yet..")
    def pushButton_LocalCameraScan_Clicked(self):
        print("Not yet..")
    def pushButton_GetFlatFieldCorrectionMode_160E_Clicked(self):
        print("Not yet..")
    def pushButton_GetFlatFieldCorrectionMode_Clicked(self):
        print("Not yet..")
        
    def comboBox_ColorMap_Changed(self):
        color_map_index=self.comboBox_ColorMap.currentIndex()
        if hasattr(self,"tmCamera"):
            self.tmCamera.set_color_map(color_map_index)
        ##self.parent.tmCamera.set_color_map(self.comboBox_ColorMap.currentIndex())
        print(f"Color map changed to index = {color_map_index}")
        print("Not yet..")
    def checkBox_NoiseFiltering_toggled(self):
        print("Not yet..")
    def comboBox_TemperatureUnit_Changed(self,min=0,avg=0,max=0):
        #print("Temperature unit changed")
        ss=''
        temp_unit=self.comboBox_TemperatureUnit.currentIndex()
        self.tmCamera.set_temp_unit(temp_unit)
        if temp_unit == TempUnit.CELSIUS:
            ss=" \xb0c"
        elif temp_unit == TempUnit.FAHRENHEIT:
            ss=' \xb0F'
        elif temp_unit == TempUnit.KELVIN:
            ss=' K'
        if ss !='':
            min=self.tmCamera.get_temperature(min)
            avg=self.tmCamera.get_temperature(avg)
            max=self.tmCamera.get_temperature(max)
        else:
            min=min
            avg=avg
            max=max
        self.label_MinimumTemperature.setText(f'{min:.2f}{ss}')
        self.label_AverageTemperature.setText(f'{avg:.2f}{ss}')
        self.label_MaximumTemperature.setText(f'{max:.2f}{ss}')
        print(f"Updated temperatures: min = {min}, avg = {avg}, max = {max}")
    def pushButton_GetSensorInformation_Clicked(self):
        serialNumber=self.tmCamera.get_sensor_serial_number()
        modelName=self.tmCamera.get_sensor_model_name()
        sensorUptime=self.tmCamera.get_sensor_uptime()    
        self.label_SensorModelName.setText((modelName))
        self.label_SensorSerialNumber.setText(serialNumber)
        self.label_SensorUptime.setText(sensorUptime)
        print("have to check..")
    def pushButton_SetNetworkConfiguration_Clicked(self):
        print("Not yet..")  
    def pushButton_SetDefaultNetworkConfiguration_Clicked():
        print("Not yet..")
    def pushButton_LocalCameraScan_Clicked():
        print("Not yet..")
    def pushButton_SoftwareUpdateFileBrowse_Clicked(self):
        print("Not yet..")
    def pushButton_StartSoftwareUpdate_Clicked(self):
        print("Not yet..")
    def pushButton_GetFlatFieldCorrection_Clicked(self):
        print("Not yet..")
        ret,ffcMode=self.tmCamera.get_flat_field_correction_mode()
        if ret:
            if ffcMode==0: #Manual
                self.radioButton_FlatFieldCorrectionManual.setChecked(True)
                self.radioButton_FlatFieldCorrectionAutomatic.setChecked(False)
            else:
                self.radioButton_FlatFieldCorrectionManual.setChecked(False)
                self.radioButton_FlatFieldCorrectionAutomatic.setChecked(True)
            
    def pushButton_GetFlatFieldCorrection_160E_Clicked(self):
        print("Not yet..")     
    def pushButton_SetFlatFieldCorrection_Clicked(self):
        print("Not yet..")
    def pushButton_SetFlatFieldCorrection_160E_Clicked(self):
        print("Not yet..")    
    def pushButton_RunFlatFieldCorrection_Clicked(self):
        print("Not yet..")
    def pushButton_RunFlatFieldCorrection_160E_Clicked(self):
        print("Not yet..")    
    def pushButton_GetFluexParams_Clicked(self):
        print("inside Get Fluex..")
        try:
            flux_params=self.tmCamera.get_flux_parameters5()
            
            if flux_params:
                self.doubleSpinBox_FluexParamEmissivity.setValue(flux_params['emissivity'])
                self.doubleSpinBox_FluexParamAtmosphericTransmittance.setValue(flux_params['atmospheric_transmittance'])
                self.doubleSpinBox_FluexParamAtmosphericTemperature.setValue(flux_params['atmospheric_temperature'])
                self.doubleSpinBox_FluexParamAmbientReflectionTemp.setValue(flux_params['ambient_reflection_temperature'])
                self.doubleSpinBox_FluexParamDistance.setValue(flux_params['distance'])        
                self.doubleSpinBox_FluexParamEmissivity.setEnabled(True)
                self.doubleSpinBox_FluexParamAtmosphericTransmittance.setEnabled(True)
                self.doubleSpinBox_FluexParamAtmosphericTemperature.setEnabled(True)
                self.doubleSpinBox_FluexParamAmbientReflectionTemp.setEnabled(True)
                self.doubleSpinBox_FluexParamDistance.setEnabled(True)
                self.pushButton_SetFluexParams.setEnabled(True)
            else:
                print("Error while getting flux parameters")
        except Exception as e:
                print(f'Error while opening camera: {str(e)}') 
    def pushButton_GetFluexParams_160E_Clicked(self):
        print("inside Get Fluex..")
        try:
            flux_params=self.tmCamera.get_flux_parameters8()
            
            if flux_params:
                self.doubleSpinBox_FluxParam160E_SceneEmissivity.setValue(flux_params['scane_emissivity'])
                self.doubleSpinBox_FluxParam160E_BackgroundTemperature.setValue(flux_params['background_temperature'])
                self.doubleSpinBox_FluxParam160E_WindowTransmission.setValue(flux_params['window_transmission'])
                self.doubleSpinBox_doubleSpinBox_FluxParam160E_WindowTemperature.setValue(flux_params['window_temperature'])
                self.doubleSpinBox_doubleSpinBox_FluxParam160E_AtmosphericTransmission.setValue(flux_params['atmospheric_transmission'])
                self.doubleSpinBox_doubleSpinBox_FluxParam160E_WindowReflection.setValue(flux_params['window_reflection'])
                self.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.setValue(flux_params['window_reflected_temperature'])
                self.doubleSpinBox_doubleSpinBox_FluxParam160E_AtmosphericTemperature.setValue(flux_params['atmospheric_temperature'])
               
                
                self.doubleSpinBox_FluxParam160E_SceneEmissivity.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_BackgroundTemperature.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_WindowTransmission.setEnabled(True)
                self.doubleSpinBox_doubleSpinBox_FluxParam160E_WindowTemperature.setEnabled(True)
                self.doubleSpinBox_doubleSpinBox_FluxParam160E_AtmosphericTransmission.setEnabled(True)
                self.doubleSpinBox_doubleSpinBox_FluxParam160E_WindowReflection.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.setEnabled(True)
                self.doubleSpinBox_doubleSpinBox_FluxParam160E_AtmosphericTemperature.setEnabled(True)
                self.pushButton_SetFluxParams_160E.setEnabled(True)
            else:
                print("Error while getting flux parameters")
        except Exception as e:
                print(f'Error while opening camera: {str(e)}') 
    def pushButton_GetFluxParams_160E_Clicked(self):
        print("Not yet..")
    def pushButton_GetFluxParameters_160E_Clicked(self):
       # print("Not yet..")  
        print("inside Get Flux_160E..")
        try:
            flux_params=self.tmCamera.get_flux_parameters8()
            
            if flux_params:
                self.doubleSpinBox_FluxParam160E_SceneEmissivity.setValue(flux_params['scane_emissivity'])
                self.doubleSpinBox_FluxParam160E_BackgroundTemperature.setValue(flux_params['background_temperature'])
                self.doubleSpinBox_FluxParam160E_WindowTransmission.setValue(flux_params['window_transmission'])
                self.doubleSpinBox_FluxParam160E_WindowTemperature.setValue(flux_params['window_temperature'])
                self.doubleSpinBox_FluxParam160E_AtmosphericTransmission.setValue(flux_params['atmospheric_transmission'])
                self.doubleSpinBox_FluxParam160E_WindowReflection.setValue(flux_params['window_reflection'])
                self.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.setValue(flux_params['window_reflected_temperature'])
                self.doubleSpinBox_FluxParam160E_AtmosphericTemperature.setValue(flux_params['atmospheric_temperature'])
               
                
                self.doubleSpinBox_FluxParam160E_SceneEmissivity.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_BackgroundTemperature.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_WindowTransmission.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_WindowTemperature.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_AtmosphericTransmission.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_WindowReflection.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.setEnabled(True)
                self.doubleSpinBox_FluxParam160E_AtmosphericTemperature.setEnabled(True)
                self.pushButton_SetFluxParameters_160E.setEnabled(True)
            else:
                print("Error while getting flux parameters")
        except Exception as e:
                print(f'Error while opening camera: {str(e)}')
    def pushButton_GetFluxParameters_Clicked(self):
        print("Not yet..")    
    def pushButton_GetFluxParams_Clicked(self):
        print("Not yet..")        
    def pushButton_SetFluxParams_Clicked(self):
        print("Not yet..")
    def pushButton_SetFluexParams_Clicked(self):
        print("Not yet..")
        print("inside Set Fluex..")
        emissivity=self.doubleSpinBox_FluexParamEmissivity.value()
        atmosphericTransmittance=self.doubleSpinBox_FluexParamAtmosphericTransmittance.value()
        atmosphericTemperature=self.doubleSpinBox_FluexParamAtmosphericTemperature.value()
        ambientReflectionTemp=self.doubleSpinBox_FluexParamAmbientReflectionTemp.value()
        distance=self.doubleSpinBox_FluexParamDistance.value()
        try:
            ret=self.tmCamera.set_flux_parameters5(emissivity,atmosphericTransmittance,atmosphericTemperature,ambientReflectionTemp,distance)
        
            if ret is None:
                QMessageBox.warning(self, "Fluex parameters", "TmCamera object is not initialized!")
            elif ret:
                QMessageBox.information(self, "Fluex parameters", "Success in setting Fluex parameters")
            else:
                QMessageBox.warning(self, "Fluex parameters", "Failed to set Fluex parameters")
        except Exception as e:
            QMessageBox.critical(self, "Fluex parameters", f'Error while opening camera: {str(e)}')
        
    def pushButton_SetFluxParameters_160E_Clicked(self):
        print("Not yet..")
        sceneEmissivitySet=self.doubleSpinBox_FluxParam160E_SceneEmissivity.value()
        backgroundTemperatureSet=self.doubleSpinBox_FluxParam160E_BackgroundTemperature.value()
        windowTransmissionSet=self.doubleSpinBox_FluxParam160E_WindowTransmission.value()
        windowTemperatureSet=self.doubleSpinBox_FluxParam160E_WindowTemperature.value()
        atmosphericTransmissionSet=self.doubleSpinBox_FluxParam160E_AtmosphericTransmission.value()
        windowReflectionSet=self.doubleSpinBox_FluxParam160E_WindowReflection.value()
        windowReflectedTemperatureSet=self.doubleSpinBox_FluxParam160E_WindowReflectedTemperature.value()
        atmosphericTemperatureSet=self.doubleSpinBox_FluxParam160E_AtmosphericTemperature.value()
        try:
            ret=self.tmCamera.set_flux_parameters8(sceneEmissivitySet,backgroundTemperatureSet,windowTransmissionSet,
                                               windowTemperatureSet,atmosphericTransmissionSet,windowReflectionSet,
                                               windowReflectedTemperatureSet,atmosphericTemperatureSet)
            if ret is None:
                QMessageBox.warning(self, "Flux parameters", "Camera object is not initialized!")
            elif ret:
                QMessageBox.information(self, "Flux parameters", "Success in setting Flux parameters")
            else:
                QMessageBox.warning(self, "Flux parameters", "Failed to set Flux parameters")
                
        except Exception as e:
            QMessageBox.critical(self, "Flux parameters", f'Error while opening camera: {str(e)}')
    def pushButton_GetFFCParams_Clicked(self):
        print("Not yet..")
        try:
            success,maxInterval,autoTriggerThreshold=self.tmCamera.get_flat_feild_correction_parameters()
            if success:
                self.doubleSpinBox_FFCParam_MaxInterval.setValue(maxInterval)
                self.doubleSpinBox_FFCParamAutoTriggerThreshold.setValue(autoTriggerThreshold)
                self.doubleSpinBox_FFCParam_MaxInterval.setEnabled(True)
                self.doubleSpinBox_FFCParamAutoTriggerThreshold.setEnabled(True)
                self.pushButton_SetFFCParams.setEnabled(True)
            else:
                print("Error while getting FFC parameters")
        except Exception as e:
            print(f'An Error occured: {str(e)}')
    def pushButton_SetFFCParams_Clicked(self):
        print("Not yet..")
        maxInterval=self.doubleSpinBox_FFCParam_MaxInterval.value()
        autoTriggerThreshold=self.doubleSpinBox_FFCParamAutoTriggerThreshold.value()
        try:
            ret=self.tmCamera.set_flat_feild_correction_parameters(maxInterval,autoTriggerThreshold)
            if ret is None:
                QMessageBox.information(self, "FFC parameters", "Camera object is not initialized!")
            elif ret:
                QMessageBox.information(self, "FFC parameters", "Success in set FFC parameters")
            else:
                QMessageBox.information(self, "FFC parameters", "Failed to set FFC parameters")
        except Exception as e:
                QMessageBox.information(self, "FFC parameters", 'Fail to set FFC parameters')
    def pushButton_StoreUserSensorConfig_Clicked(self):
        print("Not yet..")
    def pushButton_RestoreDefaultSensorConfig_Clicked(self):
        print("Not yet..")
    def pushButton_RestoreDefaultFluxParameters_160E_Clicked(self):
        print("Not yet..")        
    def pushButton_RemoveRoiItem_Clicked(self):
        print("Not yet..")
    def pushButton_AddRoiItem_Clicked(self):
        print("Not yet..")
    def DisconnectCamera(self):
        if self.worker.isRunning():
            self.worker.stop()
            self.worker.wait()
        try:
            self.roiManager.roi_clear()
            self.tmCamera.close()
        except Exception as e:
            print(f'Error while closing camera: {str(e)}')
        self.tmCamera=TmCamera()   
        print("Camera disconnected")    

if __name__ == '__main__':
    qApp = QApplication(sys.argv)
    mainWin = MainWindow()
    sys.exit(qApp.exec_())
    print("Good Bye...")