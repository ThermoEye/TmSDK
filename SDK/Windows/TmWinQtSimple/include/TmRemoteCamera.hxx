#pragma once
#include <iostream>
#include "TmCamera.hxx"
#include "TmProtocol.hxx"

namespace TmSDK
{
    /// <summary>
    /// Class representing a remote camera.
    /// </summary>
    class DLL_EXPORTS TmRemoteCamera : public TmCamera
    {
    private:
#if defined(_MSC_VER)
        SOCKET videoSocket = INVALID_SOCKET;
#elif defined(__GNUC__)
        unsigned int videoSocket = -1;
#endif
        static const int BROADCAST_PORT = 15000;
        int RTSP_PORT = 554;
        void* pRtspClient;
        int fwMaxPacketLength = 512;
        
    private:
        static std::vector<std::string> GetNetworkAdapterIPList();
        bool Receive(uint32_t timeout) override;
        std::string base64_encode(const uint8_t* buf, unsigned int bufLen);
        std::vector<uint8_t> base64_decode(const std::string& encoded_string);
#if defined(_MSC_VER)
        static void CloseSocket(SOCKET);
#elif defined(__GNUC__)
        static void CloseSocket(int);
#endif

    public:
        TmRemoteCamera();
        virtual ~TmRemoteCamera();
        static std::vector<TmRemoteCamInfo> GetCameraList();
        bool Open(TmRemoteCamInfo* camInfo) override;
        void Close() override;
        PKT_INTERFACE SendPacket(Packet packet, uint32_t timeout) override;
        int GetMaxPacketSize() override;
        TmFrame* QueryFrame(int width = -1, int height = -1) override;
    };
}


