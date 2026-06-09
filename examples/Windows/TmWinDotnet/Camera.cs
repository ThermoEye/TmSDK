/******************************************************************
 * Project: TmSDK
 * File: Camera.cs
 *
 * Description: This file contains the following implementations:
 * - Search and connect local/remote cameras
 * - Camera video preview
 * - Temperature measurement
 *
 * Version: 1.0.0
 * Copyright 2024. Thermoeye Inc. All rights reserved.
 *
 * History:
 *      2024-08-19: Initial version.
 ****************************************************************/
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using TmSDK;

namespace TmWinDotNet
{
    public partial class MainForm
    {
        // Represents the thermal camera object used for capturing frames.
        private TmCamera tmCamera;
        // Thread for running the frame capture process.
        private Thread captureThread = null;
        // Set true from UI thread to make frameCaptureThread exit its loop (cooperative shutdown).
        private volatile bool frameCaptureStopRequested;
        // Represents the frame object captured from the camera.
        private TmFrame tmframe;
        private bool pauseCapThread = false;
        // Callback-mode frame event context test object.
        private FrameCallbackTestContext callbackTestContext = null;
        private volatile bool reconnectingCamera;
        private LocalCamInfo reconnectLocalCamInfo;
        private RemoteCamInfo reconnectRemoteCamInfo;

        private const int CONNECTION_TIMEOUT = 1000;    // 3000 milliseconds

        // Test helper context class for callback registration.
        private class FrameCallbackTestContext
        {
            public string Tag { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public int FrameCount { get; set; } = 0;
            public DateTime LastFrameAt { get; set; } = DateTime.MinValue;
        }
        #region Camera Preview
        /// <summary>
        /// Thread method for continuously capturing frames from the thermal camera.
        /// </summary>
        private void frameCaptureThread()
        {
            System.Drawing.Point minLoc, maxLoc;
            double minVal, avgVal, maxVal;

            try
            {
                tmCamera.SetColorMap((int)ColormapTypes.Inferno);
                while (!frameCaptureStopRequested && tmCamera != null && tmCamera.IsOpen)
                {
                    if (!tmCamera.IsConnected())
                    {
                        //Console.WriteLine("Camera is not connected. Disconnecting camera.");
                        // OnCameraConnectionChanged(false);
                        // break;
                    }
                    if (pauseCapThread == true)
                    {
                        Thread.Sleep(1);
                        continue;
                    }
                    // Query a frame from the camera with the specified dimensions.
                    using (tmframe = tmCamera.QueryFrame(pictureBox_Preview.Width, pictureBox_Preview.Height))
                    {
                        if (frameCaptureStopRequested)
                            break;

                        if (tmframe != null)
                        {
                            Invoke(new Action(() =>
                            {
                                var bmp = tmframe.ToBitmap();
                                if (bmp != null)
                                {
                                    // Draw shapes on the bitmap based on ROI.
                                    DrawShapeObjects(bmp);

                                    pictureBox_Preview.Image?.Dispose();
                                    pictureBox_Preview.Image = bmp;

                                    if (tmCamera.Format == "Y16")
                                    {
                                        // Perform measurements on regions of interest (ROI).
                                        tmframe.DoMeasure(roiManager.GetItems());

                                        // Retrieve the minimum, average, and maximum values and their locations from the frame.
                                        tmframe.MinMaxLoc(out minVal, out avgVal, out maxVal, out minLoc, out maxLoc);

                                        label_MinimumTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(minVal), tmCamera.TempUnitSymbol);
                                        label_AverageTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(avgVal), tmCamera.TempUnitSymbol);
                                        label_MaximumTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(maxVal), tmCamera.TempUnitSymbol);
                                    }
                                }
                            }));
                        }
                    }
                }
            }
            catch (TimeoutException)
            {
                Tuple<ushort, string> status = new Tuple<ushort, string>((ushort)0xFFFF, "Unknown");
                Tuple<ushort, string> error = new Tuple<ushort, string>((ushort)0xFFFF, "Unknown");

                pictureBox_Preview.Image = null;

                if (tmCamera != null)
                {
                    status = tmCamera.tmControl.GetSystemStatus();
                    error = tmCamera.tmControl.GetSystemError();

                    Console.WriteLine("System Status : [0x{0:X2}] {1}", status.Item1, status.Item2);
                    Console.WriteLine("Error Status : [0x{0:X2}] {1}", error.Item1, error.Item2);

                    System.Threading.Thread.Sleep(1000);

                    tmCamera.Close();
                    tmCamera = null;
                }

                if (DialogResult.OK == MessageBox.Show("Can't get video frame from Camera.\r\n"
                                                      + "[0x" + status.Item1.ToString("X2") + "] " + status.Item2 + "\r\n"
                                                      + "[0x" + error.Item1.ToString("X2") + "] " + error.Item2,
                                                      "QueryFrame", MessageBoxButtons.OK))
                {
                    Invoke(new Action(() =>
                    {
                        tabControl_CameraConfig.Enabled = false;
                        tabControl_SensorConfig.Enabled = false;
                        comboBox_ColorMap.Enabled = false;
                        comboBox_TemperatureUnit.Enabled = false;
                        button_ConnectLocalCamera.Enabled = false;
                        button_ScanLocalCamera.Enabled = false;
                        button_ConnectRemoteCamera.Enabled = false;
                        button_ScanRemoteCamera.Enabled = false;
                        System.Threading.Thread.Sleep(2000);
                        button_ConnectLocalCamera.Text = "Connect";
                        button_ConnectLocalCamera.Enabled = true;
                        button_ScanLocalCamera.Enabled = true;
                        button_ConnectRemoteCamera.Text = "Connect";
                        button_ConnectRemoteCamera.Enabled = true;
                        button_ScanRemoteCamera.Enabled = true;
                    }));
                }
            }
            catch (TmException ex)
            {
                pictureBox_Preview.Image = null;

                if (tmCamera != null)
                {
                    try
                    {
                        tmCamera.Close();
                    }
                    catch
                    {
                        // ignore secondary errors during teardown
                    }
                    tmCamera = null;
                }

                if (DialogResult.OK == MessageBox.Show(
                    "Connection to camera lost or video stalled.\r\n" + ex.Message,
                    "QueryFrame",
                    MessageBoxButtons.OK))
                {
                    Invoke(new Action(() =>
                    {
                        tabControl_CameraConfig.Enabled = false;
                        tabControl_SensorConfig.Enabled = false;
                        comboBox_ColorMap.Enabled = false;
                        comboBox_TemperatureUnit.Enabled = false;
                        button_ConnectLocalCamera.Enabled = false;
                        button_ScanLocalCamera.Enabled = false;
                        button_ConnectRemoteCamera.Enabled = false;
                        button_ScanRemoteCamera.Enabled = false;
                        System.Threading.Thread.Sleep(2000);
                        button_ConnectLocalCamera.Text = "Connect";
                        button_ConnectLocalCamera.Enabled = true;
                        button_ScanLocalCamera.Enabled = true;
                        button_ConnectRemoteCamera.Text = "Connect";
                        button_ConnectRemoteCamera.Enabled = true;
                        button_ScanRemoteCamera.Enabled = true;
                        radioButton_CallbackModeOn.Enabled = false;
                        radioButton_CallbackModeOff.Enabled = false;
                    }));
                }
            }
            catch (ThreadInterruptedException) { }

