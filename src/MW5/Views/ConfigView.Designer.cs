using MW5.Controls;

namespace MW5.Views
{
    partial class ConfigView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigView));
            this._treeViewAdv1 = new MW5.Controls.ConfigTreeView();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSave = new Syncfusion.Windows.Forms.ButtonAdv();
            this.configPageControl1 = new MW5.Controls.ConfigPageControl();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSetDefaults = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolRestorePlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRestoreToolbars = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._treeViewAdv1)).BeginInit();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _treeViewAdv1
            // 
            this._treeViewAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._treeViewAdv1.ApplyStyle = true;
            this._treeViewAdv1.BackColor = System.Drawing.Color.Gray;
            this._treeViewAdv1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Gray);
            this._treeViewAdv1.BeforeTouchSize = new System.Drawing.Size(174, 473);
            this._treeViewAdv1.BorderColor = System.Drawing.Color.DarkGray;
            this._treeViewAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._treeViewAdv1.CanSelectDisabledNode = false;
            this._treeViewAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._treeViewAdv1.ForeColor = System.Drawing.Color.Black;
            this._treeViewAdv1.FullRowSelect = true;
            this._treeViewAdv1.GutterSpace = 15;
            // 
            // 
            // 
            this._treeViewAdv1.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._treeViewAdv1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this._treeViewAdv1.HelpTextControl.Name = "helpText";
            this._treeViewAdv1.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this._treeViewAdv1.HelpTextControl.TabIndex = 0;
            this._treeViewAdv1.HelpTextControl.Text = "help text";
            this._treeViewAdv1.HideSelection = false;
            this._treeViewAdv1.InactiveSelectedNodeForeColor = System.Drawing.Color.Black;
            this._treeViewAdv1.ItemHeight = 30;
            this._treeViewAdv1.Location = new System.Drawing.Point(3, 12);
            this._treeViewAdv1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._treeViewAdv1.Name = "_treeViewAdv1";
            this._treeViewAdv1.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control);
            this._treeViewAdv1.SelectedNodeForeColor = System.Drawing.Color.Black;
            this._treeViewAdv1.ShowFocusRect = false;
            this._treeViewAdv1.ShowRootLines = false;
            this._treeViewAdv1.ShowSuperTooltip = false;
            this._treeViewAdv1.Size = new System.Drawing.Size(174, 473);
            this._treeViewAdv1.TabIndex = 0;
            this._treeViewAdv1.Text = "treeViewAdv1";
            this._treeViewAdv1.ThemesEnabled = false;
            // 
            // 
            // 
            this._treeViewAdv1.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this._treeViewAdv1.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._treeViewAdv1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this._treeViewAdv1.ToolTipControl.Name = "toolTip";
            this._treeViewAdv1.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this._treeViewAdv1.ToolTipControl.TabIndex = 1;
            this._treeViewAdv1.ToolTipControl.Text = "toolTip";
            this._treeViewAdv1.ToolTipDuration = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.OfficeXP;
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(619, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyle = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.OfficeXP;
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(528, 491);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyle = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.OfficeXP;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.BeforeTouchSize = new System.Drawing.Size(92, 26);
            this.btnSave.IsBackStageButton = false;
            this.btnSave.Location = new System.Drawing.Point(430, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 26);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Apply";
            this.btnSave.UseVisualStyle = false;
            // 
            // configPageControl1
            // 
            this.configPageControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configPageControl1.ConfigPage = null;
            this.configPageControl1.Description = "Some long description of the general options. ";
            this.configPageControl1.Icon = ((System.Drawing.Image)(resources.GetObject("configPageControl1.Icon")));
            this.configPageControl1.Location = new System.Drawing.Point(183, 12);
            this.configPageControl1.Name = "configPageControl1";
            this.configPageControl1.Size = new System.Drawing.Size(521, 473);
            this.configPageControl1.TabIndex = 12;
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOptions});
            this.toolStripEx1.Location = new System.Drawing.Point(3, 492);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.Size = new System.Drawing.Size(81, 25);
            this.toolStripEx1.TabIndex = 40;
            this.toolStripEx1.Text = "Style";
            this.toolStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.ToolStripExStyle.Metro;
            // 
            // toolOptions
            // 
            this.toolOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenFolder,
            this.toolStripSeparator1,
            this.toolSetDefaults,
            this.toolStripSeparator2,
            this.toolRestorePlugins,
            this.toolRestoreToolbars});
            this.toolOptions.ForeColor = System.Drawing.Color.Black;
            this.toolOptions.Image = global::MW5.Properties.Resources.icon_settings;
            this.toolOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOptions.Name = "toolOptions";
            this.toolOptions.Size = new System.Drawing.Size(78, 22);
            this.toolOptions.Text = "Options";
            // 
            // toolOpenFolder
            // 
            this.toolOpenFolder.Image = global::MW5.Properties.Resources.icon_folder;
            this.toolOpenFolder.Name = "toolOpenFolder";
            this.toolOpenFolder.Size = new System.Drawing.Size(162, 22);
            this.toolOpenFolder.Text = "Open Folder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // toolSetDefaults
            // 
            this.toolSetDefaults.Image = global::MW5.Properties.Resources.img_default24;
            this.toolSetDefaults.Name = "toolSetDefaults";
            this.toolSetDefaults.Size = new System.Drawing.Size(162, 22);
            this.toolSetDefaults.Text = "Set Defaults";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // toolRestorePlugins
            // 
            this.toolRestorePlugins.Image = global::MW5.Properties.Resources.img_plugin32;
            this.toolRestorePlugins.Name = "toolRestorePlugins";
            this.toolRestorePlugins.Size = new System.Drawing.Size(162, 22);
            this.toolRestorePlugins.Text = "Restore Plugins";
            // 
            // toolRestoreToolbars
            // 
            this.toolRestoreToolbars.Name = "toolRestoreToolbars";
            this.toolRestoreToolbars.Size = new System.Drawing.Size(162, 22);
            this.toolRestoreToolbars.Text = "Restore Toolbars";
            // 
            // ConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(708, 523);
            this.Controls.Add(this.toolStripEx1);
            this.Controls.Add(this.configPageControl1);
            this.Controls.Add(this._treeViewAdv1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "ConfigView";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this._treeViewAdv1)).EndInit();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConfigTreeView _treeViewAdv1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.ButtonAdv btnSave;
        private ConfigPageControl configPageControl1;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripDropDownButton toolOptions;
        private System.Windows.Forms.ToolStripMenuItem toolSetDefaults;
        private System.Windows.Forms.ToolStripMenuItem toolRestorePlugins;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolOpenFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolRestoreToolbars;
    }
}