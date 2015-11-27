using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Tools.Fake;
using MW5.Tools.Tools.Geoprocessing.VectorGeometryTools;
using MW5.Tools.Views.Custom.Abstract;

namespace MW5.Tools.Views.Custom
{
    #if DEBUG
    public class LongExecutionPresenter: BasePresenter<ILongExecutionView, ToolViewModel>
    {
        private readonly IAppContext _context;

        public LongExecutionPresenter(IAppContext context, ILongExecutionView view)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override bool ViewOkClicked()
        {
            var tool = Model.Tool as LongExecutionTool;
            if (tool == null) throw new InvalidCastException("LongExecutionTool was expected");

            tool.SecondsPerStep = View.SecondsPerStep;

            if (!tool.Validate())
            {
                return false;
            }

            View.DisableButtons();

            var task = Model.CreateTask();

            if (!View.RunInBackground)
            {
                task.StatusChanged += OnStatusChanged;
                task.Progress.ProgressChanged += OnProgressChanged;
            }

            task.RunAsync();

            return View.RunInBackground;
        }

        private void OnStatusChanged(object sender, TaskStatusChangedEventArgs e)
        {
            if (e.Task.IsFinished)
            {
                _context.Tasks.Add(e.Task);
                View.Close();
            }
        }

        private void OnProgressChanged(object sender, ProgressEventArgs e)
        {
            var progress = View.Progress;
            Action action = () => progress.Value = e.Percent;
            progress.SafeInvoke(action);
        }
    }
#endif
}
