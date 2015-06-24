using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Api.Map;
using MW5.Shared;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Legend control handling user events (mouse down, mouse up, mouse move, etc).
    /// </summary>
    public partial class LegendControl : LegendControlBase, ILegend
    {
        private readonly DragInfo _dragInfo = new DragInfo();
        private readonly ClickInfo _clickInfo = new ClickInfo();
        private LayerCollection<ILegendLayer> _layers;
        private Image _dragBuffer;
        private TextBox _textBox;
        private LegendElement _activeElement;

        /// <summary>
        /// Initializes a new instance of the <see cref="LegendControl"/> class.
        /// </summary>
        public LegendControl(IContainer components) : base(components)
        {
            InitializeComponent();

            Groups = new LegendGroups(this);

            AttachEventHandlers();
        }

        private void AttachEventHandlers()
        {
            DoubleClick += LegendDoubleClick;
            KeyDown += LegendControl_KeyDown;
            MouseDown += LegendMouseDown;
            MouseMove += LegendMouseMove;
            MouseUp += LegendMouseUp;

            _clickInfo.LayerShowProperties += (s, e) => FireEvent(this, LayerDoubleClick, new LayerEventArgs(e.LayerHandle));

            _clickInfo.LayerEditName += (s, e) => ShowTextBox(e.LayerHandle);
        }

        #region Events

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
        public event EventHandler<ChartFieldClickedEventArgs> LayerDiagramFieldClicked;

        /// <summary>
        /// Fired when labels icon for the layer is clicked
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerLabelsClicked;

        internal void FireLayerVisibleChanged(int layerHandle, bool visible, ref bool cancel)
        {
            var args = new LayerCancelEventArgs(layerHandle, visible) { Cancel = cancel };
            FireEvent(this, LayerVisibleChanged, args);
            cancel = args.Cancel;
        }

        internal void FireGroupAdded(int groupHandle)
        {
            FireEvent(this, GroupAdded, new GroupEventArgs(groupHandle));
        }

        internal void FireGroupRemoved(int groupHandle)
        {
            FireEvent(this, GroupRemoved, new GroupEventArgs(groupHandle));
        }

        internal void FireGroupPositionChanged(int groupHandle, int oldPos, int newPos)
        {
            FireEvent(
                      this,
                      GroupPositionChanged,
                      new PositionChangedEventArgs(groupHandle, oldPos, newPos));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Menu for manipulating Layers (without respect to groups)
        /// </summary>
        [Browsable(false)]
        public override LayerCollection<ILegendLayer> Layers
        {
            get
            {
                return _layers ?? (_layers = new LayerCollection<ILegendLayer>(Map as MapControl, this));
            }

            protected set
            {
                _layers = value;
            }
        }

        private TextBox TextBox
        {
            get { return _textBox ?? (_textBox = new TextBox()); }
        }

        #endregion

        #region Event handlers

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
            if (_dragInfo.MouseDown)
            {
                _clickInfo.Abort();
            }

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
            }
        }

        private void LegendControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                // TODO: check group as well
                ShowTextBox(SelectedLayerHandle);
            }
        }

        #endregion

        #region Name editing

        /// <summary>
        /// Displays textbox with layer name.
        /// </summary>
        private void ShowTextBox(int layerHandle)
        {
            var layer = Layers.ItemByHandle(layerHandle) as LegendLayer;
            if (layer == null)
            {
                return;
            }

            var el = layer.Elements.FirstOrDefault(item => item.Type == LayerElementType.Name &&
                                                               item.LayerHandle == layer.Handle);

            if (el == null)
            {
                return;
            }

            var txt = TextBox;
            txt.Visible = true;

            txt.Left = el.Left;
            txt.Top = el.Top;
            txt.Width = el.Width + Constants.TextRightPad;
            txt.Height = el.Height;

            if (txt.Height > el.Height)
            {
                int dy = Convert.ToInt32((txt.Height - el.Height) / 2.0);
                txt.Top -= dy;
            }

            txt.Text = layer.Name;
            txt.SelectAll();

            txt.LostFocus += txt_LostFocus;
            txt.KeyDown += txt_KeyDown;

            Controls.Add(TextBox);
            TextBox.Focus();

            _activeElement = el;
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(TextBox.Text)) return;

                SaveLayerName();

                HideTextBox();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideTextBox();
            }
        }

        private void txt_LostFocus(object sender, EventArgs e)
        {
            HideTextBox();

            if (string.IsNullOrWhiteSpace(TextBox.Text)) return;

            SaveLayerName();
        }

        private void SaveLayerName()
        {
            if (_activeElement == null) return;

            switch (_activeElement.Type)
            {
                case LayerElementType.Name:
                    var layer = Layers.ItemByHandle(_activeElement.LayerHandle);
                    if (layer != null)
                    {
                        layer.Name = TextBox.Text;
                        Redraw();
                    }
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            HideTextBox();

            base.OnResize(e);
        }

        private void HideTextBox()
        {
            TextBox.Visible = false;

            Focus();

            Controls.Remove(TextBox); 
        }

        #endregion

        #region Mouse down

        /// <summary>
        /// The handle left mouse down.
        /// </summary>
        private void HandleLeftMouseDown(object sender, MouseEventArgs e)
        {
            _clickInfo.ClickId++;

            if (_dragInfo.Dragging || _dragInfo.MouseDown)
            {
                if (_dragInfo.LegendLocked)
                {
                    Unlock();
                    Logger.Current.Warn("Legend.HandleLeftMouseDown: something went wrong and the legend got locked but never got unlocked.");
                }
            }

            _dragInfo.Reset();

            var pnt = new Point(e.X, e.Y);

            // group
            if (TryHandleOnGroupClicked(pnt))
            {
                return;
            }

            // layer
            LegendElement element;

            var lyr = FindClickedLayer(pnt, out element);

            if (lyr != null)
            {
                // first try to find handler for particular element
                if (!OnLayerElementClicked(lyr, element))
                {
                    // call general handler if it failed
                    OnLayerCaptionClicked(pnt, lyr, GetGroup(element.GroupIndex));
                }

                return;
            }

            // outside any element
            FireEvent(this, LegendClick, new LegendClickEventArgs(MouseButtons.Left, pnt));

            Redraw();
        }

        /// <summary>
        /// Checks if the group element that was clicked has a handler.
        /// </summary>
        /// <remarks>True if a handler was found for group element that was clicked.</remarks>
        private bool TryHandleOnGroupClicked(Point pnt)
        {
            bool inCheckBox, inExpandBox;

            var grp = FindClickedGroup(pnt, out inCheckBox, out inExpandBox);
            if (grp == null)
            {
                return false;
            }
            
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
                    catch (Exception ex)
                    {
                        // We don't care about plug-in exceptions here
                        Logger.Current.Error("Error in GroupCheckboxClicked.", ex);
                    }

                    Redraw();

                    return true;
                }
            }
            else if (inExpandBox)
            {
                grp.Expanded = !grp.Expanded;
                FireEvent(this, GroupExpandedChanged, new GroupEventArgs(grp.Handle));
                Redraw();
                return true;
            }
            else
            {
                // set up group dragging
                if (Groups.Count > 1)
                {
                    _dragInfo.StartGroupDrag(pnt.Y, Groups.PositionOf(grp.Handle));
                }
            }

            FireEvent(this, GroupMouseDown, new GroupMouseEventArgs(grp.Handle, MouseButtons.Left));
            return false;
        }

        /// <summary>
        /// Runs appropriate handler for the element that was clicked. If no handler is found false is returned.
        /// </summary>
        private bool OnLayerElementClicked(LegendLayer lyr, LegendElement element)
        {
            switch (element.Type)
            {
                case LayerElementType.ColorBox:
                    if (element.Index == -1)
                    {
                        FireEvent(this, LayerStyleClicked, new LayerEventArgs(lyr.Handle));
                    }
                    else
                    {
                        FireEvent(this, LayerCategoryClicked, new LayerCategoryEventArgs(lyr.Handle, MouseButtons.Left, element.Index));
                    }
                    break;
                case LayerElementType.Label:
                    FireEvent(this, LayerLabelsClicked, new LayerEventArgs(lyr.Handle));
                    break;
                case LayerElementType.Charts:
                case LayerElementType.ChartField:
                case LayerElementType.ChartFieldName:
                    FireEvent(this, LayerDiagramsClicked, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Left));
                    
                    // event for individual fields can be fired if necessary
                    // FireEvent(this, LayerDiagramFieldClicked, new ChartFieldClickedEventArgs(lyr.Handle, MouseButtons.Left, element.Index));
                    break;
                case LayerElementType.CategoryCheckbox:
                    var sf = AxMap.get_Shapefile(lyr.Handle);
                    if (sf != null)
                    {
                        var ct = sf.Categories.Item[element.Index];
                        if (ct != null)
                        {
                            bool state = ct.DrawingOptions.Visible;
                            ct.DrawingOptions.Visible = !state;
                            AxMap.Redraw();
                        }
                    }
                    break;
                case LayerElementType.CheckBox:
                    {
                        var newState = !AxMap.get_LayerVisible(lyr.Handle);

                        var args = new LayerCancelEventArgs(lyr.Handle, newState);
                        FireEvent(this, LayerVisibleChanged, args);

                        if (args.Cancel)
                        {
                            return true;
                        }

                        AxMap.set_LayerVisible(lyr.Handle, newState);

                        var group = GetGroup(element.GroupIndex);
                        group.UpdateGroupVisibility();

                        FireEvent(this, LayerCheckboxClicked, new LayerEventArgs(lyr.Handle));
                    }
                    break;
                case LayerElementType.ExpansionBox:
                    {
                        Lock();
                        lyr.Expanded = !lyr.Expanded;
                        FireEvent(this, LayerPropertiesChanged, new LayerEventArgs(lyr.Handle));
                        Unlock();
                        return true;
                    }

                case LayerElementType.CategoriesCaption:
                case LayerElementType.ChartsCaption:
                case LayerElementType.RasterColorBox:
                    Logger.Current.Info("Legend element clicked: " + element.Type + ". No handler is attached");
                    return true;
                case LayerElementType.Name:
                case LayerElementType.None:
                default:
                    return false;
            }

            Redraw();

            return true;
        }

        /// <summary>
        /// Layer was clicked outside any of its active elements
        /// </summary>
        private void OnLayerCaptionClicked(Point pnt, LegendLayer lyr, LegendGroup grp)
        {
            if (SelectedLayerHandle != lyr.Handle)
            {
                // a click on another layer; if there will be a second one in time
                // we shall display propeties, but editing must not start unless there is 
                // one more click
                //Debug.WriteLine("First click on unselected layer.");
                _clickInfo.IsFirstClick = false;
                _clickInfo.StartTimer(lyr.Handle, true);
            }
            else
            {
                if (_clickInfo.IsFirstClick)
                {
                    // layer already selected, either editing or properties can be invoked
                    // depending on the presence of the second click in time
                    //Debug.WriteLine("A click on selected layer.");
                    _clickInfo.StartTimer(lyr.Handle, false);
                }
                else
                {
                    _clickInfo.IsDoubleClick = _clickInfo.Milliseconds < SystemInformation.DoubleClickTime;
                    //Debug.WriteLine("Second click on the selected layer. Is double click: " + _clickInfo.IsDoubleClick);
                    return;
                }
            }

            // Start dragging operation only if the clicked layer is selected.
            // Otherwise LayerSelected event will be fired which might results in a dialog box 
            // from plugin code (TableEditor) and no Legend.MouseUp event (the dragging operation won't be finished).
            if (SelectedLayerHandle == lyr.Handle)
            {
                if (Groups.Count > 1 || grp.Layers.Count > 1)
                {
                    _dragInfo.StartLayerDrag(
                        pnt.Y,
                        Groups.PositionOf(grp.Handle),
                        grp.LayerPositionInGroup(lyr.Handle));
                }
            }

            SelectedLayerHandle = lyr.Handle;

            FireEvent(this, LayerMouseDown, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Left));
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

            LegendElement element;
            Layer lyr = FindClickedLayer(pnt, out element);

            if (lyr != null)
            {
                if (element.Type == LayerElementType.Label)
                {
                    FireEvent(this, LayerLabelsClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }

                if (element.OutsideControls)
                {
                    FireEvent(this, LayerMouseDown, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Right));
                }
                
                return;
            }

            FireEvent(this, LegendClick, new LegendClickEventArgs(MouseButtons.Right, pnt));
        }

        #endregion

        #region Mouse up

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

                _dragBuffer = null;

                if (_dragInfo.DraggingLayer)
                {
                    if (_dragInfo.TargetGroupIndex != Constants.InvalidIndex)
                    {
                        var targetGroup = Groups[_dragInfo.TargetGroupIndex];
                        grp = GetGroup(_dragInfo.DragGroupIndex);

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

                    if (pos < 0 || pos >= Groups.Count)
                    {
                        _dragInfo.Reset();
                        return;
                    }

                    var grpHandle = Groups[_dragInfo.DragGroupIndex].Handle;

                    // adjust the target group index because we are setting TargetGroupIndex
                    // differently than the MoveGroup Function expects it
                    if (_dragInfo.DragGroupIndex < _dragInfo.TargetGroupIndex)
                    {
                        _dragInfo.TargetGroupIndex -= 1;
                    }

                    Groups.MoveGroup(grpHandle, _dragInfo.TargetGroupIndex);
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
            var lyr = HitTest.FindClickedLayer(pnt, out inCheck, out inExpansion);
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

            LegendElement element;

            Layer lyr = FindClickedLayer(pnt, out element);

            if (lyr != null)
            {
                if (element.OutsideControls)
                {
                    FireEvent(this, LayerMouseUp, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Right));
                }
            }
        }

        #endregion
        
        #region Dragging layers and groups

        /// <summary>
        /// The find drop location.
        /// </summary>
        /// <param name="yPosition"> The y position. </param>
        private void FindDropLocation(int yPosition)
        {
            _dragInfo.TargetGroupIndex = Constants.InvalidIndex;
            _dragInfo.TargetLayerIndex = Constants.InvalidIndex;

            LegendGroup grp;

            var grpCount = Groups.Count;

            if (grpCount < 1)
            {
                return;
            }

            var topGroup = GetGroup(grpCount - 1);
            var bottomGroup = GetGroup(0);

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
                    grp = GetGroup(i);

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
                            var lyr = grp.LayersList[j];
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
                                    var tempGroup = GetGroup(i - 1);
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
                    grp = GetGroup(i);

                    if (yPosition < grp.Top + grp.Height)
                    {
                        _dragInfo.TargetGroupIndex = i;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Drawing the dragging line.
        /// </summary>
        private void DrawDragLine(int grpIndex, int lyrIndex)
        {
            LegendGroup grp = null;

            if (_dragInfo.Dragging)
            {
                if (grpIndex >= 0 && grpIndex < Groups.Count)
                {
                    grp = GetGroup(grpIndex);
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
                        var itemTop = grp.LayersList[lyrIndex].Top;
                        drawY = itemTop + grp.LayersList[lyrIndex].Height;
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
                    if (grpIndex < 0 || grpIndex >= Groups.Count)
                    {
                        // the mouse is either above the top layer or below the bottom layer
                        if (grpIndex < 0)
                        {
                            var g = GetGroup(0);
                            drawY = g.Top + g.Height;
                        }
                        else
                        {
                            drawY = GetGroup(Groups.Count - 1).Top;
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

                Graphics = CreateGraphics();

                if (_dragBuffer == null)
                {
                    _dragBuffer = new Bitmap(BackBuffer.Width, BackBuffer.Height, GraphicsBackBuffer);
                }

                var localDraw = Graphics.FromImage(_dragBuffer);
                RenderBuffer(BackBuffer, localDraw);

                var pen = (Pen)Pens.Gray.Clone();
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

                RenderBuffer(_dragBuffer, Graphics);
            }
        }

        #endregion
    }
}
