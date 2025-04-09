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
            comboBox_ListROI.Items.Clear();
            comboBox_ListROI.Text = string.Empty;

            var itmes = roiManager.GetItems();
            if (itmes == null) return;

            foreach (var item in itmes)
            {
                TmRoiObject roiObject = new TmRoiObject(item);
                comboBox_ListROI.Items.Add($"ROI{roiObject.GetRoiIndex()}");
            }

            if (roiManager.GetItemCount() > 0)
            {
                comboBox_ListROI.SelectedIndex = 0;
            }
            else
            {
                comboBox_ListROI.SelectedIndex = -1;
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

        private void comboBox_ListROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox box && box.SelectedIndex >= 0)
            {
                var item = roiManager.GetItem(box.SelectedIndex);

                textBox_spotX.Text = String.Empty;
                textBox_spotY.Text = String.Empty;
                textBox_lineX1.Text = String.Empty;
                textBox_lineY1.Text = String.Empty;
                textBox_lineX2.Text = String.Empty;
                textBox_lineY2.Text = String.Empty;

                textBox_rectX.Text = String.Empty;
                textBox_rectY.Text = String.Empty;
                textBox_rectW.Text = String.Empty;
                textBox_rectH.Text = String.Empty;

                textBox_ellipseX.Text = String.Empty;
                textBox_ellipseY.Text = String.Empty;
                textBox_ellipseW.Text = String.Empty;
                textBox_ellipseH.Text = String.Empty;

                var roi = new TmRoiObject(item);
                var type = roi.GetRoiType();
                switch (type)
                {
                    case TmRoiType.Spot:
                        {
                            var roiSpot = new TmRoiSpot(item);
                            var spot = roiSpot.GetSpot();
                            textBox_spotX.Text = spot.x.ToString();
                            textBox_spotY.Text = spot.y.ToString();

                            rbtn_RoiSpot.Checked = true;
                        }
                        break;
                    case TmRoiType.Line:
                        {
                            var roiLine = new TmRoiLine(item);
                            var line = roiLine.GetLine();
                            textBox_lineX1.Text = line.start.x.ToString();
                            textBox_lineY1.Text = line.start.y.ToString();
                            textBox_lineX2.Text = line.end.x.ToString();
                            textBox_lineY2.Text = line.end.y.ToString();
                            rbtn_RoiLine.Checked = true;
                        }
                        break;
                    case TmRoiType.Rect:
                        {
                            var roiRect = new TmRoiRect(item);
                            var rect = roiRect.GetRect();
                            textBox_rectX.Text = rect.x.ToString();
                            textBox_rectY.Text = rect.y.ToString();
                            textBox_rectW.Text = rect.width.ToString();
                            textBox_rectH.Text = rect.height.ToString();
                            rbtn_RoiRect.Checked = true;
                        }
                        break;
                    case TmRoiType.Ellipse:
                        {
                            var roiEllipse = new TmRoiEllipse(item);
                            var ellipse = roiEllipse.GetEllipse();
                            textBox_ellipseX.Text = ellipse.x.ToString();
                            textBox_ellipseY.Text = ellipse.y.ToString();
                            textBox_ellipseW.Text = ellipse.width.ToString();
                            textBox_ellipseH.Text = ellipse.height.ToString();
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
                if (!int.TryParse(textBox_spotX.Text, out int spotX)) return;
                if (!int.TryParse(textBox_spotY.Text, out int spotY)) return;
                roiManager.AddItem(TmRoiType.Spot, spotX, spotY);
                updateRoiListItems();
            }
            else if (rbtn_RoiLine.Checked == true)
            {
                if (!int.TryParse(textBox_lineX1.Text, out int x1)) return;
                if (!int.TryParse(textBox_lineY1.Text, out int y1)) return;
                if (!int.TryParse(textBox_lineX2.Text, out int x2)) return;
                if (!int.TryParse(textBox_lineY2.Text, out int y2)) return;
                roiManager.AddItem(TmRoiType.Line, x1, y1, x2, y2);
                updateRoiListItems();
            }
            else if (rbtn_RoiRect.Checked == true)
            {
                if (!int.TryParse(textBox_rectX.Text, out int x)) return;
                if (!int.TryParse(textBox_rectY.Text, out int y)) return;
                if (!int.TryParse(textBox_rectW.Text, out int w)) return;
                if (!int.TryParse(textBox_rectH.Text, out int h)) return;
                roiManager.AddItem(TmRoiType.Rect, x, y, w, h);
                updateRoiListItems();
            }
            else if (rbtn_RoiEllipse.Checked == true)
            {
                if (!int.TryParse(textBox_ellipseX.Text, out int x)) return;
                if (!int.TryParse(textBox_ellipseY.Text, out int y)) return;
                if (!int.TryParse(textBox_ellipseW.Text, out int w)) return;
                if (!int.TryParse(textBox_ellipseH.Text, out int h)) return;
                roiManager.AddItem(TmRoiType.Ellipse, x, y, w, h);
                updateRoiListItems();
            }
        }

        private void button_RemoveRoiItem_Click(object sender, EventArgs e) 
        {
            if (comboBox_ListROI.SelectedIndex >= 0)
            {
                if (roiManager.GetItemCount() == 0) return;

                roiManager.RemoveAt(comboBox_ListROI.SelectedIndex);
                updateRoiListItems();
            }
        }
    }
}
