namespace MW5.Attributes.Views
{
    partial class AttributeExplorerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeExplorerView));
            this.label2 = new System.Windows.Forms.Label();
            this.valueCountGrid1 = new MW5.Attributes.Controls.ValueCountGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboField = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtSearch = new MW5.UI.Controls.WatermarkTextbox();
            this.recordNavigationBar1 = new Syncfusion.Windows.Forms.RecordNavigationBar();
            ((System.ComponentModel.ISupportInitialize)(this.valueCountGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Values";
            // 
            // valueCountGrid1
            // 
            this.valueCountGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueCountGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.valueCountGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.valueCountGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.valueCountGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.valueCountGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.valueCountGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.valueCountGrid1.FreezeCaption = false;
            this.valueCountGrid1.Location = new System.Drawing.Point(11, 128);
            this.valueCountGrid1.Name = "valueCountGrid1";
            this.valueCountGrid1.Size = new System.Drawing.Size(342, 203);
            this.valueCountGrid1.TabIndex = 3;
            this.valueCountGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.valueCountGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.valueCountGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.valueCountGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.valueCountGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.valueCountGrid1.Text = "valueCountGrid1";
            this.valueCountGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.valueCountGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.valueCountGrid1.TopLevelGroupOptions.ShowColumnHeaders = false;
            this.valueCountGrid1.VersionInfo = "5.0.1.0";
            this.valueCountGrid1.WrapWithPanel = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Fields";
            // 
            // cboField
            // 
            this.cboField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboField.BeforeTouchSize = new System.Drawing.Size(341, 21);
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboField.Location = new System.Drawing.Point(12, 29);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(341, 21);
            this.cboField.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "Search";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(268, 337);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "Close";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(15, 341);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 17);
            this.checkBox1.TabIndex = 71;
            this.checkBox1.Text = "Zoom to Values";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(341, 20);
            this.txtSearch.Cue = "Enter the value";
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.FarImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.FarImage")));
            this.txtSearch.Location = new System.Drawing.Point(12, 78);
            this.txtSearch.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ShowClearButton = true;
            this.txtSearch.Size = new System.Drawing.Size(341, 20);
            this.txtSearch.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.OnSearchTextChanged);
            // 
            // recordNavigationBar1
            // 
            this.recordNavigationBar1.AllowAddNew = false;
            this.recordNavigationBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordNavigationBar1.ButtonLook = Syncfusion.Windows.Forms.ButtonLook.Flat;
            this.recordNavigationBar1.CausesValidation = false;
            this.recordNavigationBar1.DisplayArrowButtons = Syncfusion.Windows.Forms.DisplayArrowButtons.All;
            this.recordNavigationBar1.Label = "Feature";
            this.recordNavigationBar1.Location = new System.Drawing.Point(102, 109);
            this.recordNavigationBar1.MaxLabel = "of 20";
            this.recordNavigationBar1.MaxRecord = 20;
            this.recordNavigationBar1.Name = "recordNavigationBar1";
            this.recordNavigationBar1.Size = new System.Drawing.Size(248, 16);
            this.recordNavigationBar1.SizeToFit = false;
            this.recordNavigationBar1.TabIndex = 75;
            this.recordNavigationBar1.Text = "recordNavigationBar1";
            this.recordNavigationBar1.ThemesEnabled = true;
            this.recordNavigationBar1.Visible = false;
            // 
            // AttributeExplorerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(362, 373);
            this.Controls.Add(this.recordNavigationBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valueCountGrid1);
            this.Controls.Add(this.label1);
            this.Name = "AttributeExplorerView";
            this.Text = "Attribute Explorer";
            ((System.ComponentModel.ISupportInitialize)(this.valueCountGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Controls.ValueCountGrid valueCountGrid1;
        private System.Windows.Forms.Label label1;
        private UI.Controls.WatermarkTextbox txtSearch;
        private System.Windows.Forms.ToolTip toolTip1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboField;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private System.Windows.Forms.CheckBox checkBox1;
        private Syncfusion.Windows.Forms.RecordNavigationBar recordNavigationBar1;
    }
}