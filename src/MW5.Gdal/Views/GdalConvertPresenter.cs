using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Gdal.Model;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Views;

namespace MW5.Gdal.Views
{
    public class GdalConvertPresenter: GdalDriverOptionsPresenter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPresenter"/> class.
        /// </summary>
        public GdalConvertPresenter(IGdalConvertView view, IAppContext context)
            : base(view, context)
        {
        }
    }
}
