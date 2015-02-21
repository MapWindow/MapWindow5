using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Core.Interfaces;

namespace MW5.Core.Concrete
{
    internal class StopExecution: IStopExecution
    {
        private readonly IStopExecutionCallback _callback;

        internal StopExecution(IStopExecutionCallback callback)
        {
            _callback = callback;
            if (callback == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public bool StopFunction()
        {
            return _callback.Stop();
        }
    }
}
