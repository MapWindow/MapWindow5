using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Interfaces
{
    public interface IDockPanel
    {
        Control Control { get; }
        DockPanelState DockState { get; }
        bool Visible { get; set; }
        void DockTo(IDockPanel parent, DockPanelState state, int size);
        string Caption { get; set; }
    }
}
