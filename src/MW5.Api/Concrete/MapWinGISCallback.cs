using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    internal class MapWinGISCallback : ICallback, IStopExecution
    {
        public MapWinGISCallback(IApplicationCallback callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            Callback = callback;
        }

        public IApplicationCallback Callback { get; private set; }

        public void Progress(string KeyOfSender, int Percent, string Message)
        {
            Callback.Progress(KeyOfSender, Percent, Message);
        }

        public void Error(string KeyOfSender, string ErrorMsg)
        {
            Callback.Error(KeyOfSender, ErrorMsg);
        }

        public bool StopFunction()
        {
            return Callback.CheckAborted();
        }

        public static MapWinGISCallback Wrap(IApplicationCallback callback)
        {
            return callback != null ? new MapWinGISCallback(callback) : null;
        }

        public static IApplicationCallback UnWrap(ICallback callback)
        {
            var wp = callback as MapWinGISCallback;
            if (wp != null)
            {
                return wp.Callback;
            }

            return null;
        }
    }
}
