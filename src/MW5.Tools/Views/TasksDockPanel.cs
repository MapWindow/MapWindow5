using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Controls;

namespace MW5.Tools.Views
{
    public partial class TasksDockPanel : DockPanelControlBase, IMenuProvider
    {
        public TasksDockPanel()
        {
            InitializeComponent();

            contextMenuStripEx1.Opening += ContextMenuOpening;
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
        }

        internal void Initialize(ITaskCollection tasks)
        {
            tasksTreeView1.Initialize(tasks);
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
    }
}