            pictureBox_Preview.Image = null;
        }

        private void comboBox_ColorMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tmCamera != null)
            {
                tmCamera.SetColorMap(comboBox_ColorMap.SelectedIndex - 1);
            }
        }
        private void comboBox_TemperatureUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tmCamera != null)
            {
                tmCamera.SetTempUnit(comboBox_TemperatureUnit.SelectedIndex);
            }
        }
        private void checkBox_NoiseFiltering_CheckedChanged(object sender, EventArgs e)
        {
            if (tmCamera != null)
            {
                tmCamera.SetNoiseFiltering(checkBox_NoiseFiltering.Checked);
            }
        }
        #endregion

        #region Local Camera
        /// <summary>
        /// Scans and retrieves a list of local cameras connected to the system.
        /// Populates the listBox_LocalCameraScanList with the names and COM ports of detected local cameras.
        /// If at least one camera is found, selects the first camera in the list and displays its details in the text boxes.
        /// </summary>
        private void ScanLocalCameraList()
        {
            listBox_LocalCameraScanList.Tag = TmLocalCamera.GetCameraList();
            if (listBox_LocalCameraScanList.Tag == null)
            {
                return;
            }
            listBox_LocalCameraScanList.Items.Clear();
            foreach (var item in listBox_LocalCameraScanList.Tag as LocalCamInfo[])
            {
                listBox_LocalCameraScanList.Items.Add($"{item.Name}-{item.ComPort}");
            }

            if (listBox_LocalCameraScanList.Items.Count > 0)
            {
                listBox_LocalCameraScanList.SelectedIndex = 0;

                LocalCamInfo[] items = listBox_LocalCameraScanList.Tag as LocalCamInfo[];
                textBox_LocalCameraName.Text = items[listBox_LocalCameraScanList.SelectedIndex].Name;
                textBox_LocalCameraComPort.Text = items[listBox_LocalCameraScanList.SelectedIndex].ComPort;

                comboBox_LocalCameraVideoFormat.Items.Clear();
                if (items[listBox_LocalCameraScanList.SelectedIndex].MediaSourcesList != null 
                    && items[listBox_LocalCameraScanList.SelectedIndex].MediaSourcesList.Count > 0)
                {
                    foreach (var item in items[listBox_LocalCameraScanList.SelectedIndex].MediaSourcesList)
                    {
                        comboBox_LocalCameraVideoFormat.Items.Add($"{item.Format} : {item.Width}x{item.Height}@{item.FrameRate}fps-{item.BitPerPixel}bpp");
                    }
                    comboBox_LocalCameraVideoFormat.SelectedIndex = items[listBox_LocalCameraScanList.SelectedIndex].MediaIndex;
                }
            }
        }

        private void button_ScanLocalCamera_Click(object sender, EventArgs e)
        {
            this.ScanLocalCameraList();
        }

        private void listBox_LocalCameraList_Click(object sender, EventArgs e)
        {
            if (sender is ListBox listbox && listbox.SelectedIndex >= 0)
            {
                var items = listbox.Tag as LocalCamInfo[];
                if (items != null)
                {
                    textBox_LocalCameraName.Text = items[listbox.SelectedIndex].Name;
                    textBox_LocalCameraComPort.Text = items[listbox.SelectedIndex].ComPort;

                    comboBox_LocalCameraVideoFormat.Items.Clear();
                    if (items[listbox.SelectedIndex].MediaSourcesList != null)
                    {
                        foreach (var item in items[listbox.SelectedIndex].MediaSourcesList)
                        {
                            comboBox_LocalCameraVideoFormat.Items.Add($"{item.Format} : {item.Width}x{item.Height}@{item.FrameRate}fps-{item.BitPerPixel}bpp");
                        }
                        comboBox_LocalCameraVideoFormat.SelectedIndex = items[listbox.SelectedIndex].MediaIndex;
                    }
                }
            }
        }

        private void listBox_LocalCameraList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is ListBox listbox && listbox.SelectedIndex >= 0)
            {
                var items = listbox.Tag as LocalCamInfo[];
                if (items != null)
                {
                    textBox_LocalCameraName.Text = items[listbox.SelectedIndex].Name;
                    textBox_LocalCameraComPort.Text = items[listbox.SelectedIndex].ComPort;

                    if (button_ConnectLocalCamera.Text == "Connect")
                    {
                        if (listBox_LocalCameraScanList.SelectedIndex < 0)
                        {
                            MessageBox.Show("Invalid Camera Index.", "Connect", MessageBoxButtons.OK);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(textBox_LocalCameraName.Text))
                        {
                            MessageBox.Show("Invalid Camera Name.", "Connect", MessageBoxButtons.OK);
                            return;
                        }

                        if (string.IsNullOrWhiteSpace(textBox_LocalCameraComPort.Text))
                        {
                            MessageBox.Show("Invalid COM Port.", "Connect", MessageBoxButtons.OK);
                            return;
                        }

                        if (listBox_LocalCameraScanList.Tag == null)
                        {
                            MessageBox.Show("Invalid Camera List.", "Connect", MessageBoxButtons.OK);
                            return;
                        }

                        if (tmCamera == null)
                        {
                            LocalCamInfo localCamInfo = (listBox_LocalCameraScanList.Tag as LocalCamInfo[])[listBox_LocalCameraScanList.SelectedIndex];
                            tmCamera = new TmLocalCamera();
                            if (tmCamera.Open(localCamInfo))
                            {
                                RegisterConnectionHandler(localCamInfo, null);
                                this.captureThread = new Thread(new ThreadStart(frameCaptureThread));
                                this.frameCaptureStopRequested = false;
                                this.captureThread.Start();

                                button_ConnectLocalCamera.Text = "Disconnect";
                                ChangeUIWhenConnectCamera();
                                this.comboBox_IPAssignment.Enabled = false;
                                this.textBox_IPAddress.Enabled = false;
                                this.textBox_Netmask.Enabled = false;
                                this.textBox_Gateway.Enabled = false;
                                this.textBox_MainDNSServer.Enabled = false;
                                this.textBox_SubDNSServer.Enabled = false;
                                this.button_SetDefaultNetworkConfiguration.Enabled = false;
                                this.button_SystemReboot.Enabled = false;
                                this.radioButton_CallbackModeOn.Enabled = true;
                                this.radioButton_CallbackModeOff.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Fail to connect Local Camera.", "Connect", MessageBoxButtons.OK);

                                button_ConnectLocalCamera.Text = "Connect";
                                DisconnectCamera();
                                return;
                            }
                        }
                    }
                    else
                    {
                        DisconnectCamera();
                        button_ConnectLocalCamera.Text = "Connect";
                    }
                }
            }
        }

        private void comboBox_LocalCameraVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_LocalCameraVideoFormat.SelectedIndex >= 0)
            {
                LocalCamInfo[] items = listBox_LocalCameraScanList.Tag as LocalCamInfo[];
                items[listBox_LocalCameraScanList.SelectedIndex].MediaIndex = comboBox_LocalCameraVideoFormat.SelectedIndex;
            }
        }

        private void button_ConnectLocalCamera_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Text == "Connect")
                {
                    if (listBox_LocalCameraScanList.SelectedIndex < 0)
                    {
                        MessageBox.Show("Invalid Camera Index.", "Connect", MessageBoxButtons.OK);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(textBox_LocalCameraName.Text))
                    {
                        MessageBox.Show("Invalid Camera Name.", "Connect", MessageBoxButtons.OK);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(textBox_LocalCameraComPort.Text))
                    {
                        MessageBox.Show("Invalid COM Port.", "Connect", MessageBoxButtons.OK);
                        return;
                    }

                    if (listBox_LocalCameraScanList.Tag == null)
                    {
                        MessageBox.Show("Invalid Camera List.", "Connect", MessageBoxButtons.OK);
                        return;
                    }

                    if (tmCamera == null)
                    {
                        LocalCamInfo[] items = listBox_LocalCameraScanList.Tag as LocalCamInfo[];
                        int index = listBox_LocalCameraScanList.SelectedIndex;

                        tmCamera = new TmLocalCamera();
                        if (tmCamera.Open(items[index]))
                        {
                            RegisterConnectionHandler(items[index], null);
                            this.captureThread = new Thread(new ThreadStart(frameCaptureThread));
                            this.frameCaptureStopRequested = false;
                            this.captureThread.Start();

                            btn.Text = "Disconnect";
                            ChangeUIWhenConnectCamera();
                            this.comboBox_IPAssignment.Enabled = false;
                            this.textBox_IPAddress.Enabled = false;
                            this.textBox_Netmask.Enabled = false;
                            this.textBox_Gateway.Enabled = false;
                            this.textBox_MainDNSServer.Enabled = false;
                            this.textBox_SubDNSServer.Enabled = false;
                            this.button_SetDefaultNetworkConfiguration.Enabled = false;
                            this.button_SystemReboot.Enabled = false;
                            this.radioButton_CallbackModeOn.Enabled = true;
                            this.radioButton_CallbackModeOff.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to connect Local Camera.", "Connect", MessageBoxButtons.OK);

                            btn.Text = "Connect";
                            DisconnectCamera();
                            return;
                        }
                    }
                }
                else
                {
                    DisconnectCamera();
                    btn.Text = "Connect";
                }
            }
        }
        #endregion

        #region RemoteCamera
        /// <summary>
        /// Scans and retrieves a list of remote cameras available on the network.
        /// Populates the listBox_RemoteCameraScanList with the names and IP addresses of detected remote cameras.
        /// If at least one camera is found, selects the first camera in the list and displays its details in the text boxes.
        /// </summary>
        private void ScanRemoteCameraList()
        {
            listBox_RemoteCameraScanList.Tag = TmRemoteCamera.GetCameraList();
            if (listBox_RemoteCameraScanList.Tag == null)
            {
                return;
            }

            listBox_RemoteCameraScanList.Items.Clear();
            foreach (var item in listBox_RemoteCameraScanList.Tag as RemoteCamInfo[])
            {
                listBox_RemoteCameraScanList.Items.Add($"{item.Name}-{item.AddrIP}");
            }

            if (listBox_RemoteCameraScanList.Items.Count > 0)
            {
                listBox_RemoteCameraScanList.SelectedIndex = 0;

                RemoteCamInfo[] items = listBox_RemoteCameraScanList.Tag as RemoteCamInfo[];
                textBox_RemoteCameraAdapterIP.Text = items[listBox_RemoteCameraScanList.SelectedIndex].AdapterIP;
                textBox_RemoteCameraIPAddress.Text = items[listBox_RemoteCameraScanList.SelectedIndex].AddrIP;
                textBox_RemoteCameraMACAddress.Text = items[listBox_RemoteCameraScanList.SelectedIndex].AddrMAC;
                textBox_RemoteCameraSerialNumber.Text = items[listBox_RemoteCameraScanList.SelectedIndex].SerialNumber;
                textBox_RemoteCameraName.Text = items[listBox_RemoteCameraScanList.SelectedIndex].Name;
                textBox_RemoteCameraPartNumber.Text = items[listBox_RemoteCameraScanList.SelectedIndex].PartNumber;

                comboBox_RemoteCameraVideoFormat.Items.Clear();
                if (items[listBox_RemoteCameraScanList.SelectedIndex].MediaSourcesList != null)
                {
                    foreach (var item in items[listBox_RemoteCameraScanList.SelectedIndex].MediaSourcesList)
                    {
                        comboBox_RemoteCameraVideoFormat.Items.Add($"{item.Format} : {item.Width}x{item.Height}@{item.FrameRate}fps-{item.BitPerPixel}bpp");
                    }
                    comboBox_RemoteCameraVideoFormat.SelectedIndex = items[listBox_RemoteCameraScanList.SelectedIndex].MediaIndex;
                }
            }
        }

        private void button_ScanRemoteCamera_Click(object sender, EventArgs e)
        {
            this.ScanRemoteCameraList();
        }

        private void listBox_RemoteCameraList_Click(object sender, EventArgs e)
        {
            if (sender is ListBox listbox && listbox.SelectedIndex >= 0)
            {
                var items = listbox.Tag as RemoteCamInfo[];
                if (items != null)
                {
                    textBox_RemoteCameraAdapterIP.Text = items[listbox.SelectedIndex].AdapterIP;
                    textBox_RemoteCameraName.Text = items[listbox.SelectedIndex].Name;
                    textBox_RemoteCameraIPAddress.Text = items[listbox.SelectedIndex].AddrIP;
                    textBox_RemoteCameraMACAddress.Text = items[listbox.SelectedIndex].AddrMAC;
                    textBox_RemoteCameraSerialNumber.Text = items[listbox.SelectedIndex].SerialNumber;
                    textBox_RemoteCameraPartNumber.Text = items[listbox.SelectedIndex].PartNumber;

                    comboBox_RemoteCameraVideoFormat.Items.Clear();
                    if (items[listbox.SelectedIndex].MediaSourcesList != null)
                    {
                        foreach (var item in items[listbox.SelectedIndex].MediaSourcesList)
                        {
                            comboBox_RemoteCameraVideoFormat.Items.Add($"{item.Format} : {item.Width}x{item.Height}@{item.FrameRate}fps-{item.BitPerPixel}bpp");
                        }
                        comboBox_RemoteCameraVideoFormat.SelectedIndex = items[listbox.SelectedIndex].MediaIndex;
                    }
                }
            }
        }

        private void listBox_RemoteCameraList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is ListBox listbox && listbox.SelectedIndex >= 0)
            {
                var items = listbox.Tag as RemoteCamInfo[];
                if (items != null)
                {
                    textBox_RemoteCameraAdapterIP.Text = items[listbox.SelectedIndex].AdapterIP;
                    textBox_RemoteCameraName.Text = items[listbox.SelectedIndex].Name;
                    textBox_RemoteCameraIPAddress.Text = items[listbox.SelectedIndex].AddrIP;
                    textBox_RemoteCameraMACAddress.Text = items[listbox.SelectedIndex].AddrMAC;
                    textBox_RemoteCameraSerialNumber.Text = items[listbox.SelectedIndex].SerialNumber;
                    textBox_RemoteCameraPartNumber.Text = items[listbox.SelectedIndex].PartNumber;

                    if (button_ConnectRemoteCamera.Text == "Connect")
                    {
                        if (string.IsNullOrEmpty(textBox_RemoteCameraIPAddress.Text))
                        {
                            MessageBox.Show("Invalid AddrIP Address.", "Connect", MessageBoxButtons.OK);
                            return;
                        }

                        if (tmCamera == null)
                        {
                            RemoteCamInfo remoteCamInfo = (listBox_RemoteCameraScanList.Tag as RemoteCamInfo[])[listBox_RemoteCameraScanList.SelectedIndex];
                            tmCamera = new TmRemoteCamera();
                            remoteCamInfo.CamTimeout = CONNECTION_TIMEOUT;
                            if (tmCamera.Open(remoteCamInfo))
                            {
                                RegisterConnectionHandler(null, remoteCamInfo);
                                this.captureThread = new Thread(new ThreadStart(frameCaptureThread));
                                this.frameCaptureStopRequested = false;
                                this.captureThread.Start();

                                button_ConnectRemoteCamera.Text = "Disconnect";

                                ChangeUIWhenConnectCamera();
                            }
                            else
                            {
                                MessageBox.Show("Fail to connect Remote Camera.", "Connect", MessageBoxButtons.OK);

                                DisconnectCamera();
                                return;
                            }
                        }
                    }
                    else
                    {
                        DisconnectCamera();
                        button_ConnectRemoteCamera.Text = "Connect";
                    }
                }
            }
        }

        private void comboBox_RemoteCameraVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_RemoteCameraVideoFormat.SelectedIndex >= 0)
            {
                RemoteCamInfo[] items = listBox_RemoteCameraScanList.Tag as RemoteCamInfo[];
                items[listBox_RemoteCameraScanList.SelectedIndex].MediaIndex = comboBox_RemoteCameraVideoFormat.SelectedIndex;
            }
        }

        private void button_ConnectRemoteCamera_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Text == "Connect")
                {
                    if (string.IsNullOrEmpty(textBox_RemoteCameraIPAddress.Text))
                    {
                        MessageBox.Show("Invalid AddrIP Address.", "Connect", MessageBoxButtons.OK);
                        return;
                    }

                    if (tmCamera == null)
                    {
                        tmCamera = new TmRemoteCamera();
                        RemoteCamInfo[] items = listBox_RemoteCameraScanList.Tag as RemoteCamInfo[];
                        int index = listBox_RemoteCameraScanList.SelectedIndex;

                        items[index].CamTimeout = CONNECTION_TIMEOUT;
                        if (tmCamera.Open(items[index]))
                        {
                            RegisterConnectionHandler(null, items[index]);
                            this.captureThread = new Thread(new ThreadStart(frameCaptureThread));
                            this.frameCaptureStopRequested = false;
                            this.captureThread.Start();

                            btn.Text = "Disconnect";

                            ChangeUIWhenConnectCamera();

                            this.comboBox_IPAssignment.Enabled = true;
                            this.textBox_IPAddress.Enabled = true;
                            this.textBox_Netmask.Enabled = true;
                            this.textBox_Gateway.Enabled = true;
                            this.textBox_MainDNSServer.Enabled = true;
                            this.textBox_SubDNSServer.Enabled = true;
                            this.button_SetDefaultNetworkConfiguration.Enabled = true;
                            this.button_SystemReboot.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Fail to connect Remote Camera.", "Connect", MessageBoxButtons.OK);

                            DisconnectCamera();
                            return;
                        }
                    }
                }
                else
                {
                    DisconnectCamera();
                    btn.Text = "Connect";
                }
            }
        }
        #endregion

        private void ChangeUIWhenConnectCamera()
        {
            switch (tmCamera.Name)
            {
                case "ThermoCam160E":
                case "TMC160E":
                case "TMC160B":
                case "TMC160F":
                case "TMC80E":
                case "TMC80B":
                case "TMC80F":
                    panel_SensorControl_160.Visible = true;
                    panel_SensorControl_256.Visible = false;
                    panel_SensorControl_256G.Visible = false;
                    break;

                case "ThermoCam256E":
                case "TMC256E":
                case "TMC256B":
                case "TMC256I":
                case "TMC160IE":
                case "TMC160IB":
                case "TMC160I":
                    panel_SensorControl_160.Visible = false;
                    panel_SensorControl_256.Visible = true;
                    panel_SensorControl_256G.Visible = false;
                    break;

                case "TMC256GE":
                case "TMC256GB":
                case "TMC256G":
                case "TMC384GE":
                case "TMC384GB":
                case "TMC384G":
                    panel_SensorControl_160.Visible = false;
                    panel_SensorControl_256.Visible = false;
                    panel_SensorControl_256G.Visible = true;
                    break;
            }

            StatusLabel_Name.Text = tmCamera.Name;
            StatusLabel_CamInfo.Text = $"{tmCamera.Width}x{tmCamera.Height}@{tmCamera.FPS}Hz";

            button_ScanLocalCamera.Enabled = false;
            button_ScanRemoteCamera.Enabled = false;
            tabControl_CameraConfig.Enabled = true;
            tabControl_SensorConfig.Enabled = true;
            comboBox_ColorMap.Enabled = true;
            comboBox_TemperatureUnit.Enabled = true;
        }

        private void DisconnectCamera(bool clearReconnectState = true)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => DisconnectCamera(clearReconnectState)));
                return;
            }

            if (tmCamera != null)
            {
                tmCamera.EndAcquisition();
                tmCamera.UnregisterEventHandler();
                callbackTestContext = null;

                if (this.captureThread != null && this.captureThread.IsAlive && Thread.CurrentThread != this.captureThread)
                {
                    frameCaptureStopRequested = true;
                    // Unblock Invoke if the capture thread is inside it; loop also exits via frameCaptureStopRequested.
                    this.captureThread.Interrupt();
                    this.captureThread.Join();

                    System.Threading.Thread.Sleep(1000);
                }

                tmCamera.UnregisterConnectionEventHandler();
                tmCamera.Close();
                tmCamera = null;
            }

            frameCaptureStopRequested = false;
            if (clearReconnectState)
            {
                reconnectingCamera = false;
                reconnectLocalCamInfo = null;
                reconnectRemoteCamInfo = null;
            }

            panel_SensorControl_160.Visible = false;
            panel_SensorControl_256.Visible = false;
            panel_SensorControl_256G.Visible = false;

            StatusLabel_Name.Text = "";
            StatusLabel_CamInfo.Text = "";
            StatusLabel_fps.Text = "";

            // Clear Product Information
            label_ProductModelName.Text = "";
            label_ProductPartNumber.Text = "";
            label_ProductSerialNumber.Text = "";
            label_HardwareVersion.Text = "";
            label_BootloaderVersion.Text = "";
            label_FirmwareVersion.Text = "";

            // Clear Sensor Information
            label_SensorModelName.Text = "";
            label_SensorSerialNumber.Text = "";
            label_SensorUptime.Text = "";

            button_ScanLocalCamera.Enabled = true;
            button_ScanRemoteCamera.Enabled = true;
            button_ConnectLocalCamera.Enabled = true;
            button_ConnectRemoteCamera.Enabled = true;
            tabControl_CameraConfig.Enabled = false;
            tabControl_SensorConfig.Enabled = false;
            comboBox_ColorMap.Enabled = false;
            comboBox_TemperatureUnit.Enabled = false;
            radioButton_CallbackModeOn.Enabled = false;
            radioButton_CallbackModeOff.Enabled = false;
            radioButton_CallbackModeOff.Checked = true;
            pauseCapThread = false;
        }
		
        private void panel_VideoPreview_SizeChanged(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                pictureBox_Preview.Width = pictureBox_Preview.Height * 4 / 3;
                pictureBox_Preview.Location = new Point(panel.Width / 2 - pictureBox_Preview.Width / 2, pictureBox_Preview.Location.Y);

                StatusLabel_PreviewSize.Text = $"{pictureBox_Preview.Width}x{pictureBox_Preview.Height}";
            }
        }

        /// <summary>
        /// Handles callback mode radio button state changes.
        /// When callback mode is turned on, it pauses polling capture,
        /// registers the callback with an optional test context, and starts acquisition.
        /// When turned off, it stops acquisition, unregisters the callback,
        /// clears the context, and resumes polling capture.
        /// </summary>
        /// <param name="sender">The radio button that raised the event.</param>
        /// <param name="e">Standard event arguments.</param>
        private void radioButton_CallbackMode_CheckedChanged(object sender, EventArgs e)
        {
            if (tmCamera == null) return;

            if (sender is RadioButton btn && btn.Checked == true)
            {
                switch (btn.Name)
                {
                    case "radioButton_CallbackModeOn":
                        pauseCapThread = true;

                        if (callbackTestContext == null)
                        {
                            callbackTestContext = new FrameCallbackTestContext
                            {
                                Tag = "callback-mode-test"
                            };
                        }
                        tmCamera.RegisterEventHandler(OnFrameEventHandler, callbackTestContext);
                        tmCamera.BeginAcquisition();
                        break;

                    case "radioButton_CallbackModeOff":
                        tmCamera.EndAcquisition();
                        tmCamera.UnregisterEventHandler();
                        callbackTestContext = null;
                        pauseCapThread = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Callback-mode frame event handler.
        /// Renders the preview image and updates ROI-based temperature labels.
        /// </summary>
        /// <param name="frame">Frame received from SDK callback.</param>
        /// <param name="context">
        /// Optional callback context object passed during registration.
        /// This value can be <c>null</c>.
        /// </param>
        public void OnFrameEventHandler(TmFrame frame, object context)
        {
            if (frame == null || tmCamera == null || !tmCamera.IsOpen) return;

            try
            {
                if (context is FrameCallbackTestContext ctxObj)
                {
                    ctxObj.FrameCount++;
                    ctxObj.LastFrameAt = DateTime.UtcNow;
                }

                Invoke(new Action(() =>
                {
                    frame.Resize(pictureBox_Preview.Width, pictureBox_Preview.Height);
                    var bmp = frame.ToBitmap();
                    if (bmp == null) return;

                    DrawShapeObjects(bmp);
                    pictureBox_Preview.Image?.Dispose();
                    pictureBox_Preview.Image = bmp;

                    if (tmCamera.Format == "Y16")
                    {
                        frame.DoMeasure(roiManager.GetItems());
                        frame.MinMaxLoc(out double minVal, out double avgVal, out double maxVal, out System.Drawing.Point minLoc, out System.Drawing.Point maxLoc);

                        label_MinimumTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(minVal), tmCamera.TempUnitSymbol);
                        label_AverageTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(avgVal), tmCamera.TempUnitSymbol);
                        label_MaximumTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(maxVal), tmCamera.TempUnitSymbol);
                    }
                }));
            }
            catch
            {
                // Ignore callback errors to keep acquisition running.
            }
        }

        private void checkBox_VerticalFlip_CheckedChanged(object sender, EventArgs e)
        {
            tmCamera.SetFlipVertical(checkBox_VerticalFlip.Checked);
        }

        private void checkBox_HorizontalFlip_CheckedChanged(object sender, EventArgs e)
        {
            tmCamera.SetFlipHorizontal(checkBox_HorizontalFlip.Checked);
        }

        private void RegisterConnectionHandler(LocalCamInfo localCamInfo, RemoteCamInfo remoteCamInfo)
        {
            reconnectLocalCamInfo = localCamInfo;
            reconnectRemoteCamInfo = remoteCamInfo;
            tmCamera.RegisterConnectionEventHandler(OnCameraConnectionChanged);
        }

        private void OnCameraConnectionChanged(bool connected)
        {
            Console.WriteLine("Camera connection changed. Connected: {0}, Reconnecting: {1}", connected, reconnectingCamera);
            if (connected || reconnectingCamera)
            {
                return;
            }

            reconnectingCamera = true;
            LocalCamInfo localCamInfo = reconnectLocalCamInfo;
            RemoteCamInfo remoteCamInfo = reconnectRemoteCamInfo;

            BeginInvoke(new Action(() =>
            {
                var reconnectTimer = new System.Windows.Forms.Timer();
                reconnectTimer.Interval = 1;
                reconnectTimer.Tick += (sender, args) =>
                {
                    reconnectTimer.Stop();
                    reconnectTimer.Dispose();

                    DisconnectCamera(false);
                    reconnectingCamera = true;
                    reconnectLocalCamInfo = localCamInfo;
                    reconnectRemoteCamInfo = remoteCamInfo;
                    button_ConnectLocalCamera.Text = "Connect";
                    button_ConnectRemoteCamera.Text = "Connect";
                    ThreadPool.QueueUserWorkItem(_ => TryCameraConnection(localCamInfo, remoteCamInfo));
                };
                reconnectTimer.Start();
            }));
        }

        private void TryCameraConnection(LocalCamInfo localCamInfo, RemoteCamInfo remoteCamInfo)
        {
            try
            {
                for (int attempt = 0; attempt < 20 && reconnectingCamera; attempt++)
                {
                    TmCamera newCamera = null;
                    try
                    {
                        Console.WriteLine("Attempting to reconnect camera. Attempt {0}", attempt);
                        if (localCamInfo != null)
                        {
                            newCamera = new TmLocalCamera();
                            if (!newCamera.Open(localCamInfo))
                            {
                                newCamera = null;
                            }
                        }
                        else if (remoteCamInfo != null)
                        {
                            newCamera = new TmRemoteCamera();
                            if (!newCamera.Open(remoteCamInfo))
                            {
                                newCamera = null;
                            }
                        }

                        if (newCamera != null)
                        {
                            tmCamera = newCamera;
                            reconnectingCamera = false;
                            RegisterConnectionHandler(localCamInfo, remoteCamInfo);
                            frameCaptureStopRequested = false;
                            captureThread = new Thread(new ThreadStart(frameCaptureThread));
                            captureThread.Start();

                            BeginInvoke(new Action(() =>
                            {
                                ChangeUIWhenConnectCamera();
                                bool isLocal = localCamInfo != null;
                                button_ConnectLocalCamera.Text = isLocal ? "Disconnect" : "Connect";
                                button_ConnectRemoteCamera.Text = isLocal ? "Connect" : "Disconnect";
                                comboBox_IPAssignment.Enabled = !isLocal;
                                textBox_IPAddress.Enabled = !isLocal;
                                textBox_Netmask.Enabled = !isLocal;
                                textBox_Gateway.Enabled = !isLocal;
                                textBox_MainDNSServer.Enabled = !isLocal;
                                textBox_SubDNSServer.Enabled = !isLocal;
                                button_SetDefaultNetworkConfiguration.Enabled = !isLocal;
                                button_SystemReboot.Enabled = !isLocal;
                            }));
                            return;
                        }
                    }
                    catch
                    {
                        try
                        {
                            newCamera?.Close();
                        }
                        catch
                        {
                            // Ignore failed reconnect cleanup.
                        }
                    }

                    Thread.Sleep(1000);
                }

                BeginInvoke(new Action(() =>
                {
                    button_ConnectLocalCamera.Text = "Connect";
                    button_ConnectRemoteCamera.Text = "Connect";
                    reconnectLocalCamInfo = null;
                    reconnectRemoteCamInfo = null;
                    MessageBox.Show("Failed to reconnect camera.", "Reconnect", MessageBoxButtons.OK);
                }));
            }
            finally
            {
                reconnectingCamera = false;
            }
        }

    }
}

