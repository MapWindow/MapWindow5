namespace MW5.Tools.Views.Gdal
{
  partial class GdalTranslateView
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputfileTextbox = new System.Windows.Forms.TextBox();
            this.OutputfileSelectButton = new System.Windows.Forms.Button();
            this.InputfileTextbox = new System.Windows.Forms.TextBox();
            this.InputFileSelectButton = new System.Windows.Forms.Button();
            this.chkAddToMap = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Zlevel = new System.Windows.Forms.TrackBar();
            this.JpegQuality = new System.Windows.Forms.TrackBar();
            this.compressionListbox = new System.Windows.Forms.ComboBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.TiledCheckbox = new System.Windows.Forms.CheckBox();
            this.OutputTypeListbox = new System.Windows.Forms.ComboBox();
            this.OutputFormatListbox = new System.Windows.Forms.ComboBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.CommandTextbox = new System.Windows.Forms.TextBox();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRun = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.OptionsGroupbox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ZlevelLabel = new System.Windows.Forms.Label();
            this.JpegQualityLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageAdv3 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.Zlevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JpegQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageAdv1.SuspendLayout();
            this.tabPageAdv2.SuspendLayout();
            this.OptionsGroupbox.SuspendLayout();
            this.tabPageAdv3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Output raster [dst_dataset]:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Input raster [src_dataset]:";
            // 
            // OutputfileTextbox
            // 
            this.OutputfileTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputfileTextbox.Location = new System.Drawing.Point(32, 104);
            this.OutputfileTextbox.Name = "OutputfileTextbox";
            this.OutputfileTextbox.Size = new System.Drawing.Size(347, 20);
            this.OutputfileTextbox.TabIndex = 10;
            this.toolTip1.SetToolTip(this.OutputfileTextbox, "The destination file name.");
            // 
            // OutputfileSelectButton
            // 
            this.OutputfileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputfileSelectButton.Image = global::MW5.Tools.Properties.Resources.img_save_24;
            this.OutputfileSelectButton.Location = new System.Drawing.Point(385, 98);
            this.OutputfileSelectButton.Name = "OutputfileSelectButton";
            this.OutputfileSelectButton.Size = new System.Drawing.Size(30, 30);
            this.OutputfileSelectButton.TabIndex = 9;
            this.toolTip1.SetToolTip(this.OutputfileSelectButton, "Give the name and location of the output raster file.");
            this.OutputfileSelectButton.UseVisualStyleBackColor = true;
            this.OutputfileSelectButton.Click += new System.EventHandler(this.OutputfileSelectButtonClick);
            // 
            // InputfileTextbox
            // 
            this.InputfileTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputfileTextbox.Location = new System.Drawing.Point(32, 48);
            this.InputfileTextbox.Name = "InputfileTextbox";
            this.InputfileTextbox.Size = new System.Drawing.Size(347, 20);
            this.InputfileTextbox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.InputfileTextbox, "The source dataset name. \r\nIt can be either file name, URL of data source or subd" +
        "ataset name for multi-dataset files. ");
            // 
            // InputFileSelectButton
            // 
            this.InputFileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InputFileSelectButton.Image = global::MW5.Tools.Properties.Resources.img_file_explorer24;
            this.InputFileSelectButton.Location = new System.Drawing.Point(385, 42);
            this.InputFileSelectButton.Name = "InputFileSelectButton";
            this.InputFileSelectButton.Size = new System.Drawing.Size(30, 30);
            this.InputFileSelectButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.InputFileSelectButton, "Select the file to translate.");
            this.InputFileSelectButton.UseVisualStyleBackColor = true;
            this.InputFileSelectButton.Click += new System.EventHandler(this.InputFileSelectButtonClick);
            // 
            // chkAddToMap
            // 
            this.chkAddToMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAddToMap.AutoSize = true;
            this.chkAddToMap.Checked = true;
            this.chkAddToMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddToMap.Location = new System.Drawing.Point(10, 598);
            this.chkAddToMap.Name = "chkAddToMap";
            this.chkAddToMap.Size = new System.Drawing.Size(86, 17);
            this.chkAddToMap.TabIndex = 3;
            this.chkAddToMap.Text = "Add to map?";
            this.toolTip1.SetToolTip(this.chkAddToMap, "Add the resulting raster to the map?");
            this.chkAddToMap.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Tip";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(28, 190);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(339, 20);
            this.textBox2.TabIndex = 26;
            this.textBox2.Tag = "-a_nodata";
            this.toolTip1.SetToolTip(this.textBox2, "Assign a specified nodata value to output bands. \r\nCan be set to none to avoid se" +
        "tting a nodata value to the output file if one exists for the source file.");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 242);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 20);
            this.textBox1.TabIndex = 25;
            this.textBox1.Tag = "-a_srs";
            this.toolTip1.SetToolTip(this.textBox1, "Override the projection for the output file. \r\nThe srs_def may be any of the usua" +
        "l GDAL/OGR forms, complete WKT, PROJ.4, EPSG:n or a file containing the WKT.\r\nFo" +
        "r example: EPSG:26918");
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "",
            "MINISBLACK",
            "MINISWHITE",
            "RGB",
            "CMYK",
            "YCBCR",
            "CIELAB",
            "ICCLAB",
            "ITULAB"});
            this.comboBox1.Location = new System.Drawing.Point(28, 142);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(339, 21);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.Tag = "-co PHOTOMETRIC=";
            this.toolTip1.SetToolTip(this.comboBox1, "Set the photometric interpretation tag. \r\nDefault is MINISBLACK, but if the input" +
        " image has 3 or 4 bands of Byte type, then RGB will be selected");
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(28, 411);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "-co TFW=YES";
            this.toolTip1.SetToolTip(this.checkBox1, "Force the generation of an associated ESRI world file.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Zlevel
            // 
            this.Zlevel.AutoSize = false;
            this.Zlevel.BackColor = System.Drawing.SystemColors.Window;
            this.Zlevel.LargeChange = 1;
            this.Zlevel.Location = new System.Drawing.Point(26, 292);
            this.Zlevel.Maximum = 9;
            this.Zlevel.Minimum = 1;
            this.Zlevel.Name = "Zlevel";
            this.Zlevel.Size = new System.Drawing.Size(338, 23);
            this.Zlevel.TabIndex = 16;
            this.Zlevel.Tag = "-co ZLEVEL=";
            this.toolTip1.SetToolTip(this.Zlevel, "Set the level of compression when using DEFLATE compression. \r\nA value of 9 is be" +
        "st, and 1 is least compression. \r\nThe default is 6.");
            this.Zlevel.Value = 6;
            // 
            // JpegQuality
            // 
            this.JpegQuality.AutoSize = false;
            this.JpegQuality.BackColor = System.Drawing.SystemColors.Window;
            this.JpegQuality.LargeChange = 10;
            this.JpegQuality.Location = new System.Drawing.Point(26, 347);
            this.JpegQuality.Maximum = 100;
            this.JpegQuality.Minimum = 1;
            this.JpegQuality.Name = "JpegQuality";
            this.JpegQuality.Size = new System.Drawing.Size(338, 24);
            this.JpegQuality.SmallChange = 5;
            this.JpegQuality.TabIndex = 14;
            this.JpegQuality.Tag = "-co JPEG_QUALITY=";
            this.JpegQuality.TickFrequency = 10;
            this.toolTip1.SetToolTip(this.JpegQuality, "Set the JPEG quality when using JPEG compression.  \r\nA value of 100 is best quali" +
        "ty (least compression), and 1 is worst quality (best compression).  \r\nThe defaul" +
        "t is 75.");
            this.JpegQuality.Value = 75;
            // 
            // compressionListbox
            // 
            this.compressionListbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compressionListbox.FormattingEnabled = true;
            this.compressionListbox.Items.AddRange(new object[] {
            "",
            "JPEG",
            "LZW",
            "PACKBITS",
            "DEFLATE",
            "CCITTRLE",
            "CCITTFAX3",
            "CCITTFAX4",
            "NONE"});
            this.compressionListbox.Location = new System.Drawing.Point(28, 93);
            this.compressionListbox.Name = "compressionListbox";
            this.compressionListbox.Size = new System.Drawing.Size(339, 21);
            this.compressionListbox.TabIndex = 12;
            this.compressionListbox.Tag = "-co COMPRESS=";
            this.toolTip1.SetToolTip(this.compressionListbox, "Set the compression to use.  \r\nJPEG should generally only be used with Byte data " +
        "(8 bit per channel).");
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(28, 434);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(51, 17);
            this.checkBox6.TabIndex = 11;
            this.checkBox6.Text = "-stats";
            this.toolTip1.SetToolTip(this.checkBox6, "Force (re)computation of statistics.");
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(28, 503);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(45, 17);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "-sds";
            this.toolTip1.SetToolTip(this.checkBox5, "Copy all subdatasets of this file to individual output files.\r\n Use with formats " +
        "like HDF or OGDI that have subdatasets. ");
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(28, 480);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 17);
            this.checkBox4.TabIndex = 9;
            this.checkBox4.Text = "-unscale";
            this.toolTip1.SetToolTip(this.checkBox4, "Apply the scale/offset metadata for the bands to convert scaled values to unscale" +
        "d values. \r\nIt is also often necessary to reset the output datatype with the -ot" +
        " switch. ");
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(28, 457);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(51, 17);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "-strict";
            this.toolTip1.SetToolTip(this.checkBox3, "Don\'t be forgiving of mismatches and lost data when translating to the output for" +
        "mat.");
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // TiledCheckbox
            // 
            this.TiledCheckbox.AutoSize = true;
            this.TiledCheckbox.Location = new System.Drawing.Point(28, 388);
            this.TiledCheckbox.Name = "TiledCheckbox";
            this.TiledCheckbox.Size = new System.Drawing.Size(102, 17);
            this.TiledCheckbox.TabIndex = 3;
            this.TiledCheckbox.Text = "-co TILED=YES";
            this.toolTip1.SetToolTip(this.TiledCheckbox, "By default stripped TIFF files are created. \r\nThis option can be used to force cr" +
        "eation of tiled TIFF files");
            this.TiledCheckbox.UseVisualStyleBackColor = true;
            // 
            // OutputTypeListbox
            // 
            this.OutputTypeListbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputTypeListbox.FormattingEnabled = true;
            this.OutputTypeListbox.Items.AddRange(new object[] {
            "",
            "Byte",
            "Int16",
            "UInt16",
            "UInt32",
            "Int32",
            "Float32",
            "Float64",
            "CInt16",
            "CInt32",
            "CFloat32",
            "CFloat64"});
            this.OutputTypeListbox.Location = new System.Drawing.Point(32, 222);
            this.OutputTypeListbox.Name = "OutputTypeListbox";
            this.OutputTypeListbox.Size = new System.Drawing.Size(347, 21);
            this.OutputTypeListbox.TabIndex = 16;
            this.OutputTypeListbox.Tag = "-ot ";
            this.toolTip1.SetToolTip(this.OutputTypeListbox, "For the output bands to be of the indicated data type. ");
            // 
            // OutputFormatListbox
            // 
            this.OutputFormatListbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputFormatListbox.FormattingEnabled = true;
            this.OutputFormatListbox.Location = new System.Drawing.Point(32, 166);
            this.OutputFormatListbox.Name = "OutputFormatListbox";
            this.OutputFormatListbox.Size = new System.Drawing.Size(347, 21);
            this.OutputFormatListbox.TabIndex = 14;
            this.OutputFormatListbox.Tag = "-of ";
            this.toolTip1.SetToolTip(this.OutputFormatListbox, "Select the output format. \r");
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Image = global::MW5.Tools.Properties.Resources.img_Pensil24;
            this.EditButton.Location = new System.Drawing.Point(373, 31);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(30, 30);
            this.EditButton.TabIndex = 28;
            this.toolTip1.SetToolTip(this.EditButton, "Manual add options.");
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // CommandTextbox
            // 
            this.CommandTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommandTextbox.Location = new System.Drawing.Point(28, 37);
            this.CommandTextbox.Name = "CommandTextbox";
            this.CommandTextbox.ReadOnly = true;
            this.CommandTextbox.Size = new System.Drawing.Size(339, 20);
            this.CommandTextbox.TabIndex = 27;
            this.toolTip1.SetToolTip(this.CommandTextbox, "The options that will be parsed.\r\nYou can manually change them and/or add more op" +
        "tions.");
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(451, 593);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnRun.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.IsBackStageButton = false;
            this.btnRun.Location = new System.Drawing.Point(360, 593);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 26);
            this.btnRun.TabIndex = 35;
            this.btnRun.Text = "Run";
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(531, 575);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv1);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv2);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv3);
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(80, 50);
            this.tabControlAdv1.Location = new System.Drawing.Point(12, 12);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(531, 575);
            this.tabControlAdv1.TabIndex = 37;
            // 
            // tabPageAdv1
            // 
            this.tabPageAdv1.Controls.Add(this.label5);
            this.tabPageAdv1.Controls.Add(this.OutputTypeListbox);
            this.tabPageAdv1.Controls.Add(this.label1);
            this.tabPageAdv1.Controls.Add(this.OutputFormatListbox);
            this.tabPageAdv1.Controls.Add(this.label4);
            this.tabPageAdv1.Controls.Add(this.InputFileSelectButton);
            this.tabPageAdv1.Controls.Add(this.label2);
            this.tabPageAdv1.Controls.Add(this.InputfileTextbox);
            this.tabPageAdv1.Controls.Add(this.OutputfileTextbox);
            this.tabPageAdv1.Controls.Add(this.OutputfileSelectButton);
            this.tabPageAdv1.Image = null;
            this.tabPageAdv1.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv1.Location = new System.Drawing.Point(83, 1);
            this.tabPageAdv1.Name = "tabPageAdv1";
            this.tabPageAdv1.ShowCloseButton = true;
            this.tabPageAdv1.Size = new System.Drawing.Size(446, 572);
            this.tabPageAdv1.TabIndex = 1;
            this.tabPageAdv1.Text = "Input";
            this.tabPageAdv1.ThemesEnabled = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Output type [-ot]:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Output format [-of]:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPageAdv2
            // 
            this.tabPageAdv2.Controls.Add(this.OptionsGroupbox);
            this.tabPageAdv2.Image = null;
            this.tabPageAdv2.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv2.Location = new System.Drawing.Point(83, 1);
            this.tabPageAdv2.Name = "tabPageAdv2";
            this.tabPageAdv2.ShowCloseButton = true;
            this.tabPageAdv2.Size = new System.Drawing.Size(446, 572);
            this.tabPageAdv2.TabIndex = 2;
            this.tabPageAdv2.Text = "Options";
            this.tabPageAdv2.ThemesEnabled = false;
            // 
            // OptionsGroupbox
            // 
            this.OptionsGroupbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsGroupbox.Controls.Add(this.EditButton);
            this.OptionsGroupbox.Controls.Add(this.CommandTextbox);
            this.OptionsGroupbox.Controls.Add(this.textBox2);
            this.OptionsGroupbox.Controls.Add(this.textBox1);
            this.OptionsGroupbox.Controls.Add(this.label10);
            this.OptionsGroupbox.Controls.Add(this.label9);
            this.OptionsGroupbox.Controls.Add(this.label3);
            this.OptionsGroupbox.Controls.Add(this.comboBox1);
            this.OptionsGroupbox.Controls.Add(this.checkBox1);
            this.OptionsGroupbox.Controls.Add(this.ZlevelLabel);
            this.OptionsGroupbox.Controls.Add(this.JpegQualityLabel);
            this.OptionsGroupbox.Controls.Add(this.label8);
            this.OptionsGroupbox.Controls.Add(this.Zlevel);
            this.OptionsGroupbox.Controls.Add(this.label7);
            this.OptionsGroupbox.Controls.Add(this.JpegQuality);
            this.OptionsGroupbox.Controls.Add(this.label6);
            this.OptionsGroupbox.Controls.Add(this.compressionListbox);
            this.OptionsGroupbox.Controls.Add(this.checkBox6);
            this.OptionsGroupbox.Controls.Add(this.checkBox5);
            this.OptionsGroupbox.Controls.Add(this.checkBox4);
            this.OptionsGroupbox.Controls.Add(this.checkBox3);
            this.OptionsGroupbox.Controls.Add(this.TiledCheckbox);
            this.OptionsGroupbox.Location = new System.Drawing.Point(14, 10);
            this.OptionsGroupbox.Name = "OptionsGroupbox";
            this.OptionsGroupbox.Size = new System.Drawing.Size(422, 543);
            this.OptionsGroupbox.TabIndex = 3;
            this.OptionsGroupbox.TabStop = false;
            this.OptionsGroupbox.Text = "Options";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "-a_srs:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "-a_nodata:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "-co PHOTOMETRIC:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ZlevelLabel
            // 
            this.ZlevelLabel.AutoSize = true;
            this.ZlevelLabel.Location = new System.Drawing.Point(370, 292);
            this.ZlevelLabel.Name = "ZlevelLabel";
            this.ZlevelLabel.Size = new System.Drawing.Size(13, 13);
            this.ZlevelLabel.TabIndex = 19;
            this.ZlevelLabel.Text = "6";
            // 
            // JpegQualityLabel
            // 
            this.JpegQualityLabel.AutoSize = true;
            this.JpegQualityLabel.Location = new System.Drawing.Point(370, 347);
            this.JpegQualityLabel.Name = "JpegQualityLabel";
            this.JpegQualityLabel.Size = new System.Drawing.Size(19, 13);
            this.JpegQualityLabel.TabIndex = 18;
            this.JpegQualityLabel.Text = "75";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Quality [-co ZLEVEL]:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Quality [-co JPEG_QUALITY]:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "-co COMPRESS:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPageAdv3
            // 
            this.tabPageAdv3.Controls.Add(this.webBrowser1);
            this.tabPageAdv3.Image = null;
            this.tabPageAdv3.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv3.Location = new System.Drawing.Point(83, 1);
            this.tabPageAdv3.Name = "tabPageAdv3";
            this.tabPageAdv3.ShowCloseButton = true;
            this.tabPageAdv3.Size = new System.Drawing.Size(446, 572);
            this.tabPageAdv3.TabIndex = 3;
            this.tabPageAdv3.Text = "Manual";
            this.tabPageAdv3.ThemesEnabled = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(446, 572);
            this.webBrowser1.TabIndex = 2;
            // 
            // GdalTranslateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(548, 621);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.chkAddToMap);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "GdalTranslateView";
            this.ShowInTaskbar = false;
            this.Text = "GDAL Translate Raster";
            ((System.ComponentModel.ISupportInitialize)(this.Zlevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JpegQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageAdv1.ResumeLayout(false);
            this.tabPageAdv1.PerformLayout();
            this.tabPageAdv2.ResumeLayout(false);
            this.OptionsGroupbox.ResumeLayout(false);
            this.OptionsGroupbox.PerformLayout();
            this.tabPageAdv3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button InputFileSelectButton;
    private System.Windows.Forms.TextBox InputfileTextbox;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox OutputfileTextbox;
    private System.Windows.Forms.Button OutputfileSelectButton;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.CheckBox chkAddToMap;
    private Syncfusion.Windows.Forms.ButtonAdv btnClose;
    private Syncfusion.Windows.Forms.ButtonAdv btnRun;
    private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
    private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox OutputTypeListbox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox OutputFormatListbox;
    private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv2;
    private System.Windows.Forms.GroupBox OptionsGroupbox;
    private System.Windows.Forms.Button EditButton;
    private System.Windows.Forms.TextBox CommandTextbox;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.Label ZlevelLabel;
    private System.Windows.Forms.Label JpegQualityLabel;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TrackBar Zlevel;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TrackBar JpegQuality;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox compressionListbox;
    private System.Windows.Forms.CheckBox checkBox6;
    private System.Windows.Forms.CheckBox checkBox5;
    private System.Windows.Forms.CheckBox checkBox4;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.CheckBox TiledCheckbox;
    private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv3;
    private System.Windows.Forms.WebBrowser webBrowser1;
  }
}