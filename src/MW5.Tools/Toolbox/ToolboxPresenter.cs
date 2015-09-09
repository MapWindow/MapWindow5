using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Helpers;
using MW5.Tools.Views;

namespace MW5.Tools.Toolbox
{
    public class ToolboxPresenter : CommandDispatcher<ToolboxDockPanel, ToolboxCommand>, IDockPanelPresenter
    {
        private readonly IAppContext _context;

        public ToolboxPresenter(IAppContext context, ToolboxDockPanel view)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            View.ToolClicked += (s, e) => RunTool(e.Tool, e.BatchMode);
        }

        public override void RunCommand(ToolboxCommand command)
        {
            switch (command)
            {
                case ToolboxCommand.Run:
                    RunTool(View.SelectedTool);
                    break;
                case ToolboxCommand.BatchRun:
                    RunTool(View.SelectedTool, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        public Control GetInternalObject()
        {
            return View;
        }

        private void RunTool(ITool clickedTool, bool batchMode = false)
        {
            if (clickedTool == null) return;

            // we don't want the same instance of tool to be used by different tasks
            // therefore a new instance is created; it's expected that it must have default empty constructor
            var tool = Activator.CreateInstance(clickedTool.GetType()) as ITool;

            if (tool == null)
            {
                Logger.Current.Warn("Failed to instantiate tool: " + clickedTool.Name);
                return;
            }

            tool.Initialize(_context);

            if (tool is IGisTool)
            {
                var presenter = tool.GetPresenter(_context);

                var model = new ToolViewModel(tool as IGisTool, batchMode);
                if (presenter.Run(model))
                {
                    _context.Container.Run<TaskLogPresenter, IGisTask>(model.Task);
                }
            }
            else
            {
                // tool doesn't have UI or have an embedded  UI
                tool.Run();
            }
        }
    }
}
