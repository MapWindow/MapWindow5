namespace MW5.Views
{
    partial class SpatialIndexView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNo = new Syncfusion.Windows.Forms.ButtonAdv();
            this.chkDontShow = new System.Windows.Forms.CheckBox();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnYes = new Syncfusion.Windows.Forms.ButtonAdv();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "No spatial index was found for the shapefile. Do you want to create it?";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 34);
            this.label2.TabIndex = 10;
            this.label2.Text = "Spatial index can increase rendering speed and selection performance for large sh" +
    "apefiles. It is stored in external mwd / mwx files.";
            // 
            // btnNo
            // 
            this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNo.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2000;
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnNo.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnNo.IsBackStageButton = false;
            this.btnNo.Location = new System.Drawing.Point(201, 145);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(85, 26);
            this.btnNo.TabIndex = 54;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyle = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // chkDontShow
            // 
            this.chkDontShow.AutoSize = true;
            this.chkDontShow.Location = new System.Drawing.Point(28, 109);
            this.chkDontShow.Name = "chkDontShow";
            this.chkDontShow.Size = new System.Drawing.Size(251, 17);
            this.chkDontShow.TabIndex = 53;
            this.chkDontShow.Text = "Use the choice and don\'t show the dialog again";
            this.chkDontShow.UseVisualStyleBackColor = true;
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
            this.btnCancel.Location = new System.Drawing.Point(292, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 52;
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
            this.btnYes.Location = new System.Drawing.Point(110, 145);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(85, 26);
            this.btnYes.TabIndex = 51;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyle = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // SpatialIndexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 183);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.chkDontShow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SpatialIndexView";
            this.Text = "Spatial Index";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.ButtonAdv btnNo;
        private System.Windows.Forms.CheckBox chkDontShow;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnYes;
    }
}