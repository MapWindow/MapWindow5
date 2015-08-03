// -------------------------------------------------------------------------------------------
// <copyright file="ToolPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The gis tool presenter.
    /// </summary>
    public class ToolPresenter : BasePresenter<IToolView, GisTool>
    {
        private readonly IAppContext _context;
        private IGisTask _task;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPresenter"/> class.
        /// </summary>
        public ToolPresenter(IToolView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override void Initialize()
        {
            Model.Initialize(_context);

            View.GenerateControls(Model.Parameters);

            View.CancelClicked += ViewCancelClicked;
        }

        private void ViewCancelClicked()
        {
            if (_task != null && _task.Status == GisTaskStatus.Running)
            {
                _task.Cancel();
            }
            else
            {
                View.Close();
            }
        }

        /// <summary>
        /// The view ok clicked.
        /// </summary>
        public override bool ViewOkClicked()
        {
            if (!Model.Validate())
            {
                return false;
            }

            _task = new GisTask(Model);

            _context.Tasks.AddTask(_task);

            _task.RunAsync();

            return false;       // TODO: close only if run in background is checked
        }
    }
}