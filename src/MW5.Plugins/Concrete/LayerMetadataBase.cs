using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Plugins.Concrete
{
    [DataContract]
    public abstract class LayerMetadataBase : ILayerMetadataBase
    {
        public XmlElement Serialize()
        {
            return this.SerializeToElement();
        }
    }
}
