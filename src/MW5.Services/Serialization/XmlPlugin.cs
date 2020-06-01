using System;
using System.Collections.Generic;

namespace MW5.Services.Serialization
{
    public class XmlPlugin
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public IDictionary<string, string> Settings { get; set; }
    }
}
