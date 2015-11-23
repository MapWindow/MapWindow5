using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Enums;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Specifies the type of control that should be used as input for the specific tool parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ControlHintAttribute: Attribute
    {
        public ControlHintAttribute(ControlHint type, int controlHeight = 0)
        {
            ControlHint = type;
            ControlHeight = controlHeight;
        }

        public int ControlHeight { get; private set; }

        public ControlHint ControlHint { get; private set; }
    }
}
