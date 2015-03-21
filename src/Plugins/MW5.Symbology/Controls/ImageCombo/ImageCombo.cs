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
    internal class ImageCombo : ComboBox
    {
        private const int PADDING_X = 1;
        private const int PADDING_Y = 1;
        
        private ImageList _list = new ImageList();
        private ImageComboStyle _style;

        private ColorSchemeCollection _colorSchemes;
        private Color _color1 = Color.Gray;
        private Color _color2 = Color.Honeydew;
        private Color _outlineColor = Color.Black;
        private int _itemCount;
        private ColorSchemeType _colorSchemeType;

        #region Contructors

        /// <summary>
        /// Constructor. Common type of combo will be used
        /// </summary>
        public ImageCombo():this(ImageComboStyle.Common){}
        
        /// <summary>
        /// Constructor. Sets the style of combo.
        /// </summary>
        public ImageCombo(ImageComboStyle style) : this(style, Color.Gray, Color.Gray) { }
        
        /// <summary>
        /// Constructor. Sets the style of combo and fill color.
        /// </summary>
        public ImageCombo(ImageComboStyle style, Color color1):this(style, color1, color1) { }
        
        /// <summary>
        /// Constructor. Sets the style of combo and 2 both fill colors.
        /// </summary>
        public ImageCombo(ImageComboStyle style, Color color1, Color color2)
        {
            _list.ColorDepth = ColorDepth.Depth24Bit;
            OutlineColor = Color.Black;
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            _style = style;
            _color1 = color1;
            _color2 = color2;
            EnabledChanged += (s, e) => RefreshImageList();
        }
        #endregion

        #region Properties
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
        /// The color to draw outline of the content
        /// </summary>
        public Color OutlineColor
        {
            get { return _outlineColor; }
            set { _outlineColor = value; }
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

        /// <summary>
        ///  Gets or sets bound ImageList
        /// </summary>
        public ImageList ImageList
        {
            get { return _list; }
            set { _list = value; }
        }

        public ColorSchemeType ColorSchemeType
        {
            get { return _colorSchemeType; }
            set
            {
                _colorSchemeType = value;
                if (_colorSchemes == null || _colorSchemes.Type != value)
                {
                    ColorSchemes = ColorSchemeProvider.GetList(value);
                }
            }
        }

        /// <summary>
        /// Sets or gets the list of color schemes
        /// </summary>
        public ColorSchemeCollection ColorSchemes
        {
            get
            {
                return _colorSchemes;
            }
            set
            {
                // preserving index
                int index = SelectedIndex;

                _colorSchemes = value;
                GenerateItems(ComboStyle);

                // restoring index
                if (index < Items.Count)
                {
                    SelectedIndex = index;
                }
                else if (Items.Count > 0)
                {
                    SelectedIndex = 0;
                }
            }
        }
        #endregion

        /// <summary>
        /// Generates items for the given combo style
        /// </summary>
        private void GenerateItems(ImageComboStyle style)
        {
            Items.Clear();

            // choosing number of items
            switch (style)
            {
                case ImageComboStyle.FrameType:             
                    _itemCount = 3; 
                    break;
                case ImageComboStyle.LinearGradient:
                    _itemCount = 4; 
                    break;
                case ImageComboStyle.LineStyle:             
                    _itemCount = 5; 
                    break;
                case ImageComboStyle.LineWidth:             
                    _itemCount = 10; 
                    break;
                case ImageComboStyle.PointShape:            
                    _itemCount = 6; 
                    break;
                case ImageComboStyle.HatchStyle:            
                    _itemCount = 53; 
                    break;
                case ImageComboStyle.HatchStyleWithNone:    
                    _itemCount = 54; 
                    break;
                case ImageComboStyle.ColorSchemeGraduated:
                case ImageComboStyle.ColorSchemeRandom:
                {
                    _itemCount = _colorSchemes != null ? _colorSchemes.List.Count : 0;
                    break;
                }
            }

            // adding items
            string str = string.Empty;
            for (int i = 0; i < _itemCount; i++)
            {
                switch (style)
                {
                    case ImageComboStyle.FrameType:
                    {
                        if (i == 0) str = "ftRectangle";
                        else if (i == 1) str = "ftRounded rectangle";
                        else if (i == 2) str = "ftPointed rectangle";
                        break;
                    }
                    case ImageComboStyle.LinearGradient:
                    {
                        // TODO: temporary
                        //str = ((tkLinearGradientMode)i).ToString();
                        str = "  Style " + (i + 1).ToString();
                        break;
                    }
                    case ImageComboStyle.LineStyle:
                    {
                        str = "ls";
                        break;
                    }
                    case ImageComboStyle.LineWidth:
                    {
                        str = "wd";
                        break;
                    }
                    case ImageComboStyle.PointShape:
                    {
                        // TODO: temporary
                        //str = ((tkPointShapeType)i).ToString();
                        //str = str.Substring(5, str.Length - 5);
                        
                        str = "  Style " + (i + 1).ToString();
                        break;
                    }
                    case ImageComboStyle.HatchStyle:
                    {
                        // TODO: temporary
                        //str = ((tkGDIPlusHatchStyle)i).ToString();
                        str = "  Style " + (i + 1).ToString();
                        break;
                    }
                    case ImageComboStyle.HatchStyleWithNone:
                    {
                        // TODO: temporary
                        //if (i == 0)
                        //{
                        //    str = "None";
                        //}
                        //else
                        //{
                        //    str = ((tkGDIPlusHatchStyle)i - 1).ToString();
                        //}
                        str = "  Style " + (i + 1).ToString();
                        break;
                    }
                    case ImageComboStyle.ColorSchemeGraduated:
                    case ImageComboStyle.ColorSchemeRandom:
                    {
                        str = "cl";
                        break;
                    }
                }

                // getting rid of prefix
                str = str.Substring(2, str.Length - 2); 
                
                Items.Add(new ImageComboItem(str, i));
            }

            // adds images
            RefreshImageList();
        }

        /// <summary>
        /// Fills the image list with icons according to the selected colors
        /// </summary>
        private void RefreshImageList()
        {
            if (_style == ImageComboStyle.Common) return;

            _list.Images.Clear();

            int width;
            if (_style == ImageComboStyle.PointShape)
            {
                width = 20;
            }
            else if (_style == ImageComboStyle.ColorSchemeGraduated || _style == ImageComboStyle.ColorSchemeRandom)
            {
                width = Width - 24;
            }
            else
            {
                width = 64;
            }

            Size sz = new Size(width, 16);
            _list.ImageSize = sz;

            int imgHeight = _list.ImageSize.Height;
            int imgWidth = _list.ImageSize.Width;

            Rectangle rect = new Rectangle(PADDING_X, PADDING_Y, imgWidth - 1 - PADDING_X * 2, imgHeight - 1 - PADDING_Y * 2);

            Color foreColor = Enabled ? Color.Black : Color.Gray;

            for (int i = 0; i < _itemCount; i++)
            {
                Bitmap img = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(img);
                
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
                            break;
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
                    case ImageComboStyle.ColorSchemeGraduated:
                    {
                        if (_colorSchemes != null)
                        {
                            var blend = _colorSchemes.List[i];
                            if (blend != null)
                            {
                                LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.White, Color.White, 0.0f);
                                lgb.InterpolationColors = blend;
                                g.FillRectangle( lgb, rect );
                                g.DrawRectangle( new Pen(_outlineColor), rect);
                                lgb.Dispose();
                            }
                        }
                        break;
                    }
                    case ImageComboStyle.ColorSchemeRandom:
                    {
                        if (_colorSchemes != null)
                        {
                            var blend = _colorSchemes.List[i];
                            if (blend != null)
                            {
                                var scheme = blend.ToColorScheme();
                                if (scheme != null)
                                {
                                    int n = 0;
                                    var rnd = new Random();
                                    while (n < imgWidth)
                                    {
                                        var clr =  scheme.GetRandomColor(rnd.NextDouble());
                                        var brush = new SolidBrush(clr);
                                        var rectTemp = new Rectangle(rect.X + n, rect.Y, 8, rect.Height);
                                        g.FillRectangle(brush, rectTemp);
                                        g.DrawRectangle(new Pen(_outlineColor), rectTemp);
                                        brush.Dispose();
                                        n += 8;
                                    }
                                }
                            }
                        }
                        break;
                    }
                    default: return;
                }
                // adding an image
                _list.Images.Add(img);
            }
        }
        
        /// <summary>
        /// Drawing procedure of a single item of list
        /// </summary>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // we don't want to draw ites when combo is disabled
            if ((ComboStyle == ImageComboStyle.ColorSchemeGraduated ||
                ComboStyle == ImageComboStyle.ColorSchemeRandom) && !Enabled)
            {
                return;
            }
            
            // check if it is an item from the Items collection
            if (e.Index < 0)
            {
                // not an item, draw the text (indented)
                e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _list.ImageSize.Width, e.Bounds.Top);
            }
            else
            {
                // check if item is an ImageComboItem
                if (Items[e.Index].GetType() == typeof(ImageComboItem))
                {
                    // get item to draw
                    ImageComboItem item = (ImageComboItem)Items[e.Index];

                    if (Enabled)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
                    }
                    else
                    {
                        e.DrawBackground();
                    }

                    var textColor = Enabled ? Color.Black : Color.Gray;
                    var forecolor = item.ForeColor;
                    var font = item.Mark ? new Font(e.Font, FontStyle.Bold) : e.Font;

                    if (item.ImageIndex != -1 && item.ImageIndex < ImageList.Images.Count)
                    {
                        // draw image
                        ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, item.ImageIndex);
                        // draw text (indented)
                        e.Graphics.DrawString(item.Text, font, new SolidBrush(textColor), e.Bounds.Left + _list.ImageSize.Width + 3 /*offset*/, e.Bounds.Top);
                    }
                    else
                    {
                        e.Graphics.DrawString(item.Text, font, new SolidBrush(forecolor), e.Bounds.Left + _list.ImageSize.Width, e.Bounds.Top);
                    }

                    if (((e.State & DrawItemState.Selected) != 0) && ((e.State & DrawItemState.ComboBoxEdit) == 0))
                    {
                        Pen pen = new Pen(textColor) {DashStyle = DashStyle.Dot};
                        e.Graphics.DrawRectangle(pen, 0, e.Bounds.Top, e.Bounds.Width - 1, e.Bounds.Height - 1);
                    }
                }
                else
                {
                    // it is not an ImageComboItem, draw it
                    e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _list.ImageSize.Width, e.Bounds.Top);
                }
            }
        }
    }
}