/******************************************************************
 * Company: Thermoeye, Inc
 * Project: TmSDK
 * File: Camera.cpp
 * Creation date: 2024-08-19
 * Version: 1.0.0
 *
 * Description: This file contains the following implementations:
 * - Search and connect local/remote cameras
 * - Camera video preview
 * - ROI management
 * - Temperature measurement
 *
 * History: 2024-08-19: Initial version.
 *
 ****************************************************************/
#include "Camera.h"
#include <QMouseEvent>

Camera::Camera(Ui::MainWindow* mUi, QObject* parent)
    : QObject(parent), ui(mUi) {}

Camera::~Camera()
{}

TmCamera* Camera::GetTmCamera()
{
    return pTmCamera;
}

/*
* Convert std::string type to std::wstring type
*/
uint32_t Camera::ConvertAnsiToUnicodeString(std::wstring& unicode, const std::string& c_string)
{
    uint32_t error = 0;
    const char* ansi = c_string.c_str();
    size_t ansi_size = c_string.size();

    do {
        if ((nullptr == ansi) || (0 == ansi_size))
        {
            error = -1;
            break;
        }
        unicode.clear();

        // Set the locale to the default locale to handle special characters
        std::setlocale(LC_ALL, "");

        int required_cch = mbstowcs(nullptr, ansi, 0);
        if (required_cch <= 0)
        {
            error = errno;
            break;
        }

        unicode.resize(required_cch);
        int result = mbstowcs(&unicode[0], ansi, ansi_size);
        if (result <= 0)
        {
            error = errno;
            break;
        }

    } while (false);

    return error;
}

/*
* Get temperature value by unit
*/
std::string Camera::GetTempStringUnit(double raw)
{
    std::string strTemp;
    std::stringstream ss;
    if (pTmCamera != nullptr && pTmCamera->IsOpen() == true)
    {
        switch (pTmCamera->GetTempUnit())
        {
        case TempUnit::RAW:
            ss << std::fixed << std::setprecision(0) << raw << " " << pTmCamera->GetTempUnitSymbol();
            break;
        case TempUnit::CELSIUS:
            ss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(raw) << " " << pTmCamera->GetTempUnitSymbol();
            break;
        case TempUnit::FAHRENHEIT:
            ss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(raw) << " " << pTmCamera->GetTempUnitSymbol();
            break;
        case TempUnit::KELVIN:
            ss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(raw) << " " << pTmCamera->GetTempUnitSymbol();
            break;
        }
    }

    return ss.str();
}

/*
* Measures the minimum, maximum, and average temperature values ​​of the current frame.
*/
void Camera::processMeasurements(TmFrame* pFrame)
{

    double minVal, avgVal, maxVal;
    Point minLoc, maxLoc;
    uint8_t* bitMap = pFrame->ToBitmap(ColorOrder::COLOR_RGB);
    QImage image(bitMap, pFrame->Width(), pFrame->Height(), QImage::Format_RGB888);
    DrawShapeObjects(image);
    UpdateDrawingLabel(image);
    QPixmap pixMap = QPixmap::fromImage(image);
    ui->label_Preview->setPixmap(pixMap);
    ui->label_Preview->show();

    pFrame->DoMeasure(roiManager.Items);
    pFrame->MinMaxLoc(minVal, avgVal, maxVal, minLoc, maxLoc);

    if (pTmCamera == nullptr)    return;

    std::wstring wideStr;
    ConvertAnsiToUnicodeString(wideStr, pTmCamera->GetTempUnitSymbol());
    QString text = QString::fromStdWString(wideStr);

    std::stringstream oss;
    oss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(minVal) << " ";
    ui->label_MinimumTemperature->setText(QString::fromStdString(oss.str()) + text);

    oss.str("");
    oss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(avgVal) << " ";
    ui->label_AverageTemperature->setText(QString::fromStdString(oss.str()) + text);

    oss.str("");
    oss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(maxVal) << " ";
    ui->label_MaximumTemperature->setText(QString::fromStdString(oss.str()) + text);
    pFrame->Release();
}

