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
using MW5.Shared;

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

        public virtual XmlSchema GetSchema()
        {
            return null;
        }

        public virtual void ReadXml(XmlReader reader)
        {
            double val;
            if (reader.GetAttribute("Value").ParseDoubleInvariant(out val))
            {
                PreviousValue = val;
            }
        }

        public virtual void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Value", ((double)Value).ToInvariantString());
        }
    }
}