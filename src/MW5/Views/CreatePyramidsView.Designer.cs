namespace MW5.Views
{
    partial class CreatePyramidsView
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
            this.btnYes = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.cboInterpolation = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboCompression = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDontShow = new System.Windows.Forms.CheckBox();
            this.btnNo = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.cboInterpolation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompression)).BeginInit();
            this.SuspendLayout();
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
            this.btnCancel.Location = new System.Drawing.Point(298, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2000;
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnYes.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnYes.IsBackStageButton = false;
            this.btnYes.Location = new System.Drawing.Point(116, 227);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(85, 26);
            this.btnYes.TabIndex = 41;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyle = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "No pyramids were found for this datasource. Do you want to build them?";
            // 
            // cboInterpolation
            // 
            this.cboInterpolation.BeforeTouchSize = new System.Drawing.Size(290, 21);
            this.cboInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInterpolation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboInterpolation.Location = new System.Drawing.Point(93, 52);
            this.cboInterpolation.Name = "cboInterpolation";
            this.cboInterpolation.Size = new System.Drawing.Size(290, 21);
            this.cboInterpolation.TabIndex = 44;
            // 
            // cboCompression
            // 
            this.cboCompression.BeforeTouchSize = new System.Drawing.Size(288, 21);
            this.cboCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboCompression.Location = new System.Drawing.Point(95, 96);
            this.cboCompression.Name = "cboCompression";
            this.cboCompression.Size = new System.Drawing.Size(288, 21);
            this.cboCompression.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Interpolation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Compression";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(22, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(361, 46);
            this.label4.TabIndex = 48;
            this.label4.Text = "Pyramids represent a smaller versions of the original image that are used to spee" +
    "d up the rendering. Pyramids are usually stored in external .ovr file (GTiff for" +
    "mat).";
            // 
            // chkDontShow
            // 
            this.chkDontShow.AutoSize = true;
            this.chkDontShow.Location = new System.Drawing.Point(25, 193);
            this.chkDontShow.Name = "chkDontShow";
            this.chkDontShow.Size = new System.Drawing.Size(251, 17);
            this.chkDontShow.TabIndex = 49;
            this.chkDontShow.Text = "Use the choice and don\'t show the dialog again";
            this.chkDontShow.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2000;
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnNo.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnNo.IsBackStageButton = false;
            this.btnNo.Location = new System.Drawing.Point(207, 227);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(85, 26);
            this.btnNo.TabIndex = 50;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyle = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // CreatePyramidsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 265);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.chkDontShow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboCompression);
            this.Controls.Add(this.cboInterpolation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Name = "CreatePyramidsView";
            this.Text = "Create pyramids";
            ((System.ComponentModel.ISupportInitialize)(this.cboInterpolation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompression)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnYes;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboInterpolation;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboCompression;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDontShow;
        private Syncfusion.Windows.Forms.ButtonAdv btnNo;
    }
}