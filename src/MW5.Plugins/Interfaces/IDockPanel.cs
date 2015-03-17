using System;
using System.Collections.Generic;
using System.Drawing;
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
        void DockTo(DockPanelState state, int size);
        string Caption { get; set; }
        Size Size { get; set; }
        bool FloatOnly { get; set; }
        bool AllowFloating { get; set; }
        void SetIcon(Icon icon);
        int TabPosition { get; set; }
        bool IsFloating { get; }
        void Float(Rectangle rect, bool tabFloating);
    }
}
