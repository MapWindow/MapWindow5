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
            this.statusStripLabel5 = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.statusMapUnits = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.superToolTip1 = new Syncfusion.Windows.Forms.Tools.SuperToolTip(this);
            this.statusStripEx1 = new Syncfusion.Windows.Forms.Tools.StatusStripEx();
            ((System.ComponentModel.ISupportInitialize)(this._dockingManager1)).BeginInit();
            this.dockingClientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mainFrameBarManager1)).BeginInit();
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
            this._mapControl1.CurrentScale = 13.87264037331304D;
            this._mapControl1.CurrentZoom = -1;
            this._mapControl1.CustomCursor = null;
            this._mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this._mapControl1.MapUnits = MW5.Api.Enums.UnitsOfMeasure.Meters;
            this._mapControl1.MouseWheelSpeed = 0.5D;
            this._mapControl1.Name = "_mapControl1";
            spatialReference1.Tag = "";
            this._mapControl1.Projection = spatialReference1;
            this._mapControl1.ResizeBehavior = MW5.Api.Enums.ResizeBehavior.Classic;
            this._mapControl1.ReuseTileBuffer = true;
            this._mapControl1.ScalebarUnits = MW5.Api.Enums.ScalebarUnits.GoogleStyle;
            this._mapControl1.ScalebarVisible = true;
            this._mapControl1.ShowCoordinates = MW5.Api.Enums.CoordinatesDisplay.Auto;
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
            this._mapControl1.ZoomPercent = 0.3D;
            // 
            // _mainFrameBarManager1
            // 
            this._mainFrameBarManager1.AutoLoadToolBarPositions = false;
            this._mainFrameBarManager1.AutoPersistCustomization = false;
            this._mainFrameBarManager1.AutoScale = true;
            this._mainFrameBarManager1.BarPositionInfo = ((System.IO.MemoryStream)(resources.GetObject("_mainFrameBarManager1.BarPositionInfo")));
            this._mainFrameBarManager1.CurrentBaseFormType = "MW5.UI.Forms.MapWindowView";
            this._mainFrameBarManager1.EnableMenuMerge = true;
            this._mainFrameBarManager1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._mainFrameBarManager1.Form = this;
            this._mainFrameBarManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this._mainFrameBarManager1.ResetCustomization = false;
            this._mainFrameBarManager1.UseBackwardCompatiblity = false;
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
            this.superToolTip1.VisualStyle = Syncfusion.Windows.Forms.Tools.SuperToolTip.Appearance.Metro;
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
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(796, 531);
            this.Controls.Add(this.dockingClientPanel1);
            this.Controls.Add(this.statusStripEx1);
            this.Name = "MainView";
            this.Text = "MapWindow 5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this._dockingManager1)).EndInit();
            this.dockingClientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mainFrameBarManager1)).EndInit();
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

    }
}