using MW5.Gdal.Tools;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Views;

namespace MW5.Gdal.Views
{
    internal class TranslateRasterPresenter: ToolPresenter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPresenter"/> class.
        /// </summary>
        public TranslateRasterPresenter(ITranslateRasterView view, IAppContext context)
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
            var view = View as ITranslateRasterView;
            if (view == null)
            {
                return;
            }

            var tool = Model.Tool as TranslateRasterTool;
            if (tool != null)
            {
                tool.OutputFormat.SaveConfig(view.DriverParameters);
            }
        }
    }
}
