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
            this.chkLoadSymbology = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            this.chkLoadLastProject = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadSymbology)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadLastProject)).BeginInit();
            this.SuspendLayout();
            // 
            // chkLoadSymbology
            // 
            this.chkLoadSymbology.BeforeTouchSize = new System.Drawing.Size(188, 21);
            this.chkLoadSymbology.Location = new System.Drawing.Point(24, 22);
            this.chkLoadSymbology.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkLoadSymbology.Name = "chkLoadSymbology";
            this.chkLoadSymbology.Size = new System.Drawing.Size(188, 21);
            this.chkLoadSymbology.TabIndex = 2;
            this.chkLoadSymbology.Text = "Load Symbology for Layers";
            this.chkLoadSymbology.ThemesEnabled = false;
            // 
            // chkLoadLastProject
            // 
            this.chkLoadLastProject.BeforeTouchSize = new System.Drawing.Size(188, 21);
            this.chkLoadLastProject.Location = new System.Drawing.Point(24, 60);
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
            this.Controls.Add(this.chkLoadLastProject);
            this.Controls.Add(this.chkLoadSymbology);
            this.Name = "GeneralConfigPage";
            this.Size = new System.Drawing.Size(268, 298);
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadSymbology)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoadLastProject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkLoadSymbology;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkLoadLastProject;
    }
}
