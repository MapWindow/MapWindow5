using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Views
{
    partial class AddConnectionView
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
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.txtPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtUserName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtDatabase = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtPort = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPageAdv3 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.btnTestConnection = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(471, 323);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControlAdv1.BorderWidth = 0;
            this.tabControlAdv1.Controls.Add(this.tabPageAdv1);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv2);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv3);
            this.tabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdv1.FixedSingleBorderColor = System.Drawing.Color.Silver;
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.Location = new System.Drawing.Point(7, 7);
            this.tabControlAdv1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.PersistTabState = true;
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(471, 323);
            this.tabControlAdv1.TabIndex = 0;
            this.tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererBlendLight);
            // 
            // tabPageAdv1
            // 
            this.tabPageAdv1.Controls.Add(this.txtPassword);
            this.tabPageAdv1.Controls.Add(this.txtUserName);
            this.tabPageAdv1.Controls.Add(this.txtDatabase);
            this.tabPageAdv1.Controls.Add(this.txtPort);
            this.tabPageAdv1.Controls.Add(this.label5);
            this.tabPageAdv1.Controls.Add(this.label4);
            this.tabPageAdv1.Controls.Add(this.label3);
            this.tabPageAdv1.Controls.Add(this.label2);
            this.tabPageAdv1.Controls.Add(this.txtHost);
            this.tabPageAdv1.Controls.Add(this.label1);
            this.tabPageAdv1.Image = global::MW5.Data.Properties.Resources.img_postgis;
            this.tabPageAdv1.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageAdv1.Location = new System.Drawing.Point(80, 1);
            this.tabPageAdv1.Name = "tabPageAdv1";
            this.tabPageAdv1.ShowCloseButton = true;
            this.tabPageAdv1.Size = new System.Drawing.Size(390, 321);
            this.tabPageAdv1.TabIndex = 1;
            this.tabPageAdv1.Text = "General";
            this.tabPageAdv1.ThemesEnabled = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Location = new System.Drawing.Point(108, 240);
            this.txtPassword.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(224, 20);
            this.txtPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPassword.TabIndex = 14;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.Location = new System.Drawing.Point(108, 192);
            this.txtUserName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(224, 20);
            this.txtUserName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtUserName.TabIndex = 12;
            this.txtUserName.Text = "postgres";
            // 
            // txtDatabase
            // 
            this.txtDatabase.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtDatabase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDatabase.Location = new System.Drawing.Point(108, 144);
            this.txtDatabase.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(224, 20);
            this.txtDatabase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtDatabase.TabIndex = 10;
            // 
            // txtPort
            // 
            this.txtPort.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.Location = new System.Drawing.Point(108, 96);
            this.txtPort.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(224, 20);
            this.txtPort.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "5432";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "User name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // txtHost
            // 
            this.txtHost.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtHost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHost.Location = new System.Drawing.Point(108, 48);
            this.txtHost.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(224, 20);
            this.txtHost.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtHost.TabIndex = 7;
            this.txtHost.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Host";
            // 
            // tabPageAdv2
            // 
            this.tabPageAdv2.Image = null;
            this.tabPageAdv2.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv2.Location = new System.Drawing.Point(80, 1);
            this.tabPageAdv2.Name = "tabPageAdv2";
            this.tabPageAdv2.ShowCloseButton = true;
            this.tabPageAdv2.Size = new System.Drawing.Size(390, 321);
            this.tabPageAdv2.TabIndex = 2;
            this.tabPageAdv2.Text = "Info";
            this.tabPageAdv2.ThemesEnabled = false;
            // 
            // tabPageAdv3
            // 
            this.tabPageAdv3.Image = null;
            this.tabPageAdv3.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv3.Location = new System.Drawing.Point(80, 1);
            this.tabPageAdv3.Name = "tabPageAdv3";
            this.tabPageAdv3.ShowCloseButton = true;
            this.tabPageAdv3.Size = new System.Drawing.Size(390, 321);
            this.tabPageAdv3.TabIndex = 3;
            this.tabPageAdv3.Text = "Rendering";
            this.tabPageAdv3.ThemesEnabled = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(386, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(295, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 31;
            this.btnOk.Text = "Ok";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel1.Controls.Add(this.btnTestConnection);
            this.gradientPanel1.Controls.Add(this.btnCancel);
            this.gradientPanel1.Controls.Add(this.btnOk);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gradientPanel1.Location = new System.Drawing.Point(7, 330);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(471, 35);
            this.gradientPanel1.TabIndex = 33;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnTestConnection.BeforeTouchSize = new System.Drawing.Size(104, 26);
            this.btnTestConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.IsBackStageButton = false;
            this.btnTestConnection.Location = new System.Drawing.Point(0, 6);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(104, 26);
            this.btnTestConnection.TabIndex = 34;
            this.btnTestConnection.Text = "Test connection";
            // 
            // AddConnectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderThickness = 0;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(485, 372);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "AddConnectionView";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Text = "Add database connection";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageAdv1.ResumeLayout(false);
            this.tabPageAdv1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private TextBoxExt txtPassword;
        private TextBoxExt txtUserName;
        private TextBoxExt txtDatabase;
        private TextBoxExt txtPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private TextBoxExt txtHost;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv2;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv3;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnTestConnection;
    }
}