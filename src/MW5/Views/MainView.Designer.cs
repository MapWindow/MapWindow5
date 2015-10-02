using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Map;

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
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            this._dockingManager1 = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.parentBarItem3 = new Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem();
            this.dockingClientPanel1 = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            this._mapControl1 = new MW5.Api.Map.BoundMapControl();
            this._mainFrameBarManager1 = new Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager(this);
            this.commandBar1 = new Syncfusion.Windows.Forms.Tools.CommandBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripEx1 = new Syncfusion.Windows.Forms.Tools.StatusStripEx();
            this.statusStripLabel5 = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusMapUnits = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.superToolTip1 = new Syncfusion.Windows.Forms.Tools.SuperToolTip(this);
            ((System.ComponentModel.ISupportInitialize)(this._dockingManager1)).BeginInit();
            this.dockingClientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainFrameBarManager1)).BeginInit();
            this.commandBar1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dockingManager1
            // 
            this._dockingManager1.ActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this._dockingManager1.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("_dockingManager1.DockLayoutStream")));
            this._dockingManager1.DockTabAlignment = Syncfusion.Windows.Forms.Tools.DockTabAlignmentStyle.Left;
            this._dockingManager1.DockTabHeight = 26;
            this._dockingManager1.EnableAutoAdjustCaption = true;
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
            // dockingClientPanel1
            // 
            this.dockingClientPanel1.BackColor = System.Drawing.Color.White;
            this.dockingClientPanel1.Controls.Add(this._mapControl1);
            this.dockingClientPanel1.Location = new System.Drawing.Point(298, 88);
            this.dockingClientPanel1.Name = "dockingClientPanel1";
            this.dockingClientPanel1.Size = new System.Drawing.Size(434, 338);
            this.dockingClientPanel1.TabIndex = 4;
            // 
            // _mapControl1
            // 
            this._mapControl1.AllowDrop = true;
            this._mapControl1.AnimationOnZooming = MW5.Api.Enums.AutoToggle.Auto;
            this._mapControl1.BackColor = System.Drawing.Color.White;
            this._mapControl1.BackgroundColor = System.Drawing.Color.White;
            this._mapControl1.CurrentScale = 0.31902886946251746D;
            this._mapControl1.CurrentZoom = -1;
            this._mapControl1.CustomCursor = null;
            this._mapControl1.ExtentHistory = 20;
            this._mapControl1.ExtentPad = 0.02D;
            this._mapControl1.GrabProjectionFromData = true;
            this._mapControl1.InertiaOnPanning = MW5.Api.Enums.AutoToggle.Auto;
            this._mapControl1.KnownExtents = MW5.Api.Enums.KnownExtents.None;
            this._mapControl1.Latitude = 0F;
            this._mapControl1.Legend = null;
            this._mapControl1.Location = new System.Drawing.Point(0, 0);
            this._mapControl1.Longitude = 0F;
            this._mapControl1.MapCursor = MW5.Api.Enums.MapCursor.ZoomIn;
            this._mapControl1.MapProjection = MW5.Api.Enums.MapProjection.None;
            this._mapControl1.MapUnits = MW5.Api.Enums.LengthUnits.Meters;
            this._mapControl1.MouseWheelSpeed = 0.5D;
            this._mapControl1.Name = "_mapControl1";
            spatialReference1.Tag = "";
            this._mapControl1.Projection = spatialReference1;
            this._mapControl1.ResizeBehavior = MW5.Api.Enums.ResizeBehavior.Classic;
            this._mapControl1.ReuseTileBuffer = true;
            this._mapControl1.ScalebarUnits = MW5.Api.Enums.ScalebarUnits.GoogleStyle;
            this._mapControl1.ScalebarVisible = true;
            this._mapControl1.ShowCoordinates = MW5.Api.Enums.CoordinatesDisplay.Auto;
            this._mapControl1.ShowCoordinatesFormat = MW5.Api.Enums.AngleFormat.Degrees;
            this._mapControl1.ShowRedrawTime = false;
            this._mapControl1.ShowVersionNumber = false;
            this._mapControl1.Size = new System.Drawing.Size(434, 338);
            this._mapControl1.SystemCursor = MW5.Api.Enums.SystemCursor.MapDefault;
            this._mapControl1.TabIndex = 0;
            this._mapControl1.Tag = "";
            this._mapControl1.TileProvider = MW5.Api.Enums.TileProvider.OpenStreetMap;
            this._mapControl1.UdCursorHandle = 0;
            this._mapControl1.UseSeamlessPan = false;
            this._mapControl1.ZoomBehavior = MW5.Api.Enums.ZoomBehavior.UseTileLevels;
            this._mapControl1.ZoomBoxStyle = MW5.Api.Enums.ZoomBoxStyle.Blue;
            this._mapControl1.ZoomPercent = 0.3D;
            // 
            // _mainFrameBarManager1
            // 
            this._mainFrameBarManager1.AutoLoadToolBarPositions = false;
            this._mainFrameBarManager1.AutoPersistCustomization = false;
            this._mainFrameBarManager1.AutoScale = true;
            this._mainFrameBarManager1.BarPositionInfo = ((System.IO.MemoryStream)(resources.GetObject("_mainFrameBarManager1.BarPositionInfo")));
            this._mainFrameBarManager1.CurrentBaseFormType = "MW5.UI.Forms.MapWindowView";
            this._mainFrameBarManager1.DetachedCommandBars.Add(this.commandBar1);
            this._mainFrameBarManager1.EnableMenuMerge = true;
            this._mainFrameBarManager1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._mainFrameBarManager1.Form = this;
            this._mainFrameBarManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this._mainFrameBarManager1.ResetCustomization = false;
            this._mainFrameBarManager1.UseBackwardCompatiblity = false;
            // 
            // commandBar1
            // 
            this.commandBar1.AlwaysLeadingEdge = true;
            this.commandBar1.ChevronColor = System.Drawing.SystemColors.ControlText;
            this.commandBar1.Controls.Add(this.menuStrip1);
            this.commandBar1.DisableFloating = true;
            this.commandBar1.DockState = Syncfusion.Windows.Forms.Tools.CommandBarDockState.Top;
            this.commandBar1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.commandBar1.HideGripper = true;
            this.commandBar1.MaxLength = 200;
            this.commandBar1.MinHeight = 32;
            this.commandBar1.MinLength = 50;
            this.commandBar1.Name = "commandBar1";
            this.commandBar1.OccupyFullRow = true;
            this.commandBar1.RowIndex = 0;
            this.commandBar1.RowOffset = 0;
            this.commandBar1.TabIndex = 0;
            this.commandBar1.TabStop = false;
            this.commandBar1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem7,
            this.toolStripMenuItem10,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.menuStrip1.Location = new System.Drawing.Point(2, 1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(362, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::MW5.Properties.Resources.icon_crs_change;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::MW5.Properties.Resources.icon_folder;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolStripMenuItem4.Size = new System.Drawing.Size(45, 20);
            this.toolStripMenuItem4.Text = "Edit";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolStripMenuItem5.Size = new System.Drawing.Size(53, 20);
            this.toolStripMenuItem5.Text = "Layer";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolStripMenuItem7.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem7.Text = "View";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolStripMenuItem10.Size = new System.Drawing.Size(64, 20);
            this.toolStripMenuItem10.Text = "Plugins";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolStripMenuItem8.Size = new System.Drawing.Size(49, 20);
            this.toolStripMenuItem8.Text = "Tiles";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolStripMenuItem9.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem9.Text = "Help";
            // 
            // statusStripEx1
            // 
            this.statusStripEx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.statusStripEx1.BeforeTouchSize = new System.Drawing.Size(796, 22);
            this.statusStripEx1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Bottom;
            this.statusStripEx1.Location = new System.Drawing.Point(0, 509);
            this.statusStripEx1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.statusStripEx1.Name = "statusStripEx1";
            this.statusStripEx1.Size = new System.Drawing.Size(796, 22);
            this.statusStripEx1.TabIndex = 1;
            this.statusStripEx1.Text = "statusStripEx1";
            this.statusStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.StatusStripExStyle.Metro;
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
            // superToolTip1
            // 
            this.superToolTip1.MetroColor = System.Drawing.Color.White;
            this.superToolTip1.Style = Syncfusion.Windows.Forms.Tools.SuperToolTip.SuperToolTipStyle.Office2013Style;
            this.superToolTip1.UseFading = Syncfusion.Windows.Forms.Tools.SuperToolTip.FadingType.System;
            this.superToolTip1.VisualStyle = Syncfusion.Windows.Forms.Tools.SuperToolTip.Appearance.Metro;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(796, 531);
            this.Controls.Add(this.dockingClientPanel1);
            this.Controls.Add(this.statusStripEx1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "MapWindow 5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._dockingManager1)).EndInit();
            this.dockingClientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainFrameBarManager1)).EndInit();
            this.commandBar1.ResumeLayout(false);
            this.commandBar1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.DockingManager _dockingManager1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.ParentBarItem parentBarItem3;
        private Syncfusion.Windows.Forms.Tools.DockingClientPanel dockingClientPanel1;
        private BoundMapControl _mapControl1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager _mainFrameBarManager1;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusStripLabel5;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel statusMapUnits;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripProgressBar statusProgress;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private Syncfusion.Windows.Forms.Tools.SuperToolTip superToolTip1;
        private Syncfusion.Windows.Forms.Tools.StatusStripEx statusStripEx1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private Syncfusion.Windows.Forms.Tools.CommandBar commandBar1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;

    }
}