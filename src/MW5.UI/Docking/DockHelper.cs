using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins;
using MW5.Plugins.Enums;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Docking
{
    internal static class DockHelper
    {
        internal static DockPanelState SyncfusionToMapWindow(DockingStyle style)
        {
            switch (style)
            {
                case DockingStyle.Top:
                    return DockPanelState.Top;
                case DockingStyle.Bottom:
                    return DockPanelState.Bottom;
                case DockingStyle.Left:
                    return DockPanelState.Left;
                case DockingStyle.Right:
                    return DockPanelState.Right;
                case DockingStyle.Tabbed:
                    return DockPanelState.Tabbed;
                case DockingStyle.None:
                default:
                    return DockPanelState.None;
            }
        }

        internal static DockingStyle MapWindowToSyncfusion(DockPanelState state)
        {
            switch (state)
            {
                case DockPanelState.Left:
                    return DockingStyle.Left;
                case DockPanelState.Right:
                    return DockingStyle.Right;
                case DockPanelState.Top:
                    return DockingStyle.Top;
                case DockPanelState.Bottom:
                    return DockingStyle.Bottom;
                case DockPanelState.Tabbed:
                    return DockingStyle.Tabbed;
                case DockPanelState.None:
                default:
                    return DockingStyle.None;
            }
        }
    }
}
