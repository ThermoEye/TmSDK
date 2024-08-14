#pragma once
#include "TmControl.hxx"
#include "TmCamera.hxx"
#include <fstream>

namespace TmSDK
{
	/// <summary>
	/// Class providing control functionalities for the TmCtrl160 camera.
	/// </summary>
	class TmCtrl160 : public TmControl
	{
	public:
		/// @cond DOXYGEN_SHOULD_SKIP_THIS
		TmCamera* pTmCamera;
		/// @endcond
	private:
		std::ifstream fwBinaryFile;
		int fwBinarySize = 0;
		std::vector<uint8_t> fwBinaryData;
		int fwBinaryOffset = 0;
		int progressPercent = 0;

	private:
		double ConvertFluxRawToRatio(uint16_t raw);
		uint16_t ConvertFluxRatioToRaw(double ratio);
		double ConvertFluxRawToCelsius(uint16_t raw);
		uint16_t ConvertFluxCelsiusToRaw(double celsius);

	public:
		TmCtrl160(TmCamera* tmCamera);
		virtual ~TmCtrl160();

		/// @cond DOXYGEN_SHOULD_SKIP_THIS
		double ConvertRawToCelsius(double raw) override;
		double ConvertRawToFahrenheit(double raw) override;
		double ConvertRawToKelvin(double raw) override;
		/// @endcond

		std::string GetProductModelName() override;
		std::string GetProductSerialNumber() override;
		string GetHardwareVersion() override;
		string GetBootloaderVersion() override;
		string GetFirmwareVersion() override;
		std::tuple<uint16_t, std::string> GetSystemStatus() override;
		std::tuple<uint16_t, std::string> GetSystemError() override;
		string GetSensorModelName() override;
		string GetSensorSerialNumber() override;
		string GetSensorUptime() override;
		bool GetFluxParameters(double& sceneEmissivity, double& backgroundTemperature,
			double& windowTransmission, double& windowTemperature,
			double& atmosphericTransmission, double& atmosphericTemperature,
			double& windowReflection, double& windowReflectedTemperature) override;
		bool GetFluxParameters(double& emissivity, double& atmosphericTransmittance,
			double& atmosphericTemperature, double& ambientReflectionTemperature,
			double& distance) override;
		bool SetFluxParameters(double sceneEmissivity, double backgroundTemperature,
			double windowTransmission, double windowTemperature,
			double atmosphericTransmission, double atmosphericTemperature,
			double windowReflection, double windowReflectedTemperature) override;
		bool SetFluxParameters(double emissivity, double atmosphericTransmittance,
			double atmosphericTemperature, double ambientReflectionTemperature,
			double distance) override;
		bool SetDefaultFluxParameters(double& sceneEmissivity, double& backgroundTemperature,
			double& windowTransmission, double& windowTemperature,
			double& atmosphericTransmission, double& atmosphericTemperature,
			double& windowReflection, double& windowReflectedTemperature) override;
		bool SetDefaultFluxParameters(double& emissivity, double& atmosphericTransmittance,
			double& atmosphericTemperature, double& ambientReflectionTemperature,
			double& distance) override;
		int GetGainModeState() override;
		bool SetGainModeState(int state) override;
		bool GetFlatFieldCorrectionParameters(double& maxInterval, double& autoTriggerThreshold) override;
		bool SetFlatFieldCorrectionParameters(double maxInterval, double autoTriggerThreshold) override;
		int GetFlatFieldCorrectionMode() override;
		bool SetFlatFieldCorrectionMode(int mode) override;
		bool RunFlatFieldCorrection() override;
		bool StoreUserSensorConfig() override;
		bool RestoreDefaultSensorConfig() override;


		bool GetNetworkConfiguration(std::string& mac, std::string& ipAssign, std::string& ip, std::string& netmask,
			std::string& gateway, std::string& dns, std::string& dns2) override;
		bool SetNetworkConfiguration(std::string ipAssign, std::string ip, std::string netmask, std::string gateway, 
			std::string dns, std::string dns2) override;
		bool SetDefaultNetworkConfiguration(std::string& ipAssign, std::string& ip, std::string& netmask,
			std::string& gateway, std::string& dns, std::string& dns2) override;
		bool RebootDevice() override;
		bool CheckFirmware(std::string fwFilePath, std::string& vendorName, std::string& productName, 
			std::string& versionName, std::string& buildTime, int& fileSize) override;
		int OpenFirmware(std::string fwFilePath) override;
		int UpdateFirmware() override;
		bool CloseFirmware() override;


#ifdef INTERNAL
		bool GetGainModeObject(uint16_t& roiStartColumn, uint16_t& roiStartRow,
			uint16_t& roiEndColumn, uint16_t& roiEndRow,
			uint16_t& thresholdPopH2L, uint16_t& thresholdPopL2H,
			uint16_t& thresholdCelH2L, uint16_t& thresholdCelL2H,
			uint16_t& thresholdKelH2L, uint16_t& thresholdKelL2H,
			uint16_t& roiPopSize, uint16_t& tlinearEnable,
			uint16_t& fluxThresholdH2L, uint16_t& fluxThresholdL2H);
		bool SetGainModeObject(uint16_t roiStartColumn, uint16_t roiStartRow,
			uint16_t roiEndColumn, uint16_t roiEndRow,
			uint16_t thresholdPopH2L, uint16_t thresholdPopL2H,
			uint16_t thresholdCelH2L, uint16_t thresholdCelL2H,
			uint16_t thresholdKelH2L, uint16_t thresholdKelL2H,
			uint16_t roiPopSize, uint16_t tlinearEnable,
			uint16_t fluxThresholdH2L, uint16_t fluxThresholdL2H);
		bool SetDefaultGainModeObject() override;
		bool RestoreCalibrationData() override;
		bool Calibrate1PointTemperature(uint16_t kelvinTemp) override;
		bool Calibrate2PointsTemperature(int pointIndex, uint16_t kelvinTemp) override;
		bool CorrectLidPatternNoise() override;
		bool GetSecureConfiguration(string password, std::string& prodSN, std::string& hwVer, std::string& mac) override;
		bool SetSecureConfiguration(string password, string prodSN, string hwVer, string mac) override;
		bool SetDefaultSecureConfiguration(string password, std::string& prodSN, std::string& hwVer, std::string& mac) override;
		bool ChangeSecureAdminPassword(string currentPW, string newPW) override;
#endif
	};
}