/*
* Thread for capture camera image
*/
void Camera::CaptureFrame()
{
    if (pTmCamera == nullptr || pTmCamera->IsOpen() == false)
    {
        return;
    }
    int colorMapIndex = (int)ColormapTypes::Inferno + 1;
    int tempUnitIndex = (int)TempUnit::CELSIUS;
    ui->comboBox_ColorMap->setCurrentIndex(colorMapIndex);
    ui->comboBox_TemperatureUnit->setCurrentIndex(tempUnitIndex);
    pTmCamera->SetColorMap((ColormapTypes)colorMapIndex);
    pTmCamera->SetTempUnit((TempUnit)tempUnitIndex);

    while (runCapThread)
    {
        TmFrame* pFrame = pTmCamera->QueryFrame(previewWidth, previewHeight);
        if (pFrame != nullptr)
        {
            future = QtConcurrent::run(this, &Camera::processMeasurements, pFrame);
            futureWatcher.setFuture(future);
        }
    }
}

/*
* Scan for local cameras
*/
void Camera::ScanLocalCamera()
{
    ui->lineEdit_LocalCameraName->setText("");
    ui->lineEdit_LocalCameraPort->setText("");
    ui->listWidget_LocalCameraList->clear();
    for (auto cam : CamList)
    {
        delete cam;
    }
    CamList.clear();
    for (auto cam : TmLocalCamera::GetCameraList())
    {
        QString qstr = QString::fromStdString(cam.Name + " - " + cam.ComPort);
        ui->listWidget_LocalCameraList->addItem(qstr);
        CamList.push_back(new TmLocalCamInfo(cam.Name, cam.ComPort, cam.Index));
    }
    if (!CamList.empty())
    {
        ui->listWidget_LocalCameraList->setCurrentRow(0);
        TmLocalCamInfo* camInfo = (TmLocalCamInfo*)CamList[0];
        ui->lineEdit_LocalCameraName->setText(QString::fromStdString(camInfo->Name));
        ui->lineEdit_LocalCameraPort->setText(QString::fromStdString(camInfo->ComPort));
    }
}

/*
* Scan for remote cameras
*/
void Camera::ScanRemoteCamera()
{
    ui->lineEdit_RemoteCameraName->setText("");
    ui->lineEdit_RemoteCameraSerial->setText("");
    ui->lineEdit_RemoteCameraMac->setText("");
    ui->lineEdit_RemoteCameraIp->setText("");
    ui->listWidget_RemoteCameraList->clear();
    for (auto cam : CamList)
    {
        delete cam;
    }
    CamList.clear();
    for (auto cam : TmRemoteCamera::GetCameraList())
    {
        QString qstr = QString::fromStdString(cam.Name + " - " + cam.AddrIP);
        ui->listWidget_RemoteCameraList->addItem(qstr);
        CamList.push_back(new TmRemoteCamInfo(cam.Name, cam.SerialNumber, cam.AddrMAC, cam.AddrIP));
    }
    if (!CamList.empty())
    {
        ui->listWidget_RemoteCameraList->setCurrentRow(0);
        TmRemoteCamInfo* camInfo = (TmRemoteCamInfo*)CamList[0];
        ui->lineEdit_RemoteCameraName->setText(QString::fromStdString(camInfo->Name));
        ui->lineEdit_RemoteCameraSerial->setText(QString::fromStdString(camInfo->SerialNumber));
        ui->lineEdit_RemoteCameraMac->setText(QString::fromStdString(camInfo->AddrMAC));
        ui->lineEdit_RemoteCameraIp->setText(QString::fromStdString(camInfo->AddrIP));
    }
}

/*
* Disconnect the connected camera.
*/
void Camera::DisconnectCamera()
{
    if (runCapThread)
    {
        runCapThread = false;
        capThread.join();
    }
    if (pTmCamera != nullptr)
    {
        if (future.isRunning())
        {
            futureWatcher.waitForFinished();
        }
        roiManager.Clear();
        pTmCamera->Close();
        pTmCamera = nullptr;
    }
}

