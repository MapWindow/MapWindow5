using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents attribute with the properties of OutputLayerParameter.
    /// </summary>
    /// <remarks>Is mandatory for OutputLayerInfo type parameters.</remarks>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class OutputLayerAttribute: Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputLayerAttribute"/> class.
        /// </summary>
        /// <param name="nameTemplate">Initial filename for the output.</param>
        /// <param name="layerType">Layer type of the output.</param>
        /// <param name="supportInMemory">True if output can be in memory layer.</param>
        public OutputLayerAttribute(string nameTemplate = "", LayerType layerType = LayerType.Invalid, bool supportInMemory = true)
        {
            NameTemplate = nameTemplate;
            SupportsInMemory = supportInMemory;
            LayerType = layerType;
            
        }

        /// <summary>
        /// Gets or sets the value indicating whether output can be an in memory layer.
        /// </summary>
        public bool SupportsInMemory { get; set; }

        /// <summary>
        /// Gets or sets the name template.
        /// </summary>
        public string NameTemplate { get; set; }

        /// <summary>
        /// Gets or sets the type of the layer.
        /// </summary>
        public LayerType LayerType { get; set; }
    }
}
