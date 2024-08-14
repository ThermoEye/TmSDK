
#include <codecvt>
#include <cwchar>
#include <iostream>

#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget* parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    //ui->tabWidget_ConnectCamera->setCurrentIndex(0);
    //tabWidget_ConnectCamera_CurrentChanged(0);

    ui->comboBox_IPAssignment->addItem(QString::fromStdString("DHCP"));
    ui->comboBox_IPAssignment->addItem(QString::fromStdString("Static"));

    ui->radioButton_ShapeCursor->setChecked(true);

    ui->label_Preview->installEventFilter(this);

    // Create drawing label
    ui->label_Draw->setAttribute(Qt::WA_TransparentForMouseEvents);  // Make it transparent for mouse events
    ui->label_Draw->setStyleSheet("background-color: rgba(0, 0, 0, 0);");  // Transparent background

    ui->stackedWidget_SensorControl->setCurrentIndex(0);

    if (ui->tabWidget_ConnectCamera->currentIndex() == 0)
    {
        ScanLocalCamera();
    }
    else
    {
        ScanRemoteCamera();
    }
}

MainWindow::~MainWindow()
{
    delete ui;
}

uint32_t convert_ansi_to_unicode_string(std::wstring& unicode, const std::string& c_string)
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

void MainWindow::UpdateRoiListItems()
{
    ui->comboBox_ListRoi->clear();

    for (TmSDK::RoiObject* item : roiManager.Items) {
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

std::string MainWindow::GetTempStringUnit(double raw)
{
    std::string strTemp;
    std::stringstream ss;
    if (pTmCamera != nullptr && pTmCamera->IsOpen() == true)
    {
        switch (pTmCamera->GetTempUnit())
        {
        case TmSDK::TempUnit::RAW:
            ss << std::fixed << std::setprecision(0) << raw << " " << pTmCamera->GetTempUnitSymbol();
            break;
        case TmSDK::TempUnit::CELSIUS:
            ss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(raw) << " " << pTmCamera->GetTempUnitSymbol();
            break;
        case TmSDK::TempUnit::FAHRENHEIT:
            ss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(raw) << " " << pTmCamera->GetTempUnitSymbol();
            break;
        case TmSDK::TempUnit::KELVIN:
            ss << std::fixed << std::setprecision(2) << pTmCamera->GetTemperature(raw) << " " << pTmCamera->GetTempUnitSymbol();
            break;
        }
    }
    
    return ss.str();
}

void MainWindow::DrawShapeObjects(QImage& image) {
    if (image.isNull()) return;

    QPainter painter(&image);
    if (!painter.isActive()) return;

    QFont font("Verdana", 7);
    painter.setFont(font);
    painter.setRenderHint(QPainter::Antialiasing);
    QString strDraw;
    QSizeF sizeDraw;
    QColor crimson(0xDC, 0x14, 0x3C); // #dc143c
    QColor cornflowerblue(0x64, 0x95, 0xED); // #6495ed

    for (size_t i = 0; i < roiManager.Items.size(); ++i)
    {
        TmSDK::RoiObject* item = roiManager.Items[i];
        switch (item->Type) {
        case TmSDK::RoiType::Spot:
        {
            TmSDK::RoiSpot* shape = static_cast<TmSDK::RoiSpot*>(item);
            // draw shape
            painter.setPen(QPen(Qt::cyan, 1));
            painter.drawEllipse(QPoint(shape->Spot.X - 1, shape->Spot.Y - 1), 2, 2);

            // draw object id
            strDraw = QString("ROI%1").arg(shape->Index);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::cyan);
            painter.drawText(shape->Spot.X - sizeDraw.width() / 2, shape->Spot.Y - 9, strDraw);

            // draw temp
            std::string tempUnit = GetTempStringUnit(shape->MaxLoc.Value);
            std::wstring wStr;
            convert_ansi_to_unicode_string(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::green);
            painter.drawText(shape->Spot.X - sizeDraw.width() / 2, shape->Spot.Y + 14, strDraw);
            break;
        }

        case TmSDK::RoiType::Line:
        {
            TmSDK::RoiLine* shape = static_cast<TmSDK::RoiLine*>(item);
            // draw shape
            painter.setPen(QPen(Qt::yellow, 1));
            painter.setBrush(Qt::NoBrush);
            painter.drawLine(shape->Start.X, shape->Start.Y, shape->End.X, shape->End.Y);

            // draw object id
            QString strDraw = QString("ROI%1").arg(shape->Index);
            painter.setPen(Qt::cyan);
            painter.drawText(shape->Start.X, shape->Start.Y - 9, strDraw);

            // draw max temp
            painter.setPen(crimson);
            painter.setBrush(crimson);
            painter.drawPolygon(QPolygon() << QPoint(shape->MaxLoc.Location.X, shape->MaxLoc.Location.Y)
                << QPoint(shape->MaxLoc.Location.X - 4, shape->MaxLoc.Location.Y - 4)
                << QPoint(shape->MaxLoc.Location.X + 4, shape->MaxLoc.Location.Y - 4));
            std::string tempUnit = GetTempStringUnit(shape->MaxLoc.Value);
            std::wstring wStr;
            convert_ansi_to_unicode_string(wStr, tempUnit);
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
            convert_ansi_to_unicode_string(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(cornflowerblue);
            painter.drawText(shape->MinLoc.Location.X - sizeDraw.width() / 2, shape->MinLoc.Location.Y + 15, strDraw);

            // draw average temp
            tempUnit = GetTempStringUnit(shape->AvgLoc.Value);
            convert_ansi_to_unicode_string(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::green);
            painter.drawText(shape->Start.X + (shape->End.X - shape->Start.X) / 2 - sizeDraw.width() / 2,
                shape->Start.Y + (shape->End.Y - shape->Start.Y) / 2 + 2, strDraw);
            break;
        }
        case TmSDK::RoiType::Rect:
        {
            TmSDK::RoiRect* shape = static_cast<TmSDK::RoiRect*>(item);
            std::string tempUnit;
            std::wstring wStr;
            // draw shape
            painter.setPen(QPen(Qt::yellow, 1));
            painter.setBrush(Qt::NoBrush);
            painter.drawRect(shape->Rect.X, shape->Rect.Y, shape->Rect.Width, shape->Rect.Height);

            // draw object id
            QString strDraw = QString("ROI%1").arg(shape->Index);
            painter.setPen(Qt::cyan);
            painter.drawText(shape->Rect.X, shape->Rect.Y - 9, strDraw);

            // draw max temp
            painter.setPen(crimson);
            painter.setBrush(crimson);
            painter.drawPolygon(QPolygon() << QPoint(shape->MaxLoc.Location.X, shape->MaxLoc.Location.Y)
                << QPoint(shape->MaxLoc.Location.X - 4, shape->MaxLoc.Location.Y - 4)
                << QPoint(shape->MaxLoc.Location.X + 4, shape->MaxLoc.Location.Y - 4));
            tempUnit = GetTempStringUnit(shape->MaxLoc.Value);
            convert_ansi_to_unicode_string(wStr, tempUnit);
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
            convert_ansi_to_unicode_string(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(cornflowerblue);
            painter.drawText(shape->MinLoc.Location.X - sizeDraw.width() / 2, shape->MinLoc.Location.Y + 15, strDraw);

            // draw average temp
            tempUnit = GetTempStringUnit(shape->AvgLoc.Value);
            convert_ansi_to_unicode_string(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::green);
            painter.drawText(shape->Rect.X + shape->Rect.Width / 2 - sizeDraw.width() / 2,
                shape->Rect.Y + shape->Rect.Height + 2, strDraw);
            break;
        }
        case TmSDK::RoiType::Ellipse:
        {
            TmSDK::RoiEllipse* shape = static_cast<TmSDK::RoiEllipse*>(item);
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
            painter.drawText(shape->Ellipse.X + shape->Ellipse.Width / 2 - sizeDraw.width() / 2, shape->Ellipse.Y - 9, strDraw);

            // draw max temp
            painter.setPen(crimson);
            painter.setBrush(crimson);
            painter.drawPolygon(QPolygon() << QPoint(shape->MaxLoc.Location.X, shape->MaxLoc.Location.Y)
                << QPoint(shape->MaxLoc.Location.X - 4, shape->MaxLoc.Location.Y - 4)
                << QPoint(shape->MaxLoc.Location.X + 4, shape->MaxLoc.Location.Y - 4));
            tempUnit = GetTempStringUnit(shape->MaxLoc.Value);
            convert_ansi_to_unicode_string(wStr, tempUnit);
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
            convert_ansi_to_unicode_string(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(cornflowerblue);
            painter.drawText(shape->MinLoc.Location.X - sizeDraw.width() / 2, shape->MinLoc.Location.Y + 15, strDraw);

            // draw average temp
            tempUnit = GetTempStringUnit(shape->AvgLoc.Value);
            convert_ansi_to_unicode_string(wStr, tempUnit);
            strDraw = QString::fromStdWString(wStr);
            sizeDraw = painter.fontMetrics().size(Qt::TextSingleLine, strDraw);
            painter.setPen(Qt::green);
            painter.drawText(shape->Ellipse.X + shape->Ellipse.Width / 2 - sizeDraw.width() / 2, shape->Ellipse.Y + shape->Ellipse.Height + 2, strDraw);
        }

        }
    }
}

bool MainWindow::eventFilter(QObject* obj, QEvent* event)
{
    TmSDK::Point pt;

    if (obj == ui->label_Preview && event->type() == QEvent::MouseButtonPress)
    {
        QMouseEvent* mouseEvent = static_cast<QMouseEvent*>(event);
        if (mouseEvent->button() == Qt::LeftButton)
        {
            pt.X = mouseEvent->pos().x();
            pt.Y = mouseEvent->pos().y();
            roiManager.MouseDown(pt);
            //previewStart.setX(pt.X);
            //previewStart.setY(pt.Y);
            previewStart = mouseEvent->pos();
            previewEnd = mouseEvent->pos();
            //std::cout << "mouse press" << endl;
            drawing = true;
        }
    }
    else if (obj == ui->label_Preview && event->type() == QEvent::MouseButtonRelease)
    {
        QMouseEvent* mouseEvent = static_cast<QMouseEvent*>(event);
        if (mouseEvent->button() == Qt::LeftButton)
        {
            pt.X = mouseEvent->pos().x();
            pt.Y = mouseEvent->pos().y();
            if (roiManager.MouseUp(pt))
            {
                ui->radioButton_ShapeCursor->setChecked(true);
                UpdateRoiListItems();
                drawing = false;
                UpdateDrawingLabel();
            }
            //std::cout << "mouse release" << endl;
        }
    }
    else if (event->type() == QEvent::MouseMove)
    {
        QMouseEvent* mouseEvent = static_cast<QMouseEvent*>(event);
        pt.X = mouseEvent->pos().x();
        pt.Y = mouseEvent->pos().y();
        if (roiManager.MouseMove(pt))
        {
            previewEnd = mouseEvent->pos();
            UpdateDrawingLabel();
        }
    }

    return false;
}

void MainWindow::UpdateDrawingLabel()
{
    QPixmap pixmap(ui->label_Draw->size());
    pixmap.fill(Qt::transparent);  // Clear the pixmap with transparent color

    if (drawing && roiManager.SelectedItem() != nullptr) {
        QPainter painter(&pixmap);
        painter.setRenderHint(QPainter::Antialiasing);
        painter.setPen(Qt::yellow);
        switch (roiManager.GetSelectedRoiType())
        {
        case TmSDK::RoiType::Hand:
            break;
        case TmSDK::RoiType::Spot:
        {
            TmSDK::RoiSpot* shape = static_cast<TmSDK::RoiSpot*>(roiManager.SelectedItem());
            //painter.drawEllipse(QPoint(shape->Spot.X - 1, shape->Spot.Y - 1), 2, 2);
            painter.drawEllipse(shape->Spot.X - 1, shape->Spot.Y - 1, 2, 2);
            break;
        }
        case TmSDK::RoiType::Line:
        {
            TmSDK::RoiLine* shape = static_cast<TmSDK::RoiLine*>(roiManager.SelectedItem());
            painter.drawLine(shape->Start.X, shape->Start.Y, shape->End.X, shape->End.Y);
            break;
        }
        case TmSDK::RoiType::Rect:
        {
            TmSDK::RoiRect* shape = static_cast<TmSDK::RoiRect*>(roiManager.SelectedItem());
            painter.drawRect(shape->Rect.X, shape->Rect.Y, shape->Rect.Width, shape->Rect.Height);
            break;
        }
        case TmSDK::RoiType::Ellipse:
            TmSDK::RoiEllipse* shape = static_cast<TmSDK::RoiEllipse*>(roiManager.SelectedItem());
            painter.drawEllipse(shape->Ellipse.X, shape->Ellipse.Y, shape->Ellipse.Width, shape->Ellipse.Height);
            break;
        }
    }

    ui->label_Draw->setPixmap(pixmap);
}

void MainWindow::ScanLocalCamera()
{
    ui->lineEdit_LocalCameraName->setText("");
    ui->lineEdit_LocalCameraPort->setText("");
    ui->listWidget_LocalCameraList->clear();
    for (auto cam : CamList)
    {
        delete cam;
    }
    CamList.clear();
    for (auto cam : TmSDK::TmLocalCamera::GetCameraList())
    {
        QString qstr = QString::fromStdString(cam.Name + " - " + cam.ComPort);
        ui->listWidget_LocalCameraList->addItem(qstr);
        CamList.push_back(new TmSDK::TmLocalCamInfo(cam.Name, cam.ComPort, cam.Index));
    }
    if (!CamList.empty())
    {
        ui->listWidget_LocalCameraList->setCurrentRow(0);
        TmSDK::TmLocalCamInfo* camInfo = (TmSDK::TmLocalCamInfo*)CamList[0];
        ui->lineEdit_LocalCameraName->setText(QString::fromStdString(camInfo->Name));
        ui->lineEdit_LocalCameraPort->setText(QString::fromStdString(camInfo->ComPort));
    }
}

void MainWindow::ScanRemoteCamera()
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
    for (auto cam : TmSDK::TmRemoteCamera::GetCameraList())
    {
        std::cout << "ScanRemoteCamera()..." << endl;
        QString qstr = QString::fromStdString(cam.Name + " - " + cam.AddrIP);
        ui->listWidget_RemoteCameraList->addItem(qstr);
        CamList.push_back(new TmSDK::TmRemoteCamInfo(cam.Name, cam.SerialNumber, cam.AddrMAC, cam.AddrIP));
    }
    if (!CamList.empty())
    {
        ui->listWidget_RemoteCameraList->setCurrentRow(0);
        TmSDK::TmRemoteCamInfo* camInfo = (TmSDK::TmRemoteCamInfo*)CamList[0];
        ui->lineEdit_RemoteCameraName->setText(QString::fromStdString(camInfo->Name));
        ui->lineEdit_RemoteCameraSerial->setText(QString::fromStdString(camInfo->SerialNumber));
        ui->lineEdit_RemoteCameraMac->setText(QString::fromStdString(camInfo->AddrMAC));
        ui->lineEdit_RemoteCameraIp->setText(QString::fromStdString(camInfo->AddrIP));
    }
}

void MainWindow::DisconnectCamera()
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

void MainWindow::closeEvent(QCloseEvent* event) 
{
    DisconnectCamera();
    QApplication::quit();
    close();
}


void MainWindow::processMeasurements(TmSDK::TmFrame* pFrame)
{
    double minVal, avgVal, maxVal;
    TmSDK::Point minLoc, maxLoc;
    uint8_t* bitMap = pFrame->ToBitmap(TmSDK::ColorOrder::COLOR_RGB);
    QImage image(bitMap, ui->label_Preview->width(), ui->label_Preview->height(), QImage::Format_RGB888);
    DrawShapeObjects(image);
    QPixmap pixMap = QPixmap::fromImage(image);
    ui->label_Preview->setPixmap(pixMap);
    ui->label_Preview->show();

    pFrame->DoMeasure(roiManager.Items);
    pFrame->MinMaxLoc(minVal, avgVal, maxVal, minLoc, maxLoc);

    if (pTmCamera == nullptr)    return;

    std::wstring wideStr;
    convert_ansi_to_unicode_string(wideStr, pTmCamera->GetTempUnitSymbol());
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
    //delete pFrame;
    pFrame->Release();
}

void MainWindow::FrameCapture()
{
    std::cout << "Start FrameCapture!" << endl;
    if (pTmCamera == nullptr || pTmCamera->IsOpen() == false)
    {
        return;
    }
    int colorMapIndex = (int)TmSDK::ColormapTypes::Inferno + 1;
    int tempUnitIndex = (int)TmSDK::TempUnit::CELSIUS;
    ui->comboBox_ColorMap->setCurrentIndex(colorMapIndex);
    ui->comboBox_TemperatureUnit->setCurrentIndex(tempUnitIndex);
    pTmCamera->SetColorMap((TmSDK::ColormapTypes)colorMapIndex);
    pTmCamera->SetTempUnit((TmSDK::TempUnit)tempUnitIndex);

    //double minVal, avgVal, maxVal;
    //TmSDK::Point minLoc, maxLoc;

    while (runCapThread)
    {
        TmSDK::TmFrame* pFrame = pTmCamera->QueryFrame(ui->label_Preview->width(), ui->label_Preview->height());
        if (pFrame != nullptr)
        {
            future = QtConcurrent::run(this, &MainWindow::processMeasurements, pFrame);
            futureWatcher.setFuture(future);
        }
    }
}


#pragma region Slot
void MainWindow::pushButton_LocalCameraConnect_Clicked()
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
            pTmCamera = new TmSDK::TmLocalCamera();
        }

        int row = ui->listWidget_LocalCameraList->currentRow();

        if (pTmCamera->Open((TmSDK::TmLocalCamInfo*)CamList[row]))
        {
            std::cout << "Open Success" << endl;
            runCapThread = true;
            //std::thread capThread(std::bind(&MainWindow::FrameCapture, this));
            capThread = std::thread(std::bind(&MainWindow::FrameCapture, this));
            //capThread.detach();
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

void MainWindow::pushButton_RemoteCameraConnect_Clicked()
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
            pTmCamera = new TmSDK::TmRemoteCamera();
            if (pTmCamera == nullptr)
            {
                return;
            }
        }

        int row = ui->listWidget_RemoteCameraList->currentRow();
        if (pTmCamera->Open((TmSDK::TmRemoteCamInfo*)CamList[row]))
        {
            runCapThread = true;
            capThread = std::thread(std::bind(&MainWindow::FrameCapture, this));
            
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

void MainWindow::tabWidget_ConnectCamera_CurrentChanged(int tabIndex)
{
    if (tabIndex == 0) {
        ScanLocalCamera();
    }
    else if (tabIndex == 1)
    {
        ScanRemoteCamera();
    }
}

void MainWindow::listWidget_LocalCameraList_CurrentRowChanged(int row)
{
    if (row < 0) return;
    TmSDK::TmLocalCamInfo* camInfo = (TmSDK::TmLocalCamInfo*)CamList[row];
    ui->lineEdit_LocalCameraName->setText(QString::fromStdString(camInfo->Name));
    ui->lineEdit_LocalCameraPort->setText(QString::fromStdString(camInfo->ComPort));
}
void MainWindow::listWidget_RemoteCameraList_CurrentRowChanged(int row)
{
    if (row < 0) return;
    TmSDK::TmRemoteCamInfo* camInfo = (TmSDK::TmRemoteCamInfo*)CamList[row];
    ui->lineEdit_RemoteCameraName->setText(QString::fromStdString(camInfo->Name));
    ui->lineEdit_RemoteCameraSerial->setText(QString::fromStdString(camInfo->SerialNumber));
    ui->lineEdit_RemoteCameraMac->setText(QString::fromStdString(camInfo->AddrMAC));
    ui->lineEdit_RemoteCameraIp->setText(QString::fromStdString(camInfo->AddrIP));
}
void MainWindow::pushButton_GetProductInformation_Clicked()
{
    std::string modelName;
    std::string serialNumber;
    std::string hardwareVersion;
    std::string bootloaderVersion;
    std::string firmwareVersion;

    modelName = pTmCamera->pTmControl->GetProductModelName();
    serialNumber = pTmCamera->pTmControl->GetProductSerialNumber();
    hardwareVersion = pTmCamera->pTmControl->GetHardwareVersion();
    bootloaderVersion = pTmCamera->pTmControl->GetBootloaderVersion();
    firmwareVersion = pTmCamera->pTmControl->GetFirmwareVersion();

    ui->label_ProductModelName->setText(QString::fromStdString(modelName));
    ui->label_ProductSerialNumber->setText(QString::fromStdString(serialNumber));
    ui->label_HardwareVersion->setText(QString::fromStdString(hardwareVersion));
    ui->label_BootloaderVersion->setText(QString::fromStdString(bootloaderVersion));
    ui->label_FirmwareVersion->setText(QString::fromStdString(firmwareVersion));

    pTmCamera->pTmControl->GetSystemStatus();
}
void MainWindow::pushButton_GetGainModeState_Clicked()
{
    int gainMode = pTmCamera->pTmControl->GetGainModeState();

    if (gainMode == 0)
    {
        // Low Gain
        ui->radioButton_GainModeHigh->setChecked(false);
        ui->radioButton_GainModeLow->setChecked(true);
    }
    else
    {
        // High Gain
        ui->radioButton_GainModeHigh->setChecked(true);
        ui->radioButton_GainModeLow->setChecked(false);
    }
}
void MainWindow::pushButton_SetGainModeState_Clicked()
{
    if (ui->radioButton_GainModeHigh->isChecked() == true && ui->radioButton_GainModeLow->isChecked() == false)
    {
        pTmCamera->pTmControl->SetGainModeState(1);
    }
    else if (ui->radioButton_GainModeHigh->isChecked() == false && ui->radioButton_GainModeLow->isChecked() == true)
    {
        pTmCamera->pTmControl->SetGainModeState(0);
    }
}

void MainWindow::radioButton_ShapeCursor_clicked()
{
    roiManager.SetSelectedRoiType(TmSDK::RoiType::Hand);
}
void MainWindow::radioButton_ShapeSpot_Clicked()
{
    roiManager.SetSelectedRoiType(TmSDK::RoiType::Spot);
}
void MainWindow::radioButton_ShapeLine_Clicked()
{
    roiManager.SetSelectedRoiType(TmSDK::RoiType::Line);
}
void MainWindow::radioButton_ShapeRectangle_Clicked()
{
    roiManager.SetSelectedRoiType(TmSDK::RoiType::Rect);
}
void MainWindow::radioButton_ShapeEllipse_Clicked()
{
    roiManager.SetSelectedRoiType(TmSDK::RoiType::Ellipse);
}
void MainWindow::pushButton_RemoveAllRoi_Clicked()
{
    roiManager.Clear();
    UpdateRoiListItems();
}
void MainWindow::comboBox_ColorMap_Changed(int index)
{
    if (pTmCamera == nullptr) return;
    pTmCamera->SetColorMap((TmSDK::ColormapTypes)index);
}
void MainWindow::checkBox_NoiseFiltering_toggled(bool toggle)
{
    if (pTmCamera == nullptr) return;
    pTmCamera->SetNoiseFiltering(toggle);
}
void MainWindow::comboBox_TemperatureUnit_Changed(int index)
{
    if (pTmCamera == nullptr) return;
    pTmCamera->SetTempUnit((TmSDK::TempUnit)index);
}
void MainWindow::pushButton_GetSensorInformation_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    std::string modelName = pTmCamera->pTmControl->GetSensorModelName();
    std::string serialNumber = pTmCamera->pTmControl->GetSensorSerialNumber();
    std::string uptime = pTmCamera->pTmControl->GetSensorUptime();

    ui->label_SensorModelName->setText(QString::fromStdString(modelName));
    ui->label_SensorSerialNumber->setText(QString::fromStdString(serialNumber));
    ui->label_SensorUptime->setText(QString::fromStdString(uptime));
}
void MainWindow::pushButton_SoftwareUpdateFileBrowse_Clicked()
{
    QString fileName = QFileDialog::getOpenFileName(this, "Open File", "", "Binary Files (*.bin);;All Files (*)");
    if (!fileName.isEmpty()) 
    {
        QFile file(fileName);
        if (file.open(QIODevice::ReadOnly)) 
        {
            std::string vendorName;
            std::string productName;
            std::string versionName;
            std::string buildTime;
            int fileSize;

            bool verify = pTmCamera->pTmControl->CheckFirmware(fileName.toStdString(), vendorName, productName, versionName, buildTime, fileSize);
            ui->label_VendorName->setText(QString::fromStdString(vendorName));
            ui->label_ProductName->setText(QString::fromStdString(productName));
            ui->label_SoftwareVersion->setText(QString::fromStdString(versionName));
            ui->label_BuildTime->setText(QString::fromStdString(buildTime));
            ui->label_BinarySize->setText(QString::number(fileSize));
            ui->lineEdit_SoftwareUpdateFilePath->setText(fileName);
            if (verify == true)
            {
                ui->pushButton_StartSoftwareUpdate->setText("Start");
                ui->pushButton_StartSoftwareUpdate->setEnabled(true);
            }
            else
            {
                ui->pushButton_StartSoftwareUpdate->setText("Reselect proper binary file");
                ui->pushButton_StartSoftwareUpdate->setEnabled(false);
            }
        }
    }
}
void MainWindow::pushButton_StartSoftwareUpdate_Clicked()
{
    if (ui->pushButton_StartSoftwareUpdate->text() == "Start")
    {


        QString fileName = ui->lineEdit_SoftwareUpdateFilePath->text();
        QFile file(fileName);
        if (file.open(QIODevice::ReadOnly))
        {
            QByteArray fileData = file.readAll();
            if (pTmCamera->pTmControl->OpenFirmware(fileName.toStdString()) > 0)
            {
                if (runCapThread == true)
                {
                    runCapThread = false;
                    capThread.join();
                }
                ui->label_SoftwareUpdateStatus->setText("Start firmware update.");
                ui->pushButton_StartSoftwareUpdate->setText("Wait...");
                ui->pushButton_StartSoftwareUpdate->setEnabled(false);
                ui->pushButton_SoftwareUpdateFileBrowse->setEnabled(false);

                FirmwareWorker* worker = nullptr;

                worker = new FirmwareWorker(pTmCamera, this);
                connect(worker, &FirmwareWorker::progressChanged, this, &MainWindow::update_ProgressChanged);
                connect(worker, &FirmwareWorker::workCompleted, this, &MainWindow::update_RunWorkerCompleted);
                worker->start();
            }
            else
            {
                ui->label_SoftwareUpdateStatus->setText("File open fail.");
                QMessageBox::about(this, "Software Update", "Please check firmware binary file.");
            }
        }
    }
}
void MainWindow::update_ProgressChanged(int progress)
{
    ui->label_SoftwareUpdateStatus->setText(QString("Downloading... %1%").arg(progress));
    ui->progressBar_SoftwareUpdate->setValue(progress);
}
void MainWindow::update_RunWorkerCompleted()
{
    bool result = pTmCamera->pTmControl->CloseFirmware();
    if (result == false)
    {
        ui->label_SoftwareUpdateStatus->setText("Update failed.");
    }
    else
    {
        ui->label_SoftwareUpdateStatus->setText("Download complete. Reboot...");
    }

    pTmCamera->Close();
    pTmCamera = nullptr;

    if (result == true)
    {
        QMessageBox::about(this, "Software Update", "Reconnect camera device.");
    }
    else
    {
        QMessageBox::about(this, "Software Update", "Please check firmware binary file.");
    }
    ui->label_SoftwareUpdateStatus->setText("");
    ui->progressBar_SoftwareUpdate->setValue(0);
    ui->lineEdit_SoftwareUpdateFilePath->setText("");
    ui->pushButton_StartSoftwareUpdate->setText("Browse and Select Binary File");
    ui->pushButton_SoftwareUpdateFileBrowse->setEnabled(true);
    //ui->tabControl2.Enabled = false;
    //ui->tabControl3.Enabled = false;
    ui->comboBox_ColorMap->setEnabled(false);
    ui->comboBox_TemperatureUnit->setEnabled(false);
    ui->pushButton_LocalCameraConnect->setEnabled(false);
    ui->pushButton_LocalCameraScan->setEnabled(false);
    ui->pushButton_RemoteCameraConnect->setEnabled(false);
    ui->pushButton_RemoteCameraScan->setEnabled(false);
    ui->pushButton_LocalCameraConnect->setText("Connect");
    ui->pushButton_LocalCameraConnect->setEnabled(true);
    ui->pushButton_LocalCameraScan->setEnabled(true);
    ui->pushButton_RemoteCameraConnect->setText("Connect");
    ui->pushButton_RemoteCameraConnect->setEnabled(true);
    ui->pushButton_RemoteCameraScan->setEnabled(true);
}
void MainWindow::pushButton_GetFlatFieldCorrection_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    int ffcMode = pTmCamera->pTmControl->GetFlatFieldCorrectionMode();
    if (ffcMode == 0)   // Manual
    {
        ui->radioButton_FlatFieldCorrectionManual->setChecked(true);
        ui->radioButton_FlatFieldCorrectionAutomatic->setChecked(false);
    }
    else
    {
        ui->radioButton_FlatFieldCorrectionManual->setChecked(false);
        ui->radioButton_FlatFieldCorrectionAutomatic->setChecked(true);
    }
}
void MainWindow::pushButton_SetFlatFieldCorrection_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    int ffcMode = 0;
    if (ui->radioButton_FlatFieldCorrectionManual->isChecked() == true)
    {
        ffcMode = 0;
    }
    else if (ui->radioButton_FlatFieldCorrectionAutomatic->isChecked() == true)
    {
        ffcMode = 1;
    }
    pTmCamera->pTmControl->SetFlatFieldCorrectionMode(ffcMode);
}
void MainWindow::pushButton_RunFlatFieldCorrection_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (pTmCamera->pTmControl->RunFlatFieldCorrection())
    {
        QMessageBox::StandardButton resBtn = QMessageBox::information(
            this, "Flat Field Correction", "Success to run Flat Field Correction",
            QMessageBox::Ok
        );
    }
    else
    {
        QMessageBox::StandardButton resBtn = QMessageBox::information(
            this, "Flat Field Correction", "Fail to run Flat Field Correction",
            QMessageBox::Ok
        );
    }
}
void MainWindow::pushButton_GetFluexParams_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    double emissivity = 0;
    double atmosphericTransmittance = 0;
    double atmosphericTemperature = 0;
    double ambientReflectionTemperature = 0;
    double distance = 0;
    if (pTmCamera->pTmControl->GetFluxParameters(emissivity, atmosphericTransmittance, atmosphericTemperature, ambientReflectionTemperature, distance))
    {
        ui->doubleSpinBox_FluexParamEmissivity->setValue(emissivity);
        ui->doubleSpinBox_FluexParamAtmosphericTransmittance->setValue(atmosphericTransmittance);
        ui->doubleSpinBox_FluexParamAtmosphericTemperature->setValue(atmosphericTemperature);
        ui->doubleSpinBox_FluexParamAmbientReflectionTemp->setValue(ambientReflectionTemperature);
        ui->doubleSpinBox_FluexParamDistance->setValue(distance);

        ui->doubleSpinBox_FluexParamEmissivity->setEnabled(true);
        ui->doubleSpinBox_FluexParamAtmosphericTransmittance->setEnabled(true);
        ui->doubleSpinBox_FluexParamAtmosphericTemperature->setEnabled(true);
        ui->doubleSpinBox_FluexParamAmbientReflectionTemp->setEnabled(true);
        ui->doubleSpinBox_FluexParamDistance->setEnabled(true);
        ui->pushButton_SetFluexParams->setEnabled(true);
    }
    else
    {
        QMessageBox::about(this, "Flux Parameters", "Fail to get Flux Parameters.");
    }
}
void MainWindow::pushButton_SetFluexParams_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    double emissivity = ui->doubleSpinBox_FluexParamEmissivity->value();
    double atmosphericTransmittance = ui->doubleSpinBox_FluexParamAtmosphericTransmittance->value();
    double atmosphericTemperature = ui->doubleSpinBox_FluexParamAtmosphericTemperature->value();
    double ambientReflectionTemperature = ui->doubleSpinBox_FluexParamAmbientReflectionTemp->value();
    double distance = ui->doubleSpinBox_FluexParamDistance->value();

    if (pTmCamera->pTmControl->SetFluxParameters(emissivity, atmosphericTransmittance, atmosphericTemperature, ambientReflectionTemperature, distance))
    {
        QMessageBox::about(this, "Flux Parameters", "Success to set Flux Parameters");
    }
    else
    {
        QMessageBox::about(this, "Flux Parameters", "Fail to set Flux Parameters");
    }
}
void MainWindow::pushButton_GetFFCParams_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    double maxInterval;
    double autoTriggerThreshold;
    if (pTmCamera->pTmControl->GetFlatFieldCorrectionParameters(maxInterval, autoTriggerThreshold))
    {
        ui->doubleSpinBox_FFCParam_MaxInterval->setValue(maxInterval);
        ui->doubleSpinBox_FFCParamAutoTriggerThreshold->setValue(autoTriggerThreshold);

        ui->doubleSpinBox_FFCParam_MaxInterval->setEnabled(true);
        ui->doubleSpinBox_FFCParamAutoTriggerThreshold->setEnabled(true);
        ui->pushButton_SetFFCParams->setEnabled(true);
    }
}
void MainWindow::pushButton_SetFFCParams_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    double maxInterval = ui->doubleSpinBox_FFCParam_MaxInterval->value();
    double autoTriggerThreshold = ui->doubleSpinBox_FFCParamAutoTriggerThreshold->value();
    if (pTmCamera->pTmControl->SetFlatFieldCorrectionParameters(maxInterval, autoTriggerThreshold))
    {
        QMessageBox::about(this, "FFC Parameters", "Success to set FFC Parameters");
    }
    else
    {
        QMessageBox::about(this, "FFC Parameters", "Fail to set FFC Parameters");
    }
}
void MainWindow::pushButton_StoreUserSensorConfig_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (pTmCamera->pTmControl->StoreUserSensorConfig())
    {
        QMessageBox::about(this, "Sensor Control", "Success to store user sensor configurations");
    }
    else
    {
        QMessageBox::about(this, "Sensor Control", "Fail to store user sensor configurations");
    }
}
void MainWindow::pushButton_RestoreDefaultSensorConfig_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    ui->pushButton_RestoreDefaultSensorConfig->setText("Wait...");
    ui->pushButton_RestoreDefaultSensorConfig->setEnabled(false);

    if (runCapThread == true)
    {
        runCapThread = false;
        capThread.join();
    }

    pTmCamera->pTmControl->RestoreDefaultSensorConfig();
    QThread::msleep(1000);
    pTmCamera->Close();
    pTmCamera = nullptr;

    QThread::msleep(1000);

    QMessageBox::about(this, "TmSDK", "Reboot... Reconnect camera device.");

    //tabControl2.Enabled = false;
    //tabControl3.Enabled = false;
    //comboBox_ColorMap.Enabled = false;
    //comboBox_TemperatureUnit.Enabled = false;
    //button_ConnectLocalCamera.Enabled = false;
    //button_ScanLocalCamera.Enabled = false;
    //button_ConnectRemoteCamera.Enabled = false;
    //button_ScanRemoteCamera.Enabled = false;
    ui->pushButton_LocalCameraConnect->setText("Connect");
    ui->pushButton_RemoteCameraConnect->setText("Connect");
    ui->pushButton_LocalCameraConnect->setEnabled(true);
    ui->pushButton_LocalCameraScan->setEnabled(true);
    ui->pushButton_RemoteCameraConnect->setEnabled(true);
    ui->pushButton_RemoteCameraScan->setEnabled(true);
    ui->pushButton_RestoreDefaultSensorConfig->setEnabled(true);
}
void MainWindow::pushButton_RemoveRoiItem_Clicked()
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
void MainWindow::pushButton_AddRoiItem_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (ui->radioButton_RoiSpot->isChecked())
    {
        bool ok;
        int spotX = ui->lineEdit_SpotX->text().toInt(&ok);
        if (!ok) return;
        int spotY = ui->lineEdit_SpotY->text().toInt(&ok);
        if (!ok) return;
        roiManager.AddItem(TmSDK::RoiType::Spot, spotX, spotY);
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
        roiManager.AddItem(TmSDK::RoiType::Line, x1, y1, x2, y2);
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
        roiManager.AddItem(TmSDK::RoiType::Rect, x, y, w, h);
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
        roiManager.AddItem(TmSDK::RoiType::Ellipse, x, y, w, h);
        UpdateRoiListItems();
    }
}

