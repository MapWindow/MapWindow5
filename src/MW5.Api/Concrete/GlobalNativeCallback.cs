using System;
using MapWinGIS;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    /// <summary>
    /// A callback object which receives all global notifications from MapWinGIS 
    /// and passes them to the interested listeners in GlobalListeners collection.
    /// </summary>
    internal class GlobalNativeCallback: ICallback
    {
        public void Progress(string keyOfSender, int percent, string message)
        {
            GlobalListeners.ReportProgress(keyOfSender, percent, message);
        }

        public void Error(string keyOfSender, string errorMsg)
        {
            GlobalListeners.ReportError(keyOfSender, errorMsg);
        }
    }
}
