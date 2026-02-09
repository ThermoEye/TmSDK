/******************************************************************
 * Project: TmSDK
 * File: CameraControl.cpp
 *
 * Description: This file contains the following implementations:
 * - Get camera product information
 * - Get sensor information
 * - Update camera firmware
 * - Get network information
 * - Configure network settings
 *
 * Version: 1.0.0
 * Copyright 2024. Thermoeye Inc. All rights reserved.
 *
 * History:
 *      2024-08-19: Initial version.
 ****************************************************************/
#include "CameraControl.h"
#include "FirmwareWorker.h"

 /*
 * Constructor of CameraControl class
 * parameter:
 *   mUi: Pointer to the UI object of MainWindow
 *   camera: Pointer to the Camera
 *   parent: Pointer to the parent QObject
 */
CameraControl::CameraControl(Ui::MainWindow* mUi, Camera* camera, QObject* parent)
    : QObject(parent), ui(mUi), pCamera(camera), firmwareWorker(nullptr) {}

/*
* distructor of CameraControl class
*/
CameraControl::~CameraControl()
{
    if (firmwareWorker != nullptr)
    {
        disconnect(firmwareWorker, nullptr, this, nullptr);
        if (firmwareWorker->isRunning())
        {
            firmwareWorker->wait();
        }
        delete firmwareWorker;
        firmwareWorker = nullptr;
    }
}

#pragma region slot
/*
* Get camera product information
*/
void CameraControl::pushButton_GetProductInformation_Clicked()
{
    std::string modelName;
    std::string partNumber;
    std::string serialNumber;
    std::string hardwareVersion;
    std::string bootloaderVersion;
    std::string firmwareVersion;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    modelName = pCamera->pTmCamera->pTmControl->GetProductModelName();
    partNumber = pCamera->pTmCamera->pTmControl->GetProductPartNumber();
    serialNumber = pCamera->pTmCamera->pTmControl->GetProductSerialNumber();
    hardwareVersion = pCamera->pTmCamera->pTmControl->GetHardwareVersion();
    bootloaderVersion = pCamera->pTmCamera->pTmControl->GetBootloaderVersion();
    firmwareVersion = pCamera->pTmCamera->pTmControl->GetFirmwareVersion();

    ui->label_ProductModelName->setText(QString::fromStdString(modelName));
    ui->label_ProductPartNumber->setText(QString::fromStdString(partNumber));
    ui->label_ProductSerialNumber->setText(QString::fromStdString(serialNumber));
    ui->label_HardwareVersion->setText(QString::fromStdString(hardwareVersion));
    ui->label_BootloaderVersion->setText(QString::fromStdString(bootloaderVersion));
    ui->label_FirmwareVersion->setText(QString::fromStdString(firmwareVersion));
}

/*
* Get camera sensor information
*/
void CameraControl::pushButton_GetSensorInformation_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    std::string modelName = pCamera->pTmCamera->pTmControl->GetSensorModelName();
    std::string serialNumber = pCamera->pTmCamera->pTmControl->GetSensorSerialNumber();
    std::string uptime = pCamera->pTmCamera->pTmControl->GetSensorUptime();

    ui->label_SensorModelName->setText(QString::fromStdString(modelName));
    ui->label_SensorSerialNumber->setText(QString::fromStdString(serialNumber));
    ui->label_SensorUptime->setText(QString::fromStdString(uptime));
}

/*
* Select the camera firmware file you want to update
*/
void CameraControl::pushButton_SoftwareUpdateFileBrowse_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    QString fileName = QFileDialog::getOpenFileName(ui->centralwidget, "Open File", "", "Binary Files (*.bin);;All Files (*)");
    if (!fileName.isEmpty())
    {
        QFile file(fileName);
        if (file.open(QIODevice::ReadOnly))
        {
            std::string vendorName;
            std::string productName;
            std::string versionName;
            std::string buildTime;
            int fileSize;

            bool verify = pCamera->pTmCamera->pTmControl->CheckFirmware(fileName.toStdString(), vendorName, productName, versionName, buildTime, fileSize);
            ui->label_VendorName->setText(QString::fromStdString(vendorName));
            ui->label_ProductName->setText(QString::fromStdString(productName));
            ui->label_SoftwareVersion->setText(QString::fromStdString(versionName));
            ui->label_BuildTime->setText(QString::fromStdString(buildTime));
            ui->label_BinarySize->setText(QString::number(fileSize));
            ui->lineEdit_SoftwareUpdateFilePath->setText(fileName);
            if (verify == true)
            {
                ui->pushButton_StartSoftwareUpdate->setText("Start");
                ui->pushButton_StartSoftwareUpdate->setEnabled(true);
            }
            else
            {
                ui->pushButton_StartSoftwareUpdate->setText("Reselect proper binary file");
                ui->pushButton_StartSoftwareUpdate->setEnabled(false);
            }
        }
    }
}

