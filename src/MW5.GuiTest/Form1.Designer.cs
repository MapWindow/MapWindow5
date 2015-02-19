using MW5.Core;
using MW5.Core.Concrete;

namespace MW5.GuiTest
{
    partial class Form1
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
            Envelope envelope17 = new Envelope();
            this.mapControl1 = new MapControl();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.CurrentScale = 13.608773521178394D;
            this.mapControl1.CurrentZoom = -1;
            this.mapControl1.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.mapControl1.Extents = envelope17;
            this.mapControl1.KnownExtents = KnownExtents.None;
            this.mapControl1.Latitude = 0F;
            this.mapControl1.Location = new System.Drawing.Point(12, 12);
            this.mapControl1.Longitude = 0F;
            this.mapControl1.MapCursor = MapCursor.ZoomIn;
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.PROJECTION = MapProjection.None;
            this.mapControl1.ScalebarUnits = ScalebarUnits.GoogleStyle;
            this.mapControl1.ScalebarVisible = true;
            this.mapControl1.Size = new System.Drawing.Size(455, 323);
            this.mapControl1.SystemCursor = SystemCursor.MapDefault;
            this.mapControl1.TabIndex = 0;
            this.mapControl1.TileProvider = TileProvider.OpenStreetMap;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(488, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(488, 41);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 369);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.mapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MapControl mapControl1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;


    }
}