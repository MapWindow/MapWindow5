using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Printing.Services
{
    [DataContract]
    internal class XmlPaperFormat
    {
        [DataMember]
        public string PaperName { get; set; }

        // TODO: add others
    }
}
