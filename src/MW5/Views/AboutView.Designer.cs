namespace MW5.Views
{
    partial class AboutView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutView));
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboAssemblyFilter = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblOcxVersion = new System.Windows.Forms.Label();
            this.lblGdalVersion = new System.Windows.Forms.Label();
            this.assembliesGrid1 = new MW5.Controls.AssembliesGrid();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageAdv2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAssemblyFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(595, 348);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv1);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv2);
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(120, 80);
            this.tabControlAdv1.Location = new System.Drawing.Point(4, 12);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(595, 348);
            this.tabControlAdv1.TabIndex = 0;
            // 
            // tabPageAdv1
            // 
            this.tabPageAdv1.Controls.Add(this.lblGdalVersion);
            this.tabPageAdv1.Controls.Add(this.lblOcxVersion);
            this.tabPageAdv1.Controls.Add(this.lblVersion);
            this.tabPageAdv1.Controls.Add(this.label4);
            this.tabPageAdv1.Controls.Add(this.label3);
            this.tabPageAdv1.Controls.Add(this.pictureBox1);
            this.tabPageAdv1.Image = global::MW5.Properties.Resources.img_mapwindow24;
            this.tabPageAdv1.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageAdv1.Location = new System.Drawing.Point(123, 1);
            this.tabPageAdv1.Name = "tabPageAdv1";
            this.tabPageAdv1.ShowCloseButton = true;
            this.tabPageAdv1.Size = new System.Drawing.Size(470, 345);
            this.tabPageAdv1.TabIndex = 1;
            this.tabPageAdv1.Text = "General";
            this.tabPageAdv1.ThemesEnabled = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MW5.Properties.Resources.mapwindow_logo;
            this.pictureBox1.Location = new System.Drawing.Point(38, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(406, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPageAdv2
            // 
            this.tabPageAdv2.Controls.Add(this.assembliesGrid1);
            this.tabPageAdv2.Controls.Add(this.panel1);
            this.tabPageAdv2.Image = global::MW5.Properties.Resources.img_component32;
            this.tabPageAdv2.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageAdv2.Location = new System.Drawing.Point(123, 1);
            this.tabPageAdv2.Name = "tabPageAdv2";
            this.tabPageAdv2.ShowCloseButton = true;
            this.tabPageAdv2.Size = new System.Drawing.Size(470, 345);
            this.tabPageAdv2.TabIndex = 2;
            this.tabPageAdv2.Text = "Assemblies";
            this.tabPageAdv2.ThemesEnabled = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboAssemblyFilter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 42);
            this.panel1.TabIndex = 3;
            // 
            // cboAssemblyFilter
            // 
            this.cboAssemblyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAssemblyFilter.BeforeTouchSize = new System.Drawing.Size(170, 21);
            this.cboAssemblyFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssemblyFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cboAssemblyFilter.Location = new System.Drawing.Point(297, 10);
            this.cboAssemblyFilter.Name = "cboAssemblyFilter";
            this.cboAssemblyFilter.Size = new System.Drawing.Size(170, 21);
            this.cboAssemblyFilter.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(509, 369);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 26);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Close";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "img_options.png");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "MapWindow Programmable Geographic Information System";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Developers: MapWindow GIS Team";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(24, 164);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(107, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "MapWindow version:";
            // 
            // lblOcxVersion
            // 
            this.lblOcxVersion.AutoSize = true;
            this.lblOcxVersion.Location = new System.Drawing.Point(24, 191);
            this.lblOcxVersion.Name = "lblOcxVersion";
            this.lblOcxVersion.Size = new System.Drawing.Size(105, 13);
            this.lblOcxVersion.TabIndex = 4;
            this.lblOcxVersion.Text = "MapWinGIS version:";
            // 
            // lblGdalVersion
            // 
            this.lblGdalVersion.AutoSize = true;
            this.lblGdalVersion.Location = new System.Drawing.Point(24, 218);
            this.lblGdalVersion.Name = "lblGdalVersion";
            this.lblGdalVersion.Size = new System.Drawing.Size(76, 13);
            this.lblGdalVersion.TabIndex = 5;
            this.lblGdalVersion.Text = "GDAL version:";
            // 
            // assembliesGrid1
            // 
            this.assembliesGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.assembliesGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.assembliesGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.assembliesGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.assembliesGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.assembliesGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.assembliesGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assembliesGrid1.FreezeCaption = false;
            this.assembliesGrid1.Location = new System.Drawing.Point(0, 42);
            this.assembliesGrid1.Name = "assembliesGrid1";
            this.assembliesGrid1.Size = new System.Drawing.Size(470, 303);
            this.assembliesGrid1.TabIndex = 0;
            this.assembliesGrid1.TableDescriptor.AllowEdit = false;
            this.assembliesGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.assembliesGrid1.TableOptions.AllowDropDownCell = false;
            this.assembliesGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.assembliesGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.assembliesGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.assembliesGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.assembliesGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.assembliesGrid1.Text = "assembliesGrid1";
            this.assembliesGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.assembliesGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.assembliesGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.assembliesGrid1.VersionInfo = "5.0.1.0";
            this.assembliesGrid1.WrapWithPanel = false;
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(604, 407);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControlAdv1);
            this.Name = "AboutView";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageAdv1.ResumeLayout(false);
            this.tabPageAdv1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageAdv2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAssemblyFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assembliesGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv2;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private System.Windows.Forms.ImageList imageList1;
        private Controls.AssembliesGrid assembliesGrid1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cboAssemblyFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGdalVersion;
        private System.Windows.Forms.Label lblOcxVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}