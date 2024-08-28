/******************************************************************
 * Company: Thermoeye, Inc
 * Project: TmSDK
 * File: TmWinQt.cpp
 * Creation Date: 2024-08-19
 * Version: 1.0.0
 *
 * Description: This file contains the following implementations:
 * - Connecting event slots
 * - Handling mouse events
 *
 * History: 2024-08-19: Initial version.
 *
 **************************************************************/
#include "TmLinux.h"

TmLinux::TmLinux(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow())
{
    ui->setupUi(this);

    pCamera = new Camera(ui, this);
    pCameraCtrl = new CameraControl(ui, pCamera, this);
    pSensorCtrl = new SensorControl(ui, pCamera, this);

    // Connect the slot to be connected to the ui event
    connect(ui->pushButton_LocalCameraScan, SIGNAL(clicked()), pCamera, SLOT(pushButton_LocalCameraScan_Clicked()));
    connect(ui->pushButton_RemoteCameraScan, SIGNAL(clicked()), pCamera, SLOT(pushButton_RemoteCameraScan_Clicked()));
    connect(ui->pushButton_LocalCameraConnect, SIGNAL(clicked()), pCamera, SLOT(pushButton_LocalCameraConnect_Clicked()));
    connect(ui->pushButton_RemoteCameraConnect, SIGNAL(clicked()), pCamera, SLOT(pushButton_RemoteCameraConnect_Clicked()));
    connect(ui->tabWidget_ConnectCamera, SIGNAL(currentChanged(int)), pCamera, SLOT(tabWidget_ConnectCamera_CurrentChanged(int)));
    connect(ui->listWidget_LocalCameraList, SIGNAL(currentRowChanged(int)), pCamera, SLOT(listWidget_LocalCameraList_CurrentRowChanged(int)));
    connect(ui->listWidget_RemoteCameraList, SIGNAL(currentRowChanged(int)), pCamera, SLOT(listWidget_RemoteCameraList_CurrentRowChanged(int)));
    connect(ui->comboBox_ColorMap, SIGNAL(currentIndexChanged(int)), pCamera, SLOT(comboBox_ColorMap_Changed(int)));
    connect(ui->checkBox_NoiseFiltering, SIGNAL(toggled(bool)), pCamera, SLOT(checkBox_NoiseFiltering_toggled(bool)));
    connect(ui->comboBox_TemperatureUnit, SIGNAL(currentIndexChanged(int)), pCamera, SLOT(comboBox_TemperatureUnit_Changed(int)));
    connect(ui->radioButton_ShapeCursor, SIGNAL(clicked()), pCamera, SLOT(radioButton_ShapeCursor_clicked()));
    connect(ui->radioButton_ShapeSpot, SIGNAL(clicked()), pCamera, SLOT(radioButton_ShapeSpot_Clicked()));
    connect(ui->radioButton_ShapeLine, SIGNAL(clicked()), pCamera, SLOT(radioButton_ShapeLine_Clicked()));
    connect(ui->radioButton_ShapeRectangle, SIGNAL(clicked()), pCamera, SLOT(radioButton_ShapeRectangle_Clicked()));
    connect(ui->radioButton_ShapeEllipse, SIGNAL(clicked()), pCamera, SLOT(radioButton_ShapeEllipse_Clicked()));
    connect(ui->pushButton_RemoveAllRoi, SIGNAL(clicked()), pCamera, SLOT(pushButton_RemoveAllRoi_Clicked()));
    connect(ui->pushButton_AddRoiItem, SIGNAL(clicked()), pCamera, SLOT(pushButton_AddRoiItem_Clicked()));
    connect(ui->pushButton_RemoveRoiItem, SIGNAL(clicked()), pCamera, SLOT(pushButton_RemoveRoiItem_Clicked()));
    connect(ui->pushButton_GetProductInformation, SIGNAL(clicked()), pCameraCtrl, SLOT(pushButton_GetProductInformation_Clicked()));
    connect(ui->pushButton_GetSensorInformation, SIGNAL(clicked()), pCameraCtrl, SLOT(pushButton_GetSensorInformation_Clicked()));
    connect(ui->pushButton_SoftwareUpdateFileBrowse, SIGNAL(clicked()), pCameraCtrl, SLOT(pushButton_SoftwareUpdateFileBrowse_Clicked()));
    connect(ui->pushButton_StartSoftwareUpdate, SIGNAL(clicked()), pCameraCtrl, SLOT(pushButton_StartSoftwareUpdate_Clicked()));
    connect(ui->pushButton_GetNetworkConfiguration, SIGNAL(clicked()), pCameraCtrl, SLOT(pushButton_GetNetworkConfiguration_Clicked()));
    connect(ui->pushButton_SetNetworkConfiguration, SIGNAL(clicked()), pCameraCtrl, SLOT(pushButton_SetNetworkConfiguration_Clicked()));
    connect(ui->pushButton_SetDefaultNetworkConfiguration, SIGNAL(clicked()), pCameraCtrl, SLOT(pushButton_SetDefaultNetworkConfiguration_Clicked()));
    connect(ui->pushButton_SystemReboot, SIGNAL(clicked()), pCameraCtrl, SLOT(pushButton_SystemReboot_Clicked()));
    connect(ui->pushButton_GetFlatFieldCorrection, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_GetFlatFieldCorrection_Clicked()));
    connect(ui->pushButton_SetFlatFieldCorrection, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_SetFlatFieldCorrection_Clicked()));
    connect(ui->pushButton_RunFlatFieldCorrection, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_RunFlatFieldCorrection_Clicked()));
    connect(ui->pushButton_GetFluexParams, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_GetFluexParams_Clicked()));
    connect(ui->pushButton_SetFluexParams, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_SetFluexParams_Clicked()));
    connect(ui->pushButton_GetFFCParams, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_GetFFCParams_Clicked()));
    connect(ui->pushButton_SetFFCParams, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_SetFFCParams_Clicked()));
    connect(ui->pushButton_StoreUserSensorConfig, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_StoreUserSensorConfig_Clicked()));
    connect(ui->pushButton_RestoreDefaultSensorConfig, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_RestoreDefaultSensorConfig_Clicked()));
    connect(ui->pushButton_GetFluxParameters_160E, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_GetFluxParameters_160E_Clicked()));
    connect(ui->pushButton_SetFluxParameters_160E, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_SetFluxParameters_160E_Clicked()));
    connect(ui->pushButton_GetGainModeState_160E, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_GetGainModeState_160E_Clicked()));
    connect(ui->pushButton_SetGainModeState_160E, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_SetGainModeState_160E_Clicked()));
    connect(ui->pushButton_GetFlatFieldCorrectionMode_160E, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_GetFlatFieldCorrectionMode_160E_Clicked()));
    connect(ui->pushButton_SetFlatFieldCorrectionMode_160E, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_SetFlatFieldCorrectionMode_160E_Clicked()));
    connect(ui->pushButton_RunFlatFieldCorrection_160E, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_RunFlatFieldCorrection_160E_Clicked()));
    connect(ui->pushButton_RestoreDefaultFluxParameters_160E, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_RestoreDefaultFluxParameters_160E_Clicked()));
    connect(ui->pushButton_GetGainModeState, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_GetGainModeState_Clicked()));
    connect(ui->pushButton_SetGainModeState, SIGNAL(clicked()), pSensorCtrl, SLOT(pushButton_SetGainModeState_Clicked()));
    

    ui->comboBox_IPAssignment->addItem(QString::fromStdString("DHCP"));
    ui->comboBox_IPAssignment->addItem(QString::fromStdString("Static"));

    ui->radioButton_ShapeCursor->setChecked(true);

    // install event for label_Preivew
    ui->label_Preview->installEventFilter(this);
    ui->label_Preview->setAlignment(Qt::AlignCenter);

    ui->stackedWidget_SensorControl->setCurrentIndex(0);

    if (ui->tabWidget_ConnectCamera->currentIndex() == 0)
    {
        pCamera->ScanLocalCamera();
    }
    else
    {
        pCamera->ScanRemoteCamera();
    }
}


