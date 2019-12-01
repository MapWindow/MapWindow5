// -------------------------------------------------------------------------------------------
// <copyright file="LongExecutionPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Tools.Tools.Fake;
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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override bool ViewOkClicked()
        {
            if (!(Model.Tool is LongExecutionTool tool)) throw new InvalidCastException("LongExecutionTool was expected");

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
            if (!e.Task.IsFinished) return;
            _context.Tasks.Add(e.Task);
            View.Close();
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
