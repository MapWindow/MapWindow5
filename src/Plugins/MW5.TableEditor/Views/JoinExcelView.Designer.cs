namespace MW5.Plugins.TableEditor.Views
{
    partial class JoinExcelView
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
            this.btnGetColumns = new System.Windows.Forms.Button();
            this.cboDelimiter = new System.Windows.Forms.ComboBox();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCurrentKeyCol = new System.Windows.Forms.ComboBox();
            this.cboExternalKeyCol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboWorkBooks = new System.Windows.Forms.ComboBox();
            this.lblWorkbook = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetColumns
            // 
            this.btnGetColumns.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGetColumns.Location = new System.Drawing.Point(285, 45);
            this.btnGetColumns.Name = "btnGetColumns";
            this.btnGetColumns.Size = new System.Drawing.Size(75, 23);
            this.btnGetColumns.TabIndex = 35;
            this.btnGetColumns.Text = "Get Columns";
            this.btnGetColumns.UseVisualStyleBackColor = true;
            this.btnGetColumns.Visible = false;
            // 
            // cboDelimiter
            // 
            this.cboDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDelimiter.FormattingEnabled = true;
            this.cboDelimiter.Items.AddRange(new object[] {
            ",",
            "|",
            ";",
            ":",
            "-",
            "=",
            "\'",
            "Tab"});
            this.cboDelimiter.Location = new System.Drawing.Point(78, 47);
            this.cboDelimiter.Name = "cboDelimiter";
            this.cboDelimiter.Size = new System.Drawing.Size(121, 21);
            this.cboDelimiter.TabIndex = 34;
            this.cboDelimiter.Visible = false;
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDelimiter.Location = new System.Drawing.Point(19, 50);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(47, 13);
            this.lblDelimiter.TabIndex = 33;
            this.lblDelimiter.Text = "Delimiter";
            this.lblDelimiter.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboCurrentKeyCol);
            this.groupBox1.Controls.Add(this.cboExternalKeyCol);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(22, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 80);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Key Columns";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(16, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Current";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(177, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "External";
            // 
            // cboCurrentKeyCol
            // 
            this.cboCurrentKeyCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentKeyCol.FormattingEnabled = true;
            this.cboCurrentKeyCol.Location = new System.Drawing.Point(16, 42);
            this.cboCurrentKeyCol.Name = "cboCurrentKeyCol";
            this.cboCurrentKeyCol.Size = new System.Drawing.Size(121, 21);
            this.cboCurrentKeyCol.TabIndex = 8;
            // 
            // cboExternalKeyCol
            // 
            this.cboExternalKeyCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExternalKeyCol.FormattingEnabled = true;
            this.cboExternalKeyCol.Location = new System.Drawing.Point(180, 42);
            this.cboExternalKeyCol.Name = "cboExternalKeyCol";
            this.cboExternalKeyCol.Size = new System.Drawing.Size(121, 21);
            this.cboExternalKeyCol.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(143, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "____";
            // 
            // cboWorkBooks
            // 
            this.cboWorkBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkBooks.FormattingEnabled = true;
            this.cboWorkBooks.Location = new System.Drawing.Point(78, 19);
            this.cboWorkBooks.Name = "cboWorkBooks";
            this.cboWorkBooks.Size = new System.Drawing.Size(121, 21);
            this.cboWorkBooks.TabIndex = 31;
            this.cboWorkBooks.Visible = false;
            // 
            // lblWorkbook
            // 
            this.lblWorkbook.AutoSize = true;
            this.lblWorkbook.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWorkbook.Location = new System.Drawing.Point(15, 22);
            this.lblWorkbook.Name = "lblWorkbook";
            this.lblWorkbook.Size = new System.Drawing.Size(57, 13);
            this.lblWorkbook.TabIndex = 30;
            this.lblWorkbook.Text = "Workbook";
            this.lblWorkbook.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(285, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(204, 167);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "Join";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // JoinExcelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 196);
            this.Controls.Add(this.btnGetColumns);
            this.Controls.Add(this.cboDelimiter);
            this.Controls.Add(this.lblDelimiter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboWorkBooks);
            this.Controls.Add(this.lblWorkbook);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "JoinExcelView";
            this.Text = "Join worksheet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetColumns;
        private System.Windows.Forms.ComboBox cboDelimiter;
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCurrentKeyCol;
        private System.Windows.Forms.ComboBox cboExternalKeyCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWorkBooks;
        private System.Windows.Forms.Label lblWorkbook;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}