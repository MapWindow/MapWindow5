namespace MW5.Plugins.IdentifierTestPlugin
{
    partial class IdentifierControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._cboIdentifierMode = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this._cboIdentifierMode)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "This is UI for identifier control";
            // 
            // _cboIdentifierMode
            // 
            this._cboIdentifierMode.BeforeTouchSize = new System.Drawing.Size(208, 21);
            this._cboIdentifierMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboIdentifierMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cboIdentifierMode.Location = new System.Drawing.Point(23, 195);
            this._cboIdentifierMode.Name = "_cboIdentifierMode";
            this._cboIdentifierMode.Size = new System.Drawing.Size(208, 21);
            this._cboIdentifierMode.TabIndex = 1;
            // 
            // IdentifierControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._cboIdentifierMode);
            this.Controls.Add(this.label1);
            this.Name = "IdentifierControl";
            this.Size = new System.Drawing.Size(268, 244);
            ((System.ComponentModel.ISupportInitialize)(this._cboIdentifierMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv _cboIdentifierMode;

    }
}
