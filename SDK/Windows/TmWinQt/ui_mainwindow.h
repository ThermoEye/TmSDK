/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.14.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QCheckBox>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QDoubleSpinBox>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHBoxLayout>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QListWidget>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QProgressBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QRadioButton>
#include <QtWidgets/QStackedWidget>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTabWidget>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralwidget;
    QTabWidget *tabWidget_ConnectCamera;
    QWidget *tab_LocalCamera;
    QWidget *gridLayoutWidget;
    QGridLayout *gridLayout;
    QLabel *label;
    QLabel *label_2;
    QLineEdit *lineEdit_LocalCameraName;
    QLineEdit *lineEdit_LocalCameraPort;
    QPushButton *pushButton_LocalCameraConnect;
    QPushButton *pushButton_LocalCameraScan;
    QListWidget *listWidget_LocalCameraList;
    QWidget *tab_RemoteCamera;
    QPushButton *pushButton_RemoteCameraScan;
    QPushButton *pushButton_RemoteCameraConnect;
    QWidget *gridLayoutWidget_2;
    QGridLayout *gridLayout_2;
    QLabel *label_3;
    QLabel *label_6;
    QLabel *label_4;
    QLabel *label_5;
    QLineEdit *lineEdit_RemoteCameraName;
    QLineEdit *lineEdit_RemoteCameraSerial;
    QLineEdit *lineEdit_RemoteCameraMac;
    QLineEdit *lineEdit_RemoteCameraIp;
    QListWidget *listWidget_RemoteCameraList;
    QTabWidget *tabWidget_Control;
    QWidget *tabSensorControl;
    QStackedWidget *stackedWidget_SensorControl;
    QWidget *page;
    QPushButton *pushButton_RestoreDefaultSensorConfig;
    QGroupBox *groupBox_5;
    QWidget *gridLayoutWidget_9;
    QGridLayout *gridLayout_9;
    QLabel *label_41;
    QLabel *label_40;
    QPushButton *pushButton_SetFFCParams;
    QLineEdit *lineEdit_FFCParam_MaxIntervalRange;
    QPushButton *pushButton_GetFFCParams;
    QDoubleSpinBox *doubleSpinBox_FFCParam_MaxInterval;
    QLabel *label_39;
    QDoubleSpinBox *doubleSpinBox_FFCParamAutoTriggerThreshold;
    QLineEdit *lineEdit_FFCParam_AutoTriggerThreshold;
    QGroupBox *groupBox_4;
    QWidget *gridLayoutWidget_8;
    QGridLayout *gridLayout_8;
    QPushButton *pushButton_GetFluexParams;
    QLabel *label_30;
    QLabel *label_35;
    QLabel *label_32;
    QDoubleSpinBox *doubleSpinBox_FluexParamEmissivity;
    QLabel *label_34;
    QLabel *label_31;
    QDoubleSpinBox *doubleSpinBox_FluexParamAtmosphericTransmittance;
    QLineEdit *lineEdit_FluexParam_EmissivityRange;
    QDoubleSpinBox *doubleSpinBox_FluexParamAtmosphericTemperature;
    QLabel *label_36;
    QLabel *label_37;
    QLabel *label_33;
    QDoubleSpinBox *doubleSpinBox_FluexParamAmbientReflectionTemp;
    QDoubleSpinBox *doubleSpinBox_FluexParamDistance;
    QLabel *label_38;
    QPushButton *pushButton_SetFluexParams;
    QLineEdit *lineEdit_FluexParam_AtmosphericTransmittanceRange;
    QLineEdit *lineEdit_FluexParamAtmosphericTempRange;
    QLineEdit *lineEdit_FluexParam_AmbientReflectionTempRange;
    QLineEdit *lineEdit_FluexParamDistanceRange;
    QGroupBox *groupBox_6;
    QWidget *gridLayoutWidget_10;
    QGridLayout *gridLayout_10;
    QRadioButton *radioButton_GainModeHigh;
    QPushButton *pushButton_GetGainModeState;
    QRadioButton *radioButton_GainModeLow;
    QPushButton *pushButton_SetGainModeState;
    QGroupBox *groupBox_7;
    QWidget *gridLayoutWidget_11;
    QGridLayout *gridLayout_11;
    QRadioButton *radioButton_FlatFieldCorrectionAutomatic;
    QRadioButton *radioButton_FlatFieldCorrectionManual;
    QPushButton *pushButton_GetFlatFieldCorrection;
    QPushButton *pushButton_SetFlatFieldCorrection;
    QPushButton *pushButton_RunFlatFieldCorrection;
    QPushButton *pushButton_StoreUserSensorConfig;
    QWidget *page_2;
    QGroupBox *groupBox_11;
    QWidget *gridLayoutWidget_16;
    QGridLayout *gridLayout_16;
    QLabel *label_122;
    QDoubleSpinBox *doubleSpinBox_FluxParam160E_AtmosphericTemperature;
    QDoubleSpinBox *doubleSpinBox_FluxParam160E_WindowTransmission;
    QLabel *label_121;
    QLabel *label_123;
    QPushButton *pushButton_GetFluxParameters_160E;
    QPushButton *pushButton_SetFluxParameters_160E;
    QLabel *label_7;
    QLabel *label_127;
    QLabel *label_128;
    QLabel *label_125;
    QLabel *label_124;
    QLineEdit *lineEdit_FluxParam160E_SceneEmissivityRange;
    QDoubleSpinBox *doubleSpinBox_FluxParam160E_AtmosphericTransmission;
    QDoubleSpinBox *doubleSpinBox_FluxParam160E_WindowReflection;
    QLabel *label_120;
    QLabel *label_9;
    QLabel *label_126;
    QLineEdit *lineEdit_FluxParam160E_WindowTemperatureRange;
    QDoubleSpinBox *doubleSpinBox_FluxParam160E_SceneEmissivity;
    QDoubleSpinBox *doubleSpinBox_FluxParam160E_BackgroundTemperature;
    QDoubleSpinBox *doubleSpinBox_FluxParam160E_WindowReflectedTemperature;
    QLabel *label_8;
    QDoubleSpinBox *doubleSpinBox_FluxParam160E_WindowTemperature;
    QLineEdit *lineEdit_FluxParam160E_BackgroundTemperatureRange;
    QLineEdit *lineEdit_FluxParam160E_WindowTransmissionRange;
    QLineEdit *lineEdit_FluxParam160E_AtmosphericTransmissionRange;
    QLineEdit *lineEdit_FluxParam160E_AtmosphericTemperatureRange;
    QLineEdit *lineEdit_FluxParam160E_WindowReflectionRange;
    QLineEdit *lineEdit_FluxParam160E_WindowReflectedTemperatureRange;
    QGroupBox *groupBox_12;
    QWidget *gridLayoutWidget_17;
    QGridLayout *gridLayout_17;
    QRadioButton *radioButton_GainModeStateAuto_160E;
    QRadioButton *radioButton_GainModeStateLow_160E;
    QRadioButton *radioButton_GainModeStateHigh_160E;
    QPushButton *pushButton_SetGainModeState_160E;
    QPushButton *pushButton_GetGainModeState_160E;
    QGroupBox *groupBox_13;
    QWidget *gridLayoutWidget_18;
    QGridLayout *gridLayout_18;
    QRadioButton *radioButton_FlatFieldCorrectionAutomatic_160E;
    QPushButton *pushButton_GetFlatFieldCorrectionMode_160E;
    QRadioButton *radioButton_FlatFieldCorrectionManual_160E;
    QPushButton *pushButton_SetFlatFieldCorrectionMode_160E;
    QPushButton *pushButton_RunFlatFieldCorrection_160E;
    QPushButton *pushButton_RestoreDefaultFluxParameters_160E;
    QWidget *tabRegionOfInterests;
    QWidget *gridLayoutWidget_12;
    QGridLayout *gridLayout_12;
    QComboBox *comboBox_ListRoi;
    QLabel *label_42;
    QPushButton *pushButton_RemoveRoiItem;
    QWidget *gridLayoutWidget_13;
    QGridLayout *gridLayout_13;
    QLineEdit *lineEdit_LineY2;
    QLabel *label_52;
    QLabel *label_48;
    QLineEdit *lineEdit_SpotY;
    QLabel *label_54;
    QRadioButton *radioButton_RoiLine;
    QLabel *label_44;
    QLabel *label_53;
    QLabel *label_46;
    QLineEdit *lineEdit_SpotX;
    QRadioButton *radioButton_RoiRectangle;
    QLabel *label_43;
    QLabel *label_55;
    QLabel *label_49;
    QRadioButton *radioButton_RoiSpot;
    QLabel *label_50;
    QRadioButton *radioButton_RoiEllipse;
    QLabel *label_56;
    QLabel *label_45;
    QLabel *label_47;
    QPushButton *pushButton_AddRoiItem;
    QLabel *label_51;
    QLineEdit *lineEdit_LineX2;
    QLineEdit *lineEdit_LineX1;
    QLineEdit *lineEdit_LineY1;
    QLineEdit *lineEdit_RectangleX;
    QLineEdit *lineEdit_EllipseX;
    QLineEdit *lineEdit_RectangleY;
    QLineEdit *lineEdit_EllipseY;
    QLineEdit *lineEdit_RectangleW;
    QLineEdit *lineEdit_EllipseW;
    QLineEdit *lineEdit_RectangleH;
    QLineEdit *lineEdit_EllipseH;
    QTabWidget *tabWidget_Product;
    QWidget *tab_3;
    QGroupBox *groupBox;
    QWidget *gridLayoutWidget_4;
    QGridLayout *gridLayout_4;
    QLabel *label_ProductModelName;
    QLabel *label_13;
    QLabel *label_HardwareVersion;
    QLabel *label_FirmwareVersion;
    QLabel *label_ProductSerialNumber;
    QLabel *label_14;
    QLabel *label_16;
    QLabel *label_BootloaderVersion;
    QLabel *label_12;
    QLabel *label_15;
    QPushButton *pushButton_GetProductInformation;
    QGroupBox *groupBox_2;
    QWidget *gridLayoutWidget_5;
    QGridLayout *gridLayout_5;
    QPushButton *pushButton_GetSensorInformation;
    QLabel *label_17;
    QLabel *label_20;
    QLabel *label_SensorSerialNumber;
    QLabel *label_SensorModelName;
    QLabel *label_18;
    QLabel *label_SensorUptime;
    QGroupBox *groupBox_3;
    QWidget *gridLayoutWidget_7;
    QGridLayout *gridLayout_7;
    QLabel *label_VendorName;
    QLabel *label_ProductName;
    QLabel *label_BinarySize;
    QLabel *label_26;
    QPushButton *pushButton_StartSoftwareUpdate;
    QLabel *label_24;
    QLabel *label_27;
    QLabel *label_28;
    QLabel *label_BuildTime;
    QProgressBar *progressBar_SoftwareUpdate;
    QLabel *label_25;
    QLabel *label_SoftwareVersion;
    QLabel *label_23;
    QHBoxLayout *horizontalLayout_4;
    QPushButton *pushButton_SoftwareUpdateFileBrowse;
    QLineEdit *lineEdit_SoftwareUpdateFilePath;
    QLabel *label_SoftwareUpdateStatus;
    QWidget *tab_4;
    QGroupBox *groupBox_10;
    QWidget *gridLayoutWidget_6;
    QGridLayout *gridLayout_6;
    QLabel *label_116;
    QLineEdit *lineEdit_Netmask;
    QLineEdit *lineEdit_SubDNSServer;
    QPushButton *pushButton_SetNetworkConfiguration;
    QLabel *label_117;
    QLabel *label_119;
    QLabel *label_21;
    QLineEdit *lineEdit_MainDNSServer;
    QPushButton *pushButton_GetNetworkConfiguration;
    QLineEdit *lineEdit_MACAddress;
    QLineEdit *lineEdit_Gateway;
    QLabel *label_22;
    QPushButton *pushButton_SetDefaultNetworkConfiguration;
    QLabel *label_118;
    QLineEdit *lineEdit_IPAddress;
    QComboBox *comboBox_IPAssignment;
    QLabel *label_19;
    QPushButton *pushButton_SystemReboot;
    QLabel *label_Preview;
    QLabel *label_Draw;
    QWidget *gridLayoutWidget_3;
    QGridLayout *gridLayout_3;
    QHBoxLayout *horizontalLayout_2;
    QLabel *label_10;
    QComboBox *comboBox_ColorMap;
    QCheckBox *checkBox_NoiseFiltering;
    QLabel *label_11;
    QComboBox *comboBox_TemperatureUnit;
    QHBoxLayout *horizontalLayout_3;
    QRadioButton *radioButton_ShapeCursor;
    QRadioButton *radioButton_ShapeSpot;
    QRadioButton *radioButton_ShapeLine;
    QRadioButton *radioButton_ShapeRectangle;
    QRadioButton *radioButton_ShapeEllipse;
    QPushButton *pushButton_RemoveAllRoi;
    QHBoxLayout *horizontalLayout;
    QLabel *label_MinimumTemperature;
    QLabel *label_AverageTemperature;
    QLabel *label_MaximumTemperature;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(1102, 772);
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        tabWidget_ConnectCamera = new QTabWidget(centralwidget);
        tabWidget_ConnectCamera->setObjectName(QString::fromUtf8("tabWidget_ConnectCamera"));
        tabWidget_ConnectCamera->setGeometry(QRect(4, 4, 261, 451));
        tab_LocalCamera = new QWidget();
        tab_LocalCamera->setObjectName(QString::fromUtf8("tab_LocalCamera"));
        gridLayoutWidget = new QWidget(tab_LocalCamera);
        gridLayoutWidget->setObjectName(QString::fromUtf8("gridLayoutWidget"));
        gridLayoutWidget->setGeometry(QRect(0, 10, 241, 51));
        gridLayout = new QGridLayout(gridLayoutWidget);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        gridLayout->setContentsMargins(0, 0, 0, 0);
        label = new QLabel(gridLayoutWidget);
        label->setObjectName(QString::fromUtf8("label"));
        label->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout->addWidget(label, 0, 0, 1, 1);

        label_2 = new QLabel(gridLayoutWidget);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout->addWidget(label_2, 1, 0, 1, 1);

        lineEdit_LocalCameraName = new QLineEdit(gridLayoutWidget);
        lineEdit_LocalCameraName->setObjectName(QString::fromUtf8("lineEdit_LocalCameraName"));

        gridLayout->addWidget(lineEdit_LocalCameraName, 0, 1, 1, 1);

        lineEdit_LocalCameraPort = new QLineEdit(gridLayoutWidget);
        lineEdit_LocalCameraPort->setObjectName(QString::fromUtf8("lineEdit_LocalCameraPort"));

        gridLayout->addWidget(lineEdit_LocalCameraPort, 1, 1, 1, 1);

        pushButton_LocalCameraConnect = new QPushButton(tab_LocalCamera);
        pushButton_LocalCameraConnect->setObjectName(QString::fromUtf8("pushButton_LocalCameraConnect"));
        pushButton_LocalCameraConnect->setGeometry(QRect(0, 70, 241, 23));
        pushButton_LocalCameraScan = new QPushButton(tab_LocalCamera);
        pushButton_LocalCameraScan->setObjectName(QString::fromUtf8("pushButton_LocalCameraScan"));
        pushButton_LocalCameraScan->setGeometry(QRect(0, 200, 241, 23));
        listWidget_LocalCameraList = new QListWidget(tab_LocalCamera);
        listWidget_LocalCameraList->setObjectName(QString::fromUtf8("listWidget_LocalCameraList"));
        listWidget_LocalCameraList->setGeometry(QRect(0, 230, 241, 191));
        tabWidget_ConnectCamera->addTab(tab_LocalCamera, QString());
        tab_RemoteCamera = new QWidget();
        tab_RemoteCamera->setObjectName(QString::fromUtf8("tab_RemoteCamera"));
        pushButton_RemoteCameraScan = new QPushButton(tab_RemoteCamera);
        pushButton_RemoteCameraScan->setObjectName(QString::fromUtf8("pushButton_RemoteCameraScan"));
        pushButton_RemoteCameraScan->setGeometry(QRect(0, 192, 241, 31));
        pushButton_RemoteCameraConnect = new QPushButton(tab_RemoteCamera);
        pushButton_RemoteCameraConnect->setObjectName(QString::fromUtf8("pushButton_RemoteCameraConnect"));
        pushButton_RemoteCameraConnect->setGeometry(QRect(0, 140, 241, 31));
        gridLayoutWidget_2 = new QWidget(tab_RemoteCamera);
        gridLayoutWidget_2->setObjectName(QString::fromUtf8("gridLayoutWidget_2"));
        gridLayoutWidget_2->setGeometry(QRect(0, 10, 241, 121));
        gridLayout_2 = new QGridLayout(gridLayoutWidget_2);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        gridLayout_2->setContentsMargins(0, 0, 0, 0);
        label_3 = new QLabel(gridLayoutWidget_2);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_2->addWidget(label_3, 0, 0, 1, 1);

        label_6 = new QLabel(gridLayoutWidget_2);
        label_6->setObjectName(QString::fromUtf8("label_6"));
        label_6->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_2->addWidget(label_6, 3, 0, 1, 1);

        label_4 = new QLabel(gridLayoutWidget_2);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_2->addWidget(label_4, 1, 0, 1, 1);

        label_5 = new QLabel(gridLayoutWidget_2);
        label_5->setObjectName(QString::fromUtf8("label_5"));
        label_5->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_2->addWidget(label_5, 2, 0, 1, 1);

        lineEdit_RemoteCameraName = new QLineEdit(gridLayoutWidget_2);
        lineEdit_RemoteCameraName->setObjectName(QString::fromUtf8("lineEdit_RemoteCameraName"));

        gridLayout_2->addWidget(lineEdit_RemoteCameraName, 0, 1, 1, 1);

        lineEdit_RemoteCameraSerial = new QLineEdit(gridLayoutWidget_2);
        lineEdit_RemoteCameraSerial->setObjectName(QString::fromUtf8("lineEdit_RemoteCameraSerial"));

        gridLayout_2->addWidget(lineEdit_RemoteCameraSerial, 1, 1, 1, 1);

        lineEdit_RemoteCameraMac = new QLineEdit(gridLayoutWidget_2);
        lineEdit_RemoteCameraMac->setObjectName(QString::fromUtf8("lineEdit_RemoteCameraMac"));

        gridLayout_2->addWidget(lineEdit_RemoteCameraMac, 2, 1, 1, 1);

        lineEdit_RemoteCameraIp = new QLineEdit(gridLayoutWidget_2);
        lineEdit_RemoteCameraIp->setObjectName(QString::fromUtf8("lineEdit_RemoteCameraIp"));

        gridLayout_2->addWidget(lineEdit_RemoteCameraIp, 3, 1, 1, 1);

        listWidget_RemoteCameraList = new QListWidget(tab_RemoteCamera);
        listWidget_RemoteCameraList->setObjectName(QString::fromUtf8("listWidget_RemoteCameraList"));
        listWidget_RemoteCameraList->setGeometry(QRect(0, 230, 241, 192));
        tabWidget_ConnectCamera->addTab(tab_RemoteCamera, QString());
        tabWidget_Control = new QTabWidget(centralwidget);
        tabWidget_Control->setObjectName(QString::fromUtf8("tabWidget_Control"));
        tabWidget_Control->setEnabled(true);
        tabWidget_Control->setGeometry(QRect(0, 450, 761, 281));
        tabWidget_Control->setMaximumSize(QSize(16777215, 16777215));
        tabSensorControl = new QWidget();
        tabSensorControl->setObjectName(QString::fromUtf8("tabSensorControl"));
        stackedWidget_SensorControl = new QStackedWidget(tabSensorControl);
        stackedWidget_SensorControl->setObjectName(QString::fromUtf8("stackedWidget_SensorControl"));
        stackedWidget_SensorControl->setGeometry(QRect(0, 0, 751, 261));
        page = new QWidget();
        page->setObjectName(QString::fromUtf8("page"));
        pushButton_RestoreDefaultSensorConfig = new QPushButton(page);
        pushButton_RestoreDefaultSensorConfig->setObjectName(QString::fromUtf8("pushButton_RestoreDefaultSensorConfig"));
        pushButton_RestoreDefaultSensorConfig->setGeometry(QRect(620, 190, 111, 51));
        groupBox_5 = new QGroupBox(page);
        groupBox_5->setObjectName(QString::fromUtf8("groupBox_5"));
        groupBox_5->setGeometry(QRect(10, 166, 471, 91));
        gridLayoutWidget_9 = new QWidget(groupBox_5);
        gridLayoutWidget_9->setObjectName(QString::fromUtf8("gridLayoutWidget_9"));
        gridLayoutWidget_9->setGeometry(QRect(10, 20, 451, 58));
        gridLayout_9 = new QGridLayout(gridLayoutWidget_9);
        gridLayout_9->setObjectName(QString::fromUtf8("gridLayout_9"));
        gridLayout_9->setContentsMargins(0, 0, 0, 0);
        label_41 = new QLabel(gridLayoutWidget_9);
        label_41->setObjectName(QString::fromUtf8("label_41"));
        label_41->setMinimumSize(QSize(12, 0));
        label_41->setAlignment(Qt::AlignCenter);

        gridLayout_9->addWidget(label_41, 0, 3, 1, 1);

        label_40 = new QLabel(gridLayoutWidget_9);
        label_40->setObjectName(QString::fromUtf8("label_40"));
        label_40->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_9->addWidget(label_40, 1, 0, 1, 1);

        pushButton_SetFFCParams = new QPushButton(gridLayoutWidget_9);
        pushButton_SetFFCParams->setObjectName(QString::fromUtf8("pushButton_SetFFCParams"));
        pushButton_SetFFCParams->setEnabled(false);
        pushButton_SetFFCParams->setMinimumSize(QSize(0, 50));
        pushButton_SetFFCParams->setMaximumSize(QSize(30, 1000));

        gridLayout_9->addWidget(pushButton_SetFFCParams, 0, 5, 2, 1);

        lineEdit_FFCParam_MaxIntervalRange = new QLineEdit(gridLayoutWidget_9);
        lineEdit_FFCParam_MaxIntervalRange->setObjectName(QString::fromUtf8("lineEdit_FFCParam_MaxIntervalRange"));
        lineEdit_FFCParam_MaxIntervalRange->setEnabled(false);
        lineEdit_FFCParam_MaxIntervalRange->setAutoFillBackground(false);
        lineEdit_FFCParam_MaxIntervalRange->setAlignment(Qt::AlignCenter);
        lineEdit_FFCParam_MaxIntervalRange->setDragEnabled(false);
        lineEdit_FFCParam_MaxIntervalRange->setReadOnly(true);
        lineEdit_FFCParam_MaxIntervalRange->setClearButtonEnabled(false);

        gridLayout_9->addWidget(lineEdit_FFCParam_MaxIntervalRange, 0, 4, 1, 1);

        pushButton_GetFFCParams = new QPushButton(gridLayoutWidget_9);
        pushButton_GetFFCParams->setObjectName(QString::fromUtf8("pushButton_GetFFCParams"));
        pushButton_GetFFCParams->setMinimumSize(QSize(0, 50));
        pushButton_GetFFCParams->setMaximumSize(QSize(30, 1000));

        gridLayout_9->addWidget(pushButton_GetFFCParams, 0, 1, 2, 1);

        doubleSpinBox_FFCParam_MaxInterval = new QDoubleSpinBox(gridLayoutWidget_9);
        doubleSpinBox_FFCParam_MaxInterval->setObjectName(QString::fromUtf8("doubleSpinBox_FFCParam_MaxInterval"));
        doubleSpinBox_FFCParam_MaxInterval->setEnabled(false);
        doubleSpinBox_FFCParam_MaxInterval->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FFCParam_MaxInterval->setMinimum(5.000000000000000);
        doubleSpinBox_FFCParam_MaxInterval->setMaximum(655.000000000000000);

        gridLayout_9->addWidget(doubleSpinBox_FFCParam_MaxInterval, 0, 2, 1, 1);

        label_39 = new QLabel(gridLayoutWidget_9);
        label_39->setObjectName(QString::fromUtf8("label_39"));
        label_39->setMinimumSize(QSize(190, 0));
        label_39->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_9->addWidget(label_39, 0, 0, 1, 1);

        doubleSpinBox_FFCParamAutoTriggerThreshold = new QDoubleSpinBox(gridLayoutWidget_9);
        doubleSpinBox_FFCParamAutoTriggerThreshold->setObjectName(QString::fromUtf8("doubleSpinBox_FFCParamAutoTriggerThreshold"));
        doubleSpinBox_FFCParamAutoTriggerThreshold->setEnabled(false);
        doubleSpinBox_FFCParamAutoTriggerThreshold->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FFCParamAutoTriggerThreshold->setMaximum(65535.000000000000000);

        gridLayout_9->addWidget(doubleSpinBox_FFCParamAutoTriggerThreshold, 1, 2, 1, 1);

        lineEdit_FFCParam_AutoTriggerThreshold = new QLineEdit(gridLayoutWidget_9);
        lineEdit_FFCParam_AutoTriggerThreshold->setObjectName(QString::fromUtf8("lineEdit_FFCParam_AutoTriggerThreshold"));
        lineEdit_FFCParam_AutoTriggerThreshold->setEnabled(false);
        lineEdit_FFCParam_AutoTriggerThreshold->setAlignment(Qt::AlignCenter);
        lineEdit_FFCParam_AutoTriggerThreshold->setReadOnly(true);

        gridLayout_9->addWidget(lineEdit_FFCParam_AutoTriggerThreshold, 1, 4, 1, 1);

        groupBox_4 = new QGroupBox(page);
        groupBox_4->setObjectName(QString::fromUtf8("groupBox_4"));
        groupBox_4->setGeometry(QRect(10, 10, 471, 151));
        gridLayoutWidget_8 = new QWidget(groupBox_4);
        gridLayoutWidget_8->setObjectName(QString::fromUtf8("gridLayoutWidget_8"));
        gridLayoutWidget_8->setGeometry(QRect(10, 20, 451, 126));
        gridLayout_8 = new QGridLayout(gridLayoutWidget_8);
        gridLayout_8->setObjectName(QString::fromUtf8("gridLayout_8"));
        gridLayout_8->setContentsMargins(0, 0, 0, 0);
        pushButton_GetFluexParams = new QPushButton(gridLayoutWidget_8);
        pushButton_GetFluexParams->setObjectName(QString::fromUtf8("pushButton_GetFluexParams"));
        pushButton_GetFluexParams->setMinimumSize(QSize(0, 120));
        pushButton_GetFluexParams->setMaximumSize(QSize(30, 16777215));

        gridLayout_8->addWidget(pushButton_GetFluexParams, 0, 1, 5, 1);

        label_30 = new QLabel(gridLayoutWidget_8);
        label_30->setObjectName(QString::fromUtf8("label_30"));
        label_30->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_8->addWidget(label_30, 0, 0, 1, 1);

        label_35 = new QLabel(gridLayoutWidget_8);
        label_35->setObjectName(QString::fromUtf8("label_35"));
        label_35->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_8->addWidget(label_35, 4, 0, 1, 1);

        label_32 = new QLabel(gridLayoutWidget_8);
        label_32->setObjectName(QString::fromUtf8("label_32"));
        label_32->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_8->addWidget(label_32, 1, 0, 1, 1);

        doubleSpinBox_FluexParamEmissivity = new QDoubleSpinBox(gridLayoutWidget_8);
        doubleSpinBox_FluexParamEmissivity->setObjectName(QString::fromUtf8("doubleSpinBox_FluexParamEmissivity"));
        doubleSpinBox_FluexParamEmissivity->setEnabled(false);
        doubleSpinBox_FluexParamEmissivity->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluexParamEmissivity->setMinimum(0.010000000000000);
        doubleSpinBox_FluexParamEmissivity->setMaximum(1.000000000000000);
        doubleSpinBox_FluexParamEmissivity->setSingleStep(0.010000000000000);

        gridLayout_8->addWidget(doubleSpinBox_FluexParamEmissivity, 0, 2, 1, 1);

        label_34 = new QLabel(gridLayoutWidget_8);
        label_34->setObjectName(QString::fromUtf8("label_34"));
        label_34->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_8->addWidget(label_34, 3, 0, 1, 1);

        label_31 = new QLabel(gridLayoutWidget_8);
        label_31->setObjectName(QString::fromUtf8("label_31"));

        gridLayout_8->addWidget(label_31, 0, 3, 1, 1);

        doubleSpinBox_FluexParamAtmosphericTransmittance = new QDoubleSpinBox(gridLayoutWidget_8);
        doubleSpinBox_FluexParamAtmosphericTransmittance->setObjectName(QString::fromUtf8("doubleSpinBox_FluexParamAtmosphericTransmittance"));
        doubleSpinBox_FluexParamAtmosphericTransmittance->setEnabled(false);
        doubleSpinBox_FluexParamAtmosphericTransmittance->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluexParamAtmosphericTransmittance->setMinimum(0.010000000000000);
        doubleSpinBox_FluexParamAtmosphericTransmittance->setMaximum(1.000000000000000);
        doubleSpinBox_FluexParamAtmosphericTransmittance->setSingleStep(0.010000000000000);

        gridLayout_8->addWidget(doubleSpinBox_FluexParamAtmosphericTransmittance, 1, 2, 1, 1);

        lineEdit_FluexParam_EmissivityRange = new QLineEdit(gridLayoutWidget_8);
        lineEdit_FluexParam_EmissivityRange->setObjectName(QString::fromUtf8("lineEdit_FluexParam_EmissivityRange"));
        lineEdit_FluexParam_EmissivityRange->setEnabled(false);
        lineEdit_FluexParam_EmissivityRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluexParam_EmissivityRange->setReadOnly(true);

        gridLayout_8->addWidget(lineEdit_FluexParam_EmissivityRange, 0, 4, 1, 1);

        doubleSpinBox_FluexParamAtmosphericTemperature = new QDoubleSpinBox(gridLayoutWidget_8);
        doubleSpinBox_FluexParamAtmosphericTemperature->setObjectName(QString::fromUtf8("doubleSpinBox_FluexParamAtmosphericTemperature"));
        doubleSpinBox_FluexParamAtmosphericTemperature->setEnabled(false);
        doubleSpinBox_FluexParamAtmosphericTemperature->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluexParamAtmosphericTemperature->setMinimum(-43.149999999999999);
        doubleSpinBox_FluexParamAtmosphericTemperature->setMaximum(625.850000000000023);
        doubleSpinBox_FluexParamAtmosphericTemperature->setSingleStep(0.010000000000000);

        gridLayout_8->addWidget(doubleSpinBox_FluexParamAtmosphericTemperature, 2, 2, 1, 1);

        label_36 = new QLabel(gridLayoutWidget_8);
        label_36->setObjectName(QString::fromUtf8("label_36"));
        label_36->setAlignment(Qt::AlignCenter);

        gridLayout_8->addWidget(label_36, 2, 3, 1, 1);

        label_37 = new QLabel(gridLayoutWidget_8);
        label_37->setObjectName(QString::fromUtf8("label_37"));
        label_37->setAlignment(Qt::AlignCenter);

        gridLayout_8->addWidget(label_37, 3, 3, 1, 1);

        label_33 = new QLabel(gridLayoutWidget_8);
        label_33->setObjectName(QString::fromUtf8("label_33"));
        label_33->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_8->addWidget(label_33, 2, 0, 1, 1);

        doubleSpinBox_FluexParamAmbientReflectionTemp = new QDoubleSpinBox(gridLayoutWidget_8);
        doubleSpinBox_FluexParamAmbientReflectionTemp->setObjectName(QString::fromUtf8("doubleSpinBox_FluexParamAmbientReflectionTemp"));
        doubleSpinBox_FluexParamAmbientReflectionTemp->setEnabled(false);
        doubleSpinBox_FluexParamAmbientReflectionTemp->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluexParamAmbientReflectionTemp->setMinimum(-43.149999999999999);
        doubleSpinBox_FluexParamAmbientReflectionTemp->setMaximum(626.850000000000023);
        doubleSpinBox_FluexParamAmbientReflectionTemp->setSingleStep(0.010000000000000);

        gridLayout_8->addWidget(doubleSpinBox_FluexParamAmbientReflectionTemp, 3, 2, 1, 1);

        doubleSpinBox_FluexParamDistance = new QDoubleSpinBox(gridLayoutWidget_8);
        doubleSpinBox_FluexParamDistance->setObjectName(QString::fromUtf8("doubleSpinBox_FluexParamDistance"));
        doubleSpinBox_FluexParamDistance->setEnabled(false);
        doubleSpinBox_FluexParamDistance->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluexParamDistance->setMaximum(200.000000000000000);
        doubleSpinBox_FluexParamDistance->setSingleStep(0.010000000000000);

        gridLayout_8->addWidget(doubleSpinBox_FluexParamDistance, 4, 2, 1, 1);

        label_38 = new QLabel(gridLayoutWidget_8);
        label_38->setObjectName(QString::fromUtf8("label_38"));
        label_38->setAlignment(Qt::AlignCenter);

        gridLayout_8->addWidget(label_38, 4, 3, 1, 1);

        pushButton_SetFluexParams = new QPushButton(gridLayoutWidget_8);
        pushButton_SetFluexParams->setObjectName(QString::fromUtf8("pushButton_SetFluexParams"));
        pushButton_SetFluexParams->setEnabled(false);
        pushButton_SetFluexParams->setMinimumSize(QSize(0, 120));
        pushButton_SetFluexParams->setMaximumSize(QSize(30, 16777215));

        gridLayout_8->addWidget(pushButton_SetFluexParams, 0, 5, 5, 1);

        lineEdit_FluexParam_AtmosphericTransmittanceRange = new QLineEdit(gridLayoutWidget_8);
        lineEdit_FluexParam_AtmosphericTransmittanceRange->setObjectName(QString::fromUtf8("lineEdit_FluexParam_AtmosphericTransmittanceRange"));
        lineEdit_FluexParam_AtmosphericTransmittanceRange->setEnabled(false);
        lineEdit_FluexParam_AtmosphericTransmittanceRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluexParam_AtmosphericTransmittanceRange->setReadOnly(true);

        gridLayout_8->addWidget(lineEdit_FluexParam_AtmosphericTransmittanceRange, 1, 4, 1, 1);

        lineEdit_FluexParamAtmosphericTempRange = new QLineEdit(gridLayoutWidget_8);
        lineEdit_FluexParamAtmosphericTempRange->setObjectName(QString::fromUtf8("lineEdit_FluexParamAtmosphericTempRange"));
        lineEdit_FluexParamAtmosphericTempRange->setEnabled(false);
        lineEdit_FluexParamAtmosphericTempRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluexParamAtmosphericTempRange->setReadOnly(true);

        gridLayout_8->addWidget(lineEdit_FluexParamAtmosphericTempRange, 2, 4, 1, 1);

        lineEdit_FluexParam_AmbientReflectionTempRange = new QLineEdit(gridLayoutWidget_8);
        lineEdit_FluexParam_AmbientReflectionTempRange->setObjectName(QString::fromUtf8("lineEdit_FluexParam_AmbientReflectionTempRange"));
        lineEdit_FluexParam_AmbientReflectionTempRange->setEnabled(false);
        lineEdit_FluexParam_AmbientReflectionTempRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluexParam_AmbientReflectionTempRange->setReadOnly(true);

        gridLayout_8->addWidget(lineEdit_FluexParam_AmbientReflectionTempRange, 3, 4, 1, 1);

        lineEdit_FluexParamDistanceRange = new QLineEdit(gridLayoutWidget_8);
        lineEdit_FluexParamDistanceRange->setObjectName(QString::fromUtf8("lineEdit_FluexParamDistanceRange"));
        lineEdit_FluexParamDistanceRange->setEnabled(false);
        lineEdit_FluexParamDistanceRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluexParamDistanceRange->setReadOnly(true);

        gridLayout_8->addWidget(lineEdit_FluexParamDistanceRange, 4, 4, 1, 1);

        groupBox_6 = new QGroupBox(page);
        groupBox_6->setObjectName(QString::fromUtf8("groupBox_6"));
        groupBox_6->setGeometry(QRect(490, 10, 251, 71));
        gridLayoutWidget_10 = new QWidget(groupBox_6);
        gridLayoutWidget_10->setObjectName(QString::fromUtf8("gridLayoutWidget_10"));
        gridLayoutWidget_10->setGeometry(QRect(10, 14, 231, 51));
        gridLayout_10 = new QGridLayout(gridLayoutWidget_10);
        gridLayout_10->setObjectName(QString::fromUtf8("gridLayout_10"));
        gridLayout_10->setContentsMargins(0, 0, 0, 0);
        radioButton_GainModeHigh = new QRadioButton(gridLayoutWidget_10);
        radioButton_GainModeHigh->setObjectName(QString::fromUtf8("radioButton_GainModeHigh"));

        gridLayout_10->addWidget(radioButton_GainModeHigh, 0, 0, 1, 1);

        pushButton_GetGainModeState = new QPushButton(gridLayoutWidget_10);
        pushButton_GetGainModeState->setObjectName(QString::fromUtf8("pushButton_GetGainModeState"));
        pushButton_GetGainModeState->setMinimumSize(QSize(50, 0));
        pushButton_GetGainModeState->setMaximumSize(QSize(50, 50));

        gridLayout_10->addWidget(pushButton_GetGainModeState, 0, 1, 2, 1);

        radioButton_GainModeLow = new QRadioButton(gridLayoutWidget_10);
        radioButton_GainModeLow->setObjectName(QString::fromUtf8("radioButton_GainModeLow"));

        gridLayout_10->addWidget(radioButton_GainModeLow, 1, 0, 1, 1);

        pushButton_SetGainModeState = new QPushButton(gridLayoutWidget_10);
        pushButton_SetGainModeState->setObjectName(QString::fromUtf8("pushButton_SetGainModeState"));
        pushButton_SetGainModeState->setMaximumSize(QSize(50, 50));

        gridLayout_10->addWidget(pushButton_SetGainModeState, 0, 2, 2, 1);

        groupBox_7 = new QGroupBox(page);
        groupBox_7->setObjectName(QString::fromUtf8("groupBox_7"));
        groupBox_7->setGeometry(QRect(490, 86, 251, 81));
        gridLayoutWidget_11 = new QWidget(groupBox_7);
        gridLayoutWidget_11->setObjectName(QString::fromUtf8("gridLayoutWidget_11"));
        gridLayoutWidget_11->setGeometry(QRect(10, 14, 231, 54));
        gridLayout_11 = new QGridLayout(gridLayoutWidget_11);
        gridLayout_11->setObjectName(QString::fromUtf8("gridLayout_11"));
        gridLayout_11->setContentsMargins(0, 0, 0, 0);
        radioButton_FlatFieldCorrectionAutomatic = new QRadioButton(gridLayoutWidget_11);
        radioButton_FlatFieldCorrectionAutomatic->setObjectName(QString::fromUtf8("radioButton_FlatFieldCorrectionAutomatic"));

        gridLayout_11->addWidget(radioButton_FlatFieldCorrectionAutomatic, 0, 0, 1, 1);

        radioButton_FlatFieldCorrectionManual = new QRadioButton(gridLayoutWidget_11);
        radioButton_FlatFieldCorrectionManual->setObjectName(QString::fromUtf8("radioButton_FlatFieldCorrectionManual"));

        gridLayout_11->addWidget(radioButton_FlatFieldCorrectionManual, 1, 0, 1, 1);

        pushButton_GetFlatFieldCorrection = new QPushButton(gridLayoutWidget_11);
        pushButton_GetFlatFieldCorrection->setObjectName(QString::fromUtf8("pushButton_GetFlatFieldCorrection"));
        pushButton_GetFlatFieldCorrection->setMinimumSize(QSize(50, 0));
        pushButton_GetFlatFieldCorrection->setMaximumSize(QSize(50, 50));

        gridLayout_11->addWidget(pushButton_GetFlatFieldCorrection, 0, 1, 1, 1);

        pushButton_SetFlatFieldCorrection = new QPushButton(gridLayoutWidget_11);
        pushButton_SetFlatFieldCorrection->setObjectName(QString::fromUtf8("pushButton_SetFlatFieldCorrection"));
        pushButton_SetFlatFieldCorrection->setMinimumSize(QSize(50, 0));
        pushButton_SetFlatFieldCorrection->setMaximumSize(QSize(50, 50));

        gridLayout_11->addWidget(pushButton_SetFlatFieldCorrection, 0, 2, 1, 1);

        pushButton_RunFlatFieldCorrection = new QPushButton(gridLayoutWidget_11);
        pushButton_RunFlatFieldCorrection->setObjectName(QString::fromUtf8("pushButton_RunFlatFieldCorrection"));
        pushButton_RunFlatFieldCorrection->setMinimumSize(QSize(50, 0));
        pushButton_RunFlatFieldCorrection->setMaximumSize(QSize(110, 50));

        gridLayout_11->addWidget(pushButton_RunFlatFieldCorrection, 1, 1, 1, 2);

        pushButton_StoreUserSensorConfig = new QPushButton(page);
        pushButton_StoreUserSensorConfig->setObjectName(QString::fromUtf8("pushButton_StoreUserSensorConfig"));
        pushButton_StoreUserSensorConfig->setGeometry(QRect(500, 190, 101, 51));
        stackedWidget_SensorControl->addWidget(page);
        page_2 = new QWidget();
        page_2->setObjectName(QString::fromUtf8("page_2"));
        groupBox_11 = new QGroupBox(page_2);
        groupBox_11->setObjectName(QString::fromUtf8("groupBox_11"));
        groupBox_11->setGeometry(QRect(0, 0, 461, 261));
        gridLayoutWidget_16 = new QWidget(groupBox_11);
        gridLayoutWidget_16->setObjectName(QString::fromUtf8("gridLayoutWidget_16"));
        gridLayoutWidget_16->setGeometry(QRect(10, 20, 441, 231));
        gridLayout_16 = new QGridLayout(gridLayoutWidget_16);
        gridLayout_16->setObjectName(QString::fromUtf8("gridLayout_16"));
        gridLayout_16->setContentsMargins(0, 0, 0, 0);
        label_122 = new QLabel(gridLayoutWidget_16);
        label_122->setObjectName(QString::fromUtf8("label_122"));
        label_122->setMaximumSize(QSize(16777215, 20));
        label_122->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_16->addWidget(label_122, 4, 0, 1, 1);

        doubleSpinBox_FluxParam160E_AtmosphericTemperature = new QDoubleSpinBox(gridLayoutWidget_16);
        doubleSpinBox_FluxParam160E_AtmosphericTemperature->setObjectName(QString::fromUtf8("doubleSpinBox_FluxParam160E_AtmosphericTemperature"));
        doubleSpinBox_FluxParam160E_AtmosphericTemperature->setEnabled(false);
        doubleSpinBox_FluxParam160E_AtmosphericTemperature->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluxParam160E_AtmosphericTemperature->setMinimum(-273.149999999999977);
        doubleSpinBox_FluxParam160E_AtmosphericTemperature->setMaximum(382.199999999999989);
        doubleSpinBox_FluxParam160E_AtmosphericTemperature->setSingleStep(0.010000000000000);

        gridLayout_16->addWidget(doubleSpinBox_FluxParam160E_AtmosphericTemperature, 5, 2, 1, 1);

        doubleSpinBox_FluxParam160E_WindowTransmission = new QDoubleSpinBox(gridLayoutWidget_16);
        doubleSpinBox_FluxParam160E_WindowTransmission->setObjectName(QString::fromUtf8("doubleSpinBox_FluxParam160E_WindowTransmission"));
        doubleSpinBox_FluxParam160E_WindowTransmission->setEnabled(false);
        doubleSpinBox_FluxParam160E_WindowTransmission->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluxParam160E_WindowTransmission->setMinimum(0.010000000000000);
        doubleSpinBox_FluxParam160E_WindowTransmission->setMaximum(1.000000000000000);
        doubleSpinBox_FluxParam160E_WindowTransmission->setSingleStep(0.010000000000000);

        gridLayout_16->addWidget(doubleSpinBox_FluxParam160E_WindowTransmission, 2, 2, 1, 1);

        label_121 = new QLabel(gridLayoutWidget_16);
        label_121->setObjectName(QString::fromUtf8("label_121"));
        label_121->setMaximumSize(QSize(16777215, 20));
        label_121->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_16->addWidget(label_121, 3, 0, 1, 1);

        label_123 = new QLabel(gridLayoutWidget_16);
        label_123->setObjectName(QString::fromUtf8("label_123"));
        label_123->setMaximumSize(QSize(16777215, 20));
        label_123->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_16->addWidget(label_123, 5, 0, 1, 1);

        pushButton_GetFluxParameters_160E = new QPushButton(gridLayoutWidget_16);
        pushButton_GetFluxParameters_160E->setObjectName(QString::fromUtf8("pushButton_GetFluxParameters_160E"));
        pushButton_GetFluxParameters_160E->setMinimumSize(QSize(0, 220));
        pushButton_GetFluxParameters_160E->setMaximumSize(QSize(30, 16777215));

        gridLayout_16->addWidget(pushButton_GetFluxParameters_160E, 0, 1, 8, 1);

        pushButton_SetFluxParameters_160E = new QPushButton(gridLayoutWidget_16);
        pushButton_SetFluxParameters_160E->setObjectName(QString::fromUtf8("pushButton_SetFluxParameters_160E"));
        pushButton_SetFluxParameters_160E->setEnabled(false);
        pushButton_SetFluxParameters_160E->setMinimumSize(QSize(0, 220));
        pushButton_SetFluxParameters_160E->setMaximumSize(QSize(30, 16777215));

        gridLayout_16->addWidget(pushButton_SetFluxParameters_160E, 0, 5, 8, 1);

        label_7 = new QLabel(gridLayoutWidget_16);
        label_7->setObjectName(QString::fromUtf8("label_7"));
        label_7->setMaximumSize(QSize(16777215, 20));
        label_7->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_16->addWidget(label_7, 0, 0, 1, 1);

        label_127 = new QLabel(gridLayoutWidget_16);
        label_127->setObjectName(QString::fromUtf8("label_127"));

        gridLayout_16->addWidget(label_127, 5, 3, 1, 1);

        label_128 = new QLabel(gridLayoutWidget_16);
        label_128->setObjectName(QString::fromUtf8("label_128"));

        gridLayout_16->addWidget(label_128, 7, 3, 1, 1);

        label_125 = new QLabel(gridLayoutWidget_16);
        label_125->setObjectName(QString::fromUtf8("label_125"));

        gridLayout_16->addWidget(label_125, 3, 3, 1, 1);

        label_124 = new QLabel(gridLayoutWidget_16);
        label_124->setObjectName(QString::fromUtf8("label_124"));
        label_124->setMaximumSize(QSize(16777215, 20));
        label_124->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_16->addWidget(label_124, 6, 0, 1, 1);

        lineEdit_FluxParam160E_SceneEmissivityRange = new QLineEdit(gridLayoutWidget_16);
        lineEdit_FluxParam160E_SceneEmissivityRange->setObjectName(QString::fromUtf8("lineEdit_FluxParam160E_SceneEmissivityRange"));
        lineEdit_FluxParam160E_SceneEmissivityRange->setEnabled(false);
        lineEdit_FluxParam160E_SceneEmissivityRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluxParam160E_SceneEmissivityRange->setReadOnly(true);

        gridLayout_16->addWidget(lineEdit_FluxParam160E_SceneEmissivityRange, 0, 4, 1, 1);

        doubleSpinBox_FluxParam160E_AtmosphericTransmission = new QDoubleSpinBox(gridLayoutWidget_16);
        doubleSpinBox_FluxParam160E_AtmosphericTransmission->setObjectName(QString::fromUtf8("doubleSpinBox_FluxParam160E_AtmosphericTransmission"));
        doubleSpinBox_FluxParam160E_AtmosphericTransmission->setEnabled(false);
        doubleSpinBox_FluxParam160E_AtmosphericTransmission->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluxParam160E_AtmosphericTransmission->setMinimum(0.010000000000000);
        doubleSpinBox_FluxParam160E_AtmosphericTransmission->setMaximum(1.000000000000000);
        doubleSpinBox_FluxParam160E_AtmosphericTransmission->setSingleStep(0.010000000000000);

        gridLayout_16->addWidget(doubleSpinBox_FluxParam160E_AtmosphericTransmission, 4, 2, 1, 1);

        doubleSpinBox_FluxParam160E_WindowReflection = new QDoubleSpinBox(gridLayoutWidget_16);
        doubleSpinBox_FluxParam160E_WindowReflection->setObjectName(QString::fromUtf8("doubleSpinBox_FluxParam160E_WindowReflection"));
        doubleSpinBox_FluxParam160E_WindowReflection->setEnabled(false);
        doubleSpinBox_FluxParam160E_WindowReflection->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluxParam160E_WindowReflection->setMaximum(0.000000000000000);
        doubleSpinBox_FluxParam160E_WindowReflection->setSingleStep(0.010000000000000);

        gridLayout_16->addWidget(doubleSpinBox_FluxParam160E_WindowReflection, 6, 2, 1, 1);

        label_120 = new QLabel(gridLayoutWidget_16);
        label_120->setObjectName(QString::fromUtf8("label_120"));
        label_120->setMaximumSize(QSize(16777215, 20));
        label_120->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_16->addWidget(label_120, 2, 0, 1, 1);

        label_9 = new QLabel(gridLayoutWidget_16);
        label_9->setObjectName(QString::fromUtf8("label_9"));
        label_9->setMaximumSize(QSize(16777215, 20));
        label_9->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_16->addWidget(label_9, 1, 0, 1, 1);

        label_126 = new QLabel(gridLayoutWidget_16);
        label_126->setObjectName(QString::fromUtf8("label_126"));

        gridLayout_16->addWidget(label_126, 1, 3, 1, 1);

        lineEdit_FluxParam160E_WindowTemperatureRange = new QLineEdit(gridLayoutWidget_16);
        lineEdit_FluxParam160E_WindowTemperatureRange->setObjectName(QString::fromUtf8("lineEdit_FluxParam160E_WindowTemperatureRange"));
        lineEdit_FluxParam160E_WindowTemperatureRange->setEnabled(false);
        lineEdit_FluxParam160E_WindowTemperatureRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluxParam160E_WindowTemperatureRange->setReadOnly(true);

        gridLayout_16->addWidget(lineEdit_FluxParam160E_WindowTemperatureRange, 3, 4, 1, 1);

        doubleSpinBox_FluxParam160E_SceneEmissivity = new QDoubleSpinBox(gridLayoutWidget_16);
        doubleSpinBox_FluxParam160E_SceneEmissivity->setObjectName(QString::fromUtf8("doubleSpinBox_FluxParam160E_SceneEmissivity"));
        doubleSpinBox_FluxParam160E_SceneEmissivity->setEnabled(false);
        doubleSpinBox_FluxParam160E_SceneEmissivity->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluxParam160E_SceneEmissivity->setMinimum(0.010000000000000);
        doubleSpinBox_FluxParam160E_SceneEmissivity->setMaximum(1.000000000000000);
        doubleSpinBox_FluxParam160E_SceneEmissivity->setSingleStep(0.010000000000000);

        gridLayout_16->addWidget(doubleSpinBox_FluxParam160E_SceneEmissivity, 0, 2, 1, 1);

        doubleSpinBox_FluxParam160E_BackgroundTemperature = new QDoubleSpinBox(gridLayoutWidget_16);
        doubleSpinBox_FluxParam160E_BackgroundTemperature->setObjectName(QString::fromUtf8("doubleSpinBox_FluxParam160E_BackgroundTemperature"));
        doubleSpinBox_FluxParam160E_BackgroundTemperature->setEnabled(false);
        doubleSpinBox_FluxParam160E_BackgroundTemperature->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluxParam160E_BackgroundTemperature->setMinimum(-273.149999999999977);
        doubleSpinBox_FluxParam160E_BackgroundTemperature->setMaximum(382.199999999999989);
        doubleSpinBox_FluxParam160E_BackgroundTemperature->setSingleStep(0.010000000000000);

        gridLayout_16->addWidget(doubleSpinBox_FluxParam160E_BackgroundTemperature, 1, 2, 1, 1);

        doubleSpinBox_FluxParam160E_WindowReflectedTemperature = new QDoubleSpinBox(gridLayoutWidget_16);
        doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setObjectName(QString::fromUtf8("doubleSpinBox_FluxParam160E_WindowReflectedTemperature"));
        doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setEnabled(false);
        doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setMinimum(-273.149999999999977);
        doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setMaximum(382.199999999999989);
        doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setSingleStep(0.010000000000000);

        gridLayout_16->addWidget(doubleSpinBox_FluxParam160E_WindowReflectedTemperature, 7, 2, 1, 1);

        label_8 = new QLabel(gridLayoutWidget_16);
        label_8->setObjectName(QString::fromUtf8("label_8"));
        label_8->setMaximumSize(QSize(16777215, 20));
        label_8->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_16->addWidget(label_8, 7, 0, 1, 1);

        doubleSpinBox_FluxParam160E_WindowTemperature = new QDoubleSpinBox(gridLayoutWidget_16);
        doubleSpinBox_FluxParam160E_WindowTemperature->setObjectName(QString::fromUtf8("doubleSpinBox_FluxParam160E_WindowTemperature"));
        doubleSpinBox_FluxParam160E_WindowTemperature->setEnabled(false);
        doubleSpinBox_FluxParam160E_WindowTemperature->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);
        doubleSpinBox_FluxParam160E_WindowTemperature->setMinimum(-273.149999999999977);
        doubleSpinBox_FluxParam160E_WindowTemperature->setMaximum(382.199999999999989);
        doubleSpinBox_FluxParam160E_WindowTemperature->setSingleStep(0.010000000000000);

        gridLayout_16->addWidget(doubleSpinBox_FluxParam160E_WindowTemperature, 3, 2, 1, 1);

        lineEdit_FluxParam160E_BackgroundTemperatureRange = new QLineEdit(gridLayoutWidget_16);
        lineEdit_FluxParam160E_BackgroundTemperatureRange->setObjectName(QString::fromUtf8("lineEdit_FluxParam160E_BackgroundTemperatureRange"));
        lineEdit_FluxParam160E_BackgroundTemperatureRange->setEnabled(false);
        lineEdit_FluxParam160E_BackgroundTemperatureRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluxParam160E_BackgroundTemperatureRange->setReadOnly(true);

        gridLayout_16->addWidget(lineEdit_FluxParam160E_BackgroundTemperatureRange, 1, 4, 1, 1);

        lineEdit_FluxParam160E_WindowTransmissionRange = new QLineEdit(gridLayoutWidget_16);
        lineEdit_FluxParam160E_WindowTransmissionRange->setObjectName(QString::fromUtf8("lineEdit_FluxParam160E_WindowTransmissionRange"));
        lineEdit_FluxParam160E_WindowTransmissionRange->setEnabled(false);
        lineEdit_FluxParam160E_WindowTransmissionRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluxParam160E_WindowTransmissionRange->setReadOnly(true);

        gridLayout_16->addWidget(lineEdit_FluxParam160E_WindowTransmissionRange, 2, 4, 1, 1);

        lineEdit_FluxParam160E_AtmosphericTransmissionRange = new QLineEdit(gridLayoutWidget_16);
        lineEdit_FluxParam160E_AtmosphericTransmissionRange->setObjectName(QString::fromUtf8("lineEdit_FluxParam160E_AtmosphericTransmissionRange"));
        lineEdit_FluxParam160E_AtmosphericTransmissionRange->setEnabled(false);
        lineEdit_FluxParam160E_AtmosphericTransmissionRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluxParam160E_AtmosphericTransmissionRange->setReadOnly(true);

        gridLayout_16->addWidget(lineEdit_FluxParam160E_AtmosphericTransmissionRange, 4, 4, 1, 1);

        lineEdit_FluxParam160E_AtmosphericTemperatureRange = new QLineEdit(gridLayoutWidget_16);
        lineEdit_FluxParam160E_AtmosphericTemperatureRange->setObjectName(QString::fromUtf8("lineEdit_FluxParam160E_AtmosphericTemperatureRange"));
        lineEdit_FluxParam160E_AtmosphericTemperatureRange->setEnabled(false);
        lineEdit_FluxParam160E_AtmosphericTemperatureRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluxParam160E_AtmosphericTemperatureRange->setReadOnly(true);

        gridLayout_16->addWidget(lineEdit_FluxParam160E_AtmosphericTemperatureRange, 5, 4, 1, 1);

        lineEdit_FluxParam160E_WindowReflectionRange = new QLineEdit(gridLayoutWidget_16);
        lineEdit_FluxParam160E_WindowReflectionRange->setObjectName(QString::fromUtf8("lineEdit_FluxParam160E_WindowReflectionRange"));
        lineEdit_FluxParam160E_WindowReflectionRange->setEnabled(false);
        lineEdit_FluxParam160E_WindowReflectionRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluxParam160E_WindowReflectionRange->setReadOnly(true);

        gridLayout_16->addWidget(lineEdit_FluxParam160E_WindowReflectionRange, 6, 4, 1, 1);

        lineEdit_FluxParam160E_WindowReflectedTemperatureRange = new QLineEdit(gridLayoutWidget_16);
        lineEdit_FluxParam160E_WindowReflectedTemperatureRange->setObjectName(QString::fromUtf8("lineEdit_FluxParam160E_WindowReflectedTemperatureRange"));
        lineEdit_FluxParam160E_WindowReflectedTemperatureRange->setEnabled(false);
        lineEdit_FluxParam160E_WindowReflectedTemperatureRange->setAlignment(Qt::AlignCenter);
        lineEdit_FluxParam160E_WindowReflectedTemperatureRange->setReadOnly(true);

        gridLayout_16->addWidget(lineEdit_FluxParam160E_WindowReflectedTemperatureRange, 7, 4, 1, 1);

        groupBox_12 = new QGroupBox(page_2);
        groupBox_12->setObjectName(QString::fromUtf8("groupBox_12"));
        groupBox_12->setGeometry(QRect(460, 0, 271, 111));
        gridLayoutWidget_17 = new QWidget(groupBox_12);
        gridLayoutWidget_17->setObjectName(QString::fromUtf8("gridLayoutWidget_17"));
        gridLayoutWidget_17->setGeometry(QRect(10, 20, 254, 81));
        gridLayout_17 = new QGridLayout(gridLayoutWidget_17);
        gridLayout_17->setObjectName(QString::fromUtf8("gridLayout_17"));
        gridLayout_17->setContentsMargins(0, 0, 0, 0);
        radioButton_GainModeStateAuto_160E = new QRadioButton(gridLayoutWidget_17);
        radioButton_GainModeStateAuto_160E->setObjectName(QString::fromUtf8("radioButton_GainModeStateAuto_160E"));

        gridLayout_17->addWidget(radioButton_GainModeStateAuto_160E, 2, 0, 1, 1);

        radioButton_GainModeStateLow_160E = new QRadioButton(gridLayoutWidget_17);
        radioButton_GainModeStateLow_160E->setObjectName(QString::fromUtf8("radioButton_GainModeStateLow_160E"));

        gridLayout_17->addWidget(radioButton_GainModeStateLow_160E, 1, 0, 1, 1);

        radioButton_GainModeStateHigh_160E = new QRadioButton(gridLayoutWidget_17);
        radioButton_GainModeStateHigh_160E->setObjectName(QString::fromUtf8("radioButton_GainModeStateHigh_160E"));

        gridLayout_17->addWidget(radioButton_GainModeStateHigh_160E, 0, 0, 1, 1);

        pushButton_SetGainModeState_160E = new QPushButton(gridLayoutWidget_17);
        pushButton_SetGainModeState_160E->setObjectName(QString::fromUtf8("pushButton_SetGainModeState_160E"));

        gridLayout_17->addWidget(pushButton_SetGainModeState_160E, 0, 2, 3, 1);

        pushButton_GetGainModeState_160E = new QPushButton(gridLayoutWidget_17);
        pushButton_GetGainModeState_160E->setObjectName(QString::fromUtf8("pushButton_GetGainModeState_160E"));

        gridLayout_17->addWidget(pushButton_GetGainModeState_160E, 0, 1, 3, 1);

        groupBox_13 = new QGroupBox(page_2);
        groupBox_13->setObjectName(QString::fromUtf8("groupBox_13"));
        groupBox_13->setGeometry(QRect(460, 130, 271, 80));
        gridLayoutWidget_18 = new QWidget(groupBox_13);
        gridLayoutWidget_18->setObjectName(QString::fromUtf8("gridLayoutWidget_18"));
        gridLayoutWidget_18->setGeometry(QRect(10, 10, 251, 61));
        gridLayout_18 = new QGridLayout(gridLayoutWidget_18);
        gridLayout_18->setObjectName(QString::fromUtf8("gridLayout_18"));
        gridLayout_18->setContentsMargins(0, 0, 0, 0);
        radioButton_FlatFieldCorrectionAutomatic_160E = new QRadioButton(gridLayoutWidget_18);
        radioButton_FlatFieldCorrectionAutomatic_160E->setObjectName(QString::fromUtf8("radioButton_FlatFieldCorrectionAutomatic_160E"));

        gridLayout_18->addWidget(radioButton_FlatFieldCorrectionAutomatic_160E, 0, 0, 1, 1);

        pushButton_GetFlatFieldCorrectionMode_160E = new QPushButton(gridLayoutWidget_18);
        pushButton_GetFlatFieldCorrectionMode_160E->setObjectName(QString::fromUtf8("pushButton_GetFlatFieldCorrectionMode_160E"));

        gridLayout_18->addWidget(pushButton_GetFlatFieldCorrectionMode_160E, 0, 1, 1, 1);

        radioButton_FlatFieldCorrectionManual_160E = new QRadioButton(gridLayoutWidget_18);
        radioButton_FlatFieldCorrectionManual_160E->setObjectName(QString::fromUtf8("radioButton_FlatFieldCorrectionManual_160E"));

        gridLayout_18->addWidget(radioButton_FlatFieldCorrectionManual_160E, 1, 0, 1, 1);

        pushButton_SetFlatFieldCorrectionMode_160E = new QPushButton(gridLayoutWidget_18);
        pushButton_SetFlatFieldCorrectionMode_160E->setObjectName(QString::fromUtf8("pushButton_SetFlatFieldCorrectionMode_160E"));

        gridLayout_18->addWidget(pushButton_SetFlatFieldCorrectionMode_160E, 0, 2, 1, 1);

        pushButton_RunFlatFieldCorrection_160E = new QPushButton(gridLayoutWidget_18);
        pushButton_RunFlatFieldCorrection_160E->setObjectName(QString::fromUtf8("pushButton_RunFlatFieldCorrection_160E"));

        gridLayout_18->addWidget(pushButton_RunFlatFieldCorrection_160E, 1, 1, 1, 2);

        pushButton_RestoreDefaultFluxParameters_160E = new QPushButton(page_2);
        pushButton_RestoreDefaultFluxParameters_160E->setObjectName(QString::fromUtf8("pushButton_RestoreDefaultFluxParameters_160E"));
        pushButton_RestoreDefaultFluxParameters_160E->setGeometry(QRect(460, 220, 261, 31));
        stackedWidget_SensorControl->addWidget(page_2);
        tabWidget_Control->addTab(tabSensorControl, QString());
        tabRegionOfInterests = new QWidget();
        tabRegionOfInterests->setObjectName(QString::fromUtf8("tabRegionOfInterests"));
        gridLayoutWidget_12 = new QWidget(tabRegionOfInterests);
        gridLayoutWidget_12->setObjectName(QString::fromUtf8("gridLayoutWidget_12"));
        gridLayoutWidget_12->setGeometry(QRect(10, 20, 181, 51));
        gridLayout_12 = new QGridLayout(gridLayoutWidget_12);
        gridLayout_12->setObjectName(QString::fromUtf8("gridLayout_12"));
        gridLayout_12->setContentsMargins(0, 0, 0, 0);
        comboBox_ListRoi = new QComboBox(gridLayoutWidget_12);
        comboBox_ListRoi->setObjectName(QString::fromUtf8("comboBox_ListRoi"));

        gridLayout_12->addWidget(comboBox_ListRoi, 1, 0, 1, 1);

        label_42 = new QLabel(gridLayoutWidget_12);
        label_42->setObjectName(QString::fromUtf8("label_42"));

        gridLayout_12->addWidget(label_42, 0, 0, 1, 1);

        pushButton_RemoveRoiItem = new QPushButton(gridLayoutWidget_12);
        pushButton_RemoveRoiItem->setObjectName(QString::fromUtf8("pushButton_RemoveRoiItem"));
        pushButton_RemoveRoiItem->setMaximumSize(QSize(60, 16777215));

        gridLayout_12->addWidget(pushButton_RemoveRoiItem, 1, 1, 1, 1);

        gridLayoutWidget_13 = new QWidget(tabRegionOfInterests);
        gridLayoutWidget_13->setObjectName(QString::fromUtf8("gridLayoutWidget_13"));
        gridLayoutWidget_13->setGeometry(QRect(10, 80, 441, 111));
        gridLayout_13 = new QGridLayout(gridLayoutWidget_13);
        gridLayout_13->setObjectName(QString::fromUtf8("gridLayout_13"));
        gridLayout_13->setContentsMargins(0, 0, 0, 0);
        lineEdit_LineY2 = new QLineEdit(gridLayoutWidget_13);
        lineEdit_LineY2->setObjectName(QString::fromUtf8("lineEdit_LineY2"));
        lineEdit_LineY2->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_LineY2, 1, 8, 1, 1);

        label_52 = new QLabel(gridLayoutWidget_13);
        label_52->setObjectName(QString::fromUtf8("label_52"));
        label_52->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_52, 3, 3, 1, 1);

        label_48 = new QLabel(gridLayoutWidget_13);
        label_48->setObjectName(QString::fromUtf8("label_48"));
        label_48->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_48, 1, 7, 1, 1);

        lineEdit_SpotY = new QLineEdit(gridLayoutWidget_13);
        lineEdit_SpotY->setObjectName(QString::fromUtf8("lineEdit_SpotY"));
        lineEdit_SpotY->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_SpotY, 0, 4, 1, 1);

        label_54 = new QLabel(gridLayoutWidget_13);
        label_54->setObjectName(QString::fromUtf8("label_54"));
        label_54->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_54, 3, 5, 1, 1);

        radioButton_RoiLine = new QRadioButton(gridLayoutWidget_13);
        radioButton_RoiLine->setObjectName(QString::fromUtf8("radioButton_RoiLine"));

        gridLayout_13->addWidget(radioButton_RoiLine, 1, 0, 1, 1);

        label_44 = new QLabel(gridLayoutWidget_13);
        label_44->setObjectName(QString::fromUtf8("label_44"));
        label_44->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_44, 0, 3, 1, 1);

        label_53 = new QLabel(gridLayoutWidget_13);
        label_53->setObjectName(QString::fromUtf8("label_53"));
        label_53->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_53, 2, 5, 1, 1);

        label_46 = new QLabel(gridLayoutWidget_13);
        label_46->setObjectName(QString::fromUtf8("label_46"));
        label_46->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_46, 1, 3, 1, 1);

        lineEdit_SpotX = new QLineEdit(gridLayoutWidget_13);
        lineEdit_SpotX->setObjectName(QString::fromUtf8("lineEdit_SpotX"));
        lineEdit_SpotX->setMinimumSize(QSize(30, 0));
        lineEdit_SpotX->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_SpotX, 0, 2, 1, 1);

        radioButton_RoiRectangle = new QRadioButton(gridLayoutWidget_13);
        radioButton_RoiRectangle->setObjectName(QString::fromUtf8("radioButton_RoiRectangle"));

        gridLayout_13->addWidget(radioButton_RoiRectangle, 2, 0, 1, 1);

        label_43 = new QLabel(gridLayoutWidget_13);
        label_43->setObjectName(QString::fromUtf8("label_43"));
        label_43->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_43, 0, 1, 1, 1);

        label_55 = new QLabel(gridLayoutWidget_13);
        label_55->setObjectName(QString::fromUtf8("label_55"));
        label_55->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_55, 2, 7, 1, 1);

        label_49 = new QLabel(gridLayoutWidget_13);
        label_49->setObjectName(QString::fromUtf8("label_49"));
        label_49->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_49, 2, 1, 1, 1);

        radioButton_RoiSpot = new QRadioButton(gridLayoutWidget_13);
        radioButton_RoiSpot->setObjectName(QString::fromUtf8("radioButton_RoiSpot"));

        gridLayout_13->addWidget(radioButton_RoiSpot, 0, 0, 1, 1);

        label_50 = new QLabel(gridLayoutWidget_13);
        label_50->setObjectName(QString::fromUtf8("label_50"));
        label_50->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_50, 3, 1, 1, 1);

        radioButton_RoiEllipse = new QRadioButton(gridLayoutWidget_13);
        radioButton_RoiEllipse->setObjectName(QString::fromUtf8("radioButton_RoiEllipse"));

        gridLayout_13->addWidget(radioButton_RoiEllipse, 3, 0, 1, 1);

        label_56 = new QLabel(gridLayoutWidget_13);
        label_56->setObjectName(QString::fromUtf8("label_56"));
        label_56->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_56, 3, 7, 1, 1);

        label_45 = new QLabel(gridLayoutWidget_13);
        label_45->setObjectName(QString::fromUtf8("label_45"));
        label_45->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_45, 1, 1, 1, 1);

        label_47 = new QLabel(gridLayoutWidget_13);
        label_47->setObjectName(QString::fromUtf8("label_47"));
        label_47->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_47, 1, 5, 1, 1);

        pushButton_AddRoiItem = new QPushButton(gridLayoutWidget_13);
        pushButton_AddRoiItem->setObjectName(QString::fromUtf8("pushButton_AddRoiItem"));
        pushButton_AddRoiItem->setMinimumSize(QSize(0, 100));

        gridLayout_13->addWidget(pushButton_AddRoiItem, 0, 9, 4, 1);

        label_51 = new QLabel(gridLayoutWidget_13);
        label_51->setObjectName(QString::fromUtf8("label_51"));
        label_51->setAlignment(Qt::AlignCenter);

        gridLayout_13->addWidget(label_51, 2, 3, 1, 1);

        lineEdit_LineX2 = new QLineEdit(gridLayoutWidget_13);
        lineEdit_LineX2->setObjectName(QString::fromUtf8("lineEdit_LineX2"));
        lineEdit_LineX2->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_LineX2, 1, 6, 1, 1);

        lineEdit_LineX1 = new QLineEdit(gridLayoutWidget_13);
        lineEdit_LineX1->setObjectName(QString::fromUtf8("lineEdit_LineX1"));
        lineEdit_LineX1->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_LineX1, 1, 2, 1, 1);

        lineEdit_LineY1 = new QLineEdit(gridLayoutWidget_13);
        lineEdit_LineY1->setObjectName(QString::fromUtf8("lineEdit_LineY1"));
        lineEdit_LineY1->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_LineY1, 1, 4, 1, 1);

        lineEdit_RectangleX = new QLineEdit(gridLayoutWidget_13);
        lineEdit_RectangleX->setObjectName(QString::fromUtf8("lineEdit_RectangleX"));
        lineEdit_RectangleX->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_RectangleX, 2, 2, 1, 1);

        lineEdit_EllipseX = new QLineEdit(gridLayoutWidget_13);
        lineEdit_EllipseX->setObjectName(QString::fromUtf8("lineEdit_EllipseX"));
        lineEdit_EllipseX->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_EllipseX, 3, 2, 1, 1);

        lineEdit_RectangleY = new QLineEdit(gridLayoutWidget_13);
        lineEdit_RectangleY->setObjectName(QString::fromUtf8("lineEdit_RectangleY"));
        lineEdit_RectangleY->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_RectangleY, 2, 4, 1, 1);

        lineEdit_EllipseY = new QLineEdit(gridLayoutWidget_13);
        lineEdit_EllipseY->setObjectName(QString::fromUtf8("lineEdit_EllipseY"));
        lineEdit_EllipseY->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_EllipseY, 3, 4, 1, 1);

        lineEdit_RectangleW = new QLineEdit(gridLayoutWidget_13);
        lineEdit_RectangleW->setObjectName(QString::fromUtf8("lineEdit_RectangleW"));
        lineEdit_RectangleW->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_RectangleW, 2, 6, 1, 1);

        lineEdit_EllipseW = new QLineEdit(gridLayoutWidget_13);
        lineEdit_EllipseW->setObjectName(QString::fromUtf8("lineEdit_EllipseW"));
        lineEdit_EllipseW->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_EllipseW, 3, 6, 1, 1);

        lineEdit_RectangleH = new QLineEdit(gridLayoutWidget_13);
        lineEdit_RectangleH->setObjectName(QString::fromUtf8("lineEdit_RectangleH"));
        lineEdit_RectangleH->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_RectangleH, 2, 8, 1, 1);

        lineEdit_EllipseH = new QLineEdit(gridLayoutWidget_13);
        lineEdit_EllipseH->setObjectName(QString::fromUtf8("lineEdit_EllipseH"));
        lineEdit_EllipseH->setMaximumSize(QSize(30, 16777215));

        gridLayout_13->addWidget(lineEdit_EllipseH, 3, 8, 1, 1);

        tabWidget_Control->addTab(tabRegionOfInterests, QString());
        tabWidget_Product = new QTabWidget(centralwidget);
        tabWidget_Product->setObjectName(QString::fromUtf8("tabWidget_Product"));
        tabWidget_Product->setGeometry(QRect(757, 0, 341, 731));
        tab_3 = new QWidget();
        tab_3->setObjectName(QString::fromUtf8("tab_3"));
        groupBox = new QGroupBox(tab_3);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        groupBox->setGeometry(QRect(0, 10, 331, 141));
        gridLayoutWidget_4 = new QWidget(groupBox);
        gridLayoutWidget_4->setObjectName(QString::fromUtf8("gridLayoutWidget_4"));
        gridLayoutWidget_4->setGeometry(QRect(10, 20, 311, 112));
        gridLayout_4 = new QGridLayout(gridLayoutWidget_4);
        gridLayout_4->setObjectName(QString::fromUtf8("gridLayout_4"));
        gridLayout_4->setContentsMargins(0, 0, 0, 0);
        label_ProductModelName = new QLabel(gridLayoutWidget_4);
        label_ProductModelName->setObjectName(QString::fromUtf8("label_ProductModelName"));

        gridLayout_4->addWidget(label_ProductModelName, 0, 1, 1, 1);

        label_13 = new QLabel(gridLayoutWidget_4);
        label_13->setObjectName(QString::fromUtf8("label_13"));
        label_13->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_4->addWidget(label_13, 1, 0, 1, 1);

        label_HardwareVersion = new QLabel(gridLayoutWidget_4);
        label_HardwareVersion->setObjectName(QString::fromUtf8("label_HardwareVersion"));

        gridLayout_4->addWidget(label_HardwareVersion, 2, 1, 1, 1);

        label_FirmwareVersion = new QLabel(gridLayoutWidget_4);
        label_FirmwareVersion->setObjectName(QString::fromUtf8("label_FirmwareVersion"));

        gridLayout_4->addWidget(label_FirmwareVersion, 4, 1, 1, 1);

        label_ProductSerialNumber = new QLabel(gridLayoutWidget_4);
        label_ProductSerialNumber->setObjectName(QString::fromUtf8("label_ProductSerialNumber"));

        gridLayout_4->addWidget(label_ProductSerialNumber, 1, 1, 1, 1);

        label_14 = new QLabel(gridLayoutWidget_4);
        label_14->setObjectName(QString::fromUtf8("label_14"));
        label_14->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_4->addWidget(label_14, 2, 0, 1, 1);

        label_16 = new QLabel(gridLayoutWidget_4);
        label_16->setObjectName(QString::fromUtf8("label_16"));
        label_16->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_4->addWidget(label_16, 4, 0, 1, 1);

        label_BootloaderVersion = new QLabel(gridLayoutWidget_4);
        label_BootloaderVersion->setObjectName(QString::fromUtf8("label_BootloaderVersion"));

        gridLayout_4->addWidget(label_BootloaderVersion, 3, 1, 1, 1);

        label_12 = new QLabel(gridLayoutWidget_4);
        label_12->setObjectName(QString::fromUtf8("label_12"));
        label_12->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_4->addWidget(label_12, 0, 0, 1, 1);

        label_15 = new QLabel(gridLayoutWidget_4);
        label_15->setObjectName(QString::fromUtf8("label_15"));
        label_15->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_4->addWidget(label_15, 3, 0, 1, 1);

        pushButton_GetProductInformation = new QPushButton(gridLayoutWidget_4);
        pushButton_GetProductInformation->setObjectName(QString::fromUtf8("pushButton_GetProductInformation"));
        pushButton_GetProductInformation->setMinimumSize(QSize(0, 110));
        pushButton_GetProductInformation->setMaximumSize(QSize(40, 16777215));

        gridLayout_4->addWidget(pushButton_GetProductInformation, 0, 2, 5, 1);

        groupBox_2 = new QGroupBox(tab_3);
        groupBox_2->setObjectName(QString::fromUtf8("groupBox_2"));
        groupBox_2->setGeometry(QRect(0, 160, 331, 91));
        gridLayoutWidget_5 = new QWidget(groupBox_2);
        gridLayoutWidget_5->setObjectName(QString::fromUtf8("gridLayoutWidget_5"));
        gridLayoutWidget_5->setGeometry(QRect(10, 20, 311, 62));
        gridLayout_5 = new QGridLayout(gridLayoutWidget_5);
        gridLayout_5->setObjectName(QString::fromUtf8("gridLayout_5"));
        gridLayout_5->setContentsMargins(0, 0, 0, 0);
        pushButton_GetSensorInformation = new QPushButton(gridLayoutWidget_5);
        pushButton_GetSensorInformation->setObjectName(QString::fromUtf8("pushButton_GetSensorInformation"));
        pushButton_GetSensorInformation->setMinimumSize(QSize(0, 60));
        pushButton_GetSensorInformation->setMaximumSize(QSize(40, 16777215));

        gridLayout_5->addWidget(pushButton_GetSensorInformation, 0, 2, 3, 1);

        label_17 = new QLabel(gridLayoutWidget_5);
        label_17->setObjectName(QString::fromUtf8("label_17"));
        label_17->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_5->addWidget(label_17, 1, 0, 1, 1);

        label_20 = new QLabel(gridLayoutWidget_5);
        label_20->setObjectName(QString::fromUtf8("label_20"));
        label_20->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_5->addWidget(label_20, 0, 0, 1, 1);

        label_SensorSerialNumber = new QLabel(gridLayoutWidget_5);
        label_SensorSerialNumber->setObjectName(QString::fromUtf8("label_SensorSerialNumber"));

        gridLayout_5->addWidget(label_SensorSerialNumber, 1, 1, 1, 1);

        label_SensorModelName = new QLabel(gridLayoutWidget_5);
        label_SensorModelName->setObjectName(QString::fromUtf8("label_SensorModelName"));

        gridLayout_5->addWidget(label_SensorModelName, 0, 1, 1, 1);

        label_18 = new QLabel(gridLayoutWidget_5);
        label_18->setObjectName(QString::fromUtf8("label_18"));
        label_18->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_5->addWidget(label_18, 2, 0, 1, 1);

        label_SensorUptime = new QLabel(gridLayoutWidget_5);
        label_SensorUptime->setObjectName(QString::fromUtf8("label_SensorUptime"));

        gridLayout_5->addWidget(label_SensorUptime, 2, 1, 1, 1);

        groupBox_3 = new QGroupBox(tab_3);
        groupBox_3->setObjectName(QString::fromUtf8("groupBox_3"));
        groupBox_3->setGeometry(QRect(0, 260, 331, 281));
        gridLayoutWidget_7 = new QWidget(groupBox_3);
        gridLayoutWidget_7->setObjectName(QString::fromUtf8("gridLayoutWidget_7"));
        gridLayoutWidget_7->setGeometry(QRect(10, 20, 311, 251));
        gridLayout_7 = new QGridLayout(gridLayoutWidget_7);
        gridLayout_7->setObjectName(QString::fromUtf8("gridLayout_7"));
        gridLayout_7->setContentsMargins(0, 0, 0, 0);
        label_VendorName = new QLabel(gridLayoutWidget_7);
        label_VendorName->setObjectName(QString::fromUtf8("label_VendorName"));

        gridLayout_7->addWidget(label_VendorName, 1, 1, 1, 1);

        label_ProductName = new QLabel(gridLayoutWidget_7);
        label_ProductName->setObjectName(QString::fromUtf8("label_ProductName"));

        gridLayout_7->addWidget(label_ProductName, 2, 1, 1, 1);

        label_BinarySize = new QLabel(gridLayoutWidget_7);
        label_BinarySize->setObjectName(QString::fromUtf8("label_BinarySize"));

        gridLayout_7->addWidget(label_BinarySize, 5, 1, 1, 1);

        label_26 = new QLabel(gridLayoutWidget_7);
        label_26->setObjectName(QString::fromUtf8("label_26"));
        label_26->setMinimumSize(QSize(140, 0));
        label_26->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_7->addWidget(label_26, 3, 0, 1, 1);

        pushButton_StartSoftwareUpdate = new QPushButton(gridLayoutWidget_7);
        pushButton_StartSoftwareUpdate->setObjectName(QString::fromUtf8("pushButton_StartSoftwareUpdate"));
        pushButton_StartSoftwareUpdate->setEnabled(false);

        gridLayout_7->addWidget(pushButton_StartSoftwareUpdate, 9, 0, 1, 2);

        label_24 = new QLabel(gridLayoutWidget_7);
        label_24->setObjectName(QString::fromUtf8("label_24"));
        label_24->setMinimumSize(QSize(140, 0));
        label_24->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_7->addWidget(label_24, 0, 0, 1, 1);

        label_27 = new QLabel(gridLayoutWidget_7);
        label_27->setObjectName(QString::fromUtf8("label_27"));
        label_27->setMinimumSize(QSize(140, 0));
        label_27->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_7->addWidget(label_27, 4, 0, 1, 1);

        label_28 = new QLabel(gridLayoutWidget_7);
        label_28->setObjectName(QString::fromUtf8("label_28"));
        label_28->setMinimumSize(QSize(140, 0));
        label_28->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_7->addWidget(label_28, 5, 0, 1, 1);

        label_BuildTime = new QLabel(gridLayoutWidget_7);
        label_BuildTime->setObjectName(QString::fromUtf8("label_BuildTime"));

        gridLayout_7->addWidget(label_BuildTime, 4, 1, 1, 1);

        progressBar_SoftwareUpdate = new QProgressBar(gridLayoutWidget_7);
        progressBar_SoftwareUpdate->setObjectName(QString::fromUtf8("progressBar_SoftwareUpdate"));
        progressBar_SoftwareUpdate->setValue(0);
        progressBar_SoftwareUpdate->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_7->addWidget(progressBar_SoftwareUpdate, 7, 0, 1, 2);

        label_25 = new QLabel(gridLayoutWidget_7);
        label_25->setObjectName(QString::fromUtf8("label_25"));
        label_25->setMinimumSize(QSize(140, 0));
        label_25->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_7->addWidget(label_25, 2, 0, 1, 1);

        label_SoftwareVersion = new QLabel(gridLayoutWidget_7);
        label_SoftwareVersion->setObjectName(QString::fromUtf8("label_SoftwareVersion"));

        gridLayout_7->addWidget(label_SoftwareVersion, 3, 1, 1, 1);

        label_23 = new QLabel(gridLayoutWidget_7);
        label_23->setObjectName(QString::fromUtf8("label_23"));
        label_23->setMinimumSize(QSize(140, 0));
        label_23->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_7->addWidget(label_23, 1, 0, 1, 1);

        horizontalLayout_4 = new QHBoxLayout();
        horizontalLayout_4->setObjectName(QString::fromUtf8("horizontalLayout_4"));
        pushButton_SoftwareUpdateFileBrowse = new QPushButton(gridLayoutWidget_7);
        pushButton_SoftwareUpdateFileBrowse->setObjectName(QString::fromUtf8("pushButton_SoftwareUpdateFileBrowse"));

        horizontalLayout_4->addWidget(pushButton_SoftwareUpdateFileBrowse);

        lineEdit_SoftwareUpdateFilePath = new QLineEdit(gridLayoutWidget_7);
        lineEdit_SoftwareUpdateFilePath->setObjectName(QString::fromUtf8("lineEdit_SoftwareUpdateFilePath"));

        horizontalLayout_4->addWidget(lineEdit_SoftwareUpdateFilePath);


        gridLayout_7->addLayout(horizontalLayout_4, 8, 0, 1, 2);

        label_SoftwareUpdateStatus = new QLabel(gridLayoutWidget_7);
        label_SoftwareUpdateStatus->setObjectName(QString::fromUtf8("label_SoftwareUpdateStatus"));
        label_SoftwareUpdateStatus->setMaximumSize(QSize(12123123, 16777215));

        gridLayout_7->addWidget(label_SoftwareUpdateStatus, 6, 0, 1, 2);

        tabWidget_Product->addTab(tab_3, QString());
        tab_4 = new QWidget();
        tab_4->setObjectName(QString::fromUtf8("tab_4"));
        groupBox_10 = new QGroupBox(tab_4);
        groupBox_10->setObjectName(QString::fromUtf8("groupBox_10"));
        groupBox_10->setGeometry(QRect(10, 10, 311, 501));
        gridLayoutWidget_6 = new QWidget(groupBox_10);
        gridLayoutWidget_6->setObjectName(QString::fromUtf8("gridLayoutWidget_6"));
        gridLayoutWidget_6->setGeometry(QRect(10, 20, 291, 301));
        gridLayout_6 = new QGridLayout(gridLayoutWidget_6);
        gridLayout_6->setObjectName(QString::fromUtf8("gridLayout_6"));
        gridLayout_6->setContentsMargins(0, 0, 0, 0);
        label_116 = new QLabel(gridLayoutWidget_6);
        label_116->setObjectName(QString::fromUtf8("label_116"));
        label_116->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_6->addWidget(label_116, 3, 0, 1, 1);

        lineEdit_Netmask = new QLineEdit(gridLayoutWidget_6);
        lineEdit_Netmask->setObjectName(QString::fromUtf8("lineEdit_Netmask"));
        lineEdit_Netmask->setEnabled(false);

        gridLayout_6->addWidget(lineEdit_Netmask, 3, 2, 1, 1);

        lineEdit_SubDNSServer = new QLineEdit(gridLayoutWidget_6);
        lineEdit_SubDNSServer->setObjectName(QString::fromUtf8("lineEdit_SubDNSServer"));
        lineEdit_SubDNSServer->setEnabled(false);
        lineEdit_SubDNSServer->setReadOnly(true);

        gridLayout_6->addWidget(lineEdit_SubDNSServer, 6, 2, 1, 1);

        pushButton_SetNetworkConfiguration = new QPushButton(gridLayoutWidget_6);
        pushButton_SetNetworkConfiguration->setObjectName(QString::fromUtf8("pushButton_SetNetworkConfiguration"));
        pushButton_SetNetworkConfiguration->setEnabled(false);
        pushButton_SetNetworkConfiguration->setMinimumSize(QSize(30, 110));
        pushButton_SetNetworkConfiguration->setMaximumSize(QSize(50, 16777215));

        gridLayout_6->addWidget(pushButton_SetNetworkConfiguration, 1, 3, 4, 1);

        label_117 = new QLabel(gridLayoutWidget_6);
        label_117->setObjectName(QString::fromUtf8("label_117"));
        label_117->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_6->addWidget(label_117, 4, 0, 1, 1);

        label_119 = new QLabel(gridLayoutWidget_6);
        label_119->setObjectName(QString::fromUtf8("label_119"));
        label_119->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_6->addWidget(label_119, 6, 0, 1, 1);

        label_21 = new QLabel(gridLayoutWidget_6);
        label_21->setObjectName(QString::fromUtf8("label_21"));
        label_21->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_6->addWidget(label_21, 1, 0, 1, 1);

        lineEdit_MainDNSServer = new QLineEdit(gridLayoutWidget_6);
        lineEdit_MainDNSServer->setObjectName(QString::fromUtf8("lineEdit_MainDNSServer"));
        lineEdit_MainDNSServer->setEnabled(false);
        lineEdit_MainDNSServer->setReadOnly(true);

        gridLayout_6->addWidget(lineEdit_MainDNSServer, 5, 2, 1, 1);

        pushButton_GetNetworkConfiguration = new QPushButton(gridLayoutWidget_6);
        pushButton_GetNetworkConfiguration->setObjectName(QString::fromUtf8("pushButton_GetNetworkConfiguration"));
        pushButton_GetNetworkConfiguration->setEnabled(false);
        pushButton_GetNetworkConfiguration->setMinimumSize(QSize(30, 220));
        pushButton_GetNetworkConfiguration->setMaximumSize(QSize(50, 16777215));

        gridLayout_6->addWidget(pushButton_GetNetworkConfiguration, 0, 1, 7, 1);

        lineEdit_MACAddress = new QLineEdit(gridLayoutWidget_6);
        lineEdit_MACAddress->setObjectName(QString::fromUtf8("lineEdit_MACAddress"));
        lineEdit_MACAddress->setEnabled(false);
        lineEdit_MACAddress->setReadOnly(true);

        gridLayout_6->addWidget(lineEdit_MACAddress, 0, 2, 1, 1);

        lineEdit_Gateway = new QLineEdit(gridLayoutWidget_6);
        lineEdit_Gateway->setObjectName(QString::fromUtf8("lineEdit_Gateway"));
        lineEdit_Gateway->setEnabled(false);

        gridLayout_6->addWidget(lineEdit_Gateway, 4, 2, 1, 1);

        label_22 = new QLabel(gridLayoutWidget_6);
        label_22->setObjectName(QString::fromUtf8("label_22"));
        label_22->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_6->addWidget(label_22, 2, 0, 1, 1);

        pushButton_SetDefaultNetworkConfiguration = new QPushButton(gridLayoutWidget_6);
        pushButton_SetDefaultNetworkConfiguration->setObjectName(QString::fromUtf8("pushButton_SetDefaultNetworkConfiguration"));

        gridLayout_6->addWidget(pushButton_SetDefaultNetworkConfiguration, 7, 1, 1, 3);

        label_118 = new QLabel(gridLayoutWidget_6);
        label_118->setObjectName(QString::fromUtf8("label_118"));
        label_118->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_6->addWidget(label_118, 5, 0, 1, 1);

        lineEdit_IPAddress = new QLineEdit(gridLayoutWidget_6);
        lineEdit_IPAddress->setObjectName(QString::fromUtf8("lineEdit_IPAddress"));
        lineEdit_IPAddress->setEnabled(false);

        gridLayout_6->addWidget(lineEdit_IPAddress, 2, 2, 1, 1);

        comboBox_IPAssignment = new QComboBox(gridLayoutWidget_6);
        comboBox_IPAssignment->setObjectName(QString::fromUtf8("comboBox_IPAssignment"));
        comboBox_IPAssignment->setEnabled(false);

        gridLayout_6->addWidget(comboBox_IPAssignment, 1, 2, 1, 1);

        label_19 = new QLabel(gridLayoutWidget_6);
        label_19->setObjectName(QString::fromUtf8("label_19"));
        label_19->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        gridLayout_6->addWidget(label_19, 0, 0, 1, 1);

        pushButton_SystemReboot = new QPushButton(gridLayoutWidget_6);
        pushButton_SystemReboot->setObjectName(QString::fromUtf8("pushButton_SystemReboot"));

        gridLayout_6->addWidget(pushButton_SystemReboot, 8, 1, 1, 3);

        tabWidget_Product->addTab(tab_4, QString());
        label_Preview = new QLabel(centralwidget);
        label_Preview->setObjectName(QString::fromUtf8("label_Preview"));
        label_Preview->setGeometry(QRect(270, 10, 480, 360));
        QPalette palette;
        QBrush brush(QColor(0, 0, 0, 255));
        brush.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::WindowText, brush);
        QBrush brush1(QColor(202, 202, 202, 255));
        brush1.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::Button, brush1);
        QBrush brush2(QColor(255, 255, 255, 255));
        brush2.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::Light, brush2);
        QBrush brush3(QColor(228, 228, 228, 255));
        brush3.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::Midlight, brush3);
        QBrush brush4(QColor(101, 101, 101, 255));
        brush4.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::Dark, brush4);
        QBrush brush5(QColor(135, 135, 135, 255));
        brush5.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::Mid, brush5);
        palette.setBrush(QPalette::Active, QPalette::Text, brush);
        palette.setBrush(QPalette::Active, QPalette::BrightText, brush2);
        palette.setBrush(QPalette::Active, QPalette::ButtonText, brush);
        palette.setBrush(QPalette::Active, QPalette::Base, brush2);
        palette.setBrush(QPalette::Active, QPalette::Window, brush1);
        palette.setBrush(QPalette::Active, QPalette::Shadow, brush);
        palette.setBrush(QPalette::Active, QPalette::AlternateBase, brush3);
        QBrush brush6(QColor(255, 255, 220, 255));
        brush6.setStyle(Qt::SolidPattern);
        palette.setBrush(QPalette::Active, QPalette::ToolTipBase, brush6);
        palette.setBrush(QPalette::Active, QPalette::ToolTipText, brush);
        QBrush brush7(QColor(0, 0, 0, 128));
        brush7.setStyle(Qt::SolidPattern);
