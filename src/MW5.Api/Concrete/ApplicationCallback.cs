using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    public static class ApplicationCallback
    {
        private static readonly List<IApplicationCallback> _list = new List<IApplicationCallback>();

        public static void ClearProgress()
        {
            foreach (var cb in ThreadCallbacks)
            {
                cb.ClearProgress();
            }
        }

        public static void Progress(string tagOfSender, int percent, string message)
        {
            foreach (var cb in ThreadCallbacks)
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
            foreach (var cb in ThreadCallbacks)
            {
                cb.Error(tagOfSender, errorMsg);
            }
        }

        private static IEnumerable<IApplicationCallback> ThreadCallbacks
        {
            get
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;
                return _list.Where(cb => cb.ThreadId == threadId).ToList();
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
