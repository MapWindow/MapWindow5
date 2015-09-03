using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
    public class OutputAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The index.</param>
        /// <param name="filename">Initial filename for the output.</param>
        public OutputAttribute(string displayName, int index, string filename)
        {
            DisplayName = displayName;
            Index = index;
            Filename = filename;
        }

        public string Filename { get; set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }
    }
}
