using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Shared
{
    public static class DelegateHelper
    {
        public static void SafeInvoke(this ISynchronizeInvoke target, Action action)
        {
            if (target.InvokeRequired)
            {
                target.BeginInvoke(action, null);
            }
            else
            {
                target.Invoke(action, null);
            }
        }
    }
}
