using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Services
{
    public class EventProgress: TaskProgressBase
    {
        public override void Update(string msg, int value)
        {
            FireProgressChanged(msg, value);
        }

        public override void Clear()
        {
            FireHideProgress();
        }

        private void FireProgressChanged(string msg, int percent)
        {
            var handler = ProgressChanged;
            if (handler != null)
            {
                handler(this, new ProgressEventArgs(msg, percent));
            }
        }
        
        private void FireHideProgress()
        {
            var handler = Hide;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public override event EventHandler<ProgressEventArgs> ProgressChanged;

        public override event EventHandler Hide;
    }
}
