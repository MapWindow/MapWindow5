using MW5.Plugins.Symbology.Controls;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    partial class GenerateLabelCategoriesForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkUseVariableSize = new System.Windows.Forms.CheckBox();
            this.groupColors = new System.Windows.Forms.GroupBox();
            this.udMaxSize = new NumericUpDownEx(this.components);
            this.btnFrameScheme = new System.Windows.Forms.Button();
            this.icbFrame = new ImageCombo();
            this.chkGraduatedFrame = new System.Windows.Forms.CheckBox();
            this.udMinSize = new NumericUpDownEx(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCategoriesCount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboClassificationType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRandomColors = new System.Windows.Forms.CheckBox();
            this.groupColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 26);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(176, 307);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 26);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkUseVariableSize
            // 
            this.chkUseVariableSize.AutoSize = true;
            this.chkUseVariableSize.Location = new System.Drawing.Point(17, 100);
            this.chkUseVariableSize.Name = "chkUseVariableSize";
            this.chkUseVariableSize.Size = new System.Drawing.Size(127, 17);
            this.chkUseVariableSize.TabIndex = 53;
            this.chkUseVariableSize.Text = "Use variable font size";
            this.chkUseVariableSize.UseVisualStyleBackColor = true;
            this.chkUseVariableSize.CheckedChanged += new System.EventHandler(this.RefreshControlsState);
            // 
            // groupColors
            // 
            this.groupColors.Controls.Add(this.chkRandomColors);
            this.groupColors.Controls.Add(this.udMaxSize);
            this.groupColors.Controls.Add(this.btnFrameScheme);
            this.groupColors.Controls.Add(this.icbFrame);
            this.groupColors.Controls.Add(this.chkGraduatedFrame);
            this.groupColors.Controls.Add(this.udMinSize);
            this.groupColors.Controls.Add(this.chkUseVariableSize);
            this.groupColors.Location = new System.Drawing.Point(12, 164);
            this.groupColors.Name = "groupColors";
            this.groupColors.Size = new System.Drawing.Size(348, 138);
            this.groupColors.TabIndex = 28;
            this.groupColors.TabStop = false;
            this.groupColors.Text = "Visualization";
            // 
            // udMaxSize
            // 
            this.udMaxSize.Location = new System.Drawing.Point(235, 99);
            this.udMaxSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udMaxSize.Name = "udMaxSize";
            this.udMaxSize.Size = new System.Drawing.Size(61, 20);
            this.udMaxSize.TabIndex = 64;
            this.udMaxSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // btnFrameScheme
            // 
            this.btnFrameScheme.Location = new System.Drawing.Point(302, 38);
            this.btnFrameScheme.Name = "btnFrameScheme";
            this.btnFrameScheme.Size = new System.Drawing.Size(27, 21);
            this.btnFrameScheme.TabIndex = 63;
            this.btnFrameScheme.Text = "...";
            this.btnFrameScheme.UseVisualStyleBackColor = true;
            this.btnFrameScheme.Click += new System.EventHandler(this.btnFrameScheme_Click);
            // 
            // icbFrame
            // 
            this.icbFrame.Color1 = System.Drawing.Color.Gray;
            this.icbFrame.Color2 = System.Drawing.Color.Honeydew;
            this.icbFrame.ColorSchemes = null;
            this.icbFrame.ComboStyle = ImageComboStyle.Common;
            this.icbFrame.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbFrame.FormattingEnabled = true;
            this.icbFrame.Location = new System.Drawing.Point(127, 38);
            this.icbFrame.Name = "icbFrame";
            this.icbFrame.OutlineColor = System.Drawing.Color.Black;
            this.icbFrame.Size = new System.Drawing.Size(169, 21);
            this.icbFrame.TabIndex = 62;
            // 
            // chkGraduatedFrame
            // 
            this.chkGraduatedFrame.AutoSize = true;
            this.chkGraduatedFrame.Checked = true;
            this.chkGraduatedFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGraduatedFrame.Location = new System.Drawing.Point(17, 40);
            this.chkGraduatedFrame.Name = "chkGraduatedFrame";
            this.chkGraduatedFrame.Size = new System.Drawing.Size(81, 17);
            this.chkGraduatedFrame.TabIndex = 61;
            this.chkGraduatedFrame.Text = "Frame color";
            this.chkGraduatedFrame.UseVisualStyleBackColor = true;
            this.chkGraduatedFrame.CheckedChanged += new System.EventHandler(this.RefreshControlsState);
            // 
            // udMinSize
            // 
            this.udMinSize.Location = new System.Drawing.Point(165, 99);
            this.udMinSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.udMinSize.Name = "udMinSize";
            this.udMinSize.Size = new System.Drawing.Size(59, 20);
            this.udMinSize.TabIndex = 54;
            this.udMinSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
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
            this.groupBox1.Size = new System.Drawing.Size(348, 146);
            this.groupBox1.TabIndex = 59;
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
            // chkRandomColors
            // 
            this.chkRandomColors.AutoSize = true;
            this.chkRandomColors.Location = new System.Drawing.Point(127, 65);
            this.chkRandomColors.Name = "chkRandomColors";
            this.chkRandomColors.Size = new System.Drawing.Size(97, 17);
            this.chkRandomColors.TabIndex = 65;
            this.chkRandomColors.Text = "Random colors";
            this.chkRandomColors.UseVisualStyleBackColor = true;
            this.chkRandomColors.CheckedChanged += new System.EventHandler(this.chkRandomColors_CheckedChanged);
            // 
            // frmGenerateLabelCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(369, 341);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupColors);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GenerateLabelCategoriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generation of label categories";
            this.groupColors.ResumeLayout(false);
            this.groupColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udMaxSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMinSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkUseVariableSize;
        private System.Windows.Forms.GroupBox groupColors;
        private NumericUpDownEx udMinSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboCategoriesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboClassificationType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFrameScheme;
        private ImageCombo icbFrame;
        private System.Windows.Forms.CheckBox chkGraduatedFrame;
        private NumericUpDownEx udMaxSize;
        private System.Windows.Forms.CheckBox chkRandomColors;
    }
}