using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.UI;

namespace MW5.Menu
{
    public static class PluginMenuRemover
    {
        public static void RemovePluginMenus(this IAppContext context, PluginIdentity identity)
        {
            for (int i = context.Toolbars.Count() - 1; i >= 0; i--)
            {
                var bar = context.Toolbars[i];
                if (bar.PluginIdentity == identity)
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

            MenuIndex.RemoveItemsForPlugin(identity);
        }

        private static void RemoveItemsWithinToolbar(IMenuItemCollection items, PluginIdentity identity)
        {
            for (int j =items.Count() - 1; j >= 0; j--)
            {
                if (items[j].PluginIdentity == identity)
                {
                    items.Remove(j);
                }
            }
        }
    }
}
