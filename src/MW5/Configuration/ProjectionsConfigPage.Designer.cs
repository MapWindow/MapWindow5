using System.Windows.Forms;

namespace MW5.Configuration
{
    partial class ProjectionsConfigPage
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
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cboProjectionAbsence = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProjectionMismatch = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkProjectionDialog = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionAbsence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionMismatch)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.checkBox1);
            this.configPanelControl2.Controls.Add(this.cboProjectionAbsence);
            this.configPanelControl2.Controls.Add(this.label3);
            this.configPanelControl2.Controls.Add(this.label5);
            this.configPanelControl2.Controls.Add(this.cboProjectionMismatch);
            this.configPanelControl2.Controls.Add(this.chkProjectionDialog);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Projections";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(394, 193);
            this.configPanelControl2.TabIndex = 14;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(21, 116);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(277, 21);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Show projection absence dialog";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Absence behavior";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 80);
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
            this.cboProjectionMismatch.Location = new System.Drawing.Point(144, 72);
            this.cboProjectionMismatch.Name = "cboProjectionMismatch";
            this.cboProjectionMismatch.Size = new System.Drawing.Size(166, 21);
            this.cboProjectionMismatch.TabIndex = 15;
            // 
            // chkProjectionDialog
            // 
            this.chkProjectionDialog.Location = new System.Drawing.Point(21, 45);
            this.chkProjectionDialog.Name = "chkProjectionDialog";
            this.chkProjectionDialog.Size = new System.Drawing.Size(292, 21);
            this.chkProjectionDialog.TabIndex = 9;
            this.chkProjectionDialog.Text = "Show projection mismatch dialog";
            // 
            // ProjectionsConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl2);
            this.Name = "ProjectionsConfigPage";
            this.Size = new System.Drawing.Size(394, 198);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionAbsence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectionMismatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl2;
        private CheckBox chkProjectionDialog;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboProjectionAbsence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboProjectionMismatch;
        private CheckBox checkBox1;
    }
}
