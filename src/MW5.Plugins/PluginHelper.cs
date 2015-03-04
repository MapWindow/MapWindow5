using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins
{
    public static class PluginHelper
    {
        public static void RemovePluginMenus(this IAppContext context, PluginIdentity identity)
        {
            for (int i = context.Toolbars.Count() - 1; i >= 0; i--)
            {
                var bar = context.Toolbars[i];
                var id = bar.Tag as PluginIdentity;
                if (id == identity)
                {
                    context.Toolbars.Remove(i);
                }
                else
                {
                    // probably there are buttons in another toolbar owned by the app
                    RemoveItemsWithinToolbar(bar.Items, identity);
                }                
            }

            RemoveItemsWithinToolbar(context.Menu.Items, identity);
        }

        private static void RemoveItemsWithinToolbar(IMenuItemCollection items, PluginIdentity identity)
        {
            for (int j =items.Count() - 1; j >= 0; j--)
            {
                var item = items[j];
                var id = item.Tag as PluginIdentity;
                if (id == identity)
                {
                    items.Remove(j);
                }
            }
        }
    }
}
