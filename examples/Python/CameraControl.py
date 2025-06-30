#################################################################
# Company: Thermoeye, Inc
# Project: TmSDK
# File: CameraControl.py
# Creation date: 2024-08-19
# Version: 1.0.0
#
# Description: This file contains the following implementations:
# - Get camera product information
# - Get sensor information
# - Update camera firmware
# - Get network information
# - Configure network settings
#
# History: 2024-08-19: Initial version.
#
#################################################################
from PyQt5.QtWidgets import *
from PyQt5.QtCore import QFile
from PyQt5.QtCore import QIODevice
from PyQt5.QtCore import QThread
from PyQt5.QtGui import *
from FirmwareWorker import FirmwareWorker

class CameraControl:
    def __init__(self, main_window, camera):
        self.main_window = main_window
        self.camera = camera
        self.worker = FirmwareWorker(self)

    def pushButton_GetProductInformation_Clicked(self):
        modelName = self.camera.tmCamera.tmControl.get_product_model_name()
        serialNumber = self.camera.tmCamera.tmControl.get_product_serial()
        hardwareVersion = self.camera.tmCamera.tmControl.get_hardware_version()
        bootloaderVersion = self.camera.tmCamera.tmControl.get_bootloader_version()
        firmwareVersion = self.camera.tmCamera.tmControl.get_firmware_version()
       
        self.main_window.label_ProductModelName.setText(modelName)
        self.main_window.label_ProductSerialNumber.setText(serialNumber)
        self.main_window.label_HardwareVersion.setText(hardwareVersion)
        self.main_window.label_BootloaderVersion.setText(bootloaderVersion)
        self.main_window.label_FirmwareVersion.setText(firmwareVersion)
    
    def pushButton_GetSensorInformation_Clicked(self):
        serialNumber = self.camera.tmCamera.tmControl.get_sensor_serial_number()
        modelName = self.camera.tmCamera.tmControl.get_sensor_model_name()
        sensorUptime = self.camera.tmCamera.tmControl.get_sensor_uptime()
        
        self.main_window.label_SensorModelName.setText((modelName))
        self.main_window.label_SensorSerialNumber.setText(serialNumber)
        self.main_window.label_SensorUptime.setText(sensorUptime)
        
    def pushButton_SoftwareUpdateFileBrowse_Clicked(self):
        file_name, _ = QFileDialog.getOpenFileName(self.main_window, "Open File", "", "Binary Files (*.bin);;All Files (*)")
    
        if file_name:
            file = QFile(file_name)
            if file.open(QIODevice.ReadOnly):
                ret, vendor, product, version, build_time, file_size = self.camera.tmCamera.tmControl.check_firmware(file_name)

                self.main_window.label_VendorName.setText(vendor)
                self.main_window.label_ProductName.setText(product)
                self.main_window.label_SoftwareVersion.setText(version)
                self.main_window.label_BuildTime.setText(build_time)
                self.main_window.label_BinarySize.setText(str(file_size))
                self.main_window.lineEdit_SoftwareUpdateFilePath.setText(file_name)

                if ret:
                    self.main_window.pushButton_StartSoftwareUpdate.setText("Start")
                    self.main_window.pushButton_StartSoftwareUpdate.setEnabled(True)
                else:
                    self.main_window.pushButton_StartSoftwareUpdate.setText("Reselect proper binary file")
                    self.main_window.pushButton_StartSoftwareUpdate.setEnabled(False)
                
    def pushButton_StartSoftwareUpdate_Clicked(self):
        if self.main_window.pushButton_StartSoftwareUpdate.text() == "Start":
            file_name = self.main_window.lineEdit_SoftwareUpdateFilePath.text()
            if self.camera.tmCamera.tmControl.open_firmware(file_name) > 0:
                if self.camera.worker.isRunning():
                    self.camera.worker.isRun = False
                    self.camera.worker.quit()
                    self.camera.worker.wait()
                    
                self.main_window.label_SoftwareUpdateStatus.setText("Start firmware update.")
                self.main_window.pushButton_StartSoftwareUpdate.setText("Wait...")
                self.main_window.pushButton_StartSoftwareUpdate.setEnabled(False)
                self.main_window.pushButton_SoftwareUpdateFileBrowse.setEnabled(False)

                self.worker.progressChanged.connect(self.update_progress_changed)
                self.worker.workCompleted.connect(self.update_worker_completed)
                self.worker.start()
            else:
                self.main_window.label_SoftwareUpdateStatus.setText("File open fail.")
                QMessageBox.about(self.main_window, "Software Update", "Please check firmware binary file.")
                    
    def pushButton_GetNetworkConfiguration_Clicked(self):
        ret, net_conf = self.camera.tmCamera.tmControl.get_network_configuration()

        self.main_window.lineEdit_MACAddress.setText(net_conf['mac'])
        if net_conf['ip_assign'] == "DHCP":
            self.main_window.comboBox_IPAssignment.setCurrentIndex(0)
        else:
            self.main_window.comboBox_IPAssignment.setCurrentIndex(1)
        self.main_window.lineEdit_IPAddress.setText(net_conf['ip'])
        self.main_window.lineEdit_Netmask.setText(net_conf['netmask'])
        self.main_window.lineEdit_Gateway.setText(net_conf['gateway'])
        self.main_window.lineEdit_MainDNSServer.setText(net_conf['dns'])
        self.main_window.lineEdit_SubDNSServer.setText(net_conf['dns2'])
        self.main_window.pushButton_SetNetworkConfiguration.setEnabled(True)
        
    def pushButton_SetNetworkConfiguration_Clicked(self):
        ret = self.camera.tmCamera.tmControl.set_network_configuration(
            self.main_window.comboBox_IPAssignment.currentText(),
            self.main_window.lineEdit_IPAddress.text(),
            self.main_window.lineEdit_Netmask.text(),
            self.main_window.lineEdit_Gateway.text(),
            self.main_window.lineEdit_MainDNSServer.text(),
            self.main_window.lineEdit_SubDNSServer.text()
        )

        if ret:
            QMessageBox.about(self.main_window, "Network", "Success to set Network Configuration.")
        else:
            QMessageBox.about(self.main_window, "Network", "Fail to set Network Configuration.")

    def pushButton_SetDefaultNetworkConfiguration_Clicked(self):
        ret, net_conf = self.camera.tmCamera.tmControl.set_default_network_configuration()

        if ret:
            if net_conf['ip_assign'] == "DHCP":
                self.main_window.comboBox_IPAssignment.setCurrentIndex(0)
            else:
                self.main_window.comboBox_IPAssignment.setCurrentIndex(1)
            self.main_window.lineEdit_IPAddress.setText(net_conf['ip'])
            self.main_window.lineEdit_Netmask.setText(net_conf['netmask'])
            self.main_window.lineEdit_Gateway.setText(net_conf['gateway'])
            self.main_window.lineEdit_MainDNSServer.setText(net_conf['dns'])
            self.main_window.lineEdit_SubDNSServer.setText(net_conf['dns2'])
            self.main_window.pushButton_SetNetworkConfiguration.setEnabled(True)
        else:
            QMessageBox.about(self.main_window, "Network", "Fail to set Network Configuration.")

    def pushButton_SystemReboot_Clicked(self):
        if self.camera.worker.isRunning():
            self.camera.worker.isRun = False
            self.camera.worker.quit()
            self.camera.worker.wait()

        self.camera.tmCamera.tmControl.reboot_device()
        self.camera.disconnect_camera()

        QThread.msleep(1000)
        QMessageBox.about(self.main_window, "TmSDK", "Reboot... Reconnect camera device.")
        self.main_window.pushButton_LocalCameraConnect.setText("Connect")
        self.main_window.pushButton_RemoteCameraConnect.setText("Connect")
        self.main_window.pushButton_LocalCameraScan.setEnabled(True)
        self.main_window.pushButton_RemoteCameraScan.setEnabled(True)
        self.main_window.pushButton_LocalCameraConnect.setEnabled(True)
        self.main_window.pushButton_RemoteCameraConnect.setEnabled(True)
    
    # A slot function that draws a progress bar when updating firmware.
    def update_progress_changed(self, progress):
        self.main_window.label_SoftwareUpdateStatus.setText(f"Downloading... {progress}%")
        self.main_window.progressBar_SoftwareUpdate.setValue(progress)
    
    # A slot function that is performed when a firmware update is completed.
    def update_worker_completed(self):
        result = self.camera.tmCamera.tmControl.close_firmware()
        if not result:
            self.main_window.label_SoftwareUpdateStatus.setText("Update failed.")
        else:
            self.main_window.label_SoftwareUpdateStatus.setText("Download complete. Reboot...")

        self.camera.disconnect_camera();

        if result:
            QMessageBox.about(self.main_window, "Software Update", "Reconnect camera device.")
        else:
            QMessageBox.about(self.main_window, "Software Update", "Please check firmware binary file.")
        
        self.main_window.label_SoftwareUpdateStatus.setText("")
        self.main_window.progressBar_SoftwareUpdate.setValue(0)
        self.main_window.lineEdit_SoftwareUpdateFilePath.setText("")
        self.main_window.pushButton_StartSoftwareUpdate.setText("Browse and Select Binary File")
        self.main_window.pushButton_SoftwareUpdateFileBrowse.setEnabled(True)
        self.main_window.comboBox_ColorMap.setEnabled(False)
        self.main_window.comboBox_TemperatureUnit.setEnabled(False)
        self.main_window.pushButton_LocalCameraConnect.setEnabled(False)
        self.main_window.pushButton_LocalCameraScan.setEnabled(False)
        self.main_window.pushButton_RemoteCameraConnect.setEnabled(False)
        self.main_window.pushButton_RemoteCameraScan.setEnabled(False)
        self.main_window.pushButton_LocalCameraConnect.setText("Connect")
        self.main_window.pushButton_LocalCameraConnect.setEnabled(True)
        self.main_window.pushButton_LocalCameraScan.setEnabled(True)
        self.main_window.pushButton_RemoteCameraConnect.setText("Connect")
        self.main_window.pushButton_RemoteCameraConnect.setEnabled(True)
        self.main_window.pushButton_RemoteCameraScan.setEnabled(True)
