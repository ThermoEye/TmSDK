/******************************************************************
 * Company: Thermoeye, Inc
 * Project: TmSDK
 * File: CameraControl.cpp
 * Creation Date: 2024-08-19
 * Version: 1.0.0
 *
 * Description: This file contains the following implementations:
 * - Get camera product information
 * - Get sensor information
 * - Update camera firmware
 * - Get network information
 * - Configure network settings
 *
 * History: 2024-08-19: Initial version.
 *
 **************************************************************/
#include "CameraControl.h"
#include "FirmwareWorker.h"

CameraControl::CameraControl(Ui::MainWindow* mUi, Camera* camera, QObject* parent)
    : QObject(parent), ui(mUi), pCamera(camera) {}

CameraControl::~CameraControl()
{}

#pragma region slot
/*
* Get camera product information
*/
void CameraControl::pushButton_GetProductInformation_Clicked()
{
    std::string modelName;
    std::string serialNumber;
    std::string hardwareVersion;
    std::string bootloaderVersion;
    std::string firmwareVersion;

    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;

    modelName = pTmCamera->pTmControl->GetProductModelName();
    serialNumber = pTmCamera->pTmControl->GetProductSerialNumber();
    hardwareVersion = pTmCamera->pTmControl->GetHardwareVersion();
    bootloaderVersion = pTmCamera->pTmControl->GetBootloaderVersion();
    firmwareVersion = pTmCamera->pTmControl->GetFirmwareVersion();

    ui->label_ProductModelName->setText(QString::fromStdString(modelName));
    ui->label_ProductSerialNumber->setText(QString::fromStdString(serialNumber));
    ui->label_HardwareVersion->setText(QString::fromStdString(hardwareVersion));
    ui->label_BootloaderVersion->setText(QString::fromStdString(bootloaderVersion));
    ui->label_FirmwareVersion->setText(QString::fromStdString(firmwareVersion));

    pTmCamera->pTmControl->GetSystemStatus();
}

/*
* Get camera sensor information
*/
void CameraControl::pushButton_GetSensorInformation_Clicked()
{
    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    std::string modelName = pTmCamera->pTmControl->GetSensorModelName();
    std::string serialNumber = pTmCamera->pTmControl->GetSensorSerialNumber();
    std::string uptime = pTmCamera->pTmControl->GetSensorUptime();

    ui->label_SensorModelName->setText(QString::fromStdString(modelName));
    ui->label_SensorSerialNumber->setText(QString::fromStdString(serialNumber));
    ui->label_SensorUptime->setText(QString::fromStdString(uptime));
}

/*
* Select the camera firmware file you want to update
*/
void CameraControl::pushButton_SoftwareUpdateFileBrowse_Clicked()
{
    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
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

            bool verify = pTmCamera->pTmControl->CheckFirmware(fileName.toStdString(), vendorName, productName, versionName, buildTime, fileSize);
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
    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (ui->pushButton_StartSoftwareUpdate->text() == "Start")
    {
        QString fileName = ui->lineEdit_SoftwareUpdateFilePath->text();
        QFile file(fileName);
        if (file.open(QIODevice::ReadOnly))
        {
            QByteArray fileData = file.readAll();
            if (pTmCamera->pTmControl->OpenFirmware(fileName.toStdString()) > 0)
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

                FirmwareWorker* worker = nullptr;

                worker = new FirmwareWorker(pTmCamera, this);
                connect(worker, &FirmwareWorker::ProgressChanged, this, &CameraControl::UpdateProgressChanged);
                connect(worker, &FirmwareWorker::WorkCompleted, this, &CameraControl::UpdateRunWorkerCompleted);
                worker->start();
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
    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    pTmCamera->pTmControl->GetNetworkConfiguration(mac, ipAssign, ip, netmask, gateway, dns, dns2);

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
    ui->pushButton_SetNetworkConfiguration->setEnabled(true);
}

/*
* Setting up a network configuration
*/
void CameraControl::pushButton_SetNetworkConfiguration_Clicked()
{
    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (pTmCamera->pTmControl->SetNetworkConfiguration(
        ui->comboBox_IPAssignment->currentText().toStdString(),
        ui->lineEdit_IPAddress->text().toStdString(),
        ui->lineEdit_Netmask->text().toStdString(),
        ui->lineEdit_Gateway->text().toStdString(),
        ui->lineEdit_MainDNSServer->text().toStdString(),
        ui->lineEdit_SubDNSServer->text().toStdString()))
    {
        QMessageBox::about(ui->centralwidget, "Network", "Succes to set Network Configuration.");
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
    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (pTmCamera->pTmControl->SetDefaultNetworkConfiguration(ipAssignDef, ipDef, netmaskDef, gatewayDef, dnsDef, dns2Def))
    {
        ui->comboBox_IPAssignment->setCurrentText(QString::fromStdString(ipAssignDef));
        ui->lineEdit_IPAddress->setText(QString::fromStdString(ipDef));
        ui->lineEdit_Netmask->setText(QString::fromStdString(netmaskDef));
        ui->lineEdit_Gateway->setText(QString::fromStdString(gatewayDef));
        ui->lineEdit_MainDNSServer->setText(QString::fromStdString(dnsDef));
        ui->lineEdit_SubDNSServer->setText(QString::fromStdString(dns2Def));
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
    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (pCamera->runCapThread == true)
    {
        pCamera->runCapThread = false;
        pCamera->capThread.join();
    }

    pTmCamera->pTmControl->RebootDevice();
    QThread::msleep(1000);
    pTmCamera->Close();
    pTmCamera = nullptr;

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
void CameraControl::UpdateRunWorkerCompleted()
{
    if (pTmCamera == nullptr)
    {
        pTmCamera = pCamera->GetTmCamera();
    }
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    bool result = pTmCamera->pTmControl->CloseFirmware();
    if (result == false)
    {
        ui->label_SoftwareUpdateStatus->setText("Update failed.");
    }
    else
    {
        ui->label_SoftwareUpdateStatus->setText("Download complete. Reboot...");
    }

    pTmCamera->Close();
    pTmCamera = nullptr;

    if (result == true)
    {
        QMessageBox::about(ui->centralwidget, "Software Update", "Reconnect camera device.");
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Software Update", "Please check firmware binary file.");
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