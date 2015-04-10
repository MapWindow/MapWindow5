using System;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Events
{
    public class MenuEventArgs: EventArgs
    {
        public MenuEventArgs(IMenuItem menuItem)
        {
            MenuItem = menuItem;
        }

        public IMenuItem MenuItem { get; private set; }
    }
}
