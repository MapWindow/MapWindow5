using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Events;
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
            tasks.TaskChanged += TaskChanged;
        }

        private void TaskChanged(object sender, TaskEventArgs e)
        {
            if (e.Event == Plugins.Enums.TaskEvent.Added)
            {
                var panel = _context.DockPanels.Find(DockPanelKeys.ToolboxResults);
                if (panel != null)
                {
                    panel.Visible = true;
                    panel.Activate();
                }
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
                    }
                    break;
                case ToolboxResultsCommand.ToggleGroup:
                    break;
                case ToolboxResultsCommand.OpenLog:
                    MessageService.Current.Info("About to open log");
                    break;
                case ToolboxResultsCommand.CancelTask:
                    {
                        var task = View.SelectedTask;
                        if (task != null)
                        {
                            task.Cancel();
                        }
                        break;
                    }
                case ToolboxResultsCommand.Pause:
                    MessageService.Current.Info("Pause task");
                    break;
                case ToolboxResultsCommand.RemoveTask:
                    {
                        var task = View.SelectedTask;
                        if (task != null)
                        {
                            _tasks.RemoveTask(task);
                        }
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }
    }
}
