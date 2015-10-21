using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Configuration
{
    partial class TilesConfigPage
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
            this.components = new System.ComponentModel.Container();
            this.configPanelControl3 = new MW5.UI.Controls.ConfigPanelControl();
            this.label9 = new System.Windows.Forms.Label();
            this.chkUseDiskCache = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpen = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxDiskSize = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.btnCreate = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.txtDiskSize = new System.Windows.Forms.TextBox();
            this.cboMaxAge = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.txtProxyUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkAutodetectProxy = new System.Windows.Forms.CheckBox();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.txtProxyPassword = new System.Windows.Forms.MaskedTextBox();
            this.txtProxyAddress = new MW5.UI.Controls.WatermarkTextbox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this.chkWmsCaching = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).BeginInit();
            this.configPanelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxDiskSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaxAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProxyAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // configPanelControl3
            // 
            this.configPanelControl3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl3.Controls.Add(this.label9);
            this.configPanelControl3.Controls.Add(this.chkUseDiskCache);
            this.configPanelControl3.Controls.Add(this.label4);
            this.configPanelControl3.Controls.Add(this.btnOpen);
            this.configPanelControl3.Controls.Add(this.label2);
            this.configPanelControl3.Controls.Add(this.txtMaxDiskSize);
            this.configPanelControl3.Controls.Add(this.btnCreate);
            this.configPanelControl3.Controls.Add(this.label3);
            this.configPanelControl3.Controls.Add(this.txtFilename);
            this.configPanelControl3.Controls.Add(this.txtDiskSize);
            this.configPanelControl3.Controls.Add(this.cboMaxAge);
            this.configPanelControl3.Controls.Add(this.btnClear);
            this.configPanelControl3.Controls.Add(this.label5);
            this.configPanelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl3.HeaderText = "Disk Cache";
            this.configPanelControl3.Location = new System.Drawing.Point(0, 179);
            this.configPanelControl3.Name = "configPanelControl3";
            this.configPanelControl3.Size = new System.Drawing.Size(443, 215);
            this.configPanelControl3.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Database name:";
            // 
            // chkUseDiskCache
            // 
            this.chkUseDiskCache.AutoSize = true;
            this.chkUseDiskCache.Location = new System.Drawing.Point(25, 88);
            this.chkUseDiskCache.Name = "chkUseDiskCache";
            this.chkUseDiskCache.Size = new System.Drawing.Size(100, 17);
            this.chkUseDiskCache.TabIndex = 12;
            this.chkUseDiskCache.Text = "Use disk cache";
            this.chkUseDiskCache.UseVisualStyleBackColor = true;
            this.chkUseDiskCache.CheckedChanged += new System.EventHandler(this.RefreshControls);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "MB";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.BeforeTouchSize = new System.Drawing.Size(65, 25);
            this.btnOpen.IsBackStageButton = false;
            this.btnOpen.Location = new System.Drawing.Point(285, 83);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(65, 25);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.OnOpenClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Maximum file size";
            // 
            // txtMaxDiskSize
            // 
            this.txtMaxDiskSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxDiskSize.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMaxDiskSize.BeforeTouchSize = new System.Drawing.Size(301, 20);
            this.txtMaxDiskSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaxDiskSize.DoubleValue = 1D;
            this.txtMaxDiskSize.Location = new System.Drawing.Point(321, 133);
            this.txtMaxDiskSize.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMaxDiskSize.Name = "txtMaxDiskSize";
            this.txtMaxDiskSize.NullString = "";
            this.txtMaxDiskSize.NumberDecimalDigits = 1;
            this.txtMaxDiskSize.Size = new System.Drawing.Size(71, 20);
            this.txtMaxDiskSize.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMaxDiskSize.TabIndex = 14;
            this.txtMaxDiskSize.Text = "1.0";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BeforeTouchSize = new System.Drawing.Size(65, 25);
            this.btnCreate.IsBackStageButton = false;
            this.btnCreate.Location = new System.Drawing.Point(214, 83);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(65, 25);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.OnCreateClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Remove tiles older than";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(25, 57);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(396, 20);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.TextChanged += new System.EventHandler(this.OnFilenameChanged);
            // 
            // txtDiskSize
            // 
            this.txtDiskSize.Location = new System.Drawing.Point(146, 133);
            this.txtDiskSize.Name = "txtDiskSize";
            this.txtDiskSize.ReadOnly = true;
            this.txtDiskSize.Size = new System.Drawing.Size(133, 20);
            this.txtDiskSize.TabIndex = 11;
            // 
            // cboMaxAge
            // 
            this.cboMaxAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaxAge.BeforeTouchSize = new System.Drawing.Size(275, 21);
            this.cboMaxAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaxAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMaxAge.Location = new System.Drawing.Point(146, 172);
            this.cboMaxAge.Name = "cboMaxAge";
            this.cboMaxAge.Size = new System.Drawing.Size(275, 21);
            this.cboMaxAge.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(65, 25);
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(356, 83);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 25);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnClearClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "from";
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.txtProxyUserName);
            this.configPanelControl2.Controls.Add(this.label11);
            this.configPanelControl2.Controls.Add(this.chkAutodetectProxy);
            this.configPanelControl2.Controls.Add(this.chkUseProxy);
            this.configPanelControl2.Controls.Add(this.txtProxyPassword);
            this.configPanelControl2.Controls.Add(this.txtProxyAddress);
            this.configPanelControl2.Controls.Add(this.label10);
            this.configPanelControl2.Controls.Add(this.label1);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Proxy Settings";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(443, 179);
            this.configPanelControl2.TabIndex = 21;
            // 
            // txtProxyUserName
            // 
            this.txtProxyUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProxyUserName.Location = new System.Drawing.Point(120, 82);
            this.txtProxyUserName.Name = "txtProxyUserName";
            this.txtProxyUserName.Size = new System.Drawing.Size(301, 20);
            this.txtProxyUserName.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Proxy user name";
            // 
            // chkAutodetectProxy
            // 
            this.chkAutodetectProxy.AutoSize = true;
            this.chkAutodetectProxy.Location = new System.Drawing.Point(209, 145);
            this.chkAutodetectProxy.Name = "chkAutodetectProxy";
            this.chkAutodetectProxy.Size = new System.Drawing.Size(106, 17);
            this.chkAutodetectProxy.TabIndex = 17;
            this.chkAutodetectProxy.Text = "Autodetect proxy";
            this.chkAutodetectProxy.UseVisualStyleBackColor = true;
            this.chkAutodetectProxy.CheckedChanged += new System.EventHandler(this.RefreshControls);
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Location = new System.Drawing.Point(120, 145);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(73, 17);
            this.chkUseProxy.TabIndex = 16;
            this.chkUseProxy.Text = "Use proxy";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            this.chkUseProxy.CheckedChanged += new System.EventHandler(this.RefreshControls);
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProxyPassword.Location = new System.Drawing.Point(120, 119);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.Size = new System.Drawing.Size(301, 20);
            this.txtProxyPassword.TabIndex = 15;
            // 
            // txtProxyAddress
            // 
            this.txtProxyAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProxyAddress.BeforeTouchSize = new System.Drawing.Size(301, 20);
            this.txtProxyAddress.Cue = "127.0.0.1:8080";
            this.txtProxyAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProxyAddress.Location = new System.Drawing.Point(120, 45);
            this.txtProxyAddress.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtProxyAddress.Name = "txtProxyAddress";
            this.txtProxyAddress.ShowClearButton = false;
            this.txtProxyAddress.Size = new System.Drawing.Size(301, 20);
            this.txtProxyAddress.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtProxyAddress.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Proxy password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proxy address";
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.chkWmsCaching);
            this.configPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl1.HeaderText = "WMS layers";
            this.configPanelControl1.Location = new System.Drawing.Point(0, 394);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(443, 68);
            this.configPanelControl1.TabIndex = 19;
            // 
            // chkWmsCaching
            // 
            this.chkWmsCaching.AutoSize = true;
            this.chkWmsCaching.Location = new System.Drawing.Point(25, 37);
            this.chkWmsCaching.Name = "chkWmsCaching";
            this.chkWmsCaching.Size = new System.Drawing.Size(136, 17);
            this.chkWmsCaching.TabIndex = 1;
            this.chkWmsCaching.Text = "Add data to disk cache";
            this.chkWmsCaching.UseVisualStyleBackColor = true;
            // 
            // TilesConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configPanelControl1);
            this.Controls.Add(this.configPanelControl3);
            this.Controls.Add(this.configPanelControl2);
            this.Name = "TilesConfigPage";
            this.Size = new System.Drawing.Size(443, 473);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).EndInit();
            this.configPanelControl3.ResumeLayout(false);
            this.configPanelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxDiskSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaxAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProxyAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiskSize;
        private System.Windows.Forms.Label label5;
        private ComboBoxAdv cboMaxAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ButtonAdv btnCreate;
        private ButtonAdv btnOpen;
        private System.Windows.Forms.TextBox txtFilename;
        private UI.Controls.ConfigPanelControl configPanelControl3;
        private System.Windows.Forms.CheckBox chkUseDiskCache;
        private ButtonAdv btnClear;
        private DoubleTextBox txtMaxDiskSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private UI.Controls.ConfigPanelControl configPanelControl2;
        private System.Windows.Forms.CheckBox chkAutodetectProxy;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.MaskedTextBox txtProxyPassword;
        private UI.Controls.WatermarkTextbox txtProxyAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProxyUserName;
        private System.Windows.Forms.Label label11;
        private UI.Controls.ConfigPanelControl configPanelControl1;
        private System.Windows.Forms.CheckBox chkWmsCaching;
    }
}
