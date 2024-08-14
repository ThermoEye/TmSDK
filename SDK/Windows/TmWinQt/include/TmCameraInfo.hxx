#pragma once

#include <string>
#include "TmExport.hxx"


namespace TmSDK
{
	/// <summary>
	/// Base class for camera information.
	/// </summary>
	class DLL_EXPORTS TmCamInfo
	{
	public:
		TmCamInfo() {}
		virtual ~TmCamInfo() = default;
	};
	/// <summary>
	/// Class representing local camera information.
	/// </summary>
	class DLL_EXPORTS TmLocalCamInfo : public TmCamInfo
	{
	public:
		int Index = -1;
		std::string Name = "";
		std::string ComPort = "";
		TmLocalCamInfo(std::string name, std::string comPort, int index);
		TmLocalCamInfo(std::string name, int index);
		TmLocalCamInfo();
		virtual ~TmLocalCamInfo();
	};
	/// <summary>
	/// Class representing remote camera information.
	/// </summary>
	class DLL_EXPORTS TmRemoteCamInfo : public TmCamInfo
	{
	public:
		std::string Name;
		std::string SerialNumber;
		std::string AddrMAC;
		std::string AddrIP;
		TmRemoteCamInfo(std::string name, std::string serialnumber, std::string mac, std::string ip);
		TmRemoteCamInfo();
		virtual ~TmRemoteCamInfo();
	};
}