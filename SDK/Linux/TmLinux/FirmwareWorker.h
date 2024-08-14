#ifndef FIRMWARE_WORKER_H
#define FIRMWARE_WORKER_H

#include <QObject>
#include <QThread>
#include "mainwindow.h"

class FirmwareWorker : public QThread
{
    Q_OBJECT

public:
    FirmwareWorker(TmSDK::TmCamera* camera, QObject* parent = nullptr);
    void run() override;

signals:
    void progressChanged(int progress);
    void workCompleted(bool success, QString message);

public slots:
    void cancel();

private:
    bool stopFlag;
    TmSDK::TmCamera* pTmCamera;
};

#endif // FIRMWARE_WORKER_H