namespace MW5.Api.Legend
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using MW5.Api.Concrete;

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
            this._legend = leg;

            // The previous line MUST GO FIRST in the constructor
            this.Layers = new List<LegendLayer>();
            this.Expanded = true;
            this.VisibleState = Visibility.AllVisible;
            this._handle = -1;
            this.Icon = null;
            this.StateLocked = false;
        }

        /// <summary>
        /// Gets or sets the Text that appears in the legend for this group
        /// </summary>
        public string Text
        {
            get
            {
                return this._caption;
            }

            set
            {
                this._caption = value;
                this._legend.Redraw();
            }
        }

        /// <summary>
        /// Gets or sets the icon that appears next to this group in the legend.
        /// Setting this value to null(nothing) removes the icon from the legend
        /// </summary>
        public object Icon
        {
            get
            {
                return this._icon;
            }

            set
            {
                if (LegendHelper.IsSupportedPicture(value))
                {
                    this._icon = value;
                    this._legend.Redraw();
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
            get
            {
                return this.Layers.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public LegendLayer this[int layerPosition]
        {
            get
            {
                if (layerPosition >= 0 && layerPosition < this.Layers.Count)
                {
                    return this.Layers[layerPosition];
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
            get
            {
                return this._handle;
            }
        }

        /// <summary>
        /// Gets or sets whether or not the group is expanded.  This shows or hides the 
        /// layers within this group
        /// </summary>
        public bool Expanded
        {
            get
            {
                return this._expanded;
            }

            set
            {
                if (value != this._expanded)
                {
                    this._expanded = value;
                    this.RecalcHeight();
                    this._legend.Redraw();
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
                this.RecalcHeight();
                return this._height;
            }
        }

        /// <summary>
        /// Calculates the expanded height of the group
        /// </summary>
        protected internal int ExpandedHeight
        {
            get
            {
                var NumLayers = this.Layers.Count;

                // initialize the height to just the height of the group item
                var Retval = Constants.ItemHeight;
                LegendLayer lyr;

                // now add all the heights of the Layers
                for (var i = 0; i < NumLayers; i++)
                {
                    lyr = this.Layers[i];
                    Retval += lyr.CalcHeight(true);
                }

                return Retval;
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
                if (this.VisibleState == Visibility.AllHidden)
                {
                    return false;
                }

                return true;
            }

            set
            {
                if (value)
                {
                    this.VisibleState = Visibility.AllVisible;
                }
                else
                {
                    this.VisibleState = Visibility.AllHidden;
                }
            }
        }

        /// <summary>
        /// Gets or Sets the Visibility State for this group
        /// Note: Set cannot be vsPARTIAL_VISIBLE
        /// </summary>
        protected internal Visibility VisibleState
        {
            get
            {
                return this._visibleState;
            }

            set
            {
                if (value == Visibility.PartialVisible)
                {
                    // not allowed
                    throw new Exception("Invalid [Property set] value: vsPARTIAL_VISIBLE");
                }

                this._visibleState = value;
                this.UpdateLayerVisibility();
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
            var count = this.Layers.Count;
            Layer lyr = null;
            for (var i = 0; i < count; i++)
            {
                lyr = this.Layers[i];
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
            var count = this.Layers.Count;
            for (var i = 0; i < count; i++)
            {
                Layer lyr = this.Layers[i];
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
            if (positionInGroup >= 0 && positionInGroup < this.Layers.Count)
            {
                return this.Layers[positionInGroup].Handle;
            }

            LegendHelper.LastError = "Invalid layer position within group";
            return -1;
        }

        /// <summary>
        /// Recalculates the Height of the Group
        /// </summary>
        protected internal void RecalcHeight()
        {
            var numLayers = this.Layers.Count;

            // initialize the height to just the height of the group item
            this._height = Constants.ItemHeight;

            if (this._expanded)
            {
                // now add all the heights of the Layers
                for (var i = 0; i < numLayers; i++)
                {
                    var lyr = this.Layers[i];
                    if (!lyr.HideFromLegend)
                    {
                        this._height += lyr.Height;
                    }
                }
            }
            else
            {
                this._height = Constants.ItemHeight;
            }
        }

        private void UpdateLayerVisibility()
        {
            var numLayers = this.Layers.Count;
            var visible = this._visibleState == Visibility.AllVisible;

            for (var i = 0; i < numLayers; i++)
            {
                var lyr = this.Layers[i];
                var oldState = this._legend._map.get_LayerVisible(lyr.Handle);

                this._legend._map.set_LayerVisible(lyr.Handle, visible);

                if (oldState != visible)
                {
                    var cancel = false;

                    this._legend.FireLayerVisibleChanged(lyr.Handle, visible, ref cancel);
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
            var numLayers = this.Layers.Count;
            for (var i = 0; i < numLayers; i++)
            {
                Layer lyr = this.Layers[i];
                if (this._legend._map.get_LayerVisible(lyr.Handle))
                {
                    numVisible++;
                }
            }

            if (numVisible == numLayers)
            {
                this._visibleState = Visibility.AllVisible;
            }
            else if (numVisible == 0)
            {
                this._visibleState = Visibility.AllHidden;
            }
            else
            {
                this._visibleState = Visibility.PartialVisible;
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
            Rectangle rect;

            Graphics g;

            bmp = new Bitmap(imgWidth, this.ExpandedHeight);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            rect = new Rectangle(0, 0, imgWidth, this.ExpandedHeight);

            this._legend.DrawGroup(g, this, rect, true);

            return bmp;
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font, int maxWidth)
        {
            return g.MeasureString(this.Text, font, maxWidth);
        }

        /// <summary>
        /// Measures the size of the layer's name string
        /// </summary>
        public SizeF MeasureCaption(Graphics g, Font font)
        {
            return g.MeasureString(this.Text, font);
        }
    }
}