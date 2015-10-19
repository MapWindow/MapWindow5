using MW5.Tools.Controls.Parameters;
using MW5.Tools.Properties;

namespace MW5.Tools.Views
{
    partial class ToolView
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
            Syncfusion.Windows.Forms.Tools.ToolTipInfo toolTipInfo1 = new Syncfusion.Windows.Forms.Tools.ToolTipInfo();
            this.comboBoxAdv2 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRun = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabRequired = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.panelRequired = new System.Windows.Forms.Panel();
            this.tabOptional = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.panelOptional = new System.Windows.Forms.Panel();
            this.tabHelp = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.chkBackground = new System.Windows.Forms.CheckBox();
            this.superToolTip1 = new Syncfusion.Windows.Forms.Tools.SuperToolTip(this);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabRequired.SuspendLayout();
            this.tabOptional.SuspendLayout();
            this.tabHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAdv2
            // 
            this.comboBoxAdv2.BeforeTouchSize = new System.Drawing.Size(282, 21);
            this.comboBoxAdv2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdv2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAdv2.Location = new System.Drawing.Point(70, 32);
            this.comboBoxAdv2.Name = "comboBoxAdv2";
            this.comboBoxAdv2.Size = new System.Drawing.Size(282, 21);
            this.comboBoxAdv2.TabIndex = 3;
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
            this.btnClose.Location = new System.Drawing.Point(471, 408);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.OnCloseClick);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnRun.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.IsBackStageButton = false;
            this.btnRun.Location = new System.Drawing.Point(380, 408);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 26);
            this.btnRun.TabIndex = 33;
            this.btnRun.Text = "Run";
            toolTipInfo1.BackColor = System.Drawing.Color.White;
            toolTipInfo1.Body.Size = new System.Drawing.Size(20, 20);
            toolTipInfo1.Body.Text = "Press Ctrl to run task without closing the dialog. This allows to run several tas" +
    "ks with different inputs in a row.";
            toolTipInfo1.Footer.Size = new System.Drawing.Size(20, 20);
            toolTipInfo1.Header.Size = new System.Drawing.Size(20, 20);
            toolTipInfo1.Header.Text = "Multiple tasks";
            this.superToolTip1.SetToolTip(this.btnRun, toolTipInfo1);
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(550, 390);
            this.tabControlAdv1.Controls.Add(this.tabRequired);
            this.tabControlAdv1.Controls.Add(this.tabOptional);
            this.tabControlAdv1.Controls.Add(this.tabHelp);
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(120, 40);
            this.tabControlAdv1.Location = new System.Drawing.Point(6, 12);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(550, 390);
            this.tabControlAdv1.TabIndex = 35;
            this.tabControlAdv1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // tabRequired
            // 
            this.tabRequired.Controls.Add(this.panelRequired);
            this.tabRequired.Image = global::MW5.Tools.Properties.Resources.img_tools24;
            this.tabRequired.ImageSize = new System.Drawing.Size(24, 24);
            this.tabRequired.Location = new System.Drawing.Point(123, 1);
            this.tabRequired.Name = "tabRequired";
            this.tabRequired.ShowCloseButton = true;
            this.tabRequired.Size = new System.Drawing.Size(425, 387);
            this.tabRequired.TabIndex = 1;
            this.tabRequired.Text = "Required";
            this.tabRequired.ThemesEnabled = false;
            // 
            // panelRequired
            // 
            this.panelRequired.AutoScroll = true;
            this.panelRequired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRequired.Location = new System.Drawing.Point(0, 0);
            this.panelRequired.Name = "panelRequired";
            this.panelRequired.Padding = new System.Windows.Forms.Padding(20, 10, 20, 25);
            this.panelRequired.Size = new System.Drawing.Size(425, 387);
            this.panelRequired.TabIndex = 0;
            // 
            // tabOptional
            // 
            this.tabOptional.Controls.Add(this.panelOptional);
            this.tabOptional.Image = global::MW5.Tools.Properties.Resources.img_options24;
            this.tabOptional.ImageSize = new System.Drawing.Size(24, 24);
            this.tabOptional.Location = new System.Drawing.Point(123, 1);
            this.tabOptional.Name = "tabOptional";
            this.tabOptional.ShowCloseButton = true;
            this.tabOptional.Size = new System.Drawing.Size(425, 387);
            this.tabOptional.TabIndex = 2;
            this.tabOptional.Text = "Optional";
            this.tabOptional.ThemesEnabled = false;
            // 
            // panelOptional
            // 
            this.panelOptional.AutoScroll = true;
            this.panelOptional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOptional.Location = new System.Drawing.Point(0, 0);
            this.panelOptional.Name = "panelOptional";
            this.panelOptional.Padding = new System.Windows.Forms.Padding(20, 10, 20, 25);
            this.panelOptional.Size = new System.Drawing.Size(425, 387);
            this.panelOptional.TabIndex = 0;
            // 
            // tabHelp
            // 
            this.tabHelp.Controls.Add(this.webBrowser1);
            this.tabHelp.Image = global::MW5.Tools.Properties.Resources.img_help24;
            this.tabHelp.ImageSize = new System.Drawing.Size(24, 24);
            this.tabHelp.Location = new System.Drawing.Point(123, 1);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.ShowCloseButton = true;
            this.tabHelp.Size = new System.Drawing.Size(425, 387);
            this.tabHelp.TabIndex = 4;
            this.tabHelp.Text = "Help";
            this.tabHelp.ThemesEnabled = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(425, 387);
            this.webBrowser1.TabIndex = 0;
            // 
            // chkBackground
            // 
            this.chkBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBackground.AutoSize = true;
            this.chkBackground.Location = new System.Drawing.Point(12, 413);
            this.chkBackground.Name = "chkBackground";
            this.chkBackground.Size = new System.Drawing.Size(135, 17);
            this.chkBackground.TabIndex = 36;
            this.chkBackground.Text = "Run in the background";
            this.chkBackground.UseVisualStyleBackColor = true;
            // 
            // superToolTip1
            // 
            this.superToolTip1.MaxWidth = 400;
            this.superToolTip1.Style = Syncfusion.Windows.Forms.Tools.SuperToolTip.SuperToolTipStyle.Office2013Style;
            this.superToolTip1.ToolTipDuration = 5;
            this.superToolTip1.UseFading = Syncfusion.Windows.Forms.Tools.SuperToolTip.FadingType.System;
            // 
            // ToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(565, 437);
            this.Controls.Add(this.chkBackground);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Name = "ToolView";
            this.Text = "ToolView";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabRequired.ResumeLayout(false);
            this.tabOptional.ResumeLayout(false);
            this.tabHelp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboBoxAdv2;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnRun;
        protected Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabRequired;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabOptional;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabHelp;
        private System.Windows.Forms.Panel panelRequired;
        private System.Windows.Forms.Panel panelOptional;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.CheckBox chkBackground;
        protected Syncfusion.Windows.Forms.Tools.SuperToolTip superToolTip1;
    }
}