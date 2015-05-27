namespace MW5.Configuration
{
    partial class LayerConfigPage
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
            this.configPanelControl3 = new MW5.UI.Controls.ConfigPanelControl();
            this.udSpatialIndexCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCreateSpatialIndex = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.chkSpatialIndexDialog = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this.cboPyramidsSampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPyramidCompression = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkCreatePyramids = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.chkPyramidsDialog = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.cboProjectionAbsence = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProjectionMismatch = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkProjectionDialog = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).BeginInit();
            this.configPanelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSpatialIndexCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCreateSpatialIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSpatialIndexDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPyramidsSampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPyramidCompression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCreatePyramids)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPyramidsDialog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionMismatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProjectionDialog)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl3
            // 
            this.configPanelControl3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl3.Controls.Add(this.udSpatialIndexCount);
            this.configPanelControl3.Controls.Add(this.label2);
            this.configPanelControl3.Controls.Add(this.chkCreateSpatialIndex);
            this.configPanelControl3.Controls.Add(this.chkSpatialIndexDialog);
            this.configPanelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl3.HeaderText = "Spatial index";
            this.configPanelControl3.Location = new System.Drawing.Point(0, 350);
            this.configPanelControl3.Name = "configPanelControl3";
            this.configPanelControl3.Size = new System.Drawing.Size(394, 140);
            this.configPanelControl3.TabIndex = 13;
            // 
            // udSpatialIndexCount
            // 
            this.udSpatialIndexCount.Enabled = false;
            this.udSpatialIndexCount.Location = new System.Drawing.Point(236, 106);
            this.udSpatialIndexCount.Name = "udSpatialIndexCount";
            this.udSpatialIndexCount.Size = new System.Drawing.Size(74, 20);
            this.udSpatialIndexCount.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Number of geometries to create index";
            // 
            // chkCreateSpatialIndex
            // 
            this.chkCreateSpatialIndex.BeforeTouchSize = new System.Drawing.Size(277, 21);
            this.chkCreateSpatialIndex.Location = new System.Drawing.Point(21, 72);
            this.chkCreateSpatialIndex.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkCreateSpatialIndex.Name = "chkCreateSpatialIndex";
            this.chkCreateSpatialIndex.Size = new System.Drawing.Size(277, 21);
            this.chkCreateSpatialIndex.TabIndex = 10;
            this.chkCreateSpatialIndex.Text = "Create spatial index on opening (if it is missing)";
            this.chkCreateSpatialIndex.ThemesEnabled = false;
            // 
            // chkSpatialIndexDialog
            // 
            this.chkSpatialIndexDialog.BeforeTouchSize = new System.Drawing.Size(292, 21);
            this.chkSpatialIndexDialog.Location = new System.Drawing.Point(21, 45);
            this.chkSpatialIndexDialog.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkSpatialIndexDialog.Name = "chkSpatialIndexDialog";
            this.chkSpatialIndexDialog.Size = new System.Drawing.Size(292, 21);
            this.chkSpatialIndexDialog.TabIndex = 9;
            this.chkSpatialIndexDialog.Text = "Show spatial index creation dialog";
            this.chkSpatialIndexDialog.ThemesEnabled = false;
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.cboPyramidsSampling);
            this.configPanelControl1.Controls.Add(this.label4);
            this.configPanelControl1.Controls.Add(this.label1);
            this.configPanelControl1.Controls.Add(this.cboPyramidCompression);
            this.configPanelControl1.Controls.Add(this.chkCreatePyramids);
            this.configPanelControl1.Controls.Add(this.chkPyramidsDialog);
            this.configPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl1.HeaderText = "Raster pyramids";
            this.configPanelControl1.Location = new System.Drawing.Point(0, 163);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(394, 187);
            this.configPanelControl1.TabIndex = 12;
            // 
            // cboPyramidsSampling
            // 
            this.cboPyramidsSampling.BeforeTouchSize = new System.Drawing.Size(166, 21);
            this.cboPyramidsSampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPyramidsSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboPyramidsSampling.Location = new System.Drawing.Point(147, 139);
            this.cboPyramidsSampling.Name = "cboPyramidsSampling";
            this.cboPyramidsSampling.Size = new System.Drawing.Size(166, 21);
            this.cboPyramidsSampling.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Pyramids sampling";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pyramids compression";
            // 
            // cboPyramidCompression
            // 
            this.cboPyramidCompression.BeforeTouchSize = new System.Drawing.Size(166, 21);
            this.cboPyramidCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPyramidCompression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboPyramidCompression.Location = new System.Drawing.Point(147, 105);
            this.cboPyramidCompression.Name = "cboPyramidCompression";
            this.cboPyramidCompression.Size = new System.Drawing.Size(166, 21);
            this.cboPyramidCompression.TabIndex = 11;
            // 
            // chkCreatePyramids
            // 
            this.chkCreatePyramids.BeforeTouchSize = new System.Drawing.Size(277, 21);
            this.chkCreatePyramids.Location = new System.Drawing.Point(21, 72);
            this.chkCreatePyramids.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkCreatePyramids.Name = "chkCreatePyramids";
            this.chkCreatePyramids.Size = new System.Drawing.Size(277, 21);
            this.chkCreatePyramids.TabIndex = 10;
            this.chkCreatePyramids.Text = "Create pyramids on opening (if they are missing)";
            this.chkCreatePyramids.ThemesEnabled = false;
            // 
            // chkPyramidsDialog
            // 
            this.chkPyramidsDialog.BeforeTouchSize = new System.Drawing.Size(188, 21);
            this.chkPyramidsDialog.Location = new System.Drawing.Point(21, 45);
            this.chkPyramidsDialog.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkPyramidsDialog.Name = "chkPyramidsDialog";
            this.chkPyramidsDialog.Size = new System.Drawing.Size(188, 21);
            this.chkPyramidsDialog.TabIndex = 9;
            this.chkPyramidsDialog.Text = "Show pyramid creation dialog";
            this.chkPyramidsDialog.ThemesEnabled = false;
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.cboProjectionAbsence);
            this.configPanelControl2.Controls.Add(this.label3);
            this.configPanelControl2.Controls.Add(this.label5);
            this.configPanelControl2.Controls.Add(this.cboProjectionMismatch);
            this.configPanelControl2.Controls.Add(this.chkProjectionDialog);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Projections";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(394, 163);
            this.configPanelControl2.TabIndex = 14;
            // 
            // cboProjectionAbsence
            // 
            this.cboProjectionAbsence.BeforeTouchSize = new System.Drawing.Size(166, 21);
            this.cboProjectionAbsence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectionAbsence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboProjectionAbsence.Location = new System.Drawing.Point(144, 115);
            this.cboProjectionAbsence.Name = "cboProjectionAbsence";
            this.cboProjectionAbsence.Size = new System.Drawing.Size(166, 21);
            this.cboProjectionAbsence.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Absence behavior";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mismatch behavior";
            // 
            // cboProjectionMismatch
            // 
            this.cboProjectionMismatch.BeforeTouchSize = new System.Drawing.Size(166, 21);
            this.cboProjectionMismatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectionMismatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboProjectionMismatch.Location = new System.Drawing.Point(144, 81);
            this.cboProjectionMismatch.Name = "cboProjectionMismatch";
            this.cboProjectionMismatch.Size = new System.Drawing.Size(166, 21);
            this.cboProjectionMismatch.TabIndex = 15;
            // 
            // chkProjectionDialog
            // 
            this.chkProjectionDialog.BeforeTouchSize = new System.Drawing.Size(292, 21);
            this.chkProjectionDialog.Location = new System.Drawing.Point(21, 45);
            this.chkProjectionDialog.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkProjectionDialog.Name = "chkProjectionDialog";
            this.chkProjectionDialog.Size = new System.Drawing.Size(292, 21);
            this.chkProjectionDialog.TabIndex = 9;
            this.chkProjectionDialog.Text = "Show projection mismatch dialog";
            this.chkProjectionDialog.ThemesEnabled = false;
            // 
            // LayerConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl3);
            this.Controls.Add(this.configPanelControl1);
            this.Controls.Add(this.configPanelControl2);
            this.Name = "LayerConfigPage";
            this.Size = new System.Drawing.Size(394, 498);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).EndInit();
            this.configPanelControl3.ResumeLayout(false);
            this.configPanelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSpatialIndexCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCreateSpatialIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSpatialIndexDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPyramidsSampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPyramidCompression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCreatePyramids)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPyramidsDialog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionMismatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkProjectionDialog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl3;
        private System.Windows.Forms.NumericUpDown udSpatialIndexCount;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkCreateSpatialIndex;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkSpatialIndexDialog;
        private UI.Controls.ConfigPanelControl configPanelControl1;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboPyramidCompression;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkCreatePyramids;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkPyramidsDialog;
        private UI.Controls.ConfigPanelControl configPanelControl2;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkProjectionDialog;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboPyramidsSampling;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboProjectionAbsence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboProjectionMismatch;
    }
}
