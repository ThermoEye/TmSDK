#################################################################
# Company: Thermoeye, Inc
# Project: TmSDK
# File: Camera.py
# Creation date: 2024-08-19
# Version: 1.0.0
#
# Description: This file contains the following implementations:
# - Search and connect local/remote cameras
# - Camera video preview
# - ROI management
# - Temperature measurement
#
# History: 2024-08-19: Initial version.
#
#################################################################
from ast import Delete
import os, sys
import ctypes
import time
from PyQt5.QtCore import *
from PyQt5.QtWidgets import *
from PyQt5 import uic
from PyQt5.QtGui import *
from PyQt5.QtCore import QThreadPool
from concurrent.futures import ThreadPoolExecutor

if sys.platform.startswith("linux"):
	sys.path.append("../../Modules/Shared/Managed/Python/TmCore")
elif os.name == "nt":
    sys.path.append(sys.path[0] + "\\..\\..\\" + "Modules\\Shared\\Managed\\Python")
    sys.path.append(sys.path[0] + "\\..\\..\\" + "Modules\\Shared\\Managed\\Python\\TmCore")

from TmCore import *
from TmCore.TmTypes import *
from TmCore.TmRoi import *

class ConnectionEventBridge(QObject):
    disconnected = pyqtSignal()
    reconnected = pyqtSignal(bool)
    reconnect_failed = pyqtSignal()

