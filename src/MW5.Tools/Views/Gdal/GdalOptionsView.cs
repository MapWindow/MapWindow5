using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Tools.Views.Gdal.Abstract;
using MW5.UI.Forms;

namespace MW5.Tools.Views.Gdal
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
