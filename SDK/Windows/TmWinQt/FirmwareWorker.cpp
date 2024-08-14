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
                emit progressChanged(percent);
            }
            else
            {
                emit workCompleted(false, "Error during download firmware.");
                return;
            }
        }

        if (stopFlag)
        {
            emit workCompleted(false, "Update cancelled.");
        }
        else
        {
            emit workCompleted(true, "Update completed.");
        }
    }
}

void FirmwareWorker::cancel()
{
    stopFlag = true;
}