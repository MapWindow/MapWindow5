// -------------------------------------------------------------------------------------------
// <copyright file="TileLoadingService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MW5.Plugins.Printing.Model;

namespace MW5.Plugins.Printing.Services
{
    internal class TileLoadingService
    {
        private readonly object _myLock = new object();
        private readonly Queue<TileLoadingTask> _queue = new Queue<TileLoadingTask>();
        private bool _queueBusy;

        // TODO: restore
        //public event EventHandler<EventArgs> TileLoadingStart;
        //public event EventHandler<EventArgs> TileLoadingEnd;

        public void EnqueTask(TileLoadingTask task)
        {
            _queue.Enqueue(task);
            RunQueue();
        }

        private void RunQueue(bool completed = false)
        {
            // TODO: use TPL
            var thread = new Thread(() =>
                {
                    if (completed) _queueBusy = false;
                    lock (_myLock)
                    {
                        if (!_queueBusy)
                        {
                            if (_queue.Any())
                            {
                                var task = _queue.Dequeue();

                                //_axMap.LoadTilesForSnapshot(task.Extents, task.Width, task.Guid, task.TileProvider);
                                //Util.FireEvent(this, TileLoadingStart, new EventArgs());

                                _queueBusy = true;
                            }
                        }
                    }
                });

            thread.Start();
        }
    }
}