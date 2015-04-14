namespace MW5.Configuration
{
    partial class GeneralConfigPage
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
            this.chkLoadSymbology = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.chkLoadLastProject = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadSymbology)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadLastProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.chkLoadSymbology);
            this.configPanelControl2.Controls.Add(this.chkLoadLastProject);
            this.configPanelControl2.HeaderText = "General options";
            this.configPanelControl2.Location = new System.Drawing.Point(7, 48);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(370, 128);
            this.configPanelControl2.TabIndex = 8;
            // 
            // chkLoadSymbology
            // 
            this.chkLoadSymbology.BeforeTouchSize = new System.Drawing.Size(188, 21);
            this.chkLoadSymbology.DrawFocusRectangle = false;
            this.chkLoadSymbology.Location = new System.Drawing.Point(18, 35);
            this.chkLoadSymbology.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.chkLoadSymbology.Name = "chkLoadSymbology";
            this.chkLoadSymbology.Size = new System.Drawing.Size(188, 21);
            this.chkLoadSymbology.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Metro;
            this.chkLoadSymbology.TabIndex = 2;
            this.chkLoadSymbology.Text = "Load Symbology for Layers";
            this.chkLoadSymbology.ThemesEnabled = false;
            // 
            // chkLoadLastProject
            // 
            this.chkLoadLastProject.BeforeTouchSize = new System.Drawing.Size(188, 21);
            this.chkLoadLastProject.Location = new System.Drawing.Point(18, 62);
            this.chkLoadLastProject.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkLoadLastProject.Name = "chkLoadLastProject";
            this.chkLoadLastProject.Size = new System.Drawing.Size(188, 21);
            this.chkLoadLastProject.TabIndex = 3;
            this.chkLoadLastProject.Text = "Load Last Project on Startup";
            this.chkLoadLastProject.ThemesEnabled = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MW5.Properties.Resources.img_options;
            this.pictureBox1.Location = new System.Drawing.Point(13, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(51, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 35);
            this.label1.TabIndex = 4;
            this.label1.Text = "Some long description of the description of the general options. Here is some mor" +
    "e.\r\n";
            // 
            // GeneralConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.configPanelControl2);
            this.Name = "GeneralConfigPage";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(390, 297);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadSymbology)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadLastProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl2;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkLoadSymbology;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkLoadLastProject;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;

    }
}
