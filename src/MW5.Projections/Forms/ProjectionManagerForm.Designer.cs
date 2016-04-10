using MW5.Projections.Controls;

namespace MW5.Projections.Forms
{
    partial class ProjectionManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectionManagerForm));
            MW5.Api.Concrete.Envelope envelope1 = new MW5.Api.Concrete.Envelope();
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblGcsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPcsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblY = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._projectionTreeView1 = new MW5.Projections.Controls.ProjectionTreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnZoomToProjection = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnProperties = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZoomToMaxExtents = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtScope = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.projectionMap1 = new MW5.Projections.Controls.ProjectionMap();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._projectionTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblGcsCount,
            this.lblPcsCount,
            this.lblX,
            this.lblY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(674, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblGcsCount
            // 
            this.lblGcsCount.Name = "lblGcsCount";
            this.lblGcsCount.Size = new System.Drawing.Size(97, 19);
            this.lblGcsCount.Text = "Geopraphical CS:";
            // 
            // lblPcsCount
            // 
            this.lblPcsCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblPcsCount.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblPcsCount.Name = "lblPcsCount";
            this.lblPcsCount.Size = new System.Drawing.Size(81, 19);
            this.lblPcsCount.Text = "Projected CS:";
            // 
            // lblX
            // 
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(55, 19);
            this.lblX.Text = "Long: 0.0";
            // 
            // lblY
            // 
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(44, 19);
            this.lblY.Text = "Lat: 0.0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._projectionTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(674, 448);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 3;
            // 
            // _projectionTreeView1
            // 
            this._projectionTreeView1.ApplyStyle = true;
            this._projectionTreeView1.BeforeTouchSize = new System.Drawing.Size(326, 448);
            this._projectionTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this._projectionTreeView1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this._projectionTreeView1.HelpTextControl.Name = "helpText";
            this._projectionTreeView1.HelpTextControl.TabIndex = 0;
            this._projectionTreeView1.HideSelection = false;
            this._projectionTreeView1.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this._projectionTreeView1.Location = new System.Drawing.Point(0, 0);
            this._projectionTreeView1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this._projectionTreeView1.Name = "_projectionTreeView1";
            this._projectionTreeView1.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            this._projectionTreeView1.ShowSuperTooltip = true;
            this._projectionTreeView1.Size = new System.Drawing.Size(326, 448);
            this._projectionTreeView1.TabIndex = 0;
            // 
            // 
            // 
            this._projectionTreeView1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this._projectionTreeView1.ToolTipControl.Name = "toolTip";
            this._projectionTreeView1.ToolTipControl.TabIndex = 1;
            this._projectionTreeView1.ToolTipDuration = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.projectionMap1);
            this.splitContainer2.Size = new System.Drawing.Size(344, 448);
            this.splitContainer2.SplitterDistance = 191;
            this.splitContainer2.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnZoomToProjection);
            this.panel1.Controls.Add(this.btnProperties);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnZoomToMaxExtents);
            this.panel1.Controls.Add(this.txtRemarks);
            this.panel1.Controls.Add(this.txtScope);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 189);
            this.panel1.TabIndex = 10;
            // 
            // btnZoomToProjection
            // 
            this.btnZoomToProjection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoomToProjection.ImageIndex = 1;
            this.btnZoomToProjection.ImageList = this.imageList1;
            this.btnZoomToProjection.Location = new System.Drawing.Point(112, 156);
            this.btnZoomToProjection.Margin = new System.Windows.Forms.Padding(5);
            this.btnZoomToProjection.Name = "btnZoomToProjection";
            this.btnZoomToProjection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnZoomToProjection.Size = new System.Drawing.Size(123, 28);
            this.btnZoomToProjection.TabIndex = 20;
            this.btnZoomToProjection.Text = "Zoom to projection";
            this.btnZoomToProjection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZoomToProjection.UseVisualStyleBackColor = true;
            this.btnZoomToProjection.Click += new System.EventHandler(this.btnZoomToProjection_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "zoom-extentNew.png");
            this.imageList1.Images.SetKeyName(1, "zoom-selectionNew.png");
            this.imageList1.Images.SetKeyName(2, "page_white_magnify.png");
            // 
            // btnProperties
            // 
            this.btnProperties.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProperties.ImageIndex = 2;
            this.btnProperties.ImageList = this.imageList1;
            this.btnProperties.Location = new System.Drawing.Point(245, 156);
            this.btnProperties.Margin = new System.Windows.Forms.Padding(5);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(84, 28);
            this.btnProperties.TabIndex = 19;
            this.btnProperties.Text = "Properties";
            this.btnProperties.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Code";
            // 
            // btnZoomToMaxExtents
            // 
            this.btnZoomToMaxExtents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZoomToMaxExtents.ImageIndex = 0;
            this.btnZoomToMaxExtents.ImageList = this.imageList1;
            this.btnZoomToMaxExtents.Location = new System.Drawing.Point(12, 156);
            this.btnZoomToMaxExtents.Margin = new System.Windows.Forms.Padding(5);
            this.btnZoomToMaxExtents.Name = "btnZoomToMaxExtents";
            this.btnZoomToMaxExtents.Size = new System.Drawing.Size(90, 28);
            this.btnZoomToMaxExtents.TabIndex = 16;
            this.btnZoomToMaxExtents.Text = "Zoom to All";
            this.btnZoomToMaxExtents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnZoomToMaxExtents.UseVisualStyleBackColor = true;
            this.btnZoomToMaxExtents.Click += new System.EventHandler(this.btnZoomToMaxExtents_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(13, 117);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(317, 32);
            this.txtRemarks.TabIndex = 14;
            // 
            // txtScope
            // 
            this.txtScope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScope.Location = new System.Drawing.Point(14, 81);
            this.txtScope.Multiline = true;
            this.txtScope.Name = "txtScope";
            this.txtScope.ReadOnly = true;
            this.txtScope.Size = new System.Drawing.Size(316, 30);
            this.txtScope.TabIndex = 13;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(49, 46);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(281, 20);
            this.txtName.TabIndex = 10;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(118, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(66, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "See online...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(49, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(63, 20);
            this.txtCode.TabIndex = 7;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            // 
            // projectionMap1
            // 
            this.projectionMap1.AllowDrop = true;
            this.projectionMap1.AnimationOnZooming = MW5.Api.Enums.AutoToggle.Auto;
            this.projectionMap1.BackgroundColor = System.Drawing.Color.White;
            this.projectionMap1.CurrentScale = 18.24950448370787D;
            this.projectionMap1.CurrentZoom = -1;
            this.projectionMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectionMap1.ExpandLayersOnAdding = true;
            this.projectionMap1.ExtentHistory = 20;
            this.projectionMap1.ExtentPad = 0.02D;
            envelope1.Tag = "";
            this.projectionMap1.Extents = envelope1;
            this.projectionMap1.GrabProjectionFromData = true;
            this.projectionMap1.InertiaOnPanning = MW5.Api.Enums.AutoToggle.Auto;
            this.projectionMap1.KnownExtents = MW5.Api.Enums.KnownExtents.None;
            this.projectionMap1.Latitude = 0F;
            this.projectionMap1.Location = new System.Drawing.Point(0, 0);
            this.projectionMap1.Longitude = 0F;
            this.projectionMap1.MapCursor = MW5.Api.Enums.MapCursor.ZoomIn;
            this.projectionMap1.MapProjection = MW5.Api.Enums.MapProjection.None;
            this.projectionMap1.MapUnits = MW5.Api.Enums.LengthUnits.Meters;
            this.projectionMap1.MouseWheelSpeed = 0.5D;
            this.projectionMap1.Name = "projectionMap1";
            spatialReference1.Tag = "";
            this.projectionMap1.Projection = spatialReference1;
            this.projectionMap1.ResizeBehavior = MW5.Api.Enums.ResizeBehavior.Classic;
            this.projectionMap1.ReuseTileBuffer = true;
            this.projectionMap1.ScalebarUnits = MW5.Api.Enums.ScalebarUnits.GoogleStyle;
            this.projectionMap1.ScalebarVisible = true;
            this.projectionMap1.ShowCoordinates = MW5.Api.Enums.CoordinatesDisplay.Auto;
            this.projectionMap1.ShowCoordinatesFormat = MW5.Api.Enums.AngleFormat.Degrees;
            this.projectionMap1.ShowRedrawTime = false;
            this.projectionMap1.ShowVersionNumber = false;
            this.projectionMap1.Size = new System.Drawing.Size(342, 251);
            this.projectionMap1.SystemCursor = MW5.Api.Enums.SystemCursor.MapDefault;
            this.projectionMap1.TabIndex = 12;
            this.projectionMap1.Tag = "";
            this.projectionMap1.TileProvider = MW5.Api.Enums.TileProvider.OpenStreetMap;
            this.projectionMap1.UdCursorHandle = -572069904;
            this.projectionMap1.UseSeamlessPan = false;
            this.projectionMap1.ZoomBehavior = MW5.Api.Enums.ZoomBehavior.UseTileLevels;
            this.projectionMap1.ZoomBoxStyle = MW5.Api.Enums.ZoomBoxStyle.Blue;
            this.projectionMap1.ZoomPercent = 0.3D;
            // 
            // ProjectionManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(674, 472);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.Name = "ProjectionManagerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projection Viewer";
            this.Load += new System.EventHandler(this.ProjectionManagerForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._projectionTreeView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectionTreeView _projectionTreeView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblGcsCount;
        private System.Windows.Forms.ToolStripStatusLabel lblPcsCount;
        private System.Windows.Forms.ToolStripStatusLabel lblX;
        private System.Windows.Forms.ToolStripStatusLabel lblY;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtName;
        private ProjectionMap projectionMap1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtScope;
        private System.Windows.Forms.Button btnZoomToMaxExtents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnZoomToProjection;
        private System.Windows.Forms.ImageList imageList1;
    }
}