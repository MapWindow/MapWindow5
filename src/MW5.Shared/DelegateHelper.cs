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

        public static void FireEvent<T>(object sender, EventHandler<T> eventHandler, T args) where T : EventArgs
        {
            var handler = eventHandler;
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public static void FireEvent(object sender, EventHandler eventHandler)
        {
            var handler = eventHandler;
            if (handler != null)
            {
                handler(sender, new EventArgs());
            }
        }
    }
}
