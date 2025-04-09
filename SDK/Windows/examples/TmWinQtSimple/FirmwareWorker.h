#pragma once
#include <QObject>
#include <QThread>
#include "TmWinQt.h"

class FirmwareWorker : public QThread
{
    Q_OBJECT

private:
    bool stopFlag;
    TmCamera* pTmCamera = nullptr;

public:
    FirmwareWorker(TmCamera* camera, QObject* parent = nullptr);
    void run() override;

signals:
    void ProgressChanged(int progress);
    void WorkCompleted(bool success, QString message);

public slots:
    void cancel();
};

