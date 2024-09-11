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

	public:
		TmLocalCamInfo(std::string name, std::string comPort, int index);
		TmLocalCamInfo();
		virtual ~TmLocalCamInfo();
		std::string GetName();
		std::string GetComPort();
		int GetIndex();
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
	public:
		TmRemoteCamInfo(std::string name, std::string serialnumber, std::string mac, std::string ip);
		TmRemoteCamInfo();
		virtual ~TmRemoteCamInfo();
		std::string GetName();
		std::string GetSerialNumber();
		std::string GetMac();
		std::string GetIp();
	};
}