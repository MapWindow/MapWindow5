using MW5.UI.Controls;
using Syncfusion.Windows.Forms;

namespace MW5.Plugins.Printing.Views
{
    partial class TableView
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
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabData = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabColumns = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.udRelWidth = new System.Windows.Forms.NumericUpDown();
            this.optRelative = new System.Windows.Forms.RadioButton();
            this.optAuto = new System.Windows.Forms.RadioButton();
            this.optFixed = new System.Windows.Forms.RadioButton();
            this.udWidth = new System.Windows.Forms.NumericUpDown();
            this.listBoxColumns = new MW5.UI.Controls.ListBoxEx();
            this.btnRemoveField = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAddField = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnApply = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabColumns.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRelWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(81, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(507, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 26);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(84, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(417, 397);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 26);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "Ok";
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(580, 379);
            this.tabControlAdv1.Controls.Add(this.tabData);
            this.tabControlAdv1.Controls.Add(this.tabColumns);
            this.tabControlAdv1.Location = new System.Drawing.Point(8, 12);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.Size = new System.Drawing.Size(580, 379);
            this.tabControlAdv1.TabIndex = 11;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.dataGridView1);
            this.tabData.Image = null;
            this.tabData.ImageSize = new System.Drawing.Size(16, 16);
            this.tabData.Location = new System.Drawing.Point(1, 25);
            this.tabData.Name = "tabData";
            this.tabData.ShowCloseButton = true;
            this.tabData.Size = new System.Drawing.Size(577, 352);
            this.tabData.TabIndex = 2;
            this.tabData.Text = "Data";
            this.tabData.ThemesEnabled = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(577, 352);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabColumns
            // 
            this.tabColumns.Controls.Add(this.groupBox1);
            this.tabColumns.Controls.Add(this.listBoxColumns);
            this.tabColumns.Controls.Add(this.btnRemoveField);
            this.tabColumns.Controls.Add(this.btnAddField);
            this.tabColumns.Image = null;
            this.tabColumns.ImageSize = new System.Drawing.Size(16, 16);
            this.tabColumns.Location = new System.Drawing.Point(1, 25);
            this.tabColumns.Name = "tabColumns";
            this.tabColumns.ShowCloseButton = true;
            this.tabColumns.Size = new System.Drawing.Size(577, 352);
            this.tabColumns.TabIndex = 3;
            this.tabColumns.Text = "Columns";
            this.tabColumns.ThemesEnabled = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblPercent);
            this.groupBox1.Controls.Add(this.udRelWidth);
            this.groupBox1.Controls.Add(this.optRelative);
            this.groupBox1.Controls.Add(this.optAuto);
            this.groupBox1.Controls.Add(this.optFixed);
            this.groupBox1.Controls.Add(this.udWidth);
            this.groupBox1.Location = new System.Drawing.Point(213, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 141);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Width";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Enabled = false;
            this.lblPercent.Location = new System.Drawing.Point(213, 102);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 16;
            this.lblPercent.Text = "%";
            // 
            // udRelWidth
            // 
            this.udRelWidth.Enabled = false;
            this.udRelWidth.Location = new System.Drawing.Point(133, 100);
            this.udRelWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRelWidth.Name = "udRelWidth";
            this.udRelWidth.Size = new System.Drawing.Size(70, 20);
            this.udRelWidth.TabIndex = 15;
            this.udRelWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // optRelative
            // 
            this.optRelative.AutoSize = true;
            this.optRelative.Enabled = false;
            this.optRelative.Location = new System.Drawing.Point(24, 100);
            this.optRelative.Name = "optRelative";
            this.optRelative.Size = new System.Drawing.Size(64, 17);
            this.optRelative.TabIndex = 14;
            this.optRelative.Text = "Relative";
            this.optRelative.UseVisualStyleBackColor = true;
            // 
            // optAuto
            // 
            this.optAuto.AutoSize = true;
            this.optAuto.Checked = true;
            this.optAuto.Location = new System.Drawing.Point(24, 32);
            this.optAuto.Name = "optAuto";
            this.optAuto.Size = new System.Drawing.Size(47, 17);
            this.optAuto.TabIndex = 13;
            this.optAuto.TabStop = true;
            this.optAuto.Text = "Auto";
            this.optAuto.UseVisualStyleBackColor = true;
            // 
            // optFixed
            // 
            this.optFixed.AutoSize = true;
            this.optFixed.Enabled = false;
            this.optFixed.Location = new System.Drawing.Point(24, 65);
            this.optFixed.Name = "optFixed";
            this.optFixed.Size = new System.Drawing.Size(50, 17);
            this.optFixed.TabIndex = 12;
            this.optFixed.Text = "Fixed";
            this.optFixed.UseVisualStyleBackColor = true;
            // 
            // udWidth
            // 
            this.udWidth.Enabled = false;
            this.udWidth.Location = new System.Drawing.Point(133, 65);
            this.udWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.udWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udWidth.Name = "udWidth";
            this.udWidth.Size = new System.Drawing.Size(70, 20);
            this.udWidth.TabIndex = 6;
            this.udWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // listBoxColumns
            // 
            this.listBoxColumns.Alignment = System.Drawing.StringAlignment.Center;
            this.listBoxColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxColumns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxColumns.FormattingEnabled = true;
            this.listBoxColumns.ItemHeight = 24;
            this.listBoxColumns.Location = new System.Drawing.Point(14, 15);
            this.listBoxColumns.Name = "listBoxColumns";
            this.listBoxColumns.Size = new System.Drawing.Size(183, 316);
            this.listBoxColumns.TabIndex = 16;
            this.listBoxColumns.SelectedIndexChanged += new System.EventHandler(this.OnSelectedColumnChanged);
            // 
            // btnRemoveField
            // 
            this.btnRemoveField.BeforeTouchSize = new System.Drawing.Size(90, 24);
            this.btnRemoveField.IsBackStageButton = false;
            this.btnRemoveField.Location = new System.Drawing.Point(309, 162);
            this.btnRemoveField.Name = "btnRemoveField";
            this.btnRemoveField.Size = new System.Drawing.Size(90, 24);
            this.btnRemoveField.TabIndex = 15;
            this.btnRemoveField.Text = "Remove";
            this.btnRemoveField.UseVisualStyleBackColor = true;
            this.btnRemoveField.Click += new System.EventHandler(this.OnRemoveField);
            // 
            // btnAddField
            // 
            this.btnAddField.BeforeTouchSize = new System.Drawing.Size(90, 24);
            this.btnAddField.IsBackStageButton = false;
            this.btnAddField.Location = new System.Drawing.Point(213, 162);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(90, 24);
            this.btnAddField.TabIndex = 14;
            this.btnAddField.Text = "Add";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.OnAddField);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnApply.BeforeTouchSize = new System.Drawing.Size(84, 26);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.IsBackStageButton = false;
            this.btnApply.Location = new System.Drawing.Point(327, 397);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(84, 26);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "Apply";
            // 
            // TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(595, 425);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.tabControlAdv1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "TableView";
            this.Text = "Table Data";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabColumns.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udRelWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabData;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabColumns;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.NumericUpDown udRelWidth;
        private System.Windows.Forms.RadioButton optRelative;
        private System.Windows.Forms.RadioButton optAuto;
        private System.Windows.Forms.RadioButton optFixed;
        private System.Windows.Forms.NumericUpDown udWidth;
        private ListBoxEx listBoxColumns;
        private ButtonAdv btnRemoveField;
        private ButtonAdv btnAddField;
        private Syncfusion.Windows.Forms.ButtonAdv btnApply;
    }
}