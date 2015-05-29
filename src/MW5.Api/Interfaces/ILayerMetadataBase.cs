using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using MW5.Shared;

namespace MW5.Api.Interfaces
{
    public interface ILayerMetadataBase
    {
        XmlElement Serialize();
    }
}
