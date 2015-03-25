using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.BO;

namespace MW5.Plugins.TableEditor
{
    public static class CompositionRoot
    {
        private static bool composed = false;

        public static void Compose(IApplicationContainer container)
        {
            if (!composed)
            {
                container.RegisterSingleton<AppContextWrapper, AppContextWrapper>();
                composed = true;
            }
        }
    }
}
