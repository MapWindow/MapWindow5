using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    public interface IMenuItemCollection: IEnumerable<IMenuItem>
    {
        IMenuItem AddLabel(string text, string key, PluginIdentity identity);
        IMenuItem AddButton(MenuCommand command, bool beginGroup = false);
        IMenuItem AddButton(string text, PluginIdentity identity);
        IMenuItem AddButton(string text, string key, PluginIdentity identity);
        IMenuItem AddButton(string text, string key, Bitmap icon, PluginIdentity identity);
        IDropDownMenuItem AddDropDown(string text, string key, PluginIdentity identity);
        IDropDownMenuItem AddDropDown(string text, Bitmap icon, PluginIdentity identity);
        IComboBoxMenuItem AddComboBox(string text, string key, PluginIdentity identity);
        IMenuItem this[int menuItemIndex] { get; }
        void Insert(IMenuItem item, int index);
        void Remove(int index);
        void Remove(IMenuItem item);
        void Clear();
        int IndexOf(IMenuItem item);
        int Count { get; }

        /// <summary>
        /// Gets or sets menu item before which all the new items will be added. If set to null
        /// items will be added to the end of collection.
        /// </summary>
        IMenuItem InsertBefore { get; set; }
    }
}
