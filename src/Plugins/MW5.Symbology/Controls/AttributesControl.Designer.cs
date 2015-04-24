namespace MW5.Plugins.Symbology.Controls
{
    partial class AttributesControl
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
            this.attributeGrid1 = new MW5.Plugins.Symbology.Controls.AttributeGrid();
            this.SuspendLayout();
            // 
            // attributeGrid1
            // 
            this.attributeGrid1.AutoAdjustRowHeights = false;
            this.attributeGrid1.DataSource = null;
            this.attributeGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributeGrid1.HotTracking = false;
            this.attributeGrid1.HotTrackingColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.attributeGrid1.Location = new System.Drawing.Point(0, 0);
            this.attributeGrid1.Name = "attributeGrid1";
            this.attributeGrid1.ReadOnly = false;
            this.attributeGrid1.ShowEditors = true;
            this.attributeGrid1.ShowSuperTooltips = false;
            this.attributeGrid1.Size = new System.Drawing.Size(448, 357);
            this.attributeGrid1.TabIndex = 0;
            this.attributeGrid1.ToolTipDuration = 3000;
            this.attributeGrid1.ToolTipMaxWidth = 450;
            this.attributeGrid1.WrapText = true;
            // 
            // AttributesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.attributeGrid1);
            this.Name = "AttributesControl";
            this.Size = new System.Drawing.Size(448, 357);
            this.ResumeLayout(false);

        }

        #endregion

        private AttributeGrid attributeGrid1;
    }
}
