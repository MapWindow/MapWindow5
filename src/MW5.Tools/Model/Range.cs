using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
    public class Range
    {
        public Range(object min, object max)
        {
            Min = min;
            Max = max;
        }

        public object Min { get; set; }
        public object Max { get; set; }
    }
}
