using MW5.Projections.Properties;

namespace MW5.Projections.UI.Forms
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
            this.chkUseAnswerLater = new System.Windows.Forms.CheckBox();
            this.chkShowMismatchWarning = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnLayer = new Syncfusion.Windows.Forms.ButtonAdv();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(12, 15);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(319, 32);
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
            this.listBox1.Size = new System.Drawing.Size(402, 84);
            this.listBox1.TabIndex = 1;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // chkUseAnswerLater
            // 
            this.chkUseAnswerLater.AutoSize = true;
            this.chkUseAnswerLater.Checked = true;
            this.chkUseAnswerLater.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseAnswerLater.Location = new System.Drawing.Point(15, 150);
            this.chkUseAnswerLater.Name = "chkUseAnswerLater";
            this.chkUseAnswerLater.Size = new System.Drawing.Size(219, 17);
            this.chkUseAnswerLater.TabIndex = 4;
            this.chkUseAnswerLater.Text = "Do the same for other missing projections";
            this.chkUseAnswerLater.UseVisualStyleBackColor = true;
            // 
            // chkShowMismatchWarning
            // 
            this.chkShowMismatchWarning.AutoSize = true;
            this.chkShowMismatchWarning.Location = new System.Drawing.Point(15, 176);
            this.chkShowMismatchWarning.Name = "chkShowMismatchWarning";
            this.chkShowMismatchWarning.Size = new System.Drawing.Size(133, 17);
            this.chkShowMismatchWarning.TabIndex = 6;
            this.chkShowMismatchWarning.Text = "Never show this dialog";
            this.chkShowMismatchWarning.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(330, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(330, 150);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 33;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyle = false;
            this.btnOk.Click += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // btnLayer
            // 
            this.btnLayer.BeforeTouchSize = new System.Drawing.Size(63, 23);
            this.btnLayer.IsBackStageButton = false;
            this.btnLayer.Location = new System.Drawing.Point(348, 15);
            this.btnLayer.Name = "btnLayer";
            this.btnLayer.Size = new System.Drawing.Size(63, 23);
            this.btnLayer.TabIndex = 35;
            this.btnLayer.Text = "Details";
            // 
            // ProjectionMismatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(423, 218);
            this.Controls.Add(this.btnLayer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkShowMismatchWarning);
            this.Controls.Add(this.chkUseAnswerLater);
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
            this.Click += new System.EventHandler(this.listBox1_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ListBox listBox1;
        internal System.Windows.Forms.CheckBox chkUseAnswerLater;
        internal System.Windows.Forms.CheckBox chkShowMismatchWarning;
        private System.Windows.Forms.ToolTip toolTip1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.ButtonAdv btnLayer;
    }
}