/******************************************************************
 * Project: TmSDK
 * File: SensorControl.cpp
 *
 * Description: This file contains the following implementations:
 * - Get Flat Field Correction mode
 * - Set Flat Field Correction mode
 * - Run Flat Field Correction mode
 * - Get flux parameters
 * - Set flux parameters
 * - Get Flat Field Correction parameters
 * - Set Flat Field Correction parameters
 * - Store sensor configuration
 * - Restore sensor configuration
 *
 * Version: 1.0.0
 * Copyright 2024. Thermoeye Inc. All rights reserved.
 *
 * History:
 *      2024-08-19: Initial version.
 ****************************************************************/

#include "SensorControl.h"
 /*
 * Constructor of SensorControl class
 * parameter:
 *   mUi: Pointer to the UI object of MainWindow
 *   camera: Pointer to the Camera
 *   parent: Pointer to the parent QObject
 */
SensorControl::SensorControl(Ui::MainWindow* mUi, Camera* camera, QObject* parent)
    : QObject(parent), ui(mUi), pCamera(camera)
{
}

/*
* distructor of SensorControl class
*/
SensorControl::~SensorControl()
{
}

#pragma region slot
/*
 * Get current flat field correction mode.
 */
void SensorControl::pushButton_GetFlatFieldCorrection_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    int ffcMode = pCamera->pTmCamera->pTmControl->GetFlatFieldCorrectionMode();
    if (ffcMode == 0)   // Manual
    {
        ui->radioButton_FlatFieldCorrectionManual->setChecked(true);
        ui->radioButton_FlatFieldCorrectionAutomatic->setChecked(false);
    }
    else
    {
        ui->radioButton_FlatFieldCorrectionManual->setChecked(false);
        ui->radioButton_FlatFieldCorrectionAutomatic->setChecked(true);
    }
}

/*
 * Set current flat field correction mode.
 */
void SensorControl::pushButton_SetFlatFieldCorrection_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    int ffcMode = 0;
    if (ui->radioButton_FlatFieldCorrectionManual->isChecked() == true)
    {
        ffcMode = 0;
    }
    else if (ui->radioButton_FlatFieldCorrectionAutomatic->isChecked() == true)
    {
        ffcMode = 1;
    }
    pCamera->pTmCamera->pTmControl->SetFlatFieldCorrectionMode(ffcMode);
}

/*
 * Run flat field correction.
 */
void SensorControl::pushButton_RunFlatFieldCorrection_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->RunFlatFieldCorrection())
    {
        QMessageBox::StandardButton resBtn = QMessageBox::information(
            ui->centralwidget, "Flat Field Correction", "Success to run Flat Field Correction",
            QMessageBox::Ok
        );
    }
    else
    {
        QMessageBox::StandardButton resBtn = QMessageBox::information(
            ui->centralwidget, "Flat Field Correction", "Fail to run Flat Field Correction",
            QMessageBox::Ok
        );
    }
}

/*
 * Get flux parameters
 */
void SensorControl::pushButton_GetFluexParams_Clicked()
{
    double emissivity = 0;
    double atmosphericTransmittance = 0;
    double atmosphericTemperature = 0;
    double ambientReflectionTemperature = 0;
    double distance = 0;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->GetFluxParameters(emissivity, atmosphericTransmittance, atmosphericTemperature, ambientReflectionTemperature, distance))
    {
        ui->doubleSpinBox_FluexParamEmissivity->setValue(emissivity);
        ui->doubleSpinBox_FluexParamAtmosphericTransmittance->setValue(atmosphericTransmittance);
        ui->doubleSpinBox_FluexParamAtmosphericTemperature->setValue(atmosphericTemperature);
        ui->doubleSpinBox_FluexParamAmbientReflectionTemp->setValue(ambientReflectionTemperature);
        ui->doubleSpinBox_FluexParamDistance->setValue(distance);

        ui->doubleSpinBox_FluexParamEmissivity->setEnabled(true);
        ui->doubleSpinBox_FluexParamAtmosphericTransmittance->setEnabled(true);
        ui->doubleSpinBox_FluexParamAtmosphericTemperature->setEnabled(true);
        ui->doubleSpinBox_FluexParamAmbientReflectionTemp->setEnabled(true);
        ui->doubleSpinBox_FluexParamDistance->setEnabled(true);
        ui->pushButton_SetFluexParams->setEnabled(true);
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Flux Parameters", "Fail to get Flux Parameters.");
    }
}

