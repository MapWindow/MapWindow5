using System.Collections.Generic;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    // TODO: add thread safety code
    public class ApplicationCallback
    {
        private static List<IApplicationCallback> _list = new List<IApplicationCallback>();

        public static void Progress(string tagOfSender, int percent, string message)
        {
            foreach (var cb in _list)
            {
                if (percent == 0 || percent == 100)
                {
                    cb.ClearProgress();
                }
                else
                {
                    cb.Progress(tagOfSender, percent, message);    
                }
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
                MapConfig.Init();
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
