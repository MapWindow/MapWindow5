using MW5.Configuration.Plugins;
using MW5.UI.Controls;

namespace MW5.Configuration
{
    partial class PluginsConfigPage
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
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.pluginGrid1 = new MW5.Configuration.PluginGrid();
            ((System.ComponentModel.ISupportInitialize)(this.pluginGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(13, 356);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(67, 17);
            this.chkSelectAll.TabIndex = 1;
            this.chkSelectAll.Text = "SelectAll";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // pluginGrid1
            // 
            this.pluginGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginGrid1.Appearance.AnyCell.Borders.Bottom = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.pluginGrid1.Appearance.AnyCell.Borders.Left = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.pluginGrid1.Appearance.AnyCell.Borders.Right = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.pluginGrid1.Appearance.AnyCell.Borders.Top = new Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.None);
            this.pluginGrid1.Appearance.AnyCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            this.pluginGrid1.BackColor = System.Drawing.SystemColors.Window;
            this.pluginGrid1.FreezeCaption = false;
            this.pluginGrid1.Location = new System.Drawing.Point(3, 3);
            this.pluginGrid1.Name = "pluginGrid1";
            this.pluginGrid1.Size = new System.Drawing.Size(334, 347);
            this.pluginGrid1.TabIndex = 0;
            this.pluginGrid1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None;
            this.pluginGrid1.TableOptions.AllowDropDownCell = true;
            this.pluginGrid1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None;
            this.pluginGrid1.TableOptions.ListBoxSelectionColorOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionColorOptions.ApplySelectionColor;
            this.pluginGrid1.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.pluginGrid1.TableOptions.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.pluginGrid1.TableOptions.SelectionTextColor = System.Drawing.Color.Black;
            this.pluginGrid1.Text = "pluginGrid1";
            this.pluginGrid1.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = false;
            this.pluginGrid1.TopLevelGroupOptions.ShowCaption = false;
            this.pluginGrid1.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.pluginGrid1.VersionInfo = "5.0.1.0";
            this.pluginGrid1.WrapWithPanel = false;
            // 
            // PluginsConfigPage
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.pluginGrid1);
            this.Name = "PluginsConfigPage";
            this.Size = new System.Drawing.Size(337, 377);
            ((System.ComponentModel.ISupportInitialize)(this.pluginGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PluginGrid pluginGrid1;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}
