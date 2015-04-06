using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.UI.Syncfusion;

namespace MW5.UI
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterService<IStyleService, SyncfusionStyleService>()
            .RegisterSingleton<ControlStyleSettings>();
        }
    }
}
