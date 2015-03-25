namespace MW5.Plugins.TableEditor.Forms
{
    partial class UpdateMeasurementsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMeasurementsForm));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblLayername = new System.Windows.Forms.Label();
            this.lblProjection = new System.Windows.Forms.Label();
            this.mainGroupbox = new System.Windows.Forms.GroupBox();
            this.LengthGroupbox = new System.Windows.Forms.GroupBox();
            this.LengthWidth = new System.Windows.Forms.NumericUpDown();
            this.LengthPrecision = new System.Windows.Forms.NumericUpDown();
            this.LengthNewText = new System.Windows.Forms.TextBox();
            this.LengthAttributesCombo = new System.Windows.Forms.ComboBox();
            this.LengthNoneRadio = new System.Windows.Forms.RadioButton();
            this.LengthNewRadio = new System.Windows.Forms.RadioButton();
            this.LengthExistingRadio = new System.Windows.Forms.RadioButton();
            this.PerimeterGroupbox = new System.Windows.Forms.GroupBox();
            this.PerimeterWidth = new System.Windows.Forms.NumericUpDown();
            this.PerimeterPrecision = new System.Windows.Forms.NumericUpDown();
            this.PerimeterNewText = new System.Windows.Forms.TextBox();
            this.PerimeterAttributesCombo = new System.Windows.Forms.ComboBox();
            this.PerimeterNoneRadio = new System.Windows.Forms.RadioButton();
            this.PerimeterNewRadio = new System.Windows.Forms.RadioButton();
            this.PerimeterExistingRadio = new System.Windows.Forms.RadioButton();
            this.AreaGroupbox = new System.Windows.Forms.GroupBox();
            this.AreaWidth = new System.Windows.Forms.NumericUpDown();
            this.AreaPrecision = new System.Windows.Forms.NumericUpDown();
            this.AreaNewText = new System.Windows.Forms.TextBox();
            this.AreaAttributesCombo = new System.Windows.Forms.ComboBox();
            this.AreaNoneRadio = new System.Windows.Forms.RadioButton();
            this.AreaNewRadio = new System.Windows.Forms.RadioButton();
            this.AreaExistingRadio = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CalculateUnitsCombo = new System.Windows.Forms.ComboBox();
            this.lblShapefileUnits = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mainGroupbox.SuspendLayout();
            this.LengthGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LengthWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthPrecision)).BeginInit();
            this.PerimeterGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PerimeterWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerimeterPrecision)).BeginInit();
            this.AreaGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AreaWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(197, 326);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdateClick);
            // 
            // lblLayername
            // 
            this.lblLayername.BackColor = System.Drawing.SystemColors.Control;
            this.lblLayername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLayername.Location = new System.Drawing.Point(12, 9);
            this.lblLayername.Name = "lblLayername";
            this.lblLayername.Size = new System.Drawing.Size(130, 15);
            this.lblLayername.TabIndex = 1;
            this.lblLayername.Text = "              ";
            // 
            // lblProjection
            // 
            this.lblProjection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProjection.Location = new System.Drawing.Point(12, 27);
            this.lblProjection.MaximumSize = new System.Drawing.Size(130, 15);
            this.lblProjection.Name = "lblProjection";
            this.lblProjection.Size = new System.Drawing.Size(130, 15);
            this.lblProjection.TabIndex = 2;
            this.lblProjection.Text = "                     ";
            // 
            // mainGroupbox
            // 
            this.mainGroupbox.Controls.Add(this.LengthGroupbox);
            this.mainGroupbox.Controls.Add(this.PerimeterGroupbox);
            this.mainGroupbox.Controls.Add(this.AreaGroupbox);
            this.mainGroupbox.Location = new System.Drawing.Point(12, 70);
            this.mainGroupbox.Name = "mainGroupbox";
            this.mainGroupbox.Size = new System.Drawing.Size(260, 243);
            this.mainGroupbox.TabIndex = 3;
            this.mainGroupbox.TabStop = false;
            this.mainGroupbox.Text = "Select an attribute";
            // 
            // LengthGroupbox
            // 
            this.LengthGroupbox.Controls.Add(this.LengthWidth);
            this.LengthGroupbox.Controls.Add(this.LengthPrecision);
            this.LengthGroupbox.Controls.Add(this.LengthNewText);
            this.LengthGroupbox.Controls.Add(this.LengthAttributesCombo);
            this.LengthGroupbox.Controls.Add(this.LengthNoneRadio);
            this.LengthGroupbox.Controls.Add(this.LengthNewRadio);
            this.LengthGroupbox.Controls.Add(this.LengthExistingRadio);
            this.LengthGroupbox.Location = new System.Drawing.Point(6, 239);
            this.LengthGroupbox.Name = "LengthGroupbox";
            this.LengthGroupbox.Size = new System.Drawing.Size(234, 104);
            this.LengthGroupbox.TabIndex = 3;
            this.LengthGroupbox.TabStop = false;
            this.LengthGroupbox.Text = "Length";
            this.LengthGroupbox.Visible = false;
            // 
            // LengthWidth
            // 
            this.LengthWidth.Location = new System.Drawing.Point(126, 70);
            this.LengthWidth.Name = "LengthWidth";
            this.LengthWidth.Size = new System.Drawing.Size(44, 20);
            this.LengthWidth.TabIndex = 6;
            this.toolTip1.SetToolTip(this.LengthWidth, "The width of the new field");
            this.LengthWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // LengthPrecision
            // 
            this.LengthPrecision.Location = new System.Drawing.Point(176, 70);
            this.LengthPrecision.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LengthPrecision.Name = "LengthPrecision";
            this.LengthPrecision.Size = new System.Drawing.Size(32, 20);
            this.LengthPrecision.TabIndex = 5;
            this.toolTip1.SetToolTip(this.LengthPrecision, "The precision of the new field");
            this.LengthPrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // LengthNewText
            // 
            this.LengthNewText.Location = new System.Drawing.Point(76, 44);
            this.LengthNewText.Name = "LengthNewText";
            this.LengthNewText.Size = new System.Drawing.Size(132, 20);
            this.LengthNewText.TabIndex = 4;
            this.LengthNewText.Text = "Length";
            this.toolTip1.SetToolTip(this.LengthNewText, "Enter new field name");
            // 
            // LengthAttributesCombo
            // 
            this.LengthAttributesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LengthAttributesCombo.FormattingEnabled = true;
            this.LengthAttributesCombo.Location = new System.Drawing.Point(76, 19);
            this.LengthAttributesCombo.Name = "LengthAttributesCombo";
            this.LengthAttributesCombo.Size = new System.Drawing.Size(132, 21);
            this.LengthAttributesCombo.TabIndex = 3;
            this.toolTip1.SetToolTip(this.LengthAttributesCombo, "Select an existing field");
            // 
            // LengthNoneRadio
            // 
            this.LengthNoneRadio.AutoSize = true;
            this.LengthNoneRadio.Checked = true;
            this.LengthNoneRadio.Location = new System.Drawing.Point(6, 70);
            this.LengthNoneRadio.Name = "LengthNoneRadio";
            this.LengthNoneRadio.Size = new System.Drawing.Size(51, 17);
            this.LengthNoneRadio.TabIndex = 2;
            this.LengthNoneRadio.TabStop = true;
            this.LengthNoneRadio.Text = "None";
            this.LengthNoneRadio.UseVisualStyleBackColor = true;
            // 
            // LengthNewRadio
            // 
            this.LengthNewRadio.AutoSize = true;
            this.LengthNewRadio.Location = new System.Drawing.Point(6, 45);
            this.LengthNewRadio.Name = "LengthNewRadio";
            this.LengthNewRadio.Size = new System.Drawing.Size(53, 17);
            this.LengthNewRadio.TabIndex = 1;
            this.LengthNewRadio.Text = "New: ";
            this.LengthNewRadio.UseVisualStyleBackColor = true;
            // 
            // LengthExistingRadio
            // 
            this.LengthExistingRadio.AutoSize = true;
            this.LengthExistingRadio.Location = new System.Drawing.Point(6, 20);
            this.LengthExistingRadio.Name = "LengthExistingRadio";
            this.LengthExistingRadio.Size = new System.Drawing.Size(64, 17);
            this.LengthExistingRadio.TabIndex = 0;
            this.LengthExistingRadio.Text = "Existing:";
            this.LengthExistingRadio.UseVisualStyleBackColor = true;
            // 
            // PerimeterGroupbox
            // 
            this.PerimeterGroupbox.Controls.Add(this.PerimeterWidth);
            this.PerimeterGroupbox.Controls.Add(this.PerimeterPrecision);
            this.PerimeterGroupbox.Controls.Add(this.PerimeterNewText);
            this.PerimeterGroupbox.Controls.Add(this.PerimeterAttributesCombo);
            this.PerimeterGroupbox.Controls.Add(this.PerimeterNoneRadio);
            this.PerimeterGroupbox.Controls.Add(this.PerimeterNewRadio);
            this.PerimeterGroupbox.Controls.Add(this.PerimeterExistingRadio);
            this.PerimeterGroupbox.Location = new System.Drawing.Point(6, 129);
            this.PerimeterGroupbox.Name = "PerimeterGroupbox";
            this.PerimeterGroupbox.Size = new System.Drawing.Size(234, 104);
            this.PerimeterGroupbox.TabIndex = 1;
            this.PerimeterGroupbox.TabStop = false;
            this.PerimeterGroupbox.Text = "Perimeter";
            // 
            // PerimeterWidth
            // 
            this.PerimeterWidth.Location = new System.Drawing.Point(126, 70);
            this.PerimeterWidth.Name = "PerimeterWidth";
            this.PerimeterWidth.Size = new System.Drawing.Size(44, 20);
            this.PerimeterWidth.TabIndex = 6;
            this.toolTip1.SetToolTip(this.PerimeterWidth, "The width of the new field");
            this.PerimeterWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // PerimeterPrecision
            // 
            this.PerimeterPrecision.Location = new System.Drawing.Point(176, 70);
            this.PerimeterPrecision.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PerimeterPrecision.Name = "PerimeterPrecision";
            this.PerimeterPrecision.Size = new System.Drawing.Size(32, 20);
            this.PerimeterPrecision.TabIndex = 5;
            this.toolTip1.SetToolTip(this.PerimeterPrecision, "The precision of the new field");
            this.PerimeterPrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // PerimeterNewText
            // 
            this.PerimeterNewText.Location = new System.Drawing.Point(76, 44);
            this.PerimeterNewText.Name = "PerimeterNewText";
            this.PerimeterNewText.Size = new System.Drawing.Size(132, 20);
            this.PerimeterNewText.TabIndex = 4;
            this.PerimeterNewText.Text = "Perimeter";
            this.toolTip1.SetToolTip(this.PerimeterNewText, "Enter new field name");
            // 
            // PerimeterAttributesCombo
            // 
            this.PerimeterAttributesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PerimeterAttributesCombo.FormattingEnabled = true;
            this.PerimeterAttributesCombo.Location = new System.Drawing.Point(76, 19);
            this.PerimeterAttributesCombo.Name = "PerimeterAttributesCombo";
            this.PerimeterAttributesCombo.Size = new System.Drawing.Size(132, 21);
            this.PerimeterAttributesCombo.TabIndex = 3;
            this.toolTip1.SetToolTip(this.PerimeterAttributesCombo, "Select an existing field");
            // 
            // PerimeterNoneRadio
            // 
            this.PerimeterNoneRadio.AutoSize = true;
            this.PerimeterNoneRadio.Checked = true;
            this.PerimeterNoneRadio.Location = new System.Drawing.Point(6, 70);
            this.PerimeterNoneRadio.Name = "PerimeterNoneRadio";
            this.PerimeterNoneRadio.Size = new System.Drawing.Size(51, 17);
            this.PerimeterNoneRadio.TabIndex = 2;
            this.PerimeterNoneRadio.TabStop = true;
            this.PerimeterNoneRadio.Text = "None";
            this.PerimeterNoneRadio.UseVisualStyleBackColor = true;
            // 
            // PerimeterNewRadio
            // 
            this.PerimeterNewRadio.AutoSize = true;
            this.PerimeterNewRadio.Location = new System.Drawing.Point(6, 45);
            this.PerimeterNewRadio.Name = "PerimeterNewRadio";
            this.PerimeterNewRadio.Size = new System.Drawing.Size(53, 17);
            this.PerimeterNewRadio.TabIndex = 1;
            this.PerimeterNewRadio.Text = "New: ";
            this.PerimeterNewRadio.UseVisualStyleBackColor = true;
            // 
            // PerimeterExistingRadio
            // 
            this.PerimeterExistingRadio.AutoSize = true;
            this.PerimeterExistingRadio.Location = new System.Drawing.Point(6, 20);
            this.PerimeterExistingRadio.Name = "PerimeterExistingRadio";
            this.PerimeterExistingRadio.Size = new System.Drawing.Size(64, 17);
            this.PerimeterExistingRadio.TabIndex = 0;
            this.PerimeterExistingRadio.Text = "Existing:";
            this.PerimeterExistingRadio.UseVisualStyleBackColor = true;
            // 
            // AreaGroupbox
            // 
            this.AreaGroupbox.Controls.Add(this.AreaWidth);
            this.AreaGroupbox.Controls.Add(this.AreaPrecision);
            this.AreaGroupbox.Controls.Add(this.AreaNewText);
            this.AreaGroupbox.Controls.Add(this.AreaAttributesCombo);
            this.AreaGroupbox.Controls.Add(this.AreaNoneRadio);
            this.AreaGroupbox.Controls.Add(this.AreaNewRadio);
            this.AreaGroupbox.Controls.Add(this.AreaExistingRadio);
            this.AreaGroupbox.Location = new System.Drawing.Point(6, 19);
            this.AreaGroupbox.Name = "AreaGroupbox";
            this.AreaGroupbox.Size = new System.Drawing.Size(234, 104);
            this.AreaGroupbox.TabIndex = 0;
            this.AreaGroupbox.TabStop = false;
            this.AreaGroupbox.Text = "Area";
            // 
            // AreaWidth
            // 
            this.AreaWidth.Location = new System.Drawing.Point(126, 70);
            this.AreaWidth.Name = "AreaWidth";
            this.AreaWidth.Size = new System.Drawing.Size(44, 20);
            this.AreaWidth.TabIndex = 6;
            this.toolTip1.SetToolTip(this.AreaWidth, "The width of the new field");
            this.AreaWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // AreaPrecision
            // 
            this.AreaPrecision.Location = new System.Drawing.Point(176, 70);
            this.AreaPrecision.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AreaPrecision.Name = "AreaPrecision";
            this.AreaPrecision.Size = new System.Drawing.Size(32, 20);
            this.AreaPrecision.TabIndex = 5;
            this.toolTip1.SetToolTip(this.AreaPrecision, "The precision of the new field");
            this.AreaPrecision.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // AreaNewText
            // 
            this.AreaNewText.Location = new System.Drawing.Point(76, 44);
            this.AreaNewText.Name = "AreaNewText";
            this.AreaNewText.Size = new System.Drawing.Size(132, 20);
            this.AreaNewText.TabIndex = 4;
            this.AreaNewText.Text = "Area";
            this.toolTip1.SetToolTip(this.AreaNewText, "Enter new field name");
            // 
            // AreaAttributesCombo
            // 
            this.AreaAttributesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AreaAttributesCombo.FormattingEnabled = true;
            this.AreaAttributesCombo.Location = new System.Drawing.Point(76, 19);
            this.AreaAttributesCombo.Name = "AreaAttributesCombo";
            this.AreaAttributesCombo.Size = new System.Drawing.Size(132, 21);
            this.AreaAttributesCombo.TabIndex = 3;
            this.toolTip1.SetToolTip(this.AreaAttributesCombo, "Select an existing field");
            // 
            // AreaNoneRadio
            // 
            this.AreaNoneRadio.AutoSize = true;
            this.AreaNoneRadio.Checked = true;
            this.AreaNoneRadio.Location = new System.Drawing.Point(6, 70);
            this.AreaNoneRadio.Name = "AreaNoneRadio";
            this.AreaNoneRadio.Size = new System.Drawing.Size(51, 17);
            this.AreaNoneRadio.TabIndex = 2;
            this.AreaNoneRadio.TabStop = true;
            this.AreaNoneRadio.Text = "None";
            this.AreaNoneRadio.UseVisualStyleBackColor = true;
            // 
            // AreaNewRadio
            // 
            this.AreaNewRadio.AutoSize = true;
            this.AreaNewRadio.Location = new System.Drawing.Point(6, 45);
            this.AreaNewRadio.Name = "AreaNewRadio";
            this.AreaNewRadio.Size = new System.Drawing.Size(53, 17);
            this.AreaNewRadio.TabIndex = 1;
            this.AreaNewRadio.Text = "New: ";
            this.AreaNewRadio.UseVisualStyleBackColor = true;
            // 
            // AreaExistingRadio
            // 
            this.AreaExistingRadio.AutoSize = true;
            this.AreaExistingRadio.Location = new System.Drawing.Point(6, 20);
            this.AreaExistingRadio.Name = "AreaExistingRadio";
            this.AreaExistingRadio.Size = new System.Drawing.Size(64, 17);
            this.AreaExistingRadio.TabIndex = 0;
            this.AreaExistingRadio.Text = "Existing:";
            this.AreaExistingRadio.UseVisualStyleBackColor = true;
            // 
            // CalculateUnitsCombo
            // 
            this.CalculateUnitsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CalculateUnitsCombo.FormattingEnabled = true;
            this.CalculateUnitsCombo.Location = new System.Drawing.Point(151, 43);
            this.CalculateUnitsCombo.Name = "CalculateUnitsCombo";
            this.CalculateUnitsCombo.Size = new System.Drawing.Size(121, 21);
            this.CalculateUnitsCombo.TabIndex = 5;
            this.toolTip1.SetToolTip(this.CalculateUnitsCombo, "In what units should the calculation be?");
            // 
            // lblShapefileUnits
            // 
            this.lblShapefileUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShapefileUnits.Location = new System.Drawing.Point(12, 45);
            this.lblShapefileUnits.MaximumSize = new System.Drawing.Size(130, 15);
            this.lblShapefileUnits.Name = "lblShapefileUnits";
            this.lblShapefileUnits.Size = new System.Drawing.Size(130, 15);
            this.lblShapefileUnits.TabIndex = 4;
            this.lblShapefileUnits.Text = "                     ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Calculate in:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 325);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(180, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // UpdateMeasurementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 361);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CalculateUnitsCombo);
            this.Controls.Add(this.lblShapefileUnits);
            this.Controls.Add(this.mainGroupbox);
            this.Controls.Add(this.lblProjection);
            this.Controls.Add(this.lblLayername);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateMeasurementsForm";
            this.Text = "Update measurements";
            this.mainGroupbox.ResumeLayout(false);
            this.LengthGroupbox.ResumeLayout(false);
            this.LengthGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LengthWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LengthPrecision)).EndInit();
            this.PerimeterGroupbox.ResumeLayout(false);
            this.PerimeterGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PerimeterWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerimeterPrecision)).EndInit();
            this.AreaGroupbox.ResumeLayout(false);
            this.AreaGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AreaWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaPrecision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblLayername;
        private System.Windows.Forms.Label lblProjection;
        private System.Windows.Forms.GroupBox mainGroupbox;
        private System.Windows.Forms.GroupBox AreaGroupbox;
        private System.Windows.Forms.RadioButton AreaNoneRadio;
        private System.Windows.Forms.RadioButton AreaNewRadio;
        private System.Windows.Forms.RadioButton AreaExistingRadio;
        private System.Windows.Forms.NumericUpDown AreaWidth;
        private System.Windows.Forms.NumericUpDown AreaPrecision;
        private System.Windows.Forms.TextBox AreaNewText;
        private System.Windows.Forms.ComboBox AreaAttributesCombo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox PerimeterGroupbox;
        private System.Windows.Forms.NumericUpDown PerimeterWidth;
        private System.Windows.Forms.NumericUpDown PerimeterPrecision;
        private System.Windows.Forms.TextBox PerimeterNewText;
        private System.Windows.Forms.ComboBox PerimeterAttributesCombo;
        private System.Windows.Forms.RadioButton PerimeterNoneRadio;
        private System.Windows.Forms.RadioButton PerimeterNewRadio;
        private System.Windows.Forms.RadioButton PerimeterExistingRadio;
        private System.Windows.Forms.Label lblShapefileUnits;
        private System.Windows.Forms.ComboBox CalculateUnitsCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox LengthGroupbox;
        private System.Windows.Forms.NumericUpDown LengthWidth;
        private System.Windows.Forms.NumericUpDown LengthPrecision;
        private System.Windows.Forms.TextBox LengthNewText;
        private System.Windows.Forms.ComboBox LengthAttributesCombo;
        private System.Windows.Forms.RadioButton LengthNoneRadio;
        private System.Windows.Forms.RadioButton LengthNewRadio;
        private System.Windows.Forms.RadioButton LengthExistingRadio;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}