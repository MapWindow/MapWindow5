using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Api.Map;
using MW5.Shared;

namespace MW5.Api.Legend
{
    /// <summary>
    /// One layer within the legend
    /// </summary>
    public class LegendLayer : Layer, ILegendLayer
    {
        private readonly LegendControl _legend;
        private readonly List<LayerElement> _elements; // size and positions of elements
        private readonly Dictionary<Guid, ILayerMetadataBase> _customObjects;
        private readonly Dictionary<Guid, XmlElement> _rawObjects;

        private bool _expanded;
        private object _icon;
        private bool _hideFromLegend;
        private bool _recalcHeight;
        private int _height;
        private string _symbologyCaption;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegendLayer"/> class.
        /// </summary>
        internal LegendLayer(MapControl map, LegendControl legend, int layerHandle )
            : base(map, layerHandle)
        {
            _legend = legend;   // must be the first line in constructor
            _icon = null;
            _elements = new List<LayerElement>();
            _customObjects = new Dictionary<Guid, ILayerMetadataBase>();
            _rawObjects = new Dictionary<System.Guid, XmlElement>();
            _recalcHeight = true;

            Guid = Guid.NewGuid();
            Expanded = true;
            SmallIconWasDrawn = false;
            SymbologyCaption = "";
        }

        /// <summary>
        /// Gets the unique identifier of the layer. Used internal during project serialization.
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Gets or sets the icon that appears next to this layer in the legend.
        /// Setting this value to null(nothing) removes the icon from the legend
        /// and sets it back to the default icon.
        /// </summary>
        public object Icon
        {
            get { return _icon; }

            set
            {
                if (!LegendHelper.IsSupportedPicture(value))
                {
                    throw new Exception("LegendControl Error: Invalid Group Icon type");
                }

                _icon = value;
            }
        }

        /// <summary>
        /// Gets the height of layer in the legend coordinates.
        /// </summary>
        internal int Height
        {
            get
            {
                if (_recalcHeight)
                {
                    _height = CalcHeight();
                    _recalcHeight = false;
                }
                return _height;
            }
        }

        /// <summary>
        /// Gets the height of the expanded layer.
        /// </summary>
        internal int ExpandedHeight
        {
            get { return CalcHeight(true); }
        }

        /// <summary>
        /// Gets or sets whether or not the Layer is expanded.  This shows or hides the
        /// layer's Color Scheme (if one exists).
        /// </summary>
        public bool Expanded
        {
            get { return _expanded; }

            set
            {
                _recalcHeight = true;
                _expanded = value;
                _legend.Redraw();
            }
        }

        /// <summary>
        /// Indicates whether to skip over the layer when drawing the legend.
        /// </summary>
        public bool HideFromLegend
        {
            get { return _hideFromLegend; }
            set
            {
                _hideFromLegend = value;
                _legend.Redraw();
            }
        }

