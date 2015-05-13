namespace MW5.Plugins.Symbology.Controls
{
    partial class RasterColorSchemeControl
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
            this.groupMinMax = new System.Windows.Forms.GroupBox();
            this.btnCalculateMinMax = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cboSelectedBand = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.txtMaximum = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMinimum = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboClassification = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnGenerateColorScheme = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRasterRendering = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkUseHistogram = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSingleBand = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.groupSingleBand = new System.Windows.Forms.GroupBox();
            this.chkAlphaRendering = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.chkHillShade = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.groupColorScheme = new System.Windows.Forms.GroupBox();
            this.chkReverse = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.colorSchemeCombo1 = new MW5.Plugins.Symbology.Controls.ImageCombo.ColorSchemeCombo();
            this.rgbBandControl1 = new MW5.Plugins.Symbology.Controls.RgbBandControl();
            this.rasterColorSchemeGrid1 = new MW5.Plugins.Symbology.Controls.RasterColorSchemeGrid();
            this.groupMinMax.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSelectedBand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClassification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRasterRendering)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSingleBand)).BeginInit();
            this.groupSingleBand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlphaRendering)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHillShade)).BeginInit();
            this.groupColorScheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkReverse)).BeginInit();
            this.SuspendLayout();
            // 
            // groupMinMax
            // 
            this.groupMinMax.Controls.Add(this.btnCalculateMinMax);
            this.groupMinMax.Controls.Add(this.cboSelectedBand);
            this.groupMinMax.Controls.Add(this.txtMaximum);
            this.groupMinMax.Controls.Add(this.label14);
            this.groupMinMax.Controls.Add(this.txtMinimum);
            this.groupMinMax.Controls.Add(this.label15);
            this.groupMinMax.Location = new System.Drawing.Point(276, 50);
            this.groupMinMax.Name = "groupMinMax";
            this.groupMinMax.Size = new System.Drawing.Size(212, 151);
            this.groupMinMax.TabIndex = 18;
            this.groupMinMax.TabStop = false;
            this.groupMinMax.Text = "Selected band";
            // 
            // btnCalculateMinMax
            // 
            this.btnCalculateMinMax.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnCalculateMinMax.IsBackStageButton = false;
            this.btnCalculateMinMax.Location = new System.Drawing.Point(120, 121);
            this.btnCalculateMinMax.Name = "btnCalculateMinMax";
            this.btnCalculateMinMax.Size = new System.Drawing.Size(75, 23);
            this.btnCalculateMinMax.TabIndex = 10;
            this.btnCalculateMinMax.Text = "Calculate";
            // 
            // cboSelectedBand
            // 
            this.cboSelectedBand.BeforeTouchSize = new System.Drawing.Size(180, 21);
            this.cboSelectedBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectedBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboSelectedBand.Location = new System.Drawing.Point(15, 31);
            this.cboSelectedBand.Name = "cboSelectedBand";
            this.cboSelectedBand.Size = new System.Drawing.Size(180, 21);
            this.cboSelectedBand.TabIndex = 4;
            this.cboSelectedBand.SelectedIndexChanged += new System.EventHandler(this.cboSelectedBand_SelectedIndexChanged);
            // 
            // txtMaximum
            // 
            this.txtMaximum.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMaximum.BeforeTouchSize = new System.Drawing.Size(101, 20);
            this.txtMaximum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaximum.DoubleValue = 1D;
            this.txtMaximum.Location = new System.Drawing.Point(94, 95);
            this.txtMaximum.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMaximum.Name = "txtMaximum";
            this.txtMaximum.NegativeColor = System.Drawing.Color.Black;
            this.txtMaximum.NullString = "";
            this.txtMaximum.Size = new System.Drawing.Size(101, 20);
            this.txtMaximum.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMaximum.TabIndex = 9;
            this.txtMaximum.Text = "1.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Minimum";
            // 
            // txtMinimum
            // 
            this.txtMinimum.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMinimum.BeforeTouchSize = new System.Drawing.Size(101, 20);
            this.txtMinimum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMinimum.DoubleValue = 1D;
            this.txtMinimum.Location = new System.Drawing.Point(94, 62);
            this.txtMinimum.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMinimum.Name = "txtMinimum";
            this.txtMinimum.NegativeColor = System.Drawing.Color.Black;
            this.txtMinimum.NullString = "";
            this.txtMinimum.Size = new System.Drawing.Size(101, 20);
            this.txtMinimum.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMinimum.TabIndex = 8;
            this.txtMinimum.Text = "1.00";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Maximum";
            // 
            // cboClassification
            // 
            this.cboClassification.BeforeTouchSize = new System.Drawing.Size(180, 21);
            this.cboClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboClassification.Location = new System.Drawing.Point(15, 31);
            this.cboClassification.Name = "cboClassification";
            this.cboClassification.Size = new System.Drawing.Size(180, 21);
            this.cboClassification.TabIndex = 19;
            // 
            // btnGenerateColorScheme
            // 
            this.btnGenerateColorScheme.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnGenerateColorScheme.IsBackStageButton = false;
            this.btnGenerateColorScheme.Location = new System.Drawing.Point(120, 95);
            this.btnGenerateColorScheme.Name = "btnGenerateColorScheme";
            this.btnGenerateColorScheme.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateColorScheme.TabIndex = 13;
            this.btnGenerateColorScheme.Text = "Generate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Rendering mode";
            // 
            // cboRasterRendering
            // 
            this.cboRasterRendering.BeforeTouchSize = new System.Drawing.Size(254, 21);
            this.cboRasterRendering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRasterRendering.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboRasterRendering.Location = new System.Drawing.Point(103, 13);
            this.cboRasterRendering.Name = "cboRasterRendering";
            this.cboRasterRendering.Size = new System.Drawing.Size(254, 21);
            this.cboRasterRendering.TabIndex = 15;
            this.cboRasterRendering.SelectedIndexChanged += new System.EventHandler(this.cboRasterRendering_SelectedIndexChanged);
            // 
            // chkUseHistogram
            // 
            this.chkUseHistogram.BeforeTouchSize = new System.Drawing.Size(133, 21);
            this.chkUseHistogram.Location = new System.Drawing.Point(370, 376);
            this.chkUseHistogram.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkUseHistogram.Name = "chkUseHistogram";
            this.chkUseHistogram.Size = new System.Drawing.Size(133, 21);
            this.chkUseHistogram.TabIndex = 14;
            this.chkUseHistogram.Text = "Use histogram";
            this.chkUseHistogram.ThemesEnabled = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Color scheme";
            // 
            // cboSingleBand
            // 
            this.cboSingleBand.BeforeTouchSize = new System.Drawing.Size(204, 21);
            this.cboSingleBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSingleBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboSingleBand.Location = new System.Drawing.Point(21, 32);
            this.cboSingleBand.Name = "cboSingleBand";
            this.cboSingleBand.Size = new System.Drawing.Size(204, 21);
            this.cboSingleBand.TabIndex = 20;
            // 
            // groupSingleBand
            // 
            this.groupSingleBand.Controls.Add(this.cboSingleBand);
            this.groupSingleBand.Location = new System.Drawing.Point(15, 251);
            this.groupSingleBand.Name = "groupSingleBand";
            this.groupSingleBand.Size = new System.Drawing.Size(243, 69);
            this.groupSingleBand.TabIndex = 21;
            this.groupSingleBand.TabStop = false;
            this.groupSingleBand.Text = "Active band";
            // 
            // chkAlphaRendering
            // 
            this.chkAlphaRendering.BeforeTouchSize = new System.Drawing.Size(107, 21);
            this.chkAlphaRendering.Location = new System.Drawing.Point(370, 349);
            this.chkAlphaRendering.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkAlphaRendering.Name = "chkAlphaRendering";
            this.chkAlphaRendering.Size = new System.Drawing.Size(107, 21);
            this.chkAlphaRendering.TabIndex = 22;
            this.chkAlphaRendering.Text = "Alpha rendering";
            this.chkAlphaRendering.ThemesEnabled = false;
            // 
            // chkHillShade
            // 
            this.chkHillShade.BeforeTouchSize = new System.Drawing.Size(88, 21);
            this.chkHillShade.Location = new System.Drawing.Point(276, 376);
            this.chkHillShade.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkHillShade.Name = "chkHillShade";
            this.chkHillShade.Size = new System.Drawing.Size(88, 21);
            this.chkHillShade.TabIndex = 23;
            this.chkHillShade.Text = "Hill shade";
            this.chkHillShade.ThemesEnabled = false;
            // 
            // groupColorScheme
            // 
            this.groupColorScheme.Controls.Add(this.cboClassification);
            this.groupColorScheme.Controls.Add(this.colorSchemeCombo1);
            this.groupColorScheme.Controls.Add(this.btnGenerateColorScheme);
            this.groupColorScheme.Location = new System.Drawing.Point(276, 207);
            this.groupColorScheme.Name = "groupColorScheme";
            this.groupColorScheme.Size = new System.Drawing.Size(212, 124);
            this.groupColorScheme.TabIndex = 24;
            this.groupColorScheme.TabStop = false;
            this.groupColorScheme.Text = "Color scheme";
            // 
            // chkReverse
            // 
            this.chkReverse.BeforeTouchSize = new System.Drawing.Size(88, 21);
            this.chkReverse.Location = new System.Drawing.Point(276, 349);
            this.chkReverse.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkReverse.Name = "chkReverse";
            this.chkReverse.Size = new System.Drawing.Size(88, 21);
            this.chkReverse.TabIndex = 25;
            this.chkReverse.Text = "Reverse";
            this.chkReverse.ThemesEnabled = false;
            // 
            // colorSchemeCombo1
            // 
            this.colorSchemeCombo1.ComboStyle = MW5.Api.Enums.SchemeType.Graduated;
            this.colorSchemeCombo1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorSchemeCombo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorSchemeCombo1.Location = new System.Drawing.Point(15, 63);
            this.colorSchemeCombo1.Name = "colorSchemeCombo1";
            this.colorSchemeCombo1.OutlineColor = System.Drawing.Color.Black;
            this.colorSchemeCombo1.SchemeTarget = MW5.Plugins.Symbology.SchemeTarget.Raster;
            this.colorSchemeCombo1.Size = new System.Drawing.Size(180, 21);
            this.colorSchemeCombo1.TabIndex = 0;
            // 
            // rgbBandControl1
            // 
            this.rgbBandControl1.Location = new System.Drawing.Point(15, 66);
            this.rgbBandControl1.Name = "rgbBandControl1";
            this.rgbBandControl1.Size = new System.Drawing.Size(243, 163);
            this.rgbBandControl1.TabIndex = 20;
            // 
            // rasterColorSchemeGrid1
            // 
            this.rasterColorSchemeGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rasterColorSchemeGrid1.AutoAdjustRowHeights = false;
            this.rasterColorSchemeGrid1.DataSource = null;
            this.rasterColorSchemeGrid1.HotTracking = false;
            this.rasterColorSchemeGrid1.HotTrackingColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.rasterColorSchemeGrid1.Location = new System.Drawing.Point(15, 66);
            this.rasterColorSchemeGrid1.Name = "rasterColorSchemeGrid1";
            this.rasterColorSchemeGrid1.ReadOnly = false;
            this.rasterColorSchemeGrid1.ShowEditors = true;
            this.rasterColorSchemeGrid1.ShowSuperTooltips = false;
            this.rasterColorSchemeGrid1.Size = new System.Drawing.Size(243, 369);
            this.rasterColorSchemeGrid1.TabIndex = 17;
            this.rasterColorSchemeGrid1.ToolTipDuration = 3000;
            this.rasterColorSchemeGrid1.ToolTipMaxWidth = 450;
            this.rasterColorSchemeGrid1.WrapText = true;
            // 
            // RasterColorSchemeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkReverse);
            this.Controls.Add(this.groupColorScheme);
            this.Controls.Add(this.chkHillShade);
            this.Controls.Add(this.chkAlphaRendering);
            this.Controls.Add(this.groupSingleBand);
            this.Controls.Add(this.rgbBandControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupMinMax);
            this.Controls.Add(this.rasterColorSchemeGrid1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboRasterRendering);
            this.Controls.Add(this.chkUseHistogram);
            this.Name = "RasterColorSchemeControl";
            this.Size = new System.Drawing.Size(500, 440);
            this.groupMinMax.ResumeLayout(false);
            this.groupMinMax.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSelectedBand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClassification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRasterRendering)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUseHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSingleBand)).EndInit();
            this.groupSingleBand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAlphaRendering)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHillShade)).EndInit();
            this.groupColorScheme.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkReverse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupMinMax;
        private Syncfusion.Windows.Forms.ButtonAdv btnGenerateColorScheme;
        private ImageCombo.ColorSchemeCombo colorSchemeCombo1;
        private System.Windows.Forms.Label label14;
        private RasterColorSchemeGrid rasterColorSchemeGrid1;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboRasterRendering;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkUseHistogram;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboClassification;
        private System.Windows.Forms.Label label2;
        private RgbBandControl rgbBandControl1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboSingleBand;
        private System.Windows.Forms.GroupBox groupSingleBand;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkAlphaRendering;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkHillShade;
        private Syncfusion.Windows.Forms.ButtonAdv btnCalculateMinMax;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboSelectedBand;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMaximum;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMinimum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupColorScheme;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkReverse;
    }
}
