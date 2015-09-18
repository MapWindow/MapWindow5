using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents attribute to mark tool properties as output parameters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class OutputAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The order in which the controls will be added to the panel.</param>
        public OutputAttribute(string displayName, int index = 0)
        {
            DisplayName = displayName;
            
            Index = index;
        }

        /// <summary>
        /// Gets or sets the order in which the controls will be added to the panel
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; set; }
    }
}
