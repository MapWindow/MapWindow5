using MW5.Api.Enums;
using MW5.Projections.Controls;
using MW5.UI.Legacy;

namespace MW5.Projections.Forms
{
    partial class ProjectionResultsForm
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
            MW5.Api.Concrete.Envelope envelope1 = new MW5.Api.Concrete.Envelope();
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.projectionMap1 = new MW5.Projections.Controls.ProjectionMap();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgv = new MW5.UI.Legacy.LayerStyleDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblX = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblY = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProjection = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.projectionMap1);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(737, 419);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 0;
            // 
            // projectionMap1
            // 
            this.projectionMap1.AllowDrop = true;
            this.projectionMap1.AnimationOnZooming = MW5.Api.Enums.AutoToggle.Auto;
            this.projectionMap1.BackgroundColor = System.Drawing.Color.White;
            this.projectionMap1.CurrentScale = 4.554085437446564D;
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
            this.projectionMap1.Size = new System.Drawing.Size(735, 395);
            this.projectionMap1.SystemCursor = MW5.Api.Enums.SystemCursor.MapDefault;
            this.projectionMap1.TabIndex = 0;
            this.projectionMap1.Tag = "";
            this.projectionMap1.TileProvider = MW5.Api.Enums.TileProvider.OpenStreetMap;
            this.projectionMap1.UdCursorHandle = -1079507232;
            this.projectionMap1.UseSeamlessPan = false;
            this.projectionMap1.ZoomBehavior = MW5.Api.Enums.ZoomBehavior.UseTileLevels;
            this.projectionMap1.ZoomBoxStyle = MW5.Api.Enums.ZoomBoxStyle.Blue;
            this.projectionMap1.ZoomPercent = 0.3D;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.ShapefileDrawingColumn = -1;
            this.dgv.Size = new System.Drawing.Size(94, 98);
            this.dgv.TabIndex = 0;
            this.dgv.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Comments";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // lblX
            // 
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 19);
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 19);
            this.lblY.Text = "Y";
            // 
            // lblProjection
            // 
            this.lblProjection.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblProjection.Name = "lblProjection";
            this.lblProjection.Size = new System.Drawing.Size(65, 19);
            this.lblProjection.Text = "projection";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(635, 427);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ProjectionResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(743, 458);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "ProjectionResultsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assigning projection: results";
            this.Load += new System.EventHandler(this.ProjectionResultsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ProjectionMap projectionMap1;
        private LayerStyleDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblX;
        private System.Windows.Forms.ToolStripStatusLabel lblY;
        private System.Windows.Forms.ToolStripStatusLabel lblProjection;
    }
}