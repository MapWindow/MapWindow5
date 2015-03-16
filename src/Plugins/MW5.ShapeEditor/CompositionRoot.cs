using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Mvp;
using MW5.Plugins.ShapeEditor.Abstract;
using MW5.Plugins.ShapeEditor.Helpers;
using MW5.Plugins.ShapeEditor.Menu;
using MW5.Services;

namespace MW5.Plugins.ShapeEditor
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container, BasePlugin plugin)
        {
            container.RegisterInstance(plugin.GetType(), plugin);    // registering for injection
            container.RegisterSingleton<IGeoprocessingService, GeoprocessingService>().
                RegisterService<MenuGenerator, MenuGenerator>().
                RegisterService<MapListener, MapListener>().
                RegisterService<ProjectListener, ProjectListener>().
                RegisterService<MenuUpdater, MenuUpdater>();
        }
    }
}


