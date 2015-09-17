using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Enums;

namespace MW5.Tools.Model
{
    public class ControlHintAttribute: Attribute
    {
        public ControlHintAttribute(ControlHint type)
        {
            ControlHint = type;
        }

        public ControlHint ControlHint { get; private set; }
    }
}
