using System;
using AxMapWinGIS;

namespace MW5.Api.Events
{
    public class FileDroppedEventArgs: EventArgs
    {
        internal FileDroppedEventArgs(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentNullException("filename");
            Filename = filename;
        }

        public string Filename { get; private set; }

        public bool IsOgrConnection
        {
            get { return Filename.StartsWith("OgrConnection"); }
        }

        public string Connection
        {
            get
            {
                if (!IsOgrConnection)
                {
                    return string.Empty;
                }

                var parts = Filename.Split('|');
                return parts.Length == 3 ? parts[1] : "";
            }
        }

        public string LayerName
        {
            get
            {
                if (!IsOgrConnection)
                {
                    return string.Empty;
                }

                var parts = Filename.Split('|');
                return parts.Length == 3 ? parts[2] : "";
            }
        }
    }
}
