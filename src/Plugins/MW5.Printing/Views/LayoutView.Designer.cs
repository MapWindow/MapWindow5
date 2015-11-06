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
            this.layoutPropertyGrid1 = new MW5.Plugins.Printing.Views.Panels.PropertiesDockPanel();
            this.statusStripEx1 = new Syncfusion.Windows.Forms.Tools.StatusStripEx();
            this.lblPageCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPageSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelected = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.lblPosition = new Syncfusion.Windows.Forms.Tools.StatusStripLabel();
            this.dockingManager1 = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.dockingClientPanel1 = new Syncfusion.Windows.Forms.Tools.DockingClientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mainFrameBarManager1)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(321, 263);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Zoom = 0.2955806F;
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
            this.lblPosition});
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
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(21, 15);
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
            this.lblPosition.Size = new System.Drawing.Size(91, 15);
            this.lblPosition.Text = "X = 212; Y = 414";
            // 
            // dockingManager1
            // 
            this.dockingManager1.ActiveCaptionFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager1.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("dockingManager1.DockLayoutStream")));
            this.dockingManager1.EnableAutoAdjustCaption = true;
            this.dockingManager1.HostControl = this;
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
    }
}