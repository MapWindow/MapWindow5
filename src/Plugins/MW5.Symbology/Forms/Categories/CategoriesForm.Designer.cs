using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ColorPicker;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Properties;

namespace MW5.Plugins.Symbology.Forms.Categories
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
            this.Visible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmnStyle = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.groupExpression = new System.Windows.Forms.GroupBox();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.groupFill = new System.Windows.Forms.GroupBox();
            this.icbFillStyle = new MW5.Plugins.Symbology.Controls.ImageCombo.ImageCombo();
            this.clpPolygonFill = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCategoryStyle = new System.Windows.Forms.Button();
            this.btnCategoryRemove = new System.Windows.Forms.Button();
            this.btnEditExpression = new System.Windows.Forms.Button();
            this.btnCategoryMoveDown = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCategoryMoveUp = new System.Windows.Forms.Button();
            this.groupLine = new System.Windows.Forms.GroupBox();
            this.clpLine = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.icbLineWidth = new MW5.Plugins.Symbology.Controls.ImageCombo.ImageCombo();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupPoint = new System.Windows.Forms.GroupBox();
            this.clpPointFill = new MW5.Plugins.Symbology.Controls.ColorPicker.Office2007ColorPicker(this.components);
            this.udPointSize = new MW5.Plugins.Symbology.Controls.NumericUpDownEx(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnApply = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddRange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadCategories = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyFrom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.groupExpression.SuspendLayout();
            this.groupFill.SuspendLayout();
            this.groupLine.SuspendLayout();
            this.groupPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPointSize)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Visible,
            this.cmnStyle,
            this.cmnName,
            this.Count});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategories.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCategories.Location = new System.Drawing.Point(12, 12);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowHeadersWidth = 15;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCategories.ShowCellErrors = false;
            this.dgvCategories.Size = new System.Drawing.Size(278, 323);
            this.dgvCategories.TabIndex = 83;
            this.dgvCategories.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCategories_CellBeginEdit);
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLabelCategories_CellDoubleClick);
            this.dgvCategories.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellEndEdit);
            this.dgvCategories.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCategories_CellFormatting);
            this.dgvCategories.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLabelCategories_CellPainting);
            this.dgvCategories.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellValueChanged);
            this.dgvCategories.CurrentCellChanged += new System.EventHandler(this.dgvCategories_CurrentCellChanged);
            this.dgvCategories.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCategories_CurrentCellDirtyStateChanged);
            // 
            // Visible
            // 
            this.Visible.HeaderText = "";
            this.Visible.Name = "Visible";
            this.Visible.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Visible.Width = 30;
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
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(413, 348);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 25);
            this.btnOk.TabIndex = 88;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(515, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 25);
            this.btnCancel.TabIndex = 89;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(218, 341);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(72, 32);
            this.btnMore.TabIndex = 113;
            this.btnMore.Text = "More...";
            this.btnMore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // groupExpression
            // 
            this.groupExpression.Controls.Add(this.txtExpression);
            this.groupExpression.Location = new System.Drawing.Point(300, 121);
            this.groupExpression.Name = "groupExpression";
            this.groupExpression.Size = new System.Drawing.Size(311, 185);
            this.groupExpression.TabIndex = 111;
            this.groupExpression.TabStop = false;
            this.groupExpression.Text = "Expression";
            // 
            // txtExpression
            // 
            this.txtExpression.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpression.Location = new System.Drawing.Point(3, 16);
            this.txtExpression.Multiline = true;
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(305, 166);
            this.txtExpression.TabIndex = 86;
            this.txtExpression.TextChanged += new System.EventHandler(this.txtExpression_TextChanged);
            this.txtExpression.Validated += new System.EventHandler(this.txtExpression_Validated);
            // 
            // groupFill
            // 
            this.groupFill.Controls.Add(this.icbFillStyle);
            this.groupFill.Controls.Add(this.clpPolygonFill);
            this.groupFill.Controls.Add(this.label12);
            this.groupFill.Controls.Add(this.label13);
            this.groupFill.Location = new System.Drawing.Point(300, 12);
            this.groupFill.Name = "groupFill";
            this.groupFill.Size = new System.Drawing.Size(311, 74);
            this.groupFill.TabIndex = 111;
            this.groupFill.TabStop = false;
            this.groupFill.Text = "Options";
            // 
            // icbFillStyle
            // 
            this.icbFillStyle.Color1 = System.Drawing.Color.Gray;
            this.icbFillStyle.Color2 = System.Drawing.Color.Gray;
            this.icbFillStyle.ComboStyle = MW5.Plugins.Symbology.ImageComboStyle.Common;
            this.icbFillStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbFillStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbFillStyle.FormattingEnabled = true;
            this.icbFillStyle.Location = new System.Drawing.Point(154, 31);
            this.icbFillStyle.Name = "icbFillStyle";
            this.icbFillStyle.OutlineColor = System.Drawing.Color.Black;
            this.icbFillStyle.Size = new System.Drawing.Size(86, 21);
            this.icbFillStyle.TabIndex = 110;
            // 
            // clpPolygonFill
            // 
            this.clpPolygonFill.Color = System.Drawing.Color.Black;
            this.clpPolygonFill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpPolygonFill.DropDownHeight = 1;
            this.clpPolygonFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpPolygonFill.FormattingEnabled = true;
            this.clpPolygonFill.IntegralHeight = false;
            this.clpPolygonFill.Items.AddRange(new object[] {
            "Color"});
            this.clpPolygonFill.Location = new System.Drawing.Point(28, 31);
            this.clpPolygonFill.Name = "clpPolygonFill";
            this.clpPolygonFill.Size = new System.Drawing.Size(58, 21);
            this.clpPolygonFill.TabIndex = 109;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(92, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Fill color";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(246, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 108;
            this.label13.Text = "Fill style";
            // 
            // btnCategoryStyle
            // 
            this.btnCategoryStyle.Location = new System.Drawing.Point(413, 92);
            this.btnCategoryStyle.Name = "btnCategoryStyle";
            this.btnCategoryStyle.Size = new System.Drawing.Size(106, 23);
            this.btnCategoryStyle.TabIndex = 8;
            this.btnCategoryStyle.Text = "More options...";
            this.btnCategoryStyle.UseVisualStyleBackColor = true;
            this.btnCategoryStyle.Click += new System.EventHandler(this.btnCategoryStyle_Click);
            // 
            // btnCategoryRemove
            // 
            this.btnCategoryRemove.Image = global::MW5.Plugins.Symbology.Properties.Resources.layer_remove;
            this.btnCategoryRemove.Location = new System.Drawing.Point(55, 341);
            this.btnCategoryRemove.Name = "btnCategoryRemove";
            this.btnCategoryRemove.Size = new System.Drawing.Size(32, 32);
            this.btnCategoryRemove.TabIndex = 103;
            this.toolTip1.SetToolTip(this.btnCategoryRemove, "Remove category");
            this.btnCategoryRemove.UseVisualStyleBackColor = true;
            this.btnCategoryRemove.Click += new System.EventHandler(this.btnCategoriesRemove_Click);
            // 
            // btnEditExpression
            // 
            this.btnEditExpression.Location = new System.Drawing.Point(520, 312);
            this.btnEditExpression.Name = "btnEditExpression";
            this.btnEditExpression.Size = new System.Drawing.Size(91, 23);
            this.btnEditExpression.TabIndex = 108;
            this.btnEditExpression.Text = "Edit...";
            this.btnEditExpression.UseVisualStyleBackColor = true;
            this.btnEditExpression.Click += new System.EventHandler(this.btnEditExpression_Click);
            // 
            // btnCategoryMoveDown
            // 
            this.btnCategoryMoveDown.Image = global::MW5.Plugins.Symbology.Properties.Resources.down;
            this.btnCategoryMoveDown.Location = new System.Drawing.Point(131, 341);
            this.btnCategoryMoveDown.Name = "btnCategoryMoveDown";
            this.btnCategoryMoveDown.Size = new System.Drawing.Size(32, 32);
            this.btnCategoryMoveDown.TabIndex = 105;
            this.btnCategoryMoveDown.UseVisualStyleBackColor = true;
            this.btnCategoryMoveDown.Click += new System.EventHandler(this.btnCategoryMoveDown_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Image = global::MW5.Plugins.Symbology.Properties.Resources.layer_vector_thematic_add;
            this.btnGenerate.Location = new System.Drawing.Point(12, 341);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(37, 32);
            this.btnGenerate.TabIndex = 100;
            this.toolTip1.SetToolTip(this.btnGenerate, "Generate categories");
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCategoryMoveUp
            // 
            this.btnCategoryMoveUp.Image = global::MW5.Plugins.Symbology.Properties.Resources.up;
            this.btnCategoryMoveUp.Location = new System.Drawing.Point(93, 341);
            this.btnCategoryMoveUp.Name = "btnCategoryMoveUp";
            this.btnCategoryMoveUp.Size = new System.Drawing.Size(32, 32);
            this.btnCategoryMoveUp.TabIndex = 104;
            this.btnCategoryMoveUp.UseVisualStyleBackColor = true;
            this.btnCategoryMoveUp.Click += new System.EventHandler(this.btnCategoryMoveUp_Click);
            // 
            // groupLine
            // 
            this.groupLine.Controls.Add(this.clpLine);
            this.groupLine.Controls.Add(this.label6);
            this.groupLine.Controls.Add(this.icbLineWidth);
            this.groupLine.Controls.Add(this.label7);
            this.groupLine.Location = new System.Drawing.Point(644, 105);
            this.groupLine.Name = "groupLine";
            this.groupLine.Size = new System.Drawing.Size(311, 74);
            this.groupLine.TabIndex = 95;
            this.groupLine.TabStop = false;
            this.groupLine.Text = "Options";
            // 
            // clpLine
            // 
            this.clpLine.Color = System.Drawing.Color.Black;
            this.clpLine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpLine.DropDownHeight = 1;
            this.clpLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpLine.FormattingEnabled = true;
            this.clpLine.IntegralHeight = false;
            this.clpLine.Items.AddRange(new object[] {
            "Color"});
            this.clpLine.Location = new System.Drawing.Point(23, 31);
            this.clpLine.Name = "clpLine";
            this.clpLine.Size = new System.Drawing.Size(60, 21);
            this.clpLine.TabIndex = 105;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(236, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Line width";
            // 
            // icbLineWidth
            // 
            this.icbLineWidth.Color1 = System.Drawing.Color.Gray;
            this.icbLineWidth.Color2 = System.Drawing.Color.Gray;
            this.icbLineWidth.ComboStyle = MW5.Plugins.Symbology.ImageComboStyle.Common;
            this.icbLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbLineWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbLineWidth.FormattingEnabled = true;
            this.icbLineWidth.Location = new System.Drawing.Point(158, 31);
            this.icbLineWidth.Name = "icbLineWidth";
            this.icbLineWidth.OutlineColor = System.Drawing.Color.Black;
            this.icbLineWidth.Size = new System.Drawing.Size(72, 21);
            this.icbLineWidth.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Line color";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Fill color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Point size";
            // 
            // groupPoint
            // 
            this.groupPoint.Controls.Add(this.clpPointFill);
            this.groupPoint.Controls.Add(this.udPointSize);
            this.groupPoint.Controls.Add(this.label8);
            this.groupPoint.Controls.Add(this.label5);
            this.groupPoint.Location = new System.Drawing.Point(644, 25);
            this.groupPoint.Name = "groupPoint";
            this.groupPoint.Size = new System.Drawing.Size(311, 74);
            this.groupPoint.TabIndex = 110;
            this.groupPoint.TabStop = false;
            this.groupPoint.Text = "Options";
            // 
            // clpPointFill
            // 
            this.clpPointFill.Color = System.Drawing.Color.Black;
            this.clpPointFill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpPointFill.DropDownHeight = 1;
            this.clpPointFill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpPointFill.FormattingEnabled = true;
            this.clpPointFill.IntegralHeight = false;
            this.clpPointFill.Items.AddRange(new object[] {
            "Color"});
            this.clpPointFill.Location = new System.Drawing.Point(22, 31);
            this.clpPointFill.Name = "clpPointFill";
            this.clpPointFill.Size = new System.Drawing.Size(58, 21);
            this.clpPointFill.TabIndex = 9;
            // 
            // udPointSize
            // 
            this.udPointSize.Location = new System.Drawing.Point(148, 29);
            this.udPointSize.Name = "udPointSize";
            this.udPointSize.Size = new System.Drawing.Size(56, 20);
            this.udPointSize.TabIndex = 8;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(311, 348);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(96, 25);
            this.btnApply.TabIndex = 111;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRange,
            this.toolStripSeparator3,
            this.btnSaveCategories,
            this.btnLoadCategories,
            this.toolStripSeparator1,
            this.btnCopyFrom,
            this.toolStripSeparator2,
            this.btnClear});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(158, 132);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btnAddRange
            // 
            this.btnAddRange.Name = "btnAddRange";
            this.btnAddRange.Size = new System.Drawing.Size(157, 22);
            this.btnAddRange.Text = "Add range...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(154, 6);
            // 
            // btnSaveCategories
            // 
            this.btnSaveCategories.Name = "btnSaveCategories";
            this.btnSaveCategories.Size = new System.Drawing.Size(157, 22);
            this.btnSaveCategories.Text = "Save categories";
            // 
            // btnLoadCategories
            // 
            this.btnLoadCategories.Name = "btnLoadCategories";
            this.btnLoadCategories.Size = new System.Drawing.Size(157, 22);
            this.btnLoadCategories.Text = "Load categories";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // btnCopyFrom
            // 
            this.btnCopyFrom.Name = "btnCopyFrom";
            this.btnCopyFrom.Size = new System.Drawing.Size(157, 22);
            this.btnCopyFrom.Text = "Copy from";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(157, 22);
            this.btnClear.Text = "Clear";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 114;
            this.button1.Text = "Labels...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(621, 385);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupExpression);
            this.Controls.Add(this.groupPoint);
            this.Controls.Add(this.groupFill);
            this.Controls.Add(this.groupLine);
            this.Controls.Add(this.btnCategoryStyle);
            this.Controls.Add(this.btnCategoryRemove);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnEditExpression);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCategoryMoveDown);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnCategoryMoveUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(470, 350);
            this.Name = "CategoriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shapefile categories";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCategories_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.groupExpression.ResumeLayout(false);
            this.groupExpression.PerformLayout();
            this.groupFill.ResumeLayout(false);
            this.groupFill.PerformLayout();
            this.groupLine.ResumeLayout(false);
            this.groupLine.PerformLayout();
            this.groupPoint.ResumeLayout(false);
            this.groupPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udPointSize)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCategoryRemove;
        private System.Windows.Forms.Button btnCategoryMoveDown;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCategoryMoveUp;
        private System.Windows.Forms.GroupBox groupLine;
        private System.Windows.Forms.Label label6;
        private ImageCombo icbLineWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditExpression;
        private System.Windows.Forms.Button btnCategoryStyle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupPoint;
        private System.Windows.Forms.GroupBox groupFill;
        private Office2007ColorPicker clpLine;
        private Office2007ColorPicker clpPointFill;
        private NumericUpDownEx udPointSize;
        private Office2007ColorPicker clpPolygonFill;
        private ImageCombo icbFillStyle;
        private System.Windows.Forms.GroupBox groupExpression;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Visible;
        private System.Windows.Forms.DataGridViewImageColumn cmnStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSaveCategories;
        private System.Windows.Forms.ToolStripMenuItem btnLoadCategories;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnCopyFrom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        private System.Windows.Forms.ToolStripMenuItem btnAddRange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button button1;
    }
}