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
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadSymbology)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadLastProject)).BeginInit();
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
            this.configPanelControl2.Location = new System.Drawing.Point(7, 13);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(370, 126);
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
            // GeneralConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl2);
            this.Name = "GeneralConfigPage";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(390, 482);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadSymbology)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadLastProject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl2;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkLoadSymbology;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkLoadLastProject;

    }
}
