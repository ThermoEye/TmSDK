#################################################################
# Company: Thermoeye, Inc
# Project: TmSDK
# File: FirmwareWorker.py
# Creation date: 2024-08-19
# Version: 1.0.0
#
# Description: This file contains the following implementations:
# - Connecting event slots
# - Handling mouse events
#
# History: 2024-08-19: Initial version.
#
#################################################################
import os, sys
import ctypes
from PyQt5.QtWidgets import QMainWindow, QApplication
from PyQt5 import uic
from PyQt5.QtCore import QObject, QEvent, Qt
from PyQt5.QtGui import QMouseEvent

from Camera import Camera
from CameraControl import CameraControl
from SensorControl import SensorControl

class MainWindow(QMainWindow):
    def __init__(self, parent=None):
        super(MainWindow, self).__init__(parent)
        uic.loadUi('mainwindow.ui', self)

        # Initialize the logic classes
        self.camera = Camera(self)
        self.camera_ctrl = CameraControl(self, self.camera)
        self.sensor_ctrl = SensorControl(self, self.camera)

        # Connect UI elements to the slots in the logic classes
        self.pushButton_LocalCameraScan.clicked.connect(self.camera.pushButton_LocalCameraScan_Clicked)
        self.pushButton_RemoteCameraScan.clicked.connect(self.camera.pushButton_RemoteCameraScan_Clicked)
        self.pushButton_LocalCameraConnect.clicked.connect(self.camera.pushButton_LocalCameraConnect_Clicked)
        self.pushButton_RemoteCameraConnect.clicked.connect(self.camera.pushButton_RemoteCameraConnect_Clicked)
        self.tabWidget_ConnectCamera.currentChanged.connect(self.camera.tabWidget_ConnectCamera_CurrentChanged)
        self.listWidget_LocalCameraList.currentRowChanged.connect(self.camera.listWidget_LocalCameraList_CurrentRowChanged)
        self.listWidget_RemoteCameraList.currentRowChanged.connect(self.camera.listWidget_RemoteCameraList_CurrentRowChanged)
        self.comboBox_ColorMap.currentIndexChanged.connect(self.camera.comboBox_ColorMap_Changed)
        self.checkBox_NoiseFiltering.toggled.connect(self.camera.checkBox_NoiseFiltering_toggled)
        self.comboBox_TemperatureUnit.currentIndexChanged.connect(self.camera.comboBox_TemperatureUnit_Changed)
        self.radioButton_ShapeCursor.clicked.connect(self.camera.radioButton_ShapeCursor_clicked)
        self.radioButton_ShapeSpot.clicked.connect(self.camera.radioButton_ShapeSpot_Clicked)
        self.radioButton_ShapeLine.clicked.connect(self.camera.radioButton_ShapeLine_Clicked)
        self.radioButton_ShapeRectangle.clicked.connect(self.camera.radioButton_ShapeRectangle_Clicked)
        self.radioButton_ShapeEllipse.clicked.connect(self.camera.radioButton_ShapeEllipse_Clicked)
        self.pushButton_RemoveAllRoi.clicked.connect(self.camera.pushButton_RemoveAllRoi_Clicked)
        self.pushButton_AddRoiItem.clicked.connect(self.camera.pushButton_AddRoiItem_Clicked)
        self.pushButton_RemoveRoiItem.clicked.connect(self.camera.pushButton_RemoveRoiItem_Clicked)
        self.pushButton_GetProductInformation.clicked.connect(self.camera_ctrl.pushButton_GetProductInformation_Clicked)
        self.pushButton_GetSensorInformation.clicked.connect(self.camera_ctrl.pushButton_GetSensorInformation_Clicked)
        self.pushButton_SoftwareUpdateFileBrowse.clicked.connect(self.camera_ctrl.pushButton_SoftwareUpdateFileBrowse_Clicked)
        self.pushButton_StartSoftwareUpdate.clicked.connect(self.camera_ctrl.pushButton_StartSoftwareUpdate_Clicked)
        self.pushButton_GetNetworkConfiguration.clicked.connect(self.camera_ctrl.pushButton_GetNetworkConfiguration_Clicked)
        self.pushButton_SetNetworkConfiguration.clicked.connect(self.camera_ctrl.pushButton_SetNetworkConfiguration_Clicked)
        self.pushButton_SetDefaultNetworkConfiguration.clicked.connect(self.camera_ctrl.pushButton_SetDefaultNetworkConfiguration_Clicked)
        self.pushButton_SystemReboot.clicked.connect(self.camera_ctrl.pushButton_SystemReboot_Clicked)
        self.pushButton_GetFlatFieldCorrection.clicked.connect(self.sensor_ctrl.pushButton_GetFlatFieldCorrection_Clicked)
        self.pushButton_SetFlatFieldCorrection.clicked.connect(self.sensor_ctrl.pushButton_SetFlatFieldCorrection_Clicked)
        self.pushButton_RunFlatFieldCorrection.clicked.connect(self.sensor_ctrl.pushButton_RunFlatFieldCorrection_Clicked)
        self.pushButton_GetFluexParams.clicked.connect(self.sensor_ctrl.pushButton_GetFluexParams_Clicked)
        self.pushButton_SetFluexParams.clicked.connect(self.sensor_ctrl.pushButton_SetFluexParams_Clicked)
        self.pushButton_GetFFCParams.clicked.connect(self.sensor_ctrl.pushButton_GetFFCParams_Clicked)
        self.pushButton_SetFFCParams.clicked.connect(self.sensor_ctrl.pushButton_SetFFCParams_Clicked)
        self.pushButton_StoreUserSensorConfig.clicked.connect(self.sensor_ctrl.pushButton_StoreUserSensorConfig_Clicked)
        self.pushButton_RestoreDefaultSensorConfig.clicked.connect(self.sensor_ctrl.pushButton_RestoreDefaultSensorConfig_Clicked)
        self.pushButton_GetFluxParameters_160E.clicked.connect(self.sensor_ctrl.pushButton_GetFluxParameters_160E_Clicked)
        self.pushButton_SetFluxParameters_160E.clicked.connect(self.sensor_ctrl.pushButton_SetFluxParameters_160E_Clicked)
        self.pushButton_GetGainModeState_160E.clicked.connect(self.sensor_ctrl.pushButton_GetGainModeState_160E_Clicked)
        self.pushButton_SetGainModeState_160E.clicked.connect(self.sensor_ctrl.pushButton_SetGainModeState_160E_Clicked)
        self.pushButton_GetFlatFieldCorrectionMode_160E.clicked.connect(self.sensor_ctrl.pushButton_GetFlatFieldCorrectionMode_160E_Clicked)
        self.pushButton_SetFlatFieldCorrectionMode_160E.clicked.connect(self.sensor_ctrl.pushButton_SetFlatFieldCorrectionMode_160E_Clicked)
        self.pushButton_RunFlatFieldCorrection_160E.clicked.connect(self.sensor_ctrl.pushButton_RunFlatFieldCorrection_160E_Clicked)
        self.pushButton_RestoreDefaultFluxParameters_160E.clicked.connect(self.sensor_ctrl.pushButton_RestoreDefaultFluxParameters_160E_Clicked)
        self.pushButton_GetGainModeState.clicked.connect(self.sensor_ctrl.pushButton_GetGainModeState_Clicked)
        self.pushButton_SetGainModeState.clicked.connect(self.sensor_ctrl.pushButton_SetGainModeState_Clicked)
        
        self.LocalCamList=[]
        self.RemoteCamList=[]
        
        self.tabWidget_Control.setVisible(False)
        self.stackedWidget_SensorControl.setVisible(False)
        self.groupBox.setEnabled(False)
        self.groupBox_SenserInformation.setEnabled(False)
        self.groupBox_SoftwareUpdate.setEnabled(False)
        self.groupBox_NetworkConfiguration.setEnabled(False)
        self.comboBox_ColorMap.setEnabled(False)
        self.comboBox_TemperatureUnit.setEnabled(False)
    
        self.radioButton_ShapeCursor.setEnabled(False)
        self.radioButton_ShapeSpot.setEnabled(False)
        self.radioButton_ShapeLine.setEnabled(False)
        self.radioButton_ShapeRectangle.setEnabled(False)
        self.radioButton_ShapeEllipse.setEnabled(False)
        self.pushButton_RemoveAllRoi.setEnabled(False)
        self.comboBox_ColorMap.setEnabled(False)
        self.checkBox_NoiseFiltering.setEnabled(False)
        self.comboBox_TemperatureUnit.setEnabled(False)
        
        self.label_Preview.installEventFilter(self)
        self.label_Preview.setAlignment(Qt.AlignCenter)

        self.stackedWidget_SensorControl.setCurrentIndex(0)

        if self.tabWidget_ConnectCamera.currentIndex() == 0:
            self.camera.scan_local_camera_list()
        else:
            self.camera.scan_remote_camera_list()
            
    def eventFilter(self, obj, event):
        if obj == self.label_Preview:
            if event.type() == QEvent.MouseButtonPress:
                if event.button() == Qt.LeftButton:
                    self.camera.mouse_down(event.pos())

            elif event.type() == QEvent.MouseButtonRelease:
                if event.button() == Qt.LeftButton:
                    self.camera.mouse_up(event.pos())

            elif event.type() == QEvent.MouseMove:
                self.camera.mouse_move(event.pos())

        if event.type() == QEvent.Resize:
            width = self.label_Preview.width()
            height = self.label_Preview.height()

            if width * 3 > height * 4:
                labelHeight = height
                labelWidth = int(labelHeight * 4 / 3)
            else:
                labelWidth = width
                labelHeight = int(labelWidth * 3 / 4)

            self.camera.preview_width = labelWidth
            self.camera.preview_height = labelHeight
            
            maginX = int(250 + ((self.centralwidget.width() - 250 - 340) / 2) - (labelWidth / 2))
            maginY = int(((self.centralwidget.height() - 380) / 2) - (labelHeight / 2))

            if maginX < 250:
                maginX = 250
            if maginY < 0:
                maginY = 0
                
            self.label_Preview.setGeometry(
                maginX + int((width - labelWidth) / 2),
                maginY + int((height - labelHeight) / 2),
                labelWidth,
                labelHeight
            )
        return False
    
    def closeEvent(self, event):
        self.camera.disconnect_camera()

        
if __name__ == '__main__':
    import sys
    app = QApplication(sys.argv)
    main_window = MainWindow()
    main_window.show()
    sys.exit(app.exec_())