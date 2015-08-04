using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Tools.Model;

namespace MW5.Tools.Views
{
    internal class TaskLogPresenter: BasePresenter<ITaskLogView, IGisTask>
    {
        private readonly IAppContext _context;

        public TaskLogPresenter(ITaskLogView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            view.Cancel += OnTaskCancel;
        }

        private void OnTaskCancel()
        {
            Model.Cancel();
        }

        public override bool ViewOkClicked()
        {
            if (_context.Tasks.All(t => t != Model))
            {
                // if task haven't been added to the list yet, correct it
                _context.Tasks.AddTask(Model);
            }

            return true;
        }
    }
}
