using MW5.Api.Map;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Views
{
    partial class VectorStyleView
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
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VectorStyleView));
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabControl1 = new MW5.UI.Controls.TabPropertiesControl();
            this.tabGeneral = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.chkEditMode = new System.Windows.Forms.CheckBox();
            this.chkSpatialIndex = new System.Windows.Forms.CheckBox();
            this.btnOpenLocation = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtBriefInfo = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProjectionDetails = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtProjection = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDatasourceName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.axMap1 = new MW5.Api.Map.MapControl();
            this.chkLayerPreview = new System.Windows.Forms.CheckBox();
            this.chkLayerVisible = new System.Windows.Forms.CheckBox();
            this.txtLayerName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dynamicVisibilityControl1 = new MW5.Plugins.Symbology.Controls.DynamicVisibilityControl();
            this.tabInfo = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnCopyInfo = new Syncfusion.Windows.Forms.ButtonAdv();
            this.infoGrid1 = new MW5.Plugins.Symbology.Controls.InfoGrid();
            this.tabDefault = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.cboCollisionMode = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.udMinDrawingSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udMinLabelingSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnClearVisibilityExpression = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnChangeVisibilityExpression = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtLayerExpression = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabCategories = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label9 = new System.Windows.Forms.Label();
            this.tabFields = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.attributesControl1 = new MW5.Plugins.Symbology.Controls.AttributesControl();
            this.tabJoins = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.joinControl1 = new MW5.Plugins.Symbology.Controls.JoinControl();
            this.tabLabels = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearLabels = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupLabelAppearance = new System.Windows.Forms.GroupBox();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.udLabelFontSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.clpLabelFrame = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.chkShowLabels = new System.Windows.Forms.CheckBox();
            this.chkLabelFrame = new System.Windows.Forms.CheckBox();
            this.groupLabelStyle = new System.Windows.Forms.GroupBox();
            this.pctLabelPreview = new System.Windows.Forms.PictureBox();
            this.btnLabelAppearance = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabCharts = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChartAppearance = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnClearCharts = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupChartAppearance = new System.Windows.Forms.GroupBox();
            this.btnChartsEditColorScheme = new Syncfusion.Windows.Forms.ButtonAdv();
            this.chkChartsVisible = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.optChartsPie = new System.Windows.Forms.RadioButton();
            this.icbChartColorScheme = new MW5.Plugins.Symbology.Controls.ImageCombo.ColorSchemeCombo();
            this.optChartBars = new System.Windows.Forms.RadioButton();
            this.groupCharts = new System.Windows.Forms.GroupBox();
            this.pctCharts = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxAdv1 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboMaxScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboMinScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnApply = new Syncfusion.Windows.Forms.ButtonAdv();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolStyle = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolSaveStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRemoveStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolOpenLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleControl2 = new MW5.Plugins.Symbology.Controls.ScaleControl();
            this.scaleControl1 = new MW5.Plugins.Symbology.Controls.ScaleControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBriefInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasourceName)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.tabInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid1)).BeginInit();
            this.tabDefault.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCollisionMode)).BeginInit();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMinDrawingSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinLabelingSize)).BeginInit();
            this.groupBox13.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabCategories.SuspendLayout();
            this.tabFields.SuspendLayout();
            this.tabJoins.SuspendLayout();
            this.tabLabels.SuspendLayout();
            this.groupLabelAppearance.SuspendLayout();
            this.panelLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLabelFontSize)).BeginInit();
            this.groupLabelStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLabelPreview)).BeginInit();
            this.tabCharts.SuspendLayout();
            this.groupChartAppearance.SuspendLayout();
            this.groupCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCharts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaxScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMinScale)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(461, 445);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.OnButtonOkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(560, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            this.tabControl1.Controls.Add(this.tabDefault);
            this.tabControl1.Controls.Add(this.tabCategories);
            this.tabControl1.Controls.Add(this.tabFields);
            this.tabControl1.Controls.Add(this.tabJoins);
            this.tabControl1.Controls.Add(this.tabLabels);
            this.tabControl1.Controls.Add(this.tabCharts);
            this.tabControl1.FocusOnTabClick = false;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.InactiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 50);
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(5, 10);
            this.tabControl1.PersistTabState = true;
            this.tabControl1.RotateTextWhenVertical = true;
            this.tabControl1.Size = new System.Drawing.Size(639, 435);
            this.tabControl1.TabGap = 10;
            this.tabControl1.TabIndex = 6;
            this.tabControl1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererBlendLight);
            this.tabControl1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.chkEditMode);
            this.tabGeneral.Controls.Add(this.chkSpatialIndex);
            this.tabGeneral.Controls.Add(this.btnOpenLocation);
            this.tabGeneral.Controls.Add(this.txtBriefInfo);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.btnProjectionDetails);
            this.tabGeneral.Controls.Add(this.txtProjection);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.txtDatasourceName);
            this.tabGeneral.Controls.Add(this.label8);
            this.tabGeneral.Controls.Add(this.groupBox10);
            this.tabGeneral.Controls.Add(this.chkLayerVisible);
            this.tabGeneral.Controls.Add(this.txtLayerName);
            this.tabGeneral.Controls.Add(this.label18);
            this.tabGeneral.Controls.Add(this.dynamicVisibilityControl1);
            this.tabGeneral.Image = null;
            this.tabGeneral.ImageIndex = 0;
            this.tabGeneral.ImageSize = new System.Drawing.Size(16, 16);
            this.tabGeneral.Location = new System.Drawing.Point(119, 0);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.ShowCloseButton = true;
            this.tabGeneral.Size = new System.Drawing.Size(520, 435);
            this.tabGeneral.TabIndex = 10;
            this.tabGeneral.Text = "General";
            this.tabGeneral.ThemesEnabled = false;
            // 
            // chkEditMode
            // 
            this.chkEditMode.AutoSize = true;
            this.chkEditMode.Enabled = false;
            this.chkEditMode.Location = new System.Drawing.Point(361, 396);
            this.chkEditMode.Name = "chkEditMode";
            this.chkEditMode.Size = new System.Drawing.Size(87, 17);
            this.chkEditMode.TabIndex = 174;
            this.chkEditMode.Text = "Editing mode";
            this.chkEditMode.UseVisualStyleBackColor = true;
            // 
            // chkSpatialIndex
            // 
            this.chkSpatialIndex.AutoSize = true;
            this.chkSpatialIndex.Location = new System.Drawing.Point(269, 396);
            this.chkSpatialIndex.Name = "chkSpatialIndex";
            this.chkSpatialIndex.Size = new System.Drawing.Size(86, 17);
            this.chkSpatialIndex.TabIndex = 173;
            this.chkSpatialIndex.Text = "Spatial index";
            this.chkSpatialIndex.UseVisualStyleBackColor = true;
            this.chkSpatialIndex.CheckedChanged += new System.EventHandler(this.OnSpatialIndexChecked);
            // 
            // btnOpenLocation
            // 
            this.btnOpenLocation.BeforeTouchSize = new System.Drawing.Size(63, 23);
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
            this.txtBriefInfo.Text = "Number of features: 143; geometry type: polygon";
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
            // btnProjectionDetails
            // 
            this.btnProjectionDetails.BeforeTouchSize = new System.Drawing.Size(63, 23);
            this.btnProjectionDetails.IsBackStageButton = false;
            this.btnProjectionDetails.Location = new System.Drawing.Point(438, 109);
            this.btnProjectionDetails.Name = "btnProjectionDetails";
            this.btnProjectionDetails.Size = new System.Drawing.Size(63, 23);
            this.btnProjectionDetails.TabIndex = 168;
            this.btnProjectionDetails.Text = "Details";
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
            // txtDatasourceName
            // 
            this.txtDatasourceName.BeforeTouchSize = new System.Drawing.Size(292, 20);
            this.txtDatasourceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDatasourceName.Location = new System.Drawing.Point(137, 71);
            this.txtDatasourceName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDatasourceName.Name = "txtDatasourceName";
            this.txtDatasourceName.ReadOnly = true;
            this.txtDatasourceName.Size = new System.Drawing.Size(292, 20);
            this.txtDatasourceName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtDatasourceName.TabIndex = 165;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 164;
            this.label8.Text = "Datasource name";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.axMap1);
            this.groupBox10.Controls.Add(this.chkLayerPreview);
            this.groupBox10.Location = new System.Drawing.Point(263, 203);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(238, 187);
            this.groupBox10.TabIndex = 163;
            this.groupBox10.TabStop = false;
            // 
            // axMap1
            // 
            this.axMap1.AllowDrop = true;
            this.axMap1.AnimationOnZooming = MW5.Api.Enums.AutoToggle.Auto;
            this.axMap1.BackgroundColor = System.Drawing.Color.White;
            this.axMap1.CurrentScale = 101016253.92530365D;
            this.axMap1.CurrentZoom = -1;
            this.axMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMap1.ExtentHistory = 20;
            this.axMap1.ExtentPad = 0.02D;
            this.axMap1.GrabProjectionFromData = true;
            this.axMap1.InertiaOnPanning = MW5.Api.Enums.AutoToggle.Auto;
            this.axMap1.KnownExtents = MW5.Api.Enums.KnownExtents.None;
            this.axMap1.Latitude = 0F;
            this.axMap1.Location = new System.Drawing.Point(3, 16);
            this.axMap1.Longitude = 0F;
            this.axMap1.MapCursor = MW5.Api.Enums.MapCursor.ZoomIn;
            this.axMap1.MapProjection = MW5.Api.Enums.MapProjection.None;
            this.axMap1.MapUnits = MW5.Api.Enums.LengthUnits.Meters;
            this.axMap1.MouseWheelSpeed = 0.5D;
            this.axMap1.Name = "axMap1";
            spatialReference1.Tag = "";
            this.axMap1.Projection = spatialReference1;
            this.axMap1.ResizeBehavior = MW5.Api.Enums.ResizeBehavior.Classic;
            this.axMap1.ReuseTileBuffer = true;
            this.axMap1.ScalebarUnits = MW5.Api.Enums.ScalebarUnits.GoogleStyle;
            this.axMap1.ScalebarVisible = false;
            this.axMap1.ShowCoordinates = MW5.Api.Enums.CoordinatesDisplay.None;
            this.axMap1.ShowCoordinatesFormat = MW5.Api.Enums.AngleFormat.Degrees;
            this.axMap1.ShowRedrawTime = false;
            this.axMap1.ShowVersionNumber = false;
            this.axMap1.Size = new System.Drawing.Size(232, 168);
            this.axMap1.SystemCursor = MW5.Api.Enums.SystemCursor.MapDefault;
            this.axMap1.TabIndex = 0;
            this.axMap1.Tag = "";
            this.axMap1.TileProvider = MW5.Api.Enums.TileProvider.OpenStreetMap;
            this.axMap1.UdCursorHandle = 0;
            this.axMap1.UseSeamlessPan = false;
            this.axMap1.Visible = false;
            this.axMap1.ZoomBehavior = MW5.Api.Enums.ZoomBehavior.UseTileLevels;
            this.axMap1.ZoomBoxStyle = MW5.Api.Enums.ZoomBoxStyle.Blue;
            this.axMap1.ZoomPercent = 0.3D;
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
            this.chkLayerPreview.CheckedChanged += new System.EventHandler(this.OnLayerPreviewChecked);
            // 
            // chkLayerVisible
            // 
            this.chkLayerVisible.AutoSize = true;
            this.chkLayerVisible.Location = new System.Drawing.Point(438, 35);
            this.chkLayerVisible.Name = "chkLayerVisible";
            this.chkLayerVisible.Size = new System.Drawing.Size(56, 17);
            this.chkLayerVisible.TabIndex = 160;
            this.chkLayerVisible.Text = "Visible";
            this.toolTip1.SetToolTip(this.chkLayerVisible, "Toggles the visibility of the layer");
            this.chkLayerVisible.UseVisualStyleBackColor = true;
            this.chkLayerVisible.CheckedChanged += new System.EventHandler(this.RefreshModel);
            // 
            // txtLayerName
            // 
            this.txtLayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLayerName.Location = new System.Drawing.Point(137, 33);
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size(291, 20);
            this.txtLayerName.TabIndex = 39;
            this.txtLayerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnLayerNameKeyPress);
            this.txtLayerName.Validated += new System.EventHandler(this.OnLayerNameValidated);
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
            this.btnCopyInfo.Click += new System.EventHandler(this.btnCopyInfo_Click);
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
            // tabDefault
            // 
            this.tabDefault.Controls.Add(this.label5);
            this.tabDefault.Controls.Add(this.groupBox21);
            this.tabDefault.Controls.Add(this.groupBox19);
            this.tabDefault.Controls.Add(this.groupBox13);
            this.tabDefault.Controls.Add(this.groupBox5);
            this.tabDefault.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_eye24;
            this.tabDefault.ImageSize = new System.Drawing.Size(24, 24);
            this.tabDefault.Location = new System.Drawing.Point(119, 0);
            this.tabDefault.Name = "tabDefault";
            this.tabDefault.ShowCloseButton = true;
            this.tabDefault.Size = new System.Drawing.Size(520, 435);
            this.tabDefault.TabIndex = 6;
            this.tabDefault.Text = "Appearance";
            this.tabDefault.ThemesEnabled = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(493, 38);
            this.label5.TabIndex = 188;
            this.label5.Text = "Default appearance for features of current datasource. Changes  made here will al" +
    "so be selectively applied to any existing categories.";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.cboCollisionMode);
            this.groupBox21.Location = new System.Drawing.Point(269, 72);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(240, 73);
            this.groupBox21.TabIndex = 187;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Prevent overlaps";
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
            this.cboCollisionMode.Click += new System.EventHandler(this.RefreshModel);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label12);
            this.groupBox19.Controls.Add(this.udMinDrawingSize);
            this.groupBox19.Controls.Add(this.udMinLabelingSize);
            this.groupBox19.Controls.Add(this.label6);
            this.groupBox19.Location = new System.Drawing.Point(269, 160);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(240, 104);
            this.groupBox19.TabIndex = 186;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Minimal geometry size, pixels";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 177;
            this.label12.Text = "to label:";
            // 
            // udMinDrawingSize
            // 
            this.udMinDrawingSize.Location = new System.Drawing.Point(89, 33);
            this.udMinDrawingSize.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udMinDrawingSize.Name = "udMinDrawingSize";
            this.udMinDrawingSize.Size = new System.Drawing.Size(53, 20);
            this.udMinDrawingSize.TabIndex = 176;
            this.udMinDrawingSize.ValueChanged += new System.EventHandler(this.RefreshModel);
            // 
            // udMinLabelingSize
            // 
            this.udMinLabelingSize.Location = new System.Drawing.Point(89, 67);
            this.udMinLabelingSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udMinLabelingSize.Name = "udMinLabelingSize";
            this.udMinLabelingSize.Size = new System.Drawing.Size(53, 20);
            this.udMinLabelingSize.TabIndex = 178;
            this.udMinLabelingSize.ValueChanged += new System.EventHandler(this.RefreshModel);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 175;
            this.label6.Text = "to draw:";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnClearVisibilityExpression);
            this.groupBox13.Controls.Add(this.btnChangeVisibilityExpression);
            this.groupBox13.Controls.Add(this.txtLayerExpression);
            this.groupBox13.Location = new System.Drawing.Point(19, 279);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(490, 128);
            this.groupBox13.TabIndex = 185;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Visibility expression";
            // 
            // btnClearVisibilityExpression
            // 
            this.btnClearVisibilityExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearVisibilityExpression.BeforeTouchSize = new System.Drawing.Size(74, 26);
            this.btnClearVisibilityExpression.IsBackStageButton = false;
            this.btnClearVisibilityExpression.Location = new System.Drawing.Point(399, 51);
            this.btnClearVisibilityExpression.Name = "btnClearVisibilityExpression";
            this.btnClearVisibilityExpression.Size = new System.Drawing.Size(74, 26);
            this.btnClearVisibilityExpression.TabIndex = 168;
            this.btnClearVisibilityExpression.Text = "Clear";
            this.btnClearVisibilityExpression.UseVisualStyleBackColor = true;
            // 
            // btnChangeVisibilityExpression
            // 
            this.btnChangeVisibilityExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeVisibilityExpression.BeforeTouchSize = new System.Drawing.Size(75, 26);
            this.btnChangeVisibilityExpression.IsBackStageButton = false;
            this.btnChangeVisibilityExpression.Location = new System.Drawing.Point(398, 19);
            this.btnChangeVisibilityExpression.Name = "btnChangeVisibilityExpression";
            this.btnChangeVisibilityExpression.Size = new System.Drawing.Size(75, 26);
            this.btnChangeVisibilityExpression.TabIndex = 163;
            this.btnChangeVisibilityExpression.Text = "Change...";
            this.btnChangeVisibilityExpression.UseVisualStyleBackColor = true;
            // 
            // txtLayerExpression
            // 
            this.txtLayerExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayerExpression.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLayerExpression.Location = new System.Drawing.Point(10, 19);
            this.txtLayerExpression.Multiline = true;
            this.txtLayerExpression.Name = "txtLayerExpression";
            this.txtLayerExpression.Size = new System.Drawing.Size(382, 103);
            this.txtLayerExpression.TabIndex = 162;
            this.toolTip1.SetToolTip(this.txtLayerExpression, "Only shapes which agree with the following expression will be visible");
            this.txtLayerExpression.TextChanged += new System.EventHandler(this.RefreshModel);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Location = new System.Drawing.Point(16, 72);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(238, 192);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Appearance (click to edit)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 173);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.OnDefaultDrawingOptionsClick);
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.label9);
            this.tabCategories.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_palette;
            this.tabCategories.ImageSize = new System.Drawing.Size(24, 24);
            this.tabCategories.Location = new System.Drawing.Point(119, 0);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.ShowCloseButton = true;
            this.tabCategories.Size = new System.Drawing.Size(520, 435);
            this.tabCategories.TabIndex = 8;
            this.tabCategories.Text = "Categories";
            this.tabCategories.ThemesEnabled = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "CategoriesSubView will be displayed here dynamically.";
            // 
            // tabFields
            // 
            this.tabFields.Controls.Add(this.attributesControl1);
            this.tabFields.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_table24;
            this.tabFields.ImageSize = new System.Drawing.Size(24, 24);
            this.tabFields.Location = new System.Drawing.Point(119, 0);
            this.tabFields.Name = "tabFields";
            this.tabFields.ShowCloseButton = true;
            this.tabFields.Size = new System.Drawing.Size(520, 435);
            this.tabFields.TabIndex = 16;
            this.tabFields.Text = "Fields";
            this.tabFields.ThemesEnabled = false;
            // 
            // attributesControl1
            // 
            this.attributesControl1.Location = new System.Drawing.Point(3, 3);
            this.attributesControl1.Name = "attributesControl1";
            this.attributesControl1.Size = new System.Drawing.Size(514, 419);
            this.attributesControl1.TabIndex = 0;
            // 
            // tabJoins
            // 
            this.tabJoins.Controls.Add(this.joinControl1);
            this.tabJoins.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_database241;
            this.tabJoins.ImageSize = new System.Drawing.Size(24, 24);
            this.tabJoins.Location = new System.Drawing.Point(119, 0);
            this.tabJoins.Name = "tabJoins";
            this.tabJoins.ShowCloseButton = true;
            this.tabJoins.Size = new System.Drawing.Size(520, 435);
            this.tabJoins.TabIndex = 13;
            this.tabJoins.Text = "Joins";
            this.tabJoins.ThemesEnabled = false;
            // 
            // joinControl1
            // 
            this.joinControl1.Location = new System.Drawing.Point(3, 3);
            this.joinControl1.Name = "joinControl1";
            this.joinControl1.Size = new System.Drawing.Size(514, 419);
            this.joinControl1.TabIndex = 0;
            // 
            // tabLabels
            // 
            this.tabLabels.Controls.Add(this.label1);
            this.tabLabels.Controls.Add(this.btnClearLabels);
            this.tabLabels.Controls.Add(this.groupLabelAppearance);
            this.tabLabels.Controls.Add(this.groupLabelStyle);
            this.tabLabels.Controls.Add(this.btnLabelAppearance);
            this.tabLabels.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_label24;
            this.tabLabels.ImageSize = new System.Drawing.Size(24, 24);
            this.tabLabels.Location = new System.Drawing.Point(119, 0);
            this.tabLabels.Name = "tabLabels";
            this.tabLabels.ShowCloseButton = true;
            this.tabLabels.Size = new System.Drawing.Size(520, 435);
            this.tabLabels.TabIndex = 5;
            this.tabLabels.Text = "Labels";
            this.tabLabels.ThemesEnabled = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 38);
            this.label1.TabIndex = 171;
            this.label1.Text = "Labels generated from attribute values of features. Any field or an expression in" +
    "cluding several fields can be used.";
            // 
            // btnClearLabels
            // 
            this.btnClearLabels.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnClearLabels.IsBackStageButton = false;
            this.btnClearLabels.Location = new System.Drawing.Point(268, 117);
            this.btnClearLabels.Name = "btnClearLabels";
            this.btnClearLabels.Size = new System.Drawing.Size(93, 26);
            this.btnClearLabels.TabIndex = 170;
            this.btnClearLabels.Text = "Clear";
            this.btnClearLabels.UseVisualStyleBackColor = true;
            // 
            // groupLabelAppearance
            // 
            this.groupLabelAppearance.Controls.Add(this.panelLabels);
            this.groupLabelAppearance.Location = new System.Drawing.Point(18, 203);
            this.groupLabelAppearance.Name = "groupLabelAppearance";
            this.groupLabelAppearance.Size = new System.Drawing.Size(235, 128);
            this.groupLabelAppearance.TabIndex = 162;
            this.groupLabelAppearance.TabStop = false;
            this.groupLabelAppearance.Text = "Appearance";
            // 
            // panelLabels
            // 
            this.panelLabels.Controls.Add(this.udLabelFontSize);
            this.panelLabels.Controls.Add(this.clpLabelFrame);
            this.panelLabels.Controls.Add(this.label15);
            this.panelLabels.Controls.Add(this.chkShowLabels);
            this.panelLabels.Controls.Add(this.chkLabelFrame);
            this.panelLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLabels.Location = new System.Drawing.Point(3, 16);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(229, 109);
            this.panelLabels.TabIndex = 161;
            // 
            // udLabelFontSize
            // 
            this.udLabelFontSize.Location = new System.Drawing.Point(19, 60);
            this.udLabelFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLabelFontSize.Name = "udLabelFontSize";
            this.udLabelFontSize.Size = new System.Drawing.Size(51, 20);
            this.udLabelFontSize.TabIndex = 160;
            this.udLabelFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLabelFontSize.ValueChanged += new System.EventHandler(this.OnLabelFontSizeValueChanged);
            // 
            // clpLabelFrame
            // 
            this.clpLabelFrame.Color = System.Drawing.Color.Black;
            this.clpLabelFrame.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpLabelFrame.DropDownHeight = 1;
            this.clpLabelFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpLabelFrame.FormattingEnabled = true;
            this.clpLabelFrame.IntegralHeight = false;
            this.clpLabelFrame.Items.AddRange(new object[] {
            "Color"});
            this.clpLabelFrame.Location = new System.Drawing.Point(128, 59);
            this.clpLabelFrame.Name = "clpLabelFrame";
            this.clpLabelFrame.Size = new System.Drawing.Size(53, 21);
            this.clpLabelFrame.TabIndex = 157;
            this.clpLabelFrame.SelectedColorChanged += new System.EventHandler(this.OnLabelFrameColorChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(76, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 159;
            this.label15.Text = "Size";
            // 
            // chkShowLabels
            // 
            this.chkShowLabels.AutoSize = true;
            this.chkShowLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkShowLabels.Location = new System.Drawing.Point(19, 19);
            this.chkShowLabels.Name = "chkShowLabels";
            this.chkShowLabels.Size = new System.Drawing.Size(89, 17);
            this.chkShowLabels.TabIndex = 137;
            this.chkShowLabels.Text = "Labels visible";
            this.chkShowLabels.UseVisualStyleBackColor = true;
            this.chkShowLabels.CheckedChanged += new System.EventHandler(this.RefreshModel);
            // 
            // chkLabelFrame
            // 
            this.chkLabelFrame.AutoSize = true;
            this.chkLabelFrame.Location = new System.Drawing.Point(128, 19);
            this.chkLabelFrame.Name = "chkLabelFrame";
            this.chkLabelFrame.Size = new System.Drawing.Size(87, 17);
            this.chkLabelFrame.TabIndex = 155;
            this.chkLabelFrame.Text = "Frame visible";
            this.chkLabelFrame.UseVisualStyleBackColor = true;
            this.chkLabelFrame.CheckedChanged += new System.EventHandler(this.OnLabelFrameChecked);
            // 
            // groupLabelStyle
            // 
            this.groupLabelStyle.Controls.Add(this.pctLabelPreview);
            this.groupLabelStyle.Location = new System.Drawing.Point(18, 69);
            this.groupLabelStyle.Name = "groupLabelStyle";
            this.groupLabelStyle.Size = new System.Drawing.Size(235, 128);
            this.groupLabelStyle.TabIndex = 130;
            this.groupLabelStyle.TabStop = false;
            this.groupLabelStyle.Text = "Preview";
            // 
            // pctLabelPreview
            // 
            this.pctLabelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctLabelPreview.Location = new System.Drawing.Point(3, 16);
            this.pctLabelPreview.Name = "pctLabelPreview";
            this.pctLabelPreview.Size = new System.Drawing.Size(229, 109);
            this.pctLabelPreview.TabIndex = 0;
            this.pctLabelPreview.TabStop = false;
            this.pctLabelPreview.Click += new System.EventHandler(this.OnLabelPreviewClick);
            // 
            // btnLabelAppearance
            // 
            this.btnLabelAppearance.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnLabelAppearance.IsBackStageButton = false;
            this.btnLabelAppearance.Location = new System.Drawing.Point(268, 85);
            this.btnLabelAppearance.Name = "btnLabelAppearance";
            this.btnLabelAppearance.Size = new System.Drawing.Size(93, 26);
            this.btnLabelAppearance.TabIndex = 125;
            this.btnLabelAppearance.Text = "Setup...";
            this.btnLabelAppearance.UseVisualStyleBackColor = true;
            // 
            // tabCharts
            // 
            this.tabCharts.Controls.Add(this.label4);
            this.tabCharts.Controls.Add(this.btnChartAppearance);
            this.tabCharts.Controls.Add(this.btnClearCharts);
            this.tabCharts.Controls.Add(this.groupChartAppearance);
            this.tabCharts.Controls.Add(this.groupCharts);
            this.tabCharts.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_chart24;
            this.tabCharts.ImageSize = new System.Drawing.Size(24, 24);
            this.tabCharts.Location = new System.Drawing.Point(119, 0);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.ShowCloseButton = true;
            this.tabCharts.Size = new System.Drawing.Size(520, 435);
            this.tabCharts.TabIndex = 14;
            this.tabCharts.Text = "Charts";
            this.tabCharts.ThemesEnabled = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(478, 38);
            this.label4.TabIndex = 174;
            this.label4.Text = "Pie or bar charts generated from attribute values of features. Any number of nume" +
    "ric fields can be charted.";
            // 
            // btnChartAppearance
            // 
            this.btnChartAppearance.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnChartAppearance.IsBackStageButton = false;
            this.btnChartAppearance.Location = new System.Drawing.Point(268, 85);
            this.btnChartAppearance.Name = "btnChartAppearance";
            this.btnChartAppearance.Size = new System.Drawing.Size(93, 26);
            this.btnChartAppearance.TabIndex = 173;
            this.btnChartAppearance.Text = "Setup...";
            this.btnChartAppearance.UseVisualStyleBackColor = true;
            // 
            // btnClearCharts
            // 
            this.btnClearCharts.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnClearCharts.IsBackStageButton = false;
            this.btnClearCharts.Location = new System.Drawing.Point(268, 117);
            this.btnClearCharts.Name = "btnClearCharts";
            this.btnClearCharts.Size = new System.Drawing.Size(93, 26);
            this.btnClearCharts.TabIndex = 172;
            this.btnClearCharts.Text = "Clear";
            this.btnClearCharts.UseVisualStyleBackColor = true;
            // 
            // groupChartAppearance
            // 
            this.groupChartAppearance.Controls.Add(this.btnChartsEditColorScheme);
            this.groupChartAppearance.Controls.Add(this.chkChartsVisible);
            this.groupChartAppearance.Controls.Add(this.label7);
            this.groupChartAppearance.Controls.Add(this.optChartsPie);
            this.groupChartAppearance.Controls.Add(this.icbChartColorScheme);
            this.groupChartAppearance.Controls.Add(this.optChartBars);
            this.groupChartAppearance.Location = new System.Drawing.Point(18, 203);
            this.groupChartAppearance.Name = "groupChartAppearance";
            this.groupChartAppearance.Size = new System.Drawing.Size(235, 128);
            this.groupChartAppearance.TabIndex = 171;
            this.groupChartAppearance.TabStop = false;
            this.groupChartAppearance.Text = "Appearance";
            // 
            // btnChartsEditColorScheme
            // 
            this.btnChartsEditColorScheme.BeforeTouchSize = new System.Drawing.Size(29, 22);
            this.btnChartsEditColorScheme.IsBackStageButton = false;
            this.btnChartsEditColorScheme.Location = new System.Drawing.Point(137, 83);
            this.btnChartsEditColorScheme.Name = "btnChartsEditColorScheme";
            this.btnChartsEditColorScheme.Size = new System.Drawing.Size(29, 22);
            this.btnChartsEditColorScheme.TabIndex = 164;
            this.btnChartsEditColorScheme.Text = "...";
            this.btnChartsEditColorScheme.UseVisualStyleBackColor = true;
            // 
            // chkChartsVisible
            // 
            this.chkChartsVisible.Location = new System.Drawing.Point(17, 33);
            this.chkChartsVisible.Name = "chkChartsVisible";
            this.chkChartsVisible.Size = new System.Drawing.Size(95, 19);
            this.chkChartsVisible.TabIndex = 127;
            this.chkChartsVisible.Text = "Charts visible";
            this.chkChartsVisible.UseVisualStyleBackColor = true;
            this.chkChartsVisible.CheckedChanged += new System.EventHandler(this.RefreshModel);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Color scheme";
            // 
            // optChartsPie
            // 
            this.optChartsPie.AutoSize = true;
            this.optChartsPie.Location = new System.Drawing.Point(145, 57);
            this.optChartsPie.Name = "optChartsPie";
            this.optChartsPie.Size = new System.Drawing.Size(72, 17);
            this.optChartsPie.TabIndex = 164;
            this.optChartsPie.Text = "Pie charts";
            this.optChartsPie.UseVisualStyleBackColor = true;
            this.optChartsPie.CheckedChanged += new System.EventHandler(this.RefreshModel);
            // 
            // icbChartColorScheme
            // 
            this.icbChartColorScheme.ComboStyle = MW5.Api.Enums.SchemeType.Graduated;
            this.icbChartColorScheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbChartColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbChartColorScheme.FormattingEnabled = true;
            this.icbChartColorScheme.Location = new System.Drawing.Point(17, 83);
            this.icbChartColorScheme.Name = "icbChartColorScheme";
            this.icbChartColorScheme.OutlineColor = System.Drawing.Color.Black;
            this.icbChartColorScheme.Size = new System.Drawing.Size(114, 21);
            this.icbChartColorScheme.TabIndex = 22;
            this.icbChartColorScheme.Target = MW5.Plugins.Symbology.SchemeTarget.Vector;
            this.icbChartColorScheme.SelectedIndexChanged += new System.EventHandler(this.OnChartColorSchemeSelectedIndexChanged);
            // 
            // optChartBars
            // 
            this.optChartBars.AutoSize = true;
            this.optChartBars.Checked = true;
            this.optChartBars.Location = new System.Drawing.Point(145, 33);
            this.optChartBars.Name = "optChartBars";
            this.optChartBars.Size = new System.Drawing.Size(73, 17);
            this.optChartBars.TabIndex = 163;
            this.optChartBars.TabStop = true;
            this.optChartBars.Text = "Bar charts";
            this.optChartBars.UseVisualStyleBackColor = true;
            this.optChartBars.CheckedChanged += new System.EventHandler(this.RefreshModel);
            // 
            // groupCharts
            // 
            this.groupCharts.Controls.Add(this.pctCharts);
            this.groupCharts.Location = new System.Drawing.Point(18, 69);
            this.groupCharts.Name = "groupCharts";
            this.groupCharts.Size = new System.Drawing.Size(235, 128);
            this.groupCharts.TabIndex = 170;
            this.groupCharts.TabStop = false;
            this.groupCharts.Text = "Preview";
            // 
            // pctCharts
            // 
            this.pctCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctCharts.Location = new System.Drawing.Point(3, 16);
            this.pctCharts.Name = "pctCharts";
            this.pctCharts.Size = new System.Drawing.Size(229, 109);
            this.pctCharts.TabIndex = 0;
            this.pctCharts.TabStop = false;
            this.pctCharts.Click += new System.EventHandler(this.OnChartsClick);
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
            this.imageList1.Images.SetKeyName(5, "img_brush24.png");
            this.imageList1.Images.SetKeyName(6, "img_chart24.png");
            this.imageList1.Images.SetKeyName(7, "img_cog24.png");
            this.imageList1.Images.SetKeyName(8, "img_eye24.png");
            this.imageList1.Images.SetKeyName(9, "img_label24.png");
            // 
            // comboBoxAdv1
            // 
            this.comboBoxAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAdv1.BeforeTouchSize = new System.Drawing.Size(199, 21);
            this.comboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAdv1.Location = new System.Drawing.Point(11, 28);
            this.comboBoxAdv1.Name = "comboBoxAdv1";
            this.comboBoxAdv1.Size = new System.Drawing.Size(199, 21);
            this.comboBoxAdv1.TabIndex = 7;
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
            this.cboMinScale.BeforeTouchSize = new System.Drawing.Size(141, 21);
            this.cboMinScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMinScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMinScale.Location = new System.Drawing.Point(12, 77);
            this.cboMinScale.Name = "cboMinScale";
            this.cboMinScale.Size = new System.Drawing.Size(141, 21);
            this.cboMinScale.TabIndex = 3;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtComments);
            this.groupBox7.Location = new System.Drawing.Point(720, 71);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(289, 81);
            this.groupBox7.TabIndex = 166;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Description";
            // 
            // txtComments
            // 
            this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtComments.Location = new System.Drawing.Point(3, 16);
            this.txtComments.Name = "txtComments";
            this.txtComments.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtComments.Size = new System.Drawing.Size(283, 62);
            this.txtComments.TabIndex = 1;
            this.txtComments.Text = "";
            this.txtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnCommentsKeyPress);
            this.txtComments.Validated += new System.EventHandler(this.OnCommentsValidated);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnApply.Enabled = false;
            this.btnApply.IsBackStageButton = false;
            this.btnApply.Location = new System.Drawing.Point(362, 445);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(93, 26);
            this.btnApply.TabIndex = 134;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnSaveChangesClick);
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStyle});
            this.toolStripEx1.Location = new System.Drawing.Point(12, 447);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.Size = new System.Drawing.Size(64, 25);
            this.toolStripEx1.TabIndex = 167;
            this.toolStripEx1.Text = "Style";
            this.toolStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.ToolStripExStyle.Metro;
            // 
            // toolStyle
            // 
            this.toolStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSaveStyle,
            this.toolRemoveStyle,
            this.toolStripSeparator1,
            this.toolOpenLocation});
            this.toolStyle.ForeColor = System.Drawing.Color.Black;
            this.toolStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.icon_settings;
            this.toolStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStyle.Name = "toolStyle";
            this.toolStyle.Size = new System.Drawing.Size(61, 22);
            this.toolStyle.Text = "Style";
            // 
            // toolSaveStyle
            // 
            this.toolSaveStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.icon_save1;
            this.toolSaveStyle.Name = "toolSaveStyle";
            this.toolSaveStyle.Size = new System.Drawing.Size(144, 22);
            this.toolSaveStyle.Text = "Save style";
            // 
            // toolRemoveStyle
            // 
            this.toolRemoveStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_remove16;
            this.toolRemoveStyle.Name = "toolRemoveStyle";
            this.toolRemoveStyle.Size = new System.Drawing.Size(144, 22);
            this.toolRemoveStyle.Text = "Remove style";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // toolOpenLocation
            // 
            this.toolOpenLocation.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_hard_disk;
            this.toolOpenLocation.Name = "toolOpenLocation";
            this.toolOpenLocation.Size = new System.Drawing.Size(144, 22);
            this.toolOpenLocation.Text = "Open folder";
            // 
            // scaleControl2
            // 
            this.scaleControl2.BackColor = System.Drawing.Color.Transparent;
            this.scaleControl2.CurrentScale = -1D;
            this.scaleControl2.FillColor = System.Drawing.Color.LightGreen;
            this.scaleControl2.FillColor2 = System.Drawing.Color.Khaki;
            this.scaleControl2.Location = new System.Drawing.Point(3, 16);
            this.scaleControl2.MaximumScale = 1000000000D;
            this.scaleControl2.MaximumSize = new System.Drawing.Size(130, 1000);
            this.scaleControl2.MinimimScale = 1.0000004910124416D;
            this.scaleControl2.MinimumSize = new System.Drawing.Size(80, 200);
            this.scaleControl2.Name = "scaleControl2";
            this.scaleControl2.OutlineColor = System.Drawing.Color.DarkGray;
            this.scaleControl2.SelectionColor = System.Drawing.Color.Blue;
            this.scaleControl2.Size = new System.Drawing.Size(110, 273);
            this.scaleControl2.TabIndex = 162;
            this.scaleControl2.UseDynamicVisibility = false;
            // 
            // scaleControl1
            // 
            this.scaleControl1.BackColor = System.Drawing.Color.Transparent;
            this.scaleControl1.CurrentScale = -1D;
            this.scaleControl1.FillColor = System.Drawing.Color.LightGreen;
            this.scaleControl1.FillColor2 = System.Drawing.Color.Khaki;
            this.scaleControl1.Location = new System.Drawing.Point(3, 16);
            this.scaleControl1.MaximumScale = 1000000000D;
            this.scaleControl1.MaximumSize = new System.Drawing.Size(130, 1000);
            this.scaleControl1.MinimimScale = 1.0000004910124416D;
            this.scaleControl1.MinimumSize = new System.Drawing.Size(80, 200);
            this.scaleControl1.Name = "scaleControl1";
            this.scaleControl1.OutlineColor = System.Drawing.Color.DarkGray;
            this.scaleControl1.SelectionColor = System.Drawing.Color.Blue;
            this.scaleControl1.Size = new System.Drawing.Size(110, 273);
            this.scaleControl1.TabIndex = 162;
            this.scaleControl1.UseDynamicVisibility = false;
            // 
            // VectorStyleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(661, 474);
            this.Controls.Add(this.toolStripEx1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VectorStyleView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Layer properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBriefInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatasourceName)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid1)).EndInit();
            this.tabDefault.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboCollisionMode)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMinDrawingSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinLabelingSize)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabCategories.ResumeLayout(false);
            this.tabCategories.PerformLayout();
            this.tabFields.ResumeLayout(false);
            this.tabJoins.ResumeLayout(false);
            this.tabLabels.ResumeLayout(false);
            this.groupLabelAppearance.ResumeLayout(false);
            this.panelLabels.ResumeLayout(false);
            this.panelLabels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLabelFontSize)).EndInit();
            this.groupLabelStyle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctLabelPreview)).EndInit();
            this.tabCharts.ResumeLayout(false);
            this.groupChartAppearance.ResumeLayout(false);
            this.groupChartAppearance.PerformLayout();
            this.groupCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctCharts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaxScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMinScale)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonAdv btnOk;
        private ButtonAdv btnCancel;
        private TabPropertiesControl tabControl1;
        private TabPageAdv tabLabels;
        private TabPageAdv tabDefault;
        private TabPageAdv tabCategories;
        private TabPageAdv tabGeneral;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtLayerName;
        private System.Windows.Forms.GroupBox groupLabelStyle;
        private System.Windows.Forms.PictureBox pctLabelPreview;
        private ButtonAdv btnLabelAppearance;
        private System.Windows.Forms.CheckBox chkShowLabels;
        private Office2007ColorPicker clpLabelFrame;
        private System.Windows.Forms.CheckBox chkLabelFrame;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkLayerVisible;
        private System.Windows.Forms.CheckBox chkLayerPreview;
        private System.Windows.Forms.GroupBox groupBox10;
        private MapControl axMap1;
        private System.Windows.Forms.Panel panelLabels;
        private NumericUpDownEx udLabelFontSize;
        private ScaleControl scaleControl2;
        private ScaleControl scaleControl1;
        private TabPageAdv tabJoins;
        private System.Windows.Forms.GroupBox groupLabelAppearance;
        private ButtonAdv btnApply;
        private ButtonAdv btnClearLabels;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox txtComments;
        private TabPageAdv tabCharts;
        private ButtonAdv btnChartAppearance;
        private ButtonAdv btnClearCharts;
        private System.Windows.Forms.GroupBox groupChartAppearance;
        private ButtonAdv btnChartsEditColorScheme;
        private System.Windows.Forms.CheckBox chkChartsVisible;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton optChartsPie;
        private ColorSchemeCombo icbChartColorScheme;
        private System.Windows.Forms.RadioButton optChartBars;
        private System.Windows.Forms.GroupBox groupCharts;
        private System.Windows.Forms.PictureBox pctCharts;
        private TabPageAdv tabInfo;
        private System.Windows.Forms.ImageList imageList1;
        private TextBoxExt txtBriefInfo;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.ButtonAdv btnProjectionDetails;
        private TextBoxExt txtProjection;
        private System.Windows.Forms.Label label3;
        private TextBoxExt txtDatasourceName;
        private System.Windows.Forms.Label label8;
        private ComboBoxAdv comboBoxAdv1;
        private ComboBoxAdv cboMaxScale;
        private ComboBoxAdv cboMinScale;
        private DynamicVisibilityControl dynamicVisibilityControl1;
        private TabPageAdv tabFields;
        private AttributesControl attributesControl1;
        private ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripDropDownButton toolStyle;
        private System.Windows.Forms.ToolStripMenuItem toolSaveStyle;
        private ButtonAdv btnOpenLocation;
        private System.Windows.Forms.ToolStripMenuItem toolRemoveStyle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolOpenLocation;
        private JoinControl joinControl1;
        private System.Windows.Forms.CheckBox chkEditMode;
        private System.Windows.Forms.CheckBox chkSpatialIndex;
        private System.Windows.Forms.GroupBox groupBox21;
        private ComboBoxAdv cboCollisionMode;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label label12;
        private NumericUpDownEx udMinDrawingSize;
        private NumericUpDownEx udMinLabelingSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox13;
        private ButtonAdv btnClearVisibilityExpression;
        private ButtonAdv btnChangeVisibilityExpression;
        private System.Windows.Forms.TextBox txtLayerExpression;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private InfoGrid infoGrid1;
        private ButtonAdv btnCopyInfo;
    }
}