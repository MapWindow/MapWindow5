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
            if (distance != null)
            {
                return string.Format("{0}: {1:g3} {2}", DisplayName, distance.Value, distance.Units);
            }

            return string.Format("{0}: <empty>", DisplayName);
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
                writer.WriteAttributeString("Value", distance.Value.ToInvariantString());
                writer.WriteAttributeString("Units", distance.Units.ToString());
            }
        }
    }
}
