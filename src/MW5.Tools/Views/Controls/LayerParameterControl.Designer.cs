namespace MW5.Tools.Views.Controls
{
    partial class LayerParameterControl
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new Syncfusion.Windows.Forms.ButtonAdv();
            this.comboBoxAdv1 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumSelected = new System.Windows.Forms.Label();
            this.chkSelectedOnly = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOpen, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxAdv1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 71);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // btnOpen
            // 
            this.btnOpen.BeforeTouchSize = new System.Drawing.Size(27, 20);
            this.btnOpen.IsBackStageButton = false;
            this.btnOpen.Location = new System.Drawing.Point(301, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(27, 20);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "...";
            this.btnOpen.Click += new System.EventHandler(this.OpenClick);
            // 
            // comboBoxAdv1
            // 
            this.comboBoxAdv1.BeforeTouchSize = new System.Drawing.Size(287, 21);
            this.comboBoxAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAdv1.ForceImageIndent = true;
            this.comboBoxAdv1.ImageList = this.imageList1;
            this.comboBoxAdv1.Location = new System.Drawing.Point(8, 19);
            this.comboBoxAdv1.Name = "comboBoxAdv1";
            this.comboBoxAdv1.ShowImageInTextBox = true;
            this.comboBoxAdv1.ShowImagesInComboListBox = true;
            this.comboBoxAdv1.Size = new System.Drawing.Size(287, 21);
            this.comboBoxAdv1.TabIndex = 4;
            this.comboBoxAdv1.SelectedIndexChanged += new System.EventHandler(this.SelectedLayerChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNumSelected);
            this.panel1.Controls.Add(this.chkSelectedOnly);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 19);
            this.panel1.TabIndex = 6;
            // 
            // lblNumSelected
            // 
            this.lblNumSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumSelected.Location = new System.Drawing.Point(90, 0);
            this.lblNumSelected.Name = "lblNumSelected";
            this.lblNumSelected.Size = new System.Drawing.Size(197, 19);
            this.lblNumSelected.TabIndex = 6;
            this.lblNumSelected.Text = "Number of selected: 0";
            this.lblNumSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkSelectedOnly
            // 
            this.chkSelectedOnly.AutoSize = true;
            this.chkSelectedOnly.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSelectedOnly.Location = new System.Drawing.Point(0, 0);
            this.chkSelectedOnly.Name = "chkSelectedOnly";
            this.chkSelectedOnly.Size = new System.Drawing.Size(90, 19);
            this.chkSelectedOnly.TabIndex = 5;
            this.chkSelectedOnly.Text = "Selected only";
            this.chkSelectedOnly.UseVisualStyleBackColor = true;
            // 
            // LayerParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LayerParameterControl";
            this.Size = new System.Drawing.Size(336, 71);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAdv1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.ButtonAdv btnOpen;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboBoxAdv1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkSelectedOnly;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumSelected;
    }
}
