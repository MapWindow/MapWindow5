using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins
{
    public enum ToolbarDockState
    {
        //
        // Summary:
        //     The CommandBar is docked to the top border of the form.
        Top = 1,
        //
        // Summary:
        //     The CommandBar is docked to the bottom border of the form.
        Bottom = 2,
        //
        // Summary:
        //     The CommandBar is docked to the left border of the form.
        Left = 4,
        //
        // Summary:
        //     The CommandBar is docked to the right border of the form.
        Right = 8,
        //
        // Summary:
        //     The CommandBar is in a floating state.
        Float = 32,
    }
}
