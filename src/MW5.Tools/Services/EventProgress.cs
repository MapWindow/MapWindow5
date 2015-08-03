using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Services
{
    public class EventProgress: IToolProgress
    {
        public void Update(string msg, int value)
        {
            FireProgressChanged(msg, value);
        }

        public void Clear()
        {
            FireProgressChanged(string.Empty, 100);
        }

        private void FireProgressChanged(string msg, int percent)
        {
            var handler = ProgressChanged;
            if (handler != null)
            {
                handler(this, new ProgressEventArgs(msg, percent));
            }
        }

        public event EventHandler<ProgressEventArgs> ProgressChanged;
    }
}
