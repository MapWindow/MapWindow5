using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Services.Serialization.Legacy;
using MW5.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Services
{
    /// <summary>
    /// Holds information about the currently selected label
    /// </summary>
    public abstract class ObjectMoveData
    {
        public int LayerHandle;
        public int ObjectIndex;
        public int PartIndex;
        public Rectangle Rect;

        public virtual bool IsChart { get; }
        public virtual bool IsLabel { get; }
        public virtual bool IsSymbol { get; }

        public virtual double X { get; set; }   // original location
        public virtual double Y { get; set; }  // original location

        public virtual void Clear()
        {
            LayerHandle = -1;
            ObjectIndex = -1;
            PartIndex = -1;
            X = 0;
            Y = 0;
        }

        public ObjectMoveData()
        {
            Clear();
        }
        public void GetEventDelta(MouseEventArgs e, out double dx, out double dy)
        {
            dx = -X + e.X;
            dy = -Y + e.Y;
        }

        public void GetProjectedEventDelta(IMuteMap map, MouseEventArgs e, out double dx, out double dy)
        {
            map.PixelToProj(X, Y, out double x1, out double y1);
            map.PixelToProj(e.X, e.Y, out double x2, out double y2);

            dx = -x1 + x2;
            dy = -y1 + y2;
        }
    }
    public abstract class ObjectTranslateData : ObjectMoveData
    {
        public bool HasBackingOffsetFields;
        public int OffsetXField;
        public int OffsetYField;

        public override void Clear()
        {
            base.Clear();
            OffsetXField = -1;
            OffsetYField = -1;
            HasBackingOffsetFields = false;
        }

        public void UpdateOffsetFields(ILayer layer, double dx, double dy)
        {
            var fs = layer.FeatureSet;
            var feature = fs.Features[ObjectIndex];
            bool needToCloseTable = !fs.EditingTable;
            if (needToCloseTable) fs.StartEditingTable();
            if (OffsetXField != -1)
                feature.SetDouble(OffsetXField, dx);
            if (OffsetYField != -1)
                feature.SetDouble(OffsetYField, dy);
            layer.VectorSource?.SaveChanges(out int count, SaveType.AttributesOnly, false);
            if (needToCloseTable) fs.StopEditingTable();
        }
    }

    public abstract class ObjectRotateData : ObjectMoveData
    {

        public bool HasBackingRotationField;
        public int RotationField;

        public double OriginalRotation;

        public IEnumerable<double> SegmentAngles { get; protected set; }
        public IEnumerable<double> CartesianAngles { get; } =
            new double[] { 0, 45, 90, 135, 180, 225, 270, 315 };


        public override void Clear()
        {
            base.Clear();
            RotationField = -1;
            OriginalRotation = 0;
            HasBackingRotationField = false;
        }

        public double GetAngle(double newX, double newY, bool azimuth = false)
        {
            var angle = Math.Atan2(newY - Y, newX - X);
            if (azimuth)
                angle = (Math.PI * 0.5) - angle;
            return NormalizeAngle(angle);
        }

        public double GetAngleInDegrees(double newX, double newY, bool geographicAngles = false)
        {
            return GetAngle(newX, newY, geographicAngles) * (180 / Math.PI);
        }

        protected double NormalizeAngle(double angle, double minAngle = 0, double maxAngle = Math.PI*2)
        {
            while (angle >= maxAngle) angle -= maxAngle;
            while (angle < minAngle) angle += maxAngle;
            return angle;
        }

        public abstract void UpdateRotationField(
            ILayer layer, double dx, double dy,
            bool snapToFeatures = false, bool snapToAxes = false);

        public abstract void SaveRotationField(ILayer layer);
    }

    public class ChartMoveData : ObjectTranslateData
    {
        override public bool IsChart => true;
    }

    public class EmptyMoveData : ObjectTranslateData
    {
    }

    public class LabelMoveData : ObjectTranslateData
    {
        override public bool IsLabel => true;
    }

    public class SymbolRotateData : ObjectRotateData
    {
        override public bool IsSymbol => true;

        private readonly ICoordinate originalPoint;

        protected IMuteMap Map { get; }

        public SymbolRotateData(IMuteMap map, int layerHandle, int objectIndex, double x, double y)
        {
            Map = map;
            LayerHandle = layerHandle;
            ObjectIndex = objectIndex;
            X = x;
            Y = y;

            CalculateSnapAngles();
        }

        private void CalculateSnapAngles()
        {
            if (LayerHandle < 0 || ObjectIndex < 0)
            {
                SegmentAngles = Enumerable.Empty<double>();
                return;
            }

            var fs = Map.GetLayer(LayerHandle).FeatureSet;
            var feature = fs.Features[ObjectIndex];
            var geometry = feature.Geometry;

            var tolerance = Map.GetProjectedMouseTolerance();
            var center = geometry.Center;
            var snapCandidates = Map.GetSnapCandidateGeometriesFromLayers(center, tolerance);
            var angles = new List<double>();
            foreach (var snapCandidate in snapCandidates
                .Where(g => g.GeometryType == GeometryType.Polygon || g.GeometryType == GeometryType.Polyline))
            {
                if (snapCandidate.Distance(snapCandidate) > float.Epsilon)
                    continue;
                var segments = snapCandidate.Points
                    .Pairwise((p1, p2) => new Tuple<ICoordinate, ICoordinate>(p1, p2))
                    .Where(pair => IsBetween(pair.Item1, pair.Item2, center, tolerance));
                foreach (var segment in segments)
                {
                    var angle = (Math.PI * 0.5) - Math.Atan2(segment.Item2.Y - segment.Item1.Y, segment.Item2.X - segment.Item1.X);
                    angle = NormalizeAngle(angle) * (180 / Math.PI);
                    angles.Add(angle);
                    angles.Add(NormalizeAngle(angle + 90, 0, 360));
                    angles.Add(NormalizeAngle(angle + 180, 0, 360));
                    angles.Add(NormalizeAngle(angle + 270, 0, 360));
                }
            }

            SegmentAngles = angles.Distinct().ToList();
        }

        public bool IsBetween(ICoordinate segment1, ICoordinate segment2, ICoordinate point, double tolerance)
        {
            var crossproduct = 
                (point.Y - segment1.Y) * (segment2.X - segment1.X) - 
                (point.X - segment1.X) * (segment2.Y - segment1.Y);

            if (Math.Abs(crossproduct) > tolerance)
                return false;

            var dotproduct = 
                (point.X - segment1.X) * (segment2.X - segment1.X) + 
                (point.Y - segment1.Y) * (segment2.Y - segment1.Y);
            if (dotproduct < -tolerance)
                return false;

            var squaredlengthba = 
                (segment2.X - segment1.X) * (segment2.X - segment1.X) +
                (segment2.Y - segment1.Y) * (segment2.Y - segment1.Y);
            if (dotproduct > squaredlengthba + tolerance)
                return false;

            return true;
        }

        public double GetSnappedAngleInDegress(
            ILayer layer, double newX, double newY,
            bool snapToFeatures = false, bool snapToAxes = false)
        {
            var angle = GetAngleInDegrees(newX, newY, true);

            if (!snapToFeatures && !snapToAxes)
                return angle;

            var snapAngles = Enumerable.Empty<double>();
            if (snapToFeatures)
                snapAngles = snapAngles.Concat(SegmentAngles);
            if (snapToAxes)
                snapAngles = snapAngles.Concat(CartesianAngles);

            if (!snapAngles.Any())
                return angle;

            var minDelta = 17.5;
            var snappedAngle = angle;
            foreach (var snapAngle in snapAngles)
            {
                var delta = Math.Abs(snapAngle - angle);
                if (180 < delta)
                    delta = 360 - delta;

                if (delta < minDelta)
                {
                    minDelta = delta;
                    snappedAngle = snapAngle;
                }
            }

            return snappedAngle;
        }

        public override void UpdateRotationField(
            ILayer layer, double dx, double dy, 
            bool snapToFeatures = false, bool snapToAxes = false)
        {
            var angle = GetSnappedAngleInDegress(layer, dx, dy, snapToFeatures, snapToAxes);

            var fs = layer.FeatureSet;
            var feature = fs.Features[ObjectIndex];
            feature.Rotation = angle;

            if (RotationField != -1)
            {
                if (!fs.EditingTable) fs.StartEditingTable();
                feature.SetDouble(RotationField, angle);
            }
                
        }

        public override void SaveRotationField(ILayer layer)
        {
            if (HasBackingRotationField)
                layer.VectorSource?.SaveChanges(out int _, SaveType.AttributesOnly, false);            
        }
    }
}
