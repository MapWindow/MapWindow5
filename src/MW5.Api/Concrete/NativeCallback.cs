using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    /// <summary>
    /// A callback object to be assigned to MapWinGIS classes to receive notifactions from them.
    /// Wraps an instance IGlobalListener usually implemented by some UI related class 
    /// interested in such notifacations.
    /// </summary>
    /// <remarks>It's recommended not to assign separate instances of native callbacks to particular classes
    /// but to use GlobalListeners class instead.</remarks>
    internal class NativeCallback : ICallback, IStopExecution
    {
        public NativeCallback(IGlobalListener callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            Callback = callback;
        }

        public IGlobalListener Callback { get; private set; }

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

        public static NativeCallback Wrap(IGlobalListener callback)
        {
            return callback != null ? new NativeCallback(callback) : null;
        }

        public static IGlobalListener UnWrap(ICallback callback)
        {
            var wp = callback as NativeCallback;
            if (wp != null)
            {
                return wp.Callback;
            }

            return null;
        }
    }
}
