namespace MW5.Plugins.TableEditor.Forms
{
    partial class ImportExtDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportExtDataForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.lblWorkbook = new System.Windows.Forms.Label();
            this.cboWorkBooks = new System.Windows.Forms.ComboBox();
            this.cboCurrentKeyCol = new System.Windows.Forms.ComboBox();
            this.cboExternalKeyCol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.cboDelimiter = new System.Windows.Forms.ComboBox();
            this.btnGetColumns = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtInputFile
            // 
            resources.ApplyResources(this.txtInputFile, "txtInputFile");
            this.txtInputFile.Name = "txtInputFile";
            // 
            // btnInputFile
            // 
            resources.ApplyResources(this.btnInputFile, "btnInputFile");
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.UseVisualStyleBackColor = true;
            this.btnInputFile.Click += new System.EventHandler(this.BtnInputFileClick);
            // 
            // lblWorkbook
            // 
            resources.ApplyResources(this.lblWorkbook, "lblWorkbook");
            this.lblWorkbook.Name = "lblWorkbook";
            // 
            // cboWorkBooks
            // 
            this.cboWorkBooks.FormattingEnabled = true;
            resources.ApplyResources(this.cboWorkBooks, "cboWorkBooks");
            this.cboWorkBooks.Name = "cboWorkBooks";
            // 
            // cboCurrentKeyCol
            // 
            this.cboCurrentKeyCol.FormattingEnabled = true;
            resources.ApplyResources(this.cboCurrentKeyCol, "cboCurrentKeyCol");
            this.cboCurrentKeyCol.Name = "cboCurrentKeyCol";
            // 
            // cboExternalKeyCol
            // 
            this.cboExternalKeyCol.FormattingEnabled = true;
            resources.ApplyResources(this.cboExternalKeyCol, "cboExternalKeyCol");
            this.cboExternalKeyCol.Name = "cboExternalKeyCol";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboCurrentKeyCol);
            this.groupBox1.Controls.Add(this.cboExternalKeyCol);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
            // 
            // lblDelimiter
            // 
            resources.ApplyResources(this.lblDelimiter, "lblDelimiter");
            this.lblDelimiter.Name = "lblDelimiter";
            // 
            // cboDelimiter
            // 
            this.cboDelimiter.FormattingEnabled = true;
            this.cboDelimiter.Items.AddRange(new object[] {
            resources.GetString("cboDelimiter.Items"),
            resources.GetString("cboDelimiter.Items1"),
            resources.GetString("cboDelimiter.Items2"),
            resources.GetString("cboDelimiter.Items3"),
            resources.GetString("cboDelimiter.Items4"),
            resources.GetString("cboDelimiter.Items5"),
            resources.GetString("cboDelimiter.Items6"),
            resources.GetString("cboDelimiter.Items7")});
            resources.ApplyResources(this.cboDelimiter, "cboDelimiter");
            this.cboDelimiter.Name = "cboDelimiter";
            // 
            // btnGetColumns
            // 
            resources.ApplyResources(this.btnGetColumns, "btnGetColumns");
            this.btnGetColumns.Name = "btnGetColumns";
            this.btnGetColumns.UseVisualStyleBackColor = true;
            this.btnGetColumns.Click += new System.EventHandler(this.BtnGetColumnsClick);
            // 
            // frmJoinExtData
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.btnGetColumns);
            this.Controls.Add(this.cboDelimiter);
            this.Controls.Add(this.lblDelimiter);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboWorkBooks);
            this.Controls.Add(this.lblWorkbook);
            this.Controls.Add(this.btnInputFile);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmJoinExtData";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Label lblWorkbook;
        private System.Windows.Forms.ComboBox cboWorkBooks;
        private System.Windows.Forms.ComboBox cboCurrentKeyCol;
        private System.Windows.Forms.ComboBox cboExternalKeyCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.ComboBox cboDelimiter;
        private System.Windows.Forms.Button btnGetColumns;
    }
}