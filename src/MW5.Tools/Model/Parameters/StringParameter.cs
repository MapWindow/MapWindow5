// -------------------------------------------------------------------------------------------
// <copyright file="StringParameter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// The string parameter.
    /// </summary>
    public class StringParameter : BaseParameter, IXmlSerializable
    {
        private readonly bool _multiline;

        public StringParameter(bool multiline = false)
        {
            _multiline = multiline;
        }

        public bool MultiLine
        {
            get { return _multiline; }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            PreviousValue = reader.GetAttribute("Value");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Value", (string)Value);
        }

        public override bool Serializable
        {
            get { return true; }
        }

        public override bool IsEmpty
        {
            get { return string.IsNullOrWhiteSpace(Value as string); }
        }
    }
}