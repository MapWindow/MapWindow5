using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// GIS tool added to the toolbox.
    /// </summary>
    public interface IToolBoxToolItem
    {
        ITool Tool { get; }
        bool Visible { get; set; }
    }
}
