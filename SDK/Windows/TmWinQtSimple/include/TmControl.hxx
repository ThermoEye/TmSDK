#pragma once
#include "TmShared.hxx"
//#include <TmCtrl.hxx>
//#include <TmProtocol.hxx>
#include <string>
#if defined(_MSC_VER)
#elif defined(__GNUC__)
#include <math.h>
#endif

namespace TmSDK
{
	using namespace std;
	/// @cond DOXYGEN_SHOULD_SKIP_THIS
	struct LEP_RAD_FLUX_LINEAR_PARAMS_T
	{
		/* Type     Field name              format   default  range       comment*/
		uint16_t sceneEmissivity;     /* 3.13     8192     [82, 8192] */
		uint16_t TBkgK;               /* 16.0     30000    [, ]        value in kelvin 100x*/
		uint16_t tauWindow;           /* 3.13     8192     [82, 8192] */
		uint16_t TWindowK;            /* 16.0     30000    [, ]        value in kelvin 100x*/
		uint16_t tauAtm;              /* 3.13     8192     [82, 8192] */
		uint16_t TAtmK;               /* 16.0     30000    [, ]        value in kelvin 100x*/
		uint16_t reflWindow;          /* 3.13     0        [0, 8192-tauWindow] */
		uint16_t TReflK;              /* 16.0     30000    [, ]        value in kelvin 100x*/
	};

#pragma pack(push, 1)
	struct LEP_SYS_FFC_SHUTTER_MODE_OBJ_T
	{
		uint8_t shutterMode;
		uint8_t tempLockoutState;
		uint8_t videoFreezeDuringFFC;
		uint8_t ffcDesired;
		uint32_t elapsedTimeSinceLastFfc;
		uint32_t desiredFfcPeriod;
		uint8_t explicitCmdToOpen;
		uint16_t desiredFfcTempDelta;
		uint16_t imminentDelay;
	};

	struct GET_NET_CFG_T
	{
		uint64_t mac;
		uint8_t ipAssign;
		uint32_t ip;
		uint32_t netmask;
		uint32_t gateway;
		uint32_t dns;
		uint32_t dns2;
	};

	struct SET_NET_CFG_T {
		uint8_t ipAssign;
		uint32_t ip;
		uint32_t netmask;
		uint32_t gateway;
		uint32_t dns;
		uint32_t dns2;
	};
#pragma pack(pop)

#ifdef INTERNAL
#pragma pack(push, 1)
	struct LEP_SYS_GAIN_MODE_ROI_T
	{
		uint16_t startCol;
		uint16_t startRow;
		uint16_t endCol;
		uint16_t endRow;
	};

	// Gain Mode Support
	struct LEP_SYS_GAIN_MODE_THRESHOLDS_T
	{
		uint16_t sys_P_high_to_low;    /* Range: [0-100], percent   */
		uint16_t sys_P_low_to_high;    /* Range: [0-100], percent   */

		uint16_t sys_C_high_to_low;    /* Range: [0-600], degrees C */
		uint16_t sys_C_low_to_high;    /* Range: [0-600], degrees C */

		uint16_t sys_T_high_to_low;    /* Range: [0-900], Kelvin    */
		uint16_t sys_T_low_to_high;    /* Range: [0-900], Kelvin    */
	};

	// Gain Mode Object
	struct LEP_SYS_GAIN_MODE_OBJ_T
	{
		LEP_SYS_GAIN_MODE_ROI_T sysGainModeROI;                /* Specified ROI to use for Gain Mode switching */
		LEP_SYS_GAIN_MODE_THRESHOLDS_T sysGainModeThresholds;  /* Set of threshold triggers */
		uint16_t sysGainRoiPopulation;                           /* Population size in pixels within the ROI */
		uint16_t sysGainModeTempEnabled;                         /* True if T-Linear is implemented */
		uint16_t sysGainModeFluxThresholdLow;                    /* calculated from desired temp */
		uint16_t sysGainModeFluxThresholdHigh;                   /* calculated from desired temp */
	};

	struct GET_SEC_CFG_START_T {
		std::vector<uint8_t> pw;
	};

	struct GET_SEC_CFG_ING_T {
		std::vector<uint8_t> prodSN;
		uint32_t hwVer;
		uint64_t mac;
	};

	struct SET_SEC_CFG_START_T
	{
		std::vector<uint8_t> pw;
		uint32_t size;
	};

	struct SET_SEC_CFG_ING_T
	{
		std::vector<uint8_t> prodSN;
		uint32_t hwVer;
		uint64_t mac;
	};

	struct CHANGE_PASSWORD_T
	{
		std::vector<uint8_t> curPW;
		std::vector<uint8_t> newPW;
	};
#pragma pack(pop)
#endif
	/// @endcond

	/// <summary>
	/// Class providing control functionalities for the camera.
	/// </summary>
	class DLL_EXPORTS TmControl
	{
	public:
		TmControl() {};
		virtual ~TmControl() {};

	public:
		virtual std::string GetProductModelName() { return ""; }
		virtual std::string GetProductSerialNumber() { return ""; }
		virtual std::string GetHardwareVersion() { return ""; }
		virtual std::string GetBootloaderVersion() { return ""; }
		virtual std::string GetFirmwareVersion() { return ""; }
		virtual std::tuple<uint16_t, std::string> GetSystemStatus() { return std::make_tuple(0, ""); }
		virtual std::tuple<uint16_t, std::string> GetSystemError() { return std::make_tuple(0, ""); }
		virtual std::string GetSensorModelName() { return ""; }
		virtual std::string GetSensorSerialNumber() { return ""; }
		virtual std::string GetSensorUptime() { return ""; }
		
