namespace MW5.Plugins.Symbology.Views
{
    partial class CategoriesSubView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dgvCategories = new MW5.Plugins.Symbology.Controls.CategoriesGrid();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmnStyle = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnExpression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lstFields1 = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkRandomColors = new System.Windows.Forms.CheckBox();
            this.chkSetGradient = new System.Windows.Forms.CheckBox();
            this.icbCategories = new MW5.Plugins.Symbology.Controls.ImageCombo.ColorSchemeCombo();
            this.btnChangeColorScheme = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCategoryClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupVariableSize = new System.Windows.Forms.GroupBox();
            this.udMaxSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.udMinSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.chkUseVariableSize = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.udNumCategories = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.chkUniqueValues = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnCategoryRemove = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCategoryAppearance = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnCategoryGenerate = new Syncfusion.Windows.Forms.ButtonAdv();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupVariableSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinSize)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udNumCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dgvCategories);
            this.groupBox12.Location = new System.Drawing.Point(3, 180);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(366, 219);
            this.groupBox12.TabIndex = 138;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Categories";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.cmnVisible,
            this.cmnStyle,
            this.cmnName,
            this.cmnExpression,
            this.cmnCount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCategories.Location = new System.Drawing.Point(3, 16);
            this.dgvCategories.LockUpdate = false;
            this.dgvCategories.Name = "dgvCategories";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategories.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowHeadersWidth = 15;
            this.dgvCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCategories.ShowCellErrors = false;
            this.dgvCategories.Size = new System.Drawing.Size(360, 200);
            this.dgvCategories.TabIndex = 93;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Visible = false;
            this.ID.Width = 30;
            // 
            // cmnVisible
            // 
            this.cmnVisible.HeaderText = "";
            this.cmnVisible.Name = "cmnVisible";
            this.cmnVisible.Width = 30;
            // 
            // cmnStyle
            // 
            this.cmnStyle.HeaderText = "Style";
            this.cmnStyle.Name = "cmnStyle";
            this.cmnStyle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmnStyle.Width = 50;
            // 
            // cmnName
            // 
            this.cmnName.HeaderText = "Name";
            this.cmnName.Name = "cmnName";
            this.cmnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmnName.Width = 120;
            // 
            // cmnExpression
            // 
            this.cmnExpression.HeaderText = "Expression";
            this.cmnExpression.Name = "cmnExpression";
            this.cmnExpression.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmnExpression.Visible = false;
            this.cmnExpression.Width = 5;
            // 
            // cmnCount
            // 
            this.cmnCount.HeaderText = "Count";
            this.cmnCount.Name = "cmnCount";
            this.cmnCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cmnCount.Width = 40;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lstFields1);
            this.groupBox11.Location = new System.Drawing.Point(3, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(153, 170);
            this.groupBox11.TabIndex = 137;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Fields";
            // 
            // lstFields1
            // 
            this.lstFields1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFields1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFields1.FormattingEnabled = true;
            this.lstFields1.Location = new System.Drawing.Point(3, 16);
            this.lstFields1.Name = "lstFields1";
            this.lstFields1.Size = new System.Drawing.Size(147, 151);
            this.lstFields1.TabIndex = 124;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkRandomColors);
            this.groupBox6.Controls.Add(this.chkSetGradient);
            this.groupBox6.Controls.Add(this.icbCategories);
            this.groupBox6.Controls.Add(this.btnChangeColorScheme);
            this.groupBox6.Location = new System.Drawing.Point(168, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(201, 82);
            this.groupBox6.TabIndex = 136;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Color scheme";
            // 
            // chkRandomColors
            // 
            this.chkRandomColors.AutoSize = true;
            this.chkRandomColors.Location = new System.Drawing.Point(93, 54);
            this.chkRandomColors.Name = "chkRandomColors";
            this.chkRandomColors.Size = new System.Drawing.Size(97, 17);
            this.chkRandomColors.TabIndex = 108;
            this.chkRandomColors.Text = "Random colors";
            this.chkRandomColors.UseVisualStyleBackColor = true;
            this.chkRandomColors.CheckedChanged += new System.EventHandler(this.OnRandomColorsChecked);
            // 
            // chkSetGradient
            // 
            this.chkSetGradient.Checked = true;
            this.chkSetGradient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetGradient.Location = new System.Drawing.Point(19, 52);
            this.chkSetGradient.Name = "chkSetGradient";
            this.chkSetGradient.Size = new System.Drawing.Size(68, 20);
            this.chkSetGradient.TabIndex = 116;
            this.chkSetGradient.Text = "Gradient";
            this.chkSetGradient.UseVisualStyleBackColor = true;
            // 
            // icbCategories
            // 
            this.icbCategories.ComboStyle = MW5.Api.Enums.SchemeType.Graduated;
            this.icbCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbCategories.FormattingEnabled = true;
            this.icbCategories.Location = new System.Drawing.Point(19, 25);
            this.icbCategories.Name = "icbCategories";
            this.icbCategories.OutlineColor = System.Drawing.Color.Black;
            this.icbCategories.Target = MW5.Plugins.Symbology.SchemeTarget.Vector;
            this.icbCategories.Size = new System.Drawing.Size(137, 21);
            this.icbCategories.TabIndex = 106;
            // 
            // btnChangeColorScheme
            // 
            this.btnChangeColorScheme.BeforeTouchSize = new System.Drawing.Size(28, 21);
            this.btnChangeColorScheme.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnChangeColorScheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChangeColorScheme.IsBackStageButton = false;
            this.btnChangeColorScheme.Location = new System.Drawing.Point(162, 25);
            this.btnChangeColorScheme.Name = "btnChangeColorScheme";
            this.btnChangeColorScheme.Size = new System.Drawing.Size(28, 21);
            this.btnChangeColorScheme.TabIndex = 107;
            this.btnChangeColorScheme.Text = "...";
            this.btnChangeColorScheme.UseVisualStyleBackColor = true;
            // 
            // btnCategoryClear
            // 
            this.btnCategoryClear.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCategoryClear.IsBackStageButton = false;
            this.btnCategoryClear.Location = new System.Drawing.Point(392, 112);
            this.btnCategoryClear.Name = "btnCategoryClear";
            this.btnCategoryClear.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryClear.TabIndex = 132;
            this.btnCategoryClear.Text = "Clear";
            this.btnCategoryClear.UseVisualStyleBackColor = true;
            // 
            // groupVariableSize
            // 
            this.groupVariableSize.Controls.Add(this.udMaxSize);
            this.groupVariableSize.Controls.Add(this.udMinSize);
            this.groupVariableSize.Controls.Add(this.label5);
            this.groupVariableSize.Controls.Add(this.chkUseVariableSize);
            this.groupVariableSize.Location = new System.Drawing.Point(392, 180);
            this.groupVariableSize.Name = "groupVariableSize";
            this.groupVariableSize.Size = new System.Drawing.Size(93, 142);
            this.groupVariableSize.TabIndex = 135;
            this.groupVariableSize.TabStop = false;
            this.groupVariableSize.Text = "Variable size";
            this.groupVariableSize.Visible = false;
            // 
            // udMaxSize
            // 
            this.udMaxSize.Location = new System.Drawing.Point(30, 95);
            this.udMaxSize.Name = "udMaxSize";
            this.udMaxSize.Size = new System.Drawing.Size(45, 20);
            this.udMaxSize.TabIndex = 118;
            // 
            // udMinSize
            // 
            this.udMinSize.Location = new System.Drawing.Point(30, 69);
            this.udMinSize.Name = "udMinSize";
            this.udMinSize.Size = new System.Drawing.Size(45, 20);
            this.udMinSize.TabIndex = 117;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 116;
            this.label5.Text = "Size:";
            // 
            // chkUseVariableSize
            // 
            this.chkUseVariableSize.AutoSize = true;
            this.chkUseVariableSize.Location = new System.Drawing.Point(16, 28);
            this.chkUseVariableSize.Name = "chkUseVariableSize";
            this.chkUseVariableSize.Size = new System.Drawing.Size(59, 17);
            this.chkUseVariableSize.TabIndex = 115;
            this.chkUseVariableSize.Text = "Enable";
            this.chkUseVariableSize.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.udNumCategories);
            this.groupBox9.Controls.Add(this.chkUniqueValues);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Location = new System.Drawing.Point(168, 88);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(201, 82);
            this.groupBox9.TabIndex = 134;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Classification";
            // 
            // udNumCategories
            // 
            this.udNumCategories.Location = new System.Drawing.Point(84, 26);
            this.udNumCategories.Name = "udNumCategories";
            this.udNumCategories.Size = new System.Drawing.Size(55, 20);
            this.udNumCategories.TabIndex = 156;
            // 
            // chkUniqueValues
            // 
            this.chkUniqueValues.AutoSize = true;
            this.chkUniqueValues.Location = new System.Drawing.Point(23, 55);
            this.chkUniqueValues.Name = "chkUniqueValues";
            this.chkUniqueValues.Size = new System.Drawing.Size(94, 17);
            this.chkUniqueValues.TabIndex = 123;
            this.chkUniqueValues.Text = "Unique values";
            this.chkUniqueValues.UseVisualStyleBackColor = true;
            this.chkUniqueValues.CheckedChanged += new System.EventHandler(this.OnUniqueValuesChecked);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 101;
            this.label19.Text = "Categories";
            // 
            // btnCategoryRemove
            // 
            this.btnCategoryRemove.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCategoryRemove.IsBackStageButton = false;
            this.btnCategoryRemove.Location = new System.Drawing.Point(392, 80);
            this.btnCategoryRemove.Name = "btnCategoryRemove";
            this.btnCategoryRemove.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryRemove.TabIndex = 133;
            this.btnCategoryRemove.Text = "Remove";
            this.btnCategoryRemove.UseVisualStyleBackColor = true;
            // 
            // btnCategoryAppearance
            // 
            this.btnCategoryAppearance.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCategoryAppearance.IsBackStageButton = false;
            this.btnCategoryAppearance.Location = new System.Drawing.Point(392, 48);
            this.btnCategoryAppearance.Name = "btnCategoryAppearance";
            this.btnCategoryAppearance.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryAppearance.TabIndex = 131;
            this.btnCategoryAppearance.Text = "Appearance...";
            this.btnCategoryAppearance.UseVisualStyleBackColor = true;
            // 
            // btnCategoryGenerate
            // 
            this.btnCategoryGenerate.BeforeTouchSize = new System.Drawing.Size(93, 26);
            this.btnCategoryGenerate.IsBackStageButton = false;
            this.btnCategoryGenerate.Location = new System.Drawing.Point(392, 16);
            this.btnCategoryGenerate.Name = "btnCategoryGenerate";
            this.btnCategoryGenerate.Size = new System.Drawing.Size(93, 26);
            this.btnCategoryGenerate.TabIndex = 130;
            this.btnCategoryGenerate.Text = "Generate";
            this.btnCategoryGenerate.UseVisualStyleBackColor = true;
            // 
            // CategoriesSubView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnCategoryClear);
            this.Controls.Add(this.groupVariableSize);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.btnCategoryRemove);
            this.Controls.Add(this.btnCategoryAppearance);
            this.Controls.Add(this.btnCategoryGenerate);
            this.Name = "CategoriesSubView";
            this.Size = new System.Drawing.Size(493, 402);
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupVariableSize.ResumeLayout(false);
            this.groupVariableSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinSize)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udNumCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox12;
        private Controls.CategoriesGrid dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cmnVisible;
        private System.Windows.Forms.DataGridViewImageColumn cmnStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnExpression;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCount;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ListBox lstFields1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkRandomColors;
        private System.Windows.Forms.CheckBox chkSetGradient;
        private Controls.ImageCombo.ColorSchemeCombo icbCategories;
        private Syncfusion.Windows.Forms.ButtonAdv btnChangeColorScheme;
        private Syncfusion.Windows.Forms.ButtonAdv btnCategoryClear;
        private System.Windows.Forms.GroupBox groupVariableSize;
        private Controls.NumericUpDownEx udMaxSize;
        private Controls.NumericUpDownEx udMinSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkUseVariableSize;
        private System.Windows.Forms.GroupBox groupBox9;
        private Controls.NumericUpDownEx udNumCategories;
        private System.Windows.Forms.CheckBox chkUniqueValues;
        private System.Windows.Forms.Label label19;
        private Syncfusion.Windows.Forms.ButtonAdv btnCategoryRemove;
        private Syncfusion.Windows.Forms.ButtonAdv btnCategoryAppearance;
        private Syncfusion.Windows.Forms.ButtonAdv btnCategoryGenerate;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
