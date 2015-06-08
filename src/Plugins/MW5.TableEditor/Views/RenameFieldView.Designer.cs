namespace MW5.Plugins.TableEditor.Views
{
    partial class RenameFieldView
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
            this.Label2 = new System.Windows.Forms.Label();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(25, 89);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(100, 16);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "New name:";
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(25, 108);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(212, 20);
            this.txtNewName.TabIndex = 16;
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.Location = new System.Drawing.Point(25, 53);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(212, 21);
            this.cboField.TabIndex = 13;
            // 
            // Label1
            // 
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(25, 34);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 16);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "Field to rename:";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(188, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(98, 174);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 33;
            this.btnOk.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.cboField);
            this.groupBox1.Controls.Add(this.txtNewName);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 156);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // RenameFieldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(285, 205);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "RenameFieldView";
            this.Text = "Rename Field";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtNewName;
        internal System.Windows.Forms.ComboBox cboField;
        internal System.Windows.Forms.Label Label1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}