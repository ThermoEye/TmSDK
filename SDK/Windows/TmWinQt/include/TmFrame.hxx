#pragma once

#include "TmShared.hxx"
//#include "TmROI.hxx"
#include "TmRoiShapes.hxx"

namespace TmSDK
{
	enum class ColormapTypes
	{
		GrayScale = -1,
		Autumn = 0,
		Bone = 1,
		Jet = 2,
		Winter = 3,
		Rainbow = 4,
		Ocean = 5,
		Summer = 6,
		Spring = 7,
		Cool = 8,
		Hsv = 9,
		Pink = 10,
		Hot = 11,
		Parula = 12,
		Magma = 13,
		Inferno = 14,
		Plasma = 15,
		Viridis = 16,
		Cividis = 17,
		Twilight = 18,
		TwilightShifted = 19,
		Turbo = 20,
		DeepGreen = 21
	};

	enum class TempUnit
	{
		RAW = 0,
		CELSIUS = 1,
		FAHRENHEIT = 2,
		KELVIN = 3
	};

	enum class ColorOrder
	{
		COLOR_BGR = 0,
		COLOR_RGB = 1
	};

	/// <summary>
	/// Class representing a frame of image data.
	/// </summary>
	class DLL_EXPORTS TmFrame
	{
	public:
		int width = -1;
		int height = -1;
		ColormapTypes colorMap = ColormapTypes::GrayScale;
		bool noiseFiltering = false;

		void* rawFrame = nullptr;
		void* bmpFrame = nullptr;

		TmFrame();
		TmFrame(ColormapTypes colorMap, bool noiseFilter = false);
		virtual ~TmFrame();
		/// <summary>
		/// Checks if the pointer used for holding frame data is null.
		/// </summary>
		/// <returns>
		/// true if the pointer is nullptr; otherwise, false.
		/// </returns>
		bool IsEmpty() { return rawFrame == nullptr ? true : false; }
		bool MinMaxLoc(double& minVal, double& avgVal, double& maxVal, Point& minLoc, Point& maxLoc);
		uint8_t* ToBitmap(ColorOrder colorOrder = ColorOrder::COLOR_BGR);
		bool SetColorMap(ColormapTypes color);
		bool SetNoiseFilter(bool filter);
		void DoMeasure(RoiObject& item);
		void DoMeasure(std::vector<RoiObject*>& items);
		void Release();
		int Width();
		int Height();
	};
}

