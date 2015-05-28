using MW5.UI.Controls;

namespace MW5.Views
{
    partial class WelcomeView
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
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPaypal = new MW5.UI.Controls.LinkLabelEx();
            this.picureLogo = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lbProject3 = new MW5.UI.Controls.LinkLabelEx();
            this.lbProject2 = new MW5.UI.Controls.LinkLabelEx();
            this.lbProject1 = new MW5.UI.Controls.LinkLabelEx();
            this.chkShowDlg = new System.Windows.Forms.CheckBox();
            this.PictureBox5 = new System.Windows.Forms.PictureBox();
            this.PictureBox4 = new System.Windows.Forms.PictureBox();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbHelpFile = new MW5.UI.Controls.LinkLabelEx();
            this.lbGettingStarted = new MW5.UI.Controls.LinkLabelEx();
            this.lbOpenProject = new MW5.UI.Controls.LinkLabelEx();
            this.lbAddData = new MW5.UI.Controls.LinkLabelEx();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(93, 29);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(459, 223);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = global::MW5.Properties.Resources.img_paypal24;
            this.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox1.Location = new System.Drawing.Point(11, 166);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(24, 24);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 37;
            this.PictureBox1.TabStop = false;
            // 
            // lbPaypal
            // 
            this.lbPaypal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbPaypal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbPaypal.LinkArea = new System.Windows.Forms.LinkArea(0, 32);
            this.lbPaypal.Location = new System.Drawing.Point(40, 174);
            this.lbPaypal.Name = "lbPaypal";
            this.lbPaypal.Size = new System.Drawing.Size(223, 16);
            this.lbPaypal.TabIndex = 36;
            this.lbPaypal.TabStop = true;
            this.lbPaypal.Text = "Help us continue the development";
            // 
            // picureLogo
            // 
            this.picureLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picureLogo.Image = global::MW5.Properties.Resources.mapwindow_logo;
            this.picureLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picureLogo.Location = new System.Drawing.Point(11, 24);
            this.picureLogo.Name = "picureLogo";
            this.picureLogo.Size = new System.Drawing.Size(268, 44);
            this.picureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picureLogo.TabIndex = 35;
            this.picureLogo.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVersion.Location = new System.Drawing.Point(40, 72);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(222, 24);
            this.lblVersion.TabIndex = 34;
            this.lblVersion.Text = "Open Source v4.8";
            // 
            // lbProject3
            // 
            this.lbProject3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbProject3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProject3.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.lbProject3.Location = new System.Drawing.Point(308, 141);
            this.lbProject3.Name = "lbProject3";
            this.lbProject3.Size = new System.Drawing.Size(215, 16);
            this.lbProject3.TabIndex = 33;
            this.lbProject3.TabStop = true;
            this.lbProject3.Tag = "2";
            this.lbProject3.Text = "Project3";
            this.lbProject3.Click += new System.EventHandler(this.OnRecentProjectClick);
            // 
            // lbProject2
            // 
            this.lbProject2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbProject2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProject2.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.lbProject2.Location = new System.Drawing.Point(308, 117);
            this.lbProject2.Name = "lbProject2";
            this.lbProject2.Size = new System.Drawing.Size(215, 16);
            this.lbProject2.TabIndex = 32;
            this.lbProject2.TabStop = true;
            this.lbProject2.Tag = "1";
            this.lbProject2.Text = "Project2";
            this.lbProject2.Click += new System.EventHandler(this.OnRecentProjectClick);
            // 
            // lbProject1
            // 
            this.lbProject1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbProject1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbProject1.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
            this.lbProject1.Location = new System.Drawing.Point(308, 93);
            this.lbProject1.Name = "lbProject1";
            this.lbProject1.Size = new System.Drawing.Size(215, 16);
            this.lbProject1.TabIndex = 31;
            this.lbProject1.TabStop = true;
            this.lbProject1.Tag = "0";
            this.lbProject1.Text = "Project1";
            this.lbProject1.Click += new System.EventHandler(this.OnRecentProjectClick);
            // 
            // chkShowDlg
            // 
            this.chkShowDlg.Checked = true;
            this.chkShowDlg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowDlg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkShowDlg.Location = new System.Drawing.Point(13, 228);
            this.chkShowDlg.Name = "chkShowDlg";
            this.chkShowDlg.Size = new System.Drawing.Size(170, 20);
            this.chkShowDlg.TabIndex = 30;
            this.chkShowDlg.Text = "Show this dialog at startup";
            this.chkShowDlg.CheckedChanged += new System.EventHandler(this.cbShowDlg_CheckedChanged);
            // 
            // PictureBox5
            // 
            this.PictureBox5.Image = global::MW5.Properties.Resources.img_book24;
            this.PictureBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox5.Location = new System.Drawing.Point(11, 104);
            this.PictureBox5.Name = "PictureBox5";
            this.PictureBox5.Size = new System.Drawing.Size(24, 24);
            this.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox5.TabIndex = 28;
            this.PictureBox5.TabStop = false;
            // 
            // PictureBox4
            // 
            this.PictureBox4.Image = global::MW5.Properties.Resources.img_docs24;
            this.PictureBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox4.Location = new System.Drawing.Point(11, 134);
            this.PictureBox4.Name = "PictureBox4";
            this.PictureBox4.Size = new System.Drawing.Size(24, 24);
            this.PictureBox4.TabIndex = 27;
            this.PictureBox4.TabStop = false;
            // 
            // PictureBox3
            // 
            this.PictureBox3.Image = global::MW5.Properties.Resources.icon_folder;
            this.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox3.Location = new System.Drawing.Point(299, 60);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(24, 24);
            this.PictureBox3.TabIndex = 26;
            this.PictureBox3.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.Image = global::MW5.Properties.Resources.icon_layer_add;
            this.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PictureBox2.Location = new System.Drawing.Point(299, 24);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(24, 24);
            this.PictureBox2.TabIndex = 25;
            this.PictureBox2.TabStop = false;
            // 
            // lbHelpFile
            // 
            this.lbHelpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbHelpFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbHelpFile.LinkArea = new System.Windows.Forms.LinkArea(0, 16);
            this.lbHelpFile.Location = new System.Drawing.Point(43, 142);
            this.lbHelpFile.Name = "lbHelpFile";
            this.lbHelpFile.Size = new System.Drawing.Size(223, 16);
            this.lbHelpFile.TabIndex = 23;
            this.lbHelpFile.TabStop = true;
            this.lbHelpFile.Text = "View online help";
            this.lbHelpFile.UseCompatibleTextRendering = true;
            // 
            // lbGettingStarted
            // 
            this.lbGettingStarted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbGettingStarted.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbGettingStarted.LinkArea = new System.Windows.Forms.LinkArea(0, 30);
            this.lbGettingStarted.Location = new System.Drawing.Point(40, 112);
            this.lbGettingStarted.Name = "lbGettingStarted";
            this.lbGettingStarted.Size = new System.Drawing.Size(223, 16);
            this.lbGettingStarted.TabIndex = 22;
            this.lbGettingStarted.TabStop = true;
            this.lbGettingStarted.Text = "Getting started with MapWindow";
            this.lbGettingStarted.UseCompatibleTextRendering = true;
            // 
            // lbOpenProject
            // 
            this.lbOpenProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbOpenProject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbOpenProject.LinkArea = new System.Windows.Forms.LinkArea(0, 14);
            this.lbOpenProject.Location = new System.Drawing.Point(331, 68);
            this.lbOpenProject.Name = "lbOpenProject";
            this.lbOpenProject.Size = new System.Drawing.Size(220, 16);
            this.lbOpenProject.TabIndex = 21;
            this.lbOpenProject.TabStop = true;
            this.lbOpenProject.Text = "Open a project";
            this.lbOpenProject.UseCompatibleTextRendering = true;
            // 
            // lbAddData
            // 
            this.lbAddData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbAddData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbAddData.LinkArea = new System.Windows.Forms.LinkArea(0, 24);
            this.lbAddData.Location = new System.Drawing.Point(329, 32);
            this.lbAddData.Name = "lbAddData";
            this.lbAddData.Size = new System.Drawing.Size(223, 16);
            this.lbAddData.TabIndex = 20;
            this.lbAddData.TabStop = true;
            this.lbAddData.Text = "Add data to this project";
            // 
            // WelcomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 260);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.lbPaypal);
            this.Controls.Add(this.picureLogo);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lbProject3);
            this.Controls.Add(this.lbProject2);
            this.Controls.Add(this.lbProject1);
            this.Controls.Add(this.chkShowDlg);
            this.Controls.Add(this.PictureBox5);
            this.Controls.Add(this.PictureBox4);
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.lbHelpFile);
            this.Controls.Add(this.lbGettingStarted);
            this.Controls.Add(this.lbOpenProject);
            this.Controls.Add(this.lbAddData);
            this.Controls.Add(this.btnClose);
            this.Name = "WelcomeView";
            this.Text = "Welcome to MapWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WelcomeView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal LinkLabelEx lbPaypal;
        internal System.Windows.Forms.PictureBox picureLogo;
        internal System.Windows.Forms.Label lblVersion;
        internal LinkLabelEx lbProject3;
        internal LinkLabelEx lbProject2;
        internal LinkLabelEx lbProject1;
        internal System.Windows.Forms.CheckBox chkShowDlg;
        internal System.Windows.Forms.PictureBox PictureBox5;
        internal System.Windows.Forms.PictureBox PictureBox4;
        internal System.Windows.Forms.PictureBox PictureBox3;
        internal System.Windows.Forms.PictureBox PictureBox2;
        internal LinkLabelEx lbHelpFile;
        internal LinkLabelEx lbGettingStarted;
        internal LinkLabelEx lbOpenProject;
        internal LinkLabelEx lbAddData;
    }
}