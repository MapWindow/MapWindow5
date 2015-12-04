namespace MW5.Plugins.Printing.Controls
{
    partial class PrintingConfigPage
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
            this.cboUnits = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboOrientation = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.txtFormat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrientation)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.txtFormat);
            this.configPanelControl2.Controls.Add(this.cboOrientation);
            this.configPanelControl2.Controls.Add(this.label3);
            this.configPanelControl2.Controls.Add(this.label2);
            this.configPanelControl2.Controls.Add(this.cboUnits);
            this.configPanelControl2.Controls.Add(this.label1);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Layout options";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(434, 178);
            this.configPanelControl2.TabIndex = 2;
            // 
            // cboUnits
            // 
            this.cboUnits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUnits.BeforeTouchSize = new System.Drawing.Size(260, 21);
            this.cboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboUnits.Location = new System.Drawing.Point(141, 49);
            this.cboUnits.Name = "cboUnits";
            this.cboUnits.Size = new System.Drawing.Size(260, 21);
            this.cboUnits.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paper units";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Paper format";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Paper orientation";
            // 
            // cboOrientation
            // 
            this.cboOrientation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOrientation.BeforeTouchSize = new System.Drawing.Size(260, 21);
            this.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOrientation.Location = new System.Drawing.Point(141, 134);
            this.cboOrientation.Name = "cboOrientation";
            this.cboOrientation.Size = new System.Drawing.Size(260, 21);
            this.cboOrientation.TabIndex = 6;
            // 
            // txtFormat
            // 
            this.txtFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormat.Location = new System.Drawing.Point(141, 93);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.ReadOnly = true;
            this.txtFormat.Size = new System.Drawing.Size(260, 20);
            this.txtFormat.TabIndex = 7;
            // 
            // PrintingConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configPanelControl2);
            this.Name = "PrintingConfigPage";
            this.Size = new System.Drawing.Size(434, 195);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrientation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboOrientation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFormat;
    }
}
