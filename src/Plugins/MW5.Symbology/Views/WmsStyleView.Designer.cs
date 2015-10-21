namespace MW5.Plugins.Symbology.Views
{
    partial class WmsStyleView
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
            this.btnApply = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabControl1 = new MW5.UI.Controls.TabPropertiesControl();
            this.tabGeneral = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnOpenLocation = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtBriefInfo = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProjection = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtProjection = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrl = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label8 = new System.Windows.Forms.Label();
            this.chkLayerVisible = new System.Windows.Forms.CheckBox();
            this.txtLayerName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dynamicVisibilityControl1 = new MW5.Plugins.Symbology.Controls.DynamicVisibilityControl();
            this.tabInfo = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnCopyInfo = new Syncfusion.Windows.Forms.ButtonAdv();
            this.infoGrid1 = new MW5.Plugins.Symbology.Controls.InfoGrid();
            this.cboCollisionMode = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBriefInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl)).BeginInit();
            this.tabInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCollisionMode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnApply.IsBackStageButton = false;
            this.btnApply.Location = new System.Drawing.Point(360, 455);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(93, 26);
            this.btnApply.TabIndex = 137;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(558, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 26);
            this.btnCancel.TabIndex = 136;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(459, 455);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 26);
            this.btnOk.TabIndex = 135;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.ActiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tabControl1.ActiveTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.BeforeTouchSize = new System.Drawing.Size(639, 435);
            this.tabControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.FocusOnTabClick = false;
            this.tabControl1.InactiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 50);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(5, 10);
            this.tabControl1.PersistTabState = true;
            this.tabControl1.RotateTextWhenVertical = true;
            this.tabControl1.Size = new System.Drawing.Size(639, 435);
            this.tabControl1.TabGap = 10;
            this.tabControl1.TabIndex = 138;
            this.tabControl1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererBlendLight);
            this.tabControl1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.btnOpenLocation);
            this.tabGeneral.Controls.Add(this.txtBriefInfo);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.btnProjection);
            this.tabGeneral.Controls.Add(this.txtProjection);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.txtUrl);
            this.tabGeneral.Controls.Add(this.label8);
            this.tabGeneral.Controls.Add(this.chkLayerVisible);
            this.tabGeneral.Controls.Add(this.txtLayerName);
            this.tabGeneral.Controls.Add(this.label18);
            this.tabGeneral.Controls.Add(this.dynamicVisibilityControl1);
            this.tabGeneral.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_options;
            this.tabGeneral.ImageSize = new System.Drawing.Size(24, 24);
            this.tabGeneral.Location = new System.Drawing.Point(119, 0);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.ShowCloseButton = true;
            this.tabGeneral.Size = new System.Drawing.Size(520, 435);
            this.tabGeneral.TabIndex = 10;
            this.tabGeneral.Text = "General";
            this.tabGeneral.ThemesEnabled = false;
            // 
            // btnOpenLocation
            // 
            this.btnOpenLocation.BeforeTouchSize = new System.Drawing.Size(63, 23);
            this.btnOpenLocation.Enabled = false;
            this.btnOpenLocation.IsBackStageButton = false;
            this.btnOpenLocation.Location = new System.Drawing.Point(438, 68);
            this.btnOpenLocation.Name = "btnOpenLocation";
            this.btnOpenLocation.Size = new System.Drawing.Size(63, 23);
            this.btnOpenLocation.TabIndex = 172;
            this.btnOpenLocation.Text = "Open";
            // 
            // txtBriefInfo
            // 
            this.txtBriefInfo.BeforeTouchSize = new System.Drawing.Size(292, 20);
            this.txtBriefInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBriefInfo.Location = new System.Drawing.Point(137, 153);
            this.txtBriefInfo.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtBriefInfo.Name = "txtBriefInfo";
            this.txtBriefInfo.ReadOnly = true;
            this.txtBriefInfo.Size = new System.Drawing.Size(364, 20);
            this.txtBriefInfo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtBriefInfo.TabIndex = 170;
            this.txtBriefInfo.Text = "<layers>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 169;
            this.label2.Text = "Information";
            // 
            // btnProjection
            // 
            this.btnProjection.BeforeTouchSize = new System.Drawing.Size(63, 23);
            this.btnProjection.IsBackStageButton = false;
            this.btnProjection.Location = new System.Drawing.Point(438, 109);
            this.btnProjection.Name = "btnProjection";
            this.btnProjection.Size = new System.Drawing.Size(63, 23);
            this.btnProjection.TabIndex = 168;
            this.btnProjection.Text = "Details";
            // 
            // txtProjection
            // 
            this.txtProjection.BeforeTouchSize = new System.Drawing.Size(292, 20);
            this.txtProjection.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjection.Location = new System.Drawing.Point(137, 112);
            this.txtProjection.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtProjection.Name = "txtProjection";
            this.txtProjection.ReadOnly = true;
            this.txtProjection.Size = new System.Drawing.Size(291, 20);
            this.txtProjection.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtProjection.TabIndex = 167;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 166;
            this.label3.Text = "Coordinate system";
            // 
            // txtUrl
            // 
            this.txtUrl.BeforeTouchSize = new System.Drawing.Size(292, 20);
            this.txtUrl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUrl.Location = new System.Drawing.Point(137, 71);
            this.txtUrl.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(292, 20);
            this.txtUrl.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtUrl.TabIndex = 165;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 164;
            this.label8.Text = "URL";
            // 
            // chkLayerVisible
            // 
            this.chkLayerVisible.AutoSize = true;
            this.chkLayerVisible.Location = new System.Drawing.Point(438, 35);
            this.chkLayerVisible.Name = "chkLayerVisible";
            this.chkLayerVisible.Size = new System.Drawing.Size(56, 17);
            this.chkLayerVisible.TabIndex = 160;
            this.chkLayerVisible.Text = "Visible";
            this.chkLayerVisible.UseVisualStyleBackColor = true;
            // 
            // txtLayerName
            // 
            this.txtLayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLayerName.Location = new System.Drawing.Point(137, 33);
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size(291, 20);
            this.txtLayerName.TabIndex = 39;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(29, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "Layer name";
            // 
            // dynamicVisibilityControl1
            // 
            this.dynamicVisibilityControl1.CurrentScale = 0D;
            this.dynamicVisibilityControl1.CurrentZoom = 0;
            this.dynamicVisibilityControl1.Location = new System.Drawing.Point(21, 203);
            this.dynamicVisibilityControl1.MaxScale = 1000000D;
            this.dynamicVisibilityControl1.MaxZoom = 24;
            this.dynamicVisibilityControl1.MinScale = 100D;
            this.dynamicVisibilityControl1.MinZoom = 1;
            this.dynamicVisibilityControl1.Mode = MW5.Api.Enums.DynamicVisibilityMode.Scale;
            this.dynamicVisibilityControl1.Name = "dynamicVisibilityControl1";
            this.dynamicVisibilityControl1.Size = new System.Drawing.Size(228, 210);
            this.dynamicVisibilityControl1.TabIndex = 171;
            this.dynamicVisibilityControl1.UseDynamicVisiblity = false;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.btnCopyInfo);
            this.tabInfo.Controls.Add(this.infoGrid1);
            this.tabInfo.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_info24;
            this.tabInfo.ImageSize = new System.Drawing.Size(24, 24);
            this.tabInfo.Location = new System.Drawing.Point(119, 0);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.ShowCloseButton = true;
            this.tabInfo.Size = new System.Drawing.Size(520, 435);
            this.tabInfo.TabIndex = 15;
            this.tabInfo.Text = "Info";
            this.tabInfo.ThemesEnabled = false;
            // 
            // btnCopyInfo
            // 
            this.btnCopyInfo.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnCopyInfo.IsBackStageButton = false;
            this.btnCopyInfo.Location = new System.Drawing.Point(15, 401);
            this.btnCopyInfo.Name = "btnCopyInfo";
            this.btnCopyInfo.Size = new System.Drawing.Size(75, 23);
            this.btnCopyInfo.TabIndex = 5;
            this.btnCopyInfo.Text = "Copy";
            // 
            // infoGrid1
            // 
            this.infoGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.infoGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.infoGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.infoGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.infoGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.infoGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.infoGrid1.FreezeCaption = false;
            this.infoGrid1.Location = new System.Drawing.Point(15, 15);
            this.infoGrid1.Name = "infoGrid1";
            this.infoGrid1.Size = new System.Drawing.Size(490, 380);
            this.infoGrid1.TabIndex = 4;
            this.infoGrid1.TableDescriptor.AllowEdit = false;
            this.infoGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.infoGrid1.TableOptions.AllowDropDownCell = false;
            this.infoGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.infoGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.infoGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.infoGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.infoGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.infoGrid1.Text = "infoGrid1";
            this.infoGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.infoGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.infoGrid1.TopLevelGroupOptions.ShowColumnHeaders = false;
            this.infoGrid1.VersionInfo = "0.0.1.0";
            this.infoGrid1.WrapWithPanel = false;
            // 
            // cboCollisionMode
            // 
            this.cboCollisionMode.BeforeTouchSize = new System.Drawing.Size(203, 21);
            this.cboCollisionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCollisionMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboCollisionMode.Location = new System.Drawing.Point(20, 28);
            this.cboCollisionMode.Name = "cboCollisionMode";
            this.cboCollisionMode.Size = new System.Drawing.Size(203, 21);
            this.cboCollisionMode.TabIndex = 184;
            // 
            // WmsStyleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 484);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "WmsStyleView";
            this.Text = "WMS Layer Style";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBriefInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl)).EndInit();
            this.tabInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCollisionMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnApply;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private UI.Controls.TabPropertiesControl tabControl1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabGeneral;
        private Syncfusion.Windows.Forms.ButtonAdv btnOpenLocation;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtBriefInfo;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.ButtonAdv btnProjection;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtProjection;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtUrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkLayerVisible;
        private System.Windows.Forms.TextBox txtLayerName;
        private System.Windows.Forms.Label label18;
        private Controls.DynamicVisibilityControl dynamicVisibilityControl1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabInfo;
        private Syncfusion.Windows.Forms.ButtonAdv btnCopyInfo;
        private Controls.InfoGrid infoGrid1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboCollisionMode;
    }
}