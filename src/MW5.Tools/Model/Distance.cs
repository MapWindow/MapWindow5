using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Tools.Model
{
    public class Distance
    {
        public Distance(double value, LengthUnits units)
        {
            Value = value;
            Units = units;
        }

        public LengthUnits Units { get; set; }
        public double Value { get; set; }
    }
}
