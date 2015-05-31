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
    /// Legend control for MapWinGIS.
    /// </summary>
    [ToolboxBitmap(typeof(MapControl), "Resources.MapWinLegend.ico")]       // TODO: test it
    public class LegendControl : UserControl, ILegend
    {
        private LayerCollection<ILegendLayer> _layers;
        private readonly LegendGroups _groups;

        private Image _backBuffer;
        private Image _midBuffer;
        private Graphics _draw;
        private Graphics _graphics;
        private Font _font;
        private uint _lockCount;
        
        private int _selectedGroupHandle;
        private int _selectedLayerHandle;
        private VScrollBar _vScrollBar;
        private IContainer components;

        private readonly Font _boldFont;
        
        private readonly DragInfo _dragInfo = new DragInfo();

        private IMuteMap _mapControl; 
        private AxMap _map;
        
        internal ImageList Icons;
        private GroupRenderer _groupRenderer;
        private LegendHitTest _hitTest;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegendControl"/> class. 
        /// This is the constructor for the <c>LegendControl</c> control.
        /// </summary>
        public LegendControl(IContainer components)
        {
            this.components = components;
            InitializeComponent();

            _groups = new LegendGroups(this);
            _hitTest = new LegendHitTest(this);

            _lockCount = 0;
            _selectedLayerHandle = -1;
            _selectedGroupHandle = -1;
            _font = new Font("Arial", 8);
            _boldFont = new Font("Arial", 8, FontStyle.Bold);

            SelectionColor = Color.FromArgb(255, 240, 240, 240);
            ShowGroupIcons = true;
            ShowLabels = false;
            DrawLines = true;

            MouseWheel += (s, e) => OnMouseWheel(e);
        }


        internal VScrollBar VScrollBar
        {
            get { return _vScrollBar; }
        }

        internal int SelectedGroupHandle 
        {
            get { return _selectedGroupHandle; }
        }

        internal Font BoldFont
        {
            get { return _boldFont; }
        }

        public GroupRenderer Renderer
        {
            get { return _groupRenderer ?? (_groupRenderer = new GroupRenderer(_map, this)); }
        }

        /// <summary>
        /// Gets or Sets the MapWinGIS.Map associated with this legend control
        /// Note: This property must be set before manipulating layers
        /// </summary>
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

        internal AxMap AxMap
        {
            get { return _map; }
        }

        /// <summary>
        /// Toggles the layer preview visiblity in the legend
        /// </summary>
        /// <returns></returns>
        public bool ShowLabels { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to draw lines between group and layer within this group.
        /// </summary>
        public bool DrawLines { get; set; }

        /// <summary>
        /// Gets the Menu for manipulating Groups
        /// </summary>
        public ILegendGroups Groups
        {
            get { return _groups; }
        }

        /// <summary>
        /// Gets the Menu for manipulating Layers (without respect to groups)
        /// </summary>
        [Browsable(false)]
        public LayerCollection<ILegendLayer> Layers
        {
            get { return _layers ?? (_layers = new LayerCollection<ILegendLayer>(_mapControl as MapControl, this)); }
        }

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

        public ILegendLayer SelectedLayer
        {
            get
            {
                int handle = SelectedLayerHandle;
                return handle != -1 ? _layers.ItemByHandle(SelectedLayerHandle) : null;
            }
            set
            {
                if (value != null)
                {
                    SelectedLayerHandle = value.Handle;
                }
            }
        }

        internal Font InternalFont
        {
            get { return _font; }
        }

        internal void SetSelectedGroup(int groupHandle)
        {
            _selectedGroupHandle = groupHandle;
        }

        internal void UpdateSelectedLayer()
        {
            int newVal = _map.NumLayers > 0 ? _map.get_LayerHandle(_map.NumLayers - 1) : -1;
            SelectedLayerHandle = newVal;
        }

        /// <summary>
        /// Gets whether or not the legend is locked.  See Lock() function for description
        /// </summary>
        public bool Locked
        {
            get { return _lockCount > 0; }
        }

        /// <summary>
        /// The fire event.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="handler"> The handler. </param>
        /// <param name="args"> The args. </param>
        protected internal void FireEvent<T>(object sender, EventHandler<T> handler, T args)
        {
            if (handler != null)
            {
                handler.Invoke(sender, args);
            }
        }

        /// <summary>
        /// The fire layer selected.
        /// </summary>
        /// <param name="layerHandle"> The layer handle. </param>
        protected internal void FireLayerSelected(int layerHandle)
        {
            FireEvent(this, LayerSelected, new LayerEventArgs(layerHandle));
        }

        /// <summary>
        /// The fire layer visible changed.
        /// </summary>
        /// <param name="layerHandle"> The layer handle. </param>
        /// <param name="visible"> The visible. </param>
        /// <param name="cancel"> The cancel. </param>
        protected internal void FireLayerVisibleChanged(int layerHandle, bool visible, ref bool cancel)
        {
            var args = new LayerCancelEventArgs(layerHandle, visible) {Cancel = cancel};
            FireEvent(this, LayerVisibleChanged, args);
            cancel = args.Cancel;
        }

        protected internal void FireGroupAdded(int groupHandle)
        {
            FireEvent(this, GroupAdded, new GroupEventArgs(groupHandle));
        }

        protected internal void FireGroupRemoved(int groupHandle)
        {
            FireEvent(this, GroupRemoved, new GroupEventArgs(groupHandle));
        }

        protected internal void FireLayerAdded(int layerHandle)
        {
            FireEvent(this, LayerAdded, new LayerEventArgs(layerHandle));
        }

        protected internal void FireGroupPositionChanged(int groupHandle, int oldPos, int newPos)
        {
            FireEvent(
                      this,
                      GroupPositionChanged,
                      new PositionChangedEventArgs(groupHandle, oldPos, newPos));  
        }

        /// <summary>
        /// Destructor for the legend
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegendControl));
            this._vScrollBar = new System.Windows.Forms.VScrollBar();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // _vScrollBar
            // 
            resources.ApplyResources(this._vScrollBar, "_vScrollBar");
            this._vScrollBar.Name = "_vScrollBar";
            this._vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VScrollBarScroll);
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "img_raster.png");
            this.Icons.Images.SetKeyName(1, "");
            this.Icons.Images.SetKeyName(2, "");
            this.Icons.Images.SetKeyName(3, "");
            this.Icons.Images.SetKeyName(4, "");
            this.Icons.Images.SetKeyName(5, "");
            this.Icons.Images.SetKeyName(6, "img_label.png");
            this.Icons.Images.SetKeyName(7, "img_label_grey.png");
            this.Icons.Images.SetKeyName(8, "pen.png");
            this.Icons.Images.SetKeyName(9, "database5.png");
            this.Icons.Images.SetKeyName(10, "img_folder_open.png");
            this.Icons.Images.SetKeyName(11, "img_folder_open.png");
            this.Icons.Images.SetKeyName(12, "tag_gray.png");
            this.Icons.Images.SetKeyName(13, "tag_blue.png");
            this.Icons.Images.SetKeyName(14, "");
            // 
            // LegendControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._vScrollBar);
            this.Name = "LegendControl";
            resources.ApplyResources(this, "$this");
            this.DoubleClick += new System.EventHandler(this.LegendDoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LegendControl_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LegendMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LegendMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LegendMouseUp);
            this.ResumeLayout(false);

        }

        #endregion Component Designer generated code

        /// <summary>
        /// Removes a layer from the list of layers
        /// </summary>
        /// <param name="layerHandle"> layerHandle of layer to be removed </param>
        /// <returns> True on success, False otherwise </returns>
        protected internal bool RemoveLayer(int layerHandle)
        {
            int groupIndex, layerIndex;
            Layer lyr = FindLayerByHandle(layerHandle, out groupIndex, out layerIndex);
            if (lyr == null)
            {
                return false;
            }

            var grp = _groups.GetGroupInternal(groupIndex);
            grp.LayersInternal.RemoveAt(layerIndex);

            _map.RemoveLayer(layerHandle);

            if (layerHandle == _selectedLayerHandle)
            {
                _selectedLayerHandle = _map.get_LayerHandle(_map.NumLayers - 1);

                FireEvent(this, LayerSelected, new LayerEventArgs(_selectedLayerHandle));
            }

            grp.RecalcHeight();
            Redraw();

            FireEvent(this, LayerRemoved, new LayerEventArgs(layerHandle));

            return true;
        }
        
        /// <summary>
        /// Renders the buffer.
        /// </summary>
        private void RenderBuffer()
        {
            RenderBuffer(_backBuffer, _graphics);
        }

        /// <summary>
        /// Renders the buffer.
        /// </summary>
        private void RenderBuffer(Image backBuffer, Graphics g)
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

        /// <summary>
        /// The create layer.
        /// </summary>
        internal LegendLayer CreateLayer(int layerHandle, object newLayer)
        {
            return new LegendLayer(_mapControl as MapControl, this, layerHandle);
        }

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
            var o = _font;
            _font = useFont;
            var b = Snapshot(visibleLayersOnly, 200);
            _font = o;
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
            var o = _font;
            _font = useFont;
            var b = Snapshot(visibleLayersOnly, imgWidth);
            _font = o;
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

            var o = _font;
            _font = useFont;

            Bitmap b;
            try
            {
                Lock();
                b = Snapshot(visibleLayersOnly, imgWidth, useFont);
            }
            finally
            {
                ForeColor = fore;
                _font = o;
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
                    for (var i = _layers.Count - 1; i >= 0; i--)
                    {
                        var lyr = _layers[i] as LegendLayer;
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
                        grp = _groups.GetGroupInternal(i);
                        lyrCount = grp.Layers.Count;
                        for (var j = lyrCount - 1; j >= 0; j--)
                        {
                            var lyr = grp.LayersInternal[j];
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
                        grp = _groups.GetGroupInternal(i);
                        lyrCount = grp.Layers.Count;
                        for (var j = lyrCount - 1; j >= 0; j--)
                        {
                            var lyr = grp.LayersInternal[j];
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

        /// <summary>
        /// The has transparency.
        /// </summary>
        /// <param name="newLayer"> The new layer. </param>
        internal bool HasTransparency(object newLayer)
        {
            try
            {
                var img = newLayer as MapWinGIS.Image;
                if (img != null)
                {
                    if (img.UseTransparencyColor)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var str = ex.Message;
            }

            return false;
        }

        /// <summary>
        /// Finds a layer given the handle
        /// </summary>
        /// <param name="handle"> layerHandle of the layer to find </param>
        /// <param name="groupIndex"> ByRef parameter that receives the index to the containing group </param>
        /// <param name="layerIndex"> ByRef parameter that receives the index of the Layer within the group </param>
        /// <returns> Layer on success, null (nothing) otherwise </returns>
        protected internal LegendLayer FindLayerByHandle(int handle, out int groupIndex, out int layerIndex)
        {
            groupIndex = -1;
            layerIndex = -1;

            var groupCount = _groups.Count;

            for (var i = 0; i < groupCount; i++)
            {
                var grp = _groups.GetGroupInternal(i);
                var itemCount = grp.Layers.Count;

                for (var j = 0; j < itemCount; j++)
                {
                    var lyr = grp.LayersInternal[j];
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
        protected internal Layer FindLayerByHandle(int handle)
        {
            int groupIndex, layerIndex;
            return FindLayerByHandle(handle, out groupIndex, out layerIndex);
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
            return _hitTest.FindClickedGroup(point, out inCheckbox, out inExpandbox);
        }

        public LegendLayer FindClickedLayer(Point point, ref ClickedElement element)
        {
            return _hitTest.FindClickedLayer(point, ref element);
        }

        /// <summary>
        /// Control is being resized
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                _backBuffer = new Bitmap(Width, Height);
                _draw = Graphics.FromImage(_backBuffer);
                _vScrollBar.Top = 0;
                _vScrollBar.Height = Height;
                _vScrollBar.Left = Width - _vScrollBar.Width;
            }

            Invalidate();
        }

        private void RedrawCore()
        {
            if (!Locked)
            {
                Invalidate();
            }
        }

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
        /// Clears all layers
        /// </summary>
        protected internal void ClearLayers()
        {
            foreach (var g in _groups)
            {
                var legendGroup = g as LegendGroup;
                if (legendGroup != null)
                {
                    legendGroup.LayersInternal.Clear();
                }
            }

            _map.RemoveAllLayers();

            Redraw();

            FireLayerSelected(-1);
        }

        /// <summary>
        /// Clears all groups
        /// </summary>
        protected internal void ClearGroups()
        {
            _map.RemoveAllLayers();
            Redraw();
        }

        /// <summary>
        /// The calc total draw height.
        /// </summary>
        private int CalcTotalDrawHeight()
        {
            int retval = 0;

            for (var i = 0; i < _groups.Count; i++)
            {
                var g = _groups.GetGroupInternal(i);
                g.RecalcHeight();
                retval += g.Height + Constants.ItemPad;
            }

            return retval;
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
            CalcTotalDrawHeight();

            var curTop = 0;

            if (_vScrollBar.Visible)
            {
                curTop = -_vScrollBar.Value;
            }

            for (var i = _groups.Count - 1; i >= 0; i--)
            {
                var grp = _groups.GetGroupInternal(i);
                grp.Top = curTop;
                if (grp.Expanded)
                {
                    curTop += Constants.ItemHeight;
                    for (var j = grp.Layers.Count - 1; j >= 0; j--)
                    {
                        var lyr = grp.LayersInternal[j];
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
        /// The draw next frame.
        /// </summary>
        private void DrawNextFrame()
        {
            if (!Locked)
            {
                var totalHeight = CalcTotalDrawHeight();
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

                _draw.Clear(Color.White);

                var numGroups = _groups.Count;

                for (var i = numGroups - 1; i >= 0; i--)
                {
                    var grp = _groups.GetGroupInternal(i);
                    grp.ScheduleHeightRecalc();

                    if (rect.Top + grp.Height < ClientRectangle.Top)
                    {
                        // update the drawing rectangle
                        rect.Y += grp.Height + Constants.ItemPad;

                        // move on to the next group
                        continue;
                    }

                    Renderer.DrawGroup(_draw, grp, rect, false);
                    rect.Y += grp.Height + Constants.ItemPad;

                    if (rect.Top >= ClientRectangle.Bottom)
                    {
                    }
                }
            }

            RenderBuffer();
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
                SetCanvas(e.Graphics);

                DrawNextFrame();

                SetCanvas(null);
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
        /// The handle left mouse down.
        /// </summary>
        private void HandleLeftMouseDown(object sender, MouseEventArgs e)
        {
            if (_dragInfo.Dragging || _dragInfo.MouseDown)
            {
                // something went wrong and the legend got locked but never got unlocked
                if (_dragInfo.LegendLocked)
                {
                    Unlock();
                }
            }

            var pnt = new Point(e.X, e.Y);

            _dragInfo.Reset();

            bool inCheckBox, inExpandBox;

            var grp = FindClickedGroup(pnt, out inCheckBox, out inExpandBox);
            if (grp != null)
            {
                if (inCheckBox)
                {
                    if (!grp.StateLocked)
                    {
                        grp.Visible = grp.Visible == Visibility.AllVisible
                            ? Visibility.AllHidden
                            : Visibility.AllVisible;

                        try
                        {
                            FireEvent(this, GroupCheckboxClicked, new GroupEventArgs(grp.Handle));
                        }
                        catch
                        {
                            // We don't care about plug-in exceptions here
                        }

                        Redraw();

                        return;
                    }
                }
                else if (inExpandBox)
                {
                    grp.Expanded = !grp.Expanded;
                    FireEvent(this, GroupExpandedChanged, new GroupEventArgs(grp.Handle));
                    Redraw();
                    return;
                }
                else
                {
                    // set up group dragging
                    if (_groups.Count > 1)
                    {
                        _dragInfo.StartGroupDrag(pnt.Y, _groups.PositionOf(grp.Handle));
                    }
                }

                FireEvent(this, GroupMouseDown, new GroupMouseEventArgs(grp.Handle, MouseButtons.Left));
                return;
            }

            // -------------------------------------------------------
            // Selecting a layer
            // -------------------------------------------------------
            var element = new ClickedElement();

            var lyr = FindClickedLayer(pnt, ref element);
            if (lyr != null)
            {
                grp = _groups.GetGroupInternal(element.GroupIndex);
                if (element.CheckBox)
                {
                    var newState = !_map.get_LayerVisible(lyr.Handle);

                    var args = new LayerCancelEventArgs(lyr.Handle, newState);
                    FireEvent(this, LayerVisibleChanged, args);

                    if (args.Cancel)
                    {
                        return;
                    }

                    _map.set_LayerVisible(lyr.Handle, newState);

                    grp = _groups.GetGroupInternal(element.GroupIndex);
                    grp.UpdateGroupVisibility();

                    FireEvent(this, LayerCheckboxClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }

                if (element.ExpansionBox)
                {
                    Lock();
                    lyr.Expanded = !lyr.Expanded;
                    FireEvent(this, LayerPropertiesChanged, new LayerEventArgs(lyr.Handle));
                    Unlock();
                    return;
                }

                if (element.ColorBox && element.CategoryIndex == -1)
                {
                    // default symbology
                    FireEvent(this, LayerStyleClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }

                if (element.LabelsIcon)
                {
                    FireEvent(this, LayerLabelsClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }

                if (element.ColorBox && element.CategoryIndex != -1)
                {
                    // category symbology
                    FireEvent(
                        this,
                        LayerCategoryClicked,
                        new LayerCategoryEventArgs(lyr.Handle, MouseButtons.Left, element.CategoryIndex));
                    Redraw();
                    return;
                }

                if (element.Charts && element.ChartFieldIndex == -1)
                {
                    // default symbology
                    FireEvent(this, LayerDiagramsClicked, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Left));
                    Redraw();
                    return;
                }

                if (element.Charts && element.ChartFieldIndex != -1)
                {
                    // category symbology
                    FireEvent(
                        this,
                        LayerChartFieldClicked,
                        new ChartFieldClickedEventArgs(lyr.Handle, MouseButtons.Left, element.ChartFieldIndex));
                    Redraw();
                    return;
                }

                // Start dragging operation only if the clicked layer is selected.
                // Otherwise LayerSelected event will be fired which might results in a dialog box 
                // from plugin code (TableEditor) and no Legend.MouseUp event (the dragging operation won't be finished).
                if (SelectedLayerHandle == lyr.Handle)
                {
                    if (_groups.Count > 1 || grp.Layers.Count > 1)
                    {
                        _dragInfo.StartLayerDrag(
                            pnt.Y,
                            _groups.PositionOf(grp.Handle),
                            grp.LayerPositionInGroup(lyr.Handle));
                    }
                }

                SelectedLayerHandle = lyr.Handle;

                FireEvent(this, LayerMouseDown, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Left));

                return;
            }

            FireEvent(this, LegendClick, new LegendClickEventArgs(MouseButtons.Left, pnt));

            Redraw();
        }

        /// <summary>
        /// The handle right mouse down.
        /// </summary>
        private void HandleRightMouseDown(object sender, MouseEventArgs e)
        {
            var pnt = new Point(e.X, e.Y);

            bool inCheckBox, inExpandBox;
            var grp = FindClickedGroup(pnt, out inCheckBox, out inExpandBox);
            if (grp != null)
            {
                if (inCheckBox == false && inExpandBox == false)
                {
                    FireEvent(this, GroupMouseDown, new GroupMouseEventArgs(grp.Handle, MouseButtons.Right));
                }
                return;
            }

            var element = new ClickedElement();
            Layer lyr = FindClickedLayer(pnt, ref element);
            if (lyr != null)
            {
                if (element.CheckBox == false && element.ExpansionBox == false)
                {
                    FireEvent(this, LayerMouseDown, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Right));
                }
                else if (element.LabelsIcon)
                {
                    FireEvent(this, LayerLabelsClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }
                return;
            }

            FireEvent(this, LegendClick, new LegendClickEventArgs(MouseButtons.Right, pnt));
        }

        /// <summary>
        /// The handle right mouse up.
        /// </summary>
        private void HandleRightMouseUp(object sender, MouseEventArgs e)
        {
            var pnt = new Point(e.X, e.Y);

            bool inCheckBox, inExpandBox;
            var grp = FindClickedGroup(pnt, out inCheckBox, out inExpandBox);
            if (grp != null)
            {
                if (inCheckBox == false && inExpandBox == false)
                {
                    FireEvent(this, GroupMouseUp, new GroupMouseEventArgs(grp.Handle, MouseButtons.Right));
                }
                return;
            }

            var element = new ClickedElement();

            Layer lyr = FindClickedLayer(pnt, ref element);
            if (lyr != null)
            {
                if (element.CheckBox == false && element.ExpansionBox == false)
                {
                    FireEvent(this, LayerMouseUp, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Right));
                }
            }
        }

        /// <summary>
        /// The legend mouse down.
        /// </summary>
        private void LegendMouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    HandleLeftMouseDown(sender, e);
                    break;
                case MouseButtons.Right:
                    HandleRightMouseDown(sender, e);
                    break;
            }


            // During the update of UI after selection of a layer focus is set to some other control;
            // TODO: would be good to explore why it happens;
            // a quick fix for now to make mouse wheel scrolling work
            if (Parent != null)
            {
                Parent.Focus();
            }
        }

        /// <summary>
        /// The handle left mouse up.
        /// </summary>
        private void HandleLeftMouseUp(object sender, MouseEventArgs e)
        {
            Capture = false;
            var pnt = new Point(e.X, e.Y);

            LegendGroup grp;

            _dragInfo.MouseDown = false;

            if (_dragInfo.Dragging)
            {
                if (_dragInfo.LegendLocked)
                {
                    _dragInfo.LegendLocked = false;
                    Unlock(); // unlock the legend
                }

                _midBuffer = null;

                if (_dragInfo.DraggingLayer)
                {
                    if (_dragInfo.TargetGroupIndex != Constants.InvalidIndex)
                    {
                        var targetGroup = Groups[_dragInfo.TargetGroupIndex];
                        grp = _groups.GetGroupInternal(_dragInfo.DragGroupIndex);

                        int newPos;

                        var layerHandle = grp.Layers[_dragInfo.DragLayerIndex].Handle;

                        if (targetGroup.Handle == grp.Handle)
                        {
                            // movement within the same group
                            int oldPos;
                            int temp;

                            FindLayerByHandle(layerHandle, out temp, out oldPos);

                            // we may have to adjust the new position if moving up in the group
                            // because the way we are using TargetLayerIndex is marking things differently
                            // than the moveLayer function expects it
                            if (oldPos < _dragInfo.TargetLayerIndex)
                            {
                                newPos = _dragInfo.TargetLayerIndex - 1;
                            }
                            else
                            {
                                newPos = _dragInfo.TargetLayerIndex;
                            }
                        }
                        else
                        {
                            // movement from one group to another group
                            newPos = _dragInfo.TargetLayerIndex;
                        }

                        MoveLayer(targetGroup.Handle, layerHandle, newPos);
                    }
                }
                else
                {
                    // we are dragging a group
                    int pos = _dragInfo.DragGroupIndex;

                    if (pos < 0 || pos >= _groups.Count)
                    {
                        _dragInfo.Reset();
                        return;
                    }

                    var grpHandle = _groups[_dragInfo.DragGroupIndex].Handle;

                    // adjust the target group index because we are setting TargetGroupIndex
                    // differently than the MoveGroup Function expects it
                    if (_dragInfo.DragGroupIndex < _dragInfo.TargetGroupIndex)
                    {
                        _dragInfo.TargetGroupIndex -= 1;
                    }

                    _groups.MoveGroup(grpHandle, _dragInfo.TargetGroupIndex);
                }

                _dragInfo.Reset();
                Redraw();
            }

            // are we completing a mouseup on a group?
            bool inCheck;
            bool inExpansion;
            grp = FindClickedGroup(pnt, out inCheck, out inExpansion);
            if (grp != null && inCheck == false && (inExpansion == false || grp.Layers.Count == 0))
            {
                FireEvent(this, GroupMouseUp, new GroupMouseEventArgs(grp.Handle, MouseButtons.Left));
                return;
            }

            // now figure out if we are completing a mouseup on a layer
            var lyr = _hitTest.FindClickedLayer(pnt, out inCheck, out inExpansion);
            if (lyr != null && inCheck == false)
            {
                if (inExpansion == false || lyr.RasterSymbologyCount == 0)
                {
                    FireEvent(this, LayerMouseUp, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Left));
                }
            }

            // if no other mouseup event is send, then send the LegendMouseUp
            FireEvent(this, LegendClick, new LegendClickEventArgs(MouseButtons.Left, pnt));
        }

        /// <summary>
        /// The update map layer positions.
        /// </summary>
        internal void UpdateMapLayerPositions()
        {
            var grpCount = _groups.Count;

            _map.LockWindow(tkLockMode.lmLock);
            for (var i = grpCount - 1; i >= 0; i--)
            {
                var grp = _groups.GetGroupInternal(i);
                var lyrCount = grp.Layers.Count;
                for (var j = lyrCount - 1; j >= 0; j--)
                {
                    Layer lyr = grp.LayersInternal[j];
                    var lyrPosition = _map.get_LayerPosition(lyr.Handle);
                    _map.MoveLayerBottom(lyrPosition);
                }
            }

            _map.LockWindow(tkLockMode.lmUnlock);
        }

        /// <summary>
        /// The legend mouse up.
        /// </summary>
        private void LegendMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HandleLeftMouseUp(sender, e);
            }

            if (e.Button == MouseButtons.Right)
            {
                HandleRightMouseUp(sender, e);
            }

            if (_dragInfo.Dragging)
            {
                if (_dragInfo.LegendLocked)
                {
                    Unlock();
                }

                _dragInfo.Reset();
            }
        }

        /// <summary>
        /// The legend_ mouse move.
        /// </summary>
        private void LegendMouseMove(object sender, MouseEventArgs e)
        {
            if (_dragInfo.MouseDown && Math.Abs(_dragInfo.StartY - e.Y) > 10)
            {
                _dragInfo.Dragging = true;
                if (_dragInfo.LegendLocked == false)
                {
                    Lock();
                    _dragInfo.LegendLocked = true;
                }
            }

            if (_dragInfo.Dragging)
            {
                FindDropLocation(e.Y);
                DrawDragLine(_dragInfo.TargetGroupIndex, _dragInfo.TargetLayerIndex);
            }
        }

        /// <summary>
        /// The draw drag line.
        /// </summary>
        /// <param name="grpIndex"> The grp index. </param>
        /// <param name="lyrIndex"> The lyr index. </param>
        private void DrawDragLine(int grpIndex, int lyrIndex)
        {
            LegendGroup grp = null;

            if (_dragInfo.Dragging)
            {
                if (grpIndex >= 0 && grpIndex < _groups.Count)
                {
                    grp = _groups.GetGroupInternal(grpIndex);
                }

                int drawY = 0;
                if (_dragInfo.DraggingLayer)
                {
                    if (grp == null)
                    {
                        return; // don't draw anything
                    }

                    var layerCount = grp.Layers.Count;

                    if (layerCount > lyrIndex && lyrIndex >= 0)
                    {
                        var itemTop = grp.LayersInternal[lyrIndex].Top;
                        drawY = itemTop + grp.LayersInternal[lyrIndex].Height;
                    }
                    else
                    {
                        // the layer is to be placed at the top of the list
                        drawY = grp.Top + Constants.ItemHeight;
                    }
                }
                else
                {
                    // we are dragging a group
                    if (grpIndex < 0 || grpIndex >= _groups.Count)
                    {
                        // the mouse is either above the top layer or below the bottom layer
                        if (grpIndex < 0)
                        {
                            var g = _groups.GetGroupInternal(0);
                            drawY =  g.Top + g.Height;
                        }
                        else
                        {
                            drawY = _groups.GetGroupInternal(_groups.Count - 1).Top;
                        }
                    }
                    else
                    {
                        if (grp != null)
                        {
                            drawY = grp.Top + grp.Height;
                        }
                    }
                }

                SetCanvas(CreateGraphics());
                if (_midBuffer == null)
                {
                    _midBuffer = new Bitmap(_backBuffer.Width, _backBuffer.Height, _draw);
                }

                var localDraw = Graphics.FromImage(_midBuffer);
                RenderBuffer(_backBuffer, localDraw);

                var pen = (Pen) Pens.Gray.Clone();
                pen.Width = 3;

                // draw a horizontal line
                localDraw.DrawLine(pen, Constants.ItemPad, drawY, Width - Constants.ItemRightPad, drawY);

                // draw the left vertical line
                localDraw.DrawLine(pen, Constants.ItemPad, drawY - 3, Constants.ItemPad, drawY + 3);

                // draw the right vertical line
                localDraw.DrawLine(
                    pen,
                    Width - Constants.ItemRightPad,
                    drawY - 3,
                    Width - Constants.ItemRightPad,
                    drawY + 3);

                RenderBuffer(_midBuffer, _graphics);
            }
        }

        private void SetCanvas(Graphics g)
        {
            _graphics = g;
        }

        /// <summary>
        /// The find drop location.
        /// </summary>
        /// <param name="yPosition"> The y position. </param>
        private void FindDropLocation(int yPosition)
        {
            _dragInfo.TargetGroupIndex = Constants.InvalidIndex;
            _dragInfo.TargetLayerIndex = Constants.InvalidIndex;

            LegendGroup grp;

            var grpCount = _groups.Count;

            if (grpCount < 1)
            {
                return;
            }

            var topGroup = _groups.GetGroupInternal(grpCount - 1);
            var bottomGroup = _groups.GetGroupInternal(0);

            if (_dragInfo.DraggingLayer)
            {
                if (yPosition >= (bottomGroup.Top + bottomGroup.Height))
                {
                    // the mouse is below the bottom layer, mark for drop at bottom
                    _dragInfo.TargetGroupIndex = 0;
                    _dragInfo.TargetLayerIndex = 0;

                    return;
                }

                if (yPosition <= topGroup.Top)
                {
                    // the mouse is above the top layer, mark for drop at top
                    _dragInfo.TargetGroupIndex = grpCount - 1;
                    _dragInfo.TargetLayerIndex = topGroup.Layers.Count;

                    return;
                }

                // not the bottom or the top, so we must search for the correct one
                for (var i = grpCount - 1; i >= 0; i--)
                {
                    grp = _groups.GetGroupInternal(i);

                    var grpHeight = grp.Height;

                    // can we drop it at the top of the group?
                    if (yPosition < grp.Top + Constants.ItemHeight)
                    {
                        _dragInfo.TargetLayerIndex = grp.Layers.Count;
                        _dragInfo.TargetGroupIndex = i;
                        return;
                    }

                    var itemCount = grp.Layers.Count;

                    if (itemCount == 0)
                    {
                        if (yPosition > grp.Top && yPosition <= grp.Top + Constants.ItemHeight)
                        {
                            _dragInfo.TargetGroupIndex = i;
                            _dragInfo.TargetLayerIndex = Constants.InvalidIndex;
                            return;
                        }
                    }
                    else if (grp.Expanded)
                    {
                        for (var j = itemCount - 1; j >= 0; j--)
                        {
                            var lyr = grp.LayersInternal[j];
                            if (yPosition <= (lyr.Top + lyr.Height))
                            {
                                // drop before this item
                                _dragInfo.TargetGroupIndex = i;
                                _dragInfo.TargetLayerIndex = j;
                                return;
                            }

                            if (j == 0)
                            {
                                // if this item is the bottom one, check to see if the item can be
                                // dropped after this item
                                if (i > 0)
                                {
                                    // if the group is not the bottom group
                                    var tempGroup = _groups.GetGroupInternal(i - 1);
                                    if (yPosition <= tempGroup.Top && yPosition > lyr.Top + lyr.Height)
                                    {
                                        _dragInfo.TargetGroupIndex = i;
                                        _dragInfo.TargetLayerIndex = 0;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (yPosition > lyr.Top + lyr.Height)
                                    {
                                        _dragInfo.TargetGroupIndex = 0;
                                        _dragInfo.TargetLayerIndex = 0;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // the group is not expanded
                        if (yPosition > grp.Top && yPosition < grp.Top + grpHeight)
                        {
                            _dragInfo.TargetGroupIndex = i;
                            _dragInfo.TargetLayerIndex = grp.Layers.Count; // put the item at the top
                        }
                    }
                }
            }
            else
            {
                // we are dragging a group
                if (yPosition > (bottomGroup.Top + bottomGroup.Height))
                {
                    // the mouse is below the bottom layer, mark for drop at bottom
                    _dragInfo.TargetGroupIndex = Constants.InvalidIndex;
                    _dragInfo.TargetLayerIndex = Constants.InvalidIndex;

                    return;
                }

                if (yPosition <= topGroup.Top)
                {
                    // the mouse is above the top Group, mark for drop at top
                    _dragInfo.TargetGroupIndex = grpCount;
                    _dragInfo.TargetLayerIndex = Constants.InvalidIndex;
                    return;
                }

                // we have to compare against all groups because we aren't at the top or bottom
                for (var i = grpCount - 1; i >= 0; i--)
                {
                    grp = _groups.GetGroupInternal(i);

                    if (yPosition < grp.Top + grp.Height)
                    {
                        _dragInfo.TargetGroupIndex = i;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Move a layer to a new location and/or group
        /// </summary>
        /// <param name="targetGroupHandle"> layerHandle of group into which to move the layer </param>
        /// <param name="layerHandle"> layerHandle of layer to move </param>
        /// <param name="targetPositionInGroup"> The Target Position In Group. </param>
        /// <returns> True if Layer position has changed, False otherwise </returns>
        protected internal bool MoveLayer(int targetGroupHandle, int layerHandle, int targetPositionInGroup = -1)
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

                var sourceGroup = _groups.GetGroupInternal(sourceGroupIndex);
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
        /// The legend double click.
        /// </summary>
        private void LegendDoubleClick(object sender, EventArgs e)
        {
            var pnt = Win32Api.GetCursorLocation();
            pnt = PointToClient(pnt);

            bool inCheckBox, inExpandBox;

            var grp = FindClickedGroup(pnt, out inCheckBox, out inExpandBox);
            if (grp != null)
            {
                if (inCheckBox == false && inExpandBox == false)
                {
                    FireEvent(this, GroupDoubleClick, new GroupEventArgs(grp.Handle));
                }
                return;
            }

            var element = new ClickedElement();

            Layer lyr = FindClickedLayer(pnt, ref element);
            if (lyr != null)
            {
                if (element.CheckBox == false && element.ExpansionBox == false)
                {
                    FireEvent(this, LayerDoubleClick, new LayerEventArgs(lyr.Handle));
                }
            }
        }

        /// <summary>
        /// The v scroll bar_ scroll.
        /// </summary>
        private void VScrollBarScroll(object sender, ScrollEventArgs e)
        {
            var sbar = (VScrollBar) sender;
            sbar.Value = e.NewValue;
            Redraw();
        }

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
                    _vScrollBar.Value = maxSize + 1;
                }
                else
                {
                    _vScrollBar.Value += stepSize;
                }

                Redraw();
            }
        }

        /// <summary>
        /// Assigns all layers outside group to a new group. This allows normal functioning of the legend after map deserialization.
        /// </summary>
        /// <param name="groupName"> The group Name. </param>
        private int AssignOrphanLayersToNewGroup(string groupName)
        {
            var g = Groups.GroupByName(groupName) as LegendGroup ?? Groups.Add(groupName) as LegendGroup;

            for (var i = 0; i < _map.NumLayers; i++)
            {
                var handle = _map.get_LayerHandle(i);
                var lyr = CreateLayer(handle, _map.get_GetObject(handle));
                g.LayersInternal.Add(lyr);
            }

            return g.Handle;
        }

        private void LegendControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (SelectedLayer != null)
                {
                    
                }
            }
        }

        /// <summary>
        /// The layer properties changed.
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerPropertiesChanged;

        /// <summary>
        /// Layer Double Click Event
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerDoubleClick;

        /// <summary>
        /// Layer Mouse Down Click Event
        /// </summary>
        public event EventHandler<LayerMouseEventArgs> LayerMouseDown;

        /// <summary>
        /// Layer Mouse Up Event
        /// </summary>
        public event EventHandler<LayerMouseEventArgs> LayerMouseUp;

        /// <summary>
        /// Group Double Click Event
        /// </summary>
        public event EventHandler<GroupEventArgs> GroupDoubleClick;

        /// <summary>
        /// Group Mouse Down Event
        /// </summary>
        public event EventHandler<GroupMouseEventArgs> GroupMouseDown;

        /// <summary>
        /// Group Mouse Up Event
        /// </summary>
        public event EventHandler<GroupMouseEventArgs> GroupMouseUp;

        /// <summary>
        /// LegendControl was clicked event (not on Group, nor on Layer)
        /// </summary>
        public event EventHandler<LegendClickEventArgs> LegendClick;

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
        /// Position of a group has changed event
        /// </summary>
        public event EventHandler<PositionChangedEventArgs> GroupPositionChanged;

        /// <summary>
        /// A Group has been added
        /// </summary>
        public event EventHandler<GroupEventArgs> GroupAdded;

        /// <summary>
        /// A Group has been removed
        /// </summary>
        public event EventHandler<GroupEventArgs> GroupRemoved;

        /// <summary>
        /// The visibility of a layer has changed event
        /// </summary>
        public event EventHandler<LayerCancelEventArgs> LayerVisibleChanged;

        /// <summary>
        /// Fires when the Group checkbox is clicked
        /// </summary>
        public event EventHandler<GroupEventArgs> GroupCheckboxClicked;

        /// <summary>
        /// Fires when the Expanded property of a group changes.
        /// </summary>
        public event EventHandler<GroupEventArgs> GroupExpandedChanged;

        /// <summary>
        /// Fires when the layer checkbox is clicked
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerCheckboxClicked;

        /// <summary>
        /// Fires when layer colorbox is clicked
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerStyleClicked;

        /// <summary>
        /// Fires when one of the shapefile categories is clicked
        /// </summary>
        public event EventHandler<LayerCategoryEventArgs> LayerCategoryClicked;

        /// <summary>
        /// Fires when charts icon is clicked
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerDiagramsClicked;

        /// <summary>
        /// Fires when one of chart fields is clicked
        /// </summary>
        public event EventHandler<ChartFieldClickedEventArgs> LayerChartFieldClicked;

        /// <summary>
        /// Fired when labels icon for the layer is clicked
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerLabelsClicked;
    }
}