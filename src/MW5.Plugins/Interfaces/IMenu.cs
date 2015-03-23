using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    public interface IMenu: IToolbar
    {
        IDropDownMenuItem FileMenu { get; }

        IDropDownMenuItem ViewMenu { get; }

        IDropDownMenuItem PluginsMenu { get; }

        IDropDownMenuItem TilesMenu { get; }

        IDropDownMenuItem HelpMenu { get; }

        IMenuItem FindItem(string key, PluginIdentity identity);

        void RemoveItemsForPlugin(PluginIdentity identity);
    }
}
