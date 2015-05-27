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
            this._treeViewAdv1 = new MW5.Controls.ConfigTreeView();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOpenFolder = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnSave = new Syncfusion.Windows.Forms.ButtonAdv();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this._treeViewAdv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _treeViewAdv1
            // 
            this._treeViewAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._treeViewAdv1.BackColor = System.Drawing.Color.Gray;
            this._treeViewAdv1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Gray);
            this._treeViewAdv1.BeforeTouchSize = new System.Drawing.Size(174, 425);
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
            this._treeViewAdv1.Location = new System.Drawing.Point(12, 12);
            this._treeViewAdv1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._treeViewAdv1.Name = "_treeViewAdv1";
            this._treeViewAdv1.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control);
            this._treeViewAdv1.SelectedNodeForeColor = System.Drawing.Color.Black;
            this._treeViewAdv1.ShowFocusRect = false;
            this._treeViewAdv1.ShowRootLines = false;
            this._treeViewAdv1.ShowSuperTooltip = false;
            this._treeViewAdv1.Size = new System.Drawing.Size(174, 425);
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
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(-1, 50);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(502, 372);
            this.panelContent.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MW5.Properties.Resources.img_options;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(41, 3);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(458, 44);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "Some long description of the general options. ";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel1.Controls.Add(this.panelContent);
            this.gradientPanel1.Controls.Add(this.lblDescription);
            this.gradientPanel1.Controls.Add(this.pictureBox1);
            this.gradientPanel1.Location = new System.Drawing.Point(192, 12);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(504, 425);
            this.gradientPanel1.TabIndex = 16;
            // 
            // ConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(708, 475);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this._treeViewAdv1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "ConfigView";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this._treeViewAdv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ConfigTreeView _treeViewAdv1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.ButtonAdv btnOpenFolder;
        private Syncfusion.Windows.Forms.ButtonAdv btnSave;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDescription;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
    }
}