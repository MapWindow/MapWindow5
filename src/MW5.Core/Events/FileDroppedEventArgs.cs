using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Core.Events
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
