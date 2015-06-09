using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Views
{
    partial class UpdateMeasurementsView
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
            this.groupArea = new System.Windows.Forms.GroupBox();
            this.optAreaIgnore = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboAreaUnits = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label1 = new System.Windows.Forms.Label();
            this.udAreaWidth = new System.Windows.Forms.NumericUpDown();
            this.udAreaPrecision = new System.Windows.Forms.NumericUpDown();
            this.txtAreaField = new System.Windows.Forms.TextBox();
            this.cboAreaField = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.optAreaNew = new System.Windows.Forms.RadioButton();
            this.optAreaExisting = new System.Windows.Forms.RadioButton();
            this.groupLength = new System.Windows.Forms.GroupBox();
            this.optLengthIgnore = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cboLengthUnits = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.udLengthWidth = new System.Windows.Forms.NumericUpDown();
            this.udLengthPrecision = new System.Windows.Forms.NumericUpDown();
            this.txtLengthField = new System.Windows.Forms.TextBox();
            this.cboLengthField = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.optLengthNew = new System.Windows.Forms.RadioButton();
            this.optLengthExisting = new System.Windows.Forms.RadioButton();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.groupArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAreaWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAreaPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaField)).BeginInit();
            this.groupLength.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLengthUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLengthWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLengthPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLengthField)).BeginInit();
            this.SuspendLayout();
            // 
            // groupArea
            // 
            this.groupArea.Controls.Add(this.optAreaIgnore);
            this.groupArea.Controls.Add(this.pictureBox1);
            this.groupArea.Controls.Add(this.cboAreaUnits);
            this.groupArea.Controls.Add(this.label1);
            this.groupArea.Controls.Add(this.udAreaWidth);
            this.groupArea.Controls.Add(this.udAreaPrecision);
            this.groupArea.Controls.Add(this.txtAreaField);
            this.groupArea.Controls.Add(this.cboAreaField);
            this.groupArea.Controls.Add(this.optAreaNew);
            this.groupArea.Controls.Add(this.optAreaExisting);
            this.groupArea.Location = new System.Drawing.Point(8, 186);
            this.groupArea.Name = "groupArea";
            this.groupArea.Size = new System.Drawing.Size(364, 180);
            this.groupArea.TabIndex = 2;
            this.groupArea.TabStop = false;
            this.groupArea.Text = "Area";
            // 
            // optAreaIgnore
            // 
            this.optAreaIgnore.AutoSize = true;
            this.optAreaIgnore.Checked = true;
            this.optAreaIgnore.Location = new System.Drawing.Point(22, 30);
            this.optAreaIgnore.Name = "optAreaIgnore";
            this.optAreaIgnore.Size = new System.Drawing.Size(96, 17);
            this.optAreaIgnore.TabIndex = 38;
            this.optAreaIgnore.TabStop = true;
            this.optAreaIgnore.Text = "Don\'t calculate";
            this.optAreaIgnore.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MW5.Plugins.TableEditor.Properties.Resources.img_geometry;
            this.pictureBox1.Location = new System.Drawing.Point(73, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // cboAreaUnits
            // 
            this.cboAreaUnits.BeforeTouchSize = new System.Drawing.Size(220, 21);
            this.cboAreaUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreaUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboAreaUnits.Location = new System.Drawing.Point(115, 139);
            this.cboAreaUnits.Name = "cboAreaUnits";
            this.cboAreaUnits.Size = new System.Drawing.Size(220, 21);
            this.cboAreaUnits.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Units";
            // 
            // udAreaWidth
            // 
            this.udAreaWidth.Location = new System.Drawing.Point(253, 100);
            this.udAreaWidth.Name = "udAreaWidth";
            this.udAreaWidth.Size = new System.Drawing.Size(44, 20);
            this.udAreaWidth.TabIndex = 6;
            this.udAreaWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // udAreaPrecision
            // 
            this.udAreaPrecision.Location = new System.Drawing.Point(303, 100);
            this.udAreaPrecision.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udAreaPrecision.Name = "udAreaPrecision";
            this.udAreaPrecision.Size = new System.Drawing.Size(32, 20);
            this.udAreaPrecision.TabIndex = 5;
            this.udAreaPrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtAreaField
            // 
            this.txtAreaField.Location = new System.Drawing.Point(115, 100);
            this.txtAreaField.Name = "txtAreaField";
            this.txtAreaField.Size = new System.Drawing.Size(132, 20);
            this.txtAreaField.TabIndex = 4;
            this.txtAreaField.Text = "Area";
            // 
            // cboAreaField
            // 
            this.cboAreaField.BeforeTouchSize = new System.Drawing.Size(220, 21);
            this.cboAreaField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAreaField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboAreaField.Location = new System.Drawing.Point(115, 64);
            this.cboAreaField.Name = "cboAreaField";
            this.cboAreaField.Size = new System.Drawing.Size(220, 21);
            this.cboAreaField.TabIndex = 3;
            // 
            // optAreaNew
            // 
            this.optAreaNew.AutoSize = true;
            this.optAreaNew.Location = new System.Drawing.Point(22, 101);
            this.optAreaNew.Name = "optAreaNew";
            this.optAreaNew.Size = new System.Drawing.Size(75, 17);
            this.optAreaNew.TabIndex = 1;
            this.optAreaNew.Text = "New field: ";
            this.optAreaNew.UseVisualStyleBackColor = true;
            // 
            // optAreaExisting
            // 
            this.optAreaExisting.AutoSize = true;
            this.optAreaExisting.Location = new System.Drawing.Point(22, 65);
            this.optAreaExisting.Name = "optAreaExisting";
            this.optAreaExisting.Size = new System.Drawing.Size(86, 17);
            this.optAreaExisting.TabIndex = 0;
            this.optAreaExisting.Text = "Existing field:";
            this.optAreaExisting.UseVisualStyleBackColor = true;
            // 
            // groupLength
            // 
            this.groupLength.Controls.Add(this.optLengthIgnore);
            this.groupLength.Controls.Add(this.pictureBox2);
            this.groupLength.Controls.Add(this.cboLengthUnits);
            this.groupLength.Controls.Add(this.label2);
            this.groupLength.Controls.Add(this.udLengthWidth);
            this.groupLength.Controls.Add(this.udLengthPrecision);
            this.groupLength.Controls.Add(this.txtLengthField);
            this.groupLength.Controls.Add(this.cboLengthField);
            this.groupLength.Controls.Add(this.optLengthNew);
            this.groupLength.Controls.Add(this.optLengthExisting);
            this.groupLength.Location = new System.Drawing.Point(8, 2);
            this.groupLength.Name = "groupLength";
            this.groupLength.Size = new System.Drawing.Size(364, 178);
            this.groupLength.TabIndex = 3;
            this.groupLength.TabStop = false;
            this.groupLength.Text = "Length";
            // 
            // optLengthIgnore
            // 
            this.optLengthIgnore.AutoSize = true;
            this.optLengthIgnore.Checked = true;
            this.optLengthIgnore.Location = new System.Drawing.Point(23, 28);
            this.optLengthIgnore.Name = "optLengthIgnore";
            this.optLengthIgnore.Size = new System.Drawing.Size(96, 17);
            this.optLengthIgnore.TabIndex = 39;
            this.optLengthIgnore.TabStop = true;
            this.optLengthIgnore.Text = "Don\'t calculate";
            this.optLengthIgnore.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MW5.Plugins.TableEditor.Properties.Resources.img_line;
            this.pictureBox2.Location = new System.Drawing.Point(86, 132);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // cboLengthUnits
            // 
            this.cboLengthUnits.BeforeTouchSize = new System.Drawing.Size(220, 21);
            this.cboLengthUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLengthUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboLengthUnits.Location = new System.Drawing.Point(116, 135);
            this.cboLengthUnits.Name = "cboLengthUnits";
            this.cboLengthUnits.Size = new System.Drawing.Size(220, 21);
            this.cboLengthUnits.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Units";
            // 
            // udLengthWidth
            // 
            this.udLengthWidth.Location = new System.Drawing.Point(254, 97);
            this.udLengthWidth.Name = "udLengthWidth";
            this.udLengthWidth.Size = new System.Drawing.Size(44, 20);
            this.udLengthWidth.TabIndex = 6;
            this.udLengthWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // udLengthPrecision
            // 
            this.udLengthPrecision.Location = new System.Drawing.Point(304, 97);
            this.udLengthPrecision.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.udLengthPrecision.Name = "udLengthPrecision";
            this.udLengthPrecision.Size = new System.Drawing.Size(32, 20);
            this.udLengthPrecision.TabIndex = 5;
            this.udLengthPrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtLengthField
            // 
            this.txtLengthField.Location = new System.Drawing.Point(116, 97);
            this.txtLengthField.Name = "txtLengthField";
            this.txtLengthField.Size = new System.Drawing.Size(132, 20);
            this.txtLengthField.TabIndex = 4;
            this.txtLengthField.Text = "Length";
            // 
            // cboLengthField
            // 
            this.cboLengthField.BeforeTouchSize = new System.Drawing.Size(220, 21);
            this.cboLengthField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLengthField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboLengthField.Location = new System.Drawing.Point(116, 61);
            this.cboLengthField.Name = "cboLengthField";
            this.cboLengthField.Size = new System.Drawing.Size(220, 21);
            this.cboLengthField.TabIndex = 3;
            // 
            // optLengthNew
            // 
            this.optLengthNew.AutoSize = true;
            this.optLengthNew.Location = new System.Drawing.Point(23, 98);
            this.optLengthNew.Name = "optLengthNew";
            this.optLengthNew.Size = new System.Drawing.Size(75, 17);
            this.optLengthNew.TabIndex = 1;
            this.optLengthNew.Text = "New field: ";
            this.optLengthNew.UseVisualStyleBackColor = true;
            // 
            // optLengthExisting
            // 
            this.optLengthExisting.AutoSize = true;
            this.optLengthExisting.Location = new System.Drawing.Point(23, 62);
            this.optLengthExisting.Name = "optLengthExisting";
            this.optLengthExisting.Size = new System.Drawing.Size(86, 17);
            this.optLengthExisting.TabIndex = 0;
            this.optLengthExisting.Text = "Existing field:";
            this.optLengthExisting.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(283, 372);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(193, 372);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 35;
            this.btnOk.Text = "Ok";
            // 
            // UpdateMeasurementsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(380, 402);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupLength);
            this.Controls.Add(this.groupArea);
            this.Name = "UpdateMeasurementsView";
            this.Text = "Update measurements";
            this.groupArea.ResumeLayout(false);
            this.groupArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAreaWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udAreaPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreaField)).EndInit();
            this.groupLength.ResumeLayout(false);
            this.groupLength.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLengthUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLengthWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLengthPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLengthField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupArea;
        private ComboBoxAdv cboAreaUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown udAreaWidth;
        private System.Windows.Forms.NumericUpDown udAreaPrecision;
        private System.Windows.Forms.TextBox txtAreaField;
        private ComboBoxAdv cboAreaField;
        private System.Windows.Forms.RadioButton optAreaNew;
        private System.Windows.Forms.RadioButton optAreaExisting;
        private System.Windows.Forms.GroupBox groupLength;
        private ComboBoxAdv cboLengthUnits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown udLengthWidth;
        private System.Windows.Forms.NumericUpDown udLengthPrecision;
        private System.Windows.Forms.TextBox txtLengthField;
        private ComboBoxAdv cboLengthField;
        private System.Windows.Forms.RadioButton optLengthNew;
        private System.Windows.Forms.RadioButton optLengthExisting;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton optAreaIgnore;
        private System.Windows.Forms.RadioButton optLengthIgnore;

    }
}