using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MW5.Shared
{
    public static class BooleanHelper
    {
        public static bool Parse(string s)
        {
            bool value;

            if (!Boolean.TryParse(s, out value))
            {
                value = XmlConvert.ToBoolean(s);
            }

            return value;
        }
    }
}
