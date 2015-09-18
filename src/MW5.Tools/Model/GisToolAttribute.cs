// -------------------------------------------------------------------------------------------
// <copyright file="GisToolAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using MW5.Plugins.Enums;
using MW5.Tools.Enums;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Represents attribute which sets the properties of the GIS tool, affecting its position in the toolbox and UI selection.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GisToolAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GisToolAttribute"/> class.
        /// </summary>
        public GisToolAttribute(string groupKey, ToolIcon icon = ToolIcon.ToolDefault, Type presenter = null)
        {
            if (string.IsNullOrWhiteSpace(groupKey))
            {
                throw new ArgumentNullException("groupKey");
            }

            GroupKey = groupKey;
            Icon = icon;
            PresenterType = presenter;
        }

        /// <summary>
        /// Gets the type of the MVP presenter to instatiate UI.
        /// </summary>
        public Type PresenterType { get; private set; }

        /// <summary>
        /// Gets the key of the toolbox group the tool should be added to.
        /// </summary>
        public string GroupKey { get; private set; }

        /// <summary>
        /// Gets the icon to display the tool in the toolbox.
        /// </summary>
        public ToolIcon Icon { get; private set; }
    }
}