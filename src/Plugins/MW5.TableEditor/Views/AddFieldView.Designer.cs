namespace MW5.Plugins.TableEditor.Views
{
    partial class AddFieldView
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
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.fldPrecision = new System.Windows.Forms.NumericUpDown();
            this.fldWidth = new System.Windows.Forms.NumericUpDown();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.cboFieldType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.fldPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWidth.Location = new System.Drawing.Point(25, 114);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(68, 16);
            this.lblWidth.TabIndex = 27;
            this.lblWidth.Text = "Width:";
            // 
            // lblPrecision
            // 
            this.lblPrecision.Enabled = false;
            this.lblPrecision.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPrecision.Location = new System.Drawing.Point(25, 154);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(68, 16);
            this.lblPrecision.TabIndex = 26;
            this.lblPrecision.Text = "Precision";
            // 
            // fldPrecision
            // 
            this.fldPrecision.Enabled = false;
            this.fldPrecision.Location = new System.Drawing.Point(118, 152);
            this.fldPrecision.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.fldPrecision.Name = "fldPrecision";
            this.fldPrecision.Size = new System.Drawing.Size(128, 20);
            this.fldPrecision.TabIndex = 23;
            this.fldPrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // fldWidth
            // 
            this.fldWidth.Location = new System.Drawing.Point(118, 112);
            this.fldWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fldWidth.Name = "fldWidth";
            this.fldWidth.Size = new System.Drawing.Size(128, 20);
            this.fldWidth.TabIndex = 21;
            this.fldWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblType
            // 
            this.lblType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblType.Location = new System.Drawing.Point(25, 74);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(68, 16);
            this.lblType.TabIndex = 22;
            this.lblType.Text = "Type:";
            // 
            // lblName
            // 
            this.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblName.Location = new System.Drawing.Point(25, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 16);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Name:";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(118, 31);
            this.txtFieldName.MaxLength = 10;
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(128, 20);
            this.txtFieldName.TabIndex = 18;
            // 
            // cboFieldType
            // 
            this.cboFieldType.BeforeTouchSize = new System.Drawing.Size(129, 21);
            this.cboFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFieldType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboFieldType.Location = new System.Drawing.Point(117, 69);
            this.cboFieldType.Name = "cboFieldType";
            this.cboFieldType.Size = new System.Drawing.Size(129, 21);
            this.cboFieldType.TabIndex = 28;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(199, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(109, 218);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "Ok";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtFieldName);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.cboFieldType);
            this.groupBox1.Controls.Add(this.fldWidth);
            this.groupBox1.Controls.Add(this.lblWidth);
            this.groupBox1.Controls.Add(this.fldPrecision);
            this.groupBox1.Controls.Add(this.lblPrecision);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 200);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // AddFieldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(294, 250);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "AddFieldView";
            this.Text = "Add New Field";
            ((System.ComponentModel.ISupportInitialize)(this.fldPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblWidth;
        internal System.Windows.Forms.Label lblPrecision;
        internal System.Windows.Forms.NumericUpDown fldPrecision;
        internal System.Windows.Forms.NumericUpDown fldWidth;
        internal System.Windows.Forms.Label lblType;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtFieldName;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboFieldType;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}