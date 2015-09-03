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
    /// The gis tool attribute.
    /// </summary>
    public class GisToolAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GisToolAttribute"/> class.
        /// </summary>
        public GisToolAttribute(string groupKey, ToolIcon icon = ToolIcon.ToolDefault)
        {
            if (string.IsNullOrWhiteSpace(groupKey))
            {
                throw new ArgumentNullException("groupKey");
            }

            GroupKey = groupKey;
            Icon = icon;
        }

        public string GroupKey { get; private set; }

        public ToolIcon Icon { get; private set; }
    }
}