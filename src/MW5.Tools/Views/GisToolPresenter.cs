// -------------------------------------------------------------------------------------------
// <copyright file="GisToolPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The gis tool presenter.
    /// </summary>
    public class GisToolPresenter : BasePresenter<IGisToolView, GisToolBase>
    {
        private readonly IAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GisToolPresenter"/> class.
        /// </summary>
        public GisToolPresenter(IGisToolView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override void Initialize()
        {
            Model.Initialize(_context);

            View.GenerateControls(Model.Parameters);
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

            var task = new GisTask(Model);

            bool result = task.Run();

            _context.Tasks.AddTask(task);

            return result;
        }
    }
}