/*
* Draws a roi object on the screen.
*/
void Camera::DrawShapeObjects(QImage& image) {
    if (image.isNull()) return;

    QPainter painter(&image);
    if (!painter.isActive()) return;

    QFont font("Verdana");
    painter.setFont(font);
    painter.setRenderHint(QPainter::Antialiasing);
    QString strDraw;
    QSizeF sizeDraw;
    QColor crimson(0xDC, 0x14, 0x3C); // #dc143c
    QColor cornflowerblue(0x64, 0x95, 0xED); // #6495ed

    for (size_t i = 0; i < roiManager.Items.size(); ++i)
    {
        RoiObject* item = roiManager.Items[i];
        switch (item->Type) {
        case RoiType::Spot:
        {
            RoiSpot* shape = static_cast<RoiSpot*>(item);
            // draw shape
            painter.setPen(QPen(Qt::cyan, 1));
            painter.drawEllipse(QPoint(shape->Spot.X - 1, shape->Spot.Y - 1), 2, 2);

            // draw object id
            strDraw = QString("ROI%1").arg(shape->Index);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::cyan);
            painter.drawText(shape->Spot.X - sizeDraw.width() / 2, shape->Spot.Y - 4, strDraw);

            // draw temp
            std::string tempUnit = GetTempStringUnit(shape->MaxLoc.Value);
            std::wstring wStr;
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::green);
            painter.drawText(shape->Spot.X - sizeDraw.width() / 2, shape->Spot.Y + 14, strDraw);
            break;
        }

        case RoiType::Line:
        {
            RoiLine* shape = static_cast<RoiLine*>(item);
            // draw shape
            painter.setPen(QPen(Qt::yellow, 1));
            painter.setBrush(Qt::NoBrush);
            painter.drawLine(shape->Start.X, shape->Start.Y, shape->End.X, shape->End.Y);

            // draw object id
            QString strDraw = QString("ROI%1").arg(shape->Index);
            painter.setPen(Qt::cyan);
            painter.drawText(shape->Start.X, shape->Start.Y - 4, strDraw);

            // draw max temp
            painter.setPen(crimson);
            painter.setBrush(crimson);
            painter.drawPolygon(QPolygon() << QPoint(shape->MaxLoc.Location.X, shape->MaxLoc.Location.Y)
                << QPoint(shape->MaxLoc.Location.X - 4, shape->MaxLoc.Location.Y - 4)
                << QPoint(shape->MaxLoc.Location.X + 4, shape->MaxLoc.Location.Y - 4));
            std::string tempUnit = GetTempStringUnit(shape->MaxLoc.Value);
            std::wstring wStr;
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            QSizeF sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(crimson);
            painter.drawText(shape->MaxLoc.Location.X - sizeDraw.width() / 2, shape->MaxLoc.Location.Y - 9, strDraw);

            // draw min temp
            painter.setPen(cornflowerblue);
            painter.setBrush(cornflowerblue);
            painter.drawPolygon(QPolygon() << QPoint(shape->MinLoc.Location.X, shape->MinLoc.Location.Y)
                << QPoint(shape->MinLoc.Location.X - 4, shape->MinLoc.Location.Y + 4)
                << QPoint(shape->MinLoc.Location.X + 4, shape->MinLoc.Location.Y + 4));
            tempUnit = GetTempStringUnit(shape->MinLoc.Value);
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(cornflowerblue);
            painter.drawText(shape->MinLoc.Location.X - sizeDraw.width() / 2, shape->MinLoc.Location.Y + 15, strDraw);

            // draw average temp
            tempUnit = GetTempStringUnit(shape->AvgLoc.Value);
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::green);
            painter.drawText(shape->Start.X + (shape->End.X - shape->Start.X) / 2 - sizeDraw.width() / 2,
                shape->Start.Y + (shape->End.Y - shape->Start.Y) / 2 + 2, strDraw);
            break;
        }
        case RoiType::Rect:
        {
            RoiRect* shape = static_cast<RoiRect*>(item);
            std::string tempUnit;
            std::wstring wStr;
            // draw shape
            painter.setPen(QPen(Qt::yellow, 1));
            painter.setBrush(Qt::NoBrush);
            painter.drawRect(shape->Rect.X, shape->Rect.Y, shape->Rect.Width, shape->Rect.Height);

            // draw object id
            QString strDraw = QString("ROI%1").arg(shape->Index);
            painter.setPen(Qt::cyan);
            painter.drawText(shape->Rect.X, shape->Rect.Y - 4, strDraw);

            // draw max temp
            painter.setPen(crimson);
            painter.setBrush(crimson);
            painter.drawPolygon(QPolygon() << QPoint(shape->MaxLoc.Location.X, shape->MaxLoc.Location.Y)
                << QPoint(shape->MaxLoc.Location.X - 4, shape->MaxLoc.Location.Y - 4)
                << QPoint(shape->MaxLoc.Location.X + 4, shape->MaxLoc.Location.Y - 4));
            tempUnit = GetTempStringUnit(shape->MaxLoc.Value);
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            QSizeF sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(crimson);
            painter.drawText(shape->MaxLoc.Location.X - sizeDraw.width() / 2, shape->MaxLoc.Location.Y - 9, strDraw);

            // draw min temp
            painter.setPen(cornflowerblue);
            painter.setBrush(cornflowerblue);
            painter.drawPolygon(QPolygon() << QPoint(shape->MinLoc.Location.X, shape->MinLoc.Location.Y)
                << QPoint(shape->MinLoc.Location.X - 4, shape->MinLoc.Location.Y + 4)
                << QPoint(shape->MinLoc.Location.X + 4, shape->MinLoc.Location.Y + 4));
            tempUnit = GetTempStringUnit(shape->MinLoc.Value);
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(cornflowerblue);
            painter.drawText(shape->MinLoc.Location.X - sizeDraw.width() / 2, shape->MinLoc.Location.Y + 15, strDraw);

            // draw average temp
            tempUnit = GetTempStringUnit(shape->AvgLoc.Value);
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::green);
            painter.drawText(shape->Rect.X + shape->Rect.Width / 2 - sizeDraw.width() / 2,
                shape->Rect.Y + shape->Rect.Height + 2, strDraw);
            break;
        }
        case RoiType::Ellipse:
        {
            RoiEllipse* shape = static_cast<RoiEllipse*>(item);
            std::string tempUnit;
            std::wstring wStr;
            // draw shape
            painter.setPen(QPen(Qt::yellow, 1));
            painter.setBrush(Qt::NoBrush);
            painter.drawEllipse(shape->Ellipse.X, shape->Ellipse.Y, shape->Ellipse.Width, shape->Ellipse.Height);

            // draw object id
            QString strDraw = QString("ROI%1").arg(shape->Index);
            QSizeF sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::cyan);
            painter.drawText(shape->Ellipse.X + shape->Ellipse.Width / 2 - sizeDraw.width() / 2, shape->Ellipse.Y - 4, strDraw);

            // draw max temp
            painter.setPen(crimson);
            painter.setBrush(crimson);
            painter.drawPolygon(QPolygon() << QPoint(shape->MaxLoc.Location.X, shape->MaxLoc.Location.Y)
                << QPoint(shape->MaxLoc.Location.X - 4, shape->MaxLoc.Location.Y - 4)
                << QPoint(shape->MaxLoc.Location.X + 4, shape->MaxLoc.Location.Y - 4));
            tempUnit = GetTempStringUnit(shape->MaxLoc.Value);
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(crimson);
            painter.drawText(shape->MaxLoc.Location.X - sizeDraw.width() / 2, shape->MaxLoc.Location.Y - 9, strDraw);

            // draw min temp
            painter.setPen(cornflowerblue);
            painter.setBrush(cornflowerblue);
            painter.drawPolygon(QPolygon() << QPoint(shape->MinLoc.Location.X, shape->MinLoc.Location.Y)
                << QPoint(shape->MinLoc.Location.X - 4, shape->MinLoc.Location.Y + 4)
                << QPoint(shape->MinLoc.Location.X + 4, shape->MinLoc.Location.Y + 4));
            tempUnit = GetTempStringUnit(shape->MinLoc.Value);
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(cornflowerblue);
            painter.drawText(shape->MinLoc.Location.X - sizeDraw.width() / 2, shape->MinLoc.Location.Y + 15, strDraw);

            // draw average temp
            tempUnit = GetTempStringUnit(shape->AvgLoc.Value);
            ConvertAnsiToUnicodeString(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::green);
            painter.drawText(shape->Ellipse.X + shape->Ellipse.Width / 2 - sizeDraw.width() / 2, shape->Ellipse.Y + shape->Ellipse.Height + 2, strDraw);
        }

        }
    }
}

