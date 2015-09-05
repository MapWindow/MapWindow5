using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public static IPresenter<ToolViewModel> GetPresenter(this ITool tool, IAppContext context)
        {
            var attr = AttributeHelper.GetAttribute<GisToolAttribute>(tool.GetType());
            if (attr.PresenterType != null)
            {
                return context.Container.GetInstance(attr.PresenterType) as IPresenter<ToolViewModel>;
            }

            return context.Container.GetInstance<ToolPresenter>();
        }

        /// <summary>
        /// Gets the reflected tools.
        /// </summary>
        /// <value>stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface</value>
        public static IEnumerable<ITool> GetTools(this Assembly assembly)
        {
            var type = typeof(ITool);

            var list = assembly.GetTypes()
                        .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

            foreach (var item in list)
            {
                ITool tool = null;

                try
                {
                    tool = Activator.CreateInstance(item) as ITool;
                }
                catch (Exception ex)
                {
                    Logger.Current.Error("Failed to create GIS tool: {0}.", ex, item.Name);
                }

                if (tool != null)
                {
                    yield return tool;
                }
            }
        }
    }
}
