using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents range constraint for tool's parameter.
    /// </summary>
    public class Range
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Range"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public Range(object min, object max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Gets or sets the minimum value of the parameter.
        /// </summary>
        public object Min { get; set; }

        /// <summary>
        /// Gets or sets the maximum value of the parameter.
        /// </summary>
        public object Max { get; set; }
    }
}
