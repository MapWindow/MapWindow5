using MW5.UI.Controls;
using MW5.UI.Enums;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Views
{
    partial class MeasuringView
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
            MW5.UI.Controls.ImageComboItem imageComboItem1 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem2 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem3 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem4 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem5 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem6 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem7 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem8 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem9 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem10 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem11 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem12 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem13 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem14 = new MW5.UI.Controls.ImageComboItem();
            MW5.UI.Controls.ImageComboItem imageComboItem15 = new MW5.UI.Controls.ImageComboItem();
            this.chkShowBearing = new System.Windows.Forms.CheckBox();
            this.chkShowLength = new System.Windows.Forms.CheckBox();
            this.cboBearingType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.udBearingPrecision = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAngleFormat = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowTotalLength = new System.Windows.Forms.CheckBox();
            this.udLengthPrecision = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLengthUnits = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAreaUnits = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.udAreaPrecision = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkShowPointLabels = new System.Windows.Forms.CheckBox();
            this.chkShowPoints = new System.Windows.Forms.CheckBox();
            this.cboLineStyle = new MW5.UI.Controls.ImageCombo();
            this.cboLineWidth = new MW5.UI.Controls.ImageCombo();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.fillTransparency = new MW5.UI.Controls.TransparencyControl();
            this.label10 = new System.Windows.Forms.Label();
            this.clpFillColor = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.clpLineColor = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPageAdv3 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPageAdv4 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ((System.ComponentModel.ISupportInitialize)(this.cboBearingType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBearingPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAngleFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLengthPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLengthUnits)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAreaPrecision)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageAdv1.SuspendLayout();
            this.tabPageAdv2.SuspendLayout();
            this.tabPageAdv3.SuspendLayout();
            this.tabPageAdv4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkShowBearing
            // 
            this.chkShowBearing.AutoSize = true;
            this.chkShowBearing.Location = new System.Drawing.Point(31, 23);
            this.chkShowBearing.Name = "chkShowBearing";
            this.chkShowBearing.Size = new System.Drawing.Size(91, 17);
            this.chkShowBearing.TabIndex = 0;
            this.chkShowBearing.Text = "Show bearing";
            this.chkShowBearing.UseVisualStyleBackColor = true;
            // 
            // chkShowLength
            // 
            this.chkShowLength.AutoSize = true;
            this.chkShowLength.Location = new System.Drawing.Point(25, 20);
            this.chkShowLength.Name = "chkShowLength";
            this.chkShowLength.Size = new System.Drawing.Size(85, 17);
            this.chkShowLength.TabIndex = 1;
            this.chkShowLength.Text = "Show length";
            this.chkShowLength.UseVisualStyleBackColor = true;
            // 
            // cboBearingType
            // 
            this.cboBearingType.BeforeTouchSize = new System.Drawing.Size(121, 21);
            this.cboBearingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBearingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboBearingType.Location = new System.Drawing.Point(158, 19);
            this.cboBearingType.Name = "cboBearingType";
            this.cboBearingType.Size = new System.Drawing.Size(121, 21);
            this.cboBearingType.TabIndex = 2;
            // 
            // udBearingPrecision
            // 
            this.udBearingPrecision.Location = new System.Drawing.Point(159, 101);
            this.udBearingPrecision.Name = "udBearingPrecision";
            this.udBearingPrecision.Size = new System.Drawing.Size(120, 20);
            this.udBearingPrecision.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Precision";
            // 
            // cboAngleFormat
            // 
            this.cboAngleFormat.BeforeTouchSize = new System.Drawing.Size(121, 21);
            this.cboAngleFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAngleFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboAngleFormat.Location = new System.Drawing.Point(158, 59);
            this.cboAngleFormat.Name = "cboAngleFormat";
            this.cboAngleFormat.Size = new System.Drawing.Size(121, 21);
            this.cboAngleFormat.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Angle format";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bearing type";
            // 
            // chkShowTotalLength
            // 
            this.chkShowTotalLength.AutoSize = true;
            this.chkShowTotalLength.Location = new System.Drawing.Point(25, 102);
            this.chkShowTotalLength.Name = "chkShowTotalLength";
            this.chkShowTotalLength.Size = new System.Drawing.Size(108, 17);
            this.chkShowTotalLength.TabIndex = 8;
            this.chkShowTotalLength.Text = "Show total length";
            this.chkShowTotalLength.UseVisualStyleBackColor = true;
            // 
            // udLengthPrecision
            // 
            this.udLengthPrecision.Location = new System.Drawing.Point(161, 67);
            this.udLengthPrecision.Name = "udLengthPrecision";
            this.udLengthPrecision.Size = new System.Drawing.Size(120, 20);
            this.udLengthPrecision.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precision";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Length units";
            // 
            // cboLengthUnits
            // 
            this.cboLengthUnits.BeforeTouchSize = new System.Drawing.Size(121, 21);
            this.cboLengthUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLengthUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboLengthUnits.Location = new System.Drawing.Point(160, 30);
            this.cboLengthUnits.Name = "cboLengthUnits";
            this.cboLengthUnits.Size = new System.Drawing.Size(121, 21);
            this.cboLengthUnits.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(263, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 26);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(359, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboLengthUnits);
            this.groupBox1.Controls.Add(this.chkShowTotalLength);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.udLengthPrecision);
            this.groupBox1.Location = new System.Drawing.Point(14, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 136);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // cboAreaUnits
            // 
            this.cboAreaUnits.BeforeTouchSize = new System.Drawing.Size(150, 21);
            this.cboAreaUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreaUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboAreaUnits.Location = new System.Drawing.Point(149, 35);
            this.cboAreaUnits.Name = "cboAreaUnits";
            this.cboAreaUnits.Size = new System.Drawing.Size(150, 21);
            this.cboAreaUnits.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Precision";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Area units";
            // 
            // udAreaPrecision
            // 
            this.udAreaPrecision.Location = new System.Drawing.Point(149, 72);
            this.udAreaPrecision.Name = "udAreaPrecision";
            this.udAreaPrecision.Size = new System.Drawing.Size(150, 20);
            this.udAreaPrecision.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.udBearingPrecision);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboBearingType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboAngleFormat);
            this.groupBox2.Location = new System.Drawing.Point(20, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 142);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // chkShowPointLabels
            // 
            this.chkShowPointLabels.AutoSize = true;
            this.chkShowPointLabels.Location = new System.Drawing.Point(131, 170);
            this.chkShowPointLabels.Name = "chkShowPointLabels";
            this.chkShowPointLabels.Size = new System.Drawing.Size(109, 17);
            this.chkShowPointLabels.TabIndex = 11;
            this.chkShowPointLabels.Text = "Show point labels";
            this.chkShowPointLabels.UseVisualStyleBackColor = true;
            // 
            // chkShowPoints
            // 
            this.chkShowPoints.AutoSize = true;
            this.chkShowPoints.Location = new System.Drawing.Point(30, 170);
            this.chkShowPoints.Name = "chkShowPoints";
            this.chkShowPoints.Size = new System.Drawing.Size(84, 17);
            this.chkShowPoints.TabIndex = 10;
            this.chkShowPoints.Text = "Show points";
            this.chkShowPoints.UseVisualStyleBackColor = true;
            // 
            // cboLineStyle
            // 
            this.cboLineStyle.Color1 = System.Drawing.Color.Gray;
            this.cboLineStyle.Color2 = System.Drawing.Color.Gray;
            this.cboLineStyle.ComboStyle = MW5.UI.Enums.ImageComboStyle.LineStyle;
            this.cboLineStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineStyle.FormattingEnabled = true;
            imageComboItem1.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem1.ImageIndex = 0;
            imageComboItem1.Mark = false;
            imageComboItem1.Tag = null;
            imageComboItem1.Text = "";
            imageComboItem2.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem2.ImageIndex = 1;
            imageComboItem2.Mark = false;
            imageComboItem2.Tag = null;
            imageComboItem2.Text = "";
            imageComboItem3.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem3.ImageIndex = 2;
            imageComboItem3.Mark = false;
            imageComboItem3.Tag = null;
            imageComboItem3.Text = "";
            imageComboItem4.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem4.ImageIndex = 3;
            imageComboItem4.Mark = false;
            imageComboItem4.Tag = null;
            imageComboItem4.Text = "";
            imageComboItem5.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem5.ImageIndex = 4;
            imageComboItem5.Mark = false;
            imageComboItem5.Tag = null;
            imageComboItem5.Text = "";
            this.cboLineStyle.Items.AddRange(new object[] {
            imageComboItem1,
            imageComboItem2,
            imageComboItem3,
            imageComboItem4,
            imageComboItem5});
            this.cboLineStyle.Location = new System.Drawing.Point(237, 76);
            this.cboLineStyle.Name = "cboLineStyle";
            this.cboLineStyle.OutlineColor = System.Drawing.Color.Black;
            this.cboLineStyle.Size = new System.Drawing.Size(86, 21);
            this.cboLineStyle.TabIndex = 9;
            // 
            // cboLineWidth
            // 
            this.cboLineWidth.Color1 = System.Drawing.Color.Gray;
            this.cboLineWidth.Color2 = System.Drawing.Color.Gray;
            this.cboLineWidth.ComboStyle = MW5.UI.Enums.ImageComboStyle.LineWidth;
            this.cboLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineWidth.FormattingEnabled = true;
            imageComboItem6.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem6.ImageIndex = 0;
            imageComboItem6.Mark = false;
            imageComboItem6.Tag = null;
            imageComboItem6.Text = "";
            imageComboItem7.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem7.ImageIndex = 1;
            imageComboItem7.Mark = false;
            imageComboItem7.Tag = null;
            imageComboItem7.Text = "";
            imageComboItem8.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem8.ImageIndex = 2;
            imageComboItem8.Mark = false;
            imageComboItem8.Tag = null;
            imageComboItem8.Text = "";
            imageComboItem9.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem9.ImageIndex = 3;
            imageComboItem9.Mark = false;
            imageComboItem9.Tag = null;
            imageComboItem9.Text = "";
            imageComboItem10.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem10.ImageIndex = 4;
            imageComboItem10.Mark = false;
            imageComboItem10.Tag = null;
            imageComboItem10.Text = "";
            imageComboItem11.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem11.ImageIndex = 5;
            imageComboItem11.Mark = false;
            imageComboItem11.Tag = null;
            imageComboItem11.Text = "";
            imageComboItem12.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem12.ImageIndex = 6;
            imageComboItem12.Mark = false;
            imageComboItem12.Tag = null;
            imageComboItem12.Text = "";
            imageComboItem13.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem13.ImageIndex = 7;
            imageComboItem13.Mark = false;
            imageComboItem13.Tag = null;
            imageComboItem13.Text = "";
            imageComboItem14.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem14.ImageIndex = 8;
            imageComboItem14.Mark = false;
            imageComboItem14.Tag = null;
            imageComboItem14.Text = "";
            imageComboItem15.ForeColor = System.Drawing.Color.Transparent;
            imageComboItem15.ImageIndex = 9;
            imageComboItem15.Mark = false;
            imageComboItem15.Tag = null;
            imageComboItem15.Text = "";
            this.cboLineWidth.Items.AddRange(new object[] {
            imageComboItem6,
            imageComboItem7,
            imageComboItem8,
            imageComboItem9,
            imageComboItem10,
            imageComboItem11,
            imageComboItem12,
            imageComboItem13,
            imageComboItem14,
            imageComboItem15});
            this.cboLineWidth.Location = new System.Drawing.Point(237, 35);
            this.cboLineWidth.Name = "cboLineWidth";
            this.cboLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.cboLineWidth.Size = new System.Drawing.Size(86, 21);
            this.cboLineWidth.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(176, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Line style";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(176, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Line width";
            // 
            // fillTransparency
            // 
            this.fillTransparency.BandColor = System.Drawing.Color.Empty;
            this.fillTransparency.Location = new System.Drawing.Point(133, 118);
            this.fillTransparency.MaximumSize = new System.Drawing.Size(1024, 32);
            this.fillTransparency.MinimumSize = new System.Drawing.Size(128, 32);
            this.fillTransparency.Name = "fillTransparency";
            this.fillTransparency.Size = new System.Drawing.Size(190, 32);
            this.fillTransparency.TabIndex = 5;
            this.fillTransparency.Value = ((byte)(255));
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Fill transparency";
            // 
            // clpFillColor
            // 
            this.clpFillColor.Color = System.Drawing.Color.Black;
            this.clpFillColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFillColor.DropDownHeight = 1;
            this.clpFillColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFillColor.FormattingEnabled = true;
            this.clpFillColor.IntegralHeight = false;
            this.clpFillColor.Items.AddRange(new object[] {
            "Color"});
            this.clpFillColor.Location = new System.Drawing.Point(82, 76);
            this.clpFillColor.Name = "clpFillColor";
            this.clpFillColor.Size = new System.Drawing.Size(79, 21);
            this.clpFillColor.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Fill color";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Line color";
            // 
            // clpLineColor
            // 
            this.clpLineColor.Color = System.Drawing.Color.Black;
            this.clpLineColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpLineColor.DropDownHeight = 1;
            this.clpLineColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpLineColor.FormattingEnabled = true;
            this.clpLineColor.IntegralHeight = false;
            this.clpLineColor.Items.AddRange(new object[] {
            "Color"});
            this.clpLineColor.Location = new System.Drawing.Point(82, 35);
            this.clpLineColor.Name = "clpLineColor";
            this.clpLineColor.Size = new System.Drawing.Size(79, 21);
            this.clpLineColor.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(445, 234);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv1);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv2);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv3);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv4);
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(100, 50);
            this.tabControlAdv1.Location = new System.Drawing.Point(1, 12);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(445, 234);
            this.tabControlAdv1.TabIndex = 8;
            // 
            // tabPageAdv1
            // 
            this.tabPageAdv1.Controls.Add(this.groupBox1);
            this.tabPageAdv1.Controls.Add(this.chkShowLength);
            this.tabPageAdv1.Image = global::MW5.Properties.Resources.img_measure_length;
            this.tabPageAdv1.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageAdv1.Location = new System.Drawing.Point(103, 1);
            this.tabPageAdv1.Name = "tabPageAdv1";
            this.tabPageAdv1.ShowCloseButton = true;
            this.tabPageAdv1.Size = new System.Drawing.Size(340, 231);
            this.tabPageAdv1.TabIndex = 1;
            this.tabPageAdv1.Text = "Length";
            this.tabPageAdv1.ThemesEnabled = false;
            // 
            // tabPageAdv2
            // 
            this.tabPageAdv2.Controls.Add(this.cboAreaUnits);
            this.tabPageAdv2.Controls.Add(this.label5);
            this.tabPageAdv2.Controls.Add(this.udAreaPrecision);
            this.tabPageAdv2.Controls.Add(this.label7);
            this.tabPageAdv2.Image = global::MW5.Properties.Resources.icon_measure_area;
            this.tabPageAdv2.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageAdv2.Location = new System.Drawing.Point(103, 1);
            this.tabPageAdv2.Name = "tabPageAdv2";
            this.tabPageAdv2.ShowCloseButton = true;
            this.tabPageAdv2.Size = new System.Drawing.Size(340, 231);
            this.tabPageAdv2.TabIndex = 2;
            this.tabPageAdv2.Text = "Area";
            this.tabPageAdv2.ThemesEnabled = false;
            // 
            // tabPageAdv3
            // 
            this.tabPageAdv3.Controls.Add(this.groupBox2);
            this.tabPageAdv3.Controls.Add(this.chkShowBearing);
            this.tabPageAdv3.Image = global::MW5.Properties.Resources.img_compass;
            this.tabPageAdv3.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageAdv3.Location = new System.Drawing.Point(103, 1);
            this.tabPageAdv3.Name = "tabPageAdv3";
            this.tabPageAdv3.ShowCloseButton = true;
            this.tabPageAdv3.Size = new System.Drawing.Size(340, 231);
            this.tabPageAdv3.TabIndex = 3;
            this.tabPageAdv3.Text = "Bearing";
            this.tabPageAdv3.ThemesEnabled = false;
            // 
            // tabPageAdv4
            // 
            this.tabPageAdv4.Controls.Add(this.chkShowPointLabels);
            this.tabPageAdv4.Controls.Add(this.label8);
            this.tabPageAdv4.Controls.Add(this.chkShowPoints);
            this.tabPageAdv4.Controls.Add(this.clpLineColor);
            this.tabPageAdv4.Controls.Add(this.cboLineStyle);
            this.tabPageAdv4.Controls.Add(this.label9);
            this.tabPageAdv4.Controls.Add(this.cboLineWidth);
            this.tabPageAdv4.Controls.Add(this.clpFillColor);
            this.tabPageAdv4.Controls.Add(this.label12);
            this.tabPageAdv4.Controls.Add(this.label10);
            this.tabPageAdv4.Controls.Add(this.label11);
            this.tabPageAdv4.Controls.Add(this.fillTransparency);
            this.tabPageAdv4.Image = global::MW5.Properties.Resources.img_palette;
            this.tabPageAdv4.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageAdv4.Location = new System.Drawing.Point(103, 1);
            this.tabPageAdv4.Name = "tabPageAdv4";
            this.tabPageAdv4.ShowCloseButton = true;
            this.tabPageAdv4.Size = new System.Drawing.Size(340, 231);
            this.tabPageAdv4.TabIndex = 4;
            this.tabPageAdv4.Text = "Style";
            this.tabPageAdv4.ThemesEnabled = false;
            // 
            // MeasuringView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 281);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MeasuringView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Measuring options";
            ((System.ComponentModel.ISupportInitialize)(this.cboBearingType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udBearingPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAngleFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLengthPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLengthUnits)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAreaPrecision)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageAdv1.ResumeLayout(false);
            this.tabPageAdv1.PerformLayout();
            this.tabPageAdv2.ResumeLayout(false);
            this.tabPageAdv2.PerformLayout();
            this.tabPageAdv3.ResumeLayout(false);
            this.tabPageAdv3.PerformLayout();
            this.tabPageAdv4.ResumeLayout(false);
            this.tabPageAdv4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowBearing;
        private System.Windows.Forms.CheckBox chkShowLength;
        private ComboBoxAdv cboBearingType;
        private System.Windows.Forms.NumericUpDown udBearingPrecision;
        private System.Windows.Forms.Label label3;
        private ComboBoxAdv cboAngleFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowTotalLength;
        private System.Windows.Forms.NumericUpDown udLengthPrecision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private ComboBoxAdv cboLengthUnits;
        private ButtonAdv btnOk;
        private ButtonAdv btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComboBoxAdv cboAreaUnits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown udAreaPrecision;
        private System.Windows.Forms.Label label10;
        private Office2007ColorPicker clpFillColor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Office2007ColorPicker clpLineColor;
        private TransparencyControl fillTransparency;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkShowPointLabels;
        private System.Windows.Forms.CheckBox chkShowPoints;
        private ImageCombo cboLineStyle;
        private ImageCombo cboLineWidth;
        private TabControlAdv tabControlAdv1;
        private TabPageAdv tabPageAdv1;
        private TabPageAdv tabPageAdv2;
        private TabPageAdv tabPageAdv3;
        private TabPageAdv tabPageAdv4;
    }
}