using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MW5.Plugins.AdvancedSnapping.Services
{

    public class AnchorService : IAnchorService
    {
        private const string drawingContextName = "anchorService";
        private IAppContext _context;
        private readonly IDrawingService _drawingService;
        private int highlightLayerHandle;
        private readonly Dispatcher dispatcher;
        private IList<CancellationTokenSource> taskTokens;

        #region Properties

        /// <summary>
        /// The anchor segment
        /// </summary>
        public Tuple<ICoordinate, ICoordinate> ReferenceSegment { get; private set; }

        private ICoordinate _userAnchorLocation;
        /// <summary>
        /// The location the mouse was at when the anchor segment was determined
        /// </summary>
        public ICoordinate UserAnchorLocation
        {
            get => _userAnchorLocation;
            set
            {
                _userAnchorLocation = value;
                UpdateReferenceSegment();
                UpdateHighlight();
            }
        }

        private ICoordinate _lastUserLocation;
        /// <summary>
        /// The location the mouse was last at
        /// </summary>
        public ICoordinate LastUserLocation
        {
            get => _lastUserLocation;
            set
            {
                // if the new location is not near the previous
                if (value != null && (ReferenceSegment == null || UserAnchorLocation == null || UserAnchorLocation.Distance(value) > MapTolerance))
                {
                    // Queue update - this will also cancel the previous update if fast enough
                    QueueAnchorUpdate(value, dispatcher);
                }
                _lastUserLocation = value;
            }
        }

        /// <summary>
        /// Map tolerance
        /// </summary>
        public double MapTolerance => MapConfig.GetProjectedMouseTolerance(_context.Map);

        /// <summary>
        /// The anchor to use for a new restriction
        /// </summary>
        public ICoordinate PrimaryAnchor
        {
            get
            {
                ICoordinate anchor = null;

                var editor = _context.Map.GeometryEditor;
                if (!editor.IsEmpty && editor.IsDigitizing)
                    // If we're digitizing, use the last digitized point
                    anchor = editor.GetPoint(editor.NumPoints - 1);
                else
                    // If not, use the last clicked point on the map
                    anchor = UserAnchorLocation;

                return anchor;
            }
        }

        public int HighlightDelay { get; set; } = 100;
        #endregion

        public AnchorService(IAppContext context, IDrawingService drawingService)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _drawingService = drawingService ?? throw new ArgumentNullException("drawingService");
            dispatcher = Dispatcher.CurrentDispatcher;
            taskTokens = new List<CancellationTokenSource>();
        }

        #region Highlight drawing
        public void UpdateHighlight()
        {
            _drawingService.Remove(drawingContextName);
            if (ReferenceSegment == null)
                return;
            _drawingService.StrokeColor = _drawingService.HighlightColor;
            _drawingService.DrawLine(drawingContextName, ReferenceSegment.Item1, ReferenceSegment.Item2, 3);
        }
        #endregion

        private void QueueAnchorUpdate(ICoordinate location, Dispatcher dispatcher)
        {
            // Cancel all other tasks started
            foreach (var taskToken in taskTokens)
                taskToken.Cancel();

            // Create & queue a new token
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            taskTokens.Add(tokenSource);

            // Create & start cancellable delayed task
            new Task(async () =>
            {
                await Task.Delay(HighlightDelay);
                if (tokenSource.Token.IsCancellationRequested)
                    return;
                dispatcher.BeginInvoke(() =>
                {
                    UserAnchorLocation = location;
                });
            }).Start();

            // Clean up tokens
            taskTokens = taskTokens.Where(t => !t.IsCancellationRequested).ToList();
        }

        public IEnumerable<IFeature> FindFeatures(ICoordinate location)
        {
            var tolerance = MapTolerance;
            var box = new Envelope(location.X, location.X, location.Y, location.Y);

            foreach (var layer in _context.Map.Layers)
            {
                if (!layer.IsVector || !layer.Visible)
                    continue;
                foreach (var feature in layer.FeatureSet.SelectShapes(box, tolerance, MapSelectionMode.Intersection))
                    if (feature.IsVisible && feature.IsRendered)
                        yield return feature;
            }
        }

        public void UpdateReferenceSegment()
        {
            var location = UserAnchorLocation;
            if (location == null)
            {
                ReferenceSegment = null;
                return;
            }

            // We specifically need a polyline or polygon:
            var features = FindFeatures(location).Where(f => 
                f.Geometry.GeometryType == GeometryType.Polygon || 
                f.Geometry.GeometryType == GeometryType.Polyline
            ).ToList();

            // Get last feature or leave if none found
            if (!features.Any())
            {
                ReferenceSegment = null;
                return;
            }

            // Get closest segment
            ReferenceSegment = features.GetClosestSegment(location, MapTolerance);
        }

    }

    internal static class FeatureExtensions
    {
        internal static Tuple<ICoordinate, ICoordinate> GetClosestSegment(this IEnumerable<IFeature> features, ICoordinate location, double tolerance = double.MaxValue)
        {
            double minDist = tolerance;
            Tuple<ICoordinate, ICoordinate> result = null;

            // Loop over each segment in each feature
            foreach (var segment in features.SelectMany(f => f.Geometry.Points.Zip(f.Geometry.Points.Skip(1), Tuple.Create)))
            {
                var d = Distance(segment.Item1, segment.Item2, location);
                if (d >= minDist)
                    continue;

                minDist = d;
                result = segment;
            }

            return result;
        }

        internal static double Distance(ICoordinate v, ICoordinate w, ICoordinate p)
        {
            // Translated from https://stackoverflow.com/questions/849211/shortest-distance-between-a-point-and-a-line-segment

            // Return minimum distance between line segment vw and point p            
            var length = v.Distance(w);  // i.e. |w-v|^2 -  avoid a sqrt
            if (length == 0.0)
                return p.Distance(v);   // v == w case

            // Consider the line extending the segment, parameterized as v + t (w - v).
            // We find projection of point p onto the line. 
            // It falls where t = [(p-v) . (w-v)] / |w-v|^2
            // We clamp t from [0,1] to handle points outside the segment vw.
            var dot = (p.X - v.X) * (w.X - v.X) + (p.Y - v.Y) * (w.Y - v.Y);
            var t = Math.Max(0, Math.Min(1, dot / (length*length)));

            // Projection falls on the segment
            ICoordinate projection = new Coordinate(v.X + t * (w.X - v.X), v.Y + t * (w.Y - v.Y));
            return p.Distance(projection);
        }
    }
}
