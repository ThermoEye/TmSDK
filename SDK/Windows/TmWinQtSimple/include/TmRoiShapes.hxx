#pragma once
#include<vector>
#include <iostream>

namespace TmSDK
{
    /// <summary>
    /// A structure to represent a point in 2D space
    /// </summary>
    struct Point
    {
        /// <summary>
        /// X coordinate of the point.
        /// </summary>
        int X = -1;
        /// <summary>
        /// Y coordinate of the point.
        /// </summary>
        int Y = -1;
        /// <summary>
        /// Constructor of Point.
        /// </summary>
        Point(int x = -1, int y = -1) : X(x), Y(y) {}
    };

    /// <summary>
    /// ROI location and temperature value
    /// </summary>
    struct LocItem
    {
        /// <summary>
        /// Temperature value
        /// </summary>
        double Value = 0.0;
        /// <summary>
        /// Location coordinates
        /// </summary>
        Point Location;
    };

    /// <summary>
    /// A structure to represent a rectangle in 2D space
    /// </summary>
    struct Rectangle
    {
        /// <summary>
        /// X coordinate of the top-left corner of the rectangle.
        /// </summary>
        int X = -1;
        /// <summary>
        /// Y coordinate of the top-left corner of the rectangle.
        /// </summary>
        int Y = -1;
        /// <summary>
        /// Width of the rectangle.
        /// </summary>
        int Width = 0;
        /// <summary>
        /// Height of the rectangle.
        /// </summary>
        int Height = 0;
    };

    /// <summary>
    /// ROI types
    /// </summary>
    enum class RoiType : int
    {
        Hand = 0,
        Spot = 1,
        Line = 2,
        Rect = 3,
        Ellipse = 4,
    };

    /// <summary>
    /// Abstract class for ROI object
    /// </summary>
    class RoiObject
    {
    public:
        /// <summary>
        /// ROI object index
        /// </summary>
        int Index;
        /// <summary>
        /// ROI type, Hand=0 / Spot=1 / Line=2 / Rect=3 / Ellipse=4
        /// </summary>
        RoiType Type;
        /// <summary>
        /// Location for minimum temperature in ROI
        /// </summary>
        LocItem MinLoc;
        /// <summary>
        /// Location for average temperature in ROI
        /// </summary>
        LocItem AvgLoc;
        /// <summary>
        /// Location for maximum temperature in ROI
        /// </summary>
        LocItem MaxLoc;
    };

    /// <summary>
    /// Inheritance class for Spot type ROI
    /// </summary>
    class RoiSpot : public RoiObject
    {
    public:
        /// <summary>
        /// Coordinates of Spot
        /// </summary>
        Point Spot;
        /// <summary>
        /// Constructor of RoiSpot
        /// </summary>
        RoiSpot()
        {
            Type = RoiType::Spot;
        }
        /// <summary>
        /// Constructor of RoiSpot
        /// </summary>
        /// <param name="index">object index</param>
        RoiSpot(int index)
        {
            Type = RoiType::Spot;
            Index = index;
        }
        /// <summary>
        /// Constructor of RoiSpot
        /// </summary>
        /// <param name="spot">point coordinates</param>
        RoiSpot(Point spot)
        {
            Type = RoiType::Spot;
            Spot = spot;
        }
        /// <summary>
        /// Constructor of RoiSpot
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        RoiSpot(int x, int y)
        {
            Type = RoiType::Spot;
            Spot.X = x;
            Spot.Y = y;
        }
        /// <summary>
        /// Constructor of RoiSpot
        /// </summary>
        /// <param name="index">object index</param>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        RoiSpot(int index, int x, int y)
        {
            Type = RoiType::Spot;
            Index = index;
            Spot.X = x;
            Spot.Y = y;
        }
    };

