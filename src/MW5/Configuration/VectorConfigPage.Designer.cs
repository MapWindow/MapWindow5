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
            this.cboProjectionAbsence = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboProjectionMismatch = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkSpatialIndexDialog = new System.Windows.Forms.CheckBox();
            this.chkCreateSpatialIndex = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.udSpatialIndexCount = new System.Windows.Forms.NumericUpDown();
            this.configPanelControl3 = new MW5.UI.Controls.ConfigPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionMismatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpatialIndexCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).BeginInit();
            this.configPanelControl3.SuspendLayout();
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
            // chkSpatialIndexDialog
            // 
            this.chkSpatialIndexDialog.Location = new System.Drawing.Point(21, 45);
            this.chkSpatialIndexDialog.Name = "chkSpatialIndexDialog";
            this.chkSpatialIndexDialog.Size = new System.Drawing.Size(292, 21);
            this.chkSpatialIndexDialog.TabIndex = 9;
            this.chkSpatialIndexDialog.Text = "Show spatial index creation dialog";
            // 
            // chkCreateSpatialIndex
            // 
            this.chkCreateSpatialIndex.Location = new System.Drawing.Point(21, 72);
            this.chkCreateSpatialIndex.Name = "chkCreateSpatialIndex";
            this.chkCreateSpatialIndex.Size = new System.Drawing.Size(277, 21);
            this.chkCreateSpatialIndex.TabIndex = 10;
            this.chkCreateSpatialIndex.Text = "Create spatial index on opening (if it is missing)";
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
            // VectorConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl3);
            this.Name = "VectorConfigPage";
            this.Size = new System.Drawing.Size(394, 154);
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionMismatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSpatialIndexCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).EndInit();
            this.configPanelControl3.ResumeLayout(false);
            this.configPanelControl3.PerformLayout();
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
    }
}
