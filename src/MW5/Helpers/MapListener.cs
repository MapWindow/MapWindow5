using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Events;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Services.Abstract;

namespace MW5.Helpers
{
    /// <summary>
    /// Allows to handle map events by the core application and broadcast them to plugins after that.
    /// </summary>
    internal class MapListener
    {
        private readonly PluginBroadcaster _plugins;
        private readonly ILayerService _layerService;
        private readonly IMap _map;
        private readonly IAppContext _context;

        public MapListener(IMap map, IAppContext context, PluginBroadcaster broadcaster, ILayerService layerService)
        {
            _plugins = broadcaster;
            _layerService = layerService;
            _map = map;
            _context = context;

            if (_plugins == null || _map == null || _context == null || layerService == null)
            {

                throw new NullReferenceException("Failed to initialize map listener.");
            }

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _map.ExtentsChanged += MapExtentsChanged;
            _map.FileDropped += MapFileDropped;
            _map.BeforeDeleteShape += MapBeforeDeleteShape;
            _map.BeforeShapeEdit += MapBeforeShapeEdit;
            _map.MouseUp += MapMouseUp;
            _map.ShapeValidationFailed += MapShapeValidationFailed;
            _map.UndoListChanged += MapUndoListChanged;
            _map.ValidateShape += MapValidateShape;

            var mapControl = (_map as MapControl);
            if (mapControl != null)
            {
                mapControl.PreviewKeyDown += MapListener_PreviewKeyDown;
            }
        }

        private void MapValidateShape(object sender, ValidateShapeEventArgs e)
        {
            _plugins.BroadcastEvent(p => p.ValidateShape_, sender as IMuteMap, e);
        }

        private void MapUndoListChanged(object sender, EventArgs e)
        {
            _plugins.BroadcastEvent(p => p.UndoListChanged_, sender as IMuteMap, e);
        }

        private void MapShapeValidationFailed(object sender, ShapeValidationFailedEventArgs e)
        {
            _plugins.BroadcastEvent(p => p.ShapeValidationFailed_, sender as IMuteMap, e);
        }

        private void MapMouseUp(object sender, MouseEventArgs e)
        {
            _plugins.BroadcastEvent(p => p.MouseUp_, sender as IMuteMap, e);
        }

        private void MapBeforeShapeEdit(object sender, BeforeShapeEditEventArgs e)
        {
            _plugins.BroadcastEvent(p => p.BeforeShapeEdit_, sender as IMuteMap, e);
        }

        private void MapBeforeDeleteShape(object sender, BeforeDeleteShapeEventArgs e)
        {
            _plugins.BroadcastEvent(p => p.BeforeDeleteShape_, sender as IMuteMap, e);
        }

        private void MapFileDropped(object sender, FileDroppedEventArgs e)
        {
            _layerService.AddLayersFromFilename(e.Filename);
        }

        private void MapExtentsChanged(object sender, EventArgs e)
        {
            _plugins.BroadcastEvent(p => p.ExtentsChanged_, sender as IMuteMap, e);
        }

        private void MapListener_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    e.IsInputKey = true;
                    return;
            }
        }
    }
}
