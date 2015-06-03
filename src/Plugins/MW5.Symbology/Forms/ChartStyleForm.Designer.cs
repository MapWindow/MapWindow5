using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.UI.Controls;

namespace MW5.Plugins.Symbology.Forms
{
    partial class ChartStyleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartStyleForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.cboChartNormalizationField = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboChartSizeField = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.listLeft = new System.Windows.Forms.ListBox();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.listRight = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnChangeScheme = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panelPieChart = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelBarChart = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chk3DMode = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkValuesFrame = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboValuesStyle = new System.Windows.Forms.ComboBox();
            this.chkValuesVisible = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboFontName = new System.Windows.Forms.ComboBox();
            this.chkFontItalic = new System.Windows.Forms.CheckBox();
            this.chkFontBold = new System.Windows.Forms.CheckBox();
            this.tabPosition = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cboChartVerticalPosition = new System.Windows.Forms.ComboBox();
            this.groupboxChartsOffset = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabVisibility = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cboMaxScale = new System.Windows.Forms.ComboBox();
            this.cboMinScale = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.chkDynamicVisibility = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnClearChartsExpression = new System.Windows.Forms.Button();
            this.btnChartExpression = new System.Windows.Forms.Button();
            this.txtChartExpression = new System.Windows.Forms.TextBox();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optBarCharts = new System.Windows.Forms.RadioButton();
            this.optPieCharts = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSetMinScale = new System.Windows.Forms.Button();
            this.btnSetMaxScale = new System.Windows.Forms.Button();
            this.transparencyControl1 = new TransparencyControl();
            this.icbColors = new ColorSchemeCombo();
            this.udPieRadius2 = new NumericUpDownEx(this.components);
            this.udPieRadius = new NumericUpDownEx(this.components);
            this.udBarHeight = new NumericUpDownEx(this.components);
            this.udBarWidth = new NumericUpDownEx(this.components);
            this.udThickness = new NumericUpDownEx(this.components);
            this.udTilt = new NumericUpDownEx(this.components);
            this.clpFrame = new Office2007ColorPicker(this.components);
            this.udFontSize = new NumericUpDownEx(this.components);
            this.clpFont = new Office2007ColorPicker(this.components);
            this.udChartsOffsetY = new NumericUpDownEx(this.components);
            this.udChartsOffsetX = new NumericUpDownEx(this.components);
            this.udChartsBuffer = new NumericUpDownEx(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panelPieChart.SuspendLayout();
            this.panelBarChart.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPosition.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupboxChartsOffset.SuspendLayout();
            this.tabVisibility.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPieRadius2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPieRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChartsOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChartsOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChartsBuffer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 149);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPosition);
            this.tabControl1.Controls.Add(this.tabVisibility);
            this.tabControl1.Location = new System.Drawing.Point(204, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(414, 339);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.btnDelete);
            this.tabPage3.Controls.Add(this.btnAdd);
            this.tabPage3.Controls.Add(this.btnDeleteAll);
            this.tabPage3.Controls.Add(this.listLeft);
            this.tabPage3.Controls.Add(this.btnAddAll);
            this.tabPage3.Controls.Add(this.listRight);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(406, 313);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Fields";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.cboChartNormalizationField);
            this.groupBox13.Controls.Add(this.label16);
            this.groupBox13.Controls.Add(this.cboChartSizeField);
            this.groupBox13.Controls.Add(this.label18);
            this.groupBox13.Location = new System.Drawing.Point(51, 216);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(307, 84);
            this.groupBox13.TabIndex = 99;
            this.groupBox13.TabStop = false;
            // 
            // cboChartNormalizationField
            // 
            this.cboChartNormalizationField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChartNormalizationField.FormattingEnabled = true;
            this.cboChartNormalizationField.Location = new System.Drawing.Point(123, 51);
            this.cboChartNormalizationField.Name = "cboChartNormalizationField";
            this.cboChartNormalizationField.Size = new System.Drawing.Size(140, 21);
            this.cboChartNormalizationField.TabIndex = 98;
            this.cboChartNormalizationField.SelectedIndexChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 13);
            this.label16.TabIndex = 97;
            this.label16.Text = "Normalization field";
            // 
            // cboChartSizeField
            // 
            this.cboChartSizeField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChartSizeField.FormattingEnabled = true;
            this.cboChartSizeField.Location = new System.Drawing.Point(123, 18);
            this.cboChartSizeField.Name = "cboChartSizeField";
            this.cboChartSizeField.Size = new System.Drawing.Size(140, 21);
            this.cboChartSizeField.TabIndex = 96;
            this.cboChartSizeField.SelectedIndexChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 13);
            this.label18.TabIndex = 95;
            this.label18.Text = "Size field";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Available fields:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(187, 65);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(35, 26);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "<";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(187, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 26);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(187, 138);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(35, 26);
            this.btnDeleteAll.TabIndex = 16;
            this.btnDeleteAll.Text = "<<";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // listLeft
            // 
            this.listLeft.FormattingEnabled = true;
            this.listLeft.Location = new System.Drawing.Point(51, 34);
            this.listLeft.Name = "listLeft";
            this.listLeft.Size = new System.Drawing.Size(130, 173);
            this.listLeft.TabIndex = 12;
            this.listLeft.DoubleClick += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(187, 106);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(35, 26);
            this.btnAddAll.TabIndex = 17;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // listRight
            // 
            this.listRight.FormattingEnabled = true;
            this.listRight.Location = new System.Drawing.Point(228, 34);
            this.listRight.Name = "listRight";
            this.listRight.Size = new System.Drawing.Size(130, 173);
            this.listRight.TabIndex = 13;
            this.listRight.DoubleClick += new System.EventHandler(this.btnAdd_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(228, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Selected fields:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnChangeScheme);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.icbColors);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(406, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bar charts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnChangeScheme
            // 
            this.btnChangeScheme.Location = new System.Drawing.Point(361, 43);
            this.btnChangeScheme.Name = "btnChangeScheme";
            this.btnChangeScheme.Size = new System.Drawing.Size(25, 21);
            this.btnChangeScheme.TabIndex = 18;
            this.btnChangeScheme.Text = "...";
            this.btnChangeScheme.UseVisualStyleBackColor = true;
            this.btnChangeScheme.Click += new System.EventHandler(this.btnChangeScheme_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Color scheme";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panelPieChart);
            this.groupBox6.Controls.Add(this.panelBarChart);
            this.groupBox6.Location = new System.Drawing.Point(15, 82);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(377, 98);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Size";
            // 
            // panelPieChart
            // 
            this.panelPieChart.Controls.Add(this.udPieRadius2);
            this.panelPieChart.Controls.Add(this.udPieRadius);
            this.panelPieChart.Controls.Add(this.label8);
            this.panelPieChart.Controls.Add(this.label9);
            this.panelPieChart.Location = new System.Drawing.Point(201, 14);
            this.panelPieChart.Name = "panelPieChart";
            this.panelPieChart.Size = new System.Drawing.Size(170, 72);
            this.panelPieChart.TabIndex = 4;
            this.panelPieChart.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Radius 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Radius";
            // 
            // panelBarChart
            // 
            this.panelBarChart.Controls.Add(this.udBarHeight);
            this.panelBarChart.Controls.Add(this.udBarWidth);
            this.panelBarChart.Controls.Add(this.label3);
            this.panelBarChart.Controls.Add(this.label2);
            this.panelBarChart.Location = new System.Drawing.Point(15, 14);
            this.panelBarChart.Name = "panelBarChart";
            this.panelBarChart.Size = new System.Drawing.Size(181, 72);
            this.panelBarChart.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Width";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.udThickness);
            this.groupBox7.Controls.Add(this.udTilt);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.chk3DMode);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Location = new System.Drawing.Point(15, 186);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(377, 98);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "3D Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Thickness";
            // 
            // chk3DMode
            // 
            this.chk3DMode.AutoSize = true;
            this.chk3DMode.Location = new System.Drawing.Point(201, 27);
            this.chk3DMode.Name = "chk3DMode";
            this.chk3DMode.Size = new System.Drawing.Size(70, 17);
            this.chk3DMode.TabIndex = 0;
            this.chk3DMode.Text = "3D Mode";
            this.chk3DMode.UseVisualStyleBackColor = true;
            this.chk3DMode.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tilt";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.cboValuesStyle);
            this.tabPage2.Controls.Add(this.chkValuesVisible);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(406, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Values";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkValuesFrame);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.clpFrame);
            this.groupBox5.Location = new System.Drawing.Point(15, 215);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(377, 80);
            this.groupBox5.TabIndex = 124;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Frame";
            // 
            // chkValuesFrame
            // 
            this.chkValuesFrame.AutoSize = true;
            this.chkValuesFrame.Location = new System.Drawing.Point(21, 36);
            this.chkValuesFrame.Name = "chkValuesFrame";
            this.chkValuesFrame.Size = new System.Drawing.Size(80, 17);
            this.chkValuesFrame.TabIndex = 122;
            this.chkValuesFrame.Text = "Draw frame";
            this.chkValuesFrame.UseVisualStyleBackColor = true;
            this.chkValuesFrame.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(122, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 119;
            this.label11.Text = "Frame color";
            // 
            // cboValuesStyle
            // 
            this.cboValuesStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboValuesStyle.FormattingEnabled = true;
            this.cboValuesStyle.Location = new System.Drawing.Point(271, 35);
            this.cboValuesStyle.Name = "cboValuesStyle";
            this.cboValuesStyle.Size = new System.Drawing.Size(108, 21);
            this.cboValuesStyle.TabIndex = 117;
            this.cboValuesStyle.SelectedIndexChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // chkValuesVisible
            // 
            this.chkValuesVisible.AutoSize = true;
            this.chkValuesVisible.Location = new System.Drawing.Point(40, 37);
            this.chkValuesVisible.Name = "chkValuesVisible";
            this.chkValuesVisible.Size = new System.Drawing.Size(56, 17);
            this.chkValuesVisible.TabIndex = 121;
            this.chkValuesVisible.Text = "Visible";
            this.chkValuesVisible.UseVisualStyleBackColor = true;
            this.chkValuesVisible.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 118;
            this.label10.Text = "Style";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cboFontName);
            this.groupBox4.Controls.Add(this.chkFontItalic);
            this.groupBox4.Controls.Add(this.chkFontBold);
            this.groupBox4.Controls.Add(this.udFontSize);
            this.groupBox4.Controls.Add(this.clpFont);
            this.groupBox4.Location = new System.Drawing.Point(15, 77);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(377, 132);
            this.groupBox4.TabIndex = 123;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Font";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Color";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(18, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(30, 13);
            this.label35.TabIndex = 112;
            this.label35.Text = "Style";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = "Size";
            // 
            // cboFontName
            // 
            this.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontName.FormattingEnabled = true;
            this.cboFontName.Location = new System.Drawing.Point(71, 29);
            this.cboFontName.Name = "cboFontName";
            this.cboFontName.Size = new System.Drawing.Size(176, 21);
            this.cboFontName.TabIndex = 110;
            this.cboFontName.SelectedIndexChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // chkFontItalic
            // 
            this.chkFontItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFontItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkFontItalic.Image = ((System.Drawing.Image)(resources.GetObject("chkFontItalic.Image")));
            this.chkFontItalic.Location = new System.Drawing.Point(187, 58);
            this.chkFontItalic.Name = "chkFontItalic";
            this.chkFontItalic.Size = new System.Drawing.Size(26, 26);
            this.chkFontItalic.TabIndex = 107;
            this.chkFontItalic.UseVisualStyleBackColor = true;
            this.chkFontItalic.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // chkFontBold
            // 
            this.chkFontBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFontBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkFontBold.Image = ((System.Drawing.Image)(resources.GetObject("chkFontBold.Image")));
            this.chkFontBold.Location = new System.Drawing.Point(219, 58);
            this.chkFontBold.Name = "chkFontBold";
            this.chkFontBold.Size = new System.Drawing.Size(28, 26);
            this.chkFontBold.TabIndex = 106;
            this.chkFontBold.UseVisualStyleBackColor = true;
            this.chkFontBold.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // tabPosition
            // 
            this.tabPosition.Controls.Add(this.groupBox10);
            this.tabPosition.Controls.Add(this.groupboxChartsOffset);
            this.tabPosition.Location = new System.Drawing.Point(4, 22);
            this.tabPosition.Name = "tabPosition";
            this.tabPosition.Size = new System.Drawing.Size(406, 313);
            this.tabPosition.TabIndex = 3;
            this.tabPosition.Text = "Position";
            this.tabPosition.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cboChartVerticalPosition);
            this.groupBox10.Location = new System.Drawing.Point(15, 157);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(202, 69);
            this.groupBox10.TabIndex = 167;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Vertical position";
            // 
            // cboChartVerticalPosition
            // 
            this.cboChartVerticalPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChartVerticalPosition.FormattingEnabled = true;
            this.cboChartVerticalPosition.Location = new System.Drawing.Point(17, 30);
            this.cboChartVerticalPosition.Name = "cboChartVerticalPosition";
            this.cboChartVerticalPosition.Size = new System.Drawing.Size(167, 21);
            this.cboChartVerticalPosition.TabIndex = 165;
            this.cboChartVerticalPosition.SelectedIndexChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // groupboxChartsOffset
            // 
            this.groupboxChartsOffset.Controls.Add(this.udChartsOffsetY);
            this.groupboxChartsOffset.Controls.Add(this.udChartsOffsetX);
            this.groupboxChartsOffset.Controls.Add(this.udChartsBuffer);
            this.groupboxChartsOffset.Controls.Add(this.label17);
            this.groupboxChartsOffset.Controls.Add(this.label14);
            this.groupboxChartsOffset.Controls.Add(this.label15);
            this.groupboxChartsOffset.Location = new System.Drawing.Point(15, 13);
            this.groupboxChartsOffset.Name = "groupboxChartsOffset";
            this.groupboxChartsOffset.Size = new System.Drawing.Size(202, 138);
            this.groupboxChartsOffset.TabIndex = 164;
            this.groupboxChartsOffset.TabStop = false;
            this.groupboxChartsOffset.Text = "Position";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(98, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 160;
            this.label17.Text = "Buffer";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(98, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 158;
            this.label14.Text = "Vertical offset";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(98, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 155;
            this.label15.Text = "Horizontal offset";
            // 
            // tabVisibility
            // 
            this.tabVisibility.Controls.Add(this.groupBox11);
            this.tabVisibility.Controls.Add(this.groupBox9);
            this.tabVisibility.Location = new System.Drawing.Point(4, 22);
            this.tabVisibility.Name = "tabVisibility";
            this.tabVisibility.Size = new System.Drawing.Size(406, 313);
            this.tabVisibility.TabIndex = 4;
            this.tabVisibility.Text = "Visibility";
            this.tabVisibility.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnSetMinScale);
            this.groupBox11.Controls.Add(this.btnSetMaxScale);
            this.groupBox11.Controls.Add(this.cboMaxScale);
            this.groupBox11.Controls.Add(this.cboMinScale);
            this.groupBox11.Controls.Add(this.label20);
            this.groupBox11.Controls.Add(this.label19);
            this.groupBox11.Controls.Add(this.chkDynamicVisibility);
            this.groupBox11.Location = new System.Drawing.Point(15, 159);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(377, 141);
            this.groupBox11.TabIndex = 175;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Dynamic visibility";
            // 
            // cboMaxScale
            // 
            this.cboMaxScale.FormattingEnabled = true;
            this.cboMaxScale.Location = new System.Drawing.Point(144, 101);
            this.cboMaxScale.Name = "cboMaxScale";
            this.cboMaxScale.Size = new System.Drawing.Size(110, 21);
            this.cboMaxScale.TabIndex = 4;
            this.cboMaxScale.TextChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // cboMinScale
            // 
            this.cboMinScale.FormattingEnabled = true;
            this.cboMinScale.Location = new System.Drawing.Point(144, 67);
            this.cboMinScale.Name = "cboMinScale";
            this.cboMinScale.Size = new System.Drawing.Size(110, 21);
            this.cboMinScale.TabIndex = 3;
            this.cboMinScale.TextChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(26, 104);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Maximal visible scale";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(26, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(102, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "Minimal visible scale";
            // 
            // chkDynamicVisibility
            // 
            this.chkDynamicVisibility.AutoSize = true;
            this.chkDynamicVisibility.Location = new System.Drawing.Point(29, 32);
            this.chkDynamicVisibility.Name = "chkDynamicVisibility";
            this.chkDynamicVisibility.Size = new System.Drawing.Size(125, 17);
            this.chkDynamicVisibility.TabIndex = 0;
            this.chkDynamicVisibility.Text = "Use dynamic visibility";
            this.chkDynamicVisibility.UseVisualStyleBackColor = true;
            this.chkDynamicVisibility.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnClearChartsExpression);
            this.groupBox9.Controls.Add(this.btnChartExpression);
            this.groupBox9.Controls.Add(this.txtChartExpression);
            this.groupBox9.Location = new System.Drawing.Point(15, 13);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(377, 138);
            this.groupBox9.TabIndex = 167;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Visibility expression";
            // 
            // btnClearChartsExpression
            // 
            this.btnClearChartsExpression.Location = new System.Drawing.Point(301, 102);
            this.btnClearChartsExpression.Name = "btnClearChartsExpression";
            this.btnClearChartsExpression.Size = new System.Drawing.Size(67, 26);
            this.btnClearChartsExpression.TabIndex = 166;
            this.btnClearChartsExpression.Text = "Clear";
            this.btnClearChartsExpression.UseVisualStyleBackColor = true;
            this.btnClearChartsExpression.Click += new System.EventHandler(this.btnClearChartsExpression_Click);
            // 
            // btnChartExpression
            // 
            this.btnChartExpression.Location = new System.Drawing.Point(228, 102);
            this.btnChartExpression.Name = "btnChartExpression";
            this.btnChartExpression.Size = new System.Drawing.Size(67, 26);
            this.btnChartExpression.TabIndex = 165;
            this.btnChartExpression.Text = "Change...";
            this.btnChartExpression.UseVisualStyleBackColor = true;
            this.btnChartExpression.Click += new System.EventHandler(this.btnChartExpression_Click);
            // 
            // txtChartExpression
            // 
            this.txtChartExpression.Location = new System.Drawing.Point(20, 19);
            this.txtChartExpression.Multiline = true;
            this.txtChartExpression.Name = "txtChartExpression";
            this.txtChartExpression.ReadOnly = true;
            this.txtChartExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChartExpression.Size = new System.Drawing.Size(348, 77);
            this.txtChartExpression.TabIndex = 164;
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(23, 21);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(88, 17);
            this.chkVisible.TabIndex = 13;
            this.chkVisible.Text = "Charts visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.CheckedChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.optBarCharts);
            this.groupBox2.Controls.Add(this.optPieCharts);
            this.groupBox2.Location = new System.Drawing.Point(10, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // optBarCharts
            // 
            this.optBarCharts.AutoSize = true;
            this.optBarCharts.Location = new System.Drawing.Point(23, 22);
            this.optBarCharts.Name = "optBarCharts";
            this.optBarCharts.Size = new System.Drawing.Size(73, 17);
            this.optBarCharts.TabIndex = 1;
            this.optBarCharts.TabStop = true;
            this.optBarCharts.Text = "Bar charts";
            this.optBarCharts.UseVisualStyleBackColor = true;
            this.optBarCharts.CheckedChanged += new System.EventHandler(this.optBarCharts_CheckedChanged);
            // 
            // optPieCharts
            // 
            this.optPieCharts.AutoSize = true;
            this.optPieCharts.Location = new System.Drawing.Point(102, 22);
            this.optPieCharts.Name = "optPieCharts";
            this.optPieCharts.Size = new System.Drawing.Size(72, 17);
            this.optPieCharts.TabIndex = 0;
            this.optPieCharts.TabStop = true;
            this.optPieCharts.Text = "Pie charts";
            this.optPieCharts.UseVisualStyleBackColor = true;
            this.optPieCharts.CheckedChanged += new System.EventHandler(this.optPieCharts_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(434, 353);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 26);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(527, 353);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkVisible);
            this.groupBox3.Location = new System.Drawing.Point(12, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 50);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.transparencyControl1);
            this.groupBox8.Location = new System.Drawing.Point(10, 287);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(188, 65);
            this.groupBox8.TabIndex = 18;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Transparency";
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(341, 353);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(87, 26);
            this.btnApply.TabIndex = 19;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnSetMinScale
            // 
            this.btnSetMinScale.Location = new System.Drawing.Point(272, 64);
            this.btnSetMinScale.Name = "btnSetMinScale";
            this.btnSetMinScale.Size = new System.Drawing.Size(87, 24);
            this.btnSetMinScale.TabIndex = 8;
            this.btnSetMinScale.Text = "Set current";
            this.btnSetMinScale.UseVisualStyleBackColor = true;
            this.btnSetMinScale.Click += new System.EventHandler(this.btnSetMinScale_Click);
            // 
            // btnSetMaxScale
            // 
            this.btnSetMaxScale.Location = new System.Drawing.Point(272, 98);
            this.btnSetMaxScale.Name = "btnSetMaxScale";
            this.btnSetMaxScale.Size = new System.Drawing.Size(87, 24);
            this.btnSetMaxScale.TabIndex = 7;
            this.btnSetMaxScale.Text = "Set current";
            this.btnSetMaxScale.UseVisualStyleBackColor = true;
            this.btnSetMaxScale.Click += new System.EventHandler(this.btnSetMaxScale_Click);
            // 
            // transparencyControl1
            // 
            this.transparencyControl1.BandColor = System.Drawing.Color.Empty;
            this.transparencyControl1.Location = new System.Drawing.Point(18, 27);
            this.transparencyControl1.MaximumSize = new System.Drawing.Size(1024, 32);
            this.transparencyControl1.MinimumSize = new System.Drawing.Size(128, 32);
            this.transparencyControl1.Name = "transparencyControl1";
            this.transparencyControl1.Size = new System.Drawing.Size(156, 32);
            this.transparencyControl1.TabIndex = 17;
            this.transparencyControl1.Value = ((byte)(255));
            this.transparencyControl1.ValueChanged += new TransparencyControl.ValueChangedDeleg(this.transparencyControl1_ValueChanged);
            // 
            // icbColors
            // 
            this.icbColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbColors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbColors.FormattingEnabled = true;
            this.icbColors.Location = new System.Drawing.Point(178, 43);
            this.icbColors.Name = "icbColors";
            this.icbColors.OutlineColor = System.Drawing.Color.Black;
            this.icbColors.Size = new System.Drawing.Size(176, 21);
            this.icbColors.TabIndex = 2;
            this.icbColors.SelectedIndexChanged += new System.EventHandler(this.icbColors_SelectedIndexChanged);
            // 
            // udPieRadius2
            // 
            this.udPieRadius2.Location = new System.Drawing.Point(89, 46);
            this.udPieRadius2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udPieRadius2.Name = "udPieRadius2";
            this.udPieRadius2.Size = new System.Drawing.Size(49, 20);
            this.udPieRadius2.TabIndex = 9;
            this.udPieRadius2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udPieRadius2.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udPieRadius
            // 
            this.udPieRadius.Location = new System.Drawing.Point(89, 14);
            this.udPieRadius.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udPieRadius.Name = "udPieRadius";
            this.udPieRadius.Size = new System.Drawing.Size(49, 20);
            this.udPieRadius.TabIndex = 5;
            this.udPieRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udPieRadius.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udBarHeight
            // 
            this.udBarHeight.Location = new System.Drawing.Point(89, 46);
            this.udBarHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udBarHeight.Name = "udBarHeight";
            this.udBarHeight.Size = new System.Drawing.Size(51, 20);
            this.udBarHeight.TabIndex = 16;
            this.udBarHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udBarHeight.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udBarWidth
            // 
            this.udBarWidth.Location = new System.Drawing.Point(89, 14);
            this.udBarWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udBarWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udBarWidth.Name = "udBarWidth";
            this.udBarWidth.Size = new System.Drawing.Size(51, 20);
            this.udBarWidth.TabIndex = 15;
            this.udBarWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udBarWidth.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udThickness
            // 
            this.udThickness.Location = new System.Drawing.Point(104, 62);
            this.udThickness.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.udThickness.Name = "udThickness";
            this.udThickness.Size = new System.Drawing.Size(51, 20);
            this.udThickness.TabIndex = 14;
            this.udThickness.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udTilt
            // 
            this.udTilt.Location = new System.Drawing.Point(105, 25);
            this.udTilt.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.udTilt.Name = "udTilt";
            this.udTilt.Size = new System.Drawing.Size(51, 20);
            this.udTilt.TabIndex = 13;
            this.udTilt.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // clpFrame
            // 
            this.clpFrame.Color = System.Drawing.Color.Black;
            this.clpFrame.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFrame.DropDownHeight = 1;
            this.clpFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFrame.FormattingEnabled = true;
            this.clpFrame.IntegralHeight = false;
            this.clpFrame.Items.AddRange(new object[] {
            "Color"});
            this.clpFrame.Location = new System.Drawing.Point(190, 34);
            this.clpFrame.Name = "clpFrame";
            this.clpFrame.Size = new System.Drawing.Size(74, 21);
            this.clpFrame.TabIndex = 120;
            this.clpFrame.SelectedColorChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udFontSize
            // 
            this.udFontSize.Location = new System.Drawing.Point(303, 32);
            this.udFontSize.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.udFontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.udFontSize.Name = "udFontSize";
            this.udFontSize.Size = new System.Drawing.Size(50, 20);
            this.udFontSize.TabIndex = 116;
            this.udFontSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.udFontSize.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // clpFont
            // 
            this.clpFont.Color = System.Drawing.Color.Black;
            this.clpFont.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFont.DropDownHeight = 1;
            this.clpFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFont.FormattingEnabled = true;
            this.clpFont.IntegralHeight = false;
            this.clpFont.Items.AddRange(new object[] {
            "Color"});
            this.clpFont.Location = new System.Drawing.Point(71, 89);
            this.clpFont.Name = "clpFont";
            this.clpFont.Size = new System.Drawing.Size(74, 21);
            this.clpFont.TabIndex = 115;
            this.clpFont.SelectedColorChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udChartsOffsetY
            // 
            this.udChartsOffsetY.Location = new System.Drawing.Point(29, 67);
            this.udChartsOffsetY.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udChartsOffsetY.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.udChartsOffsetY.Name = "udChartsOffsetY";
            this.udChartsOffsetY.Size = new System.Drawing.Size(54, 20);
            this.udChartsOffsetY.TabIndex = 163;
            this.udChartsOffsetY.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udChartsOffsetX
            // 
            this.udChartsOffsetX.Location = new System.Drawing.Point(29, 32);
            this.udChartsOffsetX.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udChartsOffsetX.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.udChartsOffsetX.Name = "udChartsOffsetX";
            this.udChartsOffsetX.Size = new System.Drawing.Size(54, 20);
            this.udChartsOffsetX.TabIndex = 162;
            this.udChartsOffsetX.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // udChartsBuffer
            // 
            this.udChartsBuffer.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udChartsBuffer.Location = new System.Drawing.Point(29, 102);
            this.udChartsBuffer.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.udChartsBuffer.Name = "udChartsBuffer";
            this.udChartsBuffer.Size = new System.Drawing.Size(54, 20);
            this.udChartsBuffer.TabIndex = 161;
            this.udChartsBuffer.ValueChanged += new System.EventHandler(this.Ui2Settings);
            // 
            // ChartStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(623, 385);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartStyleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart style";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChartStyle_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.panelPieChart.ResumeLayout(false);
            this.panelPieChart.PerformLayout();
            this.panelBarChart.ResumeLayout(false);
            this.panelBarChart.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPosition.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupboxChartsOffset.ResumeLayout(false);
            this.groupboxChartsOffset.PerformLayout();
            this.tabVisibility.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udPieRadius2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPieRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChartsOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChartsOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udChartsBuffer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk3DMode;
        private System.Windows.Forms.Panel panelBarChart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelPieChart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkValuesVisible;
        private System.Windows.Forms.Label label11;
        private Office2007ColorPicker clpFrame;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboValuesStyle;
        private NumericUpDownEx udFontSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboFontName;
        private System.Windows.Forms.CheckBox chkFontItalic;
        private System.Windows.Forms.CheckBox chkFontBold;
        private Office2007ColorPicker clpFont;
        private System.Windows.Forms.CheckBox chkValuesFrame;
        private System.Windows.Forms.RadioButton optBarCharts;
        private System.Windows.Forms.RadioButton optPieCharts;
        private ColorSchemeCombo icbColors;
        private System.Windows.Forms.GroupBox groupBox2;
        private NumericUpDownEx udTilt;
        private NumericUpDownEx udThickness;
        private NumericUpDownEx udBarHeight;
        private NumericUpDownEx udBarWidth;
        private NumericUpDownEx udPieRadius2;
        private NumericUpDownEx udPieRadius;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox3;
        private TransparencyControl transparencyControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listLeft;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox listRight;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabPage tabPosition;
        private System.Windows.Forms.GroupBox groupboxChartsOffset;
        private NumericUpDownEx udChartsOffsetY;
        private NumericUpDownEx udChartsOffsetX;
        private NumericUpDownEx udChartsBuffer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabVisibility;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cboChartNormalizationField;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboChartSizeField;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnClearChartsExpression;
        private System.Windows.Forms.Button btnChartExpression;
        private System.Windows.Forms.TextBox txtChartExpression;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox cboChartVerticalPosition;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ComboBox cboMaxScale;
        private System.Windows.Forms.ComboBox cboMinScale;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkDynamicVisibility;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnChangeScheme;
        private System.Windows.Forms.Button btnSetMinScale;
        private System.Windows.Forms.Button btnSetMaxScale;
    }
}