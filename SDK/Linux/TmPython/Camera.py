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
from PyQt5.QtCore import *
from PyQt5.QtWidgets import *
from PyQt5 import uic
from PyQt5.QtGui import *
from PyQt5.QtCore import QThreadPool
from concurrent.futures import ThreadPoolExecutor

if sys.platform.startswith("linux"):
	sys.path.append("../../Shared/Python/")
elif os.name == "nt":
    sys.path.append(sys.path[0] + "\\..\\..\\" + "Modules\\Shared\\Managed\\Python")

from TmCore import *
from TmCore.TmTypes import *
from TmCore.TmRoi import *

class Camera:
    def __init__(self, main_window):
        self.main_window = main_window
        self.roi_manager = TmRoiManager()
        self.tmCamera = TmCamera()
        self.local_camera_list=[]
        self.remote_camera_list=[]
        self.preview_width = self.main_window.label_Preview.width()
        self.preview_height = self.main_window.label_Preview.height()
        self.executor = ThreadPoolExecutor(max_workers=1)
        self.drawing = False
        self.worker = FrameWorker(self)
        self.main_window.radioButton_ShapeCursor.setChecked(True)
        
    def scan_local_camera_list(self):
        self.main_window.lineEdit_LocalCameraName.setText("")
        self.main_window.lineEdit_LocalCameraPort.setText("")
        self.main_window.listWidget_LocalCameraList.clear()
        for cam in self.local_camera_list:
            del cam
        self.local_camera_list.clear()    
        name, port, index, count = self.tmCamera.get_local_camera_list()
        for i in range(0, count):
            if name[i].startswith("TMC"):
                item = name[i] + '-' + port[i]
                self.main_window.listWidget_LocalCameraList.addItem(item)
                self.local_camera_list.append([name[i],port[i],index[i]])
                print(f'Local Camera List = {item}-{index[i]}')
        if self.local_camera_list:
            self.main_window.listWidget_LocalCameraList.setCurrentRow(0)
            camInfo=self.local_camera_list[0]
            self.main_window.lineEdit_LocalCameraName.setText(camInfo[0])
            self.main_window.lineEdit_LocalCameraPort.setText(camInfo[1])    

    def scan_remote_camera_list(self):
        self.main_window.lineEdit_RemoteCameraName.setText("")
        self.main_window.lineEdit_RemoteCameraSerial.setText("")
        self.main_window.lineEdit_RemoteCameraMac.setText("")
        self.main_window.lineEdit_RemoteCameraIp.setText("")
        self.main_window.listWidget_RemoteCameraList.clear()
        for cam in self.remote_camera_list:
            del cam
        self.remote_camera_list.clear()    
        name, serial, mac, ip, count = self.tmCamera.get_remote_camera_list(20)
        for i in range(0, count):
            item = name[i] + '-' + ip[i]
            self.main_window.listWidget_RemoteCameraList.addItem(item)
            self.remote_camera_list.append([name[i],serial[i],mac[i],ip[i]])
            print(f'Remote Camera List = {item}')
            
        if self.remote_camera_list:
            camInfo = self.remote_camera_list[0]    
            self.main_window.lineEdit_RemoteCameraName.setText(camInfo[0])
            self.main_window.lineEdit_RemoteCameraSerial.setText(camInfo[1])
            self.main_window.lineEdit_RemoteCameraMac.setText(camInfo[2])
            self.main_window.lineEdit_RemoteCameraIp.setText(camInfo[3])
            
    # Add the created roi object to the ui
    def update_roi_list_items(self):
        self.main_window.comboBox_ListRoi.clear();

        for index in range(self.roi_manager.get_roi_item_count()):
            self.main_window.comboBox_ListRoi.addItem(f"ROI{index}")

        if self.roi_manager.get_roi_item_count() > 0:
            self.main_window.comboBox_ListRoi.setCurrentIndex(0);
        else:
            self.main_window.comboBox_ListRoi.setCurrentIndex(-1);

    def disconnect_camera(self):
        if self.worker.isRunning():
            self.worker.stop()
            self.worker.wait()
        try:
            self.roi_manager.roi_clear()
            self.tmCamera.close()
        except Exception as e:
            print(f'Error while closing camera: {str(e)}')
        
        self.main_window.comboBox_ColorMap.setCurrentIndex(0)
        self.main_window.comboBox_TemperatureUnit.setCurrentIndex(0)
        self.main_window.tabWidget_Control.setVisible(False)
        self.main_window.stackedWidget_SensorControl.setVisible(False)
        self.main_window.groupBox.setEnabled(False)
        self.main_window.groupBox_SenserInformation.setEnabled(False)
        self.main_window.groupBox_SoftwareUpdate.setEnabled(False)
        self.main_window.groupBox_NetworkConfiguration.setEnabled(False)
        self.main_window.comboBox_ColorMap.setEnabled(False)
        self.main_window.comboBox_TemperatureUnit.setEnabled(False)
        
        self.main_window.radioButton_ShapeCursor.setEnabled(False);
        self.main_window.radioButton_ShapeSpot.setEnabled(False);
        self.main_window.radioButton_ShapeLine.setEnabled(False);
        self.main_window.radioButton_ShapeRectangle.setEnabled(False);
        self.main_window.radioButton_ShapeEllipse.setEnabled(False); 
        self.main_window.pushButton_RemoveAllRoi.setEnabled(False);
        self.main_window.comboBox_ColorMap.setEnabled(False);
        self.main_window.checkBox_NoiseFiltering.setEnabled(False);
        self.main_window.comboBox_TemperatureUnit.setEnabled(False);

        self.main_window.label_ProductModelName.setText("");
        self.main_window.label_ProductSerialNumber.setText("");
        self.main_window.label_HardwareVersion.setText("");
        self.main_window.label_BootloaderVersion.setText("");
        self.main_window.label_FirmwareVersion.setText("");
        self.main_window.label_SensorModelName.setText("");
        self.main_window.label_SensorSerialNumber.setText("");
        self.main_window.label_SensorUptime.setText("");
        self.main_window.label_VendorName.setText("");
        self.main_window.label_ProductName.setText("");
        self.main_window.label_SoftwareVersion.setText("");
        self.main_window.label_BuildTime.setText("");
        self.main_window.label_BinarySize.setText("");
        self.main_window.label_SoftwareUpdateStatus.setText("");
        self.main_window.lineEdit_SoftwareUpdateFilePath.setText("");
        self.main_window.lineEdit_MACAddress.setText("");
        self.main_window.comboBox_IPAssignment.setCurrentIndex(0);
        self.main_window.lineEdit_IPAddress.setText("");
        self.main_window.lineEdit_Netmask.setText("");
        self.main_window.lineEdit_Gateway.setText("");
        self.main_window.lineEdit_MainDNSServer.setText("");
        self.main_window.lineEdit_SubDNSServer.setText("");
    
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
                ret = self.tmCamera.open_local_camera((self.local_camera_list[row])[0]
                                                      , (self.local_camera_list[row])[1]
                                                      , (self.local_camera_list[row])[2]);
                
                if ret:
                    self.main_window.pushButton_LocalCameraConnect.setText("Disconnect")

                    self.worker.start()
                    val = self.tmCamera.get_temp_unit()
                    if self.local_camera_list[row][0] == "TMC256B":
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(0)
                    elif (self.local_camera_list[row][0] == "TMC160B" or self.local_camera_list[row][0] == "TMC80B"):
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(1)
                    self.tmCamera.set_temp_unit(TempUnit.CELSIUS)
                    val = self.tmCamera.get_temp_unit

                    self.main_window.tabWidget_Control.setVisible(True)
                    self.main_window.stackedWidget_SensorControl.setVisible(True)
                    self.main_window.groupBox.setEnabled(True)
                    self.main_window.groupBox_NetworkConfiguration.setEnabled(True)
                    self.main_window.groupBox_SenserInformation.setEnabled(True)
                    self.main_window.groupBox_SoftwareUpdate.setEnabled(True)
                    self.main_window.comboBox_ColorMap.setEnabled(True)
                    self.main_window.comboBox_TemperatureUnit.setEnabled(True)
                    name = self.tmCamera.tmControl.get_product_model_name()
                    self.main_window.comboBox_ColorMap.setCurrentIndex(ColormapTypes.Inferno + 1)
                    self.main_window.comboBox_TemperatureUnit.setCurrentIndex(TempUnit.CELSIUS)
                    
                    self.main_window.radioButton_ShapeCursor.setChecked(True);
                    self.main_window.radioButton_ShapeCursor.setEnabled(True);
                    self.main_window.radioButton_ShapeSpot.setEnabled(True);
                    self.main_window.radioButton_ShapeLine.setEnabled(True);
                    self.main_window.radioButton_ShapeRectangle.setEnabled(True);
                    self.main_window.radioButton_ShapeEllipse.setEnabled(True);
                    self.main_window.pushButton_RemoveAllRoi.setEnabled(True);
                    self.main_window.comboBox_ColorMap.setEnabled(True);
                    self.main_window.checkBox_NoiseFiltering.setEnabled(True);
                    self.main_window.comboBox_TemperatureUnit.setEnabled(True);
        
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
                
                ret = self.tmCamera.open_remote_camera(self.main_window.lineEdit_RemoteCameraName.text()
                                                        , self.main_window.lineEdit_RemoteCameraSerial.text()
                                                        , self.main_window.lineEdit_RemoteCameraMac.text()
                                                        , self.main_window.lineEdit_RemoteCameraIp.text())
                if ret:
                    print('Camera connected')
                    self.main_window.pushButton_RemoteCameraConnect.setText("Disconnect")
                    self.worker.start()
                    if self.main_window.lineEdit_RemoteCameraName.text() == "TMC256E":
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(0)
                    elif (self.main_window.lineEdit_RemoteCameraName.text() == "TMC160E" or self.main_window.lineEdit_RemoteCameraName.text() == "TMC80E"):
                        self.main_window.tabWidget_Control.setCurrentIndex(0)
                        self.main_window.stackedWidget_SensorControl.setCurrentIndex(1)
                    self.main_window.tabWidget_Control.setVisible(True)
                    self.main_window.stackedWidget_SensorControl.setVisible(True)
                    self.main_window.groupBox.setEnabled(True)
                    self.main_window.groupBox_SenserInformation.setEnabled(True)
                    self.main_window.groupBox_SoftwareUpdate.setEnabled(True)
                    self.main_window.comboBox_ColorMap.setEnabled(True)
                    self.main_window.comboBox_TemperatureUnit.setEnabled(True)
                    self.main_window.groupBox_NetworkConfiguration.setEnabled(True)
                    self.main_window.pushButton_GetNetworkConfiguration.setEnabled(True)
                    self.main_window.comboBox_IPAssignment.setEnabled(True)
                    self.main_window.lineEdit_Netmask.setEnabled(True)
                    self.main_window.lineEdit_IPAddress.setEnabled(True)
                    self.main_window.lineEdit_Gateway.setEnabled(True)
                    self.main_window.comboBox_ColorMap.setCurrentIndex(ColormapTypes.Inferno + 1)
                    self.main_window.comboBox_TemperatureUnit.setCurrentIndex(TempUnit.CELSIUS)

                    self.main_window.radioButton_ShapeCursor.setChecked(True);
                    self.main_window.radioButton_ShapeCursor.setEnabled(True);
                    self.main_window.radioButton_ShapeSpot.setEnabled(True);
                    self.main_window.radioButton_ShapeLine.setEnabled(True);
                    self.main_window.radioButton_ShapeRectangle.setEnabled(True);
                    self.main_window.radioButton_ShapeEllipse.setEnabled(True);
                    self.main_window.pushButton_RemoveAllRoi.setEnabled(True);
                    self.main_window.comboBox_ColorMap.setEnabled(True);
                    self.main_window.checkBox_NoiseFiltering.setEnabled(True);
                    self.main_window.comboBox_TemperatureUnit.setEnabled(True);
            except Exception as e:
                print(f'Error while opening camera: {str(e)}')  
        else:       
                self.disconnect_camera()
                self.main_window.pushButton_RemoteCameraConnect.setText("Connect")

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
        cam_info = self.local_camera_list[row];
        self.main_window.lineEdit_LocalCameraName.setText((cam_info[0]));
        self.main_window.lineEdit_LocalCameraPort.setText((cam_info[1]))
    
    def listWidget_RemoteCameraList_CurrentRowChanged(self, row):
        if row < 0:
            return
        cam_info = self.remote_camera_list[row];
        self.main_window.lineEdit_RemoteCameraName.setText(cam_info[0]);
        self.main_window.lineEdit_RemoteCameraSerial.setText(cam_info[1]);
        self.main_window.lineEdit_RemoteCameraMac.setText(cam_info[2]);
        self.main_window.lineEdit_RemoteCameraIp.setText(cam_info[3]);
 
    def comboBox_ColorMap_Changed(self, index):
        self.tmCamera.set_color_map(index)
    
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
        roi_index = self.main_window.comboBox_ListRoi.currentIndex();
        if roi_index >= 0:
            if self.roi_manager.get_roi_item_count() == 0:
                return
            self.roi_manager.remove_at(roi_index);
            self.update_roi_list_items();

