namespace MW5.Plugins.Symbology.Controls
{
    partial class HistogramControl
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
            this.components = new System.ComponentModel.Container();
            this.btnCalculateHistogram = new Syncfusion.Windows.Forms.ButtonAdv();
            this.chartControl1 = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.cboBand = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.btnDefault = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.cboBand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculateHistogram
            // 
            this.btnCalculateHistogram.BeforeTouchSize = new System.Drawing.Size(71, 21);
            this.btnCalculateHistogram.IsBackStageButton = false;
            this.btnCalculateHistogram.Location = new System.Drawing.Point(239, 13);
            this.btnCalculateHistogram.Name = "btnCalculateHistogram";
            this.btnCalculateHistogram.Size = new System.Drawing.Size(71, 21);
            this.btnCalculateHistogram.TabIndex = 3;
            this.btnCalculateHistogram.Text = "Custom...";
            this.btnCalculateHistogram.Click += new System.EventHandler(this.btnCalculateHistogram_Click);
            // 
            // chartControl1
            // 
            this.chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl1.ChartArea.CursorReDraw = false;
            this.chartControl1.ChartAreaMargins = new Syncfusion.Windows.Forms.Chart.ChartMargins(0, 10, 10, 0);
            this.chartControl1.DataSourceName = "[none]";
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.ElementsSpacing = 0;
            this.chartControl1.IsWindowLess = false;
            // 
            // 
            // 
            this.chartControl1.Legend.Location = new System.Drawing.Point(402, 11);
            this.chartControl1.Legend.Visible = false;
            this.chartControl1.Localize = null;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PrimaryXAxis.Crossing = double.NaN;
            this.chartControl1.PrimaryXAxis.Margin = true;
            this.chartControl1.PrimaryXAxis.Title = "Pixel Values";
            this.chartControl1.PrimaryYAxis.Crossing = double.NaN;
            this.chartControl1.PrimaryYAxis.Margin = true;
            this.chartControl1.PrimaryYAxis.Title = "Frequencies";
            this.chartControl1.Size = new System.Drawing.Size(549, 400);
            this.chartControl1.Spacing = 80F;
            this.chartControl1.TabIndex = 2;
            // 
            // 
            // 
            this.chartControl1.Title.Name = "Default";
            // 
            // cboBand
            // 
            this.cboBand.BeforeTouchSize = new System.Drawing.Size(144, 21);
            this.cboBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboBand.Location = new System.Drawing.Point(12, 13);
            this.cboBand.Name = "cboBand";
            this.cboBand.Size = new System.Drawing.Size(144, 21);
            this.cboBand.TabIndex = 4;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel1.Controls.Add(this.btnDefault);
            this.gradientPanel1.Controls.Add(this.btnCalculateHistogram);
            this.gradientPanel1.Controls.Add(this.cboBand);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 400);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(549, 46);
            this.gradientPanel1.TabIndex = 6;
            // 
            // btnDefault
            // 
            this.btnDefault.BeforeTouchSize = new System.Drawing.Size(71, 21);
            this.btnDefault.IsBackStageButton = false;
            this.btnDefault.Location = new System.Drawing.Point(162, 13);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(71, 21);
            this.btnDefault.TabIndex = 6;
            this.btnDefault.Text = "Default";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // HistogramControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "HistogramControl";
            this.Size = new System.Drawing.Size(549, 446);
            ((System.ComponentModel.ISupportInitialize)(this.cboBand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCalculateHistogram;
        private Syncfusion.Windows.Forms.Chart.ChartControl chartControl1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboBand;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.ButtonAdv btnDefault;
    }
}