/*
* Starting the camera firmware update
*/
void CameraControl::pushButton_StartSoftwareUpdate_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (ui->pushButton_StartSoftwareUpdate->text() == "Start")
    {
        QString fileName = ui->lineEdit_SoftwareUpdateFilePath->text();
        QFile file(fileName);
        if (file.open(QIODevice::ReadOnly))
        {
            //QByteArray fileData = file.readAll();
            if (pCamera->pTmCamera->pTmControl->OpenFirmware(fileName.toStdString()) > 0)
            {
                if (pCamera->runCapThread == true)
                {
                    pCamera->runCapThread = false;
                    pCamera->capThread.join();
                }
                ui->label_SoftwareUpdateStatus->setText("Start firmware update.");
                ui->pushButton_StartSoftwareUpdate->setText("Wait...");
                ui->pushButton_StartSoftwareUpdate->setEnabled(false);
                ui->pushButton_SoftwareUpdateFileBrowse->setEnabled(false);

                // Disconnect previous connections to avoid duplicate signal emissions
                if (firmwareWorker != nullptr)
                {
                    disconnect(firmwareWorker, nullptr, this, nullptr);
                    if (firmwareWorker->isRunning())
                    {
                        firmwareWorker->wait();
                    }
                    delete firmwareWorker;
                }

                firmwareWorker = new FirmwareWorker(pCamera->pTmCamera, this);
                connect(firmwareWorker, &FirmwareWorker::ProgressChanged, this, &CameraControl::UpdateProgressChanged);
                connect(firmwareWorker, &FirmwareWorker::WorkCompleted, this, &CameraControl::UpdateRunWorkerCompleted);
                firmwareWorker->start();
            }
            else
            {
                ui->label_SoftwareUpdateStatus->setText("File open fail.");
                QMessageBox::about(ui->centralwidget, "Software Update", "Please check firmware binary file.");
            }
        }
    }
}

/*
* Get network configuration
*/
void CameraControl::pushButton_GetNetworkConfiguration_Clicked()
{
    std::string mac;
    std::string ipAssign;
    std::string ip;
    std::string netmask;
    std::string gateway;
    std::string dns;
    std::string dns2;
    bool splash;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    pCamera->pTmCamera->pTmControl->GetNetworkConfiguration(mac, ipAssign, ip, netmask, gateway, dns, dns2, splash);

    ui->lineEdit_MACAddress->setText(QString::fromStdString(mac));
    if (ipAssign == "DHCP")
    {
        ui->comboBox_IPAssignment->setCurrentIndex(0);
    }
    else
    {
        ui->comboBox_IPAssignment->setCurrentIndex(1);
    }
    ui->lineEdit_IPAddress->setText(QString::fromStdString(ip));
    ui->lineEdit_Netmask->setText(QString::fromStdString(netmask));
    ui->lineEdit_Gateway->setText(QString::fromStdString(gateway));
    ui->lineEdit_MainDNSServer->setText(QString::fromStdString(dns));
    ui->lineEdit_SubDNSServer->setText(QString::fromStdString(dns2));
    ui->comboBox_SplashScreen->setCurrentIndex(splash ? 0 : 1);
    ui->pushButton_SetNetworkConfiguration->setEnabled(true);
}

/*
* Setting up a network configuration
*/
void CameraControl::pushButton_SetNetworkConfiguration_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->SetNetworkConfiguration(
        ui->comboBox_IPAssignment->currentText().toStdString(),
        ui->lineEdit_IPAddress->text().toStdString(),
        ui->lineEdit_Netmask->text().toStdString(),
        ui->lineEdit_Gateway->text().toStdString(),
        ui->lineEdit_MainDNSServer->text().toStdString(),
        ui->lineEdit_SubDNSServer->text().toStdString(),
        ui->comboBox_SplashScreen->currentIndex() == 0 ? true : false
        ))
    {
        if (pCamera->runCapThread == true)
        {
            pCamera->runCapThread = false;
            pCamera->capThread.join();
        }

        QThread::msleep(1000);
        pCamera->DisconnectCamera();

        QThread::msleep(1000);

        QMessageBox::about(ui->centralwidget, "Network", "Succes to set Network Configuration.\rReboot... Please reconnect camera device.");
        ui->pushButton_LocalCameraConnect->setText("Connect");
        ui->pushButton_RemoteCameraConnect->setText("Connect");
        ui->pushButton_LocalCameraConnect->setText("Connect");
        ui->pushButton_RemoteCameraConnect->setText("Connect");
        ui->pushButton_LocalCameraConnect->setEnabled(true);
        ui->pushButton_LocalCameraScan->setEnabled(true);
        ui->pushButton_RemoteCameraConnect->setEnabled(true);
        ui->pushButton_RemoteCameraScan->setEnabled(true);
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Network", "Fail to set Network Configuration.");
    }
}

