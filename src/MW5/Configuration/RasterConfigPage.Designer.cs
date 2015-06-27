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
            this.chkUseHistogram = new System.Windows.Forms.CheckBox();
            this.chkCreateColorScheme = new System.Windows.Forms.CheckBox();
            this.chkRandomColorScheme = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDefaultColorScheme = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.label11 = new System.Windows.Forms.Label();
            this.cboUpsampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboDownsampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label12 = new System.Windows.Forms.Label();
            this.configPanelControl3 = new MW5.UI.Controls.ConfigPanelControl();
            this.cboPyramidsSampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPyramidCompression = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkCreatePyramids = new System.Windows.Forms.CheckBox();
            this.chkPyramidsDialog = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefaultColorScheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUpsampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDownsampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).BeginInit();
            this.configPanelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPyramidsSampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPyramidCompression)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.chkUseHistogram);
            this.configPanelControl1.Controls.Add(this.chkCreateColorScheme);
            this.configPanelControl1.Controls.Add(this.chkRandomColorScheme);
            this.configPanelControl1.Controls.Add(this.label1);
            this.configPanelControl1.Controls.Add(this.cboDefaultColorScheme);
            this.configPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl1.HeaderText = "Grid rendering";
            this.configPanelControl1.Location = new System.Drawing.Point(0, 187);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(394, 171);
            this.configPanelControl1.TabIndex = 12;
            // 
            // chkUseHistogram
            // 
            this.chkUseHistogram.AutoSize = true;
            this.chkUseHistogram.Location = new System.Drawing.Point(24, 44);
            this.chkUseHistogram.Name = "chkUseHistogram";
            this.chkUseHistogram.Size = new System.Drawing.Size(262, 17);
            this.chkUseHistogram.TabIndex = 18;
            this.chkUseHistogram.Text = "Use histogram equalization for greyscale rendering";
            this.chkUseHistogram.UseVisualStyleBackColor = true;
            // 
            // chkCreateColorScheme
            // 
            this.chkCreateColorScheme.AutoSize = true;
            this.chkCreateColorScheme.Location = new System.Drawing.Point(24, 78);
            this.chkCreateColorScheme.Name = "chkCreateColorScheme";
            this.chkCreateColorScheme.Size = new System.Drawing.Size(323, 17);
            this.chkCreateColorScheme.TabIndex = 17;
            this.chkCreateColorScheme.Text = "Use color scheme for new grids (otherwise greyscale rendering)";
            this.chkCreateColorScheme.UseVisualStyleBackColor = true;
            // 
            // chkRandomColorScheme
            // 
            this.chkRandomColorScheme.AutoSize = true;
            this.chkRandomColorScheme.Location = new System.Drawing.Point(164, 137);
            this.chkRandomColorScheme.Name = "chkRandomColorScheme";
            this.chkRandomColorScheme.Size = new System.Drawing.Size(152, 17);
            this.chkRandomColorScheme.TabIndex = 16;
            this.chkRandomColorScheme.Text = "User random color scheme";
            this.chkRandomColorScheme.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 114);
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
            this.cboDefaultColorScheme.Location = new System.Drawing.Point(164, 110);
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
            this.configPanelControl2.Location = new System.Drawing.Point(0, 358);
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
            // configPanelControl3
            // 
            this.configPanelControl3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl3.Controls.Add(this.cboPyramidsSampling);
            this.configPanelControl3.Controls.Add(this.label4);
            this.configPanelControl3.Controls.Add(this.label2);
            this.configPanelControl3.Controls.Add(this.cboPyramidCompression);
            this.configPanelControl3.Controls.Add(this.chkCreatePyramids);
            this.configPanelControl3.Controls.Add(this.chkPyramidsDialog);
            this.configPanelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl3.HeaderText = "Raster pyramids";
            this.configPanelControl3.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl3.Name = "configPanelControl3";
            this.configPanelControl3.Size = new System.Drawing.Size(394, 187);
            this.configPanelControl3.TabIndex = 15;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Pyramids compression";
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
            this.chkCreatePyramids.Location = new System.Drawing.Point(21, 72);
            this.chkCreatePyramids.Name = "chkCreatePyramids";
            this.chkCreatePyramids.Size = new System.Drawing.Size(277, 21);
            this.chkCreatePyramids.TabIndex = 10;
            this.chkCreatePyramids.Text = "Create pyramids on opening (if they are missing)";
            // 
            // chkPyramidsDialog
            // 
            this.chkPyramidsDialog.Location = new System.Drawing.Point(21, 45);
            this.chkPyramidsDialog.Name = "chkPyramidsDialog";
            this.chkPyramidsDialog.Size = new System.Drawing.Size(188, 21);
            this.chkPyramidsDialog.TabIndex = 9;
            this.chkPyramidsDialog.Text = "Show pyramid creation dialog";
            // 
            // RasterConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl2);
            this.Controls.Add(this.configPanelControl1);
            this.Controls.Add(this.configPanelControl3);
            this.Name = "RasterConfigPage";
            this.Size = new System.Drawing.Size(394, 495);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDefaultColorScheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUpsampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDownsampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).EndInit();
            this.configPanelControl3.ResumeLayout(false);
            this.configPanelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPyramidsSampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPyramidCompression)).EndInit();
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
        private CheckBox chkUseHistogram;
        private UI.Controls.ConfigPanelControl configPanelControl3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboPyramidsSampling;
        private Label label4;
        private Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboPyramidCompression;
        private CheckBox chkCreatePyramids;
        private CheckBox chkPyramidsDialog;
    }
}
