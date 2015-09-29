using MW5.Projections.Controls;
using MW5.UI.Legacy;

namespace MW5.Projections.Forms
{
    partial class AssignProjectionForm
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
            this.LayersControl1 = new LayersControl();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblProjection = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ProjectionTreeView1 = new ProjectionTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProjectionTreeView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(388, 388);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 26);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Assign";
            this.toolTip1.SetToolTip(this.btnOk, "Assigns the projection for all selected layers.");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(579, 388);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 26);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainer1.Location = new System.Drawing.Point(4, 3);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.ProjectionTreeView1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.LayersControl1);
            this.SplitContainer1.Size = new System.Drawing.Size(663, 380);
            this.SplitContainer1.SplitterDistance = 326;
            this.SplitContainer1.TabIndex = 10;
            // 
            // LayersControl1
            // 
            this.LayersControl1.ControlType = LayersControl.CustomType.Default;
            this.LayersControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayersControl1.Location = new System.Drawing.Point(0, 0);
            this.LayersControl1.MinimumSize = new System.Drawing.Size(233, 262);
            this.LayersControl1.Multiselect = false;
            this.LayersControl1.Name = "LayersControl1";
            this.LayersControl1.Size = new System.Drawing.Size(331, 378);
            this.LayersControl1.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(484, 388);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(87, 26);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "Test";
            this.toolTip1.SetToolTip(this.btnTest, "Tries to assign projection for the selected layer and to show it on the World map" +
        " to ensure that the layer will be correctly located.");
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblProjection
            // 
            this.lblProjection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProjection.Location = new System.Drawing.Point(12, 393);
            this.lblProjection.Name = "lblProjection";
            this.lblProjection.Size = new System.Drawing.Size(359, 15);
            this.lblProjection.TabIndex = 15;
            // 
            // ProjectionTreeView1
            // 
            this.ProjectionTreeView1.BeforeTouchSize = new System.Drawing.Size(324, 378);
            this.ProjectionTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectionTreeView1.CanSelectDisabledNode = false;
            this.ProjectionTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectionTreeView1.FullRowSelect = true;
            // 
            // 
            // 
            this.ProjectionTreeView1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.ProjectionTreeView1.HelpTextControl.Name = "helpText";
            this.ProjectionTreeView1.HelpTextControl.TabIndex = 0;
            this.ProjectionTreeView1.HideSelection = false;
            this.ProjectionTreeView1.Location = new System.Drawing.Point(0, 0);
            this.ProjectionTreeView1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.ProjectionTreeView1.Name = "ProjectionTreeView1";
            this.ProjectionTreeView1.ShowFocusRect = true;
            this.ProjectionTreeView1.Size = new System.Drawing.Size(324, 378);
            this.ProjectionTreeView1.TabIndex = 11;
            // 
            // 
            // 
            this.ProjectionTreeView1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.ProjectionTreeView1.ToolTipControl.Name = "toolTip";
            this.ProjectionTreeView1.ToolTipControl.TabIndex = 1;
            this.ProjectionTreeView1.CoordinateSystemSelected += new System.EventHandler<CoordinateSystemEventArgs>(this.ProjectionTreeView1_CoordinateSystemSelected);
            // 
            // AssignProjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(671, 417);
            this.Controls.Add(this.lblProjection);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.SplitContainer1);
            this.MinimizeBox = false;
            this.Name = "AssignProjectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Projection";
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProjectionTreeView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal ProjectionTreeView ProjectionTreeView1;
        internal LayersControl LayersControl1;
        internal System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblProjection;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}