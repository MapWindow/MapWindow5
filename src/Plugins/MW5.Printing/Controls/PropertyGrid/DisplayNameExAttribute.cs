// -------------------------------------------------------------------------------------------
// <copyright file="DisplayNameExAttribute.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.ComponentModel;
using MW5.Plugins.Printing.Properties;

namespace MW5.Plugins.Printing.Controls.PropertyGrid
{
    internal class DisplayNameExAttribute : DisplayNameAttribute
    {
        private readonly string resourceName;

        public DisplayNameExAttribute(string resourceName)
        {
            this.resourceName = resourceName;
        }

        public override string DisplayName
        {
            get { return Strings.ResourceManager.GetString(this.resourceName); }
        }
    }
}