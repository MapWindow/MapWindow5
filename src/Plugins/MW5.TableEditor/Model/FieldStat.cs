using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.TableEditor.Model
{
    internal class FieldStat
    {
        public FieldStat()
        {
            
        }

        public FieldStat(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Name + ": " + Value;
        }
    }
}
