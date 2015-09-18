using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents distance set in specific length units.
    /// </summary>
    public class Distance
    {
        public Distance(double value, LengthUnits units)
        {
            Value = value;
            Units = units;
        }

        /// <summary>
        /// Gets or sets length units.
        /// </summary>
        public LengthUnits Units { get; set; }

        /// <summary>
        /// Gets or sets distance value.
        /// </summary>
        public double Value { get; set; }
    }
}
