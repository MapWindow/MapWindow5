using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Services
{
    public class ProgressEventArgs: EventArgs
    {
        public ProgressEventArgs(string msg, int percent)
        {
            Message = msg;
            Percent = percent;
        }

        public string Message { get; private set; }
        
        public int Percent { get; private set; }

        public bool Finished { get { return Percent >= 100;  } }
    }
}
