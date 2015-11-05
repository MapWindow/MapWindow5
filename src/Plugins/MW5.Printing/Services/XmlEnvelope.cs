using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Printing.Services
{
    [DataContract(Name="Envelope")]
    internal class XmlEnvelope
    {
        [DataMember]
        public double MinX { get; set; }

        [DataMember]
        public double MinY { get; set; }

        [DataMember]
        public double MaxX { get; set; }

        [DataMember]
        public double MaxY { get; set; }
    }
}
