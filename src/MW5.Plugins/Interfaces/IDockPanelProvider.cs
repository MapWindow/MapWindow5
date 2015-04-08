using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Interfaces
{
    public interface IDockPanelProvider
    {
        Control GetInternalObject();
    }
}