/*
 * Set flux parameters
 */
void SensorControl::pushButton_SetFluexParams_Clicked()
{
    double emissivity = ui->doubleSpinBox_FluexParamEmissivity->value();
    double atmosphericTransmittance = ui->doubleSpinBox_FluexParamAtmosphericTransmittance->value();
    double atmosphericTemperature = ui->doubleSpinBox_FluexParamAtmosphericTemperature->value();
    double ambientReflectionTemperature = ui->doubleSpinBox_FluexParamAmbientReflectionTemp->value();
    double distance = ui->doubleSpinBox_FluexParamDistance->value();

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->SetFluxParameters(emissivity, atmosphericTransmittance, atmosphericTemperature, ambientReflectionTemperature, distance))
    {
        QMessageBox::about(ui->centralwidget, "Flux Parameters", "Success to set Flux Parameters");
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Flux Parameters", "Fail to set Flux Parameters");
    }
}

/*
 * Get FFC parameters
 */
void SensorControl::pushButton_GetFFCParams_Clicked()
{
    double maxInterval;
    double autoTriggerThreshold;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->GetFlatFieldCorrectionParameters(maxInterval, autoTriggerThreshold))
    {
        ui->doubleSpinBox_FFCParam_MaxInterval->setValue(maxInterval);
        ui->doubleSpinBox_FFCParamAutoTriggerThreshold->setValue(autoTriggerThreshold);

        ui->doubleSpinBox_FFCParam_MaxInterval->setEnabled(true);
        ui->doubleSpinBox_FFCParamAutoTriggerThreshold->setEnabled(true);
        ui->pushButton_SetFFCParams->setEnabled(true);
    }
}

/*
 * Set FFC parameters
 */
void SensorControl::pushButton_SetFFCParams_Clicked()
{
    double maxInterval = ui->doubleSpinBox_FFCParam_MaxInterval->value();
    double autoTriggerThreshold = ui->doubleSpinBox_FFCParamAutoTriggerThreshold->value();

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->SetFlatFieldCorrectionParameters(maxInterval, autoTriggerThreshold))
    {
        QMessageBox::about(ui->centralwidget, "FFC Parameters", "Success to set FFC Parameters");
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "FFC Parameters", "Fail to set FFC Parameters");
    }
}

/*
 * Store sensor configuration
 */
void SensorControl::pushButton_StoreUserSensorConfig_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->StoreUserSensorConfig())
    {
        QMessageBox::about(ui->centralwidget, "Sensor Control", "Success to store user sensor configurations");
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Sensor Control", "Fail to store user sensor configurations");
    }
}

/*
 * Restore default sensor configuration
 */
void SensorControl::pushButton_RestoreDefaultSensorConfig_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    ui->pushButton_RestoreDefaultSensorConfig->setText("Wait...");
    ui->pushButton_RestoreDefaultSensorConfig->setEnabled(false);

    if (pCamera->runCapThread == true)
    {
        pCamera->runCapThread = false;
        pCamera->capThread.join();
    }

    pCamera->pTmCamera->pTmControl->RestoreDefaultSensorConfig();

    pCamera->DisconnectCamera();

    QThread::msleep(1000);

    QMessageBox::about(ui->centralwidget, "TmSDK", "Reboot... Reconnect camera device.");

    ui->pushButton_RestoreDefaultSensorConfig->setText("Restore to Factory\n Default");
    ui->pushButton_LocalCameraConnect->setText("Connect");
    ui->pushButton_RemoteCameraConnect->setText("Connect");
    ui->pushButton_LocalCameraConnect->setEnabled(true);
    ui->pushButton_LocalCameraScan->setEnabled(true);
    ui->pushButton_RemoteCameraConnect->setEnabled(true);
    ui->pushButton_RemoteCameraScan->setEnabled(true);
    ui->pushButton_RestoreDefaultSensorConfig->setEnabled(true);
}

