// -------------------------------------------------------------------------------------------
// <copyright file="BooleanParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The boolean parameter.
    /// </summary>
    public class BooleanParameter : BaseParameter, IXmlSerializable
    {
        public override string ToString()
        {
            return string.Format("{0}: {1}", DisplayName, Value);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            bool val;
            if (bool.TryParse(reader.GetAttribute("Value"), out val))
            {
                PreviousValue = val;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Value", Value.ToString());
        }

        public override bool Serializable
        {
            get { return true; }
        }

        public override bool IsEmpty
        {
            get { return !Convert.ToBoolean(Value); }
        }
    }
}