using MW5.Gdal.Model;
using MW5.Gdal.Tools;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Views;

namespace MW5.Gdal.Views
{
    public class GdalPresenter: ToolPresenter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPresenter"/> class.
        /// </summary>
        public GdalPresenter(IGdalView view, IAppContext context)
            : base(view, context)
        {
        }
    }
}
