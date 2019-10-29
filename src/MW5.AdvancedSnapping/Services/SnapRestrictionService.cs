using MW5.Plugins.AdvancedSnapping.Context;
using MW5.Plugins.AdvancedSnapping.Restrictions;
using MW5.Api.Concrete;
using MW5.Api.Events;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MW5.Plugins.AdvancedSnapping.Services
{
    public class SnapRestrictionService : ISnapRestrictionService
    {
        private IList<IRestriction> activeRestrictions;
        private readonly IAppContext _context;
        private readonly IDrawingService _drawingService;
        private readonly IMap _map;

        //public MapCapture MapCapture { get; }

        #region Constructor
        public SnapRestrictionService(IAppContext context, IDrawingService drawingService)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _drawingService = drawingService ?? throw new ArgumentNullException("drawingService");

            _map = _context.Map as IMap;
            //MapCapture = new MapCapture(_map as MapControl);

            activeRestrictions = new List<IRestriction>();
        }
        #endregion

        #region Event handler management (otherwise snapping is slow for no reason)
        public bool HasActiveRestrictions => activeRestrictions.Any();

        public bool AutoClear { get; set; } = true;

        public void RefreshMap()
        {
            foreach (var restriction in activeRestrictions)
                restriction.RefreshGuideline(_map);
        }

        public void HandleMapMouseUp()
        {
            if (!_map.GeometryEditor.IsDigitizing)
                Clear();
            else if (AutoClear)
                CheckHandle(_map.GeometryEditor.NumPoints);
        }
        #endregion

        #region Forcing snap mode when adding a restriction
        public void EnsureSnapMode()
        {
            if (_map.GeometryEditor.SnapBehavior == Api.Enums.LayerSelectionMode.NoLayer)
                _map.GeometryEditor.SnapBehavior = Api.Enums.LayerSelectionMode.AllLayers;
        }
        #endregion

        #region Snap point event handling
        public void OnSnapPointRequested(SnapPointRequestedEventArgs e)
        {
            // If there are no restrictions active, don't interfere
            if (!activeRestrictions.Any())
                return;

            ICoordinate closest = null;
            double distance = double.MaxValue;
            Coordinate original = new Coordinate(e.PointX, e.PointY);
            bool nearIntersection = false;

            double tolerance = MapConfig.GetProjectedMouseTolerance(_context.Map);

            // First try to snap to an intersection (if possible)
            if (activeRestrictions.Skip(1).Any())
            {
                foreach (var snap in GetIntersections())
                {
                    if (snap == null)
                        continue;

                    double newDistance = original.Distance(snap);
                    if (newDistance > tolerance)
                        continue; // try another one, too far anyway

                    if (closest == null || newDistance < distance)
                    {
                        nearIntersection = true;
                        closest = snap;
                        distance = newDistance;
                    }
                }
            }

            // If we're too far away, just do a regular snap
            if (!nearIntersection)
            {
                foreach (var snap in GetSnapPoints(original))
                {
                    if (snap == null)
                        continue; 
                    double newDistance = original.Distance(snap);
                    if (closest == null)
                    {
                        closest = snap;
                        distance = newDistance;
                    }
                    else if (newDistance < distance)
                    {
                        closest = snap;
                        distance = newDistance;
                    }
                }
            }

            e.SnappedX = closest.X;
            e.SnappedY = closest.Y;
            e.IsFinal = true;
            e.IsFound = true;
        }

        private IEnumerable<ICoordinate> GetSnapPoints(Coordinate original) 
            => activeRestrictions.Select(r => r.GetSnapPoint(original));

        private IEnumerable<ICoordinate> GetIntersections()
            => activeRestrictions
                .DifferentCombinations(2)
                .Select(pair => pair.First().GetIntersections(pair.Last()))
                .SelectMany(t => t);

        #endregion

        #region CRUD restriction methods
        private void AddRestriction(IRestriction restriction)
        {
            activeRestrictions.Add(restriction);
            restriction.AddDrawingLayer(_map);
            EnsureSnapMode();
            ZoomoutIfRequired(restriction);
        }

        private void ZoomoutIfRequired(IRestriction restriction)
        {
            if (restriction is CircularRestriction circ)
            {
                var newExtents = _map.Extents.Clone();
                newExtents.Union(circ.GetExtents());

                if (newExtents != _map.Extents)
                    _map.ZoomToExtents(newExtents);
            }
        }

        private void RemoveRestriction(IRestriction restriction)
        {
            activeRestrictions.Add(restriction);
            restriction.RemoveDrawingLayer(_map);
        }

        public void Clear()
        {
            foreach (var restr in activeRestrictions)
                restr.RemoveDrawingLayer(_map);
            activeRestrictions.Clear();
        }

        public void CheckHandle(int newHandle)
        {
            foreach (var restr in activeRestrictions.Where(r => r.Handle != newHandle).ToList())
            {
                restr.RemoveDrawingLayer(_map);
                activeRestrictions.Remove(restr);
            }
        }

        private BearingRestriction SnapBearing(ICoordinate anchor, double bearing, double offset = 0, int handle = 0)
        {
            if (offset != 0)
                anchor = Algebra.OffsetCoordinate(anchor, -bearing, offset);

            var restriction = new BearingRestriction(anchor, bearing, handle);
            AddRestriction(restriction);
            return restriction;
        }

        public void SnapBearing(ICoordinate anchor, double offset = 0, int handle = 0)
        {
            var restriction = SnapBearing(anchor, 0, offset, handle);
            void inputAction(double value)
            {
                restriction.Bearing = value / 180.0 * Math.PI;
                restriction.RefreshGuideline(_context.Map as IMap);
            }
            // Show input box to end-user to enter the bearing
            // live updating the map with the snap line
            RequestUserInput(
               inputAction,
                "Bearing °:", 
                0.0,
                anchor
            );
        }

        public void SnapSlope(ICoordinate anchor, double slope, ICoordinate offsetAnchor = null, bool needsUserInput = true, int handle = 0)
        {
            var restriction = new LinearRestriction(anchor, slope, handle);

            double offset = 0;
            if (offsetAnchor != null)
            {
                double tolerance = MapConfig.GetProjectedMouseTolerance(_context.Map);
                offset = restriction.GetOffsetDistance(offsetAnchor, tolerance);
                restriction.OffsetByDistance(offset);
            }
            
            AddRestriction(restriction);

            if (!needsUserInput)
                return;

            void inputAction (double value) {
                restriction.OffsetByDistance(value);
                restriction.RefreshGuideline(_context.Map as IMap);
            }

            // Show input box to end-user to enter the bearing
            // live updating the map with the snap line
            RequestUserInput(
               inputAction,
                "Offset:",
                offset,
                anchor
            );

        }

        public void SnapParallel(ICoordinate anchor, ICoordinate point1, ICoordinate point2, ICoordinate offsetAnchor = null, bool needsUserInput = true, int handle = 0)
        {
            SnapSlope(anchor, Algebra.CalculateSlope(point1, point2), offsetAnchor, needsUserInput, handle);
        }

        public void SnapPerpendicular(ICoordinate anchor, ICoordinate point1, ICoordinate point2, bool needsUserInput = true, int handle = 0)
        {
            SnapSlope(anchor, Algebra.CalculateNormalSlope(point1, point2), null, needsUserInput, handle);
        }
        #endregion

        #region Distance snapping
        private CircularRestriction SnapDistance(ICoordinate anchor, double distance, int handle = 0)
        {
            var restriction = new CircularRestriction(anchor, distance, handle);
            AddRestriction(restriction);
            return restriction;
        }

        public void SnapDistance(ICoordinate anchor, int handle = 0)
        {
            var restriction = SnapDistance(anchor, 0, handle);

            // Show input box to end-user to enter the distance
            // live updating the map with the snap line
            void inputAction (double value) {
                restriction.Distance = value;
                restriction.RefreshGuideline(_context.Map as IMap);
            };

            // Show input box to end-user to enter the bearing
            // live updating the map with the snap line
            RequestUserInput(
                inputAction,
                "Distance:",
                0.0,
                anchor
            );
        }
        #endregion

        private void RequestUserInput(
            Action<double> action, 
            string label, double initialValue, ICoordinate poi = null)
        {
            var onValueEnteredAction = action;

            if (poi != null)
            {
                _drawingService.StrokeColor = _drawingService.HighlightColor;
                _drawingService.DrawPoint("anchorPoint", poi, 5, 2);

                onValueEnteredAction = new Action<double>((val) => {
                    _drawingService.Remove("anchorPoint");
                    action(val);
                });
            }

            var helper = new DoubleInputHelper(_context);
            helper.ShowInputView(label, initialValue, poi,
                onValueChanged: action,
                onValueEntered: onValueEnteredAction
            );
        }

    }
}
