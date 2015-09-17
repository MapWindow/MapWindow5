using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Controls.Parameters
{
    public interface IInputParameterControl
    {
        event EventHandler<EventArgs> ValueChanged;
        object GetValue();
    }
}
