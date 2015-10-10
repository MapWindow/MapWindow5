using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Concrete
{
    /// <summary>
    /// Represents a single WMS server to be displayed in the repository.
    /// </summary>
    [DataContract]
    public class WmsServer
    {
        public WmsServer(string name, string url)
        {
            Name = name;

            Url = url;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Url { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
