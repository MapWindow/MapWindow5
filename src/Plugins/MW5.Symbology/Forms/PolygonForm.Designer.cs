using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ListControls;
using MW5.UI.Controls;

namespace MW5.Plugins.Symbology.Forms
{
    partial class PolygonForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.transpFill = new MW5.UI.Controls.TransparencyControl();
            this.pnlFillPicture = new System.Windows.Forms.Panel();
            this.udScaleY = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.udScaleX = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.groupGradient = new System.Windows.Forms.GroupBox();
            this.pnlFillGradient = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.udGradientRotation = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.cboGradientBounds = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboGradientType = new System.Windows.Forms.ComboBox();
            this.clpGradient2 = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.clpFill = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboFillType = new System.Windows.Forms.ComboBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.transpOutline = new MW5.UI.Controls.TransparencyControl();
            this.icbLineWidth = new MW5.UI.Controls.ImageCombo();
            this.icbLineType = new MW5.UI.Controls.ImageCombo();
            this.clpOutline = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.udVerticesSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.chkVerticesFillVisible = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cboVerticesType = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.clpVerticesColor = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.pnlFillHatch = new System.Windows.Forms.Panel();
            this.icbHatchStyle = new MW5.UI.Controls.ImageCombo();
            this.chkFillBgTransparent = new System.Windows.Forms.CheckBox();
            this.clpHatchBack = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkOutlineVisible = new System.Windows.Forms.CheckBox();
            this.chkFillVisible = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkVerticesVisible = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupHatch = new System.Windows.Forms.GroupBox();
            this.groupPicture = new System.Windows.Forms.GroupBox();
            this.textureControl1 = new MW5.Plugins.Symbology.Controls.ListControls.IconControl();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnlFillPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udScaleX)).BeginInit();
            this.groupGradient.SuspendLayout();
            this.pnlFillGradient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udGradientRotation)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udVerticesSize)).BeginInit();
            this.pnlFillHatch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupHatch.SuspendLayout();
            this.groupPicture.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pctPreview);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 178);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // pctPreview
            // 
            this.pctPreview.BackColor = System.Drawing.Color.Transparent;
            this.pctPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctPreview.Location = new System.Drawing.Point(3, 16);
            this.pctPreview.Name = "pctPreview";
            this.pctPreview.Size = new System.Drawing.Size(170, 159);
            this.pctPreview.TabIndex = 0;
            this.pctPreview.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(191, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(426, 342);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.transpFill);
            this.tabPage2.Controls.Add(this.pnlFillPicture);
            this.tabPage2.Controls.Add(this.groupGradient);
            this.tabPage2.Controls.Add(this.clpFill);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cboFillType);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(418, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fill";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 92;
            this.label5.Text = "Transparency";
            // 
            // transpFill
            // 
            this.transpFill.BandColor = System.Drawing.Color.Empty;
            this.transpFill.Location = new System.Drawing.Point(105, 22);
            this.transpFill.MaximumSize = new System.Drawing.Size(1024, 32);
            this.transpFill.MinimumSize = new System.Drawing.Size(128, 32);
            this.transpFill.Name = "transpFill";
            this.transpFill.Size = new System.Drawing.Size(247, 32);
            this.transpFill.TabIndex = 91;
            this.transpFill.Value = ((byte)(255));
            this.transpFill.ValueChanged += new MW5.UI.Controls.TransparencyControl.ValueChangedDeleg(this.transpOutline_ValueChanged);
            // 
            // pnlFillPicture
            // 
            this.pnlFillPicture.Controls.Add(this.udScaleY);
            this.pnlFillPicture.Controls.Add(this.label9);
            this.pnlFillPicture.Controls.Add(this.udScaleX);
            this.pnlFillPicture.Controls.Add(this.label8);
            this.pnlFillPicture.Location = new System.Drawing.Point(3, 96);
            this.pnlFillPicture.Name = "pnlFillPicture";
            this.pnlFillPicture.Size = new System.Drawing.Size(395, 35);
            this.pnlFillPicture.TabIndex = 45;
            // 
            // udScaleY
            // 
            this.udScaleY.DecimalPlaces = 1;
            this.udScaleY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udScaleY.Location = new System.Drawing.Point(236, 12);
            this.udScaleY.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udScaleY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udScaleY.Name = "udScaleY";
            this.udScaleY.Size = new System.Drawing.Size(62, 20);
            this.udScaleY.TabIndex = 77;
            this.udScaleY.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 76;
            this.label9.Text = "Scale Y";
            // 
            // udScaleX
            // 
            this.udScaleX.DecimalPlaces = 1;
            this.udScaleX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udScaleX.Location = new System.Drawing.Point(91, 12);
            this.udScaleX.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udScaleX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.udScaleX.Name = "udScaleX";
            this.udScaleX.Size = new System.Drawing.Size(62, 20);
            this.udScaleX.TabIndex = 75;
            this.udScaleX.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Scale X";
            // 
            // groupGradient
            // 
            this.groupGradient.Controls.Add(this.pnlFillGradient);
            this.groupGradient.Location = new System.Drawing.Point(6, 140);
            this.groupGradient.Name = "groupGradient";
            this.groupGradient.Size = new System.Drawing.Size(397, 143);
            this.groupGradient.TabIndex = 90;
            this.groupGradient.TabStop = false;
            // 
            // pnlFillGradient
            // 
            this.pnlFillGradient.Controls.Add(this.label11);
            this.pnlFillGradient.Controls.Add(this.udGradientRotation);
            this.pnlFillGradient.Controls.Add(this.cboGradientBounds);
            this.pnlFillGradient.Controls.Add(this.label4);
            this.pnlFillGradient.Controls.Add(this.label26);
            this.pnlFillGradient.Controls.Add(this.label7);
            this.pnlFillGradient.Controls.Add(this.cboGradientType);
            this.pnlFillGradient.Controls.Add(this.clpGradient2);
            this.pnlFillGradient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFillGradient.Location = new System.Drawing.Point(3, 16);
            this.pnlFillGradient.Name = "pnlFillGradient";
            this.pnlFillGradient.Size = new System.Drawing.Size(391, 124);
            this.pnlFillGradient.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 100;
            this.label11.Text = "Color 2";
            // 
            // udGradientRotation
            // 
            this.udGradientRotation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udGradientRotation.Location = new System.Drawing.Point(312, 15);
            this.udGradientRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udGradientRotation.Name = "udGradientRotation";
            this.udGradientRotation.Size = new System.Drawing.Size(56, 20);
            this.udGradientRotation.TabIndex = 99;
            // 
            // cboGradientBounds
            // 
            this.cboGradientBounds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradientBounds.FormattingEnabled = true;
            this.cboGradientBounds.Location = new System.Drawing.Point(102, 52);
            this.cboGradientBounds.Name = "cboGradientBounds";
            this.cboGradientBounds.Size = new System.Drawing.Size(152, 21);
            this.cboGradientBounds.TabIndex = 98;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Gradient bounds";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(272, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(34, 13);
            this.label26.TabIndex = 95;
            this.label26.Text = "Angle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 89;
            this.label7.Text = "Gradient type";
            // 
            // cboGradientType
            // 
            this.cboGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradientType.FormattingEnabled = true;
            this.cboGradientType.Location = new System.Drawing.Point(102, 14);
            this.cboGradientType.Name = "cboGradientType";
            this.cboGradientType.Size = new System.Drawing.Size(152, 21);
            this.cboGradientType.TabIndex = 90;
            // 
            // clpGradient2
            // 
            this.clpGradient2.Color = System.Drawing.Color.Black;
            this.clpGradient2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpGradient2.DropDownHeight = 1;
            this.clpGradient2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpGradient2.FormattingEnabled = true;
            this.clpGradient2.IntegralHeight = false;
            this.clpGradient2.Items.AddRange(new object[] {
            "Color"});
            this.clpGradient2.Location = new System.Drawing.Point(102, 90);
            this.clpGradient2.Name = "clpGradient2";
            this.clpGradient2.Size = new System.Drawing.Size(72, 21);
            this.clpGradient2.TabIndex = 88;
            // 
            // clpFill
            // 
            this.clpFill.Color = System.Drawing.Color.Black;
            this.clpFill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFill.DropDownHeight = 1;
            this.clpFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFill.FormattingEnabled = true;
            this.clpFill.IntegralHeight = false;
            this.clpFill.Items.AddRange(new object[] {
            "Color"});
            this.clpFill.Location = new System.Drawing.Point(82, 103);
            this.clpFill.Name = "clpFill";
            this.clpFill.Size = new System.Drawing.Size(74, 21);
            this.clpFill.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "Color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 87;
            this.label1.Text = "Fill type";
            // 
            // cboFillType
            // 
            this.cboFillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFillType.FormattingEnabled = true;
            this.cboFillType.Location = new System.Drawing.Point(111, 60);
            this.cboFillType.Name = "cboFillType";
            this.cboFillType.Size = new System.Drawing.Size(142, 21);
            this.cboFillType.TabIndex = 86;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(418, 316);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Outline";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.transpOutline);
            this.groupBox3.Controls.Add(this.icbLineWidth);
            this.groupBox3.Controls.Add(this.icbLineType);
            this.groupBox3.Controls.Add(this.clpOutline);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 172);
            this.groupBox3.TabIndex = 134;
            this.groupBox3.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 130;
            this.label21.Text = "Color";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(193, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 126;
            this.label22.Text = "Width";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 123);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 136;
            this.label12.Text = "Transparency";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 77);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 13);
            this.label23.TabIndex = 125;
            this.label23.Text = "Style";
            // 
            // transpOutline
            // 
            this.transpOutline.BandColor = System.Drawing.Color.Empty;
            this.transpOutline.Location = new System.Drawing.Point(125, 123);
            this.transpOutline.MaximumSize = new System.Drawing.Size(1024, 32);
            this.transpOutline.MinimumSize = new System.Drawing.Size(128, 32);
            this.transpOutline.Name = "transpOutline";
            this.transpOutline.Size = new System.Drawing.Size(247, 32);
            this.transpOutline.TabIndex = 135;
            this.transpOutline.Value = ((byte)(255));
            this.transpOutline.ValueChanged += new MW5.UI.Controls.TransparencyControl.ValueChangedDeleg(this.transpOutline_ValueChanged);
            // 
            // icbLineWidth
            // 
            this.icbLineWidth.Color1 = System.Drawing.Color.Blue;
            this.icbLineWidth.Color2 = System.Drawing.Color.Honeydew;
            this.icbLineWidth.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineWidth.FormattingEnabled = true;
            this.icbLineWidth.Location = new System.Drawing.Point(245, 28);
            this.icbLineWidth.Name = "icbLineWidth";
            this.icbLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.icbLineWidth.Size = new System.Drawing.Size(74, 21);
            this.icbLineWidth.TabIndex = 129;
            // 
            // icbLineType
            // 
            this.icbLineType.Color1 = System.Drawing.Color.Blue;
            this.icbLineType.Color2 = System.Drawing.Color.Honeydew;
            this.icbLineType.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbLineType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineType.FormattingEnabled = true;
            this.icbLineType.Location = new System.Drawing.Point(64, 74);
            this.icbLineType.Name = "icbLineType";
            this.icbLineType.OutlineColor = System.Drawing.Color.Black;
            this.icbLineType.Size = new System.Drawing.Size(74, 21);
            this.icbLineType.TabIndex = 128;
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
            this.clpOutline.Location = new System.Drawing.Point(64, 28);
            this.clpOutline.Name = "clpOutline";
            this.clpOutline.Size = new System.Drawing.Size(74, 21);
            this.clpOutline.TabIndex = 127;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(418, 316);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Vertices";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.udVerticesSize);
            this.groupBox4.Controls.Add(this.chkVerticesFillVisible);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.cboVerticesType);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.clpVerticesColor);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(388, 132);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // udVerticesSize
            // 
            this.udVerticesSize.Location = new System.Drawing.Point(256, 28);
            this.udVerticesSize.Name = "udVerticesSize";
            this.udVerticesSize.Size = new System.Drawing.Size(57, 20);
            this.udVerticesSize.TabIndex = 17;
            // 
            // chkVerticesFillVisible
            // 
            this.chkVerticesFillVisible.AutoSize = true;
            this.chkVerticesFillVisible.Location = new System.Drawing.Point(207, 78);
            this.chkVerticesFillVisible.Name = "chkVerticesFillVisible";
            this.chkVerticesFillVisible.Size = new System.Drawing.Size(70, 17);
            this.chkVerticesFillVisible.TabIndex = 16;
            this.chkVerticesFillVisible.Text = "Fill visible";
            this.chkVerticesFillVisible.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(204, 30);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 13);
            this.label29.TabIndex = 15;
            this.label29.Text = "Size";
            // 
            // cboVerticesType
            // 
            this.cboVerticesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVerticesType.FormattingEnabled = true;
            this.cboVerticesType.Location = new System.Drawing.Point(64, 75);
            this.cboVerticesType.Name = "cboVerticesType";
            this.cboVerticesType.Size = new System.Drawing.Size(72, 21);
            this.cboVerticesType.TabIndex = 14;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(23, 78);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(31, 13);
            this.label28.TabIndex = 13;
            this.label28.Text = "Type";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(23, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(31, 13);
            this.label27.TabIndex = 12;
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
            this.clpVerticesColor.Location = new System.Drawing.Point(64, 28);
            this.clpVerticesColor.Name = "clpVerticesColor";
            this.clpVerticesColor.Size = new System.Drawing.Size(74, 21);
            this.clpVerticesColor.TabIndex = 11;
            // 
            // pnlFillHatch
            // 
            this.pnlFillHatch.Controls.Add(this.icbHatchStyle);
            this.pnlFillHatch.Controls.Add(this.chkFillBgTransparent);
            this.pnlFillHatch.Controls.Add(this.clpHatchBack);
            this.pnlFillHatch.Controls.Add(this.label2);
            this.pnlFillHatch.Controls.Add(this.label3);
            this.pnlFillHatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFillHatch.Location = new System.Drawing.Point(3, 16);
            this.pnlFillHatch.Name = "pnlFillHatch";
            this.pnlFillHatch.Size = new System.Drawing.Size(391, 89);
            this.pnlFillHatch.TabIndex = 13;
            // 
            // icbHatchStyle
            // 
            this.icbHatchStyle.Color1 = System.Drawing.Color.Blue;
            this.icbHatchStyle.Color2 = System.Drawing.Color.Honeydew;
            this.icbHatchStyle.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbHatchStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbHatchStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbHatchStyle.FormattingEnabled = true;
            this.icbHatchStyle.Location = new System.Drawing.Point(99, 14);
            this.icbHatchStyle.Name = "icbHatchStyle";
            this.icbHatchStyle.OutlineColor = System.Drawing.Color.Black;
            this.icbHatchStyle.Size = new System.Drawing.Size(197, 21);
            this.icbHatchStyle.TabIndex = 90;
            // 
            // chkFillBgTransparent
            // 
            this.chkFillBgTransparent.AutoSize = true;
            this.chkFillBgTransparent.Location = new System.Drawing.Point(187, 56);
            this.chkFillBgTransparent.Name = "chkFillBgTransparent";
            this.chkFillBgTransparent.Size = new System.Drawing.Size(83, 17);
            this.chkFillBgTransparent.TabIndex = 89;
            this.chkFillBgTransparent.Text = "Transparent";
            this.chkFillBgTransparent.UseVisualStyleBackColor = true;
            // 
            // clpHatchBack
            // 
            this.clpHatchBack.Color = System.Drawing.Color.Black;
            this.clpHatchBack.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpHatchBack.DropDownHeight = 1;
            this.clpHatchBack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpHatchBack.FormattingEnabled = true;
            this.clpHatchBack.IntegralHeight = false;
            this.clpHatchBack.Items.AddRange(new object[] {
            "Color"});
            this.clpHatchBack.Location = new System.Drawing.Point(99, 54);
            this.clpHatchBack.Name = "clpHatchBack";
            this.clpHatchBack.Size = new System.Drawing.Size(74, 21);
            this.clpHatchBack.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Background";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Hatch type";
            // 
            // chkOutlineVisible
            // 
            this.chkOutlineVisible.AutoSize = true;
            this.chkOutlineVisible.Location = new System.Drawing.Point(27, 66);
            this.chkOutlineVisible.Name = "chkOutlineVisible";
            this.chkOutlineVisible.Size = new System.Drawing.Size(59, 17);
            this.chkOutlineVisible.TabIndex = 131;
            this.chkOutlineVisible.Text = "Outline";
            this.chkOutlineVisible.UseVisualStyleBackColor = true;
            // 
            // chkFillVisible
            // 
            this.chkFillVisible.AutoSize = true;
            this.chkFillVisible.Location = new System.Drawing.Point(27, 30);
            this.chkFillVisible.Name = "chkFillVisible";
            this.chkFillVisible.Size = new System.Drawing.Size(38, 17);
            this.chkFillVisible.TabIndex = 90;
            this.chkFillVisible.Text = "Fill";
            this.chkFillVisible.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFillVisible);
            this.groupBox2.Controls.Add(this.chkVerticesVisible);
            this.groupBox2.Controls.Add(this.chkOutlineVisible);
            this.groupBox2.Location = new System.Drawing.Point(9, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 158);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // chkVerticesVisible
            // 
            this.chkVerticesVisible.AutoSize = true;
            this.chkVerticesVisible.Location = new System.Drawing.Point(27, 104);
            this.chkVerticesVisible.Name = "chkVerticesVisible";
            this.chkVerticesVisible.Size = new System.Drawing.Size(64, 17);
            this.chkVerticesVisible.TabIndex = 10;
            this.chkVerticesVisible.Text = "Vertices";
            this.chkVerticesVisible.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(519, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 26);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(418, 352);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 26);
            this.btnOk.TabIndex = 42;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupHatch
            // 
            this.groupHatch.Controls.Add(this.pnlFillHatch);
            this.groupHatch.Location = new System.Drawing.Point(640, 252);
            this.groupHatch.Name = "groupHatch";
            this.groupHatch.Size = new System.Drawing.Size(397, 108);
            this.groupHatch.TabIndex = 46;
            this.groupHatch.TabStop = false;
            // 
            // groupPicture
            // 
            this.groupPicture.Controls.Add(this.textureControl1);
            this.groupPicture.Location = new System.Drawing.Point(640, 82);
            this.groupPicture.Name = "groupPicture";
            this.groupPicture.Size = new System.Drawing.Size(397, 164);
            this.groupPicture.TabIndex = 47;
            this.groupPicture.TabStop = false;
            // 
            // iconControl1
            // 
            this.textureControl1.BackColor = System.Drawing.Color.Transparent;
            this.textureControl1.CellHeight = 48;
            this.textureControl1.CellWidth = 48;
            this.textureControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textureControl1.FilePath = "";
            this.textureControl1.Font = new System.Drawing.Font("Arial", 25.6F);
            this.textureControl1.GridColor = System.Drawing.Color.Gray;
            this.textureControl1.GridVisible = true;
            this.textureControl1.ItemCount = 0;
            this.textureControl1.Location = new System.Drawing.Point(3, 16);
            this.textureControl1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.textureControl1.Name = "textureControl1";
            this.textureControl1.SelectedIndex = -1;
            this.textureControl1.Size = new System.Drawing.Size(391, 145);
            this.textureControl1.TabIndex = 73;
            this.textureControl1.Textures = false;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(317, 352);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 26);
            this.btnApply.TabIndex = 48;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // PolygonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(621, 385);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupPicture);
            this.Controls.Add(this.groupHatch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolygonForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Polygon Style";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPolygons_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.pnlFillPicture.ResumeLayout(false);
            this.pnlFillPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udScaleX)).EndInit();
            this.groupGradient.ResumeLayout(false);
            this.pnlFillGradient.ResumeLayout(false);
            this.pnlFillGradient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udGradientRotation)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udVerticesSize)).EndInit();
            this.pnlFillHatch.ResumeLayout(false);
            this.pnlFillHatch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupHatch.ResumeLayout(false);
            this.groupPicture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pctPreview;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel pnlFillGradient;
        private NumericUpDownEx udGradientRotation;
        private System.Windows.Forms.ComboBox cboGradientBounds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboGradientType;
        private Office2007ColorPicker clpGradient2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlFillHatch;
        private ImageCombo icbHatchStyle;
        private System.Windows.Forms.CheckBox chkFillBgTransparent;
        private Office2007ColorPicker clpHatchBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private NumericUpDownEx udVerticesSize;
        private System.Windows.Forms.CheckBox chkVerticesFillVisible;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboVerticesType;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private Office2007ColorPicker clpVerticesColor;
        private System.Windows.Forms.CheckBox chkOutlineVisible;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private ImageCombo icbLineWidth;
        private ImageCombo icbLineType;
        private Office2007ColorPicker clpOutline;
        private System.Windows.Forms.CheckBox chkFillVisible;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFillType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private IconControl textureControl1;
        private Office2007ColorPicker clpFill;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlFillPicture;
        private NumericUpDownEx udScaleY;
        private System.Windows.Forms.Label label9;
        private NumericUpDownEx udScaleX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkVerticesVisible;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupGradient;
        private System.Windows.Forms.GroupBox groupHatch;
        private System.Windows.Forms.GroupBox groupPicture;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private TransparencyControl transpFill;
        private System.Windows.Forms.Label label12;
        private TransparencyControl transpOutline;
        private System.Windows.Forms.Button btnApply;

    }
}