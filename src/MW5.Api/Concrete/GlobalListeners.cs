// -------------------------------------------------------------------------------------------
// <copyright file="GlobalListeners.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MapWinGIS;
using MW5.Api.Static;
using MW5.Shared.Log;

namespace MW5.Api.Concrete
{
    /// <summary>
    /// Holds collection of listeners that want to receive notification about global application events
    /// (errors and progress). The mechanism is used primarily to report notifcation from MapWinGIS native code but
    /// can also be used to report progress of long running tasks executed on the main thread.
    /// </summary>
    /// <remarks>Notification if passed to particular callback based on the tread id it was reported from. </remarks>
    public static class GlobalListeners
    {
        private static readonly List<IGlobalListener> _list = new List<IGlobalListener>();

        /// <summary>
        /// Gets the listeners working on the current thread (the one the message was reported from).
        /// </summary>
        private static IEnumerable<IGlobalListener> ThreadListeners
        {
            get
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;
                return _list.Where(cb => cb.ThreadId == threadId).ToList();
            }
        }

        /// <summary>
        /// Attaches particular callback listener.
        /// </summary>
        public static bool Attach(IGlobalListener callback)
        {
            if (callback != null && !_list.Contains(callback))
            {
                MapConfig.Init();
                _list.Add(callback);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Detaches particular callback listener.
        /// </summary>
        public static bool Detach(IGlobalListener callback)
        {
            if (callback != null && _list.Contains(callback))
            {
                _list.Remove(callback);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to be called to notify the listeners that progress indicator should be cleared.
        /// </summary>
        public static void ClearProgress()
        {
            foreach (var cb in ThreadListeners)
            {
                cb.ClearProgress();
            }
        }

        /// <summary>
        /// Method to be called to notify the listeners about an error.
        /// </summary>
        public static void ReportError(string tagOfSender, string errorMsg)
        {
            foreach (var cb in ThreadListeners)
            {
                cb.Error(tagOfSender, errorMsg);
            }
        }

        /// <summary>
        /// Method to be called to notify the listeners about the change of progress.
        /// </summary>
        public static void ReportProgress(string tagOfSender, int percent, string message)
        {
            foreach (var cb in ThreadListeners)
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
    }
}