/******************************************************************
 * Project: TmSDK
 * File: FirmwareWorker.cpp
 *
 * Description: This file contains the following implementations:
 * - Thread class for updating camera firmware.
 *
 * Version: 1.0.0
 * Copyright 2024. Thermoeye Inc. All rights reserved.
 *
 * History:
 *      2024-08-19: Initial version.
 ****************************************************************/
#include <QThread>
#include <QMetaType>
#include <iostream>
#include "FirmwareWorker.h"

Q_DECLARE_METATYPE(QString)

/*
* Constructor of FirmwareWorker class
* parameter:
*   camera: Pointer to the TmCamera
*   parent: Pointer to the parent QObject
*/
FirmwareWorker::FirmwareWorker(TmSDK::TmCamera* camera, QObject* parent)
    : QThread(parent), stopFlag(false), pTmCamera(camera)
{
    qRegisterMetaType<QString>("QString");
}

/**
 * Executes the firmware update thread.
 */
void FirmwareWorker::run()
{
    int percent = 0;

    if (pTmCamera != nullptr && pTmCamera->IsOpen()) {
        while (percent < 100 && !stopFlag)
        {
            percent = pTmCamera->pTmControl->UpdateFirmware();
            if (percent >= 0)
            {
                emit ProgressChanged(percent);
            }
            else
            {
                emit WorkCompleted(false, "Error during download firmware.");
                return;
            }
        }

        if (stopFlag)
        {
            emit WorkCompleted(false, "Update cancelled.");
        }
        else
        {
            emit WorkCompleted(true, "Update completed.");
        }
    }
}

/**
 * Stop the firmware update thread.
 */
void FirmwareWorker::cancel()
{
    stopFlag = true;
}