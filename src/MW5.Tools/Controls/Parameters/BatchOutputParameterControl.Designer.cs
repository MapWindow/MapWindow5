namespace MW5.Tools.Controls.Parameters
{
    partial class BatchOutputParameterControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAddToMap = new System.Windows.Forms.CheckBox();
            this.chkMemoryLayer = new System.Windows.Forms.CheckBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.btnSave = new Syncfusion.Windows.Forms.ButtonAdv();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTemplate = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPath = new MW5.UI.Controls.WatermarkTextbox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(341, 99);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAddToMap);
            this.panel1.Controls.Add(this.chkMemoryLayer);
            this.panel1.Controls.Add(this.chkOverwrite);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 22);
            this.panel1.TabIndex = 6;
            // 
            // chkAddToMap
            // 
            this.chkAddToMap.AutoSize = true;
            this.chkAddToMap.Location = new System.Drawing.Point(174, 3);
            this.chkAddToMap.Name = "chkAddToMap";
            this.chkAddToMap.Size = new System.Drawing.Size(80, 17);
            this.chkAddToMap.TabIndex = 2;
            this.chkAddToMap.Text = "Add to map";
            this.chkAddToMap.UseVisualStyleBackColor = true;
            // 
            // chkMemoryLayer
            // 
            this.chkMemoryLayer.AutoSize = true;
            this.chkMemoryLayer.Checked = true;
            this.chkMemoryLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMemoryLayer.Location = new System.Drawing.Point(80, 3);
            this.chkMemoryLayer.Name = "chkMemoryLayer";
            this.chkMemoryLayer.Size = new System.Drawing.Size(88, 17);
            this.chkMemoryLayer.TabIndex = 1;
            this.chkMemoryLayer.Text = "Memory layer";
            this.chkMemoryLayer.UseVisualStyleBackColor = true;
            this.chkMemoryLayer.CheckedChanged += new System.EventHandler(this.MemoryLayerChecked);
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(3, 3);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(71, 17);
            this.chkOverwrite.TabIndex = 0;
            this.chkOverwrite.Text = "Overwrite";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            this.chkOverwrite.CheckedChanged += new System.EventHandler(this.OnOverwriteCheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BeforeTouchSize = new System.Drawing.Size(27, 20);
            this.btnSave.IsBackStageButton = false;
            this.btnSave.Location = new System.Drawing.Point(306, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(27, 20);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "...";
            this.btnSave.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTemplate);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(8, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 20);
            this.panel2.TabIndex = 8;
            // 
            // txtTemplate
            // 
            this.txtTemplate.BeforeTouchSize = new System.Drawing.Size(268, 20);
            this.txtTemplate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTemplate.Location = new System.Drawing.Point(24, 0);
            this.txtTemplate.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(268, 20);
            this.txtTemplate.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtTemplate.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::MW5.Tools.Properties.Resources.img_info20;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Filename, {input} variable can be used to include name of the input file.\r\n");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtPath);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(8, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(292, 20);
            this.panel3.TabIndex = 9;
            // 
            // txtPath
            // 
            this.txtPath.BeforeTouchSize = new System.Drawing.Size(268, 20);
            this.txtPath.Cue = null;
            this.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPath.Location = new System.Drawing.Point(24, 0);
            this.txtPath.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPath.Name = "txtPath";
            this.txtPath.ShowClearButton = false;
            this.txtPath.Size = new System.Drawing.Size(268, 20);
            this.txtPath.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Default;
            this.txtPath.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::MW5.Tools.Properties.Resources.img_info20;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 20);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Output path");
            // 
            // BatchOutputParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BatchOutputParameterControl";
            this.Size = new System.Drawing.Size(341, 99);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTemplate;
        private Syncfusion.Windows.Forms.ButtonAdv btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAddToMap;
        private System.Windows.Forms.CheckBox chkMemoryLayer;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private UI.Controls.WatermarkTextbox txtPath;
    }
}
