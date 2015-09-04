namespace MW5.Tools.Views.Custom
{
    partial class RandomPointsView
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
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRun = new Syncfusion.Windows.Forms.ButtonAdv();
            this.cboLayers = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumPoints = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)(this.cboLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutputName)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(365, 212);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            // 
            // btnRun
            // 
            this.btnRun.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnRun.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.IsBackStageButton = false;
            this.btnRun.Location = new System.Drawing.Point(274, 212);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 26);
            this.btnRun.TabIndex = 35;
            this.btnRun.Text = "Run";
            // 
            // cboLayers
            // 
            this.cboLayers.BeforeTouchSize = new System.Drawing.Size(387, 21);
            this.cboLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboLayers.Location = new System.Drawing.Point(37, 43);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.Size = new System.Drawing.Size(387, 21);
            this.cboLayers.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Layer for bounding box";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Number of points";
            // 
            // txtNumPoints
            // 
            this.txtNumPoints.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtNumPoints.BeforeTouchSize = new System.Drawing.Size(387, 20);
            this.txtNumPoints.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumPoints.IntegerValue = ((long)(500));
            this.txtNumPoints.Location = new System.Drawing.Point(37, 108);
            this.txtNumPoints.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtNumPoints.Name = "txtNumPoints";
            this.txtNumPoints.NullString = "";
            this.txtNumPoints.Size = new System.Drawing.Size(387, 20);
            this.txtNumPoints.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtNumPoints.TabIndex = 40;
            this.txtNumPoints.Text = "500";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Output";
            // 
            // txtOutputName
            // 
            this.txtOutputName.BeforeTouchSize = new System.Drawing.Size(387, 20);
            this.txtOutputName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOutputName.Location = new System.Drawing.Point(37, 166);
            this.txtOutputName.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtOutputName.Name = "txtOutputName";
            this.txtOutputName.Size = new System.Drawing.Size(387, 20);
            this.txtOutputName.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtOutputName.TabIndex = 43;
            this.txtOutputName.Text = "random points";
            // 
            // RandomPointsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 250);
            this.Controls.Add(this.txtOutputName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLayers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Name = "RandomPointsView";
            this.Text = "Random Points";
            ((System.ComponentModel.ISupportInitialize)(this.cboLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutputName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnRun;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboLayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox txtNumPoints;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtOutputName;
    }
}