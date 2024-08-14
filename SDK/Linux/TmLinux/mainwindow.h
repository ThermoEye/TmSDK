#ifndef MAINWINDOW_H
#define MAINWINDOW_H

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

#include "libTmCore.hpp"
#include "ui_mainwindow.h" 
#include "FirmwareWorker.h"

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

enum class GainMode : int
{
    High = 0,   // High Gain
    Low = 1     // Low Gain
};

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    void ScanLocalCamera();
    void ScanRemoteCamera();
    void DisconnectCamera();

    void FrameCapture();
    bool eventFilter(QObject* obj, QEvent* event);
    void UpdateRoiListItems();
    std::string GetTempStringUnit(double raw);
    void DrawShapeObjects(QImage& image);
    void UpdateDrawingLabel();
    void processMeasurements(TmSDK::TmFrame* pFrame);

protected:
    void closeEvent(QCloseEvent* event) override;

private:
    std::vector<TmSDK::TmCamInfo*> CamList;
    TmSDK::TmCamera* pTmCamera = nullptr;
    Ui::MainWindow* ui;
    bool runCapThread = false;
    std::thread capThread;
    TmSDK::TmRoiManager roiManager;

    QPoint previewStart;
    QPoint previewEnd;
    bool drawing = false;

    QFuture<void> future;
    QFutureWatcher<void> futureWatcher;

    uint8_t gainMode = -1;
    const int CONST_1PCAL_RECOMMEND_TEMP = 35;              // 1 Point Calibration Recommend Temperature : 35℃ (308K)
    const int CONST_2PCAL_HIGHGAIN_RECOMMEND_1STTEMP = 20;  // 2 Points Calibration Recommend Temperature for High Gain : 20℃ (293K)
    const int CONST_2PCAL_HIGHGAIN_RECOMMEND_2NDTEMP = 100; // 2 Points Calibration Recommend Temperature for High Gain : 100℃ (373K)
    const int CONST_2PCAL_LOWGAIN_RECOMMEND_1STTEMP = 100;  // 2 Points Calibration Recommend Temperature for Low Gain : 100℃ (373)
    const int CONST_2PCAL_LOWGAIN_RECOMMEND_2NDTEMP = 400;  // 2 Points Calibration Recommend Temperature for Low Gain : 400℃ (673K)


private slots:
    void update_ProgressChanged(int progress);
    void update_RunWorkerCompleted();

    void tabWidget_ConnectCamera_CurrentChanged(int tabIndex);
    void pushButton_LocalCameraConnect_Clicked();
    void pushButton_RemoteCameraConnect_Clicked();
    void listWidget_LocalCameraList_CurrentRowChanged(int);
    void listWidget_RemoteCameraList_CurrentRowChanged(int);
    void pushButton_GetProductInformation_Clicked();
    void pushButton_GetGainModeState_Clicked();
    void pushButton_SetGainModeState_Clicked();
    void pushButton_GetNetworkConfiguration_Clicked();
    void radioButton_ShapeCursor_clicked();
    void radioButton_ShapeSpot_Clicked();
    void radioButton_ShapeLine_Clicked();
    void radioButton_ShapeRectangle_Clicked();
    void radioButton_ShapeEllipse_Clicked();
    void pushButton_RemoveAllRoi_Clicked();
    void comboBox_ColorMap_Changed(int);
    void checkBox_NoiseFiltering_toggled(bool);
    void comboBox_TemperatureUnit_Changed(int);
    void pushButton_GetSensorInformation_Clicked();
    void pushButton_SoftwareUpdateFileBrowse_Clicked();
    void pushButton_StartSoftwareUpdate_Clicked();
    void pushButton_GetFlatFieldCorrection_Clicked();
    void pushButton_SetFlatFieldCorrection_Clicked();
    void pushButton_RunFlatFieldCorrection_Clicked();
    void pushButton_GetFluexParams_Clicked();
    void pushButton_SetFluexParams_Clicked();
    void pushButton_GetFFCParams_Clicked();
    void pushButton_SetFFCParams_Clicked();
    void pushButton_StoreUserSensorConfig_Clicked();
    void pushButton_RestoreDefaultSensorConfig_Clicked();
    void pushButton_RemoveRoiItem_Clicked();
    void pushButton_AddRoiItem_Clicked();
    void pushButton_SetNetworkConfiguration_Clicked();
    void pushButton_SetDefaultNetworkConfiguration_Clicked();
    void pushButton_SystemReboot_Clicked();
    void pushButton_GetFluxParameters_160E_Clicked();
    void pushButton_SetFluxParameters_160E_Clicked();
    void pushButton_GetGainModeState_160E_Clicked();
    void pushButton_SetGainModeState_160E_Clicked();
    void pushButton_GetFlatFieldCorrectionMode_160E_Clicked();
    void pushButton_SetFlatFieldCorrectionMode_160E_Clicked();
    void pushButton_RunFlatFieldCorrection_160E_Clicked();
    void pushButton_RestoreDefaultFluxParameters_160E_Clicked();
    void pushButton_LocalCameraScan_Clicked();
    void pushButton_RemoteCameraScan_Clicked();
};
#endif // MAINWINDOW_H
