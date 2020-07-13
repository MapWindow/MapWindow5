using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Api.Legend.Renderer;
using MW5.Api.Map;
using MW5.Shared;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Legend control for MapWinGIS without handling mouse events. Must not be used directly used.
    /// </summary>
    public partial class LegendControlBase : UserControl
    {
        private uint _lockCount;
        private int _selectedGroupHandle;
        private int _selectedLayerHandle;
        private ImageList _icons;
        private VScrollBar _vScrollBar;
        private IContainer components;
        private GroupRenderer _groupRenderer;
        private LegendGroups _groups;
        private IMuteMap _mapControl;
        private AxMap _map;

        protected LegendHitTest HitTest;
        protected Graphics Graphics;           // output Graphics
        protected Graphics GraphicsBackBuffer;
        protected Image BackBuffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegendControlBase"/> class. 
        /// </summary>
        public LegendControlBase(IContainer components)
        {
            this.components = components;
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            _lockCount = 0;
            _selectedLayerHandle = -1;
            _selectedGroupHandle = -1;

            HitTest = new LegendHitTest(this);
            Font = new Font("Arial", 8, GraphicsUnit.Pixel);
            SelectionColor = Color.FromArgb(255, 240, 240, 240);
            ShowGroupIcons = true;
            ShowLabels = false;
            DrawLines = true;

            MouseWheel += (s, e) => OnMouseWheel(e);
        }

        #region Events

        /// <summary>
        /// Selected Layer changed event
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerSelected;

        /// <summary>
        /// Added Layer event
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerAdded;

        /// <summary>
        /// Removed Layer event
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerRemoved;

        /// <summary>
        /// Position of a layer has changed event
        /// </summary>
        public event EventHandler<PositionChangedEventArgs> LayerPositionChanged;

        /// <summary>
        /// The fire layer selected.
        /// </summary>
        /// <param name="layerHandle"> The layer handle. </param>
        protected internal void FireLayerSelected(int layerHandle)
        {
            FireEvent(this, LayerSelected, new LayerEventArgs(layerHandle));
        }

        protected internal void FireLayerAdded(int layerHandle)
        {
            FireEvent(this, LayerAdded, new LayerEventArgs(layerHandle));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the MapWinGIS.Map associated with this legend control
        /// </summary>
        /// <remarks>Note: This property must be set before manipulating layers</remarks>
        public IMuteMap Map
        {
            get
            {
                return _mapControl;
            }
            set
            {
                if (value == null) return;

                _map = value.InternalObject as AxMap;

                if (_map == null)
                {
                    throw new ApplicationException("Invalid map control reference.");
                }

                _mapControl = value;
            }
        }

        /// <summary>
        /// List of groups added to the legend.
        /// </summary>
        [Browsable(false)]
        public ILegendGroups Groups
        {
            get { return _groups; }
            protected set { _groups = value as LegendGroups; }
        }

        /// <summary>
        /// List of layers added to the legend.
        /// </summary>
        [Browsable(false)]
        public virtual LayerCollection<ILegendLayer> Layers { get; protected set; }

        public ImageList Icons
        {
            get { return _icons; }
        }

        public VScrollBar VScrollBar
        {
            get { return _vScrollBar; }
        }

        public int SelectedGroupHandle 
        {
            get { return _selectedGroupHandle; }
            set { _selectedGroupHandle = value; }
        }

        public GroupRenderer Renderer
        {
            get { return _groupRenderer ?? (_groupRenderer = new GroupRenderer(this)); }
        }

        /// <summary>
        /// Toggles the layer preview visiblity in the legend
        /// </summary>
        public bool ShowLabels { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to draw lines between group and layer within this group.
        /// </summary>
        public bool DrawLines { get; set; }

        /// <summary>
        /// Gets or Sets the background color of the selected layer within the legend
        /// </summary>
        public Color SelectionColor { get; set; }

        /// <summary>
        /// Gets or Sets the background color of the selected layer within the legend
        /// </summary>
        public bool ShowGroupIcons { get; set; }

        /// <summary>
        /// Gets or Sets the Selected layer within the legend
        /// </summary>
        [Browsable(false)]
        public int SelectedLayerHandle
        {
            get
            {
                return _map == null || Layers.Count == 0 ? -1 : _selectedLayerHandle;
            }

            set
            {
                if (_map == null) return;

                int groupIndex, layerIndex;

                if (_selectedLayerHandle != value && FindLayerByHandle(value, out groupIndex, out layerIndex) != null)
                {
                    // only redraw if the selected layer is changing and the handle is valid
                    _selectedLayerHandle = value;
                    _selectedGroupHandle = _groups[groupIndex].Handle;

                    FireLayerSelected(value);

                    Redraw();
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected layer.
        /// </summary>
        public ILegendLayer SelectedLayer
        {
            get
            {
                int handle = SelectedLayerHandle;
                return handle != -1 ? Layers.ItemByHandle(SelectedLayerHandle) : null;
            }
            set
            {
                if (value != null)
                {
                    SelectedLayerHandle = value.Handle;
                }
            }
        }

        /// <summary>
        /// Gets whether or not the legend is locked.  See Lock() function for description
        /// </summary>
        public bool Locked
        {
            get { return _lockCount > 0; }
        }

        internal AxMap AxMap
        {
            get { return _map; }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Redraw the LegendControl if not locked - See 'Locked' Property for more details
        /// </summary>
        public void Redraw(LegendRedraw redrawType = LegendRedraw.LegendOnly)
        {
            switch (redrawType)
            {
                case LegendRedraw.LegendOnly:
                    RedrawCore();
                    break;
                case LegendRedraw.LegendAndMap:
                    _map.Redraw();
                    RedrawCore();
                    break;
                case LegendRedraw.LegendAndMapForce:
                    bool locked = _map.IsLocked == tkLockMode.lmLock;
                    if (locked)
                    {
                        _map.LockWindow(tkLockMode.lmUnlock);
                    }

                    _map.Redraw();

                    if (locked)
                    {
                        _map.LockWindow(tkLockMode.lmLock);
                    }

                    RedrawCore();
                    break;
            }
        }

        /// <summary>
        /// Locks the LegendControl, stopping it from redrawing until it is unlocked.
        /// Use this as a way of adding multiple layers without redrawing between each layer being added.
        /// Make sure to Unlock the LegendControl when done.
        /// </summary>
        public void Lock()
        {
            _lockCount++;
        }

        /// <summary>
        /// Unlocks the legend.  See Lock() function for description
        /// </summary>
        public void Unlock()
        {
            if (_lockCount > 0)
            {
                _lockCount--;
            }

            if (_lockCount == 0)
            {
                Redraw();
            }
        }

        public LegendGroup FindClickedGroup(Point point, out bool inCheckbox, out bool inExpandbox)
        {
            return HitTest.FindClickedGroup(point, out inCheckbox, out inExpandbox);
        }

        public LegendLayer FindClickedLayer(Point point, out LegendElement element)
        {
            return HitTest.FindClickedLayer(point, out element);
        }

        #endregion

        #region Snapshot

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public Bitmap Snapshot()
        {
            return Snapshot(false, 200);
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="imgWidth"> Width in pixels of the desired Snapshot </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        public Bitmap Snapshot(int imgWidth)
        {
            return Snapshot(false, imgWidth);
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="visibleLayersOnly"> Only visible layers used in Snapshot? </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        public Bitmap Snapshot(bool visibleLayersOnly)
        {
            return Snapshot(visibleLayersOnly, 200);
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font.
        /// </summary>
        /// <param name="visibleLayersOnly">  Only visible layers used in Snapshot? </param>
        /// <param name="useFont"> Which font to use for legend text? </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        public Bitmap Snapshot(bool visibleLayersOnly, Font useFont)
        {
            var o = Font;
            Font = useFont;
            var b = Snapshot(visibleLayersOnly, 200);
            Font = o;
            return b;
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font and width.
        /// </summary>
        /// <param name="visibleLayersOnly">  Only visible layers used in Snapshot? </param>
        /// <param name="imgWidth">  Width of the image. </param>
        /// <param name="useFont">  Which font to use for legend text? </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        public Bitmap Snapshot(bool visibleLayersOnly, int imgWidth, Font useFont)
        {
            var o = Font;
            Font = useFont;
            var b = Snapshot(visibleLayersOnly, imgWidth);
            Font = o;
            return b;
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font and width.
        /// </summary>
        /// <param name="visibleLayersOnly">  Only visible layers used in Snapshot? </param>
        /// <param name="imgWidth"> Width of the image. </param>
        /// <param name="useFont"> Which font to use for legend text? </param>
        /// <param name="foreColor"> The fore Color. </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        public Bitmap Snapshot(bool visibleLayersOnly, int imgWidth, Font useFont, Color foreColor)
        {
            var fore = ForeColor;
            ForeColor = foreColor;

            var o = Font;
            Font = useFont;

            Bitmap b;
            try
            {
                Lock();
                b = Snapshot(visibleLayersOnly, imgWidth, useFont);
            }
            finally
            {
                ForeColor = fore;
                Font = o;
                Unlock();
            }

            return b;
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="visibleLayersOnly"> Only visible layers used in Snapshot? </param>
        /// <param name="imgWidth"> Width in pixels of the desired Snapshot </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        public Bitmap Snapshot(bool visibleLayersOnly, int imgWidth)
        {
            var imgHeight = 0; // = CalcTotalDrawHeight(true);
            var rect = new Rectangle(0, 0, 0, 0);

            try
            {
                Bitmap bmp;
                if (visibleLayersOnly)
                {
                    var visibleLayers = new List<LegendLayer>();

                    // figure out how big the img needs to be in height
                    for (var i = Layers.Count - 1; i >= 0; i--)
                    {
                        var lyr = Layers[i] as LegendLayer;
                        if (lyr != null && lyr.Visible && !lyr.HideFromLegend)
                        {
                            imgHeight += lyr.ExpandedHeight - 1;
                            visibleLayers.Add(lyr);
                        }
                    }

                    imgHeight += Constants.ItemPad;

                    bmp = new Bitmap(imgWidth, imgHeight, CreateGraphics());
                    var g = Graphics.FromImage(bmp);
                    g.Clear(BackColor);

                    if (visibleLayers.Count > 0)
                    {
                        // set up the boundaries for the first layer
                        var lyrHeight = visibleLayers[0].ExpandedHeight;
                        rect = new Rectangle(2, 2, imgWidth - 4, lyrHeight - 1);
                    }

                    foreach (LegendLayer layer in visibleLayers)
                    {
                        Renderer.DrawLayer(g, layer, rect, true);

                        var lyrHeight = layer.ExpandedHeight;

                        rect.Y += lyrHeight - 1;
                        rect.Height = lyrHeight;
                    }
                }
                else
                {
                    // draw all layers
                    var grpCount = Groups.Count;
                    LegendGroup grp;
                    int lyrCount;

                    imgHeight = 0;

                    // figure out how tall the image is going to need to be
                    for (var i = grpCount - 1; i >= 0; i--)
                    {
                        grp = GetGroup(i);
                        lyrCount = grp.Layers.Count;
                        for (var j = lyrCount - 1; j >= 0; j--)
                        {
                            var lyr = grp.LayersList[j];
                            if (!lyr.HideFromLegend)
                            {
                                imgHeight += lyr.ExpandedHeight - 1;
                            }
                        }
                    }

                    imgHeight += Constants.ItemPad;

                    // create a new bitmap of the right size, then create a graphics object from the bitmap
                    bmp = new Bitmap(imgWidth, imgHeight, CreateGraphics());
                    var g = Graphics.FromImage(bmp);
                    g.Clear(BackColor);

                    rect = new Rectangle(2, 2, imgWidth - 4, imgHeight - 1);

                    // now draw the snapshot
                    for (var i = grpCount - 1; i >= 0; i--)
                    {
                        grp = GetGroup(i);
                        lyrCount = grp.Layers.Count;
                        for (var j = lyrCount - 1; j >= 0; j--)
                        {
                            var lyr = grp.LayersList[j];
                            if (!lyr.HideFromLegend)
                            {
                                Renderer.DrawLayer(g, lyr, rect, true);

                                var lyrHeight = lyr.ExpandedHeight;

                                rect.Y += lyrHeight - 1;
                                rect.Height = lyrHeight;
                            }
                        }
                    }
                }

                return bmp;
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to do legend snapshot", ex);
                return null;
            }
        }

        /// <summary>
        /// Gets a snapshot of a specific layer
        /// </summary>
        /// <param name="layerHandle"> layerHandle of the requested layer </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        protected internal Bitmap LayerSnapshot(int layerHandle)
        {
            return LayerSnapshot(layerHandle, 200);
        }

        /// <summary>
        /// Gets a snapshot of a specific layer
        /// </summary>
        /// <param name="layerHandle"> layerHandle of the requested layer </param>
        /// <param name="imgWidth"> </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        protected internal Bitmap LayerSnapshot(int layerHandle, int imgWidth)
        {
            if (!Layers.IsValidHandle(layerHandle))
            {
                return null;
            }

            var lyr = Layers.ItemByHandle(layerHandle) as LegendLayer;

            Bitmap bmp = null;
            if (lyr != null)
            {
                var lyrHeight = lyr.ExpandedHeight;
                bmp = new Bitmap(imgWidth, lyrHeight);
                var g = Graphics.FromImage(bmp);

                var rect = new Rectangle(0, 0, imgWidth - 1, lyrHeight - 1);
                Renderer.DrawLayer(g, lyr, rect, true);
            }

            return bmp;
        }

        #endregion

        #region Overriding UserControl members

        /// <summary>
        /// handles mouse wheel event
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (_vScrollBar.Visible)
            {
                var maxSize = _vScrollBar.Maximum - Height;

                var stepSize = _vScrollBar.SmallChange;
                if (e.Delta >= 0)
                {
                    stepSize *= -1;
                }

                if (_vScrollBar.Value + stepSize < 0)
                {
                    _vScrollBar.Value = 0;
                }
                else if (_vScrollBar.Value + stepSize > maxSize)
                {
                    _vScrollBar.Value = Math.Max(maxSize + 1, _vScrollBar.Minimum);
                }
                else
                {
                    _vScrollBar.Value += stepSize;
                }

                Redraw();
            }
        }

        /// <summary>
        /// The Control is being redrawn
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // there is an exception accidentally occuring in LegendControl.SwapBuffers; 
            // perhaps it's caused by concurrency issues; let's try a lock
            lock (this)
            {
                Graphics = e.Graphics;

                DrawNextFrame();

                Graphics = null;
            }
        }

        /// <summary>
        /// the background of the control is to be redrawn
        /// </summary>
        /// <param name="e">
        /// </param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // do nothing, this helps us avoid flicker

            // if we don't override this function, then
            // the system will clear that background before
            // we draw, causing a flicker when resizing
        }

        /// <summary>
        /// Control is being resized
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                BackBuffer = new Bitmap(Width, Height);
                GraphicsBackBuffer = Graphics.FromImage(BackBuffer);
                _vScrollBar.Top = 0;
                _vScrollBar.Height = Height;
                _vScrollBar.Left = Width - _vScrollBar.Width;
            }

            Invalidate();
        }

        #endregion

        #region Rendering

        /// <summary>
        /// The draw next frame.
        /// </summary>
        private void DrawNextFrame()
        {
            if (!Locked)
            {
                var totalHeight = _groups.TotalDrawHeight;
                Rectangle rect;

                if (totalHeight > Height)
                {
                    _vScrollBar.Minimum = 0;

                    _vScrollBar.SmallChange = totalHeight / 10;
                    _vScrollBar.LargeChange = Height;
                    _vScrollBar.Maximum = totalHeight;

                    if (_vScrollBar.Visible == false)
                    {
                        _vScrollBar.Value = 0;
                        _vScrollBar.Visible = true;
                    }

                    RecalcItemPositions();
                    rect = new Rectangle(0, -_vScrollBar.Value, Width - _vScrollBar.Width, totalHeight);
                }
                else
                {
                    _vScrollBar.Visible = false;
                    rect = new Rectangle(0, 0, Width, Height);
                }

                GraphicsBackBuffer.Clear(Color.White);

                var numGroups = _groups.Count;

                for (var i = numGroups - 1; i >= 0; i--)
                {
                    var grp = GetGroup(i);
                    grp.ScheduleHeightRecalculation();

                    if (rect.Top + grp.Height < ClientRectangle.Top)
                    {
                        // update the drawing rectangle
                        rect.Y += grp.Height + Constants.ItemPad;

                        // move on to the next group
                        continue;
                    }

                    Renderer.DrawGroup(GraphicsBackBuffer, grp, rect, false);
                    rect.Y += grp.Height + Constants.ItemPad;
                }
            }

            RenderBuffer();
        }

        /// <summary>
        /// The recalc item positions.
        /// </summary>
        private void RecalcItemPositions()
        {
            // this function calculates the top of each group and layer.
            // this is important because the click events use the stored top as
            // the way of figuring out if the item was clicked
            // and if the checkbox or expansion box was clicked
            int height = _groups.TotalDrawHeight;

            var curTop = 0;

            if (_vScrollBar.Visible)
            {
                curTop = -_vScrollBar.Value;
            }

            for (var i = _groups.Count - 1; i >= 0; i--)
            {
                var grp = GetGroup(i);
                grp.Top = curTop;

                if (grp.Expanded)
                {
                    curTop += Constants.ItemHeight;
                    for (var j = grp.Layers.Count - 1; j >= 0; j--)
                    {
                        var lyr = grp.LayersList[j];
                        if (!lyr.HideFromLegend)
                        {
                            lyr.Top = curTop;

                            curTop += lyr.Height;
                        }
                    }

                    curTop += Constants.ItemPad;
                }
                else
                {
                    curTop += grp.Height + Constants.ItemPad;
                }
            }
        }

        /// <summary>
        /// Renders the buffer.
        /// </summary>
        protected void RenderBuffer()
        {
            RenderBuffer(BackBuffer, Graphics);
        }

        /// <summary>
        /// Renders the buffer.
        /// </summary>
        protected void RenderBuffer(Image backBuffer, Graphics g)
        {
            try
            {
                // TODO: find out why sometimes there is an exception here!!!
                // checking random property to be sure the object is valid
                var k = g.DpiX;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return;
            }

            g.DrawImage(backBuffer, 0, 0);
            g.Flush(FlushIntention.Sync);
        }

        protected void SetCanvas(Graphics g)
        {
            Graphics = g;
        }

        #endregion

        #region Internal methods

        internal void UpdateSelectedLayer()
        {
            int newVal = _map.NumLayers > 0 ? _map.get_LayerHandle(_map.NumLayers - 1) : -1;
            SelectedLayerHandle = newVal;
        }

        /// <summary>
        /// Removes a layer from the list of layers
        /// </summary>
        internal bool RemoveLayer(int layerHandle, bool batch)
        {
            int groupIndex, layerIndex;
            Layer lyr = FindLayerByHandle(layerHandle, out groupIndex, out layerIndex);
            if (lyr == null)
            {
                return false;
            }

            var grp = GetGroup(groupIndex);
            grp.LayersList.RemoveAt(layerIndex);

            _map.RemoveLayer(layerHandle);

            if (layerHandle == _selectedLayerHandle && !batch)
            {
                _selectedLayerHandle = _map.NumLayers > 0 ? _map.get_LayerHandle(_map.NumLayers - 1) : -1;

                FireEvent(this, LayerSelected, new LayerEventArgs(_selectedLayerHandle));
            }

            if (!batch)
            {
                grp.RecalcHeight();
                Redraw();
            }

            FireEvent(this, LayerRemoved, new LayerEventArgs(layerHandle));

            return true;
        }

        /// <summary>
        /// Assigns all layers outside group to a new group. This allows normal functioning of the legend after map deserialization.
        /// </summary>
        /// <param name="groupName"> The group Name. </param>
        internal int AssignOrphanLayersToNewGroup(string groupName)
        {
            var g = Groups.GroupByName(groupName) as LegendGroup ?? Groups.Add(groupName) as LegendGroup;

            for (var i = 0; i < _map.NumLayers; i++)
            {
                var handle = _map.get_LayerHandle(i);
                var lyr = CreateLayer(handle, _map.get_GetObject(handle));
                g.LayersList.Add(lyr);
            }

            return g.Handle;
        }

        /// <summary>
        /// The fire event.
        /// </summary>
        internal void FireEvent<T>(object sender, EventHandler<T> handler, T args)
        {
            if (handler != null)
            {
                handler.Invoke(sender, args);
            }
        }

        /// <summary>
        /// Finds a layer given the handle
        /// </summary>
        /// <param name="handle"> layerHandle of the layer to find </param>
        /// <param name="groupIndex"> ByRef parameter that receives the index to the containing group </param>
        /// <param name="layerIndex"> ByRef parameter that receives the index of the Layer within the group </param>
        /// <returns> Layer on success, null (nothing) otherwise </returns>
        internal LegendLayer FindLayerByHandle(int handle, out int groupIndex, out int layerIndex)
        {
            groupIndex = -1;
            layerIndex = -1;

            var groupCount = _groups.Count;

            for (var i = 0; i < groupCount; i++)
            {
                var grp = GetGroup(i);
                var itemCount = grp.Layers.Count;

                for (var j = 0; j < itemCount; j++)
                {
                    var lyr = grp.LayersList[j];
                    if (lyr.Handle == handle)
                    {
                        groupIndex = i;
                        layerIndex = j;
                        return lyr;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Finds a layer by handle
        /// </summary>
        /// <param name="handle"> layerHandle of the layer to lookup </param>
        /// <returns> Layer if Successful, null (nothing) otherwise </returns>
        internal Layer FindLayerByHandle(int handle)
        {
            int groupIndex, layerIndex;
            return FindLayerByHandle(handle, out groupIndex, out layerIndex);
        }

        /// <summary>
        /// Clears all layers
        /// </summary>
        internal void ClearLayers()
        {
            _mapControl.Lock();
            Lock();

            try
            {
                var handles = Layers.Select(item => item.Handle).ToList();
                foreach (var handle in handles)
                {
                    RemoveLayer(handle, true);
                }
            }
            finally
            {
                _mapControl.Unlock();
                Unlock();
            }

            FireLayerSelected(-1);
        }

        internal LegendLayer CreateLayer(int layerHandle, object newLayer)
        {
            return new LegendLayer(_mapControl as MapControl, this, layerHandle);
        }

        /// <summary>
        /// Move a layer to a new location and/or group
        /// </summary>
        /// <param name="targetGroupHandle"> layerHandle of group into which to move the layer </param>
        /// <param name="layerHandle"> layerHandle of layer to move </param>
        /// <param name="targetPositionInGroup"> The Target Position In Group. </param>
        /// <returns> True if Layer position has changed, False otherwise </returns>
        internal bool MoveLayer(int targetGroupHandle, int layerHandle, int targetPositionInGroup = -1)
        {
            bool result;

            try
            {
                if (!Layers.IsValidHandle(layerHandle))
                {
                    throw new Exception("Invalid layerHandle.");
                }

                if (!_groups.IsValidHandle(targetGroupHandle))
                {
                    throw new Exception("Invalid target group handle.");
                }

                int sourceGroupIndex;
                int currentPositionInGroup;
                FindLayerByHandle(layerHandle, out sourceGroupIndex, out currentPositionInGroup);

                var sourceGroup = GetGroup(sourceGroupIndex);
                var destinationGroup = Groups.ItemByHandle(targetGroupHandle);

                if (currentPositionInGroup != targetPositionInGroup || sourceGroup.Handle != destinationGroup.Handle)
                {
                    var oldMapPos = _map.get_LayerPosition(layerHandle);

                    _groups.ChangeLayerPosition(
                        sourceGroup,
                        currentPositionInGroup,
                        destinationGroup,
                        targetPositionInGroup);

                    UpdateMapLayerPositions();

                    var newMapPos = _map.get_LayerPosition(layerHandle);

                    var curPos = Math.Min(oldMapPos, newMapPos);
                    var endPos = Math.Max(oldMapPos, newMapPos);

                    while (curPos <= endPos)
                    {
                        var curHandle = _map.get_LayerHandle(curPos);
                        FireEvent(
                            this,
                            LayerPositionChanged,
                            new PositionChangedEventArgs(curHandle, oldMapPos, newMapPos));
                        curPos += 1;
                    }

                    Redraw();
                }

                result = true;
            }
            catch (Exception ex)
            {
                LegendHelper.LastError = ex.Message;
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Update positions of layers within map after they changed in the legend.
        /// </summary>
        internal void UpdateMapLayerPositions()
        {
            var grpCount = _groups.Count;

            _map.LockWindow(tkLockMode.lmLock);
            for (var i = grpCount - 1; i >= 0; i--)
            {
                var grp = GetGroup(i);
                var lyrCount = grp.Layers.Count;
                for (var j = lyrCount - 1; j >= 0; j--)
                {
                    Layer lyr = grp.LayersList[j];
                    var lyrPosition = _map.get_LayerPosition(lyr.Handle);
                    _map.MoveLayerBottom(lyrPosition);
                }
            }

            _map.LockWindow(tkLockMode.lmUnlock);
        }

        internal LegendGroup GetGroup(int index)
        {
            return _groups[index] as LegendGroup;
        }

        #endregion

        #region Private methods

        private void VScrollBarScroll(object sender, ScrollEventArgs e)
        {
            var sbar = (VScrollBar)sender;
            sbar.Value = e.NewValue;
            Redraw();
        }

        private void RedrawCore()
        {
            if (!Locked)
            {
                Invalidate();
            }
        }

        #endregion
    }
}