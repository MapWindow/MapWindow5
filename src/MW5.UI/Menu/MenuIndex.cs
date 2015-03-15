using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
//using System.Linq;

namespace MW5.UI.Menu
{
    internal class MenuIndex : IMenuIndex
    {
        private Dictionary<string, IMenuItem> _items = new Dictionary<string, IMenuItem>();

        public void AddItem(string key, IMenuItem item)
        {
            _items.Add(key, item);
        }

        public void Remove(string key)
        {
            _items.Remove(key);
        }

        public IMenuItem GetItem(string key)
        {
            IMenuItem item;
            _items.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<IMenuItem> ItemsForPlugin(PluginIdentity identity)
        {
            return from item in _items where item.Value.PluginIdentity == identity select item.Value;
        }

        public void RemoveItemsForPlugin(PluginIdentity pluginIdentity)
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

        public void Clear()
        {
            _items.Clear();
        }
    }
}
