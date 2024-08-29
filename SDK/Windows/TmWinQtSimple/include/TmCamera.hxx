#pragma once

#if defined(_MSC_VER)

#elif defined(__GNUC__)
#include <dirent.h>
#include <sys/stat.h>
#include <unistd.h>
#endif

#include "TmFrame.hxx"
#include "TmCameraInfo.hxx"
#include "TmCameraEx.hxx"
#include "TmControl.hxx"
#include "TmProtocol.hxx"
#include "Utils.hxx"

namespace TmSDK
{
	/// <summary>
	///  A class representing a thermal camera with various functionalities.
	/// </summary>
	class DLL_EXPORTS TmCamera
	{
	protected:
		TmCamInfo* pCamInfo = nullptr;
		TmFrame* pTmFrame = nullptr;
		Packet cmdRxPacket;
		int resultCode = 0;
		int currentGainMode = -1; // -1 = Unknown, 0 = High, 1 = Low, 2 = Auto
		bool isOpen = false;
		std::string name;
		int width = 0, height = 0;
		ColormapTypes colorMap = ColormapTypes::GrayScale;
		bool noiseFiltering = false;
		TempUnit tempUnit = TempUnit::RAW;
		std::string tempUnitSymbol = "";
	public:
		TmControl* pTmControl = nullptr;

	private:
		double InterpolateRaw(double raw);

	public:
		TmCamera();
		virtual ~TmCamera();

		virtual bool Open(TmLocalCamInfo* camInfo) { return false; }
		virtual bool Open(TmRemoteCamInfo* camInfo) { return false; }
		virtual void Close() { }
		virtual void SetCurrentGainMode(int);
		virtual std::string GetTempUnitSymbol();
		virtual TmFrame* QueryFrame(int width, int height) { return nullptr;  }
		virtual int GetMaxPacketSize() { return 0; }
		/// @cond DOXYGEN_SHOULD_SKIP_THIS
		virtual PKT_INTERFACE SendPacket(Packet packet, uint32_t timeout = 500) { return PKT_INTERFACE::ERR; }
		virtual bool Receive(uint32_t timeout = 500) { return false; }
		virtual Packet GetRxPacket();
		/// @endcond

		bool IsOpen();
		std::string GetDevName();
		double GetTemperature(double raw);
		TempUnit GetTempUnit();
		void SetTempUnit(TempUnit value);
		void SetColorMap(ColormapTypes index);
		void SetNoiseFiltering(bool filter);
		TmControl* GetTmControl();
	};
}


#include "TmLocalCamera.hxx"
#include "TmRemoteCamera.hxx"

