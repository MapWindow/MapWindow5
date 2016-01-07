using System.Windows.Forms;
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
            this.tabPostGis = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPostGisHost = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtPostGisPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtPostGisUserName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtPostGisDatabase = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtPostGisPort = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabMsSql = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMssqlConnection = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMssqlServer = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMssqlDatabase = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optSqlAuthentication = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.optWindowsAuthentication = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.txtMssqlUserName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMssqlPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.tabSqlite = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnChooseSpatialLite = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSpatiaLiteDatabase = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.tabMySql = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMySqlPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtMySqlUser = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtMySqlDatabase = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtMySqlPort = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMySqlHost = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label16 = new System.Windows.Forms.Label();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnTestConnection = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPostGis.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisPort)).BeginInit();
            this.tabMsSql.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMssqlServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMssqlDatabase)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optSqlAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optWindowsAuthentication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMssqlUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMssqlPassword)).BeginInit();
            this.tabSqlite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpatiaLiteDatabase)).BeginInit();
            this.tabMySql.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlHost)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(488, 367);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControlAdv1.BorderWidth = 0;
            this.tabControlAdv1.Controls.Add(this.tabPostGis);
            this.tabControlAdv1.Controls.Add(this.tabMsSql);
            this.tabControlAdv1.Controls.Add(this.tabSqlite);
            this.tabControlAdv1.Controls.Add(this.tabMySql);
            this.tabControlAdv1.FixedSingleBorderColor = System.Drawing.Color.Silver;
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(120, 50);
            this.tabControlAdv1.Location = new System.Drawing.Point(7, 7);
            this.tabControlAdv1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Padding = new System.Drawing.Point(6, 12);
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(488, 367);
            this.tabControlAdv1.TabIndex = 0;
            this.tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererBlendLight);
            this.tabControlAdv1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.tabControlAdv1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.tabControlAdv1.SelectedIndexChanged += new System.EventHandler(this.OnTabControlSelectedIndexChanged);
            // 
            // tabPostGis
            // 
            this.tabPostGis.Controls.Add(this.panel2);
            this.tabPostGis.Image = global::MW5.Data.Properties.Resources.img_postgis;
            this.tabPostGis.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPostGis.Location = new System.Drawing.Point(120, 1);
            this.tabPostGis.Name = "tabPostGis";
            this.tabPostGis.ShowCloseButton = true;
            this.tabPostGis.Size = new System.Drawing.Size(367, 365);
            this.tabPostGis.TabIndex = 1;
            this.tabPostGis.Text = "PostGIS";
            this.tabPostGis.ThemesEnabled = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPostGisHost);
            this.panel2.Controls.Add(this.txtPostGisPassword);
            this.panel2.Controls.Add(this.txtPostGisUserName);
            this.panel2.Controls.Add(this.txtPostGisDatabase);
            this.panel2.Controls.Add(this.txtPostGisPort);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(17, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 270);
            this.panel2.TabIndex = 0;
            this.panel2.TabStop = true;
            // 
            // txtPostGisHost
            // 
            this.txtPostGisHost.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtPostGisHost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPostGisHost.Location = new System.Drawing.Point(91, 15);
            this.txtPostGisHost.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPostGisHost.Name = "txtPostGisHost";
            this.txtPostGisHost.Size = new System.Drawing.Size(224, 20);
            this.txtPostGisHost.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPostGisHost.TabIndex = 0;
            this.txtPostGisHost.Text = "127.0.0.1";
            // 
            // txtPostGisPassword
            // 
            this.txtPostGisPassword.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtPostGisPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPostGisPassword.Location = new System.Drawing.Point(91, 207);
            this.txtPostGisPassword.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPostGisPassword.Name = "txtPostGisPassword";
            this.txtPostGisPassword.PasswordChar = '●';
            this.txtPostGisPassword.Size = new System.Drawing.Size(224, 20);
            this.txtPostGisPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPostGisPassword.TabIndex = 4;
            this.txtPostGisPassword.UseSystemPasswordChar = true;
            // 
            // txtPostGisUserName
            // 
            this.txtPostGisUserName.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtPostGisUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPostGisUserName.Location = new System.Drawing.Point(91, 159);
            this.txtPostGisUserName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPostGisUserName.Name = "txtPostGisUserName";
            this.txtPostGisUserName.Size = new System.Drawing.Size(224, 20);
            this.txtPostGisUserName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPostGisUserName.TabIndex = 3;
            this.txtPostGisUserName.Text = "postgres";
            // 
            // txtPostGisDatabase
            // 
            this.txtPostGisDatabase.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtPostGisDatabase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPostGisDatabase.Location = new System.Drawing.Point(91, 111);
            this.txtPostGisDatabase.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPostGisDatabase.Name = "txtPostGisDatabase";
            this.txtPostGisDatabase.Size = new System.Drawing.Size(224, 20);
            this.txtPostGisDatabase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPostGisDatabase.TabIndex = 2;
            // 
            // txtPostGisPort
            // 
            this.txtPostGisPort.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtPostGisPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPostGisPort.Location = new System.Drawing.Point(91, 63);
            this.txtPostGisPort.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPostGisPort.Name = "txtPostGisPort";
            this.txtPostGisPort.Size = new System.Drawing.Size(224, 20);
            this.txtPostGisPort.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPostGisPort.TabIndex = 1;
            this.txtPostGisPort.Text = "5432";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "User name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Host";
            // 
            // tabMsSql
            // 
            this.tabMsSql.Controls.Add(this.groupBox3);
            this.tabMsSql.Controls.Add(this.groupBox2);
            this.tabMsSql.Controls.Add(this.groupBox1);
            this.tabMsSql.Image = global::MW5.Data.Properties.Resources.img_mssql24;
            this.tabMsSql.ImageSize = new System.Drawing.Size(24, 24);
            this.tabMsSql.Location = new System.Drawing.Point(120, 1);
            this.tabMsSql.Name = "tabMsSql";
            this.tabMsSql.ShowCloseButton = true;
            this.tabMsSql.Size = new System.Drawing.Size(367, 365);
            this.tabMsSql.TabIndex = 2;
            this.tabMsSql.Text = "MS SQL";
            this.tabMsSql.ThemesEnabled = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMssqlConnection);
            this.groupBox3.Location = new System.Drawing.Point(13, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 105);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connection string";
            // 
            // txtMssqlConnection
            // 
            this.txtMssqlConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMssqlConnection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMssqlConnection.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMssqlConnection.Location = new System.Drawing.Point(6, 19);
            this.txtMssqlConnection.Multiline = true;
            this.txtMssqlConnection.Name = "txtMssqlConnection";
            this.txtMssqlConnection.Size = new System.Drawing.Size(329, 80);
            this.txtMssqlConnection.TabIndex = 24;
            this.txtMssqlConnection.TextChanged += new System.EventHandler(this.RawConnectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMssqlServer);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMssqlDatabase);
            this.groupBox2.Location = new System.Drawing.Point(13, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 94);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server and database";
            // 
            // txtMssqlServer
            // 
            this.txtMssqlServer.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMssqlServer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMssqlServer.Location = new System.Drawing.Point(92, 23);
            this.txtMssqlServer.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMssqlServer.Name = "txtMssqlServer";
            this.txtMssqlServer.Size = new System.Drawing.Size(224, 20);
            this.txtMssqlServer.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMssqlServer.TabIndex = 11;
            this.txtMssqlServer.Text = ".\\";
            this.txtMssqlServer.TextChanged += new System.EventHandler(this.ParametersChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Server";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Database";
            // 
            // txtMssqlDatabase
            // 
            this.txtMssqlDatabase.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMssqlDatabase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMssqlDatabase.Location = new System.Drawing.Point(92, 60);
            this.txtMssqlDatabase.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMssqlDatabase.Name = "txtMssqlDatabase";
            this.txtMssqlDatabase.Size = new System.Drawing.Size(224, 20);
            this.txtMssqlDatabase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMssqlDatabase.TabIndex = 12;
            this.txtMssqlDatabase.TextChanged += new System.EventHandler(this.ParametersChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optSqlAuthentication);
            this.groupBox1.Controls.Add(this.optWindowsAuthentication);
            this.groupBox1.Controls.Add(this.txtMssqlUserName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMssqlPassword);
            this.groupBox1.Location = new System.Drawing.Point(13, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 120);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication";
            // 
            // optSqlAuthentication
            // 
            this.optSqlAuthentication.BeforeTouchSize = new System.Drawing.Size(107, 21);
            this.optSqlAuthentication.Location = new System.Drawing.Point(134, 15);
            this.optSqlAuthentication.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optSqlAuthentication.Name = "optSqlAuthentication";
            this.optSqlAuthentication.Size = new System.Drawing.Size(107, 21);
            this.optSqlAuthentication.TabIndex = 23;
            this.optSqlAuthentication.TabStop = false;
            this.optSqlAuthentication.Text = "SQL Server";
            this.optSqlAuthentication.ThemesEnabled = false;
            this.optSqlAuthentication.CheckChanged += new System.EventHandler(this.optSqlAuthentication_CheckChanged);
            // 
            // optWindowsAuthentication
            // 
            this.optWindowsAuthentication.BeforeTouchSize = new System.Drawing.Size(75, 21);
            this.optWindowsAuthentication.Checked = true;
            this.optWindowsAuthentication.Location = new System.Drawing.Point(247, 15);
            this.optWindowsAuthentication.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optWindowsAuthentication.Name = "optWindowsAuthentication";
            this.optWindowsAuthentication.Size = new System.Drawing.Size(75, 21);
            this.optWindowsAuthentication.TabIndex = 24;
            this.optWindowsAuthentication.Text = "Windows";
            this.optWindowsAuthentication.ThemesEnabled = false;
            // 
            // txtMssqlUserName
            // 
            this.txtMssqlUserName.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMssqlUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMssqlUserName.Location = new System.Drawing.Point(92, 43);
            this.txtMssqlUserName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMssqlUserName.Name = "txtMssqlUserName";
            this.txtMssqlUserName.Size = new System.Drawing.Size(224, 20);
            this.txtMssqlUserName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMssqlUserName.TabIndex = 21;
            this.txtMssqlUserName.TextChanged += new System.EventHandler(this.ParametersChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "User name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Password";
            // 
            // txtMssqlPassword
            // 
            this.txtMssqlPassword.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMssqlPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMssqlPassword.Location = new System.Drawing.Point(92, 79);
            this.txtMssqlPassword.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMssqlPassword.Name = "txtMssqlPassword";
            this.txtMssqlPassword.PasswordChar = '●';
            this.txtMssqlPassword.Size = new System.Drawing.Size(224, 20);
            this.txtMssqlPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMssqlPassword.TabIndex = 22;
            this.txtMssqlPassword.UseSystemPasswordChar = true;
            this.txtMssqlPassword.TextChanged += new System.EventHandler(this.ParametersChanged);
            // 
            // tabSqlite
            // 
            this.tabSqlite.Controls.Add(this.btnChooseSpatialLite);
            this.tabSqlite.Controls.Add(this.label11);
            this.tabSqlite.Controls.Add(this.txtSpatiaLiteDatabase);
            this.tabSqlite.Image = global::MW5.Data.Properties.Resources.img_sqlite24;
            this.tabSqlite.ImageSize = new System.Drawing.Size(24, 24);
            this.tabSqlite.Location = new System.Drawing.Point(120, 1);
            this.tabSqlite.Name = "tabSqlite";
            this.tabSqlite.ShowCloseButton = true;
            this.tabSqlite.Size = new System.Drawing.Size(367, 365);
            this.tabSqlite.TabIndex = 3;
            this.tabSqlite.Text = "SpatiaLite";
            this.tabSqlite.ThemesEnabled = false;
            // 
            // btnChooseSpatialLite
            // 
            this.btnChooseSpatialLite.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnChooseSpatialLite.IsBackStageButton = false;
            this.btnChooseSpatialLite.Location = new System.Drawing.Point(275, 60);
            this.btnChooseSpatialLite.Name = "btnChooseSpatialLite";
            this.btnChooseSpatialLite.Size = new System.Drawing.Size(75, 23);
            this.btnChooseSpatialLite.TabIndex = 2;
            this.btnChooseSpatialLite.Text = "Choose database";
            this.btnChooseSpatialLite.Click += new System.EventHandler(this.btnChooseSpatialLite_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Database:";
            // 
            // txtSpatiaLiteDatabase
            // 
            this.txtSpatiaLiteDatabase.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtSpatiaLiteDatabase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSpatiaLiteDatabase.Location = new System.Drawing.Point(20, 34);
            this.txtSpatiaLiteDatabase.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSpatiaLiteDatabase.Name = "txtSpatiaLiteDatabase";
            this.txtSpatiaLiteDatabase.Size = new System.Drawing.Size(330, 20);
            this.txtSpatiaLiteDatabase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtSpatiaLiteDatabase.TabIndex = 0;
            // 
            // tabMySql
            // 
            this.tabMySql.Controls.Add(this.panel1);
            this.tabMySql.Image = global::MW5.Data.Properties.Resources.img_mysql2_24;
            this.tabMySql.ImageSize = new System.Drawing.Size(24, 24);
            this.tabMySql.Location = new System.Drawing.Point(120, 1);
            this.tabMySql.Name = "tabMySql";
            this.tabMySql.ShowCloseButton = true;
            this.tabMySql.Size = new System.Drawing.Size(367, 365);
            this.tabMySql.TabIndex = 5;
            this.tabMySql.Text = "MySQL";
            this.tabMySql.ThemesEnabled = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtMySqlPassword);
            this.panel1.Controls.Add(this.txtMySqlUser);
            this.panel1.Controls.Add(this.txtMySqlDatabase);
            this.panel1.Controls.Add(this.txtMySqlPort);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtMySqlHost);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Location = new System.Drawing.Point(17, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 270);
            this.panel1.TabIndex = 17;
            // 
            // txtMySqlPassword
            // 
            this.txtMySqlPassword.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMySqlPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMySqlPassword.Location = new System.Drawing.Point(91, 207);
            this.txtMySqlPassword.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMySqlPassword.Name = "txtMySqlPassword";
            this.txtMySqlPassword.PasswordChar = '●';
            this.txtMySqlPassword.Size = new System.Drawing.Size(224, 20);
            this.txtMySqlPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMySqlPassword.TabIndex = 4;
            this.txtMySqlPassword.UseSystemPasswordChar = true;
            // 
            // txtMySqlUser
            // 
            this.txtMySqlUser.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMySqlUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMySqlUser.Location = new System.Drawing.Point(91, 159);
            this.txtMySqlUser.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMySqlUser.Name = "txtMySqlUser";
            this.txtMySqlUser.Size = new System.Drawing.Size(224, 20);
            this.txtMySqlUser.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMySqlUser.TabIndex = 3;
            this.txtMySqlUser.Text = "root";
            // 
            // txtMySqlDatabase
            // 
            this.txtMySqlDatabase.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMySqlDatabase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMySqlDatabase.Location = new System.Drawing.Point(91, 111);
            this.txtMySqlDatabase.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMySqlDatabase.Name = "txtMySqlDatabase";
            this.txtMySqlDatabase.Size = new System.Drawing.Size(224, 20);
            this.txtMySqlDatabase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMySqlDatabase.TabIndex = 2;
            // 
            // txtMySqlPort
            // 
            this.txtMySqlPort.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMySqlPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMySqlPort.Location = new System.Drawing.Point(91, 63);
            this.txtMySqlPort.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMySqlPort.Name = "txtMySqlPort";
            this.txtMySqlPort.Size = new System.Drawing.Size(224, 20);
            this.txtMySqlPort.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMySqlPort.TabIndex = 1;
            this.txtMySqlPort.Text = "3306";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 210);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Password";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "User name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 114);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Database";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Port";
            // 
            // txtMySqlHost
            // 
            this.txtMySqlHost.BeforeTouchSize = new System.Drawing.Size(224, 20);
            this.txtMySqlHost.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMySqlHost.Location = new System.Drawing.Point(91, 15);
            this.txtMySqlHost.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMySqlHost.Name = "txtMySqlHost";
            this.txtMySqlHost.Size = new System.Drawing.Size(224, 20);
            this.txtMySqlHost.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMySqlHost.TabIndex = 0;
            this.txtMySqlHost.Text = "127.0.0.1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "Host";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(410, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(319, 383);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnTestConnection.BeforeTouchSize = new System.Drawing.Size(104, 26);
            this.btnTestConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.IsBackStageButton = false;
            this.btnTestConnection.Location = new System.Drawing.Point(8, 383);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(104, 26);
            this.btnTestConnection.TabIndex = 3;
            this.btnTestConnection.Text = "Test connection";
            // 
            // AddConnectionView
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(502, 419);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControlAdv1);
            this.Name = "AddConnectionView";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.Text = "Add Database Connection";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPostGis.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostGisPort)).EndInit();
            this.tabMsSql.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMssqlServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMssqlDatabase)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optSqlAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optWindowsAuthentication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMssqlUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMssqlPassword)).EndInit();
            this.tabSqlite.ResumeLayout(false);
            this.tabSqlite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpatiaLiteDatabase)).EndInit();
            this.tabMySql.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMySqlHost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPostGis;
        private TextBoxExt txtPostGisPassword;
        private TextBoxExt txtPostGisUserName;
        private TextBoxExt txtPostGisDatabase;
        private TextBoxExt txtPostGisPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private TextBoxExt txtPostGisHost;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabMsSql;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabSqlite;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.ButtonAdv btnTestConnection;
        private System.Windows.Forms.GroupBox groupBox1;
        private TextBoxExt txtMssqlUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private TextBoxExt txtMssqlPassword;
        private TextBox txtMssqlConnection;
        private TextBoxExt txtMssqlDatabase;
        private TextBoxExt txtMssqlServer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private RadioButtonAdv optSqlAuthentication;
        private RadioButtonAdv optWindowsAuthentication;
        private System.Windows.Forms.GroupBox groupBox2;
        private Syncfusion.Windows.Forms.ButtonAdv btnChooseSpatialLite;
        private System.Windows.Forms.Label label11;
        private TextBoxExt txtSpatiaLiteDatabase;
        private TabPageAdv tabMySql;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private TextBoxExt txtMySqlPassword;
        private TextBoxExt txtMySqlUser;
        private TextBoxExt txtMySqlDatabase;
        private TextBoxExt txtMySqlPort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private TextBoxExt txtMySqlHost;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}