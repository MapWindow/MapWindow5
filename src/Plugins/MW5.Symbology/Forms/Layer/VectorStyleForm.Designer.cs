using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Map;
using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ColorPicker;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Forms.Layer
{
    partial class VectorStyleForm
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
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvStyleInfo treeNodeAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvStyleInfo();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvSubItemStyleInfo treeNodeAdvSubItemStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeNodeAdvSubItemStyleInfo();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdvStyleInfo treeColumnAdvStyleInfo1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdvStyleInfo();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv treeColumnAdv1 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv treeColumnAdv2 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv treeColumnAdv3 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv treeColumnAdv4 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv treeColumnAdv5 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv();
            Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv treeColumnAdv6 = new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.TreeColumnAdv();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VectorStyleForm));
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabControl1 = new MW5.UI.Controls.TabPropertiesControl();
            this.tabGeneral = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.dynamicVisibilityControl1 = new MW5.Plugins.Symbology.Controls.DynamicVisibilityControl();
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
            this.tabInfo = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.vectorInfoTreeView1 = new MW5.Plugins.Symbology.Controls.VectorInfoTreeView();
            this.tabDefault = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.transpMain = new MW5.Plugins.Symbology.Controls.TransparencyControl();
            this.groupPoint = new System.Windows.Forms.GroupBox();
            this.udDefaultSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clpPointFill = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
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
            this.btnDefaultChange = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupLine = new System.Windows.Forms.GroupBox();
            this.icbLineWidth = new MW5.Plugins.Symbology.Controls.ImageCombo.ImageCombo();
            this.label16 = new System.Windows.Forms.Label();
            this.panelLineOptions = new System.Windows.Forms.Panel();
            this.lblMultilinePattern = new System.Windows.Forms.Label();
            this.clpDefaultOutline = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.tabCategories = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dgvCategories = new MW5.Plugins.Symbology.Controls.CategoriesGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.btnChangeColorScheme = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCategoryClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupVariableSize = new System.Windows.Forms.GroupBox();
            this.udMaxSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udMinSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.chkUseVariableSize = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.udNumCategories = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.chkUniqueValues = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCategoryRemove = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCategoryAppearance = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCategoryGenerate = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabFields = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label10 = new System.Windows.Forms.Label();
            this.attributesControl1 = new MW5.Plugins.Symbology.Controls.AttributesControl();
            this.tabLabels = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnLabelsClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupLabelAppearance = new System.Windows.Forms.GroupBox();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.udLabelFontSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.clpLabelFrame = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.chkShowLabels = new System.Windows.Forms.CheckBox();
            this.chkLabelFrame = new System.Windows.Forms.CheckBox();
            this.groupLabelStyle = new System.Windows.Forms.GroupBox();
            this.pctLabelPreview = new System.Windows.Forms.PictureBox();
            this.btnLabelsAppearance = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabCharts = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
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
            this.tabVisibility = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.scaleLayer = new MW5.Plugins.Symbology.Controls.ScaleControl();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnClearLayerExpression = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnLayerExpression = new Syncfusion.Windows.Forms.ButtonAdv();
            this.txtLayerExpression = new System.Windows.Forms.TextBox();
            this.tabMode = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxAdv1 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboMaxScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboMinScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkRedrawMap = new System.Windows.Forms.CheckBox();
            this.btnSaveChanges = new Syncfusion.Windows.Forms.ButtonAdv();
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
            ((System.ComponentModel.ISupportInitialize)(this.vectorInfoTreeView1)).BeginInit();
            this.tabDefault.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDefaultSize)).BeginInit();
            this.groupFill.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupLine.SuspendLayout();
            this.panelLineOptions.SuspendLayout();
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
            this.tabFields.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaxScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMinScale)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(460, 446);
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
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(559, 446);
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
            this.tabControl1.BeforeTouchSize = new System.Drawing.Size(639, 425);
            this.tabControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Controls.Add(this.tabDefault);
            this.tabControl1.Controls.Add(this.tabCategories);
            this.tabControl1.Controls.Add(this.tabFields);
            this.tabControl1.Controls.Add(this.tabLabels);
            this.tabControl1.Controls.Add(this.tabCharts);
            this.tabControl1.Controls.Add(this.tabVisibility);
            this.tabControl1.Controls.Add(this.tabMode);
            this.tabControl1.FocusOnTabClick = false;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.InactiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 50);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(5, 10);
            this.tabControl1.PersistTabState = true;
            this.tabControl1.RotateTextWhenVertical = true;
            this.tabControl1.Size = new System.Drawing.Size(639, 425);
            this.tabControl1.TabGap = 10;
            this.tabControl1.TabIndex = 6;
            this.tabControl1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererBlendLight);
            this.tabControl1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.dynamicVisibilityControl1);
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
            this.tabGeneral.Image = null;
            this.tabGeneral.ImageIndex = 0;
            this.tabGeneral.ImageSize = new System.Drawing.Size(16, 16);
            this.tabGeneral.Location = new System.Drawing.Point(119, 0);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.ShowCloseButton = true;
            this.tabGeneral.Size = new System.Drawing.Size(520, 425);
            this.tabGeneral.TabIndex = 10;
            this.tabGeneral.Text = "General";
            this.tabGeneral.ThemesEnabled = false;
            // 
            // dynamicVisibilityControl1
            // 
            this.dynamicVisibilityControl1.CurrentScale = 0D;
            this.dynamicVisibilityControl1.CurrentZoom = 0;
            this.dynamicVisibilityControl1.Location = new System.Drawing.Point(24, 202);
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
            // txtBriefInfo
            // 
            this.txtBriefInfo.BeforeTouchSize = new System.Drawing.Size(364, 20);
            this.txtBriefInfo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBriefInfo.Location = new System.Drawing.Point(130, 155);
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
            this.label2.Location = new System.Drawing.Point(21, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 169;
            this.label2.Text = "Information";
            // 
            // btnProjectionDetails
            // 
            this.btnProjectionDetails.BeforeTouchSize = new System.Drawing.Size(63, 23);
            this.btnProjectionDetails.IsBackStageButton = false;
            this.btnProjectionDetails.Location = new System.Drawing.Point(431, 111);
            this.btnProjectionDetails.Name = "btnProjectionDetails";
            this.btnProjectionDetails.Size = new System.Drawing.Size(63, 23);
            this.btnProjectionDetails.TabIndex = 168;
            this.btnProjectionDetails.Text = "Details";
            this.btnProjectionDetails.Click += new System.EventHandler(this.btnProjectionDetails_Click);
            // 
            // txtProjection
            // 
            this.txtProjection.BeforeTouchSize = new System.Drawing.Size(364, 20);
            this.txtProjection.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProjection.Location = new System.Drawing.Point(130, 114);
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
            this.label3.Location = new System.Drawing.Point(21, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 166;
            this.label3.Text = "Coordinate system";
            // 
            // txtDatasourceName
            // 
            this.txtDatasourceName.BeforeTouchSize = new System.Drawing.Size(364, 20);
            this.txtDatasourceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDatasourceName.Location = new System.Drawing.Point(130, 73);
            this.txtDatasourceName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtDatasourceName.Name = "txtDatasourceName";
            this.txtDatasourceName.ReadOnly = true;
            this.txtDatasourceName.Size = new System.Drawing.Size(364, 20);
            this.txtDatasourceName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtDatasourceName.TabIndex = 165;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 164;
            this.label8.Text = "Datasource name";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.axMap1);
            this.groupBox10.Controls.Add(this.chkLayerPreview);
            this.groupBox10.Location = new System.Drawing.Point(267, 202);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(238, 210);
            this.groupBox10.TabIndex = 163;
            this.groupBox10.TabStop = false;
            // 
            // axMap1
            // 
            this.axMap1.AllowDrop = true;
            this.axMap1.AnimationOnZooming = MW5.Api.Enums.AutoToggle.Auto;
            this.axMap1.CurrentScale = 146.12306998412413D;
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
            this.axMap1.MapUnits = MW5.Api.Enums.UnitsOfMeasure.Meters;
            this.axMap1.MouseWheelSpeed = 0.5D;
            this.axMap1.Name = "axMap1";
            spatialReference1.Tag = "";
            this.axMap1.Projection = spatialReference1;
            this.axMap1.ResizeBehavior = MW5.Api.Enums.ResizeBehavior.Classic;
            this.axMap1.ReuseTileBuffer = true;
            this.axMap1.ScalebarUnits = MW5.Api.Enums.ScalebarUnits.GoogleStyle;
            this.axMap1.ScalebarVisible = false;
            this.axMap1.ShowCoordinates = MW5.Api.Enums.CoordinatesDisplay.None;
            this.axMap1.ShowRedrawTime = false;
            this.axMap1.ShowVersionNumber = false;
            this.axMap1.Size = new System.Drawing.Size(232, 191);
            this.axMap1.SystemCursor = MW5.Api.Enums.SystemCursor.MapDefault;
            this.axMap1.TabIndex = 0;
            this.axMap1.Tag = "";
            this.axMap1.TileProvider = MW5.Api.Enums.TileProvider.OpenStreetMap;
            this.axMap1.UdCursorHandle = 0;
            this.axMap1.UseSeamlessPan = false;
            this.axMap1.Visible = false;
            this.axMap1.ZoomBehavior = MW5.Api.Enums.ZoomBehavior.UseTileLevels;
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
            this.chkLayerPreview.CheckedChanged += new System.EventHandler(this.chkLayerPreview_CheckedChanged);
            // 
            // chkLayerVisible
            // 
            this.chkLayerVisible.AutoSize = true;
            this.chkLayerVisible.Location = new System.Drawing.Point(431, 37);
            this.chkLayerVisible.Name = "chkLayerVisible";
            this.chkLayerVisible.Size = new System.Drawing.Size(56, 17);
            this.chkLayerVisible.TabIndex = 160;
            this.chkLayerVisible.Text = "Visible";
            this.toolTip1.SetToolTip(this.chkLayerVisible, "Toggles the visibility of the layer");
            this.chkLayerVisible.UseVisualStyleBackColor = true;
            this.chkLayerVisible.CheckedChanged += new System.EventHandler(this.chkLayerVisible_CheckedChanged);
            // 
            // txtLayerName
            // 
            this.txtLayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtLayerName.Location = new System.Drawing.Point(130, 35);
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size(291, 20);
            this.txtLayerName.TabIndex = 39;
            this.txtLayerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLayerName_KeyPress);
            this.txtLayerName.Validated += new System.EventHandler(this.txtLayerName_Validated);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "Layer name";
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.vectorInfoTreeView1);
            this.tabInfo.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_info24;
            this.tabInfo.ImageSize = new System.Drawing.Size(24, 24);
            this.tabInfo.Location = new System.Drawing.Point(119, 0);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.ShowCloseButton = true;
            this.tabInfo.Size = new System.Drawing.Size(520, 425);
            this.tabInfo.TabIndex = 15;
            this.tabInfo.Text = "Info";
            this.tabInfo.ThemesEnabled = false;
            // 
            // vectorInfoTreeView1
            // 
            this.vectorInfoTreeView1.AutoAdjustMultiLineHeight = true;
            this.vectorInfoTreeView1.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard", treeNodeAdvStyleInfo1),
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard - SubItem", treeNodeAdvSubItemStyleInfo1),
            new Syncfusion.Windows.Forms.Tools.MultiColumnTreeView.StyleNamePair("Standard - Column", treeColumnAdvStyleInfo1)});
            this.vectorInfoTreeView1.BeforeTouchSize = new System.Drawing.Size(520, 425);
            this.vectorInfoTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vectorInfoTreeView1.ColumnsHeaderBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Control);
            this.vectorInfoTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vectorInfoTreeView1.FullRowSelect = true;
            this.vectorInfoTreeView1.GutterSpace = 12;
            // 
            // 
            // 
            this.vectorInfoTreeView1.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vectorInfoTreeView1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.vectorInfoTreeView1.HelpTextControl.Name = "m_helpText";
            this.vectorInfoTreeView1.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.vectorInfoTreeView1.HelpTextControl.TabIndex = 0;
            this.vectorInfoTreeView1.HelpTextControl.Text = "help text";
            this.vectorInfoTreeView1.Location = new System.Drawing.Point(0, 0);
            this.vectorInfoTreeView1.Name = "vectorInfoTreeView1";
            this.vectorInfoTreeView1.ShowColumnsHeader = false;
            this.vectorInfoTreeView1.Size = new System.Drawing.Size(520, 425);
            this.vectorInfoTreeView1.TabIndex = 0;
            this.vectorInfoTreeView1.Text = "vectorInfoTreeView1";
            // 
            // 
            // 
            this.vectorInfoTreeView1.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.vectorInfoTreeView1.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vectorInfoTreeView1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.vectorInfoTreeView1.ToolTipControl.Name = "m_toolTip";
            this.vectorInfoTreeView1.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.vectorInfoTreeView1.ToolTipControl.TabIndex = 1;
            this.vectorInfoTreeView1.ToolTipControl.Text = "toolTip";
            // 
            // tabDefault
            // 
            this.tabDefault.Controls.Add(this.groupBox3);
            this.tabDefault.Controls.Add(this.groupPoint);
            this.tabDefault.Controls.Add(this.groupFill);
            this.tabDefault.Controls.Add(this.groupBox16);
            this.tabDefault.Controls.Add(this.groupBox5);
            this.tabDefault.Controls.Add(this.btnDefaultChange);
            this.tabDefault.Controls.Add(this.groupLine);
            this.tabDefault.Image = null;
            this.tabDefault.ImageIndex = 5;
            this.tabDefault.ImageSize = new System.Drawing.Size(16, 16);
            this.tabDefault.Location = new System.Drawing.Point(119, 0);
            this.tabDefault.Name = "tabDefault";
            this.tabDefault.ShowCloseButton = true;
            this.tabDefault.Size = new System.Drawing.Size(520, 425);
            this.tabDefault.TabIndex = 6;
            this.tabDefault.Text = "Appearance";
            this.tabDefault.ThemesEnabled = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.transpMain);
            this.groupBox3.Location = new System.Drawing.Point(265, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 68);
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
            this.transpMain.Size = new System.Drawing.Size(195, 32);
            this.transpMain.TabIndex = 177;
            this.transpMain.Value = ((byte)(255));
            this.transpMain.ValueChanged += new MW5.Plugins.Symbology.Controls.TransparencyControl.ValueChangedDeleg(this.transpMain_ValueChanged);
            // 
            // groupPoint
            // 
            this.groupPoint.Controls.Add(this.udDefaultSize);
            this.groupPoint.Controls.Add(this.label9);
            this.groupPoint.Controls.Add(this.label4);
            this.groupPoint.Controls.Add(this.clpPointFill);
            this.groupPoint.Location = new System.Drawing.Point(19, 321);
            this.groupPoint.Name = "groupPoint";
            this.groupPoint.Size = new System.Drawing.Size(240, 104);
            this.groupPoint.TabIndex = 179;
            this.groupPoint.TabStop = false;
            this.groupPoint.Text = "Point";
            // 
            // udDefaultSize
            // 
            this.udDefaultSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.udDefaultSize.Location = new System.Drawing.Point(23, 69);
            this.udDefaultSize.Name = "udDefaultSize";
            this.udDefaultSize.Size = new System.Drawing.Size(52, 20);
            this.udDefaultSize.TabIndex = 182;
            this.udDefaultSize.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(107, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Point size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 31);
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
            // groupFill
            // 
            this.groupFill.Controls.Add(this.icbFillStyle);
            this.groupFill.Controls.Add(this.clpPolygonFill);
            this.groupFill.Controls.Add(this.label22);
            this.groupFill.Controls.Add(this.label23);
            this.groupFill.Location = new System.Drawing.Point(265, 14);
            this.groupFill.Name = "groupFill";
            this.groupFill.Size = new System.Drawing.Size(240, 107);
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
            this.icbFillStyle.Location = new System.Drawing.Point(23, 71);
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
            this.label22.Location = new System.Drawing.Point(130, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 13);
            this.label22.TabIndex = 106;
            this.label22.Text = "Fill color";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(130, 74);
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
            this.groupBox16.Location = new System.Drawing.Point(265, 201);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(240, 112);
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
            this.transpSelection.Size = new System.Drawing.Size(195, 32);
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
            this.groupBox5.Size = new System.Drawing.Size(238, 299);
            this.groupBox5.TabIndex = 35;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 280);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnDrawingOptions_Click);
            // 
            // btnDefaultChange
            // 
            this.btnDefaultChange.BeforeTouchSize = new System.Drawing.Size(94, 24);
            this.btnDefaultChange.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnDefaultChange.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDefaultChange.IsBackStageButton = false;
            this.btnDefaultChange.Location = new System.Drawing.Point(159, 319);
            this.btnDefaultChange.Name = "btnDefaultChange";
            this.btnDefaultChange.Size = new System.Drawing.Size(94, 24);
            this.btnDefaultChange.TabIndex = 0;
            this.btnDefaultChange.Text = "More options...";
            this.btnDefaultChange.UseVisualStyleBackColor = true;
            this.btnDefaultChange.Click += new System.EventHandler(this.btnDrawingOptions_Click);
            // 
            // groupLine
            // 
            this.groupLine.Controls.Add(this.icbLineWidth);
            this.groupLine.Controls.Add(this.label16);
            this.groupLine.Controls.Add(this.panelLineOptions);
            this.groupLine.Location = new System.Drawing.Point(265, 319);
            this.groupLine.Name = "groupLine";
            this.groupLine.Size = new System.Drawing.Size(240, 107);
            this.groupLine.TabIndex = 178;
            this.groupLine.TabStop = false;
            this.groupLine.Text = "Outline";
            // 
            // icbLineWidth
            // 
            this.icbLineWidth.Color1 = System.Drawing.Color.Gray;
            this.icbLineWidth.Color2 = System.Drawing.Color.Gray;
            this.icbLineWidth.ComboStyle = MW5.Plugins.Symbology.ImageComboStyle.Common;
            this.icbLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineWidth.FormattingEnabled = true;
            this.icbLineWidth.Location = new System.Drawing.Point(26, 75);
            this.icbLineWidth.Name = "icbLineWidth";
            this.icbLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.icbLineWidth.Size = new System.Drawing.Size(72, 21);
            this.icbLineWidth.TabIndex = 4;
            this.icbLineWidth.SelectedIndexChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(118, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Line width";
            // 
            // panelLineOptions
            // 
            this.panelLineOptions.Controls.Add(this.lblMultilinePattern);
            this.panelLineOptions.Controls.Add(this.clpDefaultOutline);
            this.panelLineOptions.Controls.Add(this.label21);
            this.panelLineOptions.Location = new System.Drawing.Point(19, 24);
            this.panelLineOptions.Name = "panelLineOptions";
            this.panelLineOptions.Size = new System.Drawing.Size(215, 34);
            this.panelLineOptions.TabIndex = 177;
            // 
            // lblMultilinePattern
            // 
            this.lblMultilinePattern.AutoSize = true;
            this.lblMultilinePattern.Location = new System.Drawing.Point(3, 9);
            this.lblMultilinePattern.Name = "lblMultilinePattern";
            this.lblMultilinePattern.Size = new System.Drawing.Size(202, 13);
            this.lblMultilinePattern.TabIndex = 177;
            this.lblMultilinePattern.Text = "       Multiline pattern: no options available";
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
            this.tabCategories.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_palette;
            this.tabCategories.ImageSize = new System.Drawing.Size(24, 24);
            this.tabCategories.Location = new System.Drawing.Point(119, 0);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.ShowCloseButton = true;
            this.tabCategories.Size = new System.Drawing.Size(520, 425);
            this.tabCategories.TabIndex = 8;
            this.tabCategories.Text = "Categories";
            this.tabCategories.ThemesEnabled = false;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dgvCategories);
            this.groupBox12.Location = new System.Drawing.Point(18, 189);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(366, 219);
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
            this.cmnVisible,
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
            this.dgvCategories.LockUpdate = false;
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
            this.dgvCategories.Size = new System.Drawing.Size(360, 200);
            this.dgvCategories.TabIndex = 93;
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
            // cmnVisible
            // 
            this.cmnVisible.HeaderText = "";
            this.cmnVisible.Name = "cmnVisible";
            this.cmnVisible.Width = 30;
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
            this.groupBox11.Location = new System.Drawing.Point(18, 9);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(153, 170);
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
            this.lstFields1.Size = new System.Drawing.Size(147, 151);
            this.lstFields1.TabIndex = 124;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkRandomColors);
            this.groupBox6.Controls.Add(this.chkSetGradient);
            this.groupBox6.Controls.Add(this.icbCategories);
            this.groupBox6.Controls.Add(this.btnChangeColorScheme);
            this.groupBox6.Location = new System.Drawing.Point(183, 9);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(201, 82);
            this.groupBox6.TabIndex = 127;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Color scheme";
            // 
            // chkRandomColors
            // 
            this.chkRandomColors.AutoSize = true;
            this.chkRandomColors.Location = new System.Drawing.Point(93, 54);
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
            this.chkSetGradient.Location = new System.Drawing.Point(19, 52);
            this.chkSetGradient.Name = "chkSetGradient";
            this.chkSetGradient.Size = new System.Drawing.Size(68, 20);
            this.chkSetGradient.TabIndex = 116;
            this.chkSetGradient.Text = "Gradient";
            this.chkSetGradient.UseVisualStyleBackColor = true;
            // 
            // icbCategories
            // 
            this.icbCategories.ComboStyle = MW5.Api.Enums.SchemeType.Graduated;
            this.icbCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbCategories.FormattingEnabled = true;
            this.icbCategories.Location = new System.Drawing.Point(19, 25);
            this.icbCategories.Name = "icbCategories";
            this.icbCategories.OutlineColor = System.Drawing.Color.Black;
            this.icbCategories.SchemeTarget = MW5.Plugins.Symbology.SchemeTarget.Vector;
            this.icbCategories.Size = new System.Drawing.Size(137, 21);
            this.icbCategories.TabIndex = 106;
            // 
            // btnChangeColorScheme
            // 
            this.btnChangeColorScheme.BeforeTouchSize = new System.Drawing.Size(28, 21);
            this.btnChangeColorScheme.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnChangeColorScheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChangeColorScheme.IsBackStageButton = false;
            this.btnChangeColorScheme.Location = new System.Drawing.Point(162, 25);
            this.btnChangeColorScheme.Name = "btnChangeColorScheme";
            this.btnChangeColorScheme.Size = new System.Drawing.Size(28, 21);
            this.btnChangeColorScheme.TabIndex = 107;
            this.btnChangeColorScheme.Text = "...";
            this.btnChangeColorScheme.UseVisualStyleBackColor = true;
            this.btnChangeColorScheme.Click += new System.EventHandler(this.btnChangeColorScheme_Click);
            // 
            // btnCategoryClear
            // 
            this.btnCategoryClear.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCategoryClear.IsBackStageButton = false;
            this.btnCategoryClear.Location = new System.Drawing.Point(407, 121);
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
            this.groupVariableSize.Location = new System.Drawing.Point(407, 189);
            this.groupVariableSize.Name = "groupVariableSize";
            this.groupVariableSize.Size = new System.Drawing.Size(93, 142);
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
            this.groupBox9.Location = new System.Drawing.Point(183, 97);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(201, 82);
            this.groupBox9.TabIndex = 123;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Classification";
            // 
            // udNumCategories
            // 
            this.udNumCategories.Location = new System.Drawing.Point(84, 26);
            this.udNumCategories.Name = "udNumCategories";
            this.udNumCategories.Size = new System.Drawing.Size(55, 20);
            this.udNumCategories.TabIndex = 156;
            // 
            // chkUniqueValues
            // 
            this.chkUniqueValues.AutoSize = true;
            this.chkUniqueValues.Location = new System.Drawing.Point(23, 55);
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
            this.label19.Location = new System.Drawing.Point(21, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 101;
            this.label19.Text = "Categories";
            // 
            // btnCategoryRemove
            // 
            this.btnCategoryRemove.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCategoryRemove.IsBackStageButton = false;
            this.btnCategoryRemove.Location = new System.Drawing.Point(407, 89);
            this.btnCategoryRemove.Name = "btnCategoryRemove";
            this.btnCategoryRemove.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryRemove.TabIndex = 95;
            this.btnCategoryRemove.Text = "Remove";
            this.btnCategoryRemove.UseVisualStyleBackColor = true;
            this.btnCategoryRemove.Click += new System.EventHandler(this.btnCategoryRemove_Click);
            // 
            // btnCategoryAppearance
            // 
            this.btnCategoryAppearance.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCategoryAppearance.IsBackStageButton = false;
            this.btnCategoryAppearance.Location = new System.Drawing.Point(407, 57);
            this.btnCategoryAppearance.Name = "btnCategoryAppearance";
            this.btnCategoryAppearance.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryAppearance.TabIndex = 91;
            this.btnCategoryAppearance.Text = "Appearance...";
            this.btnCategoryAppearance.UseVisualStyleBackColor = true;
            this.btnCategoryAppearance.Click += new System.EventHandler(this.btnCategoryAppearance_Click);
            // 
            // btnCategoryGenerate
            // 
            this.btnCategoryGenerate.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCategoryGenerate.IsBackStageButton = false;
            this.btnCategoryGenerate.Location = new System.Drawing.Point(407, 25);
            this.btnCategoryGenerate.Name = "btnCategoryGenerate";
            this.btnCategoryGenerate.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryGenerate.TabIndex = 90;
            this.btnCategoryGenerate.Text = "Generate";
            this.btnCategoryGenerate.UseVisualStyleBackColor = true;
            this.btnCategoryGenerate.Click += new System.EventHandler(this.btnCategoryGenerate_Click);
            // 
            // tabFields
            // 
            this.tabFields.Controls.Add(this.label10);
            this.tabFields.Controls.Add(this.attributesControl1);
            this.tabFields.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_table24;
            this.tabFields.ImageSize = new System.Drawing.Size(24, 24);
            this.tabFields.Location = new System.Drawing.Point(119, 0);
            this.tabFields.Name = "tabFields";
            this.tabFields.ShowCloseButton = true;
            this.tabFields.Size = new System.Drawing.Size(520, 425);
            this.tabFields.TabIndex = 16;
            this.tabFields.Text = "Fields";
            this.tabFields.ThemesEnabled = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Attribute fields of the layer:";
            // 
            // attributesControl1
            // 
            this.attributesControl1.Location = new System.Drawing.Point(14, 43);
            this.attributesControl1.Name = "attributesControl1";
            this.attributesControl1.Size = new System.Drawing.Size(492, 359);
            this.attributesControl1.TabIndex = 0;
            // 
            // tabLabels
            // 
            this.tabLabels.Controls.Add(this.btnLabelsClear);
            this.tabLabels.Controls.Add(this.groupLabelAppearance);
            this.tabLabels.Controls.Add(this.groupLabelStyle);
            this.tabLabels.Controls.Add(this.btnLabelsAppearance);
            this.tabLabels.Image = null;
            this.tabLabels.ImageIndex = 9;
            this.tabLabels.ImageSize = new System.Drawing.Size(16, 16);
            this.tabLabels.Location = new System.Drawing.Point(119, 0);
            this.tabLabels.Name = "tabLabels";
            this.tabLabels.ShowCloseButton = true;
            this.tabLabels.Size = new System.Drawing.Size(520, 425);
            this.tabLabels.TabIndex = 5;
            this.tabLabels.Text = "Labels";
            this.tabLabels.ThemesEnabled = false;
            // 
            // btnLabelsClear
            // 
            this.btnLabelsClear.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnLabelsClear.IsBackStageButton = false;
            this.btnLabelsClear.Location = new System.Drawing.Point(265, 46);
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
            this.groupLabelAppearance.Location = new System.Drawing.Point(15, 148);
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
            this.clpLabelFrame.Location = new System.Drawing.Point(128, 59);
            this.clpLabelFrame.Name = "clpLabelFrame";
            this.clpLabelFrame.Size = new System.Drawing.Size(53, 21);
            this.clpLabelFrame.TabIndex = 157;
            this.clpLabelFrame.SelectedColorChanged += new System.EventHandler(this.clpLabelFrame_SelectedColorChanged);
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
            this.chkShowLabels.CheckedChanged += new System.EventHandler(this.Ui2Settings);
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
            this.pctLabelPreview.Click += new System.EventHandler(this.btnLabelsAppearance_Click);
            // 
            // btnLabelsAppearance
            // 
            this.btnLabelsAppearance.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnLabelsAppearance.IsBackStageButton = false;
            this.btnLabelsAppearance.Location = new System.Drawing.Point(265, 14);
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
            this.tabCharts.Image = null;
            this.tabCharts.ImageIndex = 6;
            this.tabCharts.ImageSize = new System.Drawing.Size(16, 16);
            this.tabCharts.Location = new System.Drawing.Point(119, 0);
            this.tabCharts.Name = "tabCharts";
            this.tabCharts.ShowCloseButton = true;
            this.tabCharts.Size = new System.Drawing.Size(520, 425);
            this.tabCharts.TabIndex = 14;
            this.tabCharts.Text = "Charts";
            this.tabCharts.ThemesEnabled = false;
            // 
            // btnChartAppearance
            // 
            this.btnChartAppearance.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnChartAppearance.IsBackStageButton = false;
            this.btnChartAppearance.Location = new System.Drawing.Point(265, 14);
            this.btnChartAppearance.Name = "btnChartAppearance";
            this.btnChartAppearance.Size = new System.Drawing.Size(93, 26);
            this.btnChartAppearance.TabIndex = 173;
            this.btnChartAppearance.Text = "Setup...";
            this.btnChartAppearance.UseVisualStyleBackColor = true;
            this.btnChartAppearance.Click += new System.EventHandler(this.btnChartAppearance_Click);
            // 
            // btnClearCharts
            // 
            this.btnClearCharts.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnClearCharts.IsBackStageButton = false;
            this.btnClearCharts.Location = new System.Drawing.Point(265, 46);
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
            this.groupChartAppearance.Location = new System.Drawing.Point(15, 148);
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
            this.icbChartColorScheme.ComboStyle = MW5.Api.Enums.SchemeType.Graduated;
            this.icbChartColorScheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbChartColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbChartColorScheme.FormattingEnabled = true;
            this.icbChartColorScheme.Location = new System.Drawing.Point(17, 83);
            this.icbChartColorScheme.Name = "icbChartColorScheme";
            this.icbChartColorScheme.OutlineColor = System.Drawing.Color.Black;
            this.icbChartColorScheme.SchemeTarget = MW5.Plugins.Symbology.SchemeTarget.Vector;
            this.icbChartColorScheme.Size = new System.Drawing.Size(114, 21);
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
            this.pctCharts.Click += new System.EventHandler(this.btnChartAppearance_Click);
            // 
            // tabVisibility
            // 
            this.tabVisibility.Controls.Add(this.groupBox1);
            this.tabVisibility.Controls.Add(this.groupBox13);
            this.tabVisibility.Image = null;
            this.tabVisibility.ImageIndex = 8;
            this.tabVisibility.ImageSize = new System.Drawing.Size(16, 16);
            this.tabVisibility.Location = new System.Drawing.Point(119, 0);
            this.tabVisibility.Name = "tabVisibility";
            this.tabVisibility.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisibility.ShowCloseButton = true;
            this.tabVisibility.Size = new System.Drawing.Size(520, 425);
            this.tabVisibility.TabIndex = 11;
            this.tabVisibility.Text = "Visibility";
            this.tabVisibility.ThemesEnabled = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.scaleLayer);
            this.groupBox1.Location = new System.Drawing.Point(17, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 301);
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
            this.scaleLayer.Size = new System.Drawing.Size(209, 276);
            this.scaleLayer.TabIndex = 162;
            this.scaleLayer.UseDynamicVisibility = false;
            this.scaleLayer.StateChanged += new MW5.Plugins.Symbology.Controls.StateChanged(this.scaleLayer_StateChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnClearLayerExpression);
            this.groupBox13.Controls.Add(this.btnLayerExpression);
            this.groupBox13.Controls.Add(this.txtLayerExpression);
            this.groupBox13.Location = new System.Drawing.Point(255, 10);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(252, 301);
            this.groupBox13.TabIndex = 168;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Visibility expression";
            // 
            // btnClearLayerExpression
            // 
            this.btnClearLayerExpression.BeforeTouchSize = new System.Drawing.Size(74, 26);
            this.btnClearLayerExpression.IsBackStageButton = false;
            this.btnClearLayerExpression.Location = new System.Drawing.Point(157, 257);
            this.btnClearLayerExpression.Name = "btnClearLayerExpression";
            this.btnClearLayerExpression.Size = new System.Drawing.Size(74, 26);
            this.btnClearLayerExpression.TabIndex = 168;
            this.btnClearLayerExpression.Text = "Clear";
            this.btnClearLayerExpression.UseVisualStyleBackColor = true;
            this.btnClearLayerExpression.Click += new System.EventHandler(this.btnClearLayerExpression_Click);
            // 
            // btnLayerExpression
            // 
            this.btnLayerExpression.BeforeTouchSize = new System.Drawing.Size(75, 26);
            this.btnLayerExpression.IsBackStageButton = false;
            this.btnLayerExpression.Location = new System.Drawing.Point(76, 257);
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
            this.txtLayerExpression.Size = new System.Drawing.Size(221, 232);
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
            this.tabMode.Image = null;
            this.tabMode.ImageIndex = 7;
            this.tabMode.ImageSize = new System.Drawing.Size(16, 16);
            this.tabMode.Location = new System.Drawing.Point(119, 0);
            this.tabMode.Name = "tabMode";
            this.tabMode.ShowCloseButton = true;
            this.tabMode.Size = new System.Drawing.Size(520, 425);
            this.tabMode.TabIndex = 13;
            this.tabMode.Text = "Mode";
            this.tabMode.ThemesEnabled = false;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.cboCollisionMode);
            this.groupBox21.Location = new System.Drawing.Point(270, 115);
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
            this.progressBar1.Size = new System.Drawing.Size(482, 20);
            this.progressBar1.TabIndex = 181;
            this.progressBar1.Visible = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label12);
            this.groupBox19.Controls.Add(this.udMinDrawingSize);
            this.groupBox19.Controls.Add(this.udMinLabelingSize);
            this.groupBox19.Controls.Add(this.label6);
            this.groupBox19.Location = new System.Drawing.Point(270, 14);
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
            this.groupModeDescription.Size = new System.Drawing.Size(482, 91);
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
            this.groupBox2.Size = new System.Drawing.Size(249, 173);
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
            this.chkFastMode.Enabled = false;
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
            this.txtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComments_KeyPress);
            this.txtComments.Validated += new System.EventHandler(this.txtComments_Validated);
            // 
            // chkRedrawMap
            // 
            this.chkRedrawMap.AutoSize = true;
            this.chkRedrawMap.Location = new System.Drawing.Point(12, 499);
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
            this.btnSaveChanges.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.IsBackStageButton = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(361, 446);
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
            // VectorStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(660, 475);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.chkRedrawMap);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VectorStyleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Layer properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSymbologyMain_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.vectorInfoTreeView1)).EndInit();
            this.tabDefault.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupPoint.ResumeLayout(false);
            this.groupPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDefaultSize)).EndInit();
            this.groupFill.ResumeLayout(false);
            this.groupFill.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupLine.ResumeLayout(false);
            this.groupLine.PerformLayout();
            this.panelLineOptions.ResumeLayout(false);
            this.panelLineOptions.PerformLayout();
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
            this.tabFields.ResumeLayout(false);
            this.tabFields.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaxScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMinScale)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonAdv btnOk;
        private ButtonAdv btnCancel;
        private TabPropertiesControl tabControl1;
        private TabPageAdv tabLabels;
        private TabPageAdv tabDefault;
        private ButtonAdv btnDefaultChange;
        private TabPageAdv tabCategories;
        private ButtonAdv btnCategoryRemove;
        private ButtonAdv btnCategoryClear;
        private ButtonAdv btnCategoryAppearance;
        private ButtonAdv btnCategoryGenerate;
        private TabPageAdv tabGeneral;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtLayerName;
        private System.Windows.Forms.GroupBox groupLabelStyle;
        private System.Windows.Forms.PictureBox pctLabelPreview;
        private ButtonAdv btnLabelsAppearance;
        private System.Windows.Forms.CheckBox chkShowLabels;
        private Office2007ColorPicker clpLabelFrame;
        private System.Windows.Forms.CheckBox chkLabelFrame;
        private System.Windows.Forms.Label label15;
        private ColorSchemeCombo icbCategories;
        private System.Windows.Forms.Label label19;
        private ButtonAdv btnChangeColorScheme;
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
        private System.Windows.Forms.CheckBox chkLayerVisible;
        private System.Windows.Forms.CheckBox chkLayerPreview;
        private System.Windows.Forms.GroupBox groupBox10;
        private MapControl axMap1;
        private System.Windows.Forms.GroupBox groupBox12;
        private CategoriesGrid dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cmnVisible;
        private System.Windows.Forms.DataGridViewImageColumn cmnStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnExpression;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCount;
        private System.Windows.Forms.Panel panelLabels;
        private NumericUpDownEx udLabelFontSize;
        private TabPageAdv tabVisibility;
        private System.Windows.Forms.TextBox txtLayerExpression;
        private ButtonAdv btnLayerExpression;
        private ScaleControl scaleControl2;
        private ScaleControl scaleControl1;
        private ButtonAdv btnClearLayerExpression;
        private Office2007ColorPicker clpPointFill;
        private TabPageAdv tabMode;
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
        private ButtonAdv btnSaveChanges;
        private System.Windows.Forms.GroupBox groupBox1;
        private ScaleControl scaleLayer;
        private ButtonAdv btnLabelsClear;
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
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.CheckBox chkEditMode;
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
        private System.Windows.Forms.Label label10;
        private VectorInfoTreeView vectorInfoTreeView1;
    }
}