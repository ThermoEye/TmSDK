#pragma once
#include <QObject>
#include "ui_TmWinQt.h"
#include "Camera.h"
#include "libTmCore.hpp"

using namespace  TmSDK;

class SensorControl : public QObject {
    Q_OBJECT

private:
    Ui::MainWindow* ui;
    Camera* pCamera = nullptr;

public:
    explicit SensorControl(Ui::MainWindow* mUi, Camera* camera, QObject* parent = nullptr);
    ~SensorControl();

public slots:
    void pushButton_GetFlatFieldCorrection_Clicked();
    void pushButton_SetFlatFieldCorrection_Clicked();
    void pushButton_RunFlatFieldCorrection_Clicked();
    void pushButton_GetFluexParams_Clicked();
    void pushButton_SetFluexParams_Clicked();
    void pushButton_GetFFCParams_Clicked();
    void pushButton_SetFFCParams_Clicked();
    void pushButton_StoreUserSensorConfig_Clicked();
    void pushButton_RestoreDefaultSensorConfig_Clicked();
    void pushButton_GetFluxParameters_160E_Clicked();
    void pushButton_SetFluxParameters_160E_Clicked();
    void pushButton_GetGainModeState_160E_Clicked();
    void pushButton_SetGainModeState_160E_Clicked();
    void pushButton_GetFlatFieldCorrectionMode_160E_Clicked();
    void pushButton_SetFlatFieldCorrectionMode_160E_Clicked();
    void pushButton_RunFlatFieldCorrection_160E_Clicked();
    void pushButton_RestoreDefaultFluxParameters_160E_Clicked();
    void pushButton_GetGainModeState_Clicked();
    void pushButton_SetGainModeState_Clicked();
};
