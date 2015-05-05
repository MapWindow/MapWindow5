namespace MW5.UI.Controls
{
    partial class NetColorPicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetColorPicker));
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            this.watermarkTextbox1 = new MW5.UI.Controls.WatermarkTextbox();
            this.colorUIControl1 = new Syncfusion.Windows.Forms.ColorUIControl();
            ((System.ComponentModel.ISupportInitialize)(this.watermarkTextbox1)).BeginInit();
            this.SuspendLayout();
            // 
            // watermarkTextbox1
            // 
            this.watermarkTextbox1.BeforeTouchSize = new System.Drawing.Size(258, 20);
            this.watermarkTextbox1.Cue = "Enter color name or RGB";
            this.watermarkTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.watermarkTextbox1.FarImage = ((System.Drawing.Image)(resources.GetObject("watermarkTextbox1.FarImage")));
            this.watermarkTextbox1.Location = new System.Drawing.Point(3, 3);
            this.watermarkTextbox1.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.watermarkTextbox1.Name = "watermarkTextbox1";
            this.watermarkTextbox1.Size = new System.Drawing.Size(258, 20);
            this.watermarkTextbox1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.watermarkTextbox1.TabIndex = 2;
            // 
            // colorUIControl1
            // 
            this.colorUIControl1.BeforeTouchSize = new System.Drawing.Size(258, 284);
            this.colorUIControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.colorUIControl1.Flag = false;
            this.colorUIControl1.Location = new System.Drawing.Point(3, 29);
            this.colorUIControl1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.colorUIControl1.MetroForeColor = System.Drawing.Color.White;
            this.colorUIControl1.Name = "colorUIControl1";
            metroColorTable1.ArrowChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable1.ArrowInActive = System.Drawing.Color.White;
            metroColorTable1.ArrowNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable1.ArrowNormalBackGround = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable1.ArrowPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable1.ArrowPushedBackGround = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable1.ScrollerBackground = System.Drawing.Color.White;
            metroColorTable1.ThumbChecked = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
            metroColorTable1.ThumbInActive = System.Drawing.Color.White;
            metroColorTable1.ThumbNormal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(198)))));
            metroColorTable1.ThumbPushed = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            metroColorTable1.ThumbPushedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(90)))));
            this.colorUIControl1.ScrollMetroColorTable = metroColorTable1;
            this.colorUIControl1.ShowUserSelectionColors = true;
            this.colorUIControl1.Size = new System.Drawing.Size(258, 284);
            this.colorUIControl1.TabIndex = 3;
            this.colorUIControl1.Text = "colorUIControl1";
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorUIControl1);
            this.Controls.Add(this.watermarkTextbox1);
            this.Name = "NetColorPicker";
            this.Size = new System.Drawing.Size(264, 313);
            ((System.ComponentModel.ISupportInitialize)(this.watermarkTextbox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WatermarkTextbox watermarkTextbox1;
        private Syncfusion.Windows.Forms.ColorUIControl colorUIControl1;
    }
}
