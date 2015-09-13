using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Model
{
    // TODO: remove
    public class DriverOptionCollection: IEnumerable<BaseParameter>, IXmlSerializable
    {
        private readonly IEnumerable<BaseParameter> _parameters;

        public DriverOptionCollection(IEnumerable<BaseParameter> parameters)
        {
            if (parameters == null) throw new ArgumentNullException("parameters");
            _parameters = parameters;
        }

        public IEnumerator<BaseParameter> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadParameters(_parameters);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteParameters(_parameters);
        }
    }
}