/*
* Add the created roi object to the ui
*/
void Camera::UpdateRoiListItems()
{
    ui->comboBox_ListRoi->clear();

    for (RoiObject* item : roiManager.Items) {
        ui->comboBox_ListRoi->addItem(QString("ROI%1").arg(item->Index));
    }

    if (roiManager.roiCount > 0)
    {
        ui->comboBox_ListRoi->setCurrentIndex(0);
    }
    else
    {
        ui->comboBox_ListRoi->setCurrentIndex(-1);
    }
}

/*
* Preview of the roi object you want to add
*/
void Camera::UpdateDrawingLabel(QImage& image)
{
    QPainter painter(&image);

    if (drawing && roiManager.SelectedItem() != nullptr) {
        painter.setRenderHint(QPainter::Antialiasing);
        painter.setPen(Qt::yellow);
        switch (roiManager.GetSelectedRoiType())
        {
        case RoiType::Hand:
            break;
        case RoiType::Spot:
        {
            RoiSpot* shape = static_cast<RoiSpot*>(roiManager.SelectedItem());
            painter.drawEllipse(shape->Spot.X - 1, shape->Spot.Y - 1, 2, 2);
            break;
        }
        case RoiType::Line:
        {
            RoiLine* shape = static_cast<RoiLine*>(roiManager.SelectedItem());
            painter.drawLine(shape->Start.X, shape->Start.Y, shape->End.X, shape->End.Y);
            break;
        }
        case RoiType::Rect:
        {
            RoiRect* shape = static_cast<RoiRect*>(roiManager.SelectedItem());
            painter.drawRect(shape->Rect.X, shape->Rect.Y, shape->Rect.Width, shape->Rect.Height);
            break;
        }
        case RoiType::Ellipse:
            RoiEllipse* shape = static_cast<RoiEllipse*>(roiManager.SelectedItem());
            painter.drawEllipse(shape->Ellipse.X, shape->Ellipse.Y, shape->Ellipse.Width, shape->Ellipse.Height);
            break;
        }
    }
}

