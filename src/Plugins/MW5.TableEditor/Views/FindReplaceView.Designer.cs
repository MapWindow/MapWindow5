namespace MW5.Plugins.TableEditor.Views
{
    partial class FindReplaceView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMatch = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.btnFind = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.lblReplaceWith = new System.Windows.Forms.Label();
            this.cboFind = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cboReplace = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnReplace = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnReplaceAll = new Syncfusion.Windows.Forms.ButtonAdv();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFields = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.cboMatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReplace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFields)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Match type";
            // 
            // cboMatch
            // 
            this.cboMatch.BeforeTouchSize = new System.Drawing.Size(122, 21);
            this.cboMatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboMatch.Location = new System.Drawing.Point(93, 10);
            this.cboMatch.Name = "cboMatch";
            this.cboMatch.Size = new System.Drawing.Size(122, 21);
            this.cboMatch.TabIndex = 2;
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Location = new System.Drawing.Point(227, 13);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(82, 17);
            this.chkCaseSensitive.TabIndex = 3;
            this.chkCaseSensitive.Text = "Match case";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnFind.IsBackStageButton = false;
            this.btnFind.Location = new System.Drawing.Point(340, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(90, 26);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Find next (F3)";
            // 
            // btnClose
            // 
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(340, 44);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 26);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            // 
            // lblReplaceWith
            // 
            this.lblReplaceWith.AutoSize = true;
            this.lblReplaceWith.Location = new System.Drawing.Point(14, 48);
            this.lblReplaceWith.Name = "lblReplaceWith";
            this.lblReplaceWith.Size = new System.Drawing.Size(69, 13);
            this.lblReplaceWith.TabIndex = 10;
            this.lblReplaceWith.Text = "Replace with";
            // 
            // cboFind
            // 
            this.cboFind.BeforeTouchSize = new System.Drawing.Size(226, 21);
            this.cboFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboFind.Location = new System.Drawing.Point(99, 12);
            this.cboFind.Name = "cboFind";
            this.cboFind.Size = new System.Drawing.Size(226, 21);
            this.cboFind.TabIndex = 0;
            // 
            // cboReplace
            // 
            this.cboReplace.BeforeTouchSize = new System.Drawing.Size(226, 21);
            this.cboReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboReplace.Location = new System.Drawing.Point(99, 44);
            this.cboReplace.Name = "cboReplace";
            this.cboReplace.Size = new System.Drawing.Size(226, 21);
            this.cboReplace.TabIndex = 1;
            // 
            // btnReplace
            // 
            this.btnReplace.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnReplace.IsBackStageButton = false;
            this.btnReplace.Location = new System.Drawing.Point(340, 76);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(90, 26);
            this.btnReplace.TabIndex = 8;
            this.btnReplace.Text = "Replace";
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnReplaceAll.IsBackStageButton = false;
            this.btnReplaceAll.Location = new System.Drawing.Point(340, 108);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(90, 26);
            this.btnReplaceAll.TabIndex = 9;
            this.btnReplaceAll.Text = "Replace all";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Field";
            // 
            // cboFields
            // 
            this.cboFields.BeforeTouchSize = new System.Drawing.Size(122, 21);
            this.cboFields.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboFields.Location = new System.Drawing.Point(93, 46);
            this.cboFields.Name = "cboFields";
            this.cboFields.Size = new System.Drawing.Size(122, 21);
            this.cboFields.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboFields);
            this.panel1.Controls.Add(this.chkCaseSensitive);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboMatch);
            this.panel1.Location = new System.Drawing.Point(6, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 77);
            this.panel1.TabIndex = 13;
            // 
            // FindReplaceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(437, 153);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.cboFind);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboReplace);
            this.Controls.Add(this.lblReplaceWith);
            this.Name = "FindReplaceView";
            this.Text = "Find and Replace";
            ((System.ComponentModel.ISupportInitialize)(this.cboMatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboReplace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFields)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboMatch;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private Syncfusion.Windows.Forms.ButtonAdv btnFind;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private System.Windows.Forms.Label lblReplaceWith;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboFind;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboReplace;
        private Syncfusion.Windows.Forms.ButtonAdv btnReplace;
        private Syncfusion.Windows.Forms.ButtonAdv btnReplaceAll;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboFields;
        private System.Windows.Forms.Panel panel1;
    }
}