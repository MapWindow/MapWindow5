using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Holds the name of the field and the layer it belongs to.
    /// </summary>
    public class FieldWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldWrapper"/> class.
        /// </summary>
        /// <param name="layerName">Name of the layer.</param>
        /// <param name="fieldName">Name of the field.</param>
        public FieldWrapper(string layerName, string fieldName)
        {
            LayerName = layerName;
            FieldName = fieldName;
        }

        /// <summary>
        /// Gets the name of the layer.
        /// </summary>
        public string LayerName { get; private set; }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string FieldName { get; private set; }
    }
}
