using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;

namespace MW5.UI.Menu.Classic
{
    internal class MenuStripMenu : MenuStripMenuMute, IMenuEx
    {
        internal MenuStripMenu(object menuManager, MenuIndex menuIndex)
            : base(menuManager, menuIndex)
        {
        }

        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add { _menuIndex.ItemClicked += value; }
            remove  { _menuIndex.ItemClicked -= value; }
        }
    }
}
