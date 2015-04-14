using System;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Events;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Listeners
{
    /// <summary>
    /// Allows to handle map events by the core application and broadcast them to plugins after that.
    /// </summary>
    internal class MapListener
    {
        private readonly IBroadcasterService _broadcaster;
        private readonly ILayerService _layerService;
        private readonly IMap _map;
        private readonly IAppContext _context;

        public MapListener(IAppContext context, IBroadcasterService broadcaster, ILayerService layerService)
        {
            _context = context;
            _broadcaster = broadcaster;
            _layerService = layerService;
            
            if (_broadcaster == null || _context == null || layerService == null)
            {

                throw new NullReferenceException("Failed to initialize map listener.");
            }

            _map = _context.Map as IMap;
            if (_map == null)
            {
                throw new ApplicationException("Invalid map state.");
            }

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _map.BeforeDeleteShape += MapBeforeDeleteShape;
            _map.BeforeShapeEdit += MapBeforeShapeEdit;
            _map.ChooseLayer += MapChooseLayer;
            _map.ExtentsChanged += MapExtentsChanged;
            _map.FileDropped += MapFileDropped;
            _map.HistoryChanged += MapHistoryChanged;
            _map.MapCursorChanged += MapCursorChanged;
            _map.MouseUp += MapMouseUp;
            _map.MouseDown += MapMouseDown;
            _map.MouseMove += MapMouseMove;
            _map.SelectionChanged += MapSelectionChanged;
            _map.ShapeIdentified += MapShapeIdentified;
            _map.ShapeValidationFailed += MapShapeValidationFailed;
            _map.ValidateShape += MapValidateShape;

            var mapControl = (_map as MapControl);
            if (mapControl != null)
            {
                mapControl.PreviewKeyDown += MapListener_PreviewKeyDown;
            }
        }

        private void MapMouseMove(object sender, MouseEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.MouseMove_, sender as IMuteMap, e);
        }

        private void MapMouseDown(object sender, MouseEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.MouseDown_, sender as IMuteMap, e);
        }

        private void MapShapeIdentified(object sender, ShapeIdentifiedEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.ShapeIdentified_, sender as IMuteMap, e);
        }

        private void MapSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.UpdateMap)
            {
                _map.Redraw();
            }
            _context.View.Update();

            _broadcaster.BroadcastEvent(p => p.SelectionChanged_, sender as IMuteMap, e);
        }

        private void MapChooseLayer(object sender, ChooseLayerEventArgs e)
        {
            e.LayerHandle = _context.Map.Layers.Current.Handle;
            _broadcaster.BroadcastEvent(p => p.ChooseLayer_, sender as IMuteMap, e);
        }

        private void MapCursorChanged(object sender, EventArgs e)
        {
            _context.View.Update();

            _broadcaster.BroadcastEvent(p => p.MapCursorChanged_, sender as IMuteMap, e);
        }

        private void MapValidateShape(object sender, ValidateShapeEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.ValidateShape_, sender as IMuteMap, e);
        }

        private void MapHistoryChanged(object sender, EventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.HistoryChanged_, sender as IMuteMap, e);
        }

        private void MapShapeValidationFailed(object sender, ShapeValidationFailedEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.ShapeValidationFailed_, sender as IMuteMap, e);
        }

        private void MapMouseUp(object sender, MouseEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.MouseUp_, sender as IMuteMap, e);
        }

        private void MapBeforeShapeEdit(object sender, BeforeShapeEditEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.BeforeShapeEdit_, sender as IMuteMap, e);
        }

        private void MapBeforeDeleteShape(object sender, BeforeDeleteShapeEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.BeforeDeleteShape_, sender as IMuteMap, e);
        }

        private void MapFileDropped(object sender, FileDroppedEventArgs e)
        {
            if (e.IsOgrConnection)
            {
                _layerService.AddDatabaseLayer(e.Connection, e.LayerName);
            }
            else
            {
                _layerService.AddLayersFromFilename(e.Filename);
            }

            int handle = _layerService.LastLayerHandle;
            _map.ZoomToLayer(handle);
        }

        private void MapExtentsChanged(object sender, EventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.ExtentsChanged_, sender as IMuteMap, e);
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
