using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Core.Interfaces;

namespace MW5.ConsoleTest
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
