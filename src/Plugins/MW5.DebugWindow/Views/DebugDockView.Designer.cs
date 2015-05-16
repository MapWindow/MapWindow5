using MW5.UI.Controls;

namespace MW5.Plugins.DebugWindow.Views
{
    partial class DebugDockView
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugDockView));
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolClearLog = new System.Windows.Forms.ToolStripButton();
            this.watermarkTextbox1 = new WatermarkTextbox();
            this.comboBoxAdv1 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.barItem1 = new Syncfusion.Windows.Forms.Tools.XPMenus.BarItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this._listControl = new MW5.Plugins.DebugWindow.Controls.LogEntryGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watermarkTextbox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel1.Controls.Add(this.toolStripEx1);
            this.gradientPanel1.Controls.Add(this.watermarkTextbox1);
            this.gradientPanel1.Controls.Add(this.comboBoxAdv1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(575, 30);
            this.gradientPanel1.TabIndex = 1;
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClearLog});
            this.toolStripEx1.Location = new System.Drawing.Point(460, 2);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.ShowItemToolTips = true;
            this.toolStripEx1.Size = new System.Drawing.Size(26, 25);
            this.toolStripEx1.TabIndex = 44;
            this.toolStripEx1.Text = "toolStripEx1";
            this.toolStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.ToolStripExStyle.Metro;
            // 
            // toolClearLog
            // 
            this.toolClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClearLog.Image = global::MW5.Plugins.DebugWindow.Properties.Resources.img_clear;
            this.toolClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClearLog.Name = "toolClearLog";
            this.toolClearLog.Size = new System.Drawing.Size(23, 22);
            this.toolClearLog.Text = "Clear log";
            // 
            // watermarkTextbox1
            // 
            this.watermarkTextbox1.BeforeTouchSize = new System.Drawing.Size(100, 20);
            this.watermarkTextbox1.Cue = "Search for messages";
            this.watermarkTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.watermarkTextbox1.Location = new System.Drawing.Point(3, 5);
            this.watermarkTextbox1.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.watermarkTextbox1.Name = "watermarkTextbox1";
            this.watermarkTextbox1.Size = new System.Drawing.Size(293, 20);
            this.watermarkTextbox1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.watermarkTextbox1.TabIndex = 43;
            // 
            // comboBoxAdv1
            // 
            this.comboBoxAdv1.BackColor = System.Drawing.Color.White;
            this.comboBoxAdv1.BeforeTouchSize = new System.Drawing.Size(154, 21);
            this.comboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAdv1.Items.AddRange(new object[] {
            "All"});
            this.comboBoxAdv1.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.comboBoxAdv1, "All"));
            this.comboBoxAdv1.Location = new System.Drawing.Point(302, 5);
            this.comboBoxAdv1.Name = "comboBoxAdv1";
            this.comboBoxAdv1.Size = new System.Drawing.Size(154, 21);
            this.comboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            this.comboBoxAdv1.TabIndex = 40;
            this.comboBoxAdv1.Text = "All";
            // 
            // barItem1
            // 
            this.barItem1.BarName = "barItem1";
            this.barItem1.ID = "xcvxcv";
            this.barItem1.ImageIndex = 4;
            this.barItem1.ImageList = this.imageList1;
            this.barItem1.ImageSize = new System.Drawing.Size(20, 20);
            this.barItem1.Padding = new System.Drawing.Point(5, 0);
            this.barItem1.PaintStyle = Syncfusion.Windows.Forms.Tools.XPMenus.PaintStyle.ImageAndText;
            this.barItem1.ShowToolTipInPopUp = false;
            this.barItem1.SizeToFit = true;
            this.barItem1.Text = "Clear log";
            this.barItem1.TextAlignment = Syncfusion.Windows.Forms.Tools.XPMenus.TextAlignment.Center;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "img_info.png");
            this.imageList1.Images.SetKeyName(1, "img_debug.png");
            this.imageList1.Images.SetKeyName(2, "img_warning.png");
            this.imageList1.Images.SetKeyName(3, "img_error.png");
            this.imageList1.Images.SetKeyName(4, "img_clear.png");
            // 
            // _listControl
            // 
            this._listControl.DataSource = null;
            this._listControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listControl.Location = new System.Drawing.Point(0, 30);
            this._listControl.Name = "_listControl";
            this._listControl.Size = new System.Drawing.Size(575, 65);
            this._listControl.TabIndex = 44;
            // 
            // DebugDockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._listControl);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "DebugDockView";
            this.Size = new System.Drawing.Size(575, 95);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watermarkTextbox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboBoxAdv1;
        private Syncfusion.Windows.Forms.Tools.XPMenus.BarItem barItem1;
        private WatermarkTextbox watermarkTextbox1;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.LogEntryGrid _listControl;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton toolClearLog;






    }
}
