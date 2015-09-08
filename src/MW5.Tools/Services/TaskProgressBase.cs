using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Services
{
    public abstract class TaskProgressBase : ITaskProgress
    {
        public abstract void Update(string msg, int value);

        public void TryUpdate(string msg, int step, int total, ref int lastPercent)
        {
            var percent = Convert.ToInt32(((double)(step + 1) / total) * 100.0);

            if (percent > lastPercent)
            {
                Update("Running...", percent);
                lastPercent = percent;
                Thread.Sleep(50);
            }
        }

        public abstract void Clear();

        public abstract event EventHandler<ProgressEventArgs> ProgressChanged;

        public abstract event EventHandler Hide;
    }
}
