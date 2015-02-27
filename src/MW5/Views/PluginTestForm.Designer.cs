using MW5.Api;
using MW5.Api.Concrete;

namespace MW5.Views
{
    partial class PluginTestForm
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
            Envelope envelope1 = new Envelope();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this._mapControl1 = new MapControl();
            this.btnLoadPlugins = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlugins});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuPlugins
            // 
            this.mnuPlugins.Name = "mnuPlugins";
            this.mnuPlugins.Size = new System.Drawing.Size(58, 20);
            this.mnuPlugins.Text = "Plugins";
            // 
            // _mapControl1
            // 
            this._mapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mapControl1.AnimationOnZooming = AutoToggle.Auto;
            this._mapControl1.CurrentScale = 11.984013674579206D;
            this._mapControl1.CurrentZoom = -1;
            this._mapControl1.ExtentHistory = 20;
            this._mapControl1.ExtentPad = 0.02D;
            envelope1.Tag = "";
            this._mapControl1.Extents = envelope1;
            this._mapControl1.GrabProjectionFromData = true;
            this._mapControl1.InertiaOnPanning = AutoToggle.Auto;
            this._mapControl1.KnownExtents = KnownExtents.None;
            this._mapControl1.Latitude = 0F;
            this._mapControl1.Location = new System.Drawing.Point(22, 38);
            this._mapControl1.Longitude = 0F;
            this._mapControl1.MapCursor = MapCursor.ZoomIn;
            this._mapControl1.MapUnits = UnitsOfMeasure.Meters;
            this._mapControl1.MouseWheelSpeed = 0.5D;
            this._mapControl1.Name = "_mapControl1";
            this._mapControl1.Projection = MapProjection.None;
            this._mapControl1.ResizeBehavior = ResizeBehavior.Classic;
            this._mapControl1.ReuseTileBuffer = true;
            this._mapControl1.ScalebarUnits = ScalebarUnits.GoogleStyle;
            this._mapControl1.ScalebarVisible = true;
            this._mapControl1.ShowCoordinates = CoordinatesDisplay.Auto;
            this._mapControl1.ShowRedrawTime = false;
            this._mapControl1.ShowVersionNumber = false;
            this._mapControl1.Size = new System.Drawing.Size(547, 375);
            this._mapControl1.SystemCursor = SystemCursor.MapDefault;
            this._mapControl1.TabIndex = 1;
            this._mapControl1.Tag = "";
            this._mapControl1.TileProvider = TileProvider.OpenStreetMap;
            this._mapControl1.UdCursorHandle = -1079507232;
            this._mapControl1.UseSeamlessPan = false;
            this._mapControl1.ZoomBehavior = ZoomBehavior.UseTileLevels;
            this._mapControl1.ZoomPercent = 0.3D;
            // 
            // btnLoadPlugins
            // 
            this.btnLoadPlugins.Location = new System.Drawing.Point(477, 419);
            this.btnLoadPlugins.Name = "btnLoadPlugins";
            this.btnLoadPlugins.Size = new System.Drawing.Size(92, 31);
            this.btnLoadPlugins.TabIndex = 2;
            this.btnLoadPlugins.Text = "Load plugins";
            this.btnLoadPlugins.UseVisualStyleBackColor = true;
            // 
            // PluginTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 462);
            this.Controls.Add(this.btnLoadPlugins);
            this.Controls.Add(this._mapControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PluginTestForm";
            this.Text = "TestPlugins";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuPlugins;
        private MapControl _mapControl1;
        private System.Windows.Forms.Button btnLoadPlugins;
    }
}

