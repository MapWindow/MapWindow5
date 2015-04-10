namespace MW5.Api.Map
{
    partial class MapControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapControl));
            this._map = new AxMapWinGIS.AxMap();
            ((System.ComponentModel.ISupportInitialize)(this._map)).BeginInit();
            this.SuspendLayout();
            // 
            // _map
            // 
            this._map.Dock = System.Windows.Forms.DockStyle.Fill;
            this._map.Enabled = true;
            this._map.Location = new System.Drawing.Point(0, 0);
            this._map.Name = "_map";
            this._map.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_map.OcxState")));
            this._map.Size = new System.Drawing.Size(308, 188);
            this._map.TabIndex = 0;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._map);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(308, 188);
            ((System.ComponentModel.ISupportInitialize)(this._map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected AxMapWinGIS.AxMap _map;

    }
}
