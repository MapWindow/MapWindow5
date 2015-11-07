using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Printing.Views
{
    partial class PageSetupView
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
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMarginRight = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMarginBottom = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMarginLeft = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.txtMarginTop = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboPaperSizes = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.optPortrait = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.optLandscape = new System.Windows.Forms.RadioButton();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPaperSizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(81, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(242, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(84, 26);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(154, 231);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 26);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtMarginRight);
            this.GroupBox1.Controls.Add(this.txtMarginBottom);
            this.GroupBox1.Controls.Add(this.txtMarginLeft);
            this.GroupBox1.Controls.Add(this.txtMarginTop);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Location = new System.Drawing.Point(19, 97);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(304, 119);
            this.GroupBox1.TabIndex = 25;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Margins";
            // 
            // txtMarginRight
            // 
            this.txtMarginRight.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMarginRight.BeforeTouchSize = new System.Drawing.Size(62, 20);
            this.txtMarginRight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMarginRight.DoubleValue = 1D;
            this.txtMarginRight.Location = new System.Drawing.Point(225, 72);
            this.txtMarginRight.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMarginRight.Name = "txtMarginRight";
            this.txtMarginRight.NullString = "";
            this.txtMarginRight.Size = new System.Drawing.Size(62, 20);
            this.txtMarginRight.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMarginRight.TabIndex = 12;
            this.txtMarginRight.Text = "1.00";
            // 
            // txtMarginBottom
            // 
            this.txtMarginBottom.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMarginBottom.BeforeTouchSize = new System.Drawing.Size(62, 20);
            this.txtMarginBottom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMarginBottom.DoubleValue = 1D;
            this.txtMarginBottom.Location = new System.Drawing.Point(81, 72);
            this.txtMarginBottom.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMarginBottom.Name = "txtMarginBottom";
            this.txtMarginBottom.NullString = "";
            this.txtMarginBottom.Size = new System.Drawing.Size(62, 20);
            this.txtMarginBottom.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMarginBottom.TabIndex = 11;
            this.txtMarginBottom.Text = "1.00";
            // 
            // txtMarginLeft
            // 
            this.txtMarginLeft.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMarginLeft.BeforeTouchSize = new System.Drawing.Size(62, 20);
            this.txtMarginLeft.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMarginLeft.DoubleValue = 1D;
            this.txtMarginLeft.Location = new System.Drawing.Point(225, 32);
            this.txtMarginLeft.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMarginLeft.Name = "txtMarginLeft";
            this.txtMarginLeft.NullString = "";
            this.txtMarginLeft.Size = new System.Drawing.Size(62, 20);
            this.txtMarginLeft.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMarginLeft.TabIndex = 10;
            this.txtMarginLeft.Text = "1.00";
            // 
            // txtMarginTop
            // 
            this.txtMarginTop.BackGroundColor = System.Drawing.SystemColors.Window;
            this.txtMarginTop.BeforeTouchSize = new System.Drawing.Size(62, 20);
            this.txtMarginTop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMarginTop.DoubleValue = 1D;
            this.txtMarginTop.Location = new System.Drawing.Point(81, 32);
            this.txtMarginTop.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtMarginTop.Name = "txtMarginTop";
            this.txtMarginTop.NullString = "";
            this.txtMarginTop.Size = new System.Drawing.Size(62, 20);
            this.txtMarginTop.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtMarginTop.TabIndex = 9;
            this.txtMarginTop.Text = "1.00";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(174, 75);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(32, 13);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Right";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(174, 35);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(25, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Left";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(26, 75);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 13);
            this.Label6.TabIndex = 8;
            this.Label6.Text = "Bottom";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(26, 35);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(26, 13);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Top";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(23, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(59, 13);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Paper size:";
            // 
            // cboPaperSizes
            // 
            this.cboPaperSizes.BeforeTouchSize = new System.Drawing.Size(223, 21);
            this.cboPaperSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaperSizes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboPaperSizes.Location = new System.Drawing.Point(100, 23);
            this.cboPaperSizes.Name = "cboPaperSizes";
            this.cboPaperSizes.Size = new System.Drawing.Size(223, 21);
            this.cboPaperSizes.TabIndex = 23;
            // 
            // optPortrait
            // 
            this.optPortrait.AutoSize = true;
            this.optPortrait.Location = new System.Drawing.Point(258, 61);
            this.optPortrait.Name = "optPortrait";
            this.optPortrait.Size = new System.Drawing.Size(58, 17);
            this.optPortrait.TabIndex = 13;
            this.optPortrait.Text = "Portrait";
            this.optPortrait.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MW5.Plugins.Printing.Properties.Resources.img_landscape32;
            this.pictureBox1.Location = new System.Drawing.Point(100, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MW5.Plugins.Printing.Properties.Resources.img_portrait32;
            this.pictureBox2.Location = new System.Drawing.Point(224, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // optLandscape
            // 
            this.optLandscape.AutoSize = true;
            this.optLandscape.Checked = true;
            this.optLandscape.Location = new System.Drawing.Point(130, 61);
            this.optLandscape.Name = "optLandscape";
            this.optLandscape.Size = new System.Drawing.Size(78, 17);
            this.optLandscape.TabIndex = 34;
            this.optLandscape.TabStop = true;
            this.optLandscape.Text = "Landscape";
            this.optLandscape.UseVisualStyleBackColor = true;
            // 
            // PageSetupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(339, 264);
            this.Controls.Add(this.optLandscape);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.optPortrait);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cboPaperSizes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "PageSetupView";
            this.Text = "Page Setup";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMarginTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPaperSizes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label1;
        internal ComboBoxAdv cboPaperSizes;
        private DoubleTextBox txtMarginRight;
        private DoubleTextBox txtMarginBottom;
        private DoubleTextBox txtMarginLeft;
        private DoubleTextBox txtMarginTop;
        private System.Windows.Forms.RadioButton optPortrait;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton optLandscape;
    }
}