class Camera:
    def __init__(self, main_window):
        self.main_window = main_window
        self.roi_manager = TmRoiManager()
        self.tmCamera = TmCamera()
        self.frame_callback_context = FrameCallbackContext(self, tag="trigger-preview")
        self.local_camera_list=[]
        self.remote_camera_list=[]
        self.preview_width = self.main_window.label_Preview.width()
        self.preview_height = self.main_window.label_Preview.height()
        self.drawing = False
        self.worker = FrameWorker(self)
        self.reconnecting_camera = False
        self.reconnect_local_camera = None
        self.reconnect_remote_camera = None
        self.reconnect_executor = ThreadPoolExecutor(max_workers=1)
        self.connection_event_bridge = ConnectionEventBridge()
        self.connection_event_bridge.disconnected.connect(self.handle_connection_disconnected)
        self.connection_event_bridge.reconnected.connect(self.handle_camera_reconnected)
        self.connection_event_bridge.reconnect_failed.connect(self.handle_camera_reconnect_failed)
        self.main_window.radioButton_ShapeCursor.setChecked(True)
        
    def scan_local_camera_list(self):
        self.main_window.lineEdit_LocalCameraName.setText("")
        self.main_window.lineEdit_LocalCameraPort.setText("")
        self.main_window.listWidget_LocalCameraList.clear()
        self.main_window.comboBox_LocalCameraVideoFormat.clear()
        for cam in self.local_camera_list:
            del cam
        self.local_camera_list.clear()
        local_cameras = self.tmCamera.get_local_camera_list()
        for local_camera in local_cameras:
            if local_camera.name.startswith("TMC"):
                item = local_camera.name + '-' + local_camera.com_port
                self.main_window.listWidget_LocalCameraList.addItem(item)
                self.local_camera_list.append(local_camera)

        if self.local_camera_list:
            self.main_window.listWidget_LocalCameraList.setCurrentRow(0)
            camInfo=self.local_camera_list[0]
            self.main_window.lineEdit_LocalCameraName.setText(camInfo.name)
            self.main_window.lineEdit_LocalCameraPort.setText(camInfo.com_port)
            for j in range(len(camInfo.media_info_list)):
                self.main_window.comboBox_RemoteCameraVideoFormat.addItem(
                    camInfo.media_info_list[j].format 
                    + " : " + str(camInfo.media_info_list[j].width) 
                    + "x" + str(camInfo.media_info_list[j].height) 
                    + "@" + str(camInfo.media_info_list[j].frame_rate) 
                    + "-" + str(camInfo.media_info_list[j].bit_per_pixel) + "bpp")

    def scan_remote_camera_list(self):
        self.main_window.lineEdit_RemoteCameraName.setText("")
        self.main_window.lineEdit_RemoteCameraPartNumber.setText("")
        self.main_window.lineEdit_RemoteCameraSerial.setText("")
        self.main_window.lineEdit_RemoteCameraMac.setText("")
        self.main_window.lineEdit_RemoteCameraIp.setText("")
        self.main_window.lineEdit_RemoteCameraAdapterIp.setText("")
        self.main_window.listWidget_RemoteCameraList.clear()
        self.main_window.comboBox_RemoteCameraVideoFormat.clear()
        for cam in self.remote_camera_list:
            del cam
        self.remote_camera_list.clear()    
        
        remote_cameras = self.tmCamera.get_remote_camera_list()
        for remote_camera in remote_cameras:
            if remote_camera.name.startswith("TMC"):
                item = remote_camera.name + '-' + remote_camera.ip
                self.main_window.listWidget_RemoteCameraList.addItem(item)
                self.remote_camera_list.append(remote_camera)

            
        if self.remote_camera_list:
            camInfo = self.remote_camera_list[0]    
            self.main_window.lineEdit_RemoteCameraName.setText(camInfo.name)
            self.main_window.lineEdit_RemoteCameraPartNumber.setText(camInfo.part_number)
            self.main_window.lineEdit_RemoteCameraSerial.setText(camInfo.serial_number)
            self.main_window.lineEdit_RemoteCameraMac.setText(camInfo.mac)
            self.main_window.lineEdit_RemoteCameraIp.setText(camInfo.ip)
            self.main_window.lineEdit_RemoteCameraAdapterIp.setText(camInfo.adapter_ip)
            for j in range(len(camInfo.media_info_list)):
                self.main_window.comboBox_RemoteCameraVideoFormat.addItem(
                    camInfo.media_info_list[j].format 
                    + " : " + str(camInfo.media_info_list[j].width) 
                    + "x" + str(camInfo.media_info_list[j].height) 
                    + "@" + str(camInfo.media_info_list[j].frame_rate) 
                    + "-" + str(camInfo.media_info_list[j].bit_per_pixel) + "bpp")
            
    # Add the created roi object to the ui
    def update_roi_list_items(self):
        self.main_window.comboBox_ListRoi.clear();

        for index in range(self.roi_manager.get_roi_item_count()):
            self.main_window.comboBox_ListRoi.addItem(f"ROI{index}")

        if self.roi_manager.get_roi_item_count() > 0:
            self.main_window.comboBox_ListRoi.setCurrentIndex(0);
        else:
            self.main_window.comboBox_ListRoi.setCurrentIndex(-1);

    def disconnect_camera(self, clear_reconnect_state=True):
        self.pause_capture_thread = False
        if self.tmCamera is not None:
            try:
                self.tmCamera.end_acquisition()
                self.tmCamera.unregister_event_handler()
            except Exception:
                pass
        if self.worker.isRunning():
            self.worker.stop()
            self.worker.wait()
        try:
            self.roi_manager.roi_clear()
            self.tmCamera.unregister_connection_event_handler()
            self.tmCamera.close()
        except Exception as e:
            print(f'Error while closing camera: {str(e)}')

        if clear_reconnect_state:
            self.reconnecting_camera = False
            self.reconnect_local_camera = None
            self.reconnect_remote_camera = None
        
        self.main_window.comboBox_ColorMap.setCurrentIndex(0)
        self.main_window.comboBox_TemperatureUnit.setCurrentIndex(0)
        # Hide widgets inside tabSensorControl
        self.main_window.stackedWidget_SensorControl.setVisible(False)
        self.main_window.groupBox_ProductInformation.setEnabled(False)
        self.main_window.groupBox_SensorInformation.setEnabled(False)
        self.main_window.groupBox_SoftwareUpdate.setEnabled(False)
        self.main_window.comboBox_ColorMap.setEnabled(False)
        self.main_window.comboBox_TemperatureUnit.setEnabled(False)
        
        self.main_window.radioButton_ShapeCursor.setEnabled(False)
        self.main_window.radioButton_ShapeSpot.setEnabled(False)
        self.main_window.radioButton_ShapeLine.setEnabled(False)
        self.main_window.radioButton_ShapeRectangle.setEnabled(False)
        self.main_window.radioButton_ShapeEllipse.setEnabled(False)
        self.main_window.pushButton_RemoveAllRoi.setEnabled(False)
        self.main_window.comboBox_ColorMap.setEnabled(False)
        self.main_window.checkBox_NoiseFiltering.setEnabled(False)
        self.main_window.comboBox_TemperatureUnit.setEnabled(False)

        self.main_window.radioButton_CallbackModeOn.setEnabled(False)
        self.main_window.radioButton_CallbackModeOff.setEnabled(False)
        self.main_window.radioButton_CallbackModeOff.setChecked(True)

        self.main_window.label_ProductModelName.setText("")
        self.main_window.label_ProductPartNumber.setText("")
        self.main_window.label_ProductSerialNumber.setText("")
        self.main_window.label_HardwareVersion.setText("")
        self.main_window.label_BootloaderVersion.setText("")
        self.main_window.label_FirmwareVersion.setText("")
        self.main_window.label_SensorModelName.setText("")
        self.main_window.label_SensorSerialNumber.setText("")
        self.main_window.label_SensorUptime.setText("")
        self.main_window.label_VendorName.setText("")
        self.main_window.label_ProductName.setText("")
        self.main_window.label_SoftwareVersion.setText("")
        self.main_window.label_BuildTime.setText("")
        self.main_window.label_BinarySize.setText("")
        self.main_window.label_SoftwareUpdateStatus.setText("")
        self.main_window.lineEdit_SoftwareUpdateFilePath.setText("")
        self.main_window.lineEdit_MACAddress.setText("")
        self.main_window.comboBox_IPAssignment.setCurrentIndex(0)
        self.main_window.lineEdit_IPAddress.setText("")
        self.main_window.lineEdit_Netmask.setText("")
        self.main_window.lineEdit_Gateway.setText("")
        self.main_window.lineEdit_MainDNSServer.setText("")
        self.main_window.lineEdit_SubDNSServer.setText("")
        # Clear last preview image so that label_Preview does not keep the last frame
        label = self.main_window.label_Preview
        if label is not None:
            # 먼저 비어 있는 pixmap을 설정
            label.setPixmap(QPixmap())
            label.repaint()
            # 이벤트 큐에 남아 있을 수 있는 setPixmap 호출들을 처리
            QApplication.processEvents()
            # 최종적으로 clear 한 번 더 호출
            label.clear()
            label.repaint()

    # Handles the mouse release event by updating ROI and UI elements.
    # Parameters:
    #  - point: The QPoint object representing the coordinates where the mouse button was released.
    def mouse_up(self, point: QPoint):
        pt = Point(x=point.x(), y=point.y())
        
        if self.roi_manager.mouse_up(pt):
            self.main_window.radioButton_ShapeCursor.setChecked(True)
            self.main_window.radioButton_ShapeSpot.setChecked(False)
            self.main_window.radioButton_ShapeLine.setChecked(False)
            self.main_window.radioButton_ShapeRectangle.setChecked(False)
            self.main_window.radioButton_ShapeEllipse.setChecked(False)
            self.update_roi_list_items()
            self.drawing = False

    # Handles the mouse press event by starting the drawing process.
    # Parameters:
    #   point: The QPoint object representing the coordinates where the mouse button was pressed.
    def mouse_down(self, point: QPoint):
        pt = Point(x=point.x(), y=point.y())
        
        self.roi_manager.mouse_down(pt)
        self.preview_start = point
        self.preview_end = point
        self.drawing = True

    # Handles the mouse movement event by updating the drawing preview.
    # Parameters:
    #  point: The QPoint object representing the current coordinates of the mouse during movement.
    def mouse_move(self, point: QPoint):
        pt = Point(x=point.x(), y=point.y())
        
        if self.roi_manager.mouse_move(pt):
            self.preview_end = point

    def apply_connected_camera_ui(self, camera_name, is_local):
        if (camera_name == "ThermoCam256E" or camera_name == "TMC256E" or camera_name == "TMC256B" or camera_name == "TMC256I"
            or camera_name == "TMC160IE" or camera_name == "TMC160IB" or camera_name == "TMC160I"):
            self.main_window.tabWidget_Control.setCurrentIndex(0)
            self.main_window.stackedWidget_SensorControl.setCurrentIndex(0)
        elif (camera_name == "ThermoCam160E" or camera_name == "TMC160E" or camera_name == "TMC160B" or camera_name == "TMC160F"
              or camera_name == "TMC80E" or camera_name == "TMC80B" or camera_name == "TMC80F"):
            self.main_window.tabWidget_Control.setCurrentIndex(0)
            self.main_window.stackedWidget_SensorControl.setCurrentIndex(1)
        elif (camera_name == "TMC256GE" or camera_name == "TMC256GB" or camera_name == "TMC256G"
              or camera_name == "TMC384GE" or camera_name == "TMC384GB" or camera_name == "TMC384G"):
            self.main_window.tabWidget_Control.setCurrentIndex(0)
            self.main_window.stackedWidget_SensorControl.setCurrentIndex(2)

        self.tmCamera.set_temp_unit(TempUnit.CELSIUS)
        self.main_window.stackedWidget_SensorControl.setVisible(True)
        self.main_window.groupBox_ProductInformation.setEnabled(True)
        self.main_window.groupBox_SensorInformation.setEnabled(True)
        self.main_window.groupBox_SoftwareUpdate.setEnabled(True)
        self.main_window.comboBox_ColorMap.setEnabled(True)
        self.main_window.comboBox_TemperatureUnit.setEnabled(True)
        self.main_window.comboBox_ColorMap.setCurrentIndex(ColormapTypes.Inferno + 1)
        self.main_window.comboBox_TemperatureUnit.setCurrentIndex(TempUnit.CELSIUS)

        self.main_window.radioButton_ShapeCursor.setChecked(True)
        self.main_window.radioButton_ShapeCursor.setEnabled(True)
        self.main_window.radioButton_ShapeSpot.setEnabled(True)
        self.main_window.radioButton_ShapeLine.setEnabled(True)
        self.main_window.radioButton_ShapeRectangle.setEnabled(True)
        self.main_window.radioButton_ShapeEllipse.setEnabled(True)
        self.main_window.pushButton_RemoveAllRoi.setEnabled(True)
        self.main_window.checkBox_NoiseFiltering.setEnabled(True)

        self.main_window.pushButton_GetNetworkConfiguration.setEnabled(not is_local)
        self.main_window.comboBox_IPAssignment.setEnabled(not is_local)
        self.main_window.lineEdit_Netmask.setEnabled(not is_local)
        self.main_window.lineEdit_IPAddress.setEnabled(not is_local)
        self.main_window.lineEdit_Gateway.setEnabled(not is_local)
        self.main_window.lineEdit_MainDNSServer.setEnabled(not is_local)
        self.main_window.lineEdit_SubDNSServer.setEnabled(not is_local)
        self.main_window.pushButton_SetDefaultNetworkConfiguration.setEnabled(not is_local)
        self.main_window.pushButton_SystemReboot.setEnabled(not is_local)

    def register_connection_handler(self, local_camera=None, remote_camera=None):
        self.reconnect_local_camera = local_camera
        self.reconnect_remote_camera = remote_camera
        self.tmCamera.register_connection_event_handler(self.on_camera_connection_changed)

    def on_camera_connection_changed(self, connected):
        print(f"Camera connection changed. Connected: {connected}, Reconnecting: {self.reconnecting_camera}")
        if connected or self.reconnecting_camera:
            return

        self.reconnecting_camera = True
        self.connection_event_bridge.disconnected.emit()

    def handle_connection_disconnected(self):
        local_camera = self.reconnect_local_camera
        remote_camera = self.reconnect_remote_camera

        # Delay Close/Open until after the native callback stack has returned.
        QTimer.singleShot(1, lambda: self.start_reconnect(local_camera, remote_camera))

    def start_reconnect(self, local_camera, remote_camera):
        self.disconnect_camera(clear_reconnect_state=False)
        self.reconnecting_camera = True
        self.reconnect_local_camera = local_camera
        self.reconnect_remote_camera = remote_camera
        self.main_window.pushButton_LocalCameraConnect.setText("Connect")
        self.main_window.pushButton_RemoteCameraConnect.setText("Connect")
        self.reconnect_executor.submit(self.reconnect_camera, local_camera, remote_camera)

    def reconnect_camera(self, local_camera, remote_camera):
        for attempt in range(20):
            if not self.reconnecting_camera:
                return

            try:
                print(f"Attempting to reconnect camera. Attempt {attempt}")
                if local_camera is not None:
                    fmt = local_camera.media_info_list[local_camera.media_info_index].format
                    ret = self.tmCamera.open_local_camera(local_camera.name, local_camera.com_port, local_camera.index, fmt)
                    is_local = True
                elif remote_camera is not None:
                    fmt = remote_camera.media_info_list[remote_camera.media_info_index].format
                    ret = self.tmCamera.open_remote_camera(remote_camera.name, remote_camera.serial_number, remote_camera.mac, remote_camera.ip, fmt)
                    is_local = False
                else:
                    return

                if ret:
                    self.reconnecting_camera = False
                    self.register_connection_handler(local_camera, remote_camera)
                    self.connection_event_bridge.reconnected.emit(is_local)
                    return
            except Exception as e:
                print(f"Reconnect failed: {str(e)}")

            QThread.msleep(1000)

        self.connection_event_bridge.reconnect_failed.emit()

    def handle_camera_reconnected(self, is_local):
        if is_local and self.reconnect_local_camera is not None:
            self.apply_connected_camera_ui(self.reconnect_local_camera.name, True)
        elif not is_local and self.reconnect_remote_camera is not None:
            self.apply_connected_camera_ui(self.reconnect_remote_camera.name, False)

        self.worker.start()
        if is_local:
            self.main_window.pushButton_LocalCameraConnect.setText("Disconnect")
            self.main_window.pushButton_RemoteCameraConnect.setText("Connect")
        else:
            self.main_window.pushButton_LocalCameraConnect.setText("Connect")
            self.main_window.pushButton_RemoteCameraConnect.setText("Disconnect")

    def handle_camera_reconnect_failed(self):
        self.reconnecting_camera = False
        self.reconnect_local_camera = None
        self.reconnect_remote_camera = None
        self.main_window.pushButton_LocalCameraConnect.setText("Connect")
        self.main_window.pushButton_RemoteCameraConnect.setText("Connect")
        QMessageBox.warning(self.main_window, "Reconnect", "Failed to reconnect camera.")
        
