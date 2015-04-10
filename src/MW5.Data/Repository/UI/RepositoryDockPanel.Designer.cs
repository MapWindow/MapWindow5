using System.ComponentModel;
using System.Windows.Forms;
using MW5.Data.Properties;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Repository.UI
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
            this.toolAddFolder = new System.Windows.Forms.ToolStripButton();
            this.toolRemoveFolder = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.mnuAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddFolderToMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddToMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGdalInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewAdv1 = new RepositoryTreeView();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripEx1.SuspendLayout();
            this.contextMenuStripEx1.SuspendLayout();
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
            // toolAddFolder
            // 
            this.toolAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAddFolder.Image = Resources.img_folder_add;
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
            this.toolRemoveFolder.Image = Resources.img_folder_delete;
            this.toolRemoveFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolRemoveFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRemoveFolder.Name = "toolRemoveFolder";
            this.toolRemoveFolder.Padding = new System.Windows.Forms.Padding(3);
            this.toolRemoveFolder.Size = new System.Drawing.Size(34, 34);
            this.toolRemoveFolder.Text = "Remove linked folder";
            // 
            // contextMenuStripEx1
            // 
            this.contextMenuStripEx1.DropShadowEnabled = false;
            this.contextMenuStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddFolder,
            this.mnuRemoveFolder,
            this.toolStripSeparator1,
            this.mnuAddFolderToMap,
            this.mnuRefresh,
            this.toolStripSeparator2,
            this.mnuAddToMap,
            this.mnuRemoveFile,
            this.toolStripSeparator3,
            this.mnuGdalInfo,
            this.toolStripSeparator4,
            this.mnuOpenLocation});
            this.contextMenuStripEx1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.contextMenuStripEx1.Name = "contextMenuStripEx1";
            this.contextMenuStripEx1.Size = new System.Drawing.Size(182, 226);
            this.contextMenuStripEx1.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Metro;
            // 
            // mnuAddFolder
            // 
            this.mnuAddFolder.Name = "mnuAddFolder";
            this.mnuAddFolder.Size = new System.Drawing.Size(181, 22);
            this.mnuAddFolder.Text = "Add folder link";
            // 
            // mnuRemoveFolder
            // 
            this.mnuRemoveFolder.Name = "mnuRemoveFolder";
            this.mnuRemoveFolder.Size = new System.Drawing.Size(181, 22);
            this.mnuRemoveFolder.Text = "Remove folder link";
            // 
            // mnuAddFolderToMap
            // 
            this.mnuAddFolderToMap.Name = "mnuAddFolderToMap";
            this.mnuAddFolderToMap.Size = new System.Drawing.Size(181, 22);
            this.mnuAddFolderToMap.Text = "Add files to the map";
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(181, 22);
            this.mnuRefresh.Text = "Refresh";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuAddToMap
            // 
            this.mnuAddToMap.Name = "mnuAddToMap";
            this.mnuAddToMap.Size = new System.Drawing.Size(181, 22);
            this.mnuAddToMap.Text = "Add to the map";
            // 
            // mnuRemoveFile
            // 
            this.mnuRemoveFile.Name = "mnuRemoveFile";
            this.mnuRemoveFile.Size = new System.Drawing.Size(181, 22);
            this.mnuRemoveFile.Text = "Remove file";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuGdalInfo
            // 
            this.mnuGdalInfo.Name = "mnuGdalInfo";
            this.mnuGdalInfo.Size = new System.Drawing.Size(181, 22);
            this.mnuGdalInfo.Text = "GDAL info";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuOpenLocation
            // 
            this.mnuOpenLocation.Name = "mnuOpenLocation";
            this.mnuOpenLocation.Size = new System.Drawing.Size(181, 22);
            this.mnuOpenLocation.Text = "Open file location";
            // 
            // treeViewAdv1
            // 
            this.treeViewAdv1.BackColor = System.Drawing.Color.White;
            this.treeViewAdv1.BeforeTouchSize = new System.Drawing.Size(330, 635);
            this.treeViewAdv1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.treeViewAdv1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.None;
            this.treeViewAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewAdv1.CanSelectDisabledNode = false;
            this.treeViewAdv1.ContextMenuStrip = this.contextMenuStripEx1;
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
            this.treeViewAdv1.Size = new System.Drawing.Size(330, 635);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // RepositoryDockPanel
            // 
            this.Controls.Add(this.treeViewAdv1);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "RepositoryDockPanel";
            this.Size = new System.Drawing.Size(330, 672);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.contextMenuStripEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeViewAdv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RepositoryTreeView treeViewAdv1;
        private ToolStripEx toolStripEx1;
        private ToolStripButton toolAddFolder;
        private ToolStripButton toolRemoveFolder;
        private ContextMenuStripEx contextMenuStripEx1;
        private ToolStripMenuItem mnuAddFolder;
        private ToolStripMenuItem mnuRemoveFolder;
        private ToolStripMenuItem mnuAddToMap;
        private ToolStripMenuItem mnuRemoveFile;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem mnuOpenLocation;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mnuGdalInfo;
        private ToolStripMenuItem mnuAddFolderToMap;
        private ToolStripMenuItem mnuRefresh;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator1;
    }
}
