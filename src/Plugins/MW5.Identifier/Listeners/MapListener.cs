using System;
using System.Diagnostics;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Plugins.Identifier.Enums;
using MW5.Plugins.Identifier.Views;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Plugins.Identifier.Listeners
{
    public class MapListener
    {
        private readonly IAppContext _context;
        private readonly IdentifierPresenter _identifierPresenter;
        private readonly IConfigService _configService;

        public MapListener(IAppContext context, IdentifierPlugin plugin, IdentifierPresenter identifierPresenter, 
                            IConfigService configService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (identifierPresenter == null) throw new ArgumentNullException("identifierPresenter");
            if (configService == null) throw new ArgumentNullException("configService");

            _context = context;
            _identifierPresenter = identifierPresenter;
            _configService = configService;

            plugin.ShapeIdentified += plugin_ShapeIdentified;
            plugin.ProjectClosed += plugin_ProjectClosed;
            plugin.LayerRemoved += plugin_LayerRemoved;
            plugin.MouseMove += plugin_MouseMove;
        }

        private void plugin_MouseMove(IMuteMap map, System.Windows.Forms.MouseEventArgs e)
        {
            if (map.MapCursor != Api.Enums.MapCursor.Identify)
            {
                return;
            }

            if (_identifierPresenter.View.Mode == IdentifierMode.CurrentLayer /*&& _configService.Config.ShowValuesOnMouseMove*/)
            {
                DisplayCurrentPixelValue(map, e.X, e.Y);
            }
        }

        private void plugin_LayerRemoved(IMuteLegend legend, LayerEventArgs e)
        {
            _identifierPresenter.RemoveLayer(e.LayerHandle);
        }

        private void plugin_ProjectClosed(object sender, EventArgs e)
        {
            _identifierPresenter.RunCommand(IdentifierCommand.Clear);
        }

        private void plugin_ShapeIdentified(IMuteMap map, Api.Events.ShapeIdentifiedEventArgs e)
        {
            _identifierPresenter.ShapeIdentified();
        }

        /// <remarks>
        /// TODO: think of a better place for it to allow reuse        
        /// </remarks>
        private void DisplayCurrentPixelValue(IMuteMap map, int pixelX, int pixelY)
        {
            var layer = map.Layers.Current;
            if (layer == null)
            {
                return;
            }
            
            var raster = layer.Raster;
            if (raster == null)
            {
                return;
            }
            
            double projX, projY;
            map.PixelToProj(pixelX, pixelY, out projX, out projY);

            int rasterX, rasterY;
            if (raster.ProjectionToImage(projX, projY, out rasterX, out rasterY))
            {
                if (raster.RenderingType != Api.Enums.RasterRendering.Rgb)
                {
                    var band = raster.ActiveBand;
                    double value;
                    if (band.GetValue(rasterX, rasterY, out value))
                    {
                        string msg = string.Format("Raster info. X: {0}; Y: {1}; Value: {2}", rasterX, rasterY, value);
                        _context.StatusBar.ShowInfo(msg);
                    }
                }
            }
            else
            {
                _context.StatusBar.ShowInfo("");
            }
        }
    }
}
