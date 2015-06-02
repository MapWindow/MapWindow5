using System.Windows.Forms;

namespace MW5.Configuration
{
    partial class RasterConfigPage
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
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this.chkRandomColorScheme = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDefaultColorScheme = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.label11 = new System.Windows.Forms.Label();
            this.cboUpsampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboDownsampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label12 = new System.Windows.Forms.Label();
            this.chkCreateColorScheme = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefaultColorScheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUpsampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDownsampling)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.chkCreateColorScheme);
            this.configPanelControl1.Controls.Add(this.chkRandomColorScheme);
            this.configPanelControl1.Controls.Add(this.label1);
            this.configPanelControl1.Controls.Add(this.cboDefaultColorScheme);
            this.configPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl1.HeaderText = "Rendering";
            this.configPanelControl1.Location = new System.Drawing.Point(0, 143);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(394, 129);
            this.configPanelControl1.TabIndex = 12;
            // 
            // chkRandomColorScheme
            // 
            this.chkRandomColorScheme.AutoSize = true;
            this.chkRandomColorScheme.Location = new System.Drawing.Point(162, 98);
            this.chkRandomColorScheme.Name = "chkRandomColorScheme";
            this.chkRandomColorScheme.Size = new System.Drawing.Size(152, 17);
            this.chkRandomColorScheme.TabIndex = 16;
            this.chkRandomColorScheme.Text = "User random color scheme";
            this.chkRandomColorScheme.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Default color scheme";
            // 
            // cboDefaultColorScheme
            // 
            this.cboDefaultColorScheme.BeforeTouchSize = new System.Drawing.Size(212, 21);
            this.cboDefaultColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultColorScheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboDefaultColorScheme.Location = new System.Drawing.Point(162, 71);
            this.cboDefaultColorScheme.Name = "cboDefaultColorScheme";
            this.cboDefaultColorScheme.Size = new System.Drawing.Size(212, 21);
            this.cboDefaultColorScheme.TabIndex = 4;
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.label11);
            this.configPanelControl2.Controls.Add(this.cboUpsampling);
            this.configPanelControl2.Controls.Add(this.cboDownsampling);
            this.configPanelControl2.Controls.Add(this.label12);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Default settings";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(394, 143);
            this.configPanelControl2.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Upsampling mode";
            // 
            // cboUpsampling
            // 
            this.cboUpsampling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUpsampling.BeforeTouchSize = new System.Drawing.Size(207, 21);
            this.cboUpsampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUpsampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboUpsampling.Location = new System.Drawing.Point(146, 48);
            this.cboUpsampling.Name = "cboUpsampling";
            this.cboUpsampling.Size = new System.Drawing.Size(207, 21);
            this.cboUpsampling.TabIndex = 48;
            // 
            // cboDownsampling
            // 
            this.cboDownsampling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDownsampling.BeforeTouchSize = new System.Drawing.Size(207, 21);
            this.cboDownsampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDownsampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboDownsampling.Location = new System.Drawing.Point(146, 91);
            this.cboDownsampling.Name = "cboDownsampling";
            this.cboDownsampling.Size = new System.Drawing.Size(207, 21);
            this.cboDownsampling.TabIndex = 50;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Downsampling mode";
            // 
            // chkCreateColorScheme
            // 
            this.chkCreateColorScheme.AutoSize = true;
            this.chkCreateColorScheme.Location = new System.Drawing.Point(22, 39);
            this.chkCreateColorScheme.Name = "chkCreateColorScheme";
            this.chkCreateColorScheme.Size = new System.Drawing.Size(323, 17);
            this.chkCreateColorScheme.TabIndex = 17;
            this.chkCreateColorScheme.Text = "Use color scheme for new grids (otherwise greyscale rendering)";
            this.chkCreateColorScheme.UseVisualStyleBackColor = true;
            // 
            // RasterConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl1);
            this.Controls.Add(this.configPanelControl2);
            this.Name = "RasterConfigPage";
            this.Size = new System.Drawing.Size(394, 281);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefaultColorScheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUpsampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDownsampling)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl1;
        private UI.Controls.ConfigPanelControl configPanelControl2;
        private Label label11;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboUpsampling;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboDownsampling;
        private Label label12;
        private CheckBox chkRandomColorScheme;
        private Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboDefaultColorScheme;
        private CheckBox chkCreateColorScheme;
    }
}
