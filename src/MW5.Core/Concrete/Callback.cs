using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace MW5.Core.Concrete
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