        /// <summary>
        /// If you wish to display a caption (e.g. "Region") above the legend items for the layer. Set "" to disable.
        /// </summary>
        public string SymbologyCaption
        {
            get
            {
                // TODO: restore
                //if (string.IsNullOrWhiteSpace(_symbologyCaption))
                {
                    if (IsVector)
                    {
                        var sf = AxMap.get_Shapefile(Handle);
                        return sf != null ? sf.Categories.Caption : "";
                    }

                    var raster = ImageSource as IRasterSource;
                    if (raster != null)
                    {
                        switch (raster.RenderingType)
                        {
                            case RasterRendering.SingleBand:
                                return string.Format(raster.GetBandFullName(raster.ActiveBandIndex)) + ": greyscale";
                            case RasterRendering.Rgb:
                                return "RGB";
                            case RasterRendering.ColorScheme:
                                var band = raster.ActiveBand;
                                string interp = band != null ? "(" + band.ColorInterpretation + ")" : "";
                                return string.Format("Band: {0} of {1} {2}", raster.ActiveBandIndex, raster.NumBands,
                                    interp);
                            case RasterRendering.BuiltInColorTable:
                                return "Indexed";
                            case RasterRendering.Unknown:
                                return "Unknown";
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        return "RGB";
                    }
                }

                return _symbologyCaption;
            }
            set
            {
                _symbologyCaption = value;
            }
        }

        /// <summary>
        /// Gets number of items in colors scheme for image or grid
        /// </summary>
        internal int RasterSymbologyCount
        {
            get
            {
                if (ImageSource == null)
                {
                    return 0;
                }
                
                var raster = ImageSource as IRasterSource;
                if (raster != null)
                {
                    switch (raster.RenderingType)
                    {
                        case RasterRendering.SingleBand:
                            return 1;
                        case RasterRendering.Rgb:
                            return 3; // TODO: maybe 4 because of alpha
                        case RasterRendering.ColorScheme:
                            var scheme = raster.CustomColorScheme;
                            return scheme != null ? scheme.NumBreaks : 0;
                        case RasterRendering.BuiltInColorTable:
                            return raster.Bands[1].ColorTable.NumBreaks;
                    }

                    return 0;
                }
                else
                {
                    return 3;   // common RGB
                }
            }
        }

        /// <summary>
        /// Temp flag storage during drawing
        /// </summary>
        internal bool SmallIconWasDrawn { get; set; }

        /// <summary>
        /// Vertical position, is set by the LegendControl
        /// </summary>
        internal int Top;

        /// <summary>
        /// Gets or sets the data type of the layer.
        /// </summary>
        internal LegendLayerType Type
        {
            get
            {
                if (IsVector)
                {
                    var fs = FeatureSet;
                    if (fs != null)
                    {
                        switch (fs.GeometryType)
                        {
                            case GeometryType.Point:
                            case GeometryType.MultiPoint:
                                return LegendLayerType.PointShapefile;
                            case GeometryType.Polyline:
                                return LegendLayerType.LineShapefile;
                            case GeometryType.Polygon:
                                return LegendLayerType.PolygonShapefile;
                        }
                    }
                }
                else if (LayerType == LayerType.Image)
                {
                    var raster = ImageSource as IRasterSource;
                    if (raster == null)
                    {
                        return LegendLayerType.Image;
                    }

                    return raster.RenderingType == RasterRendering.Rgb ? LegendLayerType.Image : LegendLayerType.Grid;
                }

                return LegendLayerType.Invalid;
            }
        }

        internal bool IsShapefile
        {
            get { return IsVector; }
        }

        /// <summary>
        /// Returns custom object for specified key
        /// </summary>
        public T GetCustomObject<T>(Guid pluginGuid) where T : class, ILayerMetadataBase
        {
            if (_rawObjects.ContainsKey(pluginGuid))
            {
                XmlElement el = _rawObjects[pluginGuid];
                
                var o = XmlSerializationHelper.DeserializeXmlElement<T>(el);
                if (o != null)
                {
                    _rawObjects.Remove(pluginGuid);
                    _customObjects[pluginGuid] = o;
                    return o;
                }
            }

            if (_customObjects.ContainsKey(pluginGuid))
            {
                return _customObjects[pluginGuid] as T;
            }

            return default(T);
        }

        /// <summary>
        /// Sets custom object associated with layer
        /// </summary>
        public void SetCustomObject<T>(T obj, Guid key) where T: class, ILayerMetadataBase
        {
            _customObjects[key] = obj;
        }

        public void RestoreCustomObject(XmlElement el, Guid guid)
        {
            _rawObjects[guid] = el;
        }

        public void ClearCustomObjects()
        {
            _customObjects.Clear();
            _rawObjects.Clear();
        }

        /// <summary>
        /// Gets list of objects associated with layer (added by plugins).
        /// </summary>
        public IEnumerable<KeyValuePair<Guid, XmlElement>> CustomObjects
        {
            get
            {
                foreach (var item in _rawObjects)
                {
                    yield return item;
                }

                foreach (var item in _customObjects)
                {
                    yield return new KeyValuePair<Guid, XmlElement>(item.Key, item.Value.Serialize());
                }
            }
        }

        /// <summary>
        /// Gets a snapshot (bitmap) of the layer
        /// </summary>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public Bitmap Snapshot()
        {
            return _legend.LayerSnapshot(Handle);
        }

        /// <summary>
        /// Gets a snapshot (bitmap) of the layer
        /// </summary>
        /// <param name="imgWidth">Desired width in pixels of the snapshot</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public Bitmap Snapshot(int imgWidth)
        {
            return _legend.LayerSnapshot(Handle, imgWidth);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        protected internal SizeF MeasureCaption(Graphics g, Font font, int maxWidth)
        {
            return g.MeasureString(Name, font, maxWidth);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        protected internal SizeF MeasureCaption(Graphics g, Font font, int maxWidth, string otherName, StringFormat format)
        {
            return g.MeasureString(otherName, font, maxWidth, format);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        protected internal SizeF MeasureCaption(Graphics g, Font font)
        {
            return g.MeasureString(Name, font);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        protected internal SizeF MeasureCaption(Graphics g, Font font, string otherName)
        {
            return g.MeasureString(otherName, font);
        }

        /// <summary>
        /// Calculates the height of the layer
        /// </summary>
        /// <param name="useExpandedHeight">If True, the height returned is the expanded height. 
        /// Otherwise, the height is the displayed height of the layer</param>
        /// <returns>Height of layer(depends on 'Expanded' state of the layer)</returns>
        private int CalcHeight(bool useExpandedHeight)
        {
            if (_expanded && ExpansionBoxCustomHeightFunction != null)
            {
                var args = new LayerMeasureEventArgs(_layerHandle, _legend.Width, Constants.ItemHeight) { Handled = false };
                
                ExpansionBoxCustomHeightFunction.Invoke(this, args);

                if (args.Handled)
                {
                    return args.HeightToDraw + Constants.ItemHeight + (Constants.ExpandBoxTopPad*2);
                }

                return Constants.ItemHeight;
            }

            // layer name
            int ret = Constants.ItemHeightAndPad();

            bool expanded = _expanded || useExpandedHeight;

            if (Type == LegendLayerType.Grid || Type == LegendLayerType.Image)
            {
                if (RasterSymbologyCount > 0 && expanded)
                {
                    ret += Constants.CsItemHeightAndPad(); //!string.IsNullOrWhiteSpace(SymbologyCaption) ? Constants.CsItemHeightAndPad() : 0;

                    ret += RasterSymbologyCount * Constants.CsItemHeightAndPad();
                }
            }
            else
            {
                var sf = _map.get_Shapefile(Handle);

                if (sf != null && expanded)
                {
                    ret += GetCategoryHeight(sf.DefaultDrawingOptions) + Constants.VerticalPad; // default symbology

                    if (sf.Categories.Count > 0)
                    {
                        ret += Constants.CsItemHeight + Constants.VerticalPad; // caption

                        var categories = sf.Categories;
                        if (Type == LegendLayerType.LineShapefile || Type == LegendLayerType.PolygonShapefile)
                        {
                            ret += sf.Categories.Count * (Constants.CsItemHeight + Constants.VerticalPad);
                        }
                        else
                        {
                            for (var i = 0; i < sf.Categories.Count; i++)
                            {
                                ret += GetCategoryHeight(categories.Item[i].DrawingOptions);
                            }
                        }

                        ret += Constants.VerticalPad;
                    }

                    if (sf.Charts.Count > 0 && sf.Charts.NumFields > 0 && sf.Charts.Visible)
                    {
                        ret += Constants.CsItemHeightAndPad(); // caption
                        ret += sf.Charts.IconHeight;
                        ret += Constants.VerticalPad;

                        ret += sf.Charts.NumFields * Constants.CsItemHeightAndPad();
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// Calculates the height of the given category
        /// </summary>
        protected internal int GetCategoryHeight(ShapeDrawingOptions options)
        {
            if (Type == LegendLayerType.PolygonShapefile || Type == LegendLayerType.LineShapefile)
            {
                return Constants.CsItemHeight + 2;
            }

            if (Type == LegendLayerType.PointShapefile)
            {
                switch (options.PointType)
                {
                    case tkPointSymbolType.ptSymbolPicture:
                    {
                        var defaultHeight = options.Picture == null || options.Picture.IsEmpty ||
                                            ((options.Picture.Height * options.PictureScaleY) + 2 <= Constants.CsItemHeight);

                        return defaultHeight
                            ? Constants.CsItemHeight + 2
                            : (int) ((options.Picture.Height*options.PictureScaleY) + 2);
                    }

                    case tkPointSymbolType.ptSymbolFontCharacter:
                    {
                        var ratio = options.FrameVisible ? 1.4 : 0.9;
                        return (options.PointSize*ratio) + 2 <= Constants.CsItemHeight
                            ? Constants.CsItemHeight
                            : (int) (options.PointSize*ratio);
                    }

                    default:
                    {
                        return options.PointSize + 2 <= Constants.CsItemHeight
                            ? Constants.CsItemHeight + 2
                            : (int) options.PointSize + 2;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// Returns the width of icon for specified set of options
        /// </summary>
        protected internal int GetCategoryWidth(ShapeDrawingOptions options)
        {
            const int maxWidth = 100;
            if (Type == LegendLayerType.PolygonShapefile || Type == LegendLayerType.LineShapefile)
            {
                return Constants.IconWidth;
            }

            if (Type == LegendLayerType.PointShapefile)
            {
                var width = 0;
                switch (options.PointType)
                {
                    case tkPointSymbolType.ptSymbolPicture:
                        width = options.Picture == null || options.Picture.IsEmpty ||
                                (options.Picture.Width * options.PictureScaleX <= Constants.IconWidth)
                            ? Constants.IconWidth
                            : (int) (options.Picture.Width*options.PictureScaleX);
                        break;
                    case tkPointSymbolType.ptSymbolFontCharacter:
                        var ratio = options.FrameVisible ? 1.4 : 1.0;
                        width = options.PointSize*ratio <= Constants.IconWidth
                            ? Constants.IconWidth
                            : (int) (options.PointSize*ratio);
                        break;
                    default:
                        width = options.PointSize <= Constants.IconWidth ? Constants.IconWidth : (int) options.PointSize;
                        break;
                }

                return width <= maxWidth ? width : maxWidth;
            }

            return 0;
        }

        /// <summary>
        /// Calculates the maximium width of the icon for the layer going through all categories
        /// </summary>
        /// <returns></returns>
        protected internal int get_MaxIconWidth(Shapefile sf)
        {
            if (sf == null)
            {
                return 0;
            }

            var maxWidth = GetCategoryWidth(sf.DefaultDrawingOptions);
            for (var i = 0; i < sf.Categories.Count; i++)
            {
                var width = GetCategoryWidth(sf.Categories.Item[i].DrawingOptions);
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
            }

            return maxWidth;
        }

        /// <summary>
        /// Calculates the height of a layer
        /// </summary>
        /// <returns>Height of layer(depends on Expanded state of the layer)</returns>
        private int CalcHeight()
        {
            return CalcHeight(Expanded);
        }

        internal List<LayerElement> Elements
        {
            get { return _elements; }
        }

        internal void ScheduleHeightRecalc()
        {
            _recalcHeight = true;
        }

        #region Custom rendering

        // internal for now; need to see how to (and whether to) expose it to plugins

        /// <summary>
        /// Tells the legend how high your custom rendered legend will be, so that it can  arrange items around it.
        /// </summary>
        internal EventHandler<LayerMeasureEventArgs> ExpansionBoxCustomHeightFunction = null;

        /// <summary>
        /// Allows you to render the expanded region of a layer yourself. Useful with ExpansionBoxForceAllowed=true.
        /// If you use this, you must also set ExpansionBoxCustomHeightFunction.
        /// </summary>
        internal EventHandler<LayerPaintEventArgs> ExpansionBoxCustomRenderFunction = null;

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}