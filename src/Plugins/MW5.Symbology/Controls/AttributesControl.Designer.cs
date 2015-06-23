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
            this.chkVisibility = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.attributeGrid1 = new MW5.Plugins.Symbology.Controls.AttributeGrid();
            ((System.ComponentModel.ISupportInitialize)(this.attributeGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkVisibility
            // 
            this.chkVisibility.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVisibility.AutoSize = true;
            this.chkVisibility.Location = new System.Drawing.Point(6, 361);
            this.chkVisibility.Name = "chkVisibility";
            this.chkVisibility.Size = new System.Drawing.Size(105, 17);
            this.chkVisibility.TabIndex = 41;
            this.chkVisibility.Text = "Check all / none";
            this.chkVisibility.UseVisualStyleBackColor = true;
            this.chkVisibility.CheckedChanged += new System.EventHandler(this.OnVisibilityCheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 35);
            this.label1.TabIndex = 42;
            this.label1.Text = "Note: please use table editor to add, remove and modify fields. Only alias and vi" +
    "sibility can be changed here.";
            // 
            // attributeGrid1
            // 
            this.attributeGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attributeGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.attributeGrid1.FreezeCaption = false;
            this.attributeGrid1.Location = new System.Drawing.Point(4, 46);
            this.attributeGrid1.Name = "attributeGrid1";
            this.attributeGrid1.Size = new System.Drawing.Size(448, 305);
            this.attributeGrid1.TabIndex = 0;
            this.attributeGrid1.WrapWithPanel = true;
            // 
            // AttributesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkVisibility);
            this.Controls.Add(this.attributeGrid1);
            this.Name = "AttributesControl";
            this.Size = new System.Drawing.Size(455, 383);
            ((System.ComponentModel.ISupportInitialize)(this.attributeGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AttributeGrid attributeGrid1;
        private System.Windows.Forms.CheckBox chkVisibility;
        private System.Windows.Forms.Label label1;
    }
}
