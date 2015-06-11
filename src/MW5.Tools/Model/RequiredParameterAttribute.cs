// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequiredParameterAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The required parameter attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The required parameter attribute.
    /// </summary>
    public class RequiredParameterAttribute : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredParameterAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The index.</param>
        public RequiredParameterAttribute(string displayName, int index)
        {
            DisplayName = displayName;
            Index = index;
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