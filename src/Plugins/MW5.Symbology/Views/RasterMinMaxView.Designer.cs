namespace MW5.Plugins.Symbology.Views
{
    partial class RasterMinMaxView
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
            this.optPrecise = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.optRange = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.optStdDev = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRangeMin = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtRangeMax = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtStdDev = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.optPrecise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optStdDev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStdDev)).BeginInit();
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
            this.btnCancel.Location = new System.Drawing.Point(320, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2000;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(229, 146);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 37;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyle = false;
            // 
            // optPrecise
            // 
            this.optPrecise.BeforeTouchSize = new System.Drawing.Size(132, 21);
            this.optPrecise.Location = new System.Drawing.Point(20, 27);
            this.optPrecise.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optPrecise.Name = "optPrecise";
            this.optPrecise.Size = new System.Drawing.Size(132, 21);
            this.optPrecise.TabIndex = 41;
            this.optPrecise.Text = "Precise calculation";
            this.optPrecise.ThemesEnabled = false;
            // 
            // optRange
            // 
            this.optRange.BeforeTouchSize = new System.Drawing.Size(150, 21);
            this.optRange.Location = new System.Drawing.Point(20, 64);
            this.optRange.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optRange.Name = "optRange";
            this.optRange.Size = new System.Drawing.Size(150, 21);
            this.optRange.TabIndex = 42;
            this.optRange.Text = "Range by frequency, %";
            this.optRange.ThemesEnabled = false;
            // 
            // optStdDev
            // 
            this.optStdDev.BeforeTouchSize = new System.Drawing.Size(132, 21);
            this.optStdDev.Location = new System.Drawing.Point(20, 101);
            this.optStdDev.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.optStdDev.Name = "optStdDev";
            this.optStdDev.Size = new System.Drawing.Size(132, 21);
            this.optStdDev.TabIndex = 43;
            this.optStdDev.Text = "Std. deviation";
            this.optStdDev.ThemesEnabled = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "to";
            // 
            // txtRangeMin
            // 
            this.txtRangeMin.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtRangeMin.BeforeTouchSize = new System.Drawing.Size(70, 20);
            this.txtRangeMin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRangeMin.DoubleValue = 2D;
            this.txtRangeMin.Location = new System.Drawing.Point(176, 65);
            this.txtRangeMin.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtRangeMin.Name = "txtRangeMin";
            this.txtRangeMin.NullString = "";
            this.txtRangeMin.Size = new System.Drawing.Size(70, 20);
            this.txtRangeMin.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtRangeMin.TabIndex = 48;
            this.txtRangeMin.Text = "2.00";
            // 
            // txtRangeMax
            // 
            this.txtRangeMax.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtRangeMax.BeforeTouchSize = new System.Drawing.Size(70, 20);
            this.txtRangeMax.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRangeMax.DoubleValue = 98D;
            this.txtRangeMax.Location = new System.Drawing.Point(299, 65);
            this.txtRangeMax.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtRangeMax.Name = "txtRangeMax";
            this.txtRangeMax.NullString = "";
            this.txtRangeMax.Size = new System.Drawing.Size(70, 20);
            this.txtRangeMax.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtRangeMax.TabIndex = 49;
            this.txtRangeMax.Text = "98.00";
            // 
            // txtStdDev
            // 
            this.txtStdDev.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtStdDev.BeforeTouchSize = new System.Drawing.Size(70, 20);
            this.txtStdDev.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStdDev.DoubleValue = 2D;
            this.txtStdDev.Location = new System.Drawing.Point(176, 101);
            this.txtStdDev.MaxValue = 5D;
            this.txtStdDev.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtStdDev.MinValue = 0D;
            this.txtStdDev.Name = "txtStdDev";
            this.txtStdDev.NullString = "";
            this.txtStdDev.Size = new System.Drawing.Size(70, 20);
            this.txtStdDev.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtStdDev.TabIndex = 50;
            this.txtStdDev.Text = "2.00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRangeMax);
            this.groupBox1.Controls.Add(this.txtStdDev);
            this.groupBox1.Controls.Add(this.optPrecise);
            this.groupBox1.Controls.Add(this.optRange);
            this.groupBox1.Controls.Add(this.txtRangeMin);
            this.groupBox1.Controls.Add(this.optStdDev);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 140);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // RasterMinMaxView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 176);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "RasterMinMaxView";
            this.Text = "Min / max values for raster";
            ((System.ComponentModel.ISupportInitialize)(this.optPrecise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optStdDev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRangeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStdDev)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv optPrecise;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv optRange;
        private Syncfusion.Windows.Forms.Tools.RadioButtonAdv optStdDev;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtRangeMin;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtRangeMax;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtStdDev;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}