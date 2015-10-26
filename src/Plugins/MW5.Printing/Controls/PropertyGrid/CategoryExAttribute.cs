// -------------------------------------------------------------------------------------------
// <copyright file="CategoryExAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.ComponentModel;
using MW5.Plugins.Printing.Properties;

namespace MW5.Plugins.Printing.Controls.PropertyGrid
{
    internal class CategoryExAttribute : CategoryAttribute
    {
        private readonly string resourceName;

        public CategoryExAttribute(string resourceName)
        {
            this.resourceName = resourceName;
        }

        protected override string GetLocalizedString(string value)
        {
            return Strings.ResourceManager.GetString(this.resourceName);
        }
    }
}