// -------------------------------------------------------------------------------------------
// <copyright file="ParameterSerialization.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using MW5.Shared;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Extension methods to performs serialization / deserialization of XML parameters.
    /// </summary>
    internal static class ParameterSerialization
    {
        /// <summary>
        /// An implementation IXmlSerializable interface for a list of parameters.
        /// </summary>
        public static void ReadParameters(this XmlReader reader, IEnumerable<BaseParameter> parameters)
        {
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                string name = reader.LocalName;

                var item = parameters.FirstOrDefault(p => p.Name.EqualsIgnoreCase(name));
                if (item != null && item.Serializable)
                {
                    var xml = item as IXmlSerializable;
                    if (xml != null)
                    {
                        xml.ReadXml(reader);
                    }
                }
            }
        }

        /// <summary>
        /// Serializes parameters into XML and returns it as a string.
        /// </summary>
        public static string Serialize(this IEnumerable<BaseParameter> parameters, string rootNodeName)
        {
            using (var writer = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(writer))
                {
                    xmlWriter.Formatting = Formatting.Indented;

                    xmlWriter.WriteStartElement(rootNodeName);
                    xmlWriter.WriteParameters(parameters);
                    xmlWriter.WriteEndElement();

                    return writer.ToString();
                }
            }
        }

        /// <summary>
        /// An implementation IXmlSerializable interface for a list of parameters.
        /// </summary>
        public static void WriteParameters(this XmlWriter writer, IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters.Where(p => p.Serializable))
            {
                var xml = p as IXmlSerializable;
                if (xml != null)
                {
                    writer.WriteStartElement(p.Name);
                    xml.WriteXml(writer);
                    writer.WriteEndElement();
                }
            }
        }
    }
}