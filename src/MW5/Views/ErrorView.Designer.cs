namespace MW5.Views
{
    partial class ErrorView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorView));
            this.textBoxExt1 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQuit = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnContinue = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnReport = new Syncfusion.Windows.Forms.ButtonAdv();
            this.treeViewAdv1 = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxExt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewAdv1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxExt1
            // 
            this.textBoxExt1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExt1.BeforeTouchSize = new System.Drawing.Size(530, 122);
            this.textBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxExt1.Location = new System.Drawing.Point(12, 197);
            this.textBoxExt1.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.textBoxExt1.Multiline = true;
            this.textBoxExt1.Name = "textBoxExt1";
            this.textBoxExt1.ReadOnly = true;
            this.textBoxExt1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxExt1.Size = new System.Drawing.Size(530, 122);
            this.textBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.textBoxExt1.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Location = new System.Drawing.Point(174, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(368, 58);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Error message";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MW5.Properties.Resources.img_broken_robot;
            this.pictureBox1.Location = new System.Drawing.Point(12, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnQuit.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnQuit.IsBackStageButton = false;
            this.btnQuit.Location = new System.Drawing.Point(457, 325);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(85, 26);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyle = false;
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnContinue.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnContinue.IsBackStageButton = false;
            this.btnContinue.Location = new System.Drawing.Point(366, 325);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(85, 26);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyle = false;
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.BeforeTouchSize = new System.Drawing.Size(77, 26);
            this.btnReport.IsBackStageButton = false;
            this.btnReport.Location = new System.Drawing.Point(12, 325);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(77, 26);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // treeViewAdv1
            // 
            this.treeViewAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewAdv1.BackColor = System.Drawing.Color.White;
            this.treeViewAdv1.BeforeTouchSize = new System.Drawing.Size(364, 118);
            this.treeViewAdv1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.treeViewAdv1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None;
            this.treeViewAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAdv1.CanSelectDisabledNode = false;
            // 
            // 
            // 
            this.treeViewAdv1.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAdv1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewAdv1.HelpTextControl.Name = "helpText";
            this.treeViewAdv1.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.treeViewAdv1.HelpTextControl.TabIndex = 0;
            this.treeViewAdv1.HelpTextControl.Text = "help text";
            this.treeViewAdv1.Location = new System.Drawing.Point(174, 73);
            this.treeViewAdv1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.treeViewAdv1.Name = "treeViewAdv1";
            this.treeViewAdv1.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220))))));
            this.treeViewAdv1.ShowFocusRect = false;
            this.treeViewAdv1.Size = new System.Drawing.Size(364, 118);
            this.treeViewAdv1.Style = Syncfusion.Windows.Forms.Tools.TreeStyle.Metro;
            this.treeViewAdv1.TabIndex = 4;
            this.treeViewAdv1.Text = "treeViewAdv1";
            // 
            // 
            // 
            this.treeViewAdv1.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.treeViewAdv1.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAdv1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewAdv1.ToolTipControl.Name = "toolTip";
            this.treeViewAdv1.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.treeViewAdv1.ToolTipControl.TabIndex = 1;
            this.treeViewAdv1.ToolTipControl.Text = "toolTip";
            this.treeViewAdv1.AfterSelect += new System.EventHandler(this.treeViewAdv1_AfterSelect);
            // 
            // ErrorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnContinue;
            this.ClientSize = new System.Drawing.Size(550, 363);
            this.Controls.Add(this.treeViewAdv1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.textBoxExt1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "An error has occured";
            ((System.ComponentModel.ISupportInitialize)(this.textBoxExt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewAdv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TextBoxExt textBoxExt1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Syncfusion.Windows.Forms.ButtonAdv btnQuit;
        private Syncfusion.Windows.Forms.ButtonAdv btnContinue;
        private Syncfusion.Windows.Forms.ButtonAdv btnReport;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv treeViewAdv1;
    }
}