using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace MW5.Core.Interfaces
{
    public interface IApplicationCallback
    {
        void Error(string tagOfSender, string errorMsg);
        void Progress(string tagOfSender, int percent, string message);
    }
}
