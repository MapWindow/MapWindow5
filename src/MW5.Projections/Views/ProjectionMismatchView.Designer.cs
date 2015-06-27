namespace MW5.Projections.Views
{
    partial class ProjectionMismatchView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectionMismatchView));
            this.lblSize = new System.Windows.Forms.Label();
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnSkip = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnReproject = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnDetails = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnIgnore = new Syncfusion.Windows.Forms.ButtonAdv();
            this.chkDontShow = new System.Windows.Forms.CheckBox();
            this.chkUseAnswerLater = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(22, 116);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(33, 13);
            this.lblSize.TabIndex = 50;
            this.lblSize.Text = "Size: ";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(22, 87);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(29, 13);
            this.lblFilename.TabIndex = 49;
            this.lblFilename.Text = "File: ";
            // 
            // btnSkip
            // 
            this.btnSkip.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnSkip.IsBackStageButton = false;
            this.btnSkip.Location = new System.Drawing.Point(310, 225);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(85, 26);
            this.btnSkip.TabIndex = 48;
            this.btnSkip.Text = "Skip";
            this.btnSkip.Click += new System.EventHandler(this.OnSkipClick);
            // 
            // btnReproject
            // 
            this.btnReproject.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnReproject.IsBackStageButton = false;
            this.btnReproject.Location = new System.Drawing.Point(128, 225);
            this.btnReproject.Name = "btnReproject";
            this.btnReproject.Size = new System.Drawing.Size(85, 26);
            this.btnReproject.TabIndex = 47;
            this.btnReproject.Text = "Reproject";
            this.btnReproject.Click += new System.EventHandler(this.OnReprojectClick);
            // 
            // btnDetails
            // 
            this.btnDetails.BeforeTouchSize = new System.Drawing.Size(106, 26);
            this.btnDetails.IsBackStageButton = false;
            this.btnDetails.Location = new System.Drawing.Point(380, 150);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(106, 26);
            this.btnDetails.TabIndex = 46;
            this.btnDetails.Text = "Mismatch details";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(401, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Cancel";
            // 
            // btnIgnore
            // 
            this.btnIgnore.BackColor = System.Drawing.Color.White;
            this.btnIgnore.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnIgnore.IsBackStageButton = false;
            this.btnIgnore.Location = new System.Drawing.Point(219, 225);
            this.btnIgnore.MetroColor = System.Drawing.Color.White;
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(85, 26);
            this.btnIgnore.TabIndex = 44;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyle = false;
            this.btnIgnore.Click += new System.EventHandler(this.OnIgnoreClick);
            // 
            // chkDontShow
            // 
            this.chkDontShow.AutoSize = true;
            this.chkDontShow.Location = new System.Drawing.Point(25, 185);
            this.chkDontShow.Name = "chkDontShow";
            this.chkDontShow.Size = new System.Drawing.Size(133, 17);
            this.chkDontShow.TabIndex = 43;
            this.chkDontShow.Text = "Never show this dialog";
            this.chkDontShow.UseVisualStyleBackColor = true;
            // 
            // chkUseAnswerLater
            // 
            this.chkUseAnswerLater.AutoSize = true;
            this.chkUseAnswerLater.Location = new System.Drawing.Point(25, 150);
            this.chkUseAnswerLater.Name = "chkUseAnswerLater";
            this.chkUseAnswerLater.Size = new System.Drawing.Size(238, 17);
            this.chkUseAnswerLater.TabIndex = 42;
            this.chkUseAnswerLater.Text = "Do the same for other files during this session";
            this.chkUseAnswerLater.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(22, 21);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(462, 66);
            this.lblMessage.TabIndex = 41;
            this.lblMessage.Text = resources.GetString("lblMessage.Text");
            // 
            // ProjectionMismatchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(505, 267);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnReproject);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnIgnore);
            this.Controls.Add(this.chkDontShow);
            this.Controls.Add(this.chkUseAnswerLater);
            this.Controls.Add(this.lblMessage);
            this.Name = "ProjectionMismatchView";
            this.Text = "Projection Mismatch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblFilename;
        private Syncfusion.Windows.Forms.ButtonAdv btnSkip;
        private Syncfusion.Windows.Forms.ButtonAdv btnReproject;
        private Syncfusion.Windows.Forms.ButtonAdv btnDetails;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnIgnore;
        internal System.Windows.Forms.CheckBox chkDontShow;
        internal System.Windows.Forms.CheckBox chkUseAnswerLater;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}