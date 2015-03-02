using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Legend.Events;

namespace MW5.Api.Legend
{
    /// <summary>
    /// One layer within the legend
    /// </summary>
    public class LegendLayer : Layer
    {
        private bool _expanded;
        private object _icon;
        // private SymbologySettings m_symbologySettings = new SymbologySettings();
        // public ShapefileBinding ShapefileBinding;

        /// <summary>
        /// Color Scheme information for this layer
        /// </summary>
        protected internal ArrayList ColorLegend;

        /// <summary>
        /// If you wish to display a caption (e.g. "Region") above the legend items for a stipple scheme, set this.
        /// Set to "" to disable.
        /// </summary>
        public string ColorSchemeFieldCaption = string.Empty;

        /// <summary>
        /// Stores custom objects associated with layer
        /// </summary>
        public Hashtable CustomObjects;

        internal List<LayerElement> Elements; // size and positions of elements

        /// <summary>
        /// Tells the legend how high your custom rendered legend will be, so that it can
        /// arrange items around it.
        /// </summary>
        public EventHandler<LayerMeasureEventArgs> ExpansionBoxCustomHeightFunction = null;

        /// <summary>
        /// Allows you to render the expanded region of a layer yourself. Useful with ExpansionBoxForceAllowed=true.
        /// If you use this, you must also set ExpansionBoxCustomHeightFunction.
        /// </summary>
        public EventHandler<LayerPaintEventArgs> ExpansionBoxCustomRenderFunction = null;

        /// <summary>
        /// Allows you to force the expansion box option to be shown, e.g. you're planning to use ExpansionBoxCustomRenderFunction.
        /// </summary>
        public bool ExpansionBoxForceAllowed = false;

        /// <summary>
        /// If an image layer, this tells us if the layer contains transparency
        /// </summary>
        protected internal bool HasTransparency;

        /// <summary>
        /// Indicates what field index should be used for displaying map tooltips.
        /// </summary>
        public int MapTooltipFieldIndex = -1;

        /// <summary>
        /// Indicates whether map tooltips should be shown for this layer.
        /// </summary>
        public bool MapTooltipsEnabled = false;

        /// <summary>
        /// If you wish to display a caption (e.g. "State Name") above the legend items for a point image scheme, set this.
        /// Set to "" to disable.
        /// </summary>
        public string PointImageFieldCaption = string.Empty;

        internal bool SmallIconWasDrawn;

        /// <summary>
        /// If you wish to display a caption (e.g. "State Name") above the legend items for a coloring scheme, set this.
        /// Set to "" to disable.
        /// </summary>
        public string StippleSchemeFieldCaption = string.Empty;

        /// <summary>
        /// Top of this Layer
        /// </summary>
        protected internal int Top;

        /// <summary>
        /// (Doesn't apply to line shapefiles)
        /// Indicates whether the vertices of a line or polygon are visible.
        /// </summary>
        public bool VerticesVisible = false;

        private readonly LegendControl _legend;

        /// <summary>
        /// Constructor
        /// </summary>
        public LegendLayer(AxMap map, int layerHandle, LegendControl legend)
            : base(map, layerHandle)
        {
            // The next line MUST GO FIRST in the constructor
            _legend = legend;

            // The previous line MUST GO FIRST in the constructor
            Expanded = true;

            ColorLegend = new ArrayList();
            _icon = null;
            HasTransparency = false;

            Elements = new List<LayerElement>();

            CustomObjects = new Hashtable();
            SmallIconWasDrawn = false;

            // ShapefileBinding = new ShapefileBinding();
            // _symbologySettings = new SymbologySettings();
        }

        /// <summary>
        /// Gets or sets the data type of the layer.
        /// Note:  This property should only be set when specifying a
        /// grid layer.  Shapefile layers and image layers are automatically
        /// set to the correct value
        /// </summary>
        public LegendLayerType Type
        {
            get
            {
                // TODO: implement
                return LegendLayerType.PointShapefile;
            }
        }

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

        public int Height
        {
            get { return CalcHeight(); }
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
                _expanded = value;
                _legend.Redraw();
            }
        }

        /// <summary>
        /// Indicates whether to skip over the layer when drawing the legend.
        /// </summary>
        public bool HideFromLegend { get; set; }

        /// <summary>
        /// Returns custom object for specified key
        /// </summary>
        public object GetCustomObject(string key)
        {
            return CustomObjects[key];
        }

