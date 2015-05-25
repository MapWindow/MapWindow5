using MW5.Data.Views.Controls;

namespace MW5.Data.Views
{
    partial class DriversView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriversView));
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.driversTreeView1 = new MW5.Data.Views.Controls.DriversTreeView();
            this.txtSearch = new MW5.UI.Controls.WatermarkTextbox();
            this._driverMetadataGrid1 = new MW5.Data.Views.Controls.DriverMetadataGrid();
            this.lblCount = new System.Windows.Forms.Label();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabGeneral = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabCreationOptions = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gridCreationOptions = new MW5.Data.Views.Controls.DriverOptionsGrid();
            this.tabOpenOptions = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gridOpenOptions = new MW5.Data.Views.Controls.DriverOptionsGrid();
            this.tabLayerOptions = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gridLayerOptions = new MW5.Data.Views.Controls.DriverOptionsGrid();
            this.cboFilter = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.driversTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._driverMetadataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabCreationOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCreationOptions)).BeginInit();
            this.tabOpenOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOpenOptions)).BeginInit();
            this.tabLayerOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLayerOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(706, 474);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // driversTreeView1
            // 
            this.driversTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.driversTreeView1.BeforeTouchSize = new System.Drawing.Size(228, 420);
            this.driversTreeView1.BorderColor = System.Drawing.Color.LightGray;
            this.driversTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.driversTreeView1.CanSelectDisabledNode = false;
            // 
            // 
            // 
            this.driversTreeView1.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.driversTreeView1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.driversTreeView1.HelpTextControl.Name = "helpText";
            this.driversTreeView1.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.driversTreeView1.HelpTextControl.TabIndex = 0;
            this.driversTreeView1.HelpTextControl.Text = "help text";
            this.driversTreeView1.InactiveSelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220))))));
            this.driversTreeView1.InactiveSelectedNodeForeColor = System.Drawing.Color.White;
            this.driversTreeView1.Location = new System.Drawing.Point(5, 48);
            this.driversTreeView1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.driversTreeView1.Name = "driversTreeView1";
            this.driversTreeView1.ShowFocusRect = true;
            this.driversTreeView1.ShowSuperTooltip = false;
            this.driversTreeView1.ShowToolTip = false;
            this.driversTreeView1.Size = new System.Drawing.Size(228, 420);
            this.driversTreeView1.TabIndex = 2;
            this.driversTreeView1.Text = "driversTreeView1";
            // 
            // 
            // 
            this.driversTreeView1.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.driversTreeView1.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.driversTreeView1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.driversTreeView1.ToolTipControl.Name = "toolTip";
            this.driversTreeView1.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.driversTreeView1.ToolTipControl.TabIndex = 1;
            this.driversTreeView1.ToolTipControl.Text = "toolTip";
            this.driversTreeView1.ToolTipDuration = 0;
            this.driversTreeView1.AfterSelect += new System.EventHandler(this.DriverAfterSelect);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BeforeTouchSize = new System.Drawing.Size(528, 21);
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Cue = "Enter driver name";
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.FarImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.FarImage")));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSearch.MinimumSize = new System.Drawing.Size(24, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(528, 21);
            this.txtSearch.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtSearch.TabIndex = 0;
            this.txtSearch.ThemesEnabled = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // _driverMetadataGrid1
            // 
            this._driverMetadataGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this._driverMetadataGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this._driverMetadataGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this._driverMetadataGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this._driverMetadataGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this._driverMetadataGrid1.BackColor = System.Drawing.SystemColors.Window;
            this._driverMetadataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._driverMetadataGrid1.FreezeCaption = false;
            this._driverMetadataGrid1.Location = new System.Drawing.Point(0, 0);
            this._driverMetadataGrid1.Name = "_driverMetadataGrid1";
            this._driverMetadataGrid1.Size = new System.Drawing.Size(566, 399);
            this._driverMetadataGrid1.TabIndex = 3;
            this._driverMetadataGrid1.TableDescriptor.AllowEdit = false;
            this._driverMetadataGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this._driverMetadataGrid1.TableOptions.AllowDropDownCell = false;
            this._driverMetadataGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this._driverMetadataGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this._driverMetadataGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this._driverMetadataGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this._driverMetadataGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this._driverMetadataGrid1.Text = "driversGrid1";
            this._driverMetadataGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this._driverMetadataGrid1.TopLevelGroupOptions.ShowCaption = false;
            this._driverMetadataGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this._driverMetadataGrid1.VersionInfo = "5.0.1.0";
            this._driverMetadataGrid1.WrapWithPanel = false;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(12, 483);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(78, 13);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "Raster formats:";
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControlAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(566, 420);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControlAdv1.Controls.Add(this.tabGeneral);
            this.tabControlAdv1.Controls.Add(this.tabCreationOptions);
            this.tabControlAdv1.Controls.Add(this.tabOpenOptions);
            this.tabControlAdv1.Controls.Add(this.tabLayerOptions);
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.Location = new System.Drawing.Point(239, 48);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Size = new System.Drawing.Size(566, 420);
            this.tabControlAdv1.TabIndex = 5;
            this.tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererBlendDark);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this._driverMetadataGrid1);
            this.tabGeneral.Image = null;
            this.tabGeneral.ImageSize = new System.Drawing.Size(16, 16);
            this.tabGeneral.Location = new System.Drawing.Point(0, 21);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.ShowCloseButton = true;
            this.tabGeneral.Size = new System.Drawing.Size(566, 399);
            this.tabGeneral.TabIndex = 1;
            this.tabGeneral.Text = "General";
            this.tabGeneral.ThemesEnabled = false;
            // 
            // tabCreationOptions
            // 
            this.tabCreationOptions.Controls.Add(this.gridCreationOptions);
            this.tabCreationOptions.Image = null;
            this.tabCreationOptions.ImageSize = new System.Drawing.Size(16, 16);
            this.tabCreationOptions.Location = new System.Drawing.Point(0, 21);
            this.tabCreationOptions.Name = "tabCreationOptions";
            this.tabCreationOptions.ShowCloseButton = true;
            this.tabCreationOptions.Size = new System.Drawing.Size(566, 399);
            this.tabCreationOptions.TabIndex = 2;
            this.tabCreationOptions.Text = "Creation options";
            this.tabCreationOptions.ThemesEnabled = false;
            // 
            // gridCreationOptions
            // 
            this.gridCreationOptions.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridCreationOptions.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridCreationOptions.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridCreationOptions.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridCreationOptions.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.gridCreationOptions.BackColor = System.Drawing.SystemColors.Window;
            this.gridCreationOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCreationOptions.FreezeCaption = false;
            this.gridCreationOptions.Location = new System.Drawing.Point(0, 0);
            this.gridCreationOptions.Name = "gridCreationOptions";
            this.gridCreationOptions.Size = new System.Drawing.Size(566, 399);
            this.gridCreationOptions.TabIndex = 0;
            this.gridCreationOptions.TableDescriptor.AllowEdit = false;
            this.gridCreationOptions.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.gridCreationOptions.TableOptions.AllowDropDownCell = false;
            this.gridCreationOptions.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.gridCreationOptions.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.gridCreationOptions.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.gridCreationOptions.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridCreationOptions.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.gridCreationOptions.Text = "driverOptionsGrid1";
            this.gridCreationOptions.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridCreationOptions.TopLevelGroupOptions.ShowCaption = false;
            this.gridCreationOptions.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.gridCreationOptions.VersionInfo = "5.0.1.0";
            this.gridCreationOptions.WrapWithPanel = false;
            // 
            // tabOpenOptions
            // 
            this.tabOpenOptions.Controls.Add(this.gridOpenOptions);
            this.tabOpenOptions.Image = null;
            this.tabOpenOptions.ImageSize = new System.Drawing.Size(16, 16);
            this.tabOpenOptions.Location = new System.Drawing.Point(0, 21);
            this.tabOpenOptions.Name = "tabOpenOptions";
            this.tabOpenOptions.ShowCloseButton = true;
            this.tabOpenOptions.Size = new System.Drawing.Size(566, 399);
            this.tabOpenOptions.TabIndex = 3;
            this.tabOpenOptions.Text = "Open options";
            this.tabOpenOptions.ThemesEnabled = false;
            // 
            // gridOpenOptions
            // 
            this.gridOpenOptions.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridOpenOptions.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridOpenOptions.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridOpenOptions.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridOpenOptions.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.gridOpenOptions.BackColor = System.Drawing.SystemColors.Window;
            this.gridOpenOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOpenOptions.FreezeCaption = false;
            this.gridOpenOptions.Location = new System.Drawing.Point(0, 0);
            this.gridOpenOptions.Name = "gridOpenOptions";
            this.gridOpenOptions.Size = new System.Drawing.Size(566, 399);
            this.gridOpenOptions.TabIndex = 1;
            this.gridOpenOptions.TableDescriptor.AllowEdit = false;
            this.gridOpenOptions.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.gridOpenOptions.TableOptions.AllowDropDownCell = false;
            this.gridOpenOptions.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.gridOpenOptions.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.gridOpenOptions.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.gridOpenOptions.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridOpenOptions.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.gridOpenOptions.Text = "driverOptionsGrid1";
            this.gridOpenOptions.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridOpenOptions.TopLevelGroupOptions.ShowCaption = false;
            this.gridOpenOptions.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.gridOpenOptions.VersionInfo = "5.0.1.0";
            this.gridOpenOptions.WrapWithPanel = false;
            // 
            // tabLayerOptions
            // 
            this.tabLayerOptions.Controls.Add(this.gridLayerOptions);
            this.tabLayerOptions.Image = null;
            this.tabLayerOptions.ImageSize = new System.Drawing.Size(16, 16);
            this.tabLayerOptions.Location = new System.Drawing.Point(0, 21);
            this.tabLayerOptions.Name = "tabLayerOptions";
            this.tabLayerOptions.ShowCloseButton = true;
            this.tabLayerOptions.Size = new System.Drawing.Size(566, 399);
            this.tabLayerOptions.TabIndex = 4;
            this.tabLayerOptions.Text = "Layer creation options";
            this.tabLayerOptions.ThemesEnabled = false;
            // 
            // gridLayerOptions
            // 
            this.gridLayerOptions.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridLayerOptions.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridLayerOptions.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridLayerOptions.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.gridLayerOptions.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.gridLayerOptions.BackColor = System.Drawing.SystemColors.Window;
            this.gridLayerOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLayerOptions.FreezeCaption = false;
            this.gridLayerOptions.Location = new System.Drawing.Point(0, 0);
            this.gridLayerOptions.Name = "gridLayerOptions";
            this.gridLayerOptions.Size = new System.Drawing.Size(566, 399);
            this.gridLayerOptions.TabIndex = 2;
            this.gridLayerOptions.TableDescriptor.AllowEdit = false;
            this.gridLayerOptions.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.gridLayerOptions.TableOptions.AllowDropDownCell = false;
            this.gridLayerOptions.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.gridLayerOptions.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.gridLayerOptions.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.gridLayerOptions.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.gridLayerOptions.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.gridLayerOptions.Text = "driverOptionsGrid1";
            this.gridLayerOptions.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.gridLayerOptions.TopLevelGroupOptions.ShowCaption = false;
            this.gridLayerOptions.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.gridLayerOptions.VersionInfo = "5.0.1.0";
            this.gridLayerOptions.WrapWithPanel = false;
            // 
            // cboFilter
            // 
            this.cboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilter.BeforeTouchSize = new System.Drawing.Size(259, 21);
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboFilter.Location = new System.Drawing.Point(546, 12);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(259, 21);
            this.cboFilter.TabIndex = 6;
            // 
            // DriversView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(808, 512);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.driversTreeView1);
            this.Controls.Add(this.btnClose);
            this.Name = "DriversView";
            this.Text = "Supported GDAL drivers";
            ((System.ComponentModel.ISupportInitialize)(this.driversTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._driverMetadataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabCreationOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCreationOptions)).EndInit();
            this.tabOpenOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOpenOptions)).EndInit();
            this.tabLayerOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLayerOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFilter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private DriversTreeView driversTreeView1;
        private UI.Controls.WatermarkTextbox txtSearch;
        private Controls.DriverMetadataGrid _driverMetadataGrid1;
        private System.Windows.Forms.Label lblCount;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabGeneral;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabCreationOptions;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabOpenOptions;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabLayerOptions;
        private Controls.DriverOptionsGrid gridCreationOptions;
        private Controls.DriverOptionsGrid gridOpenOptions;
        private Controls.DriverOptionsGrid gridLayerOptions;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboFilter;
    }
}