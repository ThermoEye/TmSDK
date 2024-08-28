#pragma once
#include "TmRoiShapes.hxx"

namespace TmSDK
{
	/// <summary>
	/// Manages a collection of ROI (Region of Interest) objects and handles user interactions for creating and manipulating them.
	/// </summary>
	class TmRoiManager
	{
	private:
		/// <summary>
		/// Indicates whether the mouse button is currently pressed.
		/// </summary>
		bool isMousePressed = false;
		/// <summary>
		/// The currently selected ROI type.
		/// </summary>
		RoiType selectedType = RoiType::Hand;
		/// <summary>
		/// Pointer to the currently selected ROI object.
		/// </summary>
		RoiObject* pSelectedObj = nullptr;

	public:
		/// <summary>
		/// The number of ROI objects managed by this instance.
		/// </summary>
		int roiCount = 0;
		/// <summary>
		/// A vector containing all ROI objects.
		/// </summary>
		std::vector<RoiObject*> Items;
		/// <summary>
		/// Gets the currently selected ROI type.
		/// </summary>
		/// <returns>The currently selected ROI type.</returns>
		RoiType GetSelectedRoiType()
		{
			return selectedType;
		}
		/// <summary>
		/// Sets the selected ROI type and creates a new ROI object of that type.
		/// </summary>
		/// <param name="type">The ROI type to be selected.</param>
		void SetSelectedRoiType(RoiType type)
		{
			selectedType = type;
			switch (type)
			{
			case RoiType::Hand:
				pSelectedObj = nullptr;
				break;
			case RoiType::Spot:
				pSelectedObj = new RoiSpot(roiCount);
				break;
			case RoiType::Line:
				pSelectedObj = new RoiLine(roiCount);
				break;
			case RoiType::Rect:
				pSelectedObj = new RoiRect(roiCount);
				break;
			case RoiType::Ellipse:
				pSelectedObj = new RoiEllipse(roiCount);
				break;
			}
		}
		/// <summary>
		/// Gets the currently selected ROI object.
		/// </summary>
		/// <returns>A pointer to the currently selected ROI object, or nullptr if no ROI is selected.</returns>
		RoiObject* SelectedItem()
		{
			return pSelectedObj;
		}
		/// <summary>
		/// Clears all ROI objects and resets the manager's state.
		/// </summary>
		/// <returns>True if the clearing was successful.</returns>
		bool Clear()
		{
			for (RoiObject* item : Items) 
			{
				delete item;
			}
			Items.clear();
			roiCount = 0;
			pSelectedObj = nullptr;
			selectedType = RoiType::Hand;
			return true;
		}
		/// <summary>
		/// Handles mouse down events to initialize the drawing of an ROI.
		/// </summary>
		/// <param name="pt">The point where the mouse was pressed.</param>
		/// <returns>True if the mouse down event was successfully handled.</returns>
		bool MouseDown(Point pt)
		{
			if (pSelectedObj == nullptr)
			{
				return false;
			}

			isMousePressed = true;

			switch (pSelectedObj->Type)
			{
			case RoiType::Spot:
				((RoiSpot*)pSelectedObj)->Spot = pt;
				break;

			case RoiType::Line:
				((RoiLine*)pSelectedObj)->Start = pt;
				((RoiLine*)pSelectedObj)->End = pt;
				break;

			case RoiType::Rect:
				((RoiRect*)pSelectedObj)->Rect.X = pt.X;
				((RoiRect*)pSelectedObj)->Rect.Y = pt.Y;
				((RoiRect*)pSelectedObj)->Rect.Width = 0;
				((RoiRect*)pSelectedObj)->Rect.Height = 0;
				break;

			case RoiType::Ellipse:
				((RoiEllipse*)pSelectedObj)->Ellipse.X = pt.X;
				((RoiEllipse*)pSelectedObj)->Ellipse.Y = pt.Y;
				break;
			}

			return true;
		}

