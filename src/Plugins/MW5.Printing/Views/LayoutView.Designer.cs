using MW5.Plugins.Printing.Controls;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Views.Panels;

namespace MW5.Plugins.Printing.Views
{
    partial class LayoutView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutView));
            this.mainFrameBarManager1 = new Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager(this);
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.layoutControl1 = new MW5.Plugins.Printing.Controls.Layout.LayoutControl();
            this.contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.toolMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAlign = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAlignLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAlignRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAlignTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAlignBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAlignHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolAlignVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPageAlign = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPageAlignLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPageAlignRight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPageAlignTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPageAlignBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPageAlignHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPageAlignVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFitWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolFitHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFitBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMakeSameSize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSameWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSameHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSameSize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutPropertyGrid1 = new MW5.Plugins.Printing.Views.Panels.PropertiesDockPanel();
            this.statusStripEx1 = new Syncfusion.Windows.Forms.Tools.StatusStripEx();
            this.lblPageCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPageSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelected = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.lblPosition = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.lblLoadingTiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dockingManager1 = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dockingClientPanel1 = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mainFrameBarManager1)).BeginInit();
            this.contextMenuStripEx1.SuspendLayout();
            this.statusStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockingManager1)).BeginInit();
            this.dockingClientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainFrameBarManager1
            // 
            this.mainFrameBarManager1.BarPositionInfo = ((System.IO.MemoryStream)(resources.GetObject("mainFrameBarManager1.BarPositionInfo")));
            this.mainFrameBarManager1.Categories.Add("1");
            this.mainFrameBarManager1.CurrentBaseFormType = "MW5.Plugins.Printing.Views.LayoutViewBase";
            this.mainFrameBarManager1.EnableMenuMerge = true;
            this.mainFrameBarManager1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainFrameBarManager1.Form = this;
            this.mainFrameBarManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(201)))), ((int)(((byte)(232)))));
            this.mainFrameBarManager1.ResetCustomization = false;
            this.mainFrameBarManager1.UseBackwardCompatiblity = false;
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripEx1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.ShowItemToolTips = true;
            this.toolStripEx1.Size = new System.Drawing.Size(55, 25);
            this.toolStripEx1.TabIndex = 11;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 34);
            this.panel1.TabIndex = 10;
            // 
            // layoutControl1
            // 
            this.layoutControl1.ContextMenuStrip = this.contextMenuStripEx1;
            this.layoutControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.DrawingQuality = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.layoutControl1.Filename = "";
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.PanMode = false;
            this.layoutControl1.PrinterSettings = ((System.Drawing.Printing.PrinterSettings)(resources.GetObject("layoutControl1.PrinterSettings")));
            this.layoutControl1.SelectionColor = System.Drawing.Color.Orange;
            this.layoutControl1.ShowMargins = true;
            this.layoutControl1.ShowPageNumbers = false;
            this.layoutControl1.ShowRulers = true;
            this.layoutControl1.Size = new System.Drawing.Size(321, 263);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Zoom = 0.2955806F;
            // 
            // contextMenuStripEx1
            // 
            this.contextMenuStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMoveUp,
            this.toolMoveDown,
            this.toolStripSeparator1,
            this.toolAlign,
            this.toolPageAlign,
            this.toolStripSeparator2,
            this.toolFit,
            this.toolMakeSameSize,
            this.toolStripSeparator3,
            this.toolDelete});
            this.contextMenuStripEx1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.contextMenuStripEx1.Name = "contextMenuStripEx1";
            this.contextMenuStripEx1.Size = new System.Drawing.Size(159, 176);
            this.contextMenuStripEx1.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Default;
            // 
            // toolMoveUp
            // 
            this.toolMoveUp.Image = global::MW5.Plugins.Printing.Properties.Resources.img_up24;
            this.toolMoveUp.Name = "toolMoveUp";
            this.toolMoveUp.Size = new System.Drawing.Size(158, 22);
            this.toolMoveUp.Text = "Move Up";
            // 
            // toolMoveDown
            // 
            this.toolMoveDown.Image = global::MW5.Plugins.Printing.Properties.Resources.img_down24;
            this.toolMoveDown.Name = "toolMoveDown";
            this.toolMoveDown.Size = new System.Drawing.Size(158, 22);
            this.toolMoveDown.Text = "Move Down";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // toolAlign
            // 
            this.toolAlign.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAlignLeft,
            this.toolAlignRight,
            this.toolAlignTop,
            this.toolAlignBottom,
            this.toolStripSeparator5,
            this.toolAlignHorizontal,
            this.toolAlignVertical});
            this.toolAlign.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_left24;
            this.toolAlign.Name = "toolAlign";
            this.toolAlign.Size = new System.Drawing.Size(158, 22);
            this.toolAlign.Text = "Align";
            // 
            // toolAlignLeft
            // 
            this.toolAlignLeft.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_left24;
            this.toolAlignLeft.Name = "toolAlignLeft";
            this.toolAlignLeft.Size = new System.Drawing.Size(129, 22);
            this.toolAlignLeft.Text = "Left";
            // 
            // toolAlignRight
            // 
            this.toolAlignRight.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_right24;
            this.toolAlignRight.Name = "toolAlignRight";
            this.toolAlignRight.Size = new System.Drawing.Size(129, 22);
            this.toolAlignRight.Text = "Right";
            // 
            // toolAlignTop
            // 
            this.toolAlignTop.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_top24;
            this.toolAlignTop.Name = "toolAlignTop";
            this.toolAlignTop.Size = new System.Drawing.Size(129, 22);
            this.toolAlignTop.Text = "Top";
            // 
            // toolAlignBottom
            // 
            this.toolAlignBottom.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_bottom24;
            this.toolAlignBottom.Name = "toolAlignBottom";
            this.toolAlignBottom.Size = new System.Drawing.Size(129, 22);
            this.toolAlignBottom.Text = "Bottom";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // toolAlignHorizontal
            // 
            this.toolAlignHorizontal.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_center24;
            this.toolAlignHorizontal.Name = "toolAlignHorizontal";
            this.toolAlignHorizontal.Size = new System.Drawing.Size(129, 22);
            this.toolAlignHorizontal.Text = "Horizontal";
            // 
            // toolAlignVertical
            // 
            this.toolAlignVertical.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_vertical24;
            this.toolAlignVertical.Name = "toolAlignVertical";
            this.toolAlignVertical.Size = new System.Drawing.Size(129, 22);
            this.toolAlignVertical.Text = "Vertical";
            // 
            // toolPageAlign
            // 
            this.toolPageAlign.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPageAlignLeft,
            this.toolPageAlignRight,
            this.toolPageAlignTop,
            this.toolPageAlignBottom,
            this.toolStripSeparator4,
            this.toolPageAlignHorizontal,
            this.toolPageAlignVertical});
            this.toolPageAlign.Name = "toolPageAlign";
            this.toolPageAlign.Size = new System.Drawing.Size(158, 22);
            this.toolPageAlign.Text = "Page Align";
            // 
            // toolPageAlignLeft
            // 
            this.toolPageAlignLeft.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_left24;
            this.toolPageAlignLeft.Name = "toolPageAlignLeft";
            this.toolPageAlignLeft.Size = new System.Drawing.Size(160, 22);
            this.toolPageAlignLeft.Text = "Align Left";
            // 
            // toolPageAlignRight
            // 
            this.toolPageAlignRight.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_right24;
            this.toolPageAlignRight.Name = "toolPageAlignRight";
            this.toolPageAlignRight.Size = new System.Drawing.Size(160, 22);
            this.toolPageAlignRight.Text = "Align Right";
            // 
            // toolPageAlignTop
            // 
            this.toolPageAlignTop.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_top24;
            this.toolPageAlignTop.Name = "toolPageAlignTop";
            this.toolPageAlignTop.Size = new System.Drawing.Size(160, 22);
            this.toolPageAlignTop.Text = "Align Top";
            // 
            // toolPageAlignBottom
            // 
            this.toolPageAlignBottom.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_bottom24;
            this.toolPageAlignBottom.Name = "toolPageAlignBottom";
            this.toolPageAlignBottom.Size = new System.Drawing.Size(160, 22);
            this.toolPageAlignBottom.Text = "Align Bottom";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // toolPageAlignHorizontal
            // 
            this.toolPageAlignHorizontal.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_center24;
            this.toolPageAlignHorizontal.Name = "toolPageAlignHorizontal";
            this.toolPageAlignHorizontal.Size = new System.Drawing.Size(160, 22);
            this.toolPageAlignHorizontal.Text = "Align Horizontal";
            // 
            // toolPageAlignVertical
            // 
            this.toolPageAlignVertical.Image = global::MW5.Plugins.Printing.Properties.Resources.img_align_vertical24;
            this.toolPageAlignVertical.Name = "toolPageAlignVertical";
            this.toolPageAlignVertical.Size = new System.Drawing.Size(160, 22);
            this.toolPageAlignVertical.Text = "Align Vertical";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // toolFit
            // 
            this.toolFit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFitWidth,
            this.toolFitHeight,
            this.toolStripSeparator6,
            this.toolFitBoth});
            this.toolFit.Image = global::MW5.Plugins.Printing.Properties.Resources.img_fit24;
            this.toolFit.Name = "toolFit";
            this.toolFit.Size = new System.Drawing.Size(158, 22);
            this.toolFit.Text = "Fit to Page";
            // 
            // toolFitWidth
            // 
            this.toolFitWidth.Image = global::MW5.Plugins.Printing.Properties.Resources.img_fit_width24;
            this.toolFitWidth.Name = "toolFitWidth";
            this.toolFitWidth.Size = new System.Drawing.Size(110, 22);
            this.toolFitWidth.Text = "Width";
            // 
            // toolFitHeight
            // 
            this.toolFitHeight.Image = global::MW5.Plugins.Printing.Properties.Resources.img_fit_height24;
            this.toolFitHeight.Name = "toolFitHeight";
            this.toolFitHeight.Size = new System.Drawing.Size(110, 22);
            this.toolFitHeight.Text = "Height";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(107, 6);
            // 
            // toolFitBoth
            // 
            this.toolFitBoth.Name = "toolFitBoth";
            this.toolFitBoth.Size = new System.Drawing.Size(110, 22);
            this.toolFitBoth.Text = "Both";
            // 
            // toolMakeSameSize
            // 
            this.toolMakeSameSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSameWidth,
            this.toolSameHeight,
            this.toolStripSeparator7,
            this.toolSameSize});
            this.toolMakeSameSize.Name = "toolMakeSameSize";
            this.toolMakeSameSize.Size = new System.Drawing.Size(158, 22);
            this.toolMakeSameSize.Text = "Make Same Size";
            // 
            // toolSameWidth
            // 
            this.toolSameWidth.Image = global::MW5.Plugins.Printing.Properties.Resources.img_fit_width24;
            this.toolSameWidth.Name = "toolSameWidth";
            this.toolSameWidth.Size = new System.Drawing.Size(110, 22);
            this.toolSameWidth.Text = "Width";
            // 
            // toolSameHeight
            // 
            this.toolSameHeight.Image = global::MW5.Plugins.Printing.Properties.Resources.img_fit_height24;
            this.toolSameHeight.Name = "toolSameHeight";
            this.toolSameHeight.Size = new System.Drawing.Size(110, 22);
            this.toolSameHeight.Text = "Height";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(107, 6);
            // 
            // toolSameSize
            // 
            this.toolSameSize.Name = "toolSameSize";
            this.toolSameSize.Size = new System.Drawing.Size(110, 22);
            this.toolSameSize.Text = "Both";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(155, 6);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::MW5.Plugins.Printing.Properties.Resources.img_remove24;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(158, 22);
            this.toolDelete.Text = "Delete";
            // 
            // layoutPropertyGrid1
            // 
            this.layoutPropertyGrid1.LayoutControl = null;
            this.layoutPropertyGrid1.Location = new System.Drawing.Point(443, 169);
            this.layoutPropertyGrid1.Name = "layoutPropertyGrid1";
            this.layoutPropertyGrid1.Size = new System.Drawing.Size(155, 135);
            this.layoutPropertyGrid1.TabIndex = 0;
            // 
            // statusStripEx1
            // 
            this.statusStripEx1.BackColor = System.Drawing.Color.SandyBrown;
            this.statusStripEx1.BeforeTouchSize = new System.Drawing.Size(649, 26);
            this.statusStripEx1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Bottom;
            this.statusStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPageCount,
            this.lblPageSize,
            this.lblSelected,
            this.lblPosition,
            this.lblLoadingTiles,
            this.toolStripProgressBar1});
            this.statusStripEx1.Location = new System.Drawing.Point(0, 392);
            this.statusStripEx1.MetroColor = System.Drawing.Color.SandyBrown;
            this.statusStripEx1.Name = "statusStripEx1";
            this.statusStripEx1.Size = new System.Drawing.Size(649, 26);
            this.statusStripEx1.TabIndex = 8;
            this.statusStripEx1.Text = "statusStripEx1";
            // 
            // lblPageCount
            // 
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Padding = new System.Windows.Forms.Padding(3);
            this.lblPageCount.Size = new System.Drawing.Size(56, 21);
            this.lblPageCount.Text = "Pages: 1";
            // 
            // lblPageSize
            // 
            this.lblPageSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(25, 19);
            this.lblPageSize.Text = "A4";
            // 
            // lblSelected
            // 
            this.lblSelected.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblSelected.Size = new System.Drawing.Size(114, 15);
            this.lblSelected.Text = "Items selected: 0";
            // 
            // lblPosition
            // 
            this.lblPosition.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblPosition.Size = new System.Drawing.Size(101, 15);
            this.lblPosition.Text = "X = 212; Y = 414";
            // 
            // lblLoadingTiles
            // 
            this.lblLoadingTiles.Name = "lblLoadingTiles";
            this.lblLoadingTiles.Size = new System.Drawing.Size(74, 15);
            this.lblLoadingTiles.Text = "Loading tiles";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 15);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Value = 100;
            this.toolStripProgressBar1.Visible = false;
            // 
            // dockingManager1
            // 
            this.dockingManager1.ActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.AutoHideTabFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("dockingManager1.DockLayoutStream")));
            this.dockingManager1.DockTabFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.EnableAutoAdjustCaption = true;
            this.dockingManager1.HostControl = this;
            this.dockingManager1.ImageList = this.imageList1;
            this.dockingManager1.InActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dockingManager1.MetroCaptionColor = System.Drawing.Color.White;
            this.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(159)))), ((int)(((byte)(183)))));
            this.dockingManager1.ReduceFlickeringInRtl = false;
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"));
            this.dockingManager1.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"));
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(20, 20);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dockingClientPanel1
            // 
            this.dockingClientPanel1.Controls.Add(this.layoutControl1);
            this.dockingClientPanel1.Location = new System.Drawing.Point(49, 41);
            this.dockingClientPanel1.Name = "dockingClientPanel1";
            this.dockingClientPanel1.Size = new System.Drawing.Size(321, 263);
            this.dockingClientPanel1.TabIndex = 1;
            // 
            // LayoutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 418);
            this.Controls.Add(this.layoutPropertyGrid1);
            this.Controls.Add(this.dockingClientPanel1);
            this.Controls.Add(this.statusStripEx1);
            this.Name = "LayoutView";
            this.Text = "Printing Layout";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.mainFrameBarManager1)).EndInit();
            this.contextMenuStripEx1.ResumeLayout(false);
            this.statusStripEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dockingManager1)).EndInit();
            this.dockingClientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.XPMenus.MainFrameBarManager mainFrameBarManager1;
        private LayoutControl layoutControl1;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private Syncfusion.Windows.Forms.Tools.StatusStripEx statusStripEx1;
        private System.Windows.Forms.ToolStripStatusLabel lblPageCount;
        private System.Windows.Forms.ToolStripStatusLabel lblPageSize;
        private PropertiesDockPanel layoutPropertyGrid1;
        private Syncfusion.Windows.Forms.Tools.DockingManager dockingManager1;
        private Syncfusion.Windows.Forms.Tools.DockingClientPanel dockingClientPanel1;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel lblSelected;
        private Syncfusion.Windows.Forms.Tools.StatusStripLabel lblPosition;
        private System.Windows.Forms.ImageList imageList1;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStripEx1;
        private System.Windows.Forms.ToolStripMenuItem toolMoveUp;
        private System.Windows.Forms.ToolStripMenuItem toolMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolAlign;
        private System.Windows.Forms.ToolStripMenuItem toolAlignLeft;
        private System.Windows.Forms.ToolStripMenuItem toolAlignRight;
        private System.Windows.Forms.ToolStripMenuItem toolAlignTop;
        private System.Windows.Forms.ToolStripMenuItem toolAlignBottom;
        private System.Windows.Forms.ToolStripMenuItem toolAlignHorizontal;
        private System.Windows.Forms.ToolStripMenuItem toolAlignVertical;
        private System.Windows.Forms.ToolStripMenuItem toolPageAlign;
        private System.Windows.Forms.ToolStripMenuItem toolPageAlignLeft;
        private System.Windows.Forms.ToolStripMenuItem toolPageAlignRight;
        private System.Windows.Forms.ToolStripMenuItem toolPageAlignTop;
        private System.Windows.Forms.ToolStripMenuItem toolPageAlignBottom;
        private System.Windows.Forms.ToolStripMenuItem toolPageAlignHorizontal;
        private System.Windows.Forms.ToolStripMenuItem toolPageAlignVertical;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolMakeSameSize;
        private System.Windows.Forms.ToolStripMenuItem toolSameWidth;
        private System.Windows.Forms.ToolStripMenuItem toolSameHeight;
        private System.Windows.Forms.ToolStripMenuItem toolFit;
        private System.Windows.Forms.ToolStripMenuItem toolFitWidth;
        private System.Windows.Forms.ToolStripMenuItem toolFitHeight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolDelete;
        private System.Windows.Forms.ToolStripMenuItem toolFitBoth;
        private System.Windows.Forms.ToolStripMenuItem toolSameSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripStatusLabel lblLoadingTiles;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}