		virtual bool GetFluxParameters(double& sceneEmissivity, double& backgroundTemperature,
				double& windowTransmission, double& windowTemperature,
				double& atmosphericTransmission, double& atmosphericTemperature,
				double& windowReflection, double& windowReflectedTemperature) { return false; }
		virtual bool GetFluxParameters(double& emissivity, double& atmosphericTransmittance,
				double& atmosphericTemperature, double& ambientReflectionTemperature, double& distance) { return false; }
		virtual bool SetFluxParameters(double sceneEmissivity, double backgroundTemperature,
				double windowTransmission, double windowTemperature,
				double atmosphericTransmission, double atmosphericTemperature,
				double windowReflection, double windowReflectedTemperature) { return false; }
		virtual bool SetFluxParameters(double emissivity, double atmosphericTransmittance,
				double atmosphericTemperature, double ambientReflectionTemperature,
				double distance) { return false; }
		virtual bool SetDefaultFluxParameters(double& sceneEmissivity, double& backgroundTemperature,
				double& windowTransmission, double& windowTemperature,
				double& atmosphericTransmission, double& atmosphericTemperature,
				double& windowReflection, double& windowReflectedTemperature) { return false; }
		virtual bool SetDefaultFluxParameters(double& emissivity, double& atmosphericTransmittance,
				double& atmosphericTemperature, double& ambientReflectionTemperature,
				double& distance) { return false; }
		virtual int GetGainModeState() { return -1; }
		virtual bool SetGainModeState(int state) { return false; }
		virtual bool GetFlatFieldCorrectionParameters(double& maxInterval, double& autoTriggerThreshold) { return false; }
		virtual bool SetFlatFieldCorrectionParameters(double maxInterval, double autoTriggerThreshold) { return false; }
		virtual int GetFlatFieldCorrectionMode() { return -1; }
		virtual bool SetFlatFieldCorrectionMode(int mode) { return false; }
		virtual bool RunFlatFieldCorrection() { return false; }
		virtual bool StoreUserSensorConfig() { return false; }
		virtual bool RestoreDefaultSensorConfig() { return false; }
		/// @cond DOXYGEN_SHOULD_SKIP_THIS
		virtual double ConvertRawToCelsius(double raw) { return 0.0; }
		virtual double ConvertRawToFahrenheit(double raw) { return 0.0; }
		virtual double ConvertRawToKelvin(double raw) { return 0.0; }
		/// @endcond
		virtual bool GetNetworkConfiguration(std::string& mac, std::string& ipAssign, std::string& ip, std::string& netmask,
				std::string& gateway, std::string& dns, std::string& dns2)  { return false; }
		virtual bool SetNetworkConfiguration(std::string ipAssign, std::string ip, std::string netmask, std::string gateway, std::string dns, std::string dns2) { return false; }
		virtual bool SetDefaultNetworkConfiguration(std::string& ipAssign, std::string& ip, std::string& netmask,
				std::string& gateway, std::string& dns, std::string& dns2) { return false; }
		virtual bool RebootDevice() { return false; }
		virtual bool CheckFirmware(std::string fwFilePath, std::string& vendorName, std::string& productName,
			std::string& versionName, std::string& buildTime, int& fileSize) { return false; }
		virtual int OpenFirmware(std::string fwFilePath) { return false; }
		virtual int UpdateFirmware() { return -1; }
		virtual bool CloseFirmware() { return false; }
#ifdef INTERNAL
		virtual bool GetGainModeObject(uint16_t& roiStartColumn, uint16_t& roiStartRow,
				uint16_t& roiEndColumn, uint16_t& roiEndRow,
				uint16_t& thresholdPopH2L, uint16_t& thresholdPopL2H,
				uint16_t& thresholdCelH2L, uint16_t& thresholdCelL2H,
				uint16_t& thresholdKelH2L, uint16_t& thresholdKelL2H,
				uint16_t& roiPopSize, uint16_t& tlinearEnable,
				uint16_t& fluxThresholdH2L, uint16_t& fluxThresholdL2H) { return false; }
		virtual bool SetGainModeObject(uint16_t roiStartColumn, uint16_t roiStartRow,
				uint16_t roiEndColumn, uint16_t roiEndRow,
				uint16_t thresholdPopH2L, uint16_t thresholdPopL2H,
				uint16_t thresholdCelH2L, uint16_t thresholdCelL2H,
				uint16_t thresholdKelH2L, uint16_t thresholdKelL2H,
				uint16_t roiPopSize, uint16_t tlinearEnable,
				uint16_t fluxThresholdH2L, uint16_t fluxThresholdL2H) { return false; }
		virtual bool SetDefaultGainModeObject() { return false; }
		virtual bool RestoreCalibrationData() { return false; }
		virtual bool Calibrate1PointTemperature(uint16_t kelvinTemp) { return false; }
		virtual bool Calibrate2PointsTemperature(int pointIndex, uint16_t kelvinTemp) { return false; }
		virtual bool CorrectLidPatternNoise() { return false; }
		virtual bool GetSecureConfiguration(std::string password, std::string& prodSN, std::string& hwVer, std::string& mac) { return false; }
		virtual bool SetSecureConfiguration(std::string password, std::string prodSN, std::string hwVer, std::string mac) { return false; }
		virtual bool SetDefaultSecureConfiguration(std::string password, std::string& prodSN, std::string& hwVer, std::string& mac) { return false; }
		virtual bool ChangeSecureAdminPassword(std::string currentPW, std::string newPW) { return false; }
#endif
	};
}
