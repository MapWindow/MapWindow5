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
        IMenuItem AddButton(string text, PluginIdentity pluginIdentity);
        IMenuItem AddButton(string text, string key, PluginIdentity pluginIdentity);
        IMenuItem AddButton(string text, string key, Bitmap icon, PluginIdentity pluginIdentity);
        IDropDownMenuItem AddDropDown(string text, string key, PluginIdentity pluginIdentity);
        IMenuItem this[int menuItemIndex] { get; }
        void Insert(IMenuItem item, int index);
        void Remove(int index);
        void Clear();

    }
}
