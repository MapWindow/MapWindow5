// -------------------------------------------------------------------------------------------
// <copyright file="LayoutMap.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Shared;

namespace MW5.Plugins.Printing.Model.Elements
{
    /// <summary>
    /// Represents a map element in the layout.
    /// </summary>
    public class LayoutMap : LayoutElement
    {
        private readonly IPrintableMap _map;
        private Bitmap _buffer;
        private bool _drawTiles;
        private bool _extentChanged;
        private IEnvelope _extents;
        private bool _initializing;
        private bool _mainMap;
        private RectangleF _oldRectangle;
        private TileProvider _tileProvider = TileProvider.OpenStreetMap;
        private bool _updateMapArea;

        /// <summary>
        /// Creates a new instance of the map element based on the ocx in the IMapWin interface
        /// </summary>
        public LayoutMap(IPrintableMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            _map = map;

            _extentChanged = false;
            _mainMap = true;
            _updateMapArea = true;

            Name = "Map";
            PrintQuality = PrintQuality.High;
            TilesLoaded = false;
            Guid = System.Guid.NewGuid().ToString();
            ResizeStyle = ResizeStyle.NoScaling;
            _initializing = true;
        }

        /// <summary>
        /// Indicates to the layout engine that vector based rendering should be used
        /// </summary>
        [Browsable(true)]
        [DefaultValue(true)]
        [CategoryEx(@"cat_map")]
        [DisplayNameEx(@"prop_drawtiles")]
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
                _extents = EnvelopeHelper.SetBoundsWithXYRatio(value, Size);
                RefreshElement();
            }
        }

        [Browsable(false)]
        public string Guid { get; set; }

        [Browsable(false)]
        public bool Initializing
        {
            get { return _initializing; }
        }

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
                        scale = LayoutScaleHelper.CalcMapScale(geoSize, Size);
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

                var size = LayoutScaleHelper.CalcMapGeoSize(value, Size);

                var extents = LayoutScaleHelper.CalcNewExtents(_map, _extents, size);

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
            get { return this.MainMap || _updateMapArea; }
            set
            {
                _updateMapArea = value;
                RefreshElement();
            }
        }

        /// <summary>
        /// Draws part of the map (belonging to a certain page). FOR PRINTING AND EXPORT ONLY
        /// </summary>
        public bool Draw(Graphics g, RectangleF rect, bool export)
        {
            throw new NotImplementedException();

            //bool result = false;

            //var ext = ExtentsWithinPaperRectange(rect);

            //float dpi = export ? g.DpiX : ScreenHelper.ScreenDpi;

            //float bitmapDpi = export ? PrintingConstants.EXPORT_BASE_DPI : 96.0f;
            //var bmpWidth = export ? rect.Width : (int)(rect.Width * dpi / bitmapDpi);
            //var bmpHeight = export ? rect.Height : (int)(rect.Height * dpi / bitmapDpi);

            //var tiles = _layoutControl.AxMap.Tiles;
            //bool tilesVisible = tiles.Visible;
            //TileProvider provider = tiles.Provider;

            //tiles.Visible = _drawTiles;
            //tiles.Provider = tileProvider;

            //bool result = RenderMap(_layoutControl.AxMap, ext, new Size(bmpWidth, bmpHeight), g, export ? dpi / bitmapDpi : 1.0f);

            //tiles.Visible = tilesVisible;
            //tiles.Provider = provider;

            //return result;
        }

        /// <summary>
        /// Loads tiles for particular rectangle, or all the element if none is specified
        /// </summary>
        public bool LoadTiles(int dpi, RectangleF rect)
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

        public void MarkInitialized()
        {
            _initializing = false;
        }

        public void PanMap(double x, double y)
        {
            Envelope = Envelope.Move(x, y);
        }

        public override void RefreshElement()
        {
            _extentChanged = true;

            OnInvalidate();
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
            if (Initializing) return;

            // printing goes on even if no tiles were loaded
            if (!TilesLoaded && DrawTiles && _extentChanged)
            {
                // default rectangle - to mark that no extents change is needed
                LoadTiles((int)g.DpiX, default(RectangleF));
            }

            // regular control rendering
            if (Convert.ToInt32(Size.Width) <= 0 || Convert.ToInt32(Size.Height) <= 0) return;

            int width = Convert.ToInt32(Size.Width * ScreenHelper.LogicToScreenDpi);
            int height = Convert.ToInt32(Size.Height * ScreenHelper.LogicToScreenDpi);

            ValidateScreenBuffer(width, height);

            if (_buffer == null)
            {
                _buffer = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                _buffer.SetResolution(96, 96);

                using (var graph = Graphics.FromImage(_buffer))
                {
                    //var tiles = _layoutControl.AxMap.Tiles;
                    //bool tilesVisible = tiles.Visible;
                    //TileProvider provider = tiles.Provider;

                    //tiles.Visible = _drawTiles;
                    //tiles.Provider = tileProvider;

                    RenderMap(_extents, new Size(_buffer.Width, _buffer.Height), graph, 1.0f);

                    //tiles.Visible = tilesVisible;
                    //tiles.Provider = provider;
                }
            }

            g.DrawImage(_buffer, Rectangle);

            if (TilesLoaded) TilesLoaded = false;

            UpdateThumbnail();
        }

        protected override void OnSizeChanged()
        {
            if (Resizing || Envelope == null)
            {
                return;
            }

            double dx = _oldRectangle.Width / Envelope.Width;
            double dy = _oldRectangle.Height / Envelope.Height;

            var newEnv = Envelope.Clone();

            double plusX = (Rectangle.Width - _oldRectangle.Width) / dx;
            double plusY = (Rectangle.Height - _oldRectangle.Height) / dy;

            newEnv.Inflate(plusX, plusY);
            Envelope = newEnv;

            _oldRectangle = new RectangleF(LocationF, Size);
        }

        protected override void UpdateThumbnail()
        {
            if (Resizing || NumericHelper.Equal(Size.Width, 0.0) || NumericHelper.Equal(Size.Height, 0.0)) return;

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

            double width = (_extents.MaxX - _extents.MinX);
            double height = (_extents.MaxY - _extents.MinY);

            var ext = new Envelope();
            ext.SetBounds(_extents.MinX + width * x1, _extents.MaxY - height * y1, _extents.MinX + width * x2,
                _extents.MaxY - height * y2);

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
        private bool RenderMap(IEnvelope extent, Size bitmapSize, Graphics g, float scale)
        {
            if (bitmapSize.Width < 1 | bitmapSize.Height < 1) return false;

            var mapExtent = extent.Clone();

            _map.Lock();

            //var startupCursor = axMap.MapCursor;
            //axMap.MapCursor = tkCursor.crsrWait;
            //bool state = axMap.ScalebarVisible;
            //axMap.ScalebarVisible = false;
            g.Clear(Color.White);

            float dx = g.Transform.OffsetX;
            float dy = g.Transform.OffsetY;
            var clip = g.ClipBounds;
            var dcPtr = g.GetHdc();

            bool result = _map.SnapShotToDC2(dcPtr, mapExtent, bitmapSize.Width, dx, dy, clip.X, clip.Y, clip.Width,
                clip.Height);
            g.ReleaseHdc(dcPtr);

            // restore settings
            //axMap.ScalebarVisible = state;
            //axMap.MapCursor = startupCursor;

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