# Thread for capturing camera images
class FrameWorker(QThread):
    def __init__(self, parent):
        super().__init__();
        self.parent = parent

    def stop(self): 
        self.isRun = False
    
    # Preview of the roi object you want to add
    # Parameter:
    #   image: A reference to the QImage object on which the ROI shape will be drawn.
    def update_drawing_label(self, image):
        painter = QPainter(image)

        if self.parent.drawing and self.parent.roi_manager.selected_item() is not None:
            painter.setRenderHint(QPainter.Antialiasing)
            painter.setPen(Qt.yellow)

            selected_roi_type = self.parent.roi_manager.get_selected_roi_type()

            if selected_roi_type == RoiType.Hand:
                pass
            elif selected_roi_type == RoiType.Spot:
                shape = self.parent.roi_manager.selected_item()
                roi_spot = RoiSpot(shape)
                spot = roi_spot.get_roi_spot()
                painter.drawEllipse(spot.x - 1, spot.y - 1, 2, 2)
            elif selected_roi_type == RoiType.Line:
                shape = self.parent.roi_manager.selected_item()
                roi_line = RoiLine(shape)
                start, end = roi_line.get_roi_line()
                painter.drawLine(start.x, start.y, end.x, end.y)
            elif selected_roi_type == RoiType.Rect:
                shape = self.parent.roi_manager.selected_item()
                roi_rect = RoiRect(shape)
                rect = roi_rect.get_roi_rect()
                painter.drawRect(rect.x, rect.y, rect.w, rect.h)
            elif selected_roi_type == RoiType.Ellipse:
                shape = self.parent.roi_manager.selected_item()
                roi_ellipse = RoiRect(shape)
                ellipse = roi_ellipse.get_roi_rect()
                painter.drawEllipse(ellipse.x, ellipse.y, ellipse.w, ellipse.h)

    def get_temp_string_unit(self, raw):
        temp_str = ""
        temp_unit = self.parent.tmCamera.get_temp_unit()
        temp_value = self.parent.tmCamera.get_temperature(raw)
        temp_symbol = self.parent.tmCamera.get_temp_unit_symbol()

        if temp_unit == TempUnit.RAW:
            temp_str = f"{int(raw):.0f} {temp_symbol}"
        elif temp_unit == TempUnit.CELSIUS:
            temp_str = f"{temp_value:.2f} {temp_symbol}"
        elif temp_unit == TempUnit.FAHRENHEIT:
            temp_str = f"{temp_value:.2f} {temp_symbol}"
        elif temp_unit == TempUnit.KELVIN:
            temp_str = f"{temp_value:.2f} {temp_symbol}"
        
        return temp_str
    
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

        for index in range(self.parent.roi_manager.get_roi_item_count()):
            roi_type = self.parent.roi_manager.get_roi_type(index)
            if roi_type == RoiType.Spot:
                item = self.parent.roi_manager.get_roi_spot_item(index)
                spot = item.get_roi_spot()
                
                # Draw shape
                painter.setPen(QPen(Qt.cyan, 1))
                painter.drawEllipse(QPoint(spot.x - 1, spot.y - 1), 2, 2)

                # Draw object id
                str_draw = f"ROI{index}"
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.cyan)
                painter.drawText(spot.x - size_draw.width() / 2, spot.y - 4, str_draw)

                # Draw temp
                loc = item.get_roi_maxloc()
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.green)
                painter.drawText(spot.x - size_draw.width() / 2, spot.y + 14, str_draw)
        
            elif roi_type == RoiType.Line:
                item = self.parent.roi_manager.get_roi_line_item(index)
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
                painter.setPen(crimson)
                painter.setBrush(crimson)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y - 4),
                    QPoint(loc.location.x + 4, loc.location.y - 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(crimson)
                painter.drawText(loc.location.x - size_draw.width() / 2, loc.location.y - 9, str_draw)

                # Draw min temp
                loc = item.get_roi_minloc()
                painter.setPen(cornflowerblue)
                painter.setBrush(cornflowerblue)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y + 4),
                    QPoint(loc.location.x + 4, loc.location.y + 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(cornflowerblue)
                painter.drawText(loc.location.x - size_draw.width() / 2, loc.location.y + 15, str_draw)

                # Draw average temp
                loc = item.get_roi_avgloc()
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.green)
                painter.drawText(
                    start.x + (end.x - start.x) / 2 - size_draw.width() / 2,
                    start.y + (end.y - start.y) / 2 + 2,
                    str_draw
                )
        
            elif roi_type == RoiType.Rect:
                item = self.parent.roi_manager.get_roi_rect_item(index)
                rect = item.get_roi_rect()
            
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
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(crimson)
                painter.drawText(loc.location.x - size_draw.width() / 2, loc.location.y - 9, str_draw)

                # Draw min temp
                loc = item.get_roi_minloc()
                painter.setPen(cornflowerblue)
                painter.setBrush(cornflowerblue)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y + 4),
                    QPoint(loc.location.x + 4, loc.location.y + 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(cornflowerblue)
                painter.drawText(loc.location.x - size_draw.width() / 2, loc.location.y + 15, str_draw)

                # Draw average temp
                loc = item.get_roi_avgloc()
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.green)
                painter.drawText(
                    rect.x + rect.w / 2 - size_draw.width() / 2,
                    rect.y + rect.h + 2,
                    str_draw
                )

            elif roi_type == RoiType.Ellipse:
                item = self.parent.roi_manager.get_roi_rect_item(index)
                rect = item.get_roi_rect()
            
                # Draw shape
                painter.setPen(QPen(Qt.yellow, 1))
                painter.setBrush(Qt.NoBrush)
                painter.drawEllipse(rect.x, rect.y, rect.w, rect.h)

                # Draw object id
                str_draw = f"ROI{index}"
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.cyan)
                painter.drawText(rect.x + rect.w / 2 - size_draw.width() / 2, rect.y - 4, str_draw)

                # Draw max temp
                loc = item.get_roi_maxloc()
                painter.setPen(crimson)
                painter.setBrush(crimson)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y - 4),
                    QPoint(loc.location.x + 4, loc.location.y - 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(crimson)
                painter.drawText(loc.location.x - size_draw.width() / 2, loc.location.y - 9, str_draw)

                # Draw min temp
                loc = item.get_roi_minloc()
                painter.setPen(cornflowerblue)
                painter.setBrush(cornflowerblue)
                painter.drawPolygon(
                    QPoint(loc.location.x, loc.location.y),
                    QPoint(loc.location.x - 4, loc.location.y + 4),
                    QPoint(loc.location.x + 4, loc.location.y + 4)
                )
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(cornflowerblue)
                painter.drawText(loc.location.x - size_draw.width() / 2, loc.location.y + 15, str_draw)

                # Draw average temp
                loc = item.get_roi_avgloc()
                temp_unit = self.get_temp_string_unit(loc.value)
                str_draw = temp_unit
                size_draw = painter.fontMetrics().size(Qt.TextSingleLine, str_draw)
                painter.setPen(Qt.green)
                painter.drawText(
                    rect.x + rect.w / 2 - size_draw.width() / 2,
                    rect.y + rect.h + 2,
                    str_draw
                )

        painter.end()
        pixmap = QPixmap.fromImage(image)
        # self.parent.main_window.label_camera.setPixmap(pixmap)

    # Measures the minimum, maximum, and average temperature values ​​of the current frame.
    # Parameter:
    #   pFrame: TmFrame object, from pTmCamera->QueryFrame()
    def process_measurements(self, pFrame):
        min_val, avg_val, max_val = 0.0, 0.0, 0.0
        min_loc, max_loc = None, None
        
        bit_map = pFrame.to_bitmap(ColorOrder.COLOR_RGB)
        
        image = QImage(bit_map, pFrame.width(), pFrame.height(), QImage.Format_RGB888)
        
        self.draw_shape_objects(image)
        self.update_drawing_label(image)
        
        pix_map = QPixmap.fromImage(image)
        self.parent.main_window.label_Preview.setPixmap(pix_map)
        # self.parent.main_window.label_Preview.show()
        
        for index in range(self.parent.roi_manager.get_roi_item_count()):
            item = self.parent.roi_manager.get_roi_item(index)
            pFrame.do_measure(item)
            
        min_val, avg_val, max_val, min_loc, max_loc = pFrame.min_max_loc()
        
        if self.parent.tmCamera is None:
            return

        temp_unit_symbol = self.parent.tmCamera.get_temp_unit_symbol()

        min_temp = f"{self.parent.tmCamera.get_temperature(min_val):.2f} {temp_unit_symbol}"
        avg_temp = f"{self.parent.tmCamera.get_temperature(avg_val):.2f} {temp_unit_symbol}"
        max_temp = f"{self.parent.tmCamera.get_temperature(max_val):.2f} {temp_unit_symbol}"
        
        self.parent.main_window.label_MinimumTemperature.setText(min_temp)
        self.parent.main_window.label_AverageTemperature.setText(avg_temp)
        self.parent.main_window.label_MaximumTemperature.setText(max_temp)

        del pFrame
    
    def run(self):
        self.isRun = True

        while self.isRun:
            
            tmFrame = self.parent.tmCamera.query_frame( self.parent.preview_width, self.parent.preview_height)
            
            if tmFrame is not None:
                self.parent.executor.submit(self.process_measurements, tmFrame)
            
            if self.isRun == False:
                QThread.msleep(100)
                break
                