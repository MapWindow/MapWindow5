using System.Diagnostics;
using MW5.Api.Interfaces;

namespace MW5.API.Test
{
    internal class CustomCallback: IApplicationCallback
    {
        public void Error(string tagOfSender, string errorMsg)
        {
            Debug.Print("Callback reported error: " + errorMsg);
        }

        public void Progress(string tagOfSender, int percent, string message)
        {
            Debug.Print("Callback reported progress: {0} {1}", message, percent);
        }
    }
}
