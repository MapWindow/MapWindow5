using MW5.Api;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ColorPicker;
using MW5.Plugins.Symbology.Controls.ImageCombo;

namespace MW5.Plugins.Symbology.Forms.Layer
{
    partial class LayerStyleForm
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
            MW5.Api.Concrete.Envelope envelope1 = new MW5.Api.Concrete.Envelope();
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLayerSource = new System.Windows.Forms.RichTextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.axMap1 = new MW5.Api.MapControl();
            this.chkLayerPreview = new System.Windows.Forms.CheckBox();
            this.chkLayerVisible = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtLayerName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabDefault = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.transpMain = new MW5.Plugins.Symbology.Controls.TransparencyControl();
            this.groupLine = new System.Windows.Forms.GroupBox();
            this.lblMultilinePattern = new System.Windows.Forms.Label();
            this.panelLineOptions = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.icbLineWidth = new MW5.Plugins.Symbology.Controls.ImageCombo.ImageCombo();
            this.clpDefaultOutline = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.groupPoint = new System.Windows.Forms.GroupBox();
            this.udDefaultSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.clpPointFill = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.groupFill = new System.Windows.Forms.GroupBox();
            this.icbFillStyle = new MW5.Plugins.Symbology.Controls.ImageCombo.ImageCombo();
            this.clpPolygonFill = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.transpSelection = new MW5.Plugins.Symbology.Controls.TransparencyControl();
            this.label1 = new System.Windows.Forms.Label();
            this.clpSelection = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDefaultChange = new System.Windows.Forms.Button();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmnStyle = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lstFields1 = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkRandomColors = new System.Windows.Forms.CheckBox();
            this.chkSetGradient = new System.Windows.Forms.CheckBox();
            this.icbCategories = new MW5.Plugins.Symbology.Controls.ImageCombo.ColorSchemeCombo();
            this.btnChangeColorScheme = new System.Windows.Forms.Button();
            this.btnCategoryClear = new System.Windows.Forms.Button();
            this.groupVariableSize = new System.Windows.Forms.GroupBox();
            this.udMaxSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udMinSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.chkUseVariableSize = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.udNumCategories = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.chkUniqueValues = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCategoryRemove = new System.Windows.Forms.Button();
            this.btnCategoryAppearance = new System.Windows.Forms.Button();
            this.btnCategoryGenerate = new System.Windows.Forms.Button();
            this.tabLabels = new System.Windows.Forms.TabPage();
            this.btnLabelsClear = new System.Windows.Forms.Button();
            this.groupLabelAppearance = new System.Windows.Forms.GroupBox();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.udLabelFontSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.clpLabelFrame = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.chkShowLabels = new System.Windows.Forms.CheckBox();
            this.chkLabelFrame = new System.Windows.Forms.CheckBox();
            this.groupLabelStyle = new System.Windows.Forms.GroupBox();
            this.pctLabelPreview = new System.Windows.Forms.PictureBox();
            this.btnLabelsAppearance = new System.Windows.Forms.Button();
            this.tabCharts = new System.Windows.Forms.TabPage();
            this.btnChartAppearance = new System.Windows.Forms.Button();
            this.btnClearCharts = new System.Windows.Forms.Button();
            this.groupChartAppearance = new System.Windows.Forms.GroupBox();
            this.btnChartsEditColorScheme = new System.Windows.Forms.Button();
            this.chkChartsVisible = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.optChartsPie = new System.Windows.Forms.RadioButton();
            this.icbChartColorScheme = new MW5.Plugins.Symbology.Controls.ImageCombo.ColorSchemeCombo();
            this.optChartBars = new System.Windows.Forms.RadioButton();
            this.groupCharts = new System.Windows.Forms.GroupBox();
            this.pctCharts = new System.Windows.Forms.PictureBox();
            this.tabVisibility = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scaleLayer = new MW5.Plugins.Symbology.Controls.ScaleControl();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnClearLayerExpression = new System.Windows.Forms.Button();
            this.btnLayerExpression = new System.Windows.Forms.Button();
            this.txtLayerExpression = new System.Windows.Forms.TextBox();
            this.tabMode = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.cboCollisionMode = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.udMinDrawingSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udMinLabelingSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.groupModeDescription = new System.Windows.Forms.GroupBox();
            this.txtModeDescription = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEditMode = new System.Windows.Forms.CheckBox();
            this.chkInMemory = new System.Windows.Forms.CheckBox();
            this.chkSpatialIndex = new System.Windows.Forms.CheckBox();
            this.chkFastMode = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkRedrawMap = new System.Windows.Forms.CheckBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.scaleControl2 = new MW5.Plugins.Symbology.Controls.ScaleControl();
            this.scaleControl1 = new MW5.Plugins.Symbology.Controls.ScaleControl();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabDefault.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupLine.SuspendLayout();
            this.panelLineOptions.SuspendLayout();
            this.groupPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDefaultSize)).BeginInit();
            this.groupFill.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabCategories.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupVariableSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinSize)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udNumCategories)).BeginInit();
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
            this.tabVisibility.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabMode.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMinDrawingSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinLabelingSize)).BeginInit();
            this.groupModeDescription.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(417, 355);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(93, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(516, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabDefault);
            this.tabControl1.Controls.Add(this.tabCategories);
            this.tabControl1.Controls.Add(this.tabLabels);
            this.tabControl1.Controls.Add(this.tabCharts);
            this.tabControl1.Controls.Add(this.tabVisibility);
            this.tabControl1.Controls.Add(this.tabMode);
            this.tabControl1.Location = new System.Drawing.Point(7, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 349);
            this.tabControl1.TabIndex = 6;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBox4);
            this.tabGeneral.Controls.Add(this.groupBox10);
            this.tabGeneral.Controls.Add(this.chkLayerPreview);
            this.tabGeneral.Controls.Add(this.chkLayerVisible);
            this.tabGeneral.Controls.Add(this.label20);
            this.tabGeneral.Controls.Add(this.txtLayerName);
            this.tabGeneral.Controls.Add(this.label18);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(595, 323);
            this.tabGeneral.TabIndex = 10;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLayerSource);
            this.groupBox4.Location = new System.Drawing.Point(293, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(289, 227);
            this.groupBox4.TabIndex = 165;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Source";
            // 
            // txtLayerSource
            // 
            this.txtLayerSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLayerSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLayerSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLayerSource.Location = new System.Drawing.Point(3, 16);
            this.txtLayerSource.Name = "txtLayerSource";
            this.txtLayerSource.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLayerSource.Size = new System.Drawing.Size(283, 208);
            this.txtLayerSource.TabIndex = 1;
            this.txtLayerSource.Text = "";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.axMap1);
            this.groupBox10.Location = new System.Drawing.Point(15, 15);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(260, 269);
            this.groupBox10.TabIndex = 163;
            this.groupBox10.TabStop = false;
            // 
            // axMap1
            // 
            this.axMap1.AnimationOnZooming = MW5.Api.AutoToggle.Auto;
            this.axMap1.CurrentScale = 232.28589343056248D;
            this.axMap1.CurrentZoom = -1;
            this.axMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMap1.ExtentHistory = 20;
            this.axMap1.ExtentPad = 0.02D;
            envelope1.Tag = "";
            this.axMap1.Extents = envelope1;
            spatialReference1.Tag = "";
            this.axMap1.GeoProjection = spatialReference1;
            this.axMap1.GrabProjectionFromData = true;
            this.axMap1.InertiaOnPanning = MW5.Api.AutoToggle.Auto;
            this.axMap1.KnownExtents = MW5.Api.KnownExtents.None;
            this.axMap1.Latitude = 0F;
            this.axMap1.Location = new System.Drawing.Point(3, 16);
            this.axMap1.Longitude = 0F;
            this.axMap1.MapCursor = MW5.Api.MapCursor.ZoomIn;
            this.axMap1.MapUnits = MW5.Api.UnitsOfMeasure.Meters;
            this.axMap1.MouseWheelSpeed = 0.5D;
            this.axMap1.Name = "axMap1";
            this.axMap1.Projection = MW5.Api.MapProjection.None;
            this.axMap1.ResizeBehavior = MW5.Api.ResizeBehavior.Classic;
            this.axMap1.ReuseTileBuffer = true;
            this.axMap1.ScalebarUnits = MW5.Api.ScalebarUnits.GoogleStyle;
            this.axMap1.ScalebarVisible = false;
            this.axMap1.ShowCoordinates = MW5.Api.CoordinatesDisplay.None;
            this.axMap1.ShowRedrawTime = false;
            this.axMap1.ShowVersionNumber = false;
            this.axMap1.Size = new System.Drawing.Size(254, 250);
            this.axMap1.SystemCursor = MW5.Api.SystemCursor.MapDefault;
            this.axMap1.TabIndex = 0;
            this.axMap1.Tag = "";
            this.axMap1.TileProvider = MW5.Api.TileProvider.OpenStreetMap;
            this.axMap1.UdCursorHandle = 0;
            this.axMap1.UseSeamlessPan = false;
            this.axMap1.Visible = false;
            this.axMap1.ZoomBehavior = MW5.Api.ZoomBehavior.UseTileLevels;
            this.axMap1.ZoomPercent = 0.3D;
            // 
            // chkLayerPreview
            // 
            this.chkLayerPreview.AutoSize = true;
            this.chkLayerPreview.Location = new System.Drawing.Point(179, 290);
            this.chkLayerPreview.Name = "chkLayerPreview";
            this.chkLayerPreview.Size = new System.Drawing.Size(93, 17);
            this.chkLayerPreview.TabIndex = 162;
            this.chkLayerPreview.Text = "Show preview";
            this.chkLayerPreview.UseVisualStyleBackColor = true;
            this.chkLayerPreview.CheckedChanged += new System.EventHandler(this.chkLayerPreview_CheckedChanged);
            // 
            // chkLayerVisible
            // 
            this.chkLayerVisible.AutoSize = true;
            this.chkLayerVisible.Location = new System.Drawing.Point(18, 290);
            this.chkLayerVisible.Name = "chkLayerVisible";
            this.chkLayerVisible.Size = new System.Drawing.Size(84, 17);
            this.chkLayerVisible.TabIndex = 160;
            this.chkLayerVisible.Text = "Layer visible";
            this.toolTip1.SetToolTip(this.chkLayerVisible, "Toggles the visibility of the layer");
            this.chkLayerVisible.UseVisualStyleBackColor = true;
            this.chkLayerVisible.CheckedChanged += new System.EventHandler(this.chkLayerVisible_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(290, 184);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 155;
            this.label20.Text = "Comments";
            // 
            // txtLayerName
            // 
            this.txtLayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLayerName.Location = new System.Drawing.Point(293, 31);
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size(289, 20);
            this.txtLayerName.TabIndex = 39;
            this.txtLayerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLayerName_KeyPress);
            this.txtLayerName.Validated += new System.EventHandler(this.txtLayerName_Validated);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(290, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "Name";
            // 
            // tabDefault
            // 
            this.tabDefault.Controls.Add(this.groupBox3);
            this.tabDefault.Controls.Add(this.groupLine);
            this.tabDefault.Controls.Add(this.groupPoint);
            this.tabDefault.Controls.Add(this.groupFill);
            this.tabDefault.Controls.Add(this.groupBox16);
            this.tabDefault.Controls.Add(this.groupBox5);
            this.tabDefault.Controls.Add(this.btnDefaultChange);
            this.tabDefault.Location = new System.Drawing.Point(4, 22);
            this.tabDefault.Name = "tabDefault";
            this.tabDefault.Size = new System.Drawing.Size(595, 323);
            this.tabDefault.TabIndex = 6;
            this.tabDefault.Text = "Appearance";
            this.tabDefault.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.transpMain);
            this.groupBox3.Location = new System.Drawing.Point(265, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 68);
            this.groupBox3.TabIndex = 181;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Transparency";
            // 
            // transpMain
            // 
            this.transpMain.BandColor = System.Drawing.Color.Empty;
            this.transpMain.Location = new System.Drawing.Point(23, 24);
            this.transpMain.MaximumSize = new System.Drawing.Size(1024, 32);
            this.transpMain.MinimumSize = new System.Drawing.Size(128, 32);
            this.transpMain.Name = "transpMain";
            this.transpMain.Size = new System.Drawing.Size(249, 32);
            this.transpMain.TabIndex = 177;
            this.transpMain.Value = ((byte)(255));
            this.transpMain.ValueChanged += new MW5.Plugins.Symbology.Controls.TransparencyControl.ValueChangedDeleg(this.transpMain_ValueChanged);
            // 
            // groupLine
            // 
            this.groupLine.Controls.Add(this.lblMultilinePattern);
            this.groupLine.Controls.Add(this.panelLineOptions);
            this.groupLine.Location = new System.Drawing.Point(6, 303);
            this.groupLine.Name = "groupLine";
            this.groupLine.Size = new System.Drawing.Size(299, 74);
            this.groupLine.TabIndex = 178;
            this.groupLine.TabStop = false;
            this.groupLine.Text = "Outline";
            // 
            // lblMultilinePattern
            // 
            this.lblMultilinePattern.AutoSize = true;
            this.lblMultilinePattern.Location = new System.Drawing.Point(16, 33);
            this.lblMultilinePattern.Name = "lblMultilinePattern";
            this.lblMultilinePattern.Size = new System.Drawing.Size(202, 13);
            this.lblMultilinePattern.TabIndex = 177;
            this.lblMultilinePattern.Text = "       Multiline pattern: no options available";
            // 
            // panelLineOptions
            // 
            this.panelLineOptions.Controls.Add(this.label16);
            this.panelLineOptions.Controls.Add(this.icbLineWidth);
            this.panelLineOptions.Controls.Add(this.clpDefaultOutline);
            this.panelLineOptions.Controls.Add(this.label21);
            this.panelLineOptions.Location = new System.Drawing.Point(19, 24);
            this.panelLineOptions.Name = "panelLineOptions";
            this.panelLineOptions.Size = new System.Drawing.Size(282, 34);
            this.panelLineOptions.TabIndex = 177;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(220, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Line width";
            // 
            // icbLineWidth
            // 
            this.icbLineWidth.Color1 = System.Drawing.Color.Gray;
            this.icbLineWidth.Color2 = System.Drawing.Color.Gray;
            this.icbLineWidth.ComboStyle = MW5.Plugins.Symbology.ImageComboStyle.Common;
            this.icbLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineWidth.FormattingEnabled = true;
            this.icbLineWidth.Location = new System.Drawing.Point(142, 6);
            this.icbLineWidth.Name = "icbLineWidth";
            this.icbLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.icbLineWidth.Size = new System.Drawing.Size(72, 21);
            this.icbLineWidth.TabIndex = 4;
            this.icbLineWidth.SelectedIndexChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // clpDefaultOutline
            // 
            this.clpDefaultOutline.Color = System.Drawing.Color.White;
            this.clpDefaultOutline.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpDefaultOutline.DropDownHeight = 1;
            this.clpDefaultOutline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpDefaultOutline.FormattingEnabled = true;
            this.clpDefaultOutline.IntegralHeight = false;
            this.clpDefaultOutline.Items.AddRange(new object[] {
            "Color"});
            this.clpDefaultOutline.Location = new System.Drawing.Point(7, 6);
            this.clpDefaultOutline.Name = "clpDefaultOutline";
            this.clpDefaultOutline.Size = new System.Drawing.Size(57, 21);
            this.clpDefaultOutline.TabIndex = 176;
            this.clpDefaultOutline.SelectedColorChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(75, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Line color";
            // 
            // groupPoint
            // 
            this.groupPoint.Controls.Add(this.udDefaultSize);
            this.groupPoint.Controls.Add(this.label4);
            this.groupPoint.Controls.Add(this.clpPointFill);
            this.groupPoint.Controls.Add(this.label9);
            this.groupPoint.Location = new System.Drawing.Point(320, 285);
            this.groupPoint.Name = "groupPoint";
            this.groupPoint.Size = new System.Drawing.Size(299, 77);
            this.groupPoint.TabIndex = 179;
            this.groupPoint.TabStop = false;
            this.groupPoint.Text = "Point";
            // 
            // udDefaultSize
            // 
            this.udDefaultSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.udDefaultSize.Location = new System.Drawing.Point(154, 29);
            this.udDefaultSize.Name = "udDefaultSize";
            this.udDefaultSize.Size = new System.Drawing.Size(52, 20);
            this.udDefaultSize.TabIndex = 182;
            this.udDefaultSize.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Fill color";
            // 
            // clpPointFill
            // 
            this.clpPointFill.Color = System.Drawing.Color.White;
            this.clpPointFill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpPointFill.DropDownHeight = 1;
            this.clpPointFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpPointFill.FormattingEnabled = true;
            this.clpPointFill.IntegralHeight = false;
            this.clpPointFill.Items.AddRange(new object[] {
            "Color"});
            this.clpPointFill.Location = new System.Drawing.Point(23, 28);
            this.clpPointFill.Name = "clpPointFill";
            this.clpPointFill.Size = new System.Drawing.Size(57, 21);
            this.clpPointFill.TabIndex = 167;
            this.clpPointFill.SelectedColorChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(212, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Point size";
            // 
            // groupFill
            // 
            this.groupFill.Controls.Add(this.icbFillStyle);
            this.groupFill.Controls.Add(this.clpPolygonFill);
            this.groupFill.Controls.Add(this.label22);
            this.groupFill.Controls.Add(this.label23);
            this.groupFill.Location = new System.Drawing.Point(265, 14);
            this.groupFill.Name = "groupFill";
            this.groupFill.Size = new System.Drawing.Size(299, 73);
            this.groupFill.TabIndex = 180;
            this.groupFill.TabStop = false;
            this.groupFill.Text = "Fill";
            // 
            // icbFillStyle
            // 
            this.icbFillStyle.Color1 = System.Drawing.Color.Gray;
            this.icbFillStyle.Color2 = System.Drawing.Color.Gray;
            this.icbFillStyle.ComboStyle = MW5.Plugins.Symbology.ImageComboStyle.Common;
            this.icbFillStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbFillStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbFillStyle.FormattingEnabled = true;
            this.icbFillStyle.Location = new System.Drawing.Point(154, 31);
            this.icbFillStyle.Name = "icbFillStyle";
            this.icbFillStyle.OutlineColor = System.Drawing.Color.Black;
            this.icbFillStyle.Size = new System.Drawing.Size(86, 21);
            this.icbFillStyle.TabIndex = 110;
            this.icbFillStyle.SelectedIndexChanged += new System.EventHandler(this.icbFillStyle_SelectedIndexChanged);
            // 
            // clpPolygonFill
            // 
            this.clpPolygonFill.Color = System.Drawing.Color.Black;
            this.clpPolygonFill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpPolygonFill.DropDownHeight = 1;
            this.clpPolygonFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpPolygonFill.FormattingEnabled = true;
            this.clpPolygonFill.IntegralHeight = false;
            this.clpPolygonFill.Items.AddRange(new object[] {
            "Color"});
            this.clpPolygonFill.Location = new System.Drawing.Point(23, 31);
            this.clpPolygonFill.Name = "clpPolygonFill";
            this.clpPolygonFill.Size = new System.Drawing.Size(63, 21);
            this.clpPolygonFill.TabIndex = 109;
            this.clpPolygonFill.SelectedColorChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(92, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 13);
            this.label22.TabIndex = 106;
            this.label22.Text = "Fill color";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(246, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(43, 13);
            this.label23.TabIndex = 108;
            this.label23.Text = "Fill style";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.transpSelection);
            this.groupBox16.Controls.Add(this.label1);
            this.groupBox16.Controls.Add(this.clpSelection);
            this.groupBox16.Location = new System.Drawing.Point(265, 167);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(299, 112);
            this.groupBox16.TabIndex = 177;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Selection";
            // 
            // transpSelection
            // 
            this.transpSelection.BandColor = System.Drawing.Color.Yellow;
            this.transpSelection.Location = new System.Drawing.Point(23, 67);
            this.transpSelection.MaximumSize = new System.Drawing.Size(1024, 32);
            this.transpSelection.MinimumSize = new System.Drawing.Size(128, 32);
            this.transpSelection.Name = "transpSelection";
            this.transpSelection.Size = new System.Drawing.Size(249, 32);
            this.transpSelection.TabIndex = 176;
            this.transpSelection.Value = ((byte)(255));
            this.transpSelection.ValueChanged += new MW5.Plugins.Symbology.Controls.TransparencyControl.ValueChangedDeleg(this.transpSelection_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Color";
            // 
            // clpSelection
            // 
            this.clpSelection.Color = System.Drawing.Color.White;
            this.clpSelection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpSelection.DropDownHeight = 1;
            this.clpSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpSelection.FormattingEnabled = true;
            this.clpSelection.IntegralHeight = false;
            this.clpSelection.Items.AddRange(new object[] {
            "Color"});
            this.clpSelection.Location = new System.Drawing.Point(23, 25);
            this.clpSelection.Name = "clpSelection";
            this.clpSelection.Size = new System.Drawing.Size(63, 21);
            this.clpSelection.TabIndex = 167;
            this.clpSelection.SelectedColorChanged += new System.EventHandler(this.clpSelection_SelectedColorChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Location = new System.Drawing.Point(15, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(238, 265);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 246);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnDrawingOptions_Click);
            // 
            // btnDefaultChange
            // 
            this.btnDefaultChange.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDefaultChange.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDefaultChange.Location = new System.Drawing.Point(156, 285);
            this.btnDefaultChange.Name = "btnDefaultChange";
            this.btnDefaultChange.Size = new System.Drawing.Size(94, 24);
            this.btnDefaultChange.TabIndex = 0;
            this.btnDefaultChange.Text = "More options...";
            this.btnDefaultChange.UseVisualStyleBackColor = true;
            this.btnDefaultChange.Click += new System.EventHandler(this.btnDrawingOptions_Click);
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.groupBox12);
            this.tabCategories.Controls.Add(this.groupBox11);
            this.tabCategories.Controls.Add(this.groupBox6);
            this.tabCategories.Controls.Add(this.btnCategoryClear);
            this.tabCategories.Controls.Add(this.groupVariableSize);
            this.tabCategories.Controls.Add(this.groupBox9);
            this.tabCategories.Controls.Add(this.btnCategoryRemove);
            this.tabCategories.Controls.Add(this.btnCategoryAppearance);
            this.tabCategories.Controls.Add(this.btnCategoryGenerate);
            this.tabCategories.Location = new System.Drawing.Point(4, 22);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Size = new System.Drawing.Size(595, 323);
            this.tabCategories.TabIndex = 8;
            this.tabCategories.Text = "Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dgvCategories);
            this.groupBox12.Location = new System.Drawing.Point(146, 92);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(342, 219);
            this.groupBox12.TabIndex = 129;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Categories";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Visible,
            this.cmnStyle,
            this.cmnName,
            this.cmnExpression,
            this.cmnCount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCategories.Location = new System.Drawing.Point(3, 16);
            this.dgvCategories.Name = "dgvCategories";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowHeadersWidth = 15;
            this.dgvCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCategories.ShowCellErrors = false;
            this.dgvCategories.Size = new System.Drawing.Size(336, 200);
            this.dgvCategories.TabIndex = 93;
            this.dgvCategories.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCategories_CellBeginEdit);
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellDoubleClick);
            this.dgvCategories.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellEndEdit);
            this.dgvCategories.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCategories_CellFormatting);
            this.dgvCategories.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCategories_CellPainting);
            this.dgvCategories.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellValueChanged);
            this.dgvCategories.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCategories_CurrentCellDirtyStateChanged);
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Visible = false;
            this.ID.Width = 30;
            // 
            // Visible
            // 
            this.Visible.HeaderText = "";
            this.Visible.Name = "Visible";
            this.Visible.Width = 30;
            // 
            // cmnStyle
            // 
            this.cmnStyle.HeaderText = "Style";
            this.cmnStyle.Name = "cmnStyle";
            this.cmnStyle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmnStyle.Width = 50;
            // 
            // cmnName
            // 
            this.cmnName.HeaderText = "Name";
            this.cmnName.Name = "cmnName";
            this.cmnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmnName.Width = 120;
            // 
            // cmnExpression
            // 
            this.cmnExpression.HeaderText = "Expression";
            this.cmnExpression.Name = "cmnExpression";
            this.cmnExpression.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmnExpression.Visible = false;
            this.cmnExpression.Width = 5;
            // 
            // cmnCount
            // 
            this.cmnCount.HeaderText = "Count";
            this.cmnCount.Name = "cmnCount";
            this.cmnCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmnCount.Width = 40;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lstFields1);
            this.groupBox11.Location = new System.Drawing.Point(12, 9);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(125, 302);
            this.groupBox11.TabIndex = 128;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Fields";
            // 
            // lstFields1
            // 
            this.lstFields1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFields1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFields1.FormattingEnabled = true;
            this.lstFields1.Location = new System.Drawing.Point(3, 16);
            this.lstFields1.Name = "lstFields1";
            this.lstFields1.Size = new System.Drawing.Size(119, 283);
            this.lstFields1.TabIndex = 124;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkRandomColors);
            this.groupBox6.Controls.Add(this.chkSetGradient);
            this.groupBox6.Controls.Add(this.icbCategories);
            this.groupBox6.Controls.Add(this.btnChangeColorScheme);
            this.groupBox6.Location = new System.Drawing.Point(294, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(194, 82);
            this.groupBox6.TabIndex = 127;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Color scheme";
            // 
            // chkRandomColors
            // 
            this.chkRandomColors.AutoSize = true;
            this.chkRandomColors.Location = new System.Drawing.Point(91, 54);
            this.chkRandomColors.Name = "chkRandomColors";
            this.chkRandomColors.Size = new System.Drawing.Size(97, 17);
            this.chkRandomColors.TabIndex = 108;
            this.chkRandomColors.Text = "Random colors";
            this.chkRandomColors.UseVisualStyleBackColor = true;
            this.chkRandomColors.Click += new System.EventHandler(this.chkRandomColors_CheckedChanged);
            // 
            // chkSetGradient
            // 
            this.chkSetGradient.Checked = true;
            this.chkSetGradient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetGradient.Location = new System.Drawing.Point(17, 52);
            this.chkSetGradient.Name = "chkSetGradient";
            this.chkSetGradient.Size = new System.Drawing.Size(68, 20);
            this.chkSetGradient.TabIndex = 116;
            this.chkSetGradient.Text = "Gradient";
            this.chkSetGradient.UseVisualStyleBackColor = true;
            // 
            // icbCategories
            // 
            this.icbCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbCategories.FormattingEnabled = true;
            this.icbCategories.Location = new System.Drawing.Point(17, 25);
            this.icbCategories.Name = "icbCategories";
            this.icbCategories.OutlineColor = System.Drawing.Color.Black;
            this.icbCategories.Size = new System.Drawing.Size(137, 21);
            this.icbCategories.TabIndex = 106;
            // 
            // btnChangeColorScheme
            // 
            this.btnChangeColorScheme.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnChangeColorScheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChangeColorScheme.Location = new System.Drawing.Point(160, 25);
            this.btnChangeColorScheme.Name = "btnChangeColorScheme";
            this.btnChangeColorScheme.Size = new System.Drawing.Size(28, 21);
            this.btnChangeColorScheme.TabIndex = 107;
            this.btnChangeColorScheme.Text = "...";
            this.btnChangeColorScheme.UseVisualStyleBackColor = true;
            this.btnChangeColorScheme.Click += new System.EventHandler(this.btnChangeColorScheme_Click);
            // 
            // btnCategoryClear
            // 
            this.btnCategoryClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryClear.Location = new System.Drawing.Point(491, 112);
            this.btnCategoryClear.Name = "btnCategoryClear";
            this.btnCategoryClear.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryClear.TabIndex = 93;
            this.btnCategoryClear.Text = "Clear";
            this.btnCategoryClear.UseVisualStyleBackColor = true;
            this.btnCategoryClear.Click += new System.EventHandler(this.btnCategoryClear_Click);
            // 
            // groupVariableSize
            // 
            this.groupVariableSize.Controls.Add(this.udMaxSize);
            this.groupVariableSize.Controls.Add(this.udMinSize);
            this.groupVariableSize.Controls.Add(this.label5);
            this.groupVariableSize.Controls.Add(this.chkUseVariableSize);
            this.groupVariableSize.Location = new System.Drawing.Point(497, 172);
            this.groupVariableSize.Name = "groupVariableSize";
            this.groupVariableSize.Size = new System.Drawing.Size(93, 139);
            this.groupVariableSize.TabIndex = 125;
            this.groupVariableSize.TabStop = false;
            this.groupVariableSize.Text = "Variable size";
            this.groupVariableSize.Visible = false;
            // 
            // udMaxSize
            // 
            this.udMaxSize.Location = new System.Drawing.Point(30, 95);
            this.udMaxSize.Name = "udMaxSize";
            this.udMaxSize.Size = new System.Drawing.Size(45, 20);
            this.udMaxSize.TabIndex = 118;
            // 
            // udMinSize
            // 
            this.udMinSize.Location = new System.Drawing.Point(30, 69);
            this.udMinSize.Name = "udMinSize";
            this.udMinSize.Size = new System.Drawing.Size(45, 20);
            this.udMinSize.TabIndex = 117;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Size:";
            // 
            // chkUseVariableSize
            // 
            this.chkUseVariableSize.AutoSize = true;
            this.chkUseVariableSize.Location = new System.Drawing.Point(16, 28);
            this.chkUseVariableSize.Name = "chkUseVariableSize";
            this.chkUseVariableSize.Size = new System.Drawing.Size(59, 17);
            this.chkUseVariableSize.TabIndex = 115;
            this.chkUseVariableSize.Text = "Enable";
            this.chkUseVariableSize.UseVisualStyleBackColor = true;
            this.chkUseVariableSize.CheckedChanged += new System.EventHandler(this.RefreshControlsState);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.udNumCategories);
            this.groupBox9.Controls.Add(this.chkUniqueValues);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Location = new System.Drawing.Point(146, 9);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(142, 82);
            this.groupBox9.TabIndex = 123;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Classification";
            // 
            // udNumCategories
            // 
            this.udNumCategories.Location = new System.Drawing.Point(76, 25);
            this.udNumCategories.Name = "udNumCategories";
            this.udNumCategories.Size = new System.Drawing.Size(55, 20);
            this.udNumCategories.TabIndex = 156;
            // 
            // chkUniqueValues
            // 
            this.chkUniqueValues.AutoSize = true;
            this.chkUniqueValues.Location = new System.Drawing.Point(15, 54);
            this.chkUniqueValues.Name = "chkUniqueValues";
            this.chkUniqueValues.Size = new System.Drawing.Size(94, 17);
            this.chkUniqueValues.TabIndex = 123;
            this.chkUniqueValues.Text = "Unique values";
            this.chkUniqueValues.UseVisualStyleBackColor = true;
            this.chkUniqueValues.CheckedChanged += new System.EventHandler(this.chkUniqueValues_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 101;
            this.label19.Text = "Categories";
            // 
            // btnCategoryRemove
            // 
            this.btnCategoryRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryRemove.Location = new System.Drawing.Point(491, 80);
            this.btnCategoryRemove.Name = "btnCategoryRemove";
            this.btnCategoryRemove.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryRemove.TabIndex = 95;
            this.btnCategoryRemove.Text = "Remove";
            this.btnCategoryRemove.UseVisualStyleBackColor = true;
            this.btnCategoryRemove.Click += new System.EventHandler(this.btnCategoryRemove_Click);
            // 
            // btnCategoryAppearance
            // 
            this.btnCategoryAppearance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryAppearance.Location = new System.Drawing.Point(491, 48);
            this.btnCategoryAppearance.Name = "btnCategoryAppearance";
            this.btnCategoryAppearance.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryAppearance.TabIndex = 91;
            this.btnCategoryAppearance.Text = "Appearance...";
            this.btnCategoryAppearance.UseVisualStyleBackColor = true;
            this.btnCategoryAppearance.Click += new System.EventHandler(this.btnCategoryAppearance_Click);
            // 
            // btnCategoryGenerate
            // 
            this.btnCategoryGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryGenerate.Location = new System.Drawing.Point(491, 16);
            this.btnCategoryGenerate.Name = "btnCategoryGenerate";
            this.btnCategoryGenerate.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryGenerate.TabIndex = 90;
            this.btnCategoryGenerate.Text = "Generate";
            this.btnCategoryGenerate.UseVisualStyleBackColor = true;
            this.btnCategoryGenerate.Click += new System.EventHandler(this.btnCategoryGenerate_Click);
            // 
            // tabLabels
            // 
            this.tabLabels.Controls.Add(this.btnLabelsClear);
            this.tabLabels.Controls.Add(this.groupLabelAppearance);
            this.tabLabels.Controls.Add(this.groupLabelStyle);
            this.tabLabels.Controls.Add(this.btnLabelsAppearance);
            this.tabLabels.Location = new System.Drawing.Point(4, 22);
            this.tabLabels.Name = "tabLabels";
            this.tabLabels.Size = new System.Drawing.Size(595, 323);
            this.tabLabels.TabIndex = 5;
            this.tabLabels.Text = "Labels";
            this.tabLabels.UseVisualStyleBackColor = true;
            // 
            // btnLabelsClear
            // 
            this.btnLabelsClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLabelsClear.Location = new System.Drawing.Point(259, 62);
            this.btnLabelsClear.Name = "btnLabelsClear";
            this.btnLabelsClear.Size = new System.Drawing.Size(93, 26);
            this.btnLabelsClear.TabIndex = 170;
            this.btnLabelsClear.Text = "Clear";
            this.btnLabelsClear.UseVisualStyleBackColor = true;
            this.btnLabelsClear.Click += new System.EventHandler(this.btnLabelsClear_Click);
            // 
            // groupLabelAppearance
            // 
            this.groupLabelAppearance.Controls.Add(this.panelLabels);
            this.groupLabelAppearance.Location = new System.Drawing.Point(18, 148);
            this.groupLabelAppearance.Name = "groupLabelAppearance";
            this.groupLabelAppearance.Size = new System.Drawing.Size(233, 128);
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
            this.panelLabels.Size = new System.Drawing.Size(227, 109);
            this.panelLabels.TabIndex = 161;
            // 
            // udLabelFontSize
            // 
            this.udLabelFontSize.Location = new System.Drawing.Point(19, 66);
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
            this.udLabelFontSize.ValueChanged += new System.EventHandler(this.udLabelFontSize_ValueChanged);
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
            this.clpLabelFrame.Location = new System.Drawing.Point(128, 65);
            this.clpLabelFrame.Name = "clpLabelFrame";
            this.clpLabelFrame.Size = new System.Drawing.Size(53, 21);
            this.clpLabelFrame.TabIndex = 157;
            this.clpLabelFrame.SelectedColorChanged += new System.EventHandler(this.clpLabelFrame_SelectedColorChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(76, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 159;
            this.label15.Text = "Size";
            // 
            // chkShowLabels
            // 
            this.chkShowLabels.AutoSize = true;
            this.chkShowLabels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkShowLabels.Location = new System.Drawing.Point(19, 25);
            this.chkShowLabels.Name = "chkShowLabels";
            this.chkShowLabels.Size = new System.Drawing.Size(89, 17);
            this.chkShowLabels.TabIndex = 137;
            this.chkShowLabels.Text = "Labels visible";
            this.chkShowLabels.UseVisualStyleBackColor = true;
            this.chkShowLabels.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // chkLabelFrame
            // 
            this.chkLabelFrame.AutoSize = true;
            this.chkLabelFrame.Location = new System.Drawing.Point(128, 25);
            this.chkLabelFrame.Name = "chkLabelFrame";
            this.chkLabelFrame.Size = new System.Drawing.Size(87, 17);
            this.chkLabelFrame.TabIndex = 155;
            this.chkLabelFrame.Text = "Frame visible";
            this.chkLabelFrame.UseVisualStyleBackColor = true;
            this.chkLabelFrame.CheckedChanged += new System.EventHandler(this.chkLabelFrame_CheckedChanged);
            // 
            // groupLabelStyle
            // 
            this.groupLabelStyle.Controls.Add(this.pctLabelPreview);
            this.groupLabelStyle.Location = new System.Drawing.Point(15, 14);
            this.groupLabelStyle.Name = "groupLabelStyle";
            this.groupLabelStyle.Size = new System.Drawing.Size(235, 128);
            this.groupLabelStyle.TabIndex = 130;
            this.groupLabelStyle.TabStop = false;
            this.groupLabelStyle.Text = "Labels preview";
            // 
            // pctLabelPreview
            // 
            this.pctLabelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctLabelPreview.Location = new System.Drawing.Point(3, 16);
            this.pctLabelPreview.Name = "pctLabelPreview";
            this.pctLabelPreview.Size = new System.Drawing.Size(229, 109);
            this.pctLabelPreview.TabIndex = 0;
            this.pctLabelPreview.TabStop = false;
            this.pctLabelPreview.Click += new System.EventHandler(this.btnLabelsAppearance_Click);
            // 
            // btnLabelsAppearance
            // 
            this.btnLabelsAppearance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLabelsAppearance.Location = new System.Drawing.Point(259, 30);
            this.btnLabelsAppearance.Name = "btnLabelsAppearance";
            this.btnLabelsAppearance.Size = new System.Drawing.Size(93, 26);
            this.btnLabelsAppearance.TabIndex = 125;
            this.btnLabelsAppearance.Text = "Setup...";
            this.btnLabelsAppearance.UseVisualStyleBackColor = true;
            this.btnLabelsAppearance.Click += new System.EventHandler(this.btnLabelsAppearance_Click);
            // 
            // tabCharts
            // 
            this.tabCharts.Controls.Add(this.btnChartAppearance);
            this.tabCharts.Controls.Add(this.btnClearCharts);
            this.tabCharts.Controls.Add(this.groupChartAppearance);
            this.tabCharts.Controls.Add(this.groupCharts);
            this.tabCharts.Location = new System.Drawing.Point(4, 22);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.Size = new System.Drawing.Size(595, 323);
            this.tabCharts.TabIndex = 14;
            this.tabCharts.Text = "Charts";
            this.tabCharts.UseVisualStyleBackColor = true;
            // 
            // btnChartAppearance
            // 
            this.btnChartAppearance.Location = new System.Drawing.Point(265, 30);
            this.btnChartAppearance.Name = "btnChartAppearance";
            this.btnChartAppearance.Size = new System.Drawing.Size(93, 26);
            this.btnChartAppearance.TabIndex = 173;
            this.btnChartAppearance.Text = "Setup...";
            this.btnChartAppearance.UseVisualStyleBackColor = true;
            this.btnChartAppearance.Click += new System.EventHandler(this.btnChartAppearance_Click);
            // 
            // btnClearCharts
            // 
            this.btnClearCharts.Location = new System.Drawing.Point(265, 62);
            this.btnClearCharts.Name = "btnClearCharts";
            this.btnClearCharts.Size = new System.Drawing.Size(93, 26);
            this.btnClearCharts.TabIndex = 172;
            this.btnClearCharts.Text = "Clear";
            this.btnClearCharts.UseVisualStyleBackColor = true;
            this.btnClearCharts.Click += new System.EventHandler(this.btnClearCharts_Click);
            // 
            // groupChartAppearance
            // 
            this.groupChartAppearance.Controls.Add(this.btnChartsEditColorScheme);
            this.groupChartAppearance.Controls.Add(this.chkChartsVisible);
            this.groupChartAppearance.Controls.Add(this.label7);
            this.groupChartAppearance.Controls.Add(this.optChartsPie);
            this.groupChartAppearance.Controls.Add(this.icbChartColorScheme);
            this.groupChartAppearance.Controls.Add(this.optChartBars);
            this.groupChartAppearance.Location = new System.Drawing.Point(15, 149);
            this.groupChartAppearance.Name = "groupChartAppearance";
            this.groupChartAppearance.Size = new System.Drawing.Size(232, 129);
            this.groupChartAppearance.TabIndex = 171;
            this.groupChartAppearance.TabStop = false;
            this.groupChartAppearance.Text = "Appearance";
            // 
            // btnChartsEditColorScheme
            // 
            this.btnChartsEditColorScheme.Location = new System.Drawing.Point(137, 83);
            this.btnChartsEditColorScheme.Name = "btnChartsEditColorScheme";
            this.btnChartsEditColorScheme.Size = new System.Drawing.Size(29, 22);
            this.btnChartsEditColorScheme.TabIndex = 164;
            this.btnChartsEditColorScheme.Text = "...";
            this.btnChartsEditColorScheme.UseVisualStyleBackColor = true;
            this.btnChartsEditColorScheme.Click += new System.EventHandler(this.btnChartsEditColorScheme_Click);
            // 
            // chkChartsVisible
            // 
            this.chkChartsVisible.Location = new System.Drawing.Point(17, 33);
            this.chkChartsVisible.Name = "chkChartsVisible";
            this.chkChartsVisible.Size = new System.Drawing.Size(95, 19);
            this.chkChartsVisible.TabIndex = 127;
            this.chkChartsVisible.Text = "Charts visible";
            this.chkChartsVisible.UseVisualStyleBackColor = true;
            this.chkChartsVisible.CheckedChanged += new System.EventHandler(this.Ui2Settings);
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
            this.optChartsPie.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // icbChartColorScheme
            // 
            this.icbChartColorScheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbChartColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbChartColorScheme.FormattingEnabled = true;
            this.icbChartColorScheme.ItemHeight = 16;
            this.icbChartColorScheme.Location = new System.Drawing.Point(17, 83);
            this.icbChartColorScheme.Name = "icbChartColorScheme";
            this.icbChartColorScheme.OutlineColor = System.Drawing.Color.Black;
            this.icbChartColorScheme.Size = new System.Drawing.Size(114, 22);
            this.icbChartColorScheme.TabIndex = 22;
            this.icbChartColorScheme.SelectedIndexChanged += new System.EventHandler(this.icbChartColorScheme_SelectedIndexChanged);
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
            this.optChartBars.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // groupCharts
            // 
            this.groupCharts.Controls.Add(this.pctCharts);
            this.groupCharts.Location = new System.Drawing.Point(15, 14);
            this.groupCharts.Name = "groupCharts";
            this.groupCharts.Size = new System.Drawing.Size(235, 129);
            this.groupCharts.TabIndex = 170;
            this.groupCharts.TabStop = false;
            this.groupCharts.Text = "Charts preview";
            // 
            // pctCharts
            // 
            this.pctCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctCharts.Location = new System.Drawing.Point(3, 16);
            this.pctCharts.Name = "pctCharts";
            this.pctCharts.Size = new System.Drawing.Size(229, 110);
            this.pctCharts.TabIndex = 0;
            this.pctCharts.TabStop = false;
            this.pctCharts.Click += new System.EventHandler(this.btnChartAppearance_Click);
            // 
            // tabVisibility
            // 
            this.tabVisibility.Controls.Add(this.groupBox1);
            this.tabVisibility.Controls.Add(this.groupBox13);
            this.tabVisibility.Location = new System.Drawing.Point(4, 22);
            this.tabVisibility.Name = "tabVisibility";
            this.tabVisibility.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisibility.Size = new System.Drawing.Size(595, 323);
            this.tabVisibility.TabIndex = 11;
            this.tabVisibility.Text = "Visibility";
            this.tabVisibility.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scaleLayer);
            this.groupBox1.Location = new System.Drawing.Point(17, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 301);
            this.groupBox1.TabIndex = 169;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dynamic visibility";
            // 
            // scaleLayer
            // 
            this.scaleLayer.BackColor = System.Drawing.Color.Transparent;
            this.scaleLayer.CurrentScale = -1D;
            this.scaleLayer.FillColor = System.Drawing.Color.LightGreen;
            this.scaleLayer.FillColor2 = System.Drawing.Color.LightGreen;
            this.scaleLayer.Location = new System.Drawing.Point(8, 19);
            this.scaleLayer.MaximumScale = 1000000000D;
            this.scaleLayer.MaximumSize = new System.Drawing.Size(300, 1000);
            this.scaleLayer.MinimimScale = 1.0000004910124416D;
            this.scaleLayer.MinimumSize = new System.Drawing.Size(80, 200);
            this.scaleLayer.Name = "scaleLayer";
            this.scaleLayer.OutlineColor = System.Drawing.Color.DarkGray;
            this.scaleLayer.SelectionColor = System.Drawing.SystemColors.ControlDarkDark;
            this.scaleLayer.Size = new System.Drawing.Size(245, 276);
            this.scaleLayer.TabIndex = 162;
            this.scaleLayer.UseDynamicVisibility = false;
            this.scaleLayer.StateChanged += new MW5.Plugins.Symbology.Controls.StateChanged(this.scaleLayer_StateChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnClearLayerExpression);
            this.groupBox13.Controls.Add(this.btnLayerExpression);
            this.groupBox13.Controls.Add(this.txtLayerExpression);
            this.groupBox13.Location = new System.Drawing.Point(301, 10);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(282, 301);
            this.groupBox13.TabIndex = 168;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Visibility expression";
            // 
            // btnClearLayerExpression
            // 
            this.btnClearLayerExpression.Location = new System.Drawing.Point(195, 257);
            this.btnClearLayerExpression.Name = "btnClearLayerExpression";
            this.btnClearLayerExpression.Size = new System.Drawing.Size(74, 26);
            this.btnClearLayerExpression.TabIndex = 168;
            this.btnClearLayerExpression.Text = "Clear";
            this.btnClearLayerExpression.UseVisualStyleBackColor = true;
            this.btnClearLayerExpression.Click += new System.EventHandler(this.btnClearLayerExpression_Click);
            // 
            // btnLayerExpression
            // 
            this.btnLayerExpression.Location = new System.Drawing.Point(114, 257);
            this.btnLayerExpression.Name = "btnLayerExpression";
            this.btnLayerExpression.Size = new System.Drawing.Size(75, 26);
            this.btnLayerExpression.TabIndex = 163;
            this.btnLayerExpression.Text = "Change...";
            this.btnLayerExpression.UseVisualStyleBackColor = true;
            this.btnLayerExpression.Click += new System.EventHandler(this.btnLayerExpression_Click);
            // 
            // txtLayerExpression
            // 
            this.txtLayerExpression.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLayerExpression.Location = new System.Drawing.Point(10, 19);
            this.txtLayerExpression.Multiline = true;
            this.txtLayerExpression.Name = "txtLayerExpression";
            this.txtLayerExpression.Size = new System.Drawing.Size(259, 232);
            this.txtLayerExpression.TabIndex = 162;
            this.toolTip1.SetToolTip(this.txtLayerExpression, "Only shapes which agree with the following expression will be visible");
            this.txtLayerExpression.TextChanged += new System.EventHandler(this.txtLayerExpression_TextChanged);
            // 
            // tabMode
            // 
            this.tabMode.Controls.Add(this.groupBox21);
            this.tabMode.Controls.Add(this.progressBar1);
            this.tabMode.Controls.Add(this.groupBox19);
            this.tabMode.Controls.Add(this.groupModeDescription);
            this.tabMode.Controls.Add(this.groupBox2);
            this.tabMode.Location = new System.Drawing.Point(4, 22);
            this.tabMode.Name = "tabMode";
            this.tabMode.Size = new System.Drawing.Size(595, 323);
            this.tabMode.TabIndex = 13;
            this.tabMode.Text = "Mode";
            this.tabMode.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.cboCollisionMode);
            this.groupBox21.Location = new System.Drawing.Point(244, 115);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(227, 72);
            this.groupBox21.TabIndex = 182;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Collision mode";
            // 
            // cboCollisionMode
            // 
            this.cboCollisionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCollisionMode.FormattingEnabled = true;
            this.cboCollisionMode.Location = new System.Drawing.Point(23, 28);
            this.cboCollisionMode.Name = "cboCollisionMode";
            this.cboCollisionMode.Size = new System.Drawing.Size(185, 21);
            this.cboCollisionMode.TabIndex = 184;
            this.cboCollisionMode.SelectedIndexChanged += new System.EventHandler(this.Ui2Settings);
            this.cboCollisionMode.MouseEnter += new System.EventHandler(this.chkFastMode_Enter);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 290);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(456, 20);
            this.progressBar1.TabIndex = 181;
            this.progressBar1.Visible = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label12);
            this.groupBox19.Controls.Add(this.udMinDrawingSize);
            this.groupBox19.Controls.Add(this.udMinLabelingSize);
            this.groupBox19.Controls.Add(this.label6);
            this.groupBox19.Location = new System.Drawing.Point(244, 14);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(227, 95);
            this.groupBox19.TabIndex = 180;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Minimal shape size, pixels";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 177;
            this.label12.Text = "To label:";
            // 
            // udMinDrawingSize
            // 
            this.udMinDrawingSize.Location = new System.Drawing.Point(109, 29);
            this.udMinDrawingSize.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udMinDrawingSize.Name = "udMinDrawingSize";
            this.udMinDrawingSize.Size = new System.Drawing.Size(53, 20);
            this.udMinDrawingSize.TabIndex = 176;
            this.udMinDrawingSize.ValueChanged += new System.EventHandler(this.udMinDrawingSize_ValueChanged);
            this.udMinDrawingSize.Enter += new System.EventHandler(this.chkFastMode_Enter);
            // 
            // udMinLabelingSize
            // 
            this.udMinLabelingSize.Location = new System.Drawing.Point(109, 63);
            this.udMinLabelingSize.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udMinLabelingSize.Name = "udMinLabelingSize";
            this.udMinLabelingSize.Size = new System.Drawing.Size(53, 20);
            this.udMinLabelingSize.TabIndex = 178;
            this.udMinLabelingSize.ValueChanged += new System.EventHandler(this.udMinLabelingSize_ValueChanged);
            this.udMinLabelingSize.Enter += new System.EventHandler(this.chkFastMode_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 175;
            this.label6.Text = "To draw:";
            // 
            // groupModeDescription
            // 
            this.groupModeDescription.Controls.Add(this.txtModeDescription);
            this.groupModeDescription.Location = new System.Drawing.Point(15, 193);
            this.groupModeDescription.Name = "groupModeDescription";
            this.groupModeDescription.Size = new System.Drawing.Size(456, 91);
            this.groupModeDescription.TabIndex = 169;
            this.groupModeDescription.TabStop = false;
            // 
            // txtModeDescription
            // 
            this.txtModeDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtModeDescription.Location = new System.Drawing.Point(6, 14);
            this.txtModeDescription.Name = "txtModeDescription";
            this.txtModeDescription.Size = new System.Drawing.Size(444, 71);
            this.txtModeDescription.TabIndex = 0;
            this.txtModeDescription.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEditMode);
            this.groupBox2.Controls.Add(this.chkInMemory);
            this.groupBox2.Controls.Add(this.chkSpatialIndex);
            this.groupBox2.Controls.Add(this.chkFastMode);
            this.groupBox2.Location = new System.Drawing.Point(15, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 173);
            this.groupBox2.TabIndex = 167;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // chkEditMode
            // 
            this.chkEditMode.AutoSize = true;
            this.chkEditMode.Enabled = false;
            this.chkEditMode.Location = new System.Drawing.Point(25, 98);
            this.chkEditMode.Name = "chkEditMode";
            this.chkEditMode.Size = new System.Drawing.Size(87, 17);
            this.chkEditMode.TabIndex = 44;
            this.chkEditMode.Text = "Editing mode";
            this.chkEditMode.UseVisualStyleBackColor = true;
            this.chkEditMode.CheckedChanged += new System.EventHandler(this.chkEditMode_CheckedChanged);
            this.chkEditMode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkFastMode_MouseMove);
            // 
            // chkInMemory
            // 
            this.chkInMemory.AutoSize = true;
            this.chkInMemory.Enabled = false;
            this.chkInMemory.Location = new System.Drawing.Point(25, 65);
            this.chkInMemory.Name = "chkInMemory";
            this.chkInMemory.Size = new System.Drawing.Size(107, 17);
            this.chkInMemory.TabIndex = 43;
            this.chkInMemory.Text = "Stored in memory";
            this.chkInMemory.UseVisualStyleBackColor = true;
            this.chkInMemory.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkFastMode_MouseMove);
            // 
            // chkSpatialIndex
            // 
            this.chkSpatialIndex.AutoSize = true;
            this.chkSpatialIndex.Location = new System.Drawing.Point(25, 131);
            this.chkSpatialIndex.Name = "chkSpatialIndex";
            this.chkSpatialIndex.Size = new System.Drawing.Size(86, 17);
            this.chkSpatialIndex.TabIndex = 42;
            this.chkSpatialIndex.Text = "Spatial index";
            this.chkSpatialIndex.UseVisualStyleBackColor = true;
            this.chkSpatialIndex.CheckedChanged += new System.EventHandler(this.chkSpatialIndex_CheckedChanged);
            this.chkSpatialIndex.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkFastMode_MouseMove);
            // 
            // chkFastMode
            // 
            this.chkFastMode.AutoSize = true;
            this.chkFastMode.Location = new System.Drawing.Point(25, 32);
            this.chkFastMode.Name = "chkFastMode";
            this.chkFastMode.Size = new System.Drawing.Size(115, 17);
            this.chkFastMode.TabIndex = 39;
            this.chkFastMode.Text = "Fast drawing mode";
            this.chkFastMode.UseVisualStyleBackColor = true;
            this.chkFastMode.CheckedChanged += new System.EventHandler(this.chkFastEditingMode_CheckedChanged);
            this.chkFastMode.Enter += new System.EventHandler(this.chkFastMode_Enter);
            this.chkFastMode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkFastMode_MouseMove);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtComments);
            this.groupBox7.Location = new System.Drawing.Point(638, 67);
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
            this.txtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComments_KeyPress);
            this.txtComments.Validated += new System.EventHandler(this.txtComments_Validated);
            // 
            // chkRedrawMap
            // 
            this.chkRedrawMap.AutoSize = true;
            this.chkRedrawMap.Location = new System.Drawing.Point(16, 361);
            this.chkRedrawMap.Name = "chkRedrawMap";
            this.chkRedrawMap.Size = new System.Drawing.Size(123, 17);
            this.chkRedrawMap.TabIndex = 133;
            this.chkRedrawMap.Text = "Update map at once";
            this.chkRedrawMap.UseVisualStyleBackColor = true;
            this.chkRedrawMap.Visible = false;
            this.chkRedrawMap.CheckedChanged += new System.EventHandler(this.chkRedrawMap_CheckedChanged);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(318, 355);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(93, 26);
            this.btnSaveChanges.TabIndex = 134;
            this.btnSaveChanges.Text = "Apply";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
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
            // LayerStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(616, 385);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.chkRedrawMap);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerStyleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Layer properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSymbologyMain_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.tabDefault.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupLine.ResumeLayout(false);
            this.groupLine.PerformLayout();
            this.panelLineOptions.ResumeLayout(false);
            this.panelLineOptions.PerformLayout();
            this.groupPoint.ResumeLayout(false);
            this.groupPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDefaultSize)).EndInit();
            this.groupFill.ResumeLayout(false);
            this.groupFill.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabCategories.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupVariableSize.ResumeLayout(false);
            this.groupVariableSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinSize)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udNumCategories)).EndInit();
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
            this.tabVisibility.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabMode.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMinDrawingSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinLabelingSize)).EndInit();
            this.groupModeDescription.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLabels;
        private System.Windows.Forms.TabPage tabDefault;
        private System.Windows.Forms.Button btnDefaultChange;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.Button btnCategoryRemove;
        private System.Windows.Forms.Button btnCategoryClear;
        private System.Windows.Forms.Button btnCategoryAppearance;
        private System.Windows.Forms.Button btnCategoryGenerate;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtLayerName;
        private System.Windows.Forms.GroupBox groupLabelStyle;
        private System.Windows.Forms.PictureBox pctLabelPreview;
        private System.Windows.Forms.Button btnLabelsAppearance;
        private System.Windows.Forms.CheckBox chkShowLabels;
        private Office2007ColorPicker clpLabelFrame;
        private System.Windows.Forms.CheckBox chkLabelFrame;
        private System.Windows.Forms.Label label15;
        private ColorSchemeCombo icbCategories;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnChangeColorScheme;
        private System.Windows.Forms.CheckBox chkRandomColors;
        private System.Windows.Forms.CheckBox chkSetGradient;
        private System.Windows.Forms.CheckBox chkUseVariableSize;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox chkUniqueValues;
        private System.Windows.Forms.ListBox lstFields1;
        private System.Windows.Forms.GroupBox groupVariableSize;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label5;
        private NumericUpDownEx udMinSize;
        private NumericUpDownEx udMaxSize;
        private NumericUpDownEx udNumCategories;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkLayerVisible;
        private System.Windows.Forms.CheckBox chkLayerPreview;
        private System.Windows.Forms.GroupBox groupBox10;
        private MapControl axMap1;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Visible;
        private System.Windows.Forms.DataGridViewImageColumn cmnStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnExpression;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCount;
        private System.Windows.Forms.Panel panelLabels;
        private NumericUpDownEx udLabelFontSize;
        private System.Windows.Forms.TabPage tabVisibility;
        private System.Windows.Forms.TextBox txtLayerExpression;
        private System.Windows.Forms.Button btnLayerExpression;
        private ScaleControl scaleControl2;
        private ScaleControl scaleControl1;
        private System.Windows.Forms.Button btnClearLayerExpression;
        private Office2007ColorPicker clpPointFill;
        private System.Windows.Forms.TabPage tabMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkInMemory;
        private System.Windows.Forms.CheckBox chkSpatialIndex;
        private System.Windows.Forms.CheckBox chkFastMode;
        private Office2007ColorPicker clpDefaultOutline;
        private System.Windows.Forms.GroupBox groupModeDescription;
        private Office2007ColorPicker clpSelection;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label label12;
        private NumericUpDownEx udMinDrawingSize;
        private NumericUpDownEx udMinLabelingSize;
        private System.Windows.Forms.Label label6;
        private NumericUpDownEx udDefaultSize;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkRedrawMap;
        private System.Windows.Forms.RichTextBox txtModeDescription;
        private System.Windows.Forms.GroupBox groupLabelAppearance;
        private System.Windows.Forms.ComboBox cboCollisionMode;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupLine;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupFill;
        private ImageCombo icbFillStyle;
        private Office2007ColorPicker clpPolygonFill;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private ImageCombo icbLineWidth;
        private TransparencyControl transpMain;
        private TransparencyControl transpSelection;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMultilinePattern;
        private System.Windows.Forms.Panel panelLineOptions;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.GroupBox groupBox1;
        private ScaleControl scaleLayer;
        private System.Windows.Forms.Button btnLabelsClear;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox txtComments;
        private System.Windows.Forms.RichTextBox txtLayerSource;
        private System.Windows.Forms.TabPage tabCharts;
        private System.Windows.Forms.Button btnChartAppearance;
        private System.Windows.Forms.Button btnClearCharts;
        private System.Windows.Forms.GroupBox groupChartAppearance;
        private System.Windows.Forms.Button btnChartsEditColorScheme;
        private System.Windows.Forms.CheckBox chkChartsVisible;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton optChartsPie;
        private ColorSchemeCombo icbChartColorScheme;
        private System.Windows.Forms.RadioButton optChartBars;
        private System.Windows.Forms.GroupBox groupCharts;
        private System.Windows.Forms.PictureBox pctCharts;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.CheckBox chkEditMode;
    }
}