#pragma once

#if defined(_MSC_VER)
#include <winsock2.h>
#include <Windows.h>
#include <dshow.h>
#pragma comment(lib, "strmiids")
#elif defined(__GNUC__)
#include <stdlib.h>
#include <stdio.h>
#include <fcntl.h>
#include <unistd.h>
#include <string.h>
#include <dirent.h>
#include <sys/stat.h>
#include <sys/ioctl.h>
#include <linux/videodev2.h>
#include <iostream>
#endif

#include <map>
#include <string>

namespace TmSDK
{
	/// @cond DOXYGEN_SHOULD_SKIP_THIS
	struct Device {
		int id; // This can be used to open the device in OpenCV
		std::string devicePath;
		std::string deviceName; // This can be used to show the devices to the user
		std::string deviceID;
		std::string deviceVID;
		std::string devicePID;
		std::string deviceInst;
	};

	class DeviceEnum {

	public:
		DeviceEnum() = default;
#if defined(_MSC_VER)
		std::map<int, Device> getDevicesMap(const GUID deviceClass);
#elif defined(__GNUC__)
		std::map<int, Device> getDevicesMap(const char* deviceClass);
#endif
		std::map<int, Device> getVideoDevicesMap();
		std::map<int, Device> getAudioDevicesMap();

	private:

#if defined(_MSC_VER)
		std::string ConvertBSTRToMBS(BSTR bstr);
#elif defined(__GNUC__)
		std::string ConvertBSTRToMBS(char* bstr);
#endif
		std::string ConvertWCSToMBS(const wchar_t* pstr, long wslen);

	};
	/// @endcond
}
