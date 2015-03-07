using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public class MenuItemEventArgs: EventArgs
    {
        private string _itemKey;

        public MenuItemEventArgs(string itemKey)
        {
            _itemKey = itemKey ?? string.Empty;
        }

        public string ItemKey
        {
            get { return _itemKey; }
        }
    }
}
