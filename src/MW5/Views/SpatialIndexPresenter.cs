using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Mvp;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public class SpatialIndexPresenter: BasePresenter<ISpatialIndexView>
    {
        public SpatialIndexPresenter(ISpatialIndexView view) : base(view)
        {
            View.ButtonClicked += OnButtonClicked;
        }

        public bool DontShowAgain
        {
            get { return View.DontShowAgain; }
        }

        public DialogResult Result
        {
            get
            {
                var form = View as Form;
                return form != null ? form.DialogResult : DialogResult.Cancel;
            }
        }

        private void OnButtonClicked()
        {
            Success = Result != DialogResult.Cancel;
            View.Close();
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
