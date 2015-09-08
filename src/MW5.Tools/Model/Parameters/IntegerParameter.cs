using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MW5.Tools.Model.Parameters
{
    public class IntegerParameter: NumericParameter<int>, IXmlSerializable
    {
        public override string ToString()
        {
            return string.Format("{0}: {1}", DisplayName, Value);
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            int val;
            if (Int32.TryParse(reader.GetAttribute("Value"), NumberStyles.Any, CultureInfo.InvariantCulture, out val))
            {
                PreviousValue = val;
            }
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Value", ((int)Value).ToString(CultureInfo.InvariantCulture));
        }
    }
}
