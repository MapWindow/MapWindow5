//********************************************************************************************************
//The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License");
//you may not use this file except in compliance with the License. You may obtain a copy of the License at
//http://www.mozilla.org/MPL/
//Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF
//ANY KIND, either express or implied. See the License for the specific language governing rights and
//limitations under the License.
//
//The Original Code is MapWindow Open Source.
//
//The Initial Developer of this version of the Original Code is Daniel P. Ames using portions created by
//Utah State University and the Idaho National Engineering and Environmental Lab that were released as
//public domain in March 2004.
//
//Contributor(s): (Open source contributors should list themselves and their modifications here).
//
//Christian Degrassi 2010-02-25: Implemented LayerAdded/LayerRemoved GroupAdded/GroupRemoved Events
//Christian Degrassi 2010-03-12: Refactoring MoveLayer method to fix issue 1641
//Christian Degrassi 2010-03-12: Refactoring MoveLayer method to fix issues 1642, 1643
//********************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Events;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Summary description for LegendControl.
    /// </summary>
    [ToolboxBitmap(@"C:\Dev\MapWindow4Dev\MapWinInterfaces\MapWinLegend.ico")]
    [CLSCompliant(false)]
    public class LegendControl : UserControl
    {

        // TODO: convert to enumerations
        private const int cGridIcon = 0;
        private const int cImageIcon = 1;
        private const int cCheckedBoxIcon = 2;
        private const int cUnCheckedBoxIcon = 3;
        private const int cCheckedBoxGrayIcon = 4;
        private const int cUnCheckedBoxGrayIcon = 5;
        private const int cActiveLabelIcon = 6;
        private const int cDimmedLabelIcon = 7;
        private const int cEditing = 8;
        private const int cDatabase = 9;

        /// <summary>
        /// Gets or Sets the MapWinGIS.Map associated with this legend control
        /// Note: This property must be set before manipulating layers
        /// </summary>
        //public IMapControl Map
        //{
        //    get { return _map; }
        //    set { _map = value; }
        //}

        public LegendLayer GetLayer(int layerHandle)
        {
            // TODO: reimplement
            //return Layers.ItemByHandle(layerHandle);
            return null;
        }

        private static string m_appName = "";
        public static string AppName
        {
            get { return m_appName; }
            set { m_appName = value; }
        }
        
        #region "Member Variables"

        private const int INVALID_GROUP = -1;

        private Groups _groupManager;
        private LegendLayerCollection _layers;

        protected internal AxMap _map;

        private Color _selectedColor;
        private Color _boxLineColor;

        private Image _backBuffer;
        private Image _midBuffer;
        private Graphics _frontBuffer;
        private bool _showGroupFolders;
        //private ToolTip m_ToolTip;

        // TODO: encapsulate
        protected internal List<Group> AllGroups = new List<Group>();

        /// <summary>
        /// Group Position Lookup table (use Group layerHandle as index)
        /// </summary>
        protected internal ArrayList m_GroupPositions = new ArrayList();
        private Graphics _draw = null;
        private DragInfo m_DragInfo = new DragInfo();
        private uint _lockCount;
        private int _selectedLayerHandle;
        private int _selectedGroupHandle;
        private System.Drawing.Font _font;
        private System.Drawing.Font _boldFont;
        private bool _painting = false;


        private ImageList _icons;
        private VScrollBar _vScrollBar;

        private bool _showLabels = false;

        #endregion "Member Variables"

        #region "Events"

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

        //Christian Degrassi 2010-02-25: This fixes issue 1622
        /// <summary>
        /// Added Layer event
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerAdded;

        //Christian Degrassi 2010-02-25: This fixes issue 1622
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

        //Christian Degrassi 2010-02-25: This fixes issue 1622
        /// <summary>
        /// A Group has been added
        /// </summary>
        public event EventHandler<GroupEventArgs> GroupAdded;

        //Christian Degrassi 2010-02-25: This fixes issue 1622
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
        public event EventHandler<LayerEventArgs> LayerColorboxClicked;

        /// <summary>
        /// Fires when one of the shapefile categories is clicked
        /// </summary>
        public event EventHandler<LayerCategoryEventArgs> LayerCategoryClicked;

        /// <summary>
        /// Fires when charts icon is clicked
        /// </summary>
        public event EventHandler<LayerMouseEventArgs> LayerChartClicked;

        /// <summary>
        /// Fires when one of chart fields is clicked
        /// </summary>
        public event EventHandler<ChartFieldClickedEventArgs> LayerChartFieldClicked;

        /// <summary>
        /// Fired when label preview for layer is clicked
        /// </summary>
        public event EventHandler<LayerEventArgs> LayerLabelClicked;

        /// <summary>
        /// Fired when labels icon for a layer is clicked
        /// </summary>
        /// <param name="Handle">Layer handle</param>
        public delegate void LayerLabelsEventArguments(int Handle);

        /// <summary>
        /// Fired when labels icon for the layer is clicked
        /// </summary>
        public event LayerLabelsEventArguments LayerLabelsClicked;

        #endregion

        protected internal void FireEvent<T>(object sender, EventHandler<T> handler, T args)
        {
            if (handler != null)
            {
                handler.Invoke(sender, args);
            }
        }

        protected internal void FireLayerSelected(int layerHandle)
        {
            FireEvent(this, LayerSelected, new LayerEventArgs(layerHandle));
        }

        protected internal void FireLayerVisibleChanged(int layerHandle, bool visible, ref bool cancel)
        {
            var args = new LayerCancelEventArgs(layerHandle, visible);
            FireEvent(this, LayerVisibleChanged, args);
            cancel = args.Cancel;
        }

        private System.ComponentModel.IContainer components;

        /// <summary>
        /// This is the constructor for the <c>LegendControl</c> control.
        /// </summary>
        public LegendControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            _groupManager = new Groups(this);

            _lockCount = 0;
            _selectedLayerHandle = -1;
            _selectedGroupHandle = -1;
            _font = new Font("Arial", 8);
            _boldFont = new Font("Arial", 8, System.Drawing.FontStyle.Bold);
            _selectedColor = Color.FromArgb(255, 240, 240, 240);
            _boxLineColor = Color.Gray;
            _showGroupFolders = true;
        }

        /// <summary>
        /// Destructor for the legend
        /// </summary>
        /// <param name="disposing"></param>
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
            this._icons = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // vScrollBar
            // 
            resources.ApplyResources(this._vScrollBar, "_vScrollBar");
            this._vScrollBar.Name = "_vScrollBar";
            this._vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // Icons
            // 
            this._icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this._icons.TransparentColor = System.Drawing.Color.Transparent;
            this._icons.Images.SetKeyName(0, "");
            this._icons.Images.SetKeyName(1, "");
            this._icons.Images.SetKeyName(2, "");
            this._icons.Images.SetKeyName(3, "");
            this._icons.Images.SetKeyName(4, "");
            this._icons.Images.SetKeyName(5, "");
            this._icons.Images.SetKeyName(6, "tag_blue.png");
            this._icons.Images.SetKeyName(7, "tag_gray.png");
            this._icons.Images.SetKeyName(8, "pen.png");
            this._icons.Images.SetKeyName(9, "database5.png");
            // 
            // LegendControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this._vScrollBar);
            this.Name = "Legend";
            resources.ApplyResources(this, "$this");
            this.DoubleClick += new System.EventHandler(this.Legend_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Legend_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Legend_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Legend_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion Component Designer generated code

        /// <summary>
        /// Toggles the layer preview visiblity in the legend
        /// </summary>
        /// <returns></returns>
        public bool ShowLabels
        {
            get { return _showLabels; }
            set { _showLabels = value; }
        }

        /// <summary>
        /// Gets the Menu for manipulating Groups
        /// </summary>
        public Groups Groups
        {
            get
            {
                return _groupManager;
            }
        }

        /// <summary>
        /// Gets the Menu for manipulating Layers (without respect to groups)
        /// </summary>
        public LegendLayerCollection Layers
        {
            get
            {
                if (_layers != null)
                {
                    _layers = new LegendLayerCollection(_map, this);
                }
                return _layers;
            }
        }

        /// <summary>
        /// Adds a group to the list of all groups
        /// </summary>
        /// <param name="Name">Caption shown in legend</param>
        /// <returns>layerHandle to the Group on success, -1 on failure</returns>
        protected internal int AddGroup(string Name)
        {
            return AddGroup(Name, -1);
        }

        /// <summary>
        /// Adds a group to the list of all groups
        /// </summary>
        /// <param name="Name">Caption shown in legend</param>
        /// <param name="Position">0-Based index of the new Group</param>
        /// <returns>layerHandle to the Group on success, -1 on failure</returns>
        protected internal int AddGroup(string Name, int Position)
        {
            Group grp = CreateGroup(Name, Position);
            if (grp == null)
            {
                //globals.LastError = "Failed to create instance of class 'Group'";
                return INVALID_GROUP;
            }

            Redraw();

            //Christian Degrassi 2010-02-25: This fixes issue 1622
            FireEvent(this, GroupAdded, new GroupEventArgs(grp.Handle));

            return grp.Handle;
        }

        /// <summary>
        /// Gets or Sets the background color of the selected layer within the legend
        /// </summary>
        public Color SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
            }
        }

        /// <summary>
        /// Gets or Sets the background color of the selected layer within the legend
        /// </summary>
        public bool ShowGroupFolders
        {
            get
            {
                return _showGroupFolders;
            }
            set
            {
                _showGroupFolders = value;
            }
        }

        /// <summary>
        /// Removes a group from the list of groups
        /// </summary>
        /// <param name="Handle">layerHandle of the group to remove</param>
        /// <returns>True on success, False otherwise</returns>
        protected internal bool RemoveGroup(int Handle)
        {
            Group grp = null;
            bool LayerInGroupWasSelected = false;

            //if(IS_VALID_INDEX(m_GroupPositions,layerHandle) && m_GroupPositions[layerHandle] != INVALID_GROUP)
            if (IsValidGroup(Handle) == true)
            {
                int index = (int)m_GroupPositions[Handle];
                grp = (Group)AllGroups[index];

                //remove any layers within the specified group
                while (grp.Layers.Count > 0)
                {
                    int lyr = ((Layer)grp.Layers[0]).Handle;
                    LayerInGroupWasSelected = LayerInGroupWasSelected || (_selectedLayerHandle == lyr);
                    RemoveLayer(lyr);
                    GC.Collect();
                }

                AllGroups.RemoveAt(index);
                UpdateGroupPositions();

                // Chris M 11/16/2006 don't just select nothing, could be
                // problematic. Instead intelligently select a new layer if possible.
                // FireLayerSelected(-1);
                if (LayerInGroupWasSelected)
                {
                    _selectedLayerHandle = (_map.NumLayers > 0 ? _map.get_LayerHandle(_map.NumLayers - 1) : -1);

                    FireEvent(this, LayerSelected, new LayerEventArgs(_selectedLayerHandle));
                }

                Redraw();

                //Christian Degrassi 2010-02-25: This fixes issue 1622
                FireEvent(this, GroupRemoved, new GroupEventArgs(Handle));
            }
            else
            {
                //globals.LastError = "Invalid Group layerHandle";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Removes a layer from the list of layers
        /// </summary>
        /// <param name="LayerHandle">layerHandle of layer to be removed</param>
        /// <returns>True on success, False otherwise</returns>
        protected internal bool RemoveLayer(int LayerHandle)
        {
            int GroupIndex,
                LayerIndex;
            Layer lyr = FindLayerByHandle(LayerHandle, out GroupIndex, out LayerIndex);
            if (lyr == null)
                return false;

            Group grp = (Group)AllGroups[GroupIndex];
            grp.Layers.RemoveAt(LayerIndex);

            _map.RemoveLayer(LayerHandle);

            if (LayerHandle == _selectedLayerHandle)
            {
                _selectedLayerHandle = _map.get_LayerHandle(_map.NumLayers - 1);

                FireEvent(this, LayerSelected, new LayerEventArgs(_selectedLayerHandle));
            }

            grp.RecalcHeight();
            Redraw();

            //Christian Degrassi 2010-02-25: This fixes issue 1622
            FireEvent(this, LayerRemoved, new LayerEventArgs(LayerHandle));

            return true;
        }

        private void UpdateGroupPositions()
        {
            int grpCount = AllGroups.Count;
            int HandleCount = m_GroupPositions.Count;
            int i;

            //reset all positions
            for (i = 0; i < HandleCount; i++)
                m_GroupPositions[i] = INVALID_GROUP;

            //set valid group positions for existing groups
            for (i = 0; i < grpCount; i++)
                m_GroupPositions[((Group)AllGroups[i]).Handle] = i;
        }

        private Group CreateGroup(string caption, int Position)
        {
            Group grp = new Group(this);
            if (caption.Length < 1)
                grp.Text = "New Group";
            else
                grp.Text = caption;

            grp._handle = m_GroupPositions.Count;
            m_GroupPositions.Add(INVALID_GROUP);

            if (Position < 0 || Position >= AllGroups.Count)
            {
                //put it at the top
                m_GroupPositions[grp.Handle] = AllGroups.Count;
                AllGroups.Add(grp);
            }
            else
            {
                //put it where they requested
                m_GroupPositions[grp.Handle] = Position;
                AllGroups.Insert(Position, grp);

                UpdateGroupPositions();
            }
            return grp;
        }

        private void DrawBox(Graphics DrawTool, Rectangle rect, Color LineColor)
        {
            Pen pen;
            pen = new Pen(LineColor);

            DrawTool.DrawRectangle(pen, rect);
            pen = null;
        }

        private void DrawBox(Graphics DrawTool, Rectangle rect, Color LineColor, Color BackColor)
        {
            Pen pen;
            pen = new Pen(BackColor);
            DrawTool.FillRectangle(pen.Brush, rect);

            pen = new Pen(LineColor);

            DrawTool.DrawRectangle(pen, rect);
            pen = null;
        }

        private void SwapBuffers()
        {
            SwapBuffers(_backBuffer, _frontBuffer);
        }

        private void SwapBuffers(Image BackBuffer)
        {
            SwapBuffers(BackBuffer, _frontBuffer);
        }

        private void SwapBuffers(Image BackBuffer, Graphics FrontBuffer)
        {
            try
            {
                // temporary: checking random property to be sure the object is valid
                float k = FrontBuffer.DpiX;
            }
            catch (Exception ex)
            {
                // We'll log the error.
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return;
            }

            FrontBuffer.DrawImage(BackBuffer, 0, 0);
            FrontBuffer.Flush(FlushIntention.Sync);
        }

        private void SwapBuffers(Image BackBuffer, Image FrontBuffer)
        {
            Graphics draw = Graphics.FromImage(FrontBuffer);
            draw.DrawImage(BackBuffer, 0, 0);
            draw.Flush(System.Drawing.Drawing2D.FlushIntention.Sync);
        }

        /// <summary>
        /// Draws a group onto a give graphics object (surface)
        /// </summary>
        /// <param name="DrawTool">Graphics object with which to draw</param>
        /// <param name="grp">Group to be drawn</param>
        /// <param name="bounds">Clipping boundaries for this group</param>
        /// <param name="IsSnapshot">Drawing is handled in special way if this is a Snapshot</param>
        protected internal void DrawGroup(Graphics DrawTool, Group grp, Rectangle bounds, bool IsSnapshot)
        {
            int CurLeft = Constants.GRP_INDENT,
                CurWidth = bounds.Width - Constants.GRP_INDENT - Constants.ITEM_RIGHT_PAD,
                CurTop = bounds.Top,
                CurHeight = Constants.ITEM_HEIGHT;

            Rectangle rect = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

            CurLeft = Constants.GRP_INDENT + Constants.EXPAND_BOX_LEFT_PAD;
            CurTop = bounds.Top;
            bool DrawCheck = false;
            //Color BoxBackColor = Color.White;
            bool DrawGrayCheckbox = false;
            int GroupHeight = grp.Height;
            grp.Top = bounds.Top;

            if (grp.VisibleState == Visibility.AllVisible || grp.VisibleState == Visibility.PartialVisible)
                DrawCheck = true;

            //draw the border if the group is the one that contains the selected layer and
            //the group is collapsed
            if (grp.Handle == _selectedGroupHandle && grp.Expanded == false && IsSnapshot == false)
            {
                rect = new Rectangle(Constants.GRP_INDENT, CurTop, bounds.Width - Constants.GRP_INDENT - Constants.ITEM_RIGHT_PAD, Constants.ITEM_HEIGHT);
                DrawBox(DrawTool, rect, _boxLineColor, _selectedColor);
            }

            //draw the +- box if there are sub items
            if (grp.Layers.Count > 0 && IsSnapshot == false)
                DrawExpansionBox(DrawTool, bounds.Top + Constants.EXPAND_BOX_TOP_PAD, Constants.GRP_INDENT + Constants.EXPAND_BOX_LEFT_PAD, grp.Expanded);

            if (grp.VisibleState == Visibility.PartialVisible)
                DrawGrayCheckbox = true;
            //BoxBackColor = Color.LightGray;

            if (IsSnapshot == false && grp.Expanded == true && grp.Layers.Count > 0)
            {
                int endY = grp.Top + Constants.ITEM_HEIGHT;

                Pen BlackPen = new Pen(_boxLineColor);
                DrawTool.DrawLine(BlackPen, Constants.VERT_LINE_INDENT, bounds.Top + Constants.VERT_LINE_GRP_TOP_OFFSET, Constants.VERT_LINE_INDENT, endY);
            }

            CurLeft = Constants.GRP_INDENT;
            if (bounds.Width > 35 && IsSnapshot == false)
            {
                if (!grp.StateLocked)
                {
                    CurLeft = Constants.GRP_INDENT + Constants.CHECK_LEFT_PAD;
                    DrawCheckBox(DrawTool, bounds.Top + Constants.CHECK_TOP_PAD, CurLeft, DrawCheck, DrawGrayCheckbox);
                }
            }

            CurLeft = Constants.GRP_INDENT + Constants.TEXT_LEFT_PAD;

            if (grp.Icon != null && bounds.Width > 55)
            {
                //draw the icon
                DrawPicture(DrawTool, bounds.Right - Constants.ICON_RIGHT_PAD, CurTop + Constants.ICON_TOP_PAD, Constants.ICON_SIZE, Constants.ICON_SIZE, grp.Icon);

                //set the boundaries for text so that the text and icon don't overlap
                if (IsSnapshot == true)
                    CurLeft = Constants.GRP_INDENT;
                else
                    CurLeft = Constants.GRP_INDENT + Constants.TEXT_LEFT_PAD;

                CurTop = bounds.Top + Constants.TEXT_TOP_PAD;
                CurWidth = bounds.Width - CurLeft - Constants.TEXT_RIGHT_PAD;
                CurHeight = Constants.TEXT_HEIGHT;
                rect = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);
            }
            else
            {
                //Bitmap bmp = MWLite.Symbology.Properties.Resources.folder_open;
                //DrawPicture(DrawTool, bounds.Right - Constants.ICON_RIGHT_PAD, CurTop + Constants.ICON_TOP_PAD, Constants.ICON_SIZE, Constants.ICON_SIZE, bmp);

                if (IsSnapshot == true)
                    CurLeft = Constants.GRP_INDENT;
                else
                    CurLeft = Constants.GRP_INDENT + Constants.TEXT_LEFT_PAD;

                CurTop = bounds.Top + Constants.TEXT_TOP_PAD;
                CurWidth = bounds.Width - CurLeft - Constants.TEXT_RIGHT_PAD_NO_ICON;
                CurHeight = Constants.TEXT_HEIGHT;
                rect = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);
            }

            // TODO: restore
            // group icon
            //if (_showGroupFolders)
            //{
            //    int size = 16;
            //    Bitmap bmp = grp.Expanded ? MWLite.Symbology.Properties.Resources.folder_open : MWLite.Symbology.Properties.Resources.folder;
            //    rect.Offset(0, -2);
            //    DrawPicture(DrawTool, rect.Left, rect.Top, size, size, bmp);

            //    rect = new Rectangle(rect.X + size + 3, rect.Y + 2, rect.Width - size, rect.Height);
            //}

            // group name
            if (grp.Handle == _selectedGroupHandle && !IsSnapshot)
                DrawText(DrawTool, grp.Text, rect, _boldFont);
            else
                DrawText(DrawTool, grp.Text, rect, _font);

            //set up the boundaries for drawing list items
            CurTop = bounds.Top + Constants.ITEM_HEIGHT;

            if (grp.Expanded || IsSnapshot == true)
            {
                int ItemCount;
                ItemCount = grp.Layers.Count;
                int newLeft = bounds.X + Constants.LIST_ITEM_INDENT;
                int newWidth = bounds.Width - newLeft;
                rect = new Rectangle(newLeft, CurTop, newWidth, bounds.Height - CurTop);

                Pen pen = new Pen(this._boxLineColor);

                //now draw each of the subitems
                for (int i = ItemCount - 1; i >= 0; i--)
                {
                    var lyr = grp.Layers[i];
                    
                    if (!lyr.HideFromLegend)
                    {
                        //clipping
                        if (rect.Top + lyr.Height < this.ClientRectangle.Top && IsSnapshot == false)
                        {
                            //update the rectangle for the next layer
                            rect.Y += lyr.Height;
                            rect.Height -= lyr.Height;

                            //Skip drawing this layer and move onto the next one
                            continue;
                        }

                        DrawLayer(DrawTool, lyr, rect, IsSnapshot);

                        bool drawLines = false;

                        if (IsSnapshot == false && drawLines)
                        {
                            //draw sub-item vertical line
                            if (i != 0 && !((Layer)grp.Layers[i - 1]).HideFromLegend)//not the last visible layer
                                DrawTool.DrawLine(pen, Constants.VERT_LINE_INDENT, lyr.Top, Constants.VERT_LINE_INDENT, lyr.Top + lyr.Height + Constants.ITEM_PAD);
                            else//only draw down to box, not down to next item in list(since there is no next item)
                                DrawTool.DrawLine(pen, Constants.VERT_LINE_INDENT, lyr.Top, Constants.VERT_LINE_INDENT, (int)(lyr.Top + .55 * Constants.ITEM_HEIGHT));

                            //draw Horizontal line over to the Vertical Sub-lyr line
                            CurTop = (int)(rect.Top + .5 * Constants.ITEM_HEIGHT);

                            if (lyr.ColorLegend == null || lyr.ColorLegend.Count == 0)

                                // Color or image schemes do not exist with the layer

                                // if the layer is selected
                                if (lyr.Handle == _selectedLayerHandle)
                                {
                                    DrawTool.DrawLine(pen, Constants.VERT_LINE_INDENT, CurTop, rect.Left + Constants.EXPAND_BOX_LEFT_PAD - 3, CurTop);
                                }
                                else
                                {
                                    // if the layer is not selected
                                    DrawTool.DrawLine(pen, Constants.VERT_LINE_INDENT, CurTop, rect.Left + Constants.CHECK_LEFT_PAD, CurTop);
                                    //DrawTool.DrawLine(pen, Constants.VERT_LINE_INDENT, CurTop, rect.Left + Constants.EXPAND_BOX_LEFT_PAD, CurTop);
                                }
                            //
                            else
                            {
                                // There is color or image scheme with the layer

                                // if the layer is selected
                                if (lyr.Handle == _selectedLayerHandle)
                                    DrawTool.DrawLine(pen, Constants.VERT_LINE_INDENT, CurTop, rect.Left + Constants.EXPAND_BOX_LEFT_PAD - 3, CurTop);
                                // if the layer is not selected
                                else
                                    DrawTool.DrawLine(pen, Constants.VERT_LINE_INDENT, CurTop, rect.Left + Constants.EXPAND_BOX_LEFT_PAD, CurTop);
                            }

                            //set up the rectangle for the next layer
                            rect.Y += lyr.Height;
                            rect.Height -= lyr.Height;
                        }
                        else if (IsSnapshot)
                        {
                            rect.Y += lyr.CalcHeight(true);
                            rect.Height -= lyr.CalcHeight(true);
                        }
                        else
                        {
                            rect.Y += lyr.CalcHeight(lyr.Expanded);
                            rect.Height -= lyr.CalcHeight(lyr.Expanded);
                        }

                        if (rect.Top >= this.ClientRectangle.Bottom && IsSnapshot == false)
                            break;
                    }
                }
            }
        }

        private void DrawText(Graphics DrawTool, string text, Rectangle rect, Font font, Color penColor)
        {
            Pen pen = new Pen(penColor);
            DrawTool.DrawString(text, font, pen.Brush, rect);
        }

        private void DrawText(Graphics DrawTool, string text, Rectangle rect, Font font)
        {
            DrawText(DrawTool, text, rect, font, Color.Black);
        }

        /// <summary>
        /// Gets or Sets the Selected layer within the legend
        /// </summary>
        public int SelectedLayer
        {
            get
            {
                //if (m_LayerManager == null) return 0;
                //return (m_LayerManager.Count == 0 ? -1 : _selectedLayerHandle);
                // TODO: reimplement
                return _selectedLayerHandle;
            }

            set
            {
                int GroupIndex, LayerIndex;

                if (_selectedLayerHandle != value && FindLayerByHandle(value, out GroupIndex, out LayerIndex) != null)
                {
                    //only redraw if the selected layer is changing and the handle is valid
                    _selectedLayerHandle = value;
                    _selectedGroupHandle = ((Group)AllGroups[GroupIndex]).Handle;

                    FireLayerSelected(value);

                    Redraw();
                }
            }
        }

        #region Load from map
        //public bool ReadFromMap()
        //{
        //    if (Map == null)
        //        return false;

        //    this.Layers.Clear();
        //    for (int i = 0; i < Map.NumLayers; i++)
        //    {
        //        int handle = Map.get_LayerHandle(i);
        //        var sf = Map.get_Shapefile(handle);
        //        var img = Map.get_Image(handle);
        //        if (sf != null || img != null)
        //        {
        //            object obj = sf != null ? (object)sf : (object)img;
        //            this.Layers.Add(obj, Map.get_LayerVisible(handle), 0);      // TODO: add group handle
        //        }
        //    }
        //    return true;
        //}
        #endregion

        #region AddLayer
        /// <summary>
        /// Adds a layer to the topmost Group
        /// </summary>
        /// <param name="newLayer">object to be added as new layer</param>
        /// <param name="Visible">Should this layer to be visible?</param>
        /// <param name="TargetGroupHandle">layerHandle of the group into which this layer should be added</param>
        /// <returns>layerHandle to the Layer on success, -1 on failure</returns>
        protected internal int AddLayer(object newLayer, bool Visible, int TargetGroupHandle)
        {
            return AddLayer(newLayer, Visible, TargetGroupHandle, true);
        }

        /// <summary>
        /// Adds a layer to the map, optionally placing it above the currently selected layer (otherwise at top of layer list).
        /// </summary>
        /// <param name="newLayer">The object to add (must be a supported Layer type)</param>
        /// <param name="Visible">Whether or not the layer is visible upon adding it</param>
        /// <param name="PlaceAboveCurrentlySelected">Whether the layer should be placed above currently selected layer, or at top of layer list.</param>
        /// <returns>layerHandle of the newly added layer, -1 on failure</returns>
        protected internal int AddLayer(object newLayer, bool Visible, bool PlaceAboveCurrentlySelected)
        {
            int MapLayerHandle = AddLayer(newLayer, Visible);

            if (!PlaceAboveCurrentlySelected) return MapLayerHandle;

            if (SelectedLayer != -1 && PlaceAboveCurrentlySelected)
            {
                int addPos = 0;
                int addGrp = 0;
                addPos = Layers.PositionInGroup(SelectedLayer) + 1;
                addGrp = Layers.GroupOf(SelectedLayer);
                Layers.MoveLayer(MapLayerHandle, addGrp, addPos);
                return MapLayerHandle;
            }

            return MapLayerHandle;
        }

        /// <summary>
        /// Adds a layer to the topmost Group
        /// </summary>
        /// <param name="newLayer">object to be added as new layer</param>
        /// <param name="Visible">Should this layer to be visible in the map?</param>
        /// <param name="TargetGroupHandle">layerHandle of the group into which this layer should be added</param>
        /// <param name="LegendVisible">Should this layer be visible in the legend?</param>
        /// <returns>layerHandle to the Layer on success, -1 on failure</returns>
        protected internal int AddLayer(object newLayer, bool Visible, int TargetGroupHandle, bool LegendVisible, int afterLayerHandle = -1)
        {
            Group grp = null;

            if (_map == null)
                throw new System.Exception("MapWinGIS.Map Object not yet set. Set Map Property before adding layers");

            _map.LockWindow(MapWinGIS.tkLockMode.lmLock);
            int MapLayerHandle = _map.AddLayer(newLayer, Visible);
            //newLayer = new Object();

            if (MapLayerHandle < 0)
            {
                _map.LockWindow(MapWinGIS.tkLockMode.lmUnlock);
                return MapLayerHandle;
            }

            if (AllGroups.Count == 0 || IsValidGroup(TargetGroupHandle) == false)
            {
                //we have to create or find a group to put this layer into
                if (AllGroups.Count == 0)
                {
                    grp = CreateGroup("Data Layers", -1);
                    m_GroupPositions[grp.Handle] = AllGroups.Count - 1;

                    //Christian Degrassi 2010-02-25: This fixes issue 1622
                    FireEvent(this, GroupAdded, new GroupEventArgs(grp.Handle));
                }
                else
                {
                    grp = (Group)AllGroups[AllGroups.Count - 1];
                }
            }
            else
            {
                grp = (Group)AllGroups[(int)m_GroupPositions[TargetGroupHandle]];
            }

            var lyr = CreateLayer(MapLayerHandle, newLayer);
            lyr.HideFromLegend = !LegendVisible;

            bool inserted = false;
            if (afterLayerHandle != -1)
            {
                for (int i = 0; i < grp.Layers.Count; i++)
                {
                    if (grp.Layers[i].Handle == afterLayerHandle)
                    {
                        grp.Layers.Insert(i, lyr);
                        inserted = true;
                        break;
                    }
                }
            }
            if (!inserted)
                grp.Layers.Add(lyr);
            grp.RecalcHeight();

            grp.UpdateGroupVisibility();

            // don't show preview for the large layer by default
            MapWinGIS.Shapefile sf = (newLayer as MapWinGIS.Shapefile);

            if (LegendVisible)
            {
                _selectedGroupHandle = grp.Handle;
                _selectedLayerHandle = MapLayerHandle;

                FireLayerSelected(MapLayerHandle);
            }

            _map.LockWindow(MapWinGIS.tkLockMode.lmUnlock);
            Redraw();

            //Christian Degrassi 2010-02-25: This fixes issue 1622
            FireEvent(this, LayerAdded, new LayerEventArgs(MapLayerHandle));

            return MapLayerHandle;
        }

        /// <summary>
        /// Adds a layer to the topmost Group
        /// </summary>
        /// <param name="newLayer">object to be added as new layer</param>
        /// <param name="Visible">Should this layer to be visible?</param>
        /// <returns>layerHandle to the Layer on success, -1 on failure</returns>
        protected internal int AddLayer(object newLayer, bool Visible)
        {
            return AddLayer(newLayer, Visible, -1, true);
        }

        /// <summary>
        /// Assigns all layers outside group to a new group. This allows normal functioning of the legend after map deserialization.
        /// </summary>
        public int AssignOrphanLayersToNewGroup(string groupName)
        {
            Group g = this.Groups.GroupByName(groupName);
            if (g == null)
            {
                int groupHandle = this.Groups.Add(groupName);
                g = this.Groups.ItemByHandle(groupHandle);
            }

            for (int i = 0; i < _map.NumLayers; i++)
            {
                int handle = _map.get_LayerHandle(i);
                var lyr = CreateLayer(handle, (object)_map.get_GetObject(handle));
                g.Layers.Add(lyr);
            }
            return g.Handle;
        }
        #endregion

        private LegendLayer CreateLayer(int layerHandle, object newLayer)
        {
            var lyr = new LegendLayer(_map as AxMap, layerHandle, this);    // TODO: fix it
            if (lyr.Type == LegendLayerType.Image)
            {
                lyr.HasTransparency = HasTransparency(newLayer);
            }

            return lyr;
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot()
        {
            return Snapshot(false, 200);
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="imgWidth">Width in pixels of the desired Snapshot</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot(int imgWidth)
        {
            return Snapshot(false, imgWidth);
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="VisibleLayersOnly">Only visible layers used in Snapshot?</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot(bool VisibleLayersOnly)
        {
            return Snapshot(VisibleLayersOnly, 200);
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font.
        /// </summary>
        /// <param name="VisibleLayersOnly">Only visible layers used in Snapshot?</param>
        /// <param name="useFont">Which font to use for legend text?</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot(bool VisibleLayersOnly, Font useFont)
        {
            Font o = _font;
            _font = useFont;
            Bitmap b = Snapshot(VisibleLayersOnly, 200);
            _font = o;
            return b;
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font and width.
        /// </summary>
        /// <param name="VisibleLayersOnly">Only visible layers used in Snapshot?</param>
        /// <param name="imgWidth">Width of the image.</param>
        /// <param name="useFont">Which font to use for legend text?</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot(bool VisibleLayersOnly, int imgWidth, Font useFont)
        {
            Font o = _font;
            _font = useFont;
            Bitmap b = Snapshot(VisibleLayersOnly, imgWidth);
            _font = o;
            return b;
        }

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font and width.
        /// </summary>
        /// <param name="VisibleLayersOnly">Only visible layers used in Snapshot?</param>
        /// <param name="imgWidth">Width of the image.</param>
        /// <param name="useFont">Which font to use for legend text?</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot(bool VisibleLayersOnly, int imgWidth, Font useFont, Color foreColor)
        {
            Color fore = this.ForeColor;
            this.ForeColor = foreColor;
            
            Font o = _font;
            _font = useFont;

            Bitmap b = null;
            try
            {
                this.Lock();
                b = Snapshot(VisibleLayersOnly, imgWidth, useFont);
                
            }
            finally
            {
                this.ForeColor = fore;
                _font = o;
                this.Unlock();
            }
            return b;
        }


        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="VisibleLayersOnly">Only visible layers used in Snapshot?</param>
        /// <param name="imgWidth">Width in pixels of the desired Snapshot</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        public System.Drawing.Bitmap Snapshot(bool VisibleLayersOnly, int imgWidth)
        {
            int imgHeight = 0;// = CalcTotalDrawHeight(true);
            Bitmap bmp = null;// = new Bitmap(imgWidth,imgHeight);
            Rectangle rect = new Rectangle(0, 0, 0, 0);
            int GrpCount, i;
            LegendLayer lyr;
            int LyrHeight;

            try
            {
                System.Drawing.Graphics g;

                if (VisibleLayersOnly == true)
                {
                     var visibleLayers = new List<LegendLayer>();

                    //figure out how big the img needs to be in height
                    for (i = _layers.Count - 1; i >= 0; i--)
                    {
                        lyr = _layers[i];
                        if (lyr.Visible && !lyr.HideFromLegend)
                        {
                            imgHeight += lyr.CalcHeight(true) - 1;
                            visibleLayers.Add(lyr);
                        }
                    }

                    imgHeight += Constants.ITEM_PAD;

                    bmp = new Bitmap(imgWidth, imgHeight, this.CreateGraphics());
                    g = Graphics.FromImage(bmp);
                    g.Clear(this.BackColor);

                    if (visibleLayers.Count > 0)
                    {	//set up the boundaries for the first layer
                        LyrHeight = (visibleLayers[0]).CalcHeight(true);
                        rect = new Rectangle(2, 2, imgWidth - 4, LyrHeight - 1);
                    }

                    for (i = 0; i < visibleLayers.Count; i++)
                    {
                        lyr = visibleLayers[i];

                        DrawLayer(g, lyr, rect, true);

                        LyrHeight = lyr.CalcHeight(true);

                        rect.Y += LyrHeight - 1;
                        rect.Height = LyrHeight;
                    }
                }
                else
                {//draw all layers
                    GrpCount = _groupManager.Count;
                    Group grp;
                    int LyrCount;

                    imgHeight = 0;

                    //figure out how tall the image is going to need to be
                    for (i = GrpCount - 1; i >= 0; i--)
                    {
                        grp = _groupManager[i];
                        LyrCount = grp.Layers.Count;
                        for (int j = LyrCount - 1; j >= 0; j--)
                        {
                            lyr = grp.Layers[j];
                            if (!lyr.HideFromLegend)
                            {
                                imgHeight += lyr.CalcHeight(true) - 1;
                            }
                        }
                    }

                    imgHeight += Constants.ITEM_PAD;

                    //create a new bitmap of the right size, then create a graphics object from the bitmap
                    bmp = new Bitmap(imgWidth, imgHeight, this.CreateGraphics());
                    g = Graphics.FromImage(bmp);
                    g.Clear(this.BackColor);

                    rect = new Rectangle(2, 2, imgWidth - 4, imgHeight - 1);

                    //now draw the snapshot
                    for (i = GrpCount - 1; i >= 0; i--)
                    {
                        grp = _groupManager[i];
                        LyrCount = grp.Layers.Count;
                        for (int j = LyrCount - 1; j >= 0; j--)
                        {
                            lyr = grp.Layers[j];
                            if (!lyr.HideFromLegend)
                            {
                                this.DrawLayer(g, lyr, rect, true);

                                LyrHeight = lyr.CalcHeight(true);

                                rect.Y += LyrHeight - 1;
                                rect.Height = LyrHeight;
                            }
                        }
                    }
                }

                return bmp;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Error: LegendControl.Snaphot. " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets a snapshot of a specific layer
        /// </summary>
        /// <param name="LayerHandle">layerHandle of the requested layer</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        protected internal System.Drawing.Bitmap LayerSnapshot(int LayerHandle)
        {
            return LayerSnapshot(LayerHandle, 200);
        }

        /// <summary>
        /// Gets a snapshot of a specific layer
        /// </summary>
        /// <param name="LayerHandle">layerHandle of the requested layer</param>
        /// <param name="imgWidth"></param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        protected internal Bitmap LayerSnapshot(int LayerHandle, int imgWidth)
        {
            if (!Layers.IsValidHandle(LayerHandle))
                return null;

            var lyr = Layers.ItemByHandle(LayerHandle);

            Bitmap bmp;
            Graphics g;
            int LyrHeight = lyr.CalcHeight(true);
            bmp = new Bitmap(imgWidth, LyrHeight);
            g = Graphics.FromImage(bmp);

            Rectangle rect = new Rectangle(0, 0, imgWidth - 1, LyrHeight - 1);
            DrawLayer(g, lyr, rect, true);

            return bmp;
        }

        internal bool HasTransparency(object newLayer)
        {
            try
            {
                MapWinGIS.Image img = newLayer as MapWinGIS.Image;
                if (img != null)
                {
                    if (img.UseTransparencyColor == true)
                        return true;
                }
            }
            catch (System.Exception ex)
            {
                string str = ex.Message;
            }

            return false;
        }
       
        /// <summary>
        /// Tells you if a group exists with the specified handle
        /// </summary>
        /// <param name="Handle">layerHandle of the group to check</param>
        /// <returns>True if the Group extists, False otherwise</returns>
        protected internal bool IsValidGroup(int Handle)
        {
            if (Handle >= 0 && Handle < m_GroupPositions.Count)
            {
                if ((int)m_GroupPositions[Handle] >= 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Finds a layer given the handle
        /// </summary>
        /// <param name="Handle">layerHandle of the layer to find</param>
        /// <param name="GroupIndex">ByRef parameter that receives the index to the containing group</param>
        /// <param name="LayerIndex">ByRef parameter that receives the index of the Layer within the group</param>
        /// <returns>Layer on success, null (nothing) otherwise</returns>
        protected internal LegendLayer FindLayerByHandle(int Handle, out int GroupIndex, out int LayerIndex)
        {
            GroupIndex = -1;
            LayerIndex = -1;

            int GroupCount, ItemCount;
            GroupCount = AllGroups.Count;

            for (int i = 0; i < GroupCount; i++)
            {
                var grp = AllGroups[i];
                ItemCount = grp.Layers.Count;
                for (int j = 0; j < ItemCount; j++)
                {
                    var lyr = grp.Layers[j];
                    if (lyr.Handle == Handle)
                    {
                        GroupIndex = i;
                        LayerIndex = j;
                        return lyr;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Finds a layer by handle
        /// </summary>
        /// <param name="Handle">layerHandle of the layer to lookup</param>
        /// <returns>Layer if Successful, null (nothing) otherwise</returns>
        protected internal Layer FindLayerByHandle(int Handle)
        {
            int GroupIndex, LayerIndex;
            return FindLayerByHandle(Handle, out GroupIndex, out LayerIndex);
        }

        private void DrawCheckBox(Graphics DrawTool, int ItemTop, int ItemLeft, bool DrawCheck, bool DrawGrayBackground)
        {
            Image icon;
            int index = 0;
            if (DrawCheck == true)
            {
                if (DrawGrayBackground == true)
                    index = cCheckedBoxGrayIcon;
                else
                    index = cCheckedBoxIcon;
            }
            else
            {
                if (DrawGrayBackground == true)
                    index = cUnCheckedBoxGrayIcon;
                else
                    index = cUnCheckedBoxIcon;
            }
            icon = _icons.Images[index];
            DrawPicture(DrawTool, ItemLeft, ItemTop, Constants.CHECK_BOX_SIZE, Constants.CHECK_BOX_SIZE, icon);
        }

        /// <summary>
        /// Draws picture in the legend. Picture can be either an image or an icon
        /// </summary>
        private void DrawPicture(Graphics DrawTool, int PicLeft, int PicTop, int PicWidth, int PicHeight, object picture)
        {
            if (picture == null) return;

            SmoothingMode oldSM = DrawTool.SmoothingMode;
            DrawTool.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rect = new Rectangle(PicLeft, PicTop, PicWidth, PicHeight);

            Icon icon = null;
            if (picture is Icon)
            {
                icon = (Icon)picture;
            }

            if (icon != null)
            {
                DrawTool.DrawIcon(icon, rect);
            }
            else
            {
                //try casting it to an Image
                Image img = null;
                try { img = (Image)picture; }
                catch (InvalidCastException) { }

                if (img != null)
                {
                    DrawTool.DrawImage(img, rect);
                }
                else
                {
                    MapWinGIS.Image mwImg = null;
                    try { mwImg = (MapWinGIS.Image)picture; }
                    catch (InvalidCastException) { }
                    if (mwImg != null)
                    {
                        try
                        {
                            img = Image.FromHbitmap(new System.IntPtr(mwImg.Picture.Handle));
                            DrawTool.DrawImage(img, rect);
                        }
                        catch (Exception) { }
                    }
                    mwImg = null;
                }
            }

            DrawTool.SmoothingMode = oldSM;
        }

        /// <summary>
        /// Expansion box with plus or minus sign
        /// </summary>
        /// <param name="DrawTool"></param>
        /// <param name="ItemTop"></param>
        /// <param name="ItemLeft"></param>
        /// <param name="Expanded"></param>
        private void DrawExpansionBox(Graphics DrawTool, int ItemTop, int ItemLeft, bool Expanded)
        {
            int MidX, MidY;
            Rectangle rect;

            Pen pen = new Pen(_boxLineColor, 1);

            rect = new Rectangle(ItemLeft, ItemTop, Constants.EXPAND_BOX_SIZE, Constants.EXPAND_BOX_SIZE);

            //draw the border
            DrawBox(DrawTool, rect, _boxLineColor, Color.White);

            MidX = (int)(rect.Left + .5 * (rect.Width));
            MidY = (int)(rect.Top + .5 * (rect.Height));

            if (Expanded == false)
            {//draw a + sign, indicating that there is more to be seen
                //draw the vertical part
                DrawTool.DrawLine(pen, MidX, ItemTop + 2, MidX, ItemTop + Constants.EXPAND_BOX_SIZE - 2);

                //draw the horizontal part
                DrawTool.DrawLine(pen, ItemLeft + 2, MidY, ItemLeft + Constants.EXPAND_BOX_SIZE - 2, MidY);
            }
            else
            {//draw a - sign
                DrawTool.DrawLine(pen, ItemLeft + 2, MidY, ItemLeft + Constants.EXPAND_BOX_SIZE - 2, MidY);
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
                _lockCount--;
            if (_lockCount == 0)
                Redraw();
        }

        /// <summary>
        /// Drawing procedure for the new symbology
        /// </summary>
        /// <param name="DrawTool"></param>
        /// <param name="lyr"></param>
        /// <param name="bounds"></param>
        /// <param name="IsSnapshot"></param>
        protected internal void DrawLayerExt(Graphics DrawTool, Layer lyr, Rectangle bounds, bool IsSnapshot)
        {
        }

        /// <summary>
        /// Draws a layer onto a given graphics surface
        /// </summary>
        /// <param name="DrawTool">Graphics surface (object) onto which the give layer should be drawn</param>
        /// <param name="lyr">Layer object to be drawn</param>
        /// <param name="bounds">Rectangle oulining the allowable draw area</param>
        /// <param name="IsSnapshot">Drawing is done differently when it is a snapshot we are takeing of this layer</param>
        protected internal void DrawLayer(Graphics DrawTool, LegendLayer lyr, Rectangle bounds, bool IsSnapshot)
        {
            int CurLeft,
                CurTop,
                CurWidth,
                CurHeight;
            Rectangle rect;

            lyr.SmallIconWasDrawn = false;
            lyr.Top = bounds.Top;
            lyr.Elements.Clear();

            CurLeft = bounds.Left;
            CurTop = bounds.Top;
            CurWidth = bounds.Width - Constants.ITEM_RIGHT_PAD;
            CurHeight = lyr.Height;
            rect = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

            // ------------------------------------------------------
            //  drawing background (with selection if needed)
            // ------------------------------------------------------
            if (IsSnapshot == false)
            {
                CurLeft = bounds.Left;
                CurTop = bounds.Top;
                CurWidth = bounds.Width - Constants.ITEM_RIGHT_PAD;
                CurHeight = lyr.Height;
                rect = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                if (lyr.Handle == _selectedLayerHandle && bounds.Width > 25)
                {
                    // selects the title only
                    rect.Height = Constants.ITEM_HEIGHT;

                    if (CurTop + rect.Height > 0 || CurTop < this.ClientRectangle.Height)
                    {
                        DrawBox(DrawTool, rect, _boxLineColor, _selectedColor);
                    }
                }
            }
            else
            {
                CurLeft = bounds.Left;
                CurTop = bounds.Top;
                CurWidth = bounds.Width - 1;
                CurHeight = lyr.CalcHeight(true) - 1;
                rect = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                DrawBox(DrawTool, rect, _boxLineColor, System.Drawing.Color.White);
                // MessageBox.Show("IsSnapshot");
            }

            // -------------------------------------------------------
            //  drawing checkbox
            // -------------------------------------------------------
            if (bounds.Width > 55 && IsSnapshot == false)
            {
                CurTop = bounds.Top + Constants.CHECK_TOP_PAD;
                CurLeft = bounds.Left + Constants.CHECK_LEFT_PAD;

                bool visible = true;
                if (lyr.DynamicVisibility)
                {
                    visible = (_map.CurrentScale >= lyr.MinVisibleScale) && (_map.CurrentScale <= lyr.MaxVisibleScale)
                                && _map.Tiles.CurrentZoom >= lyr.MinVisibleZoom && _map.Tiles.CurrentZoom <= lyr.MaxVisibleZoom;
                }
                visible = visible && _map.get_LayerVisible(lyr.Handle);

                // draw a grey background if the layer is in dynamic visibility mode.
                DrawCheckBox(DrawTool, CurTop, CurLeft, visible, lyr.DynamicVisibility); 
            }

            // ----------------------------------------------------------
            //    Drawing text
            // ----------------------------------------------------------
            var textSize = new SizeF(0.0f, 0.0f);
            if (bounds.Width > 60)
            {
                //draw text
                string text = _map.get_LayerName(lyr.Handle);
                textSize = DrawTool.MeasureString(text, _font);

                if (IsSnapshot == true)
                    CurLeft = bounds.Left + Constants.CHECK_LEFT_PAD;
                else
                    CurLeft = bounds.Left + Constants.TEXT_LEFT_PAD;

                CurTop = bounds.Top + Constants.TEXT_TOP_PAD;
                //CurWidth = bounds.Width - CurLeft - Constants.TEXT_RIGHT_PAD;
                CurWidth = bounds.Width - Constants.TEXT_RIGHT_PAD - 27;
                CurHeight = Constants.TEXT_HEIGHT;

                rect = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);
                DrawText(DrawTool, text, rect, _font, this.ForeColor);

                var el = new LayerElement(LayerElementType.Name, rect, text);
                lyr.Elements.Add(el);
            }

            // -------------------------------------------------------------
            //    Drawing layer icon
            // -------------------------------------------------------------
            if (bounds.Width > 60 && bounds.Right - CurLeft - 41 > textSize.Width)  // -5 (offset)
            {
                int top = bounds.Top + Constants.ICON_TOP_PAD;
                int left = bounds.Right - 36;
                Image icon;

                var ogrLayer = lyr.VectorLayer;
                if (ogrLayer != null)
                {
                    icon = _icons.Images[cDatabase];
                    DrawPicture(DrawTool, left, CurTop, Constants.ICON_SIZE, Constants.ICON_SIZE, icon);
                }
                else if (lyr.Icon != null)
                {
                    DrawPicture(DrawTool, left, CurTop, Constants.ICON_SIZE, Constants.ICON_SIZE, lyr.Icon);
                }
                else if (lyr.Type == LegendLayerType.Image)
                {
                    icon = _icons.Images[cImageIcon];
                    DrawPicture(DrawTool, left, top, Constants.ICON_SIZE, Constants.ICON_SIZE, icon);
                }
                else if (lyr.Type == LegendLayerType.Grid)
                {
                    icon = _icons.Images[cGridIcon];
                    DrawPicture(DrawTool, left, top, Constants.ICON_SIZE, Constants.ICON_SIZE, icon);
                }
                else
                {
                    // drawing shapefile symbology preview, but only in case the layer is collapsed
                    if (!lyr.Expanded)
                    {
                        lyr.SmallIconWasDrawn = true;
                        var iconBounds = new Rectangle(left, top, Constants.ICON_SIZE, Constants.ICON_SIZE);

                        // drawing category symbol
                        IntPtr hdc = DrawTool.GetHdc();
                        Color clr = (lyr.Handle == _selectedLayerHandle && bounds.Width > 25) ? _selectedColor : this.BackColor;
                        uint backColor = Convert.ToUInt32(ColorTranslator.ToOle(clr));

                        var sf = _map.get_GetObject(lyr.Handle) as Shapefile;

                        if (lyr.Type == LegendLayerType.PointShapefile)
                            sf.DefaultDrawingOptions.DrawPoint(hdc, left, top, Constants.ICON_SIZE, Constants.ICON_SIZE, backColor);
                        else if (lyr.Type == LegendLayerType.LineShapefile)
                            sf.DefaultDrawingOptions.DrawLine(hdc, left, top, Constants.ICON_SIZE - 1, Constants.ICON_SIZE - 1, false, Constants.ICON_SIZE, Constants.ICON_SIZE, backColor);
                        else if (lyr.Type == LegendLayerType.PolygonShapefile)
                            sf.DefaultDrawingOptions.DrawRectangle(hdc, left, top, Constants.ICON_SIZE - 1, Constants.ICON_SIZE - 1, false, Constants.ICON_SIZE, Constants.ICON_SIZE, backColor);

                        DrawTool.ReleaseHdc(hdc);
                    }
                }

                //  labels link
                if (bounds.Width > 60 && bounds.Right - CurLeft - 62 > textSize.Width)   // -62
                {
                    var sf = _map.get_Shapefile(lyr.Handle);
                    if (sf != null)
                    {
                        int top2 = bounds.Top + Constants.ICON_TOP_PAD;
                        int left2 = bounds.Right - 56;

                        //Image icon = null;
                        double scale = _map.CurrentScale;
                        bool labelsVisible = sf.Labels.Count > 0 && sf.Labels.Visible && sf.Labels.Expression.Trim() != "";
                        labelsVisible &= scale >= sf.Labels.MinVisibleScale && scale <= sf.Labels.MaxVisibleScale;
                        Image icon2 = labelsVisible ? _icons.Images[cActiveLabelIcon] : _icons.Images[cDimmedLabelIcon];
                        DrawPicture(DrawTool, left2, top2, Constants.ICON_SIZE, Constants.ICON_SIZE, icon2);
                    }
                }

                //  editing icon
                if (bounds.Width > 60 && bounds.Right - CurLeft - 82 > textSize.Width)
                {
                    var sf = _map.get_Shapefile(lyr.Handle);
                    if (sf != null && sf.InteractiveEditing)
                    {
                        int top2 = bounds.Top + Constants.ICON_TOP_PAD;
                        int left2 = bounds.Right - 76;
                        DrawPicture(DrawTool, left2, top2, Constants.ICON_SIZE, Constants.ICON_SIZE, _icons.Images[cEditing]);
                    }
                }
            }

            // -------------------------------------------------------------
            //    Drawing categories and expansion box for shapefiles
            // -------------------------------------------------------------
            if (lyr.Type == LegendLayerType.PointShapefile || 
                lyr.Type == LegendLayerType.LineShapefile || 
                lyr.Type == LegendLayerType.PolygonShapefile)
            {
                if (bounds.Width > 17 && IsSnapshot == false)
                {
                    rect = new Rectangle(bounds.Left, bounds.Top, bounds.Width - Constants.ITEM_RIGHT_PAD, bounds.Height);
                    DrawExpansionBox(DrawTool, rect.Top + Constants.EXPAND_BOX_TOP_PAD, rect.Left + Constants.EXPAND_BOX_LEFT_PAD, lyr.Expanded);
                }

                // drawing shapefile
                DrawShapefileCategories(DrawTool, lyr, bounds, IsSnapshot);      // drawing of categories for the new symbology

                // drawing image
                //MapWinGIS.Image img = _map.get_GetObject(lyr.layerHandle) as MapWinGIS.Image;
            }
            else
            {
                // ----------------------------------------------------------
                //   Draw the expansion box and sub items (if they exist or if we're being forced)
                // ----------------------------------------------------------
                bool Handled = false;

                var customRect = new Rectangle(bounds.Left + Constants.CHECK_LEFT_PAD,
                    lyr.Top + Constants.ITEM_HEIGHT + Constants.EXPAND_BOX_TOP_PAD,
                    bounds.Width - Constants.TEXT_RIGHT_PAD_NO_ICON - Constants.CS_TEXT_LEFT_INDENT -
                    Constants.EXPAND_BOX_LEFT_PAD, bounds.Height - lyr.Top);

                if (lyr.Expanded && lyr.ExpansionBoxCustomRenderFunction != null)
                {
                    var args = new LayerPaintEventArgs(lyr.Handle, customRect, DrawTool);
                    FireEvent(this, lyr.ExpansionBoxCustomRenderFunction, args);
                }

                // Here, draw the + or - sign according to based on  layer.expanded property
                if (lyr.ExpansionBoxForceAllowed || lyr.ColorLegend.Count > 0)
                {
                    if (bounds.Width > 17 && IsSnapshot == false)
                    {
                        //SetRect(&LocalBounds, bounds.left + LIST_ITEM_INDENT,Top,bounds.right-ITEM_PAD,Top+lyr.Height);
                        rect = new Rectangle(bounds.Left, bounds.Top, bounds.Width - Constants.ITEM_RIGHT_PAD, bounds.Height);
                        DrawExpansionBox(DrawTool, rect.Top + Constants.EXPAND_BOX_TOP_PAD, rect.Left + Constants.EXPAND_BOX_LEFT_PAD, lyr.Expanded);
                    }
                }
            }
        }

        /// <summary>
        /// Draws color scheme (categories) for the shapefile layer
        /// </summary>
        private void DrawShapefileCategories(Graphics DrawTool, LegendLayer layer, Rectangle bounds, bool IsSnapshot)
        {
            if (layer.Type != LegendLayerType.PointShapefile &&
                layer.Type != LegendLayerType.LineShapefile &&
                layer.Type != LegendLayerType.PolygonShapefile) return;

            if ((!IsSnapshot && !layer.Expanded) || bounds.Width <= 47)
                return;

            var sf = _map.get_Shapefile(layer.Handle);
            if (sf == null) return;

            int maxWidth = Constants.ICON_WIDTH; ;
            if (layer.Type == LegendLayerType.PointShapefile)
                maxWidth = layer.get_MaxIconWidth(sf);

            int top = bounds.Top + Constants.ITEM_HEIGHT + 2;

            // temp
            int val1;
            int height;
            val1 = (layer.GetCategoryHeight(sf.DefaultDrawingOptions) + 2);  // default symbology

            //if (sf.Labels.Count == 0 || (!sf.Labels.Visible) || !this.ShowLabels)
            //{
            height = val1;
            //}
            //else
            //{
            //    string text = "Arizona";
            //    LabelStyle style = new LabelStyle(sf.Labels.Options);
            //    System.Drawing.Bitmap img = new System.Drawing.Bitmap(500, 200);
            //    Graphics g = Graphics.FromImage(img);
            //    Size size = style.MeasureString(g, text, 30);
            //    val2 = size.Height + 2;
            //    height = val1 > val2 ? val1 : val2;

            //    SmoothingMode oldMode = DrawTool.SmoothingMode;
            //    DrawTool.SmoothingMode = SmoothingMode.AntiAlias;

            //    int leftTemp = bounds.Left + Constants.TEXT_LEFT_PAD + maxWidth + 5;
            //    Rectangle textBounds = style.Draw(DrawTool, new Point(leftTemp, top), text, false, 30);

            //    DrawTool.SmoothingMode = oldMode;

            //    // storing rectangle
            //    LayerElement el = new LayerElement(LayerElementType.Label, textBounds, text);
            //    layer.Elements.Add(el);
            //}

            if (top + height > this.ClientRectangle.Top)
            {
                DrawShapefileCategory(DrawTool, sf.DefaultDrawingOptions, layer, bounds, top, "", maxWidth, -1);
            }

            top += height;
            // end temp

            Rectangle rect = new Rectangle();
            if (sf.Categories.Count > 0)
            {
                // categories caption
                string caption = sf.Categories.Caption;
                if (caption == string.Empty) caption = "Categories";
                int left = bounds.Left + Constants.TEXT_LEFT_PAD;
                if (!(top + Constants.TEXT_HEIGHT < 0))
                {
                    rect = new Rectangle(left, top, bounds.Width - Constants.TEXT_RIGHT_PAD_NO_ICON - Constants.CS_TEXT_LEFT_INDENT, Constants.TEXT_HEIGHT);
                    DrawText(DrawTool, caption, rect, _font, this.ForeColor);
                }
                top += Constants.CS_ITEM_HEIGHT + 2;

                //figure out if we can clip any of the categories at the top
                int i = 0;
                MapWinGIS.ShapefileCategories categories = sf.Categories;
                int numCategories = sf.Categories.Count;
                if (top < this.ClientRectangle.Top && IsSnapshot == false)
                {
                    while (i < numCategories)
                    {
                        // for point categories height can be different
                        top += layer.GetCategoryHeight(categories.get_Item(i).DrawingOptions);

                        if (top < this.ClientRectangle.Top)
                        {
                            i++;
                        }
                        else
                        {
                            top -= layer.GetCategoryHeight(categories.get_Item(i).DrawingOptions);  // this category should be drawn
                            break;
                        }
                    }
                }

                // we shall draw symbology first and text second
                // symbology is drawn from ocx, so it's better to draw all categories at once
                // avoiding additional GetHDC calls
                IntPtr hdc = DrawTool.GetHdc();
                int topTemp = top;
                int startIndex = i;
                for (; i < categories.Count; i++)
                {
                    MapWinGIS.ShapefileCategory cat = categories.get_Item(i);
                    MapWinGIS.ShapeDrawingOptions options = cat.DrawingOptions;

                    DrawShapefileCategorySymbology(DrawTool, options, layer, bounds, topTemp, maxWidth, i, hdc);

                    topTemp += layer.GetCategoryHeight(options);
                    if (topTemp >= this.ClientRectangle.Bottom && IsSnapshot == false)     // stop drawing in case there are not visible
                        break;
                }
                DrawTool.ReleaseHdc(hdc);

                // now when hdc is released, GDI+ can be used for the text
                i = startIndex;
                for (; i < categories.Count; i++)
                {
                    MapWinGIS.ShapefileCategory cat = categories.get_Item(i);
                    MapWinGIS.ShapeDrawingOptions options = cat.DrawingOptions;

                    DrawShapefileCategoryText(DrawTool, options, layer, bounds, top, cat.Name, maxWidth, i);

                    top += layer.GetCategoryHeight(options);
                    if (top >= this.ClientRectangle.Bottom && IsSnapshot == false)     // stop drawing in case there are not visible
                        break;
                }
            }

            // charts
            if (sf.Charts.Count > 0 && sf.Charts.NumFields > 0 && sf.Charts.Visible)
            {
                // charts caption
                string caption = sf.Charts.Caption;
                if (caption == string.Empty)
                    caption = "Charts";

                int left = bounds.Left + Constants.TEXT_LEFT_PAD;
                rect = new Rectangle(left, top, bounds.Width - Constants.TEXT_RIGHT_PAD_NO_ICON - Constants.CS_TEXT_LEFT_INDENT, Constants.TEXT_HEIGHT);
                DrawText(DrawTool, caption, rect, _font, this.ForeColor);
                top += Constants.CS_ITEM_HEIGHT + 2;

                // storing bounds
                LayerElement el = new LayerElement(LayerElementType.Charts, rect);
                layer.Elements.Add(el);

                // preview
                IntPtr hdc = DrawTool.GetHdc();
                uint backColor = Convert.ToUInt32(ColorTranslator.ToOle(this.BackColor));

                left = bounds.Left + Constants.TEXT_LEFT_PAD;
                sf.Charts.DrawChart(hdc, left, top, true, backColor);
                top += sf.Charts.IconHeight + 2;
                DrawTool.ReleaseHdc(hdc);

                // storing bounds
                el = new LayerElement(LayerElementType.ChartField, rect);
                layer.Elements.Add(el);

                // fields
                Color color = ColorTranslator.FromOle(Convert.ToInt32(sf.Charts.LineColor));
                Pen pen = new Pen(color);

                for (int i = 0; i < sf.Charts.NumFields; i++)
                {
                    rect = new Rectangle(left, top, Constants.ICON_WIDTH, Constants.ICON_HEIGHT);
                    color = ColorTranslator.FromOle(Convert.ToInt32(sf.Charts.get_Field(i).Color));
                    SolidBrush brush = new SolidBrush(color);
                    DrawTool.FillRectangle(brush, rect);
                    DrawTool.DrawRectangle(pen, rect);

                    // storing bounds
                    el = new LayerElement(LayerElementType.ChartField, rect, i);
                    layer.Elements.Add(el);

                    rect = new Rectangle(left + Constants.ICON_WIDTH + 5, top, bounds.Width - Constants.TEXT_RIGHT_PAD_NO_ICON - Constants.CS_TEXT_LEFT_INDENT, Constants.TEXT_HEIGHT);
                    string name = sf.Charts.get_Field(i).Name;
                    DrawText(DrawTool, name, rect, _font, Color.Black);

                    // storing bounds
                    el = new LayerElement(LayerElementType.ChartFieldName, rect, name, i);
                    layer.Elements.Add(el);

                    top += (Constants.CS_ITEM_HEIGHT + 2);
                }
            }
        }

        /// <summary>
        /// Draws shapefile category in specified location
        /// </summary>
        /// <param name="options">Options to use for drawing</param>
        /// <param name="type">Shapefile type</param>
        private void DrawShapefileCategory(Graphics DrawTool, MapWinGIS.ShapeDrawingOptions options, LegendLayer layer,
                                           Rectangle bounds, int top, string name, int maxWidth, int index)
        {
            int categoryHeight = layer.GetCategoryHeight(options);
            int categoryWidth = layer.GetCategoryWidth(options);

            // drawing category symbol
            IntPtr hdc = DrawTool.GetHdc();
            uint backColor = Convert.ToUInt32(ColorTranslator.ToOle(this.BackColor));

            int left = bounds.Left + Constants.TEXT_LEFT_PAD;
            if (categoryWidth != Constants.ICON_WIDTH)
            {
                left -= ((categoryWidth - Constants.ICON_WIDTH) / 2);
            }

            if (layer.Type == LegendLayerType.PointShapefile)
                options.DrawPoint(hdc, left, top, categoryWidth + 1, categoryHeight + 1, backColor);
            else if (layer.Type == LegendLayerType.LineShapefile)
                options.DrawLine(hdc, left, top, categoryWidth - 1, Constants.ICON_HEIGHT - 1, false, categoryWidth, categoryHeight, backColor);
            else if (layer.Type == LegendLayerType.PolygonShapefile)
                options.DrawRectangle(hdc, left, top, categoryWidth - 1, Constants.ICON_HEIGHT - 1, false, categoryWidth, categoryHeight, backColor);

            DrawTool.ReleaseHdc(hdc);

            if (categoryHeight > Constants.CS_ITEM_HEIGHT)
                top += (categoryHeight - Constants.CS_ITEM_HEIGHT) / 2;

            // drawing category name
            left = (bounds.Left + Constants.TEXT_LEFT_PAD + Constants.ICON_WIDTH / 2 + maxWidth / 2 + 5);

            Rectangle rect = new Rectangle(left, top, bounds.Width - Constants.TEXT_RIGHT_PAD_NO_ICON - Constants.CS_TEXT_LEFT_INDENT, Constants.TEXT_HEIGHT);
            DrawText(DrawTool, name, rect, _font, Color.Black);
        }

        /// <summary>
        /// Draws shapefile category. It's assumed here that GetHDC and ReleaseHDC calls are made by caller
        /// </summary>
        private void DrawShapefileCategorySymbology(Graphics DrawTool, MapWinGIS.ShapeDrawingOptions options, LegendLayer layer,
                                           Rectangle bounds, int top, int maxWidth, int index, IntPtr hdc)
        {
            int categoryHeight = layer.GetCategoryHeight(options);
            int categoryWidth = layer.GetCategoryWidth(options);

            uint backColor = Convert.ToUInt32(ColorTranslator.ToOle(this.BackColor));

            int left = bounds.Left + Constants.TEXT_LEFT_PAD;
            if (categoryWidth != Constants.ICON_WIDTH)
            {
                left -= ((categoryWidth - Constants.ICON_WIDTH) / 2);
            }

            if (layer.Type == LegendLayerType.PointShapefile)
                options.DrawPoint(hdc, left, top, categoryWidth + 1, categoryHeight + 1, backColor);
            else if (layer.Type == LegendLayerType.LineShapefile)
                options.DrawLine(hdc, left, top, categoryWidth - 1, Constants.ICON_HEIGHT - 1, false, categoryWidth, categoryHeight, backColor);
            else if (layer.Type == LegendLayerType.PolygonShapefile)
                options.DrawRectangle(hdc, left, top, categoryWidth - 1, Constants.ICON_HEIGHT - 1, false, categoryWidth, categoryHeight, backColor);

            if (categoryHeight > Constants.CS_ITEM_HEIGHT)
                top += (categoryHeight - Constants.CS_ITEM_HEIGHT) / 2;
        }

        /// <summary>
        /// Draw the text for the shapefile category
        /// </summary>
        private void DrawShapefileCategoryText(Graphics DrawTool, MapWinGIS.ShapeDrawingOptions options, LegendLayer layer,
                                           Rectangle bounds, int top, string name, int maxWidth, int index)
        {
            int categoryHeight = layer.GetCategoryHeight(options);
            if (categoryHeight > Constants.CS_ITEM_HEIGHT)
                top += (categoryHeight - Constants.CS_ITEM_HEIGHT) / 2;

            // drawing category name
            int left = (bounds.Left + Constants.TEXT_LEFT_PAD + Constants.ICON_WIDTH / 2 + maxWidth / 2 + 5);

            Rectangle rect = new Rectangle(left, top, bounds.Width - Constants.TEXT_RIGHT_PAD_NO_ICON - Constants.CS_TEXT_LEFT_INDENT, Constants.TEXT_HEIGHT);
            DrawText(DrawTool, name, rect, _font, this.ForeColor);
        }

        /// <summary>
        /// Drawing icon for the new symbology
        /// </summary>
        /// <param name="DrawTool"></param>
        /// <param name="LayerType"></param>
        /// <param name="TopPos"></param>
        /// <param name="LeftPos"></param>
        /// <param name="FillColor"></param>
        /// <param name="OutlineColor"></param>
        /// <param name="LayerHandle"></param>
        private void DrawLayerSymbolNew(Graphics DrawTool, LegendLayer layer, int TopPos, int LeftPos)
        {
            System.Drawing.Drawing2D.SmoothingMode OldSmoothingMode;
            OldSmoothingMode = DrawTool.SmoothingMode;

            try
            {
                DrawTool.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Image icon;

                switch (layer.Type)
                {
                    case LegendLayerType.Grid:
                        icon = _icons.Images[cGridIcon];
                        DrawPicture(DrawTool, LeftPos, TopPos, Constants.ICON_SIZE, Constants.ICON_SIZE, icon);
                        break;
                    case LegendLayerType.Image:
                        icon = _icons.Images[cImageIcon];
                        DrawPicture(DrawTool, LeftPos, TopPos, Constants.ICON_SIZE, Constants.ICON_SIZE, icon);
                        break;
                    default:
                        MapWinGIS.Shapefile sf = _map.get_GetObject(layer.Handle) as MapWinGIS.Shapefile;
                        if (sf == null)
                        {
                            MessageBox.Show("Error: shapefile not set");
                            return;
                        }

                        IntPtr hdc = DrawTool.GetHdc();

                        uint backColor = Convert.ToUInt32(ColorTranslator.ToOle(this.BackColor));

                        if (layer.Type == LegendLayerType.PointShapefile)
                            sf.DefaultDrawingOptions.DrawPoint(hdc, LeftPos, TopPos, Constants.ICON_WIDTH, Constants.ICON_HEIGHT, backColor);
                        else if (layer.Type == LegendLayerType.LineShapefile)
                            sf.DefaultDrawingOptions.DrawLine(hdc, LeftPos, TopPos, Constants.ICON_WIDTH - 1, Constants.ICON_SIZE - 1, false, Constants.ICON_WIDTH, Constants.ICON_HEIGHT, backColor);
                        else if (layer.Type == LegendLayerType.PolygonShapefile)
                            sf.DefaultDrawingOptions.DrawRectangle(hdc, LeftPos, TopPos, Constants.ICON_WIDTH - 1, Constants.ICON_SIZE - 1, false, Constants.ICON_WIDTH, Constants.ICON_HEIGHT, backColor);

                        DrawTool.ReleaseHdc(hdc);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                string temp = ex.Message;
            }

            DrawTool.SmoothingMode = OldSmoothingMode;
        }

        /// <summary>
        /// Control is being resized
        /// </summary>
        protected override void OnResize(System.EventArgs e)
        {
            if (this.Width > 0 && this.Height > 0)
            {
                _backBuffer = new Bitmap(this.Width, this.Height);
                _draw = Graphics.FromImage(_backBuffer);
                _vScrollBar.Top = 0;
                _vScrollBar.Height = this.Height;
                _vScrollBar.Left = this.Width - _vScrollBar.Width;
            }
            this.Invalidate();
        }

        /// <summary>
        /// Locates the group that was clicked on in the legend, based on the coordinate within the legend (0,0) being top left of legend)
        /// </summary>
        /// <param name="point">The point inside of the legend that was clicked.</param>
        /// <param name="InCheckbox">(by reference/out) Indicates whether a group visibilty check box was clicked.</param>
        /// <param name="InExpandbox">(by reference/out) Indicates whether the expand box next to a group was clicked.</param>
        /// <returns>Returns the group that was clicked on or null/nothing.</returns>
        public Group FindClickedGroup(Point point, out bool InCheckbox, out bool InExpandbox)
        {
            //finds the group that was clicked, i.e. heading of group, not subitems
            InExpandbox = false;
            InCheckbox = false;

            int GroupCount = AllGroups.Count;
            Group grp = null;

            int CurLeft = 0,
                CurTop = 0,
                CurWidth = 0,
                CurHeight = 0;
            Rectangle bounds;

            GroupCount = AllGroups.Count;

            for (int i = 0; i < GroupCount; i++)
            {
                grp = (Group)AllGroups[i];

                //set group header bounds
                CurLeft = Constants.GRP_INDENT;
                CurWidth = this.Width - Constants.GRP_INDENT - Constants.ITEM_RIGHT_PAD;
                CurTop = grp.Top;
                CurHeight = Constants.ITEM_HEIGHT;
                bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                if (bounds.Contains(point) == true)
                {//we are in the group heading
                    //now check to see if the click was in the expansion box
                    //+- a little to make the hot spot a little more precise
                    CurLeft = Constants.GRP_INDENT + Constants.EXPAND_BOX_LEFT_PAD + 1;
                    CurWidth = Constants.EXPAND_BOX_SIZE - 1;
                    CurTop = grp.Top + Constants.EXPAND_BOX_TOP_PAD + 1;
                    CurHeight = Constants.EXPAND_BOX_SIZE - 1;
                    bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                    if (bounds.Contains(point) == true)
                    {
                        //we are in the bounds for the expansion box
                        //but only if there is an expansion box visible
                        if ((int)(grp.Layers.Count) > 0)
                            InExpandbox = true;
                    }
                    else
                    {
                        //now check to see if in the check box
                        CurLeft = Constants.GRP_INDENT + Constants.CHECK_LEFT_PAD + 1;
                        CurWidth = Constants.CHECK_BOX_SIZE - 1;
                        CurTop = grp.Top + Constants.CHECK_TOP_PAD + 1;
                        CurHeight = Constants.CHECK_BOX_SIZE - 1;
                        bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);
                        if (bounds.Contains(point) == true)
                            InCheckbox = true;
                    }
                    return grp;
                }
            }
            return null;//if we get to this point, no group item found
        }

        /// <summary>
        /// Locates the layer that was clicked on in the legend, based on the coordinate within the legend (0,0) being top left of legend)
        /// </summary>
        /// <param name="point">The point inside of the legend that was clicked.</param>
        /// <param name="InCheckBox">(by reference/out) Indicates whether a layer visibilty check box was clicked.</param>
        /// <param name="InExpansionBox">(by reference/out) Indicates whether the expand box next to a layer was clicked.</param>
        /// <returns>Returns the group that was clicked on or null/nothing.</returns>
        public LegendLayer FindClickedLayer(Point point, out bool InCheckBox, out bool InExpansionBox)
        {
            ClickedElement element = new ClickedElement();
            var lyr = FindClickedLayer(point, ref element);
            InCheckBox = element.CheckBox;
            InExpansionBox = element.ExpansionBox;
            return lyr;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public LegendLayer FindClickedLayer(Point point, ref ClickedElement Element)
        {
            int GroupCount = AllGroups.Count;
            int LayerCount;

            Element.Nullify();

            LegendLayer lyr = null;
            Group grp = null;

            int CurLeft, CurTop, CurWidth, CurHeight;
            CurLeft = CurTop = CurWidth = CurHeight = 0;
            Rectangle bounds;

            for (int i = 0; i < GroupCount; i++)
            {
                grp = (Group)AllGroups[i];

                if (grp.Expanded == false)
                    continue;

                LayerCount = grp.Layers.Count;

                for (int j = 0; j < LayerCount; j++)
                {
                    lyr = grp.Layers[j];

                    //see if we are inside the current Layer
                    CurLeft = Constants.LIST_ITEM_INDENT;
                    CurTop = lyr.Top;
                    CurWidth = this.Width - CurLeft - Constants.ITEM_RIGHT_PAD;
                    CurHeight = lyr.Height;
                    bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                    if (bounds.Contains(point))
                    {
                        //we are inside the Layer boundaries,
                        //but we need to narrow down the search
                        Element.GroupIndex = i;

                        //check to see if in the check box
                        CurLeft = Constants.LIST_ITEM_INDENT + Constants.CHECK_LEFT_PAD + 1;
                        CurTop = lyr.Top + Constants.CHECK_TOP_PAD + 1;
                        CurWidth = Constants.CHECK_BOX_SIZE - 1;
                        CurHeight = Constants.CHECK_BOX_SIZE - 1;
                        bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                        if (bounds.Contains(point))
                        {
                            //we are in the check box
                            Element.CheckBox = true;
                            return lyr;
                        }
                        
                        //check to see if we are in the expansion box for this item
                        CurLeft = Constants.LIST_ITEM_INDENT + Constants.EXPAND_BOX_LEFT_PAD + 1;
                        CurTop = lyr.Top + Constants.EXPAND_BOX_TOP_PAD + 1;
                        CurWidth = Constants.EXPAND_BOX_SIZE;
                        CurHeight = Constants.EXPAND_BOX_SIZE;
                        bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                        if (lyr.Type == LegendLayerType.Image || lyr.Type == LegendLayerType.Grid)
                        {
                            if (bounds.Contains(point) == true && (lyr.ColorLegend.Count > 0 || lyr.ExpansionBoxForceAllowed ))
                            {
                                //We are in the Expansion box
                                Element.ExpansionBox = true;
                                return lyr;
                            }
                                
                            //we aren't in the checkbox or the expansion box
                            return lyr;
                        }
                            
                        if (bounds.Contains(point))
                        {
                            //We are in the Expansion box
                            Element.ExpansionBox = true;
                            return lyr;
                        }

                        if (!lyr.Expanded && 
                            (lyr.Type == LegendLayerType.LineShapefile || 
                             lyr.Type == LegendLayerType.PointShapefile || 
                             lyr.Type == LegendLayerType.PolygonShapefile) && lyr.SmallIconWasDrawn)
                        {
                            CurHeight = Constants.ICON_SIZE;
                            CurWidth = Constants.ICON_SIZE;
                            CurTop = lyr.Top + Constants.ICON_TOP_PAD;
                            CurLeft = this.Width - 36;
                            if (this._vScrollBar.Visible) 
                                CurLeft -= this._vScrollBar.Width;
                            bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);
                            if (bounds.Contains(point))
                            {
                                Element.ColorBox = true;
                                return lyr;
                            }
                        }

                        // layer icon (to the right from the caption)
                        if (lyr.Type == LegendLayerType.LineShapefile ||
                            lyr.Type == LegendLayerType.PointShapefile ||
                            lyr.Type == LegendLayerType.PolygonShapefile)
                        {
                            CurHeight = Constants.ICON_SIZE;
                            CurWidth = Constants.ICON_SIZE;
                            CurTop = lyr.Top + Constants.ICON_TOP_PAD;
                            CurLeft = this.Width - 56;
                            if (this._vScrollBar.Visible)
                                CurLeft -= this._vScrollBar.Width;

                            bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);
                            if (bounds.Contains(point))
                            {
                                Element.LabelsIcon = true;
                                return lyr;
                            }
                        }

                        // check to see if we are in the default color box
                        MapWinGIS.Shapefile sf = _map.get_GetObject(lyr.Handle) as MapWinGIS.Shapefile;

                        CurHeight = lyr.GetCategoryHeight(sf.DefaultDrawingOptions);
                        CurWidth = lyr.GetCategoryWidth(sf.DefaultDrawingOptions);
                        CurTop = lyr.Top + Constants.ITEM_HEIGHT + 2;
                        CurLeft = Constants.LIST_ITEM_INDENT + Constants.TEXT_LEFT_PAD;
                        if (CurWidth != Constants.ICON_WIDTH)
                        {
                            CurLeft -= ((CurWidth - Constants.ICON_WIDTH) / 2);
                        }
                        bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                        if (bounds.Contains(point))
                        {
                            Element.ColorBox = true;
                            return lyr;
                        }
                            
                        // check to sse if we are in the label
                        CurHeight = lyr.GetCategoryHeight(sf.DefaultDrawingOptions);
                        CurWidth = lyr.GetCategoryWidth(sf.DefaultDrawingOptions);
                        CurTop = lyr.Top + Constants.ITEM_HEIGHT + 2;
                        int maxWidth = lyr.get_MaxIconWidth(sf);
                        CurLeft = bounds.Left + Constants.TEXT_LEFT_PAD + maxWidth + 5;
                        bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                        if (bounds.Contains(point))
                        {
                            Element.Label = true;
                            return lyr;
                        }
                            
                        // categories
                        CurLeft = Constants.LIST_ITEM_INDENT + Constants.TEXT_LEFT_PAD;
                        CurTop = lyr.Top + Constants.ITEM_HEIGHT + 2;   // name
                        CurTop += CurHeight + 2;                        // default symbology

                        if (sf.Categories.Count > 0)
                        {
                            CurTop += Constants.CS_ITEM_HEIGHT + 2;         // categories caption

                            for (int cat = 0; cat < sf.Categories.Count; cat++)
                            {
                                ShapeDrawingOptions options = sf.Categories.get_Item(cat).DrawingOptions;
                                CurWidth = lyr.GetCategoryWidth(options);
                                CurHeight = lyr.GetCategoryHeight(options);
                                bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                                CurTop += CurHeight;

                                if (bounds.Contains(point))
                                {
                                    Element.ColorBox = true;
                                    Element.CategoryIndex = cat;
                                    return lyr;
                                }
                            }
                        }

                        if (sf.Charts.NumFields > 0 && sf.Charts.Count > 0)
                        {
                            CurTop += Constants.CS_ITEM_HEIGHT + 2;         // charts caption
                            CurWidth = sf.Charts.IconWidth;
                            CurHeight = sf.Charts.IconHeight;
                            bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                            if (bounds.Contains(point))
                            {
                                Element.Charts = true;
                                return lyr;
                            }
                                
                            CurTop += (CurHeight + 2);
                            CurHeight = Constants.ICON_HEIGHT;
                            CurWidth = Constants.ICON_WIDTH;

                            for (int fld = 0; fld < sf.Charts.NumFields; fld++)
                            {
                                bounds = new Rectangle(CurLeft, CurTop, CurWidth, CurHeight);

                                if (bounds.Contains(point))
                                {
                                    Element.Charts = true;
                                    Element.ChartFieldIndex = fld;
                                    //MessageBox.Show("Field selected: " + fld.ToString());
                                    return lyr;
                                }

                                CurTop += (Constants.CS_ITEM_HEIGHT + 2);
                            }
                        }

                        // nothing was hit
                        return lyr;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets whether or not the legend is locked.  See Lock() function for description
        /// </summary>
        public bool Locked
        {
            get { return _lockCount > 0; }
        }

        /// <summary>
        /// Gets the number of groups that exist in the legend
        /// </summary>
        protected internal int NumGroups
        {
            get
            {
                return this.AllGroups.Count;
            }
        }

        /// <summary>
        /// Redraw the LegendControl if not locked - See 'Locked' Property for more details
        /// </summary>
        protected internal void Redraw()
        {
            if (Locked == false)
            {
                //Application.DoEvents();
                this.Invalidate();
            }
        }

        public void FullRedraw()
        {
            if (Locked == false)
            {
                //Application.DoEvents();
                this.Invalidate();
            }
        }

        public void RedrawLegendAndMap()
        {
            if (!Locked)
            {
                _map.Redraw();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Clears all layers
        /// </summary>
        protected internal void ClearLayers()
        {
            Group grp = null;
            int GrpCount = AllGroups.Count;

            for (int i = 0; i < GrpCount; i++)
            {
                grp = (Group)AllGroups[i];
                grp.Layers.Clear();
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
            ClearLayers();
            _map.RemoveAllLayers();
            AllGroups.Clear();

            //int count = m_GroupPositions.Count;
            //for(int i = 0; i < count; i++)
            //    m_GroupPositions[i] = INVALID_GROUP;

            //Christian Degrassi 2010-02-18: Fixes issue 0001572
            m_GroupPositions.Clear();

            Redraw();
        }

        private int CalcTotalDrawHeight(bool UseExpandedHeight)
        {
            int i = 0,
                count = AllGroups.Count,
                retval = 0;

            if (UseExpandedHeight == true)
            {
                for (i = 0; i < count; i++)
                {
                    Groups[i].RecalcHeight();
                    retval += Groups[i].ExpandedHeight;
                }
            }
            else
            {
                for (i = 0; i < count; i++)
                {
                    Groups[i].RecalcHeight();
                    retval += Groups[i].Height + Constants.ITEM_PAD;
                }
            }

            return retval;
        }

        private void RecalcItemPositions()
        {
            //this function calculates the top of each group and layer.
            //this is important because the click events use the stored top as
            //the way of figuring out if the item was clicked
            //and if the checkbox or expansion box was clicked

            int TotalHeight = CalcTotalDrawHeight(false);
            Group grp;
            LegendLayer lyr;
            int CurTop = 0;

            if (_vScrollBar.Visible == true)
                CurTop = -_vScrollBar.Value;

            for (int i = AllGroups.Count - 1; i >= 0; i--)
            {
                grp = (Group)AllGroups[i];
                grp.Top = CurTop;
                if (grp.Expanded)
                {
                    CurTop += Constants.ITEM_HEIGHT;
                    for (int j = grp.Layers.Count - 1; j >= 0; j--)
                    {
                        lyr = grp.Layers[j];
                        if (!lyr.HideFromLegend)
                        {
                            lyr.Top = CurTop;

                            CurTop += lyr.Height;
                        }
                    }
                    CurTop += Constants.ITEM_PAD;
                }
                else
                    CurTop += grp.Height + Constants.ITEM_PAD;
            }
        }

        private void DrawNextFrame()
        {
            // bool scrollBarChanged = false;
            //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            //watch.Start();

            if (Locked == false)
            {
                int TotalHeight = CalcTotalDrawHeight(false);
                Rectangle rect;
                if (TotalHeight > this.Height)
                {
                    // scrollBarChanged = true;
                    _vScrollBar.Minimum = 0;
                    _vScrollBar.SmallChange = Constants.ITEM_HEIGHT;
                    _vScrollBar.LargeChange = this.Height;
                    _vScrollBar.Maximum = TotalHeight;

                    if (_vScrollBar.Visible == false)
                    {
                        _vScrollBar.Value = 0;
                        _vScrollBar.Visible = true;
                        //_painting = true;
                        //Application.DoEvents();
                        //_painting = false;
                    }

                    RecalcItemPositions();
                    rect = new Rectangle(0, -_vScrollBar.Value, this.Width - _vScrollBar.Width, TotalHeight);
                }
                else
                {
                    _vScrollBar.Visible = false;
                    //_painting = true;
                    //Application.DoEvents();
                    //_painting = false;
                    rect = new Rectangle(0, 0, this.Width, this.Height);
                }

                _draw.Clear(Color.White);

                int NumGroups = AllGroups.Count;
                Group grp = null;

                for (int i = NumGroups - 1; i >= 0; i--)
                {
                    grp = (Group)AllGroups[i];
                    if (rect.Top + grp.Height < this.ClientRectangle.Top)
                    {
                        //update the drawing rectangle
                        rect.Y += grp.Height + Constants.ITEM_PAD;

                        //move on to the next group
                        continue;
                    }
                    DrawGroup(_draw, grp, rect, false);
                    rect.Y += grp.Height + Constants.ITEM_PAD;
                    if (rect.Top >= this.ClientRectangle.Bottom)
                        break;//
                    //rect.Height -= grp.Height + Constants.ITEM_PAD;
                }
            }

            //watch.Stop();
            //MessageBox.Show(watch.Elapsed.ToString());
            SwapBuffers();
        }

        /// <summary>
        /// The Control is being redrawn
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // we don't want to paint when when statusbar visibility changed
            if (_painting)
                return;

            _frontBuffer = e.Graphics;

            //			_frontBuffer.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            //			_frontBuffer.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            DrawNextFrame();
        }

        /// <summary>
        /// the background of the control is to be redrawn
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            //do nothing, this helps us avoid flicker

            //if we don't override this function, then
            //the system will clear that background before
            //we draw, causing a flicker when resizing
        }

        private void HandleLeftMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_DragInfo.Dragging == true || m_DragInfo.MouseDown == true)
            {//someting went wrong and the legend got locked but never got unlocked
                if (m_DragInfo.LegendLocked)
                    this.Unlock();
                m_DragInfo.Reset();
            }

            Group grp = null;
            LegendLayer lyr = null;
            Point pnt = new Point(e.X, e.Y);

            m_DragInfo.Reset();

            //pnt = this.PointToClient(pnt);
            bool InCheckBox = false,
                InExpandBox = false;


            grp = FindClickedGroup(pnt, out InCheckBox, out InExpandBox);
            if (grp != null)
            {
                if (InCheckBox == true)
                {
                    if (!grp.StateLocked)
                    {
                        if (grp.VisibleState == Visibility.AllVisible)
                            grp.VisibleState = Visibility.AllHidden;
                        else
                            grp.VisibleState = Visibility.AllVisible;

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
                else if (InExpandBox == true)
                {
                    grp.Expanded = !grp.Expanded;
                    FireEvent(this, GroupExpandedChanged, new GroupEventArgs(grp.Handle));
                    Redraw();
                    return;
                }
                else
                {
                    //set up group dragging
                    if (AllGroups.Count > 1)
                    {
                        m_DragInfo.StartGroupDrag(pnt.Y, (int)m_GroupPositions[grp.Handle]);
                        //m_DragInfo.StartDrag(pnt.Y,(int)m_GroupPositions[grp.layerHandle],Constants.INVALID_INDEX);
                    }
                }
                FireEvent(this, GroupMouseDown, new GroupMouseEventArgs(grp.Handle, MouseButtons.Left));
                return;
            }

            // -------------------------------------------------------
            //      Selecting a layer
            // -------------------------------------------------------
            ClickedElement element = new ClickedElement();

            lyr = FindClickedLayer(pnt, ref element);
            if (lyr != null)
            {
                grp = (Group)AllGroups[element.GroupIndex];
                if (element.CheckBox)
                {
                    bool NewState = !_map.get_LayerVisible(lyr.Handle);

                    var args = new LayerCancelEventArgs(lyr.Handle, NewState);
                    FireEvent(this, LayerVisibleChanged, args);
                    
                    if (args.Cancel)
                        return;

                    _map.set_LayerVisible(lyr.Handle, NewState);

                    grp = (Group)AllGroups[element.GroupIndex];
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
                    FireEvent(this, LayerColorboxClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }
                
                if (element.LabelsIcon)
                {
                    FireEvent(this, LayerLabelClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }

                if (element.ColorBox == true && element.CategoryIndex != -1)
                {
                    // category symbology
                    FireEvent(this, LayerCategoryClicked, new LayerCategoryEventArgs(lyr.Handle, MouseButtons.Left, element.CategoryIndex));
                    Redraw();
                    return;
                }
                
                if (element.Charts && element.ChartFieldIndex == -1)
                {
                    // default symbology
                    FireEvent(this, LayerChartClicked, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Left));
                    Redraw();
                    return;
                }
                
                if (element.Charts && element.ChartFieldIndex != -1)
                {
                    // category symbology
                    FireEvent(this, LayerChartFieldClicked, new ChartFieldClickedEventArgs(lyr.Handle, MouseButtons.Left, element.ChartFieldIndex));
                    Redraw();
                    return;
                }
                
                SelectedLayer = lyr.Handle;

                if (AllGroups.Count > 1 || grp.Layers.Count > 1)
                {
                    m_DragInfo.StartLayerDrag(pnt.Y, (int)m_GroupPositions[grp.Handle], grp.LayerPositionInGroup(lyr.Handle));
                }

                FireEvent(this, LayerMouseDown, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Left));
                return;
            }

            FireEvent(this, LegendClick, new LegendClickEventArgs(MouseButtons.Left, pnt));

            Redraw();
        }

        private void HandleRightMouseDown(object sender, MouseEventArgs e)
        {
            Group grp = null;
            Layer lyr = null;

            Point pnt = new Point(e.X, e.Y);

            bool InCheckBox = false,
                InExpandBox = false;
            grp = FindClickedGroup(pnt, out InCheckBox, out InExpandBox);
            if (grp != null)
            {
                if (InCheckBox == false && InExpandBox == false)
                {
                    FireEvent(this, GroupMouseDown, new GroupMouseEventArgs(grp.Handle, MouseButtons.Right));
                }
                return;
            }

            ClickedElement element = new ClickedElement();
            lyr = FindClickedLayer(pnt, ref element);
            if (lyr != null)
            {
                if (element.CheckBox == false && element.ExpansionBox == false)
                {
                    FireEvent(this, LayerMouseDown, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Right));
                }
                else if (element.LabelsIcon)
                {
                    FireEvent(this, LayerLabelClicked, new LayerEventArgs(lyr.Handle));
                    Redraw();
                    return;
                }
                return;
            }
            FireEvent(this, LegendClick, new LegendClickEventArgs(MouseButtons.Right, pnt));
        }

        private void HandleRightMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Group grp = null;
            Layer lyr = null;

            Point pnt = new Point(e.X, e.Y);

            bool InCheckBox = false, InExpandBox = false;
            grp = FindClickedGroup(pnt, out InCheckBox, out InExpandBox);
            if (grp != null)
            {
                if (InCheckBox == false && InExpandBox == false)
                {
                    FireEvent(this, GroupMouseUp, new GroupMouseEventArgs(grp.Handle, MouseButtons.Right));
                }
                return;
            }

            ClickedElement element = new ClickedElement();

            lyr = FindClickedLayer(pnt, ref element);
            if (lyr != null)
            {
                if (element.CheckBox == false && element.ExpansionBox == false)
                {
                    FireEvent(this, LayerMouseUp, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Right));
                }
            }
        }

        private void Legend_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    HandleLeftMouseDown(sender, e);
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    HandleRightMouseDown(sender, e);
                    break;
            }
        }

        private void HandleLeftMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Capture = false;
            Point pnt = new Point(e.X, e.Y);

            LegendLayer lyr = null;
            Group grp = null;
            Group TargetGroup = null;

            m_DragInfo.MouseDown = false;

            if (m_DragInfo.Dragging == true)
            {
                if (m_DragInfo.LegendLocked == true)
                {
                    m_DragInfo.LegendLocked = false;
                    Unlock();//unlock the legend
                }

                _midBuffer = null;

                if (m_DragInfo.DraggingLayer)
                {
                    if (m_DragInfo.TargetGroupIndex != Constants.INVALID_INDEX)
                    {
                        TargetGroup = _groupManager[m_DragInfo.TargetGroupIndex];
                        grp = (Group)AllGroups[m_DragInfo.DragGroupIndex];

                        int OldPos = 0,
                            NewPos = 0,
                            LayerHandle = -1,
                            temp = 0;

                        LayerHandle = grp.LayerHandle(m_DragInfo.DragLayerIndex);

                        if (TargetGroup.Handle == grp.Handle)
                        {
                            //movement within the same group

                            FindLayerByHandle(LayerHandle, out temp, out OldPos);

                            //we may have to adjust the new position if moving up in the group
                            //because the way we are using TargetLayerIndex is marking things differently
                            //than the moveLayer function expects it
                            if (OldPos < m_DragInfo.TargetLayerIndex)
                                NewPos = m_DragInfo.TargetLayerIndex - 1;
                            else
                                NewPos = m_DragInfo.TargetLayerIndex;
                        }
                        else
                        {
                            //movement from one group to another group
                            NewPos = m_DragInfo.TargetLayerIndex;
                        }

                        MoveLayer(TargetGroup.Handle, LayerHandle, NewPos);
                    }
                }
                else
                {//we are dragging a group
                    if (IsValidIndex(AllGroups, m_DragInfo.DragGroupIndex) == false)
                    {
                        m_DragInfo.Reset();
                        return;
                    }

                    int grpHandle = ((Group)AllGroups[m_DragInfo.DragGroupIndex]).Handle;

                    //adjust the target group index because we are setting TargetGroupIndex
                    //differently than the MoveGroup Function expects it
                    if (m_DragInfo.DragGroupIndex < m_DragInfo.TargetGroupIndex)
                        m_DragInfo.TargetGroupIndex -= 1;

                    MoveGroup(grpHandle, m_DragInfo.TargetGroupIndex);
                }

                m_DragInfo.Reset();
                Redraw();
            }

            //are we completing a mouseup on a group?
            bool InCheck = false;
            bool InExpansion = false;
            grp = FindClickedGroup(pnt, out InCheck, out InExpansion);
            if (grp != null && InCheck == false && (InExpansion == false || grp.Layers.Count == 0))
            {
                FireEvent(this, GroupMouseUp, new GroupMouseEventArgs(grp.Handle, MouseButtons.Left));
                return;
            }

            InCheck = false;
            InExpansion = false;
            //now figure out if we are completing a mouseup on a layer
            lyr = FindClickedLayer(pnt, out InCheck, out InExpansion);
            if (lyr != null && InCheck == false)
            {
                if (InExpansion == false || lyr.ColorLegend.Count == 0)
                {
                    FireEvent(this, LayerMouseUp, new LayerMouseEventArgs(lyr.Handle, MouseButtons.Left));
                }
            }

            //if no other mouseup event is send, then send the LegendMouseUp
            FireEvent(this, LegendClick, new LegendClickEventArgs(MouseButtons.Left, pnt));
        }

        private bool IsValidIndex<T>(List<T> list, int index)
        {
            if (index >= list.Count)
                return false;
            if (index < 0)
                return false;

            return true;
        }

        private void UpdateMapLayerPositions()
        {
            int GrpCount = AllGroups.Count;
            int LyrCount;
            Layer lyr = null;
            Group grp = null;
            int lyrPosition;

            _map.LockWindow(MapWinGIS.tkLockMode.lmLock);
            for (int i = GrpCount - 1; i >= 0; i--)
            {
                grp = (Group)AllGroups[i];
                LyrCount = grp.Layers.Count;
                for (int j = LyrCount - 1; j >= 0; j--)
                {
                    lyr = (Layer)grp.Layers[j];
                    lyrPosition = _map.get_LayerPosition(lyr.Handle);
                    _map.MoveLayerBottom(lyrPosition);
                }
            }
            _map.LockWindow(MapWinGIS.tkLockMode.lmUnlock);
        }

        private void Legend_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                HandleLeftMouseUp(sender, e);
            if (e.Button == MouseButtons.Right)
                HandleRightMouseUp(sender, e);

            if (m_DragInfo.Dragging == true)
            {
                if (m_DragInfo.LegendLocked)
                    this.Unlock();
                m_DragInfo.Reset();
            }
        }

        private void Legend_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_DragInfo.MouseDown == true && Math.Abs(m_DragInfo.StartY - e.Y) > 10)
            {
                m_DragInfo.Dragging = true;
                if (m_DragInfo.LegendLocked == false)
                {
                    Lock();//lock the LegendControl
                    m_DragInfo.LegendLocked = true;
                }
            }

            if (m_DragInfo.Dragging == true)
            {
                FindDropLocation(e.Y);
                DrawDragLine(m_DragInfo.TargetGroupIndex, m_DragInfo.TargetLayerIndex);
            }
            //			else
            //			{
            //				bool InCheck, InExpand;
            //				//show a tooltip if the mouse is over a layer
            //				Layer lyr = FindClickedLayer(new Point(e.X,e.Y),out InCheck, out InExpand);
            //				if(lyr != null)
            //				{
            //					m_ToolTip.AutoPopDelay = 5000;
            //					m_ToolTip.InitialDelay = 1000;
            //					m_ToolTip.ReshowDelay = 500;
            //					m_ToolTip.ShowAlways = false;
            //
            //					string caption = _map.get_LayerName(lyr.layerHandle);
            //
            //					m_ToolTip.SetToolTip(this,caption);
            //
            //				}
            //			}
        }

        private void DrawDragLine(int GrpIndex, int LyrIndex)
        {
            int DrawY = 0;
            Group grp = null;

            if (m_DragInfo.Dragging)
            {
                if (IsValidIndex(AllGroups, GrpIndex) == true)
                    grp = (Group)AllGroups[GrpIndex];

                if (m_DragInfo.DraggingLayer)
                {
                    if (grp == null)
                        return; //don't draw anything

                    int LayerCount = grp.Layers.Count;

                    if (LyrIndex < 0 && LayerCount > 0)
                    {//the item goes at the bottom of the list
                        DrawY = (grp.Layers[0]).Top + (grp.Layers[0]).Height;
                    }
                    if (LayerCount > LyrIndex && LyrIndex >= 0)
                    {
                        int ItemTop = (grp.Layers[LyrIndex]).Top;
                        DrawY = ItemTop + (grp.Layers[LyrIndex]).Height;
                    }
                    else
                    {//the layer is to be placed at the top of the list
                        DrawY = grp.Top + Constants.ITEM_HEIGHT;
                    }
                }
                else
                {//we are dragging a group
                    if (GrpIndex < 0 || GrpIndex >= (int)AllGroups.Count)
                    {//the mouse is either above the top layer or below the bottom layer
                        if (GrpIndex < 0)
                            DrawY = ((Group)AllGroups[0]).Top + ((Group)AllGroups[0]).Height;
                        else
                            DrawY = ((Group)AllGroups[AllGroups.Count - 1]).Top;
                    }
                    else
                    {
                        //if(grp.Expanded == true)
                        DrawY = grp.Top + grp.Height;//CalcGroupHeight(grp);
                        //else
                        //	DrawY = grp.Top + grp.Height;//CalcGroupHeight(grp);
                    }
                }

                _frontBuffer = this.CreateGraphics();
                if (_midBuffer == null)
                    _midBuffer = new Bitmap(_backBuffer.Width, _backBuffer.Height, _draw);

                Graphics LocalDraw = Graphics.FromImage(_midBuffer);
                SwapBuffers(_backBuffer, LocalDraw);

                Pen pen = (Pen)Pens.Gray.Clone();
                pen.Width = 3;

                //draw a horizontal line
                LocalDraw.DrawLine(pen, Constants.ITEM_PAD, DrawY, this.Width - Constants.ITEM_RIGHT_PAD, DrawY);

                //draw the left vertical line
                LocalDraw.DrawLine(pen, Constants.ITEM_PAD, DrawY - 3, Constants.ITEM_PAD, DrawY + 3);

                //draw the right vertical line
                LocalDraw.DrawLine(pen, this.Width - Constants.ITEM_RIGHT_PAD, DrawY - 3, this.Width - Constants.ITEM_RIGHT_PAD, DrawY + 3);

                SwapBuffers(_midBuffer, _frontBuffer);
            }
        }

        private void FindDropLocation(int YPosition)
        {
            m_DragInfo.TargetGroupIndex = Constants.INVALID_INDEX;
            m_DragInfo.TargetLayerIndex = Constants.INVALID_INDEX;

            int grpCount, itemCount;
            Group grp = null;
            Group TopGroup = null,
                BottomGroup = null,
                TempGroup = null;
            LegendLayer lyr = null;
            int grpHeight;

            grpCount = AllGroups.Count;

            if (grpCount < 1)
                return;

            TopGroup = (Group)AllGroups[grpCount - 1];
            BottomGroup = (Group)AllGroups[0];

            if (m_DragInfo.DraggingLayer == true)
            {
                if (YPosition >= (BottomGroup.Top + BottomGroup.Height))
                {//the mouse is below the bottom layer, mark for drop at bottom
                    m_DragInfo.TargetGroupIndex = 0;
                    m_DragInfo.TargetLayerIndex = 0;

                    return;
                }
                else if (YPosition <= TopGroup.Top)
                {//the mouse is above the top layer, mark for drop at top
                    m_DragInfo.TargetGroupIndex = grpCount - 1;
                    m_DragInfo.TargetLayerIndex = TopGroup.Layers.Count;

                    return;
                }

                //not the bottom or the top, so we must search for the correct one
                for (int i = grpCount - 1; i >= 0; i--)
                {
                    grp = (Group)AllGroups[i];

                    grpHeight = grp.Height;

                    //can we drop it at the top of the group?
                    //if(YPosition <= grp.Top && YPosition < grp.Top+Constants.ITEM_HEIGHT)
                    if (YPosition < grp.Top + Constants.ITEM_HEIGHT)
                    {
                        m_DragInfo.TargetLayerIndex = grp.Layers.Count;
                        m_DragInfo.TargetGroupIndex = i;
                        return;
                    }
                    else
                    {
                        itemCount = grp.Layers.Count;

                        if (itemCount == 0)
                        {
                            //if(YPosition > grp.Top && YPosition <= grp.Top + grpHeight)
                            if (YPosition > grp.Top && YPosition <= grp.Top + Constants.ITEM_HEIGHT)
                            {
                                m_DragInfo.TargetGroupIndex = i;
                                m_DragInfo.TargetLayerIndex = Constants.INVALID_INDEX;
                                return;
                            }
                        }
                        else if (grp.Expanded == true)
                        {
                            for (int j = itemCount - 1; j >= 0; j--)
                            {
                                lyr = grp.Layers[j];
                                if (YPosition <= (lyr.Top + lyr.Height))
                                {
                                    //drop before this item
                                    m_DragInfo.TargetGroupIndex = i;
                                    m_DragInfo.TargetLayerIndex = j;
                                    return;
                                }
                                if (j == 0)
                                {
                                    //if this item is the bottom one, check to see if the item can be
                                    //dropped after this item
                                    if (i > 0)//if the group is not the bottom group
                                    {
                                        TempGroup = (Group)AllGroups[i - 1];
                                        if (YPosition <= TempGroup.Top && YPosition > lyr.Top + lyr.Height)
                                        {
                                            m_DragInfo.TargetGroupIndex = i;
                                            m_DragInfo.TargetLayerIndex = 0;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (YPosition > lyr.Top + lyr.Height)
                                        {
                                            m_DragInfo.TargetGroupIndex = 0;
                                            m_DragInfo.TargetLayerIndex = 0;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {//the group is not expanded
                            if (YPosition > grp.Top && YPosition < grp.Top + grpHeight)
                            {
                                m_DragInfo.TargetGroupIndex = i;
                                m_DragInfo.TargetLayerIndex = grp.Layers.Count;//put the item at the top
                            }
                        }
                    }
                }
            }
            else
            {//we are dragging a group
                if (YPosition > (BottomGroup.Top + BottomGroup.Height))
                {//the mouse is below the bottom layer, mark for drop at bottom
                    m_DragInfo.TargetGroupIndex = Constants.INVALID_INDEX;
                    m_DragInfo.TargetLayerIndex = Constants.INVALID_INDEX;

                    return;
                }
                else if (YPosition <= TopGroup.Top)
                {//the mouse is above the top Group, mark for drop at top
                    m_DragInfo.TargetGroupIndex = grpCount;
                    m_DragInfo.TargetLayerIndex = Constants.INVALID_INDEX;
                    return;
                }

                //we have to compare against all groups because we aren't at the top or bottom
                for (int i = grpCount - 1; i >= 0; i--)
                {
                    grp = (Group)AllGroups[i];

                    if (YPosition < grp.Top + grp.Height)
                    {
                        m_DragInfo.TargetGroupIndex = i;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Handles Layer position changes within groups
        /// </summary>
        /// <param name="Lyr">The Layer being moved</param>
        /// <param name="SourceGroup">The Source group</param>
        /// <param name="DestinationGroup">The Destination group. Can be the same as the Source</param>
        /// <param name="TargetPosition">The target position within a group</param>
        /// <returns></returns>
        private void ChangeLayerPosition(int CurrentPositionInGroup, Group SourceGroup, int TargetPositionInGroup, Group DestinationGroup)
        {
            //Christian Degrassi 2010-03-12: Support method to fix issues 1642
            LegendLayer Lyr = null;

            if (CurrentPositionInGroup < 0 || CurrentPositionInGroup >= SourceGroup.Layers.Count)
                throw new Exception("Invalid Layer Index");

            Lyr = SourceGroup.Layers[CurrentPositionInGroup];
            SourceGroup.Layers.Remove(Lyr);

            if (TargetPositionInGroup >= DestinationGroup.Layers.Count)
                DestinationGroup.Layers.Add(Lyr);
            else if (TargetPositionInGroup <= 0)
                DestinationGroup.Layers.Insert(0, Lyr);
            else
                DestinationGroup.Layers.Insert(TargetPositionInGroup, Lyr);

            SourceGroup.RecalcHeight();
            SourceGroup.UpdateGroupVisibility();

            if (SourceGroup.Handle != DestinationGroup.Handle)
            {
                DestinationGroup.RecalcHeight();
                DestinationGroup.UpdateGroupVisibility();

                _selectedGroupHandle = DestinationGroup.Handle;
            }
        }

        //Christian Degrassi 2010-03-12: Refactored method to fix issues 1642
        /// <summary>
        /// Move a layer to a new location and/or group
        /// </summary>
        /// <param name="TargetGroupHandle">layerHandle of group into which to move the layer</param>
        /// <param name="LayerHandle">layerHandle of layer to move</param>
        /// <param name="NewPos">0-based index into list of layers within target group</param>
        /// <returns>True if Layer position has changed, False otherwise</returns>
        protected internal bool MoveLayer(int TargetGroupHandle, int LayerHandle, int TargetPositionInGroup)
        {
            Group SourceGroup = null;
            Group DestinationGroup = null;
            //Layer Lyr = null;

            int SourceGroupIndex = 0;
            int CurrentPositionInGroup = 0;
            int OldMapPos;
            int NewMapPos;

            bool result = false;

            try
            {
                // TODO: restore
                //if (!m_LayerManager.IsValidHandle(GroupHandle))
                //    throw new Exception("Invalid layerHandle (GroupHandle)");

                if (!IsValidGroup(TargetGroupHandle))
                    throw new Exception("Invalid layerHandle (TargetGroupHandle)");

                FindLayerByHandle(LayerHandle, out SourceGroupIndex, out CurrentPositionInGroup);

                SourceGroup = Groups[SourceGroupIndex];
                DestinationGroup = _groupManager.ItemByHandle(TargetGroupHandle);

                if (CurrentPositionInGroup != TargetPositionInGroup || SourceGroup.Handle != DestinationGroup.Handle)
                {
                    OldMapPos = _map.get_LayerPosition(LayerHandle);

                    ChangeLayerPosition(CurrentPositionInGroup, SourceGroup, TargetPositionInGroup, DestinationGroup);
                    UpdateMapLayerPositions();

                    NewMapPos = _map.get_LayerPosition(LayerHandle);

                    int CurHandle;
                    int CurPos;
                    int EndPos;

                    CurPos = Math.Min(OldMapPos, NewMapPos);
                    EndPos = Math.Max(OldMapPos, NewMapPos);

                    while (CurPos <= EndPos)
                    {
                        CurHandle = _map.get_LayerHandle(CurPos);
                        FireEvent(this, LayerPositionChanged, new PositionChangedEventArgs(CurHandle, OldMapPos, NewMapPos));
                        CurPos += 1;
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
        /// Moves a group to a new location
        /// </summary>
        /// <param name="GroupHandle">layerHandle of group to move</param>
        /// <param name="NewPos">0-Based index of new location</param>
        /// <returns>True on success, False otherwise</returns>
        protected internal bool MoveGroup(int GroupHandle, int NewPos)
        {
            if (IsValidGroup(GroupHandle))
            {
                int OldPos = (int)m_GroupPositions[GroupHandle];

                if (OldPos == NewPos)
                    return true;

                Group grp = _groupManager.ItemByHandle(GroupHandle);

                if (NewPos < 0)
                {
                    NewPos = 0;
                }

                if (NewPos >= NumGroups)
                {
                    AllGroups.RemoveAt(OldPos);
                    AllGroups.Add(grp);
                }
                else
                {
                    AllGroups.RemoveAt(OldPos);
                    AllGroups.Insert(NewPos, grp);
                }

                if (grp.Layers.Count > 0)
                {//now we have to move the layers around
                    UpdateMapLayerPositions();
                }

                UpdateGroupPositions();
                Redraw();

                FireEvent(this, GroupPositionChanged, new PositionChangedEventArgs(grp.Handle, OldPos, NewPos));
                return true;
            }
            
            LegendHelper.LastError = "Invalid Group layerHandle";
            return false;
        }

        private void Legend_DoubleClick(object sender, System.EventArgs e)
        {
            Group grp = null;
            Layer lyr = null;

            Point pnt = Win32Api.GetCursorLocation();
            pnt = this.PointToClient(pnt);

            bool InCheckBox = false, InExpandBox = false;

            grp = FindClickedGroup(pnt, out InCheckBox, out InExpandBox);
            if (grp != null)
            {
                if (InCheckBox == false && InExpandBox == false)
                {
                    FireEvent(this, GroupDoubleClick, new GroupEventArgs(grp.Handle));
                }
                return;
            }

            ClickedElement element = new ClickedElement();

            lyr = FindClickedLayer(pnt, ref element);
            if (lyr != null)
            {
                if (element.CheckBox == false && element.ExpansionBox == false)
                {
                    FireEvent(this, LayerDoubleClick, new LayerEventArgs(lyr.Handle));
                }
            }
        }

        private void DrawTransparentPatch(Graphics DrawTool, int TopPos, int LeftPos, int BoxHeight, int BoxWidth, Color OutlineColor, bool DrawOutline)
        {
            Rectangle rect = new Rectangle(LeftPos, TopPos, BoxWidth, BoxHeight);
            Pen pen = new Pen(OutlineColor);

            //fill the rectangle with a diagonal hatch
            System.Drawing.Brush brush = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.LightUpwardDiagonal, _boxLineColor, Color.White);
            DrawTool.FillRectangle(brush, rect);

            if (DrawOutline) DrawTool.DrawRectangle(pen, LeftPos, TopPos, BoxWidth, BoxHeight);
            //			//draw the Top border
            //			DrawTool.DrawLine(pen,LeftPos,TopPos,LeftPos+BoxWidth,TopPos);
            //
            //			//draw the Left border
            //			DrawTool.DrawLine(pen,LeftPos,TopPos,LeftPos,TopPos+BoxHeight);
            //
            //			//draw the Bottom border
            //			DrawTool.DrawLine(pen,LeftPos,TopPos+BoxHeight,LeftPos+BoxWidth,TopPos+BoxHeight);
            //
            //			//draw the Right border
            //			DrawTool.DrawLine(pen,LeftPos+BoxWidth,TopPos,LeftPos+BoxWidth,TopPos+BoxHeight);
        }

        private void DrawColorPatch(Graphics DrawTool, Color StartColor, Color EndColor, int TopPos, int LeftPos, int BoxHeight, int BoxWidth, Color OutlineColor, bool DrawOutline)
        {
            DrawColorPatch(DrawTool, StartColor, EndColor, TopPos, LeftPos, BoxHeight, BoxWidth, OutlineColor, DrawOutline, LegendLayerType.Invalid);
        }

        private void DrawColorPatch(Graphics DrawTool, Color StartColor, Color EndColor, int TopPos, int LeftPos, int BoxHeight, int BoxWidth, Color OutlineColor, bool DrawOutline, LegendLayerType LayerType)
        {
            // Note - LayerType == invalid when we don't care :)

            if (LayerType == LegendLayerType.LineShapefile)
            {
                if (StartColor.A == 0) StartColor = Color.FromArgb(255, StartColor);
                Pen pen = new Pen(StartColor, 2);

                System.Drawing.Drawing2D.SmoothingMode OldSmoothingMode = DrawTool.SmoothingMode;
                DrawTool.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                DrawTool.DrawLine(pen, LeftPos, TopPos + 8, LeftPos + 4, TopPos + 3);
                DrawTool.DrawLine(pen, LeftPos + 4, TopPos + 3, LeftPos + 9, TopPos + 10);
                DrawTool.DrawLine(pen, LeftPos + 9, TopPos + 10, LeftPos + 13, TopPos + 4);

                DrawTool.SmoothingMode = OldSmoothingMode;
            }
            else
            {
                Rectangle rect = new Rectangle(LeftPos, TopPos, BoxWidth, BoxHeight);
                Pen pen = new Pen(OutlineColor);

                //fill the rectangle with a gradient fill
                System.Drawing.Brush brush = new System.Drawing.Drawing2D.LinearGradientBrush(rect, StartColor, EndColor, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                DrawTool.FillRectangle(brush, rect);

                if (DrawOutline) DrawTool.DrawRectangle(pen, LeftPos, TopPos, BoxWidth, BoxHeight);
            }
        }

        private void vScrollBar_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            VScrollBar sbar = (VScrollBar)sender;
            sbar.Value = e.NewValue;
            Redraw();
        }

        /// <summary>
        /// handles mouse wheel event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e)
        {
            if (_vScrollBar.Visible == true)
            {
                int StepSize;
                int MaxSize = _vScrollBar.Maximum - this.Height;

                StepSize = _vScrollBar.SmallChange;
                if (e.Delta >= 0)
                    StepSize *= -1;

                if (_vScrollBar.Value + StepSize < 0)
                {
                    _vScrollBar.Value = 0;
                }
                else if (_vScrollBar.Value + StepSize > MaxSize)
                {
                    _vScrollBar.Value = MaxSize + 1;
                }
                else
                {
                    _vScrollBar.Value += StepSize;
                }
                Redraw();
            }
        }
    }
}