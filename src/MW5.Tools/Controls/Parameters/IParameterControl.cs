using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// The ParameterControl interface.
    /// </summary>
    public interface IParameterControl
    {
        /// <summary>
        /// The value changed event
        /// </summary>
        event EventHandler<EventArgs> ValueChanged;

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// Gets the name of the parameter.
        /// </summary>
        string ParameterName { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        object GetValue();

        /// <summary>
        /// Sets the value.
        /// </summary>
        void SetValue(object value);
    }
}
