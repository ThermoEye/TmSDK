/******************************************************************
 * Project: TmSDK
 * File: RoiManager.cs
 *
 * Description: This file contains the following implementations:
 * - ROI management
 * - Temperature measurement
 *
 * Version: 1.0.0
 * Copyright 2024. Thermoeye Inc. All rights reserved.
 *
 * History:
 *      2024-08-19: Initial version.
 ****************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TmSDK;

namespace TmWinDotNet
{
    public partial class MainForm
    {
        TmRoiManager roiManager = new TmRoiManager();

        private void button_RemoveAllRoi_Click(object sender, EventArgs e)
        {
            roiManager.Clear();
            updateRoiListItems();
        }

        private void updateRoiListItems()
        {
            comboBox_RoiList.Items.Clear();
            comboBox_RoiList.Text = string.Empty;

            var itmes = roiManager.GetItems();
            if (itmes == null) return;

            foreach (var item in itmes)
            {
                TmRoiObject roiObject = new TmRoiObject(item);
                comboBox_RoiList.Items.Add($"ROI{roiObject.GetRoiIndex()}");
            }

            if (roiManager.GetItemCount() > 0)
            {
                comboBox_RoiList.SelectedIndex = 0;
            }
            else
            {
                comboBox_RoiList.SelectedIndex = -1;
            }
        }

        private string GetTempStringUnit(double raw)
        {
            string strTemp = string.Empty;
            if (tmCamera != null && tmCamera.IsOpen)
            {
                switch (tmCamera.TempUnit)
                {
                    case TempUnit.Raw:
                        strTemp = string.Format("{0:0} {1}", raw, tmCamera.TempUnitSymbol);
                        break;

                    case TempUnit.Celsius:
                        strTemp = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(raw), tmCamera.TempUnitSymbol);
                        break;

                    case TempUnit.Fahrenheit:
                        strTemp = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(raw), tmCamera.TempUnitSymbol);
                        break;

                    case TempUnit.Kelvin:
                        strTemp = string.Format("{0:0.00} {1}", tmCamera.GetTemperature(raw), tmCamera.TempUnitSymbol);
                        break;
                }
            }
            return strTemp;
        }

        private void DrawShapeObjects(Bitmap bitmap)
        {
            if (bitmap == null) return;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                if (g == null) return;
                // Draw Roi items
                using (Font font = new Font("Verdana", 7))
                {
                    string strDraw;
                    SizeF sizeDraw;

                    var itmes = roiManager.GetItems();

                    if (itmes == null) return;

                    foreach (var item in itmes)
                    {
                        TmRoiObject roiObject = new TmRoiObject(item);
                        switch (roiObject.GetRoiType())
                        {
                            case TmRoiType.Spot:
                                {
                                    var shape = new TmRoiSpot(item);
                                    var spot = shape.GetSpot();
                                    // draw shape
                                    g.DrawEllipse(new Pen(Color.Cyan, 1), (spot.x - 1), (spot.y - 1), 2, 2);
                                    // draw object id
                                    strDraw = $"ROI{shape.GetRoiIndex()}";
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.Cyan, (spot.x - sizeDraw.Width / 2), (spot.y - 14));
                                    // draw temp
                                    strDraw = GetTempStringUnit(shape.GetMaxLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.Green, (spot.x - sizeDraw.Width / 2), (spot.y + 6));
                                }
                                break;

                            case TmRoiType.Line:
                                {
                                    var shape = new TmRoiLine(item);
                                    var line = shape.GetLine();
                                    // draw shape
                                    g.DrawLine(new Pen(Color.GreenYellow, 1), line.start.x, line.start.y, line.end.x, line.end.y);
                                    // draw object id
                                    strDraw = $"ROI{shape.GetRoiIndex()}";
                                    g.DrawString(strDraw, font, Brushes.Cyan, line.start.x, (line.start.y - 14));
                                    // draw max temp
                                    g.FillPolygon(Brushes.OrangeRed, new Point[] {
                                        new Point(shape.GetMaxLoc().location.x, shape.GetMaxLoc().location.y),
                                        new Point((shape.GetMaxLoc().location.x - 4), (shape.GetMaxLoc().location.y - 4)),
                                        new Point((shape.GetMaxLoc().location.x + 4), (shape.GetMaxLoc().location.y - 4)) });
                                    strDraw = GetTempStringUnit(shape.GetMaxLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.OrangeRed, (shape.GetMaxLoc().location.x - sizeDraw.Width / 2), (shape.GetMaxLoc().location.y - 16));
                                    // draw min temp
                                    g.FillPolygon(Brushes.DodgerBlue, new Point[] {
                                        new Point(shape.GetMinLoc().location.x, shape.GetMinLoc().location.y),
                                        new Point((shape.GetMinLoc().location.x - 4), (shape.GetMinLoc().location.y + 4)),
                                        new Point((shape.GetMinLoc().location.x + 4), (shape.GetMinLoc().location.y + 4)) });
                                    strDraw = GetTempStringUnit(shape.GetMinLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.DodgerBlue, (shape.GetMinLoc().location.x - sizeDraw.Width / 2), (shape.GetMinLoc().location.y + 4));
                                    // draw average temp
                                    strDraw = GetTempStringUnit(shape.GetAvgLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.White,
                                        (line.start.x + (line.end.x - line.start.x) / 2 - sizeDraw.Width / 2),
                                        (line.start.y + (line.end.y - line.start.y) / 2 + 2));
                                }
                                break;

                            case TmRoiType.Rect:
                                {
                                    var shape = new TmRoiRect(item);
                                    var rect = shape.GetRect();
                                    // draw shape
                                    g.DrawRectangle(new Pen(Color.Red, 1), rect.x, rect.y, rect.width, rect.height);
                                    // draw object id
                                    strDraw = $"ROI{shape.GetRoiIndex()}";
                                    g.DrawString(strDraw, font, Brushes.Cyan, rect.x, (rect.y - 14));
                                    // draw max temp
                                    g.FillPolygon(Brushes.OrangeRed, new Point[] {
                                        new Point(shape.GetMaxLoc().location.x, shape.GetMaxLoc().location.y),
                                        new Point((shape.GetMaxLoc().location.x - 4), (shape.GetMaxLoc().location.y - 4)),
                                        new Point((shape.GetMaxLoc().location.x + 4), (shape.GetMaxLoc().location.y - 4)) });
                                    strDraw = GetTempStringUnit(shape.GetMaxLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.OrangeRed, (shape.GetMaxLoc().location.x - sizeDraw.Width / 2), (shape.GetMaxLoc().location.y - 16));
                                    // draw min temp
                                    g.FillPolygon(Brushes.DodgerBlue, new Point[] {
                                        new Point(shape.GetMinLoc().location.x, shape.GetMinLoc().location.y),
                                        new Point((shape.GetMinLoc().location.x - 4), (shape.GetMinLoc().location.y + 4)),
                                        new Point((shape.GetMinLoc().location.x + 4), (shape.GetMinLoc().location.y + 4)) });
                                    strDraw = GetTempStringUnit(shape.GetMinLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.DodgerBlue, (shape.GetMinLoc().location.x - sizeDraw.Width / 2), (shape.GetMinLoc().location.y + 4));
                                    // draw average temp
                                    strDraw = GetTempStringUnit(shape.GetAvgLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.White,
                                        (rect.x + rect.width / 2 - sizeDraw.Width / 2),
                                        (rect.y + rect.height + 2));
                                }
                                break;

                            case TmRoiType.Ellipse:
                                {
                                    var shape = new TmRoiEllipse(item);
                                    var ellipse = shape.GetEllipse();
                                    // draw shape
                                    g.DrawEllipse(new Pen(Color.DarkOrange, 1), ellipse.x, ellipse.y, ellipse.width, ellipse.height);
                                    // draw object id
                                    strDraw = $"ROI{shape.GetRoiIndex()}";
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.Cyan, (ellipse.x + ellipse.width / 2 - sizeDraw.Width / 2), (ellipse.y - 14));
                                    // draw max temp
                                    g.FillPolygon(Brushes.OrangeRed, new Point[] {
                                        new Point(shape.GetMaxLoc().location.x, shape.GetMaxLoc().location.y),
                                        new Point((shape.GetMaxLoc().location.x - 4), (shape.GetMaxLoc().location.y - 4)),
                                        new Point((shape.GetMaxLoc().location.x + 4), (shape.GetMaxLoc().location.y - 4)) });
                                    strDraw = GetTempStringUnit(shape.GetMaxLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.OrangeRed, (shape.GetMaxLoc().location.x - sizeDraw.Width / 2), (shape.GetMaxLoc().location.y - 16));
                                    // draw min temp
                                    g.FillPolygon(Brushes.DodgerBlue, new Point[] {
                                        new Point(shape.GetMinLoc().location.x, shape.GetMinLoc().location.y),
                                        new Point((shape.GetMinLoc().location.x - 4), (shape.GetMinLoc().location.y + 4)),
                                        new Point((shape.GetMinLoc().location.x + 4), (shape.GetMinLoc().location.y + 4)) });
                                    strDraw = GetTempStringUnit(shape.GetMinLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.DodgerBlue, (shape.GetMinLoc().location.x - sizeDraw.Width / 2), (shape.GetMinLoc().location.y + 4));
                                    // draw average temp
                                    strDraw = GetTempStringUnit(shape.GetAvgLoc().value);
                                    sizeDraw = g.MeasureString(strDraw, font);
                                    g.DrawString(strDraw, font, Brushes.White,
                                        (ellipse.x + ellipse.width / 2 - sizeDraw.Width / 2),
                                        (ellipse.y + ellipse.height + 2));
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void radioButton_Shape_Selected(object sender, EventArgs e)
        {
            if (sender is RadioButton btn && btn.Checked == true)
            {
                switch (btn.Name)
                {
                    case "radioButton_ShapeCursor":
                        roiManager.SetSelectedRoiType(TmRoiType.Hand);
                        break;

                    case "radioButton_ShapeSpot":
                        roiManager.SetSelectedRoiType(TmRoiType.Spot);
                        break;

                    case "radioButton_ShapeLine":
                        roiManager.SetSelectedRoiType(TmRoiType.Line);
                        break;

                    case "radioButton_ShapeRectangle":
                        roiManager.SetSelectedRoiType(TmRoiType.Rect);
                        break;

                    case "radioButton_ShapeEllipse":
                        roiManager.SetSelectedRoiType(TmRoiType.Ellipse);
                        break;
                }
            }
        }

        private void pictureBox_Preview_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox box)
            {
                if (e.Button == MouseButtons.Left)
                {
                    TmPoint pt;
                    pt.x = e.X;
                    pt.y = e.Y;
                    roiManager.MouseDown(pt);
                }
            }
        }
        private void pictureBox_Preview_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox box)
            {
                if (e.Button == MouseButtons.Left)
                {
                    TmPoint pt;
                    pt.x = e.X;
                    pt.y = e.Y;
                    if (roiManager.MouseMove(pt)) box.Refresh();
                }
            }
        }
        private void pictureBox_Preview_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox box)
            {
                if (e.Button == MouseButtons.Left)
                {
                    TmPoint pt;
                    pt.x = e.X;
                    pt.y = e.Y;
                    if (roiManager.MouseUp(pt))
                    {
                        radioButton_ShapeCursor.Checked = true;
                        updateRoiListItems();
                    }
                }
            }
        }

        private void pictureBox_Preview_Paint(object sender, PaintEventArgs e)
        {
            var item = roiManager.SelectedItem();
            if (e != null && item != null)
            {
                // mouse drawing...
                if (item != null)
                {
                    using (Pen pen = new Pen(Color.Yellow, 1))
                    {
                        switch (roiManager.GetSelectedRoiType())
                        {
                            case TmRoiType.Hand:
                                break;

                            case TmRoiType.Spot:
                                {
                                    var shape = new TmRoiSpot(item);
                                    var spot = shape.GetSpot();
                                    e.Graphics.DrawEllipse(pen, spot.x - 1, spot.y - 1, 2, 2);
                                }
                                break;

                            case TmRoiType.Line:
                                {
                                    var shape = new TmRoiLine(item);
                                    var line = shape.GetLine();
                                    e.Graphics.DrawLine(pen, line.start.x, line.start.y, line.end.x, line.end.y);
                                }
                                break;

                            case TmRoiType.Rect:
                                {
                                    var shape = new TmRoiRect(item);
                                    var rect = shape.GetRect();
                                    e.Graphics.DrawRectangle(pen, rect.x, rect.y, rect.width, rect.height);
                                }
                                break;

                            case TmRoiType.Ellipse:
                                {
                                    var shape = new TmRoiEllipse(item);
                                    var ellipse = shape.GetEllipse();
                                    e.Graphics.DrawEllipse(pen, ellipse.x, ellipse.y, ellipse.width, ellipse.height);
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void comboBox_ListROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox box && box.SelectedIndex >= 0)
            {
                var item = roiManager.GetItem(box.SelectedIndex);

                textBox_RoiSpotX.Text = String.Empty;
                textBox_RoiSpotY.Text = String.Empty;
                textBox_RoiLineX1.Text = String.Empty;
                textBox_RoiLineY1.Text = String.Empty;
                textBox_RoiLineX2.Text = String.Empty;
                textBox_RoiLineY2.Text = String.Empty;

                textBox_RoiRectX.Text = String.Empty;
                textBox_RoiRectY.Text = String.Empty;
                textBox_RoiRectW.Text = String.Empty;
                textBox_RoiRectH.Text = String.Empty;

                textBox_RoiEllipseX.Text = String.Empty;
                textBox_RoiEllipseY.Text = String.Empty;
                textBox_RoiEllipseW.Text = String.Empty;
                textBox_RoiEllipseH.Text = String.Empty;

                var roi = new TmRoiObject(item);
                var type = roi.GetRoiType();
                switch (type)
                {
                    case TmRoiType.Spot:
                        {
                            var roiSpot = new TmRoiSpot(item);
                            var spot = roiSpot.GetSpot();
                            textBox_RoiSpotX.Text = spot.x.ToString();
                            textBox_RoiSpotY.Text = spot.y.ToString();

                            rbtn_RoiSpot.Checked = true;
                        }
                        break;
                    case TmRoiType.Line:
                        {
                            var roiLine = new TmRoiLine(item);
                            var line = roiLine.GetLine();
                            textBox_RoiLineX1.Text = line.start.x.ToString();
                            textBox_RoiLineY1.Text = line.start.y.ToString();
                            textBox_RoiLineX2.Text = line.end.x.ToString();
                            textBox_RoiLineY2.Text = line.end.y.ToString();
                            rbtn_RoiLine.Checked = true;
                        }
                        break;
                    case TmRoiType.Rect:
                        {
                            var roiRect = new TmRoiRect(item);
                            var rect = roiRect.GetRect();
                            textBox_RoiRectX.Text = rect.x.ToString();
                            textBox_RoiRectY.Text = rect.y.ToString();
                            textBox_RoiRectW.Text = rect.width.ToString();
                            textBox_RoiRectH.Text = rect.height.ToString();
                            rbtn_RoiRect.Checked = true;
                        }
                        break;
                    case TmRoiType.Ellipse:
                        {
                            var roiEllipse = new TmRoiEllipse(item);
                            var ellipse = roiEllipse.GetEllipse();
                            textBox_RoiEllipseX.Text = ellipse.x.ToString();
                            textBox_RoiEllipseY.Text = ellipse.y.ToString();
                            textBox_RoiEllipseW.Text = ellipse.width.ToString();
                            textBox_RoiEllipseH.Text = ellipse.height.ToString();
                            rbtn_RoiEllipse.Checked = true;
                        }
                        break;
                }
            }
        }

        private void button_AddRoiItem_Click(object sender, EventArgs e)
        {
            if (rbtn_RoiSpot.Checked == true)
            {
                if (!int.TryParse(textBox_RoiSpotX.Text, out int spotX)) return;
                if (!int.TryParse(textBox_RoiSpotY.Text, out int spotY)) return;
                roiManager.AddItem(TmRoiType.Spot, spotX, spotY);
                updateRoiListItems();
            }
            else if (rbtn_RoiLine.Checked == true)
            {
                if (!int.TryParse(textBox_RoiLineX1.Text, out int x1)) return;
                if (!int.TryParse(textBox_RoiLineY1.Text, out int y1)) return;
                if (!int.TryParse(textBox_RoiLineX2.Text, out int x2)) return;
                if (!int.TryParse(textBox_RoiLineY2.Text, out int y2)) return;
                roiManager.AddItem(TmRoiType.Line, x1, y1, x2, y2);
                updateRoiListItems();
            }
            else if (rbtn_RoiRect.Checked == true)
            {
                if (!int.TryParse(textBox_RoiRectX.Text, out int x)) return;
                if (!int.TryParse(textBox_RoiRectY.Text, out int y)) return;
                if (!int.TryParse(textBox_RoiRectW.Text, out int w)) return;
                if (!int.TryParse(textBox_RoiRectH.Text, out int h)) return;
                roiManager.AddItem(TmRoiType.Rect, x, y, w, h);
                updateRoiListItems();
            }
            else if (rbtn_RoiEllipse.Checked == true)
            {
                if (!int.TryParse(textBox_RoiEllipseX.Text, out int x)) return;
                if (!int.TryParse(textBox_RoiEllipseY.Text, out int y)) return;
                if (!int.TryParse(textBox_RoiEllipseW.Text, out int w)) return;
                if (!int.TryParse(textBox_RoiEllipseH.Text, out int h)) return;
                roiManager.AddItem(TmRoiType.Ellipse, x, y, w, h);
                updateRoiListItems();
            }
        }

        private void button_RemoveRoiItem_Click(object sender, EventArgs e)
        {
            if (comboBox_RoiList.SelectedIndex >= 0)
            {
                if (roiManager.GetItemCount() == 0) return;

                roiManager.RemoveAt(comboBox_RoiList.SelectedIndex);
                updateRoiListItems();
            }
        }
    }
}
