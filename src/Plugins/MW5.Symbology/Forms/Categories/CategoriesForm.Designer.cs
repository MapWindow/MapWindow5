using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ColorPicker;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.Visible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmnStyle = new System.Windows.Forms.DataGridViewImageColumn();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnMore = new System.Windows.Forms.Button();
            this.groupExpression = new System.Windows.Forms.GroupBox();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.groupFill = new System.Windows.Forms.GroupBox();
            this.icbFillStyle = new ImageCombo();
            this.clpPolygonFill = new Office2007ColorPicker(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCategoryStyle = new System.Windows.Forms.Button();
            this.btnCategoryRemove = new System.Windows.Forms.Button();
            this.btnEditExpression = new System.Windows.Forms.Button();
            this.btnCategoryMoveDown = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCategoryMoveUp = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnMoreLabels = new System.Windows.Forms.Button();
            this.groupLabelExpression = new System.Windows.Forms.GroupBox();
            this.txtLabelExpression = new System.Windows.Forms.TextBox();
            this.btnLabelOptions = new System.Windows.Forms.Button();
            this.btnLabelExpression = new System.Windows.Forms.Button();
            this.groupLabels = new System.Windows.Forms.GroupBox();
            this.chkFrameVisible = new System.Windows.Forms.CheckBox();
            this.clpFrame = new Office2007ColorPicker(this.components);
            this.udFontSize = new NumericUpDownEx(this.components);
            this.clpFont = new Office2007ColorPicker(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvLabels = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLabelsRemove = new System.Windows.Forms.Button();
            this.btnLabelsMoveDown = new System.Windows.Forms.Button();
            this.btnLabelsGenerate = new System.Windows.Forms.Button();
            this.btnLabelsMoveUp = new System.Windows.Forms.Button();
            this.groupLine = new System.Windows.Forms.GroupBox();
            this.clpLine = new Office2007ColorPicker(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.icbLineWidth = new ImageCombo();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupPoint = new System.Windows.Forms.GroupBox();
            this.clpPointFill = new Office2007ColorPicker(this.components);
            this.udPointSize = new NumericUpDownEx(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupExpression.SuspendLayout();
            this.groupFill.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupLabelExpression.SuspendLayout();
            this.groupLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabels)).BeginInit();
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
            this.dgvCategories.Location = new System.Drawing.Point(6, 6);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowHeadersWidth = 15;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCategories.ShowCellErrors = false;
            this.dgvCategories.Size = new System.Drawing.Size(278, 265);
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
            this.btnOk.Location = new System.Drawing.Point(414, 352);
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
            this.btnCancel.Location = new System.Drawing.Point(516, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 25);
            this.btnCancel.TabIndex = 89;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 343);
            this.tabControl1.TabIndex = 101;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnMore);
            this.tabPage1.Controls.Add(this.groupExpression);
            this.tabPage1.Controls.Add(this.groupFill);
            this.tabPage1.Controls.Add(this.btnCategoryStyle);
            this.tabPage1.Controls.Add(this.btnCategoryRemove);
            this.tabPage1.Controls.Add(this.btnEditExpression);
            this.tabPage1.Controls.Add(this.btnCategoryMoveDown);
            this.tabPage1.Controls.Add(this.btnGenerate);
            this.tabPage1.Controls.Add(this.btnCategoryMoveUp);
            this.tabPage1.Controls.Add(this.dgvCategories);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(602, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Symbology";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(212, 277);
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
            this.groupExpression.Location = new System.Drawing.Point(294, 124);
            this.groupExpression.Name = "groupExpression";
            this.groupExpression.Size = new System.Drawing.Size(299, 146);
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
            this.txtExpression.Size = new System.Drawing.Size(293, 127);
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
            this.groupFill.Location = new System.Drawing.Point(294, 15);
            this.groupFill.Name = "groupFill";
            this.groupFill.Size = new System.Drawing.Size(299, 74);
            this.groupFill.TabIndex = 111;
            this.groupFill.TabStop = false;
            this.groupFill.Text = "Options";
            // 
            // icbFillStyle
            // 
            this.icbFillStyle.Color1 = System.Drawing.Color.Gray;
            this.icbFillStyle.Color2 = System.Drawing.Color.Gray;
            this.icbFillStyle.ColorSchemes = null;
            this.icbFillStyle.ComboStyle = ImageComboStyle.Common;
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
            this.btnCategoryStyle.Location = new System.Drawing.Point(488, 95);
            this.btnCategoryStyle.Name = "btnCategoryStyle";
            this.btnCategoryStyle.Size = new System.Drawing.Size(106, 23);
            this.btnCategoryStyle.TabIndex = 8;
            this.btnCategoryStyle.Text = "More options...";
            this.btnCategoryStyle.UseVisualStyleBackColor = true;
            this.btnCategoryStyle.Click += new System.EventHandler(this.btnCategoryStyle_Click);
            // 
            // btnCategoryRemove
            // 
            this.btnCategoryRemove.Image = Resources.layer_remove;
            this.btnCategoryRemove.Location = new System.Drawing.Point(49, 277);
            this.btnCategoryRemove.Name = "btnCategoryRemove";
            this.btnCategoryRemove.Size = new System.Drawing.Size(32, 32);
            this.btnCategoryRemove.TabIndex = 103;
            this.toolTip1.SetToolTip(this.btnCategoryRemove, "Remove category");
            this.btnCategoryRemove.UseVisualStyleBackColor = true;
            this.btnCategoryRemove.Click += new System.EventHandler(this.btnCategoriesRemove_Click);
            // 
            // btnEditExpression
            // 
            this.btnEditExpression.Location = new System.Drawing.Point(503, 277);
            this.btnEditExpression.Name = "btnEditExpression";
            this.btnEditExpression.Size = new System.Drawing.Size(91, 23);
            this.btnEditExpression.TabIndex = 108;
            this.btnEditExpression.Text = "Edit...";
            this.btnEditExpression.UseVisualStyleBackColor = true;
            this.btnEditExpression.Click += new System.EventHandler(this.btnEditExpression_Click);
            // 
            // btnCategoryMoveDown
            // 
            this.btnCategoryMoveDown.Image = Resources.down;
            this.btnCategoryMoveDown.Location = new System.Drawing.Point(125, 277);
            this.btnCategoryMoveDown.Name = "btnCategoryMoveDown";
            this.btnCategoryMoveDown.Size = new System.Drawing.Size(32, 32);
            this.btnCategoryMoveDown.TabIndex = 105;
            this.btnCategoryMoveDown.UseVisualStyleBackColor = true;
            this.btnCategoryMoveDown.Click += new System.EventHandler(this.btnCategoryMoveDown_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Image = Resources.layer_vector_thematic_add;
            this.btnGenerate.Location = new System.Drawing.Point(6, 277);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(37, 32);
            this.btnGenerate.TabIndex = 100;
            this.toolTip1.SetToolTip(this.btnGenerate, "Generate categories");
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCategoryMoveUp
            // 
            this.btnCategoryMoveUp.Image = Resources.up;
            this.btnCategoryMoveUp.Location = new System.Drawing.Point(87, 277);
            this.btnCategoryMoveUp.Name = "btnCategoryMoveUp";
            this.btnCategoryMoveUp.Size = new System.Drawing.Size(32, 32);
            this.btnCategoryMoveUp.TabIndex = 104;
            this.btnCategoryMoveUp.UseVisualStyleBackColor = true;
            this.btnCategoryMoveUp.Click += new System.EventHandler(this.btnCategoryMoveUp_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnMoreLabels);
            this.tabPage2.Controls.Add(this.groupLabelExpression);
            this.tabPage2.Controls.Add(this.btnLabelOptions);
            this.tabPage2.Controls.Add(this.btnLabelExpression);
            this.tabPage2.Controls.Add(this.groupLabels);
            this.tabPage2.Controls.Add(this.dgvLabels);
            this.tabPage2.Controls.Add(this.btnLabelsRemove);
            this.tabPage2.Controls.Add(this.btnLabelsMoveDown);
            this.tabPage2.Controls.Add(this.btnLabelsGenerate);
            this.tabPage2.Controls.Add(this.btnLabelsMoveUp);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(602, 317);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Labels";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMoreLabels
            // 
            this.btnMoreLabels.Image = Resources.Gear;
            this.btnMoreLabels.Location = new System.Drawing.Point(212, 277);
            this.btnMoreLabels.Name = "btnMoreLabels";
            this.btnMoreLabels.Size = new System.Drawing.Size(72, 32);
            this.btnMoreLabels.TabIndex = 120;
            this.btnMoreLabels.Text = "More...";
            this.btnMoreLabels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMoreLabels.UseVisualStyleBackColor = true;
            this.btnMoreLabels.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // groupLabelExpression
            // 
            this.groupLabelExpression.Controls.Add(this.txtLabelExpression);
            this.groupLabelExpression.Location = new System.Drawing.Point(294, 157);
            this.groupLabelExpression.Name = "groupLabelExpression";
            this.groupLabelExpression.Size = new System.Drawing.Size(299, 113);
            this.groupLabelExpression.TabIndex = 118;
            this.groupLabelExpression.TabStop = false;
            this.groupLabelExpression.Text = "Expression";
            // 
            // txtLabelExpression
            // 
            this.txtLabelExpression.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLabelExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLabelExpression.Location = new System.Drawing.Point(3, 16);
            this.txtLabelExpression.Multiline = true;
            this.txtLabelExpression.Name = "txtLabelExpression";
            this.txtLabelExpression.Size = new System.Drawing.Size(293, 94);
            this.txtLabelExpression.TabIndex = 86;
            this.txtLabelExpression.TextChanged += new System.EventHandler(this.txtExpression_TextChanged);
            this.txtLabelExpression.Validated += new System.EventHandler(this.txtExpression_Validated);
            // 
            // btnLabelOptions
            // 
            this.btnLabelOptions.Location = new System.Drawing.Point(487, 128);
            this.btnLabelOptions.Name = "btnLabelOptions";
            this.btnLabelOptions.Size = new System.Drawing.Size(106, 23);
            this.btnLabelOptions.TabIndex = 112;
            this.btnLabelOptions.Text = "More options...";
            this.btnLabelOptions.UseVisualStyleBackColor = true;
            this.btnLabelOptions.Click += new System.EventHandler(this.btnLabelCategoriesStyle_Click);
            // 
            // btnLabelExpression
            // 
            this.btnLabelExpression.Location = new System.Drawing.Point(503, 277);
            this.btnLabelExpression.Name = "btnLabelExpression";
            this.btnLabelExpression.Size = new System.Drawing.Size(91, 23);
            this.btnLabelExpression.TabIndex = 117;
            this.btnLabelExpression.Text = "Edit...";
            this.btnLabelExpression.UseVisualStyleBackColor = true;
            this.btnLabelExpression.Click += new System.EventHandler(this.btnEditExpression_Click);
            // 
            // groupLabels
            // 
            this.groupLabels.Controls.Add(this.chkFrameVisible);
            this.groupLabels.Controls.Add(this.clpFrame);
            this.groupLabels.Controls.Add(this.udFontSize);
            this.groupLabels.Controls.Add(this.clpFont);
            this.groupLabels.Controls.Add(this.label2);
            this.groupLabels.Controls.Add(this.label3);
            this.groupLabels.Controls.Add(this.label4);
            this.groupLabels.Location = new System.Drawing.Point(294, 15);
            this.groupLabels.Name = "groupLabels";
            this.groupLabels.Size = new System.Drawing.Size(301, 107);
            this.groupLabels.TabIndex = 114;
            this.groupLabels.TabStop = false;
            this.groupLabels.Text = "Options";
            // 
            // chkFrameVisible
            // 
            this.chkFrameVisible.AutoSize = true;
            this.chkFrameVisible.Location = new System.Drawing.Point(158, 69);
            this.chkFrameVisible.Name = "chkFrameVisible";
            this.chkFrameVisible.Size = new System.Drawing.Size(82, 17);
            this.chkFrameVisible.TabIndex = 118;
            this.chkFrameVisible.Text = "Show frame";
            this.chkFrameVisible.UseVisualStyleBackColor = true;
            // 
            // clpFrame
            // 
            this.clpFrame.Color = System.Drawing.Color.White;
            this.clpFrame.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFrame.DropDownHeight = 1;
            this.clpFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFrame.ForeColor = System.Drawing.Color.White;
            this.clpFrame.FormattingEnabled = true;
            this.clpFrame.IntegralHeight = false;
            this.clpFrame.Items.AddRange(new object[] {
            "Color"});
            this.clpFrame.Location = new System.Drawing.Point(158, 29);
            this.clpFrame.Name = "clpFrame";
            this.clpFrame.Size = new System.Drawing.Size(66, 21);
            this.clpFrame.TabIndex = 117;
            // 
            // udFontSize
            // 
            this.udFontSize.Location = new System.Drawing.Point(19, 66);
            this.udFontSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udFontSize.Name = "udFontSize";
            this.udFontSize.Size = new System.Drawing.Size(60, 20);
            this.udFontSize.TabIndex = 116;
            this.udFontSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // clpFont
            // 
            this.clpFont.Color = System.Drawing.Color.White;
            this.clpFont.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.clpFont.DropDownHeight = 1;
            this.clpFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clpFont.ForeColor = System.Drawing.Color.White;
            this.clpFont.FormattingEnabled = true;
            this.clpFont.IntegralHeight = false;
            this.clpFont.Items.AddRange(new object[] {
            "Color"});
            this.clpFont.Location = new System.Drawing.Point(17, 29);
            this.clpFont.Name = "clpFont";
            this.clpFont.Size = new System.Drawing.Size(66, 21);
            this.clpFont.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Font color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Frame color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Font size";
            // 
            // dgvLabels
            // 
            this.dgvLabels.AllowUserToAddRows = false;
            this.dgvLabels.AllowUserToDeleteRows = false;
            this.dgvLabels.AllowUserToResizeRows = false;
            this.dgvLabels.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLabels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLabels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.cmnWidth});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLabels.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLabels.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLabels.Location = new System.Drawing.Point(6, 6);
            this.dgvLabels.Name = "dgvLabels";
            this.dgvLabels.RowHeadersVisible = false;
            this.dgvLabels.RowHeadersWidth = 15;
            this.dgvLabels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLabels.ShowCellErrors = false;
            this.dgvLabels.Size = new System.Drawing.Size(278, 265);
            this.dgvLabels.TabIndex = 103;
            this.dgvLabels.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCategories_CellBeginEdit);
            this.dgvLabels.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLabelCategories_CellDoubleClick);
            this.dgvLabels.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellEndEdit);
            this.dgvLabels.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCategories_CellFormatting);
            this.dgvLabels.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLabelCategories_CellPainting);
            this.dgvLabels.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellValueChanged);
            this.dgvLabels.CurrentCellChanged += new System.EventHandler(this.dgvCategories_CurrentCellChanged);
            this.dgvLabels.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCategories_CurrentCellDirtyStateChanged);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Style";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Count";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 40;
            // 
            // cmnWidth
            // 
            this.cmnWidth.HeaderText = "Column1";
            this.cmnWidth.Name = "cmnWidth";
            this.cmnWidth.Visible = false;
            // 
            // btnLabelsRemove
            // 
            this.btnLabelsRemove.Image = Resources.Minus;
            this.btnLabelsRemove.Location = new System.Drawing.Point(49, 277);
            this.btnLabelsRemove.Name = "btnLabelsRemove";
            this.btnLabelsRemove.Size = new System.Drawing.Size(32, 32);
            this.btnLabelsRemove.TabIndex = 109;
            this.btnLabelsRemove.UseVisualStyleBackColor = true;
            this.btnLabelsRemove.Click += new System.EventHandler(this.btnCategoriesRemove_Click);
            // 
            // btnLabelsMoveDown
            // 
            this.btnLabelsMoveDown.Image = Resources.Arrow2___Down;
            this.btnLabelsMoveDown.Location = new System.Drawing.Point(125, 277);
            this.btnLabelsMoveDown.Name = "btnLabelsMoveDown";
            this.btnLabelsMoveDown.Size = new System.Drawing.Size(32, 32);
            this.btnLabelsMoveDown.TabIndex = 111;
            this.btnLabelsMoveDown.UseVisualStyleBackColor = true;
            this.btnLabelsMoveDown.Click += new System.EventHandler(this.btnCategoryMoveDown_Click);
            // 
            // btnLabelsGenerate
            // 
            this.btnLabelsGenerate.Image = Resources.Plus_orange;
            this.btnLabelsGenerate.Location = new System.Drawing.Point(6, 277);
            this.btnLabelsGenerate.Name = "btnLabelsGenerate";
            this.btnLabelsGenerate.Size = new System.Drawing.Size(37, 32);
            this.btnLabelsGenerate.TabIndex = 106;
            this.btnLabelsGenerate.UseVisualStyleBackColor = true;
            this.btnLabelsGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnLabelsMoveUp
            // 
            this.btnLabelsMoveUp.Image = Resources.Arrow2___Up;
            this.btnLabelsMoveUp.Location = new System.Drawing.Point(87, 277);
            this.btnLabelsMoveUp.Name = "btnLabelsMoveUp";
            this.btnLabelsMoveUp.Size = new System.Drawing.Size(32, 32);
            this.btnLabelsMoveUp.TabIndex = 110;
            this.btnLabelsMoveUp.UseVisualStyleBackColor = true;
            this.btnLabelsMoveUp.Click += new System.EventHandler(this.btnCategoryMoveUp_Click);
            // 
            // groupLine
            // 
            this.groupLine.Controls.Add(this.clpLine);
            this.groupLine.Controls.Add(this.label6);
            this.groupLine.Controls.Add(this.icbLineWidth);
            this.groupLine.Controls.Add(this.label7);
            this.groupLine.Location = new System.Drawing.Point(644, 105);
            this.groupLine.Name = "groupLine";
            this.groupLine.Size = new System.Drawing.Size(299, 74);
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
            this.icbLineWidth.ColorSchemes = null;
            this.icbLineWidth.ComboStyle = ImageComboStyle.Common;
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
            this.groupPoint.Size = new System.Drawing.Size(299, 74);
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
            this.btnApply.Location = new System.Drawing.Point(312, 352);
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
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(619, 385);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupPoint);
            this.Controls.Add(this.groupLine);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupExpression.ResumeLayout(false);
            this.groupExpression.PerformLayout();
            this.groupFill.ResumeLayout(false);
            this.groupFill.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupLabelExpression.ResumeLayout(false);
            this.groupLabelExpression.PerformLayout();
            this.groupLabels.ResumeLayout(false);
            this.groupLabels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabels)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
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
        private System.Windows.Forms.Button btnLabelOptions;
        private System.Windows.Forms.Button btnLabelExpression;
        private System.Windows.Forms.GroupBox groupLabels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLabelsRemove;
        private System.Windows.Forms.Button btnLabelsMoveDown;
        private System.Windows.Forms.Button btnLabelsGenerate;
        private System.Windows.Forms.Button btnLabelsMoveUp;
        private System.Windows.Forms.DataGridView dgvLabels;
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
        private System.Windows.Forms.GroupBox groupLabelExpression;
        private System.Windows.Forms.TextBox txtLabelExpression;
        private NumericUpDownEx udFontSize;
        private Office2007ColorPicker clpFont;
        private Office2007ColorPicker clpFrame;
        private System.Windows.Forms.CheckBox chkFrameVisible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnWidth;
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
        private System.Windows.Forms.Button btnMoreLabels;
        private System.Windows.Forms.ToolStripMenuItem btnAddRange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}