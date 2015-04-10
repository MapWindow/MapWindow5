using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Interfaces
{
    public interface IToolbar
    {
        string Name { get; set; }
        IMenuItemCollection Items { get; }
        bool Visible { get; set; }
        object Tag { get; set; }
        string Key { get; }
        ToolbarDockState DockState { get; set; }
        PluginIdentity PluginIdentity { get; }
        void Update();
    }
}
