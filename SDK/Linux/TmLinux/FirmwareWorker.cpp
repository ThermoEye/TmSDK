/******************************************************************
 * Company: Thermoeye, Inc
 * Project: TmSDK
 * File: FirmwareWorker.cpp
 * Creation Date: 2024-08-19
 * Version: 1.0.0
 *
 * Description: This file contains the following implementations:
 * - Thread class for updating camera firmware.
 *
 * History: 2024-08-19: Initial version.
 *
 **************************************************************/
#include <QThread>
#include <QMetaType>
#include <iostream>
#include "FirmwareWorker.h"

Q_DECLARE_METATYPE(QString)

FirmwareWorker::FirmwareWorker(TmSDK::TmCamera* camera, QObject* parent)
    : QThread(parent), stopFlag(false), pTmCamera(camera)
{
    qRegisterMetaType<QString>("QString");
}

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

void FirmwareWorker::cancel()
{
    stopFlag = true;
}