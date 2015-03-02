using System;
using System.Collections.Generic;
using System.Drawing;
using MW5.Api.Concrete;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Summary description for Group.
    /// </summary>
    public class Group
    {
        private string _caption;
        private bool _expanded;

        /// <summary>
        /// The Handle for this Group
        /// </summary>
        protected internal int _handle;

        private int _height;
        private object _icon;
        private Visibility _visibleState;

        /// <summary>
        /// List of All Layers contained within this group
        /// </summary>
        public List<LegendLayer> Layers;

        /// <summary>
        /// A string that a developer can use to hold misc. information about this group
        /// </summary>
        public string Tag;

        /// <summary>
        /// The top position of this group
        /// </summary>
        protected internal int Top;

        private readonly LegendControl _legend;

        /// <summary>
        /// Constructor
        /// </summary>
        public Group(LegendControl leg)
        {
            // The next line MUST GO FIRST in the constructor
            _legend = leg;

            // The previous line MUST GO FIRST in the constructor
            Layers = new List<LegendLayer>();
            Expanded = true;
            VisibleState = Visibility.AllVisible;
            _handle = -1;
            Icon = null;
            StateLocked = false;
        }

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
                else
                {
                    throw new Exception("LegendControl Error: Invalid Group Icon type");
                }
            }
        }

        /// <summary>
        /// Gets the number of layers within this group
        /// </summary>
        public int LayerCount
        {
            get { return Layers.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public LegendLayer this[int layerPosition]
        {
            get
            {
                if (layerPosition >= 0 && layerPosition < Layers.Count)
                {
                    return Layers[layerPosition];
                }

                LegendHelper.LastError = "Invalid Layer Position within Group";
                return null;
            }
        }

        /// <summary>
        /// Gets the Handle (a unique identifier) to this group
        /// </summary>
        public int Handle
        {
            get { return _handle; }
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
        /// Gets the drawing height of the group
        /// </summary>
        protected internal int Height
        {
            get
            {
                RecalcHeight();
                return _height;
            }
        }

        /// <summary>
        /// Calculates the expanded height of the group
        /// </summary>
        protected internal int ExpandedHeight
        {
            get
            {
                var numLayers = Layers.Count;

                // initialize the height to just the height of the group item
                var retval = Constants.ItemHeight;

                // now add all the heights of the Layers
                for (var i = 0; i < numLayers; i++)
                {
                    var lyr = Layers[i];
                    retval += lyr.CalcHeight(true);
                }

                return retval;
            }
        }

        /// <summary>
        /// Gets or sets the visibility of the layers within this group.
        /// Note: When reading this property, it returns true if any layer is visible within
        /// this group
        /// </summary>
        public bool LayersVisible
        {
            get { return VisibleState == Visibility.AllHidden; }
            set {  VisibleState = value ? Visibility.AllVisible : Visibility.AllHidden; }
        }

        /// <summary>
        /// Gets or Sets the Visibility State for this group
        /// Note: Set cannot be vsPARTIAL_VISIBLE
        /// </summary>
        protected internal Visibility VisibleState
        {
            get { return _visibleState; }

            set
            {
                if (value == Visibility.PartialVisible)
                {
                    // not allowed
                    throw new Exception("Invalid [Property set] value: vsPARTIAL_VISIBLE");
                }

                _visibleState = value;
                UpdateLayerVisibility();
            }
        }

        /// <summary>
        /// gets or sets the locked property, which prevents the user from changing the visual state 
        /// except layer by layer
        /// </summary>
        public bool StateLocked { get; set; }

        /// <summary>
        /// Looks up a Layer by Handle within this group
        /// </summary>
        /// <param name="handle">Handle of the Layer to lookup</param>
        /// <returns>Layer item if successful, null (nothing) on failure</returns>
        protected internal Layer LayerByHandle(int handle)
        {
            var count = Layers.Count;
            for (var i = 0; i < count; i++)
            {
                Layer lyr = Layers[i];
                if (lyr.Handle == handle)
                {
                    return lyr;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the Layer's position (index) within a group
        /// </summary>
        /// <param name="handle">Layer Handle</param>
        /// <returns>0-Based index of the Layer on success, -1 on failure</returns>
        protected internal int LayerPositionInGroup(int handle)
        {
            var count = Layers.Count;
            for (var i = 0; i < count; i++)
            {
                Layer lyr = Layers[i];
                if (lyr.Handle == handle)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Gets the layer handle of the specified layer
        /// </summary>
        /// <param name="positionInGroup">0 based index into list of layers</param>
        /// <returns>Layer's handle on success, -1 on failure</returns>
        public int LayerHandle(int positionInGroup)
        {
            if (positionInGroup >= 0 && positionInGroup < Layers.Count)
            {
                return Layers[positionInGroup].Handle;
            }

            LegendHelper.LastError = "Invalid layer position within group";
            return -1;
        }

        /// <summary>
        /// Recalculates the Height of the Group
        /// </summary>
        protected internal void RecalcHeight()
        {
            var numLayers = Layers.Count;

            // initialize the height to just the height of the group item
            _height = Constants.ItemHeight;

            if (_expanded)
            {
                // now add all the heights of the Layers
                for (var i = 0; i < numLayers; i++)
                {
                    var lyr = Layers[i];
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
        }

        private void UpdateLayerVisibility()
        {
            var numLayers = Layers.Count;
            var visible = _visibleState == Visibility.AllVisible;

            for (var i = 0; i < numLayers; i++)
            {
                var lyr = Layers[i];
                var oldState = _legend._map.get_LayerVisible(lyr.Handle);

                _legend._map.set_LayerVisible(lyr.Handle, visible);

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
            var numLayers = Layers.Count;
            for (var i = 0; i < numLayers; i++)
            {
                Layer lyr = Layers[i];
                if (_legend._map.get_LayerVisible(lyr.Handle))
                {
                    numVisible++;
                }
            }

            if (numVisible == numLayers)
            {
                _visibleState = Visibility.AllVisible;
            }
            else if (numVisible == 0)
            {
                _visibleState = Visibility.AllHidden;
            }
            else
            {
                _visibleState = Visibility.PartialVisible;
            }
        }

        /// <summary>
        /// Returns a snapshot image of this group
        /// </summary>
        /// <param name="imgWidth">Width in pixels of the returned image (height is determined by the number of layers in the group)</param>
        /// <returns>Bitmap of the group and sublayers (expanded)</returns>
        public Bitmap Snapshot(int imgWidth)
        {
            Bitmap bmp = null; // = new Bitmap(imgWidth,imgHeight);

            Graphics g;

            bmp = new Bitmap(imgWidth, ExpandedHeight);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            var rect = new Rectangle(0, 0, imgWidth, ExpandedHeight);

            _legend.DrawGroup(g, this, rect, true);

            return bmp;
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font, int maxWidth)
        {
            return g.MeasureString(Text, font, maxWidth);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font)
        {
            return g.MeasureString(Text, font);
        }
    }
}