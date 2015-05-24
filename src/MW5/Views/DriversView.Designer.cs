namespace MW5.Views
{
    partial class DriversView
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
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.driversGrid1 = new MW5.Controls.DriversGrid();
            ((System.ComponentModel.ISupportInitialize)(this.driversGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(451, 324);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 26);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // driversGrid1
            // 
            this.driversGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.driversGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.driversGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.driversGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.driversGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.driversGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.driversGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.driversGrid1.FreezeCaption = false;
            this.driversGrid1.Location = new System.Drawing.Point(12, 12);
            this.driversGrid1.Name = "driversGrid1";
            this.driversGrid1.Size = new System.Drawing.Size(529, 306);
            this.driversGrid1.TabIndex = 9;
            this.driversGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.driversGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.driversGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.driversGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.driversGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.driversGrid1.Text = "driversGrid1";
            this.driversGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.driversGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.driversGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.driversGrid1.VersionInfo = "5.0.1.0";
            this.driversGrid1.WrapWithPanel = true;
            // 
            // DriversView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(553, 362);
            this.Controls.Add(this.driversGrid1);
            this.Controls.Add(this.btnClose);
            this.Name = "DriversView";
            this.Text = "Supported GDAL drivers";
            ((System.ComponentModel.ISupportInitialize)(this.driversGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Controls.DriversGrid driversGrid1;
    }
}