using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;

namespace MW5.UI
{
    internal static class MenuIndex
    {
        private static Dictionary<string, IMenuItem> _items = new Dictionary<string, IMenuItem>();

        public static void AddItem(string key, IMenuItem item)
        {
            _items.Add(key, item);    // TODO: handle exception
        }

        public static IMenuItem GetItem(string key)
        {
            IMenuItem item;
            _items.TryGetValue(key, out item);
            return item;
        }

        public static void RemoveItemsForPlugin(PluginIdentity pluginIdentity)
        {
            HashSet<string> keys = new HashSet<string>();
            foreach (var item in _items)
            {
                if (item.Value.PluginIdentity == pluginIdentity)
                {
                    keys.Add(item.Key);
                }
            }
            foreach (var key in keys)
            {
                _items.Remove(key);
            }
        }
    }
}
