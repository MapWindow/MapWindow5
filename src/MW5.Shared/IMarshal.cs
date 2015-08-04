using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Shared
{
    [System.Runtime.InteropServices.InterfaceTypeAttribute(1)]
    [System.Runtime.InteropServices.Guid("00000003-0000-0000-C000-000000000046")]
    public interface IMarshal
    {
        // http ://stackoverflow.com/questions/7252323/detecting-cross-thread-marshaling-by-com-rcw-objects-in-c-sharp
        // no methods needed, just querying for the interface
    }
}
