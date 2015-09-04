using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Views;

namespace MW5.Tools.Helpers
{
    public static class ToolHelper
    {
        public static IPresenter<ToolViewModel> GetPresenter(this GisTool tool, IAppContext context)
        {
            var attr = AttributeHelper.GetAttribute<GisToolAttribute>(tool.GetType());
            if (attr.PresenterType != null)
            {
                return context.Container.GetInstance(attr.PresenterType) as IPresenter<ToolViewModel>;
            }

            return context.Container.GetInstance<ToolPresenter>();
        }
    }
}
