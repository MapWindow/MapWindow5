using System.Diagnostics;
using MW5.Api.Interfaces;
using MW5.Shared.Log;

namespace MW5.API.Test
{
    internal class CustomCallback: IGlobalListener
    {
        public void Error(string tagOfSender, string errorMsg)
        {
            Debug.Print("Callback reported error: " + errorMsg);
        }

        public void Progress(string tagOfSender, int percent, string message)
        {
            Debug.Print("Callback reported progress: {0} {1}", message, percent);
        }

        public void ClearProgress()
        {
            Debug.Print("Clear callback");
        }

        public bool CheckAborted()
        {
            return false;
        }


        public int ThreadId
        {
            get { return -1; }
        }
    }
}
