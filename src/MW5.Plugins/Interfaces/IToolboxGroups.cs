// -------------------------------------------------------------------------------------------
// <copyright file="IToolboxGroups.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// Represents a list of groups at a certain level of the GIS toolbox.
    /// </summary>
    public interface IToolboxGroups : IEnumerable<IToolboxGroup>
    {
        int Count { get; }

        IToolboxGroup Add(string name, string key, PluginIdentity identity);

        void Clear();

        IToolboxGroup FindGroup(string groupKey);

        bool Remove(string groupKey);

        void RemoveItemsForPlugin(PluginIdentity identity);
    }
}