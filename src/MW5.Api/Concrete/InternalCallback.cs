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
}
