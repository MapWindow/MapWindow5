using System.Windows.Forms;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Concrete;
using MW5.UI.Forms;

namespace MW5.Gdal.Views
{
    public partial class GdalOptionsView : GdalOptionsViewBase, IGdalOptionsView
    {
        public GdalOptionsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            Text = string.IsNullOrWhiteSpace(Model.Caption) ? "GDAL options" : Model.Caption;

            txtMain.Text = Model.MainOptions;
            txtAdditional.Text = Model.AdditionalOptions;
        }

        public override void BeforeClose()
        {
            base.BeforeClose();

            Model.MainOptions = txtMain.Text;
            Model.AdditionalOptions = txtAdditional.Text;

            AppConfig.Instance.ToolShowGdalOptionsDialog = !chkDontShow.Checked;
        }

        public ButtonBase OkButton
        {
            get { return btnRun; }
        }
    }

    public class GdalOptionsViewBase : MapWindowView<GdalOptionsModel> { }
}
