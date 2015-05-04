using System;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Serialization;
using MW5.Services.Serialization.Legacy;

namespace MW5.Services.Concrete
{
    public class ProjectLoader: IProjectLoader
    {
        private readonly ImageSerializationService _imageSerializationService;
        private readonly ILayerService _layerService;
        private readonly ISerializableContext _context;

        public ProjectLoader(IAppContext context, ImageSerializationService imageSerializationService, ILayerService layerService)
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
        public bool Restore(XmlProject project)
        {
            _context.Map.Lock();
            _context.Legend.Lock();

            try
            {
                _layerService.BeginBatch();

                RestoreMapProjection(project);

                RestorePlugins(project);

                RestoreLayers(project);

                RestoreGroups(project);

                RestoreExtents(project);

                RestoreLocator(project);

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

        private void RestoreMapProjection(XmlProject project)
        {
            var sr = new SpatialReference();
            sr.ImportFromAutoDetect(project.Map.Projection);

            _context.SetMapProjection(sr);
        }

        private void RestorePlugins(XmlProject project)
        {
            foreach (var p in project.Plugins)
            {
                _context.PluginManager.LoadPlugin(p.Guid, _context);
            }
        }

        private void RestoreExtents(XmlProject project)
        {
            var e = project.Map.Envelope;
            if (e != null)
            {
                _context.Map.ZoomToExtents(new Envelope(e.MinX, e.MaxX, e.MinY, e.MaxY));
            }
        }

        private void RestoreLocator(XmlProject project)
        {
            var locator = project.Locator;
            if (locator != null)
            {
                var bitmap = _imageSerializationService.ConvertStringToImage(locator.Image, locator.Type);
                _context.Locator.RestorePicture(bitmap as System.Drawing.Image, locator.Dx, locator.Dy, locator.XllCenter, locator.YllCenter);
            }
        }

        private void RestoreLayers(XmlProject project)
        {
            var layers = _context.Map.Layers;
            foreach (var xmlLayer in project.Layers)
            {
                if (_layerService.AddLayerIdentity(xmlLayer.Identity)) 
                {
                    int handle = _layerService.LastLayerHandle;
                    var layer = layers.ItemByHandle(handle) as ILegendLayer;
                    xmlLayer.RestoreLayer(layer);
                }
            }
        }

        private void RestoreGroups(XmlProject project)
        {
            if (project.Groups == null)
            {
                return;
            }

            foreach (var g in project.Groups)
            {
                var group = _context.Legend.Groups.Add(g.Name);
                group.Expanded = g.Expanded;

                foreach (var guid in g.Layers)
                {
                    var layer = _context.Legend.Layers.FirstOrDefault(l => l.Guid == guid);
                    if (layer != null)
                    {
                        _context.Layers.MoveLayer(layer.Handle, group.Handle);
                    }
                }
            }

            // first group was generated automatically
            if (_context.Legend.Groups.Any())
            {
                _context.Legend.Groups.Remove(_context.Legend.Groups[0].Handle);
            }
        }
    }
}
