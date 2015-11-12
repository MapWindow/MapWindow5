// -------------------------------------------------------------------------------------------
// <copyright file="LayoutLegend.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Serialization;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Properties;
using MW5.Plugins.Printing.Services;
using MW5.Shared;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// Represents MapWindow legend on the printing layout
    /// </summary>
    [DataContract]
    public class LayoutLegend : LayoutElement
    {
        private LayoutControl _layoutControl;
        private LayoutMap _layoutMap;
        private IMuteLegend _legend;
        private List<int> _groupHandles;
        private List<int> _layerHandles;
        private Pen _penOutline;
        private Brush _textBrush;
        private TextRenderingHint _textHint;
        private Color _backColor;
        private Bitmap _buffer;
        private bool _fillHeader;
        private int _numCol;
        private int _thumbnailHeight;
        private int _thumbnailWidth;
        private Color color;
        private Guid _guid;

        /// <summary>
        /// Creates a new instance of the map element based on the ocx in the IMapWin interface
        /// </summary>
        public LayoutLegend()
        {
            SetDefaults();
        }

        /// <summary>
        /// Should initialize all private data members which aren't set by deserialization.
        /// </summary>
        protected override void SetDefaults()
        {
            Name = "Legend";

            _font = new Font("Arial", 10);
            _font2 = new Font("Arial", 12);

            _numCol = 1;
            _textHint = TextRenderingHint.AntiAliasGridFit;
            _thumbnailHeight = 20;
            _thumbnailWidth = 40;

            _penOutline = new Pen(Color.Black);
            _textBrush = new SolidBrush(Color.Black);
            _textHint = TextRenderingHint.SystemDefault;
            _backColor = Color.White;
        }

        public void Initialize(LayoutControl layoutControl, IMuteLegend legend)
        {
            if (layoutControl == null) throw new ArgumentNullException("layoutControl");
            if (legend == null) throw new ArgumentNullException("legend");

            _layoutControl = layoutControl;
            _legend = legend;

            InitLayers();
        }

        [Browsable(false)]
        [DataMember()]
        public Guid MapGuid
        {
            get { return _layoutMap != null ? _layoutMap.Guid : _guid; }
            set { _guid = value; }
        }

        [Browsable(true)]
        [DataMember]
        [DefaultValue(typeof(Color), "0xFFFFFF")]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_color")]
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        [CategoryEx(@"cat_symbol")]
        [DataMember]
        [DefaultValue(false)]
        [Browsable(true)]
        public bool FillHeader
        {
            get { return _fillHeader; }
            set
            {
                _fillHeader = value;
                RefreshElement();
            }
        }

        [Browsable(true)]
        [DataMember]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_font")]
        public Font Font
        {
            get { return _font; }
            set
            {
                _font = value;
                RefreshElement();
            }
        }

        [Browsable(true)]
        [DataMember]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_groupfont")]
        public Font GroupFont
        {
            get { return _font2; }
            set
            {
                _font2 = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// This is a list of layer indices based on their position in the stack not their handle
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_map")]
        [DataMember]
        [DisplayNameEx(@"prop_groups")]
        [Editor(typeof(LayoutGroupEditor), typeof(UITypeEditor))]
        public List<int> Groups
        {
            get { return _groupHandles; }
            set
            {
                _groupHandles = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// This is a list of layer indices based on their position in the stack not their handle
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_map")]
        [DataMember]
        [DisplayNameEx(@"prop_layers")]
        [Editor(typeof(LayoutLayerEditor), typeof(UITypeEditor))]
        public List<int> Layers
        {
            get { return _layerHandles; }
            set
            {
                _layerHandles = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or sets a layout control
        /// </summary>
        [Browsable(false)]
        public virtual LayoutControl LayoutControl
        {
            get { return _layoutControl; }
            set { _layoutControl = value; }
        }

        /// <summary>
        /// Gets or sets the map to use to make the legend
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_map")]
        [DisplayNameEx(@"prop_map")]
        [Editor(typeof(LayoutMapEditor), typeof(UITypeEditor))]
        public LayoutMap Map
        {
            get { return _layoutMap; }
            set
            {
                _layoutMap = value;
                RefreshElement();
            }
        }

        [Browsable(true)]
        [DataMember]
        [DefaultValue(1)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_numcol")]
        public int NumColumns
        {
            get { return _numCol; }
            set
            {
                _numCol = value < 1 ? 1 : value;
                RefreshElement();
            }
        }

        [Browsable(false)]
        [CategoryEx(@"cat_symbol")]
        [DataMember]
        [DisplayNameEx(@"prop_alias")]
        public TextRenderingHint TextHint { get; set; }

        [Browsable(true)]
        [DataMember]
        [DefaultValue(20)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_thumbnail_height")]
        public int ThumbnailHeight
        {
            get { return _thumbnailHeight; }
            set
            {
                if (value > 15)
                {
                    _thumbnailHeight = value;
                    RefreshElement();
                }
            }
        }

        [Browsable(true)]
        [DataMember]
        [DefaultValue(40)]
        [CategoryEx(@"cat_symbol")]
        [DisplayNameEx(@"prop_thumbnail_width")]
        public int ThumbnailWidth
        {
            get { return _thumbnailWidth; }
            set
            {
                if (value > 30)
                {
                    _thumbnailWidth = value;
                    RefreshElement();
                }
            }
        }

        public override ElementType Type
        {
            get { return ElementType.Legend; }
        }

        [Browsable(false)]
        internal IMuteLegend Legend
        {
            get { return _legend; }
        }

        private Font ActiveFont
        {
            get { return _font; }
        }

        private Font ActiveGroupFont
        {
            get { return _font2; }
        }

        public override void RefreshElement()
        {
            _buffer = null;
            base.RefreshElement();
        }

        /// <summary>
        /// Runs drawing
        /// </summary>
        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            if (Map == null || Legend == null) return;

            if (printing)
            {
                _buffer = null;
            }

            AdjustFonts(export);

            int bitmapWidth = GetBitmapWidth();

            CreateBuffer(bitmapWidth, printing, export);
            bitmapWidth -= Constants.LINE_OFFSET * 2;

            if (_buffer == null) return;

            var gTemp = Graphics.FromImage(_buffer);
            gTemp.TextRenderingHint = _textHint;
            gTemp.Clear(Color.White);

            float top = Constants.LINE_OFFSET;

            DrawGroups(gTemp, bitmapWidth, ref top);

            DrawBufferOnScreen(g, export, printing, bitmapWidth, x, y, top);

            _size = new SizeF(Width, top);
        }

        /// <summary>
        /// Fires when the size of the element changes
        /// </summary>
        protected override void OnSizeChanged()
        {
            base.OnSizeChanged();

            RecycleBuffer();
        }

        /// <summary>
        /// Adjusts font size for the case when screen DPI is different from the default.
        /// </summary>
        private void AdjustFonts(bool export)
        {
            if (export && NumericHelper.Equal(ScreenHelper.ScreenDpi, 100f))
            {
                _font = new Font(_font.FontFamily, _font.Size / ScreenHelper.ScreenDpi * 100f);
                _font2 = new Font(_font2.FontFamily, _font2.Size / ScreenHelper.ScreenDpi * 100f);
            }
        }

        /// <summary>
        /// Calculates size of legend items within row.
        /// </summary>
        private IEnumerable<SizeItem> CalcRowSize(
            Graphics g,
            List<LegendItem> row,
            int bitmapWidth,
            int iconWidth = 0,
            bool excludePadding = false)
        {
            var widths = row.Select(item => MeasureString(g, item.Layer.Name, ActiveFont).Width).ToList();

            int availWidth = bitmapWidth - Constants.PAD_X * 2 * widths.Count();

            var adjWidths = widths.Select(w => (float)(availWidth) / (float)widths.Count()).ToList();

            int textWidth = bitmapWidth - iconWidth - Constants.PAD_X * 2;

            for (int i = 0; i < row.Count; i++)
            {
                var item = row[i];

                int width = textWidth;
                if (_numCol > 1)
                {
                    width = (int)adjWidths[i];
                    if (excludePadding)
                    {
                        width -= Constants.PAD_X * 2;
                    }
                }

                yield return
                    new SizeItem
                        {
                            Size = new SizeF(adjWidths[i], MeasureString(g, item.Name, ActiveFont, width).Height),
                            Layer = item.Layer,
                            LegendItem = item
                        };
            }
        }

        /// <summary>
        /// Calculates the number of items in the row.
        /// </summary>
        private int CalculateRowLength(List<LegendItem> items)
        {
            var rowCount = (int)Math.Ceiling((double)items.Count() / _numCol);
            return (int)Math.Ceiling((double)items.Count() / rowCount);
        }

        /// <summary>
        /// Creates a new screen buffer if it was not done before.
        /// </summary>
        private void CreateBuffer(int bitmapWidth, bool printing, bool export)
        {
            if (_buffer != null) return;

            var tempG = GetTempGraphics(printing, export);

            float h = GetBitmapHeight(tempG, printing) + Constants.LINE_OFFSET * 2;

            _buffer = new Bitmap((int)(bitmapWidth + 0.5), (int)(h + 0.5), PixelFormat.Format32bppArgb);

            if (printing && !export)
            {
                _buffer.SetResolution(100f, 100f);
            }
        }

        /// <summary>
        /// Creates legend items for each layer and symbology category.
        /// </summary>
        private IEnumerable<LegendItem> CreateLegendItems(ILegendGroup group)
        {
            var layers = group.Layers.Where(item => _layerHandles.Contains(item.Handle)).ToList();

            foreach (var item in layers.Where(l => !l.HideFromLegend))
            {
                var fs = item.FeatureSet;
                if (fs != null)
                {
                    // default style for layer
                    yield return new LegendItem { Layer = item, Options = fs.Style, Name = item.Name };

                    // categories
                    foreach (var ct in fs.Categories)
                    {
                        string name = item.Name + ": " + ct.Name;
                        yield return new LegendItem { Layer = item, Options = ct.Style, Name = name };
                    }

                    continue;
                }
                
                if (item.Raster != null)
                {
                    // it's an image
                    yield return new LegendItem { Layer = item, Options = null, Name = item.Name };

                    var scheme = item.Raster.ActiveColorScheme;
                    if (scheme != null)
                    {
                        foreach (var ct in scheme)
                        {
                            yield return new LegendItem { Layer = item, RasterBreak = ct, Name = ct.Range };
                        }
                    }

                    continue;
                }

                yield return new LegendItem { Layer = item, Name = item.Name };
            }
        }

        /// <summary>
        /// Draws buffer bitmap to the screen.
        /// </summary>
        private void DrawBufferOnScreen(
            Graphics g,
            bool export,
            bool printing,
            int bitmapWidth,
            int x,
            int y,
            float top)
        {
            // pass it to main canvas
            var oldInterpolationMode = g.InterpolationMode;
            var oldCompositionQuality = g.CompositingQuality;

            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.CompositingQuality = CompositingQuality.HighQuality;

            float topClip = top + 1;

            if (export)
            {
                // because we used paper size in GetBitmapWidth 
                _buffer.SetResolution(100f, 100f);

                //topClip = topClip / 100f * PrintingConstants.EXPORT_BASE_DPI;
            }

            var clipRect = new RectangleF { X = x, Y = y, Width = bitmapWidth + 3, Height = topClip };
            g.SetClip(clipRect, CombineMode.Intersect);

            g.DrawImage(_buffer, x, y);

            g.ResetClip();

            g.InterpolationMode = oldInterpolationMode;
            g.CompositingQuality = oldCompositionQuality;

            if (printing)
            {
                _buffer = null;
            }
        }

        /// <summary>
        /// Draws all the groups within legend
        /// </summary>
        private void DrawGroups(Graphics g, int bitmapWidth, ref float top)
        {
            const float leftOrigin = Constants.LINE_OFFSET;

            foreach (var group in Legend.Groups.Where(gr => gr.Layers.Count > 0 && _groupHandles.Contains(gr.Handle)))
            {
                // group caption
                var size = MeasureString(g, group.Text, ActiveGroupFont, bitmapWidth - Constants.PAD_X * 2);

                if (FillHeader)
                {
                    var rTemp = new RectangleF(leftOrigin, top, bitmapWidth, size.Height + Constants.PAD_Y * 2);
                    g.FillRectangle(new SolidBrush(Color.LightGray), rTemp);
                }

                g.DrawRectangle(_penOutline, leftOrigin, top, bitmapWidth, size.Height + Constants.PAD_Y * 2);

                var r = new RectangleF(Constants.PAD_X + leftOrigin, top + Constants.PAD_Y,
                    bitmapWidth - Constants.PAD_X * 2, size.Height);
                g.DrawString(group.Text, ActiveGroupFont, _textBrush, r, GdiPlusHelper.CenterFormat);
                top += size.Height + Constants.PAD_Y * 2;

                var legendItems = CreateLegendItems(group).ToList();
                int step = CalculateRowLength(legendItems);

                int groupIconWidth, groupIconHeight;
                GetIconWidthAndHeightForRow(legendItems, out groupIconWidth, out groupIconHeight);
                groupIconWidth += Constants.PAD_X * 2;

                int position = 0;
                while (position < legendItems.Count)
                {
                    var row = legendItems.Skip(position).Take(step).ToList();
                    position += step;

                    // adjusted width of columns (according to the amount of content)
                    if (_numCol == 1)
                    {
                        DrawSingleColumnRow(g, bitmapWidth, row.First(), leftOrigin, groupIconWidth, ref top);
                    }
                    else
                    {
                        DrawMultiColumnRow(g, row, bitmapWidth, leftOrigin, ref top);
                    }
                }
            }
        }

        /// <summary>
        /// Draws layer icon.
        /// </summary>
        /// <returns>Height of icon in screen coordinates.</returns>
        private int DrawLayerIcon(ILegendLayer layer, IGeometryStyle options, Graphics g, float left, float top)
        {
            int width = _thumbnailWidth;
            int height = _thumbnailHeight;

            var fs = layer.FeatureSet;
            if (fs == null) return height + 3;

            var hdc = g.GetHdc();

            GetIconWidthAndHeight(options, ref width, ref height);

            left = (int)(left + 0.5);
            top = (int)(top + 0.5);

            if (fs.PointOrMultiPoint)
            {
                options.DrawPoint(hdc, left, top, width, height, _backColor);
            }
            else if (fs.IsPolyline)
            {
                options.DrawLine(hdc, left, top, width, height, false, width, height, _backColor);
            }
            else if (fs.IsPolygon)
            {
                options.DrawRectangle(hdc, left, top, width - 1, height - 1, false, width + 1, height + 1, _backColor);
            }

            g.ReleaseHdc(hdc);

            return height + 3;
        }

        /// <summary>
        /// Draws a single row of the legend with multiple columns.
        /// </summary>
        private void DrawMultiColumnRow(Graphics g, List<LegendItem> row, int bitmapWidth, float left, ref float top)
        {
            var sizes = CalcRowSize(g, row, bitmapWidth).ToList();

            float maxHeight = sizes.Max(s => s.Size.Height) + Constants.PAD_Y * 2;

            var legendItems = sizes.Select(item => item.LegendItem).ToList();

            int iconWidth, iconHeight;
            GetIconWidthAndHeightForRow(legendItems, out iconWidth, out iconHeight);

            float calcHeight = iconHeight + Constants.PAD_Y * 2;

            foreach (var item in sizes)
            {
                // layer caption
                float tempLeft = left + Constants.PAD_X;
                g.DrawRectangle(_penOutline, left, top, item.Size.Width + Constants.PAD_X * 2, maxHeight);

                var r2 = new RectangleF(tempLeft, top + Constants.PAD_Y, (int)item.Size.Width,
                    sizes.Max(s => s.Size.Height));
                g.DrawString(item.LegendItem.Name, ActiveFont, _textBrush, r2, GdiPlusHelper.CenterFormat);

                // drawing thumbnail at the bottom
                if (item.Size.Width > _thumbnailWidth)
                {
                    // move preview to the center of cell
                    tempLeft += (item.Size.Width - _thumbnailWidth) / 2.0f;
                }

                GetIconWidthAndHeightForRow(new List<LegendItem> { item.LegendItem }, out iconWidth, out iconHeight);

                float tempTop = top + maxHeight + (calcHeight - iconHeight) / 2.0f + 0.5f;

                DrawLegendItem(g, item.LegendItem, tempLeft, tempTop);

                g.DrawRectangle(_penOutline, left, top + maxHeight, item.Size.Width + Constants.PAD_X * 2, calcHeight);

                left += item.Size.Width + Constants.PAD_X * 2;
            }

            top += maxHeight;
            top += calcHeight;
        }

        private void DrawLegendItem(Graphics g, LegendItem item, float left, float top)
        {
            if (item.Options != null)
            {
                DrawLayerIcon(item.Layer, item.Options, g, left, top);
            }
            else if (item.RasterBreak != null)
            {
                var r = new Rectangle(Convert.ToInt32(left), Convert.ToInt32(top), _thumbnailWidth, _thumbnailHeight);
                g.DrawRectangle(Pens.Gray, r);
                
                Brush brush;
                if (item.RasterBreak.LowColor != item.RasterBreak.HighColor)
                {
                    brush = new LinearGradientBrush(r, item.RasterBreak.LowColor, item.RasterBreak.HighColor, 0.0f);
                }
                else
                {
                    brush = new SolidBrush(item.RasterBreak.LowColor);
                }

                g.FillRectangle(brush, r);
            }
            else
            {
                var r = new Rectangle(Convert.ToInt32(left), Convert.ToInt32(top), _thumbnailWidth, _thumbnailHeight);
                g.DrawImage(Resources.img_raster, r);
            }
        }

        /// <summary>
        /// Draws a row belonging to single column legend.
        /// </summary>
        private void DrawSingleColumnRow(
            Graphics g,
            int bitmapWidth,
            LegendItem legendItem,
            float leftOrigin,
            int groupIconWidth,
            ref float top)
        {
            int width = bitmapWidth - _thumbnailWidth - Constants.PAD_X * 2;
            float maxHeight = MeasureString(g, legendItem.Name, ActiveFont, width).Height + Constants.PAD_Y * 2;

            int iconHeight, iconWidth;
            GetIconWidthAndHeightForRow(new List<LegendItem> { legendItem }, out iconWidth, out iconHeight);

            maxHeight = Math.Max(iconHeight + Constants.PAD_Y * 2, maxHeight);

            // offset on the half of the spare place in the cell
            var tempTop = (int)(top + (maxHeight - iconHeight) / 2.0f + 0.5f);
            var left = (int)(leftOrigin + (groupIconWidth - iconWidth) / 2.0f + 0.5f);

            DrawLegendItem(g, legendItem, left, tempTop);

            // thumbnail
            g.DrawRectangle(_penOutline, leftOrigin, top, groupIconWidth, maxHeight);

            // text
            left = Convert.ToInt32(leftOrigin + groupIconWidth);
            g.DrawRectangle(_penOutline, leftOrigin, top, bitmapWidth, maxHeight);

            var r2 = new RectangleF(left + Constants.PAD_X, top + Constants.PAD_Y, width, maxHeight);
            g.DrawString(legendItem.Name, ActiveFont, _textBrush, r2, GdiPlusHelper.CenterLeftFormat);

            top += maxHeight;
        }

        /// <summary>
        /// Calculates the height of the bitmap. It's computationally intensive
        /// </summary>
        private int GetBitmapHeight(Graphics g, bool printing)
        {
            float height = 0f;
            int bitmapWidth = GetBitmapWidth();

            var groups = Legend.Groups.Where(gr => gr.Layers.Count > 0 && _groupHandles.Contains(gr.Handle));

            foreach (var group in groups)
            {
                var size = MeasureString(g, group.Text, GroupFont, bitmapWidth - Constants.PAD_X * 2);
                height += size.Height + Constants.PAD_Y * 2;

                var legendItems = CreateLegendItems(group).ToList();
                int step = CalculateRowLength(legendItems);

                int position = 0;
                while (position < legendItems.Count)
                {
                    var row = legendItems.Skip(position).Take(step).ToList();

                    height += GetRowHeight(g, row, bitmapWidth);

                    position += step;
                }
            }

            return (int)Math.Ceiling(height);
        }

        /// <summary>
        /// Returns width out of max number of columns, the size of group and min width of a column
        /// </summary>
        private int GetBitmapWidth()
        {
            int maxGroupCount = Legend.Groups.Max(group => group.Layers.Count);
            int minWidth = Math.Min(maxGroupCount, _numCol) * Constants.MIN_CMN_WIDTH;
            float width = SizeF.Width;
            var val = Math.Max(minWidth, width);
            return (int)Math.Ceiling(val);
        }

        /// <summary>
        /// Gets the height and width of a marker for point layer.
        /// </summary>
        private void GetIconWidthAndHeight(IGeometryStyle style, ref int iconWidth, ref int iconHeight)
        {
            var marker = style.Marker;
            var icon = style.Marker.Icon;

            if (icon != null && marker.Type == MarkerType.Bitmap)
            {
                if (icon.Width * marker.IconScaleX > iconWidth)
                {
                    iconWidth = Convert.ToInt32(icon.Width * marker.IconScaleX + 0.5);
                }

                if (icon.Height * marker.IconScaleY > iconHeight)
                {
                    iconHeight = Convert.ToInt32(icon.Height * marker.IconScaleY + 0.5);
                }
            }

            if (marker.Type == MarkerType.FontCharacter)
            {
                double ratio = marker.FrameVisible ? 1.4 : 1.0;
                if (marker.Size * ratio > iconWidth)
                {
                    iconWidth = Convert.ToInt32(marker.Size * ratio);
                }

                if (marker.Size * ratio > iconHeight)
                {
                    iconHeight = Convert.ToInt32(marker.Size * ratio);
                }
            }
        }

        /// <summary>
        /// Gets maximum icon's width and height for row.
        /// </summary>
        private void GetIconWidthAndHeightForRow(IEnumerable<LegendItem> items, out int iconWidth, out int iconHeight)
        {
            iconWidth = _thumbnailWidth;
            iconHeight = _thumbnailHeight;

            foreach (var item in items)
            {
                var options = item.Options;
                if (options == null) continue;

                GetIconWidthAndHeight(options, ref iconWidth, ref iconHeight);
            }
        }

        /// <summary>
        /// Calculates the height of the given row.
        /// </summary>
        private float GetRowHeight(Graphics g, List<LegendItem> row, int bitmapWidth)
        {
            int iconWidth, iconHeight;
            GetIconWidthAndHeightForRow(row, out iconWidth, out iconHeight);

            var sizes = CalcRowSize(g, row, bitmapWidth, iconWidth, true);

            float maxHeight = sizes.Max(s => s.Size.Height);

            float height = 0.0f;
            if (_numCol == 1)
            {
                maxHeight = maxHeight < iconHeight + Constants.PAD_Y * 2 ? iconHeight + Constants.PAD_Y * 2 : maxHeight;
                height += maxHeight + Constants.PAD_Y * 2;
            }
            else
            {
                height += maxHeight + Constants.PAD_Y * 2;
                height += iconHeight + Constants.PAD_Y * 2;
            }

            return height;
        }

        /// <summary>
        /// Gets a temporary graphics object to perform screen measuring.
        /// </summary>
        private Graphics GetTempGraphics(bool printing, bool export)
        {
            return printing && !export ? GdiPlusHelper.TempGraphicsDpi100 : GdiPlusHelper.TempGraphics;
        }

        /// <summary>
        /// Populates list of layers and groups.
        /// </summary>
        private void InitLayers()
        {
            _groupHandles = new List<int>();
            _groupHandles.AddRange(Legend.Groups.Where(item => item.LayersVisible).Select(g => g.Handle));

            _layerHandles = new List<int>();
            _layerHandles.AddRange(_legend.Layers.Where(item => item.Visible).Select(l => l.Handle));
        }

        private SizeF MeasureString(Graphics g, string text, Font font, int maxWidth = -1)
        {
            return g.MeasureString(text, font, maxWidth);
        }

        private void RecycleBuffer()
        {
            if (_buffer != null)
            {
                _buffer.Dispose();
                _buffer = null;
            }
        }

        private static class Constants
        {
            public const int MIN_CMN_WIDTH = 30; // in pixels at 96 dpi
            public const int PAD_Y = 3;
            public const int PAD_X = 3;
            public const int LINE_OFFSET = 1; // it must be equal to the width of line and depends on dpi
        }

        private class SizeItem
        {
            public ILegendLayer Layer;
            public LegendItem LegendItem;
            public SizeF Size;
        }
    }
}