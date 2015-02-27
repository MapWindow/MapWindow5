using System;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
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
