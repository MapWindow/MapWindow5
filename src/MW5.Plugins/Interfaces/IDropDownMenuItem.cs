using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IDropDownMenuItem: IMenuItem
    {
        /// <summary>
        /// Gets the collection item in submenu for this item.
        /// </summary>
        IMenuItemCollection SubItems { get; }

        event EventHandler DropDownOpening;
        
        event EventHandler DropDownClosed;

        void Update();
    }
}
