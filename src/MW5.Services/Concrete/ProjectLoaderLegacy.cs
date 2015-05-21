using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Serialization;
using MW5.Services.Serialization.Legacy;
using MW5.Shared;

namespace MW5.Services.Concrete
{
    public class ProjectLoaderLegacy
    {
        private readonly ImageSerializationService _imageSerializationService;
        private readonly ILayerService _layerService;
        private readonly ISerializableContext _context;

        public ProjectLoaderLegacy(IAppContext context, ImageSerializationService imageSerializationService, ILayerService layerService)
        {
            if (imageSerializationService == null) throw new ArgumentNullException("imageSerializationService");
            if (layerService == null) throw new ArgumentNullException("layerService");
            _imageSerializationService = imageSerializationService;
            _layerService = layerService;

            _context = context as ISerializableContext;
            if (_context == null)
            {
                throw new InvalidCastException("Application context must support ISerializable_context interface.");
            }
        }

        /// <summary>
        /// Restores the state of application by populating application _context after project file was deserialized.
        /// </summary>
        public bool Restore(MapWin4Project project, string filename)
        {
            _context.Map.Lock();
            _context.Legend.Lock();

            string path = Path.GetDirectoryName(filename);

            try
            {
                _layerService.BeginBatch();

                RestoreLayers(project, path);

                RestoreGroups(project);

                MapLayerToGroups(project);

                //RestoreMapProjection(project);

                //RestoreExtents(project);

                //RestoreLocator(project);

                return true;
            }
            finally
            {
                _layerService.EndBatch();
                _context.Map.Unlock();
                _context.Legend.Unlock();
                _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            }
        }

        private void RestoreLayers(MapWin4Project project, string path)
        {
            if (project.MapwinGis == null || project.MapwinGis.Layers == null)
            {
                Logger.Current.Info("Failed to find Layers node in the legacy project file.");
                return;
            }

            var layers = project.MapwinGis.Layers;
            foreach (var xmlLayer in layers)
            {
                if (string.IsNullOrWhiteSpace(xmlLayer.Filename))
                {
                    Logger.Current.Info("Failed to load layer: " + (xmlLayer.LayerName ?? ""));
                    continue;
                }

                string filename = Path.Combine(path, xmlLayer.Filename);
                if (!File.Exists(filename))
                {
                    Logger.Current.Info("Layer isn't found: " + filename);
                    continue;
                }

                if (_layerService.AddLayersFromFilename(filename))
                {
                    var layer = _context.Layers.ItemByHandle(_layerService.LastLayerHandle);

                    if (layer == null) continue;
                    layer.Name = xmlLayer.LayerName;

                    string state = xmlLayer.SerializeToXml();
                    layer.Deserialize(state);
                }
            }
        }

        private void RestoreGroups(MapWin4Project project)
        {
            if (project.MapWindow == null || project.MapWindow.Groups == null || project.MapWindow.Layers == null)
            {
                Logger.Current.Info("Failed to find Groups node in the legacy project file.");
                return;
            }
            
            var xmlGroups = project.MapWindow.Groups;
            var groups = _context.Legend.Groups;

            foreach (var xmlGroup in xmlGroups)
            {
                var group = groups.Add(xmlGroup.Name);
                group.Expanded = xmlGroup.IsExpanded();
            }
        }

        private void MapLayerToGroups(MapWin4Project project)
        {
            var groups = _context.Legend.Groups;
            
            var layers = project.MapWindow.Layers;
            var legendLayers = _context.Legend.Layers;

            foreach (var xmlLayer in layers)
            {
                var layer = legendLayers.FirstOrDefault(l => l.Name.EqualsIgnoreCase(xmlLayer.Name));
                if (layer != null)
                {
                    var g = groups.GetGroupSafe(xmlLayer.GroupIndex + 1);
                    if (g != null)
                    {
                        _context.Layers.MoveLayer(layer.Handle, g.Handle);
                        layer.Expanded = xmlLayer.IsExpanded();
                    }
                }
            }

            // removing data layers group to which layers are added originally
            if (groups.Count > 1 && !groups[0].Layers.Any())
            {
                groups.Remove(groups[0].Handle);
            }
        }
    }
}
