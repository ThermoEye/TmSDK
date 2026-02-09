namespace TmWinDotNet
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel_Name = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_CamInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_fps = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_PreviewSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_Camera = new System.Windows.Forms.Panel();
            this.tabControl_Camera = new System.Windows.Forms.TabControl();
            this.tabPage_RemoteCamera = new System.Windows.Forms.TabPage();
            this.textBox_RemoteCameraPartNumber = new System.Windows.Forms.TextBox();
            this.label_RemoteCameraPartNumberTitle = new System.Windows.Forms.Label();
            this.label_RemoteCameraVideoFormat = new System.Windows.Forms.Label();
            this.comboBox_RemoteCameraVideoFormat = new System.Windows.Forms.ComboBox();
            this.textBox_RemoteCameraAdapterIP = new System.Windows.Forms.TextBox();
            this.label_RemoteCameraAdapterIPTitle = new System.Windows.Forms.Label();
            this.textBox_RemoteCameraMACAddress = new System.Windows.Forms.TextBox();
            this.label_RemoteCameraMACAddressTitle = new System.Windows.Forms.Label();
            this.textBox_RemoteCameraSerialNumber = new System.Windows.Forms.TextBox();
            this.label_RemoteCameraSerialNumberTitle = new System.Windows.Forms.Label();
            this.textBox_RemoteCameraName = new System.Windows.Forms.TextBox();
            this.label_RemoteCameraNameTitle = new System.Windows.Forms.Label();
            this.label_RemoteCameraIPAddressTitle = new System.Windows.Forms.Label();
            this.textBox_RemoteCameraIPAddress = new System.Windows.Forms.TextBox();
            this.button_ConnectRemoteCamera = new System.Windows.Forms.Button();
            this.listBox_RemoteCameraScanList = new System.Windows.Forms.ListBox();
            this.button_ScanRemoteCamera = new System.Windows.Forms.Button();
            this.tabPage_LocalCamera = new System.Windows.Forms.TabPage();
            this.label_LocalCameraVideoFormat = new System.Windows.Forms.Label();
            this.comboBox_LocalCameraVideoFormat = new System.Windows.Forms.ComboBox();
            this.textBox_LocalCameraComPort = new System.Windows.Forms.TextBox();
            this.textBox_LocalCameraName = new System.Windows.Forms.TextBox();
            this.listBox_LocalCameraScanList = new System.Windows.Forms.ListBox();
            this.button_ScanLocalCamera = new System.Windows.Forms.Button();
            this.label_LocalCameraComPort = new System.Windows.Forms.Label();
            this.label_LocalCameraNameTitle = new System.Windows.Forms.Label();
            this.button_ConnectLocalCamera = new System.Windows.Forms.Button();
            this.tabControl_CameraConfig = new System.Windows.Forms.TabControl();
            this.tabPage_Product = new System.Windows.Forms.TabPage();
            this.groupBox_ProductInformation = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_ProductInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label_HardwareVersion = new System.Windows.Forms.Label();
            this.label_ProductSerialNumber = new System.Windows.Forms.Label();
            this.label_ProductModelName = new System.Windows.Forms.Label();
            this.label_ProductPartNumber = new System.Windows.Forms.Label();
            this.label_ProductModelNameTitle = new System.Windows.Forms.Label();
            this.label_FirmwareVersion = new System.Windows.Forms.Label();
            this.label_BootloaderVersion = new System.Windows.Forms.Label();
            this.label_FirmwareVersionTitle = new System.Windows.Forms.Label();
            this.label_BootloaderVersionTitle = new System.Windows.Forms.Label();
            this.label_HardwareVersionTitle = new System.Windows.Forms.Label();
            this.label_ProductSerialNumberTitle = new System.Windows.Forms.Label();
            this.label_ProductPartNumberTitle = new System.Windows.Forms.Label();
            this.button_GetProductInformation = new System.Windows.Forms.Button();
            this.groupBox_SensorInformation = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_SensorInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label_SensorUptime = new System.Windows.Forms.Label();
            this.label_SensorUptimeTitle = new System.Windows.Forms.Label();
            this.label_SensorModelNameTitle = new System.Windows.Forms.Label();
            this.label_SensorSerialNumberTitle = new System.Windows.Forms.Label();
            this.label_SensorSerialNumber = new System.Windows.Forms.Label();
            this.label_SensorModelName = new System.Windows.Forms.Label();
            this.button_GetSensorInformation = new System.Windows.Forms.Button();
            this.groupBox_SoftwareUpdate = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_BinaryInforation = new System.Windows.Forms.TableLayoutPanel();
            this.label_BinaryInformationTitle = new System.Windows.Forms.Label();
            this.label_BinarySizeTitle = new System.Windows.Forms.Label();
            this.label_BinaryVendorNameTitle = new System.Windows.Forms.Label();
            this.label_BinaryProductNameTitle = new System.Windows.Forms.Label();
            this.label_BinaryVersionTitle = new System.Windows.Forms.Label();
            this.label_BinaryBuildTimeTitle = new System.Windows.Forms.Label();
            this.label_BinaryVendorName = new System.Windows.Forms.Label();
            this.label_BinaryProductName = new System.Windows.Forms.Label();
            this.label_BinaryVersion = new System.Windows.Forms.Label();
            this.label_BinaryBuildTime = new System.Windows.Forms.Label();
            this.label_BinarySize = new System.Windows.Forms.Label();
            this.button_SoftwareUpdateFileBrowse = new System.Windows.Forms.Button();
            this.textBox_SoftwareUpdateFilePath = new System.Windows.Forms.TextBox();
            this.button_StartSoftwareUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel_SoftwareUpdateBlank = new System.Windows.Forms.TableLayoutPanel();
            this.label_SoftwareUpdateStatus = new System.Windows.Forms.Label();
            this.progressBar_SoftwareUpdate = new System.Windows.Forms.ProgressBar();
            this.tabPage_Network = new System.Windows.Forms.TabPage();
            this.groupBox_NetworkConfiguration = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_NetworkConfig = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_SubDNSServer = new System.Windows.Forms.TextBox();
            this.label_SubDNSServerTitle = new System.Windows.Forms.Label();
            this.label_MACAddressTitle = new System.Windows.Forms.Label();
            this.textBox_MACAddress = new System.Windows.Forms.TextBox();
            this.button_GetNetworkConfiguration = new System.Windows.Forms.Button();
            this.label_IPAssignmentTitle = new System.Windows.Forms.Label();
            this.label_IPAddressTitle = new System.Windows.Forms.Label();
            this.label_NetmaskTitle = new System.Windows.Forms.Label();
            this.label_GatewayNameTitle = new System.Windows.Forms.Label();
            this.textBox_IPAddress = new System.Windows.Forms.TextBox();
            this.textBox_Netmask = new System.Windows.Forms.TextBox();
            this.textBox_Gateway = new System.Windows.Forms.TextBox();
            this.textBox_MainDNSServer = new System.Windows.Forms.TextBox();
            this.button_SetNetworkConfiguration = new System.Windows.Forms.Button();
            this.comboBox_IPAssignment = new System.Windows.Forms.ComboBox();
            this.label_MainDNSServerTitle = new System.Windows.Forms.Label();
            this.label_SplashScreenTitle = new System.Windows.Forms.Label();
            this.comboBox_SplashScreen = new System.Windows.Forms.ComboBox();
            this.button_SystemReboot = new System.Windows.Forms.Button();
            this.button_SetDefaultNetworkConfiguration = new System.Windows.Forms.Button();
            this.tabControl_SensorConfig = new System.Windows.Forms.TabControl();
            this.tabPage_SensorControl = new System.Windows.Forms.TabPage();
            this.panel_SensorControl_256G = new System.Windows.Forms.Panel();
            this.groupBox_FluxParameters_256G = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_FluxParam256G = new System.Windows.Forms.TableLayoutPanel();
            this.label_FluxParam256G_DistanceTitle = new System.Windows.Forms.Label();
            this.label_FluxParam256G_EmissivityTitle = new System.Windows.Forms.Label();
            this.textBox_FluxParam256G_EmissivityRange = new System.Windows.Forms.TextBox();
            this.button_GetFluxParameters_256G = new System.Windows.Forms.Button();
            this.button_SetFluxParameters_256G = new System.Windows.Forms.Button();
            this.numericUpDown_FluxParam256G_Emissivity = new System.Windows.Forms.NumericUpDown();
            this.label_FluxParam256G_AtmosphericTransmittanceTitle = new System.Windows.Forms.Label();
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance = new System.Windows.Forms.NumericUpDown();
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange = new System.Windows.Forms.TextBox();
            this.label_FluxParam256G_AtmosphericTemperatureTitle = new System.Windows.Forms.Label();
            this.numericUpDown_FluxParam256G_AtmosphericTemperature = new System.Windows.Forms.NumericUpDown();
            this.textBox_FluxParam256G_AtmosphericTemperatureRange = new System.Windows.Forms.TextBox();
            this.label_FluxParam256G_AtmosphericTemperatureUnit = new System.Windows.Forms.Label();
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle = new System.Windows.Forms.Label();
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature = new System.Windows.Forms.NumericUpDown();
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit = new System.Windows.Forms.Label();
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange = new System.Windows.Forms.TextBox();
            this.numericUpDown_FluxParam256G_Distance = new System.Windows.Forms.NumericUpDown();
            this.label_FluxParam256G_DistanceUnit = new System.Windows.Forms.Label();
            this.textBox_FluxParam256G_DistanceRange = new System.Windows.Forms.TextBox();
            this.groupBox_FFCParameters_256G = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_FFCParam256G = new System.Windows.Forms.TableLayoutPanel();
            this.label_FFCParam256G_MaxIntervalTitle = new System.Windows.Forms.Label();
            this.textBox_FFCParam256G_MaxIntervalRange = new System.Windows.Forms.TextBox();
            this.button_GetFFCParameters_256G = new System.Windows.Forms.Button();
            this.button_SetFFCParameters_256G = new System.Windows.Forms.Button();
            this.numericUpDown_FFCParam256G_MaxInterval = new System.Windows.Forms.NumericUpDown();
            this.label_FFCParam256G_MaxIntervalUnit = new System.Windows.Forms.Label();
            this.button_StoreUserSensorConfig_256G = new System.Windows.Forms.Button();
            this.button_RestoreDefaultSensorConfig_256G = new System.Windows.Forms.Button();
            this.groupBox_GainModeState_256G = new System.Windows.Forms.GroupBox();
            this.radioButton_GainModeStateAuto_256G = new System.Windows.Forms.RadioButton();
            this.button_SetGainModeState_256G = new System.Windows.Forms.Button();
            this.button_GetGainModeState_256G = new System.Windows.Forms.Button();
            this.radioButton_GainModeStateLow_256G = new System.Windows.Forms.RadioButton();
            this.radioButton_GainModeStateHigh_256G = new System.Windows.Forms.RadioButton();
            this.groupBox_FlatFieldCorrection_256G = new System.Windows.Forms.GroupBox();
            this.button_SetFlatFieldCorrectionMode_256G = new System.Windows.Forms.Button();
            this.button_GetFlatFieldCorrectionMode_256G = new System.Windows.Forms.Button();
            this.radioButton_FlatFieldCorrectionManual_256G = new System.Windows.Forms.RadioButton();
            this.button_RunFlatFieldCorrection_256G = new System.Windows.Forms.Button();
            this.radioButton_FlatFieldCorrectionAutomatic_256G = new System.Windows.Forms.RadioButton();
            this.panel_SensorControl_256 = new System.Windows.Forms.Panel();
            this.groupBox_FFCParameters_256 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_FFCParam256 = new System.Windows.Forms.TableLayoutPanel();
            this.label_FFCParam256_MaxIntervalTitle = new System.Windows.Forms.Label();
            this.textBox_FFCParam256_MaxIntervalRange = new System.Windows.Forms.TextBox();
            this.button_GetFFCParameters_256 = new System.Windows.Forms.Button();
            this.button_SetFFCParameters_256 = new System.Windows.Forms.Button();
            this.numericUpDown_FFCParam256_MaxInterval = new System.Windows.Forms.NumericUpDown();
            this.label_FFCParam256_AutoTriggerThresholdTitle = new System.Windows.Forms.Label();
            this.numericUpDown_FFCParam256_AutoTriggerThreshold = new System.Windows.Forms.NumericUpDown();
            this.textBox_FFCParam256_AutoTriggerThresholdRange = new System.Windows.Forms.TextBox();
            this.label_FFCParam256_MaxIntervalUnit = new System.Windows.Forms.Label();
            this.button_StoreUserSensorConfig_256 = new System.Windows.Forms.Button();
            this.button_RestoreDefaultSensorConfig_256 = new System.Windows.Forms.Button();
            this.groupBox_FluxParameters_256 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_FluxParam256 = new System.Windows.Forms.TableLayoutPanel();
            this.label_FluxParam256_DistanceTitle = new System.Windows.Forms.Label();
            this.label_FluxParam256_EmissivityTitle = new System.Windows.Forms.Label();
            this.textBox_FluxParam256_EmissivityRange = new System.Windows.Forms.TextBox();
            this.button_GetFluxParameters_256 = new System.Windows.Forms.Button();
            this.button_SetFluxParameters_256 = new System.Windows.Forms.Button();
            this.numericUpDown_FluxParam256_Emissivity = new System.Windows.Forms.NumericUpDown();
            this.label_FluxParam256_AtmosphericTransmittanceTitle = new System.Windows.Forms.Label();
            this.numericUpDown_FluxParam256_AtmosphericTransmittance = new System.Windows.Forms.NumericUpDown();
            this.textBox_FluxParam256_AtmosphericTransmittanceRange = new System.Windows.Forms.TextBox();
            this.label_FluxParam256_AtmosphericTemperatureTitle = new System.Windows.Forms.Label();
            this.numericUpDown_FluxParam256_AtmosphericTemperature = new System.Windows.Forms.NumericUpDown();
            this.textBox_FluxParam256_AtmosphericTemperatureRange = new System.Windows.Forms.TextBox();
            this.label_FluxParam256_AtmosphericTemperatureUnit = new System.Windows.Forms.Label();
            this.label_FluxParam256_AmbientReflectionTemperatureTitle = new System.Windows.Forms.Label();
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature = new System.Windows.Forms.NumericUpDown();
            this.label_FluxParam256_AmbientReflectionTemperatureUnit = new System.Windows.Forms.Label();
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange = new System.Windows.Forms.TextBox();
            this.numericUpDown_FluxParam256_Distance = new System.Windows.Forms.NumericUpDown();
            this.label_FluxParam256_DistanceUnit = new System.Windows.Forms.Label();
            this.textBox_FluxParam256_DistanceRange = new System.Windows.Forms.TextBox();
            this.groupBox_GainModeState_256 = new System.Windows.Forms.GroupBox();
            this.button_SetGainModeState_256 = new System.Windows.Forms.Button();
            this.button_GetGainModeState_256 = new System.Windows.Forms.Button();
            this.radioButton_GainModeStateLow_256 = new System.Windows.Forms.RadioButton();
            this.radioButton_GainModeStateHigh_256 = new System.Windows.Forms.RadioButton();
            this.groupBox_FlatFieldCorrection_256 = new System.Windows.Forms.GroupBox();
            this.button_SetFlatFieldCorrectionMode_256 = new System.Windows.Forms.Button();
            this.button_GetFlatFieldCorrectionMode_256 = new System.Windows.Forms.Button();
            this.radioButton_FlatFieldCorrectionManual_256 = new System.Windows.Forms.RadioButton();
            this.button_RunFlatFieldCorrection_256 = new System.Windows.Forms.Button();
            this.radioButton_FlatFieldCorrectionAutomatic_256 = new System.Windows.Forms.RadioButton();
            this.panel_SensorControl_160 = new System.Windows.Forms.Panel();
            this.groupBox_FluxParameters_160 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel_FluxParam160 = new System.Windows.Forms.TableLayoutPanel();
            this.label_FluxParam160_WindowReflectedTemperatureUnit = new System.Windows.Forms.Label();
            this.label_FluxParam160_AtmosphericTemperatureUnit = new System.Windows.Forms.Label();
            this.label_FluxParam160_WindowTemperatureUnit = new System.Windows.Forms.Label();
            this.label_FluxParam160_BackgroundTemperatureUnit = new System.Windows.Forms.Label();
            this.numericUpDown_FluxParam160_WindowReflectedTemperature = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_FluxParam160_WindowReflection = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_FluxParam160_AtmosphericTemperature = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_FluxParam160_AtmosphericTransmission = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_FluxParam160_WindowTemperature = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_FluxParam160_WindowTransmission = new System.Windows.Forms.NumericUpDown();
            this.label_FluxParam160_SceneEmissivityTitle = new System.Windows.Forms.Label();
            this.textBox_FluxParam160_SceneEmissivityRange = new System.Windows.Forms.TextBox();
            this.button_GetFluxParameters_160 = new System.Windows.Forms.Button();
            this.button_SetFluxParameters_160 = new System.Windows.Forms.Button();
            this.label_FluxParam160_WindowTransmissionTitle = new System.Windows.Forms.Label();
            this.label_FluxParam160_WindowTemperatureTitle = new System.Windows.Forms.Label();
            this.label_FluxParam160_AtmosphericTransmissionTitle = new System.Windows.Forms.Label();
            this.label_FluxParam160_AtmosphericTemperatureTitle = new System.Windows.Forms.Label();
            this.textBox_FluxParam160_BackgroundTemperatureRange = new System.Windows.Forms.TextBox();
            this.textBox_FluxParam160_WindowTransmissionRange = new System.Windows.Forms.TextBox();
            this.textBox_FluxParam160_WindowTemperatureRange = new System.Windows.Forms.TextBox();
            this.textBox_FluxParam160_AtmosphericTransmissionRange = new System.Windows.Forms.TextBox();
            this.textBox_FluxParam160_AtmosphericTemperatureRange = new System.Windows.Forms.TextBox();
            this.label_FluxParam160_WindowReflectionTitle = new System.Windows.Forms.Label();
            this.label_FluxParam160_WindowReflectedTemperatureTitle = new System.Windows.Forms.Label();
            this.textBox_FluxParam160_WindowReflectionRange = new System.Windows.Forms.TextBox();
            this.textBox_FluxParam160_WindowReflectedTemperatureRange = new System.Windows.Forms.TextBox();
            this.numericUpDown_FluxParam160_SceneEmissivity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_FluxParam160_BackgroundTemperature = new System.Windows.Forms.NumericUpDown();
            this.label_FluxParam160_BackgroundTemperatureTitle = new System.Windows.Forms.Label();
            this.groupBox_GainModeState_160 = new System.Windows.Forms.GroupBox();
            this.button_SetGainModeState_160 = new System.Windows.Forms.Button();
            this.button_GetGainModeState_160 = new System.Windows.Forms.Button();
            this.radioButton_GainModeStateAuto_160 = new System.Windows.Forms.RadioButton();
            this.radioButton_GainModeStateLow_160 = new System.Windows.Forms.RadioButton();
            this.radioButton_GainModeStateHigh_160 = new System.Windows.Forms.RadioButton();
            this.groupBox_FlatFieldCorrection_160 = new System.Windows.Forms.GroupBox();
            this.button_SetFlatFieldCorrectionMode_160 = new System.Windows.Forms.Button();
            this.button_GetFlatFieldCorrectionMode_160 = new System.Windows.Forms.Button();
            this.radioButton_FlatFieldCorrectionManual_160 = new System.Windows.Forms.RadioButton();
            this.button_RunFlatFieldCorrection_160 = new System.Windows.Forms.Button();
            this.radioButton_FlatFieldCorrectionAutomatic_160 = new System.Windows.Forms.RadioButton();
            this.button_RestoreDefaultFluxParameters_160 = new System.Windows.Forms.Button();
            this.tabPage_RoiManager = new System.Windows.Forms.TabPage();
            this.button_RemoveRoiItem = new System.Windows.Forms.Button();
            this.button_AddRoiItem = new System.Windows.Forms.Button();
            this.rbtn_RoiEllipse = new System.Windows.Forms.RadioButton();
            this.rbtn_RoiRect = new System.Windows.Forms.RadioButton();
            this.rbtn_RoiLine = new System.Windows.Forms.RadioButton();
            this.rbtn_RoiSpot = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel_RoiEllipse = new System.Windows.Forms.TableLayoutPanel();
            this.label_RoiEllipseW = new System.Windows.Forms.Label();
            this.label_RoiEllipseX = new System.Windows.Forms.Label();
            this.label_RoiEllipseY = new System.Windows.Forms.Label();
            this.textBox_RoiEllipseX = new System.Windows.Forms.TextBox();
            this.textBox_RoiEllipseW = new System.Windows.Forms.TextBox();
            this.textBox_RoiEllipseY = new System.Windows.Forms.TextBox();
            this.label_RoiEllipseH = new System.Windows.Forms.Label();
            this.textBox_RoiEllipseH = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_RoiRect = new System.Windows.Forms.TableLayoutPanel();
            this.label_RoiRectW = new System.Windows.Forms.Label();
            this.label_RoiRectX = new System.Windows.Forms.Label();
            this.label_RoiRectY = new System.Windows.Forms.Label();
            this.textBox_RoiRectX = new System.Windows.Forms.TextBox();
            this.textBox_RoiRectW = new System.Windows.Forms.TextBox();
            this.textBox_RoiRectY = new System.Windows.Forms.TextBox();
            this.label_RoiRectH = new System.Windows.Forms.Label();
            this.textBox_RoiRectH = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_RoiLine = new System.Windows.Forms.TableLayoutPanel();
            this.label_RoiLineX2 = new System.Windows.Forms.Label();
            this.label_RoiLineX1 = new System.Windows.Forms.Label();
            this.label_RoiLineY1 = new System.Windows.Forms.Label();
            this.textBox_RoiLineX1 = new System.Windows.Forms.TextBox();
            this.textBox_RoiLineX2 = new System.Windows.Forms.TextBox();
            this.textBox_RoiLineY1 = new System.Windows.Forms.TextBox();
            this.label_RoiLineY2 = new System.Windows.Forms.Label();
            this.textBox_RoiLineY2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_RoiSpot = new System.Windows.Forms.TableLayoutPanel();
            this.label_RoiSpotX = new System.Windows.Forms.Label();
            this.label_RoiSpotY = new System.Windows.Forms.Label();
            this.textBox_RoiSpotX = new System.Windows.Forms.TextBox();
            this.textBox_RoiSpotY = new System.Windows.Forms.TextBox();
            this.label_RoiList = new System.Windows.Forms.Label();
            this.comboBox_RoiList = new System.Windows.Forms.ComboBox();
            this.panel_Preview = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_Preview = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Temperature = new System.Windows.Forms.Panel();
            this.label_MinimumTemperature = new System.Windows.Forms.Label();
            this.label_AverageTemperature = new System.Windows.Forms.Label();
            this.label_MaximumTemperature = new System.Windows.Forms.Label();
            this.panel_PreviewConfig = new System.Windows.Forms.Panel();
            this.checkBox_NoiseFiltering = new System.Windows.Forms.CheckBox();
            this.label_ColorMap = new System.Windows.Forms.Label();
            this.comboBox_ColorMap = new System.Windows.Forms.ComboBox();
            this.label_TemperatureUnit = new System.Windows.Forms.Label();
            this.comboBox_TemperatureUnit = new System.Windows.Forms.ComboBox();
            this.panel_VideoPreview = new System.Windows.Forms.Panel();
            this.pictureBox_Preview = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel_RoiShape = new System.Windows.Forms.TableLayoutPanel();
            this.panel_RoiShape = new System.Windows.Forms.Panel();
            this.radioButton_ShapeEllipse = new System.Windows.Forms.RadioButton();
            this.radioButton_ShapeRectangle = new System.Windows.Forms.RadioButton();
            this.radioButton_ShapeLine = new System.Windows.Forms.RadioButton();
            this.radioButton_ShapeSpot = new System.Windows.Forms.RadioButton();
            this.radioButton_ShapeCursor = new System.Windows.Forms.RadioButton();
            this.button_RemoveAllRoi = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panel_Camera.SuspendLayout();
            this.tabControl_Camera.SuspendLayout();
            this.tabPage_RemoteCamera.SuspendLayout();
            this.tabPage_LocalCamera.SuspendLayout();
            this.tabControl_CameraConfig.SuspendLayout();
            this.tabPage_Product.SuspendLayout();
            this.groupBox_ProductInformation.SuspendLayout();
            this.tableLayoutPanel_ProductInfo.SuspendLayout();
            this.groupBox_SensorInformation.SuspendLayout();
            this.tableLayoutPanel_SensorInfo.SuspendLayout();
            this.groupBox_SoftwareUpdate.SuspendLayout();
            this.tableLayoutPanel_BinaryInforation.SuspendLayout();
            this.tableLayoutPanel_SoftwareUpdateBlank.SuspendLayout();
            this.tabPage_Network.SuspendLayout();
            this.groupBox_NetworkConfiguration.SuspendLayout();
            this.tableLayoutPanel_NetworkConfig.SuspendLayout();
            this.tabControl_SensorConfig.SuspendLayout();
            this.tabPage_SensorControl.SuspendLayout();
            this.panel_SensorControl_256G.SuspendLayout();
            this.groupBox_FluxParameters_256G.SuspendLayout();
            this.tableLayoutPanel_FluxParam256G.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_Emissivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_AtmosphericTransmittance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_AtmosphericTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_AmbientReflectionTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_Distance)).BeginInit();
            this.groupBox_FFCParameters_256G.SuspendLayout();
            this.tableLayoutPanel_FFCParam256G.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FFCParam256G_MaxInterval)).BeginInit();
            this.groupBox_GainModeState_256G.SuspendLayout();
            this.groupBox_FlatFieldCorrection_256G.SuspendLayout();
            this.panel_SensorControl_256.SuspendLayout();
            this.groupBox_FFCParameters_256.SuspendLayout();
            this.tableLayoutPanel_FFCParam256.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FFCParam256_MaxInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FFCParam256_AutoTriggerThreshold)).BeginInit();
            this.groupBox_FluxParameters_256.SuspendLayout();
            this.tableLayoutPanel_FluxParam256.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_Emissivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_AtmosphericTransmittance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_AtmosphericTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_AmbientReflectionTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_Distance)).BeginInit();
            this.groupBox_GainModeState_256.SuspendLayout();
            this.groupBox_FlatFieldCorrection_256.SuspendLayout();
            this.panel_SensorControl_160.SuspendLayout();
            this.groupBox_FluxParameters_160.SuspendLayout();
            this.tableLayoutPanel_FluxParam160.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_WindowReflectedTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_WindowReflection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_AtmosphericTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_AtmosphericTransmission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_WindowTemperature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_WindowTransmission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_SceneEmissivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_BackgroundTemperature)).BeginInit();
            this.groupBox_GainModeState_160.SuspendLayout();
            this.groupBox_FlatFieldCorrection_160.SuspendLayout();
            this.tabPage_RoiManager.SuspendLayout();
            this.tableLayoutPanel_RoiEllipse.SuspendLayout();
            this.tableLayoutPanel_RoiRect.SuspendLayout();
            this.tableLayoutPanel_RoiLine.SuspendLayout();
            this.tableLayoutPanel_RoiSpot.SuspendLayout();
            this.panel_Preview.SuspendLayout();
            this.tableLayoutPanel_Preview.SuspendLayout();
            this.panel_Temperature.SuspendLayout();
            this.panel_PreviewConfig.SuspendLayout();
            this.panel_VideoPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).BeginInit();
            this.tableLayoutPanel_RoiShape.SuspendLayout();
            this.panel_RoiShape.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.tableLayoutPanelMain.Controls.Add(this.statusBar, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panel_Camera, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tabControl_CameraConfig, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tabControl_SensorConfig, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.panel_Preview, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 274F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1103, 769);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // statusBar
            // 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.statusBar, 3);
            this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel_Name,
            this.StatusLabel_CamInfo,
            this.StatusLabel_fps,
            this.StatusLabel_PreviewSize});
            this.statusBar.Location = new System.Drawing.Point(0, 747);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1103, 22);
            this.statusBar.TabIndex = 14;
            this.statusBar.Text = "statusStrip";
            // 
            // StatusLabel_Name
            // 
            this.StatusLabel_Name.Name = "StatusLabel_Name";
            this.StatusLabel_Name.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusLabel_CamInfo
            // 
            this.StatusLabel_CamInfo.Name = "StatusLabel_CamInfo";
            this.StatusLabel_CamInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusLabel_fps
            // 
            this.StatusLabel_fps.Name = "StatusLabel_fps";
            this.StatusLabel_fps.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusLabel_PreviewSize
            // 
            this.StatusLabel_PreviewSize.Name = "StatusLabel_PreviewSize";
            this.StatusLabel_PreviewSize.Size = new System.Drawing.Size(0, 17);
            // 
            // panel_Camera
            // 
            this.panel_Camera.Controls.Add(this.tabControl_Camera);
            this.panel_Camera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Camera.Location = new System.Drawing.Point(3, 4);
            this.panel_Camera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_Camera.Name = "panel_Camera";
            this.panel_Camera.Size = new System.Drawing.Size(234, 463);
            this.panel_Camera.TabIndex = 1;
            // 
            // tabControl_Camera
            // 
            this.tabControl_Camera.Controls.Add(this.tabPage_RemoteCamera);
            this.tabControl_Camera.Controls.Add(this.tabPage_LocalCamera);
            this.tabControl_Camera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Camera.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Camera.Name = "tabControl_Camera";
            this.tabControl_Camera.SelectedIndex = 0;
            this.tabControl_Camera.Size = new System.Drawing.Size(234, 463);
            this.tabControl_Camera.TabIndex = 0;
            // 
            // tabPage_RemoteCamera
            // 
            this.tabPage_RemoteCamera.Controls.Add(this.textBox_RemoteCameraPartNumber);
            this.tabPage_RemoteCamera.Controls.Add(this.label_RemoteCameraPartNumberTitle);
            this.tabPage_RemoteCamera.Controls.Add(this.label_RemoteCameraVideoFormat);
            this.tabPage_RemoteCamera.Controls.Add(this.comboBox_RemoteCameraVideoFormat);
            this.tabPage_RemoteCamera.Controls.Add(this.textBox_RemoteCameraAdapterIP);
            this.tabPage_RemoteCamera.Controls.Add(this.label_RemoteCameraAdapterIPTitle);
            this.tabPage_RemoteCamera.Controls.Add(this.textBox_RemoteCameraMACAddress);
            this.tabPage_RemoteCamera.Controls.Add(this.label_RemoteCameraMACAddressTitle);
            this.tabPage_RemoteCamera.Controls.Add(this.textBox_RemoteCameraSerialNumber);
            this.tabPage_RemoteCamera.Controls.Add(this.label_RemoteCameraSerialNumberTitle);
            this.tabPage_RemoteCamera.Controls.Add(this.textBox_RemoteCameraName);
            this.tabPage_RemoteCamera.Controls.Add(this.label_RemoteCameraNameTitle);
            this.tabPage_RemoteCamera.Controls.Add(this.label_RemoteCameraIPAddressTitle);
            this.tabPage_RemoteCamera.Controls.Add(this.textBox_RemoteCameraIPAddress);
            this.tabPage_RemoteCamera.Controls.Add(this.button_ConnectRemoteCamera);
            this.tabPage_RemoteCamera.Controls.Add(this.listBox_RemoteCameraScanList);
            this.tabPage_RemoteCamera.Controls.Add(this.button_ScanRemoteCamera);
            this.tabPage_RemoteCamera.Location = new System.Drawing.Point(4, 24);
            this.tabPage_RemoteCamera.Name = "tabPage_RemoteCamera";
            this.tabPage_RemoteCamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_RemoteCamera.Size = new System.Drawing.Size(226, 435);
            this.tabPage_RemoteCamera.TabIndex = 1;
            this.tabPage_RemoteCamera.Text = "Remote Camera";
            this.tabPage_RemoteCamera.UseVisualStyleBackColor = true;
            // 
            // textBox_RemoteCameraPartNumber
            // 
            this.textBox_RemoteCameraPartNumber.Location = new System.Drawing.Point(95, 50);
            this.textBox_RemoteCameraPartNumber.Name = "textBox_RemoteCameraPartNumber";
            this.textBox_RemoteCameraPartNumber.ReadOnly = true;
            this.textBox_RemoteCameraPartNumber.Size = new System.Drawing.Size(120, 23);
            this.textBox_RemoteCameraPartNumber.TabIndex = 18;
            // 
            // label_RemoteCameraPartNumberTitle
            // 
            this.label_RemoteCameraPartNumberTitle.AutoSize = true;
            this.label_RemoteCameraPartNumberTitle.Location = new System.Drawing.Point(46, 53);
            this.label_RemoteCameraPartNumberTitle.Name = "label_RemoteCameraPartNumberTitle";
            this.label_RemoteCameraPartNumberTitle.Size = new System.Drawing.Size(44, 15);
            this.label_RemoteCameraPartNumberTitle.TabIndex = 17;
            this.label_RemoteCameraPartNumberTitle.Text = "Part # :";
            // 
            // label_RemoteCameraVideoFormat
            // 
            this.label_RemoteCameraVideoFormat.AutoSize = true;
            this.label_RemoteCameraVideoFormat.Location = new System.Drawing.Point(9, 203);
            this.label_RemoteCameraVideoFormat.Name = "label_RemoteCameraVideoFormat";
            this.label_RemoteCameraVideoFormat.Size = new System.Drawing.Size(78, 15);
            this.label_RemoteCameraVideoFormat.TabIndex = 16;
            this.label_RemoteCameraVideoFormat.Text = "Video Format";
            // 
            // comboBox_RemoteCameraVideoFormat
            // 
            this.comboBox_RemoteCameraVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RemoteCameraVideoFormat.FormattingEnabled = true;
            this.comboBox_RemoteCameraVideoFormat.Location = new System.Drawing.Point(12, 221);
            this.comboBox_RemoteCameraVideoFormat.Name = "comboBox_RemoteCameraVideoFormat";
            this.comboBox_RemoteCameraVideoFormat.Size = new System.Drawing.Size(203, 23);
            this.comboBox_RemoteCameraVideoFormat.TabIndex = 15;
            this.comboBox_RemoteCameraVideoFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_RemoteCameraVideoFormat_SelectedIndexChanged);
            // 
            // textBox_RemoteCameraAdapterIP
            // 
            this.textBox_RemoteCameraAdapterIP.Location = new System.Drawing.Point(95, 177);
            this.textBox_RemoteCameraAdapterIP.Name = "textBox_RemoteCameraAdapterIP";
            this.textBox_RemoteCameraAdapterIP.ReadOnly = true;
            this.textBox_RemoteCameraAdapterIP.Size = new System.Drawing.Size(120, 23);
            this.textBox_RemoteCameraAdapterIP.TabIndex = 12;
            // 
            // label_RemoteCameraAdapterIPTitle
            // 
            this.label_RemoteCameraAdapterIPTitle.AutoSize = true;
            this.label_RemoteCameraAdapterIPTitle.Location = new System.Drawing.Point(23, 180);
            this.label_RemoteCameraAdapterIPTitle.Name = "label_RemoteCameraAdapterIPTitle";
            this.label_RemoteCameraAdapterIPTitle.Size = new System.Drawing.Size(68, 15);
            this.label_RemoteCameraAdapterIPTitle.TabIndex = 11;
            this.label_RemoteCameraAdapterIPTitle.Text = "Adapter IP :";
            // 
            // textBox_RemoteCameraMACAddress
            // 
            this.textBox_RemoteCameraMACAddress.Location = new System.Drawing.Point(95, 110);
            this.textBox_RemoteCameraMACAddress.Name = "textBox_RemoteCameraMACAddress";
            this.textBox_RemoteCameraMACAddress.ReadOnly = true;
            this.textBox_RemoteCameraMACAddress.Size = new System.Drawing.Size(120, 23);
            this.textBox_RemoteCameraMACAddress.TabIndex = 9;
            // 
            // label_RemoteCameraMACAddressTitle
            // 
            this.label_RemoteCameraMACAddressTitle.AutoSize = true;
            this.label_RemoteCameraMACAddressTitle.Location = new System.Drawing.Point(51, 114);
            this.label_RemoteCameraMACAddressTitle.Name = "label_RemoteCameraMACAddressTitle";
            this.label_RemoteCameraMACAddressTitle.Size = new System.Drawing.Size(40, 15);
            this.label_RemoteCameraMACAddressTitle.TabIndex = 8;
            this.label_RemoteCameraMACAddressTitle.Text = "MAC :";
            // 
            // textBox_RemoteCameraSerialNumber
            // 
            this.textBox_RemoteCameraSerialNumber.Location = new System.Drawing.Point(95, 77);
            this.textBox_RemoteCameraSerialNumber.Name = "textBox_RemoteCameraSerialNumber";
            this.textBox_RemoteCameraSerialNumber.ReadOnly = true;
            this.textBox_RemoteCameraSerialNumber.Size = new System.Drawing.Size(120, 23);
            this.textBox_RemoteCameraSerialNumber.TabIndex = 7;
            // 
            // label_RemoteCameraSerialNumberTitle
            // 
            this.label_RemoteCameraSerialNumberTitle.AutoSize = true;
            this.label_RemoteCameraSerialNumberTitle.Location = new System.Drawing.Point(40, 81);
            this.label_RemoteCameraSerialNumberTitle.Name = "label_RemoteCameraSerialNumberTitle";
            this.label_RemoteCameraSerialNumberTitle.Size = new System.Drawing.Size(51, 15);
            this.label_RemoteCameraSerialNumberTitle.TabIndex = 6;
            this.label_RemoteCameraSerialNumberTitle.Text = "Serial # :";
            // 
            // textBox_RemoteCameraName
            // 
            this.textBox_RemoteCameraName.Location = new System.Drawing.Point(95, 21);
            this.textBox_RemoteCameraName.Name = "textBox_RemoteCameraName";
            this.textBox_RemoteCameraName.ReadOnly = true;
            this.textBox_RemoteCameraName.Size = new System.Drawing.Size(120, 23);
            this.textBox_RemoteCameraName.TabIndex = 5;
            // 
            // label_RemoteCameraNameTitle
            // 
            this.label_RemoteCameraNameTitle.AutoSize = true;
            this.label_RemoteCameraNameTitle.Location = new System.Drawing.Point(46, 24);
            this.label_RemoteCameraNameTitle.Name = "label_RemoteCameraNameTitle";
            this.label_RemoteCameraNameTitle.Size = new System.Drawing.Size(45, 15);
            this.label_RemoteCameraNameTitle.TabIndex = 4;
            this.label_RemoteCameraNameTitle.Text = "Name :";
            // 
            // label_RemoteCameraIPAddressTitle
            // 
            this.label_RemoteCameraIPAddressTitle.AutoSize = true;
            this.label_RemoteCameraIPAddressTitle.Location = new System.Drawing.Point(23, 147);
            this.label_RemoteCameraIPAddressTitle.Name = "label_RemoteCameraIPAddressTitle";
            this.label_RemoteCameraIPAddressTitle.Size = new System.Drawing.Size(68, 15);
            this.label_RemoteCameraIPAddressTitle.TabIndex = 3;
            this.label_RemoteCameraIPAddressTitle.Text = "IP Address :";
            // 
            // textBox_RemoteCameraIPAddress
            // 
            this.textBox_RemoteCameraIPAddress.Location = new System.Drawing.Point(95, 143);
            this.textBox_RemoteCameraIPAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_RemoteCameraIPAddress.Name = "textBox_RemoteCameraIPAddress";
            this.textBox_RemoteCameraIPAddress.ReadOnly = true;
            this.textBox_RemoteCameraIPAddress.Size = new System.Drawing.Size(120, 23);
            this.textBox_RemoteCameraIPAddress.TabIndex = 2;
            // 
            // button_ConnectRemoteCamera
            // 
            this.button_ConnectRemoteCamera.Location = new System.Drawing.Point(12, 253);
            this.button_ConnectRemoteCamera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ConnectRemoteCamera.Name = "button_ConnectRemoteCamera";
            this.button_ConnectRemoteCamera.Size = new System.Drawing.Size(203, 27);
            this.button_ConnectRemoteCamera.TabIndex = 1;
            this.button_ConnectRemoteCamera.Text = "Connect";
            this.button_ConnectRemoteCamera.UseVisualStyleBackColor = true;
            this.button_ConnectRemoteCamera.Click += new System.EventHandler(this.button_ConnectRemoteCamera_Click);
            // 
            // listBox_RemoteCameraScanList
            // 
            this.listBox_RemoteCameraScanList.FormattingEnabled = true;
            this.listBox_RemoteCameraScanList.HorizontalScrollbar = true;
            this.listBox_RemoteCameraScanList.ItemHeight = 15;
            this.listBox_RemoteCameraScanList.Location = new System.Drawing.Point(12, 319);
            this.listBox_RemoteCameraScanList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox_RemoteCameraScanList.Name = "listBox_RemoteCameraScanList";
            this.listBox_RemoteCameraScanList.Size = new System.Drawing.Size(203, 109);
            this.listBox_RemoteCameraScanList.TabIndex = 1;
            this.listBox_RemoteCameraScanList.Click += new System.EventHandler(this.listBox_RemoteCameraList_Click);
            this.listBox_RemoteCameraScanList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_RemoteCameraList_MouseDoubleClick);
            // 
            // button_ScanRemoteCamera
            // 
            this.button_ScanRemoteCamera.Location = new System.Drawing.Point(11, 287);
            this.button_ScanRemoteCamera.Name = "button_ScanRemoteCamera";
            this.button_ScanRemoteCamera.Size = new System.Drawing.Size(204, 26);
            this.button_ScanRemoteCamera.TabIndex = 0;
            this.button_ScanRemoteCamera.Text = "Scan Camera";
            this.button_ScanRemoteCamera.UseVisualStyleBackColor = true;
            this.button_ScanRemoteCamera.Click += new System.EventHandler(this.button_ScanRemoteCamera_Click);
            // 
            // tabPage_LocalCamera
            // 
            this.tabPage_LocalCamera.Controls.Add(this.label_LocalCameraVideoFormat);
            this.tabPage_LocalCamera.Controls.Add(this.comboBox_LocalCameraVideoFormat);
            this.tabPage_LocalCamera.Controls.Add(this.textBox_LocalCameraComPort);
            this.tabPage_LocalCamera.Controls.Add(this.textBox_LocalCameraName);
            this.tabPage_LocalCamera.Controls.Add(this.listBox_LocalCameraScanList);
            this.tabPage_LocalCamera.Controls.Add(this.button_ScanLocalCamera);
            this.tabPage_LocalCamera.Controls.Add(this.label_LocalCameraComPort);
            this.tabPage_LocalCamera.Controls.Add(this.label_LocalCameraNameTitle);
            this.tabPage_LocalCamera.Controls.Add(this.button_ConnectLocalCamera);
            this.tabPage_LocalCamera.Location = new System.Drawing.Point(4, 24);
            this.tabPage_LocalCamera.Name = "tabPage_LocalCamera";
            this.tabPage_LocalCamera.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LocalCamera.Size = new System.Drawing.Size(226, 435);
            this.tabPage_LocalCamera.TabIndex = 0;
            this.tabPage_LocalCamera.Text = "Local Camera";
            this.tabPage_LocalCamera.UseVisualStyleBackColor = true;
            // 
            // label_LocalCameraVideoFormat
            // 
            this.label_LocalCameraVideoFormat.AutoSize = true;
            this.label_LocalCameraVideoFormat.Location = new System.Drawing.Point(9, 87);
            this.label_LocalCameraVideoFormat.Name = "label_LocalCameraVideoFormat";
            this.label_LocalCameraVideoFormat.Size = new System.Drawing.Size(78, 15);
            this.label_LocalCameraVideoFormat.TabIndex = 14;
            this.label_LocalCameraVideoFormat.Text = "Video Format";
            // 
            // comboBox_LocalCameraVideoFormat
            // 
            this.comboBox_LocalCameraVideoFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_LocalCameraVideoFormat.FormattingEnabled = true;
            this.comboBox_LocalCameraVideoFormat.Location = new System.Drawing.Point(12, 105);
            this.comboBox_LocalCameraVideoFormat.Name = "comboBox_LocalCameraVideoFormat";
            this.comboBox_LocalCameraVideoFormat.Size = new System.Drawing.Size(203, 23);
            this.comboBox_LocalCameraVideoFormat.TabIndex = 13;
            this.comboBox_LocalCameraVideoFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_LocalCameraVideoFormat_SelectedIndexChanged);
            // 
            // textBox_LocalCameraComPort
            // 
            this.textBox_LocalCameraComPort.Location = new System.Drawing.Point(94, 54);
            this.textBox_LocalCameraComPort.Name = "textBox_LocalCameraComPort";
            this.textBox_LocalCameraComPort.ReadOnly = true;
            this.textBox_LocalCameraComPort.Size = new System.Drawing.Size(121, 23);
            this.textBox_LocalCameraComPort.TabIndex = 12;
            // 
            // textBox_LocalCameraName
            // 
            this.textBox_LocalCameraName.Location = new System.Drawing.Point(94, 21);
            this.textBox_LocalCameraName.Name = "textBox_LocalCameraName";
            this.textBox_LocalCameraName.ReadOnly = true;
            this.textBox_LocalCameraName.Size = new System.Drawing.Size(121, 23);
            this.textBox_LocalCameraName.TabIndex = 11;
            // 
            // listBox_LocalCameraScanList
            // 
            this.listBox_LocalCameraScanList.FormattingEnabled = true;
            this.listBox_LocalCameraScanList.HorizontalScrollbar = true;
            this.listBox_LocalCameraScanList.ItemHeight = 15;
            this.listBox_LocalCameraScanList.Location = new System.Drawing.Point(12, 259);
            this.listBox_LocalCameraScanList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox_LocalCameraScanList.Name = "listBox_LocalCameraScanList";
            this.listBox_LocalCameraScanList.Size = new System.Drawing.Size(203, 169);
            this.listBox_LocalCameraScanList.TabIndex = 11;
            this.listBox_LocalCameraScanList.Click += new System.EventHandler(this.listBox_LocalCameraList_Click);
            this.listBox_LocalCameraScanList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_LocalCameraList_MouseDoubleClick);
            // 
            // button_ScanLocalCamera
            // 
            this.button_ScanLocalCamera.Location = new System.Drawing.Point(12, 227);
            this.button_ScanLocalCamera.Name = "button_ScanLocalCamera";
            this.button_ScanLocalCamera.Size = new System.Drawing.Size(204, 26);
            this.button_ScanLocalCamera.TabIndex = 5;
            this.button_ScanLocalCamera.Text = "Scan Camera";
            this.button_ScanLocalCamera.UseVisualStyleBackColor = true;
            this.button_ScanLocalCamera.Click += new System.EventHandler(this.button_ScanLocalCamera_Click);
            // 
            // label_LocalCameraComPort
            // 
            this.label_LocalCameraComPort.AutoSize = true;
            this.label_LocalCameraComPort.Location = new System.Drawing.Point(25, 57);
            this.label_LocalCameraComPort.Name = "label_LocalCameraComPort";
            this.label_LocalCameraComPort.Size = new System.Drawing.Size(66, 15);
            this.label_LocalCameraComPort.TabIndex = 4;
            this.label_LocalCameraComPort.Text = "COM Port :";
            // 
            // label_LocalCameraNameTitle
            // 
            this.label_LocalCameraNameTitle.AutoSize = true;
            this.label_LocalCameraNameTitle.Location = new System.Drawing.Point(46, 24);
            this.label_LocalCameraNameTitle.Name = "label_LocalCameraNameTitle";
            this.label_LocalCameraNameTitle.Size = new System.Drawing.Size(45, 15);
            this.label_LocalCameraNameTitle.TabIndex = 2;
            this.label_LocalCameraNameTitle.Text = "Name :";
            // 
            // button_ConnectLocalCamera
            // 
            this.button_ConnectLocalCamera.Location = new System.Drawing.Point(12, 138);
            this.button_ConnectLocalCamera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ConnectLocalCamera.Name = "button_ConnectLocalCamera";
            this.button_ConnectLocalCamera.Size = new System.Drawing.Size(203, 27);
            this.button_ConnectLocalCamera.TabIndex = 1;
            this.button_ConnectLocalCamera.Text = "Connect";
            this.button_ConnectLocalCamera.UseVisualStyleBackColor = true;
            this.button_ConnectLocalCamera.Click += new System.EventHandler(this.button_ConnectLocalCamera_Click);
            // 
            // tabControl_CameraConfig
            // 
            this.tabControl_CameraConfig.Controls.Add(this.tabPage_Product);
            this.tabControl_CameraConfig.Controls.Add(this.tabPage_Network);
            this.tabControl_CameraConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_CameraConfig.Enabled = false;
            this.tabControl_CameraConfig.Location = new System.Drawing.Point(736, 3);
            this.tabControl_CameraConfig.Name = "tabControl_CameraConfig";
            this.tableLayoutPanelMain.SetRowSpan(this.tabControl_CameraConfig, 2);
            this.tabControl_CameraConfig.SelectedIndex = 0;
            this.tabControl_CameraConfig.Size = new System.Drawing.Size(364, 739);
            this.tabControl_CameraConfig.TabIndex = 4;
            // 
            // tabPage_Product
            // 
            this.tabPage_Product.Controls.Add(this.groupBox_ProductInformation);
            this.tabPage_Product.Controls.Add(this.groupBox_SensorInformation);
            this.tabPage_Product.Controls.Add(this.groupBox_SoftwareUpdate);
            this.tabPage_Product.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Product.Name = "tabPage_Product";
            this.tabPage_Product.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Product.Size = new System.Drawing.Size(356, 711);
            this.tabPage_Product.TabIndex = 0;
            this.tabPage_Product.Text = "Product";
            this.tabPage_Product.UseVisualStyleBackColor = true;
            // 
            // groupBox_ProductInformation
            // 
            this.groupBox_ProductInformation.Controls.Add(this.tableLayoutPanel_ProductInfo);
            this.groupBox_ProductInformation.Controls.Add(this.button_GetProductInformation);
            this.groupBox_ProductInformation.Location = new System.Drawing.Point(4, 11);
            this.groupBox_ProductInformation.Name = "groupBox_ProductInformation";
            this.groupBox_ProductInformation.Size = new System.Drawing.Size(345, 186);
            this.groupBox_ProductInformation.TabIndex = 10;
            this.groupBox_ProductInformation.TabStop = false;
            this.groupBox_ProductInformation.Text = "Product Information";
            // 
            // tableLayoutPanel_ProductInfo
            // 
            this.tableLayoutPanel_ProductInfo.ColumnCount = 2;
            this.tableLayoutPanel_ProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_ProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_HardwareVersion, 1, 3);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_ProductSerialNumber, 1, 2);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_ProductModelName, 1, 0);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_ProductPartNumber, 1, 1);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_ProductModelNameTitle, 0, 0);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_FirmwareVersion, 1, 5);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_BootloaderVersion, 1, 4);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_FirmwareVersionTitle, 0, 5);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_BootloaderVersionTitle, 0, 4);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_HardwareVersionTitle, 0, 3);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_ProductSerialNumberTitle, 0, 2);
            this.tableLayoutPanel_ProductInfo.Controls.Add(this.label_ProductPartNumberTitle, 0, 1);
            this.tableLayoutPanel_ProductInfo.Location = new System.Drawing.Point(13, 22);
            this.tableLayoutPanel_ProductInfo.Name = "tableLayoutPanel_ProductInfo";
            this.tableLayoutPanel_ProductInfo.RowCount = 6;
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_ProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_ProductInfo.Size = new System.Drawing.Size(261, 144);
            this.tableLayoutPanel_ProductInfo.TabIndex = 3;
            // 
            // label_HardwareVersion
            // 
            this.label_HardwareVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_HardwareVersion.AutoSize = true;
            this.label_HardwareVersion.Location = new System.Drawing.Point(143, 76);
            this.label_HardwareVersion.Name = "label_HardwareVersion";
            this.label_HardwareVersion.Size = new System.Drawing.Size(0, 15);
            this.label_HardwareVersion.TabIndex = 14;
            // 
            // label_ProductSerialNumber
            // 
            this.label_ProductSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_ProductSerialNumber.AutoSize = true;
            this.label_ProductSerialNumber.Location = new System.Drawing.Point(143, 52);
            this.label_ProductSerialNumber.Name = "label_ProductSerialNumber";
            this.label_ProductSerialNumber.Size = new System.Drawing.Size(0, 15);
            this.label_ProductSerialNumber.TabIndex = 13;
            // 
            // label_ProductModelName
            // 
            this.label_ProductModelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_ProductModelName.AutoSize = true;
            this.label_ProductModelName.Location = new System.Drawing.Point(143, 4);
            this.label_ProductModelName.Name = "label_ProductModelName";
            this.label_ProductModelName.Size = new System.Drawing.Size(0, 15);
            this.label_ProductModelName.TabIndex = 12;
            // 
            // label_ProductPartNumber
            // 
            this.label_ProductPartNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_ProductPartNumber.AutoSize = true;
            this.label_ProductPartNumber.Location = new System.Drawing.Point(143, 28);
            this.label_ProductPartNumber.Name = "label_ProductPartNumber";
            this.label_ProductPartNumber.Size = new System.Drawing.Size(0, 15);
            this.label_ProductPartNumber.TabIndex = 16;
            // 
            // label_ProductModelNameTitle
            // 
            this.label_ProductModelNameTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ProductModelNameTitle.AutoSize = true;
            this.label_ProductModelNameTitle.Location = new System.Drawing.Point(90, 4);
            this.label_ProductModelNameTitle.Name = "label_ProductModelNameTitle";
            this.label_ProductModelNameTitle.Size = new System.Drawing.Size(47, 15);
            this.label_ProductModelNameTitle.TabIndex = 9;
            this.label_ProductModelNameTitle.Text = "Model :";
            // 
            // label_FirmwareVersion
            // 
            this.label_FirmwareVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_FirmwareVersion.AutoSize = true;
            this.label_FirmwareVersion.Location = new System.Drawing.Point(143, 124);
            this.label_FirmwareVersion.Name = "label_FirmwareVersion";
            this.label_FirmwareVersion.Size = new System.Drawing.Size(0, 15);
            this.label_FirmwareVersion.TabIndex = 6;
            // 
            // label_BootloaderVersion
            // 
            this.label_BootloaderVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_BootloaderVersion.AutoSize = true;
            this.label_BootloaderVersion.Location = new System.Drawing.Point(143, 100);
            this.label_BootloaderVersion.Name = "label_BootloaderVersion";
            this.label_BootloaderVersion.Size = new System.Drawing.Size(0, 15);
            this.label_BootloaderVersion.TabIndex = 5;
            // 
            // label_FirmwareVersionTitle
            // 
            this.label_FirmwareVersionTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_FirmwareVersionTitle.AutoSize = true;
            this.label_FirmwareVersionTitle.Location = new System.Drawing.Point(34, 124);
            this.label_FirmwareVersionTitle.Name = "label_FirmwareVersionTitle";
            this.label_FirmwareVersionTitle.Size = new System.Drawing.Size(103, 15);
            this.label_FirmwareVersionTitle.TabIndex = 3;
            this.label_FirmwareVersionTitle.Text = "Firmware Version :";
            // 
            // label_BootloaderVersionTitle
            // 
            this.label_BootloaderVersionTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_BootloaderVersionTitle.AutoSize = true;
            this.label_BootloaderVersionTitle.Location = new System.Drawing.Point(25, 100);
            this.label_BootloaderVersionTitle.Name = "label_BootloaderVersionTitle";
            this.label_BootloaderVersionTitle.Size = new System.Drawing.Size(112, 15);
            this.label_BootloaderVersionTitle.TabIndex = 2;
            this.label_BootloaderVersionTitle.Text = "Bootloader Version :";
            // 
            // label_HardwareVersionTitle
            // 
            this.label_HardwareVersionTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_HardwareVersionTitle.AutoSize = true;
            this.label_HardwareVersionTitle.Location = new System.Drawing.Point(32, 76);
            this.label_HardwareVersionTitle.Name = "label_HardwareVersionTitle";
            this.label_HardwareVersionTitle.Size = new System.Drawing.Size(105, 15);
            this.label_HardwareVersionTitle.TabIndex = 10;
            this.label_HardwareVersionTitle.Text = "Hardware Version :";
            // 
            // label_ProductSerialNumberTitle
            // 
            this.label_ProductSerialNumberTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ProductSerialNumberTitle.AutoSize = true;
            this.label_ProductSerialNumberTitle.Location = new System.Drawing.Point(49, 52);
            this.label_ProductSerialNumberTitle.Name = "label_ProductSerialNumberTitle";
            this.label_ProductSerialNumberTitle.Size = new System.Drawing.Size(88, 15);
            this.label_ProductSerialNumberTitle.TabIndex = 11;
            this.label_ProductSerialNumberTitle.Text = "Serial Number :";
            // 
            // label_ProductPartNumberTitle
            // 
            this.label_ProductPartNumberTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_ProductPartNumberTitle.AutoSize = true;
            this.label_ProductPartNumberTitle.Location = new System.Drawing.Point(56, 28);
            this.label_ProductPartNumberTitle.Name = "label_ProductPartNumberTitle";
            this.label_ProductPartNumberTitle.Size = new System.Drawing.Size(81, 15);
            this.label_ProductPartNumberTitle.TabIndex = 15;
            this.label_ProductPartNumberTitle.Text = "Part Number :";
            // 
            // button_GetProductInformation
            // 
            this.button_GetProductInformation.Location = new System.Drawing.Point(280, 22);
            this.button_GetProductInformation.Name = "button_GetProductInformation";
            this.button_GetProductInformation.Size = new System.Drawing.Size(56, 120);
            this.button_GetProductInformation.TabIndex = 0;
            this.button_GetProductInformation.Text = "Get";
            this.button_GetProductInformation.UseVisualStyleBackColor = true;
            this.button_GetProductInformation.Click += new System.EventHandler(this.button_ProductControl_Click);
            // 
            // groupBox_SensorInformation
            // 
            this.groupBox_SensorInformation.Controls.Add(this.tableLayoutPanel_SensorInfo);
            this.groupBox_SensorInformation.Controls.Add(this.button_GetSensorInformation);
            this.groupBox_SensorInformation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_SensorInformation.Location = new System.Drawing.Point(4, 203);
            this.groupBox_SensorInformation.Name = "groupBox_SensorInformation";
            this.groupBox_SensorInformation.Size = new System.Drawing.Size(345, 103);
            this.groupBox_SensorInformation.TabIndex = 9;
            this.groupBox_SensorInformation.TabStop = false;
            this.groupBox_SensorInformation.Text = "Sensor Information";
            // 
            // tableLayoutPanel_SensorInfo
            // 
            this.tableLayoutPanel_SensorInfo.ColumnCount = 2;
            this.tableLayoutPanel_SensorInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_SensorInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel_SensorInfo.Controls.Add(this.label_SensorUptime, 1, 2);
            this.tableLayoutPanel_SensorInfo.Controls.Add(this.label_SensorUptimeTitle, 0, 2);
            this.tableLayoutPanel_SensorInfo.Controls.Add(this.label_SensorModelNameTitle, 0, 0);
            this.tableLayoutPanel_SensorInfo.Controls.Add(this.label_SensorSerialNumberTitle, 0, 1);
            this.tableLayoutPanel_SensorInfo.Controls.Add(this.label_SensorSerialNumber, 1, 1);
            this.tableLayoutPanel_SensorInfo.Controls.Add(this.label_SensorModelName, 1, 0);
            this.tableLayoutPanel_SensorInfo.Location = new System.Drawing.Point(13, 22);
            this.tableLayoutPanel_SensorInfo.Name = "tableLayoutPanel_SensorInfo";
            this.tableLayoutPanel_SensorInfo.RowCount = 3;
            this.tableLayoutPanel_SensorInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_SensorInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_SensorInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_SensorInfo.Size = new System.Drawing.Size(261, 72);
            this.tableLayoutPanel_SensorInfo.TabIndex = 6;
            // 
            // label_SensorUptime
            // 
            this.label_SensorUptime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_SensorUptime.AutoSize = true;
            this.label_SensorUptime.Location = new System.Drawing.Point(143, 52);
            this.label_SensorUptime.Name = "label_SensorUptime";
            this.label_SensorUptime.Size = new System.Drawing.Size(0, 15);
            this.label_SensorUptime.TabIndex = 1;
            // 
            // label_SensorUptimeTitle
            // 
            this.label_SensorUptimeTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_SensorUptimeTitle.AutoSize = true;
            this.label_SensorUptimeTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SensorUptimeTitle.Location = new System.Drawing.Point(47, 52);
            this.label_SensorUptimeTitle.Name = "label_SensorUptimeTitle";
            this.label_SensorUptimeTitle.Size = new System.Drawing.Size(90, 15);
            this.label_SensorUptimeTitle.TabIndex = 0;
            this.label_SensorUptimeTitle.Text = "Sensor Uptime :";
            // 
            // label_SensorModelNameTitle
            // 
            this.label_SensorModelNameTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_SensorModelNameTitle.AutoSize = true;
            this.label_SensorModelNameTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SensorModelNameTitle.Location = new System.Drawing.Point(17, 4);
            this.label_SensorModelNameTitle.Name = "label_SensorModelNameTitle";
            this.label_SensorModelNameTitle.Size = new System.Drawing.Size(120, 15);
            this.label_SensorModelNameTitle.TabIndex = 5;
            this.label_SensorModelNameTitle.Text = "Sensor Model Name :";
            // 
            // label_SensorSerialNumberTitle
            // 
            this.label_SensorSerialNumberTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_SensorSerialNumberTitle.AutoSize = true;
            this.label_SensorSerialNumberTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SensorSerialNumberTitle.Location = new System.Drawing.Point(11, 28);
            this.label_SensorSerialNumberTitle.Name = "label_SensorSerialNumberTitle";
            this.label_SensorSerialNumberTitle.Size = new System.Drawing.Size(126, 15);
            this.label_SensorSerialNumberTitle.TabIndex = 0;
            this.label_SensorSerialNumberTitle.Text = "Sensor Serial Number :";
            // 
            // label_SensorSerialNumber
            // 
            this.label_SensorSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_SensorSerialNumber.AutoSize = true;
            this.label_SensorSerialNumber.Location = new System.Drawing.Point(143, 28);
            this.label_SensorSerialNumber.Name = "label_SensorSerialNumber";
            this.label_SensorSerialNumber.Size = new System.Drawing.Size(0, 15);
            this.label_SensorSerialNumber.TabIndex = 1;
            // 
            // label_SensorModelName
            // 
            this.label_SensorModelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_SensorModelName.AutoSize = true;
            this.label_SensorModelName.Location = new System.Drawing.Point(143, 4);
            this.label_SensorModelName.Name = "label_SensorModelName";
            this.label_SensorModelName.Size = new System.Drawing.Size(0, 15);
            this.label_SensorModelName.TabIndex = 5;
            // 
            // button_GetSensorInformation
            // 
            this.button_GetSensorInformation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_GetSensorInformation.Location = new System.Drawing.Point(280, 22);
            this.button_GetSensorInformation.Name = "button_GetSensorInformation";
            this.button_GetSensorInformation.Size = new System.Drawing.Size(56, 72);
            this.button_GetSensorInformation.TabIndex = 7;
            this.button_GetSensorInformation.Text = "Get";
            this.button_GetSensorInformation.UseVisualStyleBackColor = true;
            this.button_GetSensorInformation.Click += new System.EventHandler(this.button_ProductControl_Click);
            // 
            // groupBox_SoftwareUpdate
            // 
            this.groupBox_SoftwareUpdate.Controls.Add(this.tableLayoutPanel_BinaryInforation);
            this.groupBox_SoftwareUpdate.Controls.Add(this.button_SoftwareUpdateFileBrowse);
            this.groupBox_SoftwareUpdate.Controls.Add(this.textBox_SoftwareUpdateFilePath);
            this.groupBox_SoftwareUpdate.Controls.Add(this.button_StartSoftwareUpdate);
            this.groupBox_SoftwareUpdate.Controls.Add(this.tableLayoutPanel_SoftwareUpdateBlank);
            this.groupBox_SoftwareUpdate.Controls.Add(this.progressBar_SoftwareUpdate);
            this.groupBox_SoftwareUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_SoftwareUpdate.Location = new System.Drawing.Point(4, 321);
            this.groupBox_SoftwareUpdate.Name = "groupBox_SoftwareUpdate";
            this.groupBox_SoftwareUpdate.Size = new System.Drawing.Size(345, 264);
            this.groupBox_SoftwareUpdate.TabIndex = 3;
            this.groupBox_SoftwareUpdate.TabStop = false;
            this.groupBox_SoftwareUpdate.Text = "Software Update";
            // 
            // tableLayoutPanel_BinaryInforation
            // 
            this.tableLayoutPanel_BinaryInforation.ColumnCount = 2;
            this.tableLayoutPanel_BinaryInforation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.88957F));
            this.tableLayoutPanel_BinaryInforation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.11043F));
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryInformationTitle, 0, 0);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinarySizeTitle, 0, 5);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryVendorNameTitle, 0, 1);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryProductNameTitle, 0, 2);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryVersionTitle, 0, 3);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryBuildTimeTitle, 0, 4);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryVendorName, 1, 1);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryProductName, 1, 2);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryVersion, 1, 3);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinaryBuildTime, 1, 4);
            this.tableLayoutPanel_BinaryInforation.Controls.Add(this.label_BinarySize, 1, 5);
            this.tableLayoutPanel_BinaryInforation.Location = new System.Drawing.Point(10, 22);
            this.tableLayoutPanel_BinaryInforation.Name = "tableLayoutPanel_BinaryInforation";
            this.tableLayoutPanel_BinaryInforation.RowCount = 6;
            this.tableLayoutPanel_BinaryInforation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_BinaryInforation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_BinaryInforation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_BinaryInforation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_BinaryInforation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_BinaryInforation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_BinaryInforation.Size = new System.Drawing.Size(326, 120);
            this.tableLayoutPanel_BinaryInforation.TabIndex = 9;
            // 
            // label_BinaryInformationTitle
            // 
            this.label_BinaryInformationTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_BinaryInformationTitle.AutoSize = true;
            this.label_BinaryInformationTitle.Location = new System.Drawing.Point(3, 2);
            this.label_BinaryInformationTitle.Name = "label_BinaryInformationTitle";
            this.label_BinaryInformationTitle.Size = new System.Drawing.Size(106, 15);
            this.label_BinaryInformationTitle.TabIndex = 0;
            this.label_BinaryInformationTitle.Text = "Binary Information";
            // 
            // label_BinarySizeTitle
            // 
            this.label_BinarySizeTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_BinarySizeTitle.AutoSize = true;
            this.label_BinarySizeTitle.Location = new System.Drawing.Point(80, 102);
            this.label_BinarySizeTitle.Name = "label_BinarySizeTitle";
            this.label_BinarySizeTitle.Size = new System.Drawing.Size(33, 15);
            this.label_BinarySizeTitle.TabIndex = 4;
            this.label_BinarySizeTitle.Text = "Size :";
            // 
            // label_BinaryVendorNameTitle
            // 
            this.label_BinaryVendorNameTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_BinaryVendorNameTitle.AutoSize = true;
            this.label_BinaryVendorNameTitle.Location = new System.Drawing.Point(28, 22);
            this.label_BinaryVendorNameTitle.Name = "label_BinaryVendorNameTitle";
            this.label_BinaryVendorNameTitle.Size = new System.Drawing.Size(85, 15);
            this.label_BinaryVendorNameTitle.TabIndex = 1;
            this.label_BinaryVendorNameTitle.Text = "Vendor Name :";
            // 
            // label_BinaryProductNameTitle
            // 
            this.label_BinaryProductNameTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_BinaryProductNameTitle.AutoSize = true;
            this.label_BinaryProductNameTitle.Location = new System.Drawing.Point(23, 42);
            this.label_BinaryProductNameTitle.Name = "label_BinaryProductNameTitle";
            this.label_BinaryProductNameTitle.Size = new System.Drawing.Size(90, 15);
            this.label_BinaryProductNameTitle.TabIndex = 2;
            this.label_BinaryProductNameTitle.Text = "Product Name :";
            // 
            // label_BinaryVersionTitle
            // 
            this.label_BinaryVersionTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_BinaryVersionTitle.AutoSize = true;
            this.label_BinaryVersionTitle.Location = new System.Drawing.Point(62, 62);
            this.label_BinaryVersionTitle.Name = "label_BinaryVersionTitle";
            this.label_BinaryVersionTitle.Size = new System.Drawing.Size(51, 15);
            this.label_BinaryVersionTitle.TabIndex = 3;
            this.label_BinaryVersionTitle.Text = "Version :";
            // 
            // label_BinaryBuildTimeTitle
            // 
            this.label_BinaryBuildTimeTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_BinaryBuildTimeTitle.AutoSize = true;
            this.label_BinaryBuildTimeTitle.Location = new System.Drawing.Point(44, 82);
            this.label_BinaryBuildTimeTitle.Name = "label_BinaryBuildTimeTitle";
            this.label_BinaryBuildTimeTitle.Size = new System.Drawing.Size(69, 15);
            this.label_BinaryBuildTimeTitle.TabIndex = 5;
            this.label_BinaryBuildTimeTitle.Text = "Build Time :";
            // 
            // label_BinaryVendorName
            // 
            this.label_BinaryVendorName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_BinaryVendorName.AutoSize = true;
            this.label_BinaryVendorName.Location = new System.Drawing.Point(119, 22);
            this.label_BinaryVendorName.Name = "label_BinaryVendorName";
            this.label_BinaryVendorName.Size = new System.Drawing.Size(0, 15);
            this.label_BinaryVendorName.TabIndex = 6;
            // 
            // label_BinaryProductName
            // 
            this.label_BinaryProductName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_BinaryProductName.AutoSize = true;
            this.label_BinaryProductName.Location = new System.Drawing.Point(119, 42);
            this.label_BinaryProductName.Name = "label_BinaryProductName";
            this.label_BinaryProductName.Size = new System.Drawing.Size(0, 15);
            this.label_BinaryProductName.TabIndex = 7;
            // 
            // label_BinaryVersion
            // 
            this.label_BinaryVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_BinaryVersion.AutoSize = true;
            this.label_BinaryVersion.Location = new System.Drawing.Point(119, 62);
            this.label_BinaryVersion.Name = "label_BinaryVersion";
            this.label_BinaryVersion.Size = new System.Drawing.Size(0, 15);
            this.label_BinaryVersion.TabIndex = 8;
            // 
            // label_BinaryBuildTime
            // 
            this.label_BinaryBuildTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_BinaryBuildTime.AutoSize = true;
            this.label_BinaryBuildTime.Location = new System.Drawing.Point(119, 82);
            this.label_BinaryBuildTime.Name = "label_BinaryBuildTime";
            this.label_BinaryBuildTime.Size = new System.Drawing.Size(0, 15);
            this.label_BinaryBuildTime.TabIndex = 9;
            // 
            // label_BinarySize
            // 
            this.label_BinarySize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_BinarySize.AutoSize = true;
            this.label_BinarySize.Location = new System.Drawing.Point(119, 102);
            this.label_BinarySize.Name = "label_BinarySize";
            this.label_BinarySize.Size = new System.Drawing.Size(0, 15);
            this.label_BinarySize.TabIndex = 10;
            // 
            // button_SoftwareUpdateFileBrowse
            // 
            this.button_SoftwareUpdateFileBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SoftwareUpdateFileBrowse.Location = new System.Drawing.Point(10, 204);
            this.button_SoftwareUpdateFileBrowse.Name = "button_SoftwareUpdateFileBrowse";
            this.button_SoftwareUpdateFileBrowse.Size = new System.Drawing.Size(63, 23);
            this.button_SoftwareUpdateFileBrowse.TabIndex = 8;
            this.button_SoftwareUpdateFileBrowse.Text = "Browse";
            this.button_SoftwareUpdateFileBrowse.UseVisualStyleBackColor = true;
            this.button_SoftwareUpdateFileBrowse.Click += new System.EventHandler(this.button_ProductControl_Click);
            // 
            // textBox_SoftwareUpdateFilePath
            // 
            this.textBox_SoftwareUpdateFilePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SoftwareUpdateFilePath.Location = new System.Drawing.Point(79, 204);
            this.textBox_SoftwareUpdateFilePath.Name = "textBox_SoftwareUpdateFilePath";
            this.textBox_SoftwareUpdateFilePath.ReadOnly = true;
            this.textBox_SoftwareUpdateFilePath.Size = new System.Drawing.Size(257, 23);
            this.textBox_SoftwareUpdateFilePath.TabIndex = 7;
            // 
            // button_StartSoftwareUpdate
            // 
            this.button_StartSoftwareUpdate.Enabled = false;
            this.button_StartSoftwareUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartSoftwareUpdate.Location = new System.Drawing.Point(10, 234);
            this.button_StartSoftwareUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_StartSoftwareUpdate.Name = "button_StartSoftwareUpdate";
            this.button_StartSoftwareUpdate.Size = new System.Drawing.Size(326, 23);
            this.button_StartSoftwareUpdate.TabIndex = 6;
            this.button_StartSoftwareUpdate.Text = "Browse and Select Binary File";
            this.button_StartSoftwareUpdate.UseVisualStyleBackColor = true;
            this.button_StartSoftwareUpdate.Click += new System.EventHandler(this.button_ProductControl_Click);
            // 
            // tableLayoutPanel_SoftwareUpdateBlank
            // 
            this.tableLayoutPanel_SoftwareUpdateBlank.ColumnCount = 1;
            this.tableLayoutPanel_SoftwareUpdateBlank.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.12613F));
            this.tableLayoutPanel_SoftwareUpdateBlank.Controls.Add(this.label_SoftwareUpdateStatus, 0, 0);
            this.tableLayoutPanel_SoftwareUpdateBlank.Location = new System.Drawing.Point(10, 152);
            this.tableLayoutPanel_SoftwareUpdateBlank.Name = "tableLayoutPanel_SoftwareUpdateBlank";
            this.tableLayoutPanel_SoftwareUpdateBlank.RowCount = 1;
            this.tableLayoutPanel_SoftwareUpdateBlank.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_SoftwareUpdateBlank.Size = new System.Drawing.Size(326, 17);
            this.tableLayoutPanel_SoftwareUpdateBlank.TabIndex = 5;
            // 
            // label_SoftwareUpdateStatus
            // 
            this.label_SoftwareUpdateStatus.AutoSize = true;
            this.label_SoftwareUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SoftwareUpdateStatus.Location = new System.Drawing.Point(3, 0);
            this.label_SoftwareUpdateStatus.Name = "label_SoftwareUpdateStatus";
            this.label_SoftwareUpdateStatus.Size = new System.Drawing.Size(0, 15);
            this.label_SoftwareUpdateStatus.TabIndex = 0;
            // 
            // progressBar_SoftwareUpdate
            // 
            this.progressBar_SoftwareUpdate.Location = new System.Drawing.Point(10, 175);
            this.progressBar_SoftwareUpdate.Name = "progressBar_SoftwareUpdate";
            this.progressBar_SoftwareUpdate.Size = new System.Drawing.Size(326, 23);
            this.progressBar_SoftwareUpdate.TabIndex = 0;
            // 
            // tabPage_Network
            // 
            this.tabPage_Network.Controls.Add(this.groupBox_NetworkConfiguration);
            this.tabPage_Network.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Network.Name = "tabPage_Network";
            this.tabPage_Network.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Network.Size = new System.Drawing.Size(356, 711);
            this.tabPage_Network.TabIndex = 2;
            this.tabPage_Network.Text = "Network";
            this.tabPage_Network.UseVisualStyleBackColor = true;
            // 
            // groupBox_NetworkConfiguration
            // 
            this.groupBox_NetworkConfiguration.Controls.Add(this.tableLayoutPanel_NetworkConfig);
            this.groupBox_NetworkConfiguration.Controls.Add(this.button_SystemReboot);
            this.groupBox_NetworkConfiguration.Controls.Add(this.button_SetDefaultNetworkConfiguration);
            this.groupBox_NetworkConfiguration.Location = new System.Drawing.Point(3, 11);
            this.groupBox_NetworkConfiguration.Name = "groupBox_NetworkConfiguration";
            this.groupBox_NetworkConfiguration.Size = new System.Drawing.Size(348, 297);
            this.groupBox_NetworkConfiguration.TabIndex = 16;
            this.groupBox_NetworkConfiguration.TabStop = false;
            this.groupBox_NetworkConfiguration.Text = "Network Configuration";
            // 
            // tableLayoutPanel_NetworkConfig
            // 
            this.tableLayoutPanel_NetworkConfig.ColumnCount = 4;
            this.tableLayoutPanel_NetworkConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel_NetworkConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel_NetworkConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_NetworkConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.textBox_SubDNSServer, 2, 6);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.label_SubDNSServerTitle, 0, 6);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.label_MACAddressTitle, 0, 0);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.textBox_MACAddress, 2, 0);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.button_GetNetworkConfiguration, 1, 0);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.label_IPAssignmentTitle, 0, 1);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.label_IPAddressTitle, 0, 2);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.label_NetmaskTitle, 0, 3);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.label_GatewayNameTitle, 0, 4);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.textBox_IPAddress, 2, 2);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.textBox_Netmask, 2, 3);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.textBox_Gateway, 2, 4);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.textBox_MainDNSServer, 2, 5);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.button_SetNetworkConfiguration, 3, 1);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.comboBox_IPAssignment, 2, 1);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.label_MainDNSServerTitle, 0, 5);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.label_SplashScreenTitle, 0, 7);
            this.tableLayoutPanel_NetworkConfig.Controls.Add(this.comboBox_SplashScreen, 2, 7);
            this.tableLayoutPanel_NetworkConfig.Location = new System.Drawing.Point(5, 22);
            this.tableLayoutPanel_NetworkConfig.Name = "tableLayoutPanel_NetworkConfig";
            this.tableLayoutPanel_NetworkConfig.RowCount = 8;
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_NetworkConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_NetworkConfig.Size = new System.Drawing.Size(337, 203);
            this.tableLayoutPanel_NetworkConfig.TabIndex = 11;
            // 
            // textBox_SubDNSServer
            // 
            this.textBox_SubDNSServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_SubDNSServer.Location = new System.Drawing.Point(157, 153);
            this.textBox_SubDNSServer.Name = "textBox_SubDNSServer";
            this.textBox_SubDNSServer.ReadOnly = true;
            this.textBox_SubDNSServer.Size = new System.Drawing.Size(138, 23);
            this.textBox_SubDNSServer.TabIndex = 16;
            // 
            // label_SubDNSServerTitle
            // 
            this.label_SubDNSServerTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SubDNSServerTitle.AutoSize = true;
            this.label_SubDNSServerTitle.Location = new System.Drawing.Point(18, 150);
            this.label_SubDNSServerTitle.Name = "label_SubDNSServerTitle";
            this.label_SubDNSServerTitle.Size = new System.Drawing.Size(94, 25);
            this.label_SubDNSServerTitle.TabIndex = 15;
            this.label_SubDNSServerTitle.Text = "Sub DNS Server :";
            this.label_SubDNSServerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_MACAddressTitle
            // 
            this.label_MACAddressTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_MACAddressTitle.AutoSize = true;
            this.label_MACAddressTitle.Location = new System.Drawing.Point(27, 0);
            this.label_MACAddressTitle.Name = "label_MACAddressTitle";
            this.label_MACAddressTitle.Size = new System.Drawing.Size(85, 25);
            this.label_MACAddressTitle.TabIndex = 1;
            this.label_MACAddressTitle.Text = "MAC Address :";
            this.label_MACAddressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_MACAddress
            // 
            this.textBox_MACAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MACAddress.Location = new System.Drawing.Point(157, 3);
            this.textBox_MACAddress.Name = "textBox_MACAddress";
            this.textBox_MACAddress.ReadOnly = true;
            this.textBox_MACAddress.Size = new System.Drawing.Size(138, 23);
            this.textBox_MACAddress.TabIndex = 9;
            // 
            // button_GetNetworkConfiguration
            // 
            this.button_GetNetworkConfiguration.Location = new System.Drawing.Point(118, 3);
            this.button_GetNetworkConfiguration.Name = "button_GetNetworkConfiguration";
            this.tableLayoutPanel_NetworkConfig.SetRowSpan(this.button_GetNetworkConfiguration, 8);
            this.button_GetNetworkConfiguration.Size = new System.Drawing.Size(33, 197);
            this.button_GetNetworkConfiguration.TabIndex = 6;
            this.button_GetNetworkConfiguration.Text = "Get";
            this.button_GetNetworkConfiguration.UseVisualStyleBackColor = true;
            this.button_GetNetworkConfiguration.Click += new System.EventHandler(this.button_NetworkControl_Click);
            // 
            // label_IPAssignmentTitle
            // 
            this.label_IPAssignmentTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_IPAssignmentTitle.AutoSize = true;
            this.label_IPAssignmentTitle.Location = new System.Drawing.Point(23, 25);
            this.label_IPAssignmentTitle.Name = "label_IPAssignmentTitle";
            this.label_IPAssignmentTitle.Size = new System.Drawing.Size(89, 25);
            this.label_IPAssignmentTitle.TabIndex = 7;
            this.label_IPAssignmentTitle.Text = "IP Assignment :";
            this.label_IPAssignmentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_IPAddressTitle
            // 
            this.label_IPAddressTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_IPAddressTitle.AutoSize = true;
            this.label_IPAddressTitle.Location = new System.Drawing.Point(44, 50);
            this.label_IPAddressTitle.Name = "label_IPAddressTitle";
            this.label_IPAddressTitle.Size = new System.Drawing.Size(68, 25);
            this.label_IPAddressTitle.TabIndex = 8;
            this.label_IPAddressTitle.Text = "IP Address :";
            this.label_IPAddressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_NetmaskTitle
            // 
            this.label_NetmaskTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_NetmaskTitle.AutoSize = true;
            this.label_NetmaskTitle.Location = new System.Drawing.Point(52, 75);
            this.label_NetmaskTitle.Name = "label_NetmaskTitle";
            this.label_NetmaskTitle.Size = new System.Drawing.Size(60, 25);
            this.label_NetmaskTitle.TabIndex = 9;
            this.label_NetmaskTitle.Text = "Netmask :";
            this.label_NetmaskTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_GatewayNameTitle
            // 
            this.label_GatewayNameTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_GatewayNameTitle.AutoSize = true;
            this.label_GatewayNameTitle.Location = new System.Drawing.Point(54, 100);
            this.label_GatewayNameTitle.Name = "label_GatewayNameTitle";
            this.label_GatewayNameTitle.Size = new System.Drawing.Size(58, 25);
            this.label_GatewayNameTitle.TabIndex = 10;
            this.label_GatewayNameTitle.Text = "Gateway :";
            this.label_GatewayNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_IPAddress
            // 
            this.textBox_IPAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_IPAddress.Location = new System.Drawing.Point(157, 53);
            this.textBox_IPAddress.Name = "textBox_IPAddress";
            this.textBox_IPAddress.ReadOnly = true;
            this.textBox_IPAddress.Size = new System.Drawing.Size(138, 23);
            this.textBox_IPAddress.TabIndex = 9;
            // 
            // textBox_Netmask
            // 
            this.textBox_Netmask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Netmask.Location = new System.Drawing.Point(157, 78);
            this.textBox_Netmask.Name = "textBox_Netmask";
            this.textBox_Netmask.ReadOnly = true;
            this.textBox_Netmask.Size = new System.Drawing.Size(138, 23);
            this.textBox_Netmask.TabIndex = 9;
            // 
            // textBox_Gateway
            // 
            this.textBox_Gateway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Gateway.Location = new System.Drawing.Point(157, 103);
            this.textBox_Gateway.Name = "textBox_Gateway";
            this.textBox_Gateway.ReadOnly = true;
            this.textBox_Gateway.Size = new System.Drawing.Size(138, 23);
            this.textBox_Gateway.TabIndex = 9;
            // 
            // textBox_MainDNSServer
            // 
            this.textBox_MainDNSServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_MainDNSServer.Location = new System.Drawing.Point(157, 128);
            this.textBox_MainDNSServer.Name = "textBox_MainDNSServer";
            this.textBox_MainDNSServer.ReadOnly = true;
            this.textBox_MainDNSServer.Size = new System.Drawing.Size(138, 23);
            this.textBox_MainDNSServer.TabIndex = 9;
            // 
            // button_SetNetworkConfiguration
            // 
            this.button_SetNetworkConfiguration.Enabled = false;
            this.button_SetNetworkConfiguration.Location = new System.Drawing.Point(301, 28);
            this.button_SetNetworkConfiguration.Name = "button_SetNetworkConfiguration";
            this.tableLayoutPanel_NetworkConfig.SetRowSpan(this.button_SetNetworkConfiguration, 7);
            this.button_SetNetworkConfiguration.Size = new System.Drawing.Size(33, 168);
            this.button_SetNetworkConfiguration.TabIndex = 6;
            this.button_SetNetworkConfiguration.Text = "Set";
            this.button_SetNetworkConfiguration.UseVisualStyleBackColor = true;
            this.button_SetNetworkConfiguration.Click += new System.EventHandler(this.button_NetworkControl_Click);
            // 
            // comboBox_IPAssignment
            // 
            this.comboBox_IPAssignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IPAssignment.Enabled = false;
            this.comboBox_IPAssignment.FormattingEnabled = true;
            this.comboBox_IPAssignment.Items.AddRange(new object[] {
            "Static",
            "DHCP"});
            this.comboBox_IPAssignment.Location = new System.Drawing.Point(157, 28);
            this.comboBox_IPAssignment.Name = "comboBox_IPAssignment";
            this.comboBox_IPAssignment.Size = new System.Drawing.Size(138, 23);
            this.comboBox_IPAssignment.TabIndex = 12;
            this.comboBox_IPAssignment.SelectedIndexChanged += new System.EventHandler(this.comboBox_IPAssignment_SelectedIndexChanged);
            // 
            // label_MainDNSServerTitle
            // 
            this.label_MainDNSServerTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_MainDNSServerTitle.AutoSize = true;
            this.label_MainDNSServerTitle.Location = new System.Drawing.Point(11, 125);
            this.label_MainDNSServerTitle.Name = "label_MainDNSServerTitle";
            this.label_MainDNSServerTitle.Size = new System.Drawing.Size(101, 25);
            this.label_MainDNSServerTitle.TabIndex = 11;
            this.label_MainDNSServerTitle.Text = "Main DNS Server :";
            this.label_MainDNSServerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_SplashScreenTitle
            // 
            this.label_SplashScreenTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_SplashScreenTitle.AutoSize = true;
            this.label_SplashScreenTitle.Location = new System.Drawing.Point(27, 175);
            this.label_SplashScreenTitle.Name = "label_SplashScreenTitle";
            this.label_SplashScreenTitle.Size = new System.Drawing.Size(85, 28);
            this.label_SplashScreenTitle.TabIndex = 17;
            this.label_SplashScreenTitle.Text = "Splash Screen :";
            this.label_SplashScreenTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox_SplashScreen
            // 
            this.comboBox_SplashScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SplashScreen.Enabled = false;
            this.comboBox_SplashScreen.FormattingEnabled = true;
            this.comboBox_SplashScreen.Items.AddRange(new object[] {
            "On",
            "Off"});
            this.comboBox_SplashScreen.Location = new System.Drawing.Point(157, 178);
            this.comboBox_SplashScreen.Name = "comboBox_SplashScreen";
            this.comboBox_SplashScreen.Size = new System.Drawing.Size(138, 23);
            this.comboBox_SplashScreen.TabIndex = 18;
            // 
            // button_SystemReboot
            // 
            this.button_SystemReboot.Location = new System.Drawing.Point(123, 261);
            this.button_SystemReboot.Name = "button_SystemReboot";
            this.button_SystemReboot.Size = new System.Drawing.Size(216, 27);
            this.button_SystemReboot.TabIndex = 15;
            this.button_SystemReboot.Text = "Reboot to Apply Changes";
            this.button_SystemReboot.UseVisualStyleBackColor = true;
            this.button_SystemReboot.Click += new System.EventHandler(this.button_NetworkControl_Click);
            // 
            // button_SetDefaultNetworkConfiguration
            // 
            this.button_SetDefaultNetworkConfiguration.Location = new System.Drawing.Point(123, 231);
            this.button_SetDefaultNetworkConfiguration.Name = "button_SetDefaultNetworkConfiguration";
            this.button_SetDefaultNetworkConfiguration.Size = new System.Drawing.Size(216, 27);
            this.button_SetDefaultNetworkConfiguration.TabIndex = 13;
            this.button_SetDefaultNetworkConfiguration.Text = "Set to Factory Default";
            this.button_SetDefaultNetworkConfiguration.UseVisualStyleBackColor = true;
            this.button_SetDefaultNetworkConfiguration.Click += new System.EventHandler(this.button_NetworkControl_Click);
            // 
            // tabControl_SensorConfig
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.tabControl_SensorConfig, 2);
            this.tabControl_SensorConfig.Controls.Add(this.tabPage_SensorControl);
            this.tabControl_SensorConfig.Controls.Add(this.tabPage_RoiManager);
            this.tabControl_SensorConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_SensorConfig.Enabled = false;
            this.tabControl_SensorConfig.Location = new System.Drawing.Point(3, 474);
            this.tabControl_SensorConfig.Name = "tabControl_SensorConfig";
            this.tabControl_SensorConfig.SelectedIndex = 0;
            this.tabControl_SensorConfig.Size = new System.Drawing.Size(727, 268);
            this.tabControl_SensorConfig.TabIndex = 5;
            // 
            // tabPage_SensorControl
            // 
            this.tabPage_SensorControl.Controls.Add(this.panel_SensorControl_256G);
            this.tabPage_SensorControl.Controls.Add(this.panel_SensorControl_256);
            this.tabPage_SensorControl.Controls.Add(this.panel_SensorControl_160);
            this.tabPage_SensorControl.Location = new System.Drawing.Point(4, 24);
            this.tabPage_SensorControl.Name = "tabPage_SensorControl";
            this.tabPage_SensorControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_SensorControl.Size = new System.Drawing.Size(719, 240);
            this.tabPage_SensorControl.TabIndex = 0;
            this.tabPage_SensorControl.Text = "Sensor Control";
            this.tabPage_SensorControl.UseVisualStyleBackColor = true;
            // 
            // panel_SensorControl_256G
            // 
            this.panel_SensorControl_256G.Controls.Add(this.groupBox_FluxParameters_256G);
            this.panel_SensorControl_256G.Controls.Add(this.groupBox_FFCParameters_256G);
            this.panel_SensorControl_256G.Controls.Add(this.button_StoreUserSensorConfig_256G);
            this.panel_SensorControl_256G.Controls.Add(this.button_RestoreDefaultSensorConfig_256G);
            this.panel_SensorControl_256G.Controls.Add(this.groupBox_GainModeState_256G);
            this.panel_SensorControl_256G.Controls.Add(this.groupBox_FlatFieldCorrection_256G);
            this.panel_SensorControl_256G.Location = new System.Drawing.Point(0, 0);
            this.panel_SensorControl_256G.Name = "panel_SensorControl_256G";
            this.panel_SensorControl_256G.Size = new System.Drawing.Size(719, 240);
            this.panel_SensorControl_256G.TabIndex = 14;
            this.panel_SensorControl_256G.Visible = false;
            // 
            // groupBox_FluxParameters_256G
            // 
            this.groupBox_FluxParameters_256G.Controls.Add(this.tableLayoutPanel_FluxParam256G);
            this.groupBox_FluxParameters_256G.Enabled = false;
            this.groupBox_FluxParameters_256G.Location = new System.Drawing.Point(11, 4);
            this.groupBox_FluxParameters_256G.Name = "groupBox_FluxParameters_256G";
            this.groupBox_FluxParameters_256G.Size = new System.Drawing.Size(467, 155);
            this.groupBox_FluxParameters_256G.TabIndex = 18;
            this.groupBox_FluxParameters_256G.TabStop = false;
            this.groupBox_FluxParameters_256G.Text = "Flux Parameters (Not Support)";
            // 
            // tableLayoutPanel_FluxParam256G
            // 
            this.tableLayoutPanel_FluxParam256G.ColumnCount = 6;
            this.tableLayoutPanel_FluxParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel_FluxParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel_FluxParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel_FluxParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FluxParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_FluxParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_FluxParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.label_FluxParam256G_DistanceTitle, 0, 4);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.label_FluxParam256G_EmissivityTitle, 0, 0);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.textBox_FluxParam256G_EmissivityRange, 4, 0);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.button_GetFluxParameters_256G, 1, 0);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.button_SetFluxParameters_256G, 5, 0);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.numericUpDown_FluxParam256G_Emissivity, 2, 0);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.label_FluxParam256G_AtmosphericTransmittanceTitle, 0, 1);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.numericUpDown_FluxParam256G_AtmosphericTransmittance, 2, 1);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.textBox_FluxParam256G_AtmosphericTransmittanceRange, 4, 1);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.label_FluxParam256G_AtmosphericTemperatureTitle, 0, 2);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.numericUpDown_FluxParam256G_AtmosphericTemperature, 2, 2);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.textBox_FluxParam256G_AtmosphericTemperatureRange, 4, 2);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.label_FluxParam256G_AtmosphericTemperatureUnit, 3, 2);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.label_FluxParam256G_AmbientReflectionTemperatureTitle, 0, 3);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.numericUpDown_FluxParam256G_AmbientReflectionTemperature, 2, 3);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.label_FluxParam256G_AmbientReflectionTemperatureUnit, 3, 3);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.textBox_FluxParam256G_AmbientReflectionTemperatureRange, 4, 3);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.numericUpDown_FluxParam256G_Distance, 2, 4);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.label_FluxParam256G_DistanceUnit, 3, 4);
            this.tableLayoutPanel_FluxParam256G.Controls.Add(this.textBox_FluxParam256G_DistanceRange, 4, 4);
            this.tableLayoutPanel_FluxParam256G.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel_FluxParam256G.Name = "tableLayoutPanel_FluxParam256G";
            this.tableLayoutPanel_FluxParam256G.RowCount = 5;
            this.tableLayoutPanel_FluxParam256G.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256G.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256G.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256G.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256G.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256G.Size = new System.Drawing.Size(455, 130);
            this.tableLayoutPanel_FluxParam256G.TabIndex = 10;
            // 
            // label_FluxParam256G_DistanceTitle
            // 
            this.label_FluxParam256G_DistanceTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256G_DistanceTitle.AutoSize = true;
            this.label_FluxParam256G_DistanceTitle.Location = new System.Drawing.Point(130, 104);
            this.label_FluxParam256G_DistanceTitle.Name = "label_FluxParam256G_DistanceTitle";
            this.label_FluxParam256G_DistanceTitle.Size = new System.Drawing.Size(58, 26);
            this.label_FluxParam256G_DistanceTitle.TabIndex = 25;
            this.label_FluxParam256G_DistanceTitle.Text = "Distance :";
            this.label_FluxParam256G_DistanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_FluxParam256G_EmissivityTitle
            // 
            this.label_FluxParam256G_EmissivityTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256G_EmissivityTitle.AutoSize = true;
            this.label_FluxParam256G_EmissivityTitle.Location = new System.Drawing.Point(123, 0);
            this.label_FluxParam256G_EmissivityTitle.Name = "label_FluxParam256G_EmissivityTitle";
            this.label_FluxParam256G_EmissivityTitle.Size = new System.Drawing.Size(65, 26);
            this.label_FluxParam256G_EmissivityTitle.TabIndex = 1;
            this.label_FluxParam256G_EmissivityTitle.Text = "Emissivity :";
            this.label_FluxParam256G_EmissivityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FluxParam256G_EmissivityRange
            // 
            this.textBox_FluxParam256G_EmissivityRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256G_EmissivityRange.Enabled = false;
            this.textBox_FluxParam256G_EmissivityRange.Location = new System.Drawing.Point(319, 3);
            this.textBox_FluxParam256G_EmissivityRange.Name = "textBox_FluxParam256G_EmissivityRange";
            this.textBox_FluxParam256G_EmissivityRange.ReadOnly = true;
            this.textBox_FluxParam256G_EmissivityRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256G_EmissivityRange.TabIndex = 9;
            this.textBox_FluxParam256G_EmissivityRange.Text = "0.00 ~ 1.00";
            this.textBox_FluxParam256G_EmissivityRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_GetFluxParameters_256G
            // 
            this.button_GetFluxParameters_256G.Location = new System.Drawing.Point(194, 3);
            this.button_GetFluxParameters_256G.Name = "button_GetFluxParameters_256G";
            this.tableLayoutPanel_FluxParam256G.SetRowSpan(this.button_GetFluxParameters_256G, 5);
            this.button_GetFluxParameters_256G.Size = new System.Drawing.Size(33, 124);
            this.button_GetFluxParameters_256G.TabIndex = 6;
            this.button_GetFluxParameters_256G.Text = "Get";
            this.button_GetFluxParameters_256G.UseVisualStyleBackColor = true;
            // 
            // button_SetFluxParameters_256G
            // 
            this.button_SetFluxParameters_256G.Enabled = false;
            this.button_SetFluxParameters_256G.Location = new System.Drawing.Point(419, 3);
            this.button_SetFluxParameters_256G.Name = "button_SetFluxParameters_256G";
            this.tableLayoutPanel_FluxParam256G.SetRowSpan(this.button_SetFluxParameters_256G, 5);
            this.button_SetFluxParameters_256G.Size = new System.Drawing.Size(34, 124);
            this.button_SetFluxParameters_256G.TabIndex = 6;
            this.button_SetFluxParameters_256G.Text = "Set";
            this.button_SetFluxParameters_256G.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_FluxParam256G_Emissivity
            // 
            this.numericUpDown_FluxParam256G_Emissivity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256G_Emissivity.DecimalPlaces = 2;
            this.numericUpDown_FluxParam256G_Emissivity.Enabled = false;
            this.numericUpDown_FluxParam256G_Emissivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256G_Emissivity.Location = new System.Drawing.Point(233, 3);
            this.numericUpDown_FluxParam256G_Emissivity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256G_Emissivity.Name = "numericUpDown_FluxParam256G_Emissivity";
            this.numericUpDown_FluxParam256G_Emissivity.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256G_Emissivity.TabIndex = 12;
            this.numericUpDown_FluxParam256G_Emissivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256G_Emissivity.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256G_Emissivity.Value = new decimal(new int[] {
            98,
            0,
            0,
            131072});
            // 
            // label_FluxParam256G_AtmosphericTransmittanceTitle
            // 
            this.label_FluxParam256G_AtmosphericTransmittanceTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256G_AtmosphericTransmittanceTitle.AutoSize = true;
            this.label_FluxParam256G_AtmosphericTransmittanceTitle.Location = new System.Drawing.Point(25, 26);
            this.label_FluxParam256G_AtmosphericTransmittanceTitle.Name = "label_FluxParam256G_AtmosphericTransmittanceTitle";
            this.label_FluxParam256G_AtmosphericTransmittanceTitle.Size = new System.Drawing.Size(163, 26);
            this.label_FluxParam256G_AtmosphericTransmittanceTitle.TabIndex = 10;
            this.label_FluxParam256G_AtmosphericTransmittanceTitle.Text = "Transmittance (Not Support) :";
            this.label_FluxParam256G_AtmosphericTransmittanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_FluxParam256G_AtmosphericTransmittance
            // 
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.DecimalPlaces = 2;
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.Enabled = false;
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.Location = new System.Drawing.Point(233, 29);
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.Name = "numericUpDown_FluxParam256G_AtmosphericTransmittance";
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.TabIndex = 14;
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256G_AtmosphericTransmittance.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            // 
            // textBox_FluxParam256G_AtmosphericTransmittanceRange
            // 
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.Enabled = false;
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.Location = new System.Drawing.Point(319, 29);
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.Name = "textBox_FluxParam256G_AtmosphericTransmittanceRange";
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.ReadOnly = true;
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.TabIndex = 9;
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.Text = "0.00 ~ 1.00";
            this.textBox_FluxParam256G_AtmosphericTransmittanceRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_FluxParam256G_AtmosphericTemperatureTitle
            // 
            this.label_FluxParam256G_AtmosphericTemperatureTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256G_AtmosphericTemperatureTitle.AutoSize = true;
            this.label_FluxParam256G_AtmosphericTemperatureTitle.Location = new System.Drawing.Point(38, 52);
            this.label_FluxParam256G_AtmosphericTemperatureTitle.Name = "label_FluxParam256G_AtmosphericTemperatureTitle";
            this.label_FluxParam256G_AtmosphericTemperatureTitle.Size = new System.Drawing.Size(150, 26);
            this.label_FluxParam256G_AtmosphericTemperatureTitle.TabIndex = 11;
            this.label_FluxParam256G_AtmosphericTemperatureTitle.Text = "Atmospheric Temperature :";
            this.label_FluxParam256G_AtmosphericTemperatureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_FluxParam256G_AtmosphericTemperature
            // 
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.DecimalPlaces = 1;
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Enabled = false;
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Location = new System.Drawing.Point(233, 55);
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Name = "numericUpDown_FluxParam256G_AtmosphericTemperature";
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.TabIndex = 15;
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256G_AtmosphericTemperature.Value = new decimal(new int[] {
            230,
            0,
            0,
            65536});
            // 
            // textBox_FluxParam256G_AtmosphericTemperatureRange
            // 
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.Enabled = false;
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.Location = new System.Drawing.Point(319, 55);
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.Name = "textBox_FluxParam256G_AtmosphericTemperatureRange";
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.ReadOnly = true;
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.TabIndex = 9;
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.Text = "-100 ~ 1000";
            this.textBox_FluxParam256G_AtmosphericTemperatureRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_FluxParam256G_AtmosphericTemperatureUnit
            // 
            this.label_FluxParam256G_AtmosphericTemperatureUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam256G_AtmosphericTemperatureUnit.AutoSize = true;
            this.label_FluxParam256G_AtmosphericTemperatureUnit.Location = new System.Drawing.Point(296, 57);
            this.label_FluxParam256G_AtmosphericTemperatureUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam256G_AtmosphericTemperatureUnit.Name = "label_FluxParam256G_AtmosphericTemperatureUnit";
            this.label_FluxParam256G_AtmosphericTemperatureUnit.Size = new System.Drawing.Size(19, 15);
            this.label_FluxParam256G_AtmosphericTemperatureUnit.TabIndex = 22;
            this.label_FluxParam256G_AtmosphericTemperatureUnit.Text = "℃";
            // 
            // label_FluxParam256G_AmbientReflectionTemperatureTitle
            // 
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle.AutoSize = true;
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle.Location = new System.Drawing.Point(4, 78);
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle.Name = "label_FluxParam256G_AmbientReflectionTemperatureTitle";
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle.Size = new System.Drawing.Size(184, 26);
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle.TabIndex = 11;
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle.Text = "Ambient Reflection Temperature :";
            this.label_FluxParam256G_AmbientReflectionTemperatureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_FluxParam256G_AmbientReflectionTemperature
            // 
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.DecimalPlaces = 1;
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Enabled = false;
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Location = new System.Drawing.Point(233, 81);
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Name = "numericUpDown_FluxParam256G_AmbientReflectionTemperature";
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.TabIndex = 16;
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256G_AmbientReflectionTemperature.Value = new decimal(new int[] {
            230,
            0,
            0,
            65536});
            // 
            // label_FluxParam256G_AmbientReflectionTemperatureUnit
            // 
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit.AutoSize = true;
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit.Location = new System.Drawing.Point(296, 83);
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit.Name = "label_FluxParam256G_AmbientReflectionTemperatureUnit";
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit.Size = new System.Drawing.Size(19, 15);
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit.TabIndex = 24;
            this.label_FluxParam256G_AmbientReflectionTemperatureUnit.Text = "℃";
            // 
            // textBox_FluxParam256G_AmbientReflectionTemperatureRange
            // 
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.Enabled = false;
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.Location = new System.Drawing.Point(319, 81);
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.Name = "textBox_FluxParam256G_AmbientReflectionTemperatureRange";
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.ReadOnly = true;
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.TabIndex = 9;
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.Text = "-100 ~ 1000";
            this.textBox_FluxParam256G_AmbientReflectionTemperatureRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_FluxParam256G_Distance
            // 
            this.numericUpDown_FluxParam256G_Distance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256G_Distance.DecimalPlaces = 1;
            this.numericUpDown_FluxParam256G_Distance.Enabled = false;
            this.numericUpDown_FluxParam256G_Distance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam256G_Distance.Location = new System.Drawing.Point(233, 107);
            this.numericUpDown_FluxParam256G_Distance.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256G_Distance.Name = "numericUpDown_FluxParam256G_Distance";
            this.numericUpDown_FluxParam256G_Distance.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256G_Distance.TabIndex = 26;
            this.numericUpDown_FluxParam256G_Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256G_Distance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256G_Distance.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // label_FluxParam256G_DistanceUnit
            // 
            this.label_FluxParam256G_DistanceUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam256G_DistanceUnit.AutoSize = true;
            this.label_FluxParam256G_DistanceUnit.Location = new System.Drawing.Point(297, 109);
            this.label_FluxParam256G_DistanceUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam256G_DistanceUnit.Name = "label_FluxParam256G_DistanceUnit";
            this.label_FluxParam256G_DistanceUnit.Size = new System.Drawing.Size(18, 15);
            this.label_FluxParam256G_DistanceUnit.TabIndex = 27;
            this.label_FluxParam256G_DistanceUnit.Text = "m";
            // 
            // textBox_FluxParam256G_DistanceRange
            // 
            this.textBox_FluxParam256G_DistanceRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256G_DistanceRange.Enabled = false;
            this.textBox_FluxParam256G_DistanceRange.Location = new System.Drawing.Point(319, 107);
            this.textBox_FluxParam256G_DistanceRange.Name = "textBox_FluxParam256G_DistanceRange";
            this.textBox_FluxParam256G_DistanceRange.ReadOnly = true;
            this.textBox_FluxParam256G_DistanceRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256G_DistanceRange.TabIndex = 28;
            this.textBox_FluxParam256G_DistanceRange.Text = "0 ~ 30";
            this.textBox_FluxParam256G_DistanceRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox_FFCParameters_256G
            // 
            this.groupBox_FFCParameters_256G.Controls.Add(this.tableLayoutPanel_FFCParam256G);
            this.groupBox_FFCParameters_256G.Location = new System.Drawing.Point(11, 161);
            this.groupBox_FFCParameters_256G.Name = "groupBox_FFCParameters_256G";
            this.groupBox_FFCParameters_256G.Size = new System.Drawing.Size(467, 54);
            this.groupBox_FFCParameters_256G.TabIndex = 17;
            this.groupBox_FFCParameters_256G.TabStop = false;
            this.groupBox_FFCParameters_256G.Text = "FFC Parameters";
            // 
            // tableLayoutPanel_FFCParam256G
            // 
            this.tableLayoutPanel_FFCParam256G.ColumnCount = 6;
            this.tableLayoutPanel_FFCParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel_FFCParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel_FFCParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel_FFCParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FFCParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_FFCParam256G.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_FFCParam256G.Controls.Add(this.label_FFCParam256G_MaxIntervalTitle, 0, 0);
            this.tableLayoutPanel_FFCParam256G.Controls.Add(this.textBox_FFCParam256G_MaxIntervalRange, 4, 0);
            this.tableLayoutPanel_FFCParam256G.Controls.Add(this.button_GetFFCParameters_256G, 1, 0);
            this.tableLayoutPanel_FFCParam256G.Controls.Add(this.button_SetFFCParameters_256G, 5, 0);
            this.tableLayoutPanel_FFCParam256G.Controls.Add(this.numericUpDown_FFCParam256G_MaxInterval, 2, 0);
            this.tableLayoutPanel_FFCParam256G.Controls.Add(this.label_FFCParam256G_MaxIntervalUnit, 3, 0);
            this.tableLayoutPanel_FFCParam256G.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel_FFCParam256G.Name = "tableLayoutPanel_FFCParam256G";
            this.tableLayoutPanel_FFCParam256G.RowCount = 1;
            this.tableLayoutPanel_FFCParam256G.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel_FFCParam256G.Size = new System.Drawing.Size(455, 30);
            this.tableLayoutPanel_FFCParam256G.TabIndex = 10;
            // 
            // label_FFCParam256G_MaxIntervalTitle
            // 
            this.label_FFCParam256G_MaxIntervalTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FFCParam256G_MaxIntervalTitle.AutoSize = true;
            this.label_FFCParam256G_MaxIntervalTitle.Location = new System.Drawing.Point(78, 0);
            this.label_FFCParam256G_MaxIntervalTitle.Name = "label_FFCParam256G_MaxIntervalTitle";
            this.label_FFCParam256G_MaxIntervalTitle.Size = new System.Drawing.Size(110, 30);
            this.label_FFCParam256G_MaxIntervalTitle.TabIndex = 1;
            this.label_FFCParam256G_MaxIntervalTitle.Text = "Maximum Interval :";
            this.label_FFCParam256G_MaxIntervalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FFCParam256G_MaxIntervalRange
            // 
            this.textBox_FFCParam256G_MaxIntervalRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FFCParam256G_MaxIntervalRange.Enabled = false;
            this.textBox_FFCParam256G_MaxIntervalRange.Location = new System.Drawing.Point(319, 3);
            this.textBox_FFCParam256G_MaxIntervalRange.Name = "textBox_FFCParam256G_MaxIntervalRange";
            this.textBox_FFCParam256G_MaxIntervalRange.ReadOnly = true;
            this.textBox_FFCParam256G_MaxIntervalRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FFCParam256G_MaxIntervalRange.TabIndex = 9;
            this.textBox_FFCParam256G_MaxIntervalRange.Text = "0 ~ 100";
            this.textBox_FFCParam256G_MaxIntervalRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_GetFFCParameters_256G
            // 
            this.button_GetFFCParameters_256G.Location = new System.Drawing.Point(194, 3);
            this.button_GetFFCParameters_256G.Name = "button_GetFFCParameters_256G";
            this.button_GetFFCParameters_256G.Size = new System.Drawing.Size(33, 24);
            this.button_GetFFCParameters_256G.TabIndex = 6;
            this.button_GetFFCParameters_256G.Text = "Get";
            this.button_GetFFCParameters_256G.UseVisualStyleBackColor = true;
            this.button_GetFFCParameters_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_SetFFCParameters_256G
            // 
            this.button_SetFFCParameters_256G.Enabled = false;
            this.button_SetFFCParameters_256G.Location = new System.Drawing.Point(419, 3);
            this.button_SetFFCParameters_256G.Name = "button_SetFFCParameters_256G";
            this.button_SetFFCParameters_256G.Size = new System.Drawing.Size(34, 24);
            this.button_SetFFCParameters_256G.TabIndex = 6;
            this.button_SetFFCParameters_256G.Text = "Set";
            this.button_SetFFCParameters_256G.UseVisualStyleBackColor = true;
            this.button_SetFFCParameters_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // numericUpDown_FFCParam256G_MaxInterval
            // 
            this.numericUpDown_FFCParam256G_MaxInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FFCParam256G_MaxInterval.Enabled = false;
            this.numericUpDown_FFCParam256G_MaxInterval.Location = new System.Drawing.Point(233, 3);
            this.numericUpDown_FFCParam256G_MaxInterval.Name = "numericUpDown_FFCParam256G_MaxInterval";
            this.numericUpDown_FFCParam256G_MaxInterval.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FFCParam256G_MaxInterval.TabIndex = 12;
            this.numericUpDown_FFCParam256G_MaxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FFCParam256G_MaxInterval.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FFCParam256G_MaxInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FFCParam256G_MaxInterval.ValueChanged += new System.EventHandler(this.numericUpDown_FFCParam256G_MaxInterval_ValueChanged);
            // 
            // label_FFCParam256G_MaxIntervalUnit
            // 
            this.label_FFCParam256G_MaxIntervalUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FFCParam256G_MaxIntervalUnit.AutoSize = true;
            this.label_FFCParam256G_MaxIntervalUnit.Location = new System.Drawing.Point(297, 7);
            this.label_FFCParam256G_MaxIntervalUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FFCParam256G_MaxIntervalUnit.Name = "label_FFCParam256G_MaxIntervalUnit";
            this.label_FFCParam256G_MaxIntervalUnit.Size = new System.Drawing.Size(18, 15);
            this.label_FFCParam256G_MaxIntervalUnit.TabIndex = 28;
            this.label_FFCParam256G_MaxIntervalUnit.Text = "m";
            // 
            // button_StoreUserSensorConfig_256G
            // 
            this.button_StoreUserSensorConfig_256G.Location = new System.Drawing.Point(489, 189);
            this.button_StoreUserSensorConfig_256G.Name = "button_StoreUserSensorConfig_256G";
            this.button_StoreUserSensorConfig_256G.Size = new System.Drawing.Size(104, 45);
            this.button_StoreUserSensorConfig_256G.TabIndex = 16;
            this.button_StoreUserSensorConfig_256G.Text = "Store Config Permanently";
            this.button_StoreUserSensorConfig_256G.UseVisualStyleBackColor = true;
            this.button_StoreUserSensorConfig_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_RestoreDefaultSensorConfig_256G
            // 
            this.button_RestoreDefaultSensorConfig_256G.Location = new System.Drawing.Point(599, 189);
            this.button_RestoreDefaultSensorConfig_256G.Name = "button_RestoreDefaultSensorConfig_256G";
            this.button_RestoreDefaultSensorConfig_256G.Size = new System.Drawing.Size(114, 45);
            this.button_RestoreDefaultSensorConfig_256G.TabIndex = 12;
            this.button_RestoreDefaultSensorConfig_256G.Text = "Restore to Factory Default";
            this.button_RestoreDefaultSensorConfig_256G.UseVisualStyleBackColor = true;
            this.button_RestoreDefaultSensorConfig_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // groupBox_GainModeState_256G
            // 
            this.groupBox_GainModeState_256G.Controls.Add(this.radioButton_GainModeStateAuto_256G);
            this.groupBox_GainModeState_256G.Controls.Add(this.button_SetGainModeState_256G);
            this.groupBox_GainModeState_256G.Controls.Add(this.button_GetGainModeState_256G);
            this.groupBox_GainModeState_256G.Controls.Add(this.radioButton_GainModeStateLow_256G);
            this.groupBox_GainModeState_256G.Controls.Add(this.radioButton_GainModeStateHigh_256G);
            this.groupBox_GainModeState_256G.Location = new System.Drawing.Point(489, 3);
            this.groupBox_GainModeState_256G.Name = "groupBox_GainModeState_256G";
            this.groupBox_GainModeState_256G.Size = new System.Drawing.Size(224, 97);
            this.groupBox_GainModeState_256G.TabIndex = 15;
            this.groupBox_GainModeState_256G.TabStop = false;
            this.groupBox_GainModeState_256G.Text = "Gain Mode State";
            // 
            // radioButton_GainModeStateAuto_256G
            // 
            this.radioButton_GainModeStateAuto_256G.AutoSize = true;
            this.radioButton_GainModeStateAuto_256G.Location = new System.Drawing.Point(9, 71);
            this.radioButton_GainModeStateAuto_256G.Name = "radioButton_GainModeStateAuto_256G";
            this.radioButton_GainModeStateAuto_256G.Size = new System.Drawing.Size(51, 19);
            this.radioButton_GainModeStateAuto_256G.TabIndex = 20;
            this.radioButton_GainModeStateAuto_256G.TabStop = true;
            this.radioButton_GainModeStateAuto_256G.Text = "Auto";
            this.radioButton_GainModeStateAuto_256G.UseVisualStyleBackColor = true;
            // 
            // button_SetGainModeState_256G
            // 
            this.button_SetGainModeState_256G.Location = new System.Drawing.Point(162, 24);
            this.button_SetGainModeState_256G.Name = "button_SetGainModeState_256G";
            this.button_SetGainModeState_256G.Size = new System.Drawing.Size(49, 66);
            this.button_SetGainModeState_256G.TabIndex = 19;
            this.button_SetGainModeState_256G.Text = "Set";
            this.button_SetGainModeState_256G.UseVisualStyleBackColor = true;
            this.button_SetGainModeState_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_GetGainModeState_256G
            // 
            this.button_GetGainModeState_256G.Location = new System.Drawing.Point(110, 24);
            this.button_GetGainModeState_256G.Name = "button_GetGainModeState_256G";
            this.button_GetGainModeState_256G.Size = new System.Drawing.Size(49, 66);
            this.button_GetGainModeState_256G.TabIndex = 18;
            this.button_GetGainModeState_256G.Text = "Get";
            this.button_GetGainModeState_256G.UseVisualStyleBackColor = true;
            this.button_GetGainModeState_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_GainModeStateLow_256G
            // 
            this.radioButton_GainModeStateLow_256G.AutoSize = true;
            this.radioButton_GainModeStateLow_256G.Location = new System.Drawing.Point(9, 47);
            this.radioButton_GainModeStateLow_256G.Name = "radioButton_GainModeStateLow_256G";
            this.radioButton_GainModeStateLow_256G.Size = new System.Drawing.Size(47, 19);
            this.radioButton_GainModeStateLow_256G.TabIndex = 1;
            this.radioButton_GainModeStateLow_256G.TabStop = true;
            this.radioButton_GainModeStateLow_256G.Text = "Low";
            this.radioButton_GainModeStateLow_256G.UseVisualStyleBackColor = true;
            // 
            // radioButton_GainModeStateHigh_256G
            // 
            this.radioButton_GainModeStateHigh_256G.AutoSize = true;
            this.radioButton_GainModeStateHigh_256G.Location = new System.Drawing.Point(9, 22);
            this.radioButton_GainModeStateHigh_256G.Name = "radioButton_GainModeStateHigh_256G";
            this.radioButton_GainModeStateHigh_256G.Size = new System.Drawing.Size(51, 19);
            this.radioButton_GainModeStateHigh_256G.TabIndex = 0;
            this.radioButton_GainModeStateHigh_256G.TabStop = true;
            this.radioButton_GainModeStateHigh_256G.Text = "High";
            this.radioButton_GainModeStateHigh_256G.UseVisualStyleBackColor = true;
            // 
            // groupBox_FlatFieldCorrection_256G
            // 
            this.groupBox_FlatFieldCorrection_256G.Controls.Add(this.button_SetFlatFieldCorrectionMode_256G);
            this.groupBox_FlatFieldCorrection_256G.Controls.Add(this.button_GetFlatFieldCorrectionMode_256G);
            this.groupBox_FlatFieldCorrection_256G.Controls.Add(this.radioButton_FlatFieldCorrectionManual_256G);
            this.groupBox_FlatFieldCorrection_256G.Controls.Add(this.button_RunFlatFieldCorrection_256G);
            this.groupBox_FlatFieldCorrection_256G.Controls.Add(this.radioButton_FlatFieldCorrectionAutomatic_256G);
            this.groupBox_FlatFieldCorrection_256G.Location = new System.Drawing.Point(489, 104);
            this.groupBox_FlatFieldCorrection_256G.Name = "groupBox_FlatFieldCorrection_256G";
            this.groupBox_FlatFieldCorrection_256G.Size = new System.Drawing.Size(224, 74);
            this.groupBox_FlatFieldCorrection_256G.TabIndex = 14;
            this.groupBox_FlatFieldCorrection_256G.TabStop = false;
            this.groupBox_FlatFieldCorrection_256G.Text = "Flat Field Correction";
            // 
            // button_SetFlatFieldCorrectionMode_256G
            // 
            this.button_SetFlatFieldCorrectionMode_256G.Location = new System.Drawing.Point(162, 19);
            this.button_SetFlatFieldCorrectionMode_256G.Name = "button_SetFlatFieldCorrectionMode_256G";
            this.button_SetFlatFieldCorrectionMode_256G.Size = new System.Drawing.Size(49, 23);
            this.button_SetFlatFieldCorrectionMode_256G.TabIndex = 18;
            this.button_SetFlatFieldCorrectionMode_256G.Text = "Set";
            this.button_SetFlatFieldCorrectionMode_256G.UseVisualStyleBackColor = true;
            this.button_SetFlatFieldCorrectionMode_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_GetFlatFieldCorrectionMode_256G
            // 
            this.button_GetFlatFieldCorrectionMode_256G.Location = new System.Drawing.Point(110, 19);
            this.button_GetFlatFieldCorrectionMode_256G.Name = "button_GetFlatFieldCorrectionMode_256G";
            this.button_GetFlatFieldCorrectionMode_256G.Size = new System.Drawing.Size(50, 23);
            this.button_GetFlatFieldCorrectionMode_256G.TabIndex = 17;
            this.button_GetFlatFieldCorrectionMode_256G.Text = "Get";
            this.button_GetFlatFieldCorrectionMode_256G.UseVisualStyleBackColor = true;
            this.button_GetFlatFieldCorrectionMode_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_FlatFieldCorrectionManual_256G
            // 
            this.radioButton_FlatFieldCorrectionManual_256G.AutoSize = true;
            this.radioButton_FlatFieldCorrectionManual_256G.Location = new System.Drawing.Point(8, 45);
            this.radioButton_FlatFieldCorrectionManual_256G.Name = "radioButton_FlatFieldCorrectionManual_256G";
            this.radioButton_FlatFieldCorrectionManual_256G.Size = new System.Drawing.Size(65, 19);
            this.radioButton_FlatFieldCorrectionManual_256G.TabIndex = 16;
            this.radioButton_FlatFieldCorrectionManual_256G.TabStop = true;
            this.radioButton_FlatFieldCorrectionManual_256G.Text = "Manual";
            this.radioButton_FlatFieldCorrectionManual_256G.UseVisualStyleBackColor = true;
            // 
            // button_RunFlatFieldCorrection_256G
            // 
            this.button_RunFlatFieldCorrection_256G.Location = new System.Drawing.Point(110, 44);
            this.button_RunFlatFieldCorrection_256G.Name = "button_RunFlatFieldCorrection_256G";
            this.button_RunFlatFieldCorrection_256G.Size = new System.Drawing.Size(101, 23);
            this.button_RunFlatFieldCorrection_256G.TabIndex = 14;
            this.button_RunFlatFieldCorrection_256G.Text = "Run";
            this.button_RunFlatFieldCorrection_256G.UseVisualStyleBackColor = true;
            this.button_RunFlatFieldCorrection_256G.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_FlatFieldCorrectionAutomatic_256G
            // 
            this.radioButton_FlatFieldCorrectionAutomatic_256G.AutoSize = true;
            this.radioButton_FlatFieldCorrectionAutomatic_256G.Location = new System.Drawing.Point(8, 22);
            this.radioButton_FlatFieldCorrectionAutomatic_256G.Name = "radioButton_FlatFieldCorrectionAutomatic_256G";
            this.radioButton_FlatFieldCorrectionAutomatic_256G.Size = new System.Drawing.Size(81, 19);
            this.radioButton_FlatFieldCorrectionAutomatic_256G.TabIndex = 15;
            this.radioButton_FlatFieldCorrectionAutomatic_256G.TabStop = true;
            this.radioButton_FlatFieldCorrectionAutomatic_256G.Text = "Automatic";
            this.radioButton_FlatFieldCorrectionAutomatic_256G.UseVisualStyleBackColor = true;
            // 
            // panel_SensorControl_256
            // 
            this.panel_SensorControl_256.Controls.Add(this.groupBox_FFCParameters_256);
            this.panel_SensorControl_256.Controls.Add(this.button_StoreUserSensorConfig_256);
            this.panel_SensorControl_256.Controls.Add(this.button_RestoreDefaultSensorConfig_256);
            this.panel_SensorControl_256.Controls.Add(this.groupBox_FluxParameters_256);
            this.panel_SensorControl_256.Controls.Add(this.groupBox_GainModeState_256);
            this.panel_SensorControl_256.Controls.Add(this.groupBox_FlatFieldCorrection_256);
            this.panel_SensorControl_256.Location = new System.Drawing.Point(0, 0);
            this.panel_SensorControl_256.Name = "panel_SensorControl_256";
            this.panel_SensorControl_256.Size = new System.Drawing.Size(719, 240);
            this.panel_SensorControl_256.TabIndex = 14;
            this.panel_SensorControl_256.Visible = false;
            // 
            // groupBox_FFCParameters_256
            // 
            this.groupBox_FFCParameters_256.Controls.Add(this.tableLayoutPanel_FFCParam256);
            this.groupBox_FFCParameters_256.Location = new System.Drawing.Point(6, 160);
            this.groupBox_FFCParameters_256.Name = "groupBox_FFCParameters_256";
            this.groupBox_FFCParameters_256.Size = new System.Drawing.Size(467, 77);
            this.groupBox_FFCParameters_256.TabIndex = 17;
            this.groupBox_FFCParameters_256.TabStop = false;
            this.groupBox_FFCParameters_256.Text = "FFC Parameters";
            // 
            // tableLayoutPanel_FFCParam256
            // 
            this.tableLayoutPanel_FFCParam256.ColumnCount = 6;
            this.tableLayoutPanel_FFCParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel_FFCParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel_FFCParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel_FFCParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FFCParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_FFCParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_FFCParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.label_FFCParam256_MaxIntervalTitle, 0, 0);
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.textBox_FFCParam256_MaxIntervalRange, 4, 0);
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.button_GetFFCParameters_256, 1, 0);
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.button_SetFFCParameters_256, 5, 0);
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.numericUpDown_FFCParam256_MaxInterval, 2, 0);
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.label_FFCParam256_AutoTriggerThresholdTitle, 0, 1);
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.numericUpDown_FFCParam256_AutoTriggerThreshold, 2, 1);
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.textBox_FFCParam256_AutoTriggerThresholdRange, 4, 1);
            this.tableLayoutPanel_FFCParam256.Controls.Add(this.label_FFCParam256_MaxIntervalUnit, 3, 0);
            this.tableLayoutPanel_FFCParam256.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel_FFCParam256.Name = "tableLayoutPanel_FFCParam256";
            this.tableLayoutPanel_FFCParam256.RowCount = 2;
            this.tableLayoutPanel_FFCParam256.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FFCParam256.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FFCParam256.Size = new System.Drawing.Size(455, 52);
            this.tableLayoutPanel_FFCParam256.TabIndex = 10;
            // 
            // label_FFCParam256_MaxIntervalTitle
            // 
            this.label_FFCParam256_MaxIntervalTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FFCParam256_MaxIntervalTitle.AutoSize = true;
            this.label_FFCParam256_MaxIntervalTitle.Location = new System.Drawing.Point(78, 0);
            this.label_FFCParam256_MaxIntervalTitle.Name = "label_FFCParam256_MaxIntervalTitle";
            this.label_FFCParam256_MaxIntervalTitle.Size = new System.Drawing.Size(110, 26);
            this.label_FFCParam256_MaxIntervalTitle.TabIndex = 1;
            this.label_FFCParam256_MaxIntervalTitle.Text = "Maximum Interval :";
            this.label_FFCParam256_MaxIntervalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FFCParam256_MaxIntervalRange
            // 
            this.textBox_FFCParam256_MaxIntervalRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FFCParam256_MaxIntervalRange.Enabled = false;
            this.textBox_FFCParam256_MaxIntervalRange.Location = new System.Drawing.Point(319, 3);
            this.textBox_FFCParam256_MaxIntervalRange.Name = "textBox_FFCParam256_MaxIntervalRange";
            this.textBox_FFCParam256_MaxIntervalRange.ReadOnly = true;
            this.textBox_FFCParam256_MaxIntervalRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FFCParam256_MaxIntervalRange.TabIndex = 9;
            this.textBox_FFCParam256_MaxIntervalRange.Text = "5 ~ 655";
            this.textBox_FFCParam256_MaxIntervalRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_GetFFCParameters_256
            // 
            this.button_GetFFCParameters_256.Location = new System.Drawing.Point(194, 3);
            this.button_GetFFCParameters_256.Name = "button_GetFFCParameters_256";
            this.tableLayoutPanel_FFCParam256.SetRowSpan(this.button_GetFFCParameters_256, 2);
            this.button_GetFFCParameters_256.Size = new System.Drawing.Size(33, 46);
            this.button_GetFFCParameters_256.TabIndex = 6;
            this.button_GetFFCParameters_256.Text = "Get";
            this.button_GetFFCParameters_256.UseVisualStyleBackColor = true;
            this.button_GetFFCParameters_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_SetFFCParameters_256
            // 
            this.button_SetFFCParameters_256.Enabled = false;
            this.button_SetFFCParameters_256.Location = new System.Drawing.Point(419, 3);
            this.button_SetFFCParameters_256.Name = "button_SetFFCParameters_256";
            this.tableLayoutPanel_FFCParam256.SetRowSpan(this.button_SetFFCParameters_256, 2);
            this.button_SetFFCParameters_256.Size = new System.Drawing.Size(34, 46);
            this.button_SetFFCParameters_256.TabIndex = 6;
            this.button_SetFFCParameters_256.Text = "Set";
            this.button_SetFFCParameters_256.UseVisualStyleBackColor = true;
            this.button_SetFFCParameters_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // numericUpDown_FFCParam256_MaxInterval
            // 
            this.numericUpDown_FFCParam256_MaxInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FFCParam256_MaxInterval.Enabled = false;
            this.numericUpDown_FFCParam256_MaxInterval.Location = new System.Drawing.Point(233, 3);
            this.numericUpDown_FFCParam256_MaxInterval.Maximum = new decimal(new int[] {
            655,
            0,
            0,
            0});
            this.numericUpDown_FFCParam256_MaxInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_FFCParam256_MaxInterval.Name = "numericUpDown_FFCParam256_MaxInterval";
            this.numericUpDown_FFCParam256_MaxInterval.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FFCParam256_MaxInterval.TabIndex = 12;
            this.numericUpDown_FFCParam256_MaxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FFCParam256_MaxInterval.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FFCParam256_MaxInterval.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDown_FFCParam256_MaxInterval.ValueChanged += new System.EventHandler(this.numericUpDown_FFCParam256_MaxInterval_ValueChanged);
            // 
            // label_FFCParam256_AutoTriggerThresholdTitle
            // 
            this.label_FFCParam256_AutoTriggerThresholdTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FFCParam256_AutoTriggerThresholdTitle.AutoSize = true;
            this.label_FFCParam256_AutoTriggerThresholdTitle.Location = new System.Drawing.Point(25, 26);
            this.label_FFCParam256_AutoTriggerThresholdTitle.Name = "label_FFCParam256_AutoTriggerThresholdTitle";
            this.label_FFCParam256_AutoTriggerThresholdTitle.Size = new System.Drawing.Size(163, 26);
            this.label_FFCParam256_AutoTriggerThresholdTitle.TabIndex = 10;
            this.label_FFCParam256_AutoTriggerThresholdTitle.Text = "Automatic Trigger Threshold :";
            this.label_FFCParam256_AutoTriggerThresholdTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_FFCParam256_AutoTriggerThreshold
            // 
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.Enabled = false;
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.Location = new System.Drawing.Point(233, 29);
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.Name = "numericUpDown_FFCParam256_AutoTriggerThreshold";
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.TabIndex = 14;
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_FFCParam256_AutoTriggerThreshold.ValueChanged += new System.EventHandler(this.numericUpDown_FFCParam256_AutoTriggerThreshold_ValueChanged);
            // 
            // textBox_FFCParam256_AutoTriggerThresholdRange
            // 
            this.textBox_FFCParam256_AutoTriggerThresholdRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FFCParam256_AutoTriggerThresholdRange.Enabled = false;
            this.textBox_FFCParam256_AutoTriggerThresholdRange.Location = new System.Drawing.Point(319, 29);
            this.textBox_FFCParam256_AutoTriggerThresholdRange.Name = "textBox_FFCParam256_AutoTriggerThresholdRange";
            this.textBox_FFCParam256_AutoTriggerThresholdRange.ReadOnly = true;
            this.textBox_FFCParam256_AutoTriggerThresholdRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FFCParam256_AutoTriggerThresholdRange.TabIndex = 9;
            this.textBox_FFCParam256_AutoTriggerThresholdRange.Text = "0 ~ 65535";
            this.textBox_FFCParam256_AutoTriggerThresholdRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_FFCParam256_MaxIntervalUnit
            // 
            this.label_FFCParam256_MaxIntervalUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FFCParam256_MaxIntervalUnit.AutoSize = true;
            this.label_FFCParam256_MaxIntervalUnit.Location = new System.Drawing.Point(300, 5);
            this.label_FFCParam256_MaxIntervalUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FFCParam256_MaxIntervalUnit.Name = "label_FFCParam256_MaxIntervalUnit";
            this.label_FFCParam256_MaxIntervalUnit.Size = new System.Drawing.Size(12, 15);
            this.label_FFCParam256_MaxIntervalUnit.TabIndex = 28;
            this.label_FFCParam256_MaxIntervalUnit.Text = "s";
            // 
            // button_StoreUserSensorConfig_256
            // 
            this.button_StoreUserSensorConfig_256.Location = new System.Drawing.Point(489, 189);
            this.button_StoreUserSensorConfig_256.Name = "button_StoreUserSensorConfig_256";
            this.button_StoreUserSensorConfig_256.Size = new System.Drawing.Size(104, 45);
            this.button_StoreUserSensorConfig_256.TabIndex = 16;
            this.button_StoreUserSensorConfig_256.Text = "Store Config Permanently";
            this.button_StoreUserSensorConfig_256.UseVisualStyleBackColor = true;
            this.button_StoreUserSensorConfig_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_RestoreDefaultSensorConfig_256
            // 
            this.button_RestoreDefaultSensorConfig_256.Location = new System.Drawing.Point(599, 189);
            this.button_RestoreDefaultSensorConfig_256.Name = "button_RestoreDefaultSensorConfig_256";
            this.button_RestoreDefaultSensorConfig_256.Size = new System.Drawing.Size(114, 45);
            this.button_RestoreDefaultSensorConfig_256.TabIndex = 12;
            this.button_RestoreDefaultSensorConfig_256.Text = "Restore to Factory Default";
            this.button_RestoreDefaultSensorConfig_256.UseVisualStyleBackColor = true;
            this.button_RestoreDefaultSensorConfig_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // groupBox_FluxParameters_256
            // 
            this.groupBox_FluxParameters_256.Controls.Add(this.tableLayoutPanel_FluxParam256);
            this.groupBox_FluxParameters_256.Location = new System.Drawing.Point(6, 3);
            this.groupBox_FluxParameters_256.Name = "groupBox_FluxParameters_256";
            this.groupBox_FluxParameters_256.Size = new System.Drawing.Size(467, 155);
            this.groupBox_FluxParameters_256.TabIndex = 13;
            this.groupBox_FluxParameters_256.TabStop = false;
            this.groupBox_FluxParameters_256.Text = "Flux Parameters";
            // 
            // tableLayoutPanel_FluxParam256
            // 
            this.tableLayoutPanel_FluxParam256.ColumnCount = 6;
            this.tableLayoutPanel_FluxParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel_FluxParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel_FluxParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel_FluxParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FluxParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_FluxParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_FluxParam256.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.label_FluxParam256_DistanceTitle, 0, 4);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.label_FluxParam256_EmissivityTitle, 0, 0);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.textBox_FluxParam256_EmissivityRange, 4, 0);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.button_GetFluxParameters_256, 1, 0);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.button_SetFluxParameters_256, 5, 0);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.numericUpDown_FluxParam256_Emissivity, 2, 0);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.label_FluxParam256_AtmosphericTransmittanceTitle, 0, 1);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.numericUpDown_FluxParam256_AtmosphericTransmittance, 2, 1);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.textBox_FluxParam256_AtmosphericTransmittanceRange, 4, 1);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.label_FluxParam256_AtmosphericTemperatureTitle, 0, 2);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.numericUpDown_FluxParam256_AtmosphericTemperature, 2, 2);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.textBox_FluxParam256_AtmosphericTemperatureRange, 4, 2);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.label_FluxParam256_AtmosphericTemperatureUnit, 3, 2);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.label_FluxParam256_AmbientReflectionTemperatureTitle, 0, 3);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.numericUpDown_FluxParam256_AmbientReflectionTemperature, 2, 3);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.label_FluxParam256_AmbientReflectionTemperatureUnit, 3, 3);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.textBox_FluxParam256_AmbientReflectionTemperatureRange, 4, 3);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.numericUpDown_FluxParam256_Distance, 2, 4);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.label_FluxParam256_DistanceUnit, 3, 4);
            this.tableLayoutPanel_FluxParam256.Controls.Add(this.textBox_FluxParam256_DistanceRange, 4, 4);
            this.tableLayoutPanel_FluxParam256.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel_FluxParam256.Name = "tableLayoutPanel_FluxParam256";
            this.tableLayoutPanel_FluxParam256.RowCount = 5;
            this.tableLayoutPanel_FluxParam256.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam256.Size = new System.Drawing.Size(455, 130);
            this.tableLayoutPanel_FluxParam256.TabIndex = 10;
            // 
            // label_FluxParam256_DistanceTitle
            // 
            this.label_FluxParam256_DistanceTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256_DistanceTitle.AutoSize = true;
            this.label_FluxParam256_DistanceTitle.Location = new System.Drawing.Point(55, 104);
            this.label_FluxParam256_DistanceTitle.Name = "label_FluxParam256_DistanceTitle";
            this.label_FluxParam256_DistanceTitle.Size = new System.Drawing.Size(133, 26);
            this.label_FluxParam256_DistanceTitle.TabIndex = 25;
            this.label_FluxParam256_DistanceTitle.Text = "Distance (Not support) :";
            this.label_FluxParam256_DistanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_FluxParam256_EmissivityTitle
            // 
            this.label_FluxParam256_EmissivityTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256_EmissivityTitle.AutoSize = true;
            this.label_FluxParam256_EmissivityTitle.Location = new System.Drawing.Point(123, 0);
            this.label_FluxParam256_EmissivityTitle.Name = "label_FluxParam256_EmissivityTitle";
            this.label_FluxParam256_EmissivityTitle.Size = new System.Drawing.Size(65, 26);
            this.label_FluxParam256_EmissivityTitle.TabIndex = 1;
            this.label_FluxParam256_EmissivityTitle.Text = "Emissivity :";
            this.label_FluxParam256_EmissivityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FluxParam256_EmissivityRange
            // 
            this.textBox_FluxParam256_EmissivityRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256_EmissivityRange.Enabled = false;
            this.textBox_FluxParam256_EmissivityRange.Location = new System.Drawing.Point(319, 3);
            this.textBox_FluxParam256_EmissivityRange.Name = "textBox_FluxParam256_EmissivityRange";
            this.textBox_FluxParam256_EmissivityRange.ReadOnly = true;
            this.textBox_FluxParam256_EmissivityRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256_EmissivityRange.TabIndex = 9;
            this.textBox_FluxParam256_EmissivityRange.Text = "0.01 ~ 1.00";
            this.textBox_FluxParam256_EmissivityRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_GetFluxParameters_256
            // 
            this.button_GetFluxParameters_256.Location = new System.Drawing.Point(194, 3);
            this.button_GetFluxParameters_256.Name = "button_GetFluxParameters_256";
            this.tableLayoutPanel_FluxParam256.SetRowSpan(this.button_GetFluxParameters_256, 5);
            this.button_GetFluxParameters_256.Size = new System.Drawing.Size(33, 124);
            this.button_GetFluxParameters_256.TabIndex = 6;
            this.button_GetFluxParameters_256.Text = "Get";
            this.button_GetFluxParameters_256.UseVisualStyleBackColor = true;
            this.button_GetFluxParameters_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_SetFluxParameters_256
            // 
            this.button_SetFluxParameters_256.Enabled = false;
            this.button_SetFluxParameters_256.Location = new System.Drawing.Point(419, 3);
            this.button_SetFluxParameters_256.Name = "button_SetFluxParameters_256";
            this.tableLayoutPanel_FluxParam256.SetRowSpan(this.button_SetFluxParameters_256, 5);
            this.button_SetFluxParameters_256.Size = new System.Drawing.Size(34, 124);
            this.button_SetFluxParameters_256.TabIndex = 6;
            this.button_SetFluxParameters_256.Text = "Set";
            this.button_SetFluxParameters_256.UseVisualStyleBackColor = true;
            this.button_SetFluxParameters_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // numericUpDown_FluxParam256_Emissivity
            // 
            this.numericUpDown_FluxParam256_Emissivity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256_Emissivity.DecimalPlaces = 2;
            this.numericUpDown_FluxParam256_Emissivity.Enabled = false;
            this.numericUpDown_FluxParam256_Emissivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_Emissivity.Location = new System.Drawing.Point(233, 3);
            this.numericUpDown_FluxParam256_Emissivity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256_Emissivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_Emissivity.Name = "numericUpDown_FluxParam256_Emissivity";
            this.numericUpDown_FluxParam256_Emissivity.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256_Emissivity.TabIndex = 12;
            this.numericUpDown_FluxParam256_Emissivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256_Emissivity.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256_Emissivity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256_Emissivity.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam256_Emissivity_ValueChanged);
            // 
            // label_FluxParam256_AtmosphericTransmittanceTitle
            // 
            this.label_FluxParam256_AtmosphericTransmittanceTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256_AtmosphericTransmittanceTitle.AutoSize = true;
            this.label_FluxParam256_AtmosphericTransmittanceTitle.Location = new System.Drawing.Point(30, 26);
            this.label_FluxParam256_AtmosphericTransmittanceTitle.Name = "label_FluxParam256_AtmosphericTransmittanceTitle";
            this.label_FluxParam256_AtmosphericTransmittanceTitle.Size = new System.Drawing.Size(158, 26);
            this.label_FluxParam256_AtmosphericTransmittanceTitle.TabIndex = 10;
            this.label_FluxParam256_AtmosphericTransmittanceTitle.Text = "Atmospheric Transmittance :";
            this.label_FluxParam256_AtmosphericTransmittanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_FluxParam256_AtmosphericTransmittance
            // 
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.DecimalPlaces = 2;
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Enabled = false;
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Location = new System.Drawing.Point(233, 29);
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Name = "numericUpDown_FluxParam256_AtmosphericTransmittance";
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.TabIndex = 14;
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_AtmosphericTransmittance.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam256_AtmosphericTransmittance_ValueChanged);
            // 
            // textBox_FluxParam256_AtmosphericTransmittanceRange
            // 
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.Enabled = false;
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.Location = new System.Drawing.Point(319, 29);
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.Name = "textBox_FluxParam256_AtmosphericTransmittanceRange";
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.ReadOnly = true;
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.TabIndex = 9;
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.Text = "0.01 ~ 1.00";
            this.textBox_FluxParam256_AtmosphericTransmittanceRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_FluxParam256_AtmosphericTemperatureTitle
            // 
            this.label_FluxParam256_AtmosphericTemperatureTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256_AtmosphericTemperatureTitle.AutoSize = true;
            this.label_FluxParam256_AtmosphericTemperatureTitle.Location = new System.Drawing.Point(38, 52);
            this.label_FluxParam256_AtmosphericTemperatureTitle.Name = "label_FluxParam256_AtmosphericTemperatureTitle";
            this.label_FluxParam256_AtmosphericTemperatureTitle.Size = new System.Drawing.Size(150, 26);
            this.label_FluxParam256_AtmosphericTemperatureTitle.TabIndex = 11;
            this.label_FluxParam256_AtmosphericTemperatureTitle.Text = "Atmospheric Temperature :";
            this.label_FluxParam256_AtmosphericTemperatureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_FluxParam256_AtmosphericTemperature
            // 
            this.numericUpDown_FluxParam256_AtmosphericTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256_AtmosphericTemperature.DecimalPlaces = 2;
            this.numericUpDown_FluxParam256_AtmosphericTemperature.Enabled = false;
            this.numericUpDown_FluxParam256_AtmosphericTemperature.Location = new System.Drawing.Point(233, 55);
            this.numericUpDown_FluxParam256_AtmosphericTemperature.Maximum = new decimal(new int[] {
            62685,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_AtmosphericTemperature.Minimum = new decimal(new int[] {
            4315,
            0,
            0,
            -2147352576});
            this.numericUpDown_FluxParam256_AtmosphericTemperature.Name = "numericUpDown_FluxParam256_AtmosphericTemperature";
            this.numericUpDown_FluxParam256_AtmosphericTemperature.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256_AtmosphericTemperature.TabIndex = 15;
            this.numericUpDown_FluxParam256_AtmosphericTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256_AtmosphericTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256_AtmosphericTemperature.Value = new decimal(new int[] {
            2685,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_AtmosphericTemperature.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam256_AtmosphericTemperature_ValueChanged);
            // 
            // textBox_FluxParam256_AtmosphericTemperatureRange
            // 
            this.textBox_FluxParam256_AtmosphericTemperatureRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256_AtmosphericTemperatureRange.Enabled = false;
            this.textBox_FluxParam256_AtmosphericTemperatureRange.Location = new System.Drawing.Point(319, 55);
            this.textBox_FluxParam256_AtmosphericTemperatureRange.Name = "textBox_FluxParam256_AtmosphericTemperatureRange";
            this.textBox_FluxParam256_AtmosphericTemperatureRange.ReadOnly = true;
            this.textBox_FluxParam256_AtmosphericTemperatureRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256_AtmosphericTemperatureRange.TabIndex = 9;
            this.textBox_FluxParam256_AtmosphericTemperatureRange.Text = "-43.15 ~ 626.85";
            this.textBox_FluxParam256_AtmosphericTemperatureRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_FluxParam256_AtmosphericTemperatureUnit
            // 
            this.label_FluxParam256_AtmosphericTemperatureUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam256_AtmosphericTemperatureUnit.AutoSize = true;
            this.label_FluxParam256_AtmosphericTemperatureUnit.Location = new System.Drawing.Point(296, 57);
            this.label_FluxParam256_AtmosphericTemperatureUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam256_AtmosphericTemperatureUnit.Name = "label_FluxParam256_AtmosphericTemperatureUnit";
            this.label_FluxParam256_AtmosphericTemperatureUnit.Size = new System.Drawing.Size(19, 15);
            this.label_FluxParam256_AtmosphericTemperatureUnit.TabIndex = 22;
            this.label_FluxParam256_AtmosphericTemperatureUnit.Text = "℃";
            // 
            // label_FluxParam256_AmbientReflectionTemperatureTitle
            // 
            this.label_FluxParam256_AmbientReflectionTemperatureTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam256_AmbientReflectionTemperatureTitle.AutoSize = true;
            this.label_FluxParam256_AmbientReflectionTemperatureTitle.Location = new System.Drawing.Point(4, 78);
            this.label_FluxParam256_AmbientReflectionTemperatureTitle.Name = "label_FluxParam256_AmbientReflectionTemperatureTitle";
            this.label_FluxParam256_AmbientReflectionTemperatureTitle.Size = new System.Drawing.Size(184, 26);
            this.label_FluxParam256_AmbientReflectionTemperatureTitle.TabIndex = 11;
            this.label_FluxParam256_AmbientReflectionTemperatureTitle.Text = "Ambient Reflection Temperature :";
            this.label_FluxParam256_AmbientReflectionTemperatureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_FluxParam256_AmbientReflectionTemperature
            // 
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.DecimalPlaces = 2;
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.Enabled = false;
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.Location = new System.Drawing.Point(233, 81);
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.Maximum = new decimal(new int[] {
            62685,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.Minimum = new decimal(new int[] {
            4315,
            0,
            0,
            -2147352576});
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.Name = "numericUpDown_FluxParam256_AmbientReflectionTemperature";
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.TabIndex = 16;
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.Value = new decimal(new int[] {
            2685,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_AmbientReflectionTemperature.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam256_ReflectionTemperature_ValueChanged);
            // 
            // label_FluxParam256_AmbientReflectionTemperatureUnit
            // 
            this.label_FluxParam256_AmbientReflectionTemperatureUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam256_AmbientReflectionTemperatureUnit.AutoSize = true;
            this.label_FluxParam256_AmbientReflectionTemperatureUnit.Location = new System.Drawing.Point(296, 83);
            this.label_FluxParam256_AmbientReflectionTemperatureUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam256_AmbientReflectionTemperatureUnit.Name = "label_FluxParam256_AmbientReflectionTemperatureUnit";
            this.label_FluxParam256_AmbientReflectionTemperatureUnit.Size = new System.Drawing.Size(19, 15);
            this.label_FluxParam256_AmbientReflectionTemperatureUnit.TabIndex = 24;
            this.label_FluxParam256_AmbientReflectionTemperatureUnit.Text = "℃";
            // 
            // textBox_FluxParam256_AmbientReflectionTemperatureRange
            // 
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.Enabled = false;
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.Location = new System.Drawing.Point(319, 81);
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.Name = "textBox_FluxParam256_AmbientReflectionTemperatureRange";
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.ReadOnly = true;
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.TabIndex = 9;
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.Text = "-43.15 ~ 626.85";
            this.textBox_FluxParam256_AmbientReflectionTemperatureRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_FluxParam256_Distance
            // 
            this.numericUpDown_FluxParam256_Distance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam256_Distance.DecimalPlaces = 2;
            this.numericUpDown_FluxParam256_Distance.Enabled = false;
            this.numericUpDown_FluxParam256_Distance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_Distance.Location = new System.Drawing.Point(233, 107);
            this.numericUpDown_FluxParam256_Distance.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_FluxParam256_Distance.Name = "numericUpDown_FluxParam256_Distance";
            this.numericUpDown_FluxParam256_Distance.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam256_Distance.TabIndex = 26;
            this.numericUpDown_FluxParam256_Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam256_Distance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam256_Distance.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam256_Distance.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam256_Distance_ValueChanged);
            // 
            // label_FluxParam256_DistanceUnit
            // 
            this.label_FluxParam256_DistanceUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam256_DistanceUnit.AutoSize = true;
            this.label_FluxParam256_DistanceUnit.Location = new System.Drawing.Point(297, 109);
            this.label_FluxParam256_DistanceUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam256_DistanceUnit.Name = "label_FluxParam256_DistanceUnit";
            this.label_FluxParam256_DistanceUnit.Size = new System.Drawing.Size(18, 15);
            this.label_FluxParam256_DistanceUnit.TabIndex = 27;
            this.label_FluxParam256_DistanceUnit.Text = "m";
            // 
            // textBox_FluxParam256_DistanceRange
            // 
            this.textBox_FluxParam256_DistanceRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam256_DistanceRange.Enabled = false;
            this.textBox_FluxParam256_DistanceRange.Location = new System.Drawing.Point(319, 107);
            this.textBox_FluxParam256_DistanceRange.Name = "textBox_FluxParam256_DistanceRange";
            this.textBox_FluxParam256_DistanceRange.ReadOnly = true;
            this.textBox_FluxParam256_DistanceRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam256_DistanceRange.TabIndex = 28;
            this.textBox_FluxParam256_DistanceRange.Text = "0.00 ~ 200.00";
            this.textBox_FluxParam256_DistanceRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox_GainModeState_256
            // 
            this.groupBox_GainModeState_256.Controls.Add(this.button_SetGainModeState_256);
            this.groupBox_GainModeState_256.Controls.Add(this.button_GetGainModeState_256);
            this.groupBox_GainModeState_256.Controls.Add(this.radioButton_GainModeStateLow_256);
            this.groupBox_GainModeState_256.Controls.Add(this.radioButton_GainModeStateHigh_256);
            this.groupBox_GainModeState_256.Location = new System.Drawing.Point(489, 3);
            this.groupBox_GainModeState_256.Name = "groupBox_GainModeState_256";
            this.groupBox_GainModeState_256.Size = new System.Drawing.Size(224, 74);
            this.groupBox_GainModeState_256.TabIndex = 15;
            this.groupBox_GainModeState_256.TabStop = false;
            this.groupBox_GainModeState_256.Text = "Gain Mode State";
            // 
            // button_SetGainModeState_256
            // 
            this.button_SetGainModeState_256.Location = new System.Drawing.Point(162, 24);
            this.button_SetGainModeState_256.Name = "button_SetGainModeState_256";
            this.button_SetGainModeState_256.Size = new System.Drawing.Size(49, 42);
            this.button_SetGainModeState_256.TabIndex = 19;
            this.button_SetGainModeState_256.Text = "Set";
            this.button_SetGainModeState_256.UseVisualStyleBackColor = true;
            this.button_SetGainModeState_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_GetGainModeState_256
            // 
            this.button_GetGainModeState_256.Location = new System.Drawing.Point(110, 24);
            this.button_GetGainModeState_256.Name = "button_GetGainModeState_256";
            this.button_GetGainModeState_256.Size = new System.Drawing.Size(49, 42);
            this.button_GetGainModeState_256.TabIndex = 18;
            this.button_GetGainModeState_256.Text = "Get";
            this.button_GetGainModeState_256.UseVisualStyleBackColor = true;
            this.button_GetGainModeState_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_GainModeStateLow_256
            // 
            this.radioButton_GainModeStateLow_256.AutoSize = true;
            this.radioButton_GainModeStateLow_256.Location = new System.Drawing.Point(9, 47);
            this.radioButton_GainModeStateLow_256.Name = "radioButton_GainModeStateLow_256";
            this.radioButton_GainModeStateLow_256.Size = new System.Drawing.Size(47, 19);
            this.radioButton_GainModeStateLow_256.TabIndex = 1;
            this.radioButton_GainModeStateLow_256.TabStop = true;
            this.radioButton_GainModeStateLow_256.Text = "Low";
            this.radioButton_GainModeStateLow_256.UseVisualStyleBackColor = true;
            // 
            // radioButton_GainModeStateHigh_256
            // 
            this.radioButton_GainModeStateHigh_256.AutoSize = true;
            this.radioButton_GainModeStateHigh_256.Location = new System.Drawing.Point(9, 22);
            this.radioButton_GainModeStateHigh_256.Name = "radioButton_GainModeStateHigh_256";
            this.radioButton_GainModeStateHigh_256.Size = new System.Drawing.Size(51, 19);
            this.radioButton_GainModeStateHigh_256.TabIndex = 0;
            this.radioButton_GainModeStateHigh_256.TabStop = true;
            this.radioButton_GainModeStateHigh_256.Text = "High";
            this.radioButton_GainModeStateHigh_256.UseVisualStyleBackColor = true;
            // 
            // groupBox_FlatFieldCorrection_256
            // 
            this.groupBox_FlatFieldCorrection_256.Controls.Add(this.button_SetFlatFieldCorrectionMode_256);
            this.groupBox_FlatFieldCorrection_256.Controls.Add(this.button_GetFlatFieldCorrectionMode_256);
            this.groupBox_FlatFieldCorrection_256.Controls.Add(this.radioButton_FlatFieldCorrectionManual_256);
            this.groupBox_FlatFieldCorrection_256.Controls.Add(this.button_RunFlatFieldCorrection_256);
            this.groupBox_FlatFieldCorrection_256.Controls.Add(this.radioButton_FlatFieldCorrectionAutomatic_256);
            this.groupBox_FlatFieldCorrection_256.Location = new System.Drawing.Point(489, 83);
            this.groupBox_FlatFieldCorrection_256.Name = "groupBox_FlatFieldCorrection_256";
            this.groupBox_FlatFieldCorrection_256.Size = new System.Drawing.Size(224, 74);
            this.groupBox_FlatFieldCorrection_256.TabIndex = 14;
            this.groupBox_FlatFieldCorrection_256.TabStop = false;
            this.groupBox_FlatFieldCorrection_256.Text = "Flat Field Correction";
            // 
            // button_SetFlatFieldCorrectionMode_256
            // 
            this.button_SetFlatFieldCorrectionMode_256.Location = new System.Drawing.Point(162, 19);
            this.button_SetFlatFieldCorrectionMode_256.Name = "button_SetFlatFieldCorrectionMode_256";
            this.button_SetFlatFieldCorrectionMode_256.Size = new System.Drawing.Size(49, 23);
            this.button_SetFlatFieldCorrectionMode_256.TabIndex = 18;
            this.button_SetFlatFieldCorrectionMode_256.Text = "Set";
            this.button_SetFlatFieldCorrectionMode_256.UseVisualStyleBackColor = true;
            this.button_SetFlatFieldCorrectionMode_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_GetFlatFieldCorrectionMode_256
            // 
            this.button_GetFlatFieldCorrectionMode_256.Location = new System.Drawing.Point(110, 19);
            this.button_GetFlatFieldCorrectionMode_256.Name = "button_GetFlatFieldCorrectionMode_256";
            this.button_GetFlatFieldCorrectionMode_256.Size = new System.Drawing.Size(50, 23);
            this.button_GetFlatFieldCorrectionMode_256.TabIndex = 17;
            this.button_GetFlatFieldCorrectionMode_256.Text = "Get";
            this.button_GetFlatFieldCorrectionMode_256.UseVisualStyleBackColor = true;
            this.button_GetFlatFieldCorrectionMode_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_FlatFieldCorrectionManual_256
            // 
            this.radioButton_FlatFieldCorrectionManual_256.AutoSize = true;
            this.radioButton_FlatFieldCorrectionManual_256.Location = new System.Drawing.Point(8, 45);
            this.radioButton_FlatFieldCorrectionManual_256.Name = "radioButton_FlatFieldCorrectionManual_256";
            this.radioButton_FlatFieldCorrectionManual_256.Size = new System.Drawing.Size(65, 19);
            this.radioButton_FlatFieldCorrectionManual_256.TabIndex = 16;
            this.radioButton_FlatFieldCorrectionManual_256.TabStop = true;
            this.radioButton_FlatFieldCorrectionManual_256.Text = "Manual";
            this.radioButton_FlatFieldCorrectionManual_256.UseVisualStyleBackColor = true;
            // 
            // button_RunFlatFieldCorrection_256
            // 
            this.button_RunFlatFieldCorrection_256.Location = new System.Drawing.Point(110, 44);
            this.button_RunFlatFieldCorrection_256.Name = "button_RunFlatFieldCorrection_256";
            this.button_RunFlatFieldCorrection_256.Size = new System.Drawing.Size(101, 23);
            this.button_RunFlatFieldCorrection_256.TabIndex = 14;
            this.button_RunFlatFieldCorrection_256.Text = "Run";
            this.button_RunFlatFieldCorrection_256.UseVisualStyleBackColor = true;
            this.button_RunFlatFieldCorrection_256.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_FlatFieldCorrectionAutomatic_256
            // 
            this.radioButton_FlatFieldCorrectionAutomatic_256.AutoSize = true;
            this.radioButton_FlatFieldCorrectionAutomatic_256.Location = new System.Drawing.Point(8, 22);
            this.radioButton_FlatFieldCorrectionAutomatic_256.Name = "radioButton_FlatFieldCorrectionAutomatic_256";
            this.radioButton_FlatFieldCorrectionAutomatic_256.Size = new System.Drawing.Size(81, 19);
            this.radioButton_FlatFieldCorrectionAutomatic_256.TabIndex = 15;
            this.radioButton_FlatFieldCorrectionAutomatic_256.TabStop = true;
            this.radioButton_FlatFieldCorrectionAutomatic_256.Text = "Automatic";
            this.radioButton_FlatFieldCorrectionAutomatic_256.UseVisualStyleBackColor = true;
            // 
            // panel_SensorControl_160
            // 
            this.panel_SensorControl_160.Controls.Add(this.groupBox_FluxParameters_160);
            this.panel_SensorControl_160.Controls.Add(this.groupBox_GainModeState_160);
            this.panel_SensorControl_160.Controls.Add(this.groupBox_FlatFieldCorrection_160);
            this.panel_SensorControl_160.Controls.Add(this.button_RestoreDefaultFluxParameters_160);
            this.panel_SensorControl_160.Location = new System.Drawing.Point(0, 0);
            this.panel_SensorControl_160.Name = "panel_SensorControl_160";
            this.panel_SensorControl_160.Size = new System.Drawing.Size(719, 244);
            this.panel_SensorControl_160.TabIndex = 15;
            this.panel_SensorControl_160.Visible = false;
            // 
            // groupBox_FluxParameters_160
            // 
            this.groupBox_FluxParameters_160.Controls.Add(this.tableLayoutPanel_FluxParam160);
            this.groupBox_FluxParameters_160.Location = new System.Drawing.Point(6, 3);
            this.groupBox_FluxParameters_160.Name = "groupBox_FluxParameters_160";
            this.groupBox_FluxParameters_160.Size = new System.Drawing.Size(467, 233);
            this.groupBox_FluxParameters_160.TabIndex = 12;
            this.groupBox_FluxParameters_160.TabStop = false;
            this.groupBox_FluxParameters_160.Text = "Flux Parameters";
            // 
            // tableLayoutPanel_FluxParam160
            // 
            this.tableLayoutPanel_FluxParam160.ColumnCount = 6;
            this.tableLayoutPanel_FluxParam160.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel_FluxParam160.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel_FluxParam160.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel_FluxParam160.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FluxParam160.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_FluxParam160.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_FluxParam160.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_WindowReflectedTemperatureUnit, 3, 7);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_AtmosphericTemperatureUnit, 3, 5);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_WindowTemperatureUnit, 3, 3);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_BackgroundTemperatureUnit, 3, 1);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.numericUpDown_FluxParam160_WindowReflectedTemperature, 2, 7);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.numericUpDown_FluxParam160_WindowReflection, 2, 6);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.numericUpDown_FluxParam160_AtmosphericTemperature, 2, 5);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.numericUpDown_FluxParam160_AtmosphericTransmission, 2, 4);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.numericUpDown_FluxParam160_WindowTemperature, 2, 3);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.numericUpDown_FluxParam160_WindowTransmission, 2, 2);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_SceneEmissivityTitle, 0, 0);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.textBox_FluxParam160_SceneEmissivityRange, 4, 0);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.button_GetFluxParameters_160, 1, 0);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.button_SetFluxParameters_160, 5, 0);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_WindowTransmissionTitle, 0, 2);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_WindowTemperatureTitle, 0, 3);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_AtmosphericTransmissionTitle, 0, 4);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_AtmosphericTemperatureTitle, 0, 5);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.textBox_FluxParam160_BackgroundTemperatureRange, 4, 1);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.textBox_FluxParam160_WindowTransmissionRange, 4, 2);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.textBox_FluxParam160_WindowTemperatureRange, 4, 3);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.textBox_FluxParam160_AtmosphericTransmissionRange, 4, 4);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.textBox_FluxParam160_AtmosphericTemperatureRange, 4, 5);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_WindowReflectionTitle, 0, 6);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_WindowReflectedTemperatureTitle, 0, 7);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.textBox_FluxParam160_WindowReflectionRange, 4, 6);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.textBox_FluxParam160_WindowReflectedTemperatureRange, 4, 7);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.numericUpDown_FluxParam160_SceneEmissivity, 2, 0);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.numericUpDown_FluxParam160_BackgroundTemperature, 2, 1);
            this.tableLayoutPanel_FluxParam160.Controls.Add(this.label_FluxParam160_BackgroundTemperatureTitle, 0, 1);
            this.tableLayoutPanel_FluxParam160.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel_FluxParam160.Name = "tableLayoutPanel_FluxParam160";
            this.tableLayoutPanel_FluxParam160.RowCount = 8;
            this.tableLayoutPanel_FluxParam160.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam160.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam160.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam160.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam160.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam160.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam160.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam160.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel_FluxParam160.Size = new System.Drawing.Size(455, 208);
            this.tableLayoutPanel_FluxParam160.TabIndex = 10;
            // 
            // label_FluxParam160_WindowReflectedTemperatureUnit
            // 
            this.label_FluxParam160_WindowReflectedTemperatureUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam160_WindowReflectedTemperatureUnit.AutoSize = true;
            this.label_FluxParam160_WindowReflectedTemperatureUnit.Location = new System.Drawing.Point(296, 187);
            this.label_FluxParam160_WindowReflectedTemperatureUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam160_WindowReflectedTemperatureUnit.Name = "label_FluxParam160_WindowReflectedTemperatureUnit";
            this.label_FluxParam160_WindowReflectedTemperatureUnit.Size = new System.Drawing.Size(19, 15);
            this.label_FluxParam160_WindowReflectedTemperatureUnit.TabIndex = 24;
            this.label_FluxParam160_WindowReflectedTemperatureUnit.Text = "℃";
            // 
            // label_FluxParam160_AtmosphericTemperatureUnit
            // 
            this.label_FluxParam160_AtmosphericTemperatureUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam160_AtmosphericTemperatureUnit.AutoSize = true;
            this.label_FluxParam160_AtmosphericTemperatureUnit.Location = new System.Drawing.Point(296, 135);
            this.label_FluxParam160_AtmosphericTemperatureUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam160_AtmosphericTemperatureUnit.Name = "label_FluxParam160_AtmosphericTemperatureUnit";
            this.label_FluxParam160_AtmosphericTemperatureUnit.Size = new System.Drawing.Size(19, 15);
            this.label_FluxParam160_AtmosphericTemperatureUnit.TabIndex = 22;
            this.label_FluxParam160_AtmosphericTemperatureUnit.Text = "℃";
            // 
            // label_FluxParam160_WindowTemperatureUnit
            // 
            this.label_FluxParam160_WindowTemperatureUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam160_WindowTemperatureUnit.AutoSize = true;
            this.label_FluxParam160_WindowTemperatureUnit.Location = new System.Drawing.Point(296, 83);
            this.label_FluxParam160_WindowTemperatureUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam160_WindowTemperatureUnit.Name = "label_FluxParam160_WindowTemperatureUnit";
            this.label_FluxParam160_WindowTemperatureUnit.Size = new System.Drawing.Size(19, 15);
            this.label_FluxParam160_WindowTemperatureUnit.TabIndex = 20;
            this.label_FluxParam160_WindowTemperatureUnit.Text = "℃";
            // 
            // label_FluxParam160_BackgroundTemperatureUnit
            // 
            this.label_FluxParam160_BackgroundTemperatureUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_FluxParam160_BackgroundTemperatureUnit.AutoSize = true;
            this.label_FluxParam160_BackgroundTemperatureUnit.Location = new System.Drawing.Point(296, 31);
            this.label_FluxParam160_BackgroundTemperatureUnit.Margin = new System.Windows.Forms.Padding(0);
            this.label_FluxParam160_BackgroundTemperatureUnit.Name = "label_FluxParam160_BackgroundTemperatureUnit";
            this.label_FluxParam160_BackgroundTemperatureUnit.Size = new System.Drawing.Size(19, 15);
            this.label_FluxParam160_BackgroundTemperatureUnit.TabIndex = 18;
            this.label_FluxParam160_BackgroundTemperatureUnit.Text = "℃";
            // 
            // numericUpDown_FluxParam160_WindowReflectedTemperature
            // 
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.DecimalPlaces = 2;
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Enabled = false;
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Location = new System.Drawing.Point(233, 185);
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Maximum = new decimal(new int[] {
            3822,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Minimum = new decimal(new int[] {
            27315,
            0,
            0,
            -2147352576});
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Name = "numericUpDown_FluxParam160_WindowReflectedTemperature";
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.TabIndex = 16;
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.Value = new decimal(new int[] {
            220,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam160_WindowReflectedTemperature.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam160_WindowReflectedTemperature_ValueChanged);
            // 
            // numericUpDown_FluxParam160_WindowReflection
            // 
            this.numericUpDown_FluxParam160_WindowReflection.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam160_WindowReflection.DecimalPlaces = 2;
            this.numericUpDown_FluxParam160_WindowReflection.Enabled = false;
            this.numericUpDown_FluxParam160_WindowReflection.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_WindowReflection.Location = new System.Drawing.Point(233, 159);
            this.numericUpDown_FluxParam160_WindowReflection.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_WindowReflection.Name = "numericUpDown_FluxParam160_WindowReflection";
            this.numericUpDown_FluxParam160_WindowReflection.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam160_WindowReflection.TabIndex = 15;
            this.numericUpDown_FluxParam160_WindowReflection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam160_WindowReflection.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam160_WindowReflection.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam160_WindowReflection_ValueChanged);
            // 
            // numericUpDown_FluxParam160_AtmosphericTemperature
            // 
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam160_AtmosphericTemperature.DecimalPlaces = 2;
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Enabled = false;
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Location = new System.Drawing.Point(233, 133);
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Maximum = new decimal(new int[] {
            3822,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Minimum = new decimal(new int[] {
            27315,
            0,
            0,
            -2147352576});
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Name = "numericUpDown_FluxParam160_AtmosphericTemperature";
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam160_AtmosphericTemperature.TabIndex = 15;
            this.numericUpDown_FluxParam160_AtmosphericTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam160_AtmosphericTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam160_AtmosphericTemperature.Value = new decimal(new int[] {
            220,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam160_AtmosphericTemperature.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam160_AtmosphericTemperature_ValueChanged);
            // 
            // numericUpDown_FluxParam160_AtmosphericTransmission
            // 
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam160_AtmosphericTransmission.DecimalPlaces = 2;
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Enabled = false;
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Location = new System.Drawing.Point(233, 107);
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Name = "numericUpDown_FluxParam160_AtmosphericTransmission";
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam160_AtmosphericTransmission.TabIndex = 14;
            this.numericUpDown_FluxParam160_AtmosphericTransmission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam160_AtmosphericTransmission.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam160_AtmosphericTransmission.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_AtmosphericTransmission.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam160_AtmosphericTransmission_ValueChanged);
            // 
            // numericUpDown_FluxParam160_WindowTemperature
            // 
            this.numericUpDown_FluxParam160_WindowTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam160_WindowTemperature.DecimalPlaces = 2;
            this.numericUpDown_FluxParam160_WindowTemperature.Enabled = false;
            this.numericUpDown_FluxParam160_WindowTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_WindowTemperature.Location = new System.Drawing.Point(233, 81);
            this.numericUpDown_FluxParam160_WindowTemperature.Maximum = new decimal(new int[] {
            3822,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam160_WindowTemperature.Minimum = new decimal(new int[] {
            27315,
            0,
            0,
            -2147352576});
            this.numericUpDown_FluxParam160_WindowTemperature.Name = "numericUpDown_FluxParam160_WindowTemperature";
            this.numericUpDown_FluxParam160_WindowTemperature.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam160_WindowTemperature.TabIndex = 14;
            this.numericUpDown_FluxParam160_WindowTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam160_WindowTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam160_WindowTemperature.Value = new decimal(new int[] {
            220,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam160_WindowTemperature.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam160_WindowTemperature_ValueChanged);
            // 
            // numericUpDown_FluxParam160_WindowTransmission
            // 
            this.numericUpDown_FluxParam160_WindowTransmission.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam160_WindowTransmission.DecimalPlaces = 2;
            this.numericUpDown_FluxParam160_WindowTransmission.Enabled = false;
            this.numericUpDown_FluxParam160_WindowTransmission.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_WindowTransmission.Location = new System.Drawing.Point(233, 55);
            this.numericUpDown_FluxParam160_WindowTransmission.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam160_WindowTransmission.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_WindowTransmission.Name = "numericUpDown_FluxParam160_WindowTransmission";
            this.numericUpDown_FluxParam160_WindowTransmission.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam160_WindowTransmission.TabIndex = 13;
            this.numericUpDown_FluxParam160_WindowTransmission.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam160_WindowTransmission.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam160_WindowTransmission.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam160_WindowTransmission.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam160_WindowTransmission_ValueChanged);
            // 
            // label_FluxParam160_SceneEmissivityTitle
            // 
            this.label_FluxParam160_SceneEmissivityTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam160_SceneEmissivityTitle.AutoSize = true;
            this.label_FluxParam160_SceneEmissivityTitle.Location = new System.Drawing.Point(89, 0);
            this.label_FluxParam160_SceneEmissivityTitle.Name = "label_FluxParam160_SceneEmissivityTitle";
            this.label_FluxParam160_SceneEmissivityTitle.Size = new System.Drawing.Size(99, 26);
            this.label_FluxParam160_SceneEmissivityTitle.TabIndex = 1;
            this.label_FluxParam160_SceneEmissivityTitle.Text = "Scene Emissivity :";
            this.label_FluxParam160_SceneEmissivityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FluxParam160_SceneEmissivityRange
            // 
            this.textBox_FluxParam160_SceneEmissivityRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam160_SceneEmissivityRange.Enabled = false;
            this.textBox_FluxParam160_SceneEmissivityRange.Location = new System.Drawing.Point(319, 3);
            this.textBox_FluxParam160_SceneEmissivityRange.Name = "textBox_FluxParam160_SceneEmissivityRange";
            this.textBox_FluxParam160_SceneEmissivityRange.ReadOnly = true;
            this.textBox_FluxParam160_SceneEmissivityRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam160_SceneEmissivityRange.TabIndex = 9;
            this.textBox_FluxParam160_SceneEmissivityRange.Text = "0.01 ~ 1.00";
            this.textBox_FluxParam160_SceneEmissivityRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_GetFluxParameters_160
            // 
            this.button_GetFluxParameters_160.Location = new System.Drawing.Point(194, 3);
            this.button_GetFluxParameters_160.Name = "button_GetFluxParameters_160";
            this.tableLayoutPanel_FluxParam160.SetRowSpan(this.button_GetFluxParameters_160, 8);
            this.button_GetFluxParameters_160.Size = new System.Drawing.Size(33, 202);
            this.button_GetFluxParameters_160.TabIndex = 6;
            this.button_GetFluxParameters_160.Text = "Get";
            this.button_GetFluxParameters_160.UseVisualStyleBackColor = true;
            this.button_GetFluxParameters_160.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_SetFluxParameters_160
            // 
            this.button_SetFluxParameters_160.Enabled = false;
            this.button_SetFluxParameters_160.Location = new System.Drawing.Point(419, 3);
            this.button_SetFluxParameters_160.Name = "button_SetFluxParameters_160";
            this.tableLayoutPanel_FluxParam160.SetRowSpan(this.button_SetFluxParameters_160, 8);
            this.button_SetFluxParameters_160.Size = new System.Drawing.Size(34, 202);
            this.button_SetFluxParameters_160.TabIndex = 6;
            this.button_SetFluxParameters_160.Text = "Set";
            this.button_SetFluxParameters_160.UseVisualStyleBackColor = true;
            this.button_SetFluxParameters_160.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // label_FluxParam160_WindowTransmissionTitle
            // 
            this.label_FluxParam160_WindowTransmissionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam160_WindowTransmissionTitle.AutoSize = true;
            this.label_FluxParam160_WindowTransmissionTitle.Location = new System.Drawing.Point(60, 52);
            this.label_FluxParam160_WindowTransmissionTitle.Name = "label_FluxParam160_WindowTransmissionTitle";
            this.label_FluxParam160_WindowTransmissionTitle.Size = new System.Drawing.Size(128, 26);
            this.label_FluxParam160_WindowTransmissionTitle.TabIndex = 8;
            this.label_FluxParam160_WindowTransmissionTitle.Text = "Window Transmission :";
            this.label_FluxParam160_WindowTransmissionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_FluxParam160_WindowTemperatureTitle
            // 
            this.label_FluxParam160_WindowTemperatureTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam160_WindowTemperatureTitle.AutoSize = true;
            this.label_FluxParam160_WindowTemperatureTitle.Location = new System.Drawing.Point(62, 78);
            this.label_FluxParam160_WindowTemperatureTitle.Name = "label_FluxParam160_WindowTemperatureTitle";
            this.label_FluxParam160_WindowTemperatureTitle.Size = new System.Drawing.Size(126, 26);
            this.label_FluxParam160_WindowTemperatureTitle.TabIndex = 9;
            this.label_FluxParam160_WindowTemperatureTitle.Text = "Window Temperature :";
            this.label_FluxParam160_WindowTemperatureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_FluxParam160_AtmosphericTransmissionTitle
            // 
            this.label_FluxParam160_AtmosphericTransmissionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam160_AtmosphericTransmissionTitle.AutoSize = true;
            this.label_FluxParam160_AtmosphericTransmissionTitle.Location = new System.Drawing.Point(36, 104);
            this.label_FluxParam160_AtmosphericTransmissionTitle.Name = "label_FluxParam160_AtmosphericTransmissionTitle";
            this.label_FluxParam160_AtmosphericTransmissionTitle.Size = new System.Drawing.Size(152, 26);
            this.label_FluxParam160_AtmosphericTransmissionTitle.TabIndex = 10;
            this.label_FluxParam160_AtmosphericTransmissionTitle.Text = "Atmospheric Transmission :";
            this.label_FluxParam160_AtmosphericTransmissionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_FluxParam160_AtmosphericTemperatureTitle
            // 
            this.label_FluxParam160_AtmosphericTemperatureTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam160_AtmosphericTemperatureTitle.AutoSize = true;
            this.label_FluxParam160_AtmosphericTemperatureTitle.Location = new System.Drawing.Point(38, 130);
            this.label_FluxParam160_AtmosphericTemperatureTitle.Name = "label_FluxParam160_AtmosphericTemperatureTitle";
            this.label_FluxParam160_AtmosphericTemperatureTitle.Size = new System.Drawing.Size(150, 26);
            this.label_FluxParam160_AtmosphericTemperatureTitle.TabIndex = 11;
            this.label_FluxParam160_AtmosphericTemperatureTitle.Text = "Atmospheric Temperature :";
            this.label_FluxParam160_AtmosphericTemperatureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FluxParam160_BackgroundTemperatureRange
            // 
            this.textBox_FluxParam160_BackgroundTemperatureRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam160_BackgroundTemperatureRange.Enabled = false;
            this.textBox_FluxParam160_BackgroundTemperatureRange.Location = new System.Drawing.Point(319, 29);
            this.textBox_FluxParam160_BackgroundTemperatureRange.Name = "textBox_FluxParam160_BackgroundTemperatureRange";
            this.textBox_FluxParam160_BackgroundTemperatureRange.ReadOnly = true;
            this.textBox_FluxParam160_BackgroundTemperatureRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam160_BackgroundTemperatureRange.TabIndex = 9;
            this.textBox_FluxParam160_BackgroundTemperatureRange.Text = "-273.15 ~ 382.2";
            this.textBox_FluxParam160_BackgroundTemperatureRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_FluxParam160_WindowTransmissionRange
            // 
            this.textBox_FluxParam160_WindowTransmissionRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam160_WindowTransmissionRange.Enabled = false;
            this.textBox_FluxParam160_WindowTransmissionRange.Location = new System.Drawing.Point(319, 55);
            this.textBox_FluxParam160_WindowTransmissionRange.Name = "textBox_FluxParam160_WindowTransmissionRange";
            this.textBox_FluxParam160_WindowTransmissionRange.ReadOnly = true;
            this.textBox_FluxParam160_WindowTransmissionRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam160_WindowTransmissionRange.TabIndex = 9;
            this.textBox_FluxParam160_WindowTransmissionRange.Text = "0.01 ~ 1.00";
            this.textBox_FluxParam160_WindowTransmissionRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_FluxParam160_WindowTemperatureRange
            // 
            this.textBox_FluxParam160_WindowTemperatureRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam160_WindowTemperatureRange.Enabled = false;
            this.textBox_FluxParam160_WindowTemperatureRange.Location = new System.Drawing.Point(319, 81);
            this.textBox_FluxParam160_WindowTemperatureRange.Name = "textBox_FluxParam160_WindowTemperatureRange";
            this.textBox_FluxParam160_WindowTemperatureRange.ReadOnly = true;
            this.textBox_FluxParam160_WindowTemperatureRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam160_WindowTemperatureRange.TabIndex = 9;
            this.textBox_FluxParam160_WindowTemperatureRange.Text = "-273.15 ~ 382.2";
            this.textBox_FluxParam160_WindowTemperatureRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_FluxParam160_AtmosphericTransmissionRange
            // 
            this.textBox_FluxParam160_AtmosphericTransmissionRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam160_AtmosphericTransmissionRange.Enabled = false;
            this.textBox_FluxParam160_AtmosphericTransmissionRange.Location = new System.Drawing.Point(319, 107);
            this.textBox_FluxParam160_AtmosphericTransmissionRange.Name = "textBox_FluxParam160_AtmosphericTransmissionRange";
            this.textBox_FluxParam160_AtmosphericTransmissionRange.ReadOnly = true;
            this.textBox_FluxParam160_AtmosphericTransmissionRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam160_AtmosphericTransmissionRange.TabIndex = 9;
            this.textBox_FluxParam160_AtmosphericTransmissionRange.Text = "0.01 ~ 1.00";
            this.textBox_FluxParam160_AtmosphericTransmissionRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_FluxParam160_AtmosphericTemperatureRange
            // 
            this.textBox_FluxParam160_AtmosphericTemperatureRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam160_AtmosphericTemperatureRange.Enabled = false;
            this.textBox_FluxParam160_AtmosphericTemperatureRange.Location = new System.Drawing.Point(319, 133);
            this.textBox_FluxParam160_AtmosphericTemperatureRange.Name = "textBox_FluxParam160_AtmosphericTemperatureRange";
            this.textBox_FluxParam160_AtmosphericTemperatureRange.ReadOnly = true;
            this.textBox_FluxParam160_AtmosphericTemperatureRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam160_AtmosphericTemperatureRange.TabIndex = 9;
            this.textBox_FluxParam160_AtmosphericTemperatureRange.Text = "-273.15 ~ 382.2";
            this.textBox_FluxParam160_AtmosphericTemperatureRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_FluxParam160_WindowReflectionTitle
            // 
            this.label_FluxParam160_WindowReflectionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam160_WindowReflectionTitle.AutoSize = true;
            this.label_FluxParam160_WindowReflectionTitle.Location = new System.Drawing.Point(75, 156);
            this.label_FluxParam160_WindowReflectionTitle.Name = "label_FluxParam160_WindowReflectionTitle";
            this.label_FluxParam160_WindowReflectionTitle.Size = new System.Drawing.Size(113, 26);
            this.label_FluxParam160_WindowReflectionTitle.TabIndex = 11;
            this.label_FluxParam160_WindowReflectionTitle.Text = "Window Reflection :";
            this.label_FluxParam160_WindowReflectionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_FluxParam160_WindowReflectedTemperatureTitle
            // 
            this.label_FluxParam160_WindowReflectedTemperatureTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam160_WindowReflectedTemperatureTitle.AutoSize = true;
            this.label_FluxParam160_WindowReflectedTemperatureTitle.Location = new System.Drawing.Point(10, 182);
            this.label_FluxParam160_WindowReflectedTemperatureTitle.Name = "label_FluxParam160_WindowReflectedTemperatureTitle";
            this.label_FluxParam160_WindowReflectedTemperatureTitle.Size = new System.Drawing.Size(178, 26);
            this.label_FluxParam160_WindowReflectedTemperatureTitle.TabIndex = 11;
            this.label_FluxParam160_WindowReflectedTemperatureTitle.Text = "Window Reflected Temperature :";
            this.label_FluxParam160_WindowReflectedTemperatureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_FluxParam160_WindowReflectionRange
            // 
            this.textBox_FluxParam160_WindowReflectionRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam160_WindowReflectionRange.Enabled = false;
            this.textBox_FluxParam160_WindowReflectionRange.Location = new System.Drawing.Point(319, 159);
            this.textBox_FluxParam160_WindowReflectionRange.Name = "textBox_FluxParam160_WindowReflectionRange";
            this.textBox_FluxParam160_WindowReflectionRange.ReadOnly = true;
            this.textBox_FluxParam160_WindowReflectionRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam160_WindowReflectionRange.TabIndex = 9;
            this.textBox_FluxParam160_WindowReflectionRange.Text = "0.00 ~ 0.00";
            this.textBox_FluxParam160_WindowReflectionRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_FluxParam160_WindowReflectedTemperatureRange
            // 
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.Enabled = false;
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.Location = new System.Drawing.Point(319, 185);
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.Name = "textBox_FluxParam160_WindowReflectedTemperatureRange";
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.ReadOnly = true;
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.Size = new System.Drawing.Size(94, 23);
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.TabIndex = 9;
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.Text = "-273.15 ~ 382.2";
            this.textBox_FluxParam160_WindowReflectedTemperatureRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_FluxParam160_SceneEmissivity
            // 
            this.numericUpDown_FluxParam160_SceneEmissivity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam160_SceneEmissivity.DecimalPlaces = 2;
            this.numericUpDown_FluxParam160_SceneEmissivity.Enabled = false;
            this.numericUpDown_FluxParam160_SceneEmissivity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_SceneEmissivity.Location = new System.Drawing.Point(233, 3);
            this.numericUpDown_FluxParam160_SceneEmissivity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam160_SceneEmissivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_SceneEmissivity.Name = "numericUpDown_FluxParam160_SceneEmissivity";
            this.numericUpDown_FluxParam160_SceneEmissivity.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam160_SceneEmissivity.TabIndex = 12;
            this.numericUpDown_FluxParam160_SceneEmissivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam160_SceneEmissivity.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam160_SceneEmissivity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_FluxParam160_SceneEmissivity.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam160_SceneEmissivity_ValueChanged);
            // 
            // numericUpDown_FluxParam160_BackgroundTemperature
            // 
            this.numericUpDown_FluxParam160_BackgroundTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDown_FluxParam160_BackgroundTemperature.DecimalPlaces = 2;
            this.numericUpDown_FluxParam160_BackgroundTemperature.Enabled = false;
            this.numericUpDown_FluxParam160_BackgroundTemperature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_FluxParam160_BackgroundTemperature.Location = new System.Drawing.Point(233, 29);
            this.numericUpDown_FluxParam160_BackgroundTemperature.Maximum = new decimal(new int[] {
            3822,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam160_BackgroundTemperature.Minimum = new decimal(new int[] {
            27315,
            0,
            0,
            -2147352576});
            this.numericUpDown_FluxParam160_BackgroundTemperature.Name = "numericUpDown_FluxParam160_BackgroundTemperature";
            this.numericUpDown_FluxParam160_BackgroundTemperature.Size = new System.Drawing.Size(60, 23);
            this.numericUpDown_FluxParam160_BackgroundTemperature.TabIndex = 13;
            this.numericUpDown_FluxParam160_BackgroundTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_FluxParam160_BackgroundTemperature.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDown_FluxParam160_BackgroundTemperature.Value = new decimal(new int[] {
            220,
            0,
            0,
            65536});
            this.numericUpDown_FluxParam160_BackgroundTemperature.ValueChanged += new System.EventHandler(this.numericUpDown_FluxParam160_BackgroundTemperature_ValueChanged);
            // 
            // label_FluxParam160_BackgroundTemperatureTitle
            // 
            this.label_FluxParam160_BackgroundTemperatureTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FluxParam160_BackgroundTemperatureTitle.AutoSize = true;
            this.label_FluxParam160_BackgroundTemperatureTitle.Location = new System.Drawing.Point(42, 26);
            this.label_FluxParam160_BackgroundTemperatureTitle.Name = "label_FluxParam160_BackgroundTemperatureTitle";
            this.label_FluxParam160_BackgroundTemperatureTitle.Size = new System.Drawing.Size(146, 26);
            this.label_FluxParam160_BackgroundTemperatureTitle.TabIndex = 7;
            this.label_FluxParam160_BackgroundTemperatureTitle.Text = "Background Temperature :";
            this.label_FluxParam160_BackgroundTemperatureTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox_GainModeState_160
            // 
            this.groupBox_GainModeState_160.Controls.Add(this.button_SetGainModeState_160);
            this.groupBox_GainModeState_160.Controls.Add(this.button_GetGainModeState_160);
            this.groupBox_GainModeState_160.Controls.Add(this.radioButton_GainModeStateAuto_160);
            this.groupBox_GainModeState_160.Controls.Add(this.radioButton_GainModeStateLow_160);
            this.groupBox_GainModeState_160.Controls.Add(this.radioButton_GainModeStateHigh_160);
            this.groupBox_GainModeState_160.Location = new System.Drawing.Point(489, 3);
            this.groupBox_GainModeState_160.Name = "groupBox_GainModeState_160";
            this.groupBox_GainModeState_160.Size = new System.Drawing.Size(224, 100);
            this.groupBox_GainModeState_160.TabIndex = 18;
            this.groupBox_GainModeState_160.TabStop = false;
            this.groupBox_GainModeState_160.Text = "Gain Mode State";
            // 
            // button_SetGainModeState_160
            // 
            this.button_SetGainModeState_160.Location = new System.Drawing.Point(162, 24);
            this.button_SetGainModeState_160.Name = "button_SetGainModeState_160";
            this.button_SetGainModeState_160.Size = new System.Drawing.Size(49, 67);
            this.button_SetGainModeState_160.TabIndex = 19;
            this.button_SetGainModeState_160.Text = "Set";
            this.button_SetGainModeState_160.UseVisualStyleBackColor = true;
            this.button_SetGainModeState_160.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_GetGainModeState_160
            // 
            this.button_GetGainModeState_160.Location = new System.Drawing.Point(110, 24);
            this.button_GetGainModeState_160.Name = "button_GetGainModeState_160";
            this.button_GetGainModeState_160.Size = new System.Drawing.Size(49, 67);
            this.button_GetGainModeState_160.TabIndex = 18;
            this.button_GetGainModeState_160.Text = "Get";
            this.button_GetGainModeState_160.UseVisualStyleBackColor = true;
            this.button_GetGainModeState_160.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_GainModeStateAuto_160
            // 
            this.radioButton_GainModeStateAuto_160.AutoSize = true;
            this.radioButton_GainModeStateAuto_160.Location = new System.Drawing.Point(9, 72);
            this.radioButton_GainModeStateAuto_160.Name = "radioButton_GainModeStateAuto_160";
            this.radioButton_GainModeStateAuto_160.Size = new System.Drawing.Size(81, 19);
            this.radioButton_GainModeStateAuto_160.TabIndex = 2;
            this.radioButton_GainModeStateAuto_160.TabStop = true;
            this.radioButton_GainModeStateAuto_160.Text = "Automatic";
            this.radioButton_GainModeStateAuto_160.UseVisualStyleBackColor = true;
            // 
            // radioButton_GainModeStateLow_160
            // 
            this.radioButton_GainModeStateLow_160.AutoSize = true;
            this.radioButton_GainModeStateLow_160.Location = new System.Drawing.Point(9, 47);
            this.radioButton_GainModeStateLow_160.Name = "radioButton_GainModeStateLow_160";
            this.radioButton_GainModeStateLow_160.Size = new System.Drawing.Size(47, 19);
            this.radioButton_GainModeStateLow_160.TabIndex = 1;
            this.radioButton_GainModeStateLow_160.TabStop = true;
            this.radioButton_GainModeStateLow_160.Text = "Low";
            this.radioButton_GainModeStateLow_160.UseVisualStyleBackColor = true;
            // 
            // radioButton_GainModeStateHigh_160
            // 
            this.radioButton_GainModeStateHigh_160.AutoSize = true;
            this.radioButton_GainModeStateHigh_160.Location = new System.Drawing.Point(9, 22);
            this.radioButton_GainModeStateHigh_160.Name = "radioButton_GainModeStateHigh_160";
            this.radioButton_GainModeStateHigh_160.Size = new System.Drawing.Size(51, 19);
            this.radioButton_GainModeStateHigh_160.TabIndex = 0;
            this.radioButton_GainModeStateHigh_160.TabStop = true;
            this.radioButton_GainModeStateHigh_160.Text = "High";
            this.radioButton_GainModeStateHigh_160.UseVisualStyleBackColor = true;
            // 
            // groupBox_FlatFieldCorrection_160
            // 
            this.groupBox_FlatFieldCorrection_160.Controls.Add(this.button_SetFlatFieldCorrectionMode_160);
            this.groupBox_FlatFieldCorrection_160.Controls.Add(this.button_GetFlatFieldCorrectionMode_160);
            this.groupBox_FlatFieldCorrection_160.Controls.Add(this.radioButton_FlatFieldCorrectionManual_160);
            this.groupBox_FlatFieldCorrection_160.Controls.Add(this.button_RunFlatFieldCorrection_160);
            this.groupBox_FlatFieldCorrection_160.Controls.Add(this.radioButton_FlatFieldCorrectionAutomatic_160);
            this.groupBox_FlatFieldCorrection_160.Location = new System.Drawing.Point(489, 109);
            this.groupBox_FlatFieldCorrection_160.Name = "groupBox_FlatFieldCorrection_160";
            this.groupBox_FlatFieldCorrection_160.Size = new System.Drawing.Size(224, 74);
            this.groupBox_FlatFieldCorrection_160.TabIndex = 17;
            this.groupBox_FlatFieldCorrection_160.TabStop = false;
            this.groupBox_FlatFieldCorrection_160.Text = "Flat Field Correction";
            // 
            // button_SetFlatFieldCorrectionMode_160
            // 
            this.button_SetFlatFieldCorrectionMode_160.Location = new System.Drawing.Point(162, 19);
            this.button_SetFlatFieldCorrectionMode_160.Name = "button_SetFlatFieldCorrectionMode_160";
            this.button_SetFlatFieldCorrectionMode_160.Size = new System.Drawing.Size(49, 23);
            this.button_SetFlatFieldCorrectionMode_160.TabIndex = 18;
            this.button_SetFlatFieldCorrectionMode_160.Text = "Set";
            this.button_SetFlatFieldCorrectionMode_160.UseVisualStyleBackColor = true;
            this.button_SetFlatFieldCorrectionMode_160.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // button_GetFlatFieldCorrectionMode_160
            // 
            this.button_GetFlatFieldCorrectionMode_160.Location = new System.Drawing.Point(110, 19);
            this.button_GetFlatFieldCorrectionMode_160.Name = "button_GetFlatFieldCorrectionMode_160";
            this.button_GetFlatFieldCorrectionMode_160.Size = new System.Drawing.Size(50, 23);
            this.button_GetFlatFieldCorrectionMode_160.TabIndex = 17;
            this.button_GetFlatFieldCorrectionMode_160.Text = "Get";
            this.button_GetFlatFieldCorrectionMode_160.UseVisualStyleBackColor = true;
            this.button_GetFlatFieldCorrectionMode_160.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_FlatFieldCorrectionManual_160
            // 
            this.radioButton_FlatFieldCorrectionManual_160.AutoSize = true;
            this.radioButton_FlatFieldCorrectionManual_160.Location = new System.Drawing.Point(8, 45);
            this.radioButton_FlatFieldCorrectionManual_160.Name = "radioButton_FlatFieldCorrectionManual_160";
            this.radioButton_FlatFieldCorrectionManual_160.Size = new System.Drawing.Size(65, 19);
            this.radioButton_FlatFieldCorrectionManual_160.TabIndex = 16;
            this.radioButton_FlatFieldCorrectionManual_160.TabStop = true;
            this.radioButton_FlatFieldCorrectionManual_160.Text = "Manual";
            this.radioButton_FlatFieldCorrectionManual_160.UseVisualStyleBackColor = true;
            // 
            // button_RunFlatFieldCorrection_160
            // 
            this.button_RunFlatFieldCorrection_160.Location = new System.Drawing.Point(110, 44);
            this.button_RunFlatFieldCorrection_160.Name = "button_RunFlatFieldCorrection_160";
            this.button_RunFlatFieldCorrection_160.Size = new System.Drawing.Size(101, 23);
            this.button_RunFlatFieldCorrection_160.TabIndex = 14;
            this.button_RunFlatFieldCorrection_160.Text = "Run";
            this.button_RunFlatFieldCorrection_160.UseVisualStyleBackColor = true;
            this.button_RunFlatFieldCorrection_160.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // radioButton_FlatFieldCorrectionAutomatic_160
            // 
            this.radioButton_FlatFieldCorrectionAutomatic_160.AutoSize = true;
            this.radioButton_FlatFieldCorrectionAutomatic_160.Location = new System.Drawing.Point(8, 22);
            this.radioButton_FlatFieldCorrectionAutomatic_160.Name = "radioButton_FlatFieldCorrectionAutomatic_160";
            this.radioButton_FlatFieldCorrectionAutomatic_160.Size = new System.Drawing.Size(81, 19);
            this.radioButton_FlatFieldCorrectionAutomatic_160.TabIndex = 15;
            this.radioButton_FlatFieldCorrectionAutomatic_160.TabStop = true;
            this.radioButton_FlatFieldCorrectionAutomatic_160.Text = "Automatic";
            this.radioButton_FlatFieldCorrectionAutomatic_160.UseVisualStyleBackColor = true;
            // 
            // button_RestoreDefaultFluxParameters_160
            // 
            this.button_RestoreDefaultFluxParameters_160.Location = new System.Drawing.Point(489, 197);
            this.button_RestoreDefaultFluxParameters_160.Name = "button_RestoreDefaultFluxParameters_160";
            this.button_RestoreDefaultFluxParameters_160.Size = new System.Drawing.Size(224, 30);
            this.button_RestoreDefaultFluxParameters_160.TabIndex = 12;
            this.button_RestoreDefaultFluxParameters_160.Text = "Restore Flux Parameters to Default";
            this.button_RestoreDefaultFluxParameters_160.UseVisualStyleBackColor = true;
            this.button_RestoreDefaultFluxParameters_160.Click += new System.EventHandler(this.button_SensorControl_Click);
            // 
            // tabPage_RoiManager
            // 
            this.tabPage_RoiManager.Controls.Add(this.button_RemoveRoiItem);
            this.tabPage_RoiManager.Controls.Add(this.button_AddRoiItem);
            this.tabPage_RoiManager.Controls.Add(this.rbtn_RoiEllipse);
            this.tabPage_RoiManager.Controls.Add(this.rbtn_RoiRect);
            this.tabPage_RoiManager.Controls.Add(this.rbtn_RoiLine);
            this.tabPage_RoiManager.Controls.Add(this.rbtn_RoiSpot);
            this.tabPage_RoiManager.Controls.Add(this.tableLayoutPanel_RoiEllipse);
            this.tabPage_RoiManager.Controls.Add(this.tableLayoutPanel_RoiRect);
            this.tabPage_RoiManager.Controls.Add(this.tableLayoutPanel_RoiLine);
            this.tabPage_RoiManager.Controls.Add(this.tableLayoutPanel_RoiSpot);
            this.tabPage_RoiManager.Controls.Add(this.label_RoiList);
            this.tabPage_RoiManager.Controls.Add(this.comboBox_RoiList);
            this.tabPage_RoiManager.Location = new System.Drawing.Point(4, 24);
            this.tabPage_RoiManager.Name = "tabPage_RoiManager";
            this.tabPage_RoiManager.Size = new System.Drawing.Size(719, 240);
            this.tabPage_RoiManager.TabIndex = 2;
            this.tabPage_RoiManager.Text = "Region of Interests";
            this.tabPage_RoiManager.UseVisualStyleBackColor = true;
            // 
            // button_RemoveRoiItem
            // 
            this.button_RemoveRoiItem.Location = new System.Drawing.Point(129, 32);
            this.button_RemoveRoiItem.Name = "button_RemoveRoiItem";
            this.button_RemoveRoiItem.Size = new System.Drawing.Size(60, 23);
            this.button_RemoveRoiItem.TabIndex = 4;
            this.button_RemoveRoiItem.Text = "Remove";
            this.button_RemoveRoiItem.UseVisualStyleBackColor = true;
            this.button_RemoveRoiItem.Click += new System.EventHandler(this.button_RemoveRoiItem_Click);
            // 
            // button_AddRoiItem
            // 
            this.button_AddRoiItem.Location = new System.Drawing.Point(392, 79);
            this.button_AddRoiItem.Name = "button_AddRoiItem";
            this.button_AddRoiItem.Size = new System.Drawing.Size(60, 98);
            this.button_AddRoiItem.TabIndex = 4;
            this.button_AddRoiItem.Text = "Add";
            this.button_AddRoiItem.UseVisualStyleBackColor = true;
            this.button_AddRoiItem.Click += new System.EventHandler(this.button_AddRoiItem_Click);
            // 
            // rbtn_RoiEllipse
            // 
            this.rbtn_RoiEllipse.AutoSize = true;
            this.rbtn_RoiEllipse.Location = new System.Drawing.Point(24, 156);
            this.rbtn_RoiEllipse.Name = "rbtn_RoiEllipse";
            this.rbtn_RoiEllipse.Size = new System.Drawing.Size(58, 19);
            this.rbtn_RoiEllipse.TabIndex = 3;
            this.rbtn_RoiEllipse.TabStop = true;
            this.rbtn_RoiEllipse.Text = "Ellipse";
            this.rbtn_RoiEllipse.UseVisualStyleBackColor = true;
            // 
            // rbtn_RoiRect
            // 
            this.rbtn_RoiRect.AutoSize = true;
            this.rbtn_RoiRect.Location = new System.Drawing.Point(24, 131);
            this.rbtn_RoiRect.Name = "rbtn_RoiRect";
            this.rbtn_RoiRect.Size = new System.Drawing.Size(77, 19);
            this.rbtn_RoiRect.TabIndex = 3;
            this.rbtn_RoiRect.TabStop = true;
            this.rbtn_RoiRect.Text = "Rectangle";
            this.rbtn_RoiRect.UseVisualStyleBackColor = true;
            // 
            // rbtn_RoiLine
            // 
            this.rbtn_RoiLine.AutoSize = true;
            this.rbtn_RoiLine.Location = new System.Drawing.Point(24, 106);
            this.rbtn_RoiLine.Name = "rbtn_RoiLine";
            this.rbtn_RoiLine.Size = new System.Drawing.Size(47, 19);
            this.rbtn_RoiLine.TabIndex = 3;
            this.rbtn_RoiLine.TabStop = true;
            this.rbtn_RoiLine.Text = "Line";
            this.rbtn_RoiLine.UseVisualStyleBackColor = true;
            // 
            // rbtn_RoiSpot
            // 
            this.rbtn_RoiSpot.AutoSize = true;
            this.rbtn_RoiSpot.Location = new System.Drawing.Point(24, 81);
            this.rbtn_RoiSpot.Name = "rbtn_RoiSpot";
            this.rbtn_RoiSpot.Size = new System.Drawing.Size(49, 19);
            this.rbtn_RoiSpot.TabIndex = 3;
            this.rbtn_RoiSpot.TabStop = true;
            this.rbtn_RoiSpot.Text = "Spot";
            this.rbtn_RoiSpot.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_RoiEllipse
            // 
            this.tableLayoutPanel_RoiEllipse.ColumnCount = 8;
            this.tableLayoutPanel_RoiEllipse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiEllipse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiEllipse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiEllipse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiEllipse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiEllipse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiEllipse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiEllipse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiEllipse.Controls.Add(this.label_RoiEllipseW, 4, 0);
            this.tableLayoutPanel_RoiEllipse.Controls.Add(this.label_RoiEllipseX, 0, 0);
            this.tableLayoutPanel_RoiEllipse.Controls.Add(this.label_RoiEllipseY, 2, 0);
            this.tableLayoutPanel_RoiEllipse.Controls.Add(this.textBox_RoiEllipseX, 1, 0);
            this.tableLayoutPanel_RoiEllipse.Controls.Add(this.textBox_RoiEllipseW, 5, 0);
            this.tableLayoutPanel_RoiEllipse.Controls.Add(this.textBox_RoiEllipseY, 3, 0);
            this.tableLayoutPanel_RoiEllipse.Controls.Add(this.label_RoiEllipseH, 6, 0);
            this.tableLayoutPanel_RoiEllipse.Controls.Add(this.textBox_RoiEllipseH, 7, 0);
            this.tableLayoutPanel_RoiEllipse.Location = new System.Drawing.Point(129, 154);
            this.tableLayoutPanel_RoiEllipse.Name = "tableLayoutPanel_RoiEllipse";
            this.tableLayoutPanel_RoiEllipse.RowCount = 1;
            this.tableLayoutPanel_RoiEllipse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_RoiEllipse.Size = new System.Drawing.Size(256, 23);
            this.tableLayoutPanel_RoiEllipse.TabIndex = 2;
            // 
            // label_RoiEllipseW
            // 
            this.label_RoiEllipseW.AutoSize = true;
            this.label_RoiEllipseW.Location = new System.Drawing.Point(131, 3);
            this.label_RoiEllipseW.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiEllipseW.Name = "label_RoiEllipseW";
            this.label_RoiEllipseW.Size = new System.Drawing.Size(24, 15);
            this.label_RoiEllipseW.TabIndex = 0;
            this.label_RoiEllipseW.Text = "W :";
            // 
            // label_RoiEllipseX
            // 
            this.label_RoiEllipseX.AutoSize = true;
            this.label_RoiEllipseX.Location = new System.Drawing.Point(3, 3);
            this.label_RoiEllipseX.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiEllipseX.Name = "label_RoiEllipseX";
            this.label_RoiEllipseX.Size = new System.Drawing.Size(20, 15);
            this.label_RoiEllipseX.TabIndex = 0;
            this.label_RoiEllipseX.Text = "X :";
            // 
            // label_RoiEllipseY
            // 
            this.label_RoiEllipseY.AutoSize = true;
            this.label_RoiEllipseY.Location = new System.Drawing.Point(67, 3);
            this.label_RoiEllipseY.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiEllipseY.Name = "label_RoiEllipseY";
            this.label_RoiEllipseY.Size = new System.Drawing.Size(20, 15);
            this.label_RoiEllipseY.TabIndex = 0;
            this.label_RoiEllipseY.Text = "Y :";
            // 
            // textBox_RoiEllipseX
            // 
            this.textBox_RoiEllipseX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiEllipseX.Location = new System.Drawing.Point(32, 0);
            this.textBox_RoiEllipseX.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiEllipseX.Name = "textBox_RoiEllipseX";
            this.textBox_RoiEllipseX.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiEllipseX.TabIndex = 1;
            // 
            // textBox_RoiEllipseW
            // 
            this.textBox_RoiEllipseW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiEllipseW.Location = new System.Drawing.Point(160, 0);
            this.textBox_RoiEllipseW.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiEllipseW.Name = "textBox_RoiEllipseW";
            this.textBox_RoiEllipseW.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiEllipseW.TabIndex = 1;
            // 
            // textBox_RoiEllipseY
            // 
            this.textBox_RoiEllipseY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiEllipseY.Location = new System.Drawing.Point(96, 0);
            this.textBox_RoiEllipseY.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiEllipseY.Name = "textBox_RoiEllipseY";
            this.textBox_RoiEllipseY.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiEllipseY.TabIndex = 1;
            // 
            // label_RoiEllipseH
            // 
            this.label_RoiEllipseH.AutoSize = true;
            this.label_RoiEllipseH.Location = new System.Drawing.Point(195, 3);
            this.label_RoiEllipseH.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiEllipseH.Name = "label_RoiEllipseH";
            this.label_RoiEllipseH.Size = new System.Drawing.Size(22, 15);
            this.label_RoiEllipseH.TabIndex = 0;
            this.label_RoiEllipseH.Text = "H :";
            // 
            // textBox_RoiEllipseH
            // 
            this.textBox_RoiEllipseH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiEllipseH.Location = new System.Drawing.Point(224, 0);
            this.textBox_RoiEllipseH.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiEllipseH.Name = "textBox_RoiEllipseH";
            this.textBox_RoiEllipseH.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiEllipseH.TabIndex = 1;
            // 
            // tableLayoutPanel_RoiRect
            // 
            this.tableLayoutPanel_RoiRect.ColumnCount = 8;
            this.tableLayoutPanel_RoiRect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiRect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiRect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiRect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiRect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiRect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiRect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiRect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiRect.Controls.Add(this.label_RoiRectW, 4, 0);
            this.tableLayoutPanel_RoiRect.Controls.Add(this.label_RoiRectX, 0, 0);
            this.tableLayoutPanel_RoiRect.Controls.Add(this.label_RoiRectY, 2, 0);
            this.tableLayoutPanel_RoiRect.Controls.Add(this.textBox_RoiRectX, 1, 0);
            this.tableLayoutPanel_RoiRect.Controls.Add(this.textBox_RoiRectW, 5, 0);
            this.tableLayoutPanel_RoiRect.Controls.Add(this.textBox_RoiRectY, 3, 0);
            this.tableLayoutPanel_RoiRect.Controls.Add(this.label_RoiRectH, 6, 0);
            this.tableLayoutPanel_RoiRect.Controls.Add(this.textBox_RoiRectH, 7, 0);
            this.tableLayoutPanel_RoiRect.Location = new System.Drawing.Point(129, 129);
            this.tableLayoutPanel_RoiRect.Name = "tableLayoutPanel_RoiRect";
            this.tableLayoutPanel_RoiRect.RowCount = 1;
            this.tableLayoutPanel_RoiRect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_RoiRect.Size = new System.Drawing.Size(256, 23);
            this.tableLayoutPanel_RoiRect.TabIndex = 2;
            // 
            // label_RoiRectW
            // 
            this.label_RoiRectW.AutoSize = true;
            this.label_RoiRectW.Location = new System.Drawing.Point(131, 3);
            this.label_RoiRectW.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiRectW.Name = "label_RoiRectW";
            this.label_RoiRectW.Size = new System.Drawing.Size(24, 15);
            this.label_RoiRectW.TabIndex = 0;
            this.label_RoiRectW.Text = "W :";
            // 
            // label_RoiRectX
            // 
            this.label_RoiRectX.AutoSize = true;
            this.label_RoiRectX.Location = new System.Drawing.Point(3, 3);
            this.label_RoiRectX.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiRectX.Name = "label_RoiRectX";
            this.label_RoiRectX.Size = new System.Drawing.Size(20, 15);
            this.label_RoiRectX.TabIndex = 0;
            this.label_RoiRectX.Text = "X :";
            // 
            // label_RoiRectY
            // 
            this.label_RoiRectY.AutoSize = true;
            this.label_RoiRectY.Location = new System.Drawing.Point(67, 3);
            this.label_RoiRectY.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiRectY.Name = "label_RoiRectY";
            this.label_RoiRectY.Size = new System.Drawing.Size(20, 15);
            this.label_RoiRectY.TabIndex = 0;
            this.label_RoiRectY.Text = "Y :";
            // 
            // textBox_RoiRectX
            // 
            this.textBox_RoiRectX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiRectX.Location = new System.Drawing.Point(32, 0);
            this.textBox_RoiRectX.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiRectX.Name = "textBox_RoiRectX";
            this.textBox_RoiRectX.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiRectX.TabIndex = 1;
            // 
            // textBox_RoiRectW
            // 
            this.textBox_RoiRectW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiRectW.Location = new System.Drawing.Point(160, 0);
            this.textBox_RoiRectW.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiRectW.Name = "textBox_RoiRectW";
            this.textBox_RoiRectW.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiRectW.TabIndex = 1;
            // 
            // textBox_RoiRectY
            // 
            this.textBox_RoiRectY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiRectY.Location = new System.Drawing.Point(96, 0);
            this.textBox_RoiRectY.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiRectY.Name = "textBox_RoiRectY";
            this.textBox_RoiRectY.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiRectY.TabIndex = 1;
            // 
            // label_RoiRectH
            // 
            this.label_RoiRectH.AutoSize = true;
            this.label_RoiRectH.Location = new System.Drawing.Point(195, 3);
            this.label_RoiRectH.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiRectH.Name = "label_RoiRectH";
            this.label_RoiRectH.Size = new System.Drawing.Size(22, 15);
            this.label_RoiRectH.TabIndex = 0;
            this.label_RoiRectH.Text = "H :";
            // 
            // textBox_RoiRectH
            // 
            this.textBox_RoiRectH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiRectH.Location = new System.Drawing.Point(224, 0);
            this.textBox_RoiRectH.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiRectH.Name = "textBox_RoiRectH";
            this.textBox_RoiRectH.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiRectH.TabIndex = 1;
            // 
            // tableLayoutPanel_RoiLine
            // 
            this.tableLayoutPanel_RoiLine.ColumnCount = 8;
            this.tableLayoutPanel_RoiLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiLine.Controls.Add(this.label_RoiLineX2, 4, 0);
            this.tableLayoutPanel_RoiLine.Controls.Add(this.label_RoiLineX1, 0, 0);
            this.tableLayoutPanel_RoiLine.Controls.Add(this.label_RoiLineY1, 2, 0);
            this.tableLayoutPanel_RoiLine.Controls.Add(this.textBox_RoiLineX1, 1, 0);
            this.tableLayoutPanel_RoiLine.Controls.Add(this.textBox_RoiLineX2, 5, 0);
            this.tableLayoutPanel_RoiLine.Controls.Add(this.textBox_RoiLineY1, 3, 0);
            this.tableLayoutPanel_RoiLine.Controls.Add(this.label_RoiLineY2, 6, 0);
            this.tableLayoutPanel_RoiLine.Controls.Add(this.textBox_RoiLineY2, 7, 0);
            this.tableLayoutPanel_RoiLine.Location = new System.Drawing.Point(129, 104);
            this.tableLayoutPanel_RoiLine.Name = "tableLayoutPanel_RoiLine";
            this.tableLayoutPanel_RoiLine.RowCount = 1;
            this.tableLayoutPanel_RoiLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_RoiLine.Size = new System.Drawing.Size(256, 23);
            this.tableLayoutPanel_RoiLine.TabIndex = 2;
            // 
            // label_RoiLineX2
            // 
            this.label_RoiLineX2.AutoSize = true;
            this.label_RoiLineX2.Location = new System.Drawing.Point(131, 3);
            this.label_RoiLineX2.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiLineX2.Name = "label_RoiLineX2";
            this.label_RoiLineX2.Size = new System.Drawing.Size(26, 15);
            this.label_RoiLineX2.TabIndex = 0;
            this.label_RoiLineX2.Text = "X2 :";
            // 
            // label_RoiLineX1
            // 
            this.label_RoiLineX1.AutoSize = true;
            this.label_RoiLineX1.Location = new System.Drawing.Point(3, 3);
            this.label_RoiLineX1.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiLineX1.Name = "label_RoiLineX1";
            this.label_RoiLineX1.Size = new System.Drawing.Size(26, 15);
            this.label_RoiLineX1.TabIndex = 0;
            this.label_RoiLineX1.Text = "X1 :";
            // 
            // label_RoiLineY1
            // 
            this.label_RoiLineY1.AutoSize = true;
            this.label_RoiLineY1.Location = new System.Drawing.Point(67, 3);
            this.label_RoiLineY1.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiLineY1.Name = "label_RoiLineY1";
            this.label_RoiLineY1.Size = new System.Drawing.Size(26, 15);
            this.label_RoiLineY1.TabIndex = 0;
            this.label_RoiLineY1.Text = "Y1 :";
            // 
            // textBox_RoiLineX1
            // 
            this.textBox_RoiLineX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiLineX1.Location = new System.Drawing.Point(32, 0);
            this.textBox_RoiLineX1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiLineX1.Name = "textBox_RoiLineX1";
            this.textBox_RoiLineX1.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiLineX1.TabIndex = 1;
            // 
            // textBox_RoiLineX2
            // 
            this.textBox_RoiLineX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiLineX2.Location = new System.Drawing.Point(160, 0);
            this.textBox_RoiLineX2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiLineX2.Name = "textBox_RoiLineX2";
            this.textBox_RoiLineX2.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiLineX2.TabIndex = 1;
            // 
            // textBox_RoiLineY1
            // 
            this.textBox_RoiLineY1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiLineY1.Location = new System.Drawing.Point(96, 0);
            this.textBox_RoiLineY1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiLineY1.Name = "textBox_RoiLineY1";
            this.textBox_RoiLineY1.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiLineY1.TabIndex = 1;
            // 
            // label_RoiLineY2
            // 
            this.label_RoiLineY2.AutoSize = true;
            this.label_RoiLineY2.Location = new System.Drawing.Point(195, 3);
            this.label_RoiLineY2.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiLineY2.Name = "label_RoiLineY2";
            this.label_RoiLineY2.Size = new System.Drawing.Size(26, 15);
            this.label_RoiLineY2.TabIndex = 0;
            this.label_RoiLineY2.Text = "Y2 :";
            // 
            // textBox_RoiLineY2
            // 
            this.textBox_RoiLineY2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiLineY2.Location = new System.Drawing.Point(224, 0);
            this.textBox_RoiLineY2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiLineY2.Name = "textBox_RoiLineY2";
            this.textBox_RoiLineY2.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiLineY2.TabIndex = 1;
            // 
            // tableLayoutPanel_RoiSpot
            // 
            this.tableLayoutPanel_RoiSpot.ColumnCount = 4;
            this.tableLayoutPanel_RoiSpot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiSpot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiSpot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiSpot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel_RoiSpot.Controls.Add(this.label_RoiSpotX, 0, 0);
            this.tableLayoutPanel_RoiSpot.Controls.Add(this.label_RoiSpotY, 2, 0);
            this.tableLayoutPanel_RoiSpot.Controls.Add(this.textBox_RoiSpotX, 1, 0);
            this.tableLayoutPanel_RoiSpot.Controls.Add(this.textBox_RoiSpotY, 3, 0);
            this.tableLayoutPanel_RoiSpot.Location = new System.Drawing.Point(129, 79);
            this.tableLayoutPanel_RoiSpot.Name = "tableLayoutPanel_RoiSpot";
            this.tableLayoutPanel_RoiSpot.RowCount = 1;
            this.tableLayoutPanel_RoiSpot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_RoiSpot.Size = new System.Drawing.Size(128, 23);
            this.tableLayoutPanel_RoiSpot.TabIndex = 2;
            // 
            // label_RoiSpotX
            // 
            this.label_RoiSpotX.AutoSize = true;
            this.label_RoiSpotX.Location = new System.Drawing.Point(3, 3);
            this.label_RoiSpotX.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiSpotX.Name = "label_RoiSpotX";
            this.label_RoiSpotX.Size = new System.Drawing.Size(20, 15);
            this.label_RoiSpotX.TabIndex = 0;
            this.label_RoiSpotX.Text = "X :";
            // 
            // label_RoiSpotY
            // 
            this.label_RoiSpotY.AutoSize = true;
            this.label_RoiSpotY.Location = new System.Drawing.Point(67, 3);
            this.label_RoiSpotY.Margin = new System.Windows.Forms.Padding(3);
            this.label_RoiSpotY.Name = "label_RoiSpotY";
            this.label_RoiSpotY.Size = new System.Drawing.Size(20, 15);
            this.label_RoiSpotY.TabIndex = 0;
            this.label_RoiSpotY.Text = "Y :";
            // 
            // textBox_RoiSpotX
            // 
            this.textBox_RoiSpotX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiSpotX.Location = new System.Drawing.Point(32, 0);
            this.textBox_RoiSpotX.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiSpotX.Name = "textBox_RoiSpotX";
            this.textBox_RoiSpotX.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiSpotX.TabIndex = 1;
            // 
            // textBox_RoiSpotY
            // 
            this.textBox_RoiSpotY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_RoiSpotY.Location = new System.Drawing.Point(96, 0);
            this.textBox_RoiSpotY.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_RoiSpotY.Name = "textBox_RoiSpotY";
            this.textBox_RoiSpotY.Size = new System.Drawing.Size(32, 23);
            this.textBox_RoiSpotY.TabIndex = 1;
            // 
            // label_RoiList
            // 
            this.label_RoiList.AutoSize = true;
            this.label_RoiList.Location = new System.Drawing.Point(21, 13);
            this.label_RoiList.Name = "label_RoiList";
            this.label_RoiList.Size = new System.Drawing.Size(47, 15);
            this.label_RoiList.TabIndex = 1;
            this.label_RoiList.Text = "ROI List";
            // 
            // comboBox_RoiList
            // 
            this.comboBox_RoiList.FormattingEnabled = true;
            this.comboBox_RoiList.Location = new System.Drawing.Point(24, 32);
            this.comboBox_RoiList.Name = "comboBox_RoiList";
            this.comboBox_RoiList.Size = new System.Drawing.Size(99, 23);
            this.comboBox_RoiList.TabIndex = 0;
            this.comboBox_RoiList.SelectedIndexChanged += new System.EventHandler(this.comboBox_ListROI_SelectedIndexChanged);
            // 
            // panel_Preview
            // 
            this.panel_Preview.Controls.Add(this.tableLayoutPanel_Preview);
            this.panel_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Preview.Location = new System.Drawing.Point(240, 0);
            this.panel_Preview.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Preview.Name = "panel_Preview";
            this.panel_Preview.Size = new System.Drawing.Size(493, 471);
            this.panel_Preview.TabIndex = 6;
            // 
            // tableLayoutPanel_Preview
            // 
            this.tableLayoutPanel_Preview.ColumnCount = 1;
            this.tableLayoutPanel_Preview.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Preview.Controls.Add(this.panel_Temperature, 0, 1);
            this.tableLayoutPanel_Preview.Controls.Add(this.panel_PreviewConfig, 0, 3);
            this.tableLayoutPanel_Preview.Controls.Add(this.panel_VideoPreview, 0, 0);
            this.tableLayoutPanel_Preview.Controls.Add(this.tableLayoutPanel_RoiShape, 0, 2);
            this.tableLayoutPanel_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Preview.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Preview.Name = "tableLayoutPanel_Preview";
            this.tableLayoutPanel_Preview.RowCount = 4;
            this.tableLayoutPanel_Preview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Preview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel_Preview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel_Preview.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Preview.Size = new System.Drawing.Size(493, 471);
            this.tableLayoutPanel_Preview.TabIndex = 11;
            // 
            // panel_Temperature
            // 
            this.panel_Temperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Temperature.BackColor = System.Drawing.Color.White;
            this.panel_Temperature.Controls.Add(this.label_MinimumTemperature);
            this.panel_Temperature.Controls.Add(this.label_AverageTemperature);
            this.panel_Temperature.Controls.Add(this.label_MaximumTemperature);
            this.panel_Temperature.Location = new System.Drawing.Point(1, 373);
            this.panel_Temperature.Margin = new System.Windows.Forms.Padding(1);
            this.panel_Temperature.Name = "panel_Temperature";
            this.panel_Temperature.Size = new System.Drawing.Size(491, 20);
            this.panel_Temperature.TabIndex = 3;
            // 
            // label_MinimumTemperature
            // 
            this.label_MinimumTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_MinimumTemperature.AutoSize = true;
            this.label_MinimumTemperature.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label_MinimumTemperature.Location = new System.Drawing.Point(3, 2);
            this.label_MinimumTemperature.Name = "label_MinimumTemperature";
            this.label_MinimumTemperature.Size = new System.Drawing.Size(57, 15);
            this.label_MinimumTemperature.TabIndex = 1;
            this.label_MinimumTemperature.Text = "MinTemp";
            this.label_MinimumTemperature.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_AverageTemperature
            // 
            this.label_AverageTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label_AverageTemperature.AutoSize = true;
            this.label_AverageTemperature.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_AverageTemperature.Location = new System.Drawing.Point(212, 2);
            this.label_AverageTemperature.Name = "label_AverageTemperature";
            this.label_AverageTemperature.Size = new System.Drawing.Size(57, 15);
            this.label_AverageTemperature.TabIndex = 1;
            this.label_AverageTemperature.Text = "AvgTemp";
            this.label_AverageTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_MaximumTemperature
            // 
            this.label_MaximumTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_MaximumTemperature.AutoSize = true;
            this.label_MaximumTemperature.ForeColor = System.Drawing.Color.OrangeRed;
            this.label_MaximumTemperature.Location = new System.Drawing.Point(422, 2);
            this.label_MaximumTemperature.Name = "label_MaximumTemperature";
            this.label_MaximumTemperature.Size = new System.Drawing.Size(59, 15);
            this.label_MaximumTemperature.TabIndex = 1;
            this.label_MaximumTemperature.Text = "MaxTemp";
            this.label_MaximumTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_PreviewConfig
            // 
            this.panel_PreviewConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_PreviewConfig.BackColor = System.Drawing.Color.White;
            this.panel_PreviewConfig.Controls.Add(this.checkBox_NoiseFiltering);
            this.panel_PreviewConfig.Controls.Add(this.label_ColorMap);
            this.panel_PreviewConfig.Controls.Add(this.comboBox_ColorMap);
            this.panel_PreviewConfig.Controls.Add(this.label_TemperatureUnit);
            this.panel_PreviewConfig.Controls.Add(this.comboBox_TemperatureUnit);
            this.panel_PreviewConfig.Location = new System.Drawing.Point(1, 434);
            this.panel_PreviewConfig.Margin = new System.Windows.Forms.Padding(1);
            this.panel_PreviewConfig.Name = "panel_PreviewConfig";
            this.panel_PreviewConfig.Size = new System.Drawing.Size(491, 34);
            this.panel_PreviewConfig.TabIndex = 2;
            // 
            // checkBox_NoiseFiltering
            // 
            this.checkBox_NoiseFiltering.AutoSize = true;
            this.checkBox_NoiseFiltering.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_NoiseFiltering.Location = new System.Drawing.Point(190, 9);
            this.checkBox_NoiseFiltering.Name = "checkBox_NoiseFiltering";
            this.checkBox_NoiseFiltering.Size = new System.Drawing.Size(102, 19);
            this.checkBox_NoiseFiltering.TabIndex = 5;
            this.checkBox_NoiseFiltering.Text = "Noise Filtering";
            this.checkBox_NoiseFiltering.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_NoiseFiltering.UseVisualStyleBackColor = true;
            this.checkBox_NoiseFiltering.CheckedChanged += new System.EventHandler(this.checkBox_NoiseFiltering_CheckedChanged);
            // 
            // label_ColorMap
            // 
            this.label_ColorMap.AutoSize = true;
            this.label_ColorMap.Location = new System.Drawing.Point(3, 10);
            this.label_ColorMap.Name = "label_ColorMap";
            this.label_ColorMap.Size = new System.Drawing.Size(63, 15);
            this.label_ColorMap.TabIndex = 3;
            this.label_ColorMap.Text = "Color Map";
            // 
            // comboBox_ColorMap
            // 
            this.comboBox_ColorMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ColorMap.Enabled = false;
            this.comboBox_ColorMap.FormattingEnabled = true;
            this.comboBox_ColorMap.Items.AddRange(new object[] {
            "Grayscale",
            "Autumn",
            "Bone",
            "Jet",
            "Winter",
            "Rainbow",
            "Ocean",
            "Summer",
            "Spring",
            "Cool",
            "Hsv",
            "Pink",
            "Hot",
            "Parula",
            "Magma",
            "Inferno",
            "Plasma",
            "Viridis",
            "Cividis",
            "Twilight",
            "TwilightShifted",
            "Turbo",
            "DeepGreen"});
            this.comboBox_ColorMap.Location = new System.Drawing.Point(72, 6);
            this.comboBox_ColorMap.Name = "comboBox_ColorMap";
            this.comboBox_ColorMap.Size = new System.Drawing.Size(97, 23);
            this.comboBox_ColorMap.TabIndex = 2;
            this.comboBox_ColorMap.SelectedIndexChanged += new System.EventHandler(this.comboBox_ColorMap_SelectedIndexChanged);
            // 
            // label_TemperatureUnit
            // 
            this.label_TemperatureUnit.AutoSize = true;
            this.label_TemperatureUnit.Location = new System.Drawing.Point(309, 10);
            this.label_TemperatureUnit.Name = "label_TemperatureUnit";
            this.label_TemperatureUnit.Size = new System.Drawing.Size(73, 15);
            this.label_TemperatureUnit.TabIndex = 1;
            this.label_TemperatureUnit.Text = "Temperature";
            // 
            // comboBox_TemperatureUnit
            // 
            this.comboBox_TemperatureUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TemperatureUnit.Enabled = false;
            this.comboBox_TemperatureUnit.FormattingEnabled = true;
            this.comboBox_TemperatureUnit.Items.AddRange(new object[] {
            "Raw",
            "Celsius(℃)",
            "Fahrenheit(℉)",
            "Kelvin(Κ)"});
            this.comboBox_TemperatureUnit.Location = new System.Drawing.Point(388, 6);
            this.comboBox_TemperatureUnit.Name = "comboBox_TemperatureUnit";
            this.comboBox_TemperatureUnit.Size = new System.Drawing.Size(97, 23);
            this.comboBox_TemperatureUnit.TabIndex = 0;
            this.comboBox_TemperatureUnit.SelectedIndexChanged += new System.EventHandler(this.comboBox_TemperatureUnit_SelectedIndexChanged);
            // 
            // panel_VideoPreview
            // 
            this.panel_VideoPreview.Controls.Add(this.pictureBox_Preview);
            this.panel_VideoPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_VideoPreview.Location = new System.Drawing.Point(0, 0);
            this.panel_VideoPreview.Margin = new System.Windows.Forms.Padding(0);
            this.panel_VideoPreview.Name = "panel_VideoPreview";
            this.panel_VideoPreview.Size = new System.Drawing.Size(493, 371);
            this.panel_VideoPreview.TabIndex = 4;
            this.panel_VideoPreview.SizeChanged += new System.EventHandler(this.panel_VideoPreview_SizeChanged);
            // 
            // pictureBox_Preview
            // 
            this.pictureBox_Preview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox_Preview.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox_Preview.Location = new System.Drawing.Point(7, 5);
            this.pictureBox_Preview.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_Preview.Name = "pictureBox_Preview";
            this.pictureBox_Preview.Size = new System.Drawing.Size(480, 360);
            this.pictureBox_Preview.TabIndex = 0;
            this.pictureBox_Preview.TabStop = false;
            this.pictureBox_Preview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Preview_Paint);
            this.pictureBox_Preview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Preview_MouseDown);
            this.pictureBox_Preview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Preview_MouseMove);
            this.pictureBox_Preview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Preview_MouseUp);
            // 
            // tableLayoutPanel_RoiShape
            // 
            this.tableLayoutPanel_RoiShape.ColumnCount = 2;
            this.tableLayoutPanel_RoiShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_RoiShape.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel_RoiShape.Controls.Add(this.panel_RoiShape, 0, 0);
            this.tableLayoutPanel_RoiShape.Controls.Add(this.button_RemoveAllRoi, 1, 0);
            this.tableLayoutPanel_RoiShape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_RoiShape.Location = new System.Drawing.Point(1, 396);
            this.tableLayoutPanel_RoiShape.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel_RoiShape.Name = "tableLayoutPanel_RoiShape";
            this.tableLayoutPanel_RoiShape.RowCount = 1;
            this.tableLayoutPanel_RoiShape.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_RoiShape.Size = new System.Drawing.Size(491, 34);
            this.tableLayoutPanel_RoiShape.TabIndex = 5;
            // 
            // panel_RoiShape
            // 
            this.panel_RoiShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_RoiShape.BackColor = System.Drawing.Color.White;
            this.panel_RoiShape.Controls.Add(this.radioButton_ShapeEllipse);
            this.panel_RoiShape.Controls.Add(this.radioButton_ShapeRectangle);
            this.panel_RoiShape.Controls.Add(this.radioButton_ShapeLine);
            this.panel_RoiShape.Controls.Add(this.radioButton_ShapeSpot);
            this.panel_RoiShape.Controls.Add(this.radioButton_ShapeCursor);
            this.panel_RoiShape.Location = new System.Drawing.Point(1, 1);
            this.panel_RoiShape.Margin = new System.Windows.Forms.Padding(1);
            this.panel_RoiShape.Name = "panel_RoiShape";
            this.panel_RoiShape.Size = new System.Drawing.Size(409, 32);
            this.panel_RoiShape.TabIndex = 1;
            // 
            // radioButton_ShapeEllipse
            // 
            this.radioButton_ShapeEllipse.Location = new System.Drawing.Point(311, 6);
            this.radioButton_ShapeEllipse.Name = "radioButton_ShapeEllipse";
            this.radioButton_ShapeEllipse.Size = new System.Drawing.Size(73, 19);
            this.radioButton_ShapeEllipse.TabIndex = 0;
            this.radioButton_ShapeEllipse.Text = "Ellipse";
            this.radioButton_ShapeEllipse.UseVisualStyleBackColor = true;
            this.radioButton_ShapeEllipse.Click += new System.EventHandler(this.radioButton_Shape_Selected);
            // 
            // radioButton_ShapeRectangle
            // 
            this.radioButton_ShapeRectangle.Location = new System.Drawing.Point(223, 6);
            this.radioButton_ShapeRectangle.Name = "radioButton_ShapeRectangle";
            this.radioButton_ShapeRectangle.Size = new System.Drawing.Size(82, 19);
            this.radioButton_ShapeRectangle.TabIndex = 0;
            this.radioButton_ShapeRectangle.Text = "Rectangle";
            this.radioButton_ShapeRectangle.UseVisualStyleBackColor = true;
            this.radioButton_ShapeRectangle.Click += new System.EventHandler(this.radioButton_Shape_Selected);
            // 
            // radioButton_ShapeLine
            // 
            this.radioButton_ShapeLine.Location = new System.Drawing.Point(157, 6);
            this.radioButton_ShapeLine.Name = "radioButton_ShapeLine";
            this.radioButton_ShapeLine.Size = new System.Drawing.Size(60, 19);
            this.radioButton_ShapeLine.TabIndex = 0;
            this.radioButton_ShapeLine.Text = "Line";
            this.radioButton_ShapeLine.UseVisualStyleBackColor = true;
            this.radioButton_ShapeLine.Click += new System.EventHandler(this.radioButton_Shape_Selected);
            // 
            // radioButton_ShapeSpot
            // 
            this.radioButton_ShapeSpot.Location = new System.Drawing.Point(91, 6);
            this.radioButton_ShapeSpot.Name = "radioButton_ShapeSpot";
            this.radioButton_ShapeSpot.Size = new System.Drawing.Size(60, 19);
            this.radioButton_ShapeSpot.TabIndex = 0;
            this.radioButton_ShapeSpot.Text = "Spot";
            this.radioButton_ShapeSpot.UseVisualStyleBackColor = true;
            this.radioButton_ShapeSpot.Click += new System.EventHandler(this.radioButton_Shape_Selected);
            // 
            // radioButton_ShapeCursor
            // 
            this.radioButton_ShapeCursor.AutoSize = true;
            this.radioButton_ShapeCursor.Checked = true;
            this.radioButton_ShapeCursor.Location = new System.Drawing.Point(8, 6);
            this.radioButton_ShapeCursor.Name = "radioButton_ShapeCursor";
            this.radioButton_ShapeCursor.Size = new System.Drawing.Size(60, 19);
            this.radioButton_ShapeCursor.TabIndex = 0;
            this.radioButton_ShapeCursor.TabStop = true;
            this.radioButton_ShapeCursor.Text = "Cursor";
            this.radioButton_ShapeCursor.UseVisualStyleBackColor = true;
            this.radioButton_ShapeCursor.Click += new System.EventHandler(this.radioButton_Shape_Selected);
            // 
            // button_RemoveAllRoi
            // 
            this.button_RemoveAllRoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_RemoveAllRoi.Location = new System.Drawing.Point(412, 1);
            this.button_RemoveAllRoi.Margin = new System.Windows.Forms.Padding(1);
            this.button_RemoveAllRoi.Name = "button_RemoveAllRoi";
            this.button_RemoveAllRoi.Size = new System.Drawing.Size(78, 32);
            this.button_RemoveAllRoi.TabIndex = 2;
            this.button_RemoveAllRoi.Text = "Remove All";
            this.button_RemoveAllRoi.UseVisualStyleBackColor = true;
            this.button_RemoveAllRoi.Click += new System.EventHandler(this.button_RemoveAllRoi_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 769);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TmWinDotNet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panel_Camera.ResumeLayout(false);
            this.tabControl_Camera.ResumeLayout(false);
            this.tabPage_RemoteCamera.ResumeLayout(false);
            this.tabPage_RemoteCamera.PerformLayout();
            this.tabPage_LocalCamera.ResumeLayout(false);
            this.tabPage_LocalCamera.PerformLayout();
            this.tabControl_CameraConfig.ResumeLayout(false);
            this.tabPage_Product.ResumeLayout(false);
            this.groupBox_ProductInformation.ResumeLayout(false);
            this.tableLayoutPanel_ProductInfo.ResumeLayout(false);
            this.tableLayoutPanel_ProductInfo.PerformLayout();
            this.groupBox_SensorInformation.ResumeLayout(false);
            this.tableLayoutPanel_SensorInfo.ResumeLayout(false);
            this.tableLayoutPanel_SensorInfo.PerformLayout();
            this.groupBox_SoftwareUpdate.ResumeLayout(false);
            this.groupBox_SoftwareUpdate.PerformLayout();
            this.tableLayoutPanel_BinaryInforation.ResumeLayout(false);
            this.tableLayoutPanel_BinaryInforation.PerformLayout();
            this.tableLayoutPanel_SoftwareUpdateBlank.ResumeLayout(false);
            this.tableLayoutPanel_SoftwareUpdateBlank.PerformLayout();
            this.tabPage_Network.ResumeLayout(false);
            this.groupBox_NetworkConfiguration.ResumeLayout(false);
            this.tableLayoutPanel_NetworkConfig.ResumeLayout(false);
            this.tableLayoutPanel_NetworkConfig.PerformLayout();
            this.tabControl_SensorConfig.ResumeLayout(false);
            this.tabPage_SensorControl.ResumeLayout(false);
            this.panel_SensorControl_256G.ResumeLayout(false);
            this.groupBox_FluxParameters_256G.ResumeLayout(false);
            this.tableLayoutPanel_FluxParam256G.ResumeLayout(false);
            this.tableLayoutPanel_FluxParam256G.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_Emissivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_AtmosphericTransmittance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_AtmosphericTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_AmbientReflectionTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256G_Distance)).EndInit();
            this.groupBox_FFCParameters_256G.ResumeLayout(false);
            this.tableLayoutPanel_FFCParam256G.ResumeLayout(false);
            this.tableLayoutPanel_FFCParam256G.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FFCParam256G_MaxInterval)).EndInit();
            this.groupBox_GainModeState_256G.ResumeLayout(false);
            this.groupBox_GainModeState_256G.PerformLayout();
            this.groupBox_FlatFieldCorrection_256G.ResumeLayout(false);
            this.groupBox_FlatFieldCorrection_256G.PerformLayout();
            this.panel_SensorControl_256.ResumeLayout(false);
            this.groupBox_FFCParameters_256.ResumeLayout(false);
            this.tableLayoutPanel_FFCParam256.ResumeLayout(false);
            this.tableLayoutPanel_FFCParam256.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FFCParam256_MaxInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FFCParam256_AutoTriggerThreshold)).EndInit();
            this.groupBox_FluxParameters_256.ResumeLayout(false);
            this.tableLayoutPanel_FluxParam256.ResumeLayout(false);
            this.tableLayoutPanel_FluxParam256.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_Emissivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_AtmosphericTransmittance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_AtmosphericTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_AmbientReflectionTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam256_Distance)).EndInit();
            this.groupBox_GainModeState_256.ResumeLayout(false);
            this.groupBox_GainModeState_256.PerformLayout();
            this.groupBox_FlatFieldCorrection_256.ResumeLayout(false);
            this.groupBox_FlatFieldCorrection_256.PerformLayout();
            this.panel_SensorControl_160.ResumeLayout(false);
            this.groupBox_FluxParameters_160.ResumeLayout(false);
            this.tableLayoutPanel_FluxParam160.ResumeLayout(false);
            this.tableLayoutPanel_FluxParam160.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_WindowReflectedTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_WindowReflection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_AtmosphericTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_AtmosphericTransmission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_WindowTemperature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_WindowTransmission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_SceneEmissivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_FluxParam160_BackgroundTemperature)).EndInit();
            this.groupBox_GainModeState_160.ResumeLayout(false);
            this.groupBox_GainModeState_160.PerformLayout();
            this.groupBox_FlatFieldCorrection_160.ResumeLayout(false);
            this.groupBox_FlatFieldCorrection_160.PerformLayout();
            this.tabPage_RoiManager.ResumeLayout(false);
            this.tabPage_RoiManager.PerformLayout();
            this.tableLayoutPanel_RoiEllipse.ResumeLayout(false);
            this.tableLayoutPanel_RoiEllipse.PerformLayout();
            this.tableLayoutPanel_RoiRect.ResumeLayout(false);
            this.tableLayoutPanel_RoiRect.PerformLayout();
            this.tableLayoutPanel_RoiLine.ResumeLayout(false);
            this.tableLayoutPanel_RoiLine.PerformLayout();
            this.tableLayoutPanel_RoiSpot.ResumeLayout(false);
            this.tableLayoutPanel_RoiSpot.PerformLayout();
            this.panel_Preview.ResumeLayout(false);
            this.tableLayoutPanel_Preview.ResumeLayout(false);
            this.panel_Temperature.ResumeLayout(false);
            this.panel_Temperature.PerformLayout();
            this.panel_PreviewConfig.ResumeLayout(false);
            this.panel_PreviewConfig.PerformLayout();
            this.panel_VideoPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).EndInit();
            this.tableLayoutPanel_RoiShape.ResumeLayout(false);
            this.panel_RoiShape.ResumeLayout(false);
            this.panel_RoiShape.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.PictureBox pictureBox_Preview;
        private System.Windows.Forms.Panel panel_Camera;
        private System.Windows.Forms.Button button_ConnectLocalCamera;
        private System.Windows.Forms.TextBox textBox_RemoteCameraIPAddress;
        private System.Windows.Forms.Button button_ConnectRemoteCamera;
        private System.Windows.Forms.ListBox listBox_RemoteCameraScanList;
        private System.Windows.Forms.Button button_ScanRemoteCamera;
        private System.Windows.Forms.Label label_RemoteCameraIPAddressTitle;
        private System.Windows.Forms.Button button_GetProductInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_ProductInfo;
        private System.Windows.Forms.Label label_SensorSerialNumberTitle;
        private System.Windows.Forms.Label label_SensorSerialNumber;
        private System.Windows.Forms.Label label_SensorUptimeTitle;
        private System.Windows.Forms.Label label_SensorUptime;
        private System.Windows.Forms.GroupBox groupBox_SoftwareUpdate;
        private System.Windows.Forms.ProgressBar progressBar_SoftwareUpdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_SoftwareUpdateBlank;
        private System.Windows.Forms.Label label_SoftwareUpdateStatus;
        private System.Windows.Forms.Button button_StartSoftwareUpdate;
        private System.Windows.Forms.TabControl tabControl_Camera;
        private System.Windows.Forms.TabPage tabPage_LocalCamera;
        private System.Windows.Forms.TabPage tabPage_RemoteCamera;
        private System.Windows.Forms.TabControl tabControl_CameraConfig;
        private System.Windows.Forms.TabPage tabPage_Product;
        private System.Windows.Forms.TabPage tabPage_Network;
        private System.Windows.Forms.TabControl tabControl_SensorConfig;
        private System.Windows.Forms.TabPage tabPage_SensorControl;
        private System.Windows.Forms.Panel panel_Preview;
        private System.Windows.Forms.Label label_MinimumTemperature;
        private System.Windows.Forms.Label label_AverageTemperature;
        private System.Windows.Forms.Label label_MaximumTemperature;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FluxParam160;
        private System.Windows.Forms.TextBox textBox_FluxParam160_SceneEmissivityRange;
        private System.Windows.Forms.TextBox textBox_FluxParam160_BackgroundTemperatureRange;
        private System.Windows.Forms.TextBox textBox_FluxParam160_WindowTransmissionRange;
        private System.Windows.Forms.TextBox textBox_FluxParam160_WindowTemperatureRange;
        private System.Windows.Forms.TextBox textBox_FluxParam160_AtmosphericTransmissionRange;
        private System.Windows.Forms.TextBox textBox_FluxParam160_AtmosphericTemperatureRange;
        private System.Windows.Forms.Label label_FluxParam160_WindowReflectionTitle;
        private System.Windows.Forms.Label label_FluxParam160_WindowReflectedTemperatureTitle;
        private System.Windows.Forms.TextBox textBox_FluxParam160_WindowReflectionRange;
        private System.Windows.Forms.TextBox textBox_FluxParam160_WindowReflectedTemperatureRange;
        private System.Windows.Forms.Label label_LocalCameraComPort;
        private System.Windows.Forms.Label label_LocalCameraNameTitle;
        private System.Windows.Forms.Label label_BootloaderVersionTitle;
        private System.Windows.Forms.Label label_FirmwareVersionTitle;
        private System.Windows.Forms.Label label_FirmwareVersion;
        private System.Windows.Forms.Label label_BootloaderVersion;
        private System.Windows.Forms.Label label_SensorModelName;
        private System.Windows.Forms.Label label_SensorModelNameTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_NetworkConfig;
        private System.Windows.Forms.Label label_MACAddressTitle;
        private System.Windows.Forms.TextBox textBox_MACAddress;
        private System.Windows.Forms.Button button_GetNetworkConfiguration;
        private System.Windows.Forms.Label label_IPAssignmentTitle;
        private System.Windows.Forms.Button button_SetNetworkConfiguration;
        private System.Windows.Forms.Label label_IPAddressTitle;
        private System.Windows.Forms.Label label_NetmaskTitle;
        private System.Windows.Forms.Label label_GatewayNameTitle;
        private System.Windows.Forms.Label label_MainDNSServerTitle;
        private System.Windows.Forms.TextBox textBox_IPAddress;
        private System.Windows.Forms.TextBox textBox_Netmask;
        private System.Windows.Forms.TextBox textBox_Gateway;
        private System.Windows.Forms.TextBox textBox_MainDNSServer;
        private System.Windows.Forms.ComboBox comboBox_IPAssignment;
        private System.Windows.Forms.Button button_SetDefaultNetworkConfiguration;
        private System.Windows.Forms.Label label_SubDNSServerTitle;
        private System.Windows.Forms.TextBox textBox_SubDNSServer;
        private System.Windows.Forms.TextBox textBox_SoftwareUpdateFilePath;
        private System.Windows.Forms.Button button_SoftwareUpdateFileBrowse;
        private System.Windows.Forms.Button button_SystemReboot;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam160_SceneEmissivity;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam160_BackgroundTemperature;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam160_WindowTransmission;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam160_WindowReflection;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam160_AtmosphericTemperature;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam160_AtmosphericTransmission;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam160_WindowTemperature;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam160_WindowReflectedTemperature;
        private System.Windows.Forms.Button button_RestoreDefaultFluxParameters_160;
        private System.Windows.Forms.Button button_GetSensorInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_SensorInfo;
        private System.Windows.Forms.Label label_ProductModelNameTitle;
        private System.Windows.Forms.Label label_HardwareVersionTitle;
        private System.Windows.Forms.Label label_ProductSerialNumberTitle;
        private System.Windows.Forms.Label label_HardwareVersion;
        private System.Windows.Forms.Label label_ProductSerialNumber;
        private System.Windows.Forms.Label label_ProductModelName;
        private System.Windows.Forms.Label label_ProductPartNumber;
        private System.Windows.Forms.GroupBox groupBox_SensorInformation;
        private System.Windows.Forms.GroupBox groupBox_ProductInformation;
        private System.Windows.Forms.GroupBox groupBox_FluxParameters_160;
        private System.Windows.Forms.GroupBox groupBox_NetworkConfiguration;
        private System.Windows.Forms.Button button_ScanLocalCamera;
        private System.Windows.Forms.TextBox textBox_RemoteCameraName;
        private System.Windows.Forms.Label label_RemoteCameraNameTitle;
        private System.Windows.Forms.TextBox textBox_RemoteCameraSerialNumber;
        private System.Windows.Forms.Label label_RemoteCameraSerialNumberTitle;
        private System.Windows.Forms.Label label_RemoteCameraMACAddressTitle;
        private System.Windows.Forms.TextBox textBox_RemoteCameraMACAddress;
        private System.Windows.Forms.ListBox listBox_LocalCameraScanList;
        private System.Windows.Forms.TextBox textBox_LocalCameraComPort;
        private System.Windows.Forms.TextBox textBox_LocalCameraName;
        private System.Windows.Forms.Label label_FluxParam160_BackgroundTemperatureUnit;
        private System.Windows.Forms.Label label_FluxParam160_WindowReflectedTemperatureUnit;
        private System.Windows.Forms.Label label_FluxParam160_AtmosphericTemperatureUnit;
        private System.Windows.Forms.Label label_FluxParam160_WindowTemperatureUnit;
        private System.Windows.Forms.Panel panel_PreviewConfig;
        private System.Windows.Forms.ComboBox comboBox_TemperatureUnit;
        private System.Windows.Forms.Label label_TemperatureUnit;
        private System.Windows.Forms.Label label_ColorMap;
        private System.Windows.Forms.ComboBox comboBox_ColorMap;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_Name;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_CamInfo;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_fps;
        private System.Windows.Forms.TabPage tabPage_RoiManager;
        private System.Windows.Forms.Panel panel_RoiShape;
        private System.Windows.Forms.Panel panel_Temperature;
        private System.Windows.Forms.RadioButton radioButton_ShapeEllipse;
        private System.Windows.Forms.RadioButton radioButton_ShapeRectangle;
        private System.Windows.Forms.RadioButton radioButton_ShapeLine;
        private System.Windows.Forms.RadioButton radioButton_ShapeSpot;
        private System.Windows.Forms.RadioButton radioButton_ShapeCursor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Preview;
        private System.Windows.Forms.Panel panel_VideoPreview;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_PreviewSize;
        private System.Windows.Forms.Button button_RestoreDefaultSensorConfig_256G;
        private System.Windows.Forms.GroupBox groupBox_FluxParameters_256;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FluxParam256;
        private System.Windows.Forms.Button button_RestoreDefaultSensorConfig_256;
        private System.Windows.Forms.Label label_FluxParam256_EmissivityTitle;
        private System.Windows.Forms.TextBox textBox_FluxParam256_EmissivityRange;
        private System.Windows.Forms.Button button_GetFluxParameters_256;
        private System.Windows.Forms.Button button_SetFluxParameters_256;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256_Emissivity;
        private System.Windows.Forms.Label label_FluxParam256_AtmosphericTransmittanceTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256_AtmosphericTransmittance;
        private System.Windows.Forms.TextBox textBox_FluxParam256_AtmosphericTransmittanceRange;
        private System.Windows.Forms.Label label_FluxParam256_AtmosphericTemperatureTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256_AtmosphericTemperature;
        private System.Windows.Forms.TextBox textBox_FluxParam256_AtmosphericTemperatureRange;
        private System.Windows.Forms.Label label_FluxParam256_AtmosphericTemperatureUnit;
        private System.Windows.Forms.Label label_FluxParam256_AmbientReflectionTemperatureTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256_AmbientReflectionTemperature;
        private System.Windows.Forms.Label label_FluxParam256_AmbientReflectionTemperatureUnit;
        private System.Windows.Forms.TextBox textBox_FluxParam256_AmbientReflectionTemperatureRange;
        private System.Windows.Forms.Label label_FluxParam160_SceneEmissivityTitle;
        private System.Windows.Forms.Button button_GetFluxParameters_160;
        private System.Windows.Forms.Button button_SetFluxParameters_160;
        private System.Windows.Forms.Label label_FluxParam160_WindowTransmissionTitle;
        private System.Windows.Forms.Label label_FluxParam160_WindowTemperatureTitle;
        private System.Windows.Forms.Label label_FluxParam160_AtmosphericTransmissionTitle;
        private System.Windows.Forms.Label label_FluxParam160_AtmosphericTemperatureTitle;
        private System.Windows.Forms.Label label_FluxParam160_BackgroundTemperatureTitle;
        private System.Windows.Forms.GroupBox groupBox_GainModeState_256G;
        private System.Windows.Forms.Button button_SetGainModeState_256G;
        private System.Windows.Forms.Button button_GetGainModeState_256G;
        private System.Windows.Forms.RadioButton radioButton_GainModeStateLow_256G;
        private System.Windows.Forms.RadioButton radioButton_GainModeStateHigh_256G;
        private System.Windows.Forms.GroupBox groupBox_FlatFieldCorrection_256G;
        private System.Windows.Forms.Button button_SetFlatFieldCorrectionMode_256G;
        private System.Windows.Forms.Button button_GetFlatFieldCorrectionMode_256G;
        private System.Windows.Forms.RadioButton radioButton_FlatFieldCorrectionManual_256G;
        private System.Windows.Forms.Button button_RunFlatFieldCorrection_256G;
        private System.Windows.Forms.RadioButton radioButton_FlatFieldCorrectionAutomatic_256G;
        private System.Windows.Forms.GroupBox groupBox_GainModeState_256;
        private System.Windows.Forms.Button button_SetGainModeState_256;
        private System.Windows.Forms.Button button_GetGainModeState_256;
        private System.Windows.Forms.RadioButton radioButton_GainModeStateLow_256;
        private System.Windows.Forms.RadioButton radioButton_GainModeStateHigh_256;
        private System.Windows.Forms.GroupBox groupBox_FlatFieldCorrection_256;
        private System.Windows.Forms.Button button_SetFlatFieldCorrectionMode_256;
        private System.Windows.Forms.Button button_GetFlatFieldCorrectionMode_256;
        private System.Windows.Forms.RadioButton radioButton_FlatFieldCorrectionManual_256;
        private System.Windows.Forms.Button button_RunFlatFieldCorrection_256;
        private System.Windows.Forms.RadioButton radioButton_FlatFieldCorrectionAutomatic_256;
        private System.Windows.Forms.Label label_RoiList;
        private System.Windows.Forms.ComboBox comboBox_RoiList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RoiShape;
        private System.Windows.Forms.Button button_RemoveAllRoi;
        private System.Windows.Forms.Button button_RemoveRoiItem;
        private System.Windows.Forms.Button button_AddRoiItem;
        private System.Windows.Forms.RadioButton rbtn_RoiEllipse;
        private System.Windows.Forms.RadioButton rbtn_RoiRect;
        private System.Windows.Forms.RadioButton rbtn_RoiLine;
        private System.Windows.Forms.RadioButton rbtn_RoiSpot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RoiEllipse;
        private System.Windows.Forms.Label label_RoiEllipseW;
        private System.Windows.Forms.Label label_RoiEllipseX;
        private System.Windows.Forms.Label label_RoiEllipseY;
        private System.Windows.Forms.TextBox textBox_RoiEllipseX;
        private System.Windows.Forms.TextBox textBox_RoiEllipseW;
        private System.Windows.Forms.TextBox textBox_RoiEllipseY;
        private System.Windows.Forms.Label label_RoiEllipseH;
        private System.Windows.Forms.TextBox textBox_RoiEllipseH;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RoiRect;
        private System.Windows.Forms.Label label_RoiRectW;
        private System.Windows.Forms.Label label_RoiRectX;
        private System.Windows.Forms.Label label_RoiRectY;
        private System.Windows.Forms.TextBox textBox_RoiRectX;
        private System.Windows.Forms.TextBox textBox_RoiRectW;
        private System.Windows.Forms.TextBox textBox_RoiRectY;
        private System.Windows.Forms.Label label_RoiRectH;
        private System.Windows.Forms.TextBox textBox_RoiRectH;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RoiLine;
        private System.Windows.Forms.Label label_RoiLineX2;
        private System.Windows.Forms.Label label_RoiLineX1;
        private System.Windows.Forms.Label label_RoiLineY1;
        private System.Windows.Forms.TextBox textBox_RoiLineX1;
        private System.Windows.Forms.TextBox textBox_RoiLineX2;
        private System.Windows.Forms.TextBox textBox_RoiLineY1;
        private System.Windows.Forms.Label label_RoiLineY2;
        private System.Windows.Forms.TextBox textBox_RoiLineY2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_RoiSpot;
        private System.Windows.Forms.Label label_RoiSpotX;
        private System.Windows.Forms.Label label_RoiSpotY;
        private System.Windows.Forms.TextBox textBox_RoiSpotX;
        private System.Windows.Forms.TextBox textBox_RoiSpotY;
        private System.Windows.Forms.Panel panel_SensorControl_256G;
        private System.Windows.Forms.Panel panel_SensorControl_256;
        private System.Windows.Forms.GroupBox groupBox_GainModeState_160;
        private System.Windows.Forms.Button button_SetGainModeState_160;
        private System.Windows.Forms.Button button_GetGainModeState_160;
        private System.Windows.Forms.RadioButton radioButton_GainModeStateAuto_160;
        private System.Windows.Forms.RadioButton radioButton_GainModeStateLow_160;
        private System.Windows.Forms.RadioButton radioButton_GainModeStateHigh_160;
        private System.Windows.Forms.GroupBox groupBox_FlatFieldCorrection_160;
        private System.Windows.Forms.Button button_SetFlatFieldCorrectionMode_160;
        private System.Windows.Forms.Button button_GetFlatFieldCorrectionMode_160;
        private System.Windows.Forms.RadioButton radioButton_FlatFieldCorrectionManual_160;
        private System.Windows.Forms.Button button_RunFlatFieldCorrection_160;
        private System.Windows.Forms.RadioButton radioButton_FlatFieldCorrectionAutomatic_160;
        private System.Windows.Forms.Panel panel_SensorControl_160;
        private System.Windows.Forms.Button button_StoreUserSensorConfig_256G;
        private System.Windows.Forms.GroupBox groupBox_FFCParameters_256G;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FFCParam256G;
        private System.Windows.Forms.Label label_FFCParam256G_MaxIntervalTitle;
        private System.Windows.Forms.TextBox textBox_FFCParam256G_MaxIntervalRange;
        private System.Windows.Forms.Button button_GetFFCParameters_256G;
        private System.Windows.Forms.Button button_SetFFCParameters_256G;
        private System.Windows.Forms.NumericUpDown numericUpDown_FFCParam256G_MaxInterval;
        private System.Windows.Forms.Label label_FFCParam256G_MaxIntervalUnit;
        private System.Windows.Forms.Button button_StoreUserSensorConfig_256;
        private System.Windows.Forms.Label label_FluxParam256_DistanceTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256_Distance;
        private System.Windows.Forms.Label label_FluxParam256_DistanceUnit;
        private System.Windows.Forms.TextBox textBox_FluxParam256_DistanceRange;
        private System.Windows.Forms.GroupBox groupBox_FFCParameters_256;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FFCParam256;
        private System.Windows.Forms.Label label_FFCParam256_MaxIntervalTitle;
        private System.Windows.Forms.TextBox textBox_FFCParam256_MaxIntervalRange;
        private System.Windows.Forms.Button button_GetFFCParameters_256;
        private System.Windows.Forms.Button button_SetFFCParameters_256;
        private System.Windows.Forms.NumericUpDown numericUpDown_FFCParam256_MaxInterval;
        private System.Windows.Forms.Label label_FFCParam256_AutoTriggerThresholdTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_FFCParam256_AutoTriggerThreshold;
        private System.Windows.Forms.TextBox textBox_FFCParam256_AutoTriggerThresholdRange;
        private System.Windows.Forms.Label label_FFCParam256_MaxIntervalUnit;
        private System.Windows.Forms.CheckBox checkBox_NoiseFiltering;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_BinaryInforation;
        private System.Windows.Forms.Label label_BinaryInformationTitle;
        private System.Windows.Forms.Label label_BinarySizeTitle;
        private System.Windows.Forms.Label label_BinaryVendorNameTitle;
        private System.Windows.Forms.Label label_BinaryProductNameTitle;
        private System.Windows.Forms.Label label_BinaryVersionTitle;
        private System.Windows.Forms.Label label_BinaryBuildTimeTitle;
        private System.Windows.Forms.Label label_BinaryVendorName;
        private System.Windows.Forms.Label label_BinaryProductName;
        private System.Windows.Forms.Label label_BinaryVersion;
        private System.Windows.Forms.Label label_BinaryBuildTime;
        private System.Windows.Forms.Label label_BinarySize;
        private System.Windows.Forms.Label label_RemoteCameraAdapterIPTitle;
        private System.Windows.Forms.TextBox textBox_RemoteCameraAdapterIP;
        private System.Windows.Forms.Label label_LocalCameraVideoFormat;
        private System.Windows.Forms.ComboBox comboBox_LocalCameraVideoFormat;
        private System.Windows.Forms.Label label_RemoteCameraVideoFormat;
        private System.Windows.Forms.ComboBox comboBox_RemoteCameraVideoFormat;
        private System.Windows.Forms.RadioButton radioButton_GainModeStateAuto_256G;
        private System.Windows.Forms.Label label_ProductPartNumberTitle;
        private System.Windows.Forms.Label label_SplashScreenTitle;
        private System.Windows.Forms.TextBox textBox_RemoteCameraPartNumber;
        private System.Windows.Forms.Label label_RemoteCameraPartNumberTitle;
        private System.Windows.Forms.GroupBox groupBox_FluxParameters_256G;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_FluxParam256G;
        private System.Windows.Forms.Label label_FluxParam256G_DistanceTitle;
        private System.Windows.Forms.Label label_FluxParam256G_EmissivityTitle;
        private System.Windows.Forms.TextBox textBox_FluxParam256G_EmissivityRange;
        private System.Windows.Forms.Button button_GetFluxParameters_256G;
        private System.Windows.Forms.Button button_SetFluxParameters_256G;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256G_Emissivity;
        private System.Windows.Forms.Label label_FluxParam256G_AtmosphericTransmittanceTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256G_AtmosphericTransmittance;
        private System.Windows.Forms.TextBox textBox_FluxParam256G_AtmosphericTransmittanceRange;
        private System.Windows.Forms.Label label_FluxParam256G_AtmosphericTemperatureTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256G_AtmosphericTemperature;
        private System.Windows.Forms.TextBox textBox_FluxParam256G_AtmosphericTemperatureRange;
        private System.Windows.Forms.Label label_FluxParam256G_AtmosphericTemperatureUnit;
        private System.Windows.Forms.Label label_FluxParam256G_AmbientReflectionTemperatureTitle;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256G_AmbientReflectionTemperature;
        private System.Windows.Forms.Label label_FluxParam256G_AmbientReflectionTemperatureUnit;
        private System.Windows.Forms.TextBox textBox_FluxParam256G_AmbientReflectionTemperatureRange;
        private System.Windows.Forms.NumericUpDown numericUpDown_FluxParam256G_Distance;
        private System.Windows.Forms.Label label_FluxParam256G_DistanceUnit;
        private System.Windows.Forms.TextBox textBox_FluxParam256G_DistanceRange;
        private System.Windows.Forms.ComboBox comboBox_SplashScreen;
    }
}

