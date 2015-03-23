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
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    /// <summary>
    /// Image combo to store the icons for symbology plug-in
    /// </summary>
    internal class ImageCombo : ImageComboBase
    {
        private ImageComboStyle _style;
        
        private Color _color1;
        private Color _color2;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCombo"/> class.
        /// </summary>
        public ImageCombo()
        {
            _style = ImageComboStyle.Common;
            _color1 = Color.Gray;
            _color2 = Color.Honeydew;
        }
        
        /// <summary>
        /// The main  color to fill contents
        /// </summary>
        public Color Color1
        {
            get { return _color1; }
            set 
            { 
                _color1 = value;
                RefreshImageList();
                Invalidate();
            }
        }

        /// <summary>
        /// The second color to fill the contents
        /// </summary>
        public Color Color2
        {
            get { return _color2; }
            set { _color2 = value; }
        }

        /// <summary>
        ///  Setting the number of items for a given combo style
        /// </summary>
        public ImageComboStyle ComboStyle
        {
            get { return _style; }
            set 
            {
                _style = value; 
                GenerateItems(value);
            }
        }

        private int GetItemCount(ImageComboStyle style)
        {
            switch (style)
            {
                case ImageComboStyle.FrameType:
                    return 3;
                case ImageComboStyle.LinearGradient:
                    return 4;
                case ImageComboStyle.LineStyle:
                    return 5;
                case ImageComboStyle.LineWidth:
                    return 10;
                case ImageComboStyle.PointShape:
                    return 6;
                case ImageComboStyle.HatchStyle:
                    return 53;
                case ImageComboStyle.HatchStyleWithNone:
                    return 54;
            }
            return 0;
        }


        /// <summary>
        /// Generates items for the given combo style
        /// </summary>
        private void GenerateItems(ImageComboStyle style)
        {
            Items.Clear();

            _itemCount = GetItemCount(style);

            var s = string.Empty;
            for (int i = 0; i < _itemCount; i++)
            {
                switch (style)
                {
                    case ImageComboStyle.FrameType:
                    {
                        s = ((FrameType) i).ToString();
                        break;
                    }
                    case ImageComboStyle.LinearGradient:
                    {
                        s = ((LinearGradient)i).ToString();
                        break;
                    }
                    case ImageComboStyle.PointShape:
                    {
                        s = ((VectorMarkerType)i).ToString();
                        s = s.Substring(5, s.Length - 5);
                        break;
                    }
                    case ImageComboStyle.HatchStyle:
                    {
                        s = ((HatchStyle)i).ToString();
                        break;
                    }
                    case ImageComboStyle.HatchStyleWithNone:
                    {
                        s = i == 0 ? "None" : ((HatchStyle)i - 1).ToString();
                        break;
                    }
                }

                Items.Add(new ImageComboItem(s, i));
            }

            RefreshImageList();
        }

        /// <summary>
        /// Fills the image list with icons according to the selected colors
        /// </summary>
        protected override void RefreshImageList()
        {
            if (_style == ImageComboStyle.Common)
            {
                return;
            }

            _list.Images.Clear();

            int width = _style == ImageComboStyle.PointShape ? 20 : 64;

            Size sz = new Size(width, 16);
            _list.ImageSize = sz;

            int imgHeight = _list.ImageSize.Height;
            int imgWidth = _list.ImageSize.Width;

            var rect = new Rectangle(PADDING_X, PADDING_Y, imgWidth - 1 - PADDING_X * 2, imgHeight - 1 - PADDING_Y * 2);

            var foreColor = Enabled ? Color.Black : Color.Gray;

            for (int i = 0; i < _itemCount; i++)
            {
                var img = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                var g = Graphics.FromImage(img);
                
                switch (_style)
                {
                    // frame type combo
                    case ImageComboStyle.FrameType:
                    {
                        if (i == 0 )
                        {
                            g.FillRectangle(new SolidBrush(_color1), rect);
                            g.DrawRectangle(new Pen(foreColor), rect);
                        }
                        else if (i == 1)
                        {

                            g.FillEllipse(new SolidBrush(_color1), rect);
                            g.DrawEllipse(new Pen(foreColor), rect);
                        }
                        else if  (i == 2)
                        {
                            float left = rect.X;
                            float right = rect.X + rect.Width;
                            float top = rect.Y;
                            float bottom = rect.Y + rect.Height;

                            GraphicsPath path = new GraphicsPath();
                            path.StartFigure();
                            path.AddLine(left + (rect.Height / 4), top, right - (rect.Height / 4), top);

                            path.AddLine(right - (rect.Height / 4), top, right, (top + bottom) / 2);
                            path.AddLine(right, (top + bottom) / 2, right - (rect.Height / 4), bottom);

                            path.AddLine(right - (rect.Height / 4), bottom, left + (rect.Height / 4), bottom);

                            path.AddLine(left + (rect.Height / 4), bottom, left, (top + bottom) / 2);
                            path.AddLine(left, (top + bottom) / 2, left + (rect.Height / 4), top);

                            path.CloseFigure();
                            g.FillPath(new SolidBrush(_color1), path);
                            g.DrawPath(new Pen(foreColor), path);
                            path.Dispose();
                        }
                        break;
                    }

                    // linear gradient combo
                    case ImageComboStyle.LinearGradient:
                    {
                        if ((LinearGradient)i == LinearGradient.None)
                        {
                            g.FillRectangle(new SolidBrush(_color1), rect);
                            g.DrawRectangle(new Pen(_outlineColor), rect);
                        }
                        else
                        {
                            LinearGradientBrush lgb = new LinearGradientBrush(rect, _color1, _color2, (LinearGradientMode)i);
                            g.FillRectangle(lgb, rect);
                            g.DrawRectangle(new Pen(_outlineColor), rect);
                            lgb.Dispose();
                        }
                        break;
                    }

                    //  line style combo
                    case ImageComboStyle.LineStyle: 
                    {
                        var pen = new Pen(_outlineColor) {DashStyle = (DashStyle) i, Width = 2};
                        g.DrawLine(pen, new Point(rect.Left, rect.Top + rect.Height / 2),
                                                            new Point(rect.Right, rect.Top + rect.Height / 2));
                        break;
                    }

                    //  line width combo
                    case ImageComboStyle.LineWidth: 
                    {
                        var pen = new Pen(_outlineColor) {Width = i + 1};
                        g.DrawLine(pen, new Point(rect.Left, rect.Top + rect.Height / 2),
                                                            new Point(rect.Right, rect.Top + rect.Height / 2));
                        break;
                    }
                    case ImageComboStyle.PointShape:
                    {
                        IGeometryStyle sdo = new GeometryStyle();
                        sdo.Fill.Color =  _color1;
                        sdo.Line.Color =  _outlineColor;

                        var marker = sdo.Marker;
                        marker.VectorMarker = (VectorMarkerType)i;
                        marker.Type = MarkerType.Vector;
                        marker.Size = 12;
                        if (marker.VectorMarker == VectorMarkerType.Star)
                        {
                            marker.VectorSideCount = 5;
                            marker.Rotation = 17;
                            marker.Size = 14;
                        }
                        else if (marker.VectorMarker == VectorMarkerType.Arrow)
                        {
                            marker.Size = 14;
                            marker.Rotation = 0;
                        }
                        else
                        {
                            marker.VectorSideCount = 4;
                            marker.Rotation = 0;
                            marker.Size = 12;
                        }
                        
                        sdo.DrawPoint(g, 0.0f, 0.0f, imgWidth, imgHeight,  BackColor);
                        break;
                    }
                    case ImageComboStyle.HatchStyle:
                    {
                        HatchBrush br = new HatchBrush((HatchStyle)i, _color1, Color.Transparent);
                        g.FillRectangle(br, rect);
                        g.DrawRectangle(new Pen(_outlineColor), rect);
                        br.Dispose();
                        break;
                    }
                    case ImageComboStyle.HatchStyleWithNone:
                    {
                        if (i == 0)
                        {
                            g.FillRectangle(new SolidBrush(_color1), rect);
                            g.DrawRectangle(new Pen(_outlineColor), rect);
                        }
                        else
                        {
                            HatchBrush br = new HatchBrush((HatchStyle)(i - 1), _color1, Color.Transparent);
                            g.FillRectangle(br, rect);
                            g.DrawRectangle(new Pen(_outlineColor), rect);
                            br.Dispose();
                        }
                        break;
                    }
                    default: return;
                }

                _list.Images.Add(img);
            }
        }
        
        
    }
}