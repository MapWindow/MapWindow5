using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
    public class RequiredParameterAttribute: Attribute
    {
        public RequiredParameterAttribute(string displayName, int index)
        {
            DisplayName = displayName;
            Index = index;
        }

        public int Index { get; set; }
        public string DisplayName { get; private set; }
    }
}
