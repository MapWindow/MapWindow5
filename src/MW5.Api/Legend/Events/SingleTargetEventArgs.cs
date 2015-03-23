using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend.Events
{
    public class SingleTargetEventArgs: EventArgs
    {
        public bool Handled { get; set; }
    }
}
