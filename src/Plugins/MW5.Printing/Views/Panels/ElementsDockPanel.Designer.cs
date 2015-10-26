namespace MW5.Plugins.Printing.Views.Panels
{
    partial class ElementsDockPanel
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
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolMoveDown = new System.Windows.Forms.ToolStripButton();
            this.toolMoveUp = new System.Windows.Forms.ToolStripButton();
            this.toolRemove = new System.Windows.Forms.ToolStripButton();
            this.layoutListBox1 = new MW5.Plugins.Printing.Controls.LayoutListBox();
            this.toolStripEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMoveDown,
            this.toolMoveUp,
            this.toolRemove});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.ShowItemToolTips = true;
            this.toolStripEx1.Size = new System.Drawing.Size(265, 37);
            this.toolStripEx1.TabIndex = 2;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // toolMoveDown
            // 
            this.toolMoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMoveDown.Image = global::MW5.Plugins.Printing.Properties.Resources.img_down24;
            this.toolMoveDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolMoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMoveDown.Name = "toolMoveDown";
            this.toolMoveDown.Padding = new System.Windows.Forms.Padding(3);
            this.toolMoveDown.Size = new System.Drawing.Size(34, 34);
            this.toolMoveDown.Text = "Move Down";
            // 
            // toolMoveUp
            // 
            this.toolMoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMoveUp.Image = global::MW5.Plugins.Printing.Properties.Resources.img_up24;
            this.toolMoveUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolMoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMoveUp.Name = "toolMoveUp";
            this.toolMoveUp.Padding = new System.Windows.Forms.Padding(3);
            this.toolMoveUp.Size = new System.Drawing.Size(34, 34);
            this.toolMoveUp.Text = "Move Up";
            // 
            // toolRemove
            // 
            this.toolRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRemove.Image = global::MW5.Plugins.Printing.Properties.Resources.img_remove24;
            this.toolRemove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRemove.Name = "toolRemove";
            this.toolRemove.Padding = new System.Windows.Forms.Padding(3);
            this.toolRemove.Size = new System.Drawing.Size(34, 34);
            this.toolRemove.Text = "Remove Selected";
            // 
            // layoutListBox1
            // 
            this.layoutListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutListBox1.LayoutControl = null;
            this.layoutListBox1.Location = new System.Drawing.Point(0, 37);
            this.layoutListBox1.Name = "layoutListBox1";
            this.layoutListBox1.Size = new System.Drawing.Size(265, 277);
            this.layoutListBox1.TabIndex = 0;
            // 
            // ElementsDockPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutListBox1);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "ElementsDockPanel";
            this.Size = new System.Drawing.Size(265, 314);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton toolMoveDown;
        private System.Windows.Forms.ToolStripButton toolMoveUp;
        private System.Windows.Forms.ToolStripButton toolRemove;
        internal Controls.LayoutListBox layoutListBox1;
    }
}
