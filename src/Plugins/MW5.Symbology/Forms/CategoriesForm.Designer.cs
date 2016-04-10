using MW5.Plugins.Symbology.Controls;
using MW5.UI.Controls;
using MW5.UI.Enums;

namespace MW5.Plugins.Symbology.Forms
{
    partial class CategoriesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.cmnVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmnStyle = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCategoryStyle = new System.Windows.Forms.Button();
            this.btnCategoryRemove = new System.Windows.Forms.Button();
            this.btnEditExpression = new System.Windows.Forms.Button();
            this.btnCategoryMoveDown = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCategoryMoveUp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnApply = new System.Windows.Forms.Button();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolStyle = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolAddRange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSaveCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRemoveStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.toolStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnVisible,
            this.cmnStyle,
            this.cmnName,
            this.cmnExpression,
            this.Count});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCategories.Location = new System.Drawing.Point(0, 0);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowHeadersWidth = 15;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCategories.ShowCellErrors = false;
            this.dgvCategories.Size = new System.Drawing.Size(498, 324);
            this.dgvCategories.TabIndex = 83;
            this.dgvCategories.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCategories_CellBeginEdit);
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnGridCellDoubleClick);
            this.dgvCategories.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellEndEdit);
            this.dgvCategories.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCategories_CellFormatting);
            this.dgvCategories.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLabelCategories_CellPainting);
            this.dgvCategories.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellValueChanged);
            this.dgvCategories.CurrentCellChanged += new System.EventHandler(this.dgvCategories_CurrentCellChanged);
            this.dgvCategories.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCategories_CurrentCellDirtyStateChanged);
            // 
            // cmnVisible
            // 
            this.cmnVisible.HeaderText = "";
            this.cmnVisible.Name = "cmnVisible";
            this.cmnVisible.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmnVisible.Width = 30;
            // 
            // cmnStyle
            // 
            this.cmnStyle.HeaderText = "Style";
            this.cmnStyle.Name = "cmnStyle";
            this.cmnStyle.ReadOnly = true;
            this.cmnStyle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmnStyle.Width = 50;
            // 
            // cmnName
            // 
            this.cmnName.HeaderText = "Name";
            this.cmnName.Name = "cmnName";
            this.cmnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmnName.Width = 135;
            // 
            // cmnExpression
            // 
            this.cmnExpression.HeaderText = "Expression";
            this.cmnExpression.Name = "cmnExpression";
            this.cmnExpression.ReadOnly = true;
            this.cmnExpression.Width = 220;
            // 
            // Count
            // 
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Count.Width = 40;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(427, 346);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 88;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.OnOkButtonClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(518, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 26);
            this.btnCancel.TabIndex = 89;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancelButtonClicked);
            // 
            // btnCategoryStyle
            // 
            this.btnCategoryStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryStyle.Location = new System.Drawing.Point(518, 46);
            this.btnCategoryStyle.Name = "btnCategoryStyle";
            this.btnCategoryStyle.Size = new System.Drawing.Size(91, 26);
            this.btnCategoryStyle.TabIndex = 8;
            this.btnCategoryStyle.Text = "Style...";
            this.btnCategoryStyle.UseVisualStyleBackColor = true;
            this.btnCategoryStyle.Click += new System.EventHandler(this.btnCategoryStyle_Click);
            // 
            // btnCategoryRemove
            // 
            this.btnCategoryRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryRemove.Location = new System.Drawing.Point(518, 182);
            this.btnCategoryRemove.Name = "btnCategoryRemove";
            this.btnCategoryRemove.Size = new System.Drawing.Size(91, 26);
            this.btnCategoryRemove.TabIndex = 103;
            this.btnCategoryRemove.Text = "Remove";
            this.btnCategoryRemove.UseVisualStyleBackColor = true;
            this.btnCategoryRemove.Click += new System.EventHandler(this.btnCategoriesRemove_Click);
            // 
            // btnEditExpression
            // 
            this.btnEditExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditExpression.Location = new System.Drawing.Point(518, 80);
            this.btnEditExpression.Name = "btnEditExpression";
            this.btnEditExpression.Size = new System.Drawing.Size(91, 26);
            this.btnEditExpression.TabIndex = 108;
            this.btnEditExpression.Text = "Expression...";
            this.btnEditExpression.UseVisualStyleBackColor = true;
            this.btnEditExpression.Click += new System.EventHandler(this.btnEditExpression_Click);
            // 
            // btnCategoryMoveDown
            // 
            this.btnCategoryMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryMoveDown.Location = new System.Drawing.Point(518, 148);
            this.btnCategoryMoveDown.Name = "btnCategoryMoveDown";
            this.btnCategoryMoveDown.Size = new System.Drawing.Size(91, 26);
            this.btnCategoryMoveDown.TabIndex = 105;
            this.btnCategoryMoveDown.Text = "Down";
            this.btnCategoryMoveDown.UseVisualStyleBackColor = true;
            this.btnCategoryMoveDown.Click += new System.EventHandler(this.btnCategoryMoveDown_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(518, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(91, 26);
            this.btnGenerate.TabIndex = 100;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCategoryMoveUp
            // 
            this.btnCategoryMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryMoveUp.Location = new System.Drawing.Point(518, 114);
            this.btnCategoryMoveUp.Name = "btnCategoryMoveUp";
            this.btnCategoryMoveUp.Size = new System.Drawing.Size(91, 26);
            this.btnCategoryMoveUp.TabIndex = 104;
            this.btnCategoryMoveUp.Text = "Up";
            this.btnCategoryMoveUp.UseVisualStyleBackColor = true;
            this.btnCategoryMoveUp.Click += new System.EventHandler(this.btnCategoryMoveUp_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(336, 346);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 26);
            this.btnApply.TabIndex = 111;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnApplyButtonClicked);
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStripEx1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStyle});
            this.toolStripEx1.Location = new System.Drawing.Point(12, 347);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.Office12Mode = false;
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.Size = new System.Drawing.Size(67, 25);
            this.toolStripEx1.TabIndex = 168;
            this.toolStripEx1.Text = "Style";
            this.toolStripEx1.VisualStyle = Syncfusion.Windows.Forms.Tools.ToolStripExStyle.Metro;
            // 
            // toolStyle
            // 
            this.toolStyle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddRange,
            this.toolStripSeparator5,
            this.toolSaveCategories,
            this.toolRemoveStyle});
            this.toolStyle.ForeColor = System.Drawing.Color.Black;
            this.toolStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.icon_settings;
            this.toolStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStyle.Name = "toolStyle";
            this.toolStyle.Size = new System.Drawing.Size(64, 22);
            this.toolStyle.Text = "More";
            // 
            // toolAddRange
            // 
            this.toolAddRange.Name = "toolAddRange";
            this.toolAddRange.Size = new System.Drawing.Size(157, 22);
            this.toolAddRange.Text = "Add Range...";
            this.toolAddRange.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(154, 6);
            // 
            // toolSaveCategories
            // 
            this.toolSaveCategories.Image = global::MW5.Plugins.Symbology.Properties.Resources.icon_save1;
            this.toolSaveCategories.Name = "toolSaveCategories";
            this.toolSaveCategories.Size = new System.Drawing.Size(157, 22);
            this.toolSaveCategories.Text = "Save categories";
            this.toolSaveCategories.Click += new System.EventHandler(this.toolSaveCategories_Click);
            // 
            // toolRemoveStyle
            // 
            this.toolRemoveStyle.Image = global::MW5.Plugins.Symbology.Properties.Resources.img_folder_open;
            this.toolRemoveStyle.Name = "toolRemoveStyle";
            this.toolRemoveStyle.Size = new System.Drawing.Size(157, 22);
            this.toolRemoveStyle.Text = "Load categories";
            this.toolRemoveStyle.Click += new System.EventHandler(this.toolRemoveStyle_Click);
            // 
            // lblEmpty
            // 
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty.Location = new System.Drawing.Point(0, 0);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(498, 324);
            this.lblEmpty.TabIndex = 169;
            this.lblEmpty.Text = "There are no categories for this layer yet.";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel1.Controls.Add(this.lblEmpty);
            this.gradientPanel1.Controls.Add(this.dgvCategories);
            this.gradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(500, 326);
            this.gradientPanel1.TabIndex = 171;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(518, 216);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 26);
            this.btnClear.TabIndex = 172;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnCategoriesClearClick);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(615, 379);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.toolStripEx1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCategoryStyle);
            this.Controls.Add(this.btnCategoryRemove);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnEditExpression);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCategoryMoveDown);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnCategoryMoveUp);
            this.MinimumSize = new System.Drawing.Size(470, 350);
            this.Name = "CategoriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layer Categories";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnCategoriesFormClosing);
            this.Load += new System.EventHandler(this.CategoriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCategoryRemove;
        private System.Windows.Forms.Button btnCategoryMoveDown;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCategoryMoveUp;
        private System.Windows.Forms.Button btnEditExpression;
        private System.Windows.Forms.Button btnCategoryStyle;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cmnVisible;
        private System.Windows.Forms.DataGridViewImageColumn cmnStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnExpression;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripDropDownButton toolStyle;
        private System.Windows.Forms.ToolStripMenuItem toolSaveCategories;
        private System.Windows.Forms.ToolStripMenuItem toolRemoveStyle;
        private System.Windows.Forms.ToolStripMenuItem toolAddRange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Label lblEmpty;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.Button btnClear;
    }
}