using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// Represents parameter which holds instance of geoprojection (ISpatialReference).
    /// </summary>
    internal class GeoProjectionParameter : BaseParameter, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
            string value = reader.GetAttribute("Value");

            if (!string.IsNullOrWhiteSpace(value))
            {
                var sr = new SpatialReference();
                sr.ImportFromAutoDetect(value);
                PreviousValue = sr;
            }
        }

        public virtual void WriteXml(XmlWriter writer)
        {
            var sr = Value as ISpatialReference;
            string s = sr != null ? sr.ExportToWkt() : string.Empty;
            writer.WriteAttributeString("Value", s);
        }
    }
}
