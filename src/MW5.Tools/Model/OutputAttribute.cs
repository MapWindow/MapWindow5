using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Tools.Model
{
    public class OutputAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="filename">Initial filename for the output.</param>
        /// <param name="layerType">Layer type of the output.</param>
        public OutputAttribute(string displayName, string filename, LayerType layerType = LayerType.Invalid)
        {
            DisplayName = displayName;
            Filename = filename;
        }

        public string Filename { get; set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the type of the layer.
        /// </summary>
        public LayerType LayerType { get; set; }
    }
}
