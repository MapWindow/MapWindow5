// -------------------------------------------------------------------------------------------
// <copyright file="InputAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Tools.Enums;

namespace MW5.Tools.Model
{
    public class InputAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The index.</param>
        /// <param name="optional">True if parameter must be displayed on the optional panel.</param>
        /// <param name="type">A hint to choose proper UI representation for parameter.</param>
        public InputAttribute(string displayName, int index, bool optional = false)
        {
            DisplayName = displayName;
            Index = index;
            Optional = optional;
        }

        public bool Optional { get; set; }

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