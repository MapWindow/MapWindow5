using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IMenu: IMenuBase
    {
        IDropDownMenuItem FileMenu { get; }

        IDropDownMenuItem LayerMenu { get; }

        IDropDownMenuItem ViewMenu { get; }

        IDropDownMenuItem PluginsMenu { get; }

        IDropDownMenuItem TilesMenu { get; }

        IDropDownMenuItem HelpMenu { get; }

        IDropDownMenuItem MapMenu { get; }
    }
}
