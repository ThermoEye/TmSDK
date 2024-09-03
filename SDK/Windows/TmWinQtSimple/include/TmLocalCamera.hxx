#pragma once
#if defined(_MSC_VER)
#elif defined(__GNUC__)
#include <sys/epoll.h>
#endif

#include "TmShared.hxx"
#include "TmCamera.hxx"
#include "TmProtocol.hxx"

namespace TmSDK
{
	/// <summary>
	/// Class representing a local camera.
	/// </summary>
	class DLL_EXPORTS TmLocalCamera : public TmCamera
	{
	private:
		int fwMaxPacketLength = 48;
		void* pVideoCapture = nullptr;
#if defined(_MSC_VER)
		HANDLE hComm = NULL;
		OVERLAPPED readOverlapped = { 0 };
		OVERLAPPED writeOverlapped = { 0 };
#elif defined(__GNUC__)
		int comfd = -1;
		int epollfd = -1;
		struct epoll_event ev, events[1];
#endif
	private:
#if defined(_MSC_VER)
#elif defined(__GNUC__)
		static std::vector<struct localDevice> GetDeviceInfo(std::string subsystem);
#endif
		bool ConnectPort(std::string port);
		bool Receive(uint32_t timeout);

	public:
		TmLocalCamera();
		virtual ~TmLocalCamera();

		bool Open(TmLocalCamInfo* camInfo) override;
		void Close() override;
		PKT_INTERFACE SendPacket(Packet packet, uint32_t timeout) override;
		static std::vector<TmLocalCamInfo> GetCameraList();
		TmFrame* QueryFrame(int width, int height);
		int GetMaxPacketSize() override;
	};
}

