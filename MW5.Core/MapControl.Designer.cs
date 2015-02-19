namespace MW5.Core
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
            this._axMap1 = new AxMapWinGIS.AxMap();
            ((System.ComponentModel.ISupportInitialize)(this._axMap1)).BeginInit();
            this.SuspendLayout();
            // 
            // _axMap1
            // 
            this._axMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._axMap1.Enabled = true;
            this._axMap1.Location = new System.Drawing.Point(0, 0);
            this._axMap1.Name = "_axMap1";
            this._axMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_axMap1.OcxState")));
            this._axMap1.Size = new System.Drawing.Size(308, 188);
            this._axMap1.TabIndex = 0;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._axMap1);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(308, 188);
            ((System.ComponentModel.ISupportInitialize)(this._axMap1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxMapWinGIS.AxMap _axMap1;

    }
}
