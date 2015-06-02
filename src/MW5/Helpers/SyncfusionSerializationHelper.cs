using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Runtime.Serialization;

namespace MW5.Helpers
{
    public static class SyncfusionSerializationHelper
    {
        public static string GetPath(this AppStateSerializer serializer)
        {
            string path = serializer.SerializationPath as string ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(path))
            {
                path += ".xml";
            }

            return path;
        }
    }
}
