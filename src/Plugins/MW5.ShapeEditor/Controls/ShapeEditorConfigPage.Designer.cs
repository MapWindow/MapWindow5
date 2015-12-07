namespace MW5.Plugins.ShapeEditor.Controls
{
    partial class ShapeEditorConfigPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.configPanelControl4 = new MW5.UI.Controls.ConfigPanelControl();
            this.chkShowAttributesDialog = new System.Windows.Forms.CheckBox();
            this.chkShowPointLabels = new System.Windows.Forms.CheckBox();
            this.configPanelControl3 = new MW5.UI.Controls.ConfigPanelControl();
            this.udBearingPrecision = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowBearing = new System.Windows.Forms.CheckBox();
            this.cboBearingType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAngleFormat = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.configPanelControl2 = new MW5.UI.Controls.ConfigPanelControl();
            this.cboLengthUnits = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label4 = new System.Windows.Forms.Label();
            this.chkShowLength = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.udLengthPrecision = new System.Windows.Forms.NumericUpDown();
            this.chkShowArea = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl4)).BeginInit();
            this.configPanelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).BeginInit();
            this.configPanelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBearingPrecision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBearingType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAngleFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).BeginInit();
            this.configPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLengthUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLengthPrecision)).BeginInit();
            this.SuspendLayout();
            // 
            // configPanelControl4
            // 
            this.configPanelControl4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl4.Controls.Add(this.chkShowAttributesDialog);
            this.configPanelControl4.Controls.Add(this.chkShowPointLabels);
            this.configPanelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl4.HeaderText = "Style and Behavior";
            this.configPanelControl4.Location = new System.Drawing.Point(0, 0);
            this.configPanelControl4.Name = "configPanelControl4";
            this.configPanelControl4.Size = new System.Drawing.Size(447, 122);
            this.configPanelControl4.TabIndex = 33;
            // 
            // chkShowAttributesDialog
            // 
            this.chkShowAttributesDialog.AutoSize = true;
            this.chkShowAttributesDialog.Location = new System.Drawing.Point(31, 82);
            this.chkShowAttributesDialog.Name = "chkShowAttributesDialog";
            this.chkShowAttributesDialog.Size = new System.Drawing.Size(222, 17);
            this.chkShowAttributesDialog.TabIndex = 28;
            this.chkShowAttributesDialog.Text = "Show attribute dialog after shape creation";
            this.chkShowAttributesDialog.UseVisualStyleBackColor = true;
            // 
            // chkShowPointLabels
            // 
            this.chkShowPointLabels.AutoSize = true;
            this.chkShowPointLabels.Location = new System.Drawing.Point(31, 47);
            this.chkShowPointLabels.Name = "chkShowPointLabels";
            this.chkShowPointLabels.Size = new System.Drawing.Size(109, 17);
            this.chkShowPointLabels.TabIndex = 29;
            this.chkShowPointLabels.Text = "Show point labels";
            this.chkShowPointLabels.UseVisualStyleBackColor = true;
            // 
            // configPanelControl3
            // 
            this.configPanelControl3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl3.Controls.Add(this.udBearingPrecision);
            this.configPanelControl3.Controls.Add(this.label1);
            this.configPanelControl3.Controls.Add(this.chkShowBearing);
            this.configPanelControl3.Controls.Add(this.cboBearingType);
            this.configPanelControl3.Controls.Add(this.label2);
            this.configPanelControl3.Controls.Add(this.label3);
            this.configPanelControl3.Controls.Add(this.cboAngleFormat);
            this.configPanelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl3.HeaderText = "Bearing and Angles";
            this.configPanelControl3.Location = new System.Drawing.Point(0, 247);
            this.configPanelControl3.Name = "configPanelControl3";
            this.configPanelControl3.Size = new System.Drawing.Size(447, 153);
            this.configPanelControl3.TabIndex = 32;
            // 
            // udBearingPrecision
            // 
            this.udBearingPrecision.Location = new System.Drawing.Point(299, 69);
            this.udBearingPrecision.Name = "udBearingPrecision";
            this.udBearingPrecision.Size = new System.Drawing.Size(68, 20);
            this.udBearingPrecision.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bearing type";
            // 
            // chkShowBearing
            // 
            this.chkShowBearing.AutoSize = true;
            this.chkShowBearing.Location = new System.Drawing.Point(33, 35);
            this.chkShowBearing.Name = "chkShowBearing";
            this.chkShowBearing.Size = new System.Drawing.Size(91, 17);
            this.chkShowBearing.TabIndex = 16;
            this.chkShowBearing.Text = "Show bearing";
            this.chkShowBearing.UseVisualStyleBackColor = true;
            // 
            // cboBearingType
            // 
            this.cboBearingType.BeforeTouchSize = new System.Drawing.Size(121, 21);
            this.cboBearingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBearingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboBearingType.Location = new System.Drawing.Point(102, 69);
            this.cboBearingType.Name = "cboBearingType";
            this.cboBearingType.Size = new System.Drawing.Size(121, 21);
            this.cboBearingType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Angle format";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Precision";
            // 
            // cboAngleFormat
            // 
            this.cboAngleFormat.BeforeTouchSize = new System.Drawing.Size(121, 21);
            this.cboAngleFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAngleFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboAngleFormat.Location = new System.Drawing.Point(102, 110);
            this.cboAngleFormat.Name = "cboAngleFormat";
            this.cboAngleFormat.Size = new System.Drawing.Size(121, 21);
            this.cboAngleFormat.TabIndex = 5;
            // 
            // configPanelControl2
            // 
            this.configPanelControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.configPanelControl2.Controls.Add(this.chkShowArea);
            this.configPanelControl2.Controls.Add(this.cboLengthUnits);
            this.configPanelControl2.Controls.Add(this.label4);
            this.configPanelControl2.Controls.Add(this.chkShowLength);
            this.configPanelControl2.Controls.Add(this.label6);
            this.configPanelControl2.Controls.Add(this.udLengthPrecision);
            this.configPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.configPanelControl2.HeaderText = "Distance and Area";
            this.configPanelControl2.Location = new System.Drawing.Point(0, 122);
            this.configPanelControl2.Name = "configPanelControl2";
            this.configPanelControl2.Size = new System.Drawing.Size(447, 125);
            this.configPanelControl2.TabIndex = 30;
            // 
            // cboLengthUnits
            // 
            this.cboLengthUnits.BeforeTouchSize = new System.Drawing.Size(121, 21);
            this.cboLengthUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLengthUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboLengthUnits.Location = new System.Drawing.Point(99, 83);
            this.cboLengthUnits.Name = "cboLengthUnits";
            this.cboLengthUnits.Size = new System.Drawing.Size(121, 21);
            this.cboLengthUnits.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precision";
            // 
            // chkShowLength
            // 
            this.chkShowLength.AutoSize = true;
            this.chkShowLength.Location = new System.Drawing.Point(31, 46);
            this.chkShowLength.Name = "chkShowLength";
            this.chkShowLength.Size = new System.Drawing.Size(85, 17);
            this.chkShowLength.TabIndex = 10;
            this.chkShowLength.Text = "Show length";
            this.chkShowLength.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Display units";
            // 
            // udLengthPrecision
            // 
            this.udLengthPrecision.Location = new System.Drawing.Point(299, 83);
            this.udLengthPrecision.Name = "udLengthPrecision";
            this.udLengthPrecision.Size = new System.Drawing.Size(68, 20);
            this.udLengthPrecision.TabIndex = 7;
            // 
            // chkShowArea
            // 
            this.chkShowArea.AutoSize = true;
            this.chkShowArea.Location = new System.Drawing.Point(143, 46);
            this.chkShowArea.Name = "chkShowArea";
            this.chkShowArea.Size = new System.Drawing.Size(77, 17);
            this.chkShowArea.TabIndex = 17;
            this.chkShowArea.Text = "Show area";
            this.chkShowArea.UseVisualStyleBackColor = true;
            // 
            // ShapeEditorConfigPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.configPanelControl3);
            this.Controls.Add(this.configPanelControl2);
            this.Controls.Add(this.configPanelControl4);
            this.Name = "ShapeEditorConfigPage";
            this.Size = new System.Drawing.Size(447, 409);
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl4)).EndInit();
            this.configPanelControl4.ResumeLayout(false);
            this.configPanelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl3)).EndInit();
            this.configPanelControl3.ResumeLayout(false);
            this.configPanelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udBearingPrecision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBearingType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAngleFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPanelControl2)).EndInit();
            this.configPanelControl2.ResumeLayout(false);
            this.configPanelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLengthUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLengthPrecision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboLengthUnits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown udLengthPrecision;
        private System.Windows.Forms.CheckBox chkShowLength;
        private System.Windows.Forms.NumericUpDown udBearingPrecision;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboBearingType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboAngleFormat;
        private System.Windows.Forms.CheckBox chkShowBearing;
        private System.Windows.Forms.CheckBox chkShowPointLabels;
        private UI.Controls.ConfigPanelControl configPanelControl2;
        private UI.Controls.ConfigPanelControl configPanelControl3;
        private UI.Controls.ConfigPanelControl configPanelControl4;
        private System.Windows.Forms.CheckBox chkShowAttributesDialog;
        private System.Windows.Forms.CheckBox chkShowArea;
    }
}
