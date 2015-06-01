using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Events
{
    public class LockedEventArgs: EventArgs
    {
        public LockedEventArgs(bool locked)
        {
            Locked = locked;
        }

        public bool Locked { get; set; }
    }
}
