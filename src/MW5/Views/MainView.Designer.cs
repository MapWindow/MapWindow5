using MW5.Api;
using MW5.Api.Concrete;

namespace MW5.Views
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            MW5.Api.Concrete.Envelope envelope2 = new MW5.Api.Concrete.Envelope();
            MW5.Api.Concrete.SpatialReference spatialReference2 = new MW5.Api.Concrete.SpatialReference();
            this._dockingManager1 = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.statusStripEx1 = new Syncfusion.Windows.Forms.Tools.StatusStripEx();
            this.statusTileProvider = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusProjection = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusStripLabel4 = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusMapUnits = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusStripLabel5 = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusCoordinates = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.parentBarItem3 = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.treeViewAdv2 = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            this.dockingClientPanel1 = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            this._mapControlControl1 = new MW5.Api.MapControl();
            this._mainFrameBarManager1 = new Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager(this);
            this._mainMenu = new Syncfusion.Windows.Forms.Tools.XPMenus.Bar(this._mainFrameBarManager1, "MainMenu");
            this.mnuFile = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.barItem1 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.mnuTiles = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.mnuPlugins = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.mnuHelp = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this._toolbarProject = new Syncfusion.Windows.Forms.Tools.XPMenus.Bar(this._mainFrameBarManager1, "MainToolbar");
            this.mnuOpenProject = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.mnuSaveProject = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.mnuSaveProjectAs = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.barItem6 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.mnuOpenVector = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.mnuOpenRaster = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.toolOpenDatabase = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.toolCreateLayer = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.toolRemoveLayer = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this._toolbarMap = new Syncfusion.Windows.Forms.Tools.XPMenus.Bar(this._mainFrameBarManager1, "MapToolbar");
            this.toolZoomIn = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.toolZoomOut = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.toolZoomToMax = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.toolZoomToLayer = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.toolPan = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.barItem2 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this._imageListAdv1 = new Syncfusion.Windows.Forms.Tools.ImageListAdv(this.components);
            this._legendControl1 = new MW5.Api.Legend.LegendControl();
            ((System.ComponentModel.ISupportInitialize)(this._dockingManager1)).BeginInit();
            this.statusStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewAdv2)).BeginInit();
            this.dockingClientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainFrameBarManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // _dockingManager1
            // 
            this._dockingManager1.ActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this._dockingManager1.DockBehavior = Syncfusion.Windows.Forms.Tools.DockBehavior.VS2010;
            this._dockingManager1.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("_dockingManager1.DockLayoutStream")));
            this._dockingManager1.DockTabAlignment = Syncfusion.Windows.Forms.Tools.DockTabAlignmentStyle.Left;
            this._dockingManager1.HostControl = this;
            this._dockingManager1.InActiveCaptionBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212))))));
            this._dockingManager1.InActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this._dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._dockingManager1.MetroCaptionColor = System.Drawing.Color.White;
            this._dockingManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(159)))), ((int)(((byte)(183)))));
            this._dockingManager1.ReduceFlickeringInRtl = false;
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"));
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"));
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"));
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"));
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"));
            // 
            // statusStripEx1
            // 
            this.statusStripEx1.AutoSize = false;
            this.statusStripEx1.BeforeTouchSize = new System.Drawing.Size(796, 22);
            this.statusStripEx1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Bottom;
            this.statusStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTileProvider,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.statusProgress,
            this.statusProjection,
            this.statusStripLabel4,
            this.statusMapUnits,
            this.statusStripLabel5,
            this.statusCoordinates});
            this.statusStripEx1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStripEx1.Location = new System.Drawing.Point(0, 509);
            this.statusStripEx1.MetroColor = System.Drawing.Color.Empty;
            this.statusStripEx1.Name = "statusStripEx1";
            this.statusStripEx1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStripEx1.Size = new System.Drawing.Size(796, 22);
            this.statusStripEx1.TabIndex = 1;
            this.statusStripEx1.Text = "statusStripEx1";
            this.statusStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.StatusStripExStyle.Metro;
            // 
            // statusTileProvider
            // 
            this.statusTileProvider.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusTileProvider.Name = "statusTileProvider";
            this.statusTileProvider.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.statusTileProvider.Size = new System.Drawing.Size(87, 19);
            this.statusTileProvider.Text = "Tile provider";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(52, 15);
            this.toolStripStatusLabel3.Text = "Progress";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 0);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // statusProgress
            // 
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(100, 15);
            // 
            // statusProjection
            // 
            this.statusProjection.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusProjection.Name = "statusProjection";
            this.statusProjection.Size = new System.Drawing.Size(87, 15);
            this.statusProjection.Text = "ProjectionType";
            // 
            // statusStripLabel4
            // 
            this.statusStripLabel4.EndOfGroup = true;
            this.statusStripLabel4.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusStripLabel4.Name = "statusStripLabel4";
            this.statusStripLabel4.Size = new System.Drawing.Size(10, 15);
            this.statusStripLabel4.Text = "|";
            // 
            // statusMapUnits
            // 
            this.statusMapUnits.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusMapUnits.Name = "statusMapUnits";
            this.statusMapUnits.Size = new System.Drawing.Size(61, 15);
            this.statusMapUnits.Text = "Map Units";
            // 
            // statusStripLabel5
            // 
            this.statusStripLabel5.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusStripLabel5.Name = "statusStripLabel5";
            this.statusStripLabel5.Size = new System.Drawing.Size(10, 15);
            this.statusStripLabel5.Text = "|";
            // 
            // statusCoordinates
            // 
            this.statusCoordinates.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusCoordinates.Name = "statusCoordinates";
            this.statusCoordinates.Size = new System.Drawing.Size(71, 15);
            this.statusCoordinates.Text = "Coordinates";
            // 
            // parentBarItem3
            // 
            this.parentBarItem3.BarName = "parentBarItem3";
            this.parentBarItem3.CategoryIndex = 1;
            this.parentBarItem3.ID = "Trial";
            this.parentBarItem3.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.parentBarItem3.ShowToolTipInPopUp = false;
            this.parentBarItem3.SizeToFit = true;
            this.parentBarItem3.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.parentBarItem3.Text = "Trial";
            this.parentBarItem3.WrapLength = 20;
            // 
            // treeViewAdv2
            // 
            this.treeViewAdv2.BeforeTouchSize = new System.Drawing.Size(152, 87);
            this.treeViewAdv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAdv2.CanSelectDisabledNode = false;
            // 
            // 
            // 
            this.treeViewAdv2.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAdv2.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewAdv2.HelpTextControl.Name = "helpText";
            this.treeViewAdv2.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.treeViewAdv2.HelpTextControl.TabIndex = 0;
            this.treeViewAdv2.HelpTextControl.Text = "help text";
            this.treeViewAdv2.Location = new System.Drawing.Point(85, 351);
            this.treeViewAdv2.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.treeViewAdv2.Name = "treeViewAdv2";
            this.treeViewAdv2.ShowFocusRect = true;
            this.treeViewAdv2.Size = new System.Drawing.Size(152, 87);
            this.treeViewAdv2.TabIndex = 3;
            this.treeViewAdv2.Text = "treeViewAdv2";
            // 
            // 
            // 
            this.treeViewAdv2.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.treeViewAdv2.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAdv2.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewAdv2.ToolTipControl.Name = "toolTip";
            this.treeViewAdv2.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.treeViewAdv2.ToolTipControl.TabIndex = 1;
            this.treeViewAdv2.ToolTipControl.Text = "toolTip";
            // 
            // dockingClientPanel1
            // 
            this.dockingClientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dockingClientPanel1.Controls.Add(this._mapControlControl1);
            this.dockingClientPanel1.Location = new System.Drawing.Point(366, 179);
            this.dockingClientPanel1.Name = "dockingClientPanel1";
            this.dockingClientPanel1.Size = new System.Drawing.Size(366, 294);
            this.dockingClientPanel1.TabIndex = 4;
            // 
            // _mapControlControl1
            // 
            this._mapControlControl1.AnimationOnZooming = MW5.Api.AutoToggle.Auto;
            this._mapControlControl1.CurrentScale = 16.918010798186259D;
            this._mapControlControl1.CurrentZoom = -1;
            this._mapControlControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mapControlControl1.ExtentHistory = 20;
            this._mapControlControl1.ExtentPad = 0.02D;
            envelope2.Tag = "";
            this._mapControlControl1.Extents = envelope2;
            spatialReference2.Tag = "";
            this._mapControlControl1.GeoProjection = spatialReference2;
            this._mapControlControl1.GrabProjectionFromData = true;
            this._mapControlControl1.InertiaOnPanning = MW5.Api.AutoToggle.Auto;
            this._mapControlControl1.KnownExtents = MW5.Api.KnownExtents.None;
            this._mapControlControl1.Latitude = 0F;
            this._mapControlControl1.Legend = null;
            this._mapControlControl1.Location = new System.Drawing.Point(0, 0);
            this._mapControlControl1.Longitude = 0F;
            this._mapControlControl1.MapCursor = MW5.Api.MapCursor.ZoomIn;
            this._mapControlControl1.MapUnits = MW5.Api.UnitsOfMeasure.Meters;
            this._mapControlControl1.MouseWheelSpeed = 0.5D;
            this._mapControlControl1.Name = "_mapControlControl1";
            this._mapControlControl1.Projection = MW5.Api.MapProjection.None;
            this._mapControlControl1.ResizeBehavior = MW5.Api.ResizeBehavior.Classic;
            this._mapControlControl1.ReuseTileBuffer = true;
            this._mapControlControl1.ScalebarUnits = MW5.Api.ScalebarUnits.GoogleStyle;
            this._mapControlControl1.ScalebarVisible = true;
            this._mapControlControl1.ShowCoordinates = MW5.Api.CoordinatesDisplay.Auto;
            this._mapControlControl1.ShowRedrawTime = false;
            this._mapControlControl1.ShowVersionNumber = false;
            this._mapControlControl1.Size = new System.Drawing.Size(366, 294);
            this._mapControlControl1.SystemCursor = MW5.Api.SystemCursor.MapDefault;
            this._mapControlControl1.TabIndex = 0;
            this._mapControlControl1.Tag = "";
            this._mapControlControl1.TileProvider = MW5.Api.TileProvider.OpenStreetMap;
            this._mapControlControl1.UdCursorHandle = 0;
            this._mapControlControl1.UseSeamlessPan = false;
            this._mapControlControl1.ZoomBehavior = MW5.Api.ZoomBehavior.UseTileLevels;
            this._mapControlControl1.ZoomPercent = 0.3D;
            // 
            // _mainFrameBarManager1
            // 
            this._mainFrameBarManager1.AutoScale = true;
            this._mainFrameBarManager1.BarPositionInfo = ((System.IO.MemoryStream)(resources.GetObject("_mainFrameBarManager1.BarPositionInfo")));
            this._mainFrameBarManager1.Bars.Add(this._mainMenu);
            this._mainFrameBarManager1.Bars.Add(this._toolbarProject);
            this._mainFrameBarManager1.Bars.Add(this._toolbarMap);
            this._mainFrameBarManager1.Categories.Add("FileToolbar");
            this._mainFrameBarManager1.Categories.Add("Tools");
            this._mainFrameBarManager1.Categories.Add("Menu");
            this._mainFrameBarManager1.Categories.Add("FileMenu");
            this._mainFrameBarManager1.CurrentBaseFormType = "System.Windows.Forms.Form";
            this._mainFrameBarManager1.EnableMenuMerge = true;
            this._mainFrameBarManager1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._mainFrameBarManager1.Form = this;
            this._mainFrameBarManager1.ImageListAdv = this._imageListAdv1;
            this._mainFrameBarManager1.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.mnuFile,
            this.mnuTiles,
            this.mnuOpenVector,
            this.mnuPlugins,
            this.mnuOpenRaster,
            this.mnuHelp,
            this.mnuSaveProject,
            this.mnuSaveProjectAs,
            this.mnuOpenProject,
            this.toolOpenDatabase,
            this.toolCreateLayer,
            this.toolRemoveLayer,
            this.toolZoomIn,
            this.toolZoomOut,
            this.toolZoomToMax,
            this.toolZoomToLayer,
            this.toolPan,
            this.barItem1,
            this.barItem6,
            this.barItem2});
            this._mainFrameBarManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this._mainFrameBarManager1.ResetCustomization = false;
            this._mainFrameBarManager1.UseBackwardCompatiblity = false;
            // 
            // _mainMenu
            // 
            this._mainMenu.AllowCustomizing = false;
            this._mainMenu.AllowItemsReorderOnShrunk = false;
            this._mainMenu.AllowResizing = false;
            this._mainMenu.BarName = "MainMenu";
            this._mainMenu.BarStyle = ((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle)((((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.IsMainMenu | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.RotateWhenVertical) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.Visible) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.UseWholeRow)));
            this._mainMenu.Caption = "Main Menu";
            this._mainMenu.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.mnuFile,
            this.mnuTiles,
            this.mnuPlugins,
            this.mnuHelp});
            this._mainMenu.Manager = this._mainFrameBarManager1;
            // 
            // mnuFile
            // 
            this.mnuFile.BarName = "mnuFile";
            this.mnuFile.CategoryIndex = 2;
            this.mnuFile.ID = "File";
            this.mnuFile.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.barItem1});
            this.mnuFile.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.mnuFile.ShowToolTipInPopUp = false;
            this.mnuFile.SizeToFit = true;
            this.mnuFile.Style = Syncfusion.Windows.Forms.VisualStyle.OfficeXP;
            this.mnuFile.Text = "File";
            this.mnuFile.WrapLength = 20;
            // 
            // barItem1
            // 
            this.barItem1.BarName = "barItem1";
            this.barItem1.CategoryIndex = 3;
            this.barItem1.CustomTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.barItem1.ID = "mnuOpen";
            this.barItem1.ImageSize = new System.Drawing.Size(32, 32);
            this.barItem1.Padding = new System.Drawing.Point(15, 15);
            this.barItem1.ShowToolTipInPopUp = false;
            this.barItem1.SizeToFit = true;
            this.barItem1.Text = "Open";
            // 
            // mnuTiles
            // 
            this.mnuTiles.BarName = "mnuTiles";
            this.mnuTiles.CategoryIndex = 2;
            this.mnuTiles.ID = "tiles";
            this.mnuTiles.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.mnuTiles.ShowToolTipInPopUp = false;
            this.mnuTiles.SizeToFit = true;
            this.mnuTiles.Style = Syncfusion.Windows.Forms.VisualStyle.OfficeXP;
            this.mnuTiles.Text = "Tiles";
            this.mnuTiles.WrapLength = 20;
            // 
            // mnuPlugins
            // 
            this.mnuPlugins.BarName = "mnuPlugins";
            this.mnuPlugins.CategoryIndex = 2;
            this.mnuPlugins.ID = "plugins";
            this.mnuPlugins.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.mnuPlugins.ShowToolTipInPopUp = false;
            this.mnuPlugins.SizeToFit = true;
            this.mnuPlugins.Style = Syncfusion.Windows.Forms.VisualStyle.OfficeXP;
            this.mnuPlugins.Text = "Plugins";
            this.mnuPlugins.WrapLength = 20;
            // 
            // mnuHelp
            // 
            this.mnuHelp.BarName = "mnuHelp";
            this.mnuHelp.CategoryIndex = 2;
            this.mnuHelp.ID = "Help";
            this.mnuHelp.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.mnuHelp.ShowToolTipInPopUp = false;
            this.mnuHelp.SizeToFit = true;
            this.mnuHelp.Style = Syncfusion.Windows.Forms.VisualStyle.OfficeXP;
            this.mnuHelp.Text = "Help";
            this.mnuHelp.WrapLength = 20;
            // 
            // _toolbarProject
            // 
            this._toolbarProject.BarName = "MainToolbar";
            this._toolbarProject.BarStyle = ((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle)((((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.AllowQuickCustomizing | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.RotateWhenVertical) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.Visible) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.DrawDragBorder)));
            this._toolbarProject.Caption = "Project";
            this._toolbarProject.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.mnuOpenProject,
            this.mnuSaveProject,
            this.mnuSaveProjectAs,
            this.barItem6,
            this.mnuOpenVector,
            this.mnuOpenRaster,
            this.toolOpenDatabase,
            this.toolCreateLayer,
            this.toolRemoveLayer});
            this._toolbarProject.Manager = this._mainFrameBarManager1;
            this._toolbarProject.SeparatorIndices.AddRange(new int[] {
            3,
            7});
            // 
            // mnuOpenProject
            // 
            this.mnuOpenProject.BarName = "mnuOpenProject";
            this.mnuOpenProject.CategoryIndex = 0;
            this.mnuOpenProject.ID = "Open Project";
            this.mnuOpenProject.ImageIndex = 4;
            this.mnuOpenProject.Padding = new System.Drawing.Point(10, 5);
            this.mnuOpenProject.ShowToolTipInPopUp = false;
            this.mnuOpenProject.SizeToFit = true;
            this.mnuOpenProject.Text = "Open Project";
            // 
            // mnuSaveProject
            // 
            this.mnuSaveProject.BarName = "mnuSaveProject";
            this.mnuSaveProject.CategoryIndex = 0;
            this.mnuSaveProject.ID = "mnuSaveProject";
            this.mnuSaveProject.ImageIndex = 22;
            this.mnuSaveProject.Padding = new System.Drawing.Point(10, 5);
            this.mnuSaveProject.ShowToolTipInPopUp = false;
            this.mnuSaveProject.SizeToFit = true;
            this.mnuSaveProject.Text = "Save Project";
            // 
            // mnuSaveProjectAs
            // 
            this.mnuSaveProjectAs.BarName = "mnuSaveProjectAs";
            this.mnuSaveProjectAs.CategoryIndex = 0;
            this.mnuSaveProjectAs.ID = "Save Project As";
            this.mnuSaveProjectAs.ImageIndex = 24;
            this.mnuSaveProjectAs.Padding = new System.Drawing.Point(10, 5);
            this.mnuSaveProjectAs.ShowToolTipInPopUp = false;
            this.mnuSaveProjectAs.SizeToFit = true;
            this.mnuSaveProjectAs.Text = "Save Project As";
            // 
            // barItem6
            // 
            this.barItem6.BarName = "barItem6";
            this.barItem6.CategoryIndex = 0;
            this.barItem6.ID = "Open";
            this.barItem6.ImageIndex = 6;
            this.barItem6.ShowToolTipInPopUp = false;
            this.barItem6.SizeToFit = true;
            this.barItem6.Text = "Open";
            // 
            // mnuOpenVector
            // 
            this.mnuOpenVector.BarName = "mnuOpenVector";
            this.mnuOpenVector.CategoryIndex = 0;
            this.mnuOpenVector.ID = "toolOpenVector";
            this.mnuOpenVector.ImageIndex = 14;
            this.mnuOpenVector.Padding = new System.Drawing.Point(10, 5);
            this.mnuOpenVector.ShowToolTipInPopUp = false;
            this.mnuOpenVector.SizeToFit = true;
            this.mnuOpenVector.Text = "Open Vector";
            // 
            // mnuOpenRaster
            // 
            this.mnuOpenRaster.BarName = "mnuOpenRaster";
            this.mnuOpenRaster.CategoryIndex = 0;
            this.mnuOpenRaster.ID = "toolOpenRaster";
            this.mnuOpenRaster.ImageIndex = 11;
            this.mnuOpenRaster.Padding = new System.Drawing.Point(10, 5);
            this.mnuOpenRaster.ShowToolTipInPopUp = false;
            this.mnuOpenRaster.SizeToFit = true;
            this.mnuOpenRaster.Text = "Open Raster";
            // 
            // toolOpenDatabase
            // 
            this.toolOpenDatabase.BarName = "toolOpenDatabase";
            this.toolOpenDatabase.CategoryIndex = 0;
            this.toolOpenDatabase.ID = "Open PostGIS layer";
            this.toolOpenDatabase.ImageIndex = 13;
            this.toolOpenDatabase.Padding = new System.Drawing.Point(10, 5);
            this.toolOpenDatabase.ShowToolTipInPopUp = false;
            this.toolOpenDatabase.SizeToFit = true;
            this.toolOpenDatabase.Text = "Open database layer";
            // 
            // toolCreateLayer
            // 
            this.toolCreateLayer.BarName = "toolCreateLayer";
            this.toolCreateLayer.CategoryIndex = 0;
            this.toolCreateLayer.ID = "Create Layer";
            this.toolCreateLayer.ImageIndex = 7;
            this.toolCreateLayer.Padding = new System.Drawing.Point(10, 5);
            this.toolCreateLayer.ShowToolTipInPopUp = false;
            this.toolCreateLayer.SizeToFit = true;
            this.toolCreateLayer.Text = "Create Layer";
            // 
            // toolRemoveLayer
            // 
            this.toolRemoveLayer.BarName = "toolRemoveLayer";
            this.toolRemoveLayer.CategoryIndex = 0;
            this.toolRemoveLayer.ID = "toolRemoveLayer";
            this.toolRemoveLayer.ImageIndex = 12;
            this.toolRemoveLayer.Padding = new System.Drawing.Point(10, 5);
            this.toolRemoveLayer.ShowToolTipInPopUp = false;
            this.toolRemoveLayer.SizeToFit = true;
            this.toolRemoveLayer.Text = "Remove Layer";
            // 
            // _toolbarMap
            // 
            this._toolbarMap.BarName = "MapToolbar";
            this._toolbarMap.BarStyle = ((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle)((((Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.AllowQuickCustomizing | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.RotateWhenVertical) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.Visible) 
            | Syncfusion.Windows.Forms.Tools.XPMenus.BarStyle.DrawDragBorder)));
            this._toolbarMap.Caption = "Tools";
            this._toolbarMap.Items.AddRange(new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem[] {
            this.toolZoomIn,
            this.toolZoomOut,
            this.toolZoomToMax,
            this.toolZoomToLayer,
            this.toolPan,
            this.barItem2});
            this._toolbarMap.Manager = this._mainFrameBarManager1;
            this._toolbarMap.SeparatorIndices.AddRange(new int[] {
            5});
            // 
            // toolZoomIn
            // 
            this.toolZoomIn.BarName = "toolZoomIn";
            this.toolZoomIn.CategoryIndex = 1;
            this.toolZoomIn.ID = "ZoomIn";
            this.toolZoomIn.ImageIndex = 32;
            this.toolZoomIn.Padding = new System.Drawing.Point(10, 5);
            this.toolZoomIn.ShowToolTipInPopUp = false;
            this.toolZoomIn.SizeToFit = true;
            this.toolZoomIn.Text = "Zoom In";
            // 
            // toolZoomOut
            // 
            this.toolZoomOut.BarName = "toolZoomOut";
            this.toolZoomOut.CategoryIndex = 1;
            this.toolZoomOut.ID = "ZoomOut";
            this.toolZoomOut.ImageIndex = 34;
            this.toolZoomOut.Padding = new System.Drawing.Point(10, 5);
            this.toolZoomOut.ShowToolTipInPopUp = false;
            this.toolZoomOut.SizeToFit = true;
            this.toolZoomOut.Text = "Zoom Out";
            // 
            // toolZoomToMax
            // 
            this.toolZoomToMax.BarName = "toolZoomToMax";
            this.toolZoomToMax.CategoryIndex = 1;
            this.toolZoomToMax.ID = "ZoomMax";
            this.toolZoomToMax.ImageIndex = 31;
            this.toolZoomToMax.Padding = new System.Drawing.Point(10, 5);
            this.toolZoomToMax.ShowToolTipInPopUp = false;
            this.toolZoomToMax.SizeToFit = true;
            this.toolZoomToMax.Text = "Zoom to Max";
            // 
            // toolZoomToLayer
            // 
            this.toolZoomToLayer.BarName = "toolZoomToLayer";
            this.toolZoomToLayer.CategoryIndex = 1;
            this.toolZoomToLayer.ID = "toolZoomToLayer";
            this.toolZoomToLayer.ImageIndex = 33;
            this.toolZoomToLayer.Padding = new System.Drawing.Point(10, 5);
            this.toolZoomToLayer.ShowToolTipInPopUp = false;
            this.toolZoomToLayer.SizeToFit = true;
            this.toolZoomToLayer.Text = "Zoom to Layer";
            // 
            // toolPan
            // 
            this.toolPan.BarName = "toolPan";
            this.toolPan.CategoryIndex = 1;
            this.toolPan.ID = "Pan";
            this.toolPan.ImageIndex = 20;
            this.toolPan.Padding = new System.Drawing.Point(10, 5);
            this.toolPan.ShowToolTipInPopUp = false;
            this.toolPan.SizeToFit = true;
            this.toolPan.Text = "Pan";
            // 
            // barItem2
            // 
            this.barItem2.BarName = "barItem2";
            this.barItem2.CategoryIndex = 1;
            this.barItem2.ID = "toolSetProjection";
            this.barItem2.ImageIndex = 2;
            this.barItem2.ShowToolTipInPopUp = false;
            this.barItem2.SizeToFit = true;
            this.barItem2.Text = "Set projection";
            // 
            // _imageListAdv1
            // 
            this._imageListAdv1.Images.AddRange(new System.Drawing.Image[] {
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images1"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images2"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images3"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images4"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images5"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images6"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images7"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images8"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images9"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images10"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images11"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images12"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images13"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images14"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images15"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images16"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images17"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images18"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images19"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images20"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images21"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images22"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images23"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images24"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images25"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images26"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images27"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images28"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images29"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images30"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images31"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images32"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images33"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images34"))),
            ((System.Drawing.Image)(resources.GetObject("_imageListAdv1.Images35")))});
            this._imageListAdv1.ImageSize = new System.Drawing.Size(24, 24);
            // 
            // _legendControl1
            // 
            this._legendControl1.BackColor = System.Drawing.Color.White;
            this._legendControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._legendControl1.Location = new System.Drawing.Point(106, 174);
            this._legendControl1.Name = "_legendControl1";
            this._legendControl1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._legendControl1.ShowGroupIcons = true;
            this._legendControl1.ShowLabels = false;
            this._legendControl1.Size = new System.Drawing.Size(107, 126);
            this._legendControl1.TabIndex = 5;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(796, 531);
            this.Controls.Add(this._legendControl1);
            this.Controls.Add(this.dockingClientPanel1);
            this.Controls.Add(this.treeViewAdv2);
            this.Controls.Add(this.statusStripEx1);
            this.Name = "MainView";
            this.Text = "MapWindow 5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._dockingManager1)).EndInit();
            this.statusStripEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewAdv2)).EndInit();
            this.dockingClientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainFrameBarManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.StatusStripEx statusStripEx1;
        private System.Windows.Forms.ToolStripStatusLabel statusTileProvider;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusProjection;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripLabel4;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusMapUnits;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripLabel5;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusCoordinates;
        private Syncfusion.Windows.Forms.Tools.DockingManager _dockingManager1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem parentBarItem3;
        private Syncfusion.Windows.Forms.Tools.DockingClientPanel dockingClientPanel1;
        private MapControl _mapControlControl1;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv treeViewAdv2;
        private Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager _mainFrameBarManager1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.Bar _mainMenu;
        private Syncfusion.Windows.Forms.Tools.XPMenus.Bar _toolbarProject;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem mnuOpenVector;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem mnuOpenRaster;
        private Syncfusion.Windows.Forms.Tools.ImageListAdv _imageListAdv1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem mnuOpenProject;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem mnuSaveProject;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem mnuSaveProjectAs;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem toolOpenDatabase;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem toolCreateLayer;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem toolRemoveLayer;
        private Syncfusion.Windows.Forms.Tools.XPMenus.Bar _toolbarMap;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem toolZoomIn;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem toolZoomOut;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem toolZoomToMax;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem toolZoomToLayer;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem toolPan;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem mnuFile;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem mnuTiles;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem mnuPlugins;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem mnuHelp;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem6;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem2;
        private Api.Legend.LegendControl _legendControl1;

    }
}