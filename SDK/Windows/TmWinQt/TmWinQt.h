#pragma once

#include <thread>

#include <QMainWindow>
#include <QApplication>
#include <QListWidget>
#include <QVBoxLayout>
#include <QStandardItemModel>
#include <QStandardItem>
#include <QMessageBox>
#include <QCloseEvent>
#include <QMouseEvent>
#include <QPainter>
#include <QImage>
#include <QFont>
#include <QBrush>
#include <QString>
#include <QDebug>
#include <QtConcurrent/QtConcurrent>
#include <QFileDialog>

#include "ui_TmWinQt.h"
#include "Camera.h"
#include "CameraControl.h"
#include "SensorControl.h"
#include "libTmCore.hpp"

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; };
QT_END_NAMESPACE

using namespace  TmSDK;

class TmWinQt : public QMainWindow
{
    Q_OBJECT

public:
    TmWinQt(QWidget *parent = nullptr);
    ~TmWinQt();

    bool eventFilter(QObject* obj, QEvent* event);
    void closeEvent(QCloseEvent* event) override;

private:
    Ui::MainWindow* ui;
    Camera* pCamera;
    CameraControl* pCameraCtrl;
    SensorControl* pSensorCtrl;

    TmCamera* pTmCamera = nullptr;

    QPoint previewStart;
    QPoint previewEnd;
    bool drawing = false;

    QFuture<void> future;
    QFutureWatcher<void> futureWatcher;

    uint8_t gainMode = -1;
};