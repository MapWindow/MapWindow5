using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.UI
{
    public class MenuFactory
    {
        private static IMenu _instance;

        internal static IMenu CreateInstance(object menuManager)
        {
            if (_instance == null)
            {
                var menuIndex = new MenuIndex();
                var menu = new Menu(menuManager, menuIndex);
                menu.CreateMenuBar();
                menu.CreateDefaultItems();
                _instance = menu;
            }
            return _instance;
        }
    }
}
