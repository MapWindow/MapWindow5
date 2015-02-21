using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Core.Interfaces;
using MW5.Core.Static;

namespace MW5.Core.Concrete
{
    // TODO: add thread safety code
    public class ApplicationCallback
    {
        private static List<IApplicationCallback> _list = new List<IApplicationCallback>();

        public static void Progress(string tagOfSender, int percent, string message)
        {
            foreach (var cb in _list)
            {
                cb.Progress(tagOfSender, percent, message);
            }
        }

        public static void Error(string tagOfSender, string errorMsg)
        {
            foreach (var cb in _list)
            {
                cb.Error(tagOfSender, errorMsg);
            }
        }

        public static bool Attach(IApplicationCallback callback)
        {
            if (callback != null && !_list.Contains(callback))
            {
                Configuration.Init();
                _list.Add(callback);
                return true;
            }
            return false;
        }

        public static bool Detach(IApplicationCallback callback)
        {
            if (callback != null && _list.Contains(callback))
            {
                _list.Remove(callback);
                return true;
            }
            return false;
        }
    }
}
