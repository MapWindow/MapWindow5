namespace MW5.Plugins.Symbology.Controls
{
    partial class OverviewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverviewControl));
            this.configPanelControl1 = new MW5.UI.Controls.ConfigPanelControl();
            this.cboCompression = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearOverviews = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuildOverviews = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cboOverviewType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboOverviewSampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this._overviewGrid1 = new MW5.Plugins.Symbology.Controls.OverviewGrid();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).BeginInit();
            this.configPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewSampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._overviewGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl1
            // 
            this.configPanelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configPanelControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl1.Controls.Add(this.cboCompression);
            this.configPanelControl1.Controls.Add(this.label1);
            this.configPanelControl1.Controls.Add(this._overviewGrid1);
            this.configPanelControl1.Controls.Add(this.btnClearOverviews);
            this.configPanelControl1.Controls.Add(this.label8);
            this.configPanelControl1.Controls.Add(this.btnBuildOverviews);
            this.configPanelControl1.Controls.Add(this.cboOverviewType);
            this.configPanelControl1.Controls.Add(this.label6);
            this.configPanelControl1.Controls.Add(this.label10);
            this.configPanelControl1.Controls.Add(this.cboOverviewSampling);
            this.configPanelControl1.HeaderText = "Pyramid generation";
            this.configPanelControl1.Location = new System.Drawing.Point(4, 111);
            this.configPanelControl1.Name = "configPanelControl1";
            this.configPanelControl1.Size = new System.Drawing.Size(500, 228);
            this.configPanelControl1.TabIndex = 52;
            // 
            // cboCompression
            // 
            this.cboCompression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCompression.BeforeTouchSize = new System.Drawing.Size(235, 21);
            this.cboCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboCompression.Location = new System.Drawing.Point(10, 153);
            this.cboCompression.Name = "cboCompression";
            this.cboCompression.Size = new System.Drawing.Size(235, 21);
            this.cboCompression.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Compression:";
            // 
            // btnClearOverviews
            // 
            this.btnClearOverviews.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnClearOverviews.IsBackStageButton = false;
            this.btnClearOverviews.Location = new System.Drawing.Point(92, 190);
            this.btnClearOverviews.Name = "btnClearOverviews";
            this.btnClearOverviews.Size = new System.Drawing.Size(75, 23);
            this.btnClearOverviews.TabIndex = 48;
            this.btnClearOverviews.Text = "Clear";
            this.btnClearOverviews.Click += new System.EventHandler(this.btnClearOverviews_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Overview format:";
            // 
            // btnBuildOverviews
            // 
            this.btnBuildOverviews.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnBuildOverviews.IsBackStageButton = false;
            this.btnBuildOverviews.Location = new System.Drawing.Point(11, 190);
            this.btnBuildOverviews.Name = "btnBuildOverviews";
            this.btnBuildOverviews.Size = new System.Drawing.Size(75, 23);
            this.btnBuildOverviews.TabIndex = 47;
            this.btnBuildOverviews.Text = "Generate";
            this.btnBuildOverviews.Click += new System.EventHandler(this.btnBuildOverviews_Click);
            // 
            // cboOverviewType
            // 
            this.cboOverviewType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOverviewType.BeforeTouchSize = new System.Drawing.Size(234, 21);
            this.cboOverviewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOverviewType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOverviewType.Location = new System.Drawing.Point(11, 53);
            this.cboOverviewType.Name = "cboOverviewType";
            this.cboOverviewType.Size = new System.Drawing.Size(234, 21);
            this.cboOverviewType.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Resampling method:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Available scales:";
            // 
            // cboOverviewSampling
            // 
            this.cboOverviewSampling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOverviewSampling.BeforeTouchSize = new System.Drawing.Size(235, 21);
            this.cboOverviewSampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOverviewSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOverviewSampling.Location = new System.Drawing.Point(10, 102);
            this.cboOverviewSampling.Name = "cboOverviewSampling";
            this.cboOverviewSampling.Size = new System.Drawing.Size(235, 21);
            this.cboOverviewSampling.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(56, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(431, 78);
            this.label9.TabIndex = 51;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(18, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // _overviewGrid1
            // 
            this._overviewGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._overviewGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this._overviewGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this._overviewGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this._overviewGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this._overviewGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this._overviewGrid1.BackColor = System.Drawing.SystemColors.Window;
            this._overviewGrid1.FreezeCaption = false;
            this._overviewGrid1.Location = new System.Drawing.Point(264, 53);
            this._overviewGrid1.Name = "_overviewGrid1";
            this._overviewGrid1.Size = new System.Drawing.Size(233, 160);
            this._overviewGrid1.TabIndex = 49;
            this._overviewGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this._overviewGrid1.TableOptions.AllowDropDownCell = true;
            this._overviewGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this._overviewGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this._overviewGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this._overviewGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this._overviewGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this._overviewGrid1.Text = "overviewGrid1";
            this._overviewGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this._overviewGrid1.TopLevelGroupOptions.ShowCaption = false;
            this._overviewGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this._overviewGrid1.VersionInfo = "0.0.1.0";
            this._overviewGrid1.WrapWithPanel = true;
            // 
            // OverviewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configPanelControl1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox2);
            this.Name = "OverviewControl";
            this.Size = new System.Drawing.Size(513, 344);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl1)).EndInit();
            this.configPanelControl1.ResumeLayout(false);
            this.configPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewSampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._overviewGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.Controls.ConfigPanelControl configPanelControl1;
        private Syncfusion.Windows.Forms.ButtonAdv btnClearOverviews;
        private System.Windows.Forms.Label label8;
        private Syncfusion.Windows.Forms.ButtonAdv btnBuildOverviews;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboOverviewType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboOverviewSampling;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboCompression;
        private System.Windows.Forms.Label label1;
        private OverviewGrid _overviewGrid1;
    }
}
