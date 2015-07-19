// -------------------------------------------------------------------------------------------
// <copyright file="ToolboxGroupMetadata.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Plugins.Concrete;

namespace MW5.Tools.Toolbox
{
    internal class ToolboxGroupMetadata
    {
        public ToolboxGroupMetadata(string key, string name, PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            PluginIdentity = identity;
            Key = key;
            Name = name;
        }

        public string Description { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public object Tag { get; set; }

        public PluginIdentity PluginIdentity { get; set; }
    }
}