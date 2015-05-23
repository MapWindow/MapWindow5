using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Controls;
using MW5.Services.Serialization;
using MW5.Services.Serialization.Legacy;
using MW5.Services.Views;
using MW5.Shared;

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

                if (!RestoreLayers(project))
                {
                    return false;
                }

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

        private bool RestoreLayers(XmlProject project)
        {
            if (!ValidateLayers(project))
            {
                return false;
            }

            var layers = _context.Map.Layers;

            foreach (var xmlLayer in project.Layers)
            {
                if (xmlLayer.SkipLoading)
                {
                    Logger.Current.Info("Layer loading was skipped: " + xmlLayer.Identity);
                    continue;
                }
                
                if (_layerService.AddLayerIdentity(xmlLayer.Identity))
                {
                    int handle = _layerService.LastLayerHandle;
                    var layer = layers.ItemByHandle(handle) as ILegendLayer;
                    xmlLayer.RestoreLayer(layer);
                }
            }

            return true;
        }

        private void TryFindLayers(XmlProject project, List<MissingLayer> missingLayers)
        {
            // in case project has moved, let's try to use relative filename
            foreach (var xmlLayer in project.Layers)
            {
                if (xmlLayer.Identity.IdentityType == Api.Enums.LayerIdentityType.File)
                {
                    if (!File.Exists(xmlLayer.Identity.Filename))
                    {
                        string filename = project.Settings.UpdateLayerPath(xmlLayer.Identity.Filename);

                        if (!File.Exists(filename))
                        {
                            var ml = new MissingLayer(xmlLayer.Name, xmlLayer.Identity.Filename, xmlLayer.LayerType, xmlLayer);

                            missingLayers.Add(ml);

                            continue;
                        }

                        // substitute with relative one
                        xmlLayer.Identity.Filename = filename;
                    }
                }
            }
        }

        private bool ValidateLayers(XmlProject project)
        {
            var missingLayers = new List<MissingLayer>();

            TryFindLayers(project, missingLayers);

            // if it didn't help, let's ask offer the user to find them
            if (missingLayers.Any())
            {
                var p = _context.Container.GetInstance<MissingLayersPresenter>();
                if (!p.Run(missingLayers))
                {
                    return false;
                }

                foreach (var layer in missingLayers)
                {
                    var xmlLayer = layer.Tag as XmlLayer;
                    if (xmlLayer != null )
                    {
                        if (File.Exists(layer.Filename))
                        {
                            xmlLayer.Identity.Filename = layer.Filename;
                        }
                        else
                        {
                            xmlLayer.SkipLoading = true;
                        }
                    }
                }
            }

            return true;
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
