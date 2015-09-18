// -------------------------------------------------------------------------------------------
// <copyright file="InputAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Tools.Enums;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents attribute to mark tool properties as input parameters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InputAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The index. -1 should be passed to exclude parameter for UI.</param>
        /// <param name="optional">True if parameter must be displayed on the optional panel.</param>
        public InputAttribute(string displayName, int index, bool optional = false)
        {
            DisplayName = displayName;
            Index = index;
            Optional = optional;
            SectionName = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The index. -1 should be passed to exclude parameter from UI.</param>
        /// <param name="sectionName">The name of the section which will be displayed as a separate section or panel in the UI.</param>
        public InputAttribute(string displayName, int index, string sectionName)
        {
            DisplayName = displayName;
            Index = index;
            Optional = true;
            SectionName = sectionName;
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

        /// <summary>
        /// Gets or sets the name of the section which will be displayed as a separate section or panel in the UI.
        /// </summary>
        public string SectionName { get; set; }
    }
}