using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Events;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Plugins.AdvancedSnapping.Context;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.AdvancedSnapping.Services;

namespace MW5.Plugins.AdvancedSnapping.Listeners
{
    public class MapListener
    {
        private readonly IAppContext _context;
        private readonly IConfigService _configService;
        private readonly IAnchorService _anchorService;
        private readonly ISnapRestrictionService _snapRestrictionService;
        private readonly ContextMenuExtender _contextMenuExtender;
        private readonly AdvancedSnappingPlugin _plugin;

        public MapListener(IAppContext context, AdvancedSnappingPlugin plugin, 
            ContextMenuExtender contextMenuPresenter,
            IConfigService configService,
            IAnchorService anchorService,
            ISnapRestrictionService snapRestrictionService)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _contextMenuExtender = contextMenuPresenter ?? throw new ArgumentNullException("identifierPresenter");
            _configService = configService ?? throw new ArgumentNullException("configService");
            _anchorService = anchorService ?? throw new ArgumentNullException("anchorService");
            _snapRestrictionService = snapRestrictionService ?? throw new ArgumentNullException("snapRestrictionService");
            _plugin = plugin ?? throw new ArgumentNullException("plugin");

            _plugin.MouseUp += OnMapMouseUp;
            _plugin.ExtentsChanged += OnMapExtentsChanged;

            _plugin.MapCursorChanged += OnMapCursorChanged;

            mapControl = (context.Map as MapControl);

            mapControl.SnapPointRequested += OnSnapPointRequested;

            mapControl.MouseMove += OnMapMouseMove;

            var form = mapControl.FindForm();
            form.KeyPreview = true;
            form.KeyPress += OnApplicationKeyPress;
            form.MouseMove += OnApplicationMouseMove;
        }

        private void OnApplicationMouseMove(object sender, MouseEventArgs e)
        {
            if (_context.Map.MapCursor == Api.Enums.MapCursor.AddShape || _context.Map.MapCursor == Api.Enums.MapCursor.EditShape)
                return;

            _anchorService.UserAnchorLocation = null;
        }

        private void OnMapCursorChanged(IMuteMap map, EventArgs e)
        {
            if (map.MapCursor == Api.Enums.MapCursor.AddShape || map.MapCursor == Api.Enums.MapCursor.EditShape)
                return;

            _anchorService.UserAnchorLocation = null;
        }

        private Point lastKnownMapLocation;
        private MapControl mapControl;

        public bool Digitizing => _context.Map.GeometryEditor.EditorState != Api.Enums.EditorState.None;

        private void OnMapMouseMove(object sender, MouseEventArgs e)
        {
            lastKnownMapLocation = e.Location;

            if (!Digitizing)
                return;

            mapControl.PixelToProj(lastKnownMapLocation.X, lastKnownMapLocation.Y, out double mapX, out double mapY);
            _anchorService.LastUserLocation = new Coordinate(mapX, mapY);
        }

        private void OnApplicationKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled)
                return;

            if (Digitizing)
            {

                mapControl.PixelToProj(lastKnownMapLocation.X, lastKnownMapLocation.Y, out double mapX, out double mapY);
                _anchorService.UserAnchorLocation = new Coordinate(mapX, mapY);

                switch (e.KeyChar)
                {
                    case 's':
                    case 'S':
                        ParallelSnapShortcut();
                        break;
                    case 'd':
                    case 'D':
                        DistanceSnapShortcut();
                        break;
                    case 'f':
                    case 'F':
                        PerpendicularSnapShortcut();
                        break;
                    case 'g':
                    case 'G':
                        BearingSnapShortcut();
                        break;
                }
            }
        }

        private void BearingSnapShortcut()
        {
            if (_plugin.CanSnapBearing)
                _contextMenuExtender.RunCommand(AdvancedSnappingCommand.SnapBearing);
            else
                SystemSounds.Hand.Play();
        }

        private void DistanceSnapShortcut()
        {
            if (_plugin.CanSnapDistance)
                _contextMenuExtender.RunCommand(AdvancedSnappingCommand.SnapDistance);
            else
                SystemSounds.Hand.Play();
        }

        private void PerpendicularSnapShortcut()
        {
            if (_plugin.CanSnapPerpendicular)
                _contextMenuExtender.RunCommand(AdvancedSnappingCommand.SnapPerpendicular);
            else
                SystemSounds.Hand.Play();
        }

        private void ParallelSnapShortcut()
        {
            if (_plugin.CanSnapParallel)
                _contextMenuExtender.RunCommand(AdvancedSnappingCommand.SnapParallel);
            else
                SystemSounds.Hand.Play();
        }

        private void OnSnapPointRequested(object sender, SnapPointRequestedEventArgs e)
        {
            _snapRestrictionService.OnSnapPointRequested(e);
        }

        private void OnMapExtentsChanged(IMuteMap map, EventArgs e)
        {
            _snapRestrictionService.RefreshMap();
        }

        private void OnMapMouseUp(IMuteMap map, MouseEventArgs e)
        {
            bool rightClick = e.Button == MouseButtons.Right;
            if (rightClick)
            {
                _context.Map.PixelToProj(e.X, e.Y, out double mapX, out double mapY);
                _anchorService.UserAnchorLocation = new Coordinate(mapX, mapY);
                _contextMenuExtender.UpdateStates();
            }
            else
            {
                _snapRestrictionService.HandleMapMouseUp();
            }
        }
    }
}
