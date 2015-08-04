using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;

namespace MW5.Tools.Services
{
    public class CallbackProgress : IToolProgress
    {
        private readonly Action<string, int> _progress;

        public CallbackProgress(Action<string, int> progress)
        {
            if (progress == null) throw new ArgumentNullException("progress");
            _progress = progress;
        }

        public void Update(string msg, int value)
        {
            _progress(msg, value);
        }

        public void Clear()
        {
            _progress(string.Empty, 100);
        }

        public event EventHandler<ProgressEventArgs> ProgressChanged;

        public event EventHandler Hide;
    }
}
