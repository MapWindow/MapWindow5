using MW5.Projections.Properties;

namespace MW5.Projections.Forms
{
    partial class ProjectionMismatchForm
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkUseAnswerLater = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chkShowMismatchWarning = new System.Windows.Forms.CheckBox();
            this.btnLayer = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(49, 15);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(241, 32);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Layer projection is different from project one. Choose the way how to handle it:";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Ignore",
            "Reproject in new file",
            "Reproject inplace",
            "Skip file"});
            this.listBox1.Location = new System.Drawing.Point(9, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(350, 84);
            this.listBox1.TabIndex = 1;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(265, 144);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 26);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 176);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkUseAnswerLater
            // 
            this.chkUseAnswerLater.AutoSize = true;
            this.chkUseAnswerLater.Checked = true;
            this.chkUseAnswerLater.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseAnswerLater.Location = new System.Drawing.Point(19, 150);
            this.chkUseAnswerLater.Name = "chkUseAnswerLater";
            this.chkUseAnswerLater.Size = new System.Drawing.Size(175, 17);
            this.chkUseAnswerLater.TabIndex = 4;
            //this.chkUseAnswerLater.Text = "Use this answer for the rest files";
            this.chkUseAnswerLater.Text = "Do the same for other missing projections";
            this.chkUseAnswerLater.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = Resources.img_projection_mismatch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // chkShowMismatchWarning
            // 
            this.chkShowMismatchWarning.AutoSize = true;
            this.chkShowMismatchWarning.Location = new System.Drawing.Point(19, 176);
            this.chkShowMismatchWarning.Name = "chkShowMismatchWarning";
            this.chkShowMismatchWarning.Size = new System.Drawing.Size(133, 17);
            this.chkShowMismatchWarning.TabIndex = 6;
            this.chkShowMismatchWarning.Text = "Never show this dialog";
            this.chkShowMismatchWarning.UseVisualStyleBackColor = true;
            // 
            // btnLayer
            // 
            this.btnLayer.Location = new System.Drawing.Point(296, 19);
            this.btnLayer.Name = "btnLayer";
            this.btnLayer.Size = new System.Drawing.Size(63, 26);
            this.btnLayer.TabIndex = 10;
            this.btnLayer.Text = "Details...";
            this.toolTip1.SetToolTip(this.btnLayer, "See definition");
            this.btnLayer.UseVisualStyleBackColor = true;
            // 
            // frmProjectionMismatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(367, 212);
            this.Controls.Add(this.btnLayer);
            this.Controls.Add(this.chkShowMismatchWarning);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkUseAnswerLater);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectionMismatchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projection mismatch";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ListBox listBox1;
        internal System.Windows.Forms.CheckBox chkUseAnswerLater;
        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.CheckBox chkShowMismatchWarning;
        private System.Windows.Forms.Button btnLayer;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}