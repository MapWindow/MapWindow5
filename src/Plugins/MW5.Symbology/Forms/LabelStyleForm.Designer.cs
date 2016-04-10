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
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnSetCurrent = new System.Windows.Forms.Button();
            this.cboBasicScale = new System.Windows.Forms.ComboBox();
            this.lblScaleLabels = new System.Windows.Forms.Label();
            this.chkScaleLabels = new System.Windows.Forms.CheckBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.chkAviodCollisions = new System.Windows.Forms.CheckBox();
            this.chkLabelsRemoveDuplicates = new System.Windows.Forms.CheckBox();
            this.lblLabelVerticalPosition = new System.Windows.Forms.Label();
            this.cboLabelsVerticalPosition = new System.Windows.Forms.ComboBox();
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
            this.tabExpression = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPosition = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
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
            this.groupBox12.SuspendLayout();
            this.groupBox20.SuspendLayout();
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
            this.tabExpression.SuspendLayout();
            this.tabPosition.SuspendLayout();
            this.tabVisibility.SuspendLayout();
            this.tabFont.SuspendLayout();
            this.tabFrame.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLogScaleForSize
            // 
            this.chkLogScaleForSize.AutoSize = true;
            this.chkLogScaleForSize.Location = new System.Drawing.Point(260, 124);
            this.chkLogScaleForSize.Name = "chkLogScaleForSize";
            this.chkLogScaleForSize.Size = new System.Drawing.Size(108, 17);
            this.chkLogScaleForSize.TabIndex = 55;
            this.chkLogScaleForSize.Text = "Logarithmic scale";
            this.chkLogScaleForSize.UseVisualStyleBackColor = true;
            this.chkLogScaleForSize.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkUseVariableSize
            // 
            this.chkUseVariableSize.AutoSize = true;
            this.chkUseVariableSize.Location = new System.Drawing.Point(141, 124);
            this.chkUseVariableSize.Name = "chkUseVariableSize";
            this.chkUseVariableSize.Size = new System.Drawing.Size(106, 17);
            this.chkUseVariableSize.TabIndex = 54;
            this.chkUseVariableSize.Text = "Use variable size";
            this.chkUseVariableSize.UseVisualStyleBackColor = true;
            this.chkUseVariableSize.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(28, 292);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(308, 13);
            this.label33.TabIndex = 51;
            this.label33.Text = "* To generate labels based on multiple fields use expression tab.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(28, 159);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(140, 13);
            this.label18.TabIndex = 50;
            this.label18.Text = "Decimal places for numbers:";
            // 
            // cboDecimalPlaces
            // 
            this.cboDecimalPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDecimalPlaces.FormattingEnabled = true;
            this.cboDecimalPlaces.Location = new System.Drawing.Point(31, 175);
            this.cboDecimalPlaces.Name = "cboDecimalPlaces";
            this.cboDecimalPlaces.Size = new System.Drawing.Size(337, 21);
            this.cboDecimalPlaces.TabIndex = 49;
            this.cboDecimalPlaces.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkSortAscending
            // 
            this.chkSortAscending.AutoSize = true;
            this.chkSortAscending.Location = new System.Drawing.Point(31, 124);
            this.chkSortAscending.Name = "chkSortAscending";
            this.chkSortAscending.Size = new System.Drawing.Size(97, 17);
            this.chkSortAscending.TabIndex = 4;
            this.chkSortAscending.Text = "Sort ascending";
            this.chkSortAscending.UseVisualStyleBackColor = true;
            this.chkSortAscending.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // cboSortField
            // 
            this.cboSortField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboSortField.Location = new System.Drawing.Point(31, 97);
            this.cboSortField.Name = "cboSortField";
            this.cboSortField.Size = new System.Drawing.Size(337, 21);
            this.cboSortField.TabIndex = 3;
            this.cboSortField.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(28, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 13);
            this.label24.TabIndex = 2;
            this.label24.Text = "Sort field:";
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboField.Location = new System.Drawing.Point(31, 44);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(337, 21);
            this.cboField.TabIndex = 1;
            this.cboField.SelectedIndexChanged += new System.EventHandler(this.OnFieldChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(28, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Label field:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Location = new System.Drawing.Point(227, 241);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(159, 55);
            this.groupBox10.TabIndex = 46;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Description";
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 36);
            this.label13.TabIndex = 0;
            this.label13.Text = "[Area], [Quant]  - fields, \"ha\", \"thnds.\" - string literals";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Location = new System.Drawing.Point(227, 183);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(159, 52);
            this.groupBox9.TabIndex = 45;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Example";
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 33);
            this.label11.TabIndex = 0;
            this.label11.Text = "[Area] + \"ha\" +                          [Quant]/1000 + \"thnds.\"";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(311, 121);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnClearClick);
            // 
            // btnNewLine
            // 
            this.btnNewLine.Location = new System.Drawing.Point(288, 152);
            this.btnNewLine.Name = "btnNewLine";
            this.btnNewLine.Size = new System.Drawing.Size(97, 25);
            this.btnNewLine.TabIndex = 42;
            this.btnNewLine.Text = "New line";
            this.btnNewLine.UseVisualStyleBackColor = true;
            this.btnNewLine.Click += new System.EventHandler(this.OnNewLineClick);
            // 
            // btnQuotes
            // 
            this.btnQuotes.Location = new System.Drawing.Point(256, 152);
            this.btnQuotes.Name = "btnQuotes";
            this.btnQuotes.Size = new System.Drawing.Size(28, 25);
            this.btnQuotes.TabIndex = 41;
            this.btnQuotes.Text = "\" \"";
            this.btnQuotes.UseVisualStyleBackColor = true;
            this.btnQuotes.Click += new System.EventHandler(this.OnQuotesClick);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(224, 152);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(28, 25);
            this.btnPlus.TabIndex = 40;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.OnPlusClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.listBox1);
            this.groupBox7.Location = new System.Drawing.Point(15, 121);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(200, 175);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Fields";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(194, 156);
            this.listBox1.TabIndex = 37;
            this.listBox1.DoubleClick += new System.EventHandler(this.OnFieldListBoxDoubleClick);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtExpression);
            this.groupBox8.Location = new System.Drawing.Point(15, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(371, 103);
            this.groupBox8.TabIndex = 38;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Expression";
            // 
            // txtExpression
            // 
            this.txtExpression.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpression.Location = new System.Drawing.Point(3, 16);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(365, 84);
            this.txtExpression.TabIndex = 15;
            this.txtExpression.Text = "";
            this.txtExpression.TextChanged += new System.EventHandler(this.OnExpressionChanged);
            // 
            // groupBox5
            // 
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
            this.groupBox5.Location = new System.Drawing.Point(15, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(368, 140);
            this.groupBox5.TabIndex = 123;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Font style";
            // 
            // cboTextRenderingHint
            // 
            this.cboTextRenderingHint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextRenderingHint.FormattingEnabled = true;
            this.cboTextRenderingHint.Location = new System.Drawing.Point(98, 101);
            this.cboTextRenderingHint.Name = "cboTextRenderingHint";
            this.cboTextRenderingHint.Size = new System.Drawing.Size(245, 21);
            this.cboTextRenderingHint.TabIndex = 127;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(15, 104);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(76, 13);
            this.label32.TabIndex = 126;
            this.label32.Text = "Rendering hint";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Color";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(15, 36);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(28, 13);
            this.label35.TabIndex = 61;
            this.label35.Text = "Font";
            // 
            // cboFontName
            // 
            this.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontName.FormattingEnabled = true;
            this.cboFontName.Location = new System.Drawing.Point(66, 33);
            this.cboFontName.Name = "cboFontName";
            this.cboFontName.Size = new System.Drawing.Size(177, 21);
            this.cboFontName.TabIndex = 58;
            this.cboFontName.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkFontStrikeout
            // 
            this.chkFontStrikeout.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFontStrikeout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkFontStrikeout.Image = ((System.Drawing.Image)(resources.GetObject("chkFontStrikeout.Image")));
            this.chkFontStrikeout.Location = new System.Drawing.Point(168, 60);
            this.chkFontStrikeout.Name = "chkFontStrikeout";
            this.chkFontStrikeout.Size = new System.Drawing.Size(27, 26);
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
            this.chkFontUnderline.Location = new System.Drawing.Point(133, 60);
            this.chkFontUnderline.Name = "chkFontUnderline";
            this.chkFontUnderline.Size = new System.Drawing.Size(28, 26);
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
            this.chkFontItalic.Location = new System.Drawing.Point(65, 60);
            this.chkFontItalic.Name = "chkFontItalic";
            this.chkFontItalic.Size = new System.Drawing.Size(26, 26);
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
            this.clpFont1.Location = new System.Drawing.Point(281, 33);
            this.clpFont1.Name = "clpFont1";
            this.clpFont1.Size = new System.Drawing.Size(50, 21);
            this.clpFont1.TabIndex = 103;
            this.clpFont1.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkFontBold
            // 
            this.chkFontBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFontBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chkFontBold.Image = ((System.Drawing.Image)(resources.GetObject("chkFontBold.Image")));
            this.chkFontBold.Location = new System.Drawing.Point(98, 60);
            this.chkFontBold.Name = "chkFontBold";
            this.chkFontBold.Size = new System.Drawing.Size(28, 26);
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
            this.groupBox3.Location = new System.Drawing.Point(15, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 140);
            this.groupBox3.TabIndex = 122;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Outline";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(278, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 122;
            this.label9.Text = "Offset Y";
            // 
            // udShadowOffsetY
            // 
            this.udShadowOffsetY.Location = new System.Drawing.Point(210, 106);
            this.udShadowOffsetY.Name = "udShadowOffsetY";
            this.udShadowOffsetY.Size = new System.Drawing.Size(52, 20);
            this.udShadowOffsetY.TabIndex = 121;
            this.udShadowOffsetY.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // udShadowOffsetX
            // 
            this.udShadowOffsetX.Location = new System.Drawing.Point(210, 71);
            this.udShadowOffsetX.Name = "udShadowOffsetX";
            this.udShadowOffsetX.Size = new System.Drawing.Size(52, 20);
            this.udShadowOffsetX.TabIndex = 120;
            this.udShadowOffsetX.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // udHaloSize
            // 
            this.udHaloSize.Location = new System.Drawing.Point(210, 29);
            this.udHaloSize.Name = "udHaloSize";
            this.udHaloSize.Size = new System.Drawing.Size(52, 20);
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
            this.clpShadow.Location = new System.Drawing.Point(96, 71);
            this.clpShadow.Name = "clpShadow";
            this.clpShadow.Size = new System.Drawing.Size(67, 21);
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
            this.clpHalo.Location = new System.Drawing.Point(96, 30);
            this.clpHalo.Name = "clpHalo";
            this.clpHalo.Size = new System.Drawing.Size(68, 21);
            this.clpHalo.TabIndex = 117;
            this.clpHalo.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(278, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 115;
            this.label12.Text = "Offset X";
            // 
            // chkShadowVisible
            // 
            this.chkShadowVisible.AutoSize = true;
            this.chkShadowVisible.Location = new System.Drawing.Point(25, 73);
            this.chkShadowVisible.Name = "chkShadowVisible";
            this.chkShadowVisible.Size = new System.Drawing.Size(65, 17);
            this.chkShadowVisible.TabIndex = 113;
            this.chkShadowVisible.Text = "Shadow";
            this.chkShadowVisible.UseVisualStyleBackColor = true;
            this.chkShadowVisible.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(278, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 112;
            this.label15.Text = "Size";
            // 
            // chkHaloVisible
            // 
            this.chkHaloVisible.AutoSize = true;
            this.chkHaloVisible.Location = new System.Drawing.Point(26, 32);
            this.chkHaloVisible.Name = "chkHaloVisible";
            this.chkHaloVisible.Size = new System.Drawing.Size(48, 17);
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
            this.groupBox4.Location = new System.Drawing.Point(20, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 148);
            this.groupBox4.TabIndex = 142;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Style";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(128, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 135;
            this.label10.Text = "X:";
            // 
            // udFramePaddingY
            // 
            this.udFramePaddingY.Location = new System.Drawing.Point(254, 100);
            this.udFramePaddingY.Name = "udFramePaddingY";
            this.udFramePaddingY.Size = new System.Drawing.Size(54, 20);
            this.udFramePaddingY.TabIndex = 134;
            this.udFramePaddingY.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Frame type";
            // 
            // udFramePaddingX
            // 
            this.udFramePaddingX.Location = new System.Drawing.Point(152, 100);
            this.udFramePaddingX.Name = "udFramePaddingX";
            this.udFramePaddingX.Size = new System.Drawing.Size(54, 20);
            this.udFramePaddingX.TabIndex = 133;
            this.udFramePaddingX.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "Y:";
            // 
            // btnSetFrameGradient
            // 
            this.btnSetFrameGradient.Location = new System.Drawing.Point(224, 57);
            this.btnSetFrameGradient.Name = "btnSetFrameGradient";
            this.btnSetFrameGradient.Size = new System.Drawing.Size(84, 21);
            this.btnSetFrameGradient.TabIndex = 117;
            this.btnSetFrameGradient.Text = "Gradient...";
            this.btnSetFrameGradient.UseVisualStyleBackColor = true;
            this.btnSetFrameGradient.Click += new System.EventHandler(this.OnSetFrameGradientClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "Padding";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 61);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
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
            this.icbFrameType.Location = new System.Drawing.Point(131, 21);
            this.icbFrameType.Name = "icbFrameType";
            this.icbFrameType.OutlineColor = System.Drawing.Color.Black;
            this.icbFrameType.Size = new System.Drawing.Size(177, 21);
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
            this.clpFrame1.Location = new System.Drawing.Point(131, 58);
            this.clpFrame1.Name = "clpFrame1";
            this.clpFrame1.Size = new System.Drawing.Size(75, 21);
            this.clpFrame1.TabIndex = 106;
            this.clpFrame1.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkUseFrame
            // 
            this.chkUseFrame.AutoSize = true;
            this.chkUseFrame.Location = new System.Drawing.Point(308, 18);
            this.chkUseFrame.Name = "chkUseFrame";
            this.chkUseFrame.Size = new System.Drawing.Size(80, 17);
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
            this.groupBox2.Location = new System.Drawing.Point(20, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 94);
            this.groupBox2.TabIndex = 141;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outline";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 23);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 140;
            this.label19.Text = "Color";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 136;
            this.label17.Text = "Width";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(198, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 13);
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
            this.icbLineWidth.Location = new System.Drawing.Point(87, 56);
            this.icbLineWidth.Name = "icbLineWidth";
            this.icbLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.icbLineWidth.Size = new System.Drawing.Size(68, 21);
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
            this.icbLineType.Location = new System.Drawing.Point(234, 19);
            this.icbLineType.Name = "icbLineType";
            this.icbLineType.OutlineColor = System.Drawing.Color.Black;
            this.icbLineType.Size = new System.Drawing.Size(68, 21);
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
            this.clpFrameBorder.Location = new System.Drawing.Point(87, 20);
            this.clpFrameBorder.Name = "clpFrameBorder";
            this.clpFrameBorder.Size = new System.Drawing.Size(68, 21);
            this.clpFrameBorder.TabIndex = 137;
            this.clpFrameBorder.SelectedColorChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnSetCurrent);
            this.groupBox12.Controls.Add(this.cboBasicScale);
            this.groupBox12.Controls.Add(this.lblScaleLabels);
            this.groupBox12.Controls.Add(this.chkScaleLabels);
            this.groupBox12.Location = new System.Drawing.Point(199, 143);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(183, 150);
            this.groupBox12.TabIndex = 166;
            this.groupBox12.TabStop = false;
            // 
            // btnSetCurrent
            // 
            this.btnSetCurrent.Location = new System.Drawing.Point(80, 108);
            this.btnSetCurrent.Name = "btnSetCurrent";
            this.btnSetCurrent.Size = new System.Drawing.Size(81, 23);
            this.btnSetCurrent.TabIndex = 3;
            this.btnSetCurrent.Text = "Current";
            this.btnSetCurrent.UseVisualStyleBackColor = true;
            this.btnSetCurrent.Click += new System.EventHandler(this.OnSetCurrentClick);
            // 
            // cboBasicScale
            // 
            this.cboBasicScale.FormattingEnabled = true;
            this.cboBasicScale.Location = new System.Drawing.Point(18, 81);
            this.cboBasicScale.Name = "cboBasicScale";
            this.cboBasicScale.Size = new System.Drawing.Size(143, 21);
            this.cboBasicScale.TabIndex = 2;
            this.cboBasicScale.TextChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // lblScaleLabels
            // 
            this.lblScaleLabels.Location = new System.Drawing.Point(15, 64);
            this.lblScaleLabels.Name = "lblScaleLabels";
            this.lblScaleLabels.Size = new System.Drawing.Size(146, 14);
            this.lblScaleLabels.TabIndex = 1;
            this.lblScaleLabels.Text = "Scale to use normal font size:";
            // 
            // chkScaleLabels
            // 
            this.chkScaleLabels.AutoSize = true;
            this.chkScaleLabels.Location = new System.Drawing.Point(18, 35);
            this.chkScaleLabels.Name = "chkScaleLabels";
            this.chkScaleLabels.Size = new System.Drawing.Size(83, 17);
            this.chkScaleLabels.TabIndex = 0;
            this.chkScaleLabels.Text = "Scale labels";
            this.chkScaleLabels.UseVisualStyleBackColor = true;
            this.chkScaleLabels.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.chkAviodCollisions);
            this.groupBox20.Controls.Add(this.chkLabelsRemoveDuplicates);
            this.groupBox20.Controls.Add(this.lblLabelVerticalPosition);
            this.groupBox20.Controls.Add(this.cboLabelsVerticalPosition);
            this.groupBox20.Location = new System.Drawing.Point(19, 143);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(167, 150);
            this.groupBox20.TabIndex = 165;
            this.groupBox20.TabStop = false;
            // 
            // chkAviodCollisions
            // 
            this.chkAviodCollisions.AutoSize = true;
            this.chkAviodCollisions.Location = new System.Drawing.Point(18, 114);
            this.chkAviodCollisions.Name = "chkAviodCollisions";
            this.chkAviodCollisions.Size = new System.Drawing.Size(98, 17);
            this.chkAviodCollisions.TabIndex = 129;
            this.chkAviodCollisions.Text = "Avoid collisions";
            this.chkAviodCollisions.UseVisualStyleBackColor = true;
            this.chkAviodCollisions.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // chkLabelsRemoveDuplicates
            // 
            this.chkLabelsRemoveDuplicates.AutoSize = true;
            this.chkLabelsRemoveDuplicates.Location = new System.Drawing.Point(18, 79);
            this.chkLabelsRemoveDuplicates.Name = "chkLabelsRemoveDuplicates";
            this.chkLabelsRemoveDuplicates.Size = new System.Drawing.Size(117, 17);
            this.chkLabelsRemoveDuplicates.TabIndex = 128;
            this.chkLabelsRemoveDuplicates.Text = "Remove duplicates";
            this.chkLabelsRemoveDuplicates.UseVisualStyleBackColor = true;
            this.chkLabelsRemoveDuplicates.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // lblLabelVerticalPosition
            // 
            this.lblLabelVerticalPosition.AutoSize = true;
            this.lblLabelVerticalPosition.Location = new System.Drawing.Point(13, 21);
            this.lblLabelVerticalPosition.Name = "lblLabelVerticalPosition";
            this.lblLabelVerticalPosition.Size = new System.Drawing.Size(84, 13);
            this.lblLabelVerticalPosition.TabIndex = 126;
            this.lblLabelVerticalPosition.Text = "Vertical position:";
            // 
            // cboLabelsVerticalPosition
            // 
            this.cboLabelsVerticalPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabelsVerticalPosition.FormattingEnabled = true;
            this.cboLabelsVerticalPosition.Location = new System.Drawing.Point(14, 37);
            this.cboLabelsVerticalPosition.Name = "cboLabelsVerticalPosition";
            this.cboLabelsVerticalPosition.Size = new System.Drawing.Size(127, 21);
            this.cboLabelsVerticalPosition.TabIndex = 124;
            this.cboLabelsVerticalPosition.SelectedIndexChanged += new System.EventHandler(this.Ui2LabelStyle);
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
            this.groupLabelAlignment.Location = new System.Drawing.Point(19, 15);
            this.groupLabelAlignment.Name = "groupLabelAlignment";
            this.groupLabelAlignment.Size = new System.Drawing.Size(363, 122);
            this.groupLabelAlignment.TabIndex = 164;
            this.groupLabelAlignment.TabStop = false;
            this.groupLabelAlignment.Text = "Alignment";
            // 
            // udLabelOffsetY
            // 
            this.udLabelOffsetY.Location = new System.Drawing.Point(135, 53);
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
            this.udLabelOffsetY.Size = new System.Drawing.Size(54, 20);
            this.udLabelOffsetY.TabIndex = 159;
            this.udLabelOffsetY.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // udLabelOffsetX
            // 
            this.udLabelOffsetX.Location = new System.Drawing.Point(135, 22);
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
            this.udLabelOffsetX.Size = new System.Drawing.Size(54, 20);
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
            this.udLabelsBuffer.Location = new System.Drawing.Point(135, 82);
            this.udLabelsBuffer.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.udLabelsBuffer.Name = "udLabelsBuffer";
            this.udLabelsBuffer.Size = new System.Drawing.Size(54, 20);
            this.udLabelsBuffer.TabIndex = 157;
            this.udLabelsBuffer.ValueChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(198, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 156;
            this.label14.Text = "Buffer distance";
            // 
            // optAlignBottomRight
            // 
            this.optAlignBottomRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignBottomRight.Image = ((System.Drawing.Image)(resources.GetObject("optAlignBottomRight.Image")));
            this.optAlignBottomRight.Location = new System.Drawing.Point(85, 79);
            this.optAlignBottomRight.Name = "optAlignBottomRight";
            this.optAlignBottomRight.Size = new System.Drawing.Size(30, 23);
            this.optAlignBottomRight.TabIndex = 148;
            this.optAlignBottomRight.TabStop = true;
            this.optAlignBottomRight.UseVisualStyleBackColor = true;
            this.optAlignBottomRight.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // lblLabelsOffsetY
            // 
            this.lblLabelsOffsetY.AutoSize = true;
            this.lblLabelsOffsetY.Location = new System.Drawing.Point(198, 55);
            this.lblLabelsOffsetY.Name = "lblLabelsOffsetY";
            this.lblLabelsOffsetY.Size = new System.Drawing.Size(71, 13);
            this.lblLabelsOffsetY.TabIndex = 154;
            this.lblLabelsOffsetY.Text = "Vertical offset";
            // 
            // optAlignBottomCenter
            // 
            this.optAlignBottomCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignBottomCenter.Image = ((System.Drawing.Image)(resources.GetObject("optAlignBottomCenter.Image")));
            this.optAlignBottomCenter.Location = new System.Drawing.Point(49, 79);
            this.optAlignBottomCenter.Name = "optAlignBottomCenter";
            this.optAlignBottomCenter.Size = new System.Drawing.Size(30, 23);
            this.optAlignBottomCenter.TabIndex = 147;
            this.optAlignBottomCenter.TabStop = true;
            this.optAlignBottomCenter.UseVisualStyleBackColor = true;
            this.optAlignBottomCenter.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // lblLabelsOffsetX
            // 
            this.lblLabelsOffsetX.AutoSize = true;
            this.lblLabelsOffsetX.Location = new System.Drawing.Point(198, 24);
            this.lblLabelsOffsetX.Name = "lblLabelsOffsetX";
            this.lblLabelsOffsetX.Size = new System.Drawing.Size(83, 13);
            this.lblLabelsOffsetX.TabIndex = 150;
            this.lblLabelsOffsetX.Text = "Horizontal offset";
            // 
            // optAlignBottomLeft
            // 
            this.optAlignBottomLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignBottomLeft.Image = ((System.Drawing.Image)(resources.GetObject("optAlignBottomLeft.Image")));
            this.optAlignBottomLeft.Location = new System.Drawing.Point(13, 79);
            this.optAlignBottomLeft.Name = "optAlignBottomLeft";
            this.optAlignBottomLeft.Size = new System.Drawing.Size(30, 23);
            this.optAlignBottomLeft.TabIndex = 146;
            this.optAlignBottomLeft.TabStop = true;
            this.optAlignBottomLeft.UseVisualStyleBackColor = true;
            this.optAlignBottomLeft.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignCenterRight
            // 
            this.optAlignCenterRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignCenterRight.Image = ((System.Drawing.Image)(resources.GetObject("optAlignCenterRight.Image")));
            this.optAlignCenterRight.Location = new System.Drawing.Point(86, 50);
            this.optAlignCenterRight.Name = "optAlignCenterRight";
            this.optAlignCenterRight.Size = new System.Drawing.Size(30, 23);
            this.optAlignCenterRight.TabIndex = 145;
            this.optAlignCenterRight.TabStop = true;
            this.optAlignCenterRight.UseVisualStyleBackColor = true;
            this.optAlignCenterRight.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignCenter
            // 
            this.optAlignCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("optAlignCenter.Image")));
            this.optAlignCenter.Location = new System.Drawing.Point(50, 50);
            this.optAlignCenter.Name = "optAlignCenter";
            this.optAlignCenter.Size = new System.Drawing.Size(30, 23);
            this.optAlignCenter.TabIndex = 144;
            this.optAlignCenter.TabStop = true;
            this.optAlignCenter.UseVisualStyleBackColor = true;
            this.optAlignCenter.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignCenterLeft
            // 
            this.optAlignCenterLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignCenterLeft.Image = ((System.Drawing.Image)(resources.GetObject("optAlignCenterLeft.Image")));
            this.optAlignCenterLeft.Location = new System.Drawing.Point(14, 50);
            this.optAlignCenterLeft.Name = "optAlignCenterLeft";
            this.optAlignCenterLeft.Size = new System.Drawing.Size(30, 23);
            this.optAlignCenterLeft.TabIndex = 143;
            this.optAlignCenterLeft.TabStop = true;
            this.optAlignCenterLeft.UseVisualStyleBackColor = true;
            this.optAlignCenterLeft.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignTopRight
            // 
            this.optAlignTopRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignTopRight.Image = ((System.Drawing.Image)(resources.GetObject("optAlignTopRight.Image")));
            this.optAlignTopRight.Location = new System.Drawing.Point(86, 21);
            this.optAlignTopRight.Name = "optAlignTopRight";
            this.optAlignTopRight.Size = new System.Drawing.Size(30, 23);
            this.optAlignTopRight.TabIndex = 142;
            this.optAlignTopRight.TabStop = true;
            this.optAlignTopRight.UseVisualStyleBackColor = true;
            this.optAlignTopRight.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignTopCenter
            // 
            this.optAlignTopCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignTopCenter.Image = ((System.Drawing.Image)(resources.GetObject("optAlignTopCenter.Image")));
            this.optAlignTopCenter.Location = new System.Drawing.Point(50, 21);
            this.optAlignTopCenter.Name = "optAlignTopCenter";
            this.optAlignTopCenter.Size = new System.Drawing.Size(30, 23);
            this.optAlignTopCenter.TabIndex = 141;
            this.optAlignTopCenter.TabStop = true;
            this.optAlignTopCenter.UseVisualStyleBackColor = true;
            this.optAlignTopCenter.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // optAlignTopLeft
            // 
            this.optAlignTopLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlignTopLeft.Image = ((System.Drawing.Image)(resources.GetObject("optAlignTopLeft.Image")));
            this.optAlignTopLeft.Location = new System.Drawing.Point(14, 21);
            this.optAlignTopLeft.Name = "optAlignTopLeft";
            this.optAlignTopLeft.Size = new System.Drawing.Size(30, 23);
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
            this.groupBox11.Location = new System.Drawing.Point(23, 221);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(355, 86);
            this.groupBox11.TabIndex = 172;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Visibility expression";
            // 
            // txtLabelExpression
            // 
            this.txtLabelExpression.Location = new System.Drawing.Point(20, 22);
            this.txtLabelExpression.Multiline = true;
            this.txtLabelExpression.Name = "txtLabelExpression";
            this.txtLabelExpression.ReadOnly = true;
            this.txtLabelExpression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLabelExpression.Size = new System.Drawing.Size(264, 50);
            this.txtLabelExpression.TabIndex = 168;
            // 
            // btnLabelExpression
            // 
            this.btnLabelExpression.Location = new System.Drawing.Point(290, 22);
            this.btnLabelExpression.Name = "btnLabelExpression";
            this.btnLabelExpression.Size = new System.Drawing.Size(51, 22);
            this.btnLabelExpression.TabIndex = 169;
            this.btnLabelExpression.Text = "Edit";
            this.btnLabelExpression.UseVisualStyleBackColor = true;
            this.btnLabelExpression.Click += new System.EventHandler(this.OnLabelExpressionClick);
            // 
            // btnClearLabelsExpression
            // 
            this.btnClearLabelsExpression.Location = new System.Drawing.Point(290, 50);
            this.btnClearLabelsExpression.Name = "btnClearLabelsExpression";
            this.btnClearLabelsExpression.Size = new System.Drawing.Size(51, 22);
            this.btnClearLabelsExpression.TabIndex = 170;
            this.btnClearLabelsExpression.Text = "Clear";
            this.btnClearLabelsExpression.UseVisualStyleBackColor = true;
            this.btnClearLabelsExpression.Click += new System.EventHandler(this.OnClearLabelsExpressionClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Size";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(417, 363);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.OnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(515, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 26);
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
            this.comboBox1.Size = new System.Drawing.Size(160, 21);
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
            this.comboBox2.Size = new System.Drawing.Size(161, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(300, 199);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(79, 21);
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
            this.comboBox12.Size = new System.Drawing.Size(79, 21);
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
            this.comboBox13.Size = new System.Drawing.Size(79, 21);
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
            this.comboBox14.Size = new System.Drawing.Size(132, 21);
            this.comboBox14.TabIndex = 50;
            // 
            // comboBox15
            // 
            this.comboBox15.FormattingEnabled = true;
            this.comboBox15.Location = new System.Drawing.Point(104, 22);
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(152, 21);
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
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 162);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // pctPreview
            // 
            this.pctPreview.BackColor = System.Drawing.Color.Transparent;
            this.pctPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctPreview.Location = new System.Drawing.Point(3, 16);
            this.pctPreview.Name = "pctPreview";
            this.pctPreview.Size = new System.Drawing.Size(186, 143);
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
            this.groupBox6.Location = new System.Drawing.Point(11, 176);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(189, 183);
            this.groupBox6.TabIndex = 134;
            this.groupBox6.TabStop = false;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(109, 80);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(16, 13);
            this.label36.TabIndex = 122;
            this.label36.Text = "to";
            // 
            // udFontSize2
            // 
            this.udFontSize2.Location = new System.Drawing.Point(130, 78);
            this.udFontSize2.Name = "udFontSize2";
            this.udFontSize2.Size = new System.Drawing.Size(50, 20);
            this.udFontSize2.TabIndex = 121;
            this.udFontSize2.ValueChanged += new System.EventHandler(this.UpdateSize);
            // 
            // chkVisible
            // 
            this.chkVisible.AutoSize = true;
            this.chkVisible.Location = new System.Drawing.Point(23, 35);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(89, 17);
            this.chkVisible.TabIndex = 120;
            this.chkVisible.Text = "Labels visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            this.chkVisible.CheckedChanged += new System.EventHandler(this.Ui2LabelStyle);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 119;
            this.label7.Text = "Transparency";
            // 
            // transparencyControl1
            // 
            this.transparencyControl1.BandColor = System.Drawing.Color.Empty;
            this.transparencyControl1.Location = new System.Drawing.Point(23, 139);
            this.transparencyControl1.MaximumSize = new System.Drawing.Size(1024, 32);
            this.transparencyControl1.MinimumSize = new System.Drawing.Size(128, 32);
            this.transparencyControl1.Name = "transparencyControl1";
            this.transparencyControl1.Size = new System.Drawing.Size(157, 32);
            this.transparencyControl1.TabIndex = 118;
            this.transparencyControl1.Value = ((byte)(255));
            this.transparencyControl1.ValueChanged += new MW5.UI.Controls.TransparencyControl.ValueChangedDeleg(this.OnTransparencyControlValueChanged);
            // 
            // udFontSize
            // 
            this.udFontSize.Location = new System.Drawing.Point(53, 78);
            this.udFontSize.Name = "udFontSize";
            this.udFontSize.Size = new System.Drawing.Size(50, 20);
            this.udFontSize.TabIndex = 105;
            this.udFontSize.ValueChanged += new System.EventHandler(this.UpdateSize);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(14, 368);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(296, 19);
            this.lblResult.TabIndex = 44;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(316, 363);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 26);
            this.btnApply.TabIndex = 135;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnApplyClick);
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(402, 347);
            this.tabControlAdv1.Controls.Add(this.tabMain);
            this.tabControlAdv1.Controls.Add(this.tabExpression);
            this.tabControlAdv1.Controls.Add(this.tabPosition);
            this.tabControlAdv1.Controls.Add(this.tabVisibility);
            this.tabControlAdv1.Controls.Add(this.tabFont);
            this.tabControlAdv1.Controls.Add(this.tabFrame);
            this.tabControlAdv1.Location = new System.Drawing.Point(209, 12);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Size = new System.Drawing.Size(402, 347);
            this.tabControlAdv1.TabIndex = 177;
            // 
            // tabMain
            // 
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
            this.tabMain.Location = new System.Drawing.Point(1, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.ShowCloseButton = true;
            this.tabMain.Size = new System.Drawing.Size(399, 320);
            this.tabMain.TabIndex = 1;
            this.tabMain.Text = "Main";
            this.tabMain.ThemesEnabled = false;
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
            this.tabExpression.Location = new System.Drawing.Point(1, 25);
            this.tabExpression.Name = "tabExpression";
            this.tabExpression.ShowCloseButton = true;
            this.tabExpression.Size = new System.Drawing.Size(399, 320);
            this.tabExpression.TabIndex = 2;
            this.tabExpression.Text = "Expression";
            this.tabExpression.ThemesEnabled = false;
            // 
            // tabPosition
            // 
            this.tabPosition.Controls.Add(this.groupBox12);
            this.tabPosition.Controls.Add(this.groupLabelAlignment);
            this.tabPosition.Controls.Add(this.groupBox20);
            this.tabPosition.Image = null;
            this.tabPosition.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPosition.Location = new System.Drawing.Point(1, 25);
            this.tabPosition.Name = "tabPosition";
            this.tabPosition.ShowCloseButton = true;
            this.tabPosition.Size = new System.Drawing.Size(399, 320);
            this.tabPosition.TabIndex = 6;
            this.tabPosition.Text = "Position";
            this.tabPosition.ThemesEnabled = false;
            // 
            // tabVisibility
            // 
            this.tabVisibility.Controls.Add(this.dynamicVisibilityControl1);
            this.tabVisibility.Controls.Add(this.groupBox11);
            this.tabVisibility.Image = null;
            this.tabVisibility.ImageSize = new System.Drawing.Size(16, 16);
            this.tabVisibility.Location = new System.Drawing.Point(1, 25);
            this.tabVisibility.Name = "tabVisibility";
            this.tabVisibility.ShowCloseButton = true;
            this.tabVisibility.Size = new System.Drawing.Size(399, 320);
            this.tabVisibility.TabIndex = 3;
            this.tabVisibility.Text = "Visibility";
            this.tabVisibility.ThemesEnabled = false;
            // 
            // dynamicVisibilityControl1
            // 
            this.dynamicVisibilityControl1.CurrentScale = 0D;
            this.dynamicVisibilityControl1.CurrentZoom = 0;
            this.dynamicVisibilityControl1.Location = new System.Drawing.Point(23, 12);
            this.dynamicVisibilityControl1.MaxScale = 1000000D;
            this.dynamicVisibilityControl1.MaxZoom = 24;
            this.dynamicVisibilityControl1.MinScale = 100D;
            this.dynamicVisibilityControl1.MinZoom = 1;
            this.dynamicVisibilityControl1.Mode = MW5.Api.Enums.DynamicVisibilityMode.Scale;
            this.dynamicVisibilityControl1.Name = "dynamicVisibilityControl1";
            this.dynamicVisibilityControl1.Size = new System.Drawing.Size(355, 199);
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
            this.tabFont.Location = new System.Drawing.Point(1, 25);
            this.tabFont.Name = "tabFont";
            this.tabFont.ShowCloseButton = true;
            this.tabFont.Size = new System.Drawing.Size(399, 320);
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
            this.tabFrame.Location = new System.Drawing.Point(1, 25);
            this.tabFrame.Name = "tabFrame";
            this.tabFrame.ShowCloseButton = true;
            this.tabFrame.Size = new System.Drawing.Size(399, 320);
            this.tabFrame.TabIndex = 5;
            this.tabFrame.Text = "Frame";
            this.tabFrame.ThemesEnabled = false;
            // 
            // LabelStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(620, 393);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
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
            this.tabExpression.ResumeLayout(false);
            this.tabPosition.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.CheckBox chkLabelsRemoveDuplicates;
        private System.Windows.Forms.Label lblLabelVerticalPosition;
        private System.Windows.Forms.ComboBox cboLabelsVerticalPosition;
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
        private System.Windows.Forms.CheckBox chkAviodCollisions;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnSetCurrent;
        private System.Windows.Forms.ComboBox cboBasicScale;
        private System.Windows.Forms.Label lblScaleLabels;
        private System.Windows.Forms.CheckBox chkScaleLabels;
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

    }
}