void Camera::MouseUp(QPoint point)
{
    Point pt;
    pt.X = point.x();
    pt.Y = point.y();
    if (roiManager.MouseUp(pt))
    {
        ui->radioButton_ShapeCursor->setChecked(true);
        ui->radioButton_ShapeSpot->setChecked(false);
        ui->radioButton_ShapeLine->setChecked(false);
        ui->radioButton_ShapeRectangle->setChecked(false);
        ui->radioButton_ShapeEllipse->setChecked(false);
        UpdateRoiListItems();
        drawing = false;
    }
}

void Camera::MouseDown(QPoint point)
{
    Point pt;
    pt.X = point.x();
    pt.Y = point.y();
    roiManager.MouseDown(pt);
    previewStart = point;
    previewEnd = point;
    drawing = true;
}

void Camera::MouseMove(QPoint point)
{
    Point pt;
    pt.X = point.x();
    pt.Y = point.y();
    if (roiManager.MouseMove(pt))
    {
        previewEnd = point;
    }
}

#pragma region slot
void Camera::pushButton_LocalCameraScan_Clicked()
{
    ScanLocalCamera();
}

void Camera::pushButton_RemoteCameraScan_Clicked()
{
    ScanRemoteCamera();
}

void Camera::tabWidget_ConnectCamera_CurrentChanged(int tabIndex)
{
    if (tabIndex == 0) {
        ScanLocalCamera();
    }
    else if (tabIndex == 1)
    {
        ScanRemoteCamera();
    }
}

