// -------------------------------------------------------------------------------------------
// <copyright file="ToolPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The gis tool presenter.
    /// </summary>
    public class ToolPresenter : BasePresenter<IToolView, ToolViewModel>
    {
        private readonly IAppContext _context;

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
            Model.Tool.Initialize(_context);

            View.GenerateControls(Model.Tool.Parameters);
        }

        /// <summary>
        /// The view ok clicked.
        /// </summary>
        public override bool ViewOkClicked()
        {
            var tool = Model.Tool;

            if (!tool.Validate())
            {
                return false;
            }

            var task = Model.CreateTask();

            if (View.RunInBackground)
            {
                // no progress / log dialog will be shown, so start tracking at once
                _context.Tasks.AddTask(task);
            }

            task.RunAsync();

            // on success a log window will be opened immediately
            Success = !View.RunInBackground;

            View.Close();

            return false;
        }
    }
}