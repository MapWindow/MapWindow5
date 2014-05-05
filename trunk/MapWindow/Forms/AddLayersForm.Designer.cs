namespace MapWindow.Forms
{
    partial class AddLayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLayersForm));
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel1 = new Syncfusion.Windows.Forms.CaptionLabel();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageShapefile = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.OpenShapefileButton = new Syncfusion.Windows.Forms.ButtonAdv();
            this.SelectShapefileButton = new System.Windows.Forms.Button();
            this.SelectShapefileTextbox = new System.Windows.Forms.TextBox();
            this.tabPageGrid = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.OpenGridFileButton = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridfilePropertiesTextbox = new System.Windows.Forms.TextBox();
            this.SelectGridfileButton = new System.Windows.Forms.Button();
            this.SelectGridfileTextbox = new System.Windows.Forms.TextBox();
            this.gradientLabel2 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.tabPageImage = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientLabel3 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.tabPageDatabase = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientLabel4 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.tabPageWebservice = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientLabel5 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.ShapefileGroupbar = new Syncfusion.Windows.Forms.Tools.GroupBar();
            this.ShapefileInformationItem = new Syncfusion.Windows.Forms.Tools.GroupBarItem();
            this.ShapefileSettingsItem = new Syncfusion.Windows.Forms.Tools.GroupBarItem();
            this.ShapefileInformationTextbox = new System.Windows.Forms.TextBox();
            this.gradientPanel3 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.gradientLabel1 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageShapefile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.tabPageGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            this.tabPageDatabase.SuspendLayout();
            this.tabPageWebservice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShapefileGroupbar)).BeginInit();
            this.ShapefileGroupbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel3)).BeginInit();
            this.gradientPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(550, 490);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControlAdv1.BorderWidth = 0;
            this.tabControlAdv1.Controls.Add(this.tabPageShapefile);
            this.tabControlAdv1.Controls.Add(this.tabPageGrid);
            this.tabControlAdv1.Controls.Add(this.tabPageImage);
            this.tabControlAdv1.Controls.Add(this.tabPageDatabase);
            this.tabControlAdv1.Controls.Add(this.tabPageWebservice);
            this.tabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(120, 23);
            this.tabControlAdv1.Location = new System.Drawing.Point(0, 0);
            this.tabControlAdv1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.PersistTabState = true;
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(550, 490);
            this.tabControlAdv1.TabGap = 10;
            this.tabControlAdv1.TabIndex = 2;
            this.tabControlAdv1.TabPanelBackColor = System.Drawing.Color.Transparent;
            this.tabControlAdv1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.tabControlAdv1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.tabControlAdv1.DrawItem += new Syncfusion.Windows.Forms.Tools.DrawTabEventHandler(this.TabControlAdv1DrawItem);
            // 
            // tabPageShapefile
            // 
            this.tabPageShapefile.Controls.Add(this.gradientPanel1);
            this.tabPageShapefile.Image = ((System.Drawing.Image)(resources.GetObject("tabPageShapefile.Image")));
            this.tabPageShapefile.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageShapefile.Location = new System.Drawing.Point(122, 0);
            this.tabPageShapefile.Name = "tabPageShapefile";
            this.tabPageShapefile.ShowCloseButton = false;
            this.tabPageShapefile.Size = new System.Drawing.Size(428, 490);
            this.tabPageShapefile.TabIndex = 1;
            this.tabPageShapefile.Text = "Shapefile";
            this.tabPageShapefile.ThemesEnabled = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.White;
            this.gradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.gradientPanel1.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel1.Controls.Add(this.gradientLabel1);
            this.gradientPanel1.Controls.Add(this.ShapefileGroupbar);
            this.gradientPanel1.Controls.Add(this.OpenShapefileButton);
            this.gradientPanel1.Controls.Add(this.SelectShapefileButton);
            this.gradientPanel1.Controls.Add(this.SelectShapefileTextbox);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(428, 490);
            this.gradientPanel1.TabIndex = 2;
            // 
            // OpenShapefileButton
            // 
            this.OpenShapefileButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.OpenShapefileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.OpenShapefileButton.BeforeTouchSize = new System.Drawing.Size(345, 23);
            this.OpenShapefileButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenShapefileButton.ForeColor = System.Drawing.Color.White;
            this.OpenShapefileButton.IsBackStageButton = false;
            this.OpenShapefileButton.Location = new System.Drawing.Point(34, 402);
            this.OpenShapefileButton.Name = "OpenShapefileButton";
            this.OpenShapefileButton.Size = new System.Drawing.Size(345, 23);
            this.OpenShapefileButton.TabIndex = 4;
            this.OpenShapefileButton.Text = "Open selected shapefile";
            this.OpenShapefileButton.UseVisualStyle = true;
            this.OpenShapefileButton.UseVisualStyleBackColor = false;
            this.OpenShapefileButton.Click += new System.EventHandler(this.ButtonAdv1Click);
            // 
            // SelectShapefileButton
            // 
            this.SelectShapefileButton.AutoSize = true;
            this.SelectShapefileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectShapefileButton.Location = new System.Drawing.Point(353, 61);
            this.SelectShapefileButton.Name = "SelectShapefileButton";
            this.SelectShapefileButton.Size = new System.Drawing.Size(26, 23);
            this.SelectShapefileButton.TabIndex = 2;
            this.SelectShapefileButton.Text = "...";
            this.SelectShapefileButton.UseVisualStyleBackColor = true;
            this.SelectShapefileButton.Click += new System.EventHandler(this.SelectShapefileButtonClick);
            // 
            // SelectShapefileTextbox
            // 
            this.SelectShapefileTextbox.Location = new System.Drawing.Point(34, 61);
            this.SelectShapefileTextbox.Name = "SelectShapefileTextbox";
            this.SelectShapefileTextbox.Size = new System.Drawing.Size(313, 20);
            this.SelectShapefileTextbox.TabIndex = 1;
            this.SelectShapefileTextbox.TextChanged += new System.EventHandler(this.SelectShapefileTextboxTextChanged);
            // 
            // tabPageGrid
            // 
            this.tabPageGrid.Controls.Add(this.gradientPanel2);
            this.tabPageGrid.Image = ((System.Drawing.Image)(resources.GetObject("tabPageGrid.Image")));
            this.tabPageGrid.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageGrid.Location = new System.Drawing.Point(122, 0);
            this.tabPageGrid.Name = "tabPageGrid";
            this.tabPageGrid.ShowCloseButton = true;
            this.tabPageGrid.Size = new System.Drawing.Size(428, 490);
            this.tabPageGrid.TabIndex = 2;
            this.tabPageGrid.Text = "Grid";
            this.tabPageGrid.ThemesEnabled = false;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.BackColor = System.Drawing.Color.White;
            this.gradientPanel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientPanel2.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.gradientPanel2.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel2.Controls.Add(this.OpenGridFileButton);
            this.gradientPanel2.Controls.Add(this.groupBox2);
            this.gradientPanel2.Controls.Add(this.SelectGridfileButton);
            this.gradientPanel2.Controls.Add(this.SelectGridfileTextbox);
            this.gradientPanel2.Controls.Add(this.gradientLabel2);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(428, 490);
            this.gradientPanel2.TabIndex = 3;
            // 
            // OpenGridFileButton
            // 
            this.OpenGridFileButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.OpenGridFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.OpenGridFileButton.BeforeTouchSize = new System.Drawing.Size(345, 23);
            this.OpenGridFileButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenGridFileButton.ForeColor = System.Drawing.Color.White;
            this.OpenGridFileButton.IsBackStageButton = false;
            this.OpenGridFileButton.Location = new System.Drawing.Point(34, 402);
            this.OpenGridFileButton.Name = "OpenGridFileButton";
            this.OpenGridFileButton.Size = new System.Drawing.Size(345, 23);
            this.OpenGridFileButton.TabIndex = 4;
            this.OpenGridFileButton.Text = "Open selected grid file";
            this.OpenGridFileButton.UseVisualStyle = true;
            this.OpenGridFileButton.UseVisualStyleBackColor = false;
            this.OpenGridFileButton.Click += new System.EventHandler(this.OpenGridFileButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.GridfilePropertiesTextbox);
            this.groupBox2.Location = new System.Drawing.Point(34, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 290);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // GridfilePropertiesTextbox
            // 
            this.GridfilePropertiesTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridfilePropertiesTextbox.Location = new System.Drawing.Point(3, 16);
            this.GridfilePropertiesTextbox.Multiline = true;
            this.GridfilePropertiesTextbox.Name = "GridfilePropertiesTextbox";
            this.GridfilePropertiesTextbox.ReadOnly = true;
            this.GridfilePropertiesTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GridfilePropertiesTextbox.Size = new System.Drawing.Size(339, 271);
            this.GridfilePropertiesTextbox.TabIndex = 1;
            // 
            // SelectGridfileButton
            // 
            this.SelectGridfileButton.AutoSize = true;
            this.SelectGridfileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectGridfileButton.Location = new System.Drawing.Point(353, 61);
            this.SelectGridfileButton.Name = "SelectGridfileButton";
            this.SelectGridfileButton.Size = new System.Drawing.Size(26, 23);
            this.SelectGridfileButton.TabIndex = 2;
            this.SelectGridfileButton.Text = "...";
            this.SelectGridfileButton.UseVisualStyleBackColor = true;
            this.SelectGridfileButton.Click += new System.EventHandler(this.SelectGridfileButtonClick);
            // 
            // SelectGridfileTextbox
            // 
            this.SelectGridfileTextbox.Location = new System.Drawing.Point(34, 61);
            this.SelectGridfileTextbox.Name = "SelectGridfileTextbox";
            this.SelectGridfileTextbox.Size = new System.Drawing.Size(313, 20);
            this.SelectGridfileTextbox.TabIndex = 1;
            this.SelectGridfileTextbox.TextChanged += new System.EventHandler(this.SelectGridfileTextboxTextChanged);
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.AutoEllipsis = true;
            this.gradientLabel2.AutoSize = true;
            this.gradientLabel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel2.BeforeTouchSize = new System.Drawing.Size(175, 37);
            this.gradientLabel2.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel2.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel2.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel2.Location = new System.Drawing.Point(127, 9);
            this.gradientLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel2.Size = new System.Drawing.Size(175, 37);
            this.gradientLabel2.TabIndex = 0;
            this.gradientLabel2.Text = "Add a Grid file";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.gradientLabel3);
            this.tabPageImage.Image = ((System.Drawing.Image)(resources.GetObject("tabPageImage.Image")));
            this.tabPageImage.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageImage.Location = new System.Drawing.Point(122, 0);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.ShowCloseButton = true;
            this.tabPageImage.Size = new System.Drawing.Size(428, 490);
            this.tabPageImage.TabIndex = 3;
            this.tabPageImage.Text = "Image";
            this.tabPageImage.ThemesEnabled = false;
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.AutoEllipsis = true;
            this.gradientLabel3.AutoSize = true;
            this.gradientLabel3.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel3.BeforeTouchSize = new System.Drawing.Size(168, 37);
            this.gradientLabel3.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel3.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel3.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel3.Location = new System.Drawing.Point(122, 9);
            this.gradientLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel3.Size = new System.Drawing.Size(168, 37);
            this.gradientLabel3.TabIndex = 1;
            this.gradientLabel3.Text = "Add an image";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageDatabase
            // 
            this.tabPageDatabase.Controls.Add(this.gradientLabel4);
            this.tabPageDatabase.Image = ((System.Drawing.Image)(resources.GetObject("tabPageDatabase.Image")));
            this.tabPageDatabase.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageDatabase.Location = new System.Drawing.Point(122, 0);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.ShowCloseButton = true;
            this.tabPageDatabase.Size = new System.Drawing.Size(428, 490);
            this.tabPageDatabase.TabIndex = 4;
            this.tabPageDatabase.Text = "Geodatabase";
            this.tabPageDatabase.ThemesEnabled = false;
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.AutoEllipsis = true;
            this.gradientLabel4.AutoSize = true;
            this.gradientLabel4.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel4.BeforeTouchSize = new System.Drawing.Size(262, 37);
            this.gradientLabel4.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel4.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel4.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel4.Location = new System.Drawing.Point(122, 9);
            this.gradientLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel4.Size = new System.Drawing.Size(262, 37);
            this.gradientLabel4.TabIndex = 1;
            this.gradientLabel4.Text = "Connect to a database";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageWebservice
            // 
            this.tabPageWebservice.Controls.Add(this.gradientLabel5);
            this.tabPageWebservice.Image = ((System.Drawing.Image)(resources.GetObject("tabPageWebservice.Image")));
            this.tabPageWebservice.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageWebservice.Location = new System.Drawing.Point(122, 0);
            this.tabPageWebservice.Name = "tabPageWebservice";
            this.tabPageWebservice.ShowCloseButton = true;
            this.tabPageWebservice.Size = new System.Drawing.Size(428, 490);
            this.tabPageWebservice.TabIndex = 5;
            this.tabPageWebservice.Text = "Webservices";
            this.tabPageWebservice.ThemesEnabled = false;
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.AutoEllipsis = true;
            this.gradientLabel5.AutoSize = true;
            this.gradientLabel5.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel5.BeforeTouchSize = new System.Drawing.Size(283, 37);
            this.gradientLabel5.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel5.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel5.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel5.Location = new System.Drawing.Point(122, 9);
            this.gradientLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel5.Size = new System.Drawing.Size(283, 37);
            this.gradientLabel5.TabIndex = 1;
            this.gradientLabel5.Text = "Connect to a webservice";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShapefileGroupbar
            // 
            this.ShapefileGroupbar.AllowCollapse = true;
            this.ShapefileGroupbar.AllowDrop = true;
            this.ShapefileGroupbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ShapefileGroupbar.BeforeTouchSize = new System.Drawing.Size(345, 300);
            this.ShapefileGroupbar.BorderColor = System.Drawing.Color.White;
            this.ShapefileGroupbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ShapefileGroupbar.CollapseImage = ((System.Drawing.Image)(resources.GetObject("ShapefileGroupbar.CollapseImage")));
            this.ShapefileGroupbar.Controls.Add(this.ShapefileInformationTextbox);
            this.ShapefileGroupbar.Controls.Add(this.gradientPanel3);
            this.ShapefileGroupbar.ExpandButtonToolTip = null;
            this.ShapefileGroupbar.ExpandImage = ((System.Drawing.Image)(resources.GetObject("ShapefileGroupbar.ExpandImage")));
            this.ShapefileGroupbar.FlatLook = true;
            this.ShapefileGroupbar.ForeColor = System.Drawing.Color.White;
            this.ShapefileGroupbar.GroupBarDropDownToolTip = null;
            this.ShapefileGroupbar.GroupBarItems.AddRange(new Syncfusion.Windows.Forms.Tools.GroupBarItem[] {
            this.ShapefileInformationItem,
            this.ShapefileSettingsItem});
            this.ShapefileGroupbar.IndexOnVisibleItems = true;
            this.ShapefileGroupbar.Location = new System.Drawing.Point(34, 87);
            this.ShapefileGroupbar.MinimizeButtonToolTip = null;
            this.ShapefileGroupbar.Name = "ShapefileGroupbar";
            this.ShapefileGroupbar.NavigationPaneTooltip = null;
            this.ShapefileGroupbar.PopupClientSize = new System.Drawing.Size(0, 0);
            this.ShapefileGroupbar.SelectedItem = 0;
            this.ShapefileGroupbar.Size = new System.Drawing.Size(345, 300);
            this.ShapefileGroupbar.TabIndex = 5;
            this.ShapefileGroupbar.Text = "groupBar1";
            this.ShapefileGroupbar.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // ShapefileInformationItem
            // 
            this.ShapefileInformationItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ShapefileInformationItem.Client = this.ShapefileInformationTextbox;
            this.ShapefileInformationItem.Image = global::MapWindow.Properties.Resources.mw_ball_48;
            this.ShapefileInformationItem.LargeImageMode = true;
            this.ShapefileInformationItem.Text = "Information";
            // 
            // ShapefileSettingsItem
            // 
            this.ShapefileSettingsItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ShapefileSettingsItem.Client = this.gradientPanel3;
            this.ShapefileSettingsItem.LargeImageMode = true;
            this.ShapefileSettingsItem.Text = "Settings";
            // 
            // ShapefileInformationTextbox
            // 
            this.ShapefileInformationTextbox.Location = new System.Drawing.Point(0, 22);
            this.ShapefileInformationTextbox.Multiline = true;
            this.ShapefileInformationTextbox.Name = "ShapefileInformationTextbox";
            this.ShapefileInformationTextbox.ReadOnly = true;
            this.ShapefileInformationTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ShapefileInformationTextbox.Size = new System.Drawing.Size(345, 256);
            this.ShapefileInformationTextbox.TabIndex = 0;
            // 
            // gradientPanel3
            // 
            this.gradientPanel3.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientPanel3.Controls.Add(this.label1);
            this.gradientPanel3.Location = new System.Drawing.Point(0, 300);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(345, 0);
            this.gradientPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(55, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TODO: Add controls";
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoEllipsis = true;
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel1.BeforeTouchSize = new System.Drawing.Size(188, 37);
            this.gradientLabel1.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel1.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel1.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel1.Location = new System.Drawing.Point(120, 9);
            this.gradientLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel1.Size = new System.Drawing.Size(188, 37);
            this.gradientLabel1.TabIndex = 6;
            this.gradientLabel1.Text = "Add a shapefile";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddLayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(212)))), ((int)(((byte)(241)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.CaptionBarHeight = 48;
            this.CaptionFont = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            captionImage1.BackColor = System.Drawing.Color.Transparent;
            captionImage1.Image = ((System.Drawing.Image)(resources.GetObject("captionImage1.Image")));
            captionImage1.Location = new System.Drawing.Point(10, 8);
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(32, 32);
            this.CaptionImages.Add(captionImage1);
            captionLabel1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            captionLabel1.Location = new System.Drawing.Point(50, 4);
            captionLabel1.Name = "CaptionLabel1";
            captionLabel1.Size = new System.Drawing.Size(400, 40);
            captionLabel1.Text = "Add Geospatial data";
            this.CaptionLabels.Add(captionLabel1);
            this.ClientSize = new System.Drawing.Size(550, 490);
            this.Controls.Add(this.tabControlAdv1);
            this.DropShadow = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddLayersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageShapefile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.tabPageGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.gradientPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            this.tabPageDatabase.ResumeLayout(false);
            this.tabPageDatabase.PerformLayout();
            this.tabPageWebservice.ResumeLayout(false);
            this.tabPageWebservice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShapefileGroupbar)).EndInit();
            this.ShapefileGroupbar.ResumeLayout(false);
            this.ShapefileGroupbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel3)).EndInit();
            this.gradientPanel3.ResumeLayout(false);
            this.gradientPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageShapefile;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageGrid;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageImage;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageDatabase;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageWebservice;
        private System.Windows.Forms.Button SelectShapefileButton;
        private System.Windows.Forms.TextBox SelectShapefileTextbox;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel3;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel4;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel5;
        private Syncfusion.Windows.Forms.ButtonAdv OpenShapefileButton;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.ButtonAdv OpenGridFileButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SelectGridfileButton;
        private System.Windows.Forms.TextBox SelectGridfileTextbox;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel2;
        private System.Windows.Forms.TextBox GridfilePropertiesTextbox;
        private Syncfusion.Windows.Forms.Tools.GroupBar ShapefileGroupbar;
        private Syncfusion.Windows.Forms.Tools.GroupBarItem ShapefileInformationItem;
        private Syncfusion.Windows.Forms.Tools.GroupBarItem ShapefileSettingsItem;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ShapefileInformationTextbox;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel1;


    }
}