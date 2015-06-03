using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ListControls;
using MW5.UI.Controls;

namespace MW5.Plugins.Symbology.Forms
{
    partial class PointsForm
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.udSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udRotation = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.clpFillColor = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSymbol = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.transparencyControl1 = new MW5.UI.Controls.TransparencyControl();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.udPointNumSides = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udSideRatio = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.symbolControl1 = new MW5.Plugins.Symbology.Controls.ListControls.SymbolControl();
            this.icbPointShape = new MW5.UI.Controls.ImageCombo();
            this.label17 = new System.Windows.Forms.Label();
            this.tabCharacter = new System.Windows.Forms.TabPage();
            this.chkShowAllFonts = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cboFontName = new System.Windows.Forms.ComboBox();
            this.characterControl1 = new MW5.Plugins.Symbology.Controls.ListControls.CharacterControl();
            this.tabIcon = new System.Windows.Forms.TabPage();
            this.pointIconControl1 = new MW5.Plugins.Symbology.Controls.PointIconControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblNoOptions = new System.Windows.Forms.Label();
            this.chkFillVisible = new System.Windows.Forms.CheckBox();
            this.pnlFillHatch = new System.Windows.Forms.Panel();
            this.icbHatchStyle = new MW5.UI.Controls.ImageCombo();
            this.label6 = new System.Windows.Forms.Label();
            this.chkFillBgTransparent = new System.Windows.Forms.CheckBox();
            this.clpHatchBack = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboFillType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkOutlineVisible = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.icbLineWidth = new MW5.UI.Controls.ImageCombo();
            this.icbLineType = new MW5.UI.Controls.ImageCombo();
            this.clpOutline = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pctPreview = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlFillGradient = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.udGradientRotation = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.clpGradient2 = new MW5.UI.Controls.Office2007ColorPicker(this.components);
            this.cboGradientType = new System.Windows.Forms.ComboBox();
            this.pnlFillPicture = new System.Windows.Forms.Panel();
            this.btnChooseTexture = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRotation)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabSymbol.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPointNumSides)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSideRatio)).BeginInit();
            this.tabCharacter.SuspendLayout();
            this.tabIcon.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlFillHatch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).BeginInit();
            this.pnlFillGradient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udGradientRotation)).BeginInit();
            this.pnlFillPicture.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Location = new System.Drawing.Point(9, 175);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 177);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.udSize);
            this.panel1.Controls.Add(this.udRotation);
            this.panel1.Controls.Add(this.clpFillColor);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 158);
            this.panel1.TabIndex = 35;
            // 
            // udSize
            // 
            this.udSize.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udSize.Location = new System.Drawing.Point(106, 22);
            this.udSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udSize.Name = "udSize";
            this.udSize.Size = new System.Drawing.Size(49, 20);
            this.udSize.TabIndex = 15;
            this.udSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // udRotation
            // 
            this.udRotation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udRotation.Location = new System.Drawing.Point(106, 67);
            this.udRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udRotation.Name = "udRotation";
            this.udRotation.Size = new System.Drawing.Size(49, 20);
            this.udRotation.TabIndex = 25;
            this.udRotation.ValueChanged += new System.EventHandler(this.Gui2Options);
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
            this.clpFillColor.Location = new System.Drawing.Point(96, 110);
            this.clpFillColor.Name = "clpFillColor";
            this.clpFillColor.Size = new System.Drawing.Size(59, 21);
            this.clpFillColor.TabIndex = 86;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(19, 113);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(31, 13);
            this.label34.TabIndex = 29;
            this.label34.Text = "Color";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(18, 69);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(47, 13);
            this.label33.TabIndex = 26;
            this.label33.Text = "Rotation";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(19, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(27, 13);
            this.label32.TabIndex = 16;
            this.label32.Text = "Size";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSymbol);
            this.tabControl1.Controls.Add(this.tabCharacter);
            this.tabControl1.Controls.Add(this.tabIcon);
            this.tabControl1.Controls.Add(this.tabOptions);
            this.tabControl1.Location = new System.Drawing.Point(191, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 340);
            this.tabControl1.TabIndex = 37;
            // 
            // tabSymbol
            // 
            this.tabSymbol.Controls.Add(this.label3);
            this.tabSymbol.Controls.Add(this.transparencyControl1);
            this.tabSymbol.Controls.Add(this.groupBox5);
            this.tabSymbol.Controls.Add(this.symbolControl1);
            this.tabSymbol.Controls.Add(this.icbPointShape);
            this.tabSymbol.Controls.Add(this.label17);
            this.tabSymbol.Location = new System.Drawing.Point(4, 22);
            this.tabSymbol.Name = "tabSymbol";
            this.tabSymbol.Size = new System.Drawing.Size(415, 314);
            this.tabSymbol.TabIndex = 2;
            this.tabSymbol.Text = "Points";
            this.tabSymbol.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 137;
            this.label3.Text = "Transparency";
            // 
            // transparencyControl1
            // 
            this.transparencyControl1.BandColor = System.Drawing.Color.Empty;
            this.transparencyControl1.Location = new System.Drawing.Point(116, 240);
            this.transparencyControl1.MaximumSize = new System.Drawing.Size(1024, 32);
            this.transparencyControl1.MinimumSize = new System.Drawing.Size(128, 32);
            this.transparencyControl1.Name = "transparencyControl1";
            this.transparencyControl1.Size = new System.Drawing.Size(283, 32);
            this.transparencyControl1.TabIndex = 136;
            this.transparencyControl1.Value = ((byte)(255));
            this.transparencyControl1.ValueChanged += new MW5.UI.Controls.TransparencyControl.ValueChangedDeleg(this.transparencyControl1_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.udPointNumSides);
            this.groupBox5.Controls.Add(this.udSideRatio);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Location = new System.Drawing.Point(10, 67);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(389, 68);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            // 
            // udPointNumSides
            // 
            this.udPointNumSides.Location = new System.Drawing.Point(106, 25);
            this.udPointNumSides.Name = "udPointNumSides";
            this.udPointNumSides.Size = new System.Drawing.Size(56, 20);
            this.udPointNumSides.TabIndex = 24;
            // 
            // udSideRatio
            // 
            this.udSideRatio.Location = new System.Drawing.Point(285, 25);
            this.udSideRatio.Name = "udSideRatio";
            this.udSideRatio.Size = new System.Drawing.Size(58, 20);
            this.udSideRatio.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(177, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Side ratio";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Side count";
            // 
            // symbolControl1
            // 
            this.symbolControl1.BackColor = System.Drawing.Color.Transparent;
            this.symbolControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.symbolControl1.CellHeight = 24;
            this.symbolControl1.CellWidth = 24;
            this.symbolControl1.Font = new System.Drawing.Font("Arial", 25.6F);
            this.symbolControl1.GridColor = System.Drawing.Color.Black;
            this.symbolControl1.GridVisible = false;
            this.symbolControl1.ItemCount = 17;
            this.symbolControl1.Location = new System.Drawing.Point(10, 147);
            this.symbolControl1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.symbolControl1.Name = "symbolControl1";
            this.symbolControl1.SelectedIndex = -1;
            this.symbolControl1.Size = new System.Drawing.Size(389, 72);
            this.symbolControl1.TabIndex = 26;
            // 
            // icbPointShape
            // 
            this.icbPointShape.Color1 = System.Drawing.Color.Orange;
            this.icbPointShape.Color2 = System.Drawing.Color.Honeydew;
            this.icbPointShape.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbPointShape.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbPointShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbPointShape.FormattingEnabled = true;
            this.icbPointShape.Location = new System.Drawing.Point(116, 29);
            this.icbPointShape.Name = "icbPointShape";
            this.icbPointShape.OutlineColor = System.Drawing.Color.DimGray;
            this.icbPointShape.Size = new System.Drawing.Size(124, 21);
            this.icbPointShape.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Point type";
            // 
            // tabCharacter
            // 
            this.tabCharacter.Controls.Add(this.chkShowAllFonts);
            this.tabCharacter.Controls.Add(this.label35);
            this.tabCharacter.Controls.Add(this.cboFontName);
            this.tabCharacter.Controls.Add(this.characterControl1);
            this.tabCharacter.Location = new System.Drawing.Point(4, 22);
            this.tabCharacter.Name = "tabCharacter";
            this.tabCharacter.Size = new System.Drawing.Size(415, 314);
            this.tabCharacter.TabIndex = 3;
            this.tabCharacter.Text = "Characters";
            this.tabCharacter.UseVisualStyleBackColor = true;
            // 
            // chkShowAllFonts
            // 
            this.chkShowAllFonts.AutoSize = true;
            this.chkShowAllFonts.Location = new System.Drawing.Point(295, 27);
            this.chkShowAllFonts.Name = "chkShowAllFonts";
            this.chkShowAllFonts.Size = new System.Drawing.Size(67, 17);
            this.chkShowAllFonts.TabIndex = 70;
            this.chkShowAllFonts.Text = "Show All";
            this.chkShowAllFonts.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(25, 28);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(28, 13);
            this.label35.TabIndex = 69;
            this.label35.Text = "Font";
            // 
            // cboFontName
            // 
            this.cboFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontName.FormattingEnabled = true;
            this.cboFontName.Location = new System.Drawing.Point(72, 25);
            this.cboFontName.Name = "cboFontName";
            this.cboFontName.Size = new System.Drawing.Size(210, 21);
            this.cboFontName.TabIndex = 68;
            // 
            // characterControl1
            // 
            this.characterControl1.BackColor = System.Drawing.Color.Transparent;
            this.characterControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.characterControl1.CellHeight = 32;
            this.characterControl1.CellWidth = 32;
            this.characterControl1.Font = new System.Drawing.Font("Webdings", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.characterControl1.ForeColor = System.Drawing.Color.Black;
            this.characterControl1.GridColor = System.Drawing.Color.DimGray;
            this.characterControl1.GridVisible = true;
            this.characterControl1.ItemCount = 224;
            this.characterControl1.Location = new System.Drawing.Point(17, 57);
            this.characterControl1.Margin = new System.Windows.Forms.Padding(17, 8, 17, 8);
            this.characterControl1.Name = "characterControl1";
            this.characterControl1.SelectedCharacterCode = ((byte)(0));
            this.characterControl1.SelectedIndex = -1;
            this.characterControl1.Size = new System.Drawing.Size(388, 243);
            this.characterControl1.TabIndex = 0;
            // 
            // tabIcon
            // 
            this.tabIcon.Controls.Add(this.pointIconControl1);
            this.tabIcon.Location = new System.Drawing.Point(4, 22);
            this.tabIcon.Name = "tabIcon";
            this.tabIcon.Size = new System.Drawing.Size(415, 314);
            this.tabIcon.TabIndex = 4;
            this.tabIcon.Text = "Icons";
            this.tabIcon.UseVisualStyleBackColor = true;
            // 
            // pointIconControl1
            // 
            this.pointIconControl1.Location = new System.Drawing.Point(10, 12);
            this.pointIconControl1.Name = "pointIconControl1";
            this.pointIconControl1.Size = new System.Drawing.Size(397, 299);
            this.pointIconControl1.TabIndex = 74;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.groupBox3);
            this.tabOptions.Controls.Add(this.groupBox2);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(415, 314);
            this.tabOptions.TabIndex = 0;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNoOptions);
            this.groupBox3.Controls.Add(this.chkFillVisible);
            this.groupBox3.Controls.Add(this.pnlFillHatch);
            this.groupBox3.Controls.Add(this.cboFillType);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 147);
            this.groupBox3.TabIndex = 133;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fill";
            // 
            // lblNoOptions
            // 
            this.lblNoOptions.AutoSize = true;
            this.lblNoOptions.Location = new System.Drawing.Point(74, 83);
            this.lblNoOptions.Name = "lblNoOptions";
            this.lblNoOptions.Size = new System.Drawing.Size(123, 13);
            this.lblNoOptions.TabIndex = 86;
            this.lblNoOptions.Text = "No settings are available";
            this.lblNoOptions.Visible = false;
            // 
            // chkFillVisible
            // 
            this.chkFillVisible.AutoSize = true;
            this.chkFillVisible.Location = new System.Drawing.Point(267, 32);
            this.chkFillVisible.Name = "chkFillVisible";
            this.chkFillVisible.Size = new System.Drawing.Size(65, 17);
            this.chkFillVisible.TabIndex = 85;
            this.chkFillVisible.Text = "Show fill";
            this.chkFillVisible.UseVisualStyleBackColor = true;
            // 
            // pnlFillHatch
            // 
            this.pnlFillHatch.Controls.Add(this.icbHatchStyle);
            this.pnlFillHatch.Controls.Add(this.label6);
            this.pnlFillHatch.Controls.Add(this.chkFillBgTransparent);
            this.pnlFillHatch.Controls.Add(this.clpHatchBack);
            this.pnlFillHatch.Controls.Add(this.label4);
            this.pnlFillHatch.Location = new System.Drawing.Point(6, 55);
            this.pnlFillHatch.Name = "pnlFillHatch";
            this.pnlFillHatch.Size = new System.Drawing.Size(362, 85);
            this.pnlFillHatch.TabIndex = 43;
            // 
            // icbHatchStyle
            // 
            this.icbHatchStyle.Color1 = System.Drawing.Color.Blue;
            this.icbHatchStyle.Color2 = System.Drawing.Color.Honeydew;
            this.icbHatchStyle.ComboStyle = MW5.UI.Enums.ImageComboStyle.Common;
            this.icbHatchStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbHatchStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbHatchStyle.FormattingEnabled = true;
            this.icbHatchStyle.Location = new System.Drawing.Point(85, 11);
            this.icbHatchStyle.Name = "icbHatchStyle";
            this.icbHatchStyle.OutlineColor = System.Drawing.Color.Black;
            this.icbHatchStyle.Size = new System.Drawing.Size(197, 21);
            this.icbHatchStyle.TabIndex = 90;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 82;
            this.label6.Text = "Type";
            // 
            // chkFillBgTransparent
            // 
            this.chkFillBgTransparent.AutoSize = true;
            this.chkFillBgTransparent.Location = new System.Drawing.Point(173, 53);
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
            this.clpHatchBack.Location = new System.Drawing.Point(85, 51);
            this.clpHatchBack.Name = "clpHatchBack";
            this.clpHatchBack.Size = new System.Drawing.Size(74, 21);
            this.clpHatchBack.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Background";
            // 
            // cboFillType
            // 
            this.cboFillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFillType.FormattingEnabled = true;
            this.cboFillType.Location = new System.Drawing.Point(91, 28);
            this.cboFillType.Name = "cboFillType";
            this.cboFillType.Size = new System.Drawing.Size(136, 21);
            this.cboFillType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fill type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOutlineVisible);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.icbLineWidth);
            this.groupBox2.Controls.Add(this.icbLineType);
            this.groupBox2.Controls.Add(this.clpOutline);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 140);
            this.groupBox2.TabIndex = 132;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outline";
            // 
            // chkOutlineVisible
            // 
            this.chkOutlineVisible.AutoSize = true;
            this.chkOutlineVisible.Location = new System.Drawing.Point(225, 31);
            this.chkOutlineVisible.Name = "chkOutlineVisible";
            this.chkOutlineVisible.Size = new System.Drawing.Size(87, 17);
            this.chkOutlineVisible.TabIndex = 131;
            this.chkOutlineVisible.Text = "Show outline";
            this.chkOutlineVisible.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 130;
            this.label21.Text = "Color";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(222, 72);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 126;
            this.label22.Text = "Width";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(25, 70);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(30, 13);
            this.label23.TabIndex = 125;
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
            this.icbLineWidth.Location = new System.Drawing.Point(277, 70);
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
            this.icbLineType.Location = new System.Drawing.Point(65, 67);
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
            this.clpOutline.Location = new System.Drawing.Point(65, 29);
            this.clpOutline.Name = "clpOutline";
            this.clpOutline.Size = new System.Drawing.Size(74, 21);
            this.clpOutline.TabIndex = 127;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pctPreview);
            this.groupBox1.Location = new System.Drawing.Point(9, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 164);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // pctPreview
            // 
            this.pctPreview.BackColor = System.Drawing.Color.Transparent;
            this.pctPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctPreview.Location = new System.Drawing.Point(3, 16);
            this.pctPreview.Name = "pctPreview";
            this.pctPreview.Size = new System.Drawing.Size(170, 145);
            this.pctPreview.TabIndex = 0;
            this.pctPreview.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(515, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 26);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(414, 354);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 26);
            this.btnOk.TabIndex = 38;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlFillGradient
            // 
            this.pnlFillGradient.Controls.Add(this.label5);
            this.pnlFillGradient.Controls.Add(this.udGradientRotation);
            this.pnlFillGradient.Controls.Add(this.label26);
            this.pnlFillGradient.Controls.Add(this.label8);
            this.pnlFillGradient.Controls.Add(this.clpGradient2);
            this.pnlFillGradient.Controls.Add(this.cboGradientType);
            this.pnlFillGradient.Location = new System.Drawing.Point(630, 24);
            this.pnlFillGradient.Name = "pnlFillGradient";
            this.pnlFillGradient.Size = new System.Drawing.Size(362, 83);
            this.pnlFillGradient.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Color 2";
            // 
            // udGradientRotation
            // 
            this.udGradientRotation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.udGradientRotation.Location = new System.Drawing.Point(292, 11);
            this.udGradientRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.udGradientRotation.Name = "udGradientRotation";
            this.udGradientRotation.Size = new System.Drawing.Size(56, 20);
            this.udGradientRotation.TabIndex = 99;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(252, 13);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(34, 13);
            this.label26.TabIndex = 95;
            this.label26.Text = "Angle";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "Gradient type";
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
            this.clpGradient2.Location = new System.Drawing.Point(85, 51);
            this.clpGradient2.Name = "clpGradient2";
            this.clpGradient2.Size = new System.Drawing.Size(72, 21);
            this.clpGradient2.TabIndex = 88;
            // 
            // cboGradientType
            // 
            this.cboGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradientType.FormattingEnabled = true;
            this.cboGradientType.Location = new System.Drawing.Point(98, 11);
            this.cboGradientType.Name = "cboGradientType";
            this.cboGradientType.Size = new System.Drawing.Size(136, 21);
            this.cboGradientType.TabIndex = 90;
            // 
            // pnlFillPicture
            // 
            this.pnlFillPicture.Controls.Add(this.btnChooseTexture);
            this.pnlFillPicture.Location = new System.Drawing.Point(630, 146);
            this.pnlFillPicture.Name = "pnlFillPicture";
            this.pnlFillPicture.Size = new System.Drawing.Size(362, 63);
            this.pnlFillPicture.TabIndex = 43;
            // 
            // btnChooseTexture
            // 
            this.btnChooseTexture.Location = new System.Drawing.Point(85, 7);
            this.btnChooseTexture.Name = "btnChooseTexture";
            this.btnChooseTexture.Size = new System.Drawing.Size(113, 23);
            this.btnChooseTexture.TabIndex = 0;
            this.btnChooseTexture.Text = "Choose texture...";
            this.btnChooseTexture.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(313, 354);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 26);
            this.btnApply.TabIndex = 44;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnApplyClick);
            // 
            // PointsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(619, 385);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.pnlFillGradient);
            this.Controls.Add(this.pnlFillPicture);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Point Style";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRotation)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabSymbol.ResumeLayout(false);
            this.tabSymbol.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPointNumSides)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udSideRatio)).EndInit();
            this.tabCharacter.ResumeLayout(false);
            this.tabCharacter.PerformLayout();
            this.tabIcon.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlFillHatch.ResumeLayout(false);
            this.pnlFillHatch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctPreview)).EndInit();
            this.pnlFillGradient.ResumeLayout(false);
            this.pnlFillGradient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udGradientRotation)).EndInit();
            this.pnlFillPicture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private NumericUpDownEx udSize;
        private NumericUpDownEx udRotation;
        private Office2007ColorPicker clpFillColor;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSymbol;
        private SymbolControl symbolControl1;
        private NumericUpDownEx udPointNumSides;
        private NumericUpDownEx udSideRatio;
        private ImageCombo icbPointShape;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pctPreview;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabCharacter;
        private System.Windows.Forms.TabPage tabIcon;
        private CharacterControl characterControl1;
        private System.Windows.Forms.CheckBox chkShowAllFonts;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cboFontName;
        private System.Windows.Forms.GroupBox groupBox5;
        private Office2007ColorPicker clpHatchBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlFillHatch;
        private ImageCombo icbHatchStyle;
        private System.Windows.Forms.CheckBox chkFillBgTransparent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlFillGradient;
        private NumericUpDownEx udGradientRotation;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboGradientType;
        private Office2007ColorPicker clpGradient2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlFillPicture;
        private System.Windows.Forms.Button btnChooseTexture;
        private System.Windows.Forms.Label lblNoOptions;
        private System.Windows.Forms.Label label3;
        private TransparencyControl transparencyControl1;
        private System.Windows.Forms.Button btnApply;
        private PointIconControl pointIconControl1;

    }
}