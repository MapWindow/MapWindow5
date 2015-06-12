// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GisToolAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The gis tool attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Model
{
    #region

    using System;

    #endregion

    /// <summary>
    /// The gis tool attribute.
    /// </summary>
    public class GisToolAttribute : Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GisToolAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public GisToolAttribute(string name, Type type)
        {
        }

        #endregion
    }
}