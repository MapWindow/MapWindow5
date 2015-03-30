using MW5.Projections.Controls;
using MW5.UI.Controls;

namespace MW5.Projections.Forms
{
    partial class ReprojectForm
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ProjectionTreeView1 = new ProjectionTreeView();
            this.LayersControl1 = new LayersControl();
            this.lblProjection = new System.Windows.Forms.Label();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(409, 366);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(104, 26);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Reproject";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(519, 366);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 26);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.ProjectionTreeView1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.LayersControl1);
            this.SplitContainer1.Size = new System.Drawing.Size(619, 356);
            this.SplitContainer1.SplitterDistance = 304;
            this.SplitContainer1.TabIndex = 14;
            // 
            // ProjectionTreeView1
            // 
            this.ProjectionTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectionTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectionTreeView1.FullRowSelect = true;
            this.ProjectionTreeView1.HideSelection = false;
            this.ProjectionTreeView1.ImageIndex = 0;
            this.ProjectionTreeView1.Location = new System.Drawing.Point(0, 0);
            this.ProjectionTreeView1.Name = "ProjectionTreeView1";
            this.ProjectionTreeView1.SelectedImageIndex = 0;
            this.ProjectionTreeView1.Size = new System.Drawing.Size(302, 354);
            this.ProjectionTreeView1.TabIndex = 11;
            this.ProjectionTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ProjectionTreeView1_AfterSelect);
            // 
            // LayersControl1
            // 
            this.LayersControl1.ControlType = LayersControl.CustomType.Default;
            this.LayersControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayersControl1.Location = new System.Drawing.Point(0, 0);
            this.LayersControl1.MinimumSize = new System.Drawing.Size(233, 262);
            this.LayersControl1.Multiselect = false;
            this.LayersControl1.Name = "LayersControl1";
            this.LayersControl1.Size = new System.Drawing.Size(309, 354);
            this.LayersControl1.TabIndex = 0;
            // 
            // lblProjection
            // 
            this.lblProjection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProjection.Location = new System.Drawing.Point(12, 373);
            this.lblProjection.Name = "lblProjection";
            this.lblProjection.Size = new System.Drawing.Size(391, 16);
            this.lblProjection.TabIndex = 17;
            // 
            // frmReproject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(626, 398);
            this.Controls.Add(this.lblProjection);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.SplitContainer1);
            this.MinimizeBox = false;
            this.Name = "ReprojectForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reproject layers";
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal ProjectionTreeView ProjectionTreeView1;
        internal LayersControl LayersControl1;
        private System.Windows.Forms.Label lblProjection;
    }
}