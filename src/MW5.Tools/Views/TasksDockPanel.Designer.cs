namespace MW5.Tools.Views
{
    partial class TasksDockPanel
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
            this.components = new System.ComponentModel.Container();
            this.toolStripEx1 = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.toolClear = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStripEx1 = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.toolOpenLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRerun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRunAnother = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolCancelTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPauseTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolRemoveTask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.tasksTreeView1 = new MW5.Tools.Views.TasksTreeView();
            this.toolStripEx1.SuspendLayout();
            this.contextMenuStripEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTreeView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripEx1
            // 
            this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.toolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripEx1.Image = null;
            this.toolStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClear});
            this.toolStripEx1.Location = new System.Drawing.Point(0, 0);
            this.toolStripEx1.Name = "toolStripEx1";
            this.toolStripEx1.ShowCaption = false;
            this.toolStripEx1.ShowItemToolTips = true;
            this.toolStripEx1.Size = new System.Drawing.Size(238, 37);
            this.toolStripEx1.TabIndex = 2;
            this.toolStripEx1.Text = "toolStripEx1";
            // 
            // toolClear
            // 
            this.toolClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClear.Image = global::MW5.Tools.Properties.Resources.img_clear24;
            this.toolClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClear.Name = "toolClear";
            this.toolClear.Padding = new System.Windows.Forms.Padding(3);
            this.toolClear.Size = new System.Drawing.Size(34, 34);
            this.toolClear.Text = "Clear All";
            // 
            // contextMenuStripEx1
            // 
            this.contextMenuStripEx1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenLog,
            this.toolRerun,
            this.toolRunAnother,
            this.toolStripSeparator2,
            this.toolCancelTask,
            this.toolPauseTask,
            this.toolStripSeparator1,
            this.toolRemoveTask,
            this.mnuRemoveOutput});
            this.contextMenuStripEx1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.contextMenuStripEx1.Name = "contextMenuStripEx1";
            this.contextMenuStripEx1.Size = new System.Drawing.Size(204, 170);
            this.contextMenuStripEx1.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Default;
            // 
            // toolOpenLog
            // 
            this.toolOpenLog.Name = "toolOpenLog";
            this.toolOpenLog.Size = new System.Drawing.Size(203, 22);
            this.toolOpenLog.Text = "Open log";
            // 
            // toolRerun
            // 
            this.toolRerun.Name = "toolRerun";
            this.toolRerun.Size = new System.Drawing.Size(203, 22);
            this.toolRerun.Text = "Rerun";
            // 
            // toolRunAnother
            // 
            this.toolRunAnother.Name = "toolRunAnother";
            this.toolRunAnother.Size = new System.Drawing.Size(203, 22);
            this.toolRunAnother.Text = "Run another";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // toolCancelTask
            // 
            this.toolCancelTask.Name = "toolCancelTask";
            this.toolCancelTask.Size = new System.Drawing.Size(203, 22);
            this.toolCancelTask.Text = "Cancel";
            // 
            // toolPauseTask
            // 
            this.toolPauseTask.Name = "toolPauseTask";
            this.toolPauseTask.Size = new System.Drawing.Size(203, 22);
            this.toolPauseTask.Text = "Pause";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // toolRemoveTask
            // 
            this.toolRemoveTask.Name = "toolRemoveTask";
            this.toolRemoveTask.Size = new System.Drawing.Size(203, 22);
            this.toolRemoveTask.Text = "Remove";
            // 
            // mnuRemoveOutput
            // 
            this.mnuRemoveOutput.Name = "mnuRemoveOutput";
            this.mnuRemoveOutput.Size = new System.Drawing.Size(203, 22);
            this.mnuRemoveOutput.Text = "Remove task and output";
            // 
            // tasksTreeView1
            // 
            this.tasksTreeView1.ApplyStyle = true;
            this.tasksTreeView1.BeforeTouchSize = new System.Drawing.Size(238, 218);
            this.tasksTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tasksTreeView1.CanSelectDisabledNode = false;
            this.tasksTreeView1.ContextMenuStrip = this.contextMenuStripEx1;
            this.tasksTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.tasksTreeView1.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tasksTreeView1.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.tasksTreeView1.HelpTextControl.Name = "helpText";
            this.tasksTreeView1.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.tasksTreeView1.HelpTextControl.TabIndex = 0;
            this.tasksTreeView1.HelpTextControl.Text = "help text";
            this.tasksTreeView1.Location = new System.Drawing.Point(0, 37);
            this.tasksTreeView1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.tasksTreeView1.Name = "tasksTreeView1";
            this.tasksTreeView1.ShowFocusRect = true;
            this.tasksTreeView1.ShowSuperTooltip = false;
            this.tasksTreeView1.Size = new System.Drawing.Size(238, 218);
            this.tasksTreeView1.TabIndex = 3;
            this.tasksTreeView1.Text = "_gisResultsTreeView1";
            // 
            // 
            // 
            this.tasksTreeView1.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.tasksTreeView1.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tasksTreeView1.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.tasksTreeView1.ToolTipControl.Name = "toolTip";
            this.tasksTreeView1.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.tasksTreeView1.ToolTipControl.TabIndex = 1;
            this.tasksTreeView1.ToolTipControl.Text = "toolTip";
            this.tasksTreeView1.ToolTipDuration = 0;
            // 
            // TasksDockPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tasksTreeView1);
            this.Controls.Add(this.toolStripEx1);
            this.Name = "TasksDockPanel";
            this.Size = new System.Drawing.Size(238, 255);
            this.toolStripEx1.ResumeLayout(false);
            this.toolStripEx1.PerformLayout();
            this.contextMenuStripEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tasksTreeView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.ToolStripEx toolStripEx1;
        private System.Windows.Forms.ToolStripButton toolClear;
        private TasksTreeView tasksTreeView1;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx contextMenuStripEx1;
        private System.Windows.Forms.ToolStripMenuItem toolOpenLog;
        private System.Windows.Forms.ToolStripMenuItem toolCancelTask;
        private System.Windows.Forms.ToolStripMenuItem toolPauseTask;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolRemoveTask;
        private System.Windows.Forms.ToolStripMenuItem toolRerun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolRunAnother;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveOutput;
    }
}
