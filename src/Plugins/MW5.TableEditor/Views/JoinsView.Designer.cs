namespace MW5.Plugins.TableEditor.Views
{
    partial class JoinsView
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
            this.btnEditJoin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.joinsGrid1 = new MW5.Plugins.TableEditor.Controls.JoinsGrid();
            ((System.ComponentModel.ISupportInitialize)(this.joinsGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditJoin
            // 
            this.btnEditJoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditJoin.Location = new System.Drawing.Point(569, 44);
            this.btnEditJoin.Name = "btnEditJoin";
            this.btnEditJoin.Size = new System.Drawing.Size(81, 26);
            this.btnEditJoin.TabIndex = 10;
            this.btnEditJoin.Text = "Edit join";
            this.btnEditJoin.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(569, 321);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 26);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnStopAll
            // 
            this.btnStopAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopAll.Location = new System.Drawing.Point(569, 107);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(81, 26);
            this.btnStopAll.TabIndex = 8;
            this.btnStopAll.Text = "Stop all";
            this.btnStopAll.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(569, 75);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 26);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop join";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnJoin
            // 
            this.btnJoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJoin.Location = new System.Drawing.Point(569, 12);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(81, 26);
            this.btnJoin.TabIndex = 6;
            this.btnJoin.Text = "Add";
            this.btnJoin.UseVisualStyleBackColor = true;
            // 
            // joinsGrid1
            // 
            this.joinsGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.joinsGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.joinsGrid1.FreezeCaption = false;
            this.joinsGrid1.Location = new System.Drawing.Point(12, 12);
            this.joinsGrid1.Name = "joinsGrid1";
            this.joinsGrid1.Size = new System.Drawing.Size(551, 335);
            this.joinsGrid1.TabIndex = 11;
            this.joinsGrid1.TableDescriptor.AllowEdit = false;
            this.joinsGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.joinsGrid1.TableOptions.AllowDropDownCell = false;
            this.joinsGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.joinsGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.joinsGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.joinsGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.joinsGrid1.Text = "joinsGrid1";
            this.joinsGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.joinsGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.joinsGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.joinsGrid1.VersionInfo = "0.0.1.0";
            this.joinsGrid1.WrapWithPanel = true;
            // 
            // JoinsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(653, 359);
            this.Controls.Add(this.joinsGrid1);
            this.Controls.Add(this.btnEditJoin);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStopAll);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnJoin);
            this.Name = "JoinsView";
            this.Text = "Table Joins";
            ((System.ComponentModel.ISupportInitialize)(this.joinsGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditJoin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnJoin;
        private Controls.JoinsGrid joinsGrid1;
    }
}