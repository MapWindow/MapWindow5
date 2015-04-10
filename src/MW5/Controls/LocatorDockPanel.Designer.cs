using MW5.Api.Enums;
using MW5.Api.Map;

namespace MW5.Controls
{
    partial class LocatorDockPanel
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
            MW5.Api.Concrete.Envelope envelope1 = new MW5.Api.Concrete.Envelope();
            MW5.Api.Concrete.SpatialReference spatialReference1 = new MW5.Api.Concrete.SpatialReference();
            this.mapControl1 = new MapControl();
            this.contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.btnUpdateFull = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisplayBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.AnimationOnZooming = AutoToggle.Auto;
            this.mapControl1.ContextMenuStrip = this.contextMenuStripEx1;
            this.mapControl1.CurrentScale = 21.133078334935735D;
            this.mapControl1.CurrentZoom = -1;
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.ExtentHistory = 20;
            this.mapControl1.ExtentPad = 0.02D;
            envelope1.Tag = "";
            this.mapControl1.Extents = envelope1;
            spatialReference1.Tag = "";
            this.mapControl1.Projection = spatialReference1;
            this.mapControl1.GrabProjectionFromData = true;
            this.mapControl1.InertiaOnPanning = AutoToggle.Auto;
            this.mapControl1.KnownExtents = KnownExtents.None;
            this.mapControl1.Latitude = 0F;
            this.mapControl1.Location = new System.Drawing.Point(0, 0);
            this.mapControl1.Longitude = 0F;
            this.mapControl1.MapCursor = MapCursor.ZoomIn;
            this.mapControl1.MapUnits = UnitsOfMeasure.Meters;
            this.mapControl1.MouseWheelSpeed = 0.5D;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.ResizeBehavior = ResizeBehavior.Classic;
            this.mapControl1.ReuseTileBuffer = true;
            this.mapControl1.ScalebarUnits = ScalebarUnits.GoogleStyle;
            this.mapControl1.ScalebarVisible = true;
            this.mapControl1.ShowCoordinates = CoordinatesDisplay.Auto;
            this.mapControl1.ShowRedrawTime = false;
            this.mapControl1.ShowVersionNumber = false;
            this.mapControl1.Size = new System.Drawing.Size(293, 301);
            this.mapControl1.SystemCursor = SystemCursor.MapDefault;
            this.mapControl1.TabIndex = 0;
            this.mapControl1.Tag = "";
            this.mapControl1.TileProvider = TileProvider.OpenStreetMap;
            this.mapControl1.UdCursorHandle = 0;
            this.mapControl1.UseSeamlessPan = false;
            this.mapControl1.ZoomBehavior = ZoomBehavior.UseTileLevels;
            this.mapControl1.ZoomPercent = 0.3D;
            // 
            // contextMenuStripEx1
            // 
            this.contextMenuStripEx1.DropShadowEnabled = false;
            this.contextMenuStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDisplayBackground,
            this.toolStripSeparator2,
            this.btnUpdateFull,
            this.btnUpdateCurrent,
            this.toolStripSeparator1,
            this.btnClear});
            this.contextMenuStripEx1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.contextMenuStripEx1.Name = "contextMenuStripEx1";
            this.contextMenuStripEx1.Size = new System.Drawing.Size(213, 126);
            this.contextMenuStripEx1.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Default;
            // 
            // btnUpdateFull
            // 
            this.btnUpdateFull.Name = "btnUpdateFull";
            this.btnUpdateFull.Size = new System.Drawing.Size(212, 22);
            this.btnUpdateFull.Text = "Update using full extents";
            // 
            // btnUpdateCurrent
            // 
            this.btnUpdateCurrent.Name = "btnUpdateCurrent";
            this.btnUpdateCurrent.Size = new System.Drawing.Size(212, 22);
            this.btnUpdateCurrent.Text = "Update using current view";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(209, 6);
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(212, 22);
            this.btnClear.Text = "Clear";
            // 
            // btnDisplayBackground
            // 
            this.btnDisplayBackground.Name = "btnDisplayBackground";
            this.btnDisplayBackground.Size = new System.Drawing.Size(212, 22);
            this.btnDisplayBackground.Text = "Background visible";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // PreviewDockPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mapControl1);
            this.Name = "LocatorDockPanel";
            this.Size = new System.Drawing.Size(293, 301);
            this.contextMenuStripEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MapControl mapControl1;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStripEx1;
        private System.Windows.Forms.ToolStripMenuItem btnUpdateFull;
        private System.Windows.Forms.ToolStripMenuItem btnUpdateCurrent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private System.Windows.Forms.ToolStripMenuItem btnDisplayBackground;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
