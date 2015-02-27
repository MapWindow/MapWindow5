using MapWinGIS;

namespace MW5.Api.Concrete
{
    internal class Callback: ICallback
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
