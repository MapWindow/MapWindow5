using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Services.Serialization
{
    [DataContract]
    public class XmlMap
    {
        [DataMember]
        public string Projection { get; set; }

        [DataMember]
        public XmlEnvelope Envelope { get; set; }
    }
}
