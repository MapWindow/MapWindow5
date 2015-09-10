// -------------------------------------------------------------------------------------------
// <copyright file="TasksDockPanel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.UI.Controls;

namespace MW5.Tools.Views
{
    /// <summary>
    /// Represents dock panel with list of active and finished tasks.
    /// </summary>
    public partial class TasksDockPanel : DockPanelControlBase, IMenuProvider
    {
        public TasksDockPanel()
        {
            InitializeComponent();

            contextMenuStripEx1.Opening += ContextMenuOpening;

            tasksTreeView1.AfterSelect += OnAfterSelect;
        }

        public event KeyEventHandler TreeViewKeyDown
        {
            add { tasksTreeView1.KeyDown += value; }
            remove { tasksTreeView1.KeyDown -= value; }
        }

        public IGisTask SelectedTask
        {
            get { return tasksTreeView1.SelectedTask; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get
            {
                yield return toolStripEx1.Items;
                yield return contextMenuStripEx1.Items;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        internal void Initialize(ITaskCollection tasks)
        {
            splitContainerAdv1.SplitterDistance = Convert.ToInt32(Height * 0.7);

            InitTextBox();

            tasksTreeView1.Initialize(tasks);
        }

        private void ContextMenuOpening(object sender, CancelEventArgs e)
        {
            var task = tasksTreeView1.SelectedTask;
            if (task == null)
            {
                e.Cancel = true;
                return;
            }

            toolCancelTask.Enabled = !task.IsFinished;
            toolPauseTask.Enabled = !task.IsFinished;
            toolRemoveTask.Enabled = task.IsFinished;
            toolPauseTask.Text = task.IsPaused ? "Resume" : "Pause";
        }

        private void DisplayTaskInfo(IGisTask task)
        {
            richTextBox1.Clear();

            string s = task.Tool.Name;
            
            var lines = task.GetDescription();
            foreach (var line in lines)
            {
                s += line + Environment.NewLine;
            }

            richTextBox1.Text = s;
            richTextBox1.MakeFirstLineBold();
        }

        private void InitTextBox()
        {
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.BackColor = Color.FromKnownColor(KnownColor.Control);
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = "No task is selected.";
        }

        private void OnAfterSelect(object sender, EventArgs e)
        {
            var task = tasksTreeView1.SelectedTask;
            if (task == null)
            {
                richTextBox1.Text = "No task is selected.";
            }
            else
            {
                DisplayTaskInfo(task);
            }
        }
    }
}