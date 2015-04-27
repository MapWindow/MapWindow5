namespace MW5.Plugins.Symbology.Views
{
    partial class HistogramOptionsView
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.udNumberBuckets = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMax = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMin = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.udNumberBuckets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(173, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2000;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(82, 151);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 39;
            this.btnOk.Text = "Calculate";
            this.btnOk.UseVisualStyle = false;
            // 
            // udNumberBuckets
            // 
            this.udNumberBuckets.BeforeTouchSize = new System.Drawing.Size(65, 20);
            this.udNumberBuckets.Location = new System.Drawing.Point(159, 94);
            this.udNumberBuckets.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.udNumberBuckets.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.udNumberBuckets.Name = "udNumberBuckets";
            this.udNumberBuckets.Size = new System.Drawing.Size(65, 20);
            this.udNumberBuckets.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Number of buckets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Maximum";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Minimum";
            // 
            // txtMax
            // 
            this.txtMax.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMax.BeforeTouchSize = new System.Drawing.Size(62, 20);
            this.txtMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMax.DoubleValue = 1D;
            this.txtMax.Location = new System.Drawing.Point(159, 57);
            this.txtMax.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMax.Name = "txtMax";
            this.txtMax.NullString = "";
            this.txtMax.Size = new System.Drawing.Size(62, 20);
            this.txtMax.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMax.TabIndex = 42;
            this.txtMax.Text = "1.00";
            // 
            // txtMin
            // 
            this.txtMin.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMin.BeforeTouchSize = new System.Drawing.Size(62, 20);
            this.txtMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMin.DoubleValue = 1D;
            this.txtMin.Location = new System.Drawing.Point(159, 19);
            this.txtMin.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMin.Name = "txtMin";
            this.txtMin.NullString = "";
            this.txtMin.Size = new System.Drawing.Size(62, 20);
            this.txtMin.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMin.TabIndex = 41;
            this.txtMin.Text = "1.00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.udNumberBuckets);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMax);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 133);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // HistogramOptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(269, 185);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "HistogramOptionsView";
            this.Text = "Histogram calculation";
            ((System.ComponentModel.ISupportInitialize)(this.udNumberBuckets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt udNumberBuckets;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMax;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMin;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}