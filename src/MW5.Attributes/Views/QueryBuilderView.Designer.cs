using MW5.Attributes.Controls;

namespace MW5.Attributes.Views
{
    partial class QueryBuilderView
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
            this.btnRun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.valueCountGrid1 = new MW5.Attributes.Controls.ValueCountGrid();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldTypeGrid1 = new MW5.Attributes.Controls.FieldTypeGrid();
            this.chkShowValues = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnShowValues = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.lblValidation = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblSelect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.valueCountGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTypeGrid1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(409, 324);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(67, 25);
            this.btnRun.TabIndex = 64;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Values";
            // 
            // valueCountGrid1
            // 
            this.valueCountGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.valueCountGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.valueCountGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.valueCountGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.valueCountGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.valueCountGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.valueCountGrid1.FreezeCaption = false;
            this.valueCountGrid1.Location = new System.Drawing.Point(185, 27);
            this.valueCountGrid1.Name = "valueCountGrid1";
            this.valueCountGrid1.Size = new System.Drawing.Size(291, 158);
            this.valueCountGrid1.TabIndex = 62;
            this.valueCountGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.valueCountGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.valueCountGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.valueCountGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.valueCountGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.valueCountGrid1.Text = "valueCountGrid1";
            this.valueCountGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.valueCountGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.valueCountGrid1.TopLevelGroupOptions.ShowColumnHeaders = false;
            this.valueCountGrid1.VersionInfo = "5.0.1.0";
            this.valueCountGrid1.WrapWithPanel = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(222, 228);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(20, 25);
            this.button13.TabIndex = 61;
            this.button13.Tag = "";
            this.button13.Text = "_";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(196, 228);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(20, 25);
            this.button12.TabIndex = 60;
            this.button12.Tag = "";
            this.button12.Text = "%";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(145, 228);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(45, 25);
            this.button11.TabIndex = 59;
            this.button11.Tag = "";
            this.button11.Text = "LIKE";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 58;
            this.label1.Text = "Fields";
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
            this.fieldTypeGrid1.Location = new System.Drawing.Point(12, 27);
            this.fieldTypeGrid1.Name = "fieldTypeGrid1";
            this.fieldTypeGrid1.Size = new System.Drawing.Size(167, 158);
            this.fieldTypeGrid1.TabIndex = 36;
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
            // chkShowValues
            // 
            this.chkShowValues.AutoSize = true;
            this.chkShowValues.Location = new System.Drawing.Point(16, 426);
            this.chkShowValues.Name = "chkShowValues";
            this.chkShowValues.Size = new System.Drawing.Size(87, 17);
            this.chkShowValues.TabIndex = 57;
            this.chkShowValues.Text = "Show values";
            this.chkShowValues.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(409, 355);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(67, 25);
            this.btnClear.TabIndex = 56;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.OnClearClicked);
            // 
            // btnShowValues
            // 
            this.btnShowValues.Location = new System.Drawing.Point(381, 197);
            this.btnShowValues.Name = "btnShowValues";
            this.btnShowValues.Size = new System.Drawing.Size(95, 25);
            this.btnShowValues.TabIndex = 55;
            this.btnShowValues.Text = "Get values";
            this.btnShowValues.UseVisualStyleBackColor = true;
            this.btnShowValues.Click += new System.EventHandler(this.OnShowValuesClicked);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(260, 197);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(19, 25);
            this.button10.TabIndex = 47;
            this.button10.Tag = "";
            this.button10.Text = ")";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(409, 293);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(67, 25);
            this.btnTest.TabIndex = 48;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(97, 228);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(45, 25);
            this.button8.TabIndex = 45;
            this.button8.Tag = "";
            this.button8.Text = "NOT";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // lblValidation
            // 
            this.lblValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblValidation.Location = new System.Drawing.Point(13, 398);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(461, 19);
            this.lblValidation.TabIndex = 51;
            this.lblValidation.Text = "Results";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(57, 228);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(35, 25);
            this.button7.TabIndex = 44;
            this.button7.Tag = "";
            this.button7.Text = "OR";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(14, 283);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 112);
            this.groupBox3.TabIndex = 54;
            this.groupBox3.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(383, 93);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(236, 197);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(18, 25);
            this.button9.TabIndex = 46;
            this.button9.Tag = "";
            this.button9.Text = "(";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 228);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(39, 25);
            this.button6.TabIndex = 43;
            this.button6.Tag = "";
            this.button6.Text = "AND";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(192, 197);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 25);
            this.button5.TabIndex = 42;
            this.button5.Tag = "";
            this.button5.Text = "<>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(279, 420);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(95, 26);
            this.btnOk.TabIndex = 50;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 197);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 25);
            this.button3.TabIndex = 40;
            this.button3.Tag = "";
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(156, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 25);
            this.button4.TabIndex = 41;
            this.button4.Tag = "";
            this.button4.Text = "=";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(381, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 26);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 25);
            this.button2.TabIndex = 39;
            this.button2.Tag = "";
            this.button2.Text = "<=";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(120, 197);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(34, 25);
            this.button0.TabIndex = 37;
            this.button0.Tag = "";
            this.button0.Text = ">";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 25);
            this.button1.TabIndex = 38;
            this.button1.Tag = "";
            this.button1.Text = ">=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnOperatorClick);
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(14, 267);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(199, 13);
            this.lblSelect.TabIndex = 65;
            this.lblSelect.Text = "SELECT * FROM [LayerName] WHERE ";
            // 
            // QueryBuilderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 456);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valueCountGrid1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fieldTypeGrid1);
            this.Controls.Add(this.chkShowValues);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnShowValues);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button1);
            this.Name = "QueryBuilderView";
            this.Text = "Build Query";
            ((System.ComponentModel.ISupportInitialize)(this.valueCountGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTypeGrid1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.FieldTypeGrid fieldTypeGrid1;
        private System.Windows.Forms.CheckBox chkShowValues;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnShowValues;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label lblValidation;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private Controls.ValueCountGrid valueCountGrid1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblSelect;
    }
}