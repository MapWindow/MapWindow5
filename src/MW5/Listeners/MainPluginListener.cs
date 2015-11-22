using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Serialization;
using MW5.Shared;
using MW5.Views;

namespace MW5.Listeners
{
    public class MainPluginListener
    {
        private readonly IAppContext _context;
        private readonly MainPlugin _plugin;
        private readonly IConfigService _configService;
        private readonly IBroadcasterService _broadcaster;

        public MainPluginListener(IAppContext context, MainPlugin plugin, IConfigService configService, 
                                IBroadcasterService broadcaster)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (configService == null) throw new ArgumentNullException("configService");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");

            _context = context;
            _plugin = plugin;
            _configService = configService;
            _broadcaster = broadcaster;

            plugin.BeforeLayerAdded += BeforeLayerAdded;
            plugin.LayerAdded += plugin_LayerAdded;
            plugin.GroupDoubleClick += plugin_GroupDoubleClick;
        }

        private void plugin_GroupDoubleClick(IMuteLegend legend, GroupEventArgs e)
        {
            var group = legend.Groups.ItemByHandle(e.GroupHandle);
            if (group != null)
            {
                if (_context.Container.Run<LegendGroupPresenter, ILegendGroup>(group))
                {
                    legend.Redraw();
                }
            }
        }

        private void plugin_LayerAdded(IMuteLegend legend, LayerEventArgs e)
        {
            var layer = _context.Legend.Layers.ItemByHandle(e.LayerHandle);
            if (layer != null)
            {
                LayerSerializationHelper.LoadSettings(layer, _broadcaster, true);
            }
        }

        /// <summary>
        /// Performs actions necessary before adding layer to the map.
        /// </summary>
        private void BeforeLayerAdded(IMuteMap map, DatasourceCancelEventArgs e)
        {
            var raster = e.Datasource as IRasterSource;
            if (raster != null)
            {
                if (!UpdateOverviews(raster))
                {
                    e.Cancel = true;
                }
            }

            var fs = e.Datasource as IFeatureSet;
            if (fs != null)
            {
                if (!UpdateSpatialIndex(fs))
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Checks if spatial index is needed for shapefile.
        /// </summary>
        private bool UpdateSpatialIndex(IFeatureSet fs)
        {
            if (fs.LayerType != LayerType.Shapefile)
            {
                return true;
            }

            var config = _configService.Config;

            if (!NeedsSpatialIndex(fs, config.SpatialIndexFeatureCount))
            {
                return true;
            }

            if (config.ShowSpatialIndexDialog)
            {
                var presenter = _context.Container.GetInstance<SpatialIndexPresenter>();
                if (!presenter.Run())
                {
                    return false;
                }

                config.ShowSpatialIndexDialog = !presenter.DontShowAgain;
                config.CreateSpatialIndexOnOpening = presenter.ReturnValue;
            }

            if (config.CreateSpatialIndexOnOpening)
            {
                CreateSpatialIndex(fs);
            }

            return true;
        }

        /// <summary>
        /// Checks if spatial index is needed for shapefile.
        /// </summary>
        private static bool NeedsSpatialIndex(IFeatureSet fs, int minFeatureCount)
        {
            return fs.SourceType == FeatureSourceType.DiskBased &&
                   fs.NumFeatures >= minFeatureCount &&
                   !fs.SpatialIndex.DiskIndexExists;
        }

        /// <summary>
        /// Creates spatial index for shapefile.
        /// </summary>
        private void CreateSpatialIndex(IFeatureSet fs)
        {
            bool result = fs.SpatialIndex.CreateDiskIndex();

            if (result)
            {
                Logger.Current.Info("Spatial index is build for shapefile: " + fs.Filename);
            }
            else
            {
                Logger.Current.Warn("Failed to build spatial index for shapefile: " + fs.Filename);
            }
        }

        /// <summary>
        /// Prompts user or automatically creates raster overviews if needed.
        /// </summary>
        private bool UpdateOverviews(IRasterSource raster)
        {
            if (!raster.NeedsOverviews)
            {
                return true;
            }

            var config = _configService.Config;

            if (!config.ShowPyramidDialog && config.CreatePyramidsOnOpening)
            {
                bool result = raster.BuildDefaultOverviews(config.PyramidSampling, config.PyramidCompression);



                return true;
            }

            var presenter = _context.Container.GetInstance<CreatePyramidsPresenter>();
            if (!presenter.Run(raster))
            {
                return false;
            }
            
            config.ShowPyramidDialog = !presenter.DontShowAgain;
            config.CreatePyramidsOnOpening = presenter.Result == DialogResult.Yes;
            config.PyramidCompression = presenter.View.Compression;
            config.PyramidSampling = presenter.View.Sampling;
            return true;
        }
    }
}
