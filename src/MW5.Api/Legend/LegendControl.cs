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
        private const string CHARTS_CAPTION = "Charts";

        private LegendLayerCollection<ILegendLayer> _layers;
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
        private readonly IContainer components;

        private readonly Font _boldFont;
        private readonly Color _boxLineColor;
        private readonly DragInfo _dragInfo = new DragInfo();
        private readonly ToolTip _toolTip = new ToolTip();

        private IMuteMap _mapControl; 
        private AxMap _map;
        
        protected ImageList Icons;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LegendControl"/> class. 
        /// This is the constructor for the <c>LegendControl</c> control.
        /// </summary>
        public LegendControl(IContainer components)
        {
            this.components = components;
            InitializeComponent();

            _groups = new LegendGroups(this);

            _lockCount = 0;
            _selectedLayerHandle = -1;
            _selectedGroupHandle = -1;
            _font = new Font("Arial", 8);
            _boldFont = new Font("Arial", 8, FontStyle.Bold);
            _boxLineColor = Color.Gray;
            SelectionColor = Color.FromArgb(255, 240, 240, 240);
            ShowGroupIcons = true;
            ShowLabels = false;
            DrawLines = true;
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
                if (value == null)
                {
                    return;
                }
                _map = value.InternalObject as AxMap;
                if (_map == null)
                {
                    throw new ApplicationException("Invalid map control reference.");
                }
                _mapControl = value;
            }
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
        public LegendLayerCollection<ILegendLayer> Layers
        {
            get { return _layers ?? (_layers = new LegendLayerCollection<ILegendLayer>(_mapControl as MapControl, this)); }
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
                if (_map == null)
                {
                    return;
                }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegendControl));
            this._vScrollBar = new System.Windows.Forms.VScrollBar();
            this.Icons = new System.Windows.Forms.ImageList();
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
            this.Icons.Images.SetKeyName(0, "");
            this.Icons.Images.SetKeyName(1, "");
            this.Icons.Images.SetKeyName(2, "");
            this.Icons.Images.SetKeyName(3, "");
            this.Icons.Images.SetKeyName(4, "");
            this.Icons.Images.SetKeyName(5, "");
            this.Icons.Images.SetKeyName(6, "img_label.png");
            this.Icons.Images.SetKeyName(7, "img_label_grey.png");
            this.Icons.Images.SetKeyName(8, "pen.png");
            this.Icons.Images.SetKeyName(9, "database5.png");
            this.Icons.Images.SetKeyName(10, "folder.png");
            this.Icons.Images.SetKeyName(11, "folder_open.png");
            this.Icons.Images.SetKeyName(12, "tag_gray.png");
            this.Icons.Images.SetKeyName(13, "tag_blue.png");
            // 
            // LegendControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._vScrollBar);
            this.Name = "LegendControl";
            resources.ApplyResources(this, "$this");
            this.DoubleClick += new System.EventHandler(this.LegendDoubleClick);
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

            var grp = _groups.GetGroup(groupIndex);
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
        /// The draw box.
        /// </summary>
        /// <param name="drawTool">  The draw tool. </param>
        /// <param name="rect"> The rect. </param>
        /// <param name="lineColor"> The line color. </param>
        private void DrawBox(Graphics drawTool, Rectangle rect, Color lineColor)
        {
            var pen = new Pen(lineColor);

            drawTool.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// The draw box.
        /// </summary>
        /// <param name="drawTool">The draw tool. </param>
        /// <param name="rect"> The rect. </param>
        /// <param name="lineColor"> The line color. </param>
        /// <param name="backColor"> The back color. </param>
        private void DrawBox(Graphics drawTool, Rectangle rect, Color lineColor, Color backColor)
        {
            var pen = new Pen(backColor);
            drawTool.FillRectangle(pen.Brush, rect);

            pen = new Pen(lineColor);
            drawTool.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// The swap buffers.
        /// </summary>
        private void RenderBuffer()
        {
            RenderBuffer(_backBuffer, _graphics);
        }

        /// <summary>
        /// The swap buffers.
        /// </summary>
        private void RenderBuffer(Image backBuffer, Graphics g)
        {
            try
            {
                // temporary: checking random property to be sure the object is valid
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
        /// The swap buffers.
        /// </summary>
        /// <param name="backBuffer"> The back buffer. </param>
        /// <param name="frontBuffer"> The front buffer. </param>
        private void RenderBuffer(Image backBuffer, Image frontBuffer)
        {
            var draw = Graphics.FromImage(frontBuffer);
            draw.DrawImage(backBuffer, 0, 0);
            draw.Flush(FlushIntention.Sync);
        }

        /// <summary>
        /// Draws a group onto a give graphics object (surface)
        /// </summary>
        /// <param name="drawTool"> Graphics object with which to draw </param>
        /// <param name="grp"> Group to be drawn </param>
        /// <param name="bounds"> Clipping boundaries for this group </param>
        /// <param name="isSnapshot"> Drawing is handled in special way if this is a Snapshot </param>
        internal protected void DrawGroup(Graphics drawTool, LegendGroup grp, Rectangle bounds, bool isSnapshot)
        {
            int curLeft,
                curWidth,
                curTop = bounds.Top + bounds.Top,
                curHeight;

            Rectangle rect;

            var drawCheck = false;

            // Color BoxBackColor = Color.White;
            var drawGrayCheckbox = false;
            grp.Top = bounds.Top;

            if (grp.Visible == Visibility.AllVisible || grp.Visible == Visibility.PartiallyVisible)
            {
                drawCheck = true;
            }

            // draw the border if the group is the one that contains the selected layer and
            // the group is collapsed
            if (grp.Handle == _selectedGroupHandle && grp.Expanded == false && isSnapshot == false)
            {
                rect = new Rectangle(
                    Constants.GrpIndent,
                    curTop,
                    bounds.Width - Constants.GrpIndent - Constants.ItemRightPad,
                    Constants.ItemHeight);
                DrawBox(drawTool, rect, _boxLineColor, SelectionColor);
            }

            // draw the +- box if there are sub items
            if (grp.Layers.Any() && isSnapshot == false)
            {
                DrawExpansionBox(
                    drawTool,
                    bounds.Top + Constants.ExpandBoxTopPad,
                    Constants.GrpIndent + Constants.ExpandBoxLeftPad,
                    grp.Expanded);
            }

            if (grp.Visible == Visibility.PartiallyVisible)
            {
                drawGrayCheckbox = true;
            }

            if (DrawLines && !isSnapshot && grp.Expanded && grp.Layers.Any())
            {
                var endY = grp.Top + Constants.ItemHeight;

                var blackPen = new Pen(_boxLineColor);
                drawTool.DrawLine(
                    blackPen,
                    Constants.VertLineIndent,
                    bounds.Top + Constants.VertLineGrpTopOffset,
                    Constants.VertLineIndent,
                    endY);
            }

            if (bounds.Width > 35 && isSnapshot == false)
            {
                if (!grp.StateLocked)
                {
                    curLeft = Constants.GrpIndent + Constants.CheckLeftPad;
                    DrawCheckBox(
                        drawTool,
                        bounds.Top + Constants.CheckTopPad,
                        curLeft,
                        drawCheck,
                        drawGrayCheckbox);
                }
            }

            if (grp.Icon != null && bounds.Width > 55)
            {
                // draw the icon
                DrawPicture(
                    drawTool,
                    bounds.Right - Constants.IconRightPad,
                    curTop + Constants.IconTopPad,
                    Constants.IconSize,
                    Constants.IconSize,
                    grp.Icon);

                // set the boundaries for text so that the text and icon don't overlap
                curLeft = isSnapshot ? Constants.GrpIndent : Constants.GrpIndent + Constants.TextLeftPad;

                curTop = bounds.Top + Constants.TextTopPad;
                curWidth = bounds.Width - curLeft - Constants.TextRightPad;
                curHeight = Constants.TextHeight;
                rect = new Rectangle(curLeft, curTop, curWidth, curHeight);
            }
            else
            {
                // Bitmap bmp = MWLite.Symbology.Properties.Resources.folder_open;
                // DrawPicture(DrawTool, bounds.Right - Constants.ICON_RIGHT_PAD, CurTop + Constants.ICON_TOP_PAD, Constants.ICON_SIZE, Constants.ICON_SIZE, bmp);
                if (isSnapshot)
                {
                    curLeft = Constants.GrpIndent;
                }
                else
                {
                    curLeft = Constants.GrpIndent + Constants.TextLeftPad;
                }

                curTop = bounds.Top + Constants.TextTopPad;
                curWidth = bounds.Width - curLeft - Constants.TextRightPadNoIcon;
                curHeight = Constants.TextHeight;
                rect = new Rectangle(curLeft, curTop, curWidth, curHeight);
            }

             // group icon
             if (ShowGroupIcons)
             {
                 const int size = 16;
                 Bitmap bmp = Icons.GetIcon(grp.Expanded ? LegendIcon.FolderOpened : LegendIcon.Folder) as Bitmap;
                 rect.Offset(0, -2);
                 DrawPicture(drawTool, rect.Left, rect.Top, size, size, bmp);
                 rect = new Rectangle(rect.X + size + 3, rect.Y + 2, rect.Width - size, rect.Height);
             }

            // group name
            if (grp.Handle == _selectedGroupHandle && !isSnapshot)
            {
                DrawText(drawTool, grp.Text, rect, _boldFont);
            }
            else
            {
                DrawText(drawTool, grp.Text, rect, _font);
            }

            // set up the boundaries for drawing list items
            curTop = bounds.Top + Constants.ItemHeight;

            if (!grp.Expanded && !isSnapshot) return;
            
            var itemCount = grp.Layers.Count();
            var newLeft = bounds.X + Constants.ListItemIndent;
            var newWidth = bounds.Width - newLeft;
            rect = new Rectangle(newLeft, curTop, newWidth, bounds.Height - curTop);

            // now draw each of the subitems
            for (var i = itemCount - 1; i >= 0; i--)
            {
                var lyr = grp.LayersInternal[i];
                lyr.ScheduleHeightRecalc();

                if (lyr.HideFromLegend)
                {
                    continue;
                }
                
                // clipping
                if (rect.Top + lyr.Height < ClientRectangle.Top && isSnapshot == false)
                {
                    // update the rectangle for the next layer
                    rect.Y += lyr.Height;
                    rect.Height -= lyr.Height;

                    // Skip drawing this layer and move onto the next one
                    continue;
                }

                DrawLayer(drawTool, lyr, rect, isSnapshot);

                DrawLayerLines(isSnapshot, drawTool, grp, lyr, i, ref rect);

                // set up the rectangle for the next layer
                rect.Y += lyr.Height;
                rect.Height -= lyr.Height;

                if (rect.Top >= ClientRectangle.Bottom && !isSnapshot)
                {
                    break;
                }
            }
        }

        private void DrawLayerLines(bool isSnapshot, Graphics drawTool, LegendGroup grp, LegendLayer lyr, int i, ref Rectangle rect)
        {
            if (isSnapshot || !DrawLines)
            {
                return;
            }
            
            var pen = new Pen(_boxLineColor);

            // draw sub-item vertical line
            if (i != 0 && !grp.Layers[i - 1].HideFromLegend)
            {
                // not the last visible layer
                drawTool.DrawLine(
                    pen,
                    Constants.VertLineIndent,
                    lyr.Top,
                    Constants.VertLineIndent,
                    lyr.Top + lyr.Height + Constants.ItemPad);
            }
            else
            {
                // only draw down to box, not down to next item in list(since there is no next item)
                drawTool.DrawLine(
                    pen,
                    Constants.VertLineIndent,
                    lyr.Top,
                    Constants.VertLineIndent,
                    (int) (lyr.Top + (.55*Constants.ItemHeight)));
            }

            // draw Horizontal line over to the Vertical Sub-lyr line
            int curTop = (int) (rect.Top + (.5*Constants.ItemHeight));

            drawTool.DrawLine(
                pen,
                Constants.VertLineIndent,
                curTop,
                rect.Left + Constants.ExpandBoxLeftPad - 3,
                curTop);
        }

        /// <summary>
        /// The draw text.
        /// </summary>
        private void DrawText(Graphics drawTool, string text, Rectangle rect, Font font, Color penColor)
        {
            var pen = new Pen(penColor);
            drawTool.DrawString(text, font, pen.Brush, rect);
        }

        /// <summary>
        /// The draw text.
        /// </summary>
        private void DrawText(Graphics drawTool, string text, Rectangle rect, Font font)
        {
            DrawText(drawTool, text, rect, font, Color.Black);
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
                        DrawLayer(g, layer, rect, true);

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
                        grp = _groups.GetGroup(i);
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
                        grp = _groups.GetGroup(i);
                        lyrCount = grp.Layers.Count;
                        for (var j = lyrCount - 1; j >= 0; j--)
                        {
                            var lyr = grp.LayersInternal[j];
                            if (!lyr.HideFromLegend)
                            {
                                DrawLayer(g, lyr, rect, true);

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
                Debug.Print("Error: LegendControl.Snaphot. " + ex.Message);
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
                DrawLayer(g, lyr, rect, true);
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
                var grp = _groups.GetGroup(i);
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
        /// The draw check box.
        /// </summary>
        /// <param name="drawTool"> The draw tool. </param>
        /// <param name="itemTop"> The item top. </param>
        /// <param name="itemLeft"> The item left. </param>
        /// <param name="drawCheck"> The draw check. </param>
        /// <param name="drawGrayBackground"> The draw gray background. </param>
        private void DrawCheckBox(Graphics drawTool, int itemTop, int itemLeft, bool drawCheck, bool drawGrayBackground)
        {
            LegendIcon icon;
            if (drawCheck)
            {
                icon = drawGrayBackground ? LegendIcon.CheckedBoxGray : LegendIcon.CheckedBox;
            }
            else
            {
                icon = drawGrayBackground ? LegendIcon.UnCheckedBoxGray : LegendIcon.UnCheckedBox;
            }

            var image = Icons.GetIcon(icon);
            DrawPicture(drawTool, itemLeft, itemTop, Constants.CheckBoxSize, Constants.CheckBoxSize, image);
        }

        /// <summary>
        /// Draws picture in the legend. Picture can be either an image or an icon
        /// </summary>
        /// <param name="drawTool"> The Draw Tool. </param>
        /// <param name="picLeft"> The Pic Left. </param>
        /// <param name="picTop"> The Pic Top. </param>
        /// <param name="picWidth"> The Pic Width. </param>
        /// <param name="picHeight"> The Pic Height. </param>
        /// <param name="picture"> The picture. </param>
        private void DrawPicture(Graphics drawTool, int picLeft, int picTop, int picWidth, int picHeight, object picture)
        {
            if (picture == null)
            {
                return;
            }

            var oldSm = drawTool.SmoothingMode;
            drawTool.SmoothingMode = SmoothingMode.HighQuality;

            var rect = new Rectangle(picLeft, picTop, picWidth, picHeight);

            var icon = picture as Icon;

            if (icon != null)
            {
                drawTool.DrawIcon(icon, rect);
            }
            else
            {
                // try casting it to an Image
                Image img = null;
                try
                {
                    img = (Image) picture;
                }
                catch (InvalidCastException)
                {
                }

                if (img != null)
                {
                    drawTool.DrawImage(img, rect);
                }
                else
                {
                    MapWinGIS.Image mwImg = null;
                    try
                    {
                        mwImg = (MapWinGIS.Image) picture;
                    }
                    catch (InvalidCastException)
                    {
                    }

                    if (mwImg != null)
                    {
                        try
                        {
                            img = Image.FromHbitmap(new IntPtr(mwImg.Picture.Handle));
                            drawTool.DrawImage(img, rect);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            drawTool.SmoothingMode = oldSm;
        }

        /// <summary>
        /// Expansion box with plus or minus sign
        /// </summary>
        private void DrawExpansionBox(Graphics drawTool, int itemTop, int itemLeft, bool expanded)
        {
            var pen = new Pen(_boxLineColor, 1);

            var rect = new Rectangle(itemLeft, itemTop, Constants.ExpandBoxSize, Constants.ExpandBoxSize);

            // draw the border
            DrawBox(drawTool, rect, _boxLineColor, Color.White);

            var midX = (int) (rect.Left + (.5*rect.Width));
            var midY = (int) (rect.Top + (.5*rect.Height));

            if (!expanded)
            {
                // draw a + sign, indicating that there is more to be seen
                // draw the vertical part
                drawTool.DrawLine(pen, midX, itemTop + 2, midX, itemTop + Constants.ExpandBoxSize - 2);

                // draw the horizontal part
                drawTool.DrawLine(pen, itemLeft + 2, midY, itemLeft + Constants.ExpandBoxSize - 2, midY);
            }
            else
            {
                // draw a - sign
                drawTool.DrawLine(pen, itemLeft + 2, midY, itemLeft + Constants.ExpandBoxSize - 2, midY);
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

        /// <summary>
        /// Drawing procedure for the new symbology
        /// </summary>
        /// <param name="drawTool"> </param>
        /// <param name="lyr"> </param>
        /// <param name="bounds"> </param>
        /// <param name="isSnapshot"> </param>
        protected internal void DrawLayerExt(Graphics drawTool, Layer lyr, Rectangle bounds, bool isSnapshot)
        {
        }

        /// <summary>
        /// Draws a layer onto a given graphics surface
        /// </summary>
        /// <param name="drawTool"> Graphics surface (object) onto which the give layer should be drawn </param>
        /// <param name="lyr"> Layer object to be drawn </param>
        /// <param name="bounds"> Rectangle oulining the allowable draw area </param>
        /// <param name="isSnapshot"> Drawing is done differently when it is a snapshot we are takeing of this layer </param>
        protected void DrawLayer(Graphics drawTool, LegendLayer lyr, Rectangle bounds, bool isSnapshot)
        {
            lyr.SmallIconWasDrawn = false;
            lyr.Top = bounds.Top;
            lyr.Elements.Clear();

            int curLeft;
            int curTop;
            int curWidth;
            int curHeight;
            Rectangle rect;

            // ------------------------------------------------------
            // drawing background (with selection if needed)
            // ------------------------------------------------------
            if (!isSnapshot)
            {
                curLeft = bounds.Left;
                curTop = bounds.Top;
                curWidth = bounds.Width - Constants.ItemRightPad;
                curHeight = lyr.Height;
                rect = new Rectangle(curLeft, curTop, curWidth, curHeight);

                if (lyr.Handle == _selectedLayerHandle && bounds.Width > 25)
                {
                    // selects the title only
                    rect.Height = Constants.ItemHeight;

                    if (curTop + rect.Height > 0 || curTop < ClientRectangle.Height)
                    {
                        DrawBox(drawTool, rect, _boxLineColor, SelectionColor);
                    }
                }
            }
            else
            {
                curLeft = bounds.Left;
                curTop = bounds.Top;
                curWidth = bounds.Width - 1;
                curHeight = lyr.ExpandedHeight - 1;
                rect = new Rectangle(curLeft, curTop, curWidth, curHeight);

                DrawBox(drawTool, rect, _boxLineColor, Color.White);
            }

            // -------------------------------------------------------
            // drawing checkbox
            // -------------------------------------------------------
            if (bounds.Width > 55 && isSnapshot == false)
            {
                curTop = bounds.Top + Constants.CheckTopPad;
                curLeft = bounds.Left + Constants.CheckLeftPad;

                var visible = true;
                if (lyr.DynamicVisibility)
                {
                    visible = (_map.CurrentScale >= lyr.MinVisibleScale)
                              && (_map.CurrentScale <= lyr.MaxVisibleScale)
                              && _map.Tiles.CurrentZoom >= lyr.MinVisibleZoom
                              && _map.Tiles.CurrentZoom <= lyr.MaxVisibleZoom;
                }

                visible = visible && _map.get_LayerVisible(lyr.Handle);

                // draw a grey background if the layer is in dynamic visibility mode.
                DrawCheckBox(drawTool, curTop, curLeft, visible, lyr.DynamicVisibility);
            }

            // ----------------------------------------------------------
            // Drawing text
            // ----------------------------------------------------------
            var textSize = new SizeF(0.0f, 0.0f);
            if (bounds.Width > 60)
            {
                // draw text
                var text = _map.get_LayerName(lyr.Handle);
                textSize = drawTool.MeasureString(text, _font);

                if (isSnapshot)
                {
                    curLeft = bounds.Left + Constants.CheckLeftPad;
                }
                else
                {
                    curLeft = bounds.Left + Constants.TextLeftPad;
                }

                curTop = bounds.Top + Constants.TextTopPad;

                // CurWidth = bounds.Width - CurLeft - Constants.TEXT_RIGHT_PAD;
                curWidth = bounds.Width - Constants.TextRightPad - 27;
                curHeight = Constants.TextHeight;

                rect = new Rectangle(curLeft, curTop, curWidth, curHeight);
                DrawText(drawTool, text, rect, _font, ForeColor);

                var el = new LayerElement(LayerElementType.Name, rect, text);
                lyr.Elements.Add(el);
            }

            // -------------------------------------------------------------
            // Drawing layer icon
            // -------------------------------------------------------------
            if (bounds.Width > 60 && bounds.Right - curLeft - 41 > textSize.Width)
            {
                // -5 (offset)
                var top = bounds.Top + Constants.IconTopPad;
                var left = bounds.Right - 36;
                Image icon;

                var ogrLayer = lyr.VectorLayer;
                if (ogrLayer != null)
                {
                    icon = Icons.GetIcon(LegendIcon.Database);
                    DrawPicture(drawTool, left, curTop, Constants.IconSize, Constants.IconSize, icon);
                }
                else if (lyr.Icon != null)
                {
                    DrawPicture(drawTool, left, curTop, Constants.IconSize, Constants.IconSize, lyr.Icon);
                }
                else if (lyr.Type == LegendLayerType.Image)
                {
                    icon = Icons.GetIcon(LegendIcon.Image);
                    DrawPicture(drawTool, left, top, Constants.IconSize, Constants.IconSize, icon);
                }
                else if (lyr.Type == LegendLayerType.Grid)
                {
                    icon = Icons.GetIcon(LegendIcon.Grid);
                    DrawPicture(drawTool, left, top, Constants.IconSize, Constants.IconSize, icon);
                }
                else
                {
                    // drawing shapefile symbology preview, but only in case the layer is collapsed
                    if (!lyr.Expanded)
                    {
                        lyr.SmallIconWasDrawn = true;

                        // drawing category symbol
                        var hdc = drawTool.GetHdc();
                        var clr = (lyr.Handle == _selectedLayerHandle && bounds.Width > 25)
                            ? SelectionColor
                            : BackColor;
                        var backColor = Convert.ToUInt32(ColorTranslator.ToOle(clr));

                        var sf = _map.get_GetObject(lyr.Handle) as Shapefile;

                        if (sf != null)
                        {
                            if (lyr.Type == LegendLayerType.PointShapefile)
                            {
                                sf.DefaultDrawingOptions.DrawPoint(
                                    hdc,
                                    left,
                                    top,
                                    Constants.IconSize,
                                    Constants.IconSize,
                                    backColor);
                            }
                            else if (lyr.Type == LegendLayerType.LineShapefile)
                            {
                                sf.DefaultDrawingOptions.DrawLine(
                                    hdc,
                                    left,
                                    top,
                                    Constants.IconSize - 1,
                                    Constants.IconSize - 1,
                                    false,
                                    Constants.IconSize,
                                    Constants.IconSize,
                                    backColor);
                            }
                            else if (lyr.Type == LegendLayerType.PolygonShapefile)
                            {
                                sf.DefaultDrawingOptions.DrawRectangle(
                                    hdc,
                                    left,
                                    top,
                                    Constants.IconSize - 1,
                                    Constants.IconSize - 1,
                                    false,
                                    Constants.IconSize,
                                    Constants.IconSize,
                                    backColor);
                            }
                        }

                        drawTool.ReleaseHdc(hdc);
                    }
                }

                // labels link
                if (bounds.Width > 60 && bounds.Right - curLeft - 62 > textSize.Width)
                {
                    var sf = _map.get_Shapefile(lyr.Handle);
                    if (sf != null)
                    {
                        var top2 = bounds.Top + Constants.IconTopPad;
                        var left2 = bounds.Right - 56;

                        var scale = _map.CurrentScale;
                        var labelsVisible = sf.Labels.Count > 0 && sf.Labels.Visible &&
                                            sf.Labels.Expression.Trim() != string.Empty;
                        labelsVisible &= scale >= sf.Labels.MinVisibleScale && scale <= sf.Labels.MaxVisibleScale;

                        var icon2 = Icons.GetIcon(labelsVisible ? LegendIcon.ActiveLabel : LegendIcon.DimmedLabel);
                        DrawPicture(drawTool, left2, top2, Constants.IconSize, Constants.IconSize, icon2);
                    }
                }

                // editing icon
                if (bounds.Width > 60 && bounds.Right - curLeft - 82 > textSize.Width)
                {
                    var sf = _map.get_Shapefile(lyr.Handle);
                    if (sf != null && sf.InteractiveEditing)
                    {
                        var top2 = bounds.Top + Constants.IconTopPad;
                        var left2 = bounds.Right - 76;
                        DrawPicture(
                            drawTool,
                            left2,
                            top2,
                            Constants.IconSize,
                            Constants.IconSize,
                            Icons.GetIcon(LegendIcon.Editing));
                    }
                }
            }

            // -------------------------------------------------------------
            // Drawing categories and expansion box for shapefiles
            // -------------------------------------------------------------
            if (lyr.IsShapefile)
            {
                if (bounds.Width > 17 && isSnapshot == false)
                {
                    rect = new Rectangle(
                        bounds.Left,
                        bounds.Top,
                        bounds.Width - Constants.ItemRightPad,
                        bounds.Height);
                    DrawExpansionBox(
                        drawTool,
                        rect.Top + Constants.ExpandBoxTopPad,
                        rect.Left + Constants.ExpandBoxLeftPad,
                        lyr.Expanded);
                }

                // drawing shapefile
                DrawShapefileCategories(drawTool, lyr, bounds, isSnapshot);
            }
            else
            {
                // Draw the expansion box and sub items (if they exist or if we're being forced)
                var customRect = new Rectangle(
                    bounds.Left + Constants.CheckLeftPad,
                    lyr.Top + Constants.ItemHeight + Constants.ExpandBoxTopPad,
                    bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent -
                    Constants.ExpandBoxLeftPad,
                    bounds.Height - lyr.Top);

                if (lyr.Expanded && lyr.ExpansionBoxCustomRenderFunction != null)
                {
                    var args = new LayerPaintEventArgs(lyr.Handle, customRect, drawTool);
                    FireEvent(this, lyr.ExpansionBoxCustomRenderFunction, args);
                }

                // Here, draw the + or - sign according to based on  layer.expanded property
                if (lyr.ExpansionBoxForceAllowed || lyr.ColorSchemeCount > 0)
                {
                    if (bounds.Width > 17 && isSnapshot == false)
                    {
                        // SetRect(&LocalBounds, bounds.left + LIST_ITEM_INDENT,Top,bounds.right-ITEM_PAD,Top+lyr.Height);
                        rect = new Rectangle(
                            bounds.Left,
                            bounds.Top,
                            bounds.Width - Constants.ItemRightPad,
                            bounds.Height);
                        DrawExpansionBox(
                            drawTool,
                            rect.Top + Constants.ExpandBoxTopPad,
                            rect.Left + Constants.ExpandBoxLeftPad,
                            lyr.Expanded);
                    }
                }
            }
        }

        /// <summary>
        /// Draws color scheme (categories) for the shapefile layer
        /// </summary>
        /// <param name="drawTool"> The Draw Tool. </param>
        /// <param name="layer"> The layer. </param>
        /// <param name="bounds"> The bounds. </param>
        /// <param name="isSnapshot"> The Is Snapshot. </param>
        private void DrawShapefileCategories(Graphics drawTool, LegendLayer layer, Rectangle bounds, bool isSnapshot)
        {
            if (!layer.IsShapefile)
            {
                return;
            }

            if ((!isSnapshot && !layer.Expanded) || bounds.Width <= 47)
            {
                return;
            }

            var sf = _map.get_Shapefile(layer.Handle);
            if (sf == null)
            {
                return;
            }

            var maxWidth = Constants.IconWidth;
            if (layer.Type == LegendLayerType.PointShapefile)
            {
                maxWidth = layer.get_MaxIconWidth(sf);
            }

            var top = bounds.Top + Constants.ItemHeight + 2;
            var height = layer.GetCategoryHeight(sf.DefaultDrawingOptions) + 2;

            if (top + height > ClientRectangle.Top)
            {
                DrawShapefileCategory(
                    drawTool,
                    sf.DefaultDrawingOptions,
                    layer,
                    bounds,
                    top,
                    string.Empty,
                    maxWidth);
            }

            top += height;

            Rectangle rect;
            if (sf.Categories.Count > 0)
            {
                // categories caption
                var caption = sf.Categories.Caption;
                if (caption == string.Empty)
                {
                    caption = "Categories";
                }

                var left = bounds.Left + Constants.TextLeftPad;
                if (!(top + Constants.TextHeight < 0))
                {
                    rect = new Rectangle(
                        left,
                        top,
                        bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                        Constants.TextHeight);
                    DrawText(drawTool, caption, rect, _font, ForeColor);
                }

                top += Constants.CsItemHeight + 2;

                // figure out if we can clip any of the categories at the top
                var i = 0;
                var categories = sf.Categories;
                var numCategories = sf.Categories.Count;
                if (top < ClientRectangle.Top && isSnapshot == false)
                {
                    while (i < numCategories)
                    {
                        // for point categories height can be different
                        top += layer.GetCategoryHeight(categories.Item[i].DrawingOptions);

                        if (top < ClientRectangle.Top)
                        {
                            i++;
                        }
                        else
                        {
                            top -= layer.GetCategoryHeight(categories.Item[i].DrawingOptions);

                            // this category should be drawn
                            break;
                        }
                    }
                }

                // we shall draw symbology first and text second
                // symbology is drawn from ocx, so it's better to draw all categories at once
                // avoiding additional GetHDC calls
                var hdc = drawTool.GetHdc();
                var topTemp = top;
                var startIndex = i;
                for (; i < categories.Count; i++)
                {
                    var cat = categories.Item[i];
                    var options = cat.DrawingOptions;

                    DrawShapefileCategorySymbology(drawTool, options, layer, bounds, topTemp, maxWidth, i, hdc);

                    topTemp += layer.GetCategoryHeight(options);
                    if (topTemp >= ClientRectangle.Bottom && isSnapshot == false)
                    {
                        // stop drawing in case there are not visible
                        break;
                    }
                }

                drawTool.ReleaseHdc(hdc);

                // now when hdc is released, GDI+ can be used for the text
                i = startIndex;
                for (; i < categories.Count; i++)
                {
                    var cat = categories.Item[i];
                    var options = cat.DrawingOptions;

                    DrawShapefileCategoryText(drawTool, options, layer, bounds, top, cat.Name, maxWidth, i);

                    top += layer.GetCategoryHeight(options);
                    if (top >= ClientRectangle.Bottom && isSnapshot == false)
                    {
                        // stop drawing in case there are not visible
                        break;
                    }
                }
            }

            // charts
            if (sf.Charts.Count > 0 && sf.Charts.NumFields > 0 && sf.Charts.Visible)
            {
                // charts caption
                var caption = sf.Charts.Caption;
                if (caption == string.Empty)
                {
                    caption = CHARTS_CAPTION;
                }

                var left = bounds.Left + Constants.TextLeftPad;
                rect = new Rectangle(
                    left,
                    top,
                    bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                    Constants.TextHeight);
                DrawText(drawTool, caption, rect, _font, ForeColor);
                top += Constants.CsItemHeight + 2;

                // storing bounds
                var el = new LayerElement(LayerElementType.Charts, rect);
                layer.Elements.Add(el);

                // preview
                var hdc = drawTool.GetHdc();
                var backColor = Convert.ToUInt32(ColorTranslator.ToOle(BackColor));

                left = bounds.Left + Constants.TextLeftPad;
                sf.Charts.DrawChart(hdc, left, top, true, backColor);
                top += sf.Charts.IconHeight + 2;
                drawTool.ReleaseHdc(hdc);

                // storing bounds
                el = new LayerElement(LayerElementType.ChartField, rect);
                layer.Elements.Add(el);

                // fields
                var color = ColorTranslator.FromOle(Convert.ToInt32(sf.Charts.LineColor));
                var pen = new Pen(color);

                for (var i = 0; i < sf.Charts.NumFields; i++)
                {
                    rect = new Rectangle(left, top, Constants.IconWidth, Constants.IconHeight);
                    color = ColorTranslator.FromOle(Convert.ToInt32(sf.Charts.Field[i].Color));
                    var brush = new SolidBrush(color);
                    drawTool.FillRectangle(brush, rect);
                    drawTool.DrawRectangle(pen, rect);

                    // storing bounds
                    el = new LayerElement(LayerElementType.ChartField, rect, i);
                    layer.Elements.Add(el);

                    rect = new Rectangle(
                        left + Constants.IconWidth + 5,
                        top,
                        bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                        Constants.TextHeight);
                    var name = sf.Charts.Field[i].Name;
                    DrawText(drawTool, name, rect, _font, Color.Black);

                    // storing bounds
                    el = new LayerElement(LayerElementType.ChartFieldName, rect, name, i);
                    layer.Elements.Add(el);

                    top += Constants.CsItemHeight + 2;
                }
            }
        }

        /// <summary>
        /// Draws shapefile category in specified location
        /// </summary>
        /// <param name="drawTool"> The Draw Tool. </param>
        /// <param name="options"> Options to use for drawing </param>
        /// <param name="layer"> The layer. </param>
        /// <param name="bounds"> The bounds. </param>
        /// <param name="top"> The top. </param>
        /// <param name="name"> The name. </param>
        /// <param name="maxWidth"> The max Width. </param>
        private void DrawShapefileCategory(
            Graphics drawTool,
            ShapeDrawingOptions options,
            LegendLayer layer,
            Rectangle bounds,
            int top,
            string name,
            int maxWidth)
        {
            var categoryHeight = layer.GetCategoryHeight(options);
            var categoryWidth = layer.GetCategoryWidth(options);

            // drawing category symbol
            var hdc = drawTool.GetHdc();
            var backColor = Convert.ToUInt32(ColorTranslator.ToOle(BackColor));

            var left = bounds.Left + Constants.TextLeftPad;
            if (categoryWidth != Constants.IconWidth)
            {
                left -= (categoryWidth - Constants.IconWidth)/2;
            }

            if (layer.Type == LegendLayerType.PointShapefile)
            {
                options.DrawPoint(hdc, left, top, categoryWidth + 1, categoryHeight + 1, backColor);
            }
            else if (layer.Type == LegendLayerType.LineShapefile)
            {
                options.DrawLine(
                    hdc,
                    left,
                    top,
                    categoryWidth - 1,
                    Constants.IconHeight - 1,
                    false,
                    categoryWidth,
                    categoryHeight,
                    backColor);
            }
            else if (layer.Type == LegendLayerType.PolygonShapefile)
            {
                options.DrawRectangle(
                    hdc,
                    left,
                    top,
                    categoryWidth - 1,
                    Constants.IconHeight - 1,
                    false,
                    categoryWidth,
                    categoryHeight,
                    backColor);
            }

            drawTool.ReleaseHdc(hdc);

            if (categoryHeight > Constants.CsItemHeight)
            {
                top += (categoryHeight - Constants.CsItemHeight)/2;
            }

            // drawing category name
            left = bounds.Left + Constants.TextLeftPad + (Constants.IconWidth/2) + (maxWidth/2) + 5;

            var rect = new Rectangle(
                left,
                top,
                bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                Constants.TextHeight);
            DrawText(drawTool, name, rect, _font, Color.Black);
        }

        /// <summary>
        /// Draws shapefile category. It's assumed here that GetHDC and ReleaseHDC calls are made by caller
        /// </summary>
        /// <param name="drawTool"> The Draw Tool. </param>
        /// <param name="options"> The options. </param>
        /// <param name="layer"> The layer. </param>
        /// <param name="bounds"> The bounds. </param>
        /// <param name="top"> The top. </param>
        /// <param name="maxWidth"> The max Width. </param>
        /// <param name="index"> The index. </param>
        /// <param name="hdc"> The hdc. </param>
        private void DrawShapefileCategorySymbology(
            Graphics drawTool,
            ShapeDrawingOptions options,
            LegendLayer layer,
            Rectangle bounds,
            int top,
            int maxWidth,
            int index,
            IntPtr hdc)
        {
            var categoryHeight = layer.GetCategoryHeight(options);
            var categoryWidth = layer.GetCategoryWidth(options);

            var backColor = Convert.ToUInt32(ColorTranslator.ToOle(BackColor));

            var left = bounds.Left + Constants.TextLeftPad;
            if (categoryWidth != Constants.IconWidth)
            {
                left -= (categoryWidth - Constants.IconWidth)/2;
            }

            if (layer.Type == LegendLayerType.PointShapefile)
            {
                options.DrawPoint(hdc, left, top, categoryWidth + 1, categoryHeight + 1, backColor);
            }
            else if (layer.Type == LegendLayerType.LineShapefile)
            {
                options.DrawLine(
                    hdc,
                    left,
                    top,
                    categoryWidth - 1,
                    Constants.IconHeight - 1,
                    false,
                    categoryWidth,
                    categoryHeight,
                    backColor);
            }
            else if (layer.Type == LegendLayerType.PolygonShapefile)
            {
                options.DrawRectangle(
                    hdc,
                    left,
                    top,
                    categoryWidth - 1,
                    Constants.IconHeight - 1,
                    false,
                    categoryWidth,
                    categoryHeight,
                    backColor);
            }

            if (categoryHeight > Constants.CsItemHeight)
            {
                top += (categoryHeight - Constants.CsItemHeight)/2;
            }
        }

        /// <summary>
        /// Draw the text for the shapefile category
        /// </summary>
        /// <param name="drawTool"> The Draw Tool. </param>
        /// <param name="options"> The options. </param>
        /// <param name="layer"> The layer. </param>
        /// <param name="bounds"> The bounds. </param>
        /// <param name="top"> The top. </param>
        /// <param name="name"> The name. </param>
        /// <param name="maxWidth"> The max Width. </param>
        /// <param name="index"> The index. </param>
        private void DrawShapefileCategoryText(
            Graphics drawTool,
            ShapeDrawingOptions options,
            LegendLayer layer,
            Rectangle bounds,
            int top,
            string name,
            int maxWidth,
            int index)
        {
            var categoryHeight = layer.GetCategoryHeight(options);
            if (categoryHeight > Constants.CsItemHeight)
            {
                top += (categoryHeight - Constants.CsItemHeight)/2;
            }

            // drawing category name
            var left = bounds.Left + Constants.TextLeftPad + (Constants.IconWidth/2) + (maxWidth/2) + 5;

            var rect = new Rectangle(
                left,
                top,
                bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                Constants.TextHeight);
            DrawText(drawTool, name, rect, _font, ForeColor);
        }

        /// <summary>
        /// Drawing icon for the new symbology
        /// </summary>
        /// <param name="drawTool"> </param>
        /// <param name="layer"> The layer. </param>
        /// <param name="topPos"> </param>
        /// <param name="leftPos"> </param>
        private void DrawLayerSymbolNew(Graphics drawTool, LegendLayer layer, int topPos, int leftPos)
        {
            var oldSmoothingMode = drawTool.SmoothingMode;

            try
            {
                drawTool.SmoothingMode = SmoothingMode.AntiAlias;
                Image icon;

                switch (layer.Type)
                {
                    case LegendLayerType.Grid:
                        icon = Icons.GetIcon(LegendIcon.Grid);
                        DrawPicture(drawTool, leftPos, topPos, Constants.IconSize, Constants.IconSize, icon);
                        break;
                    case LegendLayerType.Image:
                        icon = Icons.GetIcon(LegendIcon.Image);
                        DrawPicture(drawTool, leftPos, topPos, Constants.IconSize, Constants.IconSize, icon);
                        break;
                    default:
                        var sf = _map.get_GetObject(layer.Handle) as Shapefile;
                        if (sf == null)
                        {
                            MessageBox.Show("Error: shapefile not set");
                            return;
                        }

                        var hdc = drawTool.GetHdc();

                        var backColor = Convert.ToUInt32(ColorTranslator.ToOle(BackColor));

                        if (layer.Type == LegendLayerType.PointShapefile)
                        {
                            sf.DefaultDrawingOptions.DrawPoint(
                                hdc,
                                leftPos,
                                topPos,
                                Constants.IconWidth,
                                Constants.IconHeight,
                                backColor);
                        }
                        else if (layer.Type == LegendLayerType.LineShapefile)
                        {
                            sf.DefaultDrawingOptions.DrawLine(
                                hdc,
                                leftPos,
                                topPos,
                                Constants.IconWidth - 1,
                                Constants.IconSize - 1,
                                false,
                                Constants.IconWidth,
                                Constants.IconHeight,
                                backColor);
                        }
                        else if (layer.Type == LegendLayerType.PolygonShapefile)
                        {
                            sf.DefaultDrawingOptions.DrawRectangle(
                                hdc,
                                leftPos,
                                topPos,
                                Constants.IconWidth - 1,
                                Constants.IconSize - 1,
                                false,
                                Constants.IconWidth,
                                Constants.IconHeight,
                                backColor);
                        }

                        drawTool.ReleaseHdc(hdc);
                        break;
                }
            }
            catch (Exception ex)
            {
                var temp = ex.Message;
            }

            drawTool.SmoothingMode = oldSmoothingMode;
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

        /// <summary>
        /// Locates the group that was clicked on in the legend, based on the coordinate within the legend (0,0) being top left of legend)
        /// </summary>
        /// <param name="point"> The point inside of the legend that was clicked. </param>
        /// <param name="inCheckbox"> (by reference/out) Indicates whether a group visibilty check box was clicked. </param>
        /// <param name="inExpandbox"> (by reference/out) Indicates whether the expand box next to a group was clicked. </param>
        /// <returns> Returns the group that was clicked on or null/nothing. </returns>
        public LegendGroup FindClickedGroup(Point point, out bool inCheckbox, out bool inExpandbox)
        {
            // finds the group that was clicked, i.e. heading of group, not subitems
            inExpandbox = false;
            inCheckbox = false;

            var groupCount = _groups.Count;

            for (var i = 0; i < groupCount; i++)
            {
                var grp = _groups.GetGroup(i);

                // set group header bounds
                var curLeft = Constants.GrpIndent;
                var curWidth = Width - Constants.GrpIndent - Constants.ItemRightPad;
                var curTop = grp.Top;
                var curHeight = Constants.ItemHeight;
                var bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                if (bounds.Contains(point))
                {
                    // we are in the group heading
                    // now check to see if the click was in the expansion box
                    // +- a little to make the hot spot a little more precise
                    curLeft = Constants.GrpIndent + Constants.ExpandBoxLeftPad + 1;
                    curWidth = Constants.ExpandBoxSize - 1;
                    curTop = grp.Top + Constants.ExpandBoxTopPad + 1;
                    curHeight = Constants.ExpandBoxSize - 1;
                    bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                    if (bounds.Contains(point))
                    {
                        // we are in the bounds for the expansion box
                        // but only if there is an expansion box visible
                        if (grp.Layers.Count > 0)
                        {
                            inExpandbox = true;
                        }
                    }
                    else
                    {
                        // now check to see if in the check box
                        curLeft = Constants.GrpIndent + Constants.CheckLeftPad + 1;
                        curWidth = Constants.CheckBoxSize - 1;
                        curTop = grp.Top + Constants.CheckTopPad + 1;
                        curHeight = Constants.CheckBoxSize - 1;
                        bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);
                        if (bounds.Contains(point))
                        {
                            inCheckbox = true;
                        }
                    }

                    return grp;
                }
            }

            return null; // if we get to this point, no group item found
        }

        /// <summary>
        /// Locates the layer that was clicked on in the legend, based on the coordinate within the legend (0,0) being top left of legend)
        /// </summary>
        /// <param name="point"> The point inside of the legend that was clicked. </param>
        /// <param name="inCheckBox"> (by reference/out) Indicates whether a layer visibilty check box was clicked. </param>
        /// <param name="inExpansionBox"> (by reference/out) Indicates whether the expand box next to a layer was clicked. </param>
        /// <returns> Returns the group that was clicked on or null/nothing. </returns>
        private LegendLayer FindClickedLayer(Point point, out bool inCheckBox, out bool inExpansionBox)
        {
            var element = new ClickedElement();
            var lyr = FindClickedLayer(point, ref element);
            inCheckBox = element.CheckBox;
            inExpansionBox = element.ExpansionBox;
            return lyr;
        }

        /// <summary>
        /// Locates the layer that was clicked on in the legend.
        /// </summary>
        /// <param name="point"> The point. </param>
        /// <param name="element"> The Element. </param>
        /// <returns> The group that was clicked on or null/nothing. </returns>
        public LegendLayer FindClickedLayer(Point point, ref ClickedElement element)
        {
            var groupCount = _groups.Count;

            element.Nullify();

            for (var i = 0; i < groupCount; i++)
            {
                var grp = _groups.GetGroup(i);

                if (grp.Expanded == false)
                {
                    continue;
                }

                var layerCount = grp.Layers.Count;

                for (var j = 0; j < layerCount; j++)
                {
                    var lyr = grp.LayersInternal[j];

                    // see if we are inside the current Layer
                    var curLeft = Constants.ListItemIndent;
                    var curTop = lyr.Top;
                    var curWidth = Width - curLeft - Constants.ItemRightPad;
                    var curHeight = lyr.Height;
                    var bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                    if (bounds.Contains(point))
                    {
                        // we are inside the Layer boundaries,
                        // but we need to narrow down the search
                        element.GroupIndex = i;

                        // check to see if in the check box
                        curLeft = Constants.ListItemIndent + Constants.CheckLeftPad + 1;
                        curTop = lyr.Top + Constants.CheckTopPad + 1;
                        curWidth = Constants.CheckBoxSize - 1;
                        curHeight = Constants.CheckBoxSize - 1;
                        bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                        if (bounds.Contains(point))
                        {
                            // we are in the check box
                            element.CheckBox = true;
                            return lyr;
                        }

                        // check to see if we are in the expansion box for this item
                        curLeft = Constants.ListItemIndent + Constants.ExpandBoxLeftPad + 1;
                        curTop = lyr.Top + Constants.ExpandBoxTopPad + 1;
                        curWidth = Constants.ExpandBoxSize;
                        curHeight = Constants.ExpandBoxSize;
                        bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                        if (lyr.Type == LegendLayerType.Image || lyr.Type == LegendLayerType.Grid)
                        {
                            if (bounds.Contains(point) && (lyr.ColorSchemeCount > 0 || lyr.ExpansionBoxForceAllowed))
                            {
                                element.ExpansionBox = true;
                                return lyr;
                            }

                            // we aren't in the checkbox or the expansion box
                            return lyr;
                        }

                        if (bounds.Contains(point))
                        {
                            // We are in the Expansion box
                            element.ExpansionBox = true;
                            return lyr;
                        }

                        if (!lyr.Expanded && lyr.IsShapefile && lyr.SmallIconWasDrawn)
                        {
                            curHeight = Constants.IconSize;
                            curWidth = Constants.IconSize;
                            curTop = lyr.Top + Constants.IconTopPad;
                            curLeft = Width - 36;
                            if (_vScrollBar.Visible)
                            {
                                curLeft -= _vScrollBar.Width;
                            }

                            bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);
                            if (bounds.Contains(point))
                            {
                                element.ColorBox = true;
                                return lyr;
                            }
                        }

                        // layer icon (to the right from the caption)
                        if ( lyr.IsShapefile )
                        {
                            curHeight = Constants.IconSize;
                            curWidth = Constants.IconSize;
                            curTop = lyr.Top + Constants.IconTopPad;
                            curLeft = Width - 56;
                            if (_vScrollBar.Visible)
                            {
                                curLeft -= _vScrollBar.Width;
                            }

                            bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);
                            if (bounds.Contains(point))
                            {
                                element.LabelsIcon = true;
                                return lyr;
                            }
                        }

                        // check to see if we are in the default color box
                        var sf = _map.get_GetObject(lyr.Handle) as Shapefile;

                        if (sf != null)
                        {
                            curHeight = lyr.GetCategoryHeight(sf.DefaultDrawingOptions);
                            curWidth = lyr.GetCategoryWidth(sf.DefaultDrawingOptions);
                            curTop = lyr.Top + Constants.ItemHeight + 2;
                            curLeft = Constants.ListItemIndent + Constants.TextLeftPad;
                            if (curWidth != Constants.IconWidth)
                            {
                                curLeft -= (curWidth - Constants.IconWidth)/2;
                            }

                            bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                            if (bounds.Contains(point))
                            {
                                element.ColorBox = true;
                                return lyr;
                            }

                            // check to sse if we are in the label
                            curHeight = lyr.GetCategoryHeight(sf.DefaultDrawingOptions);
                            curWidth = lyr.GetCategoryWidth(sf.DefaultDrawingOptions);
                            curTop = lyr.Top + Constants.ItemHeight + 2;
                            var maxWidth = lyr.get_MaxIconWidth(sf);
                            curLeft = bounds.Left + Constants.TextLeftPad + maxWidth + 5;
                            bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                            if (bounds.Contains(point))
                            {
                                element.Label = true;
                                return lyr;
                            }

                            // categories
                            curLeft = Constants.ListItemIndent + Constants.TextLeftPad;
                            curTop = lyr.Top + Constants.ItemHeight + 2; // name
                            curTop += curHeight + 2; // default symbology

                            if (sf.Categories.Count > 0)
                            {
                                curTop += Constants.CsItemHeight + 2; // categories caption

                                for (var cat = 0; cat < sf.Categories.Count; cat++)
                                {
                                    var options = sf.Categories.Item[cat].DrawingOptions;
                                    curWidth = lyr.GetCategoryWidth(options);
                                    curHeight = lyr.GetCategoryHeight(options);
                                    bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                                    curTop += curHeight;

                                    if (bounds.Contains(point))
                                    {
                                        element.ColorBox = true;
                                        element.CategoryIndex = cat;
                                        return lyr;
                                    }
                                }
                            }

                            if (sf.Charts.NumFields > 0 && sf.Charts.Count > 0)
                            {
                                curTop += Constants.CsItemHeight + 2; // charts caption
                                curWidth = sf.Charts.IconWidth;
                                curHeight = sf.Charts.IconHeight;
                                bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                                if (bounds.Contains(point))
                                {
                                    element.Charts = true;
                                    return lyr;
                                }

                                curTop += curHeight + 2;
                                curHeight = Constants.IconHeight;
                                curWidth = Constants.IconWidth;

                                for (var fld = 0; fld < sf.Charts.NumFields; fld++)
                                {
                                    bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                                    if (bounds.Contains(point))
                                    {
                                        element.Charts = true;
                                        element.ChartFieldIndex = fld;

                                        // MessageBox.Show("Field selected: " + fld.ToString());
                                        return lyr;
                                    }

                                    curTop += Constants.CsItemHeight + 2;
                                }
                            }
                        }

                        // nothing was hit
                        return lyr;
                    }
                }
            }

            return null;
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
                var g = _groups.GetGroup(i);
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
                var grp = _groups.GetGroup(i);
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
                    _vScrollBar.SmallChange = Constants.ItemHeight;
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
                    var grp = _groups.GetGroup(i);
                    grp.ScheduleHeightRecalc();

                    if (rect.Top + grp.Height < ClientRectangle.Top)
                    {
                        // update the drawing rectangle
                        rect.Y += grp.Height + Constants.ItemPad;

                        // move on to the next group
                        continue;
                    }

                    DrawGroup(_draw, grp, rect, false);
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
            //lock (this)     
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
                grp = _groups.GetGroup(element.GroupIndex);
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

                    grp = _groups.GetGroup(element.GroupIndex);
                    grp.UpdateGroupVisibility();

                    FireEvent(this, LayerCheckboxClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }

                if (element.ExpansionBox)
                {
                    lyr.Expanded = !lyr.Expanded;
                    FireEvent(this, LayerPropertiesChanged, new LayerEventArgs(lyr.Handle));
                    Redraw();
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
                        grp = _groups.GetGroup(_dragInfo.DragGroupIndex);

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
            var lyr = FindClickedLayer(pnt, out inCheck, out inExpansion);
            if (lyr != null && inCheck == false)
            {
                if (inExpansion == false || lyr.ColorSchemeCount == 0)
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
                var grp = _groups.GetGroup(i);
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
            else
            {
                // TODO: it's flickering
                //show a tooltip if the mouse is over a layer
                //bool inCheck, inExpand;
                //var lyr = FindClickedLayer(new Point(e.X, e.Y), out inCheck, out inExpand);
                //if (lyr != null)
                //{
                //    _toolTip.AutoPopDelay = 5000;
                //    _toolTip.InitialDelay = 1000;
                //    _toolTip.ReshowDelay = 500;
                //    _toolTip.ShowAlways = false;
                //    string caption = _map.get_LayerName(lyr.Handle);
                //    _toolTip.SetToolTip(this, caption);
                //}
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
                    grp = _groups.GetGroup(grpIndex);
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
                            var g = _groups.GetGroup(0);
                            drawY =  g.Top + g.Height;
                        }
                        else
                        {
                            drawY = _groups.GetGroup(_groups.Count - 1).Top;
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

            var topGroup = _groups.GetGroup(grpCount - 1);
            var bottomGroup = _groups.GetGroup(0);

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
                    grp = _groups.GetGroup(i);

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
                                    var tempGroup = _groups.GetGroup(i - 1);
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
                    grp = _groups.GetGroup(i);

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

                var sourceGroup = _groups.GetGroup(sourceGroupIndex);
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
        /// The draw transparent patch.
        /// </summary>
        /// <param name="drawTool"> The draw tool. </param>
        /// <param name="topPos"> The top pos. </param>
        /// <param name="leftPos"> The left pos. </param>
        /// <param name="boxHeight"> The box height. </param>
        /// <param name="boxWidth"> The box width. </param>
        /// <param name="outlineColor"> The outline color. </param>
        /// <param name="drawOutline"> The draw outline. </param>
        private void DrawTransparentPatch(Graphics drawTool, int topPos, int leftPos, int boxHeight, int boxWidth,
            Color outlineColor, bool drawOutline)
        {
            var rect = new Rectangle(leftPos, topPos, boxWidth, boxHeight);
            var pen = new Pen(outlineColor);

            // fill the rectangle with a diagonal hatch
            Brush brush = new HatchBrush(HatchStyle.LightUpwardDiagonal, _boxLineColor, Color.White);
            drawTool.FillRectangle(brush, rect);

            if (drawOutline)
            {
                drawTool.DrawRectangle(pen, leftPos, topPos, boxWidth, boxHeight);
            }
        }

        /// <summary>
        /// The draw color patch.
        /// </summary>
        /// <param name="drawTool"> The draw tool. </param>
        /// <param name="startColor"> The start color. </param>
        /// <param name="endColor"> The end color. </param>
        /// <param name="topPos"> The top pos. </param>
        /// <param name="leftPos"> The left pos. </param>
        /// <param name="boxHeight"> The box height. </param>
        /// <param name="boxWidth"> The box width. </param>
        /// <param name="outlineColor"> The outline color. </param>
        /// <param name="drawOutline"> The draw outline. </param>
        private void DrawColorPatch(
            Graphics drawTool,
            Color startColor,
            Color endColor,
            int topPos,
            int leftPos,
            int boxHeight,
            int boxWidth,
            Color outlineColor,
            bool drawOutline)
        {
            DrawColorPatch(
                drawTool,
                startColor,
                endColor,
                topPos,
                leftPos,
                boxHeight,
                boxWidth,
                outlineColor,
                drawOutline,
                LegendLayerType.Invalid);
        }

        /// <summary>
        /// The draw color patch.
        /// </summary>
        /// <param name="drawTool"> The draw tool. </param>
        /// <param name="startColor"> The start color. </param>
        /// <param name="endColor"> The end color. </param>
        /// <param name="topPos"> The top pos. </param>
        /// <param name="leftPos"> The left pos. </param>
        /// <param name="boxHeight"> The box height. </param>
        /// <param name="boxWidth"> The box width. </param>
        /// <param name="outlineColor"> The outline color. </param>
        /// <param name="drawOutline"> The draw outline. </param>
        /// <param name="layerType"> The layer type. </param>
        private void DrawColorPatch(
            Graphics drawTool,
            Color startColor,
            Color endColor,
            int topPos,
            int leftPos,
            int boxHeight,
            int boxWidth,
            Color outlineColor,
            bool drawOutline,
            LegendLayerType layerType)
        {
            // Note - LayerType == invalid when we don't care :)
            if (layerType == LegendLayerType.LineShapefile)
            {
                if (startColor.A == 0)
                {
                    startColor = Color.FromArgb(255, startColor);
                }

                var pen = new Pen(startColor, 2);

                var oldSmoothingMode = drawTool.SmoothingMode;
                drawTool.SmoothingMode = SmoothingMode.AntiAlias;

                drawTool.DrawLine(pen, leftPos, topPos + 8, leftPos + 4, topPos + 3);
                drawTool.DrawLine(pen, leftPos + 4, topPos + 3, leftPos + 9, topPos + 10);
                drawTool.DrawLine(pen, leftPos + 9, topPos + 10, leftPos + 13, topPos + 4);

                drawTool.SmoothingMode = oldSmoothingMode;
            }
            else
            {
                var rect = new Rectangle(leftPos, topPos, boxWidth, boxHeight);
                var pen = new Pen(outlineColor);

                // fill the rectangle with a gradient fill
                Brush brush = new LinearGradientBrush(rect, startColor, endColor, LinearGradientMode.Horizontal);
                drawTool.FillRectangle(brush, rect);

                if (drawOutline)
                {
                    drawTool.DrawRectangle(pen, leftPos, topPos, boxWidth, boxHeight);
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