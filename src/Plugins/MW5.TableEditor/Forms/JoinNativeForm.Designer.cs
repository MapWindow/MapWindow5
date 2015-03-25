namespace MW5.Plugins.TableEditor.Forms
{
    partial class JoinNativeForm
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
            this.btnInputFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCurrent = new System.Windows.Forms.ComboBox();
            this.cboExternal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lblMatchJoin = new System.Windows.Forms.Label();
            this.lblMatch = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInputFile
            // 
            this.btnInputFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInputFile.Location = new System.Drawing.Point(514, 21);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(29, 23);
            this.btnInputFile.TabIndex = 7;
            this.btnInputFile.Text = "...";
            this.btnInputFile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(451, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Inputfile";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMatch);
            this.groupBox1.Controls.Add(this.lblMatchJoin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboCurrent);
            this.groupBox1.Controls.Add(this.cboExternal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 92);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Key Columns";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(28, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Current";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(189, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "External";
            // 
            // cboCurrent
            // 
            this.cboCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrent.FormattingEnabled = true;
            this.cboCurrent.Location = new System.Drawing.Point(19, 42);
            this.cboCurrent.Name = "cboCurrent";
            this.cboCurrent.Size = new System.Drawing.Size(130, 21);
            this.cboCurrent.TabIndex = 8;
            this.cboCurrent.SelectedIndexChanged += new System.EventHandler(this.cboCurrent_SelectedIndexChanged);
            // 
            // cboExternal
            // 
            this.cboExternal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExternal.FormattingEnabled = true;
            this.cboExternal.Location = new System.Drawing.Point(192, 42);
            this.cboExternal.Name = "cboExternal";
            this.cboExternal.Size = new System.Drawing.Size(130, 21);
            this.cboExternal.TabIndex = 9;
            this.cboExternal.SelectedIndexChanged += new System.EventHandler(this.cboExternal_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(155, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "____";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(282, 271);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(201, 271);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Join";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(9, 116);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(348, 149);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(11, 275);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(99, 17);
            this.chkAll.TabIndex = 16;
            this.chkAll.Text = "Check all/none";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lblMatchJoin
            // 
            this.lblMatchJoin.AutoSize = true;
            this.lblMatchJoin.Location = new System.Drawing.Point(189, 66);
            this.lblMatchJoin.Name = "lblMatchJoin";
            this.lblMatchJoin.Size = new System.Drawing.Size(79, 13);
            this.lblMatchJoin.TabIndex = 13;
            this.lblMatchJoin.Text = "Matching rows:";
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.Location = new System.Drawing.Point(20, 66);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(79, 13);
            this.lblMatch.TabIndex = 14;
            this.lblMatch.Text = "Matching rows:";
            // 
            // frmNativeJoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(369, 303);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInputFile);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNativeJoin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Native join";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCurrent;
        private System.Windows.Forms.ComboBox cboExternal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.Label lblMatchJoin;
    }
}