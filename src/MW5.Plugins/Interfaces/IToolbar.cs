using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    public interface IToolbar
    {
        string Name { get; set; }
        IMenuItemCollection Items { get; }
        bool Visible { get; set; }
        object Tag { get; set; }
        ToolbarDockState DockState { get; set; }
        void AddSeparator(int beforeItemIndex);
        void ClearSeparators();
        PluginIdentity PluginIdentity { get; }
    }
}
