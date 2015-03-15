using MW5.Plugins.Interfaces;

namespace MW5.UI.Menu
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
