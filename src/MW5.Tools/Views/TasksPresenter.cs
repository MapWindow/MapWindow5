using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Tools.Enums;
using MW5.UI.Docking;

namespace MW5.Tools.Views
{
    public class TasksPresenter : CommandDispatcher<TasksDockPanel, ToolboxResultsCommand>
    {
        private readonly IAppContext _context;
        private readonly ITaskCollection _tasks;

        public TasksPresenter(IAppContext context, TasksDockPanel view, ITaskCollection tasks)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (tasks == null) throw new ArgumentNullException("tasks");

            _context = context;
            _tasks = tasks;

            View.Initialize(tasks);
            tasks.CollectionChanged += TasksCollectionChanged;
        }

        private void TasksCollectionChanged(object sender, EventArgs e)
        {
            var panel = _context.DockPanels.Find(DockPanelKeys.ToolboxResults);
            if (panel != null)
            {
                panel.Visible = true;
                panel.TabPosition = 0;
            }
        }

        public override void RunCommand(ToolboxResultsCommand command)
        {
            switch (command)
            {
                case ToolboxResultsCommand.Clear:
                    if (MessageService.Current.Ask("Remove all the tasks from the list?"))
                    {
                        _tasks.Clear();
                        View.UpdateView();
                    }
                    break;
                case ToolboxResultsCommand.ToggleGroup:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }
    }
}
