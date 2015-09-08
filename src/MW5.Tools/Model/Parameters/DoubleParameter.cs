// -------------------------------------------------------------------------------------------
// <copyright file="BooleanParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The double parameter.
    /// </summary>
    public class DoubleParameter : NumericParameter<double>, IXmlSerializable
    {
        public override string ToString()
        {
            return string.Format("{0}: {1:g3}", DisplayName, Value);
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            double val;
            if (double.TryParse(reader.GetAttribute("Value"), NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out val))
            {
                DefaultValue = val;
            }
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Value", ((double)Value).ToString(CultureInfo.InvariantCulture));
        }
    }
}