using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IMenuItemCollection: IEnumerable<IMenuItem>
    {
        IMenuItem AddButton(string text);
        IMenuItem AddButton(string text, string name);
        IDropDownMenuItem AddDropDown(string text);
        void Insert(IMenuItem item, int index);
        void Remove(int index);
        void Clear();
    }
}
