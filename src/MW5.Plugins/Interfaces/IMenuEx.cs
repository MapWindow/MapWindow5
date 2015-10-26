using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Events;

namespace MW5.Plugins.Interfaces
{
    public interface IMenuEx: IMenuBase
    {
        event EventHandler<MenuItemEventArgs> ItemClicked;
    }
}