TmLinux::~TmLinux()
{
}

bool TmLinux::eventFilter(QObject* obj, QEvent* event)
{
    if (obj == ui->label_Preview && event->type() == QEvent::MouseButtonPress)
    {
        // Event handling for mouse button press
        QMouseEvent* mouseEvent = static_cast<QMouseEvent*>(event);
        if (mouseEvent->button() == Qt::LeftButton)
        {
            pCamera->MouseDown(mouseEvent->pos());
        }
    }
    else if (obj == ui->label_Preview && event->type() == QEvent::MouseButtonRelease)
    {
        // Event handling for mouse button release
        QMouseEvent* mouseEvent = static_cast<QMouseEvent*>(event);
        if (mouseEvent->button() == Qt::LeftButton)
        {
            pCamera->MouseUp(mouseEvent->pos());
        }
    }
    else if (event->type() == QEvent::MouseMove)
    {
        // Event handling for mouse movement
        QMouseEvent* mouseEvent = static_cast<QMouseEvent*>(event);
        pCamera->MouseMove(mouseEvent->pos());
    }
    else if (event->type() == QEvent::Resize)
    {
        // Event handling for window resizing events
        int width = ui->label_Preview->width();
        int height = ui->label_Preview->height();
        int labelWidth, labelHeight;

        if (width * 3 > height * 4) {
            labelHeight = height;
            labelWidth = labelHeight * 4 / 3;
        }
        else {
            labelWidth = width;
            labelHeight = labelWidth * 3 / 4;
        }
        pCamera->previewWidth = labelWidth;
        pCamera->previewHeight = labelHeight;
        int maginX = 250 + ((ui->centralwidget->width() - 250 - 340) / 2) - (labelWidth / 2);
        int maginY = ((ui->centralwidget->height() - 380) / 2) - (labelHeight / 2);
        if (maginX < 250) maginX = 250;
        if (maginY < 0) maginY = 0;
        ui->label_Preview->setGeometry(maginX + (width - labelWidth) / 2, maginY + (height - labelHeight) / 2, labelWidth, labelHeight);
    }

    return false;
}

void TmLinux::closeEvent(QCloseEvent* event)
{
    pCamera->DisconnectCamera();
    QApplication::quit();
    delete pCamera;
    delete pCameraCtrl;
    delete pSensorCtrl;
    close();
}