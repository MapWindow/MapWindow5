namespace MW5.Plugins.Symbology.Views
{
    partial class RasterColorSchemeView
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
            this.rasterColorSchemeGrid1 = new MW5.Plugins.Symbology.Controls.RasterColorSchemeGrid();
            this.btnCancel = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnOk = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnAddInterval = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRemoveInterval = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.chkGradientWithinCategory = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            ((System.ComponentModel.ISupportInitialize)(this.rasterColorSchemeGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGradientWithinCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // rasterColorSchemeGrid1
            // 
            this.rasterColorSchemeGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rasterColorSchemeGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.rasterColorSchemeGrid1.Extended = false;
            this.rasterColorSchemeGrid1.FreezeCaption = false;
            this.rasterColorSchemeGrid1.Location = new System.Drawing.Point(12, 12);
            this.rasterColorSchemeGrid1.Name = "rasterColorSchemeGrid1";
            this.rasterColorSchemeGrid1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.rasterColorSchemeGrid1.ShowGradient = true;
            this.rasterColorSchemeGrid1.Size = new System.Drawing.Size(525, 397);
            this.rasterColorSchemeGrid1.TabIndex = 18;
            this.rasterColorSchemeGrid1.TableDescriptor.VisibleColumns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor[] {
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Visible"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("LowColor"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HighColor"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Range")});
            this.rasterColorSchemeGrid1.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.rasterColorSchemeGrid1.WrapWithPanel = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(535, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2000;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(444, 415);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 39;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyle = false;
            // 
            // btnAddInterval
            // 
            this.btnAddInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInterval.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnAddInterval.IsBackStageButton = false;
            this.btnAddInterval.Location = new System.Drawing.Point(549, 12);
            this.btnAddInterval.Name = "btnAddInterval";
            this.btnAddInterval.Size = new System.Drawing.Size(75, 23);
            this.btnAddInterval.TabIndex = 41;
            this.btnAddInterval.Text = "Add";
            // 
            // btnRemoveInterval
            // 
            this.btnRemoveInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveInterval.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnRemoveInterval.IsBackStageButton = false;
            this.btnRemoveInterval.Location = new System.Drawing.Point(549, 41);
            this.btnRemoveInterval.Name = "btnRemoveInterval";
            this.btnRemoveInterval.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveInterval.TabIndex = 42;
            this.btnRemoveInterval.Text = "Remove";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(549, 70);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 43;
            this.btnClear.Text = "Clear";
            // 
            // chkGradientWithinCategory
            // 
            this.chkGradientWithinCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkGradientWithinCategory.BeforeTouchSize = new System.Drawing.Size(159, 21);
            this.chkGradientWithinCategory.Location = new System.Drawing.Point(12, 415);
            this.chkGradientWithinCategory.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.chkGradientWithinCategory.Name = "chkGradientWithinCategory";
            this.chkGradientWithinCategory.Size = new System.Drawing.Size(159, 21);
            this.chkGradientWithinCategory.TabIndex = 44;
            this.chkGradientWithinCategory.Text = "Gradient within category";
            this.chkGradientWithinCategory.ThemesEnabled = false;
            this.chkGradientWithinCategory.CheckStateChanged += new System.EventHandler(this.chkGradientWithinCategory_CheckStateChanged);
            // 
            // RasterColorSchemeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.chkGradientWithinCategory);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemoveInterval);
            this.Controls.Add(this.btnAddInterval);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rasterColorSchemeGrid1);
            this.Name = "RasterColorSchemeView";
            this.Text = "Edit raster color scheme";
            ((System.ComponentModel.ISupportInitialize)(this.rasterColorSchemeGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGradientWithinCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.RasterColorSchemeGrid rasterColorSchemeGrid1;
        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private Syncfusion.Windows.Forms.ButtonAdv btnAddInterval;
        private Syncfusion.Windows.Forms.ButtonAdv btnRemoveInterval;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkGradientWithinCategory;
    }
}