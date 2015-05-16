namespace MW5.Plugins.Symbology.Controls
{
    partial class RgbBandControl
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRed = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboGreen = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBlue = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAlpha = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnDefaultMapping = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtMinRed = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMaxRed = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMaxGreen = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMinGreen = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMaxBlue = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMinBlue = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.btnRedDefault = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRedCustom = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnGreenCustom = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnGreenDefault = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnBlueCustom = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnBlueDefault = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAllDefault = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAllCustom = new Syncfusion.Windows.Forms.ButtonAdv();
            this.chkCustomMinMax = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.cboRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinBlue)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            // 
            // cboRed
            // 
            this.cboRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRed.BeforeTouchSize = new System.Drawing.Size(222, 21);
            this.cboRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboRed.Location = new System.Drawing.Point(59, 48);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(222, 21);
            this.cboRed.TabIndex = 1;
            this.cboRed.SelectedIndexChanged += new System.EventHandler(this.SelectedBandChanged);
            // 
            // cboGreen
            // 
            this.cboGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGreen.BeforeTouchSize = new System.Drawing.Size(222, 21);
            this.cboGreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboGreen.Location = new System.Drawing.Point(59, 85);
            this.cboGreen.Name = "cboGreen";
            this.cboGreen.Size = new System.Drawing.Size(222, 21);
            this.cboGreen.TabIndex = 3;
            this.cboGreen.SelectedIndexChanged += new System.EventHandler(this.SelectedBandChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Green";
            // 
            // cboBlue
            // 
            this.cboBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBlue.BeforeTouchSize = new System.Drawing.Size(222, 21);
            this.cboBlue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboBlue.Location = new System.Drawing.Point(59, 124);
            this.cboBlue.Name = "cboBlue";
            this.cboBlue.Size = new System.Drawing.Size(222, 21);
            this.cboBlue.TabIndex = 5;
            this.cboBlue.SelectedIndexChanged += new System.EventHandler(this.SelectedBandChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Blue";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Alpha";
            // 
            // cboAlpha
            // 
            this.cboAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAlpha.BeforeTouchSize = new System.Drawing.Size(222, 21);
            this.cboAlpha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboAlpha.Location = new System.Drawing.Point(59, 160);
            this.cboAlpha.Name = "cboAlpha";
            this.cboAlpha.Size = new System.Drawing.Size(222, 21);
            this.cboAlpha.TabIndex = 7;
            this.cboAlpha.SelectedIndexChanged += new System.EventHandler(this.SelectedBandChanged);
            // 
            // btnDefaultMapping
            // 
            this.btnDefaultMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefaultMapping.BeforeTouchSize = new System.Drawing.Size(111, 23);
            this.btnDefaultMapping.IsBackStageButton = false;
            this.btnDefaultMapping.Location = new System.Drawing.Point(99, 196);
            this.btnDefaultMapping.Name = "btnDefaultMapping";
            this.btnDefaultMapping.Size = new System.Drawing.Size(111, 23);
            this.btnDefaultMapping.TabIndex = 8;
            this.btnDefaultMapping.Text = "Default mapping";
            this.btnDefaultMapping.Click += new System.EventHandler(this.SetDefaultMappingClick);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(65, 23);
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(216, 196);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.ClearMappingClick);
            // 
            // txtMinRed
            // 
            this.txtMinRed.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMinRed.BeforeTouchSize = new System.Drawing.Size(64, 20);
            this.txtMinRed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMinRed.DoubleValue = 1D;
            this.txtMinRed.Location = new System.Drawing.Point(3, 14);
            this.txtMinRed.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMinRed.Name = "txtMinRed";
            this.txtMinRed.NegativeColor = System.Drawing.Color.Black;
            this.txtMinRed.NullString = "";
            this.txtMinRed.Size = new System.Drawing.Size(64, 20);
            this.txtMinRed.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMinRed.TabIndex = 10;
            this.txtMinRed.Text = "1.00";
            // 
            // txtMaxRed
            // 
            this.txtMaxRed.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMaxRed.BeforeTouchSize = new System.Drawing.Size(64, 20);
            this.txtMaxRed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaxRed.DoubleValue = 1D;
            this.txtMaxRed.Location = new System.Drawing.Point(73, 14);
            this.txtMaxRed.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMaxRed.Name = "txtMaxRed";
            this.txtMaxRed.NegativeColor = System.Drawing.Color.Black;
            this.txtMaxRed.NullString = "";
            this.txtMaxRed.Size = new System.Drawing.Size(64, 20);
            this.txtMaxRed.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMaxRed.TabIndex = 11;
            this.txtMaxRed.Text = "1.00";
            // 
            // txtMaxGreen
            // 
            this.txtMaxGreen.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMaxGreen.BeforeTouchSize = new System.Drawing.Size(64, 20);
            this.txtMaxGreen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaxGreen.DoubleValue = 1D;
            this.txtMaxGreen.Location = new System.Drawing.Point(73, 51);
            this.txtMaxGreen.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMaxGreen.Name = "txtMaxGreen";
            this.txtMaxGreen.NegativeColor = System.Drawing.Color.Black;
            this.txtMaxGreen.NullString = "";
            this.txtMaxGreen.Size = new System.Drawing.Size(64, 20);
            this.txtMaxGreen.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMaxGreen.TabIndex = 13;
            this.txtMaxGreen.Text = "1.00";
            // 
            // txtMinGreen
            // 
            this.txtMinGreen.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMinGreen.BeforeTouchSize = new System.Drawing.Size(64, 20);
            this.txtMinGreen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMinGreen.DoubleValue = 1D;
            this.txtMinGreen.Location = new System.Drawing.Point(3, 51);
            this.txtMinGreen.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMinGreen.Name = "txtMinGreen";
            this.txtMinGreen.NegativeColor = System.Drawing.Color.Black;
            this.txtMinGreen.NullString = "";
            this.txtMinGreen.Size = new System.Drawing.Size(64, 20);
            this.txtMinGreen.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMinGreen.TabIndex = 12;
            this.txtMinGreen.Text = "1.00";
            // 
            // txtMaxBlue
            // 
            this.txtMaxBlue.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMaxBlue.BeforeTouchSize = new System.Drawing.Size(64, 20);
            this.txtMaxBlue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaxBlue.DoubleValue = 1D;
            this.txtMaxBlue.Location = new System.Drawing.Point(73, 90);
            this.txtMaxBlue.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMaxBlue.Name = "txtMaxBlue";
            this.txtMaxBlue.NegativeColor = System.Drawing.Color.Black;
            this.txtMaxBlue.NullString = "";
            this.txtMaxBlue.Size = new System.Drawing.Size(64, 20);
            this.txtMaxBlue.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMaxBlue.TabIndex = 15;
            this.txtMaxBlue.Text = "1.00";
            // 
            // txtMinBlue
            // 
            this.txtMinBlue.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMinBlue.BeforeTouchSize = new System.Drawing.Size(64, 20);
            this.txtMinBlue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMinBlue.DoubleValue = 1D;
            this.txtMinBlue.Location = new System.Drawing.Point(3, 90);
            this.txtMinBlue.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMinBlue.Name = "txtMinBlue";
            this.txtMinBlue.NegativeColor = System.Drawing.Color.Black;
            this.txtMinBlue.NullString = "";
            this.txtMinBlue.Size = new System.Drawing.Size(64, 20);
            this.txtMinBlue.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMinBlue.TabIndex = 14;
            this.txtMinBlue.Text = "1.00";
            // 
            // btnRedDefault
            // 
            this.btnRedDefault.BeforeTouchSize = new System.Drawing.Size(59, 23);
            this.btnRedDefault.IsBackStageButton = false;
            this.btnRedDefault.Location = new System.Drawing.Point(143, 11);
            this.btnRedDefault.Name = "btnRedDefault";
            this.btnRedDefault.Size = new System.Drawing.Size(59, 23);
            this.btnRedDefault.TabIndex = 18;
            this.btnRedDefault.Text = "Default";
            this.btnRedDefault.Click += new System.EventHandler(this.BandSetDefaultClick);
            // 
            // btnRedCustom
            // 
            this.btnRedCustom.BeforeTouchSize = new System.Drawing.Size(59, 23);
            this.btnRedCustom.IsBackStageButton = false;
            this.btnRedCustom.Location = new System.Drawing.Point(208, 11);
            this.btnRedCustom.Name = "btnRedCustom";
            this.btnRedCustom.Size = new System.Drawing.Size(59, 23);
            this.btnRedCustom.TabIndex = 19;
            this.btnRedCustom.Text = "Custom";
            this.btnRedCustom.Click += new System.EventHandler(this.BandSetCustomClick);
            // 
            // btnGreenCustom
            // 
            this.btnGreenCustom.BeforeTouchSize = new System.Drawing.Size(59, 23);
            this.btnGreenCustom.IsBackStageButton = false;
            this.btnGreenCustom.Location = new System.Drawing.Point(208, 48);
            this.btnGreenCustom.Name = "btnGreenCustom";
            this.btnGreenCustom.Size = new System.Drawing.Size(59, 23);
            this.btnGreenCustom.TabIndex = 21;
            this.btnGreenCustom.Text = "Custom";
            this.btnGreenCustom.Click += new System.EventHandler(this.BandSetCustomClick);
            // 
            // btnGreenDefault
            // 
            this.btnGreenDefault.BeforeTouchSize = new System.Drawing.Size(59, 23);
            this.btnGreenDefault.IsBackStageButton = false;
            this.btnGreenDefault.Location = new System.Drawing.Point(143, 48);
            this.btnGreenDefault.Name = "btnGreenDefault";
            this.btnGreenDefault.Size = new System.Drawing.Size(59, 23);
            this.btnGreenDefault.TabIndex = 20;
            this.btnGreenDefault.Text = "Default";
            this.btnGreenDefault.Click += new System.EventHandler(this.BandSetDefaultClick);
            // 
            // btnBlueCustom
            // 
            this.btnBlueCustom.BeforeTouchSize = new System.Drawing.Size(59, 23);
            this.btnBlueCustom.IsBackStageButton = false;
            this.btnBlueCustom.Location = new System.Drawing.Point(208, 87);
            this.btnBlueCustom.Name = "btnBlueCustom";
            this.btnBlueCustom.Size = new System.Drawing.Size(59, 23);
            this.btnBlueCustom.TabIndex = 23;
            this.btnBlueCustom.Text = "Custom";
            this.btnBlueCustom.Click += new System.EventHandler(this.BandSetCustomClick);
            // 
            // btnBlueDefault
            // 
            this.btnBlueDefault.BeforeTouchSize = new System.Drawing.Size(59, 23);
            this.btnBlueDefault.IsBackStageButton = false;
            this.btnBlueDefault.Location = new System.Drawing.Point(143, 87);
            this.btnBlueDefault.Name = "btnBlueDefault";
            this.btnBlueDefault.Size = new System.Drawing.Size(59, 23);
            this.btnBlueDefault.TabIndex = 22;
            this.btnBlueDefault.Text = "Default";
            this.btnBlueDefault.Click += new System.EventHandler(this.BandSetDefaultClick);
            // 
            // btnAllDefault
            // 
            this.btnAllDefault.BeforeTouchSize = new System.Drawing.Size(77, 23);
            this.btnAllDefault.IsBackStageButton = false;
            this.btnAllDefault.Location = new System.Drawing.Point(107, 124);
            this.btnAllDefault.Name = "btnAllDefault";
            this.btnAllDefault.Size = new System.Drawing.Size(77, 23);
            this.btnAllDefault.TabIndex = 26;
            this.btnAllDefault.Text = "All default";
            this.btnAllDefault.Click += new System.EventHandler(this.SetAllDefaultClick);
            // 
            // btnAllCustom
            // 
            this.btnAllCustom.BeforeTouchSize = new System.Drawing.Size(77, 23);
            this.btnAllCustom.IsBackStageButton = false;
            this.btnAllCustom.Location = new System.Drawing.Point(190, 124);
            this.btnAllCustom.Name = "btnAllCustom";
            this.btnAllCustom.Size = new System.Drawing.Size(77, 23);
            this.btnAllCustom.TabIndex = 27;
            this.btnAllCustom.Text = "All custom";
            this.btnAllCustom.Click += new System.EventHandler(this.SetAllCustomClick);
            // 
            // chkCustomMinMax
            // 
            this.chkCustomMinMax.AutoSize = true;
            this.chkCustomMinMax.Location = new System.Drawing.Point(17, 16);
            this.chkCustomMinMax.Name = "chkCustomMinMax";
            this.chkCustomMinMax.Size = new System.Drawing.Size(165, 17);
            this.chkCustomMinMax.TabIndex = 28;
            this.chkCustomMinMax.Text = "Use custom min / max values";
            this.chkCustomMinMax.UseVisualStyleBackColor = true;
            this.chkCustomMinMax.CheckedChanged += new System.EventHandler(this.chkCustomMinMax_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtMinRed);
            this.panel1.Controls.Add(this.txtMaxRed);
            this.panel1.Controls.Add(this.btnAllCustom);
            this.panel1.Controls.Add(this.txtMinGreen);
            this.panel1.Controls.Add(this.btnAllDefault);
            this.panel1.Controls.Add(this.txtMaxGreen);
            this.panel1.Controls.Add(this.txtMinBlue);
            this.panel1.Controls.Add(this.txtMaxBlue);
            this.panel1.Controls.Add(this.btnBlueCustom);
            this.panel1.Controls.Add(this.btnBlueDefault);
            this.panel1.Controls.Add(this.btnGreenCustom);
            this.panel1.Controls.Add(this.btnRedDefault);
            this.panel1.Controls.Add(this.btnGreenDefault);
            this.panel1.Controls.Add(this.btnRedCustom);
            this.panel1.Location = new System.Drawing.Point(287, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 192);
            this.panel1.TabIndex = 29;
            this.panel1.Visible = false;
            // 
            // RgbBandControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkCustomMinMax);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDefaultMapping);
            this.Controls.Add(this.cboAlpha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboBlue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboGreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRed);
            this.Controls.Add(this.label1);
            this.Name = "RgbBandControl";
            this.Size = new System.Drawing.Size(566, 229);
            ((System.ComponentModel.ISupportInitialize)(this.cboRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinBlue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboRed;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboGreen;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboBlue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboAlpha;
        private Syncfusion.Windows.Forms.ButtonAdv btnDefaultMapping;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMinRed;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMaxRed;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMaxGreen;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMinGreen;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMaxBlue;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMinBlue;
        private Syncfusion.Windows.Forms.ButtonAdv btnRedDefault;
        private Syncfusion.Windows.Forms.ButtonAdv btnRedCustom;
        private Syncfusion.Windows.Forms.ButtonAdv btnGreenCustom;
        private Syncfusion.Windows.Forms.ButtonAdv btnGreenDefault;
        private Syncfusion.Windows.Forms.ButtonAdv btnBlueCustom;
        private Syncfusion.Windows.Forms.ButtonAdv btnBlueDefault;
        private Syncfusion.Windows.Forms.ButtonAdv btnAllDefault;
        private Syncfusion.Windows.Forms.ButtonAdv btnAllCustom;
        private System.Windows.Forms.CheckBox chkCustomMinMax;
        private System.Windows.Forms.Panel panel1;
    }
}
