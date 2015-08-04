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
        public TaskLogPresenter(ITaskLogView view)
            : base(view)
        {
            view.Cancel += OnTaskCancel;
        }

        private void OnTaskCancel()
        {
            Model.Cancel();
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
