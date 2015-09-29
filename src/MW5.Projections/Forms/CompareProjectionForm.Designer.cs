using Syncfusion.Windows.Forms;

namespace MW5.Projections.Forms
{
    partial class CompareProjectionForm
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
            this.lblLayer = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.txtLayer = new System.Windows.Forms.TextBox();
            this.btnLayer = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnProject = new Syncfusion.Windows.Forms.ButtonAdv();
            this.chkWkt = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblLayer
            // 
            this.lblLayer.Location = new System.Drawing.Point(8, 143);
            this.lblLayer.Name = "lblLayer";
            this.lblLayer.Size = new System.Drawing.Size(349, 18);
            this.lblLayer.TabIndex = 14;
            this.lblLayer.Text = "Layer:";
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(8, 16);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(349, 18);
            this.lblProject.TabIndex = 13;
            this.lblProject.Text = "Project:";
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(10, 41);
            this.txtProject.Multiline = true;
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(442, 77);
            this.txtProject.TabIndex = 18;
            // 
            // txtLayer
            // 
            this.txtLayer.Location = new System.Drawing.Point(11, 168);
            this.txtLayer.Multiline = true;
            this.txtLayer.Name = "txtLayer";
            this.txtLayer.Size = new System.Drawing.Size(442, 77);
            this.txtLayer.TabIndex = 19;
            // 
            // btnLayer
            // 
            this.btnLayer.BeforeTouchSize = new System.Drawing.Size(66, 23);
            this.btnLayer.IsBackStageButton = false;
            this.btnLayer.Location = new System.Drawing.Point(386, 135);
            this.btnLayer.Name = "btnLayer";
            this.btnLayer.Size = new System.Drawing.Size(66, 23);
            this.btnLayer.TabIndex = 20;
            this.btnLayer.Text = "Details...";
            this.btnLayer.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(89, 26);
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(363, 251);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 26);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Close";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnProject
            // 
            this.btnProject.BeforeTouchSize = new System.Drawing.Size(66, 23);
            this.btnProject.IsBackStageButton = false;
            this.btnProject.Location = new System.Drawing.Point(386, 11);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(66, 23);
            this.btnProject.TabIndex = 22;
            this.btnProject.Text = "Details...";
            this.btnProject.UseVisualStyleBackColor = true;
            // 
            // chkWkt
            // 
            this.chkWkt.AutoSize = true;
            this.chkWkt.Location = new System.Drawing.Point(12, 257);
            this.chkWkt.Name = "chkWkt";
            this.chkWkt.Size = new System.Drawing.Size(79, 17);
            this.chkWkt.TabIndex = 23;
            this.chkWkt.Text = "WKT string";
            this.chkWkt.UseVisualStyleBackColor = true;
            this.chkWkt.Visible = false;
            // 
            // CompareProjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(462, 284);
            this.Controls.Add(this.chkWkt);
            this.Controls.Add(this.btnProject);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnLayer);
            this.Controls.Add(this.txtLayer);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.lblLayer);
            this.Controls.Add(this.lblProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CompareProjectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Projection mismatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLayer;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.TextBox txtLayer;
        private ButtonAdv btnLayer;
        private ButtonAdv btnOk;
        private ButtonAdv btnProject;
        private System.Windows.Forms.CheckBox chkWkt;
    }
}