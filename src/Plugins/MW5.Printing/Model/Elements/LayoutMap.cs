// -------------------------------------------------------------------------------------------
// <copyright file="LayoutMap.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.Serialization;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Services;
using MW5.Shared;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// Represents a map element in the layout.
    /// </summary>
    [DataContract]
    public class LayoutMap : LayoutElement
    {
        private IPrintableMap _map;
        private Bitmap _buffer;
        private bool _drawTiles;
        private bool _extentChanged;
        private IEnvelope _extents;
        private bool _mainMap;
        private TileProvider _tileProvider = TileProvider.OpenStreetMap;
        private bool _updateMapArea;
        private RectangleF _oldRectangle;

        /// <summary>
        /// Creates a new instance of the map element based on the ocx in the IMapWin interface
        /// </summary>
        public LayoutMap()
        {
            SetDefaults();
        }

        /// <summary>
        /// Should initialize all private data members which aren't set by deserialization.
        /// </summary>
        protected override void SetDefaults()
        {
            _extentChanged = false;
            _mainMap = true;
            _updateMapArea = true;

            Name = "Map";
            PrintQuality = PrintQuality.High;
            TilesLoaded = false;
            Guid = System.Guid.NewGuid().ToString();
            ResizeStyle = ResizeStyle.NoScaling;
        }

        public void Initialize(IPrintableMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            _map = map;
        }

        /// <summary>
        /// Indicates to the layout engine that vector based rendering should be used
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryEx(@"cat_map")]
        [DisplayNameEx(@"prop_drawtiles")]
        [DataMember]
        public bool DrawTiles
        {
            get { return _drawTiles; }
            set
            {
                _drawTiles = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Sets a new extent for the map on calls invalidation of the control
        /// </summary>
        [Browsable(false)]
        public IEnvelope Envelope
        {
            get { return _extents; }
            set
            {
                _extents = EnvelopeHelper.SetBoundsWithXYRatio(value, SizeF);
                RefreshElement();
            }
        }

        /// <summary>
        /// Performs serialization of map bounds without binding serializer to Envelope implementation.
        /// </summary>
        [Browsable(false)]
        [DataMember]
        private XmlEnvelope Bounds
        {
            get
            {
                var box = Envelope;
                return new XmlEnvelope() { MinX = box.MinX, MinY = box.MinY, MaxX = box.MaxX, MaxY = box.MaxY };
            }

            set
            {
                if (value == null) return;
                Envelope = new Envelope(value.MinX, value.MaxX, value.MinY, value.MaxY);
            }
        }

        [Browsable(false)]
        public string Guid { get; set; }

        /// <summary>
        /// Indicates to the layout engine that vector based rendering should be used
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryEx(@"cat_map")]
        [DisplayNameEx(@"prop_mainmap")]
        public bool MainMap
        {
            get { return _mainMap; }
            set
            {
                _mainMap = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Gets or set the quality of the final print out
        /// </summary>
        [Browsable(false)]
        [DataMember]
        public PrintQuality PrintQuality { get; set; }

        /// <summary>
        /// Gets or set scale of the map
        /// </summary>
        [Browsable(true)]
        [CategoryEx(@"cat_map")]
        [DisplayNameEx(@"prop_scale")]
        public int Scale
        {
            get
            {
                double scale = -1.0;

                if (!Resizing)
                {
                    GeoSize geoSize;
                    if (_map.GetGeodesicSize(_extents, out geoSize))
                    {
                        scale = LayoutScaleHelper.CalcMapScale(geoSize, SizeF);
                    }

                    if (double.IsNaN(scale) || scale > Int32.MaxValue || scale <= 0)
                    {
                        scale = -1.0;
                    }
                }

                return Convert.ToInt32(scale);
            }
            set
            {
                if (value <= 1) return;

                var size = LayoutScaleHelper.CalcMapGeoSize(value, SizeF);

                var extents = LayoutScaleHelper.CalcNewExtents(_map, _extents, size, SizeF);

                _extents = extents;

                RecycleScreenBuffer();

                RefreshElement();
            }
        }

        /// <summary>
        /// This is a list of layer indices based on their position in the stack not their handle
        /// </summary>
        [Browsable(true)]
        [DefaultValue(TileProvider.OpenStreetMap)]
        [CategoryEx(@"cat_map")]
        [DisplayNameEx(@"prop_provider")]
        [DataMember]
        public TileProvider TileProvider
        {
            get { return _tileProvider; }
            set
            {
                _tileProvider = value;
                TilesLoaded = false;
                RefreshElement();
            }
        }

        [Browsable(false)]
        public bool TilesLoaded { get; set; }

        public override ElementType Type
        {
            get { return ElementType.Map; }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryEx(@"cat_map")]
        [DisplayNameEx(@"prop_updatemaparea")]
        public bool UpdateMapArea
        {
            get { return MainMap || _updateMapArea; }
            set
            {
                _updateMapArea = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Draws part of the map (belonging to a certain page). For printing and export to bitmap only.
        /// </summary>
        public bool Print(Graphics g, RectangleF paperRect, bool export)
        {
            var ext = ExtentsWithinPaperRectange(paperRect);

            Size size;

            if (export)
            {
                float dpiRatio = g.DpiX / 100f;
                var point = new PointF(paperRect.Width * dpiRatio, paperRect.Height * dpiRatio);
                size = new Size(Convert.ToInt32(point.X), Convert.ToInt32(point.Y));
                ScalePointsAndFonts(dpiRatio);
            }
            else
            {
                size = new Size((int)paperRect.Width, (int)paperRect.Height);
            }

            //var tiles = _layoutControl.AxMap.Tiles;
            //bool tilesVisible = tiles.Visible;
            //TileProvider provider = tiles.Provider;
            //tiles.Visible = _drawTiles;
            //tiles.Provider = tileProvider;
            //float scale = export ? dpi / bitmapDpi : 1.0f;

            bool result = RenderMap(ext, size, g);

            if (export)
            {
                float dpiRatio = g.DpiX / 100f;
                ScalePointsAndFonts(1 / dpiRatio);
            }

            //tiles.Visible = tilesVisible;
            //tiles.Provider = provider;

            return result;
        }

        private void ScalePointsAndFonts(float dpiRatio)
        {
            foreach (var layer in _map.Layers)
            {
                var style = layer.Labels.Style;
                style.FontSize = Convert.ToInt32(style.FontSize * dpiRatio);
                style.FontSize2 = Convert.ToInt32(style.FontSize2 * dpiRatio);
                layer.Labels.UpdateSizeField();

                var fs = layer.FeatureSet;
                if (fs != null)
                {
                    fs.Style.Marker.Size *= dpiRatio;
                }
            }
        }

        /// <summary>
        /// Loads tiles for particular rectangle, or all the element if none is specified
        /// </summary>
        public bool LoadTiles(float dpi, RectangleF rect)
        {
            //float inchesWidth = rect == default(RectangleF) ? Size.Width : rect.Width;
            //int width = Convert.ToInt32(inchesWidth * dpi / 100);
            //var map = _layoutControl.AxMap;

            //int result = map.TilesAreInCache(_extent, width, tileProvider);
            //if (result == 1) return true;

            //if (rect == default(RectangleF))
            //{
            //    var ext = new Envelope();
            //    ext.SetBounds(_extent.MinX, _extent.MinY, _extent.MaxX, _extent.MaxY);
            //    var task = new TileLoadingTask() { Extents = ext, Guid = Guid, TileProvider = tileProvider, Width = width};
            //    _layoutControl.EnqueLoadingTask(task);
            //}
            //else
            //{
            //    // part of it on particular page
            //    map.LoadTilesForSnapshot(ExtentsWithinRectange(rect), width, Guid + "print", tileProvider);
            //}
            return false;
        }

        public void PanMap(double x, double y)
        {
            Envelope = Envelope.Move(x, y);
        }

        public override void RefreshElement()
        {
            _extentChanged = true;

            FireInvalidated();
        }

        /// <summary>
        /// Zooms the map element in by 20%
        /// </summary>
        public virtual void ZoomInMap()
        {
            var envl = new Envelope();
            envl.SetBounds(Envelope.Center, Envelope.Width * 0.8, Envelope.Height * 0.8);
            Envelope = envl;
        }

        /// <summary>
        /// Zooms the map element out by 20%
        /// </summary>
        public virtual void ZoomOutMap()
        {
            var envl = new Envelope();
            envl.SetBounds(Envelope.Center, Envelope.Width * 1.2, Envelope.Height * 1.2);
            Envelope = envl;
        }

        public virtual void ZoomToFullExtent()
        {
            Envelope = _map.Extents.Clone();
        }

        /// <summary>
        /// Draw the map to the graphics object passed in. FOR LAYOUT ONLY (without splitting by pages)
        /// </summary>
        protected override void Draw(Graphics g, bool printing, bool export, int x, int y)
        {
            // printing goes on even if no tiles were loaded
            if (!TilesLoaded && DrawTiles && _extentChanged)
            {
                // default rectangle - to mark that no extents change is needed
                LoadTiles((int)g.DpiX, default(RectangleF));
            }

            // regular control rendering
            if (Convert.ToInt32(SizeF.Width) <= 0 || Convert.ToInt32(SizeF.Height) <= 0) return;

            int width = Convert.ToInt32(SizeF.Width * ScreenHelper.LogicToScreenDpi);
            int height = Convert.ToInt32(SizeF.Height * ScreenHelper.LogicToScreenDpi);

            ValidateScreenBuffer(width, height);

            if (_buffer == null)
            {
                _buffer = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                
                // TODO: don't we use a real screen DPI here?
                _buffer.SetResolution(96, 96);

                using (var graph = Graphics.FromImage(_buffer))
                {
                    //var tiles = _layoutControl.AxMap.Tiles;
                    //bool tilesVisible = tiles.Visible;
                    //TileProvider provider = tiles.Provider;

                    //tiles.Visible = _drawTiles;
                    //tiles.Provider = tileProvider;

                    RenderMap(_extents, new Size(_buffer.Width, _buffer.Height), graph);

                    //tiles.Visible = tilesVisible;
                    //tiles.Provider = provider;
                }
            }

            g.DrawImage(_buffer, Rectangle.FloatRectangleToInt());

            TilesLoaded = false;

            UpdateThumbnail();
        }

        protected override void OnSizeChanged()
        {
            base.OnSizeChanged();

            if (Envelope == null)
            {
                _oldRectangle = Rectangle;
                return;
            }

            if (Resizing)
            {
                return;
            }

            double dx = _oldRectangle.Width / Envelope.Width;
            double dy = _oldRectangle.Height / Envelope.Height;

            var newEnv = Envelope.Clone();

            double plusX = (Rectangle.Width - _oldRectangle.Width) / dx;
            double plusY = (Rectangle.Height - _oldRectangle.Height) / dy;

            newEnv.SetBounds(newEnv.MinX,
                             newEnv.MaxX + plusX,
                             newEnv.MinY - plusY,
                             newEnv.MaxY);
            
            Envelope = newEnv;

            _oldRectangle = Rectangle;
        }

        protected override void UpdateThumbnail()
        {
            if (Resizing || NumericHelper.Equal(SizeF.Width, 0.0) || NumericHelper.Equal(SizeF.Height, 0.0)) return;

            var tempThumbnail = new Bitmap(32, 32, PixelFormat.Format32bppArgb);

            using (var g = Graphics.FromImage(tempThumbnail))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                if (_buffer != null)
                {
                    g.DrawImage(_buffer, new RectangleF(0.0f, 0.0f, 32.0f, 32.0f));
                }
            }

            Thumbnail = tempThumbnail;
        }

        /// <summary>
        /// Returns extents of map that a within certain rectangle (in paper coordinates)
        /// </summary>
        private IEnvelope ExtentsWithinPaperRectange(RectangleF rect)
        {
            double x1 = (rect.X - Rectangle.X) / Rectangle.Width;
            double x2 = (rect.Right - Rectangle.X) / Rectangle.Width;
            double y1 = (rect.Y - Rectangle.Y) / Rectangle.Height;
            double y2 = (rect.Bottom - Rectangle.Y) / Rectangle.Height;

            var ext = new Envelope();

            ext.SetBounds(_extents.MinX + _extents.Width * x1,
                          _extents.MinX + _extents.Width * x2,
                          _extents.MaxY - _extents.Height * y1,
                          _extents.MaxY - _extents.Height * y2);

            return ext;
        }

        private void RecycleScreenBuffer()
        {
            if (_buffer != null)
            {
                _buffer.Dispose();
                _buffer = null;
            }
        }

        /// <summary>
        /// Actual rendering of map
        /// </summary>
        private bool RenderMap(IEnvelope extent, Size bitmapSize, Graphics g)
        {
            if (bitmapSize.Width < 1 | bitmapSize.Height < 1) return false;

            _map.Lock();

            // save settings
            bool state = _map.ScalebarVisible;
            _map.ScalebarVisible = false;

            float dx = g.Transform.OffsetX;
            float dy = g.Transform.OffsetY;
            var clip = g.ClipBounds;

            // rendering
            g.Clear(Color.White);
            var dcPtr = g.GetHdc();

            bool result = _map.SnapShotToDC2(dcPtr, extent.Clone(), bitmapSize.Width, dx, dy, clip.X, clip.Y, clip.Width, clip.Height);

            g.ReleaseHdc(dcPtr);

            // restore settings
            _map.ScalebarVisible = state;

            _map.Unlock();

            return result;
        }

        private void ValidateScreenBuffer(int newWidth, int newHeight)
        {
            if (_extentChanged || _buffer != null && (_buffer.Width != newWidth || _buffer.Height != newHeight))
            {
                _extentChanged = false;
                RecycleScreenBuffer();
            }
        }
    }
}