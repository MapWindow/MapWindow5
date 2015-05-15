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

using System.Drawing;
using System.Drawing.Drawing2D;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Symbology.Services
{
    /// <summary>
    /// A class to encapsulating label properties and drawing
    /// </summary>
    internal class LabelStyleRenderer
    {
        private readonly ILabelStyle _style;

        /// <summary>
        /// Initializes a new instance of the LabelStyle class
        /// </summary>
        public LabelStyleRenderer(ILabelStyle style)
        {
            _style = style;
        }

        /// <summary>
        ///  Returns the size of the string drawn with current options
        /// </summary>
        /// <param name="g">Graphics object on which the drawing is performed</param>
        /// <param name="s">Text string to measure</param>
        /// <param name="maxFontSize">This is maximum font size that will be used, larger values will be reduced to the given value</param>
        /// <returns>The size needed to draw the string</returns>
        public Size MeasureString(Graphics g, string s, int maxFontSize)
        {
            int fontSize = _style.FontSize;
            if (maxFontSize > 0 && maxFontSize < fontSize)
            {
                fontSize = maxFontSize;
            }

            // font options
            FontStyle style = FontStyle.Regular;
            if (_style.FontUnderline)
            {
                style |= FontStyle.Underline;
            }
            
            if (_style.FontBold)
            {
                style |= FontStyle.Bold;
            }
            
            if (_style.FontItalic)
            {
                style |= FontStyle.Italic;
            }
            
            if (_style.FontStrikeOut)
            {
                style |= FontStyle.Strikeout;
            }

            Font font = new Font(_style.FontName, fontSize, style);
            var format = StringFormatByAlignment(_style.InboxAlignment);

            SizeF sizef = g.MeasureString(s, font);
            Size size = new Size((int)sizef.Width, (int)sizef.Height);
            size.Width += 1;
            size.Height += 1;

            if (_style.FrameVisible)
            {
                size.Width += _style.FramePaddingX;
                size.Height += _style.FramePaddingY;
            }

            return size;
        }

        /// <summary>
        /// Returns Color object initialized with the given OLE_COLOR and alpha value
        /// </summary>
        /// <param name="color">OLE COLOR as unsigned interger</param>
        /// <param name="alpha">alpha value</param>
        /// <returns>Color object</returns>
        public Color GetColor(Color color, int alpha)
        {
            if (alpha != 255)
            {
                return Color.FromArgb(alpha, color);
            }
            return color;
        }

        /// <summary>
        /// Drawing of label using the label category options
        /// </summary>
        /// <param name="g">Graphics object to draw on</param>
        /// <param name="pntOrigin">The position to start drawing</param>
        /// <param name="s">A string to draw</param>
        /// <param name="useAlignment">Toggles usage of alignment options</param>
        /// <param name="maxFontSize">This is maximum font size that will be used, larger values will be reduced to the given value</param>
        public void Draw(Graphics g, Point pntOrigin, string s, bool useAlignment, int maxFontSize)
        {
            if (s == "")
            {
                return;
            }

            int fontSize = _style.FontSize;
            if (maxFontSize > 0 && maxFontSize < fontSize)
            {
                fontSize = maxFontSize;
            }

            // font options
            FontStyle style = FontStyle.Regular;
            if (_style.FontUnderline)
            {
                style |= FontStyle.Underline;
            }

            if (_style.FontBold)
            {
                style |= FontStyle.Bold;
            }

            if (_style.FontItalic)
            {
                style |= FontStyle.Italic;
            }

            if (_style.FontStrikeOut)
            {
                style |= FontStyle.Strikeout;
            }
            
            Font font = new Font(_style.FontName, fontSize, style);
            var format = StringFormatByAlignment(_style.InboxAlignment);

            SizeF sizef = g.MeasureString(s, font);
            Size size = new Size((int)sizef.Width, (int)sizef.Height);
            Rectangle rect = new Rectangle(pntOrigin, size);
            rect.Height += 1;   // to avoid clipping he letters in some cases
            rect.Width += 1;

            if (useAlignment)
            {
                AlignRectangle(ref rect, _style.Alignment);
                
                // offset
                rect.X += (int)_style.OffsetX;
                rect.Y += (int)_style.OffsetY;
            }

            if (_style.FrameVisible)
            {
                rect.Width += _style.FramePaddingX;
                rect.Height += _style.FramePaddingY;
                rect.X -= _style.FramePaddingX/2;
                rect.Y -= _style.FramePaddingY/2;
            }

            // drawing a frame
            if ((_style.FrameTransparency != 0) && _style.FrameVisible)
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.SmoothingMode = SmoothingMode.None;
                Pen penFrame = new Pen(GetColor(_style.FrameOutlineColor, _style.FrameTransparency), _style.FrameOutlineWidth);  //  base.FrameOutlineColor));
                penFrame.DashStyle = _style.FrameOutlineStyle;
                if (_style.FrameGradientMode != LinearGradient.None)
                {
                    LinearGradientBrush lgb = new LinearGradientBrush(
                                                                      rect,
                                                                      GetColor(_style.FrameBackColor, _style.FrameTransparency),
                                                                      GetColor(_style.FrameBackColor2, _style.FrameTransparency),
                                                                      (LinearGradientMode)_style.FrameGradientMode);
                    DrawLabelFrame(g, lgb, penFrame, rect);
                    lgb.Dispose();
                }
                else
                {
                    SolidBrush brush = new SolidBrush(GetColor(_style.FrameBackColor, _style.FrameTransparency));
                    DrawLabelFrame(g, brush, penFrame, rect);
                    brush.Dispose();
                }

                penFrame.Dispose();
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
            }

            // drawing the label itself
            if (_style.FontTransparency != 0)
            {
                GraphicsPath path = new GraphicsPath();
                path.StartFigure();
                path.AddString(s, font.FontFamily, (int)font.Style, (float)fontSize * 96f / 72f, rect, format);
                path.CloseFigure();

                // shadow
                if (_style.ShadowVisible)
                {
                    SolidBrush brushShadow = new SolidBrush(GetColor(_style.ShadowColor, _style.FontTransparency));
                    Matrix mtx = new Matrix();
                    mtx.Translate(_style.ShadowOffsetX, _style.ShadowOffsetY);
                    path.Transform(mtx);
                    g.FillPath(brushShadow, path);
                    mtx.Translate(-2 * _style.ShadowOffsetX, -2 * _style.ShadowOffsetY);
                    path.Transform(mtx);
                    mtx.Dispose();
                }

                // halo
                if (_style.HaloVisible)
                {
                    float width = (float)font.Size / 16.0f * (float)_style.HaloSize;
                    Pen penHalo = new Pen(GetColor(_style.HaloColor, _style.FontTransparency), width);
                    penHalo.LineJoin = LineJoin.Round;
                    g.DrawPath(penHalo, path);
                    penHalo.Dispose();
                }

                // font outline
                if (_style.FontOutlineVisible)
                {
                    Pen penOutline = new Pen(GetColor(_style.FontOutlineColor, _style.FontTransparency), _style.FontOutlineWidth);
                    penOutline.LineJoin = LineJoin.Round;
                    g.DrawPath(penOutline, path);
                    penOutline.Dispose();
                }

                // the font itself
                if (_style.FontGradientMode != LinearGradient.None)
                {
                    LinearGradientBrush lgb = new LinearGradientBrush(  
                                                                        rect, 
                                                                        GetColor(_style.FontColor, _style.FontTransparency),
                                                                        GetColor(_style.FontColor2, _style.FontTransparency), 
                                                                        (LinearGradientMode)_style.FontGradientMode);
                    g.FillPath(lgb, path);
                    lgb.Dispose();
                }
                else
                {
                    SolidBrush brush = new SolidBrush(GetColor(_style.FontColor, _style.FontTransparency));
                    g.FillPath(brush, path);
                    brush.Dispose();
                }

                path.Dispose();
            }   // (fontTransparency != 0)
        }

        /// <summary>
        /// Returns string format for the text to draw based upon label alignment option
        /// </summary>
        /// <param name="alignment">MapWinGIS to convert</param>
        /// <returns>Net string format</returns>
        private StringFormat StringFormatByAlignment(LabelAlignment alignment)
        {
            StringFormat fmt = new StringFormat();
            switch (alignment)
            {
                case LabelAlignment.Center: 
                    fmt.Alignment = StringAlignment.Center; 
                    fmt.LineAlignment = StringAlignment.Center; 
                    break;
                case LabelAlignment.CenterLeft: 
                    fmt.Alignment = StringAlignment.Near; 
                    fmt.LineAlignment = StringAlignment.Center; 
                    break;
                case LabelAlignment.CenterRight: 
                    fmt.Alignment = StringAlignment.Far; 
                    fmt.LineAlignment = StringAlignment.Center; 
                    break;
                case LabelAlignment.BottomCenter: 
                    fmt.Alignment = StringAlignment.Center; 
                    fmt.LineAlignment = StringAlignment.Far; 
                    break;
                case LabelAlignment.BottomLeft: 
                    fmt.Alignment = StringAlignment.Near; 
                    fmt.LineAlignment = StringAlignment.Far; 
                    break;
                case LabelAlignment.BottomRight: 
                    fmt.Alignment = StringAlignment.Far; 
                    fmt.LineAlignment = StringAlignment.Far; 
                    break;
                case LabelAlignment.TopCenter: 
                    fmt.Alignment = StringAlignment.Center; 
                    fmt.LineAlignment = StringAlignment.Near; 
                    break;
                case LabelAlignment.TopLeft: 
                    fmt.Alignment = StringAlignment.Near; 
                    fmt.LineAlignment = StringAlignment.Near; 
                    break;
                case LabelAlignment.TopRight: 
                    fmt.Alignment = StringAlignment.Far; 
                    fmt.LineAlignment = StringAlignment.Near; 
                    break;
            }
            
            return fmt;
        }

        /// <summary>
        /// Aligning the label rectangle around the point of origin
        /// </summary>
        /// <param name="r">Rectangle to align</param>
        /// <param name="alignment">Alignment option to apply</param>
        private void AlignRectangle(ref Rectangle r, LabelAlignment alignment)
        {
            switch (alignment)
            {
                case LabelAlignment.TopLeft:
                                r.X -= r.Width;
                                r.Y -= r.Height;
                                break;                
                case LabelAlignment.TopCenter:
                                r.X -= r.Width / 2;
                                r.Y -= r.Height;
                                break;                        
                case LabelAlignment.TopRight:
                                r.X += 0;
                                r.Y -= r.Height;
                                break;            
                case LabelAlignment.CenterLeft:
                                r.X -= r.Width;
                                r.Y -= r.Height / 2;
                                break;
                case LabelAlignment.Center:
                                r.X -= r.Width / 2;
                                r.Y -= r.Height / 2;
                                break;
                case LabelAlignment.CenterRight:
                                r.X += 0;
                                r.Y -= r.Height / 2;
                                break;            
                case LabelAlignment.BottomLeft:
                                r.X -= r.Width;
                                r.Y += 0;
                                break;            
                case LabelAlignment.BottomCenter:
                                r.X -= r.Width / 2;
                                r.Y += 0;
                                break;
                case LabelAlignment.BottomRight:
                                // rect.MoveToXY(0, 0);
                                break;            
            }
        }

        /// <summary>
        /// Draws a frame for the label
        /// </summary>
        /// <param name="g">Graphics object to draw on</param>
        /// <param name="brush">Brush object to draw frame background</param>
        /// <param name="pen">Pen object to draw frame outline</param>
        /// <param name="rect">Rectangle to draw in</param>
        private void DrawLabelFrame(Graphics g, Brush brush, Pen pen, Rectangle rect)
        {
            switch (_style.FrameType)
            {
                case FrameType.Rectangle:
                    {
                        g.FillRectangle(brush, rect);
                        g.DrawRectangle(pen, rect);
                        break;
                    }

                case FrameType.RoundedRectangle:
                    {
                        int left = rect.X;
                        int right = rect.X + rect.Width;
                        int top = rect.Y;
                        int bottom = rect.Y + rect.Height;

                        GraphicsPath path = new GraphicsPath();
                        path.StartFigure();

                        path.AddLine(left + rect.Height, top, right - rect.Height, top);
                        path.AddArc(right - rect.Height, top, rect.Height, rect.Height, -90.0f, 180.0f);
                        path.AddLine(right - rect.Height, bottom, left + rect.Height, bottom);
                        path.AddArc(left, top, rect.Height, rect.Height, 90.0f, 180.0f);
                        path.CloseFigure();
                        g.FillPath(brush, path);
                        g.DrawPath(pen, path);
                        path.Dispose();
                        break;
                    }

                case FrameType.PointedRectangle:
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
                        g.FillPath(brush, path);
                        g.DrawPath(pen, path);
                        path.Dispose();
                        break;
                    }
            }
        }
    }
}
