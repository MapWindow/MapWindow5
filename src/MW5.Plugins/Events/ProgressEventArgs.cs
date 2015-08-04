using System;

namespace MW5.Plugins.Events
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
