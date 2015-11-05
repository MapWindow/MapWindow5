using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Services
{
    [DataContract(Name="Layout")]
    internal class XmlLayout: XmlLayoutBase
    {
        public XmlLayout()
        {
            
            Elements = new List<LayoutElement>();
        }

        [DataMember]
        public List<LayoutElement> Elements { get; set; }
    }

    [DataContract(Name = "Layout")]
    internal class XmlLayoutBase
    {
        [DataMember]
        public XmlPaper Paper { get; set; }
    }
}