/*
* Restore default network configuration
*/
void CameraControl::pushButton_SetDefaultNetworkConfiguration_Clicked()
{
    std::string ipAssignDef;
    std::string ipDef;
    std::string netmaskDef;
    std::string gatewayDef;
    std::string dnsDef;
    std::string dns2Def;
    bool splash;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->SetDefaultNetworkConfiguration(ipAssignDef, ipDef, netmaskDef, gatewayDef, dnsDef, dns2Def, splash))
    {
        if (pCamera->runCapThread == true)
        {
            pCamera->runCapThread = false;
            pCamera->capThread.join();
        }

        QThread::msleep(1000);
        pCamera->DisconnectCamera();

        QThread::msleep(1000);

        QMessageBox::about(ui->centralwidget, "Network", "Succes to set Network Configuration.\rReboot... Please reconnect camera device.");
        ui->pushButton_LocalCameraConnect->setText("Connect");
        ui->pushButton_RemoteCameraConnect->setText("Connect");
        ui->pushButton_LocalCameraConnect->setText("Connect");
        ui->pushButton_RemoteCameraConnect->setText("Connect");
        ui->pushButton_LocalCameraConnect->setEnabled(true);
        ui->pushButton_LocalCameraScan->setEnabled(true);
        ui->pushButton_RemoteCameraConnect->setEnabled(true);
        ui->pushButton_RemoteCameraScan->setEnabled(true);
        ui->comboBox_SplashScreen->setCurrentIndex(splash ? 0 : 1);
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Network", "Fail to set Network Configuration.");
    }
}

/*
* Reboot the camera
*/
void CameraControl::pushButton_SystemReboot_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->runCapThread == true)
    {
        pCamera->runCapThread = false;
        pCamera->capThread.join();
    }

    pCamera->pTmCamera->pTmControl->RebootDevice();
    QThread::msleep(1000);
    pCamera->DisconnectCamera();

    QThread::msleep(1000);

    QMessageBox::about(ui->centralwidget, "TmSDK", "Reboot... Reconnect camera device.");
    ui->pushButton_LocalCameraConnect->setText("Connect");
    ui->pushButton_RemoteCameraConnect->setText("Connect");
    ui->pushButton_LocalCameraConnect->setText("Connect");
    ui->pushButton_RemoteCameraConnect->setText("Connect");
    ui->pushButton_LocalCameraConnect->setEnabled(true);
    ui->pushButton_LocalCameraScan->setEnabled(true);
    ui->pushButton_RemoteCameraConnect->setEnabled(true);
    ui->pushButton_RemoteCameraScan->setEnabled(true);
}

/*
* Display firmware update progress
*/
void CameraControl::UpdateProgressChanged(int progress)
{
    ui->label_SoftwareUpdateStatus->setText(QString("Downloading... %1%").arg(progress));
    ui->progressBar_SoftwareUpdate->setValue(progress);
}

/*
* Complete firmware update
*/
void CameraControl::UpdateRunWorkerCompleted(bool ret, QString msg)
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    
    // CloseFirmware() must be called before DisconnectCamera() to ensure
    // the serial port is still open. CloseFirmware() internally calls SendPacket
    // which requires the serial port to be open.
    bool result = pCamera->pTmCamera->pTmControl->CloseFirmware();
    
    // Both ret (download completion) and result (CloseFirmware completion) must be true
    // for the firmware update to be considered successful
    bool updateSuccessful = ret && result;
    
    if (!updateSuccessful)
    {
        if (!ret)
        {
            ui->label_SoftwareUpdateStatus->setText("Update failed.");
        }
        else
        {
            ui->label_SoftwareUpdateStatus->setText("Download complete, but close failed.");
        }
    }
    else
    {
        ui->label_SoftwareUpdateStatus->setText("Download complete. Reboot...");
    }

    // Only disconnect after CloseFirmware() has completed
    // This ensures the serial port is still open during CloseFirmware() execution
    pCamera->DisconnectCamera();

    if (updateSuccessful)
    {
        QMessageBox::about(ui->centralwidget, "Software Update", "Reconnect camera device.");
    }
    else
    {
        if (!ret)
        {
            QMessageBox::about(ui->centralwidget, "Software Update", "Please check firmware binary file.");
        }
        else
        {
            QMessageBox::about(ui->centralwidget, "Software Update", "Download completed but close failed. Please check connection.");
        }
    }
    ui->label_SoftwareUpdateStatus->setText("");
    ui->progressBar_SoftwareUpdate->setValue(0);
    ui->lineEdit_SoftwareUpdateFilePath->setText("");
    ui->pushButton_StartSoftwareUpdate->setText("Browse and Select Binary File");
    ui->pushButton_SoftwareUpdateFileBrowse->setEnabled(true);
    ui->comboBox_ColorMap->setEnabled(false);
    ui->comboBox_TemperatureUnit->setEnabled(false);
    ui->pushButton_LocalCameraConnect->setEnabled(false);
    ui->pushButton_LocalCameraScan->setEnabled(false);
    ui->pushButton_RemoteCameraConnect->setEnabled(false);
    ui->pushButton_RemoteCameraScan->setEnabled(false);
    ui->pushButton_LocalCameraConnect->setText("Connect");
    ui->pushButton_LocalCameraConnect->setEnabled(true);
    ui->pushButton_LocalCameraScan->setEnabled(true);
    ui->pushButton_RemoteCameraConnect->setText("Connect");
    ui->pushButton_RemoteCameraConnect->setEnabled(true);
    ui->pushButton_RemoteCameraScan->setEnabled(true);
}
#pragma region