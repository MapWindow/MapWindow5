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
        IMenuItem AddButton(MenuCommand command);
        IMenuItem AddButton(string text, PluginIdentity identity);
        IMenuItem AddButton(string text, string key, PluginIdentity identity);
        IMenuItem AddButton(string text, string key, Bitmap icon, PluginIdentity identity);
        IDropDownMenuItem AddDropDown(string text, string key, PluginIdentity identity);
        IDropDownMenuItem AddDropDown(string text, Bitmap icon, PluginIdentity identity);
        IMenuItem this[int menuItemIndex] { get; }
        void Insert(IMenuItem item, int index);
        void Remove(int index);
        void Clear();

    }
}
