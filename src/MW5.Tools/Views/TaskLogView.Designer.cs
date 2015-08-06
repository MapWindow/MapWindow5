using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Views
{
    partial class TaskLogView
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
            this.panelLog = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxExt1 = new System.Windows.Forms.TextBox();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.panelProgress = new System.Windows.Forms.GroupBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.btnPause = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelResults = new System.Windows.Forms.Panel();
            this.lblExecutionTime = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.panelLog.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.panelResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLog
            // 
            this.panelLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLog.Controls.Add(this.groupBox1);
            this.panelLog.Controls.Add(this.panelSeparator);
            this.panelLog.Controls.Add(this.panelProgress);
            this.panelLog.Controls.Add(this.panelResults);
            this.panelLog.Location = new System.Drawing.Point(12, 12);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(495, 243);
            this.panelLog.TabIndex = 43;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxExt1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log messages";
            // 
            // textBoxExt1
            // 
            this.textBoxExt1.BackColor = System.Drawing.Color.White;
            this.textBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxExt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxExt1.Location = new System.Drawing.Point(3, 16);
            this.textBoxExt1.Multiline = true;
            this.textBoxExt1.Name = "textBoxExt1";
            this.textBoxExt1.ReadOnly = true;
            this.textBoxExt1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxExt1.Size = new System.Drawing.Size(489, 82);
            this.textBoxExt1.TabIndex = 1;
            // 
            // panelSeparator
            // 
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Location = new System.Drawing.Point(0, 131);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(495, 11);
            this.panelSeparator.TabIndex = 4;
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.lblPercent);
            this.panelProgress.Controls.Add(this.lblElapsed);
            this.panelProgress.Controls.Add(this.btnPause);
            this.panelProgress.Controls.Add(this.btnCancel);
            this.panelProgress.Controls.Add(this.progressBar1);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProgress.Location = new System.Drawing.Point(0, 47);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(495, 84);
            this.panelProgress.TabIndex = 3;
            this.panelProgress.TabStop = false;
            this.panelProgress.Text = "Tool is running";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(13, 56);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(77, 13);
            this.lblPercent.TabIndex = 45;
            this.lblPercent.Text = "Completed: 0%";
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Location = new System.Drawing.Point(115, 56);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(87, 13);
            this.lblElapsed.TabIndex = 44;
            this.lblElapsed.Text = "Elapsed: 0:00:00";
            // 
            // btnPause
            // 
            this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPause.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnPause.BeforeTouchSize = new System.Drawing.Size(82, 26);
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.IsBackStageButton = false;
            this.btnPause.Location = new System.Drawing.Point(306, 48);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(82, 26);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(82, 26);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(394, 48);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(16, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(460, 14);
            this.progressBar1.TabIndex = 2;
            // 
            // panelResults
            // 
            this.panelResults.Controls.Add(this.lblExecutionTime);
            this.panelResults.Controls.Add(this.lblStatus);
            this.panelResults.Controls.Add(this.pictureBox1);
            this.panelResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResults.Location = new System.Drawing.Point(0, 0);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(495, 47);
            this.panelResults.TabIndex = 2;
            this.panelResults.Visible = false;
            // 
            // lblExecutionTime
            // 
            this.lblExecutionTime.AutoSize = true;
            this.lblExecutionTime.Location = new System.Drawing.Point(41, 25);
            this.lblExecutionTime.Name = "lblExecutionTime";
            this.lblExecutionTime.Size = new System.Drawing.Size(79, 13);
            this.lblExecutionTime.TabIndex = 45;
            this.lblExecutionTime.Text = "Execution time:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(41, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(249, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Tool execution has finished successfully.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(422, 261);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            // 
            // TaskLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(519, 298);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelLog);
            this.Name = "TaskLogView";
            this.Text = "Task status";
            this.panelLog.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.panelResults.ResumeLayout(false);
            this.panelResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.ProgressBar progressBar1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblExecutionTime;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.GroupBox panelProgress;
        private GroupBox groupBox1;
        private TextBox textBoxExt1;
        private Syncfusion.Windows.Forms.ButtonAdv btnPause;
        private Label lblPercent;
        private Label lblElapsed;
    }
}