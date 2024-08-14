#pragma once
#include <unordered_map>
#include <string>
#include <iostream>

namespace TmSDK
{
    /// @cond DOXYGEN_SHOULD_SKIP_THIS
    /// <summary> 
    /// Camera device system status code
    /// </summary>
    enum class SysStatusCode : uint16_t
    {
        SYS_BOOTING = 0x0100,
        SYS_IDLE = 0x0101,
        SYS_STREAMING = 0x0102,
        SYS_BOOTING_FAIL = 0x8100,
        SYS_SENSOR_UNSTABLE = 0x8101,
        SYS_UNKNOWN = 0xFFFF
    };
    
    /// <summary> 
    /// Camera device system error code
    /// </summary>
    enum class SysErrorCode : uint16_t
    {
        ERR_NONE = 0x0000,
        ERR_CAMERA = 0x8000,
        ERR_SENSOR = 0x8100,
        ERR_SENSOR_DISCONNECTED = 0x8101,
        ERR_ETHERNET = 0x8200,
        ERR_USB = 0x8300,
        ERR_UNKNOWN = 0xFFFF
    };

    /// <summary> 
    /// Camera device system status class
    /// </summary>
    class TmCameraStatus
    {
    public:
        TmCameraStatus();
        virtual ~TmCameraStatus();

        static std::unordered_map<uint16_t, std::string> SysStatus;
        static std::unordered_map<uint16_t, std::string> SysError;
    };
    /// @endcond
}