/*
 * Get flux parameters (TMC80, TMC160)
 */
void SensorControl::pushButton_GetFluxParameters_160E_Clicked()
{
    double sceneEmissivity;
    double backgroundTemperature;
    double windowTransmission;
    double windowTemperature;
    double atmosphericTransmission;
    double atmosphericTemperature;
    double windowReflection;
    double windowReflectedTemperature;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->GetFluxParameters(sceneEmissivity, backgroundTemperature,
        windowTransmission, windowTemperature,
        atmosphericTransmission, atmosphericTemperature,
        windowReflection, windowReflectedTemperature))
    {
        ui->doubleSpinBox_FluxParam160E_SceneEmissivity->setValue(sceneEmissivity);
        ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->setValue(backgroundTemperature);
        ui->doubleSpinBox_FluxParam160E_WindowTransmission->setValue(windowTransmission);
        ui->doubleSpinBox_FluxParam160E_WindowTemperature->setValue(windowTemperature);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->setValue(atmosphericTransmission);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->setValue(atmosphericTemperature);
        ui->doubleSpinBox_FluxParam160E_WindowReflection->setValue(windowReflection);
        ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setValue(windowReflectedTemperature);
    }
    ui->doubleSpinBox_FluxParam160E_SceneEmissivity->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_WindowTransmission->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_WindowTemperature->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_WindowReflection->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setEnabled(true);
    ui->pushButton_SetFluxParameters_160E->setEnabled(true);
}

/*
 * Set flux parameters (TMC80, TMC160)
 */
void SensorControl::pushButton_SetFluxParameters_160E_Clicked()
{
    double sceneEmissivitySet = ui->doubleSpinBox_FluxParam160E_SceneEmissivity->value();
    double backgroundTemperatureSet = ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->value();
    double windowTransmissionSet = ui->doubleSpinBox_FluxParam160E_WindowTransmission->value();
    double windowTemperatureSet = ui->doubleSpinBox_FluxParam160E_WindowTemperature->value();
    double atmosphericTransmissionSet = ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->value();
    double atmosphericTemperatureSet = ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->value();
    double windowReflectionSet = ui->doubleSpinBox_FluxParam160E_WindowReflection->value();
    double windowReflectedTemperatureSet = ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->value();

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->SetFluxParameters(sceneEmissivitySet, backgroundTemperatureSet,
        windowTransmissionSet, windowTemperatureSet,
        atmosphericTransmissionSet, atmosphericTemperatureSet,
        windowReflectionSet, windowReflectedTemperatureSet))
    {
        QMessageBox::about(ui->centralwidget, "Flux Parameters", "Succes to set Flux Parameters.");
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Flux Parameters", "Fail to set Flux Parameters.");
    }
}

/*
 * Get gain mode (TMC80, TMC160)
 */
void SensorControl::pushButton_GetGainModeState_160E_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    int gainModeState_160E = pCamera->pTmCamera->pTmControl->GetGainModeState();

    if (gainModeState_160E == 0) // High
    {
        ui->radioButton_GainModeStateHigh_160E->setChecked(true);
        ui->radioButton_GainModeStateLow_160E->setChecked(false);
        ui->radioButton_GainModeStateAuto_160E->setChecked(false);
    }
    else if (gainModeState_160E == 1) // Low
    {
        ui->radioButton_GainModeStateHigh_160E->setChecked(false);
        ui->radioButton_GainModeStateLow_160E->setChecked(true);
        ui->radioButton_GainModeStateAuto_160E->setChecked(false);
    }
    else if (gainModeState_160E == 2) // Auto
    {
        ui->radioButton_GainModeStateHigh_160E->setChecked(false);
        ui->radioButton_GainModeStateLow_160E->setChecked(false);
        ui->radioButton_GainModeStateAuto_160E->setChecked(true);
    }
    else
    {
        ui->radioButton_GainModeStateHigh_160E->setChecked(false);
        ui->radioButton_GainModeStateLow_160E->setChecked(false);
        ui->radioButton_GainModeStateAuto_160E->setChecked(false);

        QMessageBox::about(ui->centralwidget, "Gain Mode", "Fail to get Gain Mode State");
    }
}

