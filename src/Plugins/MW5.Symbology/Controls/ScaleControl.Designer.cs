namespace MW5.Plugins.Symbology.Controls
{
    partial class ScaleControl
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
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.btnSetMin = new System.Windows.Forms.Button();
            this.btnSetMax = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtMaxScale = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMinScale = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(124, 337);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(125, 17);
            this.chkEnabled.TabIndex = 180;
            this.chkEnabled.Text = "Use dynamic visibility";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // btnSetMin
            // 
            this.btnSetMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetMin.Location = new System.Drawing.Point(5, 130);
            this.btnSetMin.Name = "btnSetMin";
            this.btnSetMin.Size = new System.Drawing.Size(109, 21);
            this.btnSetMin.TabIndex = 179;
            this.btnSetMin.Text = "Set current";
            this.btnSetMin.UseVisualStyleBackColor = true;
            this.btnSetMin.Click += new System.EventHandler(this.btnSetMin_Click);
            // 
            // btnSetMax
            // 
            this.btnSetMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetMax.Location = new System.Drawing.Point(6, 51);
            this.btnSetMax.Name = "btnSetMax";
            this.btnSetMax.Size = new System.Drawing.Size(109, 21);
            this.btnSetMax.TabIndex = 178;
            this.btnSetMax.Text = "Set current";
            this.btnSetMax.UseVisualStyleBackColor = true;
            this.btnSetMax.Click += new System.EventHandler(this.btnSetMax_Click);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(4, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 13);
            this.label23.TabIndex = 177;
            this.label23.Text = "1:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 107);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 13);
            this.label21.TabIndex = 176;
            this.label21.Text = "1:";
            // 
            // txtMaxScale
            // 
            this.txtMaxScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxScale.Location = new System.Drawing.Point(26, 26);
            this.txtMaxScale.Name = "txtMaxScale";
            this.txtMaxScale.Size = new System.Drawing.Size(89, 20);
            this.txtMaxScale.TabIndex = 175;
            this.txtMaxScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxScale.Validated += new System.EventHandler(this.txtMaxScale_Validated);
            this.txtMaxScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxScale_KeyPress);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 13);
            this.label16.TabIndex = 174;
            this.label16.Text = "Maximum visible  scale";
            // 
            // txtMinScale
            // 
            this.txtMinScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMinScale.Location = new System.Drawing.Point(24, 104);
            this.txtMinScale.Name = "txtMinScale";
            this.txtMinScale.Size = new System.Drawing.Size(90, 20);
            this.txtMinScale.TabIndex = 173;
            this.txtMinScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinScale.Validated += new System.EventHandler(this.txtMinScale_Validated);
            this.txtMinScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinScale_KeyPress);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 13);
            this.label12.TabIndex = 172;
            this.label12.Text = "Minimum visible  scale";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSetMin);
            this.panel1.Controls.Add(this.txtMinScale);
            this.panel1.Controls.Add(this.btnSetMax);
            this.panel1.Controls.Add(this.txtMaxScale);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(124, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 159);
            this.panel1.TabIndex = 181;
            // 
            // ScaleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkEnabled);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(250, 1000);
            this.MinimumSize = new System.Drawing.Size(250, 0);
            this.Name = "ScaleControl";
            this.Size = new System.Drawing.Size(250, 368);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button btnSetMin;
        private System.Windows.Forms.Button btnSetMax;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtMaxScale;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMinScale;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;

    }
}
