namespace MW5.Views
{
    partial class SetScaleView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.cboScale = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkSnap = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboScale)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(260, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(164, 137);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 26);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current map scale, 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "New map scale, 1:";
            // 
            // txtScale
            // 
            this.txtScale.Enabled = false;
            this.txtScale.Location = new System.Drawing.Point(152, 26);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(193, 20);
            this.txtScale.TabIndex = 11;
            // 
            // cboScale
            // 
            this.cboScale.BeforeTouchSize = new System.Drawing.Size(193, 21);
            this.cboScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboScale.Location = new System.Drawing.Point(152, 69);
            this.cboScale.Name = "cboScale";
            this.cboScale.Size = new System.Drawing.Size(193, 21);
            this.cboScale.TabIndex = 0;
            // 
            // chkSnap
            // 
            this.chkSnap.AutoSize = true;
            this.chkSnap.Location = new System.Drawing.Point(152, 105);
            this.chkSnap.Name = "chkSnap";
            this.chkSnap.Size = new System.Drawing.Size(121, 17);
            this.chkSnap.TabIndex = 12;
            this.chkSnap.Text = "Snap to zoom levels";
            this.chkSnap.UseVisualStyleBackColor = true;
            // 
            // SetScaleView
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(363, 175);
            this.Controls.Add(this.chkSnap);
            this.Controls.Add(this.cboScale);
            this.Controls.Add(this.txtScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "SetScaleView";
            this.Text = "Set Map Scale";
            ((System.ComponentModel.ISupportInitialize)(this.cboScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtScale;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboScale;
        private System.Windows.Forms.CheckBox chkSnap;

    }
}