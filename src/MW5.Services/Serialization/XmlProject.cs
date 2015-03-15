using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using MW5.Api.Concrete;
using MW5.Api.Legend;
using MW5.Plugins.Interfaces;

namespace MW5.Services.Serialization
{
    /// <summary>
    /// Represents a data contract for MapWindow project file. 
    /// Before serialization the instance is populated from ISerializedContext.
    /// After deserialization RestoreState method should be called.
    /// </summary>
    [DataContract(Name="MapWindow5")]
    public class XmlProject
    {
        public XmlProject(ISerializableContext context)
        {
            Layers = context.Legend.Layers.Select(l => new XmlLayer(l)).ToList();

            Groups = context.Legend.Groups.Select(g => new XmlGroup(g)).ToList();

            Plugins = context.PluginManager.ActivePlugins.Select(p => new XmlPlugin()
            {
                Name = p.Identity.Name,
                Guid = p.Identity.Guid
            }).ToList();

            Map = new XmlMap();
            Map.Projection = context.Map.GeoProjection.ExportToWkt();
        }

        [DataMember] public XmlMap Map { get; set; }
        [DataMember] public List<XmlGroup> Groups { get; set; }
        [DataMember] public List<XmlLayer> Layers { get; set; }
        [DataMember] public List<XmlPlugin> Plugins { get; set; }

        /// <summary>
        /// Restores the state of application by populating application context after project file was deserialized.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public bool RestoreState(ISerializableContext context)
        {
            var sr = new SpatialReference();
            sr.ImportFromAutoDetect(Map.Projection);
            
            foreach (var p in Plugins)
            {
                context.PluginManager.LoadPlugin(p.Guid, context);
            }

            foreach (var layer in Layers)
            {
                layer.RestoreLayer(context.Legend.Layers);
            }

            RestoreGroups(context);
           
            context.Legend.Redraw(LegendRedraw.LegendAndMap);

            return true;
        }

        private void RestoreGroups(ISerializableContext context)
        {
            if (Groups != null)
            {
                foreach (var g in Groups)
                {
                    var group = context.Legend.Groups.Add(g.Name);
                    group.Expanded = g.Expanded;

                    foreach (var guid in g.Layers)
                    {
                        var layer = context.Legend.Layers.FirstOrDefault(l => l.Guid == guid);
                        if (layer != null)
                        {
                            context.Layers.MoveLayer(layer.Handle, group.Handle);
                        }
                    }
                }

                // first group was generated automatically
                context.Legend.Groups.Remove(context.Legend.Groups[0].Handle);
            }
        }
    }
}
