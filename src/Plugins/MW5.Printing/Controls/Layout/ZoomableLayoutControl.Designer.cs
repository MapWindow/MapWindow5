using System.Windows.Forms;
using MW5.Plugins.Printing.Controls.PropertyGrid;
using MW5.Plugins.Printing.Views.Panels;

namespace MW5.Plugins.Printing.Controls.Layout
{
    partial class ZoomableLayoutControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any Resources. being used.
        /// </summary>
        /// <param name="disposing">true if managed Resources. should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoomableLayoutControl));
            this.SuspendLayout();
            // 
            // ZoomableLayoutControl
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "ZoomableLayoutControl";
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        protected LayoutListBox _layoutListBox;
        protected PropertiesDockPanel _layoutPropertyGrip;
    }
}
