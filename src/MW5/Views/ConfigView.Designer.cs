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
            this._treeViewAdv1 = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenFolder = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSave = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this._treeViewAdv1)).BeginInit();
            this.SuspendLayout();
            // 
            // _treeViewAdv1
            // 
            this._treeViewAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._treeViewAdv1.BackColor = System.Drawing.Color.White;
            this._treeViewAdv1.BeforeTouchSize = new System.Drawing.Size(174, 425);
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
            this._treeViewAdv1.InactiveSelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255))))));
            this._treeViewAdv1.InactiveSelectedNodeForeColor = System.Drawing.Color.Black;
            this._treeViewAdv1.ItemHeight = 30;
            this._treeViewAdv1.Location = new System.Drawing.Point(12, 12);
            this._treeViewAdv1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._treeViewAdv1.Name = "_treeViewAdv1";
            this._treeViewAdv1.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255))))));
            this._treeViewAdv1.SelectedNodeForeColor = System.Drawing.Color.Black;
            this._treeViewAdv1.ShowFocusRect = false;
            this._treeViewAdv1.ShowRootLines = false;
            this._treeViewAdv1.Size = new System.Drawing.Size(174, 425);
            this._treeViewAdv1.TabIndex = 0;
            this._treeViewAdv1.Text = "treeViewAdv1";
            this._treeViewAdv1.ThemesEnabled = true;
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
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.OfficeXP;
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(611, 443);
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
            this.btnOk.Location = new System.Drawing.Point(520, 443);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyle = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(192, 12);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(504, 425);
            this.panel1.TabIndex = 9;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.OfficeXP;
            this.btnOpenFolder.BackColor = System.Drawing.Color.White;
            this.btnOpenFolder.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOpenFolder.IsBackStageButton = false;
            this.btnOpenFolder.Location = new System.Drawing.Point(12, 443);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(85, 26);
            this.btnOpenFolder.TabIndex = 10;
            this.btnOpenFolder.Text = "Open folder";
            this.btnOpenFolder.UseVisualStyle = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.OfficeXP;
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.BeforeTouchSize = new System.Drawing.Size(92, 26);
            this.btnSave.IsBackStageButton = false;
            this.btnSave.Location = new System.Drawing.Point(422, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 26);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyle = false;
            // 
            // ConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(708, 475);
            this.Controls.Add(this._treeViewAdv1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "ConfigView";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this._treeViewAdv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TreeViewAdv _treeViewAdv1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.Panel panel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnOpenFolder;
        private Syncfusion.Windows.Forms.ButtonAdv btnSave;
    }
}