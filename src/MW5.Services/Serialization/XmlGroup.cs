using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;

namespace MW5.Services.Serialization
{
    [DataContract]
    public class XmlGroup
    {
        public XmlGroup(ILegendGroup group)
        {
            Name = group.Text;
            Expanded = group.Expanded;
            Layers = group.Layers.Select(l => l.Guid);
        }
        [DataMember] public IEnumerable<Guid> Layers { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public bool Expanded { get; set; }
    }
}