		/// <summary>
		/// Handles mouse move events to update the current ROI being drawn.
		/// </summary>
		/// <param name="pt">The point where the mouse is moving.</param>
		/// <returns>True if the mouse move event was successfully handled.</returns>
		bool MouseMove(Point pt)
		{
			if (pSelectedObj == nullptr) return false;

			//if (e.Button == MouseButtons.Left && isMousePressed == true)
			if (isMousePressed == true)
			{
				switch (pSelectedObj->Type)
				{
				case RoiType::Spot:
					((RoiSpot*)pSelectedObj)->Spot = pt;
					break;

				case RoiType::Line:
					((RoiLine*)pSelectedObj)->End = pt;
					break;

				case RoiType::Rect:
				{
					RoiRect* shape = (RoiRect*)pSelectedObj;
					shape->Rect.Width = max(shape->Rect.X, pt.X) - min(shape->Rect.X, pt.X);
					shape->Rect.Height = max(shape->Rect.Y, pt.Y) - min(shape->Rect.Y, pt.Y);
				}
				break;

				case RoiType::Ellipse:
				{
					RoiEllipse* shape = (RoiEllipse*)pSelectedObj;
					shape->Ellipse.Width = max(shape->Ellipse.X, pt.X) - min(shape->Ellipse.X, pt.X);
					shape->Ellipse.Height = max(shape->Ellipse.Y, pt.Y) - min(shape->Ellipse.Y, pt.Y);
				}
				break;
				}

				return true;
			}

			return false;
		}

		/// <summary>
		/// Handles mouse up events to finalize the drawing of an ROI.
		/// </summary>
		/// <param name="pt">The point where the mouse was released.</param>
		/// <returns>True if the mouse up event was successfully handled.</returns>
		bool MouseUp(Point pt)
		{
			if (pSelectedObj == nullptr)
			{
				return false;
			}

			if (isMousePressed == true)
			{
				Items.push_back(pSelectedObj);

				pSelectedObj = nullptr;
				isMousePressed = false;
				roiCount++;     // increase number for next item

				return true;
			}

			return false;
		}

		/// <summary>
		/// Adds a new ROI object of type `Spot` to the manager.
		/// </summary>
		/// <param name="type">The type of ROI to add.</param>
		/// <param name="x">The x-coordinate of the ROI.</param>
		/// <param name="y">The y-coordinate of the ROI.</param>
		/// <returns>True if the ROI was successfully added.</returns>
		bool AddItem(RoiType type, int x, int y)
		{
			switch (type)
			{
			case RoiType::Spot:
				Items.push_back(new RoiSpot(roiCount, x, y));
				roiCount++;
				break;
			}
			return true;
		}

		/// <summary>
		/// Adds a new ROI object of types `Line`, `Rect`, or `Ellipse` to the manager.
		/// </summary>
		/// <param name="type">The type of ROI to add.</param>
		/// <param name="x">The x-coordinate of the ROI.</param>
		/// <param name="y">The y-coordinate of the ROI.</param>
		/// <param name="w">The width of the ROI.</param>
		/// <param name="h">The height of the ROI.</param>
		/// <returns>True if the ROI was successfully added.</returns>
		bool AddItem(RoiType type, int x, int y, int w, int h)
		{
			switch (type)
			{
			case RoiType::Line:
				Items.push_back(new RoiLine(roiCount, x, y, w, h));
				roiCount++;
				break;
			case RoiType::Rect:
				Items.push_back(new RoiRect(roiCount, x, y, w, h));
				roiCount++;
				break;
			case RoiType::Ellipse:
				Items.push_back(new RoiEllipse(roiCount, x, y, w, h));
				roiCount++;
				break;
			}
			return true;
		}

		/// <summary>
		/// Removes an ROI object at the specified index.
		/// </summary>
		/// <param name="index">The index of the ROI to remove.</param>
		/// <returns>True if the ROI was successfully removed.</returns>
		bool RemoveAt(int index)
		{
			if (index < 0 || index >= roiCount)
				return false;
			Items.erase(Items.begin() + index);
			roiCount--;
			return true;
		}
	};
}