using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
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
