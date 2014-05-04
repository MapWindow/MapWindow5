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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLayersForm));
            Syncfusion.Windows.Forms.CaptionImage captionImage1 = new Syncfusion.Windows.Forms.CaptionImage();
            Syncfusion.Windows.Forms.CaptionLabel captionLabel1 = new Syncfusion.Windows.Forms.CaptionLabel();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageShapefile = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SelectShapefileButton = new System.Windows.Forms.Button();
            this.SelectShapefileTextbox = new System.Windows.Forms.TextBox();
            this.gradientLabel1 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.tabPageGrid = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientLabel2 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.tabPageImage = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientLabel3 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.tabPageDatabase = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientLabel4 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.tabPageWebservice = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.gradientLabel5 = new Syncfusion.Windows.Forms.Tools.GradientLabel();
            this.buttonAdv1 = new Syncfusion.Windows.Forms.ButtonAdv();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageShapefile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.tabPageGrid.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            this.tabPageDatabase.SuspendLayout();
            this.tabPageWebservice.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(550, 490);
            this.tabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControlAdv1.BorderWidth = 0;
            this.tabControlAdv1.Controls.Add(this.tabPageShapefile);
            this.tabControlAdv1.Controls.Add(this.tabPageGrid);
            this.tabControlAdv1.Controls.Add(this.tabPageImage);
            this.tabControlAdv1.Controls.Add(this.tabPageDatabase);
            this.tabControlAdv1.Controls.Add(this.tabPageWebservice);
            this.tabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdv1.FocusOnTabClick = false;
            this.tabControlAdv1.ItemSize = new System.Drawing.Size(120, 23);
            this.tabControlAdv1.Location = new System.Drawing.Point(0, 0);
            this.tabControlAdv1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.RotateTextWhenVertical = true;
            this.tabControlAdv1.Size = new System.Drawing.Size(550, 490);
            this.tabControlAdv1.TabGap = 10;
            this.tabControlAdv1.TabIndex = 2;
            this.tabControlAdv1.TabPanelBackColor = System.Drawing.Color.Transparent;
            this.tabControlAdv1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.tabControlAdv1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.tabControlAdv1.DrawItem += new Syncfusion.Windows.Forms.Tools.DrawTabEventHandler(this.TabControlAdv1DrawItem);
            // 
            // tabPageShapefile
            // 
            this.tabPageShapefile.Controls.Add(this.gradientPanel1);
            this.tabPageShapefile.Image = ((System.Drawing.Image)(resources.GetObject("tabPageShapefile.Image")));
            this.tabPageShapefile.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageShapefile.Location = new System.Drawing.Point(122, 0);
            this.tabPageShapefile.Name = "tabPageShapefile";
            this.tabPageShapefile.ShowCloseButton = false;
            this.tabPageShapefile.Size = new System.Drawing.Size(428, 490);
            this.tabPageShapefile.TabIndex = 1;
            this.tabPageShapefile.Text = "Shapefile";
            this.tabPageShapefile.ThemesEnabled = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.White;
            this.gradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientPanel1.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.gradientPanel1.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel1.Controls.Add(this.buttonAdv1);
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Controls.Add(this.SelectShapefileButton);
            this.gradientPanel1.Controls.Add(this.SelectShapefileTextbox);
            this.gradientPanel1.Controls.Add(this.gradientLabel1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(428, 490);
            this.gradientPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(34, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 290);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // SelectShapefileButton
            // 
            this.SelectShapefileButton.AutoSize = true;
            this.SelectShapefileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SelectShapefileButton.Location = new System.Drawing.Point(353, 61);
            this.SelectShapefileButton.Name = "SelectShapefileButton";
            this.SelectShapefileButton.Size = new System.Drawing.Size(26, 23);
            this.SelectShapefileButton.TabIndex = 2;
            this.SelectShapefileButton.Text = "...";
            this.SelectShapefileButton.UseVisualStyleBackColor = true;
            this.SelectShapefileButton.Click += new System.EventHandler(this.SelectShapefileButtonClick);
            // 
            // SelectShapefileTextbox
            // 
            this.SelectShapefileTextbox.Location = new System.Drawing.Point(34, 61);
            this.SelectShapefileTextbox.Name = "SelectShapefileTextbox";
            this.SelectShapefileTextbox.Size = new System.Drawing.Size(313, 20);
            this.SelectShapefileTextbox.TabIndex = 1;
            // 
            // gradientLabel1
            // 
            this.gradientLabel1.AutoEllipsis = true;
            this.gradientLabel1.AutoSize = true;
            this.gradientLabel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel1.BeforeTouchSize = new System.Drawing.Size(188, 37);
            this.gradientLabel1.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel1.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel1.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel1.Location = new System.Drawing.Point(120, 9);
            this.gradientLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel1.Name = "gradientLabel1";
            this.gradientLabel1.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel1.Size = new System.Drawing.Size(188, 37);
            this.gradientLabel1.TabIndex = 0;
            this.gradientLabel1.Text = "Add a shapefile";
            this.gradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageGrid
            // 
            this.tabPageGrid.Controls.Add(this.gradientLabel2);
            this.tabPageGrid.Image = ((System.Drawing.Image)(resources.GetObject("tabPageGrid.Image")));
            this.tabPageGrid.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageGrid.Location = new System.Drawing.Point(122, 0);
            this.tabPageGrid.Name = "tabPageGrid";
            this.tabPageGrid.ShowCloseButton = true;
            this.tabPageGrid.Size = new System.Drawing.Size(428, 490);
            this.tabPageGrid.TabIndex = 2;
            this.tabPageGrid.Text = "Grid";
            this.tabPageGrid.ThemesEnabled = false;
            // 
            // gradientLabel2
            // 
            this.gradientLabel2.AutoEllipsis = true;
            this.gradientLabel2.AutoSize = true;
            this.gradientLabel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel2.BeforeTouchSize = new System.Drawing.Size(132, 37);
            this.gradientLabel2.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel2.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel2.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel2.Location = new System.Drawing.Point(160, 9);
            this.gradientLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel2.Name = "gradientLabel2";
            this.gradientLabel2.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel2.Size = new System.Drawing.Size(132, 37);
            this.gradientLabel2.TabIndex = 1;
            this.gradientLabel2.Text = "Add a grid";
            this.gradientLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.gradientLabel3);
            this.tabPageImage.Image = ((System.Drawing.Image)(resources.GetObject("tabPageImage.Image")));
            this.tabPageImage.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageImage.Location = new System.Drawing.Point(122, 0);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.ShowCloseButton = true;
            this.tabPageImage.Size = new System.Drawing.Size(428, 490);
            this.tabPageImage.TabIndex = 3;
            this.tabPageImage.Text = "Image";
            this.tabPageImage.ThemesEnabled = false;
            // 
            // gradientLabel3
            // 
            this.gradientLabel3.AutoEllipsis = true;
            this.gradientLabel3.AutoSize = true;
            this.gradientLabel3.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel3.BeforeTouchSize = new System.Drawing.Size(168, 37);
            this.gradientLabel3.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel3.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel3.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel3.Location = new System.Drawing.Point(122, 9);
            this.gradientLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel3.Name = "gradientLabel3";
            this.gradientLabel3.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel3.Size = new System.Drawing.Size(168, 37);
            this.gradientLabel3.TabIndex = 1;
            this.gradientLabel3.Text = "Add an image";
            this.gradientLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageDatabase
            // 
            this.tabPageDatabase.Controls.Add(this.gradientLabel4);
            this.tabPageDatabase.Image = ((System.Drawing.Image)(resources.GetObject("tabPageDatabase.Image")));
            this.tabPageDatabase.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageDatabase.Location = new System.Drawing.Point(122, 0);
            this.tabPageDatabase.Name = "tabPageDatabase";
            this.tabPageDatabase.ShowCloseButton = true;
            this.tabPageDatabase.Size = new System.Drawing.Size(428, 490);
            this.tabPageDatabase.TabIndex = 4;
            this.tabPageDatabase.Text = "Geodatabase";
            this.tabPageDatabase.ThemesEnabled = false;
            // 
            // gradientLabel4
            // 
            this.gradientLabel4.AutoEllipsis = true;
            this.gradientLabel4.AutoSize = true;
            this.gradientLabel4.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel4.BeforeTouchSize = new System.Drawing.Size(262, 37);
            this.gradientLabel4.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel4.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel4.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel4.Location = new System.Drawing.Point(122, 9);
            this.gradientLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel4.Name = "gradientLabel4";
            this.gradientLabel4.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel4.Size = new System.Drawing.Size(262, 37);
            this.gradientLabel4.TabIndex = 1;
            this.gradientLabel4.Text = "Connect to a database";
            this.gradientLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageWebservice
            // 
            this.tabPageWebservice.Controls.Add(this.gradientLabel5);
            this.tabPageWebservice.Image = ((System.Drawing.Image)(resources.GetObject("tabPageWebservice.Image")));
            this.tabPageWebservice.ImageSize = new System.Drawing.Size(24, 24);
            this.tabPageWebservice.Location = new System.Drawing.Point(122, 0);
            this.tabPageWebservice.Name = "tabPageWebservice";
            this.tabPageWebservice.ShowCloseButton = true;
            this.tabPageWebservice.Size = new System.Drawing.Size(428, 490);
            this.tabPageWebservice.TabIndex = 5;
            this.tabPageWebservice.Text = "Webservices";
            this.tabPageWebservice.ThemesEnabled = false;
            // 
            // gradientLabel5
            // 
            this.gradientLabel5.AutoEllipsis = true;
            this.gradientLabel5.AutoSize = true;
            this.gradientLabel5.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.BackwardDiagonal, System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(211)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(241))))));
            this.gradientLabel5.BeforeTouchSize = new System.Drawing.Size(283, 37);
            this.gradientLabel5.BorderAppearance = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientLabel5.BorderColor = System.Drawing.Color.SteelBlue;
            this.gradientLabel5.BorderSides = ((System.Windows.Forms.Border3DSide)((((System.Windows.Forms.Border3DSide.Left | System.Windows.Forms.Border3DSide.Top) 
            | System.Windows.Forms.Border3DSide.Right) 
            | System.Windows.Forms.Border3DSide.Bottom)));
            this.gradientLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.gradientLabel5.Location = new System.Drawing.Point(122, 9);
            this.gradientLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.gradientLabel5.Name = "gradientLabel5";
            this.gradientLabel5.Padding = new System.Windows.Forms.Padding(6);
            this.gradientLabel5.Size = new System.Drawing.Size(283, 37);
            this.gradientLabel5.TabIndex = 1;
            this.gradientLabel5.Text = "Connect to a webservice";
            this.gradientLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAdv1
            // 
            this.buttonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.buttonAdv1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.buttonAdv1.BeforeTouchSize = new System.Drawing.Size(345, 23);
            this.buttonAdv1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdv1.ForeColor = System.Drawing.Color.White;
            this.buttonAdv1.IsBackStageButton = false;
            this.buttonAdv1.Location = new System.Drawing.Point(34, 402);
            this.buttonAdv1.Name = "buttonAdv1";
            this.buttonAdv1.Size = new System.Drawing.Size(345, 23);
            this.buttonAdv1.TabIndex = 4;
            this.buttonAdv1.Text = "Open selected shapefile";
            this.buttonAdv1.UseVisualStyle = true;
            this.buttonAdv1.UseVisualStyleBackColor = false;
            this.buttonAdv1.Click += new System.EventHandler(this.ButtonAdv1Click);
            // 
            // AddLayersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(212)))), ((int)(((byte)(241)))));
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
            this.ClientSize = new System.Drawing.Size(550, 490);
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
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.tabPageGrid.ResumeLayout(false);
            this.tabPageGrid.PerformLayout();
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            this.tabPageDatabase.ResumeLayout(false);
            this.tabPageDatabase.PerformLayout();
            this.tabPageWebservice.ResumeLayout(false);
            this.tabPageWebservice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageShapefile;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageGrid;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageImage;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageDatabase;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageWebservice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SelectShapefileButton;
        private System.Windows.Forms.TextBox SelectShapefileTextbox;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel2;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel3;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel4;
        private Syncfusion.Windows.Forms.Tools.GradientLabel gradientLabel5;
        private Syncfusion.Windows.Forms.ButtonAdv buttonAdv1;


    }
}