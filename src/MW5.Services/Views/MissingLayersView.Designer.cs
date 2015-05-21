using MW5.Services.Controls;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.Services.Views
{
    partial class MissingLayersView
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
            this.missingLayersGrid1 = new MissingLayersGrid();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.missingLayersGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BeforeTouchSize = new System.Drawing.Size(85, 26);
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.IsBackStageButton = false;
            this.btnCancel.Location = new System.Drawing.Point(405, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 26);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(90, 26);
            this.btnOk.IsBackStageButton = false;
            this.btnOk.Location = new System.Drawing.Point(309, 307);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 26);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // missingLayersGrid1
            // 
            this.missingLayersGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.missingLayersGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.missingLayersGrid1.Appearance.AnyCell.Borders.Right = new GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.missingLayersGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.missingLayersGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.missingLayersGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.missingLayersGrid1.FreezeCaption = false;
            this.missingLayersGrid1.Location = new System.Drawing.Point(5, 38);
            this.missingLayersGrid1.Name = "missingLayersGrid1";
            this.missingLayersGrid1.Size = new System.Drawing.Size(495, 263);
            this.missingLayersGrid1.TabIndex = 9;
            this.missingLayersGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.missingLayersGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.missingLayersGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.None;
            this.missingLayersGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.missingLayersGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.missingLayersGrid1.Text = "missingLayersGrid1";
            this.missingLayersGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.missingLayersGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.missingLayersGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.missingLayersGrid1.VersionInfo = "5.0.1.0";
            this.missingLayersGrid1.WrapWithPanel = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "The following datasources were not found. Please specify their location manually." +
    "";
            // 
            // MissingLayersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.missingLayersGrid1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "MissingLayersView";
            this.Text = "Missing datasources";
            ((System.ComponentModel.ISupportInitialize)(this.missingLayersGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnCancel;
        private Syncfusion.Windows.Forms.ButtonAdv btnOk;
        private MissingLayersGrid missingLayersGrid1;
        private System.Windows.Forms.Label label1;
    }
}