#if QT_VERSION >= QT_VERSION_CHECK(5, 12, 0)
        palette.setBrush(QPalette::Active, QPalette::PlaceholderText, brush7);
#endif
        palette.setBrush(QPalette::Inactive, QPalette::WindowText, brush);
        palette.setBrush(QPalette::Inactive, QPalette::Button, brush1);
        palette.setBrush(QPalette::Inactive, QPalette::Light, brush2);
        palette.setBrush(QPalette::Inactive, QPalette::Midlight, brush3);
        palette.setBrush(QPalette::Inactive, QPalette::Dark, brush4);
        palette.setBrush(QPalette::Inactive, QPalette::Mid, brush5);
        palette.setBrush(QPalette::Inactive, QPalette::Text, brush);
        palette.setBrush(QPalette::Inactive, QPalette::BrightText, brush2);
        palette.setBrush(QPalette::Inactive, QPalette::ButtonText, brush);
        palette.setBrush(QPalette::Inactive, QPalette::Base, brush2);
        palette.setBrush(QPalette::Inactive, QPalette::Window, brush1);
        palette.setBrush(QPalette::Inactive, QPalette::Shadow, brush);
        palette.setBrush(QPalette::Inactive, QPalette::AlternateBase, brush3);
        palette.setBrush(QPalette::Inactive, QPalette::ToolTipBase, brush6);
        palette.setBrush(QPalette::Inactive, QPalette::ToolTipText, brush);
