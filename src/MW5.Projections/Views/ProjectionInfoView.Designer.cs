using MW5.Projections.Controls;

namespace MW5.Projections.Views
{
    partial class ProjectionInfoView
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
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tabControl1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabDescription = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtProj4 = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtScope = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.tabMap = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this._projectionMap1 = new MW5.Projections.Controls.ProjectionMap();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAreaName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.tabWkt = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnCopyClipboard = new Syncfusion.Windows.Forms.ButtonAdv();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.projectionTextBox1 = new MW5.Projections.Controls.ProjectionTextBox();
            this.tabEsriWkt = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.btnCopyClipboardEsri = new Syncfusion.Windows.Forms.ButtonAdv();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.projectionTextBoxEsri = new MW5.Projections.Controls.ProjectionTextBox();
            this.tabDialects = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.dialectGrid1 = new MW5.Projections.Controls.DialectGrid();
            this.btnClearDialects = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnEditDialect = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRemoveDialect = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAddDialect = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProj4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScope)).BeginInit();
            this.tabMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName)).BeginInit();
            this.tabWkt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.tabEsriWkt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            this.tabDialects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dialectGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.btnCancel.Location = new System.Drawing.Point(377, 511);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 37;
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
            this.btnOk.Location = new System.Drawing.Point(287, 511);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 36;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyle = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BeforeTouchSize = new System.Drawing.Size(450, 493);
            this.tabControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl1.Controls.Add(this.tabDescription);
            this.tabControl1.Controls.Add(this.tabMap);
            this.tabControl1.Controls.Add(this.tabWkt);
            this.tabControl1.Controls.Add(this.tabEsriWkt);
            this.tabControl1.Controls.Add(this.tabDialects);
            this.tabControl1.FixedSingleBorderColor = System.Drawing.Color.LightGray;
            this.tabControl1.FocusOnTabClick = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(450, 493);
            this.tabControl1.TabIndex = 35;
            this.tabControl1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
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
            this.tabDescription.Size = new System.Drawing.Size(448, 470);
            this.tabDescription.TabIndex = 1;
            this.tabDescription.Text = "Description";
            this.tabDescription.ThemesEnabled = false;
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
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BeforeTouchSize = new System.Drawing.Size(409, 186);
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Location = new System.Drawing.Point(77, 29);
            this.txtName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(353, 20);
            this.txtName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtName.TabIndex = 1;
            // 
            // txtProj4
            // 
            this.txtProj4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProj4.BeforeTouchSize = new System.Drawing.Size(409, 186);
            this.txtProj4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProj4.Location = new System.Drawing.Point(27, 221);
            this.txtProj4.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtProj4.Multiline = true;
            this.txtProj4.Name = "txtProj4";
            this.txtProj4.ReadOnly = true;
            this.txtProj4.Size = new System.Drawing.Size(403, 70);
            this.txtProj4.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtProj4.TabIndex = 15;
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
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BeforeTouchSize = new System.Drawing.Size(409, 186);
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.Location = new System.Drawing.Point(27, 323);
            this.txtRemarks.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(403, 107);
            this.txtRemarks.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtRemarks.TabIndex = 16;
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
            // txtCode
            // 
            this.txtCode.BeforeTouchSize = new System.Drawing.Size(409, 186);
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.Location = new System.Drawing.Point(77, 70);
            this.txtCode.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(73, 20);
            this.txtCode.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtCode.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Scope:";
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
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnEpsgLinkClicked);
            // 
            // txtScope
            // 
            this.txtScope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScope.BeforeTouchSize = new System.Drawing.Size(409, 186);
            this.txtScope.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScope.Location = new System.Drawing.Point(27, 131);
            this.txtScope.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtScope.Multiline = true;
            this.txtScope.Name = "txtScope";
            this.txtScope.ReadOnly = true;
            this.txtScope.Size = new System.Drawing.Size(403, 59);
            this.txtScope.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtScope.TabIndex = 13;
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
            this.tabMap.Size = new System.Drawing.Size(448, 470);
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
            this._projectionMap1.CurrentScale = 21.24436183764016D;
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
            this._projectionMap1.Size = new System.Drawing.Size(409, 219);
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
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Area description:";
            // 
            // txtAreaName
            // 
            this.txtAreaName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAreaName.BeforeTouchSize = new System.Drawing.Size(409, 186);
            this.txtAreaName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAreaName.Location = new System.Drawing.Point(20, 259);
            this.txtAreaName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtAreaName.Multiline = true;
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.ReadOnly = true;
            this.txtAreaName.Size = new System.Drawing.Size(409, 186);
            this.txtAreaName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtAreaName.TabIndex = 17;
            // 
            // tabWkt
            // 
            this.tabWkt.Controls.Add(this.btnCopyClipboard);
            this.tabWkt.Controls.Add(this.gradientPanel1);
            this.tabWkt.Image = null;
            this.tabWkt.ImageSize = new System.Drawing.Size(16, 16);
            this.tabWkt.Location = new System.Drawing.Point(1, 22);
            this.tabWkt.Name = "tabWkt";
            this.tabWkt.ShowCloseButton = true;
            this.tabWkt.Size = new System.Drawing.Size(448, 470);
            this.tabWkt.TabIndex = 3;
            this.tabWkt.Text = "WKT";
            this.tabWkt.ThemesEnabled = false;
            // 
            // btnCopyClipboard
            // 
            this.btnCopyClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyClipboard.BeforeTouchSize = new System.Drawing.Size(110, 23);
            this.btnCopyClipboard.IsBackStageButton = false;
            this.btnCopyClipboard.Location = new System.Drawing.Point(323, 432);
            this.btnCopyClipboard.Name = "btnCopyClipboard";
            this.btnCopyClipboard.Size = new System.Drawing.Size(110, 23);
            this.btnCopyClipboard.TabIndex = 4;
            this.btnCopyClipboard.Text = "Copy to clipboard";
            this.btnCopyClipboard.Click += new System.EventHandler(this.OnCopyClipboardClick);
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
            this.gradientPanel1.Size = new System.Drawing.Size(415, 413);
            this.gradientPanel1.TabIndex = 6;
            // 
            // projectionTextBox1
            // 
            this.projectionTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectionTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectionTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.projectionTextBox1.Location = new System.Drawing.Point(5, 5);
            this.projectionTextBox1.Name = "projectionTextBox1";
            this.projectionTextBox1.Size = new System.Drawing.Size(403, 401);
            this.projectionTextBox1.TabIndex = 0;
            this.projectionTextBox1.Text = "";
            // 
            // tabEsriWkt
            // 
            this.tabEsriWkt.Controls.Add(this.btnCopyClipboardEsri);
            this.tabEsriWkt.Controls.Add(this.gradientPanel2);
            this.tabEsriWkt.Image = null;
            this.tabEsriWkt.ImageSize = new System.Drawing.Size(16, 16);
            this.tabEsriWkt.Location = new System.Drawing.Point(1, 22);
            this.tabEsriWkt.Name = "tabEsriWkt";
            this.tabEsriWkt.ShowCloseButton = true;
            this.tabEsriWkt.Size = new System.Drawing.Size(448, 470);
            this.tabEsriWkt.TabIndex = 5;
            this.tabEsriWkt.Text = "ESRI WKT";
            this.tabEsriWkt.ThemesEnabled = false;
            // 
            // btnCopyClipboardEsri
            // 
            this.btnCopyClipboardEsri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyClipboardEsri.BeforeTouchSize = new System.Drawing.Size(110, 23);
            this.btnCopyClipboardEsri.IsBackStageButton = false;
            this.btnCopyClipboardEsri.Location = new System.Drawing.Point(322, 433);
            this.btnCopyClipboardEsri.Name = "btnCopyClipboardEsri";
            this.btnCopyClipboardEsri.Size = new System.Drawing.Size(110, 23);
            this.btnCopyClipboardEsri.TabIndex = 7;
            this.btnCopyClipboardEsri.Text = "Copy to clipboard";
            this.btnCopyClipboardEsri.Click += new System.EventHandler(this.btnCopyClipboardEsri_Click);
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White);
            this.gradientPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel2.Controls.Add(this.projectionTextBoxEsri);
            this.gradientPanel2.Location = new System.Drawing.Point(17, 14);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.gradientPanel2.Size = new System.Drawing.Size(415, 413);
            this.gradientPanel2.TabIndex = 8;
            // 
            // projectionTextBoxEsri
            // 
            this.projectionTextBoxEsri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectionTextBoxEsri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectionTextBoxEsri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.projectionTextBoxEsri.Location = new System.Drawing.Point(5, 5);
            this.projectionTextBoxEsri.Name = "projectionTextBoxEsri";
            this.projectionTextBoxEsri.Size = new System.Drawing.Size(403, 401);
            this.projectionTextBoxEsri.TabIndex = 0;
            this.projectionTextBoxEsri.Text = "";
            // 
            // tabDialects
            // 
            this.tabDialects.Controls.Add(this.dialectGrid1);
            this.tabDialects.Controls.Add(this.btnClearDialects);
            this.tabDialects.Controls.Add(this.btnEditDialect);
            this.tabDialects.Controls.Add(this.btnRemoveDialect);
            this.tabDialects.Controls.Add(this.btnAddDialect);
            this.tabDialects.Controls.Add(this.label6);
            this.tabDialects.Image = null;
            this.tabDialects.ImageSize = new System.Drawing.Size(16, 16);
            this.tabDialects.Location = new System.Drawing.Point(1, 22);
            this.tabDialects.Name = "tabDialects";
            this.tabDialects.ShowCloseButton = true;
            this.tabDialects.Size = new System.Drawing.Size(448, 470);
            this.tabDialects.TabIndex = 4;
            this.tabDialects.Text = "Dialects";
            this.tabDialects.ThemesEnabled = false;
            // 
            // dialectGrid1
            // 
            this.dialectGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialectGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dialectGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dialectGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dialectGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.dialectGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.dialectGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.dialectGrid1.FreezeCaption = false;
            this.dialectGrid1.Location = new System.Drawing.Point(14, 42);
            this.dialectGrid1.Name = "dialectGrid1";
            this.dialectGrid1.Size = new System.Drawing.Size(419, 386);
            this.dialectGrid1.TabIndex = 38;
            this.dialectGrid1.TableDescriptor.AllowEdit = false;
            this.dialectGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.dialectGrid1.TableOptions.AllowDropDownCell = false;
            this.dialectGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.dialectGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.dialectGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.dialectGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.dialectGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.dialectGrid1.Text = "dialectGrid1";
            this.dialectGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.dialectGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.dialectGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.dialectGrid1.VersionInfo = "5.0.1.0";
            this.dialectGrid1.WrapWithPanel = true;
            // 
            // btnClearDialects
            // 
            this.btnClearDialects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearDialects.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClearDialects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClearDialects.BeforeTouchSize = new System.Drawing.Size(69, 23);
            this.btnClearDialects.ForeColor = System.Drawing.Color.White;
            this.btnClearDialects.IsBackStageButton = false;
            this.btnClearDialects.Location = new System.Drawing.Point(364, 434);
            this.btnClearDialects.Name = "btnClearDialects";
            this.btnClearDialects.Size = new System.Drawing.Size(69, 23);
            this.btnClearDialects.TabIndex = 38;
            this.btnClearDialects.Text = "Clear";
            this.btnClearDialects.UseVisualStyle = false;
            // 
            // btnEditDialect
            // 
            this.btnEditDialect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDialect.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnEditDialect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnEditDialect.BeforeTouchSize = new System.Drawing.Size(69, 23);
            this.btnEditDialect.ForeColor = System.Drawing.Color.White;
            this.btnEditDialect.IsBackStageButton = false;
            this.btnEditDialect.Location = new System.Drawing.Point(213, 434);
            this.btnEditDialect.Name = "btnEditDialect";
            this.btnEditDialect.Size = new System.Drawing.Size(69, 23);
            this.btnEditDialect.TabIndex = 36;
            this.btnEditDialect.Text = "Edit";
            this.btnEditDialect.UseVisualStyle = false;
            // 
            // btnRemoveDialect
            // 
            this.btnRemoveDialect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveDialect.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnRemoveDialect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnRemoveDialect.BeforeTouchSize = new System.Drawing.Size(69, 23);
            this.btnRemoveDialect.ForeColor = System.Drawing.Color.White;
            this.btnRemoveDialect.IsBackStageButton = false;
            this.btnRemoveDialect.Location = new System.Drawing.Point(288, 434);
            this.btnRemoveDialect.Name = "btnRemoveDialect";
            this.btnRemoveDialect.Size = new System.Drawing.Size(69, 23);
            this.btnRemoveDialect.TabIndex = 35;
            this.btnRemoveDialect.Text = "Remove";
            this.btnRemoveDialect.UseVisualStyle = false;
            // 
            // btnAddDialect
            // 
            this.btnAddDialect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDialect.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnAddDialect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnAddDialect.BeforeTouchSize = new System.Drawing.Size(69, 23);
            this.btnAddDialect.ForeColor = System.Drawing.Color.White;
            this.btnAddDialect.IsBackStageButton = false;
            this.btnAddDialect.Location = new System.Drawing.Point(138, 434);
            this.btnAddDialect.Name = "btnAddDialect";
            this.btnAddDialect.Size = new System.Drawing.Size(69, 23);
            this.btnAddDialect.TabIndex = 34;
            this.btnAddDialect.Text = "Add";
            this.btnAddDialect.UseVisualStyle = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(19, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(379, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "Dialects are alternative formulations of the projection. Add to this list any WKT" +
    " or proj4 strings that should be bound to the current EPSG code:\r\n";
            // 
            // ProjectionInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 548);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.Name = "ProjectionInfoView";
            this.Text = "Projection Properties";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProj4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScope)).EndInit();
            this.tabMap.ResumeLayout(false);
            this.tabMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName)).EndInit();
            this.tabWkt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.tabEsriWkt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            this.tabDialects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dialectGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControl1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabDescription;
        private System.Windows.Forms.Label label8;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtProj4;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtScope;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabMap;
        private ProjectionMap _projectionMap1;
        private System.Windows.Forms.Label label5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAreaName;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabWkt;
        private Syncfusion.Windows.Forms.ButtonAdv btnCopyClipboard;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private ProjectionTextBox projectionTextBox1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabDialects;
        private Syncfusion.Windows.Forms.ButtonAdv btnClearDialects;
        private Syncfusion.Windows.Forms.ButtonAdv btnEditDialect;
        private Syncfusion.Windows.Forms.ButtonAdv btnRemoveDialect;
        private Syncfusion.Windows.Forms.ButtonAdv btnAddDialect;
        private System.Windows.Forms.Label label6;
        private DialectGrid dialectGrid1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabEsriWkt;
        private Syncfusion.Windows.Forms.ButtonAdv btnCopyClipboardEsri;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private ProjectionTextBox projectionTextBoxEsri;

    }
}