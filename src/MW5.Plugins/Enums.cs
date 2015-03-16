using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins
{
    public enum DataSourceType
    {
        Vector = 0,
        Raster = 1,
        All = 2,
    }

    public enum ProjectState
    {
        NotSaved = 0,
        HasChanges = 1,
        NoChanges = 2,
        Empty = 3,
    }

    public enum DockPanelState
    {
        None = 0,
        Left = 1,
        Right = 2,
        Top = 3,
        Bottom = 4,
        Tabbed = 5,
    }

    public enum DockPanels
    {
        Legend = 0,
        Preview = 1,
    }
}
