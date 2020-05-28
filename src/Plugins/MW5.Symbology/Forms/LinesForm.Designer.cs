using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ListControls;
using MW5.UI.Controls;
using MW5.UI.Enums;

namespace MW5.Plugins.Symbology.Forms
{
    partial class LinesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pctPreview = new System.Windows.Forms.PictureBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLine = new System.Windows.Forms.TabPage();
            this.transparencyControl1 = new MW5.UI.Controls.TransparencyControl();
            this.groupLine = new System.Windows.Forms.GroupBox();
            this.icbLineWidth = new MW5.UI.Controls.ImageCombo();
            this.label21 = new System.Windows.Forms.Label();
            this.clpOutline = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.icbLineType = new MW5.UI.Controls.ImageCombo();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLineType = new System.Windows.Forms.ComboBox();
            this.tabVertices = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.udVerticesSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.chkVerticesFillVisible = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cboVerticesType = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.clpVerticesColor = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.chkVerticesVisible = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRemoveStyle = new System.Windows.Forms.Button();
            this.btnAddStyle = new System.Windows.Forms.Button();
            this.linePatternControl1 = new MW5.Plugins.Symbology.Controls.ListControls.LinePatternControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupMarker = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.udMarkerOffset = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.clpMarkerOutline = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.udMarkerSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.cboOrientation = new System.Windows.Forms.ComboBox();
            this.pointSymbolControl1 = new MW5.Plugins.Symbology.Controls.ListControls.SymbolControl();
            this.clpMarkerFill = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.udMarkerInterval = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.chkIntervalIsRelative = new System.Windows.Forms.CheckBox();
            this.chkOffsetIsRelative = new System.Windows.Forms.CheckBox();
            this.ttOffsetIsRelative = new System.Windows.Forms.ToolTip(this.components);
            this.chkMarkerFlipFirst = new System.Windows.Forms.CheckBox();
            this.chkMarkerAllowOverflow = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLine.SuspendLayout();
            this.groupLine.SuspendLayout();
            this.tabVertices.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udVerticesSize)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupMarker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMarkerOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMarkerSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMarkerInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pctPreview);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 142);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // pctPreview
            // 
            this.pctPreview.BackColor = System.Drawing.Color.Transparent;
            this.pctPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctPreview.Location = new System.Drawing.Point(3, 16);
            this.pctPreview.Name = "pctPreview";
            this.pctPreview.Size = new System.Drawing.Size(170, 123);
            this.pctPreview.TabIndex = 0;
            this.pctPreview.TabStop = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ColumnHeadersVisible = false;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.SystemColors.Control;
            this.dgv.Location = new System.Drawing.Point(3, 16);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(170, 147);
            this.dgv.TabIndex = 7;
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Image";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Type";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 60;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 166);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Layers";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLine);
            this.tabControl1.Controls.Add(this.tabVertices);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(194, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(419, 341);
            this.tabControl1.TabIndex = 9;
            // 
            // tabLine
            // 
            this.tabLine.Controls.Add(this.transparencyControl1);
            this.tabLine.Controls.Add(this.groupLine);
            this.tabLine.Controls.Add(this.label5);
            this.tabLine.Controls.Add(this.cboLineType);
            this.tabLine.Location = new System.Drawing.Point(4, 22);
            this.tabLine.Name = "tabLine";
            this.tabLine.Size = new System.Drawing.Size(411, 315);
            this.tabLine.TabIndex = 4;
            this.tabLine.Text = "Lines";
            this.tabLine.UseVisualStyleBackColor = true;
            // 
            // transparencyControl1
            // 
            this.transparencyControl1.BandColor = System.Drawing.Color.Empty;
            this.transparencyControl1.Location = new System.Drawing.Point(210, 21);
            this.transparencyControl1.MaximumSize = new System.Drawing.Size(1024, 32);
            this.transparencyControl1.MinimumSize = new System.Drawing.Size(128, 32);
            this.transparencyControl1.Name = "transparencyControl1";
            this.transparencyControl1.Size = new System.Drawing.Size(190, 32);
            this.transparencyControl1.TabIndex = 143;
            this.transparencyControl1.Value = ((byte)(255));
            this.transparencyControl1.ValueChanged += new MW5.UI.Controls.TransparencyControl.ValueChangedDeleg(this.transparencyControl1_ValueChanged);
            // 
            // groupLine
            // 
            this.groupLine.Controls.Add(this.icbLineWidth);
            this.groupLine.Controls.Add(this.label21);
            this.groupLine.Controls.Add(this.clpOutline);
            this.groupLine.Controls.Add(this.icbLineType);
            this.groupLine.Controls.Add(this.label22);
            this.groupLine.Controls.Add(this.label23);
            this.groupLine.Location = new System.Drawing.Point(12, 58);
            this.groupLine.Name = "groupLine";
            this.groupLine.Size = new System.Drawing.Size(390, 109);
            this.groupLine.TabIndex = 140;
            this.groupLine.TabStop = false;
            // 
            // icbLineWidth
            // 
            this.icbLineWidth.Color1 = System.Drawing.Color.Blue;
            this.icbLineWidth.Color2 = System.Drawing.Color.Honeydew;
            this.icbLineWidth.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineWidth.FormattingEnabled = true;
            this.icbLineWidth.Location = new System.Drawing.Point(236, 29);
            this.icbLineWidth.Name = "icbLineWidth";
            this.icbLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.icbLineWidth.Size = new System.Drawing.Size(74, 21);
            this.icbLineWidth.TabIndex = 138;
            this.icbLineWidth.SelectedIndexChanged += new System.EventHandler(this.Ui2Options);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 139;
            this.label21.Text = "Color";
            // 
            // clpOutline
            // 
            this.clpOutline.Color = System.Drawing.Color.Black;
            this.clpOutline.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpOutline.DropDownHeight = 1;
            this.clpOutline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpOutline.FormattingEnabled = true;
            this.clpOutline.IntegralHeight = false;
            this.clpOutline.Items.AddRange(new object[] {
            "Color"});
            this.clpOutline.Location = new System.Drawing.Point(60, 29);
            this.clpOutline.Name = "clpOutline";
            this.clpOutline.Size = new System.Drawing.Size(74, 21);
            this.clpOutline.TabIndex = 136;
            this.clpOutline.SelectedColorChanged += new System.EventHandler(this.Ui2Options);
            // 
            // icbLineType
            // 
            this.icbLineType.Color1 = System.Drawing.Color.Blue;
            this.icbLineType.Color2 = System.Drawing.Color.Honeydew;
            this.icbLineType.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbLineType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineType.FormattingEnabled = true;
            this.icbLineType.Location = new System.Drawing.Point(60, 66);
            this.icbLineType.Name = "icbLineType";
            this.icbLineType.OutlineColor = System.Drawing.Color.Black;
            this.icbLineType.Size = new System.Drawing.Size(74, 21);
            this.icbLineType.TabIndex = 137;
            this.icbLineType.SelectedIndexChanged += new System.EventHandler(this.Ui2Options);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(184, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 135;
            this.label22.Text = "Width";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 69);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 13);
            this.label23.TabIndex = 134;
            this.label23.Text = "Style";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "Line type";
            // 
            // cboLineType
            // 
            this.cboLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineType.FormattingEnabled = true;
            this.cboLineType.Location = new System.Drawing.Point(84, 21);
            this.cboLineType.Name = "cboLineType";
            this.cboLineType.Size = new System.Drawing.Size(85, 21);
            this.cboLineType.TabIndex = 126;
            // 
            // tabVertices
            // 
            this.tabVertices.Controls.Add(this.groupBox3);
            this.tabVertices.Controls.Add(this.chkVerticesVisible);
            this.tabVertices.Location = new System.Drawing.Point(4, 22);
            this.tabVertices.Name = "tabVertices";
            this.tabVertices.Size = new System.Drawing.Size(411, 315);
            this.tabVertices.TabIndex = 3;
            this.tabVertices.Text = "Vertices";
            this.tabVertices.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.udVerticesSize);
            this.groupBox3.Controls.Add(this.chkVerticesFillVisible);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.cboVerticesType);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.clpVerticesColor);
            this.groupBox3.Location = new System.Drawing.Point(12, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 122);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // udVerticesSize
            // 
            this.udVerticesSize.Location = new System.Drawing.Point(248, 32);
            this.udVerticesSize.Name = "udVerticesSize";
            this.udVerticesSize.Size = new System.Drawing.Size(57, 20);
            this.udVerticesSize.TabIndex = 9;
            // 
            // chkVerticesFillVisible
            // 
            this.chkVerticesFillVisible.AutoSize = true;
            this.chkVerticesFillVisible.Location = new System.Drawing.Point(199, 78);
            this.chkVerticesFillVisible.Name = "chkVerticesFillVisible";
            this.chkVerticesFillVisible.Size = new System.Drawing.Size(70, 17);
            this.chkVerticesFillVisible.TabIndex = 8;
            this.chkVerticesFillVisible.Text = "Fill visible";
            this.chkVerticesFillVisible.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(196, 34);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 13);
            this.label29.TabIndex = 6;
            this.label29.Text = "Size";
            // 
            // cboVerticesType
            // 
            this.cboVerticesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVerticesType.FormattingEnabled = true;
            this.cboVerticesType.Location = new System.Drawing.Point(61, 76);
            this.cboVerticesType.Name = "cboVerticesType";
            this.cboVerticesType.Size = new System.Drawing.Size(72, 21);
            this.cboVerticesType.TabIndex = 5;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(15, 79);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 13);
            this.label28.TabIndex = 4;
            this.label28.Text = "Type";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(15, 34);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(31, 13);
            this.label27.TabIndex = 3;
            this.label27.Text = "Color";
            // 
            // clpVerticesColor
            // 
            this.clpVerticesColor.Color = System.Drawing.Color.Black;
            this.clpVerticesColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpVerticesColor.DropDownHeight = 1;
            this.clpVerticesColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpVerticesColor.FormattingEnabled = true;
            this.clpVerticesColor.IntegralHeight = false;
            this.clpVerticesColor.Items.AddRange(new object[] {
            "Color"});
            this.clpVerticesColor.Location = new System.Drawing.Point(61, 31);
            this.clpVerticesColor.Name = "clpVerticesColor";
            this.clpVerticesColor.Size = new System.Drawing.Size(74, 21);
            this.clpVerticesColor.TabIndex = 2;
            // 
            // chkVerticesVisible
            // 
            this.chkVerticesVisible.AutoSize = true;
            this.chkVerticesVisible.Location = new System.Drawing.Point(30, 23);
            this.chkVerticesVisible.Name = "chkVerticesVisible";
            this.chkVerticesVisible.Size = new System.Drawing.Size(64, 17);
            this.chkVerticesVisible.TabIndex = 0;
            this.chkVerticesVisible.Text = "Vertices";
            this.chkVerticesVisible.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRemoveStyle);
            this.tabPage1.Controls.Add(this.btnAddStyle);
            this.tabPage1.Controls.Add(this.linePatternControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(411, 315);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Styles";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRemoveStyle
            // 
            this.btnRemoveStyle.Location = new System.Drawing.Point(326, 48);
            this.btnRemoveStyle.Name = "btnRemoveStyle";
            this.btnRemoveStyle.Size = new System.Drawing.Size(75, 26);
            this.btnRemoveStyle.TabIndex = 2;
            this.btnRemoveStyle.Text = "Remove";
            this.btnRemoveStyle.UseVisualStyleBackColor = true;
            this.btnRemoveStyle.Click += new System.EventHandler(this.btnRemoveStyle_Click);
            // 
            // btnAddStyle
            // 
            this.btnAddStyle.Location = new System.Drawing.Point(326, 16);
            this.btnAddStyle.Name = "btnAddStyle";
            this.btnAddStyle.Size = new System.Drawing.Size(75, 26);
            this.btnAddStyle.TabIndex = 1;
            this.btnAddStyle.Text = "Add";
            this.btnAddStyle.UseVisualStyleBackColor = true;
            this.btnAddStyle.Click += new System.EventHandler(this.btnAddStyle_Click);
            // 
            // linePatternControl1
            // 
            this.linePatternControl1.BackColor = System.Drawing.Color.Transparent;
            this.linePatternControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linePatternControl1.CellHeight = 24;
            this.linePatternControl1.CellWidth = 72;
            this.linePatternControl1.Font = new System.Drawing.Font("Arial", 25.6F);
            this.linePatternControl1.GridColor = System.Drawing.Color.Gray;
            this.linePatternControl1.GridVisible = true;
            this.linePatternControl1.ItemCount = 1;
            this.linePatternControl1.Location = new System.Drawing.Point(19, 16);
            this.linePatternControl1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.linePatternControl1.Name = "linePatternControl1";
            this.linePatternControl1.SelectedIndex = -1;
            this.linePatternControl1.Size = new System.Drawing.Size(299, 279);
            this.linePatternControl1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 122;
            this.label1.Text = "Fill color";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(19, 63);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 13);
            this.label30.TabIndex = 1;
            this.label30.Text = "Interval";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(512, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 26);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(411, 355);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 26);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupMarker
            // 
            this.groupMarker.Controls.Add(this.chkOffsetIsRelative);
            this.groupMarker.Controls.Add(this.chkIntervalIsRelative);
            this.groupMarker.Controls.Add(this.label7);
            this.groupMarker.Controls.Add(this.label4);
            this.groupMarker.Controls.Add(this.udMarkerOffset);
            this.groupMarker.Controls.Add(this.clpMarkerOutline);
            this.groupMarker.Controls.Add(this.label6);
            this.groupMarker.Controls.Add(this.udMarkerSize);
            this.groupMarker.Controls.Add(this.cboOrientation);
            this.groupMarker.Controls.Add(this.label2);
            this.groupMarker.Controls.Add(this.label1);
            this.groupMarker.Controls.Add(this.pointSymbolControl1);
            this.groupMarker.Controls.Add(this.clpMarkerFill);
            this.groupMarker.Controls.Add(this.udMarkerInterval);
            this.groupMarker.Controls.Add(this.label30);
            this.groupMarker.Controls.Add(this.chkMarkerFlipFirst);
            this.groupMarker.Controls.Add(this.chkMarkerAllowOverflow);
            this.groupMarker.Location = new System.Drawing.Point(635, 34);
            this.groupMarker.Name = "groupMarker";
            this.groupMarker.Size = new System.Drawing.Size(390, 224);
            this.groupMarker.TabIndex = 128;
            this.groupMarker.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 132;
            this.label7.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "Outline color";
            // 
            // chkIntervalIsRelative
            // 
            this.chkIntervalIsRelative.AutoSize = true;
            this.chkIntervalIsRelative.Location = new System.Drawing.Point(5, 62);
            this.chkIntervalIsRelative.Name = "chkIntervalIsRelative";
            this.chkIntervalIsRelative.Size = new System.Drawing.Size(18, 17);
            this.chkIntervalIsRelative.TabIndex = 133;
            this.ttOffsetIsRelative.SetToolTip(this.chkIntervalIsRelative, "If checked, the interval is expressed as a fraction of the total length of the li" +
        "ne to be drawn.\r\nIf not checked, the interval is in pixels.");
            this.chkIntervalIsRelative.UseVisualStyleBackColor = true;
            this.chkIntervalIsRelative.CheckedChanged += new System.EventHandler(this.OnIntervalIsRelativeChanged);
            // 
            // chkOffsetIsRelative
            // 
            this.chkOffsetIsRelative.AutoSize = true;
            this.chkOffsetIsRelative.Location = new System.Drawing.Point(5, 105);
            this.chkOffsetIsRelative.Name = "chkOffsetIsRelative";
            this.chkOffsetIsRelative.Size = new System.Drawing.Size(18, 17);
            this.chkOffsetIsRelative.TabIndex = 134;
            this.ttOffsetIsRelative.SetToolTip(this.chkOffsetIsRelative, "If checked, the offset is expressed as a fraction of the total length of the line" +
        " to be drawn.\r\nIf not checked, the offset is in pixels.");
            this.chkOffsetIsRelative.UseVisualStyleBackColor = true;
            this.chkOffsetIsRelative.CheckedChanged += new System.EventHandler(this.OnOffsetIsRelativeChanged);
            // 
            // udMarkerOffset
            // 
            this.udMarkerOffset.Location = new System.Drawing.Point(93, 93);
            this.udMarkerOffset.Name = "udMarkerOffset";
            this.udMarkerOffset.Size = new System.Drawing.Size(57, 20);
            this.udMarkerOffset.TabIndex = 131;
            this.udMarkerOffset.ValueChanged += new System.EventHandler(this.Ui2Options);
            // 
            // clpMarkerOutline
            // 
            this.clpMarkerOutline.Color = System.Drawing.Color.Black;
            this.clpMarkerOutline.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpMarkerOutline.DropDownHeight = 1;
            this.clpMarkerOutline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpMarkerOutline.FormattingEnabled = true;
            this.clpMarkerOutline.IntegralHeight = false;
            this.clpMarkerOutline.Items.AddRange(new object[] {
            "Color"});
            this.clpMarkerOutline.Location = new System.Drawing.Point(259, 93);
            this.clpMarkerOutline.Name = "clpMarkerOutline";
            this.clpMarkerOutline.Size = new System.Drawing.Size(74, 21);
            this.clpMarkerOutline.TabIndex = 126;
            this.clpMarkerOutline.SelectedColorChanged += new System.EventHandler(this.Ui2Options);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 130;
            this.label6.Text = "Orientation";
            // 
            // udMarkerSize
            // 
            this.udMarkerSize.Location = new System.Drawing.Point(93, 25);
            this.udMarkerSize.Name = "udMarkerSize";
            this.udMarkerSize.Size = new System.Drawing.Size(57, 20);
            this.udMarkerSize.TabIndex = 124;
            this.udMarkerSize.ValueChanged += new System.EventHandler(this.Ui2Options);
            // 
            // cboOrientation
            // 
            this.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrientation.FormattingEnabled = true;
            this.cboOrientation.Location = new System.Drawing.Point(259, 25);
            this.cboOrientation.Name = "cboOrientation";
            this.cboOrientation.Size = new System.Drawing.Size(95, 21);
            this.cboOrientation.TabIndex = 129;
            this.cboOrientation.SelectedIndexChanged += new System.EventHandler(this.Ui2Options);
            // 
            // pointSymbolControl1
            // 
            this.pointSymbolControl1.BackColor = System.Drawing.Color.White;
            this.pointSymbolControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pointSymbolControl1.CellHeight = 24;
            this.pointSymbolControl1.CellWidth = 24;
            this.pointSymbolControl1.Font = new System.Drawing.Font("Arial", 25.6F);
            this.pointSymbolControl1.GridColor = System.Drawing.Color.Black;
            this.pointSymbolControl1.GridVisible = false;
            this.pointSymbolControl1.ItemCount = 17;
            this.pointSymbolControl1.Location = new System.Drawing.Point(13, 141);
            this.pointSymbolControl1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.pointSymbolControl1.Name = "pointSymbolControl1";
            this.pointSymbolControl1.SelectedIndex = -1;
            this.pointSymbolControl1.Size = new System.Drawing.Size(364, 54);
            this.pointSymbolControl1.TabIndex = 13;
            // 
            // clpMarkerFill
            // 
            this.clpMarkerFill.Color = System.Drawing.Color.Black;
            this.clpMarkerFill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpMarkerFill.DropDownHeight = 1;
            this.clpMarkerFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpMarkerFill.FormattingEnabled = true;
            this.clpMarkerFill.IntegralHeight = false;
            this.clpMarkerFill.Items.AddRange(new object[] {
            "Color"});
            this.clpMarkerFill.Location = new System.Drawing.Point(259, 59);
            this.clpMarkerFill.Name = "clpMarkerFill";
            this.clpMarkerFill.Size = new System.Drawing.Size(74, 21);
            this.clpMarkerFill.TabIndex = 121;
            this.clpMarkerFill.SelectedColorChanged += new System.EventHandler(this.Ui2Options);
            // 
            // udMarkerInterval
            // 
            this.udMarkerInterval.Location = new System.Drawing.Point(93, 59);
            this.udMarkerInterval.Name = "udMarkerInterval";
            this.udMarkerInterval.Size = new System.Drawing.Size(57, 20);
            this.udMarkerInterval.TabIndex = 12;
            this.udMarkerInterval.ValueChanged += new System.EventHandler(this.Ui2Options);
            // 
            // chkMarkerAllowOverflow
            // 
            this.chkMarkerAllowOverflow.AutoSize = true;
            this.chkMarkerAllowOverflow.Location = new System.Drawing.Point(120, 200);
            this.chkMarkerAllowOverflow.Name = "chkMarkerAllowOverflow";
            this.chkMarkerAllowOverflow.Size = new System.Drawing.Size(93, 17);
            this.chkMarkerAllowOverflow.TabIndex = 0;
            this.chkMarkerAllowOverflow.Text = "Allow marker overflow";
            this.chkMarkerAllowOverflow.UseVisualStyleBackColor = true;
            this.chkMarkerAllowOverflow.CheckedChanged += new System.EventHandler(this.Ui2Options);
            // 
            // chkMarkerFlipFirst
            // 
            this.chkMarkerFlipFirst.AutoSize = true;
            this.chkMarkerFlipFirst.Location = new System.Drawing.Point(15, 200);
            this.chkMarkerFlipFirst.Name = "chkMarkerFlipFirst";
            this.chkMarkerFlipFirst.Size = new System.Drawing.Size(93, 17);
            this.chkMarkerFlipFirst.TabIndex = 0;
            this.chkMarkerFlipFirst.Text = "Flip first marker";
            this.chkMarkerFlipFirst.UseVisualStyleBackColor = true;
            this.chkMarkerFlipFirst.CheckedChanged += new System.EventHandler(this.Ui2Options);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(310, 355);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 26);
            this.btnApply.TabIndex = 129;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = global::MW5.Plugins.Symbology.Properties.Resources.Arrow2___Down;
            this.btnMoveDown.Location = new System.Drawing.Point(153, 321);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(32, 32);
            this.btnMoveDown.TabIndex = 13;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = global::MW5.Plugins.Symbology.Properties.Resources.Arrow2___Up;
            this.btnMoveUp.Location = new System.Drawing.Point(115, 321);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(32, 32);
            this.btnMoveUp.TabIndex = 12;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::MW5.Plugins.Symbology.Properties.Resources.Minus;
            this.btnRemove.Location = new System.Drawing.Point(54, 321);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(32, 32);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::MW5.Plugins.Symbology.Properties.Resources.Plus_orange;
            this.btnAdd.Location = new System.Drawing.Point(16, 321);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // LinesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(615, 385);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupMarker);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LinesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Polyline Style";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLines_FormClosing);
            this.Load += new System.EventHandler(this.LinesForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabLine.ResumeLayout(false);
            this.tabLine.PerformLayout();
            this.groupLine.ResumeLayout(false);
            this.groupLine.PerformLayout();
            this.tabVertices.ResumeLayout(false);
            this.tabVertices.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udVerticesSize)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupMarker.ResumeLayout(false);
            this.groupMarker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMarkerOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMarkerSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMarkerInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pctPreview;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVertices;
        private NumericUpDownEx udVerticesSize;
        private System.Windows.Forms.CheckBox chkVerticesFillVisible;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboVerticesType;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chkVerticesVisible;
        private Office2007ColorPicker clpVerticesColor;
        private System.Windows.Forms.TabPage tabLine;
        private NumericUpDownEx udMarkerInterval;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private Office2007ColorPicker clpMarkerFill;
        private SymbolControl pointSymbolControl1;
        private NumericUpDownEx udMarkerSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboLineType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private ImageCombo icbLineWidth;
        private ImageCombo icbLineType;
        private Office2007ColorPicker clpOutline;
        private System.Windows.Forms.GroupBox groupLine;
        private System.Windows.Forms.GroupBox groupMarker;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label4;
        private Office2007ColorPicker clpMarkerOutline;
        private System.Windows.Forms.Label label7;
        private NumericUpDownEx udMarkerOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboOrientation;
        private System.Windows.Forms.CheckBox chkMarkerFlipFirst;
        private System.Windows.Forms.CheckBox chkMarkerAllowOverflow;
        private TransparencyControl transparencyControl1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnRemoveStyle;
        private System.Windows.Forms.Button btnAddStyle;
        private LinePatternControl linePatternControl1;
        private System.Windows.Forms.CheckBox chkOffsetIsRelative;
        private System.Windows.Forms.ToolTip ttOffsetIsRelative;
        private System.Windows.Forms.CheckBox chkIntervalIsRelative;
    }
}