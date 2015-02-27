using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MW5.CoreApi.Interfaces;

namespace MW5.CoreApi.Concrete
{
    public class DoubleValue : IAttributeValue
    {
        public AttributeType Type { get { return AttributeType.Double; } }
        public Double Value { get; set; }
    }

    public class IntegerValue : IAttributeValue
    {
        public AttributeType Type { get { return AttributeType.Integer; } }
        public int Value { get; set; }
    }

    public class StringValue : IAttributeValue
    {
        public AttributeType Type { get { return AttributeType.String; } }
        public string Value { get; set; }
    }
}
