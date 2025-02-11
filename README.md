# TmSDK

This project is a SDK for controlling TMC80/160/256 cameras.
After downloading the code, please refer to the **'Document/TmSDK Manual.pdf'** file.

## Directory
```
├─Document                  ; API Documentation and User Manual
│  └─API
│      ├─Cpp                ; C++ API
│      ├─CSharp             ; C# API
│      └─Python             ; Python API
├─Firmware                  ; TMCxxx firmware files
└─SDK                       ; TmSDK library and sample code
    ├─App                   ; 
    │  ├─Cpp                ; C++ program executable on Windows OS
    │  └─CSharp             ; C# program executable on Windows OS
    ├─Linux
    │  ├─TmLinux            ; Qt5-based C++ application for Linux
    │  └─TmPython           ; Python application for Linux
    └─Windows
        ├─TmPython          ; Python application for Windows
        ├─TmWinDotNet       ; C# application for Windows
        ├─TmWinQt           ; Qt5-based C++ application for Windows
        └─TmWinQtSimple     ; C++ application without installing Qt5
```
## Requirement

Windows C++
- Windows 10 or 11
- Visual Studio 2022
- Qt5.14.2
- qtcreator

Windows C#
- Windows 10 or 11
- Visual Studio 2022

Windows Python
- Windows 10 or 11
- Visual Studio 2022 (optional)
- Python 3.9 or later versions
- PyQt5
- qtcreator

Linux C++
- Ubuntu 20.04 or later versions 
- Gcc-11
- Qt5.14.2
- qtcreator

Linux Python
- Ubuntu 20.04 or later versions
- Python 3.9 or later versions
- PyQt5
- qtcreator

## Downloads

```
git clone https://github.com/ThermoEye/TmSDK
```
or

Download from [releases](https://github.com/ThermoEye/TmSDK/releases)

## Installing

Please refer to [TmSDK Manual.pdf](https://github.com/ThermoEye/TmSDK/blob/main/Document/TmSDK%20Manual.pdf)

## Support

Thermoeye Inc. operates service channels to keep your camera running at all times. 
If you discover a problem with your camera, please get in touch with us for technical support.

- Website: [www.thermoeye.co.kr](http://www.thermoeye.co.kr)
- E-mail: help@thermoeye.co.kr
- Tel: +82-70-4489-6196
- Head Office: 307, Research Building 3, 70, Yuseong-daero 1689 beon-gil, Yuseong-gu, Daejeon, Republic of Korea
- Seoul R&D: 4~5F, 169 Sadang-ro, Dongjak-gu, Seoul, Republic of Korea