/*
* Connect local camera
*/
void Camera::pushButton_LocalCameraConnect_Clicked()
{
    if (ui->pushButton_LocalCameraConnect->text() == "Connect")
    {
        if (ui->lineEdit_LocalCameraName == nullptr || ui->lineEdit_LocalCameraName->text() == ""
            || ui->lineEdit_LocalCameraPort == nullptr || ui->lineEdit_LocalCameraPort->text() == "")
        {
            QMessageBox::warning(nullptr, "Warning", "Invalid Camera..");
            return;
        }
        if (pTmCamera == nullptr)
        {
            pTmCamera = new TmLocalCamera();
        }

        int row = ui->listWidget_LocalCameraList->currentRow();

        if (pTmCamera->Open((TmLocalCamInfo*)CamList[row]))
        {
            runCapThread = true;
            capThread = std::thread(std::bind(&Camera::CaptureFrame, this));
            ui->pushButton_LocalCameraConnect->setText("Disconnect");
            if (pTmCamera->GetDevName() == "TMC256B")
            {
                ui->tabWidget_Control->setCurrentIndex(0);
                ui->stackedWidget_SensorControl->setCurrentIndex(0);
            }
            else if (pTmCamera->GetDevName() == "TMC160B" || pTmCamera->GetDevName() == "TMC80B")
            {
                ui->tabWidget_Control->setCurrentIndex(0);
                ui->stackedWidget_SensorControl->setCurrentIndex(1);
            }
        }
    }
    else
    {
        DisconnectCamera();
        ui->pushButton_LocalCameraConnect->setText("Connect");
    }
}

/*
* Connect remote camera
*/
void Camera::pushButton_RemoteCameraConnect_Clicked()
{
    if (ui->pushButton_RemoteCameraConnect->text() == "Connect")
    {
        if (ui->lineEdit_RemoteCameraIp == nullptr || ui->lineEdit_RemoteCameraIp->text() == "")
        {
            QMessageBox::warning(nullptr, "Warning", "Invalid IP Address..");
            return;
        }
        if (pTmCamera == nullptr)
        {
            pTmCamera = new TmRemoteCamera();
            if (pTmCamera == nullptr)
            {
                return;
            }
        }

        int row = ui->listWidget_RemoteCameraList->currentRow();
        if (pTmCamera->Open((TmRemoteCamInfo*)CamList[row]))
        {
            runCapThread = true;
            capThread = std::thread(std::bind(&Camera::CaptureFrame, this));

            ui->pushButton_RemoteCameraConnect->setText("Disconnect");

            if (pTmCamera->GetDevName() == "TMC256E")
            {
                ui->tabWidget_Control->setCurrentIndex(0);
                ui->stackedWidget_SensorControl->setCurrentIndex(0);
            }
            else if (pTmCamera->GetDevName() == "TMC160E" || pTmCamera->GetDevName() == "TMC80E")
            {
                ui->tabWidget_Control->setCurrentIndex(0);
                ui->stackedWidget_SensorControl->setCurrentIndex(1);
            }

            ui->pushButton_GetNetworkConfiguration->setEnabled(true);
            ui->comboBox_IPAssignment->setEnabled(true);
            ui->lineEdit_IPAddress->setEnabled(true);
            ui->lineEdit_Netmask->setEnabled(true);
            ui->lineEdit_Gateway->setEnabled(true);
        }

    }
    else
    {
        DisconnectCamera();
        ui->pushButton_RemoteCameraConnect->setText("Connect");
    }
}

/*
* Select from the list of scanned local cameras
*/
void Camera::listWidget_LocalCameraList_CurrentRowChanged(int row)
{
    if (row < 0) return;
    TmLocalCamInfo* camInfo = (TmLocalCamInfo*)CamList[row];
    ui->lineEdit_LocalCameraName->setText(QString::fromStdString(camInfo->Name));
    ui->lineEdit_LocalCameraPort->setText(QString::fromStdString(camInfo->ComPort));
}

/*
* Select from the list of scanned remote cameras
*/
void Camera::listWidget_RemoteCameraList_CurrentRowChanged(int row)
{
    if (row < 0) return;
    TmRemoteCamInfo* camInfo = (TmRemoteCamInfo*)CamList[row];
    ui->lineEdit_RemoteCameraName->setText(QString::fromStdString(camInfo->Name));
    ui->lineEdit_RemoteCameraSerial->setText(QString::fromStdString(camInfo->SerialNumber));
    ui->lineEdit_RemoteCameraMac->setText(QString::fromStdString(camInfo->AddrMAC));
    ui->lineEdit_RemoteCameraIp->setText(QString::fromStdString(camInfo->AddrIP));
}

