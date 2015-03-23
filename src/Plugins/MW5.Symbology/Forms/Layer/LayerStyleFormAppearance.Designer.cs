// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Forms.Utilities;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Forms.Layer
{
    partial class LayerStyleForm
    {
        /// <summary>
        /// Sets the state of controls on the general tab on loading
        /// </summary>
        private void InitAppearanceTab()
        {
            // default options
            var options = _shapefile.Style;

            groupPoint.Top = groupFill.Top;
            groupPoint.Left = groupFill.Left;

            groupLine.Top = groupFill.Top;
            groupLine.Left = groupFill.Left;

            groupFill.Visible = false;
            groupLine.Visible = false;
            groupPoint.Visible = false;

            icbFillStyle.ComboStyle = ImageComboStyle.HatchStyleWithNone;
            icbLineWidth.ComboStyle = ImageComboStyle.LineWidth;

            var type = _shapefile.GeometryType;
            if (type == GeometryType.Point || type == GeometryType.MultiPoint)
            {
                groupPoint.Visible = true;
                clpPointFill.Color = options.Fill.Color;
            }
            else if ( type == GeometryType.Polyline )
            {
                groupLine.Visible = true;
            }
            else if (type == GeometryType.Polygon )
            {
                groupFill.Visible = true;
                clpPolygonFill.Color = options.Fill.Color;
            }

            Appearance2Controls();
        }

        /// <summary>
        /// Updating controls
        /// </summary>
        private void Appearance2Controls()
        {
            var options = _shapefile.Style;
            clpSelection.Color =  _shapefile.SelectionColor;
            transpSelection.Value = _shapefile.SelectionTransparency;

            var type = _shapefile.GeometryType;
            if (type == GeometryType.Point || type == GeometryType.MultiPoint)
            {
                transpMain.Value  = (byte)_shapefile.Style.Fill.Transparency;
                clpPointFill.Color = options.Fill.Color;
                udDefaultSize.SetValue(options.Marker.Size);

            }
            else if (type == GeometryType.Polyline)
            {
                transpMain.Value = (byte)_shapefile.Style.Line.Transparency;
                icbLineWidth.SelectedIndex = (int)options.Line.Width - 1;
                clpDefaultOutline.Color = options.Line.Color;
            }
            else if (type == GeometryType.Polygon)
            {
                clpPolygonFill.Color = _shapefile.Style.Fill.Color;
                icbFillStyle.SelectedIndex = options.Fill.Type == FillType.Hatch ? (int)options.Fill.HatchStyle : 0;
            }
        }

        /// <summary>
        /// Opens default drawing options
        /// </summary>
        private void btnDrawingOptions_Click(object sender, EventArgs e)
        {
            using (var form = FormHelper.GetSymbologyForm(_legend, _layerHandle, _shapefile.GeometryType, _shapefile.Style, true))
            {
                form.Text = "Default drawing options";
                if (_context.View.ShowDialog(form, this))
                {
                    Appearance2Controls();
                    DrawAppearancePreview();
                    Application.DoEvents();
                    RedrawMap();
                    RefreshControlsState(null, null);
                }
                else
                {
                    Application.DoEvents();
                }
            }
        }

        /// <summary>
        /// Draws preview on the appearance tab
        /// </summary>
        private void DrawAppearancePreview()
        {
            var pct = new PictureBox();
                
            pct = pictureBox1;
            var sdo = _shapefile.Style;

            if (pct.Image != null)
            {
                pct.Image.Dispose();
            }

            Rectangle rect = pct.ClientRectangle;
            Bitmap bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);

            if (_shapefile.PointOrMultiPoint)
            {
                sdo.DrawPoint(g, 0.0f, 0.0f, rect.Width, rect.Height,  Color.White);
            }
            else if (_shapefile.GeometryType == GeometryType.Polyline)
            {
                if (sdo.Line.UsePattern)
                {
                    sdo.DrawLine(g, 20.0f, 0.0f, 0, 0, true, rect.Width - 40, rect.Height,  Color.White);
                }
                else
                {
                    int w = rect.Width - 40;
                    int h = rect.Height - 40;
                    sdo.DrawLine(g, (rect.Width - w)/2, (rect.Height - h) / 2, w, h, true, rect.Width, rect.Height,  Color.White);
                }
            }
            else if (_shapefile.GeometryType == GeometryType.Polygon)
            {
                sdo.DrawRectangle(g, rect.Width / 2 - 40, rect.Height / 2 - 40, 80, 80, true, rect.Width, rect.Height,  Color.White);
            }

            pct.Image = bmp;
        }

        /// <summary>
        /// Sets the properties of the labels based upon user input
        /// </summary>
        private void Controls2Appearance()
        {
            IGeometryStyle options = _shapefile.Style;
            
            if (_shapefile.GeometryType == GeometryType.Polygon)
            {
                options.Fill.Color =  clpPolygonFill.Color;
                // hatch style is set in the corresponding event
            }
            else if (_shapefile.PointOrMultiPoint)
            {
                options.Fill.Color =  clpPointFill.Color;
                options.Marker.Size = (float)udDefaultSize.Value;
            }
            else if (_shapefile.GeometryType == GeometryType.Polyline)
            {
                options.Line.Color =  clpDefaultOutline.Color;
                options.Line.Width = (float)icbLineWidth.SelectedIndex + 1;

                // and pattern ones in case there is a single line pattern
                if (options.Line.UsePattern)
                {
                    if (options.Line.Pattern.Count == 1)
                    {
                        var line = options.Line.Pattern[0];
                        line.Color = options.Line.Color;
                        if (line.LineType == LineType.Simple)
                        {
                            line.LineWidth = options.Line.Width;
                        }
                    }
                }
            }

            _shapefile.SelectionColor =  clpSelection.Color;
            _shapefile.SelectionTransparency = transpSelection.Value;
            
            DrawAppearancePreview();
        }

        /// <summary>
        /// Handles the change of transparency by user
        /// </summary>
        private void transpMain_ValueChanged(object sender, byte value)
        {
            if (_shapefile.PointOrMultiPoint)
            {
                _shapefile.Style.Fill.Transparency = value;
                _shapefile.Style.Line.Transparency = value;
            }
            else if (_shapefile.IsPolyline)
            {
                _shapefile.Style.Line.Transparency = value;
            }
            else if (_shapefile.IsPolygon)
            {
                _shapefile.Style.Fill.Transparency = value;
                _shapefile.Style.Line.Transparency = value;
            }
            DrawAppearancePreview();
            RedrawMap();
        }

        /// <summary>
        /// Handles the changes of the selection transparency by user
        /// </summary>
        private void transpSelection_ValueChanged(object sender, byte value)
        {
            _shapefile.SelectionTransparency = value;
            DrawAppearancePreview();
            RedrawMap();
        }

        /// <summary>
        /// Handles the changes of the fill type by user
        /// </summary>
        private void icbFillStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            IGeometryStyle options = _shapefile.Style;
            if (icbFillStyle.SelectedIndex == 0 && options.Fill.Type == FillType.Hatch)
            {
                options.Fill.Type = FillType.Solid;
            }
            if (icbFillStyle.SelectedIndex > 0)
            {
                options.Fill.Type = FillType.Hatch;
                options.Fill.HatchStyle = (HatchStyle)icbFillStyle.SelectedIndex - 1;
            }
            DrawAppearancePreview();
            RedrawMap();
        }

        /// <summary>
        /// Handles the change of selection color
        /// </summary>
        private void clpSelection_SelectedColorChanged(object sender, EventArgs e)
        {
            _shapefile.SelectionColor =  clpSelection.Color;
            transpSelection.BandColor = clpSelection.Color;
            DrawAppearancePreview();
            RedrawMap();
        }
    }
}