# slot
    def pushButton_LocalCameraScan_Clicked(self):
        self.scan_local_camera_list()
    
    def pushButton_RemoteCameraScan_Clicked(self):
        self.scan_remote_camera_list()  
    
    def pushButton_LocalCameraConnect_Clicked(self):
        if (self.main_window.pushButton_LocalCameraConnect.text() == "Connect"):
            try:
                if self.tmCamera is None:
                    self.tmCamera = TmCamera()
                row = self.main_window.listWidget_LocalCameraList.currentRow()
                if row < 0 or row >= len(self.local_camera_list):
                    print('No camera selected')
                    return
                # ret = self.tmCamera.open_local_camera(self.local_camera_list[row].name
                #                                       , self.local_camera_list[row].com_port
                #                                       , self.local_camera_list[row].index
                #                                       )        
                ret = self.tmCamera.open_local_camera(self.local_camera_list[row].name
                                                      , self.local_camera_list[row].com_port
                                                      , self.local_camera_list[row].index
                                                      , self.local_camera_list[row].media_info_list[self.local_camera_list[row].media_info_index].format)
        
                if ret:
                    self.register_connection_handler(local_camera=self.local_camera_list[row])
                    self.main_window.pushButton_LocalCameraConnect.setText("Disconnect")

                    self.worker.start()
                    val = self.tmCamera.get_temp_unit()
                    if (self.local_camera_list[row].name == "TMC256E" or self.local_camera_list[row].name == "TMC256B" or self.local_camera_list[row].name == "TMC256I"
                        or self.local_camera_list[row].name == "TMC160IE" or self.local_camera_list[row].name == "TMC160IB" or self.local_camera_list[row].name == "TMC160I"):
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(0)
                    elif (self.local_camera_list[row].name == "TMC160E" or self.local_camera_list[row].name == "TMC160B" or self.local_camera_list[row].name == "TMC160F"
                          or self.local_camera_list[row].name == "TMC80E" or self.local_camera_list[row].name == "TMC80B" or self.local_camera_list[row].name == "TMC80F"):
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(1)
                    elif (self.local_camera_list[row].name == "TMC256GE" or self.local_camera_list[row].name == "TMC256GB" or self.local_camera_list[row].name == "TMC256G"
                        or self.local_camera_list[row].name == "TMC384GE" or self.local_camera_list[row].name == "TMC384GB" or self.local_camera_list[row].name == "TMC384G"):
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(2)

                    self.tmCamera.set_temp_unit(TempUnit.CELSIUS)
                    val = self.tmCamera.get_temp_unit

                    # Show widgets inside tabSensorControl
                    self.main_window.stackedWidget_SensorControl.setVisible(True)
                    self.main_window.groupBox_ProductInformation.setEnabled(True)
                    self.main_window.groupBox_SensorInformation.setEnabled(True)
                    self.main_window.groupBox_SoftwareUpdate.setEnabled(True)
                    self.main_window.comboBox_ColorMap.setEnabled(True)
                    self.main_window.comboBox_TemperatureUnit.setEnabled(True)
                    name = self.tmCamera.tmControl.get_product_model_name()
                    self.main_window.comboBox_ColorMap.setCurrentIndex(ColormapTypes.Inferno + 1)
                    self.main_window.comboBox_TemperatureUnit.setCurrentIndex(TempUnit.CELSIUS)
                    
                    self.main_window.radioButton_ShapeCursor.setChecked(True)
                    self.main_window.radioButton_ShapeCursor.setEnabled(True)
                    self.main_window.radioButton_ShapeSpot.setEnabled(True)
                    self.main_window.radioButton_ShapeLine.setEnabled(True)
                    self.main_window.radioButton_ShapeRectangle.setEnabled(True)
                    self.main_window.radioButton_ShapeEllipse.setEnabled(True)
                    self.main_window.pushButton_RemoveAllRoi.setEnabled(True)
                    self.main_window.comboBox_ColorMap.setEnabled(True)
                    self.main_window.checkBox_NoiseFiltering.setEnabled(True)
                    self.main_window.comboBox_TemperatureUnit.setEnabled(True)

                    self.main_window.pushButton_SetDefaultNetworkConfiguration.setEnabled(False)
                    self.main_window.pushButton_SystemReboot.setEnabled(False)

                    self.main_window.radioButton_CallbackModeOn.setEnabled(True)
                    self.main_window.radioButton_CallbackModeOff.setEnabled(True)
                    self.main_window.radioButton_CallbackModeOn.setChecked(False)
                    self.main_window.radioButton_CallbackModeOff.setChecked(True)
        
            except Exception as e:
                print(f'Error while opening camera: {str(e)}')
        else:
            self.disconnect_camera()
            self.main_window.pushButton_LocalCameraConnect.setText("Connect")

    def pushButton_RemoteCameraConnect_Clicked(self):
        if (self.main_window.pushButton_RemoteCameraConnect.text() == "Connect"):
            try:
                if self.tmCamera is None:
                    self.tmCamera = TmCamera()
                
                if (self.main_window.lineEdit_RemoteCameraName.text() == ""):
                    print('No camera selected')
                    return
                
                row = self.main_window.listWidget_RemoteCameraList.currentRow()
                
                # ret = self.tmCamera.open_remote_camera(self.main_window.lineEdit_RemoteCameraName.text()
                #                                         , self.main_window.lineEdit_RemoteCameraSerial.text()
                #                                         , self.main_window.lineEdit_RemoteCameraMac.text()
                #                                         , self.main_window.lineEdit_RemoteCameraIp.text()
                #                                         )
                ret = self.tmCamera.open_remote_camera(self.main_window.lineEdit_RemoteCameraName.text()
                                                        , self.main_window.lineEdit_RemoteCameraSerial.text()
                                                        , self.main_window.lineEdit_RemoteCameraMac.text()
                                                        , self.main_window.lineEdit_RemoteCameraIp.text()
                                                        , self.remote_camera_list[row].media_info_list[self.remote_camera_list[row].media_info_index].format)
                if ret:
                    self.register_connection_handler(remote_camera=self.remote_camera_list[row])
                    self.main_window.pushButton_RemoteCameraConnect.setText("Disconnect")
                    self.worker.start()
                    if (self.remote_camera_list[row].name == "ThermoCam256E"
                        or self.remote_camera_list[row].name == "TMC256E" or self.remote_camera_list[row].name == "TMC256B" or self.remote_camera_list[row].name == "TMC256I"
                        or self.remote_camera_list[row].name == "TMC160IE" or self.remote_camera_list[row].name == "TMC160IB" or self.remote_camera_list[row].name == "TMC160I"):
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(0)
                    elif (self.remote_camera_list[row].name == "ThermoCam160E"
                          or self.remote_camera_list[row].name == "TMC160E" or self.remote_camera_list[row].name == "TMC160B" or self.remote_camera_list[row].name == "TMC160F"
                          or self.remote_camera_list[row].name == "TMC80E" or self.remote_camera_list[row].name == "TMC80B" or self.remote_camera_list[row].name == "TMC80F"):
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(1)
                    elif (self.remote_camera_list[row].name == "TMC256GE" or self.remote_camera_list[row].name == "TMC256GB" or self.remote_camera_list[row].name == "TMC256G"
                        or self.remote_camera_list[row].name == "TMC384GE" or self.remote_camera_list[row].name == "TMC384GB" or self.remote_camera_list[row].name == "TMC384G"):
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(2)

                    # Show widgets inside tabSensorControl
                    self.main_window.stackedWidget_SensorControl.setVisible(True)
                    self.main_window.groupBox_ProductInformation.setEnabled(True)
                    self.main_window.groupBox_SensorInformation.setEnabled(True)
                    self.main_window.groupBox_SoftwareUpdate.setEnabled(True)
                    self.main_window.comboBox_ColorMap.setEnabled(True)
                    self.main_window.comboBox_TemperatureUnit.setEnabled(True)
                    self.main_window.pushButton_GetNetworkConfiguration.setEnabled(True)
                    self.main_window.comboBox_IPAssignment.setEnabled(True)
                    self.main_window.lineEdit_Netmask.setEnabled(True)
                    self.main_window.lineEdit_IPAddress.setEnabled(True)
                    self.main_window.lineEdit_Gateway.setEnabled(True)
                    self.main_window.lineEdit_MainDNSServer.setEnabled(True)
                    self.main_window.lineEdit_SubDNSServer.setEnabled(True)
                    self.main_window.pushButton_SetDefaultNetworkConfiguration.setEnabled(True)
                    self.main_window.pushButton_SystemReboot.setEnabled(True)
                    self.main_window.comboBox_ColorMap.setCurrentIndex(ColormapTypes.Inferno + 1)
                    self.main_window.comboBox_TemperatureUnit.setCurrentIndex(TempUnit.CELSIUS)

                    self.main_window.radioButton_ShapeCursor.setChecked(True)
                    self.main_window.radioButton_ShapeCursor.setEnabled(True)
                    self.main_window.radioButton_ShapeSpot.setEnabled(True)
                    self.main_window.radioButton_ShapeLine.setEnabled(True)
                    self.main_window.radioButton_ShapeRectangle.setEnabled(True)
                    self.main_window.radioButton_ShapeEllipse.setEnabled(True)
                    self.main_window.pushButton_RemoveAllRoi.setEnabled(True)
                    self.main_window.comboBox_ColorMap.setEnabled(True)
                    self.main_window.checkBox_NoiseFiltering.setEnabled(True)
                    self.main_window.comboBox_TemperatureUnit.setEnabled(True)
            except Exception as e:
                print(f'Error while opening camera: {str(e)}')  
        else:       
                self.disconnect_camera()
                self.main_window.pushButton_RemoteCameraConnect.setText("Connect")

    def tabWidget_Control_CurrentChanged(self, tab_index):
        """
        Slot function for handling the "tabWidget_Control" tab change event.
        Prevents tab switching when camera is not connected.
        """
        # If camera is not connected, prevent tab change by reverting to previous index
        if self.tmCamera is None:
            # Block signals to prevent recursive calls
            self.main_window.tabWidget_Control.blockSignals(True)
            self.main_window.tabWidget_Control.setCurrentIndex(0)  # Always keep on first tab (Sensor Control)
            self.main_window.tabWidget_Control.blockSignals(False)

    def tabWidget_ConnectCamera_CurrentChanged(self, tab_index):
        if self.main_window.pushButton_LocalCameraConnect.text() == "Disconnect":
            self.main_window.tabWidget_ConnectCamera.setCurrentIndex(0)
            return
        elif self.main_window.pushButton_RemoteCameraConnect.text() == "Disconnect":
            self.main_window.tabWidget_ConnectCamera.setCurrentIndex(1)
            return
        if tab_index == 0:
            self.scan_local_camera_list()
        elif tab_index == 1:
            self.scan_remote_camera_list()

    def listWidget_LocalCameraList_CurrentRowChanged(self, row):
        if row < 0:
            return
        cam_info = self.local_camera_list[row]
        self.main_window.lineEdit_LocalCameraName.setText(cam_info.name)
        self.main_window.lineEdit_LocalCameraPort.setText(cam_info.com_port)
        self.main_window.comboBox_LocalCameraVideoFormat.clear()
        for j in range(len(cam_info.media_info_list)):
            self.main_window.comboBox_LocalCameraVideoFormat.addItem(
                cam_info.media_info_list[j].format 
                + " : " + str(cam_info.media_info_list[j].width) 
                + "x" + str(cam_info.media_info_list[j].height) 
                + "@" + str(cam_info.media_info_list[j].frame_rate) 
                + "-" + str(cam_info.media_info_list[j].bit_per_pixel) + "bpp")
    
    def listWidget_RemoteCameraList_CurrentRowChanged(self, row):
        if row < 0:
            return
        cam_info = self.remote_camera_list[row]
        self.main_window.lineEdit_RemoteCameraName.setText(cam_info.name)
        self.main_window.lineEdit_RemoteCameraPartNumber.setText(cam_info.part_number)
        self.main_window.lineEdit_RemoteCameraSerial.setText(cam_info.serial_number)
        self.main_window.lineEdit_RemoteCameraMac.setText(cam_info.mac)
        self.main_window.lineEdit_RemoteCameraIp.setText(cam_info.ip)
        self.main_window.lineEdit_RemoteCameraAdapterIp.setText(cam_info.adapter_ip)
        self.main_window.comboBox_RemoteCameraVideoFormat.clear()
        for j in range(len(cam_info.media_info_list)):
            self.main_window.comboBox_RemoteCameraVideoFormat.addItem(
                cam_info.media_info_list[j].format 
                + " : " + str(cam_info.media_info_list[j].width) 
                + "x" + str(cam_info.media_info_list[j].height) 
                + "@" + str(cam_info.media_info_list[j].frame_rate) 
                + "-" + str(cam_info.media_info_list[j].bit_per_pixel) + "bpp")
 
    def comboBox_ColorMap_Changed(self, index):
        self.tmCamera.set_color_map(index - 1)
    
    def checkBox_NoiseFiltering_toggled(self, checked):
        ret = self.tmCamera.set_noise_filtering(checked)
    
    def comboBox_TemperatureUnit_Changed(self, temp_unit):
        self.tmCamera.set_temp_unit(temp_unit)
        
    def radioButton_ShapeCursor_clicked(self):
        self.roi_manager.set_selected_roi_type(RoiType.Hand)
        
    def radioButton_ShapeSpot_Clicked(self):
        self.roi_manager.set_selected_roi_type(RoiType.Spot)
        
    def radioButton_ShapeLine_Clicked(self):
        self.roi_manager.set_selected_roi_type(RoiType.Line)
        
    def radioButton_ShapeRectangle_Clicked(self):
        self.roi_manager.set_selected_roi_type(RoiType.Rect)
        
    def radioButton_ShapeEllipse_Clicked(self):
        self.roi_manager.set_selected_roi_type(RoiType.Ellipse)
        
    def pushButton_RemoveAllRoi_Clicked(self):
        self.roi_manager.roi_clear()
        
    def pushButton_AddRoiItem_Clicked(self):
        if self.main_window.radioButton_RoiSpot.isChecked():
            try:
                spotX = int(self.main_window.lineEdit_SpotX.text())
                spotY = int(self.main_window.lineEdit_SpotY.text())
            except ValueError:
                return
        
            self.roi_manager.add_item_xy(RoiType.Spot, spotX, spotY)
            self.update_roi_list_items()

        elif self.main_window.radioButton_RoiLine.isChecked():
            try:
                x1 = int(self.main_window.lineEdit_LineX1.text())
                y1 = int(self.main_window.lineEdit_LineY1.text())
                x2 = int(self.main_window.lineEdit_LineX2.text())
                y2 = int(self.main_window.lineEdit_LineY2.text())
            except ValueError:
                return
        
            self.roi_manager.add_item_xywh(RoiType.Line, x1, y1, x2, y2)
            self.update_roi_list_items()

        elif self.main_window.radioButton_RoiRectangle.isChecked():
            try:
                x = int(self.main_window.lineEdit_RectangleX.text())
                y = int(self.main_window.lineEdit_RectangleY.text())
                w = int(self.main_window.lineEdit_RectangleW.text())
                h = int(self.main_window.lineEdit_RectangleH.text())
            except ValueError:
                return
        
            self.roi_manager.add_item_xywh(RoiType.Rect, x, y, w, h)
            self.update_roi_list_items()

        elif self.main_window.radioButton_RoiEllipse.isChecked():
            try:
                x = int(self.main_window.lineEdit_EllipseX.text())
                y = int(self.main_window.lineEdit_EllipseY.text())
                w = int(self.main_window.lineEdit_EllipseW.text())
                h = int(self.main_window.lineEdit_EllipseH.text())
            except ValueError:
                return
        
            self.roi_manager.add_item_xywh(RoiType.Ellipse, x, y, w, h)
            self.update_roi_list_items()
        
    def pushButton_RemoveRoiItem_Clicked(self):
        roi_index = self.main_window.comboBox_ListRoi.currentIndex()
        if roi_index >= 0:
            if self.roi_manager.get_roi_item_count() == 0:
                return
            self.roi_manager.remove_at(roi_index)
            self.update_roi_list_items()

    def comboBox_LocalCameraVideoFormat_Changed(self, index):
        if len(self.local_camera_list) > 0:
            row = self.main_window.listWidget_LocalCameraList.currentRow()
            if row < 0:
                row = 0
            self.local_camera_list[row].media_info_index = index
        pass

    def comboBox_RemoteCameraVideoFormat_Changed(self, index):
        if len(self.remote_camera_list) > 0:
            row = self.main_window.listWidget_RemoteCameraList.currentRow()
            if row < 0:
                row = 0
            self.remote_camera_list[row].media_info_index = index
        pass

    def clear_roi_detail_inputs(self):
        self.main_window.lineEdit_SpotX.clear()
        self.main_window.lineEdit_SpotY.clear()
        self.main_window.lineEdit_LineX1.clear()
        self.main_window.lineEdit_LineY1.clear()
        self.main_window.lineEdit_LineX2.clear()
        self.main_window.lineEdit_LineY2.clear()
        self.main_window.lineEdit_RectangleX.clear()
        self.main_window.lineEdit_RectangleY.clear()
        self.main_window.lineEdit_RectangleW.clear()
        self.main_window.lineEdit_RectangleH.clear()
        self.main_window.lineEdit_EllipseX.clear()
        self.main_window.lineEdit_EllipseY.clear()
        self.main_window.lineEdit_EllipseW.clear()
        self.main_window.lineEdit_EllipseH.clear()
        self.main_window.lineEdit_RoiEmiss.clear()
        self.main_window.lineEdit_RoiAmbRefTemp.clear()

    def comboBox_ListRoi_CurrentIndexChanged(self, index):
        self.clear_roi_detail_inputs()

        if self.tmCamera is None or self.tmCamera.tmControl is None:
            return
        if index < 0:
            return

        roi_type = self.roi_manager.get_roi_type(index)
        if roi_type == RoiType.Spot:
            self.main_window.radioButton_RoiSpot.setChecked(True)
            spot_item = self.roi_manager.get_roi_spot_item(index)
            spot = spot_item.get_roi_spot()
            self.main_window.lineEdit_SpotX.setText(str(spot.x))
            self.main_window.lineEdit_SpotY.setText(str(spot.y))
        elif roi_type == RoiType.Line:
            self.main_window.radioButton_RoiLine.setChecked(True)
            line_item = self.roi_manager.get_roi_line_item(index)
            start, end = line_item.get_roi_line()
            self.main_window.lineEdit_LineX1.setText(str(start.x))
            self.main_window.lineEdit_LineY1.setText(str(start.y))
            self.main_window.lineEdit_LineX2.setText(str(end.x))
            self.main_window.lineEdit_LineY2.setText(str(end.y))
        elif roi_type == RoiType.Rect:
            self.main_window.radioButton_RoiRectangle.setChecked(True)
            rect_item = self.roi_manager.get_roi_rect_item(index)
            rect = rect_item.get_roi_rect()
            self.main_window.lineEdit_RectangleX.setText(str(rect.x))
            self.main_window.lineEdit_RectangleY.setText(str(rect.y))
            self.main_window.lineEdit_RectangleW.setText(str(rect.w))
            self.main_window.lineEdit_RectangleH.setText(str(rect.h))
        elif roi_type == RoiType.Ellipse:
            self.main_window.radioButton_RoiEllipse.setChecked(True)
            ellipse_item = self.roi_manager.get_roi_ellipse_item(index)
            ellipse = ellipse_item.get_roi_ellipse()
            self.main_window.lineEdit_EllipseX.setText(str(ellipse.x))
            self.main_window.lineEdit_EllipseY.setText(str(ellipse.y))
            self.main_window.lineEdit_EllipseW.setText(str(ellipse.w))
            self.main_window.lineEdit_EllipseH.setText(str(ellipse.h))

        item = self.roi_manager.get_roi_item(index)
        flux = item.get_roi_flux_item()
        self.main_window.lineEdit_RoiEmiss.setText(f"{flux.Emiss:.1f}")
        self.main_window.lineEdit_RoiAmbRefTemp.setText(str(flux.AmbRefTemp))

    def pushButton_SetRoiFluxItem_Clicked(self):
        if self.tmCamera is None or self.tmCamera.tmControl is None:
            return

        roi_index = self.main_window.comboBox_ListRoi.currentIndex()
        if roi_index < 0:
            return

        try:
            emiss = float(self.main_window.lineEdit_RoiEmiss.text())
            amb_ref_temp = float(self.main_window.lineEdit_RoiAmbRefTemp.text())
        except ValueError:
            return

        item = self.roi_manager.get_roi_item(roi_index)
        flux = item.get_roi_flux_item()
        flux.Emiss = emiss
        flux.AmbRefTemp = amb_ref_temp
        item.set_roi_flux_item(flux)

    def lineEdit_RoiEmiss_EditingFinished(self):
        try:
            emiss = float(self.main_window.lineEdit_RoiEmiss.text())
        except ValueError:
            return

        emiss = max(0.0, min(1.0, emiss))
        self.main_window.lineEdit_RoiEmiss.setText(f"{emiss:.1f}")

    def lineEdit_RoiAmbRefTemp_EditingFinished(self):
        try:
            amb_ref_temp = float(self.main_window.lineEdit_RoiAmbRefTemp.text())
        except ValueError:
            return

        self.main_window.lineEdit_RoiAmbRefTemp.setText(f"{amb_ref_temp:.1f}")

    def checkBox_HorizontalFlip_toggled(self, checked):
        if self.tmCamera is None:
            return
        self.tmCamera.set_flip_horizontal(checked)

    def checkBox_VerticalFlip_toggled(self, checked):
        if self.tmCamera is None:
            return
        self.tmCamera.set_flip_vertical(checked)


    def radioButton_CallbackModeOn_Clicked(self, checked):
        if not checked:
            return

        self.tmCamera.register_event_handler(
            self.on_frame_event_handler,
            # context is a FrameCallbackContext object, it will be passed to the on_frame_event_handler function.
            # If you do not use it, you can pass None.
            self.frame_callback_context 
        )

        self.tmCamera.begin_acquisition()

    def radioButton_CallbackModeOff_Clicked(self, checked):
        if not checked:
            return
        self.tmCamera.unregister_event_handler()
        self.tmCamera.end_acquisition()

    def display_preview_frame(self, frame):
        if frame is None:
            return

        # label_size = self.main_window.label_Preview.size()
        # if label_size.width() <= 0 or label_size.height() <= 0:
        #     return

        if not frame.resize(self.preview_width, self.preview_height):
            return

        width = frame.width()
        height = frame.height()

        min_val = 0.0
        avg_val = 0.0
        max_val = 0.0
        min_loc = (0, 0)
        max_loc = (0, 0)

        bit_map = frame.to_bitmap(ColorOrder.COLOR_RGB)
        if bit_map is None:
            return

        image = QImage(bit_map, width, height, QImage.Format_RGB888)
        if image.isNull():
            return

        if self.tmCamera.get_camera_format() == "Y16":
            for index in range(self.roi_manager.get_roi_item_count()):
                item = self.roi_manager.get_roi_item(index)
                frame.do_measure(item)
                
            min_val, avg_val, max_val, min_loc, max_loc = frame.min_max_loc()

        self.draw_shape_objects(image)
        self.update_drawing_label(image)
        pix_map = QPixmap.fromImage(image)
        self.main_window.label_Preview.setPixmap(pix_map)

        temp_unit_symbol = self.tmCamera.get_temp_unit_symbol()
        min_temp = f'{self.tmCamera.get_temperature(min_val):.2f} {temp_unit_symbol}'
        avg_temp = f'{self.tmCamera.get_temperature(avg_val):.2f} {temp_unit_symbol}'
        max_temp = f'{self.tmCamera.get_temperature(max_val):.2f} {temp_unit_symbol}'
        self.main_window.label_MinimumTemperature.setText(min_temp)
        self.main_window.label_AverageTemperature.setText(avg_temp)
        self.main_window.label_MaximumTemperature.setText(max_temp)


    
    def on_frame_event_handler(self, frame, context):
        if frame is None:
            print('on_frame_event_handler: frame is None')
            return

        callback_context = context if isinstance(context, FrameCallbackContext) else None
        if callback_context is not None:
            callback_context.frame_count += 1
            callback_context.last_frame_ts = time.time()
            # print(f'frame_count: {callback_context.frame_count}, last_frame_ts: {callback_context.last_frame_ts}')



        self.display_preview_frame(frame)

    def get_temp_string_unit(self, raw, flux=None):
        temp_str = ""
        temp_unit = self.tmCamera.get_temp_unit()
        temp_value = self.tmCamera.get_temperature(raw, flux)
        temp_symbol = self.tmCamera.get_temp_unit_symbol()

        if temp_unit == TempUnit.RAW:
            temp_str = f"{int(raw):.0f} {temp_symbol}"
        elif temp_unit == TempUnit.CELSIUS:
            temp_str = f"{temp_value:.2f} {temp_symbol}"
        elif temp_unit == TempUnit.FAHRENHEIT:
            temp_str = f"{temp_value:.2f} {temp_symbol}"
        elif temp_unit == TempUnit.KELVIN:
            temp_str = f"{temp_value:.2f} {temp_symbol}"
        
        return temp_str

    # Preview of the roi object you want to add
    # Parameter:
    #   image: A reference to the QImage object on which the ROI shape will be drawn.
    def update_drawing_label(self, image):
        painter = QPainter(image)

        if self.drawing and self.roi_manager.selected_item() is not None:
            painter.setRenderHint(QPainter.Antialiasing)
            painter.setPen(Qt.yellow)

            selected_roi_type = self.roi_manager.get_selected_roi_type()

            if selected_roi_type == RoiType.Hand:
                pass
            elif selected_roi_type == RoiType.Spot:
                shape = self.roi_manager.selected_item()
                roi_spot = RoiSpot(shape)
                spot = roi_spot.get_roi_spot()
                painter.drawEllipse(spot.x - 1, spot.y - 1, 2, 2)
            elif selected_roi_type == RoiType.Line:
                shape = self.roi_manager.selected_item()
                roi_line = RoiLine(shape)
                start, end = roi_line.get_roi_line()
                painter.drawLine(start.x, start.y, end.x, end.y)
            elif selected_roi_type == RoiType.Rect:
                shape = self.roi_manager.selected_item()
                roi_rect = RoiRect(shape)
                rect = roi_rect.get_roi_rect()
                painter.drawRect(rect.x, rect.y, rect.w, rect.h)
            elif selected_roi_type == RoiType.Ellipse:
                shape = self.roi_manager.selected_item()
                roi_ellipse = RoiRect(shape)
                ellipse = roi_ellipse.get_roi_rect()
                painter.drawEllipse(ellipse.x, ellipse.y, ellipse.w, ellipse.h)

    def draw_shape_objects(self, image):
        if image.isNull():
            return

        painter = QPainter(image)
        if not painter.isActive():
            return

        font = QFont("Verdana")
        painter.setFont(font)
        painter.setRenderHint(QPainter.Antialiasing)

        crimson = QColor(0xDC, 0x14, 0x3C)  # #dc143c
        cornflowerblue = QColor(0x64, 0x95, 0xED)  # #6495ed

        for index in range(self.roi_manager.get_roi_item_count()):
            roi_type = self.roi_manager.get_roi_type(index)
            if roi_type == RoiType.Spot:
                item = self.roi_manager.get_roi_spot_item(index)
                flux = item.get_roi_flux_item()
                spot = item.get_roi_spot()

                # Draw shape
                painter.setPen(QPen(Qt.cyan, 1))
                painter.drawEllipse(QPoint(spot.x - 1, spot.y - 1), 2, 2)

                # Draw object id
                str_draw = f"ROI{index}"
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.cyan)
                painter.drawText(int(spot.x - size_draw.width() / 2), spot.y - 4, str_draw)

                # Draw temp
                loc = item.get_roi_maxloc()
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.green)
                painter.drawText(int(spot.x - size_draw.width() / 2), spot.y + 14, str_draw)

            elif roi_type == RoiType.Line:
                item = self.roi_manager.get_roi_line_item(index)
                flux = item.get_roi_flux_item()
                start, end = item.get_roi_line()

                # Draw shape
                painter.setPen(QPen(Qt.yellow, 1))
                painter.setBrush(Qt.NoBrush)
                painter.drawLine(start.x, start.y, end.x, end.y)

                # Draw object id
                str_draw = f"ROI{index}"
                painter.setPen(Qt.cyan)
                painter.drawText(start.x, start.y - 4, str_draw)

                # Draw max temp
                loc = item.get_roi_maxloc()
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                painter.setPen(crimson)
                painter.setBrush(crimson)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y - 4),
                    QPoint(loc.location.x + 4, loc.location.y - 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(crimson)
                painter.drawText(int(loc.location.x - size_draw.width() / 2), loc.location.y - 9, str_draw)

                # Draw min temp
                loc = item.get_roi_minloc()
                painter.setPen(cornflowerblue)
                painter.setBrush(cornflowerblue)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y + 4),
                    QPoint(loc.location.x + 4, loc.location.y + 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(cornflowerblue)
                painter.drawText(int(loc.location.x - size_draw.width() / 2), loc.location.y + 15, str_draw)

                # Draw average temp
                loc = item.get_roi_avgloc()
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.green)
                painter.drawText(
                    int(start.x + (end.x - start.x) / 2 - size_draw.width() / 2),
                    int(start.y + (end.y - start.y) / 2 + 2),
                    str_draw
                )

            elif roi_type == RoiType.Rect:
                item = self.roi_manager.get_roi_rect_item(index)
                rect = item.get_roi_rect()
                flux = item.get_roi_flux_item()
                # Draw shape
                painter.setPen(QPen(Qt.yellow, 1))
                painter.setBrush(Qt.NoBrush)
                painter.drawRect(rect.x, rect.y, rect.w, rect.h)

                # Draw object id
                str_draw = f"ROI{index}"
                painter.setPen(Qt.cyan)
                painter.drawText(rect.x, rect.y - 4, str_draw)

                # Draw max temp
                loc = item.get_roi_maxloc()
                painter.setPen(crimson)
                painter.setBrush(crimson)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y - 4),
                    QPoint(loc.location.x + 4, loc.location.y - 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(crimson)
                painter.drawText(int(loc.location.x - size_draw.width() / 2), loc.location.y - 9, str_draw)

                # Draw min temp
                loc = item.get_roi_minloc()
                painter.setPen(cornflowerblue)
                painter.setBrush(cornflowerblue)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y + 4),
                    QPoint(loc.location.x + 4, loc.location.y + 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(cornflowerblue)
                painter.drawText(int(loc.location.x - size_draw.width() / 2), loc.location.y + 15, str_draw)

                # Draw average temp
                loc = item.get_roi_avgloc()
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.green)
                painter.drawText(
                    int(rect.x + rect.w / 2 - size_draw.width() / 2),
                    rect.y + rect.h + 2,
                    str_draw
                )

            elif roi_type == RoiType.Ellipse:
                item = self.roi_manager.get_roi_rect_item(index)
                rect = item.get_roi_rect()
                flux = item.get_roi_flux_item()
                # Draw shape
                painter.setPen(QPen(Qt.yellow, 1))
                painter.setBrush(Qt.NoBrush)
                painter.drawEllipse(rect.x, rect.y, rect.w, rect.h)

                # Draw object id
                str_draw = f"ROI{index}"
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.cyan)
                painter.drawText(int(rect.x + rect.w / 2 - size_draw.width() / 2), rect.y - 4, str_draw)

                # Draw max temp
                loc = item.get_roi_maxloc()
                painter.setPen(crimson)
                painter.setBrush(crimson)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y - 4),
                    QPoint(loc.location.x + 4, loc.location.y - 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(crimson)
                painter.drawText(int(loc.location.x - size_draw.width() / 2), loc.location.y - 9, str_draw)

                # Draw min temp
                loc = item.get_roi_minloc()
                painter.setPen(cornflowerblue)
                painter.setBrush(cornflowerblue)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y + 4),
                    QPoint(loc.location.x + 4, loc.location.y + 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(cornflowerblue)
                painter.drawText(int(loc.location.x - size_draw.width() / 2), loc.location.y + 15, str_draw)

                # Draw average temp
                loc = item.get_roi_avgloc()
                temp_unit = self.get_temp_string_unit(loc.value, flux)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.green)
                painter.drawText(
                    int(rect.x + rect.w / 2 - size_draw.width() / 2),
                    int(rect.y + rect.h / 2 + 2),
                    str_draw
                )

        painter.end()


