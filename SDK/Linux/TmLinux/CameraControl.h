#pragma once
#include <QObject>
#include <QMessageBox>
#include <thread>
#include <QThread>
#include <QFileDialog>

#include "ui_TmLinux.h"
#include "Camera.h"
#include "libTmCore.hpp"

using namespace  TmSDK;

class CameraControl : public QObject {
    Q_OBJECT

private:
    Ui::MainWindow* ui;
    Camera* pCamera = nullptr;
    QThread* updateFirmwareThread;

    TmCamera* pTmCamera = nullptr;

public:
    explicit CameraControl(Ui::MainWindow* mUi, Camera* camera, QObject* parent = nullptr);
    ~CameraControl();

public slots:
    void pushButton_GetProductInformation_Clicked();
    void pushButton_GetSensorInformation_Clicked();
    void pushButton_SoftwareUpdateFileBrowse_Clicked();
    void pushButton_StartSoftwareUpdate_Clicked();
    void pushButton_GetNetworkConfiguration_Clicked();
    void pushButton_SetNetworkConfiguration_Clicked();
    void pushButton_SetDefaultNetworkConfiguration_Clicked();
    void pushButton_SystemReboot_Clicked();

    void UpdateProgressChanged(int progress);
    void UpdateRunWorkerCompleted();
};