#if QT_VERSION >= QT_VERSION_CHECK(5, 12, 0)
        palette.setBrush(QPalette::Inactive, QPalette::PlaceholderText, brush7);
#endif
        palette.setBrush(QPalette::Disabled, QPalette::WindowText, brush4);
        palette.setBrush(QPalette::Disabled, QPalette::Button, brush1);
        palette.setBrush(QPalette::Disabled, QPalette::Light, brush2);
        palette.setBrush(QPalette::Disabled, QPalette::Midlight, brush3);
        palette.setBrush(QPalette::Disabled, QPalette::Dark, brush4);
        palette.setBrush(QPalette::Disabled, QPalette::Mid, brush5);
        palette.setBrush(QPalette::Disabled, QPalette::Text, brush4);
        palette.setBrush(QPalette::Disabled, QPalette::BrightText, brush2);
        palette.setBrush(QPalette::Disabled, QPalette::ButtonText, brush4);
        palette.setBrush(QPalette::Disabled, QPalette::Base, brush1);
        palette.setBrush(QPalette::Disabled, QPalette::Window, brush1);
        palette.setBrush(QPalette::Disabled, QPalette::Shadow, brush);
        palette.setBrush(QPalette::Disabled, QPalette::AlternateBase, brush1);
        palette.setBrush(QPalette::Disabled, QPalette::ToolTipBase, brush6);
        palette.setBrush(QPalette::Disabled, QPalette::ToolTipText, brush);
