using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Services
{
    internal class EmptyProgress: IToolProgress
    {
        public void Update(string msg, int value)
        {
            // do nothing
        }

        public void Clear()
        {
            // do nothing
        }

        public event EventHandler<ProgressEventArgs> ProgressChanged;

        public event EventHandler Hide;
    }
}
