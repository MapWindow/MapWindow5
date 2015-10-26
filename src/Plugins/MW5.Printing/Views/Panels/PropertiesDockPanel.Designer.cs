using System.Windows.Forms;
using MW5.Plugins.Printing.Controls.Layout;

namespace MW5.Plugins.Printing.Views.Panels
{
    partial class PropertiesDockPanel
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesDockPanel));
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _propertyGrid
            // 
            this._propertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            resources.ApplyResources(this._propertyGrid, "_propertyGrid");
            this._propertyGrid.HelpBorderColor = System.Drawing.SystemColors.Control;
            this._propertyGrid.Name = "_propertyGrid";
            this._propertyGrid.ToolbarVisible = false;
            this._propertyGrid.ViewBorderColor = System.Drawing.SystemColors.Window;
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolGroup});
            resources.ApplyResources(this.toolStripEx1, "toolStripEx1");
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.ShowItemToolTips = true;
            // 
            // toolGroup
            // 
            this.toolGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolGroup.Image = global::MW5.Plugins.Printing.Properties.Resources.img_group24;
            resources.ApplyResources(this.toolGroup, "toolGroup");
            this.toolGroup.Name = "toolGroup";
            this.toolGroup.Padding = new System.Windows.Forms.Padding(3);
            this.toolGroup.Click += new System.EventHandler(this.OnGroupClick);
            // 
            // PropertiesDockPanel
            // 
            this.Controls.Add(this._propertyGrid);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "PropertiesDockPanel";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LayoutPropertyGridKeyUp);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LayoutControl _layoutControl;
        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private ToolStripButton toolGroup;
        private PropertyGrid _propertyGrid;
    }
}