#if QT_VERSION >= QT_VERSION_CHECK(5, 12, 0)
        palette.setBrush(QPalette::Disabled, QPalette::PlaceholderText, brush7);
#endif
        label_Preview->setPalette(palette);
        label_Preview->setAlignment(Qt::AlignCenter);
        label_Draw = new QLabel(centralwidget);
        label_Draw->setObjectName(QString::fromUtf8("label_Draw"));
        label_Draw->setGeometry(QRect(270, 10, 480, 360));
        gridLayoutWidget_3 = new QWidget(centralwidget);
        gridLayoutWidget_3->setObjectName(QString::fromUtf8("gridLayoutWidget_3"));
        gridLayoutWidget_3->setGeometry(QRect(270, 370, 481, 80));
        gridLayout_3 = new QGridLayout(gridLayoutWidget_3);
        gridLayout_3->setObjectName(QString::fromUtf8("gridLayout_3"));
        gridLayout_3->setContentsMargins(0, 0, 0, 0);
        horizontalLayout_2 = new QHBoxLayout();
        horizontalLayout_2->setObjectName(QString::fromUtf8("horizontalLayout_2"));
        label_10 = new QLabel(gridLayoutWidget_3);
        label_10->setObjectName(QString::fromUtf8("label_10"));

        horizontalLayout_2->addWidget(label_10);

        comboBox_ColorMap = new QComboBox(gridLayoutWidget_3);
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->addItem(QString());
        comboBox_ColorMap->setObjectName(QString::fromUtf8("comboBox_ColorMap"));

        horizontalLayout_2->addWidget(comboBox_ColorMap);

        checkBox_NoiseFiltering = new QCheckBox(gridLayoutWidget_3);
        checkBox_NoiseFiltering->setObjectName(QString::fromUtf8("checkBox_NoiseFiltering"));

        horizontalLayout_2->addWidget(checkBox_NoiseFiltering);

        label_11 = new QLabel(gridLayoutWidget_3);
        label_11->setObjectName(QString::fromUtf8("label_11"));

        horizontalLayout_2->addWidget(label_11);

        comboBox_TemperatureUnit = new QComboBox(gridLayoutWidget_3);
        comboBox_TemperatureUnit->addItem(QString());
        comboBox_TemperatureUnit->addItem(QString());
        comboBox_TemperatureUnit->addItem(QString());
        comboBox_TemperatureUnit->addItem(QString());
        comboBox_TemperatureUnit->setObjectName(QString::fromUtf8("comboBox_TemperatureUnit"));

        horizontalLayout_2->addWidget(comboBox_TemperatureUnit);


        gridLayout_3->addLayout(horizontalLayout_2, 3, 1, 1, 1);

        horizontalLayout_3 = new QHBoxLayout();
        horizontalLayout_3->setObjectName(QString::fromUtf8("horizontalLayout_3"));
        radioButton_ShapeCursor = new QRadioButton(gridLayoutWidget_3);
        radioButton_ShapeCursor->setObjectName(QString::fromUtf8("radioButton_ShapeCursor"));

        horizontalLayout_3->addWidget(radioButton_ShapeCursor);

        radioButton_ShapeSpot = new QRadioButton(gridLayoutWidget_3);
        radioButton_ShapeSpot->setObjectName(QString::fromUtf8("radioButton_ShapeSpot"));

        horizontalLayout_3->addWidget(radioButton_ShapeSpot);

        radioButton_ShapeLine = new QRadioButton(gridLayoutWidget_3);
        radioButton_ShapeLine->setObjectName(QString::fromUtf8("radioButton_ShapeLine"));

        horizontalLayout_3->addWidget(radioButton_ShapeLine);

        radioButton_ShapeRectangle = new QRadioButton(gridLayoutWidget_3);
        radioButton_ShapeRectangle->setObjectName(QString::fromUtf8("radioButton_ShapeRectangle"));

        horizontalLayout_3->addWidget(radioButton_ShapeRectangle);

        radioButton_ShapeEllipse = new QRadioButton(gridLayoutWidget_3);
        radioButton_ShapeEllipse->setObjectName(QString::fromUtf8("radioButton_ShapeEllipse"));

        horizontalLayout_3->addWidget(radioButton_ShapeEllipse);

        pushButton_RemoveAllRoi = new QPushButton(gridLayoutWidget_3);
        pushButton_RemoveAllRoi->setObjectName(QString::fromUtf8("pushButton_RemoveAllRoi"));

        horizontalLayout_3->addWidget(pushButton_RemoveAllRoi);


        gridLayout_3->addLayout(horizontalLayout_3, 2, 1, 1, 1);

        horizontalLayout = new QHBoxLayout();
        horizontalLayout->setObjectName(QString::fromUtf8("horizontalLayout"));
        label_MinimumTemperature = new QLabel(gridLayoutWidget_3);
        label_MinimumTemperature->setObjectName(QString::fromUtf8("label_MinimumTemperature"));

        horizontalLayout->addWidget(label_MinimumTemperature);

        label_AverageTemperature = new QLabel(gridLayoutWidget_3);
        label_AverageTemperature->setObjectName(QString::fromUtf8("label_AverageTemperature"));
        label_AverageTemperature->setAlignment(Qt::AlignCenter);

        horizontalLayout->addWidget(label_AverageTemperature);

        label_MaximumTemperature = new QLabel(gridLayoutWidget_3);
        label_MaximumTemperature->setObjectName(QString::fromUtf8("label_MaximumTemperature"));
        label_MaximumTemperature->setAlignment(Qt::AlignRight|Qt::AlignTrailing|Qt::AlignVCenter);

        horizontalLayout->addWidget(label_MaximumTemperature);


        gridLayout_3->addLayout(horizontalLayout, 1, 1, 1, 1);

        MainWindow->setCentralWidget(centralwidget);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        MainWindow->setStatusBar(statusbar);

        retranslateUi(MainWindow);
        QObject::connect(pushButton_LocalCameraConnect, SIGNAL(clicked()), MainWindow, SLOT(pushButton_LocalCameraConnect_Clicked()));
        QObject::connect(tabWidget_ConnectCamera, SIGNAL(currentChanged(int)), MainWindow, SLOT(tabWidget_ConnectCamera_CurrentChanged(int)));
        QObject::connect(pushButton_RemoteCameraConnect, SIGNAL(clicked()), MainWindow, SLOT(pushButton_RemoteCameraConnect_Clicked()));
        QObject::connect(listWidget_LocalCameraList, SIGNAL(currentRowChanged(int)), MainWindow, SLOT(listWidget_LocalCameraList_CurrentRowChanged(int)));
        QObject::connect(listWidget_RemoteCameraList, SIGNAL(currentRowChanged(int)), MainWindow, SLOT(listWidget_RemoteCameraList_CurrentRowChanged(int)));
        QObject::connect(pushButton_GetProductInformation, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetProductInformation_Clicked()));
        QObject::connect(pushButton_GetNetworkConfiguration, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetNetworkConfiguration_Clicked()));
        QObject::connect(radioButton_ShapeCursor, SIGNAL(clicked()), MainWindow, SLOT(radioButton_ShapeCursor_clicked()));
        QObject::connect(radioButton_ShapeSpot, SIGNAL(clicked()), MainWindow, SLOT(radioButton_ShapeSpot_Clicked()));
        QObject::connect(radioButton_ShapeLine, SIGNAL(clicked()), MainWindow, SLOT(radioButton_ShapeLine_Clicked()));
        QObject::connect(radioButton_ShapeRectangle, SIGNAL(clicked()), MainWindow, SLOT(radioButton_ShapeRectangle_Clicked()));
        QObject::connect(radioButton_ShapeEllipse, SIGNAL(clicked()), MainWindow, SLOT(radioButton_ShapeEllipse_Clicked()));
        QObject::connect(pushButton_RemoveAllRoi, SIGNAL(clicked()), MainWindow, SLOT(pushButton_RemoveAllRoi_Clicked()));
        QObject::connect(comboBox_ColorMap, SIGNAL(currentIndexChanged(int)), MainWindow, SLOT(comboBox_ColorMap_Changed(int)));
        QObject::connect(checkBox_NoiseFiltering, SIGNAL(toggled(bool)), MainWindow, SLOT(checkBox_NoiseFiltering_toggled(bool)));
        QObject::connect(comboBox_TemperatureUnit, SIGNAL(currentIndexChanged(int)), MainWindow, SLOT(comboBox_TemperatureUnit_Changed(int)));
        QObject::connect(pushButton_GetSensorInformation, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetSensorInformation_Clicked()));
        QObject::connect(pushButton_SoftwareUpdateFileBrowse, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SoftwareUpdateFileBrowse_Clicked()));
        QObject::connect(pushButton_StartSoftwareUpdate, SIGNAL(clicked()), MainWindow, SLOT(pushButton_StartSoftwareUpdate_Clicked()));
        QObject::connect(pushButton_SetNetworkConfiguration, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetNetworkConfiguration_Clicked()));
        QObject::connect(pushButton_SetDefaultNetworkConfiguration, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetDefaultNetworkConfiguration_Clicked()));
        QObject::connect(pushButton_SystemReboot, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SystemReboot_Clicked()));
        QObject::connect(pushButton_LocalCameraScan, SIGNAL(clicked()), MainWindow, SLOT(pushButton_LocalCameraScan_Clicked()));
        QObject::connect(pushButton_RemoteCameraScan, SIGNAL(clicked()), MainWindow, SLOT(pushButton_RemoteCameraScan_Clicked()));
        QObject::connect(pushButton_GetFlatFieldCorrectionMode_160E, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetFlatFieldCorrectionMode_160E_Clicked()));
        QObject::connect(pushButton_SetFlatFieldCorrection, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetFlatFieldCorrection_Clicked()));
        QObject::connect(pushButton_RestoreDefaultSensorConfig, SIGNAL(clicked()), MainWindow, SLOT(pushButton_RestoreDefaultSensorConfig_Clicked()));
        QObject::connect(pushButton_GetGainModeState_160E, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetGainModeState_160E_Clicked()));
        QObject::connect(pushButton_AddRoiItem, SIGNAL(clicked()), MainWindow, SLOT(pushButton_AddRoiItem_Clicked()));
        QObject::connect(pushButton_SetFFCParams, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetFFCParams_Clicked()));
        QObject::connect(pushButton_GetFlatFieldCorrection, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetFlatFieldCorrection_Clicked()));
        QObject::connect(pushButton_SetFlatFieldCorrectionMode_160E, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetFlatFieldCorrectionMode_160E_Clicked()));
        QObject::connect(pushButton_SetGainModeState, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetGainModeState_Clicked()));
        QObject::connect(pushButton_SetGainModeState_160E, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetGainModeState_160E_Clicked()));
        QObject::connect(pushButton_RestoreDefaultFluxParameters_160E, SIGNAL(clicked()), MainWindow, SLOT(pushButton_RestoreDefaultFluxParameters_160E_Clicked()));
        QObject::connect(pushButton_RunFlatFieldCorrection_160E, SIGNAL(clicked()), MainWindow, SLOT(pushButton_RunFlatFieldCorrection_160E_Clicked()));
        QObject::connect(pushButton_GetFluexParams, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetFluexParams_Clicked()));
        QObject::connect(pushButton_RemoveRoiItem, SIGNAL(clicked()), MainWindow, SLOT(pushButton_RemoveRoiItem_Clicked()));
        QObject::connect(pushButton_SetFluxParameters_160E, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetFluxParameters_160E_Clicked()));
        QObject::connect(pushButton_GetFluxParameters_160E, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetFluxParameters_160E_Clicked()));
        QObject::connect(pushButton_StoreUserSensorConfig, SIGNAL(clicked()), MainWindow, SLOT(pushButton_StoreUserSensorConfig_Clicked()));
        QObject::connect(pushButton_GetFFCParams, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetFFCParams_Clicked()));
        QObject::connect(pushButton_SetFluexParams, SIGNAL(clicked()), MainWindow, SLOT(pushButton_SetFluexParams_Clicked()));
        QObject::connect(pushButton_RunFlatFieldCorrection, SIGNAL(clicked()), MainWindow, SLOT(pushButton_RunFlatFieldCorrection_Clicked()));
        QObject::connect(pushButton_GetGainModeState, SIGNAL(clicked()), MainWindow, SLOT(pushButton_GetGainModeState_Clicked()));

        tabWidget_ConnectCamera->setCurrentIndex(0);
        tabWidget_Control->setCurrentIndex(0);
        stackedWidget_SensorControl->setCurrentIndex(0);
        tabWidget_Product->setCurrentIndex(0);


        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QCoreApplication::translate("MainWindow", "TmWinQt", nullptr));
        label->setText(QCoreApplication::translate("MainWindow", "Name :", nullptr));
        label_2->setText(QCoreApplication::translate("MainWindow", "Com Port :", nullptr));
        pushButton_LocalCameraConnect->setText(QCoreApplication::translate("MainWindow", "Connect", nullptr));
        pushButton_LocalCameraScan->setText(QCoreApplication::translate("MainWindow", "Scan", nullptr));
        tabWidget_ConnectCamera->setTabText(tabWidget_ConnectCamera->indexOf(tab_LocalCamera), QCoreApplication::translate("MainWindow", "Local Camera", nullptr));
        pushButton_RemoteCameraScan->setText(QCoreApplication::translate("MainWindow", "Scan", nullptr));
        pushButton_RemoteCameraConnect->setText(QCoreApplication::translate("MainWindow", "Connect", nullptr));
        label_3->setText(QCoreApplication::translate("MainWindow", "Name :", nullptr));
        label_6->setText(QCoreApplication::translate("MainWindow", "IP Address :", nullptr));
        label_4->setText(QCoreApplication::translate("MainWindow", "Serial :", nullptr));
        label_5->setText(QCoreApplication::translate("MainWindow", "MAC Address :", nullptr));
        tabWidget_ConnectCamera->setTabText(tabWidget_ConnectCamera->indexOf(tab_RemoteCamera), QCoreApplication::translate("MainWindow", "Remote Camera", nullptr));
        pushButton_RestoreDefaultSensorConfig->setText(QCoreApplication::translate("MainWindow", "Restore to Factory\n"
" Default", nullptr));
        groupBox_5->setTitle(QCoreApplication::translate("MainWindow", "FFC Parameters", nullptr));
        label_41->setText(QCoreApplication::translate("MainWindow", "s", nullptr));
        label_40->setText(QCoreApplication::translate("MainWindow", "Automatic Trigger Threshold :", nullptr));
        pushButton_SetFFCParams->setText(QCoreApplication::translate("MainWindow", "Set", nullptr));
        lineEdit_FFCParam_MaxIntervalRange->setText(QCoreApplication::translate("MainWindow", "5 ~ 655", nullptr));
        pushButton_GetFFCParams->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        label_39->setText(QCoreApplication::translate("MainWindow", "Maximum Interval :", nullptr));
        lineEdit_FFCParam_AutoTriggerThreshold->setText(QCoreApplication::translate("MainWindow", "0 ~ 65535", nullptr));
        groupBox_4->setTitle(QCoreApplication::translate("MainWindow", "Fluex Parameters", nullptr));
        pushButton_GetFluexParams->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        label_30->setText(QCoreApplication::translate("MainWindow", "Emissivity :", nullptr));
        label_35->setText(QCoreApplication::translate("MainWindow", "Distance (Not support) :", nullptr));
        label_32->setText(QCoreApplication::translate("MainWindow", "Atmospheric Transmittance :", nullptr));
        label_34->setText(QCoreApplication::translate("MainWindow", "Ambient Reflection Temperature :", nullptr));
        label_31->setText(QString());
        lineEdit_FluexParam_EmissivityRange->setText(QCoreApplication::translate("MainWindow", "0.01 ~ 1.00", nullptr));
        label_36->setText(QCoreApplication::translate("MainWindow", "\342\204\203", nullptr));
        label_37->setText(QCoreApplication::translate("MainWindow", "\342\204\203", nullptr));
        label_33->setText(QCoreApplication::translate("MainWindow", "Atmospheric Temperature :", nullptr));
        label_38->setText(QCoreApplication::translate("MainWindow", "m", nullptr));
        pushButton_SetFluexParams->setText(QCoreApplication::translate("MainWindow", "Set", nullptr));
        lineEdit_FluexParam_AtmosphericTransmittanceRange->setText(QCoreApplication::translate("MainWindow", "0.01 ~ 1.00", nullptr));
        lineEdit_FluexParamAtmosphericTempRange->setText(QCoreApplication::translate("MainWindow", "-43.15 ~ 625.85", nullptr));
        lineEdit_FluexParam_AmbientReflectionTempRange->setText(QCoreApplication::translate("MainWindow", "-43.15 ~ 626.85", nullptr));
        lineEdit_FluexParamDistanceRange->setText(QCoreApplication::translate("MainWindow", "0.00 ~ 200.00", nullptr));
        groupBox_6->setTitle(QCoreApplication::translate("MainWindow", "Gain Mode State", nullptr));
        radioButton_GainModeHigh->setText(QCoreApplication::translate("MainWindow", "High", nullptr));
        pushButton_GetGainModeState->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        radioButton_GainModeLow->setText(QCoreApplication::translate("MainWindow", "Low", nullptr));
        pushButton_SetGainModeState->setText(QCoreApplication::translate("MainWindow", "Set", nullptr));
        groupBox_7->setTitle(QCoreApplication::translate("MainWindow", "Flat Field Correction", nullptr));
        radioButton_FlatFieldCorrectionAutomatic->setText(QCoreApplication::translate("MainWindow", "Automatic", nullptr));
        radioButton_FlatFieldCorrectionManual->setText(QCoreApplication::translate("MainWindow", "Manual", nullptr));
        pushButton_GetFlatFieldCorrection->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        pushButton_SetFlatFieldCorrection->setText(QCoreApplication::translate("MainWindow", "Set", nullptr));
        pushButton_RunFlatFieldCorrection->setText(QCoreApplication::translate("MainWindow", "Run", nullptr));
        pushButton_StoreUserSensorConfig->setText(QCoreApplication::translate("MainWindow", "Store Config\n"
" Permanently", nullptr));
        groupBox_11->setTitle(QCoreApplication::translate("MainWindow", "Flux Parameters", nullptr));
        label_122->setText(QCoreApplication::translate("MainWindow", "Atmospheric Transmission : ", nullptr));
        label_121->setText(QCoreApplication::translate("MainWindow", "Window Temperature : ", nullptr));
        label_123->setText(QCoreApplication::translate("MainWindow", "Atmospheric Temperature : ", nullptr));
        pushButton_GetFluxParameters_160E->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        pushButton_SetFluxParameters_160E->setText(QCoreApplication::translate("MainWindow", "Set", nullptr));
        label_7->setText(QCoreApplication::translate("MainWindow", "Scene Emissivity : ", nullptr));
        label_127->setText(QCoreApplication::translate("MainWindow", "\342\204\203", nullptr));
        label_128->setText(QCoreApplication::translate("MainWindow", "\342\204\203", nullptr));
        label_125->setText(QCoreApplication::translate("MainWindow", "\342\204\203", nullptr));
        label_124->setText(QCoreApplication::translate("MainWindow", "Window Reflection :", nullptr));
        lineEdit_FluxParam160E_SceneEmissivityRange->setText(QCoreApplication::translate("MainWindow", "0.01 ~ 1.00", nullptr));
        label_120->setText(QCoreApplication::translate("MainWindow", "Window Transmission : ", nullptr));
        label_9->setText(QCoreApplication::translate("MainWindow", "Background Temperature : ", nullptr));
        label_126->setText(QCoreApplication::translate("MainWindow", "\342\204\203", nullptr));
        lineEdit_FluxParam160E_WindowTemperatureRange->setText(QCoreApplication::translate("MainWindow", "-273.15 ~ 382.2", nullptr));
        label_8->setText(QCoreApplication::translate("MainWindow", "Window Reflected Temperature : ", nullptr));
        lineEdit_FluxParam160E_BackgroundTemperatureRange->setText(QCoreApplication::translate("MainWindow", "-273.15 ~ 382.2", nullptr));
        lineEdit_FluxParam160E_WindowTransmissionRange->setText(QCoreApplication::translate("MainWindow", "0.01 ~ 1.00", nullptr));
        lineEdit_FluxParam160E_AtmosphericTransmissionRange->setText(QCoreApplication::translate("MainWindow", "0.01 ~ 1.00", nullptr));
        lineEdit_FluxParam160E_AtmosphericTemperatureRange->setText(QCoreApplication::translate("MainWindow", "-273.15 ~ 382.2", nullptr));
        lineEdit_FluxParam160E_WindowReflectionRange->setText(QCoreApplication::translate("MainWindow", "0.00 ~ 0.00", nullptr));
        lineEdit_FluxParam160E_WindowReflectedTemperatureRange->setText(QCoreApplication::translate("MainWindow", "-273.15 ~ 382.2", nullptr));
        groupBox_12->setTitle(QCoreApplication::translate("MainWindow", "Gain Mode State", nullptr));
        radioButton_GainModeStateAuto_160E->setText(QCoreApplication::translate("MainWindow", "Automatic", nullptr));
        radioButton_GainModeStateLow_160E->setText(QCoreApplication::translate("MainWindow", "Low", nullptr));
        radioButton_GainModeStateHigh_160E->setText(QCoreApplication::translate("MainWindow", "High", nullptr));
        pushButton_SetGainModeState_160E->setText(QCoreApplication::translate("MainWindow", "Set", nullptr));
        pushButton_GetGainModeState_160E->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        groupBox_13->setTitle(QCoreApplication::translate("MainWindow", "Flat Field Correction", nullptr));
        radioButton_FlatFieldCorrectionAutomatic_160E->setText(QCoreApplication::translate("MainWindow", "Automatic", nullptr));
        pushButton_GetFlatFieldCorrectionMode_160E->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        radioButton_FlatFieldCorrectionManual_160E->setText(QCoreApplication::translate("MainWindow", "Manual", nullptr));
        pushButton_SetFlatFieldCorrectionMode_160E->setText(QCoreApplication::translate("MainWindow", "Set", nullptr));
        pushButton_RunFlatFieldCorrection_160E->setText(QCoreApplication::translate("MainWindow", "Run", nullptr));
        pushButton_RestoreDefaultFluxParameters_160E->setText(QCoreApplication::translate("MainWindow", "Restore Flux Parameters to Default", nullptr));
        tabWidget_Control->setTabText(tabWidget_Control->indexOf(tabSensorControl), QCoreApplication::translate("MainWindow", "Sensor Control", nullptr));
        label_42->setText(QCoreApplication::translate("MainWindow", "ROI List", nullptr));
        pushButton_RemoveRoiItem->setText(QCoreApplication::translate("MainWindow", "Remove", nullptr));
        label_52->setText(QCoreApplication::translate("MainWindow", "Y :", nullptr));
        label_48->setText(QCoreApplication::translate("MainWindow", "Y2 :", nullptr));
        label_54->setText(QCoreApplication::translate("MainWindow", "W :", nullptr));
        radioButton_RoiLine->setText(QCoreApplication::translate("MainWindow", "Line", nullptr));
        label_44->setText(QCoreApplication::translate("MainWindow", "Y :", nullptr));
        label_53->setText(QCoreApplication::translate("MainWindow", "W :", nullptr));
        label_46->setText(QCoreApplication::translate("MainWindow", "Y1 :", nullptr));
        radioButton_RoiRectangle->setText(QCoreApplication::translate("MainWindow", "Rectangle", nullptr));
        label_43->setText(QCoreApplication::translate("MainWindow", "X :", nullptr));
        label_55->setText(QCoreApplication::translate("MainWindow", "H :", nullptr));
        label_49->setText(QCoreApplication::translate("MainWindow", "X :", nullptr));
        radioButton_RoiSpot->setText(QCoreApplication::translate("MainWindow", "Spot", nullptr));
        label_50->setText(QCoreApplication::translate("MainWindow", "X :", nullptr));
        radioButton_RoiEllipse->setText(QCoreApplication::translate("MainWindow", "Ellipse", nullptr));
        label_56->setText(QCoreApplication::translate("MainWindow", "H :", nullptr));
        label_45->setText(QCoreApplication::translate("MainWindow", "X1 :", nullptr));
        label_47->setText(QCoreApplication::translate("MainWindow", "X2 :", nullptr));
        pushButton_AddRoiItem->setText(QCoreApplication::translate("MainWindow", "Add", nullptr));
        label_51->setText(QCoreApplication::translate("MainWindow", "Y :", nullptr));
        tabWidget_Control->setTabText(tabWidget_Control->indexOf(tabRegionOfInterests), QCoreApplication::translate("MainWindow", "Region of Interests", nullptr));
        groupBox->setTitle(QCoreApplication::translate("MainWindow", "Product Information", nullptr));
        label_ProductModelName->setText(QString());
        label_13->setText(QCoreApplication::translate("MainWindow", "Product Serial Number : ", nullptr));
        label_HardwareVersion->setText(QString());
        label_FirmwareVersion->setText(QString());
        label_ProductSerialNumber->setText(QString());
        label_14->setText(QCoreApplication::translate("MainWindow", "Hardware Version : ", nullptr));
        label_16->setText(QCoreApplication::translate("MainWindow", "Firmware Version : ", nullptr));
        label_BootloaderVersion->setText(QString());
        label_12->setText(QCoreApplication::translate("MainWindow", "Product Model Name : ", nullptr));
        label_15->setText(QCoreApplication::translate("MainWindow", "Bootloader Version : ", nullptr));
        pushButton_GetProductInformation->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        groupBox_2->setTitle(QCoreApplication::translate("MainWindow", "Sensor Information", nullptr));
        pushButton_GetSensorInformation->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        label_17->setText(QCoreApplication::translate("MainWindow", "Sensor Serial Number : ", nullptr));
        label_20->setText(QCoreApplication::translate("MainWindow", "Sensor Model Name : ", nullptr));
        label_SensorSerialNumber->setText(QString());
        label_SensorModelName->setText(QString());
        label_18->setText(QCoreApplication::translate("MainWindow", "Sensor Uptime : ", nullptr));
        label_SensorUptime->setText(QString());
        groupBox_3->setTitle(QCoreApplication::translate("MainWindow", "Software Update", nullptr));
        label_VendorName->setText(QString());
        label_ProductName->setText(QString());
        label_BinarySize->setText(QString());
        label_26->setText(QCoreApplication::translate("MainWindow", "Version :", nullptr));
        pushButton_StartSoftwareUpdate->setText(QCoreApplication::translate("MainWindow", "Browse and Select Binary File", nullptr));
        label_24->setText(QCoreApplication::translate("MainWindow", "Binary Information", nullptr));
        label_27->setText(QCoreApplication::translate("MainWindow", "Build Time :", nullptr));
        label_28->setText(QCoreApplication::translate("MainWindow", "Size :", nullptr));
        label_BuildTime->setText(QString());
        label_25->setText(QCoreApplication::translate("MainWindow", "Product Name :", nullptr));
        label_SoftwareVersion->setText(QString());
        label_23->setText(QCoreApplication::translate("MainWindow", "Vendor Name : ", nullptr));
        pushButton_SoftwareUpdateFileBrowse->setText(QCoreApplication::translate("MainWindow", "Browse", nullptr));
        label_SoftwareUpdateStatus->setText(QString());
        tabWidget_Product->setTabText(tabWidget_Product->indexOf(tab_3), QCoreApplication::translate("MainWindow", "Product", nullptr));
        groupBox_10->setTitle(QCoreApplication::translate("MainWindow", "Network Configuration", nullptr));
        label_116->setText(QCoreApplication::translate("MainWindow", "Netmask :", nullptr));
        pushButton_SetNetworkConfiguration->setText(QCoreApplication::translate("MainWindow", "Set", nullptr));
        label_117->setText(QCoreApplication::translate("MainWindow", "Gateway :", nullptr));
        label_119->setText(QCoreApplication::translate("MainWindow", "Sub DNS Server :", nullptr));
        label_21->setText(QCoreApplication::translate("MainWindow", "IP Assignment :", nullptr));
        pushButton_GetNetworkConfiguration->setText(QCoreApplication::translate("MainWindow", "Get", nullptr));
        label_22->setText(QCoreApplication::translate("MainWindow", "IP Address :", nullptr));
        pushButton_SetDefaultNetworkConfiguration->setText(QCoreApplication::translate("MainWindow", "Set to Factory Default", nullptr));
        label_118->setText(QCoreApplication::translate("MainWindow", "Main DNS Server :", nullptr));
        label_19->setText(QCoreApplication::translate("MainWindow", "MAC Address :", nullptr));
        pushButton_SystemReboot->setText(QCoreApplication::translate("MainWindow", "Reboot to Apply Changes", nullptr));
        tabWidget_Product->setTabText(tabWidget_Product->indexOf(tab_4), QCoreApplication::translate("MainWindow", "Network", nullptr));
        label_Preview->setText(QCoreApplication::translate("MainWindow", "Preview", nullptr));
        label_10->setText(QCoreApplication::translate("MainWindow", "Color Map", nullptr));
        comboBox_ColorMap->setItemText(0, QCoreApplication::translate("MainWindow", "GrayScale", nullptr));
        comboBox_ColorMap->setItemText(1, QCoreApplication::translate("MainWindow", "Autumn", nullptr));
        comboBox_ColorMap->setItemText(2, QCoreApplication::translate("MainWindow", "Bone", nullptr));
        comboBox_ColorMap->setItemText(3, QCoreApplication::translate("MainWindow", "Jet", nullptr));
        comboBox_ColorMap->setItemText(4, QCoreApplication::translate("MainWindow", "Winter", nullptr));
        comboBox_ColorMap->setItemText(5, QCoreApplication::translate("MainWindow", "Rainbow", nullptr));
        comboBox_ColorMap->setItemText(6, QCoreApplication::translate("MainWindow", "Ocean", nullptr));
        comboBox_ColorMap->setItemText(7, QCoreApplication::translate("MainWindow", "Summer", nullptr));
        comboBox_ColorMap->setItemText(8, QCoreApplication::translate("MainWindow", "Spring", nullptr));
        comboBox_ColorMap->setItemText(9, QCoreApplication::translate("MainWindow", "Cool", nullptr));
        comboBox_ColorMap->setItemText(10, QCoreApplication::translate("MainWindow", "Hsv", nullptr));
        comboBox_ColorMap->setItemText(11, QCoreApplication::translate("MainWindow", "Pink", nullptr));
        comboBox_ColorMap->setItemText(12, QCoreApplication::translate("MainWindow", "Hot", nullptr));
        comboBox_ColorMap->setItemText(13, QCoreApplication::translate("MainWindow", "Parula", nullptr));
        comboBox_ColorMap->setItemText(14, QCoreApplication::translate("MainWindow", "Magma", nullptr));
        comboBox_ColorMap->setItemText(15, QCoreApplication::translate("MainWindow", "Inferno", nullptr));
        comboBox_ColorMap->setItemText(16, QCoreApplication::translate("MainWindow", "Plasma", nullptr));
        comboBox_ColorMap->setItemText(17, QCoreApplication::translate("MainWindow", "Viridis", nullptr));
        comboBox_ColorMap->setItemText(18, QCoreApplication::translate("MainWindow", "Cividis", nullptr));
        comboBox_ColorMap->setItemText(19, QCoreApplication::translate("MainWindow", "Twilight", nullptr));
        comboBox_ColorMap->setItemText(20, QCoreApplication::translate("MainWindow", "TwilightShifted", nullptr));
        comboBox_ColorMap->setItemText(21, QCoreApplication::translate("MainWindow", "Turbo", nullptr));
        comboBox_ColorMap->setItemText(22, QCoreApplication::translate("MainWindow", "DeepGreen", nullptr));

        checkBox_NoiseFiltering->setText(QCoreApplication::translate("MainWindow", "Noise Filtering", nullptr));
        label_11->setText(QCoreApplication::translate("MainWindow", "Temperature", nullptr));
        comboBox_TemperatureUnit->setItemText(0, QCoreApplication::translate("MainWindow", "Raw", nullptr));
        comboBox_TemperatureUnit->setItemText(1, QCoreApplication::translate("MainWindow", "Celsius(\342\204\203)", nullptr));
        comboBox_TemperatureUnit->setItemText(2, QCoreApplication::translate("MainWindow", "Fahrenheit(\342\204\211)", nullptr));
        comboBox_TemperatureUnit->setItemText(3, QCoreApplication::translate("MainWindow", "Kelvin(K)", nullptr));

        radioButton_ShapeCursor->setText(QCoreApplication::translate("MainWindow", "Cursor", nullptr));
        radioButton_ShapeSpot->setText(QCoreApplication::translate("MainWindow", "Spot", nullptr));
        radioButton_ShapeLine->setText(QCoreApplication::translate("MainWindow", "Line", nullptr));
        radioButton_ShapeRectangle->setText(QCoreApplication::translate("MainWindow", "Rectangle", nullptr));
        radioButton_ShapeEllipse->setText(QCoreApplication::translate("MainWindow", "Ellipse", nullptr));
        pushButton_RemoveAllRoi->setText(QCoreApplication::translate("MainWindow", "Remove All", nullptr));
        label_MinimumTemperature->setText(QCoreApplication::translate("MainWindow", "MinTemp", nullptr));
        label_AverageTemperature->setText(QCoreApplication::translate("MainWindow", "AvgTemp", nullptr));
        label_MaximumTemperature->setText(QCoreApplication::translate("MainWindow", "MaxTemp", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
