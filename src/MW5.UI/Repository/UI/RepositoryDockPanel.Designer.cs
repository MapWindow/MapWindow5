using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MW5.UI.Properties;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Repository.UI
{
    partial class RepositoryDockPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.treeViewAdv1 = new MW5.UI.Repository.UI.RepositoryTreeView();
            this.toolAddFolder = new System.Windows.Forms.ToolStripButton();
            this.toolRemoveFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewAdv1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAddFolder,
            this.toolRemoveFolder});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.Size = new System.Drawing.Size(330, 37);
            this.toolStripEx1.TabIndex = 1;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // treeViewAdv1
            // 
            this.treeViewAdv1.BackColor = System.Drawing.Color.White;
            this.treeViewAdv1.BeforeTouchSize = new System.Drawing.Size(330, 378);
            this.treeViewAdv1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.treeViewAdv1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None;
            this.treeViewAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAdv1.CanSelectDisabledNode = false;
            this.treeViewAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.treeViewAdv1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewAdv1.HelpTextControl.Name = "helpText";
            this.treeViewAdv1.HelpTextControl.Size = new System.Drawing.Size(51, 17);
            this.treeViewAdv1.HelpTextControl.TabIndex = 0;
            this.treeViewAdv1.HelpTextControl.Text = "help text";
            this.treeViewAdv1.ItemHeight = 18;
            this.treeViewAdv1.LoadOnDemand = true;
            this.treeViewAdv1.Location = new System.Drawing.Point(0, 37);
            this.treeViewAdv1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.treeViewAdv1.Name = "treeViewAdv1";
            this.treeViewAdv1.SelectedNodeBackground = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220))))));
            this.treeViewAdv1.ShowFocusRect = false;
            this.treeViewAdv1.Size = new System.Drawing.Size(330, 378);
            this.treeViewAdv1.Style = Syncfusion.Windows.Forms.Tools.TreeStyle.Metro;
            this.treeViewAdv1.TabIndex = 0;
            this.treeViewAdv1.Text = "treeViewAdv1";
            // 
            // 
            // 
            this.treeViewAdv1.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.treeViewAdv1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.treeViewAdv1.ToolTipControl.Name = "toolTip";
            this.treeViewAdv1.ToolTipControl.Size = new System.Drawing.Size(43, 17);
            this.treeViewAdv1.ToolTipControl.TabIndex = 1;
            this.treeViewAdv1.ToolTipControl.Text = "toolTip";
            this.treeViewAdv1.ToolTipDuration = 3000;
            // 
            // toolAddFolder
            // 
            this.toolAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddFolder.Image = global::MW5.UI.Properties.Resources.img_folder_add;
            this.toolAddFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAddFolder.Name = "toolAddFolder";
            this.toolAddFolder.Padding = new System.Windows.Forms.Padding(3);
            this.toolAddFolder.Size = new System.Drawing.Size(34, 34);
            this.toolAddFolder.Text = "Add linked folder";
            // 
            // toolRemoveFolder
            // 
            this.toolRemoveFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolRemoveFolder.Image = global::MW5.UI.Properties.Resources.img_folder_delete;
            this.toolRemoveFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolRemoveFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRemoveFolder.Name = "toolRemoveFolder";
            this.toolRemoveFolder.Padding = new System.Windows.Forms.Padding(3);
            this.toolRemoveFolder.Size = new System.Drawing.Size(34, 34);
            this.toolRemoveFolder.Text = "Remove linked folder";
            // 
            // RepositoryDockPanel
            // 
            this.Controls.Add(this.treeViewAdv1);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "RepositoryDockPanel";
            this.Size = new System.Drawing.Size(330, 415);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeViewAdv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RepositoryTreeView treeViewAdv1;
        private ToolStripEx toolStripEx1;
        private ToolStripButton toolAddFolder;
        private ToolStripButton toolRemoveFolder;
    }
}
