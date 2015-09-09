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
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.UI.Docking;

namespace MW5.Tools.Views
{
    public class TasksPresenter : CommandDispatcher<TasksDockPanel, TaskCommand>
    {
        private readonly IAppContext _context;
        private readonly ILayerService _layerService;
        private readonly ITaskCollection _tasks;

        public TasksPresenter(IAppContext context, ILayerService layerService, TasksDockPanel view, ITaskCollection tasks)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (tasks == null) throw new ArgumentNullException("tasks");

            _context = context;
            _layerService = layerService;
            _tasks = tasks;

            View.Initialize(tasks);
            
            tasks.TaskChanged += TaskChanged;

            View.TreeViewKeyDown += OnTreeViewKeyDown;
        }

        private void OnTreeViewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RunCommand(e.Control ? TaskCommand.RemoveOutput : TaskCommand.RemoveTask);
            }
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

        /// <summary>
        /// Removes the previous output of the task and runs it again.
        /// </summary>
        private void RerunTask()
        {
            if (!MessageService.Current.Ask("Do you want to rerun the task?" + Environment.NewLine + Environment.NewLine +
                                           "The existing output will be removed and the task will be executed once more with the same parameters."))
            {
                return;
            }

            var task = View.SelectedTask;
            if (task == null)
            {
                return;
            }
            
            var tool = task.Tool as IParametrizedTool;
            if (tool == null)
            {
                return;
            }

            try
            {
                if (!tool.Parameters.ReopenDatasources(_context))
                {
                    return;
                }

                if (!tool.RemoveOutputs(_context, _layerService))
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Shared.Logger.Current.Error("Failed to rerun tool: " + task.Tool.Name, ex.Message);
                return;
            }

            if (!task.Tool.Validate())
            {
                return;
            }

            task.RunAsync();
        }

        public override void RunCommand(TaskCommand command)
        {
            switch (command)
            {
                case TaskCommand.RemoveOutput:
                    {
                        var task = View.SelectedTask;
                        if (task != null)
                        {
                            if (!MessageService.Current.Ask("Remove the selected task and its output?"))
                            {
                                return;
                            }

                            var tool = task.Tool as IParametrizedTool;
                            if (tool != null)
                            {
                                if (tool.RemoveOutputs(_context, _layerService))
                                {
                                    _tasks.Remove(task);
                                }
                            }
                        }
                    }
                    break;
                case TaskCommand.RunAnother:
                    {
                        var task = View.SelectedTask;
                        if (task != null)
                        {
                            _context.Toolbox.OpenToolDialog(task.Tool, false);
                        }
                    }
                    break;
                case TaskCommand.Rerun:
                    RerunTask();
                    break;
                case TaskCommand.Clear:
                    if (MessageService.Current.Ask("Remove all the finished tasks from the list?"))
                    {
                        _tasks.Clear(true);
                    }
                    break;
                case TaskCommand.OpenLog:
                    {
                        var task = View.SelectedTask;
                        if (task != null)
                        {
                            _context.Container.Run<TaskLogPresenter, IGisTask>(task);
                        }
                    }
                    break;
                case TaskCommand.CancelTask:
                    {
                        var task = View.SelectedTask;
                        if (task != null)
                        {
                            task.Cancel();
                        }
                        break;
                    }
                case TaskCommand.PauseTask:
                    {
                        var task = View.SelectedTask;
                        if (task != null)
                        {
                            task.TogglePause();
                        }
                    }
                    break;
                case TaskCommand.RemoveTask:
                    {
                        if (MessageService.Current.Ask("Remove the selected task?"))
                        {
                            var task = View.SelectedTask;
                            if (task != null)
                            {
                                _tasks.Remove(task);
                            }
                        }
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }
    }
}
