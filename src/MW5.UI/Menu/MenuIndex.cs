using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.UI.Enums;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI.Menu
{
    internal class MenuIndex : IMenuIndex
    {
        private readonly Dictionary<string, IMenuItem> _items = new Dictionary<string, IMenuItem>();
        private readonly Dictionary<object, MenuItemCollectionMetadata> _collectionMetadata = new Dictionary<object, MenuItemCollectionMetadata>();
        private readonly MenuIndexType _indexType;

        public MenuIndex(MenuIndexType indexType)
        {
            _indexType = indexType;
        }

        public void AddItem(string key, IMenuItem item)
        {
            if (NeedsToolTip)
            {
                ToolTipHelper.UpdateTooltip(item);
            }

            item.ItemChanged += (s, e) => ToolTipHelper.UpdateTooltip(item);
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

        public void SaveMetadata(object key, MenuItemCollectionMetadata metadata)
        {
            _collectionMetadata[key] = metadata;
        }

        public MenuItemCollectionMetadata LoadMetadata(object key)
        {
            MenuItemCollectionMetadata data;
            if (_collectionMetadata.TryGetValue(key, out data))
            {
                return data;
            }
            return null;

            
        }

        public bool NeedsToolTip
        {
            get
            {
                switch (_indexType)
                {
                    case MenuIndexType.MainMenu:
                        return AppConfig.Instance.ShowMenuToolTips;
                    case MenuIndexType.Toolbar:
                        return true;
                    case MenuIndexType.StatusBar:
                        return false;
                }

                return false;
            }
        }

        public MenuIndexType ToolbarType
        {
            get { return _indexType; }
        }
    }
}
