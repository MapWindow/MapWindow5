using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class FileDroppedEventArgs: EventArgs
    {
        internal FileDroppedEventArgs(string filename)
        {
            Filename = filename;
        }

        public string Filename { get; private set; }
    }
}
