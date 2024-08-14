#pragma once
#include <sstream>
#include <string>
#include <vector>
#include <iostream>
#include <algorithm>
#include <iomanip>
#include <cstring>
#if defined(_MSC_VER)
#include <ws2tcpip.h>
#include <WinSock2.h>
#pragma comment(lib, "Ws2_32.lib")
#elif defined(__GNUC__)
#include <stdexcept>
#include <arpa/inet.h> // For inet_pton and ntohl
#endif


namespace TmSDK
{
    /// @cond DOXYGEN_SHOULD_SKIP_THIS
    class Utils
    {
    public:
        static const std::string STR_SYMBOL_RAW;
        static const std::string STR_SYMBOL_CELSIUS;
        static const std::string STR_SYMBOL_FAHRENHEIT;
        static const std::string STR_SYMBOL_KELVIN;

        static const double CONST_KELVIN2CELSIUS;
        static const double CONST_KELVIN2FAHRENHEIT;

        static double CompensateHumanTemperature(double tempC)
        {
            double compTempC = tempC;
            if (25.0 < tempC && tempC <= 37.5)
            {
                compTempC = tempC - (0.9 * (tempC - 36.5));
            }
            else if (37.5 < tempC && tempC <= 40.0)
            {
                compTempC = tempC - (0.9 * (tempC - 37.3));
            }
            return compTempC;
        }

        static bool IsNullOrWhiteSpace(const std::string& str)
        {
            return str.empty() || std::all_of(str.begin(), str.end(), [](unsigned char c) { return std::isspace(c); });
        }

        static bool ValidateIPv4(std::string ipString)
        {
            if (Utils::IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            std::istringstream ipSt(ipString);
            std::vector<std::string> buffer(4);
            int i = 0;
            while (i < 4 && std::getline(ipSt, buffer[i], '.'))
            {
                int ipNum = std::stoi(buffer[i]);
                if (ipNum < 0 || ipNum > 255)
                {
                    return false;
                }
                i++;
            }
            if (i != 4)
            {
                return false;
            }

            return true;
        }
        
        static uint32_t NetworkToHostOrder(const std::string& ip) {
            struct in_addr addr;

            if (inet_pton(AF_INET, ip.c_str(), &addr) != 1) {
                throw std::runtime_error("Invalid IP address format");
            }

            // Convert network byte order to host byte order
            return ntohl(addr.s_addr);
        }

        static std::string toHex(uint8_t num) {
            std::stringstream ss;
            ss << std::hex << std::uppercase << std::setw(2) << std::setfill('0') << static_cast<int>(num);
            return ss.str();
        }

        static std::string ToHexString(void* ptr, size_t size) {
            unsigned char* bytePtr = static_cast<unsigned char*>(ptr);
            std::ostringstream oss;
            oss << std::hex << std::setfill('0');

            for (size_t i = 0; i < size; ++i) {
                oss << std::setw(2) << " " << static_cast<int>(bytePtr[i]);
            }

            return oss.str();
        }

        static std::string toIpString(uint32_t ip) {
            std::vector<uint8_t> bytes(4);
            memcpy(bytes.data(), &ip, sizeof(ip));
            std::reverse(bytes.begin(), bytes.end());

            std::stringstream ss;
            for (size_t i = 0; i < bytes.size(); ++i) {
                ss << static_cast<int>(bytes[i]);
                if (i < bytes.size() - 1) {
                    ss << ".";
                }
            }
            return ss.str();
        }

        static std::vector<uint8_t> IntToByteVector(int value) {
            std::vector<uint8_t> vec(sizeof(int));
            memcpy(vec.data(), &value, sizeof(int));
            return vec;
        }

        /// <summary>
        /// Adjusts the given value to be within the specified range.
        /// </summary>
        /// <param name="value">
        /// A reference to the value that needs to be checked and adjusted. If the value is less than <paramref name="min"/> 
        /// it will be set to <paramref name="min"/>. If it is greater than <paramref name="max"/> it will be set to <paramref name="max"/>.
        /// </param>
        /// <param name="min">
        /// The minimum allowable value. If <paramref name="value"/> is less than this value, <paramref name="value"/> is set to this minimum value.
        /// </param>
        /// <param name="max">
        /// The maximum allowable value. If <paramref name="value"/> is greater than this value, <paramref name="value"/> is set to this maximum value.
        /// </param>
        static void CheckValue(uint16_t& value, uint16_t min, uint16_t max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
        }
        /// <summary>
        /// Adjusts the given value to be within the specified range.
        /// </summary>
        /// <param name="value">
        /// A reference to the value that needs to be checked and adjusted. If the value is less than <paramref name="min"/> 
        /// it will be set to <paramref name="min"/>. If it is greater than <paramref name="max"/> it will be set to <paramref name="max"/>.
        /// </param>
        /// <param name="min">
        /// The minimum allowable value. If <paramref name="value"/> is less than this value, <paramref name="value"/> is set to this minimum value.
        /// </param>
        /// <param name="max">
        /// The maximum allowable value. If <paramref name="value"/> is greater than this value, <paramref name="value"/> is set to this maximum value.
        /// </param>
        static void CheckValue(double& value, double min, double max)
        {
            if (value < min) value = min;
            if (value > max) value = max;
        }
    };
    /// @endcond
}
