using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MW5.Shared
{
    public static class GcHelper
    {
        public static void Collect(int sleepMilliSenconds = 0)
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            if (sleepMilliSenconds != 0)
            {
                Thread.Sleep(sleepMilliSenconds);
            }
        }
    }
}
