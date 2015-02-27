using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class FileDroppedEventArgs: EventArgs
    {
        private readonly _DMapEvents_FileDroppedEvent _args;

        internal FileDroppedEventArgs(_DMapEvents_FileDroppedEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public string Filename
        {
            get { return _args.filename; }
        }
    }
}
