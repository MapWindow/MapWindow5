namespace MW5.Plugins.Symbology.Controls
{
    partial class RgbBandControl
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
            this.cboRed = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboGreen = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBlue = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cboRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            // 
            // cboRed
            // 
            this.cboRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRed.BeforeTouchSize = new System.Drawing.Size(182, 21);
            this.cboRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboRed.Location = new System.Drawing.Point(63, 11);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(182, 21);
            this.cboRed.TabIndex = 1;
            // 
            // cboGreen
            // 
            this.cboGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGreen.BeforeTouchSize = new System.Drawing.Size(182, 21);
            this.cboGreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboGreen.Location = new System.Drawing.Point(63, 48);
            this.cboGreen.Name = "cboGreen";
            this.cboGreen.Size = new System.Drawing.Size(182, 21);
            this.cboGreen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Green";
            // 
            // cboBlue
            // 
            this.cboBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBlue.BeforeTouchSize = new System.Drawing.Size(182, 21);
            this.cboBlue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboBlue.Location = new System.Drawing.Point(63, 87);
            this.cboBlue.Name = "cboBlue";
            this.cboBlue.Size = new System.Drawing.Size(182, 21);
            this.cboBlue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Blue";
            // 
            // RgbBandControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboBlue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboGreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRed);
            this.Controls.Add(this.label1);
            this.Name = "RgbBandControl";
            this.Size = new System.Drawing.Size(259, 120);
            ((System.ComponentModel.ISupportInitialize)(this.cboRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboRed;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboGreen;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboBlue;
        private System.Windows.Forms.Label label3;
    }
}
