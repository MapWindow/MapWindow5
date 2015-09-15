using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Tools.Gdal;
using MW5.Tools.Views.Abstract;
using MW5.Tools.Views.Gdal.Abstract;

namespace MW5.Tools.Views.Gdal
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
