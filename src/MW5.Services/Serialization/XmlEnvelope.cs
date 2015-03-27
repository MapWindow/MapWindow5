using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Services.Serialization
{
    [DataContract]
    public class XmlEnvelope
    {
        public XmlEnvelope(IEnvelope e)
        {
            MinX = e.MinX;
            MaxX = e.MaxX;
            MinY = e.MinY;
            MaxY = e.MaxY;
        }
        [DataMember] public double MinX { get; set; }
        [DataMember] public double MaxX { get; set; }
        [DataMember] public double MinY { get; set; }
        [DataMember] public double MaxY { get; set; }
    }
}
