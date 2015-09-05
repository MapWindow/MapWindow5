namespace MW5.Tools.Views.Custom
{
    partial class LongExecutionView
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSecondsPerStep = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBackground = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecondsPerStep)).BeginInit();
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
            this.btnClose.Location = new System.Drawing.Point(365, 145);
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
            this.btnRun.Location = new System.Drawing.Point(274, 145);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 26);
            this.btnRun.TabIndex = 35;
            this.btnRun.Text = "Run";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Seconds per step";
            // 
            // txtSecondsPerStep
            // 
            this.txtSecondsPerStep.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtSecondsPerStep.BeforeTouchSize = new System.Drawing.Size(418, 20);
            this.txtSecondsPerStep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSecondsPerStep.DoubleValue = 0.2D;
            this.txtSecondsPerStep.Location = new System.Drawing.Point(32, 43);
            this.txtSecondsPerStep.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtSecondsPerStep.Name = "txtSecondsPerStep";
            this.txtSecondsPerStep.NullString = "";
            this.txtSecondsPerStep.Size = new System.Drawing.Size(418, 20);
            this.txtSecondsPerStep.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtSecondsPerStep.TabIndex = 40;
            this.txtSecondsPerStep.Text = "0.20";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 104);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(418, 15);
            this.progressBar1.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Progress";
            // 
            // chkBackground
            // 
            this.chkBackground.AutoSize = true;
            this.chkBackground.Location = new System.Drawing.Point(32, 150);
            this.chkBackground.Name = "chkBackground";
            this.chkBackground.Size = new System.Drawing.Size(135, 17);
            this.chkBackground.TabIndex = 43;
            this.chkBackground.Text = "Run in the background";
            this.chkBackground.UseVisualStyleBackColor = true;
            // 
            // LongExecutionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 188);
            this.Controls.Add(this.chkBackground);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtSecondsPerStep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Name = "LongExecutionView";
            this.Text = "Long execution";
            ((System.ComponentModel.ISupportInitialize)(this.txtSecondsPerStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnRun;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtSecondsPerStep;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBackground;
    }
}