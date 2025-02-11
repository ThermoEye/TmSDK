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
        // Represents the frame object captured from the camera.
        private TmFrame tmframe; 


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
                while (tmCamera != null && tmCamera.IsOpen == true)
                {
                    // Query a frame from the camera with the specified dimensions.
                    using (tmframe = tmCamera.QueryFrame(pictureBox_Preview.Width, pictureBox_Preview.Height))
                    {
                        if (tmframe != null)
                        {
                            Invoke(new Action(() =>
                            {
                                var bmp = tmframe.ToBitmap();
                                if (bmp != null)
                                {
                                    // Perform measurements on regions of interest (ROI).
                                    tmframe.DoMeasure(roiManager.GetItems());
                                    // Draw shapes on the bitmap based on ROI.
                                    DrawShapeObjects(bmp);

                                    pictureBox_Preview.Image?.Dispose();
                                    pictureBox_Preview.Image = bmp;


                                    // Retrieve the minimum, average, and maximum values and their locations from the frame.
                                    tmframe.MinMaxLoc(out minVal, out avgVal, out maxVal, out minLoc, out maxLoc);

                                    label_MinimumTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(minVal), tmCamera.TempUnitSymbol);
                                    label_AverageTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(avgVal), tmCamera.TempUnitSymbol);
                                    label_MaximumTemperature.Text = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(maxVal), tmCamera.TempUnitSymbol);
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
                        tabControl2.Enabled = false;
                        tabControl3.Enabled = false;
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
            catch (ThreadInterruptedException) { }

            pictureBox_Preview.Image = null;
        }

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
            }
        }

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
                textBox_RemoteCameraIPAddress.Text = items[listBox_RemoteCameraScanList.SelectedIndex].AddrIP;
                textBox_RemoteCameraMACAddress.Text = items[listBox_RemoteCameraScanList.SelectedIndex].AddrMAC;
                textBox_RemoteCameraSerialNumber.Text = items[listBox_RemoteCameraScanList.SelectedIndex].SerialNumber;
                textBox_RemoteCameraName.Text = items[listBox_RemoteCameraScanList.SelectedIndex].Name;
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

                        if (tmCamera.Open(items[index]))
                        {
                            this.captureThread = new Thread(new ThreadStart(frameCaptureThread));
                            this.captureThread.Start();

                            btn.Text = "Disconnect";

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
                    btn.Text = "Connect";
                }
            }
        }
        private void listBox_RemoteCameraList_Click(object sender, EventArgs e) 
        {
            if (sender is ListBox listbox && listbox.SelectedIndex >= 0)
            {
                var items = listbox.Tag as RemoteCamInfo[];
                if (items != null)
                {
                    textBox_RemoteCameraName.Text = items[listbox.SelectedIndex].Name;
                    textBox_RemoteCameraIPAddress.Text = items[listbox.SelectedIndex].AddrIP;
                    textBox_RemoteCameraMACAddress.Text = items[listbox.SelectedIndex].AddrMAC;
                    textBox_RemoteCameraSerialNumber.Text = items[listbox.SelectedIndex].SerialNumber;
                }
            }
        }
        private void button_ScanRemoteCamera_Click(object sender, EventArgs e) 
        {
            this.ScanRemoteCameraList();
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
                }
            }
        }
        private void button_ScanLocalCamera_Click(object sender, EventArgs e) 
        {
            this.ScanLocalCameraList();
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
                            this.captureThread = new Thread(new ThreadStart(frameCaptureThread));
                            this.captureThread.Start();

                            btn.Text = "Disconnect";
                            ChangeUIWhenConnectCamera();
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
        
        private void comboBox_ColorMap_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (tmCamera != null)
            {
                tmCamera.SetColorMap(comboBox_ColorMap.SelectedIndex);
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

        private void panel_VideoPreview_SizeChanged(object sender, EventArgs e) 
        {
            if (sender is Panel panel)
            {
                pictureBox_Preview.Width = pictureBox_Preview.Height * 4 / 3;
                pictureBox_Preview.Location = new Point(panel.Width / 2 - pictureBox_Preview.Width / 2, pictureBox_Preview.Location.Y);

                StatusLabel_PreviewSize.Text = $"{pictureBox_Preview.Width}x{pictureBox_Preview.Height}";
            }
        }

        private void ChangeUIWhenConnectCamera()
        {
            switch (tmCamera.Name)
            {
                case "ThermoCam160E":
                case "TMC160E":
                case "TMC160B":
                case "TMC80E":
                case "TMC80B":
                    panel_SensorControl_160E.Visible = true;
                    panel_SensorControl_256E.Visible = false;
                    break;

                case "ThermoCam256E":
                case "TMC256E":
                case "TMC256B":
                    panel_SensorControl_160E.Visible = false;
                    panel_SensorControl_256E.Visible = true;
                    break;
            }

            StatusLabel_Name.Text = tmCamera.Name;

            button_ScanLocalCamera.Enabled = false;
            button_ScanRemoteCamera.Enabled = false;

            tabControl2.Enabled = true;
            tabControl3.Enabled = true;
            comboBox_ColorMap.Enabled = true;
            comboBox_TemperatureUnit.Enabled = true;
        }

        private void DisconnectCamera()
        {
            if (tmCamera != null)
            {
                if(this.captureThread != null && this.captureThread.IsAlive)
                {
                    // force to terminate frameThread
                    this.captureThread.Interrupt();
                    // Wait for frameThread to end.
                    this.captureThread.Join();

                    System.Threading.Thread.Sleep(1000);
                }

                tmCamera.Close();
                tmCamera = null;
            }

            panel_SensorControl_160E.Visible = false;
            panel_SensorControl_256E.Visible = false;

            button_ScanLocalCamera.Enabled = true;
            button_ScanRemoteCamera.Enabled = true;
            button_ConnectLocalCamera.Enabled = true;
            button_ConnectRemoteCamera.Enabled = true;
            tabControl2.Enabled = false;
            tabControl3.Enabled = false;
            comboBox_ColorMap.Enabled = false;
            comboBox_TemperatureUnit.Enabled = false;
        }
    }
}

