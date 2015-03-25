namespace MW5.Plugins.TableEditor.Forms
{
    partial class NewFieldForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFieldForm));
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblPrecision = new System.Windows.Forms.Label();
            this.fldPrecision = new System.Windows.Forms.NumericUpDown();
            this.fldWidth = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbFieldType = new System.Windows.Forms.ComboBox();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fldPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWidth
            // 
            resources.ApplyResources(this.lblWidth, "lblWidth");
            this.lblWidth.Name = "lblWidth";
            // 
            // lblPrecision
            // 
            resources.ApplyResources(this.lblPrecision, "lblPrecision");
            this.lblPrecision.Name = "lblPrecision";
            // 
            // fldPrecision
            // 
            resources.ApplyResources(this.fldPrecision, "fldPrecision");
            this.fldPrecision.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.fldPrecision.Name = "fldPrecision";
            this.fldPrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // fldWidth
            // 
            resources.ApplyResources(this.fldWidth, "fldWidth");
            this.fldWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fldWidth.Name = "fldWidth";
            this.fldWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // cmbFieldType
            // 
            this.cmbFieldType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFieldType.Items.AddRange(new object[] {
            resources.GetString("cmbFieldType.Items"),
            resources.GetString("cmbFieldType.Items1"),
            resources.GetString("cmbFieldType.Items2")});
            resources.ApplyResources(this.cmbFieldType, "cmbFieldType");
            this.cmbFieldType.Name = "cmbFieldType";
            this.cmbFieldType.SelectedIndexChanged += new System.EventHandler(this.cmbFieldType_SelectedIndexChanged);
            // 
            // txtFieldName
            // 
            resources.ApplyResources(this.txtFieldName, "txtFieldName");
            this.txtFieldName.Name = "txtFieldName";
            // 
            // frmNewField
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblPrecision);
            this.Controls.Add(this.fldPrecision);
            this.Controls.Add(this.fldWidth);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmbFieldType);
            this.Controls.Add(this.txtFieldName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewFieldForm";
            ((System.ComponentModel.ISupportInitialize)(this.fldPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldWidth)).EndInit();
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
        internal System.Windows.Forms.ComboBox cmbFieldType;
        internal System.Windows.Forms.TextBox txtFieldName;
    }
}