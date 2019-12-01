// -------------------------------------------------------------------------------------------
// <copyright file="GisToolAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
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
        public GisToolAttribute(
            string groupKey,
            ToolIcon icon = ToolIcon.ToolDefault,
            Type presenter = null,
            string groupName = "",
            string groupDescription = "",
            bool onlyGroup = false,
            string parentGroupKey = "")
        {
            if (string.IsNullOrWhiteSpace(groupKey))
            {
                throw new ArgumentNullException(nameof(groupKey));
            }

            GroupKey = groupKey;
            GroupName = string.IsNullOrEmpty(groupName) ? groupKey : groupName;
            GroupDescription = string.IsNullOrEmpty(groupDescription) ? groupKey : groupDescription;
            Icon = icon;
            PresenterType = presenter;
            OnlyGroup = onlyGroup;
            ParentGroupKey = parentGroupKey;
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
        /// Gets the key of the toolbox group the tool should be added to.
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        /// Gets the description of the toolbox group.
        /// </summary>
        public string GroupDescription { get; private set; }

        /// <summary>
        /// Gets the key of the toolbox parent group.
        /// </summary>
        public string ParentGroupKey { get; private set; }

        /// <summary>
        /// Indicates of this tool is only to create a group
        /// </summary>
        public bool OnlyGroup { get; private set; }

        /// <summary>
        /// Gets the icon to display the tool in the toolbox.
        /// </summary>
        public ToolIcon Icon { get; private set; }
    }

}