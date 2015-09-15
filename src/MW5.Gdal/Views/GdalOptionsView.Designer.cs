namespace MW5.Gdal.Views
{
    partial class GdalOptionsView
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
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRun = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtMain = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtAdditional = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDontShow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdditional)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(366, 231);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Cancel";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnRun.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.IsBackStageButton = false;
            this.btnRun.Location = new System.Drawing.Point(275, 231);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 26);
            this.btnRun.TabIndex = 37;
            this.btnRun.Text = "Run";
            // 
            // txtMain
            // 
            this.txtMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMain.BeforeTouchSize = new System.Drawing.Size(439, 78);
            this.txtMain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMain.Location = new System.Drawing.Point(12, 35);
            this.txtMain.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ReadOnly = true;
            this.txtMain.Size = new System.Drawing.Size(439, 78);
            this.txtMain.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMain.TabIndex = 39;
            // 
            // txtAdditional
            // 
            this.txtAdditional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditional.BeforeTouchSize = new System.Drawing.Size(439, 78);
            this.txtAdditional.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAdditional.Location = new System.Drawing.Point(12, 142);
            this.txtAdditional.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtAdditional.Multiline = true;
            this.txtAdditional.Name = "txtAdditional";
            this.txtAdditional.Size = new System.Drawing.Size(439, 78);
            this.txtAdditional.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtAdditional.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Additional:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Command line options:";
            // 
            // chkDontShow
            // 
            this.chkDontShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDontShow.AutoSize = true;
            this.chkDontShow.Location = new System.Drawing.Point(15, 235);
            this.chkDontShow.Name = "chkDontShow";
            this.chkDontShow.Size = new System.Drawing.Size(129, 17);
            this.chkDontShow.TabIndex = 48;
            this.chkDontShow.Text = "Don\'t show this dialog";
            this.chkDontShow.UseVisualStyleBackColor = true;
            // 
            // GdalOptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(463, 262);
            this.Controls.Add(this.chkDontShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAdditional);
            this.Controls.Add(this.txtMain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Name = "GdalOptionsView";
            this.Text = "GDAL options";
            ((System.ComponentModel.ISupportInitialize)(this.txtMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdditional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnRun;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtMain;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAdditional;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDontShow;
    }
}