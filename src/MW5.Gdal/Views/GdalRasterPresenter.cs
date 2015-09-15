using MW5.Gdal.Model;
using MW5.Gdal.Tools;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Views;

namespace MW5.Gdal.Views
{
    internal class GdalRasterPresenter: ToolPresenter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPresenter"/> class.
        /// </summary>
        public GdalRasterPresenter(IGdalRasterView view, IAppContext context)
            : base(view, context)
        {
        }

        public override bool ViewOkClicked()
        {
            SaveDriverConfig();

            return base.ViewOkClicked();
        }

        private void SaveDriverConfig()
        {
            var view = View as IGdalRasterView;
            if (view == null)
            {
                return;
            }

            var tool = Model.Tool as GdalRasterTool;
            if (tool != null)
            {
                tool.OutputFormat.SaveConfig(view.DriverParameters);
            }
        }
    }
}
