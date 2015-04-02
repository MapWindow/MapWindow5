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
            MW5.Api.Concrete.Envelope envelope1 = new MW5.Api.Concrete.Envelope();
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            this._dockingManager1 = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStripEx1 = new Syncfusion.Windows.Forms.Tools.StatusStripEx();
            this.statusTileProvider = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusProjectionDropDown = new Syncfusion.Windows.Forms.Tools.StatusStripDropDownButton();
            this.toolChooseProjection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolProjectionProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.statusSelected = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.parentBarItem3 = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.treeViewAdv2 = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            this.dockingClientPanel1 = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            this._mapControl1 = new MW5.Api.BoundMapControl();
            this._mainFrameBarManager1 = new Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager(this);
            this._legendControl1 = new MW5.Api.Legend.LegendControl(this.components);
            this.statusStripLabel5 = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusMapUnits = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
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
            this._dockingManager1.DragProviderStyle = Syncfusion.Windows.Forms.Tools.DragProviderStyle.VS2010;
            this._dockingManager1.HostControl = this;
            this._dockingManager1.ImageList = this.imageList1;
            this._dockingManager1.InActiveCaptionBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212))))));
            this._dockingManager1.InActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this._dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._dockingManager1.MetroCaptionColor = System.Drawing.Color.White;
            this._dockingManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(159)))), ((int)(((byte)(183)))));
            this._dockingManager1.ReduceFlickeringInRtl = false;
            this._dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2010;
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"));
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"));
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"));
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"));
            this._dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"));
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_edit_copy.png");
            this.imageList1.Images.SetKeyName(1, "icon_edit_cut.png");
            // 
            // statusStripEx1
            // 
            this.statusStripEx1.AutoSize = false;
            this.statusStripEx1.BeforeTouchSize = new System.Drawing.Size(796, 29);
            this.statusStripEx1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Bottom;
            this.statusStripEx1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusTileProvider,
            this.statusProgressMessage,
            this.toolStripStatusLabel4,
            this.statusProgressBar,
            this.statusProjectionDropDown,
            this.statusSelected});
            this.statusStripEx1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStripEx1.Location = new System.Drawing.Point(0, 502);
            this.statusStripEx1.MetroColor = System.Drawing.Color.Empty;
            this.statusStripEx1.Name = "statusStripEx1";
            this.statusStripEx1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStripEx1.Size = new System.Drawing.Size(796, 29);
            this.statusStripEx1.TabIndex = 1;
            this.statusStripEx1.Text = "|";
            // 
            // statusTileProvider
            // 
            this.statusTileProvider.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusTileProvider.Name = "statusTileProvider";
            this.statusTileProvider.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.statusTileProvider.Size = new System.Drawing.Size(87, 19);
            this.statusTileProvider.Spring = true;
            this.statusTileProvider.Text = "Tile provider";
            // 
            // statusProgressMessage
            // 
            this.statusProgressMessage.Name = "statusProgressMessage";
            this.statusProgressMessage.Size = new System.Drawing.Size(52, 15);
            this.statusProgressMessage.Text = "Progress";
            this.statusProgressMessage.Visible = false;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 0);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Enabled = false;
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(100, 15);
            this.statusProgressBar.Visible = false;
            // 
            // statusProjectionDropDown
            // 
            this.statusProjectionDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolChooseProjection,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem5,
            this.toolStripMenuItem4,
            this.toolStripSeparator2,
            this.toolProjectionProperties});
            this.statusProjectionDropDown.EndOfGroup = true;
            this.statusProjectionDropDown.Image = global::MW5.Properties.Resources.icon_crs_change;
            this.statusProjectionDropDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusProjectionDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.statusProjectionDropDown.Name = "statusProjectionDropDown";
            this.statusProjectionDropDown.Size = new System.Drawing.Size(107, 28);
            this.statusProjectionDropDown.Text = "Not defined";
            // 
            // toolChooseProjection
            // 
            this.toolChooseProjection.Name = "toolChooseProjection";
            this.toolChooseProjection.Size = new System.Drawing.Size(181, 22);
            this.toolChooseProjection.Text = "Choose projection";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem2.Text = "Absense behavior";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem7.Text = "Assign from project";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem8.Text = "Ignore the absense";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem9.Text = "Slip the file";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem3.Text = "Mismatch behavior";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem10.Text = "Ignore mismatch";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem11.Text = "Reproject the file";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem12.Text = "Skip the file";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Checked = true;
            this.toolStripMenuItem5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem5.Text = "Show loading report";
            this.toolStripMenuItem5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Checked = true;
            this.toolStripMenuItem4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem4.Text = "Show warnings";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // toolProjectionProperties
            // 
            this.toolProjectionProperties.Name = "toolProjectionProperties";
            this.toolProjectionProperties.Size = new System.Drawing.Size(181, 22);
            this.toolProjectionProperties.Text = "Properties";
            // 
            // statusSelected
            // 
            this.statusSelected.EndOfGroup = true;
            this.statusSelected.Margin = new System.Windows.Forms.Padding(10);
            this.statusSelected.Name = "statusSelected";
            this.statusSelected.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.statusSelected.Size = new System.Drawing.Size(67, 15);
            this.statusSelected.Text = "Selected: ";
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
            this.dockingClientPanel1.BackColor = System.Drawing.Color.White;
            this.dockingClientPanel1.Controls.Add(this._mapControl1);
            this.dockingClientPanel1.Location = new System.Drawing.Point(366, 179);
            this.dockingClientPanel1.Name = "dockingClientPanel1";
            this.dockingClientPanel1.Size = new System.Drawing.Size(366, 294);
            this.dockingClientPanel1.TabIndex = 4;
            // 
            // _mapControl1
            // 
            this._mapControl1.AnimationOnZooming = MW5.Api.AutoToggle.Auto;
            this._mapControl1.CurrentScale = 16.918010798186259D;
            this._mapControl1.CurrentZoom = -1;
            this._mapControl1.CustomCursor = null;
            this._mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mapControl1.ExtentHistory = 20;
            this._mapControl1.ExtentPad = 0.02D;
            envelope1.Tag = "";
            this._mapControl1.Extents = envelope1;
            spatialReference1.Tag = "";
            this._mapControl1.GeoProjection = spatialReference1;
            this._mapControl1.GrabProjectionFromData = true;
            this._mapControl1.InertiaOnPanning = MW5.Api.AutoToggle.Auto;
            this._mapControl1.KnownExtents = MW5.Api.KnownExtents.None;
            this._mapControl1.Latitude = 0F;
            this._mapControl1.Legend = null;
            this._mapControl1.Location = new System.Drawing.Point(0, 0);
            this._mapControl1.Longitude = 0F;
            this._mapControl1.MapCursor = MW5.Api.MapCursor.ZoomIn;
            this._mapControl1.MapUnits = MW5.Api.UnitsOfMeasure.Meters;
            this._mapControl1.MouseWheelSpeed = 0.5D;
            this._mapControl1.Name = "_mapControl1";
            this._mapControl1.Projection = MW5.Api.MapProjection.None;
            this._mapControl1.ResizeBehavior = MW5.Api.ResizeBehavior.Classic;
            this._mapControl1.ReuseTileBuffer = true;
            this._mapControl1.ScalebarUnits = MW5.Api.ScalebarUnits.GoogleStyle;
            this._mapControl1.ScalebarVisible = true;
            this._mapControl1.ShowCoordinates = MW5.Api.CoordinatesDisplay.Auto;
            this._mapControl1.ShowRedrawTime = false;
            this._mapControl1.ShowVersionNumber = false;
            this._mapControl1.Size = new System.Drawing.Size(366, 294);
            this._mapControl1.SystemCursor = MW5.Api.SystemCursor.MapDefault;
            this._mapControl1.TabIndex = 0;
            this._mapControl1.Tag = "";
            this._mapControl1.TileProvider = MW5.Api.TileProvider.OpenStreetMap;
            this._mapControl1.UdCursorHandle = 0;
            this._mapControl1.UseSeamlessPan = false;
            this._mapControl1.ZoomBehavior = MW5.Api.ZoomBehavior.UseTileLevels;
            this._mapControl1.ZoomPercent = 0.3D;
            // 
            // _mainFrameBarManager1
            // 
            this._mainFrameBarManager1.AutoScale = true;
            this._mainFrameBarManager1.BarPositionInfo = ((System.IO.MemoryStream)(resources.GetObject("_mainFrameBarManager1.BarPositionInfo")));
            this._mainFrameBarManager1.CurrentBaseFormType = "MW5.UI.MapWindowView";
            this._mainFrameBarManager1.EnableMenuMerge = true;
            this._mainFrameBarManager1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._mainFrameBarManager1.Form = this;
            this._mainFrameBarManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this._mainFrameBarManager1.ResetCustomization = false;
            this._mainFrameBarManager1.UseBackwardCompatiblity = false;
            // 
            // _legendControl1
            // 
            this._legendControl1.BackColor = System.Drawing.Color.White;
            this._legendControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._legendControl1.DrawLines = true;
            this._legendControl1.Location = new System.Drawing.Point(106, 174);
            this._legendControl1.Map = null;
            this._legendControl1.Name = "_legendControl1";
            this._legendControl1.SelectedLayer = -1;
            this._legendControl1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this._legendControl1.ShowGroupIcons = true;
            this._legendControl1.ShowLabels = false;
            this._legendControl1.Size = new System.Drawing.Size(107, 126);
            this._legendControl1.TabIndex = 5;
            // 
            // statusStripLabel5
            // 
            this.statusStripLabel5.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusStripLabel5.Name = "statusStripLabel5";
            this.statusStripLabel5.Size = new System.Drawing.Size(10, 15);
            this.statusStripLabel5.Text = "|";
            // 
            // statusMapUnits
            // 
            this.statusMapUnits.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.statusMapUnits.Name = "statusMapUnits";
            this.statusMapUnits.Size = new System.Drawing.Size(61, 15);
            this.statusMapUnits.Text = "Map Units";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(52, 15);
            this.toolStripStatusLabel3.Text = "Progress";
            // 
            // statusProgress
            // 
            this.statusProgress.Name = "statusProgress";
            this.statusProgress.Size = new System.Drawing.Size(100, 15);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(181, 22);
            this.toolStripMenuItem6.Text = "Properties";
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
        private System.Windows.Forms.ToolStripStatusLabel statusProgressMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private Syncfusion.Windows.Forms.Tools.DockingManager _dockingManager1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem parentBarItem3;
        private Syncfusion.Windows.Forms.Tools.DockingClientPanel dockingClientPanel1;
        private BoundMapControl _mapControl1;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv treeViewAdv2;
        private Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager _mainFrameBarManager1;
        private Api.Legend.LegendControl _legendControl1;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripLabel5;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusMapUnits;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private System.Windows.Forms.ImageList imageList1;
        private Syncfusion.Windows.Forms.Tools.StatusStripDropDownButton statusProjectionDropDown;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusSelected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolChooseProjection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolProjectionProperties;

    }
}