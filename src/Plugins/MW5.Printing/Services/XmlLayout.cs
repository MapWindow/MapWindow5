using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Services
{
    [DataContract]
    internal class XmlLayout
    {
        public XmlLayout()
        {
            PaperFormat = new XmlPaperFormat();
            Elements = new List<LayoutElement>();
        }

        [DataMember]
        public XmlPaperFormat PaperFormat { get; set; }

        [DataMember]
        public List<LayoutElement> Elements { get; set; }
    }
}
