using System.Windows.Forms;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Views
{
    partial class RasterStyleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RasterStyleView));
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvStyleInfo treeNodeAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvStyleInfo();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvSubItemStyleInfo treeNodeAdvSubItemStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvSubItemStyleInfo();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdvStyleInfo treeColumnAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdvStyleInfo();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageGeneral = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnOpenFolder = new Syncfusion.Windows.Forms.ButtonAdv();
            this._dynamicVisibilityControl1 = new MW5.Plugins.Symbology.Controls.DynamicVisibilityControl();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkLayerPreview = new System.Windows.Forms.CheckBox();
            this.chkLayerVisible = new System.Windows.Forms.CheckBox();
            this.txtBriefInfo = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label5 = new System.Windows.Forms.Label();
            this.btnProjectionDetails = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtProjection = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatasourceName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLayerName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageColors = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageRendering = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.clpTransparent = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.chkUseTransparentColor = new System.Windows.Forms.CheckBox();
            this.btnClearColorAdjustments = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbrTransparency = new System.Windows.Forms.TrackBar();
            this.tbrHue = new System.Windows.Forms.TrackBar();
            this.tbrSaturation = new System.Windows.Forms.TrackBar();
            this.tbrGamma = new System.Windows.Forms.TrackBar();
            this.tbrConstrast = new System.Windows.Forms.TrackBar();
            this.tbrBrightness = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboUpsampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboDownsampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelColorize = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.tbrColorizeIntensity = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.clpColorize = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.chkColorize = new System.Windows.Forms.CheckBox();
            this.chkGreyScale = new System.Windows.Forms.CheckBox();
            this.tabPageHistogram = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.histogramControl1 = new MW5.Plugins.Symbology.Controls.HistogramControl();
            this.tabPagePyramids = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this._overviewControl1 = new MW5.Plugins.Symbology.Controls.OverviewControl();
            this.tabPageInfo = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnShowDriverInfo = new Syncfusion.Windows.Forms.ButtonAdv();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rasterInfoTreeView1 = new MW5.Plugins.Symbology.Controls.RasterInfoTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cboOverviewType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboOverviewSampling = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboDynamicScaleMode = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboMaxScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboMinScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnApply = new Syncfusion.Windows.Forms.ButtonAdv();
            this.superToolTip1 = new Syncfusion.Windows.Forms.Tools.SuperToolTip(this);
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolStyle = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolLoadStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSaveStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRemoveStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBriefInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasourceName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLayerName)).BeginInit();
            this.tabPageColors.SuspendLayout();
            this.tabPageRendering.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrTransparency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrConstrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrBrightness)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUpsampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDownsampling)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelColorize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrColorizeIntensity)).BeginInit();
            this.tabPageHistogram.SuspendLayout();
            this.tabPagePyramids.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rasterInfoTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewSampling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDynamicScaleMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaxScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMinScale)).BeginInit();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(631, 443);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControlAdv1.BorderVisible = true;
            this.tabControlAdv1.BorderWidth = 1;
            this.tabControlAdv1.Controls.Add(this.tabPageGeneral);
            this.tabControlAdv1.Controls.Add(this.tabPageColors);
            this.tabControlAdv1.Controls.Add(this.tabPageRendering);
            this.tabControlAdv1.Controls.Add(this.tabPageHistogram);
            this.tabControlAdv1.Controls.Add(this.tabPagePyramids);
            this.tabControlAdv1.Controls.Add(this.tabPageInfo);
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.ImageList = this.imageList1;
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(120, 50);
            this.tabControlAdv1.Location = new System.Drawing.Point(4, 12);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Padding = new System.Drawing.Point(5, 10);
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(631, 443);
            this.tabControlAdv1.TabIndex = 0;
            this.tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererBlendLight);
            this.tabControlAdv1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.btnOpenFolder);
            this.tabPageGeneral.Controls.Add(this._dynamicVisibilityControl1);
            this.tabPageGeneral.Controls.Add(this.groupBox10);
            this.tabPageGeneral.Controls.Add(this.chkLayerVisible);
            this.tabPageGeneral.Controls.Add(this.txtBriefInfo);
            this.tabPageGeneral.Controls.Add(this.label5);
            this.tabPageGeneral.Controls.Add(this.btnProjectionDetails);
            this.tabPageGeneral.Controls.Add(this.txtProjection);
            this.tabPageGeneral.Controls.Add(this.label4);
            this.tabPageGeneral.Controls.Add(this.txtDatasourceName);
            this.tabPageGeneral.Controls.Add(this.label3);
            this.tabPageGeneral.Controls.Add(this.txtLayerName);
            this.tabPageGeneral.Controls.Add(this.label2);
            this.tabPageGeneral.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_options;
            this.tabPageGeneral.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageGeneral.Location = new System.Drawing.Point(120, 1);
            this.tabPageGeneral.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageGeneral.ShowCloseButton = true;
            this.tabPageGeneral.Size = new System.Drawing.Size(510, 441);
            this.tabPageGeneral.TabIndex = 1;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.ThemesEnabled = false;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.BeforeTouchSize = new System.Drawing.Size(63, 23);
            this.btnOpenFolder.IsBackStageButton = false;
            this.btnOpenFolder.Location = new System.Drawing.Point(433, 60);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(63, 23);
            this.btnOpenFolder.TabIndex = 181;
            this.btnOpenFolder.Text = "Open";
            // 
            // _dynamicVisibilityControl1
            // 
            this._dynamicVisibilityControl1.CurrentScale = 0D;
            this._dynamicVisibilityControl1.CurrentZoom = 0;
            this._dynamicVisibilityControl1.Location = new System.Drawing.Point(22, 195);
            this._dynamicVisibilityControl1.MaxScale = 1000000D;
            this._dynamicVisibilityControl1.MaxZoom = 24;
            this._dynamicVisibilityControl1.MinScale = 100D;
            this._dynamicVisibilityControl1.MinZoom = 1;
            this._dynamicVisibilityControl1.Mode = MW5.Api.Enums.DynamicVisibilityMode.Scale;
            this._dynamicVisibilityControl1.Name = "_dynamicVisibilityControl1";
            this._dynamicVisibilityControl1.Size = new System.Drawing.Size(232, 207);
            this._dynamicVisibilityControl1.TabIndex = 164;
            this._dynamicVisibilityControl1.UseDynamicVisiblity = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.pictureBox1);
            this.groupBox10.Controls.Add(this.chkLayerPreview);
            this.groupBox10.Location = new System.Drawing.Point(269, 195);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(227, 210);
            this.groupBox10.TabIndex = 180;
            this.groupBox10.TabStop = false;
            this.groupBox10.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 191);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 163;
            this.pictureBox1.TabStop = false;
            // 
            // chkLayerPreview
            // 
            this.chkLayerPreview.AutoSize = true;
            this.chkLayerPreview.Location = new System.Drawing.Point(6, 0);
            this.chkLayerPreview.Name = "chkLayerPreview";
            this.chkLayerPreview.Size = new System.Drawing.Size(93, 17);
            this.chkLayerPreview.TabIndex = 162;
            this.chkLayerPreview.Text = "Show preview";
            this.chkLayerPreview.UseVisualStyleBackColor = true;
            // 
            // chkLayerVisible
            // 
            this.chkLayerVisible.Location = new System.Drawing.Point(433, 24);
            this.chkLayerVisible.Name = "chkLayerVisible";
            this.chkLayerVisible.Size = new System.Drawing.Size(63, 21);
            this.chkLayerVisible.TabIndex = 179;
            this.chkLayerVisible.Text = "Visible";
            // 
            // txtBriefInfo
            // 
            this.txtBriefInfo.BeforeTouchSize = new System.Drawing.Size(299, 20);
            this.txtBriefInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBriefInfo.Location = new System.Drawing.Point(128, 145);
            this.txtBriefInfo.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtBriefInfo.Name = "txtBriefInfo";
            this.txtBriefInfo.ReadOnly = true;
            this.txtBriefInfo.Size = new System.Drawing.Size(368, 20);
            this.txtBriefInfo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtBriefInfo.TabIndex = 8;
            this.txtBriefInfo.Text = "800 * 600 pixels, 3 bands; rendered as RGB image";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Information";
            // 
            // btnProjectionDetails
            // 
            this.btnProjectionDetails.BeforeTouchSize = new System.Drawing.Size(63, 23);
            this.btnProjectionDetails.IsBackStageButton = false;
            this.btnProjectionDetails.Location = new System.Drawing.Point(433, 101);
            this.btnProjectionDetails.Name = "btnProjectionDetails";
            this.btnProjectionDetails.Size = new System.Drawing.Size(63, 23);
            this.btnProjectionDetails.TabIndex = 6;
            this.btnProjectionDetails.Text = "Details";
            // 
            // txtProjection
            // 
            this.txtProjection.BeforeTouchSize = new System.Drawing.Size(299, 20);
            this.txtProjection.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjection.Location = new System.Drawing.Point(128, 104);
            this.txtProjection.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtProjection.Name = "txtProjection";
            this.txtProjection.ReadOnly = true;
            this.txtProjection.Size = new System.Drawing.Size(299, 20);
            this.txtProjection.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtProjection.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Coordinate system";
            // 
            // txtDatasourceName
            // 
            this.txtDatasourceName.BeforeTouchSize = new System.Drawing.Size(299, 20);
            this.txtDatasourceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDatasourceName.Location = new System.Drawing.Point(128, 63);
            this.txtDatasourceName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDatasourceName.Name = "txtDatasourceName";
            this.txtDatasourceName.ReadOnly = true;
            this.txtDatasourceName.Size = new System.Drawing.Size(299, 20);
            this.txtDatasourceName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtDatasourceName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datasource name";
            // 
            // txtLayerName
            // 
            this.txtLayerName.BeforeTouchSize = new System.Drawing.Size(299, 20);
            this.txtLayerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLayerName.Location = new System.Drawing.Point(128, 24);
            this.txtLayerName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size(299, 20);
            this.txtLayerName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtLayerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Layer name";
            // 
            // tabPageColors
            // 
            this.tabPageColors.Controls.Add(this.label8);
            this.tabPageColors.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_palette;
            this.tabPageColors.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageColors.Location = new System.Drawing.Point(120, 1);
            this.tabPageColors.Name = "tabPageColors";
            this.tabPageColors.ShowCloseButton = true;
            this.tabPageColors.Size = new System.Drawing.Size(510, 441);
            this.tabPageColors.TabIndex = 4;
            this.tabPageColors.Text = "Colors";
            this.tabPageColors.ThemesEnabled = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(287, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "RasterRenderingSubView will be added here during runtime";
            this.label8.Visible = false;
            // 
            // tabPageRendering
            // 
            this.tabPageRendering.Controls.Add(this.clpTransparent);
            this.tabPageRendering.Controls.Add(this.chkUseTransparentColor);
            this.tabPageRendering.Controls.Add(this.btnClearColorAdjustments);
            this.tabPageRendering.Controls.Add(this.groupBox3);
            this.tabPageRendering.Controls.Add(this.groupBox2);
            this.tabPageRendering.Controls.Add(this.groupBox1);
            this.tabPageRendering.Controls.Add(this.chkGreyScale);
            this.tabPageRendering.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_contrast24;
            this.tabPageRendering.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageRendering.Location = new System.Drawing.Point(120, 1);
            this.tabPageRendering.Name = "tabPageRendering";
            this.tabPageRendering.ShowCloseButton = true;
            this.tabPageRendering.Size = new System.Drawing.Size(510, 441);
            this.tabPageRendering.TabIndex = 3;
            this.tabPageRendering.Text = "Rendering";
            this.tabPageRendering.ThemesEnabled = false;
            // 
            // clpTransparent
            // 
            this.clpTransparent.Color = System.Drawing.Color.Black;
            this.clpTransparent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpTransparent.DropDownHeight = 1;
            this.clpTransparent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpTransparent.FormattingEnabled = true;
            this.clpTransparent.IntegralHeight = false;
            this.clpTransparent.Items.AddRange(new object[] {
            "Color"});
            this.clpTransparent.Location = new System.Drawing.Point(178, 293);
            this.clpTransparent.Name = "clpTransparent";
            this.clpTransparent.Size = new System.Drawing.Size(73, 21);
            this.clpTransparent.TabIndex = 66;
            // 
            // chkUseTransparentColor
            // 
            this.chkUseTransparentColor.Location = new System.Drawing.Point(35, 293);
            this.chkUseTransparentColor.Name = "chkUseTransparentColor";
            this.chkUseTransparentColor.Size = new System.Drawing.Size(137, 21);
            this.chkUseTransparentColor.TabIndex = 65;
            this.chkUseTransparentColor.Text = "Transparent color";
            // 
            // btnClearColorAdjustments
            // 
            this.btnClearColorAdjustments.BeforeTouchSize = new System.Drawing.Size(82, 23);
            this.btnClearColorAdjustments.IsBackStageButton = false;
            this.btnClearColorAdjustments.Location = new System.Drawing.Point(410, 291);
            this.btnClearColorAdjustments.Name = "btnClearColorAdjustments";
            this.btnClearColorAdjustments.Size = new System.Drawing.Size(82, 23);
            this.btnClearColorAdjustments.TabIndex = 62;
            this.btnClearColorAdjustments.Text = "Set defaults";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbrTransparency);
            this.groupBox3.Controls.Add(this.tbrHue);
            this.groupBox3.Controls.Add(this.tbrSaturation);
            this.groupBox3.Controls.Add(this.tbrGamma);
            this.groupBox3.Controls.Add(this.tbrConstrast);
            this.groupBox3.Controls.Add(this.tbrBrightness);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(23, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 184);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Adjustments";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Transparency";
            // 
            // tbrTransparency
            // 
            this.tbrTransparency.AutoSize = false;
            this.tbrTransparency.Location = new System.Drawing.Point(243, 149);
            this.tbrTransparency.Maximum = 255;
            this.tbrTransparency.Name = "tbrTransparency";
            this.tbrTransparency.Size = new System.Drawing.Size(209, 24);
            this.tbrTransparency.SmallChange = 10;
            this.tbrTransparency.TabIndex = 62;
            this.tbrTransparency.TickFrequency = 15;
            // 
            // tbrHue
            // 
            this.tbrHue.AutoSize = false;
            this.tbrHue.Location = new System.Drawing.Point(19, 149);
            this.tbrHue.Maximum = 180;
            this.tbrHue.Minimum = -180;
            this.tbrHue.Name = "tbrHue";
            this.tbrHue.Size = new System.Drawing.Size(209, 24);
            this.tbrHue.SmallChange = 10;
            this.tbrHue.TabIndex = 61;
            this.tbrHue.TickFrequency = 20;
            // 
            // tbrSaturation
            // 
            this.tbrSaturation.AutoSize = false;
            this.tbrSaturation.Location = new System.Drawing.Point(243, 97);
            this.tbrSaturation.Maximum = 60;
            this.tbrSaturation.Name = "tbrSaturation";
            this.tbrSaturation.Size = new System.Drawing.Size(209, 24);
            this.tbrSaturation.SmallChange = 10;
            this.tbrSaturation.TabIndex = 60;
            this.tbrSaturation.TickFrequency = 4;
            this.tbrSaturation.Value = 20;
            // 
            // tbrGamma
            // 
            this.tbrGamma.AutoSize = false;
            this.tbrGamma.Location = new System.Drawing.Point(19, 97);
            this.tbrGamma.Maximum = 80;
            this.tbrGamma.Minimum = 4;
            this.tbrGamma.Name = "tbrGamma";
            this.tbrGamma.Size = new System.Drawing.Size(209, 24);
            this.tbrGamma.SmallChange = 10;
            this.tbrGamma.TabIndex = 59;
            this.tbrGamma.TickFrequency = 4;
            this.tbrGamma.Value = 20;
            // 
            // tbrConstrast
            // 
            this.tbrConstrast.AutoSize = false;
            this.tbrConstrast.Location = new System.Drawing.Point(243, 43);
            this.tbrConstrast.Maximum = 80;
            this.tbrConstrast.Minimum = 4;
            this.tbrConstrast.Name = "tbrConstrast";
            this.tbrConstrast.Size = new System.Drawing.Size(209, 24);
            this.tbrConstrast.SmallChange = 10;
            this.tbrConstrast.TabIndex = 58;
            this.tbrConstrast.TickFrequency = 4;
            this.tbrConstrast.Value = 20;
            // 
            // tbrBrightness
            // 
            this.tbrBrightness.AutoSize = false;
            this.tbrBrightness.Location = new System.Drawing.Point(19, 43);
            this.tbrBrightness.Maximum = 20;
            this.tbrBrightness.Minimum = -20;
            this.tbrBrightness.Name = "tbrBrightness";
            this.tbrBrightness.Size = new System.Drawing.Size(209, 24);
            this.tbrBrightness.SmallChange = 10;
            this.tbrBrightness.TabIndex = 57;
            this.tbrBrightness.TickFrequency = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Brightness";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Contrast";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(246, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Saturation";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Gamma";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "Hue";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboUpsampling);
            this.groupBox2.Controls.Add(this.cboDownsampling);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(16, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 80);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interpolation mode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Upsampling";
            // 
            // cboUpsampling
            // 
            this.cboUpsampling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUpsampling.BeforeTouchSize = new System.Drawing.Size(201, 21);
            this.cboUpsampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUpsampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboUpsampling.Location = new System.Drawing.Point(15, 44);
            this.cboUpsampling.Name = "cboUpsampling";
            this.cboUpsampling.Size = new System.Drawing.Size(201, 21);
            this.cboUpsampling.TabIndex = 44;
            // 
            // cboDownsampling
            // 
            this.cboDownsampling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDownsampling.BeforeTouchSize = new System.Drawing.Size(207, 21);
            this.cboDownsampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDownsampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboDownsampling.Location = new System.Drawing.Point(232, 44);
            this.cboDownsampling.Name = "cboDownsampling";
            this.cboDownsampling.Size = new System.Drawing.Size(207, 21);
            this.cboDownsampling.TabIndex = 46;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(234, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 45;
            this.label12.Text = "Downsampling";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelColorize);
            this.groupBox1.Controls.Add(this.chkColorize);
            this.groupBox1.Location = new System.Drawing.Point(23, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 63);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // panelColorize
            // 
            this.panelColorize.Controls.Add(this.label17);
            this.panelColorize.Controls.Add(this.tbrColorizeIntensity);
            this.panelColorize.Controls.Add(this.label16);
            this.panelColorize.Controls.Add(this.clpColorize);
            this.panelColorize.Location = new System.Drawing.Point(19, 21);
            this.panelColorize.Name = "panelColorize";
            this.panelColorize.Size = new System.Drawing.Size(433, 33);
            this.panelColorize.TabIndex = 65;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 64;
            this.label17.Text = "Color";
            // 
            // tbrColorizeIntensity
            // 
            this.tbrColorizeIntensity.AutoSize = false;
            this.tbrColorizeIntensity.Location = new System.Drawing.Point(196, 3);
            this.tbrColorizeIntensity.Maximum = 100;
            this.tbrColorizeIntensity.Name = "tbrColorizeIntensity";
            this.tbrColorizeIntensity.Size = new System.Drawing.Size(209, 24);
            this.tbrColorizeIntensity.SmallChange = 10;
            this.tbrColorizeIntensity.TabIndex = 62;
            this.tbrColorizeIntensity.TickFrequency = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(144, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 63;
            this.label16.Text = "Intensity";
            // 
            // clpColorize
            // 
            this.clpColorize.Color = System.Drawing.Color.Orange;
            this.clpColorize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpColorize.DropDownHeight = 1;
            this.clpColorize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpColorize.FormattingEnabled = true;
            this.clpColorize.IntegralHeight = false;
            this.clpColorize.Items.AddRange(new object[] {
            "Color"});
            this.clpColorize.Location = new System.Drawing.Point(42, 6);
            this.clpColorize.Name = "clpColorize";
            this.clpColorize.Size = new System.Drawing.Size(74, 21);
            this.clpColorize.TabIndex = 60;
            // 
            // chkColorize
            // 
            this.chkColorize.AutoSize = true;
            this.chkColorize.Location = new System.Drawing.Point(12, 0);
            this.chkColorize.Name = "chkColorize";
            this.chkColorize.Size = new System.Drawing.Size(63, 17);
            this.chkColorize.TabIndex = 61;
            this.chkColorize.Text = "Colorize";
            this.chkColorize.UseVisualStyleBackColor = true;
            // 
            // chkGreyScale
            // 
            this.chkGreyScale.Location = new System.Drawing.Point(265, 293);
            this.chkGreyScale.Name = "chkGreyScale";
            this.chkGreyScale.Size = new System.Drawing.Size(139, 21);
            this.chkGreyScale.TabIndex = 57;
            this.chkGreyScale.Text = "Greyscale";
            // 
            // tabPageHistogram
            // 
            this.tabPageHistogram.Controls.Add(this.histogramControl1);
            this.tabPageHistogram.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_histogram24;
            this.tabPageHistogram.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageHistogram.Location = new System.Drawing.Point(120, 1);
            this.tabPageHistogram.Name = "tabPageHistogram";
            this.tabPageHistogram.ShowCloseButton = true;
            this.tabPageHistogram.Size = new System.Drawing.Size(510, 441);
            this.tabPageHistogram.TabIndex = 7;
            this.tabPageHistogram.Text = "Histogram";
            this.tabPageHistogram.ThemesEnabled = false;
            // 
            // histogramControl1
            // 
            this.histogramControl1.Location = new System.Drawing.Point(3, 3);
            this.histogramControl1.Name = "histogramControl1";
            this.histogramControl1.Size = new System.Drawing.Size(505, 435);
            this.histogramControl1.TabIndex = 0;
            // 
            // tabPagePyramids
            // 
            this.tabPagePyramids.Controls.Add(this._overviewControl1);
            this.tabPagePyramids.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_pyramid24;
            this.tabPagePyramids.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPagePyramids.Location = new System.Drawing.Point(120, 1);
            this.tabPagePyramids.Name = "tabPagePyramids";
            this.tabPagePyramids.ShowCloseButton = true;
            this.tabPagePyramids.Size = new System.Drawing.Size(510, 441);
            this.tabPagePyramids.TabIndex = 5;
            this.tabPagePyramids.Text = "Pyramids";
            this.tabPagePyramids.ThemesEnabled = false;
            // 
            // _overviewControl1
            // 
            this._overviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._overviewControl1.Location = new System.Drawing.Point(0, 0);
            this._overviewControl1.Name = "_overviewControl1";
            this._overviewControl1.Padding = new System.Windows.Forms.Padding(10);
            this._overviewControl1.Size = new System.Drawing.Size(510, 441);
            this._overviewControl1.TabIndex = 0;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.btnShowDriverInfo);
            this.tabPageInfo.Controls.Add(this.richTextBox1);
            this.tabPageInfo.Controls.Add(this.rasterInfoTreeView1);
            this.tabPageInfo.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_info24;
            this.tabPageInfo.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageInfo.Location = new System.Drawing.Point(120, 1);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.ShowCloseButton = true;
            this.tabPageInfo.Size = new System.Drawing.Size(510, 441);
            this.tabPageInfo.TabIndex = 2;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.ThemesEnabled = false;
            // 
            // btnShowDriverInfo
            // 
            this.btnShowDriverInfo.BeforeTouchSize = new System.Drawing.Size(113, 23);
            this.btnShowDriverInfo.IsBackStageButton = false;
            this.btnShowDriverInfo.Location = new System.Drawing.Point(15, 408);
            this.btnShowDriverInfo.Name = "btnShowDriverInfo";
            this.btnShowDriverInfo.Size = new System.Drawing.Size(113, 23);
            this.btnShowDriverInfo.TabIndex = 7;
            this.btnShowDriverInfo.Text = "Show driver info";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(5, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(505, 386);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // rasterInfoTreeView1
            // 
            this.rasterInfoTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rasterInfoTreeView1.AutoAdjustMultiLineHeight = true;
            treeNodeAdvStyleInfo1.ThemesEnabled = false;
            this.rasterInfoTreeView1.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard", treeNodeAdvStyleInfo1),
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard - SubItem", treeNodeAdvSubItemStyleInfo1),
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard - Column", treeColumnAdvStyleInfo1)});
            this.rasterInfoTreeView1.BeforeTouchSize = new System.Drawing.Size(510, 400);
            this.rasterInfoTreeView1.BorderColor = System.Drawing.Color.Silver;
            this.rasterInfoTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rasterInfoTreeView1.ColumnsHeaderBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control);
            // 
            // 
            // 
            this.rasterInfoTreeView1.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rasterInfoTreeView1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.rasterInfoTreeView1.HelpTextControl.Name = "m_helpText";
            this.rasterInfoTreeView1.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.rasterInfoTreeView1.HelpTextControl.TabIndex = 0;
            this.rasterInfoTreeView1.HelpTextControl.Text = "help text";
            this.rasterInfoTreeView1.HideSelection = false;
            this.rasterInfoTreeView1.Location = new System.Drawing.Point(0, 0);
            this.rasterInfoTreeView1.Margin = new System.Windows.Forms.Padding(5);
            this.rasterInfoTreeView1.Name = "rasterInfoTreeView1";
            this.rasterInfoTreeView1.ShowColumnsHeader = false;
            this.rasterInfoTreeView1.ShowLines = false;
            this.rasterInfoTreeView1.ShowRootLines = false;
            this.rasterInfoTreeView1.Size = new System.Drawing.Size(510, 400);
            this.rasterInfoTreeView1.Style = Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.MultiColumnVisualStyle.Metro;
            this.rasterInfoTreeView1.TabIndex = 0;
            this.rasterInfoTreeView1.Text = "rasterInfoTreeView1";
            this.rasterInfoTreeView1.ThemesEnabled = false;
            // 
            // 
            // 
            this.rasterInfoTreeView1.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.rasterInfoTreeView1.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rasterInfoTreeView1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.rasterInfoTreeView1.ToolTipControl.Name = "m_toolTip";
            this.rasterInfoTreeView1.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.rasterInfoTreeView1.ToolTipControl.TabIndex = 1;
            this.rasterInfoTreeView1.ToolTipControl.Text = "toolTip";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "img_options32.png");
            this.imageList1.Images.SetKeyName(1, "img_info32.png");
            this.imageList1.Images.SetKeyName(2, "img_colors32.png");
            this.imageList1.Images.SetKeyName(3, "img_contrast32.png");
            this.imageList1.Images.SetKeyName(4, "img_pyramid32.png");
            // 
            // cboOverviewType
            // 
            this.cboOverviewType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOverviewType.BeforeTouchSize = new System.Drawing.Size(319, 21);
            this.cboOverviewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOverviewType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOverviewType.Location = new System.Drawing.Point(11, 53);
            this.cboOverviewType.Name = "cboOverviewType";
            this.cboOverviewType.Size = new System.Drawing.Size(319, 21);
            this.cboOverviewType.TabIndex = 41;
            // 
            // cboOverviewSampling
            // 
            this.cboOverviewSampling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOverviewSampling.BeforeTouchSize = new System.Drawing.Size(320, 21);
            this.cboOverviewSampling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOverviewSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboOverviewSampling.Location = new System.Drawing.Point(10, 102);
            this.cboOverviewSampling.Name = "cboOverviewSampling";
            this.cboOverviewSampling.Size = new System.Drawing.Size(320, 21);
            this.cboOverviewSampling.TabIndex = 42;
            // 
            // cboDynamicScaleMode
            // 
            this.cboDynamicScaleMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDynamicScaleMode.BeforeTouchSize = new System.Drawing.Size(199, 21);
            this.cboDynamicScaleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDynamicScaleMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboDynamicScaleMode.Location = new System.Drawing.Point(11, 28);
            this.cboDynamicScaleMode.Name = "cboDynamicScaleMode";
            this.cboDynamicScaleMode.Size = new System.Drawing.Size(199, 21);
            this.cboDynamicScaleMode.TabIndex = 7;
            // 
            // cboMaxScale
            // 
            this.cboMaxScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaxScale.BeforeTouchSize = new System.Drawing.Size(142, 21);
            this.cboMaxScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaxScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMaxScale.Location = new System.Drawing.Point(11, 126);
            this.cboMaxScale.Name = "cboMaxScale";
            this.cboMaxScale.Size = new System.Drawing.Size(142, 21);
            this.cboMaxScale.TabIndex = 4;
            // 
            // cboMinScale
            // 
            this.cboMinScale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMinScale.BeforeTouchSize = new System.Drawing.Size(142, 21);
            this.cboMinScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMinScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMinScale.Location = new System.Drawing.Point(11, 77);
            this.cboMinScale.Name = "cboMinScale";
            this.cboMinScale.Size = new System.Drawing.Size(142, 21);
            this.cboMinScale.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(544, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2000;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(453, 461);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 35;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyle = false;
            // 
            // btnApply
            // 
            this.btnApply.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2000;
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnApply.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnApply.IsBackStageButton = false;
            this.btnApply.Location = new System.Drawing.Point(361, 461);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 26);
            this.btnApply.TabIndex = 37;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyle = false;
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStyle});
            this.toolStripEx1.Location = new System.Drawing.Point(10, 462);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.Size = new System.Drawing.Size(95, 25);
            this.toolStripEx1.TabIndex = 39;
            this.toolStripEx1.Text = "Style";
            this.toolStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.ToolStripExStyle.Metro;
            // 
            // toolStyle
            // 
            this.toolStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLoadStyle,
            this.toolSaveStyle,
            this.toolStripSeparator2,
            this.toolRemoveStyle,
            this.toolStripSeparator1,
            this.toolOpenFolder});
            this.toolStyle.ForeColor = System.Drawing.Color.Black;
            this.toolStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.icon_settings;
            this.toolStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStyle.Name = "toolStyle";
            this.toolStyle.Size = new System.Drawing.Size(61, 22);
            this.toolStyle.Text = "Style";
            // 
            // toolLoadStyle
            // 
            this.toolLoadStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_folder_open;
            this.toolLoadStyle.Name = "toolLoadStyle";
            this.toolLoadStyle.Size = new System.Drawing.Size(152, 22);
            this.toolLoadStyle.Text = "Load Style...";
            // 
            // toolSaveStyle
            // 
            this.toolSaveStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.icon_save1;
            this.toolSaveStyle.Name = "toolSaveStyle";
            this.toolSaveStyle.Size = new System.Drawing.Size(152, 22);
            this.toolSaveStyle.Text = "Save Style...";
            // 
            // toolRemoveStyle
            // 
            this.toolRemoveStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_remove16;
            this.toolRemoveStyle.Name = "toolRemoveStyle";
            this.toolRemoveStyle.Size = new System.Drawing.Size(152, 22);
            this.toolRemoveStyle.Text = "Remove Style";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolOpenFolder
            // 
            this.toolOpenFolder.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_hard_disk;
            this.toolOpenFolder.Name = "toolOpenFolder";
            this.toolOpenFolder.Size = new System.Drawing.Size(152, 22);
            this.toolOpenFolder.Text = "Open  Folder";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // RasterStyleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(642, 491);
            this.Controls.Add(this.toolStripEx1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "RasterStyleView";
            this.Text = "Raster Layer Properties";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBriefInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasourceName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLayerName)).EndInit();
            this.tabPageColors.ResumeLayout(false);
            this.tabPageColors.PerformLayout();
            this.tabPageRendering.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrTransparency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrConstrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrBrightness)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUpsampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDownsampling)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelColorize.ResumeLayout(false);
            this.panelColorize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrColorizeIntensity)).EndInit();
            this.tabPageHistogram.ResumeLayout(false);
            this.tabPagePyramids.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rasterInfoTreeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOverviewSampling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDynamicScaleMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaxScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMinScale)).EndInit();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageGeneral;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageInfo;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageColors;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageRendering;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPagePyramids;
        private System.Windows.Forms.ImageList imageList1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtBriefInfo;
        private System.Windows.Forms.Label label5;
        private Syncfusion.Windows.Forms.ButtonAdv btnProjectionDetails;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtProjection;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDatasourceName;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtLayerName;
        private System.Windows.Forms.Label label2;
        private ComboBoxAdv cboMaxScale;
        private ComboBoxAdv cboMinScale;
        private ComboBoxAdv cboDynamicScaleMode;
        private CheckBox chkLayerVisible;
        private System.Windows.Forms.Label label12;
        private ComboBoxAdv cboDownsampling;
        private System.Windows.Forms.Label label11;
        private ComboBoxAdv cboUpsampling;
        private ComboBoxAdv cboOverviewType;
        private ComboBoxAdv cboOverviewSampling;
        private Controls.RasterInfoTreeView rasterInfoTreeView1;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkLayerPreview;
        private ButtonAdv btnApply;
        private Controls.DynamicVisibilityControl _dynamicVisibilityControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkColorize;
        private Office2007ColorPicker clpColorize;
        private CheckBox chkGreyScale;
        private System.Windows.Forms.TrackBar tbrHue;
        private System.Windows.Forms.TrackBar tbrSaturation;
        private System.Windows.Forms.TrackBar tbrGamma;
        private System.Windows.Forms.TrackBar tbrConstrast;
        private System.Windows.Forms.TrackBar tbrBrightness;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar tbrColorizeIntensity;
        private System.Windows.Forms.Label label17;
        private ButtonAdv btnClearColorAdjustments;
        private System.Windows.Forms.Panel panelColorize;
        private TabPageAdv tabPageHistogram;
        private Controls.HistogramControl histogramControl1;
        private Controls.OverviewControl _overviewControl1;
        private SuperToolTip superToolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar tbrTransparency;
        private Office2007ColorPicker clpTransparent;
        private CheckBox chkUseTransparentColor;
        private RichTextBox richTextBox1;
        private ButtonAdv btnOpenFolder;
        private Label label8;
        private ToolStripEx toolStripEx1;
        private ToolStripDropDownButton toolStyle;
        private ToolStripMenuItem toolSaveStyle;
        private ToolStripMenuItem toolLoadStyle;
        private ButtonAdv btnShowDriverInfo;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolOpenFolder;
        private ToolStripMenuItem toolRemoveStyle;
        private ToolStripSeparator toolStripSeparator2;
    }
}