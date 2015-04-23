using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
    public class OptionalParameterAttribute: RequiredParameterAttribute
    {
        public OptionalParameterAttribute(int index, string displayName) : base(displayName, index)
        {
        }
    }
}