# Test helper context class for callback registration.
# Use this to verify that a custom Python object is passed to
# the frame callback and can be updated safely per callback call.
class FrameCallbackContext():
    def __init__(self, parent, tag=""):
        self.parent = parent
        self.tag = tag
        self.created_at = time.time()
        self.frame_count = 0
        self.last_frame_ts = 0.0

    
# Thread for capturing camera images
class FrameWorker(QThread):
    def __init__(self, parent):
        super().__init__()
        self.parent = parent

    def stop(self): 
        self.isRun = False
    
    # Reuse shared drawing logic from Camera.
    def update_drawing_label(self, image):
        self.parent.update_drawing_label(image)

    # Reuse shared drawing logic from Camera.
    def draw_shape_objects(self, image):
        self.parent.draw_shape_objects(image)

    # Measures the minimum, maximum, and average temperature values ​​of the current frame.
    # Parameter:
    #   pFrame: TmFrame object, from pTmCamera->QueryFrame()
    def process_measurements(self, pFrame):
        try:
            min_val, avg_val, max_val = 0.0, 0.0, 0.0
            min_loc, max_loc = None, None
            
            # 카메라가 유효한지 확인
            if self.parent.tmCamera is None or self.parent.tmCamera.obj is None:
                if pFrame is not None:
                    del pFrame
                
                print('self.parent.tmCamera is None or self.parent.tmCamera.obj is None')

                return
            
            if pFrame is None:
                print('pFrame is None')

                return
            
            if self.parent.tmCamera.get_camera_format() == "Y16":
                for index in range(self.parent.roi_manager.get_roi_item_count()):
                    item = self.parent.roi_manager.get_roi_item(index)
                    pFrame.do_measure(item)

                min_val, avg_val, max_val, min_loc, max_loc = pFrame.min_max_loc()

            bit_map = pFrame.to_bitmap(ColorOrder.COLOR_RGB)
            
            image = QImage(bit_map, pFrame.width(), pFrame.height(), QImage.Format_RGB888)
            
            self.draw_shape_objects(image)
            self.update_drawing_label(image)
            
            pix_map = QPixmap.fromImage(image)
            self.parent.main_window.label_Preview.setPixmap(pix_map)
            # self.parent.main_window.label_Preview.show()
            
            temp_unit_symbol = self.parent.tmCamera.get_temp_unit_symbol()

            min_temp = f"{self.parent.tmCamera.get_temperature(min_val):.2f} {temp_unit_symbol}"
            avg_temp = f"{self.parent.tmCamera.get_temperature(avg_val):.2f} {temp_unit_symbol}"
            max_temp = f"{self.parent.tmCamera.get_temperature(max_val):.2f} {temp_unit_symbol}"
            
            self.parent.main_window.label_MinimumTemperature.setText(min_temp)
            self.parent.main_window.label_AverageTemperature.setText(avg_temp)
            self.parent.main_window.label_MaximumTemperature.setText(max_temp)

            del pFrame
        except Exception as e:
            print(f'Error in process_measurements: {str(e)}')
            if pFrame is not None:
                try:
                    del pFrame
                except:
                    pass
    
    def run(self):
        self.isRun = True

        while self.isRun:
            try:
                # 카메라가 유효한지 확인
                if self.parent.tmCamera is None or self.parent.tmCamera.obj is None:
                    QThread.msleep(100)
                    continue

                if self.parent.tmCamera.is_connected() == False:
                    print('Camera is not connected. Disconnecting camera.')
                    QThread.msleep(100)
                    continue

                if getattr(self.parent, "pause_capture_thread", False):
                    QThread.msleep(50)
                    continue

                tmFrame = self.parent.tmCamera.query_frame(
                    self.parent.preview_width,
                    self.parent.preview_height
                )

                # DLL 호출은 모두 이 QThread 안에서만 수행한다.
                if tmFrame is not None:
                    self.process_measurements(tmFrame)
            except Exception as e:
                print(f'Error in FrameWorker.run: {str(e)}')
                QThread.msleep(100)
            
            if self.isRun == False:
                QThread.msleep(100)
                break
                