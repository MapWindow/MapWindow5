using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Projections.BL;

namespace MW5.Projections.UI.Controls
{
    public class CoordinateSystemEventArgs: EventArgs
    {
        public CoordinateSystem CoordinateSystem { get; set; }
    }
}
