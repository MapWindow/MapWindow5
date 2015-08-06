using System;
using MapWinGIS;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    internal class InternalCallback: ICallback
    {
        public void Progress(string keyOfSender, int percent, string message)
        {
            ApplicationCallback.Progress(keyOfSender, percent, message);
        }

        public void Error(string keyOfSender, string errorMsg)
        {
            ApplicationCallback.Error(keyOfSender, errorMsg);
        }
    }

    internal class CallbackWrapper : ICallback
    {
        public CallbackWrapper(IApplicationCallback callback)
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
    }
}