/*
 * Set gain mode (TMC80, TMC160)
 */
void SensorControl::pushButton_SetGainModeState_160E_Clicked()
{
    int gainModeStateSet_160E = -1;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    ui->pushButton_SetGainModeState_160E->setText("Wait...");
    ui->pushButton_SetGainModeState_160E->setEnabled(false);

    if ((ui->radioButton_GainModeStateHigh_160E->isChecked() == true)
        && (ui->radioButton_GainModeStateLow_160E->isChecked() == false)
        && (ui->radioButton_GainModeStateAuto_160E->isChecked() == false))
        gainModeStateSet_160E = 0; // High
    else if ((ui->radioButton_GainModeStateHigh_160E->isChecked() == false)
        && (ui->radioButton_GainModeStateLow_160E->isChecked() == true)
        && (ui->radioButton_GainModeStateAuto_160E->isChecked() == false))
        gainModeStateSet_160E = 1; // Low
    else if ((ui->radioButton_GainModeStateHigh_160E->isChecked() == false)
        && (ui->radioButton_GainModeStateLow_160E->isChecked() == false)
        && (ui->radioButton_GainModeStateAuto_160E->isChecked() == true))
        gainModeStateSet_160E = 2; // Auto

    if ((gainModeStateSet_160E != -1) && pCamera->pTmCamera->pTmControl->SetGainModeState(gainModeStateSet_160E))
    {
        QMessageBox::about(ui->centralwidget, "Gain Mode", "Success to set Gain Mode State");
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Gain Mode", "Fail to set Gain Mode State");
    }

    ui->pushButton_SetGainModeState_160E->setText("Set");
    ui->pushButton_SetGainModeState_160E->setEnabled(true);
}

/*
 * Get flat field correction mode (TMC80, TMC160)
 */
void SensorControl::pushButton_GetFlatFieldCorrectionMode_160E_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    int ffcMode_160E = pCamera->pTmCamera->pTmControl->GetFlatFieldCorrectionMode();

    if (ffcMode_160E == 0) // Manual
    {
        ui->radioButton_FlatFieldCorrectionManual_160E->setChecked(true);
        ui->radioButton_FlatFieldCorrectionAutomatic_160E->setChecked(false);
    }
    else if (ffcMode_160E == 1) // Automatic
    {
        ui->radioButton_FlatFieldCorrectionManual_160E->setChecked(false);
        ui->radioButton_FlatFieldCorrectionAutomatic_160E->setChecked(true);
    }
    else
    {
        ui->radioButton_FlatFieldCorrectionManual_160E->setChecked(false);
        ui->radioButton_FlatFieldCorrectionAutomatic_160E->setChecked(false);

        QMessageBox::about(ui->centralwidget, "Flat Field Correction", "Fail to get Flat Field Correction Mode");
    }
}

/*
 * Set flat field correction mode (TMC80, TMC160)
 */
void SensorControl::pushButton_SetFlatFieldCorrectionMode_160E_Clicked()
{
    int ffcModeSet_160E = -1;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    if ((ui->radioButton_FlatFieldCorrectionManual_160E->isChecked() == true) && (ui->radioButton_FlatFieldCorrectionAutomatic_160E->isChecked() == false))
        ffcModeSet_160E = 0; // Manual
    else if ((ui->radioButton_FlatFieldCorrectionManual_160E->isChecked() == false) && (ui->radioButton_FlatFieldCorrectionAutomatic_160E->isChecked() == true))
        ffcModeSet_160E = 1; // Automatic

    if (ffcModeSet_160E != -1)
        pCamera->pTmCamera->pTmControl->SetFlatFieldCorrectionMode(ffcModeSet_160E);
    else
        QMessageBox::about(ui->centralwidget, "Flat Field Correction", "Fail to set Flat Field Correction Mode");
}

