using MW5.Attributes.Controls;

namespace MW5.Attributes.Forms
{
    partial class QueryBuilderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button0 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.chkShowDynamically = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowValues = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkShowValues = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvField = new System.Windows.Forms.DataGridView();
            this.cmnIcon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fieldTypeGrid1 = new FieldTypeGrid();
            this.dgvValues = new System.Windows.Forms.DataGridView();
            this.cmnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTypeGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(121, 198);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(34, 25);
            this.button0.TabIndex = 2;
            this.button0.Tag = "";
            this.button0.Text = ">";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 25);
            this.button1.TabIndex = 3;
            this.button1.Tag = "";
            this.button1.Text = ">=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 25);
            this.button2.TabIndex = 4;
            this.button2.Tag = "";
            this.button2.Text = "<=";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 25);
            this.button3.TabIndex = 5;
            this.button3.Tag = "";
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(157, 198);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 25);
            this.button4.TabIndex = 6;
            this.button4.Tag = "";
            this.button4.Text = "=";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(193, 198);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 25);
            this.button5.TabIndex = 7;
            this.button5.Tag = "";
            this.button5.Text = "<>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(13, 229);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 25);
            this.button6.TabIndex = 8;
            this.button6.Tag = "";
            this.button6.Text = "AND";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(58, 229);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(35, 25);
            this.button7.TabIndex = 9;
            this.button7.Tag = "";
            this.button7.Text = "OR";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(98, 229);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(45, 25);
            this.button8.TabIndex = 10;
            this.button8.Tag = "";
            this.button8.Text = "NOT";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(159, 229);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(18, 25);
            this.button9.TabIndex = 11;
            this.button9.Tag = "";
            this.button9.Text = "(";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(183, 229);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(19, 25);
            this.button10.TabIndex = 12;
            this.button10.Tag = "";
            this.button10.Text = ")";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(458, 110);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(342, 232);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(67, 25);
            this.btnTest.TabIndex = 20;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(382, 421);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 26);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(280, 421);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 26);
            this.btnOk.TabIndex = 25;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(14, 399);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(461, 19);
            this.lblResult.TabIndex = 26;
            this.lblResult.Text = "Results";
            // 
            // chkShowDynamically
            // 
            this.chkShowDynamically.AutoSize = true;
            this.chkShowDynamically.Location = new System.Drawing.Point(18, 427);
            this.chkShowDynamically.Name = "chkShowDynamically";
            this.chkShowDynamically.Size = new System.Drawing.Size(106, 17);
            this.chkShowDynamically.TabIndex = 28;
            this.chkShowDynamically.Text = "Update selection";
            this.chkShowDynamically.UseVisualStyleBackColor = true;
            this.chkShowDynamically.CheckedChanged += new System.EventHandler(this.chkShowDynamically_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(15, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(464, 129);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SELECT * FROM [LayerName] WHERE ";
            // 
            // btnShowValues
            // 
            this.btnShowValues.Location = new System.Drawing.Point(382, 198);
            this.btnShowValues.Name = "btnShowValues";
            this.btnShowValues.Size = new System.Drawing.Size(95, 25);
            this.btnShowValues.TabIndex = 32;
            this.btnShowValues.Text = "Get values";
            this.btnShowValues.UseVisualStyleBackColor = true;
            this.btnShowValues.Click += new System.EventHandler(this.btnShowValues_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(415, 231);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 26);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkShowValues
            // 
            this.chkShowValues.AutoSize = true;
            this.chkShowValues.Location = new System.Drawing.Point(130, 427);
            this.chkShowValues.Name = "chkShowValues";
            this.chkShowValues.Size = new System.Drawing.Size(87, 17);
            this.chkShowValues.TabIndex = 34;
            this.chkShowValues.Text = "Show values";
            this.chkShowValues.UseVisualStyleBackColor = true;
            this.chkShowValues.CheckedChanged += new System.EventHandler(this.chkShowValues_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Fields";
            // 
            // dgvField
            // 
            this.dgvField.AllowUserToAddRows = false;
            this.dgvField.AllowUserToDeleteRows = false;
            this.dgvField.AllowUserToResizeColumns = false;
            this.dgvField.AllowUserToResizeRows = false;
            this.dgvField.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvField.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvField.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvField.ColumnHeadersVisible = false;
            this.dgvField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnIcon,
            this.cmnName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvField.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvField.Location = new System.Drawing.Point(3, 16);
            this.dgvField.MultiSelect = false;
            this.dgvField.Name = "dgvField";
            this.dgvField.ReadOnly = true;
            this.dgvField.RowHeadersVisible = false;
            this.dgvField.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvField.Size = new System.Drawing.Size(184, 158);
            this.dgvField.TabIndex = 1;
            this.dgvField.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvField_CellClick);
            this.dgvField.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvField_CellDoubleClick);
            // 
            // cmnIcon
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmnIcon.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmnIcon.HeaderText = "Icon";
            this.cmnIcon.MinimumWidth = 30;
            this.cmnIcon.Name = "cmnIcon";
            this.cmnIcon.ReadOnly = true;
            this.cmnIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmnIcon.Width = 30;
            // 
            // cmnName
            // 
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.cmnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmnName.HeaderText = "Name";
            this.cmnName.MinimumWidth = 100;
            this.cmnName.Name = "cmnName";
            this.cmnName.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvField);
            this.groupBox1.Location = new System.Drawing.Point(15, 450);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 177);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fields";
            // 
            // fieldTypeGrid1
            // 
            this.fieldTypeGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldTypeGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldTypeGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldTypeGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.fieldTypeGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.fieldTypeGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.fieldTypeGrid1.FreezeCaption = false;
            this.fieldTypeGrid1.Location = new System.Drawing.Point(13, 28);
            this.fieldTypeGrid1.Name = "fieldTypeGrid1";
            this.fieldTypeGrid1.Size = new System.Drawing.Size(189, 158);
            this.fieldTypeGrid1.TabIndex = 2;
            this.fieldTypeGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.fieldTypeGrid1.TableOptions.AllowDropDownCell = true;
            this.fieldTypeGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.fieldTypeGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.fieldTypeGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.fieldTypeGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.fieldTypeGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.fieldTypeGrid1.Text = "fieldTypeGrid1";
            this.fieldTypeGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.fieldTypeGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.fieldTypeGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.fieldTypeGrid1.VersionInfo = "0.0.1.0";
            this.fieldTypeGrid1.WrapWithPanel = true;
            // 
            // dgvValues
            // 
            this.dgvValues.AllowUserToAddRows = false;
            this.dgvValues.AllowUserToDeleteRows = false;
            this.dgvValues.AllowUserToResizeColumns = false;
            this.dgvValues.AllowUserToResizeRows = false;
            this.dgvValues.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvValues.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvValues.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValues.ColumnHeadersVisible = false;
            this.dgvValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnCount,
            this.cmnValue});
            this.dgvValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValues.Location = new System.Drawing.Point(3, 16);
            this.dgvValues.MultiSelect = false;
            this.dgvValues.Name = "dgvValues";
            this.dgvValues.ReadOnly = true;
            this.dgvValues.RowHeadersVisible = false;
            this.dgvValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValues.Size = new System.Drawing.Size(262, 158);
            this.dgvValues.TabIndex = 24;
            this.dgvValues.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValues_CellDoubleClick);
            this.dgvValues.SelectionChanged += new System.EventHandler(this.dgvValues_SelectionChanged);
            // 
            // cmnValue
            // 
            this.cmnValue.HeaderText = "Value";
            this.cmnValue.Name = "cmnValue";
            this.cmnValue.ReadOnly = true;
            // 
            // cmnCount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.cmnCount.DefaultCellStyle = dataGridViewCellStyle4;
            this.cmnCount.HeaderText = "Count";
            this.cmnCount.Name = "cmnCount";
            this.cmnCount.ReadOnly = true;
            this.cmnCount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmnCount.Width = 35;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvValues);
            this.groupBox2.Location = new System.Drawing.Point(208, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 177);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Values";
            // 
            // QueryBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(487, 454);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fieldTypeGrid1);
            this.Controls.Add(this.chkShowValues);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnShowValues);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.chkShowDynamically);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryBuilderForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query builder";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvField)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fieldTypeGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValues)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.CheckBox chkShowDynamically;
        private System.Windows.Forms.Button btnShowValues;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkShowValues;
        private FieldTypeGrid fieldTypeGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvField;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvValues;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnValue;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}