using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Represents a group of layers (folder) in the legend.
    /// </summary>
    public class LegendGroup : ILegendGroup
    {
        private readonly LegendControl _legend;
        private readonly List<LegendLayer> _layers;
        private Visibility _visible;
        private string _caption;
        private bool _expanded;
        private int _height;
        private object _icon;
        private bool _recalcHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegendGroup"/> class.
        /// </summary>
        internal LegendGroup(LegendControl leg, int handle)
        {
            _legend = leg;
            _layers = new List<LegendLayer>();
            _icon = null;
            _recalcHeight = true;

            Handle = handle;
            Visible = Visibility.AllVisible;
            Expanded = true;
            StateLocked = false;
        }

        /// <summary>
        /// A string that a developer can use to hold misc. information about this group
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Gets the Handle (a unique identifier) to this group
        /// </summary>
        public int Handle { get; private set; }

        /// <summary>
        /// Gets or sets the locked property, which prevents the user from changing the visual state 
        /// except layer by layer
        /// </summary>
        public bool StateLocked { get; set; }

        /// <summary>
        /// Gets or sets the Text that appears in the legend for this group
        /// </summary>
        public string Text
        {
            get { return _caption; }

            set
            {
                _caption = value;
                _legend.Redraw();
            }
        }

        /// <summary>
        /// Gets or sets the icon that appears next to this group in the legend.
        /// Setting this value to null(nothing) removes the icon from the legend
        /// </summary>
        public object Icon
        {
            get { return _icon; }

            set
            {
                if (LegendHelper.IsSupportedPicture(value))
                {
                    _icon = value;
                    _legend.Redraw();    
                }

                throw new Exception("Invalid Group Icon type");
            }
        }

        /// <summary>
        /// Gets legend at the specified position within group.
        /// </summary>
        public ILegendLayer this[int layerPosition]
        {
            get
            {
                if (layerPosition >= 0 && layerPosition < _layers.Count)
                {
                    return _layers[layerPosition];
                }

                throw new IndexOutOfRangeException("Invalid Layer Position within Group");
            }
        }

        /// <summary>
        /// Gets or sets whether or not the group is expanded.  This shows or hides the 
        /// layers within this group
        /// </summary>
        public bool Expanded
        {
            get { return _expanded; }

            set
            {
                if (value != _expanded)
                {
                    _expanded = value;
                    RecalcHeight();
                    _legend.Redraw();
                }
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the layers within this group.
        /// Note: When reading this property, it returns true if any layer is visible within
        /// this group
        /// </summary>
        public bool LayersVisible
        {
            get
            {
                return Visible == Visibility.AllVisible;
            }
            set
            {
                Visible = value ? Visibility.AllVisible : Visibility.AllHidden;
            }
        }

        /// <summary>
        /// List of All Layers contained within this group
        /// </summary>
        public IReadOnlyList<ILegendLayer> Layers
        {
            get { return _layers.Cast<ILegendLayer>().ToList(); }
        }

        internal List<LegendLayer> LayersList
        {
            get { return _layers; }
        }

        /// <summary>
        /// Gets or Sets the Visibility State for this group (Note: Set cannot be PartiallyVisible)
        /// </summary>
        public Visibility Visible
        {
            get { return _visible; }

            set
            {
                if (value == Visibility.PartiallyVisible)
                {
                    throw new Exception("Invalid [Property set] value: PartiallyVisible");
                }

                _visible = value;
                UpdateLayerVisibility();
            }
        }

        /// <summary>
        /// The top position of this group
        /// </summary>
        protected internal int Top { get; set; }

        internal void ScheduleHeightRecalculation()
        {
            _recalcHeight = true;
        }

        /// <summary>
        /// Gets the drawing height of the group
        /// </summary>
        protected internal int Height
        {
            get
            {
                if (_recalcHeight)
                {
                    RecalcHeight();
                }

                return _height;
            }
        }

        /// <summary>
        /// Calculates the expanded height of the group
        /// </summary>
        private int ExpandedHeight
        {
            get
            {
                return Constants.ItemHeight + _layers.Sum(lyr => lyr.ExpandedHeight);
            }
        }

        /// <summary>
        /// Returns a snapshot image of this group
        /// </summary>
        /// <param name="imgWidth">Width in pixels of the returned image (height is determined by the number of layers in the group)</param>
        /// <returns>Bitmap of the group and sublayers (expanded)</returns>
        public Bitmap Snapshot(int imgWidth)
        {
            int expandedHeight = ExpandedHeight;
            
            var bmp = new Bitmap(imgWidth, expandedHeight);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            var rect = new Rectangle(0, 0, imgWidth, expandedHeight);

            _legend.Renderer.DrawGroup(g, this, rect, true);

            return bmp;
        }

        /// <summary>
        /// Gets the Layer's position (index) within a group
        /// </summary>
        /// <param name="handle">Layer Handle</param>
        /// <returns>0-Based index of the Layer on success, -1 on failure</returns>
        protected internal int LayerPositionInGroup(int handle)
        {
            var count = _layers.Count;
            for (var i = 0; i < count; i++)
            {
                var lyr = _layers[i];
                if (lyr != null && lyr.Handle == handle)
                {
                    return i;
                }
            }

            return -1;
        }
        
        /// <summary>
        /// Recalculates the Height of the Group
        /// </summary>
        protected internal void RecalcHeight()
        {
            _height = Constants.ItemHeight;

            if (_expanded)
            {
                foreach (var lyr in _layers)
                {
                    if (!lyr.HideFromLegend)
                    {
                        _height += lyr.Height;
                    }
                }
            }
            else
            {
                _height = Constants.ItemHeight;
            }

            _recalcHeight = false;
        }

        private void UpdateLayerVisibility()
        {
            var visible = _visible == Visibility.AllVisible;

            foreach (var lyr in _layers)
            {
                var oldState = lyr.Visible;

                lyr.Visible = visible;

                if (oldState != visible)
                {
                    var cancel = false;

                    _legend.FireLayerVisibleChanged(lyr.Handle, visible, ref cancel);
                    if (cancel)
                    {
                        lyr.Visible = !visible;
                    }
                }
            }
        }

        /// <summary>
        /// Updates the Visibility State for this group depending on the visibility of each layer within the group.
        /// </summary>
        protected internal void UpdateGroupVisibility()
        {
            var numVisible = 0;
            var numLayers = _layers.Count;
            for (var i = 0; i < numLayers; i++)
            {
                var lyr = _layers[i];
                if (lyr.Visible)
                {
                    numVisible++;
                }
            }

            if (numVisible == numLayers)
            {
                _visible = Visibility.AllVisible;
            }
            else if (numVisible == 0)
            {
                _visible = Visibility.AllHidden;
            }
            else
            {
                _visible = Visibility.PartiallyVisible;
            }
        }

        public void InsertLayer(int position, ILegendLayer layer)
        {
            if (position < 0)
            {
                position = 0;
            }
            if (position > _layers.Count)
            {
                position = _layers.Count;
            }

            if (!(layer is LegendLayer))
            {
                throw new InvalidCastException("LegendLayer class is expected");
            }

            _layers.Insert(position, (LegendLayer) layer);

            RecalcHeight();

            UpdateGroupVisibility();
        }

        public void AddLayer(ILegendLayer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            if (!(layer is LegendLayer))
            {
                throw new InvalidCastException("LegendLayer class is expected");
            }

            _layers.Add((LegendLayer)layer);

            RecalcHeight();

            UpdateGroupVisibility();
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        protected internal SizeF MeasureCaption(Graphics g, Font font, int maxWidth)
        {
            return g.MeasureString(Text, font, maxWidth);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        protected internal SizeF MeasureCaption(Graphics g, Font font)
        {
            return g.MeasureString(Text, font);
        }

        /// <summary>
        /// Gets the combined extents of all layers within the group.
        /// </summary>
        public IEnvelope Envelope
        {
            get
            {
                IEnvelope env = null;
                var layer = Layers.FirstOrDefault();
                if (layer != null)
                {
                    env = layer.Envelope;
                }

                if (env != null)
                {
                    foreach (var l in Layers)
                    {
                        env.Union(l.Envelope);
                    }
                }

                return env;
            }
        }
    }
}