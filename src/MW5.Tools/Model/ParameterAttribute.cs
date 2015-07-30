// -------------------------------------------------------------------------------------------
// <copyright file="ParameterAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;

namespace MW5.Tools.Model
{
    public abstract class ParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The index.</param>
        protected ParameterAttribute(string displayName, int index)
        {
            DisplayName = displayName;
            Index = index;
        }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }
    }
}