void Camera::comboBox_ColorMap_Changed(int index)
{
    if (pTmCamera == nullptr) return;
    pTmCamera->SetColorMap((ColormapTypes)index);
}

void Camera::checkBox_NoiseFiltering_toggled(bool toggle)
{
    if (pTmCamera == nullptr) return;
    pTmCamera->SetNoiseFiltering(toggle);
}

void Camera::comboBox_TemperatureUnit_Changed(int index)
{
    if (pTmCamera == nullptr) return;
    pTmCamera->SetTempUnit((TempUnit)index);
}

void Camera::radioButton_ShapeCursor_clicked()
{
    roiManager.SetSelectedRoiType(RoiType::Hand);
}

void Camera::radioButton_ShapeSpot_Clicked()
{
    roiManager.SetSelectedRoiType(RoiType::Spot);
}

void Camera::radioButton_ShapeLine_Clicked()
{
    roiManager.SetSelectedRoiType(RoiType::Line);
}

void Camera::radioButton_ShapeRectangle_Clicked()
{
    roiManager.SetSelectedRoiType(RoiType::Rect);
}
void Camera::radioButton_ShapeEllipse_Clicked()
{
    roiManager.SetSelectedRoiType(RoiType::Ellipse);
}

void Camera::pushButton_RemoveAllRoi_Clicked()
{
    roiManager.Clear();
    UpdateRoiListItems();
}

/*
* Add roi object
*/
void Camera::pushButton_AddRoiItem_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;

    if (ui->radioButton_RoiSpot->isChecked())
    {
        bool ok;
        int spotX = ui->lineEdit_SpotX->text().toInt(&ok);
        if (!ok) return;
        int spotY = ui->lineEdit_SpotY->text().toInt(&ok);
        if (!ok) return;
        roiManager.AddItem(RoiType::Spot, spotX, spotY);
        UpdateRoiListItems();
    }
    else if (ui->radioButton_RoiLine->isChecked())
    {
        bool ok;
        int x1 = ui->lineEdit_LineX1->text().toInt(&ok);
        if (!ok) return;
        int y1 = ui->lineEdit_LineY1->text().toInt(&ok);
        if (!ok) return;
        int x2 = ui->lineEdit_LineX2->text().toInt(&ok);
        if (!ok) return;
        int y2 = ui->lineEdit_LineY2->text().toInt(&ok);
        if (!ok) return;
        roiManager.AddItem(RoiType::Line, x1, y1, x2, y2);
        UpdateRoiListItems();
    }
    else if (ui->radioButton_RoiRectangle->isChecked())
    {
        bool ok;
        int x = ui->lineEdit_RectangleX->text().toInt(&ok);
        if (!ok) return;
        int y = ui->lineEdit_RectangleY->text().toInt(&ok);
        if (!ok) return;
        int w = ui->lineEdit_RectangleW->text().toInt(&ok);
        if (!ok) return;
        int h = ui->lineEdit_RectangleH->text().toInt(&ok);
        if (!ok) return;
        roiManager.AddItem(RoiType::Rect, x, y, w, h);
        UpdateRoiListItems();
    }
    else if (ui->radioButton_RoiEllipse->isChecked())
    {
        bool ok;
        int x = ui->lineEdit_EllipseX->text().toInt(&ok);
        if (!ok) return;
        int y = ui->lineEdit_EllipseY->text().toInt(&ok);
        if (!ok) return;
        int w = ui->lineEdit_EllipseW->text().toInt(&ok);
        if (!ok) return;
        int h = ui->lineEdit_EllipseH->text().toInt(&ok);
        if (!ok) return;
        roiManager.AddItem(RoiType::Ellipse, x, y, w, h);
        UpdateRoiListItems();
    }
}

/*
* Remove roi object
*/
void Camera::pushButton_RemoveRoiItem_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;

    int roiIndex = ui->comboBox_ListRoi->currentIndex();
    if (roiIndex >= 0)
    {
        if (roiManager.roiCount == 0) return;
        roiManager.RemoveAt(roiIndex);
        UpdateRoiListItems();
    }
}
#pragma region