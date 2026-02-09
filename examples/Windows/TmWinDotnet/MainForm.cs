using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

using TmSDK;
using System.IO.Ports;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TmWinDotNet
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ScanLocalCameraList();
            this.ScanRemoteCameraList();
            comboBox_ColorMap.SelectedIndex = 15;       // Inferno
            comboBox_TemperatureUnit.SelectedIndex = 1; // Celsius
        }
        
        private void MainForm_FormClosed(object sender, EventArgs e)
        {
            DisconnectCamera();
        }
    }
}
