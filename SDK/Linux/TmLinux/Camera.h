#pragma once
#include <QObject>
#include <QMessageBox>
#include <thread>
#include <QPainter>
#include <QImage>
#include <QFont>
#include <QBrush>
#include <QPixmap>
#include <QtConcurrent/QtConcurrent>

#include "ui_TmLinux.h"
#include "libTmCore.hpp"

using namespace  TmSDK;

class Camera : public QObject {
    Q_OBJECT

private:
    Ui::MainWindow* ui = nullptr;
    QFuture<void> future;
    QFutureWatcher<void> futureWatcher;
    TmRoiManager roiManager;

    std::vector<TmSDK::TmCamInfo*> CamList;
    QPoint previewStart;
    QPoint previewEnd;
    bool drawing = false;

public:
    TmCamera* pTmCamera = nullptr;
    bool runCapThread = false;
    std::thread capThread;
    int previewWidth;
    int previewHeight;

public:
    explicit Camera(Ui::MainWindow* mUi, QObject* parent = nullptr);
    ~Camera();
    void ScanLocalCamera();
    void ScanRemoteCamera();
    void DrawShapeObjects(QImage& image);
    void processMeasurements(TmSDK::TmFrame* pFrame);
    void CaptureFrame();
    std::string GetTempStringUnit(double raw);
    void DisconnectCamera();
    uint32_t ConvertAnsiToUnicodeString(std::wstring& unicode, const std::string& c_string);
    TmCamera* GetTmCamera();
    void UpdateRoiListItems();
    void UpdateDrawingLabel(QImage& image);
    void MouseUp(QPoint point);
    void MouseDown(QPoint point);
    void MouseMove(QPoint point);

public slots:
    void pushButton_LocalCameraScan_Clicked();
    void pushButton_RemoteCameraScan_Clicked();
    void tabWidget_ConnectCamera_CurrentChanged(int tabIndex);
    void pushButton_LocalCameraConnect_Clicked();
    void pushButton_RemoteCameraConnect_Clicked();
    void listWidget_LocalCameraList_CurrentRowChanged(int);
    void listWidget_RemoteCameraList_CurrentRowChanged(int);
    void comboBox_ColorMap_Changed(int);
    void checkBox_NoiseFiltering_toggled(bool);
    void comboBox_TemperatureUnit_Changed(int);
    void radioButton_ShapeCursor_clicked();
    void radioButton_ShapeSpot_Clicked();
    void radioButton_ShapeLine_Clicked();
    void radioButton_ShapeRectangle_Clicked();
    void radioButton_ShapeEllipse_Clicked();
    void pushButton_RemoveAllRoi_Clicked();
    void pushButton_AddRoiItem_Clicked();
    void pushButton_RemoveRoiItem_Clicked();
};
