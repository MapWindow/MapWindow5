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
            this.tabNewLayout = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblPages = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboArea = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboFormat = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.lblMapArea = new System.Windows.Forms.Label();
            this.cboScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.cboOrientation = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.tabTemplates = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.templateGrid1 = new MW5.Plugins.Printing.Controls.TemplateGrid();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnFitToPage = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabNewLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrientation)).BeginInit();
            this.tabTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.templateGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(460, 288);
            this.tabControlAdv1.Controls.Add(this.tabNewLayout);
            this.tabControlAdv1.Controls.Add(this.tabTemplates);
            this.tabControlAdv1.Location = new System.Drawing.Point(8, 5);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Size = new System.Drawing.Size(460, 288);
            this.tabControlAdv1.TabIndex = 4;
            this.tabControlAdv1.SelectedIndexChanged += new System.EventHandler(this.OnTabChanged);
            // 
            // tabNewLayout
            // 
            this.tabNewLayout.Controls.Add(this.btnFitToPage);
            this.tabNewLayout.Controls.Add(this.lblArea);
            this.tabNewLayout.Controls.Add(this.lblWarning);
            this.tabNewLayout.Controls.Add(this.lblPages);
            this.tabNewLayout.Controls.Add(this.label2);
            this.tabNewLayout.Controls.Add(this.cboArea);
            this.tabNewLayout.Controls.Add(this.cboFormat);
            this.tabNewLayout.Controls.Add(this.lblMapArea);
            this.tabNewLayout.Controls.Add(this.cboScale);
            this.tabNewLayout.Controls.Add(this.label4);
            this.tabNewLayout.Controls.Add(this.cboOrientation);
            this.tabNewLayout.Controls.Add(this.label3);
            this.tabNewLayout.Image = null;
            this.tabNewLayout.ImageSize = new System.Drawing.Size(16, 16);
            this.tabNewLayout.Location = new System.Drawing.Point(1, 25);
            this.tabNewLayout.Name = "tabNewLayout";
            this.tabNewLayout.ShowCloseButton = true;
            this.tabNewLayout.Size = new System.Drawing.Size(457, 261);
            this.tabNewLayout.TabIndex = 2;
            this.tabNewLayout.Text = "New Layout";
            this.tabNewLayout.ThemesEnabled = false;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(341, 30);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(84, 13);
            this.lblArea.TabIndex = 15;
            this.lblArea.Text = "1000 × 1000 km";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(22, 189);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(350, 13);
            this.lblWarning.TabIndex = 14;
            this.lblWarning.Text = "The layout size is too large. Consider choosing smaller scale or map area.";
            this.lblWarning.Visible = false;
            // 
            // lblPages
            // 
            this.lblPages.AutoSize = true;
            this.lblPages.Location = new System.Drawing.Point(341, 69);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(67, 13);
            this.lblPages.TabIndex = 13;
            this.lblPages.Text = "Pages: 2 × 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 69);
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
            this.cboArea.Location = new System.Drawing.Point(109, 26);
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
            this.cboFormat.Location = new System.Drawing.Point(109, 66);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(226, 21);
            this.cboFormat.TabIndex = 11;
            // 
            // lblMapArea
            // 
            this.lblMapArea.AutoSize = true;
            this.lblMapArea.Location = new System.Drawing.Point(22, 30);
            this.lblMapArea.Name = "lblMapArea";
            this.lblMapArea.Size = new System.Drawing.Size(52, 13);
            this.lblMapArea.TabIndex = 9;
            this.lblMapArea.Text = "Map area";
            // 
            // cboScale
            // 
            this.cboScale.BeforeTouchSize = new System.Drawing.Size(226, 21);
            this.cboScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboScale.Location = new System.Drawing.Point(109, 142);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(226, 21);
            this.cboScale.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 146);
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
            this.cboOrientation.Location = new System.Drawing.Point(109, 104);
            this.cboOrientation.Name = "cboOrientation";
            this.cboOrientation.Size = new System.Drawing.Size(316, 21);
            this.cboOrientation.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Orientation";
            // 
            // tabTemplates
            // 
            this.tabTemplates.Controls.Add(this.templateGrid1);
            this.tabTemplates.Image = null;
            this.tabTemplates.ImageSize = new System.Drawing.Size(16, 16);
            this.tabTemplates.Location = new System.Drawing.Point(1, 25);
            this.tabTemplates.Name = "tabTemplates";
            this.tabTemplates.ShowCloseButton = true;
            this.tabTemplates.Size = new System.Drawing.Size(457, 261);
            this.tabTemplates.TabIndex = 1;
            this.tabTemplates.Text = "Templates";
            this.tabTemplates.ThemesEnabled = false;
            // 
            // templateGrid1
            // 
            this.templateGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.templateGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.templateGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.templateGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.templateGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.templateGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.templateGrid1.FreezeCaption = false;
            this.templateGrid1.Location = new System.Drawing.Point(6, 71);
            this.templateGrid1.Name = "templateGrid1";
            this.templateGrid1.Size = new System.Drawing.Size(445, 184);
            this.templateGrid1.TabIndex = 19;
            this.templateGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.templateGrid1.TableOptions.AllowDropDownCell = false;
            this.templateGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.templateGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.templateGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.templateGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.templateGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.templateGrid1.Text = "templateGrid1";
            this.templateGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.templateGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.templateGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.templateGrid1.VersionInfo = "0.0.1.0";
            this.templateGrid1.WrapWithPanel = true;
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
            // btnFitToPage
            // 
            this.btnFitToPage.BeforeTouchSize = new System.Drawing.Size(78, 23);
            this.btnFitToPage.IsBackStageButton = false;
            this.btnFitToPage.Location = new System.Drawing.Point(347, 140);
            this.btnFitToPage.Name = "btnFitToPage";
            this.btnFitToPage.Size = new System.Drawing.Size(78, 23);
            this.btnFitToPage.TabIndex = 7;
            this.btnFitToPage.Text = "Fit to Page";
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
            this.Text = "Choose Layout";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabNewLayout.ResumeLayout(false);
            this.tabNewLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOrientation)).EndInit();
            this.tabTemplates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.templateGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabTemplates;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabNewLayout;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboScale;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboOrientation;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboArea;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboFormat;
        private System.Windows.Forms.Label lblMapArea;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Label lblArea;
        private Controls.TemplateGrid templateGrid1;
        private Syncfusion.Windows.Forms.ButtonAdv btnFitToPage;
    }
}