/*
 * Run flat field correction (TMC80, TMC160)
 */
void SensorControl::pushButton_RunFlatFieldCorrection_160E_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    ui->pushButton_RunFlatFieldCorrection_160E->setText("Wait...");
    ui->pushButton_RunFlatFieldCorrection_160E->setEnabled(false);

    if (pCamera->pTmCamera->pTmControl->RunFlatFieldCorrection())
    {
        QMessageBox::about(ui->centralwidget, "Flat Field Correction", "Success to run Flat Field Correction");
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Flat Field Correction", "Fail to run Flat Field Correction");
    }

    ui->pushButton_RunFlatFieldCorrection_160E->setText("Run");
    ui->pushButton_RunFlatFieldCorrection_160E->setEnabled(true);
}

/*
 * Restore default flux parameters (TMC80, TMC160)
 */
void SensorControl::pushButton_RestoreDefaultFluxParameters_160E_Clicked()
{
    double sceneEmissivityDef;
    double backgroundTemperatureDef;
    double windowTransmissionDef;
    double windowTemperatureDef;
    double atmosphericTransmissionDef;
    double atmosphericTemperatureDef;
    double windowReflectionDef;
    double windowReflectedTemperatureDef;

    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;
    if (pCamera->pTmCamera->pTmControl->SetDefaultFluxParameters(sceneEmissivityDef, backgroundTemperatureDef,
        windowTransmissionDef, windowTemperatureDef,
        atmosphericTransmissionDef, atmosphericTemperatureDef,
        windowReflectionDef, windowReflectedTemperatureDef))
    {
        ui->doubleSpinBox_FluxParam160E_SceneEmissivity->setValue(sceneEmissivityDef);
        ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->setValue(backgroundTemperatureDef);
        ui->doubleSpinBox_FluxParam160E_WindowTransmission->setValue(windowTransmissionDef);
        ui->doubleSpinBox_FluxParam160E_WindowTemperature->setValue(windowTemperatureDef);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->setValue(atmosphericTransmissionDef);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->setValue(atmosphericTemperatureDef);
        ui->doubleSpinBox_FluxParam160E_WindowReflection->setValue(windowReflectionDef);
        ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setValue(windowReflectedTemperatureDef);

        ui->doubleSpinBox_FluxParam160E_SceneEmissivity->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_WindowTransmission->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_WindowTemperature->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_WindowReflection->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setEnabled(true);
        ui->pushButton_SetFluxParameters_160E->setEnabled(true);

        QMessageBox::about(ui->centralwidget, "Flux Parameters", "Succes to restore Factory Default Flux Parameters.");
    }
    else
    {
        QMessageBox::about(ui->centralwidget, "Flux Parameters", "Fail to restore Factory Default Flux Parameters.");
    }
}

/*
 * Get gain mode
 */
void SensorControl::pushButton_GetGainModeState_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    int gainMode = pCamera->pTmCamera->pTmControl->GetGainModeState();

    if (gainMode == 0)
    {
        // High Gain
        ui->radioButton_GainModeHigh->setChecked(true);
        ui->radioButton_GainModeLow->setChecked(false);
    }
    else if (gainMode == 1)
    {
        // Low Gain
        ui->radioButton_GainModeHigh->setChecked(false);
        ui->radioButton_GainModeLow->setChecked(true);
    }
}

/*
 * Set gain mode
 */
void SensorControl::pushButton_SetGainModeState_Clicked()
{
    if (pCamera->pTmCamera == nullptr || pCamera->pTmCamera->pTmControl == nullptr) return;

    if (ui->radioButton_GainModeHigh->isChecked() == true && ui->radioButton_GainModeLow->isChecked() == false)
    {
        pCamera->pTmCamera->pTmControl->SetGainModeState(0);
    }
    else if (ui->radioButton_GainModeHigh->isChecked() == false && ui->radioButton_GainModeLow->isChecked() == true)
    {
        pCamera->pTmCamera->pTmControl->SetGainModeState(1);
    }
}
#pragma region