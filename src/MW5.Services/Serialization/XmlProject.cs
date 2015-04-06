using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
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
                Projection = context.Map.Projection.ExportToWkt(),
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
    }
}
