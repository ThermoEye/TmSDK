#pragma once

#ifndef EXTERNC
#define EXTERNC extern "C"
#endif

#if defined(_MSC_VER)
#ifndef DLL_EXPORTS
#define DLL_EXPORTS __declspec(dllexport)
#endif
#elif defined(__GNUC__)
#ifndef DLL_EXPORTS
#define DLL_EXPORTS __attribute((visibility("default")))
#endif
#endif

#ifndef TMAPI
#define TMAPI EXTERNC DLL_EXPORTS
#endif


