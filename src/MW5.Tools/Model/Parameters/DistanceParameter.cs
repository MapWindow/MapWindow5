using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using MW5.Api.Enums;
using MW5.Shared;
using MW5.Tools.Controls.Parameters;

namespace MW5.Tools.Model.Parameters
{
    public class DistanceParameter: DoubleParameter
    {
        public override string ToString()
        {
            var distance = Value as Distance;
            return string.Format("{0}: {1:g3}", DisplayName, (distance != null) ? distance.Value : 0.0);
        }

        public override void ReadXml(XmlReader reader)
        {
            LengthUnits units;
            double value;

            if (reader.GetAttribute("Value").ParseDoubleInvariant(out value) &&
                Enum.TryParse(reader.GetAttribute("Units"), out units))
            {
                PreviousValue = new Distance(value, units);
            }
        }

        public override void WriteXml(XmlWriter writer)
        {
            var distance = Value as Distance;
            if (distance != null)
            {
                writer.WriteAttributeString("Value", distance.Value.ToInVariantString());
                writer.WriteAttributeString("Units", distance.Units.ToString());
            }
        }
    }
}
