using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public class CreatePyramidsPresenter: BasePresenter<ICreatePyramidsView, IRasterSource>
    {
        public CreatePyramidsPresenter(ICreatePyramidsView view) : base(view)
        {
            view.ButtonClicked += OnButtonClicked;
        }

        public DialogResult Result
        {
            get
            {
                var form = View as Form;
                return form != null ? form.DialogResult : DialogResult.Cancel;
            }
        }

        public bool DontShowAgain
        {
            get { return View.DontShowAgain; }
        }

        private void OnButtonClicked()
        {
            if (Result == DialogResult.Yes)
            {
                // warning is displayed by MapWinGIS
                Model.BuildDefaultOverviews(View.Sampling, View.Compression);
            }
            
            ReturnValue = Result != DialogResult.Cancel;
            View.Close();
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
