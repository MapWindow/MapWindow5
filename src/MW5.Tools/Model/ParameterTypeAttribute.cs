using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Enums;

namespace MW5.Tools.Model
{
    public class ParameterTypeAttribute: Attribute
    {
        public ParameterTypeAttribute(ParameterType type)
        {
            ParameterType = type;
        }

        public ParameterType ParameterType { get; private set; }
    }
}
