// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The required parameter attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model
{
    /// <summary>
    /// The required parameter attribute.
    /// </summary>
    public class InputAttribute : ParameterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputAttribute"/> class.
        /// </summary>
        public InputAttribute(string displayName, int index) 
            : base(displayName, index)
        {
            DisplayName = displayName;
            Index = index;
        }
    }
}