        /// <summary>
        /// Sets custom object associated with layer
        /// </summary>
        public void SetCustomObject(object obj, string key)
        {
            CustomObjects[key] = obj;
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
        public SizeF MeasureCaption(Graphics g, Font font, int maxWidth)
        {
            return g.MeasureString(Name, font, maxWidth);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font, int maxWidth, string otherName, StringFormat format)
        {
            return g.MeasureString(otherName, font, maxWidth, format);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font)
        {
            return g.MeasureString(Name, font);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font, string otherName)
        {
            return g.MeasureString(otherName, font);
        }

        /// <summary>
        /// Regenerates the Color Scheme associate with this layer and
        /// causes the control to redraw itself.
        /// </summary>
        public void Refresh()
        {
            _legend.Redraw();
        }

        /// <summary>
        /// Calculates the height of the layer
        /// </summary>
        /// <param name="useExpandedHeight">If True, the height returned is the expanded height. Otherwise, the height is the displayed height of the layer</param>
        /// <returns>Height of layer(depends on 'Expanded' state of the layer)</returns>
        protected internal int CalcHeight(bool useExpandedHeight)
        {
            // to affect drawing of the expansion box externally
            if (_expanded && ExpansionBoxCustomHeightFunction != null)
            {
                var args = new LayerMeasureEventArgs(_layerHandle, _legend.Width, Constants.ItemHeight)
                {
                    Handled
                        =
                        false
                };
                ExpansionBoxCustomHeightFunction.Invoke(this, args);

                if (args.Handled)
                {
                    return args.HeightToDraw + Constants.ItemHeight + (Constants.ExpandBoxTopPad*2);
                }

                return Constants.ItemHeight;
            }

            var ret = 0;

            if (Type == LegendLayerType.Grid || Type == LegendLayerType.Image)
            {
                // Our own calculation
                if (useExpandedHeight == false && (_expanded == false || ColorLegend.Count == 0))
                {
                    ret = Constants.ItemHeight;
                }
                else
                {
                    ret = Constants.ItemHeight + (ColorLegend.Count*Constants.CsItemHeight) + 2;
                }

                // Add in caption space
                if (useExpandedHeight || _expanded)
                {
                    ret += (ColorSchemeFieldCaption.Trim() != string.Empty ? Constants.CsItemHeight : 0)
                           + (StippleSchemeFieldCaption.Trim() != string.Empty ? Constants.CsItemHeight : 0);
                }
            }
            else
            {
                var sf = _map.get_Shapefile(Handle);

                if ((useExpandedHeight || _expanded) && sf != null)
                {
                    ret = Constants.ItemHeight + 2; // layer name

                    ret += GetCategoryHeight(sf.DefaultDrawingOptions) + 2; // default symbology

                    if (sf.Categories.Count > 0)
                    {
                        ret += Constants.CsItemHeight + 2; // caption

                        var categories = sf.Categories;
                        if (Type == LegendLayerType.LineShapefile || Type == LegendLayerType.PolygonShapefile)
                        {
                            ret += sf.Categories.Count*(Constants.CsItemHeight + 2);
                        }
                        else
                        {
                            for (var i = 0; i < sf.Categories.Count; i++)
                            {
                                ret += GetCategoryHeight(categories.Item[i].DrawingOptions);
                            }
                        }

                        ret += 2;
                    }

                    if (sf.Charts.Count > 0 && sf.Charts.NumFields > 0 && sf.Charts.Visible)
                    {
                        ret += Constants.CsItemHeight + 2; // caption
                        ret += sf.Charts.IconHeight;
                        ret += 2;

                        ret += sf.Charts.NumFields*(Constants.CsItemHeight + 2);
                    }
                }
                else
                {
                    ret = Constants.ItemHeight;
                }

                // TODO: Add caption space
                // if (UseExpandedHeight || _expanded)
                // ret += (ColorSchemeFieldCaption.Trim() != "" ? Constants.CS_ITEM_HEIGHT : 0) + (StippleSchemeFieldCaption.Trim() != "" ? Constants.CS_ITEM_HEIGHT : 0);
            }

            return ret;
        }

        /// <summary>
        /// Calculates the height of the given category
        /// </summary>
        public int GetCategoryHeight(ShapeDrawingOptions options)
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
                        var defaultHeight = (options.Picture.Height*options.PictureScaleY) + 2
                                            <= Constants.CsItemHeight || options.Picture == null;
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
        public int GetCategoryWidth(ShapeDrawingOptions options)
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
                        width = options.Picture.Width*options.PictureScaleX <= Constants.IconWidth
                                || options.Picture == null
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
        public int get_MaxIconWidth(Shapefile sf)
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
        protected internal int CalcHeight()
        {
            return CalcHeight(Expanded);
        }
    }
}