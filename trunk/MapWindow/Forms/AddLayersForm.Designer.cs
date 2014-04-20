namespace MapWindow.Forms
{
    partial class AddLayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLayersForm));
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel1 = new Syncfusion.Windows.Forms.CaptionLabel();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageShapefile = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.tabPageGrid = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPageImage = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPageDatabase = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.tabPageWebservice = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageShapefile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(629, 438);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControlAdv1.Controls.Add(this.tabPageShapefile);
            this.tabControlAdv1.Controls.Add(this.tabPageGrid);
            this.tabControlAdv1.Controls.Add(this.tabPageImage);
            this.tabControlAdv1.Controls.Add(this.tabPageDatabase);
            this.tabControlAdv1.Controls.Add(this.tabPageWebservice);
            this.tabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(120, 23);
            this.tabControlAdv1.Location = new System.Drawing.Point(0, 0);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(629, 438);
            this.tabControlAdv1.TabIndex = 0;
            // 
            // tabPageShapefile
            // 
            this.tabPageShapefile.Controls.Add(this.autoLabel1);
            this.tabPageShapefile.Image = ((System.Drawing.Image)(resources.GetObject("tabPageShapefile.Image")));
            this.tabPageShapefile.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageShapefile.Location = new System.Drawing.Point(123, 1);
            this.tabPageShapefile.Name = "tabPageShapefile";
            this.tabPageShapefile.ShowCloseButton = true;
            this.tabPageShapefile.Size = new System.Drawing.Size(505, 436);
            this.tabPageShapefile.TabIndex = 1;
            this.tabPageShapefile.Text = "Shapefile";
            this.tabPageShapefile.ThemesEnabled = false;
            // 
            // autoLabel1
            // 
            this.autoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoLabel1.Location = new System.Drawing.Point(134, 8);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Position = Syncfusion.Windows.Forms.Tools.AutoLabelPosition.Top;
            this.autoLabel1.Size = new System.Drawing.Size(201, 25);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "Select a shapefile";
            // 
            // tabPageGrid
            // 
            this.tabPageGrid.Image = ((System.Drawing.Image)(resources.GetObject("tabPageGrid.Image")));
            this.tabPageGrid.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageGrid.Location = new System.Drawing.Point(123, 1);
            this.tabPageGrid.Name = "tabPageGrid";
            this.tabPageGrid.ShowCloseButton = true;
            this.tabPageGrid.Size = new System.Drawing.Size(505, 452);
            this.tabPageGrid.TabIndex = 2;
            this.tabPageGrid.Text = "Grid";
            this.tabPageGrid.ThemesEnabled = false;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Image = ((System.Drawing.Image)(resources.GetObject("tabPageImage.Image")));
            this.tabPageImage.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageImage.Location = new System.Drawing.Point(123, 1);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.ShowCloseButton = true;
            this.tabPageImage.Size = new System.Drawing.Size(505, 452);
            this.tabPageImage.TabIndex = 3;
            this.tabPageImage.Text = "Image";
            this.tabPageImage.ThemesEnabled = false;
            // 
            // tabPageDatabase
            // 
            this.tabPageDatabase.Image = ((System.Drawing.Image)(resources.GetObject("tabPageDatabase.Image")));
            this.tabPageDatabase.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageDatabase.Location = new System.Drawing.Point(123, 1);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.ShowCloseButton = true;
            this.tabPageDatabase.Size = new System.Drawing.Size(505, 452);
            this.tabPageDatabase.TabIndex = 4;
            this.tabPageDatabase.Text = "Geodatabase";
            this.tabPageDatabase.ThemesEnabled = false;
            // 
            // tabPageWebservice
            // 
            this.tabPageWebservice.Image = ((System.Drawing.Image)(resources.GetObject("tabPageWebservice.Image")));
            this.tabPageWebservice.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageWebservice.Location = new System.Drawing.Point(123, 1);
            this.tabPageWebservice.Name = "tabPageWebservice";
            this.tabPageWebservice.ShowCloseButton = true;
            this.tabPageWebservice.Size = new System.Drawing.Size(505, 452);
            this.tabPageWebservice.TabIndex = 5;
            this.tabPageWebservice.Text = "Webservice";
            this.tabPageWebservice.ThemesEnabled = false;
            // 
            // AddLayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.CaptionBarHeight = 48;
            this.CaptionFont = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            captionImage1.BackColor = System.Drawing.Color.Transparent;
            captionImage1.Image = ((System.Drawing.Image)(resources.GetObject("captionImage1.Image")));
            captionImage1.Location = new System.Drawing.Point(10, 8);
            captionImage1.Name = "CaptionImage1";
            captionImage1.Size = new System.Drawing.Size(32, 32);
            this.CaptionImages.Add(captionImage1);
            captionLabel1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            captionLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            captionLabel1.Location = new System.Drawing.Point(50, 4);
            captionLabel1.Name = "CaptionLabel1";
            captionLabel1.Size = new System.Drawing.Size(400, 40);
            captionLabel1.Text = "Add Geospatial data";
            this.CaptionLabels.Add(captionLabel1);
            this.ClientSize = new System.Drawing.Size(629, 438);
            this.Controls.Add(this.tabControlAdv1);
            this.DropShadow = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddLayersForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageShapefile.ResumeLayout(false);
            this.tabPageShapefile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageShapefile;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageGrid;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageImage;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageDatabase;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageWebservice;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
    }
}