void MainWindow::pushButton_GetNetworkConfiguration_Clicked()
{
    std::string mac;
    std::string ipAssign;
    std::string ip;
    std::string netmask;
    std::string gateway;
    std::string dns;
    std::string dns2;
    pTmCamera->pTmControl->GetNetworkConfiguration(mac, ipAssign, ip, netmask, gateway, dns, dns2);

    ui->lineEdit_MACAddress->setText(QString::fromStdString(mac));
    if (ipAssign == "DHCP")
    {
        ui->comboBox_IPAssignment->setCurrentIndex(0);
    }
    else
    {
        ui->comboBox_IPAssignment->setCurrentIndex(1);
    }
    ui->lineEdit_IPAddress->setText(QString::fromStdString(ip));
    ui->lineEdit_Netmask->setText(QString::fromStdString(netmask));
    ui->lineEdit_Gateway->setText(QString::fromStdString(gateway));
    ui->lineEdit_MainDNSServer->setText(QString::fromStdString(dns));
    ui->lineEdit_SubDNSServer->setText(QString::fromStdString(dns2));
    ui->pushButton_SetNetworkConfiguration->setEnabled(true);
}

void MainWindow::pushButton_SetNetworkConfiguration_Clicked()
{
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (pTmCamera->pTmControl->SetNetworkConfiguration(
        ui->comboBox_IPAssignment->currentText().toStdString(),
        ui->lineEdit_IPAddress->text().toStdString(),
        ui->lineEdit_Netmask->text().toStdString(),
        ui->lineEdit_Gateway->text().toStdString(),
        ui->lineEdit_MainDNSServer->text().toStdString(),
        ui->lineEdit_SubDNSServer->text().toStdString()))
    {
        QMessageBox::about(this, "Network", "Succes to set Network Configuration.");
    }
    else
    {
        QMessageBox::about(this, "Network", "Fail to set Network Configuration.");
    }

}
void MainWindow::pushButton_SetDefaultNetworkConfiguration_Clicked()
{
    std::string ipAssignDef;
    std::string ipDef;
    std::string netmaskDef;
    std::string gatewayDef;
    std::string dnsDef;
    std::string dns2Def;
    if (pTmCamera == nullptr || pTmCamera->pTmControl == nullptr) return;
    if (pTmCamera->pTmControl->SetDefaultNetworkConfiguration(ipAssignDef, ipDef, netmaskDef, gatewayDef, dnsDef, dns2Def))
    {
        ui->comboBox_IPAssignment->setCurrentText(QString::fromStdString(ipAssignDef));
        ui->lineEdit_IPAddress->setText(QString::fromStdString(ipDef));
        ui->lineEdit_Netmask->setText(QString::fromStdString(netmaskDef));
        ui->lineEdit_Gateway->setText(QString::fromStdString(gatewayDef));
        ui->lineEdit_MainDNSServer->setText(QString::fromStdString(dnsDef));
        ui->lineEdit_SubDNSServer->setText(QString::fromStdString(dns2Def));
    }
    else
    {
        QMessageBox::about(this, "Network", "Fail to set Network Configuration.");
    }
}
void MainWindow::pushButton_SystemReboot_Clicked()
{
    if (runCapThread == true)
    {
        runCapThread = false;
        capThread.join();
    }

    pTmCamera->pTmControl->RebootDevice();
    QThread::msleep(1000);
    pTmCamera->Close();
    pTmCamera = nullptr;

    QThread::msleep(1000);

    QMessageBox::about(this, "TmSDK", "Reboot... Reconnect camera device.");
    //tabControl2.Enabled = false;
    //tabControl3.Enabled = false;
    //comboBox_ColorMap.Enabled = false;
    //comboBox_TemperatureUnit.Enabled = false;
    //button_ConnectLocalCamera.Enabled = false;
    //button_ScanLocalCamera.Enabled = false;
    //button_ConnectRemoteCamera.Enabled = false;
    //button_ScanRemoteCamera.Enabled = false;
    ui->pushButton_LocalCameraConnect->setText("Connect");
    ui->pushButton_RemoteCameraConnect->setText("Connect");
    ui->pushButton_LocalCameraConnect->setText("Connect");
    ui->pushButton_RemoteCameraConnect->setText("Connect");
    ui->pushButton_LocalCameraConnect->setEnabled(true);
    ui->pushButton_LocalCameraScan->setEnabled(true);
    ui->pushButton_RemoteCameraConnect->setEnabled(true);
    ui->pushButton_RemoteCameraScan->setEnabled(true);
}
void MainWindow::pushButton_GetFluxParameters_160E_Clicked()
{
    double sceneEmissivity;
    double backgroundTemperature;
    double windowTransmission;
    double windowTemperature;
    double atmosphericTransmission;
    double atmosphericTemperature;
    double windowReflection;
    double windowReflectedTemperature;

    if (pTmCamera->pTmControl->GetFluxParameters(sceneEmissivity, backgroundTemperature,
        windowTransmission, windowTemperature,
        atmosphericTransmission, atmosphericTemperature,
        windowReflection, windowReflectedTemperature))
    {
        ui->doubleSpinBox_FluxParam160E_SceneEmissivity->setValue(sceneEmissivity);
        ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->setValue(backgroundTemperature);
        ui->doubleSpinBox_FluxParam160E_WindowTransmission->setValue(windowTransmission);
        ui->doubleSpinBox_FluxParam160E_WindowTemperature->setValue(windowTemperature);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->setValue(atmosphericTransmission);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->setValue(atmosphericTemperature);
        ui->doubleSpinBox_FluxParam160E_WindowReflection->setValue(windowReflection);
        ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setValue(windowReflectedTemperature);
    }
    ui->doubleSpinBox_FluxParam160E_SceneEmissivity->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_WindowTransmission->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_WindowTemperature->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_WindowReflection->setEnabled(true);
    ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setEnabled(true);
    ui->pushButton_SetFluxParameters_160E->setEnabled(true);
}
void MainWindow::pushButton_SetFluxParameters_160E_Clicked()
{
    double sceneEmissivitySet = ui->doubleSpinBox_FluxParam160E_SceneEmissivity->value();
    double backgroundTemperatureSet = ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->value();
    double windowTransmissionSet = ui->doubleSpinBox_FluxParam160E_WindowTransmission->value();
    double windowTemperatureSet = ui->doubleSpinBox_FluxParam160E_WindowTemperature->value();
    double atmosphericTransmissionSet = ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->value();
    double atmosphericTemperatureSet = ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->value();
    double windowReflectionSet = ui->doubleSpinBox_FluxParam160E_WindowReflection->value();
    double windowReflectedTemperatureSet = ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->value();

    if (pTmCamera->pTmControl->SetFluxParameters(sceneEmissivitySet, backgroundTemperatureSet,
        windowTransmissionSet, windowTemperatureSet,
        atmosphericTransmissionSet, atmosphericTemperatureSet,
        windowReflectionSet, windowReflectedTemperatureSet))
    {
        QMessageBox::about(this, "Flux Parameters", "Succes to set Flux Parameters.");
    }
    else
    {
        QMessageBox::about(this, "Flux Parameters", "Fail to set Flux Parameters.");
    }
}
void MainWindow::pushButton_GetGainModeState_160E_Clicked()
{
    int gainModeState_160E = pTmCamera->pTmControl->GetGainModeState();

    if (gainModeState_160E == 0) // High
    {
        ui->radioButton_GainModeStateHigh_160E->setChecked(true);
        ui->radioButton_GainModeStateLow_160E->setChecked(false);
        ui->radioButton_GainModeStateAuto_160E->setChecked(false);
    }
    else if (gainModeState_160E == 1) // Low
    {
        ui->radioButton_GainModeStateHigh_160E->setChecked(false);
        ui->radioButton_GainModeStateLow_160E->setChecked(true);
        ui->radioButton_GainModeStateAuto_160E->setChecked(false);
    }
    else if (gainModeState_160E == 2) // Auto
    {
        ui->radioButton_GainModeStateHigh_160E->setChecked(false);
        ui->radioButton_GainModeStateLow_160E->setChecked(false);
        ui->radioButton_GainModeStateAuto_160E->setChecked(true);
    }
    else
    {
        ui->radioButton_GainModeStateHigh_160E->setChecked(false);
        ui->radioButton_GainModeStateLow_160E->setChecked(false);
        ui->radioButton_GainModeStateAuto_160E->setChecked(false);

        QMessageBox::about(this, "Gain Mode", "Fail to get Gain Mode State");
    }
}
void MainWindow::pushButton_SetGainModeState_160E_Clicked()
{
    int gainModeStateSet_160E = -1;

    ui->pushButton_SetGainModeState_160E->setText("Wait...");
    ui->pushButton_SetGainModeState_160E->setEnabled(false);

    if ((ui->radioButton_GainModeStateHigh_160E->isChecked() == true) 
        && (ui->radioButton_GainModeStateLow_160E->isChecked() == false)
        && (ui->radioButton_GainModeStateAuto_160E->isChecked() == false))
        gainModeStateSet_160E = 0; // High
    else if ((ui->radioButton_GainModeStateHigh_160E->isChecked() == false)
        && (ui->radioButton_GainModeStateLow_160E->isChecked() == true)
        && (ui->radioButton_GainModeStateAuto_160E->isChecked() == false))
        gainModeStateSet_160E = 1; // Low
    else if ((ui->radioButton_GainModeStateHigh_160E->isChecked() == false)
        && (ui->radioButton_GainModeStateLow_160E->isChecked() == false)
        && (ui->radioButton_GainModeStateAuto_160E->isChecked() == true))
        gainModeStateSet_160E = 2; // Auto

    if ((gainModeStateSet_160E != -1) && pTmCamera->pTmControl->SetGainModeState(gainModeStateSet_160E))
    {
        QMessageBox::about(this, "Gain Mode", "Success to set Gain Mode State");
    }
    else
    {
        QMessageBox::about(this, "Gain Mode", "Fail to set Gain Mode State");
    }

    ui->pushButton_SetGainModeState_160E->setText("Set");
    ui->pushButton_SetGainModeState_160E->setEnabled(true);
}
void MainWindow::pushButton_GetFlatFieldCorrectionMode_160E_Clicked()
{
    int ffcMode_160E = pTmCamera->pTmControl->GetFlatFieldCorrectionMode();

    if (ffcMode_160E == 0) // Manual
    {
        ui->radioButton_FlatFieldCorrectionManual_160E->setChecked(true);
        ui->radioButton_FlatFieldCorrectionAutomatic_160E->setChecked(false);
    }
    else if (ffcMode_160E == 1) // Automatic
    {
        ui->radioButton_FlatFieldCorrectionManual_160E->setChecked(false);
        ui->radioButton_FlatFieldCorrectionAutomatic_160E->setChecked(true);
    }
    else
    {
        ui->radioButton_FlatFieldCorrectionManual_160E->setChecked(false);
        ui->radioButton_FlatFieldCorrectionAutomatic_160E->setChecked(false);

        QMessageBox::about(this, "Flat Field Correction", "Fail to get Flat Field Correction Mode");
    }
}
void MainWindow::pushButton_SetFlatFieldCorrectionMode_160E_Clicked()
{
    int ffcModeSet_160E = -1;

    if ((ui->radioButton_FlatFieldCorrectionManual_160E->isChecked() == true) && (ui->radioButton_FlatFieldCorrectionAutomatic_160E->isChecked() == false))
        ffcModeSet_160E = 0; // Manual
    else if ((ui->radioButton_FlatFieldCorrectionManual_160E->isChecked() == false) && (ui->radioButton_FlatFieldCorrectionAutomatic_160E->isChecked() == true))
        ffcModeSet_160E = 1; // Automatic

    if (ffcModeSet_160E != -1)
        pTmCamera->pTmControl->SetFlatFieldCorrectionMode(ffcModeSet_160E);
    else
        QMessageBox::about(this, "Flat Field Correction", "Fail to set Flat Field Correction Mode");
}
void MainWindow::pushButton_RunFlatFieldCorrection_160E_Clicked()
{
    ui->pushButton_RunFlatFieldCorrection_160E->setText("Wait...");
    ui->pushButton_RunFlatFieldCorrection_160E->setEnabled(false);

    if (pTmCamera->pTmControl->RunFlatFieldCorrection())
    {
        QMessageBox::about(this, "Flat Field Correction", "Success to run Flat Field Correction");
    }
    else
    {
        QMessageBox::about(this, "Flat Field Correction", "Fail to run Flat Field Correction");
    }

    ui->pushButton_RunFlatFieldCorrection_160E->setText("Run");
    ui->pushButton_RunFlatFieldCorrection_160E->setEnabled(true);
}
void MainWindow::pushButton_RestoreDefaultFluxParameters_160E_Clicked()
{
    double sceneEmissivityDef;
    double backgroundTemperatureDef;
    double windowTransmissionDef;
    double windowTemperatureDef;
    double atmosphericTransmissionDef;
    double atmosphericTemperatureDef;
    double windowReflectionDef;
    double windowReflectedTemperatureDef;

    if (pTmCamera->pTmControl->SetDefaultFluxParameters(sceneEmissivityDef, backgroundTemperatureDef,
        windowTransmissionDef, windowTemperatureDef,
        atmosphericTransmissionDef, atmosphericTemperatureDef,
        windowReflectionDef, windowReflectedTemperatureDef))
    {
        ui->doubleSpinBox_FluxParam160E_SceneEmissivity->setValue(sceneEmissivityDef);
        ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->setValue(backgroundTemperatureDef);
        ui->doubleSpinBox_FluxParam160E_WindowTransmission->setValue(windowTransmissionDef);
        ui->doubleSpinBox_FluxParam160E_WindowTemperature->setValue(windowTemperatureDef);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->setValue(atmosphericTransmissionDef);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->setValue(atmosphericTemperatureDef);
        ui->doubleSpinBox_FluxParam160E_WindowReflection->setValue(windowReflectionDef);
        ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setValue(windowReflectedTemperatureDef);

        ui->doubleSpinBox_FluxParam160E_SceneEmissivity->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_BackgroundTemperature->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_WindowTransmission->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_WindowTemperature->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTransmission->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_AtmosphericTemperature->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_WindowReflection->setEnabled(true);
        ui->doubleSpinBox_FluxParam160E_WindowReflectedTemperature->setEnabled(true);
        ui->lineEdit_FluxParam160E_SceneEmissivityRange->setEnabled(true);
        ui->lineEdit_FluxParam160E_BackgroundTemperatureRange->setEnabled(true);
        ui->lineEdit_FluxParam160E_WindowTransmissionRange->setEnabled(true);
        ui->lineEdit_FluxParam160E_WindowTemperatureRange->setEnabled(true);
        ui->lineEdit_FluxParam160E_AtmosphericTransmissionRange->setEnabled(true);
        ui->lineEdit_FluxParam160E_AtmosphericTemperatureRange->setEnabled(true);
        ui->lineEdit_FluxParam160E_WindowReflectionRange->setEnabled(true);
        ui->lineEdit_FluxParam160E_WindowReflectedTemperatureRange->setEnabled(true);
        ui->pushButton_SetFluxParameters_160E->setEnabled(true);

        QMessageBox::about(this, "Flux Parameters", "Succes to restore Factory Default Flux Parameters.");
    }
    else
    {
        QMessageBox::about(this, "Flux Parameters", "Fail to restore Factory Default Flux Parameters.");
    }
}

void MainWindow::pushButton_LocalCameraScan_Clicked()
{
    ScanLocalCamera();
}
void MainWindow::pushButton_RemoteCameraScan_Clicked()
{
    ScanRemoteCamera();
}
#pragma region
