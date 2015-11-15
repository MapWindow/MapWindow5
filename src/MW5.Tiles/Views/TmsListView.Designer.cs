namespace MW5.Tiles.Views
{
    partial class TmsListView
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
            this.btnAdd = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRemove = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnEdit = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnClear = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tileProviderGrid1 = new MW5.Tiles.Controls.TileProviderGrid();
            ((System.ComponentModel.ISupportInitialize)(this.tileProviderGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnAdd.IsBackStageButton = false;
            this.btnAdd.Location = new System.Drawing.Point(483, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnRemove.IsBackStageButton = false;
            this.btnRemove.Location = new System.Drawing.Point(483, 70);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnEdit.IsBackStageButton = false;
            this.btnEdit.Location = new System.Drawing.Point(483, 41);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnClear.IsBackStageButton = false;
            this.btnClear.Location = new System.Drawing.Point(483, 99);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(483, 281);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            // 
            // tileProviderGrid1
            // 
            this.tileProviderGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.tileProviderGrid1.FreezeCaption = false;
            this.tileProviderGrid1.Location = new System.Drawing.Point(12, 12);
            this.tileProviderGrid1.Name = "tileProviderGrid1";
            this.tileProviderGrid1.Size = new System.Drawing.Size(465, 292);
            this.tileProviderGrid1.TabIndex = 0;
            this.tileProviderGrid1.TableDescriptor.AllowEdit = false;
            this.tileProviderGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.tileProviderGrid1.TableOptions.AllowDropDownCell = false;
            this.tileProviderGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.tileProviderGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.tileProviderGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.tileProviderGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.tileProviderGrid1.Text = "tileProviderGrid1";
            this.tileProviderGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.tileProviderGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.tileProviderGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.tileProviderGrid1.WrapWithPanel = true;
            // 
            // TmsListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 316);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tileProviderGrid1);
            this.Name = "TmsListView";
            this.Text = "Custom Tile Providers";
            ((System.ComponentModel.ISupportInitialize)(this.tileProviderGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnAdd;
        private Syncfusion.Windows.Forms.ButtonAdv btnRemove;
        private Syncfusion.Windows.Forms.ButtonAdv btnEdit;
        private Syncfusion.Windows.Forms.ButtonAdv btnClear;
        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Controls.TileProviderGrid tileProviderGrid1;
    }
}