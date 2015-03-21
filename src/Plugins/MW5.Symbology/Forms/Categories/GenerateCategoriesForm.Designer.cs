using MW5.Plugins.Symbology.Controls;
using MW5.Plugins.Symbology.Controls.ImageCombo;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    partial class GenerateCategoriesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCategoriesCount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboClassificationType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChangeColorScheme = new System.Windows.Forms.Button();
            this.chkSetGradient = new System.Windows.Forms.CheckBox();
            this.chkUseVariableSize = new System.Windows.Forms.CheckBox();
            this.chkRandomColors = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.udMaxSize = new NumericUpDownEx(this.components);
            this.udMinSize = new NumericUpDownEx(this.components);
            this.icbColorScheme = new ImageCombo();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinSize)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboField);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboCategoriesCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboClassificationType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 145);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Classification";
            // 
            // cboField
            // 
            this.cboField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(130, 104);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(202, 21);
            this.cboField.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Classification field";
            // 
            // cboCategoriesCount
            // 
            this.cboCategoriesCount.FormattingEnabled = true;
            this.cboCategoriesCount.Location = new System.Drawing.Point(130, 66);
            this.cboCategoriesCount.Name = "cboCategoriesCount";
            this.cboCategoriesCount.Size = new System.Drawing.Size(202, 21);
            this.cboCategoriesCount.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Number of categories";
            // 
            // cboClassificationType
            // 
            this.cboClassificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassificationType.FormattingEnabled = true;
            this.cboClassificationType.Location = new System.Drawing.Point(130, 28);
            this.cboClassificationType.Name = "cboClassificationType";
            this.cboClassificationType.Size = new System.Drawing.Size(202, 21);
            this.cboClassificationType.TabIndex = 26;
            this.cboClassificationType.SelectedIndexChanged += new System.EventHandler(this.RefreshControlsState);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Classification type";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(158, 366);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 25);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(262, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 25);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.udMaxSize);
            this.groupBox2.Controls.Add(this.udMinSize);
            this.groupBox2.Controls.Add(this.btnChangeColorScheme);
            this.groupBox2.Controls.Add(this.chkSetGradient);
            this.groupBox2.Controls.Add(this.chkUseVariableSize);
            this.groupBox2.Controls.Add(this.icbColorScheme);
            this.groupBox2.Controls.Add(this.chkRandomColors);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 197);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualization";
            // 
            // btnChangeColorScheme
            // 
            this.btnChangeColorScheme.Location = new System.Drawing.Point(302, 38);
            this.btnChangeColorScheme.Name = "btnChangeColorScheme";
            this.btnChangeColorScheme.Size = new System.Drawing.Size(29, 21);
            this.btnChangeColorScheme.TabIndex = 52;
            this.btnChangeColorScheme.Text = "...";
            this.btnChangeColorScheme.UseVisualStyleBackColor = true;
            this.btnChangeColorScheme.Click += new System.EventHandler(this.btnChangeColorScheme_Click);
            // 
            // chkSetGradient
            // 
            this.chkSetGradient.AutoSize = true;
            this.chkSetGradient.Checked = true;
            this.chkSetGradient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetGradient.Location = new System.Drawing.Point(18, 155);
            this.chkSetGradient.Name = "chkSetGradient";
            this.chkSetGradient.Size = new System.Drawing.Size(278, 17);
            this.chkSetGradient.TabIndex = 51;
            this.chkSetGradient.Text = "Set gradient for each category (reduces performance)";
            this.chkSetGradient.UseVisualStyleBackColor = true;
            // 
            // chkUseVariableSize
            // 
            this.chkUseVariableSize.AutoSize = true;
            this.chkUseVariableSize.Location = new System.Drawing.Point(18, 91);
            this.chkUseVariableSize.Name = "chkUseVariableSize";
            this.chkUseVariableSize.Size = new System.Drawing.Size(141, 17);
            this.chkUseVariableSize.TabIndex = 50;
            this.chkUseVariableSize.Text = "Use variable symbol size";
            this.chkUseVariableSize.UseVisualStyleBackColor = true;
            this.chkUseVariableSize.CheckedChanged += new System.EventHandler(this.RefreshControlsState);
            // 
            // chkRandomColors
            // 
            this.chkRandomColors.AutoSize = true;
            this.chkRandomColors.Location = new System.Drawing.Point(130, 65);
            this.chkRandomColors.Name = "chkRandomColors";
            this.chkRandomColors.Size = new System.Drawing.Size(133, 17);
            this.chkRandomColors.TabIndex = 48;
            this.chkRandomColors.Text = "Choose color randomly";
            this.chkRandomColors.UseVisualStyleBackColor = true;
            this.chkRandomColors.CheckedChanged += new System.EventHandler(this.chkRandomColors_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Color scheme";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Symbol size";
            // 
            // udMaxSize
            // 
            this.udMaxSize.Location = new System.Drawing.Point(218, 118);
            this.udMaxSize.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.udMaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udMaxSize.Name = "udMaxSize";
            this.udMaxSize.Size = new System.Drawing.Size(67, 20);
            this.udMaxSize.TabIndex = 54;
            this.udMaxSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // udMinSize
            // 
            this.udMinSize.Location = new System.Drawing.Point(130, 118);
            this.udMinSize.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.udMinSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udMinSize.Name = "udMinSize";
            this.udMinSize.Size = new System.Drawing.Size(67, 20);
            this.udMinSize.TabIndex = 53;
            this.udMinSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // icbColorScheme
            // 
            this.icbColorScheme.Color1 = System.Drawing.Color.Gray;
            this.icbColorScheme.Color2 = System.Drawing.Color.Honeydew;
            this.icbColorScheme.ColorSchemes = null;
            this.icbColorScheme.ComboStyle = ImageComboStyle.Common;
            this.icbColorScheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbColorScheme.FormattingEnabled = true;
            this.icbColorScheme.Location = new System.Drawing.Point(130, 38);
            this.icbColorScheme.Name = "icbColorScheme";
            this.icbColorScheme.OutlineColor = System.Drawing.Color.Black;
            this.icbColorScheme.Size = new System.Drawing.Size(166, 21);
            this.icbColorScheme.TabIndex = 49;
            // 
            // GenerateCategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(372, 395);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateCategoriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Category generation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboCategoriesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboClassificationType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkUseVariableSize;
        private ImageCombo icbColorScheme;
        private System.Windows.Forms.CheckBox chkRandomColors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSetGradient;
        private System.Windows.Forms.Button btnChangeColorScheme;
        private NumericUpDownEx udMaxSize;
        private NumericUpDownEx udMinSize;
    }
}