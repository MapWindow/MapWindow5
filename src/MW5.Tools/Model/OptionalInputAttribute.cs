// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionalInputAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The optional parameter attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model
{
    /// <summary>
    /// The optional parameter attribute.
    /// </summary>
    public class OptionalInputAttribute : ParameterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionalInputAttribute"/> class.
        /// </summary>
        public OptionalInputAttribute(string displayName, int index) : base(displayName, index)
        {
            DisplayName = displayName;
            Index = index;
        }
    }
}