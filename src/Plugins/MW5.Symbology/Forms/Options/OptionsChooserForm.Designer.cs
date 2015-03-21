using MW5.Api;

namespace MW5.Plugins.Symbology.Forms.Options
{
    partial class OptionsChooserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsChooserForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkDontShow = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.axMap1 = new MapControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose the set of visualization options to use for the new layer:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(347, 306);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 26);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(448, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(12, 267);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(531, 30);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description: ";
            // 
            // chkDontShow
            // 
            this.chkDontShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDontShow.AutoSize = true;
            this.chkDontShow.Location = new System.Drawing.Point(15, 312);
            this.chkDontShow.Name = "chkDontShow";
            this.chkDontShow.Size = new System.Drawing.Size(181, 17);
            this.chkDontShow.TabIndex = 14;
            this.chkDontShow.Text = "Don\'t show this dialog on loading";
            this.chkDontShow.UseVisualStyleBackColor = true;
            this.chkDontShow.CheckedChanged += new System.EventHandler(this.chkDontShow_CheckedChanged);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(167, 229);
            this.listView1.TabIndex = 29;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.dgv_CurrentCellChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Available options";
            this.columnHeader1.Width = 155;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 33);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axMap1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(530, 231);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 30;
            // 
            // axMap1
            // 
            this.axMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMap1.Enabled = true;
            this.axMap1.Location = new System.Drawing.Point(0, 0);
            this.axMap1.Name = "axMap1";
            this.axMap1.Size = new System.Drawing.Size(355, 229);
            this.axMap1.TabIndex = 1;
            // 
            // frmOptionsChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(551, 341);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.chkDontShow);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "OptionsChooserForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Symbology chooser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOptionsChooser_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkDontShow;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MapControl axMap1;
    }
}