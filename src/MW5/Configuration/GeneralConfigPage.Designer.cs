using System.Windows.Forms;

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
            this.configPanelControl3 = new MW5.UI.Controls.ConfigPanelControl();
            this.chkLocalDocumentation = new System.Windows.Forms.CheckBox();
            this.chkDynamicVisibilityWarnings = new System.Windows.Forms.CheckBox();
            this.chkShowMenuToolTips = new System.Windows.Forms.CheckBox();
            this.chkShowPluginInToolTip = new System.Windows.Forms.CheckBox();
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSymbologyStorage = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkLoadSymbology = new System.Windows.Forms.CheckBox();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.chkNewVersion = new System.Windows.Forms.CheckBox();
            this.chkShowWelcomeDialog = new System.Windows.Forms.CheckBox();
            this.chkLoadLastProject = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).BeginInit();
            this.configPanelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSymbologyStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // configPanelControl3
            // 
            this.configPanelControl3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl3.Controls.Add(this.chkLocalDocumentation);
            this.configPanelControl3.Controls.Add(this.chkDynamicVisibilityWarnings);
            this.configPanelControl3.Controls.Add(this.chkShowMenuToolTips);
            this.configPanelControl3.Controls.Add(this.chkShowPluginInToolTip);
            this.configPanelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl3.HeaderText = "Various";
            this.configPanelControl3.Location = new System.Drawing.Point(0, 246);
            this.configPanelControl3.Name = "configPanelControl3";
            this.configPanelControl3.Size = new System.Drawing.Size(380, 176);
            this.configPanelControl3.TabIndex = 10;
            // 
            // chkLocalDocumentation
            // 
            this.chkLocalDocumentation.Location = new System.Drawing.Point(15, 139);
            this.chkLocalDocumentation.Name = "chkLocalDocumentation";
            this.chkLocalDocumentation.Size = new System.Drawing.Size(283, 21);
            this.chkLocalDocumentation.TabIndex = 11;
            this.chkLocalDocumentation.Text = "Use only local documentation";
            // 
            // chkDynamicVisibilityWarnings
            // 
            this.chkDynamicVisibilityWarnings.Location = new System.Drawing.Point(15, 105);
            this.chkDynamicVisibilityWarnings.Name = "chkDynamicVisibilityWarnings";
            this.chkDynamicVisibilityWarnings.Size = new System.Drawing.Size(283, 21);
            this.chkDynamicVisibilityWarnings.TabIndex = 6;
            this.chkDynamicVisibilityWarnings.Text = "Display dynamic visibility warnings";
            // 
            // chkShowMenuToolTips
            // 
            this.chkShowMenuToolTips.Location = new System.Drawing.Point(15, 71);
            this.chkShowMenuToolTips.Name = "chkShowMenuToolTips";
            this.chkShowMenuToolTips.Size = new System.Drawing.Size(283, 21);
            this.chkShowMenuToolTips.TabIndex = 5;
            this.chkShowMenuToolTips.Text = "Show tooltips for menu items (needs app restart)";
            // 
            // chkShowPluginInToolTip
            // 
            this.chkShowPluginInToolTip.Location = new System.Drawing.Point(15, 37);
            this.chkShowPluginInToolTip.Name = "chkShowPluginInToolTip";
            this.chkShowPluginInToolTip.Size = new System.Drawing.Size(352, 21);
            this.chkShowPluginInToolTip.TabIndex = 4;
            this.chkShowPluginInToolTip.Text = "Show plugin name in toolbar tooltips (needs app restart)";
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.label1);
            this.configPanelControl1.Controls.Add(this.cboSymbologyStorage);
            this.configPanelControl1.Controls.Add(this.chkLoadSymbology);
            this.configPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl1.HeaderText = "Symbology";
            this.configPanelControl1.Location = new System.Drawing.Point(0, 132);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(380, 114);
            this.configPanelControl1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Store symbology in";
            // 
            // cboSymbologyStorage
            // 
            this.cboSymbologyStorage.BeforeTouchSize = new System.Drawing.Size(189, 21);
            this.cboSymbologyStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSymbologyStorage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboSymbologyStorage.Location = new System.Drawing.Point(135, 72);
            this.cboSymbologyStorage.Name = "cboSymbologyStorage";
            this.cboSymbologyStorage.Size = new System.Drawing.Size(189, 21);
            this.cboSymbologyStorage.TabIndex = 3;
            // 
            // chkLoadSymbology
            // 
            this.chkLoadSymbology.Location = new System.Drawing.Point(18, 35);
            this.chkLoadSymbology.Name = "chkLoadSymbology";
            this.chkLoadSymbology.Size = new System.Drawing.Size(234, 21);
            this.chkLoadSymbology.TabIndex = 2;
            this.chkLoadSymbology.Text = "Load symbology for layers on opening";
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.chkNewVersion);
            this.configPanelControl2.Controls.Add(this.chkShowWelcomeDialog);
            this.configPanelControl2.Controls.Add(this.chkLoadLastProject);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Startup";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(380, 132);
            this.configPanelControl2.TabIndex = 8;
            // 
            // chkNewVersion
            // 
            this.chkNewVersion.Location = new System.Drawing.Point(15, 97);
            this.chkNewVersion.Name = "chkNewVersion";
            this.chkNewVersion.Size = new System.Drawing.Size(188, 21);
            this.chkNewVersion.TabIndex = 5;
            this.chkNewVersion.Text = "Check for updates";
            // 
            // chkShowWelcomeDialog
            // 
            this.chkShowWelcomeDialog.Location = new System.Drawing.Point(15, 37);
            this.chkShowWelcomeDialog.Name = "chkShowWelcomeDialog";
            this.chkShowWelcomeDialog.Size = new System.Drawing.Size(188, 21);
            this.chkShowWelcomeDialog.TabIndex = 4;
            this.chkShowWelcomeDialog.Text = "Show welcome dialog";
            // 
            // chkLoadLastProject
            // 
            this.chkLoadLastProject.Location = new System.Drawing.Point(15, 67);
            this.chkLoadLastProject.Name = "chkLoadLastProject";
            this.chkLoadLastProject.Size = new System.Drawing.Size(188, 21);
            this.chkLoadLastProject.TabIndex = 3;
            this.chkLoadLastProject.Text = "Load last project on startup";
            // 
            // GeneralConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.configPanelControl3);
            this.Controls.Add(this.configPanelControl1);
            this.Controls.Add(this.configPanelControl2);
            this.Name = "GeneralConfigPage";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.Size = new System.Drawing.Size(390, 431);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).EndInit();
            this.configPanelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSymbologyStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl2;
        private CheckBox chkLoadSymbology;
        private CheckBox chkLoadLastProject;
        private CheckBox chkShowWelcomeDialog;
        private UI.Controls.ConfigPanelControl configPanelControl1;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboSymbologyStorage;
        private UI.Controls.ConfigPanelControl configPanelControl3;
        private CheckBox chkShowPluginInToolTip;
        private CheckBox chkShowMenuToolTips;
        private CheckBox chkDynamicVisibilityWarnings;
        private CheckBox chkLocalDocumentation;
        private CheckBox chkNewVersion;

    }
}
