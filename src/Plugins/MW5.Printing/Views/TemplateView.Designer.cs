namespace MW5.Plugins.Printing.Views
{
    partial class TemplateView
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabMultiPage = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboArea = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboFormat = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTemplate = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.cboScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOrientation = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageAdv1.SuspendLayout();
            this.tabMultiPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrientation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(460, 288);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv1);
            this.tabControlAdv1.Controls.Add(this.tabMultiPage);
            this.tabControlAdv1.Location = new System.Drawing.Point(8, 5);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Size = new System.Drawing.Size(460, 288);
            this.tabControlAdv1.TabIndex = 4;
            // 
            // tabPageAdv1
            // 
            this.tabPageAdv1.Controls.Add(this.listBox1);
            this.tabPageAdv1.Image = null;
            this.tabPageAdv1.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv1.Location = new System.Drawing.Point(1, 25);
            this.tabPageAdv1.Name = "tabPageAdv1";
            this.tabPageAdv1.ShowCloseButton = true;
            this.tabPageAdv1.Size = new System.Drawing.Size(457, 261);
            this.tabPageAdv1.TabIndex = 1;
            this.tabPageAdv1.Text = "Single page";
            this.tabPageAdv1.ThemesEnabled = false;
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Template 1 [Horizontal]",
            "Template 2 [Vertical]",
            "Template 3 [Horizontal]",
            "Template 4 [Vertical]",
            "Template 5 [Vertical]",
            "Template 6 [Horizontal]",
            "Template 7 [Vertical]"});
            this.listBox1.Location = new System.Drawing.Point(27, 112);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(403, 130);
            this.listBox1.TabIndex = 0;
            // 
            // tabMultiPage
            // 
            this.tabMultiPage.Controls.Add(this.lblArea);
            this.tabMultiPage.Controls.Add(this.lblWarning);
            this.tabMultiPage.Controls.Add(this.lblPages);
            this.tabMultiPage.Controls.Add(this.label2);
            this.tabMultiPage.Controls.Add(this.cboArea);
            this.tabMultiPage.Controls.Add(this.cboFormat);
            this.tabMultiPage.Controls.Add(this.label7);
            this.tabMultiPage.Controls.Add(this.cboTemplate);
            this.tabMultiPage.Controls.Add(this.label5);
            this.tabMultiPage.Controls.Add(this.cboScale);
            this.tabMultiPage.Controls.Add(this.label4);
            this.tabMultiPage.Controls.Add(this.cboOrientation);
            this.tabMultiPage.Controls.Add(this.label3);
            this.tabMultiPage.Image = null;
            this.tabMultiPage.ImageSize = new System.Drawing.Size(16, 16);
            this.tabMultiPage.Location = new System.Drawing.Point(1, 25);
            this.tabMultiPage.Name = "tabMultiPage";
            this.tabMultiPage.ShowCloseButton = true;
            this.tabMultiPage.Size = new System.Drawing.Size(457, 261);
            this.tabMultiPage.TabIndex = 2;
            this.tabMultiPage.Text = "Multipage";
            this.tabMultiPage.ThemesEnabled = false;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(347, 34);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(84, 13);
            this.lblArea.TabIndex = 15;
            this.lblArea.Text = "1000 × 1000 km";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(28, 221);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(350, 13);
            this.lblWarning.TabIndex = 14;
            this.lblWarning.Text = "The layout size is too large. Consider choosing smaller scale or map area.";
            this.lblWarning.Visible = false;
            // 
            // lblPages
            // 
            this.lblPages.AutoSize = true;
            this.lblPages.Location = new System.Drawing.Point(347, 73);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(67, 13);
            this.lblPages.TabIndex = 13;
            this.lblPages.Text = "Pages: 2 × 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Paper format";
            // 
            // cboArea
            // 
            this.cboArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboArea.BeforeTouchSize = new System.Drawing.Size(226, 21);
            this.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboArea.Location = new System.Drawing.Point(115, 26);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(226, 21);
            this.cboArea.TabIndex = 10;
            this.cboArea.SelectedIndexChanged += new System.EventHandler(this.OnAreaChanged);
            // 
            // cboFormat
            // 
            this.cboFormat.BeforeTouchSize = new System.Drawing.Size(226, 21);
            this.cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboFormat.Location = new System.Drawing.Point(115, 66);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(226, 21);
            this.cboFormat.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Map area";
            // 
            // cboTemplate
            // 
            this.cboTemplate.BeforeTouchSize = new System.Drawing.Size(316, 21);
            this.cboTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboTemplate.Items.AddRange(new object[] {
            "Default"});
            this.cboTemplate.ItemsImageIndexes.Add(new Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(this.cboTemplate, "Default"));
            this.cboTemplate.Location = new System.Drawing.Point(115, 180);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(316, 21);
            this.cboTemplate.TabIndex = 8;
            this.cboTemplate.Text = "Default";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Template";
            // 
            // cboScale
            // 
            this.cboScale.BeforeTouchSize = new System.Drawing.Size(316, 21);
            this.cboScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboScale.Location = new System.Drawing.Point(115, 142);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(316, 21);
            this.cboScale.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Scale";
            // 
            // cboOrientation
            // 
            this.cboOrientation.BeforeTouchSize = new System.Drawing.Size(316, 21);
            this.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrientation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOrientation.Location = new System.Drawing.Point(115, 104);
            this.cboOrientation.Name = "cboOrientation";
            this.cboOrientation.Size = new System.Drawing.Size(316, 21);
            this.cboOrientation.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Orientation";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(81, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(387, 299);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(84, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(297, 299);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 26);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            // 
            // TemplateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(476, 327);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControlAdv1);
            this.Name = "TemplateView";
            this.Text = "Layout Templates";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageAdv1.ResumeLayout(false);
            this.tabMultiPage.ResumeLayout(false);
            this.tabMultiPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrientation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabMultiPage;
        private System.Windows.Forms.ListBox listBox1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboTemplate;
        private System.Windows.Forms.Label label5;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboScale;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboOrientation;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboArea;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Label lblArea;
    }
}