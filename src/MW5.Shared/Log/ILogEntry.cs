using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Shared.Log
{
    public interface ILogEntry
    {
        string Message { get; }
        LogLevel Level { get;  }
        Exception Exception { get;  }
        DateTime TimeStamp { get;  }
    }
}
