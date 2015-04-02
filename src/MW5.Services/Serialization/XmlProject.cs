using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using MW5.Api.Concrete;
using MW5.Api.Legend;
using MW5.Plugins.Interfaces;
using MW5.Services.Serialization.Utility;

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

            Map = new XmlMap
            {
                Projection = context.Map.GeoProjection.ExportToWkt(),
                Envelope = new XmlEnvelope(context.Map.Extents)
            };

            if (!context.Locator.Empty)
            {
                var service = context.Container.GetInstance<ImageSerializationService>();
                Locator = new XmlMapLocator(context.Locator, service);
            }
        }

        [DataMember] public XmlMap Map { get; set; }
        [DataMember] public XmlMapLocator Locator { get; set; }
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
            context.Map.Lock();

            var sr = new SpatialReference();
            sr.ImportFromAutoDetect(Map.Projection);

            context.SetMapProjection(sr);

            foreach (var p in Plugins)
            {
                context.PluginManager.LoadPlugin(p.Guid, context);
            }

            foreach (var layer in Layers)
            {
                layer.RestoreLayer(context.Legend.Layers);
            }

            RestoreGroups(context);

            var e = Map.Envelope;
            if (e != null)
            {
                context.Map.Extents = new Envelope(e.MinX, e.MaxX, e.MinY, e.MaxY);
            }

            if (Locator != null)
            {
                var service = context.Container.GetInstance<ImageSerializationService>();
                var bitmap = service.ConvertStringToImage(Locator.Image, Locator.Type);
                context.Locator.RestorePicture(bitmap as System.Drawing.Image, Locator.Dx, Locator.Dy, Locator.XllCenter, Locator.YllCenter);
            }

            context.Map.Unlock();

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
