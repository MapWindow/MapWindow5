using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Projections.Forms;
using MW5.Projections.Views.Abstract;

namespace MW5.Projections.Views
{
    public class ProjectionMismatchPresenter: BasePresenter<IProjectionMismatchView, ProjectionMismatchModel>
    {
        private readonly IAppContext _context;

        public ProjectionMismatchPresenter(IProjectionMismatchView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
            View.DetailsClicked += OnDetailsClicked;
            ViewAsForm.FormClosed += OnFormClosed;
        }

        private Form ViewAsForm
        {
            get { return View as Form; }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            ReturnValue = ViewAsForm.DialogResult == DialogResult.OK;
        }

        private void OnDetailsClicked()
        {
            using (var form = new CompareProjectionForm(_context, Model.ProjectProjection, Model.LayerSource.Projection))
            {
                _context.View.ShowChildView(form, View as IWin32Window);
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