    /// <summary>
    /// Inheritance class for Line type ROI
    /// </summary>
    class RoiLine : public RoiObject
    {
    public:
        /// <summary>
        /// Start coordinates of Line
        /// </summary>
        Point Start;
        /// <summary>
        /// End coordinates of Line
        /// </summary>
        Point End;
        /// <summary>
        /// Constructor of RoiLine
        /// </summary>
        RoiLine()
        {
            Type = RoiType::Line;
        }
        /// <summary>
        /// Constructor of RoiLine
        /// </summary>
        /// <param name="index">object index</param>
        RoiLine(int index)
        {
            Type = RoiType::Line;
            Index = index;
        }
        /// <summary>
        /// Constructor of RoiLine
        /// </summary>
        /// <param name="start">start point coordinates</param>
        /// <param name="end">end point coordinates</param>
        RoiLine(Point start, Point end)
        {
            Type = RoiType::Line;
            Start = start;
            End = end;
        }
        /// <summary>
        /// Constructor of RoiLine
        /// </summary>
        /// <param name="startX">start x-coordinate</param>
        /// <param name="startY">start y-coordinate</param>
        /// <param name="endX">end x-coordinate</param>
        /// <param name="endY">end y-coordinate</param>
        RoiLine(int startX, int startY, int endX, int endY)
        {
            Type = RoiType::Line;
            Start.X = startX;
            Start.Y = startY;
            End.X = endX;
            End.Y = endY;
        }
        /// <summary>
        /// Constructor of RoiLine
        /// </summary>
        /// <param name="index">object index</param>
        /// <param name="startX">start x-coordinate</param>
        /// <param name="startY">start y-coordinate</param>
        /// <param name="endX">end x-coordinate</param>
        /// <param name="endY">end y-coordinate</param>
        RoiLine(int index, int startX, int startY, int endX, int endY)
        {
            Type = RoiType::Line;
            Index = index;
            Start.X = startX;
            Start.Y = startY;
            End.X = endX;
            End.Y = endY;
        }
    };

    /// <summary>
    /// Inheritance class for Rectangle type ROI
    /// </summary>
    class RoiRect : public RoiObject
    {
    public:
        /// <summary>
        /// Location and size of Rectangle
        /// </summary>
        Rectangle Rect;

        /// <summary>
        /// Constructor of RoiRect
        /// </summary>
        RoiRect()
        {
            Type = RoiType::Rect;
        }
        
        /// <summary>
        /// Constructor of RoiRect
        /// </summary>
        /// <param name="index">object index</param>
        RoiRect(int index)
        {
            Type = RoiType::Rect;
            Index = index;
        }
        
        /// <summary>
        /// Constructor of RoiRect
        /// </summary>
        /// <param name="rect">rectangle location and size</param>
        RoiRect(Rectangle rect)
        {
            Type = RoiType::Rect;
            Rect = rect;
        }
        
        /// <summary>
        /// Constructor of RoiRect
        /// </summary>
        /// <param name="x">start x-coordinate</param>
        /// <param name="y">start y-coordinate</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        RoiRect(int x, int y, int width, int height)
        {
            Type = RoiType::Rect;
            Rect.X = x;
            Rect.Y = y;
            Rect.Width = width;
            Rect.Height = height;
        }
        
        /// <summary>
        /// Constructor of RoiRect
        /// </summary>
        /// <param name="index">object index</param>
        /// <param name="x">start x-coordinate</param>
        /// <param name="y">start y-coordinate</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        RoiRect(int index, int x, int y, int width, int height)
        {
            Type = RoiType::Rect;
            Index = index;
            Rect.X = x;
            Rect.Y = y;
            Rect.Width = width;
            Rect.Height = height;
        }
    };

    /// <summary>
    /// Inheritance class for Ellipse type ROI
    /// </summary>
    class RoiEllipse : public RoiObject
    {
    public:
        /// <summary>
        /// Location and size of Ellipse
        /// </summary>
        Rectangle Ellipse;
    
        /// <summary>
        /// Constructor of RoiEllipse
        /// </summary>
        RoiEllipse()
        {
            Type = RoiType::Ellipse;
        }
        
        /// <summary>
        /// Constructor of RoiEllipse
        /// </summary>
        /// <param name="index">object index</param>
        RoiEllipse(int index)
        {
            Type = RoiType::Ellipse;
            Index = index;
        }
        
        /// <summary>
        /// Constructor of RoiEllipse
        /// </summary>
        /// <param name="rect">ellipse location and size</param>
        RoiEllipse(Rectangle rect)
        {
            Type = RoiType::Ellipse;
            Ellipse = rect;
        }
        
        /// <summary>
        /// Constructor of RoiEllipse
        /// </summary>
        /// <param name="x">start x-coordinate</param>
        /// <param name="y">start y-coordinate</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        RoiEllipse(int x, int y, int width, int height)
        {
            Type = RoiType::Ellipse;
            Ellipse.X = x;
            Ellipse.Y = y;
            Ellipse.Width = width;
            Ellipse.Height = height;
        }
        
        /// <summary>
        /// Constructor of RoiEllipse
        /// </summary>
        /// <param name="index">object index</param>
        /// <param name="x">start x-coordinate</param>
        /// <param name="y">start y-coordinate</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        RoiEllipse(int index, int x, int y, int width, int height)
        {
            Type = RoiType::Ellipse;
            Index = index;
            Ellipse.X = x;
            Ellipse.Y = y;
            Ellipse.Width = width;
            Ellipse.Height = height;
        }
    };
}