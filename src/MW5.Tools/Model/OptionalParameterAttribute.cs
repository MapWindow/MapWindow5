// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionalParameterAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The optional parameter attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model
{
    using System;

    /// <summary>
    /// The optional parameter attribute.
    /// </summary>
    public class OptionalParameterAttribute : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionalParameterAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The index.</param>
        public OptionalParameterAttribute(string displayName, int index)
        {
            DisplayName = displayName;
            Index = index;

            // TODO: Optional parameters should have a default value,
            // this value can be of any type: string, boolean, integer, layer, etc
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }

        #endregion
    }
}