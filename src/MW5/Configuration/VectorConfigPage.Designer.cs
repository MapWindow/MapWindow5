using System.Windows.Forms;

namespace MW5.Configuration
{
    partial class VectorConfigPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VectorConfigPage));
            this.cboProjectionAbsence = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboProjectionMismatch = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this.chkFastMode = new System.Windows.Forms.CheckBox();
            this.chkCacheDbfRecords = new System.Windows.Forms.CheckBox();
            this.chkCacheRenderingData = new System.Windows.Forms.CheckBox();
            this.configPanelControl3 = new MW5.UI.Controls.ConfigPanelControl();
            this.udSpatialIndexCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCreateSpatialIndex = new System.Windows.Forms.CheckBox();
            this.chkSpatialIndexDialog = new System.Windows.Forms.CheckBox();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaxOgrCount = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionMismatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).BeginInit();
            this.configPanelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSpatialIndexCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxOgrCount)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProjectionAbsence
            // 
            this.cboProjectionAbsence.BeforeTouchSize = new System.Drawing.Size(166, 21);
            this.cboProjectionAbsence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectionAbsence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboProjectionAbsence.Location = new System.Drawing.Point(147, 143);
            this.cboProjectionAbsence.Name = "cboProjectionAbsence";
            this.cboProjectionAbsence.Size = new System.Drawing.Size(166, 21);
            this.cboProjectionAbsence.TabIndex = 18;
            // 
            // cboProjectionMismatch
            // 
            this.cboProjectionMismatch.BeforeTouchSize = new System.Drawing.Size(166, 21);
            this.cboProjectionMismatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectionMismatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboProjectionMismatch.Location = new System.Drawing.Point(144, 72);
            this.cboProjectionMismatch.Name = "cboProjectionMismatch";
            this.cboProjectionMismatch.Size = new System.Drawing.Size(166, 21);
            this.cboProjectionMismatch.TabIndex = 15;
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.chkFastMode);
            this.configPanelControl1.Controls.Add(this.chkCacheDbfRecords);
            this.configPanelControl1.Controls.Add(this.chkCacheRenderingData);
            this.configPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl1.HeaderText = "Performance and caching";
            this.configPanelControl1.Location = new System.Drawing.Point(0, 143);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(394, 122);
            this.configPanelControl1.TabIndex = 14;
            // 
            // chkFastMode
            // 
            this.chkFastMode.Enabled = false;
            this.chkFastMode.Location = new System.Drawing.Point(21, 34);
            this.chkFastMode.Name = "chkFastMode";
            this.chkFastMode.Size = new System.Drawing.Size(292, 21);
            this.chkFastMode.TabIndex = 12;
            this.chkFastMode.Text = "Fast mode (don\'t use COM points)";
            // 
            // chkCacheDbfRecords
            // 
            this.chkCacheDbfRecords.Location = new System.Drawing.Point(21, 88);
            this.chkCacheDbfRecords.Name = "chkCacheDbfRecords";
            this.chkCacheDbfRecords.Size = new System.Drawing.Size(292, 21);
            this.chkCacheDbfRecords.TabIndex = 11;
            this.chkCacheDbfRecords.Text = "Cache attribute table records";
            // 
            // chkCacheRenderingData
            // 
            this.chkCacheRenderingData.Location = new System.Drawing.Point(21, 61);
            this.chkCacheRenderingData.Name = "chkCacheRenderingData";
            this.chkCacheRenderingData.Size = new System.Drawing.Size(292, 21);
            this.chkCacheRenderingData.TabIndex = 10;
            this.chkCacheRenderingData.Text = "Cache rendering data (disk based mode)";
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
            this.configPanelControl3.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl3.Name = "configPanelControl3";
            this.configPanelControl3.Size = new System.Drawing.Size(394, 143);
            this.configPanelControl3.TabIndex = 13;
            // 
            // udSpatialIndexCount
            // 
            this.udSpatialIndexCount.Location = new System.Drawing.Point(236, 106);
            this.udSpatialIndexCount.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.udSpatialIndexCount.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udSpatialIndexCount.Name = "udSpatialIndexCount";
            this.udSpatialIndexCount.Size = new System.Drawing.Size(74, 20);
            this.udSpatialIndexCount.TabIndex = 13;
            this.udSpatialIndexCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
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
            this.chkCreateSpatialIndex.Location = new System.Drawing.Point(21, 72);
            this.chkCreateSpatialIndex.Name = "chkCreateSpatialIndex";
            this.chkCreateSpatialIndex.Size = new System.Drawing.Size(277, 21);
            this.chkCreateSpatialIndex.TabIndex = 10;
            this.chkCreateSpatialIndex.Text = "Create spatial index on opening (if it is missing)";
            // 
            // chkSpatialIndexDialog
            // 
            this.chkSpatialIndexDialog.Location = new System.Drawing.Point(21, 45);
            this.chkSpatialIndexDialog.Name = "chkSpatialIndexDialog";
            this.chkSpatialIndexDialog.Size = new System.Drawing.Size(292, 21);
            this.chkSpatialIndexDialog.TabIndex = 9;
            this.chkSpatialIndexDialog.Text = "Show spatial index creation dialog";
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.label3);
            this.configPanelControl2.Controls.Add(this.label1);
            this.configPanelControl2.Controls.Add(this.txtMaxOgrCount);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "OGR datasources";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 265);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(394, 155);
            this.configPanelControl2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(18, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 57);
            this.label3.TabIndex = 3;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum number of features allowed to be loaded from the source:";
            // 
            // txtMaxOgrCount
            // 
            this.txtMaxOgrCount.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMaxOgrCount.BeforeTouchSize = new System.Drawing.Size(301, 20);
            this.txtMaxOgrCount.BorderColor = System.Drawing.Color.LightGray;
            this.txtMaxOgrCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaxOgrCount.IntegerValue = ((long)(1));
            this.txtMaxOgrCount.Location = new System.Drawing.Point(21, 62);
            this.txtMaxOgrCount.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMaxOgrCount.MinValue = ((long)(0));
            this.txtMaxOgrCount.Name = "txtMaxOgrCount";
            this.txtMaxOgrCount.NullString = "";
            this.txtMaxOgrCount.Size = new System.Drawing.Size(100, 20);
            this.txtMaxOgrCount.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMaxOgrCount.TabIndex = 1;
            this.txtMaxOgrCount.Text = "1";
            // 
            // VectorConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl2);
            this.Controls.Add(this.configPanelControl1);
            this.Controls.Add(this.configPanelControl3);
            this.Name = "VectorConfigPage";
            this.Size = new System.Drawing.Size(394, 427);
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionMismatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).EndInit();
            this.configPanelControl3.ResumeLayout(false);
            this.configPanelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSpatialIndexCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxOgrCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboProjectionAbsence;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboProjectionMismatch;
        private CheckBox chkSpatialIndexDialog;
        private CheckBox chkCreateSpatialIndex;
        private Label label2;
        private NumericUpDown udSpatialIndexCount;
        private UI.Controls.ConfigPanelControl configPanelControl3;
        private UI.Controls.ConfigPanelControl configPanelControl1;
        private CheckBox chkCacheDbfRecords;
        private CheckBox chkCacheRenderingData;
        private CheckBox chkFastMode;
        private UI.Controls.ConfigPanelControl configPanelControl2;
        private Label label3;
        private Label label1;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox txtMaxOgrCount;
    }
}
