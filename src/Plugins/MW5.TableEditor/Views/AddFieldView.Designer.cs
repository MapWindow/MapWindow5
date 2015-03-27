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
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.fldPrecision = new System.Windows.Forms.NumericUpDown();
            this.fldWidth = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.cboFieldType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.fldPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            this.lblWidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWidth.Location = new System.Drawing.Point(24, 105);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(68, 16);
            this.lblWidth.TabIndex = 27;
            this.lblWidth.Text = "Width:";
            // 
            // lblPrecision
            // 
            this.lblPrecision.Enabled = false;
            this.lblPrecision.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPrecision.Location = new System.Drawing.Point(24, 145);
            this.lblPrecision.Name = "lblPrecision";
            this.lblPrecision.Size = new System.Drawing.Size(68, 16);
            this.lblPrecision.TabIndex = 26;
            this.lblPrecision.Text = "Precision";
            // 
            // fldPrecision
            // 
            this.fldPrecision.Enabled = false;
            this.fldPrecision.Location = new System.Drawing.Point(117, 143);
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
            this.fldWidth.Location = new System.Drawing.Point(117, 103);
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
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(197, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(116, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            // 
            // lblType
            // 
            this.lblType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblType.Location = new System.Drawing.Point(24, 65);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(68, 16);
            this.lblType.TabIndex = 22;
            this.lblType.Text = "Type:";
            // 
            // lblName
            // 
            this.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblName.Location = new System.Drawing.Point(24, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 16);
            this.lblName.TabIndex = 20;
            this.lblName.Text = "Name:";
            // 
            // txtFieldName
            // 
            this.txtFieldName.Location = new System.Drawing.Point(117, 22);
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
            this.cboFieldType.Location = new System.Drawing.Point(116, 60);
            this.cboFieldType.Name = "cboFieldType";
            this.cboFieldType.Size = new System.Drawing.Size(129, 21);
            this.cboFieldType.TabIndex = 28;
            // 
            // AddFieldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 221);
            this.Controls.Add(this.cboFieldType);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblPrecision);
            this.Controls.Add(this.fldPrecision);
            this.Controls.Add(this.fldWidth);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtFieldName);
            this.Name = "AddFieldView";
            this.Text = "Add New Field";
            ((System.ComponentModel.ISupportInitialize)(this.fldPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFieldType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblWidth;
        internal System.Windows.Forms.Label lblPrecision;
        internal System.Windows.Forms.NumericUpDown fldPrecision;
        internal System.Windows.Forms.NumericUpDown fldWidth;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lblType;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtFieldName;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboFieldType;
    }
}