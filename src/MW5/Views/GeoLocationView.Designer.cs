using Syncfusion.Windows.Forms.Tools;

namespace MW5.Views
{
    partial class GeoLocationView
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
            this.lblLicense = new System.Windows.Forms.Label();
            this.cboKnownExtents = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.txtFindLocation = new System.Windows.Forms.TextBox();
            this.optFindLocation = new System.Windows.Forms.RadioButton();
            this.optKnownExtents = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboKnownExtents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(283, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(187, 181);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 26);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Find";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblLicense
            // 
            this.lblLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLicense.Location = new System.Drawing.Point(28, 74);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(329, 19);
            this.lblLicense.TabIndex = 13;
            this.lblLicense.Text = "Data © OpenStreetMap contributors, ODbL 1.0.";
            this.lblLicense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboKnownExtents
            // 
            this.cboKnownExtents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKnownExtents.BeforeTouchSize = new System.Drawing.Size(329, 21);
            this.cboKnownExtents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKnownExtents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboKnownExtents.Location = new System.Drawing.Point(28, 131);
            this.cboKnownExtents.Name = "cboKnownExtents";
            this.cboKnownExtents.Size = new System.Drawing.Size(329, 21);
            this.cboKnownExtents.TabIndex = 1;
            // 
            // txtFindLocation
            // 
            this.txtFindLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFindLocation.Location = new System.Drawing.Point(28, 51);
            this.txtFindLocation.Name = "txtFindLocation";
            this.txtFindLocation.Size = new System.Drawing.Size(329, 20);
            this.txtFindLocation.TabIndex = 0;
            // 
            // optFindLocation
            // 
            this.optFindLocation.AutoSize = true;
            this.optFindLocation.Checked = true;
            this.optFindLocation.Location = new System.Drawing.Point(28, 28);
            this.optFindLocation.Name = "optFindLocation";
            this.optFindLocation.Size = new System.Drawing.Size(229, 17);
            this.optFindLocation.TabIndex = 2;
            this.optFindLocation.TabStop = true;
            this.optFindLocation.Text = "Find location (e.g. Boston, Spain, Nile, etc.)";
            this.optFindLocation.UseVisualStyleBackColor = true;
            // 
            // optKnownExtents
            // 
            this.optKnownExtents.AutoSize = true;
            this.optKnownExtents.Location = new System.Drawing.Point(28, 108);
            this.optKnownExtents.Name = "optKnownExtents";
            this.optKnownExtents.Size = new System.Drawing.Size(147, 17);
            this.optKnownExtents.TabIndex = 3;
            this.optKnownExtents.Text = "Known extents (countries)";
            this.optKnownExtents.UseVisualStyleBackColor = true;
            // 
            // GeoLocationView
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(380, 214);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.cboKnownExtents);
            this.Controls.Add(this.txtFindLocation);
            this.Controls.Add(this.optFindLocation);
            this.Controls.Add(this.optKnownExtents);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "GeoLocationView";
            this.Text = "Find Location";
            ((System.ComponentModel.ISupportInitialize)(this.cboKnownExtents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.Label lblLicense;
        private ComboBoxAdv cboKnownExtents;
        private System.Windows.Forms.TextBox txtFindLocation;
        private System.Windows.Forms.RadioButton optFindLocation;
        private System.Windows.Forms.RadioButton optKnownExtents;
    }
}