using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;

namespace MW5.UI
{
    internal class ToolbarsCollection: IToolbarCollection
    {
        private readonly IMenuIndex _menuIndex;
        private MainFrameBarManager _manager;

        internal static IToolbarCollection CreateInstance(object menuManager)
        {
            var menuIndex = new MenuIndex();
            var collection = new ToolbarsCollection(menuManager, menuIndex);
            return collection;
        }

        private ToolbarsCollection(object menuManager, IMenuIndex menuIndex)
        {
            _menuIndex = menuIndex;
            _manager = menuManager as MainFrameBarManager;
            if (menuIndex == null) throw new ArgumentNullException("menuIndex");
            if (_manager == null)
            {
                throw new NullReferenceException("ToolbarsCollection: instance of menu manager is not provided.");
            }
        }

        public IEnumerator<IToolbar> GetEnumerator()
        {
            for (int i = 0; i < _manager.Bars.Count; i++)
            {
                yield return this[i];
            }
        }

        public IToolbar this[int index]
        {
            get
            {
                if (index < 0 || index >= _manager.Bars.Count)
                {
                    throw new IndexOutOfRangeException("Invalid toolbar index.");
                }
                return new Toolbar(_manager, _manager.Bars[index], _menuIndex);
            }
        }

        public IMenuItem FindItem(string key)
        {
            return _menuIndex.GetItem(key);
        }

        public void RemoveItemsForPlugin(PluginIdentity identity)
        {
            _menuIndex.RemoveItemsForPlugin(identity);

            for (int i = this.Count() - 1; i >= 0; i--)
            {
                var bar = this[i];
                if (bar.PluginIdentity == identity)
                {
                    Remove(i);
                }
                else
                {
                    MenuItemCollection.RemoveItems(bar.Items, identity);
                }
            }
        }

        public IEnumerable<IMenuItem> ItemsForPlugin(PluginIdentity identity)
        {
            return _menuIndex.ItemsForPlugin(identity);
        }

        public IToolbar Add(string name, PluginIdentity identity)
        {
            var bar = new Bar(_manager, name);
            int index = _manager.Bars.Add(bar);
            var cbr = _manager.GetBarControl(bar);
            cbr.Tag = new MenuItemMetadata(identity, name);
            return this[index];
        }

        public void Remove(int toolbarIndex)
        {
            if (toolbarIndex < 0 || toolbarIndex >= _manager.Bars.Count)
            {
                throw new IndexOutOfRangeException("Invalid toolbar index.");
            }

            var bar = _manager.Bars[toolbarIndex];
            if (bar.BarStyle == BarStyle.IsMainMenu)
            {
                throw new Exception("Main menu can't be removed.");
            }

            var toolbar = this[toolbarIndex];
            toolbar.Items.Clear();    // make sure to clear the index

            _manager.Bars.RemoveAt(toolbarIndex);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
