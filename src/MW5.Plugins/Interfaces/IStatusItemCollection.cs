using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.UI.Menu
{
    public interface IStatusItemCollection: IMenuItemCollection
    {
        IMenuItem AddProgressBar(string key, PluginIdentity identity);
    }
}
