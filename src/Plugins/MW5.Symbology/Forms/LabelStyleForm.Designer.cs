// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System.Windows.Forms;
using MW5.Plugins.Symbology.Controls;
using MW5.UI.Controls;
using MW5.UI.Enums;

namespace MW5.Plugins.Symbology.Forms
{
    partial class LabelStyleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelStyleForm));
            this.chkLogScaleForSize = new System.Windows.Forms.CheckBox();
            this.chkUseVariableSize = new System.Windows.Forms.CheckBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboDecimalPlaces = new System.Windows.Forms.ComboBox();
            this.chkSortAscending = new System.Windows.Forms.CheckBox();
            this.cboSortField = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnNewLine = new System.Windows.Forms.Button();
            this.btnQuotes = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtExpression = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnSetCurrent = new System.Windows.Forms.Button();
            this.cboBasicScale = new System.Windows.Forms.ComboBox();
            this.chkScaleLabels = new System.Windows.Forms.CheckBox();
            this.cboTextRenderingHint = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cboFontName = new System.Windows.Forms.ComboBox();
            this.chkFontStrikeout = new System.Windows.Forms.CheckBox();
            this.chkFontUnderline = new System.Windows.Forms.CheckBox();
            this.chkFontItalic = new System.Windows.Forms.CheckBox();
            this.clpFont1 = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.chkFontBold = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.udShadowOffsetY = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udShadowOffsetX = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udHaloSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.clpShadow = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.clpHalo = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.chkShadowVisible = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkHaloVisible = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.udFramePaddingY = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.udFramePaddingX = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetFrameGradient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.icbFrameType = new MW5.UI.Controls.ImageCombo();
            this.clpFrame1 = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.chkUseFrame = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.icbLineWidth = new MW5.UI.Controls.ImageCombo();
            this.icbLineType = new MW5.UI.Controls.ImageCombo();
            this.clpFrameBorder = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.groupLabelAlignment = new System.Windows.Forms.GroupBox();
            this.udLabelOffsetY = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udLabelOffsetX = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udLabelsBuffer = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.optAlignBottomRight = new System.Windows.Forms.RadioButton();
            this.lblLabelsOffsetY = new System.Windows.Forms.Label();
            this.optAlignBottomCenter = new System.Windows.Forms.RadioButton();
            this.lblLabelsOffsetX = new System.Windows.Forms.Label();
            this.optAlignBottomLeft = new System.Windows.Forms.RadioButton();
            this.optAlignCenterRight = new System.Windows.Forms.RadioButton();
            this.optAlignCenter = new System.Windows.Forms.RadioButton();
            this.optAlignCenterLeft = new System.Windows.Forms.RadioButton();
            this.optAlignTopRight = new System.Windows.Forms.RadioButton();
            this.optAlignTopCenter = new System.Windows.Forms.RadioButton();
            this.optAlignTopLeft = new System.Windows.Forms.RadioButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtLabelExpression = new System.Windows.Forms.TextBox();
            this.btnLabelExpression = new System.Windows.Forms.Button();
            this.btnClearLabelsExpression = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pctPreview = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.udFontSize2 = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.transparencyControl1 = new MW5.UI.Controls.TransparencyControl();
            this.udFontSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.lblResult = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabMain = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.chkAviodCollisions = new System.Windows.Forms.CheckBox();
            this.chkLabelsRemoveDuplicates = new System.Windows.Forms.CheckBox();
            this.lblLabelVerticalPosition = new System.Windows.Forms.Label();
            this.cboLabelsVerticalPosition = new System.Windows.Forms.ComboBox();
            this.tabExpression = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPosition = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.groupBoxPositioning = new System.Windows.Forms.GroupBox();
            this.chkLabelEveryPart = new System.Windows.Forms.CheckBox();
            this.cboLineOrientation = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.optPosition4 = new System.Windows.Forms.RadioButton();
            this.optPosition3 = new System.Windows.Forms.RadioButton();
            this.optPosition2 = new System.Windows.Forms.RadioButton();
            this.optPosition1 = new System.Windows.Forms.RadioButton();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.comboOffsetY = new System.Windows.Forms.ComboBox();
            this.comboOffsetX = new System.Windows.Forms.ComboBox();
            this.labelOffsetYField = new System.Windows.Forms.Label();
            this.labelOffsetXField = new System.Windows.Forms.Label();
            this.tabVisibility = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.dynamicVisibilityControl1 = new MW5.Plugins.Symbology.Controls.DynamicVisibilityControl();
            this.tabFont = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabFrame = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udShadowOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udShadowOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHaloSize)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udFramePaddingY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFramePaddingX)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupLabelAlignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLabelOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLabelOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLabelsBuffer)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udFontSize2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.tabExpression.SuspendLayout();
            this.tabPosition.SuspendLayout();
            this.groupBoxPositioning.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabVisibility.SuspendLayout();
            this.tabFont.SuspendLayout();
            this.tabFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLogScaleForSize
            // 
            this.chkLogScaleForSize.AutoSize = true;
            this.chkLogScaleForSize.Location = new System.Drawing.Point(347, 186);
            this.chkLogScaleForSize.Margin = new System.Windows.Forms.Padding(4);
            this.chkLogScaleForSize.Name = "chkLogScaleForSize";
            this.chkLogScaleForSize.Size = new System.Drawing.Size(140, 21);
            this.chkLogScaleForSize.TabIndex = 55;
            this.chkLogScaleForSize.Text = "Logarithmic scale";
            this.chkLogScaleForSize.UseVisualStyleBackColor = true;
            this.chkLogScaleForSize.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkUseVariableSize
            // 
            this.chkUseVariableSize.AutoSize = true;
            this.chkUseVariableSize.Location = new System.Drawing.Point(188, 186);
            this.chkUseVariableSize.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseVariableSize.Name = "chkUseVariableSize";
            this.chkUseVariableSize.Size = new System.Drawing.Size(138, 21);
            this.chkUseVariableSize.TabIndex = 54;
            this.chkUseVariableSize.Text = "Use variable size";
            this.chkUseVariableSize.UseVisualStyleBackColor = true;
            this.chkUseVariableSize.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(181, 17);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(306, 15);
            this.label33.TabIndex = 51;
            this.label33.Text = " (To generate multi-field labels use the expression tab.)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(38, 67);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(187, 17);
            this.label18.TabIndex = 50;
            this.label18.Text = "Decimal places for numbers:";
            // 
            // cboDecimalPlaces
            // 
            this.cboDecimalPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDecimalPlaces.FormattingEnabled = true;
            this.cboDecimalPlaces.Location = new System.Drawing.Point(42, 86);
            this.cboDecimalPlaces.Margin = new System.Windows.Forms.Padding(4);
            this.cboDecimalPlaces.Name = "cboDecimalPlaces";
            this.cboDecimalPlaces.Size = new System.Drawing.Size(448, 24);
            this.cboDecimalPlaces.TabIndex = 49;
            this.cboDecimalPlaces.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkSortAscending
            // 
            this.chkSortAscending.AutoSize = true;
            this.chkSortAscending.Location = new System.Drawing.Point(41, 186);
            this.chkSortAscending.Margin = new System.Windows.Forms.Padding(4);
            this.chkSortAscending.Name = "chkSortAscending";
            this.chkSortAscending.Size = new System.Drawing.Size(125, 21);
            this.chkSortAscending.TabIndex = 4;
            this.chkSortAscending.Text = "Sort ascending";
            this.chkSortAscending.UseVisualStyleBackColor = true;
            this.chkSortAscending.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // cboSortField
            // 
            this.cboSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboSortField.Location = new System.Drawing.Point(41, 152);
            this.cboSortField.Margin = new System.Windows.Forms.Padding(4);
            this.cboSortField.Name = "cboSortField";
            this.cboSortField.Size = new System.Drawing.Size(448, 25);
            this.cboSortField.TabIndex = 3;
            this.cboSortField.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(37, 133);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 17);
            this.label24.TabIndex = 2;
            this.label24.Text = "Sort field:";
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboField.Location = new System.Drawing.Point(41, 38);
            this.cboField.Margin = new System.Windows.Forms.Padding(4);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(448, 25);
            this.cboField.TabIndex = 1;
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(37, 17);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 17);
            this.label22.TabIndex = 0;
            this.label22.Text = "Label field:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Location = new System.Drawing.Point(303, 297);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox10.Size = new System.Drawing.Size(212, 68);
            this.groupBox10.TabIndex = 46;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Description";
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(4, 19);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(204, 45);
            this.label13.TabIndex = 0;
            this.label13.Text = "[Area], [Quant]  - fields, \"ha\", \"thnds.\" - string literals";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Location = new System.Drawing.Point(303, 225);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox9.Size = new System.Drawing.Size(212, 64);
            this.groupBox9.TabIndex = 45;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Example";
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(4, 19);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 41);
            this.label11.TabIndex = 0;
            this.label11.Text = "[Area] + \"ha\" +                          [Quant]/1000 + \"thnds.\"";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(415, 149);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 31);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnClearClick);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Location = new System.Drawing.Point(384, 187);
            this.btnNewLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(129, 31);
            this.btnNewLine.TabIndex = 42;
            this.btnNewLine.Text = "New line";
            this.btnNewLine.UseVisualStyleBackColor = true;
            this.btnNewLine.Click += new System.EventHandler(this.OnNewLineClick);
            // 
            // btnQuotes
            // 
            this.btnQuotes.Location = new System.Drawing.Point(341, 187);
            this.btnQuotes.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuotes.Name = "btnQuotes";
            this.btnQuotes.Size = new System.Drawing.Size(37, 31);
            this.btnQuotes.TabIndex = 41;
            this.btnQuotes.Text = "\" \"";
            this.btnQuotes.UseVisualStyleBackColor = true;
            this.btnQuotes.Click += new System.EventHandler(this.OnQuotesClick);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(299, 187);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(37, 31);
            this.btnPlus.TabIndex = 40;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.OnPlusClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listBox1);
            this.groupBox7.Location = new System.Drawing.Point(20, 149);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(267, 215);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Fields";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(4, 19);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(259, 192);
            this.listBox1.TabIndex = 37;
            this.listBox1.DoubleClick += new System.EventHandler(this.OnFieldListBoxDoubleClick);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtExpression);
            this.groupBox8.Location = new System.Drawing.Point(20, 15);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(495, 127);
            this.groupBox8.TabIndex = 38;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Expression";
            // 
            // txtExpression
            // 
            this.txtExpression.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpression.Location = new System.Drawing.Point(4, 19);
            this.txtExpression.Margin = new System.Windows.Forms.Padding(4);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(487, 104);
            this.txtExpression.TabIndex = 15;
            this.txtExpression.Text = "";
            this.txtExpression.TextChanged += new System.EventHandler(this.OnExpressionChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSetCurrent);
            this.groupBox5.Controls.Add(this.cboBasicScale);
            this.groupBox5.Controls.Add(this.chkScaleLabels);
            this.groupBox5.Controls.Add(this.cboTextRenderingHint);
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label35);
            this.groupBox5.Controls.Add(this.cboFontName);
            this.groupBox5.Controls.Add(this.chkFontStrikeout);
            this.groupBox5.Controls.Add(this.chkFontUnderline);
            this.groupBox5.Controls.Add(this.chkFontItalic);
            this.groupBox5.Controls.Add(this.clpFont1);
            this.groupBox5.Controls.Add(this.chkFontBold);
            this.groupBox5.Location = new System.Drawing.Point(20, 17);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(491, 211);
            this.groupBox5.TabIndex = 123;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Font style";
            // 
            // btnSetCurrent
            // 
            this.btnSetCurrent.Location = new System.Drawing.Point(274, 168);
            this.btnSetCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetCurrent.Name = "btnSetCurrent";
            this.btnSetCurrent.Size = new System.Drawing.Size(85, 28);
            this.btnSetCurrent.TabIndex = 131;
            this.btnSetCurrent.Text = "Current";
            this.btnSetCurrent.UseVisualStyleBackColor = true;
            this.btnSetCurrent.Click += new System.EventHandler(this.btnSetCurrent_Click);
            // 
            // cboBasicScale
            // 
            this.cboBasicScale.FormattingEnabled = true;
            this.cboBasicScale.Location = new System.Drawing.Point(23, 168);
            this.cboBasicScale.Margin = new System.Windows.Forms.Padding(4);
            this.cboBasicScale.Name = "cboBasicScale";
            this.cboBasicScale.Size = new System.Drawing.Size(237, 24);
            this.cboBasicScale.TabIndex = 130;
            this.cboBasicScale.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkScaleLabels
            // 
            this.chkScaleLabels.AutoSize = true;
            this.chkScaleLabels.Location = new System.Drawing.Point(23, 139);
            this.chkScaleLabels.Margin = new System.Windows.Forms.Padding(4);
            this.chkScaleLabels.Name = "chkScaleLabels";
            this.chkScaleLabels.Size = new System.Drawing.Size(245, 21);
            this.chkScaleLabels.TabIndex = 128;
            this.chkScaleLabels.Text = "Increase font size from map scale:";
            this.chkScaleLabels.UseVisualStyleBackColor = true;
            this.chkScaleLabels.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // cboTextRenderingHint
            // 
            this.cboTextRenderingHint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextRenderingHint.FormattingEnabled = true;
            this.cboTextRenderingHint.Location = new System.Drawing.Point(131, 101);
            this.cboTextRenderingHint.Margin = new System.Windows.Forms.Padding(4);
            this.cboTextRenderingHint.Name = "cboTextRenderingHint";
            this.cboTextRenderingHint.Size = new System.Drawing.Size(341, 24);
            this.cboTextRenderingHint.TabIndex = 127;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(20, 104);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(101, 17);
            this.label32.TabIndex = 126;
            this.label32.Text = "Rendering hint";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 17);
            this.label8.TabIndex = 64;
            this.label8.Text = "Color";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(20, 29);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(36, 17);
            this.label35.TabIndex = 61;
            this.label35.Text = "Font";
            // 
            // cboFontName
            // 
            this.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontName.FormattingEnabled = true;
            this.cboFontName.Location = new System.Drawing.Point(88, 26);
            this.cboFontName.Margin = new System.Windows.Forms.Padding(4);
            this.cboFontName.Name = "cboFontName";
            this.cboFontName.Size = new System.Drawing.Size(235, 24);
            this.cboFontName.TabIndex = 58;
            this.cboFontName.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkFontStrikeout
            // 
            this.chkFontStrikeout.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFontStrikeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkFontStrikeout.Image = ((System.Drawing.Image)(resources.GetObject("chkFontStrikeout.Image")));
            this.chkFontStrikeout.Location = new System.Drawing.Point(224, 59);
            this.chkFontStrikeout.Margin = new System.Windows.Forms.Padding(4);
            this.chkFontStrikeout.Name = "chkFontStrikeout";
            this.chkFontStrikeout.Size = new System.Drawing.Size(36, 32);
            this.chkFontStrikeout.TabIndex = 57;
            this.chkFontStrikeout.UseVisualStyleBackColor = true;
            this.chkFontStrikeout.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkFontUnderline
            // 
            this.chkFontUnderline.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFontUnderline.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFontUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkFontUnderline.Image = ((System.Drawing.Image)(resources.GetObject("chkFontUnderline.Image")));
            this.chkFontUnderline.Location = new System.Drawing.Point(177, 59);
            this.chkFontUnderline.Margin = new System.Windows.Forms.Padding(4);
            this.chkFontUnderline.Name = "chkFontUnderline";
            this.chkFontUnderline.Size = new System.Drawing.Size(37, 32);
            this.chkFontUnderline.TabIndex = 56;
            this.chkFontUnderline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFontUnderline.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkFontUnderline.UseVisualStyleBackColor = true;
            this.chkFontUnderline.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkFontItalic
            // 
            this.chkFontItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFontItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkFontItalic.Image = ((System.Drawing.Image)(resources.GetObject("chkFontItalic.Image")));
            this.chkFontItalic.Location = new System.Drawing.Point(87, 59);
            this.chkFontItalic.Margin = new System.Windows.Forms.Padding(4);
            this.chkFontItalic.Name = "chkFontItalic";
            this.chkFontItalic.Size = new System.Drawing.Size(35, 32);
            this.chkFontItalic.TabIndex = 55;
            this.chkFontItalic.UseVisualStyleBackColor = true;
            this.chkFontItalic.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // clpFont1
            // 
            this.clpFont1.Color = System.Drawing.Color.Black;
            this.clpFont1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFont1.DropDownHeight = 1;
            this.clpFont1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFont1.FormattingEnabled = true;
            this.clpFont1.IntegralHeight = false;
            this.clpFont1.Items.AddRange(new object[] {
            "Color"});
            this.clpFont1.Location = new System.Drawing.Point(407, 26);
            this.clpFont1.Margin = new System.Windows.Forms.Padding(4);
            this.clpFont1.Name = "clpFont1";
            this.clpFont1.Size = new System.Drawing.Size(65, 23);
            this.clpFont1.TabIndex = 103;
            this.clpFont1.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkFontBold
            // 
            this.chkFontBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFontBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkFontBold.Image = ((System.Drawing.Image)(resources.GetObject("chkFontBold.Image")));
            this.chkFontBold.Location = new System.Drawing.Point(131, 59);
            this.chkFontBold.Margin = new System.Windows.Forms.Padding(4);
            this.chkFontBold.Name = "chkFontBold";
            this.chkFontBold.Size = new System.Drawing.Size(37, 32);
            this.chkFontBold.TabIndex = 54;
            this.chkFontBold.UseVisualStyleBackColor = true;
            this.chkFontBold.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.udShadowOffsetY);
            this.groupBox3.Controls.Add(this.udShadowOffsetX);
            this.groupBox3.Controls.Add(this.udHaloSize);
            this.groupBox3.Controls.Add(this.clpShadow);
            this.groupBox3.Controls.Add(this.clpHalo);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.chkShadowVisible);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.chkHaloVisible);
            this.groupBox3.Location = new System.Drawing.Point(20, 236);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(491, 145);
            this.groupBox3.TabIndex = 122;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Outline";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(225, 101);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 17);
            this.label9.TabIndex = 122;
            this.label9.Text = "Offset Y";
            // 
            // udShadowOffsetY
            // 
            this.udShadowOffsetY.Location = new System.Drawing.Point(290, 99);
            this.udShadowOffsetY.Margin = new System.Windows.Forms.Padding(4);
            this.udShadowOffsetY.Name = "udShadowOffsetY";
            this.udShadowOffsetY.Size = new System.Drawing.Size(69, 22);
            this.udShadowOffsetY.TabIndex = 121;
            this.udShadowOffsetY.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // udShadowOffsetX
            // 
            this.udShadowOffsetX.Location = new System.Drawing.Point(290, 69);
            this.udShadowOffsetX.Margin = new System.Windows.Forms.Padding(4);
            this.udShadowOffsetX.Name = "udShadowOffsetX";
            this.udShadowOffsetX.Size = new System.Drawing.Size(69, 22);
            this.udShadowOffsetX.TabIndex = 120;
            this.udShadowOffsetX.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // udHaloSize
            // 
            this.udHaloSize.Location = new System.Drawing.Point(290, 33);
            this.udHaloSize.Margin = new System.Windows.Forms.Padding(4);
            this.udHaloSize.Name = "udHaloSize";
            this.udHaloSize.Size = new System.Drawing.Size(69, 22);
            this.udHaloSize.TabIndex = 119;
            this.udHaloSize.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // clpShadow
            // 
            this.clpShadow.Color = System.Drawing.Color.Black;
            this.clpShadow.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpShadow.DropDownHeight = 1;
            this.clpShadow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpShadow.FormattingEnabled = true;
            this.clpShadow.IntegralHeight = false;
            this.clpShadow.Items.AddRange(new object[] {
            "Color"});
            this.clpShadow.Location = new System.Drawing.Point(121, 69);
            this.clpShadow.Margin = new System.Windows.Forms.Padding(4);
            this.clpShadow.Name = "clpShadow";
            this.clpShadow.Size = new System.Drawing.Size(88, 23);
            this.clpShadow.TabIndex = 118;
            this.clpShadow.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // clpHalo
            // 
            this.clpHalo.Color = System.Drawing.Color.Black;
            this.clpHalo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpHalo.DropDownHeight = 1;
            this.clpHalo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpHalo.FormattingEnabled = true;
            this.clpHalo.IntegralHeight = false;
            this.clpHalo.Items.AddRange(new object[] {
            "Color"});
            this.clpHalo.Location = new System.Drawing.Point(121, 31);
            this.clpHalo.Margin = new System.Windows.Forms.Padding(4);
            this.clpHalo.Name = "clpHalo";
            this.clpHalo.Size = new System.Drawing.Size(89, 23);
            this.clpHalo.TabIndex = 117;
            this.clpHalo.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 71);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 17);
            this.label12.TabIndex = 115;
            this.label12.Text = "Offset X";
            // 
            // chkShadowVisible
            // 
            this.chkShadowVisible.AutoSize = true;
            this.chkShadowVisible.Location = new System.Drawing.Point(23, 68);
            this.chkShadowVisible.Margin = new System.Windows.Forms.Padding(4);
            this.chkShadowVisible.Name = "chkShadowVisible";
            this.chkShadowVisible.Size = new System.Drawing.Size(80, 21);
            this.chkShadowVisible.TabIndex = 113;
            this.chkShadowVisible.Text = "Shadow";
            this.chkShadowVisible.UseVisualStyleBackColor = true;
            this.chkShadowVisible.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(247, 34);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 17);
            this.label15.TabIndex = 112;
            this.label15.Text = "Size";
            // 
            // chkHaloVisible
            // 
            this.chkHaloVisible.AutoSize = true;
            this.chkHaloVisible.Location = new System.Drawing.Point(23, 32);
            this.chkHaloVisible.Margin = new System.Windows.Forms.Padding(4);
            this.chkHaloVisible.Name = "chkHaloVisible";
            this.chkHaloVisible.Size = new System.Drawing.Size(59, 21);
            this.chkHaloVisible.TabIndex = 111;
            this.chkHaloVisible.Text = "Halo";
            this.chkHaloVisible.UseVisualStyleBackColor = true;
            this.chkHaloVisible.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.udFramePaddingY);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.udFramePaddingX);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnSetFrameGradient);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.icbFrameType);
            this.groupBox4.Controls.Add(this.clpFrame1);
            this.groupBox4.Location = new System.Drawing.Point(27, 50);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(491, 182);
            this.groupBox4.TabIndex = 142;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Style";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 126);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 17);
            this.label10.TabIndex = 135;
            this.label10.Text = "X:";
            // 
            // udFramePaddingY
            // 
            this.udFramePaddingY.Location = new System.Drawing.Point(339, 123);
            this.udFramePaddingY.Margin = new System.Windows.Forms.Padding(4);
            this.udFramePaddingY.Name = "udFramePaddingY";
            this.udFramePaddingY.Size = new System.Drawing.Size(72, 22);
            this.udFramePaddingY.TabIndex = 134;
            this.udFramePaddingY.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 118;
            this.label4.Text = "Frame type";
            // 
            // udFramePaddingX
            // 
            this.udFramePaddingX.Location = new System.Drawing.Point(203, 123);
            this.udFramePaddingX.Margin = new System.Windows.Forms.Padding(4);
            this.udFramePaddingX.Name = "udFramePaddingX";
            this.udFramePaddingX.Size = new System.Drawing.Size(72, 22);
            this.udFramePaddingX.TabIndex = 133;
            this.udFramePaddingX.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 132;
            this.label2.Text = "Y:";
            // 
            // btnSetFrameGradient
            // 
            this.btnSetFrameGradient.Location = new System.Drawing.Point(299, 70);
            this.btnSetFrameGradient.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetFrameGradient.Name = "btnSetFrameGradient";
            this.btnSetFrameGradient.Size = new System.Drawing.Size(112, 26);
            this.btnSetFrameGradient.TabIndex = 117;
            this.btnSetFrameGradient.Text = "Gradient...";
            this.btnSetFrameGradient.UseVisualStyleBackColor = true;
            this.btnSetFrameGradient.Click += new System.EventHandler(this.OnSetFrameGradientClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 131;
            this.label1.Text = "Padding";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(37, 75);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 17);
            this.label21.TabIndex = 78;
            this.label21.Text = "Color";
            // 
            // icbFrameType
            // 
            this.icbFrameType.Color1 = System.Drawing.Color.Blue;
            this.icbFrameType.Color2 = System.Drawing.Color.Honeydew;
            this.icbFrameType.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbFrameType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbFrameType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbFrameType.FormattingEnabled = true;
            this.icbFrameType.Location = new System.Drawing.Point(175, 26);
            this.icbFrameType.Margin = new System.Windows.Forms.Padding(4);
            this.icbFrameType.Name = "icbFrameType";
            this.icbFrameType.OutlineColor = System.Drawing.Color.Black;
            this.icbFrameType.Size = new System.Drawing.Size(235, 23);
            this.icbFrameType.TabIndex = 109;
            this.icbFrameType.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // clpFrame1
            // 
            this.clpFrame1.Color = System.Drawing.Color.Black;
            this.clpFrame1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFrame1.DropDownHeight = 1;
            this.clpFrame1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFrame1.FormattingEnabled = true;
            this.clpFrame1.IntegralHeight = false;
            this.clpFrame1.Items.AddRange(new object[] {
            "Color"});
            this.clpFrame1.Location = new System.Drawing.Point(175, 71);
            this.clpFrame1.Margin = new System.Windows.Forms.Padding(4);
            this.clpFrame1.Name = "clpFrame1";
            this.clpFrame1.Size = new System.Drawing.Size(99, 23);
            this.clpFrame1.TabIndex = 106;
            this.clpFrame1.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkUseFrame
            // 
            this.chkUseFrame.AutoSize = true;
            this.chkUseFrame.Location = new System.Drawing.Point(411, 22);
            this.chkUseFrame.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseFrame.Name = "chkUseFrame";
            this.chkUseFrame.Size = new System.Drawing.Size(102, 21);
            this.chkUseFrame.TabIndex = 116;
            this.chkUseFrame.Text = "Draw frame";
            this.chkUseFrame.UseVisualStyleBackColor = true;
            this.chkUseFrame.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.icbLineWidth);
            this.groupBox2.Controls.Add(this.icbLineType);
            this.groupBox2.Controls.Add(this.clpFrameBorder);
            this.groupBox2.Location = new System.Drawing.Point(27, 240);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(491, 116);
            this.groupBox2.TabIndex = 141;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outline";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(37, 28);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 17);
            this.label19.TabIndex = 140;
            this.label19.Text = "Color";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(37, 73);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 17);
            this.label17.TabIndex = 136;
            this.label17.Text = "Width";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(264, 28);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(39, 17);
            this.label23.TabIndex = 135;
            this.label23.Text = "Style";
            // 
            // icbLineWidth
            // 
            this.icbLineWidth.Color1 = System.Drawing.Color.Blue;
            this.icbLineWidth.Color2 = System.Drawing.Color.Honeydew;
            this.icbLineWidth.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineWidth.FormattingEnabled = true;
            this.icbLineWidth.Location = new System.Drawing.Point(116, 69);
            this.icbLineWidth.Margin = new System.Windows.Forms.Padding(4);
            this.icbLineWidth.Name = "icbLineWidth";
            this.icbLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.icbLineWidth.Size = new System.Drawing.Size(89, 23);
            this.icbLineWidth.TabIndex = 139;
            this.icbLineWidth.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // icbLineType
            // 
            this.icbLineType.Color1 = System.Drawing.Color.Blue;
            this.icbLineType.Color2 = System.Drawing.Color.Honeydew;
            this.icbLineType.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbLineType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineType.FormattingEnabled = true;
            this.icbLineType.Location = new System.Drawing.Point(312, 23);
            this.icbLineType.Margin = new System.Windows.Forms.Padding(4);
            this.icbLineType.Name = "icbLineType";
            this.icbLineType.OutlineColor = System.Drawing.Color.Black;
            this.icbLineType.Size = new System.Drawing.Size(89, 23);
            this.icbLineType.TabIndex = 138;
            this.icbLineType.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // clpFrameBorder
            // 
            this.clpFrameBorder.Color = System.Drawing.Color.Black;
            this.clpFrameBorder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFrameBorder.DropDownHeight = 1;
            this.clpFrameBorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFrameBorder.FormattingEnabled = true;
            this.clpFrameBorder.IntegralHeight = false;
            this.clpFrameBorder.Items.AddRange(new object[] {
            "Color"});
            this.clpFrameBorder.Location = new System.Drawing.Point(116, 25);
            this.clpFrameBorder.Margin = new System.Windows.Forms.Padding(4);
            this.clpFrameBorder.Name = "clpFrameBorder";
            this.clpFrameBorder.Size = new System.Drawing.Size(89, 23);
            this.clpFrameBorder.TabIndex = 137;
            this.clpFrameBorder.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // groupLabelAlignment
            // 
            this.groupLabelAlignment.Controls.Add(this.udLabelOffsetY);
            this.groupLabelAlignment.Controls.Add(this.udLabelOffsetX);
            this.groupLabelAlignment.Controls.Add(this.udLabelsBuffer);
            this.groupLabelAlignment.Controls.Add(this.label14);
            this.groupLabelAlignment.Controls.Add(this.optAlignBottomRight);
            this.groupLabelAlignment.Controls.Add(this.lblLabelsOffsetY);
            this.groupLabelAlignment.Controls.Add(this.optAlignBottomCenter);
            this.groupLabelAlignment.Controls.Add(this.lblLabelsOffsetX);
            this.groupLabelAlignment.Controls.Add(this.optAlignBottomLeft);
            this.groupLabelAlignment.Controls.Add(this.optAlignCenterRight);
            this.groupLabelAlignment.Controls.Add(this.optAlignCenter);
            this.groupLabelAlignment.Controls.Add(this.optAlignCenterLeft);
            this.groupLabelAlignment.Controls.Add(this.optAlignTopRight);
            this.groupLabelAlignment.Controls.Add(this.optAlignTopCenter);
            this.groupLabelAlignment.Controls.Add(this.optAlignTopLeft);
            this.groupLabelAlignment.Location = new System.Drawing.Point(25, 18);
            this.groupLabelAlignment.Margin = new System.Windows.Forms.Padding(4);
            this.groupLabelAlignment.Name = "groupLabelAlignment";
            this.groupLabelAlignment.Padding = new System.Windows.Forms.Padding(4);
            this.groupLabelAlignment.Size = new System.Drawing.Size(484, 153);
            this.groupLabelAlignment.TabIndex = 164;
            this.groupLabelAlignment.TabStop = false;
            this.groupLabelAlignment.Text = "Alignment";
            // 
            // udLabelOffsetY
            // 
            this.udLabelOffsetY.Location = new System.Drawing.Point(180, 73);
            this.udLabelOffsetY.Margin = new System.Windows.Forms.Padding(4);
            this.udLabelOffsetY.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udLabelOffsetY.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.udLabelOffsetY.Name = "udLabelOffsetY";
            this.udLabelOffsetY.Size = new System.Drawing.Size(72, 22);
            this.udLabelOffsetY.TabIndex = 159;
            this.udLabelOffsetY.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // udLabelOffsetX
            // 
            this.udLabelOffsetX.Location = new System.Drawing.Point(180, 35);
            this.udLabelOffsetX.Margin = new System.Windows.Forms.Padding(4);
            this.udLabelOffsetX.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udLabelOffsetX.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.udLabelOffsetX.Name = "udLabelOffsetX";
            this.udLabelOffsetX.Size = new System.Drawing.Size(72, 22);
            this.udLabelOffsetX.TabIndex = 158;
            this.udLabelOffsetX.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // udLabelsBuffer
            // 
            this.udLabelsBuffer.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udLabelsBuffer.Location = new System.Drawing.Point(180, 109);
            this.udLabelsBuffer.Margin = new System.Windows.Forms.Padding(4);
            this.udLabelsBuffer.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.udLabelsBuffer.Name = "udLabelsBuffer";
            this.udLabelsBuffer.Size = new System.Drawing.Size(72, 22);
            this.udLabelsBuffer.TabIndex = 157;
            this.udLabelsBuffer.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(264, 111);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 17);
            this.label14.TabIndex = 156;
            this.label14.Text = "Buffer distance";
            // 
            // optAlignBottomRight
            // 
            this.optAlignBottomRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignBottomRight.Image = ((System.Drawing.Image)(resources.GetObject("optAlignBottomRight.Image")));
            this.optAlignBottomRight.Location = new System.Drawing.Point(115, 105);
            this.optAlignBottomRight.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignBottomRight.Name = "optAlignBottomRight";
            this.optAlignBottomRight.Size = new System.Drawing.Size(40, 28);
            this.optAlignBottomRight.TabIndex = 148;
            this.optAlignBottomRight.TabStop = true;
            this.optAlignBottomRight.UseVisualStyleBackColor = true;
            this.optAlignBottomRight.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // lblLabelsOffsetY
            // 
            this.lblLabelsOffsetY.AutoSize = true;
            this.lblLabelsOffsetY.Location = new System.Drawing.Point(264, 76);
            this.lblLabelsOffsetY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLabelsOffsetY.Name = "lblLabelsOffsetY";
            this.lblLabelsOffsetY.Size = new System.Drawing.Size(94, 17);
            this.lblLabelsOffsetY.TabIndex = 154;
            this.lblLabelsOffsetY.Text = "Vertical offset";
            // 
            // optAlignBottomCenter
            // 
            this.optAlignBottomCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignBottomCenter.Image = ((System.Drawing.Image)(resources.GetObject("optAlignBottomCenter.Image")));
            this.optAlignBottomCenter.Location = new System.Drawing.Point(67, 105);
            this.optAlignBottomCenter.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignBottomCenter.Name = "optAlignBottomCenter";
            this.optAlignBottomCenter.Size = new System.Drawing.Size(40, 28);
            this.optAlignBottomCenter.TabIndex = 147;
            this.optAlignBottomCenter.TabStop = true;
            this.optAlignBottomCenter.UseVisualStyleBackColor = true;
            this.optAlignBottomCenter.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // lblLabelsOffsetX
            // 
            this.lblLabelsOffsetX.AutoSize = true;
            this.lblLabelsOffsetX.Location = new System.Drawing.Point(264, 38);
            this.lblLabelsOffsetX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLabelsOffsetX.Name = "lblLabelsOffsetX";
            this.lblLabelsOffsetX.Size = new System.Drawing.Size(111, 17);
            this.lblLabelsOffsetX.TabIndex = 150;
            this.lblLabelsOffsetX.Text = "Horizontal offset";
            // 
            // optAlignBottomLeft
            // 
            this.optAlignBottomLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignBottomLeft.Image = ((System.Drawing.Image)(resources.GetObject("optAlignBottomLeft.Image")));
            this.optAlignBottomLeft.Location = new System.Drawing.Point(19, 105);
            this.optAlignBottomLeft.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignBottomLeft.Name = "optAlignBottomLeft";
            this.optAlignBottomLeft.Size = new System.Drawing.Size(40, 28);
            this.optAlignBottomLeft.TabIndex = 146;
            this.optAlignBottomLeft.TabStop = true;
            this.optAlignBottomLeft.UseVisualStyleBackColor = true;
            this.optAlignBottomLeft.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignCenterRight
            // 
            this.optAlignCenterRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignCenterRight.Image = ((System.Drawing.Image)(resources.GetObject("optAlignCenterRight.Image")));
            this.optAlignCenterRight.Location = new System.Drawing.Point(115, 70);
            this.optAlignCenterRight.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignCenterRight.Name = "optAlignCenterRight";
            this.optAlignCenterRight.Size = new System.Drawing.Size(40, 28);
            this.optAlignCenterRight.TabIndex = 145;
            this.optAlignCenterRight.TabStop = true;
            this.optAlignCenterRight.UseVisualStyleBackColor = true;
            this.optAlignCenterRight.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignCenter
            // 
            this.optAlignCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("optAlignCenter.Image")));
            this.optAlignCenter.Location = new System.Drawing.Point(67, 70);
            this.optAlignCenter.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignCenter.Name = "optAlignCenter";
            this.optAlignCenter.Size = new System.Drawing.Size(40, 28);
            this.optAlignCenter.TabIndex = 144;
            this.optAlignCenter.TabStop = true;
            this.optAlignCenter.UseVisualStyleBackColor = true;
            this.optAlignCenter.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignCenterLeft
            // 
            this.optAlignCenterLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignCenterLeft.Image = ((System.Drawing.Image)(resources.GetObject("optAlignCenterLeft.Image")));
            this.optAlignCenterLeft.Location = new System.Drawing.Point(19, 70);
            this.optAlignCenterLeft.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignCenterLeft.Name = "optAlignCenterLeft";
            this.optAlignCenterLeft.Size = new System.Drawing.Size(40, 28);
            this.optAlignCenterLeft.TabIndex = 143;
            this.optAlignCenterLeft.TabStop = true;
            this.optAlignCenterLeft.UseVisualStyleBackColor = true;
            this.optAlignCenterLeft.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignTopRight
            // 
            this.optAlignTopRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignTopRight.Image = ((System.Drawing.Image)(resources.GetObject("optAlignTopRight.Image")));
            this.optAlignTopRight.Location = new System.Drawing.Point(115, 34);
            this.optAlignTopRight.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignTopRight.Name = "optAlignTopRight";
            this.optAlignTopRight.Size = new System.Drawing.Size(40, 28);
            this.optAlignTopRight.TabIndex = 142;
            this.optAlignTopRight.TabStop = true;
            this.optAlignTopRight.UseVisualStyleBackColor = true;
            this.optAlignTopRight.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignTopCenter
            // 
            this.optAlignTopCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignTopCenter.Image = ((System.Drawing.Image)(resources.GetObject("optAlignTopCenter.Image")));
            this.optAlignTopCenter.Location = new System.Drawing.Point(67, 34);
            this.optAlignTopCenter.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignTopCenter.Name = "optAlignTopCenter";
            this.optAlignTopCenter.Size = new System.Drawing.Size(40, 28);
            this.optAlignTopCenter.TabIndex = 141;
            this.optAlignTopCenter.TabStop = true;
            this.optAlignTopCenter.UseVisualStyleBackColor = true;
            this.optAlignTopCenter.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignTopLeft
            // 
            this.optAlignTopLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignTopLeft.Image = ((System.Drawing.Image)(resources.GetObject("optAlignTopLeft.Image")));
            this.optAlignTopLeft.Location = new System.Drawing.Point(19, 34);
            this.optAlignTopLeft.Margin = new System.Windows.Forms.Padding(4);
            this.optAlignTopLeft.Name = "optAlignTopLeft";
            this.optAlignTopLeft.Size = new System.Drawing.Size(40, 28);
            this.optAlignTopLeft.TabIndex = 140;
            this.optAlignTopLeft.TabStop = true;
            this.optAlignTopLeft.UseVisualStyleBackColor = true;
            this.optAlignTopLeft.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtLabelExpression);
            this.groupBox11.Controls.Add(this.btnLabelExpression);
            this.groupBox11.Controls.Add(this.btnClearLabelsExpression);
            this.groupBox11.Location = new System.Drawing.Point(31, 272);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox11.Size = new System.Drawing.Size(473, 106);
            this.groupBox11.TabIndex = 172;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Visibility expression";
            // 
            // txtLabelExpression
            // 
            this.txtLabelExpression.Location = new System.Drawing.Point(27, 27);
            this.txtLabelExpression.Margin = new System.Windows.Forms.Padding(4);
            this.txtLabelExpression.Multiline = true;
            this.txtLabelExpression.Name = "txtLabelExpression";
            this.txtLabelExpression.ReadOnly = true;
            this.txtLabelExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLabelExpression.Size = new System.Drawing.Size(351, 61);
            this.txtLabelExpression.TabIndex = 168;
            // 
            // btnLabelExpression
            // 
            this.btnLabelExpression.Location = new System.Drawing.Point(387, 27);
            this.btnLabelExpression.Margin = new System.Windows.Forms.Padding(4);
            this.btnLabelExpression.Name = "btnLabelExpression";
            this.btnLabelExpression.Size = new System.Drawing.Size(68, 27);
            this.btnLabelExpression.TabIndex = 169;
            this.btnLabelExpression.Text = "Edit";
            this.btnLabelExpression.UseVisualStyleBackColor = true;
            this.btnLabelExpression.Click += new System.EventHandler(this.OnLabelExpressionClick);
            // 
            // btnClearLabelsExpression
            // 
            this.btnClearLabelsExpression.Location = new System.Drawing.Point(387, 62);
            this.btnClearLabelsExpression.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLabelsExpression.Name = "btnClearLabelsExpression";
            this.btnClearLabelsExpression.Size = new System.Drawing.Size(68, 27);
            this.btnClearLabelsExpression.TabIndex = 170;
            this.btnClearLabelsExpression.Text = "Clear";
            this.btnClearLabelsExpression.UseVisualStyleBackColor = true;
            this.btnClearLabelsExpression.Click += new System.EventHandler(this.OnClearLabelsExpressionClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 59;
            this.label3.Text = "Size";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(556, 447);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(127, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.OnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(687, 447);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Size";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(67, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 25);
            this.comboBox1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Family";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(67, 24);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(161, 25);
            this.comboBox2.TabIndex = 9;
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(300, 199);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(79, 25);
            this.comboBox11.TabIndex = 62;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(211, 202);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 13);
            this.label25.TabIndex = 61;
            this.label25.Text = "Border width";
            // 
            // comboBox12
            // 
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Location = new System.Drawing.Point(104, 204);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(79, 25);
            this.comboBox12.TabIndex = 60;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(15, 207);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(64, 13);
            this.label26.TabIndex = 59;
            this.label26.Text = "Border Style";
            // 
            // comboBox13
            // 
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.Location = new System.Drawing.Point(104, 166);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(79, 25);
            this.comboBox13.TabIndex = 58;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(15, 169);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 13);
            this.label27.TabIndex = 57;
            this.label27.Text = "Transparency";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(191, 92);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(31, 22);
            this.button6.TabIndex = 54;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(15, 97);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 13);
            this.label28.TabIndex = 53;
            this.label28.Text = "Second color";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(191, 59);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(31, 22);
            this.button7.TabIndex = 52;
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(15, 131);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(70, 13);
            this.label29.TabIndex = 49;
            this.label29.Text = "Gradient type";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(15, 64);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(52, 13);
            this.label30.TabIndex = 51;
            this.label30.Text = "First color";
            // 
            // comboBox14
            // 
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Location = new System.Drawing.Point(104, 128);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(132, 25);
            this.comboBox14.TabIndex = 50;
            // 
            // comboBox15
            // 
            this.comboBox15.FormattingEnabled = true;
            this.comboBox15.Location = new System.Drawing.Point(104, 22);
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(152, 25);
            this.comboBox15.TabIndex = 1;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(15, 25);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(59, 13);
            this.label31.TabIndex = 0;
            this.label31.Text = "Frame type";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pctPreview);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(256, 199);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // pctPreview
            // 
            this.pctPreview.BackColor = System.Drawing.Color.Transparent;
            this.pctPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctPreview.Location = new System.Drawing.Point(4, 19);
            this.pctPreview.Margin = new System.Windows.Forms.Padding(4);
            this.pctPreview.Name = "pctPreview";
            this.pctPreview.Size = new System.Drawing.Size(248, 176);
            this.pctPreview.TabIndex = 16;
            this.pctPreview.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox9.Location = new System.Drawing.Point(104, 93);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(79, 21);
            this.pictureBox9.TabIndex = 56;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox10.Location = new System.Drawing.Point(104, 60);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(79, 21);
            this.pictureBox10.TabIndex = 55;
            this.pictureBox10.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.udFontSize2);
            this.groupBox6.Controls.Add(this.chkVisible);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.transparencyControl1);
            this.groupBox6.Controls.Add(this.udFontSize);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(15, 217);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(252, 225);
            this.groupBox6.TabIndex = 134;
            this.groupBox6.TabStop = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(145, 98);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(20, 17);
            this.label36.TabIndex = 122;
            this.label36.Text = "to";
            // 
            // udFontSize2
            // 
            this.udFontSize2.Location = new System.Drawing.Point(173, 96);
            this.udFontSize2.Margin = new System.Windows.Forms.Padding(4);
            this.udFontSize2.Name = "udFontSize2";
            this.udFontSize2.Size = new System.Drawing.Size(67, 22);
            this.udFontSize2.TabIndex = 121;
            this.udFontSize2.ValueChanged += new System.EventHandler(this.UpdateSize);
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(31, 43);
            this.chkVisible.Margin = new System.Windows.Forms.Padding(4);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(115, 21);
            this.chkVisible.TabIndex = 120;
            this.chkVisible.Text = "Labels visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 119;
            this.label7.Text = "Transparency";
            // 
            // transparencyControl1
            // 
            this.transparencyControl1.BandColor = System.Drawing.Color.Empty;
            this.transparencyControl1.Location = new System.Drawing.Point(31, 171);
            this.transparencyControl1.Margin = new System.Windows.Forms.Padding(5);
            this.transparencyControl1.MaximumSize = new System.Drawing.Size(1365, 39);
            this.transparencyControl1.MinimumSize = new System.Drawing.Size(171, 39);
            this.transparencyControl1.Name = "transparencyControl1";
            this.transparencyControl1.Size = new System.Drawing.Size(209, 39);
            this.transparencyControl1.TabIndex = 118;
            this.transparencyControl1.Value = ((byte)(255));
            this.transparencyControl1.ValueChanged += new MW5.UI.Controls.TransparencyControl.ValueChangedDeleg(this.OnTransparencyControlValueChanged);
            // 
            // udFontSize
            // 
            this.udFontSize.Location = new System.Drawing.Point(71, 96);
            this.udFontSize.Margin = new System.Windows.Forms.Padding(4);
            this.udFontSize.Name = "udFontSize";
            this.udFontSize.Size = new System.Drawing.Size(67, 22);
            this.udFontSize.TabIndex = 105;
            this.udFontSize.ValueChanged += new System.EventHandler(this.UpdateSize);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(19, 453);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(395, 23);
            this.lblResult.TabIndex = 44;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(421, 447);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(127, 32);
            this.btnApply.TabIndex = 135;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnApplyClick);
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.ActiveTabForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(536, 427);
            this.tabControlAdv1.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.CloseButtonHoverForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.CloseButtonPressedForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.Controls.Add(this.tabMain);
            this.tabControlAdv1.Controls.Add(this.tabExpression);
            this.tabControlAdv1.Controls.Add(this.tabPosition);
            this.tabControlAdv1.Controls.Add(this.tabVisibility);
            this.tabControlAdv1.Controls.Add(this.tabFont);
            this.tabControlAdv1.Controls.Add(this.tabFrame);
            this.tabControlAdv1.InActiveTabForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.Location = new System.Drawing.Point(279, 15);
            this.tabControlAdv1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.SeparatorColor = System.Drawing.SystemColors.ControlDark;
            this.tabControlAdv1.ShowSeparator = false;
            this.tabControlAdv1.Size = new System.Drawing.Size(536, 427);
            this.tabControlAdv1.TabIndex = 177;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.groupBox20);
            this.tabMain.Controls.Add(this.chkLogScaleForSize);
            this.tabMain.Controls.Add(this.label22);
            this.tabMain.Controls.Add(this.chkUseVariableSize);
            this.tabMain.Controls.Add(this.cboField);
            this.tabMain.Controls.Add(this.label33);
            this.tabMain.Controls.Add(this.label24);
            this.tabMain.Controls.Add(this.label18);
            this.tabMain.Controls.Add(this.cboSortField);
            this.tabMain.Controls.Add(this.cboDecimalPlaces);
            this.tabMain.Controls.Add(this.chkSortAscending);
            this.tabMain.Image = null;
            this.tabMain.ImageSize = new System.Drawing.Size(16, 16);
            this.tabMain.Location = new System.Drawing.Point(1, 28);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabMain.Name = "tabMain";
            this.tabMain.ShowCloseButton = true;
            this.tabMain.Size = new System.Drawing.Size(533, 397);
            this.tabMain.TabIndex = 1;
            this.tabMain.Text = "Main";
            this.tabMain.ThemesEnabled = false;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.chkAviodCollisions);
            this.groupBox20.Controls.Add(this.chkLabelsRemoveDuplicates);
            this.groupBox20.Controls.Add(this.lblLabelVerticalPosition);
            this.groupBox20.Controls.Add(this.cboLabelsVerticalPosition);
            this.groupBox20.Location = new System.Drawing.Point(29, 262);
            this.groupBox20.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox20.Size = new System.Drawing.Size(471, 114);
            this.groupBox20.TabIndex = 166;
            this.groupBox20.TabStop = false;
            // 
            // chkAviodCollisions
            // 
            this.chkAviodCollisions.AutoSize = true;
            this.chkAviodCollisions.Location = new System.Drawing.Point(26, 78);
            this.chkAviodCollisions.Margin = new System.Windows.Forms.Padding(4);
            this.chkAviodCollisions.Name = "chkAviodCollisions";
            this.chkAviodCollisions.Size = new System.Drawing.Size(126, 21);
            this.chkAviodCollisions.TabIndex = 129;
            this.chkAviodCollisions.Text = "Avoid collisions";
            this.chkAviodCollisions.UseVisualStyleBackColor = true;
            // 
            // chkLabelsRemoveDuplicates
            // 
            this.chkLabelsRemoveDuplicates.AutoSize = true;
            this.chkLabelsRemoveDuplicates.Location = new System.Drawing.Point(26, 49);
            this.chkLabelsRemoveDuplicates.Margin = new System.Windows.Forms.Padding(4);
            this.chkLabelsRemoveDuplicates.Name = "chkLabelsRemoveDuplicates";
            this.chkLabelsRemoveDuplicates.Size = new System.Drawing.Size(150, 21);
            this.chkLabelsRemoveDuplicates.TabIndex = 128;
            this.chkLabelsRemoveDuplicates.Text = "Remove duplicates";
            this.chkLabelsRemoveDuplicates.UseVisualStyleBackColor = true;
            // 
            // lblLabelVerticalPosition
            // 
            this.lblLabelVerticalPosition.AutoSize = true;
            this.lblLabelVerticalPosition.Location = new System.Drawing.Point(8, 20);
            this.lblLabelVerticalPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLabelVerticalPosition.Name = "lblLabelVerticalPosition";
            this.lblLabelVerticalPosition.Size = new System.Drawing.Size(97, 17);
            this.lblLabelVerticalPosition.TabIndex = 126;
            this.lblLabelVerticalPosition.Text = "Drawing order";
            // 
            // cboLabelsVerticalPosition
            // 
            this.cboLabelsVerticalPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabelsVerticalPosition.FormattingEnabled = true;
            this.cboLabelsVerticalPosition.Location = new System.Drawing.Point(113, 17);
            this.cboLabelsVerticalPosition.Margin = new System.Windows.Forms.Padding(4);
            this.cboLabelsVerticalPosition.Name = "cboLabelsVerticalPosition";
            this.cboLabelsVerticalPosition.Size = new System.Drawing.Size(334, 24);
            this.cboLabelsVerticalPosition.TabIndex = 124;
            // 
            // tabExpression
            // 
            this.tabExpression.Controls.Add(this.groupBox10);
            this.tabExpression.Controls.Add(this.groupBox8);
            this.tabExpression.Controls.Add(this.groupBox9);
            this.tabExpression.Controls.Add(this.groupBox7);
            this.tabExpression.Controls.Add(this.btnClear);
            this.tabExpression.Controls.Add(this.btnPlus);
            this.tabExpression.Controls.Add(this.btnNewLine);
            this.tabExpression.Controls.Add(this.btnQuotes);
            this.tabExpression.Image = null;
            this.tabExpression.ImageSize = new System.Drawing.Size(16, 16);
            this.tabExpression.Location = new System.Drawing.Point(1, 28);
            this.tabExpression.Margin = new System.Windows.Forms.Padding(4);
            this.tabExpression.Name = "tabExpression";
            this.tabExpression.ShowCloseButton = true;
            this.tabExpression.Size = new System.Drawing.Size(533, 397);
            this.tabExpression.TabIndex = 2;
            this.tabExpression.Text = "Expression";
            this.tabExpression.ThemesEnabled = false;
            // 
            // tabPosition
            // 
            this.tabPosition.Controls.Add(this.groupBoxPositioning);
            this.tabPosition.Controls.Add(this.groupBox13);
            this.tabPosition.Controls.Add(this.groupLabelAlignment);
            this.tabPosition.Image = null;
            this.tabPosition.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPosition.Location = new System.Drawing.Point(1, 28);
            this.tabPosition.Margin = new System.Windows.Forms.Padding(4);
            this.tabPosition.Name = "tabPosition";
            this.tabPosition.ShowCloseButton = true;
            this.tabPosition.Size = new System.Drawing.Size(533, 397);
            this.tabPosition.TabIndex = 6;
            this.tabPosition.Text = "Position";
            this.tabPosition.ThemesEnabled = false;
            // 
            // groupBoxPositioning
            // 
            this.groupBoxPositioning.Controls.Add(this.chkLabelEveryPart);
            this.groupBoxPositioning.Controls.Add(this.cboLineOrientation);
            this.groupBoxPositioning.Controls.Add(this.label16);
            this.groupBoxPositioning.Controls.Add(this.optPosition4);
            this.groupBoxPositioning.Controls.Add(this.optPosition3);
            this.groupBoxPositioning.Controls.Add(this.optPosition2);
            this.groupBoxPositioning.Controls.Add(this.optPosition1);
            this.groupBoxPositioning.Location = new System.Drawing.Point(24, 239);
            this.groupBoxPositioning.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxPositioning.Name = "groupBoxPositioning";
            this.groupBoxPositioning.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxPositioning.Size = new System.Drawing.Size(485, 145);
            this.groupBoxPositioning.TabIndex = 170;
            this.groupBoxPositioning.TabStop = false;
            this.groupBoxPositioning.Text = "Position";
            // 
            // chkLabelEveryPart
            // 
            this.chkLabelEveryPart.AutoSize = true;
            this.chkLabelEveryPart.Location = new System.Drawing.Point(210, 93);
            this.chkLabelEveryPart.Margin = new System.Windows.Forms.Padding(4);
            this.chkLabelEveryPart.Name = "chkLabelEveryPart";
            this.chkLabelEveryPart.Size = new System.Drawing.Size(119, 21);
            this.chkLabelEveryPart.TabIndex = 24;
            this.chkLabelEveryPart.Text = "Label all parts";
            this.chkLabelEveryPart.UseVisualStyleBackColor = true;
            this.chkLabelEveryPart.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // cboLineOrientation
            // 
            this.cboLineOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLineOrientation.FormattingEnabled = true;
            this.cboLineOrientation.Location = new System.Drawing.Point(210, 45);
            this.cboLineOrientation.Margin = new System.Windows.Forms.Padding(4);
            this.cboLineOrientation.Name = "cboLineOrientation";
            this.cboLineOrientation.Size = new System.Drawing.Size(201, 24);
            this.cboLineOrientation.TabIndex = 23;
            this.cboLineOrientation.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(207, 19);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 17);
            this.label16.TabIndex = 22;
            this.label16.Text = "Relative to line:";
            // 
            // optPosition4
            // 
            this.optPosition4.AutoSize = true;
            this.optPosition4.Location = new System.Drawing.Point(19, 116);
            this.optPosition4.Margin = new System.Windows.Forms.Padding(4);
            this.optPosition4.Name = "optPosition4";
            this.optPosition4.Size = new System.Drawing.Size(108, 21);
            this.optPosition4.TabIndex = 3;
            this.optPosition4.Text = "Interior point";
            this.optPosition4.UseVisualStyleBackColor = true;
            this.optPosition4.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optPosition3
            // 
            this.optPosition3.AutoSize = true;
            this.optPosition3.Location = new System.Drawing.Point(19, 87);
            this.optPosition3.Margin = new System.Windows.Forms.Padding(4);
            this.optPosition3.Name = "optPosition3";
            this.optPosition3.Size = new System.Drawing.Size(108, 21);
            this.optPosition3.TabIndex = 2;
            this.optPosition3.Text = "Interior point";
            this.optPosition3.UseVisualStyleBackColor = true;
            this.optPosition3.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optPosition2
            // 
            this.optPosition2.AutoSize = true;
            this.optPosition2.Location = new System.Drawing.Point(19, 58);
            this.optPosition2.Margin = new System.Windows.Forms.Padding(4);
            this.optPosition2.Name = "optPosition2";
            this.optPosition2.Size = new System.Drawing.Size(82, 21);
            this.optPosition2.TabIndex = 1;
            this.optPosition2.Text = "Centroid";
            this.optPosition2.UseVisualStyleBackColor = true;
            this.optPosition2.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optPosition1
            // 
            this.optPosition1.AutoSize = true;
            this.optPosition1.Checked = true;
            this.optPosition1.Location = new System.Drawing.Point(19, 29);
            this.optPosition1.Margin = new System.Windows.Forms.Padding(4);
            this.optPosition1.Name = "optPosition1";
            this.optPosition1.Size = new System.Drawing.Size(71, 21);
            this.optPosition1.TabIndex = 0;
            this.optPosition1.TabStop = true;
            this.optPosition1.Text = "Center";
            this.optPosition1.UseVisualStyleBackColor = true;
            this.optPosition1.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.comboOffsetY);
            this.groupBox13.Controls.Add(this.comboOffsetX);
            this.groupBox13.Controls.Add(this.labelOffsetYField);
            this.groupBox13.Controls.Add(this.labelOffsetXField);
            this.groupBox13.Location = new System.Drawing.Point(24, 174);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox13.Size = new System.Drawing.Size(484, 57);
            this.groupBox13.TabIndex = 169;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Offset data fields";
            // 
            // comboOffsetY
            // 
            this.comboOffsetY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOffsetY.FormattingEnabled = true;
            this.comboOffsetY.Location = new System.Drawing.Point(285, 23);
            this.comboOffsetY.Margin = new System.Windows.Forms.Padding(4);
            this.comboOffsetY.Name = "comboOffsetY";
            this.comboOffsetY.Size = new System.Drawing.Size(184, 24);
            this.comboOffsetY.TabIndex = 158;
            this.comboOffsetY.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // comboOffsetX
            // 
            this.comboOffsetX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOffsetX.FormattingEnabled = true;
            this.comboOffsetX.Location = new System.Drawing.Point(36, 23);
            this.comboOffsetX.Margin = new System.Windows.Forms.Padding(4);
            this.comboOffsetX.Name = "comboOffsetX";
            this.comboOffsetX.Size = new System.Drawing.Size(184, 24);
            this.comboOffsetX.TabIndex = 157;
            this.comboOffsetX.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // labelOffsetYField
            // 
            this.labelOffsetYField.AutoSize = true;
            this.labelOffsetYField.Location = new System.Drawing.Point(259, 27);
            this.labelOffsetYField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOffsetYField.Name = "labelOffsetYField";
            this.labelOffsetYField.Size = new System.Drawing.Size(17, 17);
            this.labelOffsetYField.TabIndex = 156;
            this.labelOffsetYField.Text = "Y";
            // 
            // labelOffsetXField
            // 
            this.labelOffsetXField.AutoSize = true;
            this.labelOffsetXField.Location = new System.Drawing.Point(9, 27);
            this.labelOffsetXField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOffsetXField.Name = "labelOffsetXField";
            this.labelOffsetXField.Size = new System.Drawing.Size(17, 17);
            this.labelOffsetXField.TabIndex = 154;
            this.labelOffsetXField.Text = "X";
            // 
            // tabVisibility
            // 
            this.tabVisibility.Controls.Add(this.dynamicVisibilityControl1);
            this.tabVisibility.Controls.Add(this.groupBox11);
            this.tabVisibility.Image = null;
            this.tabVisibility.ImageSize = new System.Drawing.Size(16, 16);
            this.tabVisibility.Location = new System.Drawing.Point(1, 28);
            this.tabVisibility.Margin = new System.Windows.Forms.Padding(4);
            this.tabVisibility.Name = "tabVisibility";
            this.tabVisibility.ShowCloseButton = true;
            this.tabVisibility.Size = new System.Drawing.Size(533, 397);
            this.tabVisibility.TabIndex = 3;
            this.tabVisibility.Text = "Visibility";
            this.tabVisibility.ThemesEnabled = false;
            // 
            // dynamicVisibilityControl1
            // 
            this.dynamicVisibilityControl1.CurrentScale = 0D;
            this.dynamicVisibilityControl1.CurrentZoom = 0;
            this.dynamicVisibilityControl1.Location = new System.Drawing.Point(31, 15);
            this.dynamicVisibilityControl1.Margin = new System.Windows.Forms.Padding(5);
            this.dynamicVisibilityControl1.MaxScale = 1000000D;
            this.dynamicVisibilityControl1.MaxZoom = 24;
            this.dynamicVisibilityControl1.MinScale = 100D;
            this.dynamicVisibilityControl1.MinZoom = 1;
            this.dynamicVisibilityControl1.Mode = MW5.Api.Enums.DynamicVisibilityMode.Scale;
            this.dynamicVisibilityControl1.Name = "dynamicVisibilityControl1";
            this.dynamicVisibilityControl1.Size = new System.Drawing.Size(473, 245);
            this.dynamicVisibilityControl1.TabIndex = 177;
            this.dynamicVisibilityControl1.UseDynamicVisiblity = false;
            this.dynamicVisibilityControl1.ValueChanged += new System.EventHandler<System.EventArgs>(this.Ui2LabelStyle);
            // 
            // tabFont
            // 
            this.tabFont.Controls.Add(this.groupBox5);
            this.tabFont.Controls.Add(this.groupBox3);
            this.tabFont.Image = null;
            this.tabFont.ImageSize = new System.Drawing.Size(16, 16);
            this.tabFont.Location = new System.Drawing.Point(1, 28);
            this.tabFont.Margin = new System.Windows.Forms.Padding(4);
            this.tabFont.Name = "tabFont";
            this.tabFont.ShowCloseButton = true;
            this.tabFont.Size = new System.Drawing.Size(533, 397);
            this.tabFont.TabIndex = 4;
            this.tabFont.Text = "Font";
            this.tabFont.ThemesEnabled = false;
            // 
            // tabFrame
            // 
            this.tabFrame.Controls.Add(this.groupBox4);
            this.tabFrame.Controls.Add(this.chkUseFrame);
            this.tabFrame.Controls.Add(this.groupBox2);
            this.tabFrame.Image = null;
            this.tabFrame.ImageSize = new System.Drawing.Size(16, 16);
            this.tabFrame.Location = new System.Drawing.Point(1, 28);
            this.tabFrame.Margin = new System.Windows.Forms.Padding(4);
            this.tabFrame.Name = "tabFrame";
            this.tabFrame.ShowCloseButton = true;
            this.tabFrame.Size = new System.Drawing.Size(533, 397);
            this.tabFrame.TabIndex = 5;
            this.tabFrame.Text = "Frame";
            this.tabFrame.ThemesEnabled = false;
            // 
            // LabelStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(825, 482);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabelStyleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Label style";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.LabelStyleForm_Load);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udShadowOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udShadowOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udHaloSize)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udFramePaddingY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFramePaddingX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupLabelAlignment.ResumeLayout(false);
            this.groupLabelAlignment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udLabelOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLabelOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLabelsBuffer)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udFontSize2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.tabExpression.ResumeLayout(false);
            this.tabPosition.ResumeLayout(false);
            this.groupBoxPositioning.ResumeLayout(false);
            this.groupBoxPositioning.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabVisibility.ResumeLayout(false);
            this.tabFont.ResumeLayout(false);
            this.tabFrame.ResumeLayout(false);
            this.tabFrame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnOk;
        protected System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox comboBox12;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox comboBox13;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.ComboBox comboBox15;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFontName;
        private System.Windows.Forms.CheckBox chkFontStrikeout;
        private System.Windows.Forms.CheckBox chkFontUnderline;
        private System.Windows.Forms.CheckBox chkFontItalic;
        private System.Windows.Forms.CheckBox chkFontBold;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pctPreview;
        private Office2007ColorPicker clpFont1;
        private Office2007ColorPicker clpFrame1;
        private ImageCombo icbFrameType;
        private System.Windows.Forms.CheckBox chkUseFrame;
        private System.Windows.Forms.Button btnSetFrameGradient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private NumericUpDownEx udFramePaddingY;
        private NumericUpDownEx udFramePaddingX;
        private NumericUpDownEx udFontSize;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label23;
        private ImageCombo icbLineWidth;
        private ImageCombo icbLineType;
        private Office2007ColorPicker clpFrameBorder;
        private System.Windows.Forms.GroupBox groupBox3;
        private NumericUpDownEx udShadowOffsetY;
        private NumericUpDownEx udShadowOffsetX;
        private NumericUpDownEx udHaloSize;
        private Office2007ColorPicker clpShadow;
        private Office2007ColorPicker clpHalo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkShadowVisible;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkHaloVisible;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private TransparencyControl transparencyControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnNewLine;
        private System.Windows.Forms.Button btnQuotes;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox txtExpression;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.GroupBox groupLabelAlignment;
        private NumericUpDownEx udLabelOffsetY;
        private NumericUpDownEx udLabelOffsetX;
        private NumericUpDownEx udLabelsBuffer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton optAlignBottomRight;
        private System.Windows.Forms.Label lblLabelsOffsetY;
        private System.Windows.Forms.RadioButton optAlignBottomCenter;
        private System.Windows.Forms.Label lblLabelsOffsetX;
        private System.Windows.Forms.RadioButton optAlignBottomLeft;
        private System.Windows.Forms.RadioButton optAlignCenterRight;
        private System.Windows.Forms.RadioButton optAlignCenter;
        private System.Windows.Forms.RadioButton optAlignCenterLeft;
        private System.Windows.Forms.RadioButton optAlignTopRight;
        private System.Windows.Forms.RadioButton optAlignTopCenter;
        private System.Windows.Forms.RadioButton optAlignTopLeft;
        private System.Windows.Forms.Button btnClearLabelsExpression;
        private System.Windows.Forms.TextBox txtLabelExpression;
        private System.Windows.Forms.Button btnLabelExpression;
        private System.Windows.Forms.GroupBox groupBox11;
        protected System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cboTextRenderingHint;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboDecimalPlaces;
        private System.Windows.Forms.CheckBox chkSortAscending;
        private ComboBox cboSortField;
        private System.Windows.Forms.Label label24;
        private ComboBox cboField;
        private System.Windows.Forms.Label label22;
        private Label label33;
        private Label label36;
        private NumericUpDownEx udFontSize2;
        private CheckBox chkUseVariableSize;
        private CheckBox chkLogScaleForSize;
        private DynamicVisibilityControl dynamicVisibilityControl1;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabMain;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabExpression;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPosition;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabVisibility;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabFont;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabFrame;
        private GroupBox groupBox13;
        private Label labelOffsetYField;
        private Label labelOffsetXField;
        private ComboBox comboOffsetY;
        private ComboBox comboOffsetX;
        private Button btnSetCurrent;
        private ComboBox cboBasicScale;
        private CheckBox chkScaleLabels;
        private GroupBox groupBox20;
        private CheckBox chkAviodCollisions;
        private CheckBox chkLabelsRemoveDuplicates;
        private Label lblLabelVerticalPosition;
        private ComboBox cboLabelsVerticalPosition;
        private GroupBox groupBoxPositioning;
        private CheckBox chkLabelEveryPart;
        private ComboBox cboLineOrientation;
        private Label label16;
        private RadioButton optPosition4;
        private RadioButton optPosition3;
        private RadioButton optPosition2;
        private RadioButton optPosition1;
    }
}