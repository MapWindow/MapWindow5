using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Views;

namespace MW5.Gdal.Views
{
    public class GdalDriverOptionsPresenter: GdalPresenter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPresenter"/> class.
        /// </summary>
        public GdalDriverOptionsPresenter(IGdalDriverOptionsView view, IAppContext context)
            : base(view, context)
        {
        }
    }
}
