using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    public interface IDockPanelCollection: IEnumerable<IDockPanel>
    {
        void Lock();
        void Unlock();
        bool Locked { get; }
        IDockPanel Add(Control control, DockPanelState state, bool visible, int size, PluginIdentity identity);
        void Remove(IDockPanel panel, PluginIdentity identity);
        void RemoveItemsForPlugin(PluginIdentity identity);
    }
}
