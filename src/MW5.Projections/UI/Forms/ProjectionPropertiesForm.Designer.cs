using MW5.Api.Enums;
using MW5.Projections.Properties;
using MW5.Projections.UI.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Projections.UI.Forms
{
    partial class ProjectionPropertiesForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProj4 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtRemarks = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScope = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAreaName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabDescription = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabMap = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this._projectionMap1 = new MW5.Projections.UI.Controls.ProjectionMap();
            this.tabWkt = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.buttonAdv1 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.projectionTextBox1 = new MW5.Projections.UI.Controls.ProjectionTextBox();
            this.tabDialects = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.buttonAdv2 = new Syncfusion.Windows.Forms.ButtonAdv();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.txtDialect = new MW5.Projections.UI.Controls.ProjectionTextBox();
            this.btnRemove = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAdd = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProj4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tabMap.SuspendLayout();
            this.tabWkt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.tabDialects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BeforeTouchSize = new System.Drawing.Size(420, 186);
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Location = new System.Drawing.Point(77, 29);
            this.txtName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(364, 20);
            this.txtName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "EPSG";
            // 
            // txtCode
            // 
            this.txtCode.BeforeTouchSize = new System.Drawing.Size(420, 186);
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.Location = new System.Drawing.Point(77, 70);
            this.txtCode.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(73, 20);
            this.txtCode.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtCode.TabIndex = 23;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(156, 73);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(66, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "See online...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Proj 4:";
            // 
            // txtProj4
            // 
            this.txtProj4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProj4.BeforeTouchSize = new System.Drawing.Size(420, 186);
            this.txtProj4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProj4.Location = new System.Drawing.Point(27, 221);
            this.txtProj4.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtProj4.Multiline = true;
            this.txtProj4.Name = "txtProj4";
            this.txtProj4.ReadOnly = true;
            this.txtProj4.Size = new System.Drawing.Size(414, 70);
            this.txtProj4.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtProj4.TabIndex = 15;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BeforeTouchSize = new System.Drawing.Size(420, 186);
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.Location = new System.Drawing.Point(27, 323);
            this.txtRemarks.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(414, 118);
            this.txtRemarks.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtRemarks.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Remarks:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Scope:";
            // 
            // txtScope
            // 
            this.txtScope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScope.BeforeTouchSize = new System.Drawing.Size(420, 186);
            this.txtScope.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScope.Location = new System.Drawing.Point(27, 131);
            this.txtScope.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtScope.Multiline = true;
            this.txtScope.Name = "txtScope";
            this.txtScope.ReadOnly = true;
            this.txtScope.Size = new System.Drawing.Size(414, 59);
            this.txtScope.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtScope.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Area description:";
            // 
            // txtAreaName
            // 
            this.txtAreaName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAreaName.BeforeTouchSize = new System.Drawing.Size(420, 186);
            this.txtAreaName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAreaName.Location = new System.Drawing.Point(20, 253);
            this.txtAreaName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtAreaName.Multiline = true;
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.ReadOnly = true;
            this.txtAreaName.Size = new System.Drawing.Size(420, 186);
            this.txtAreaName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtAreaName.TabIndex = 17;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(22, 52);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(420, 110);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "#";
            this.columnHeader2.Width = 30;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Format";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Dialect definition";
            this.columnHeader3.Width = 320;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Dialect definition:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(19, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(390, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "Dialects are alternative formulations of the projection. Add to this list any WKT" +
    " or proj4 strings that should be bound to the current EPSG code:\r\n";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BeforeTouchSize = new System.Drawing.Size(461, 492);
            this.tabControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl1.Controls.Add(this.tabDescription);
            this.tabControl1.Controls.Add(this.tabMap);
            this.tabControl1.Controls.Add(this.tabWkt);
            this.tabControl1.Controls.Add(this.tabDialects);
            this.tabControl1.FixedSingleBorderColor = System.Drawing.Color.LightGray;
            this.tabControl1.FocusOnTabClick = false;
            this.tabControl1.Location = new System.Drawing.Point(5, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(461, 492);
            this.tabControl1.TabIndex = 24;
            this.tabControl1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.label8);
            this.tabDescription.Controls.Add(this.txtName);
            this.tabDescription.Controls.Add(this.txtProj4);
            this.tabDescription.Controls.Add(this.label1);
            this.tabDescription.Controls.Add(this.txtRemarks);
            this.tabDescription.Controls.Add(this.label3);
            this.tabDescription.Controls.Add(this.label4);
            this.tabDescription.Controls.Add(this.txtCode);
            this.tabDescription.Controls.Add(this.label2);
            this.tabDescription.Controls.Add(this.linkLabel1);
            this.tabDescription.Controls.Add(this.txtScope);
            this.tabDescription.Image = null;
            this.tabDescription.ImageSize = new System.Drawing.Size(16, 16);
            this.tabDescription.Location = new System.Drawing.Point(1, 22);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.ShowCloseButton = true;
            this.tabDescription.Size = new System.Drawing.Size(459, 469);
            this.tabDescription.TabIndex = 1;
            this.tabDescription.Text = "Description";
            this.tabDescription.ThemesEnabled = false;
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this._projectionMap1);
            this.tabMap.Controls.Add(this.label5);
            this.tabMap.Controls.Add(this.txtAreaName);
            this.tabMap.Image = null;
            this.tabMap.ImageSize = new System.Drawing.Size(16, 16);
            this.tabMap.Location = new System.Drawing.Point(1, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.ShowCloseButton = true;
            this.tabMap.Size = new System.Drawing.Size(459, 469);
            this.tabMap.TabIndex = 2;
            this.tabMap.Text = "Area of use";
            this.tabMap.ThemesEnabled = false;
            // 
            // _projectionMap1
            // 
            this._projectionMap1.AllowDrop = true;
            this._projectionMap1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._projectionMap1.AnimationOnZooming = MW5.Api.Enums.AutoToggle.Auto;
            this._projectionMap1.BackgroundColor = System.Drawing.Color.White;
            this._projectionMap1.CurrentScale = 16.289511562153113D;
            this._projectionMap1.CurrentZoom = -1;
            this._projectionMap1.ExtentHistory = 20;
            this._projectionMap1.ExtentPad = 0.02D;
            this._projectionMap1.GrabProjectionFromData = true;
            this._projectionMap1.InertiaOnPanning = MW5.Api.Enums.AutoToggle.Auto;
            this._projectionMap1.KnownExtents = MW5.Api.Enums.KnownExtents.None;
            this._projectionMap1.Latitude = 0F;
            this._projectionMap1.Location = new System.Drawing.Point(20, 12);
            this._projectionMap1.Longitude = 0F;
            this._projectionMap1.MapCursor = MW5.Api.Enums.MapCursor.ZoomIn;
            this._projectionMap1.MapProjection = MW5.Api.Enums.MapProjection.None;
            this._projectionMap1.MapUnits = MW5.Api.Enums.LengthUnits.Meters;
            this._projectionMap1.MouseWheelSpeed = 0.5D;
            this._projectionMap1.Name = "_projectionMap1";
            spatialReference1.Tag = "";
            this._projectionMap1.Projection = spatialReference1;
            this._projectionMap1.ResizeBehavior = MW5.Api.Enums.ResizeBehavior.Classic;
            this._projectionMap1.ReuseTileBuffer = true;
            this._projectionMap1.ScalebarUnits = MW5.Api.Enums.ScalebarUnits.GoogleStyle;
            this._projectionMap1.ScalebarVisible = true;
            this._projectionMap1.ShowCoordinates = MW5.Api.Enums.CoordinatesDisplay.Auto;
            this._projectionMap1.ShowCoordinatesFormat = MW5.Api.Enums.AngleFormat.Degrees;
            this._projectionMap1.ShowRedrawTime = false;
            this._projectionMap1.ShowVersionNumber = false;
            this._projectionMap1.Size = new System.Drawing.Size(420, 203);
            this._projectionMap1.SystemCursor = MW5.Api.Enums.SystemCursor.MapDefault;
            this._projectionMap1.TabIndex = 20;
            this._projectionMap1.Tag = "";
            this._projectionMap1.TileProvider = MW5.Api.Enums.TileProvider.OpenStreetMap;
            this._projectionMap1.UdCursorHandle = 0;
            this._projectionMap1.UseSeamlessPan = false;
            this._projectionMap1.ZoomBehavior = MW5.Api.Enums.ZoomBehavior.UseTileLevels;
            this._projectionMap1.ZoomBoxStyle = MW5.Api.Enums.ZoomBoxStyle.Blue;
            this._projectionMap1.ZoomPercent = 0.3D;
            // 
            // tabWkt
            // 
            this.tabWkt.Controls.Add(this.buttonAdv1);
            this.tabWkt.Controls.Add(this.gradientPanel1);
            this.tabWkt.Image = null;
            this.tabWkt.ImageSize = new System.Drawing.Size(16, 16);
            this.tabWkt.Location = new System.Drawing.Point(1, 22);
            this.tabWkt.Name = "tabWkt";
            this.tabWkt.ShowCloseButton = true;
            this.tabWkt.Size = new System.Drawing.Size(459, 469);
            this.tabWkt.TabIndex = 3;
            this.tabWkt.Text = "ESRI WKT";
            this.tabWkt.ThemesEnabled = false;
            // 
            // buttonAdv1
            // 
            this.buttonAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdv1.BeforeTouchSize = new System.Drawing.Size(110, 23);
            this.buttonAdv1.IsBackStageButton = false;
            this.buttonAdv1.Location = new System.Drawing.Point(334, 429);
            this.buttonAdv1.Name = "buttonAdv1";
            this.buttonAdv1.Size = new System.Drawing.Size(110, 23);
            this.buttonAdv1.TabIndex = 4;
            this.buttonAdv1.Text = "Copy to clipboard";
            this.buttonAdv1.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White);
            this.gradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel1.Controls.Add(this.projectionTextBox1);
            this.gradientPanel1.Location = new System.Drawing.Point(18, 13);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.gradientPanel1.Size = new System.Drawing.Size(426, 410);
            this.gradientPanel1.TabIndex = 6;
            // 
            // projectionTextBox1
            // 
            this.projectionTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectionTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectionTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.projectionTextBox1.Location = new System.Drawing.Point(5, 5);
            this.projectionTextBox1.Name = "projectionTextBox1";
            this.projectionTextBox1.Size = new System.Drawing.Size(414, 398);
            this.projectionTextBox1.TabIndex = 0;
            this.projectionTextBox1.Text = "";
            // 
            // tabDialects
            // 
            this.tabDialects.Controls.Add(this.buttonAdv2);
            this.tabDialects.Controls.Add(this.gradientPanel2);
            this.tabDialects.Controls.Add(this.btnRemove);
            this.tabDialects.Controls.Add(this.btnAdd);
            this.tabDialects.Controls.Add(this.listView1);
            this.tabDialects.Controls.Add(this.label6);
            this.tabDialects.Controls.Add(this.label7);
            this.tabDialects.Image = null;
            this.tabDialects.ImageSize = new System.Drawing.Size(16, 16);
            this.tabDialects.Location = new System.Drawing.Point(1, 22);
            this.tabDialects.Name = "tabDialects";
            this.tabDialects.ShowCloseButton = true;
            this.tabDialects.Size = new System.Drawing.Size(459, 469);
            this.tabDialects.TabIndex = 4;
            this.tabDialects.Text = "Dialects";
            this.tabDialects.ThemesEnabled = false;
            // 
            // buttonAdv2
            // 
            this.buttonAdv2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonAdv2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.buttonAdv2.BeforeTouchSize = new System.Drawing.Size(69, 23);
            this.buttonAdv2.ForeColor = System.Drawing.Color.White;
            this.buttonAdv2.IsBackStageButton = false;
            this.buttonAdv2.Location = new System.Drawing.Point(373, 430);
            this.buttonAdv2.Name = "buttonAdv2";
            this.buttonAdv2.Size = new System.Drawing.Size(69, 23);
            this.buttonAdv2.TabIndex = 36;
            this.buttonAdv2.Text = "Edit";
            this.buttonAdv2.UseVisualStyle = false;
            this.buttonAdv2.Click += new System.EventHandler(this.buttonAdv2_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel2.BackColor = System.Drawing.Color.White;
            this.gradientPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel2.Controls.Add(this.txtDialect);
            this.gradientPanel2.Location = new System.Drawing.Point(22, 212);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.gradientPanel2.Size = new System.Drawing.Size(420, 212);
            this.gradientPanel2.TabIndex = 37;
            // 
            // txtDialect
            // 
            this.txtDialect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDialect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDialect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDialect.Location = new System.Drawing.Point(5, 5);
            this.txtDialect.Name = "txtDialect";
            this.txtDialect.Size = new System.Drawing.Size(408, 200);
            this.txtDialect.TabIndex = 0;
            this.txtDialect.Text = "";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnRemove.BeforeTouchSize = new System.Drawing.Size(69, 23);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.IsBackStageButton = false;
            this.btnRemove.Location = new System.Drawing.Point(373, 168);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(69, 23);
            this.btnRemove.TabIndex = 35;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyle = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnAdd.BeforeTouchSize = new System.Drawing.Size(69, 23);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.IsBackStageButton = false;
            this.btnAdd.Location = new System.Drawing.Point(299, 168);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 23);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyle = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(377, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(287, 510);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 33;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyle = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ProjectionPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 548);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 405);
            this.Name = "ProjectionPropertiesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projection Properties";
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProj4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabDescription.PerformLayout();
            this.tabMap.ResumeLayout(false);
            this.tabMap.PerformLayout();
            this.tabWkt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.tabDialects.ResumeLayout(false);
            this.tabDialects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TextBoxExt txtName;
        private System.Windows.Forms.Label label3;
        private TextBoxExt txtCode;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private TextBoxExt txtScope;
        private TextBoxExt txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private TextBoxExt txtAreaName;
        private System.Windows.Forms.Label label8;
        private TextBoxExt txtProj4;
        private ProjectionTextBox projectionTextBox1;
        private ProjectionMap _projectionMap1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControl1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabDescription;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabMap;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabWkt;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabDialects;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv1;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv2;
        private Syncfusion.Windows.Forms.ButtonAdv btnRemove;
        private Syncfusion.Windows.Forms.ButtonAdv btnAdd;
        private GradientPanel gradientPanel1;
        private GradientPanel gradientPanel2;
        private ProjectionTextBox txtDialect;
    }
}
