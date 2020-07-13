using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Services
{
    public class SymbolRotater
    {
        private readonly IAppContext _context;
        private readonly IMuteMap _map;

        public SnapAngleDrawer SnapAngleDrawer { get; }

        public ObjectRotateData CurrentObject { get; set; }

        public SymbolRotater(IAppContext context, SymbologyPlugin plugin)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _map = context.Map;

            SnapAngleDrawer = new SnapAngleDrawer(_map, _context.Config);

            CurrentObject = new SymbolRotateData(_map, -1, -1, 0, 0);

            plugin.MouseDown += MapMouseDown;
            plugin.MouseUp += MapMouseUp;
            plugin.MouseMove += MapMouseMove;
            plugin.ExtentsChanged += MapExtentsChanged;
        }

        public bool Active
        {
            get { return _map.CustomCursor == SymbolRotaterCursor.Instance; }
        }

        private void MapMouseDown(IMuteMap map, MouseEventArgs e)
        {
            if (Active && CurrentObject.LayerHandle == -1)
            {
                var data = FindRotatebleItem(e.X, e.Y);
                if (data == null)
                    return;

                CurrentObject = data;
            }

            var ctrlDown = Control.ModifierKeys.HasFlag(Keys.Control);
            var shiftDown = Control.ModifierKeys.HasFlag(Keys.Shift);
            SnapAngleDrawer.DrawSnapAngles(CurrentObject, shiftDown, ctrlDown);
        }

        private void MapMouseUp(IMuteMap map, MouseEventArgs e)
        {
            var ctrlDown = Control.ModifierKeys.HasFlag(Keys.Control);
            var shiftDown = Control.ModifierKeys.HasFlag(Keys.Shift);

            if (!Active || CurrentObject.LayerHandle == -1)
                return;

            if (!map.EventWithinMap(e))
            {
                ResetRotation();
                Clear();
                return;
            }

            RotateSymbol(map, e.X, e.Y, shiftDown, ctrlDown);
            SaveRotation(map);
            Clear();
        }

        private void MapMouseMove(IMuteMap map, MouseEventArgs e)
        {
            var ctrlDown = Control.ModifierKeys.HasFlag(Keys.Control);
            var shiftDown = Control.ModifierKeys.HasFlag(Keys.Shift);
            SnapAngleDrawer.DrawSnapAngles(CurrentObject, shiftDown, ctrlDown);

            if (!Active || CurrentObject.LayerHandle == -1)
                return;

            RotateSymbol(map, e.X, e.Y, shiftDown, ctrlDown);
        }

        private void MapExtentsChanged(IMuteMap map, EventArgs e)
        {
            var ctrlDown = Control.ModifierKeys.HasFlag(Keys.Control);
            var shiftDown = Control.ModifierKeys.HasFlag(Keys.Shift);

            SnapAngleDrawer.DrawSnapAngles(CurrentObject, shiftDown, ctrlDown, true);
        }

        private void ResetRotation()
        {
            if (CurrentObject == null)
                return;

            var layer = _context.Map.GetLayer(CurrentObject.LayerHandle);
            var fs = layer.FeatureSet;
            var feature = fs.Features[CurrentObject.ObjectIndex];
            if (feature == null)
                return;

            feature.Rotation = CurrentObject.OriginalRotation;
        }

        private void RotateSymbol(IMuteMap map, double dx, double dy,
            bool snapToFeatures = false, bool snapToAxes = false)
        {
            var layer = map.GetLayer(CurrentObject.LayerHandle);
            var fs = layer.FeatureSet;
            var feature = fs.Features[CurrentObject.ObjectIndex];
            if (feature == null)
                return;     
            
            var projCoordinate = _context.Map.PixelToProj(new Coordinate(dx, dy));
            CurrentObject.UpdateRotationField(layer, projCoordinate.X, projCoordinate.Y, snapToFeatures, snapToAxes);

            map.Redraw();
        }

        private void SaveRotation(IMuteMap map)
        {
            var layer = map.GetLayer(CurrentObject.LayerHandle);
            var fs = layer.FeatureSet;
            var feature = fs.Features[CurrentObject.ObjectIndex];
            if (feature == null)
                return;

            CurrentObject.SaveRotationField(layer);
        }

        private void Clear()
        {
            CurrentObject.Clear();
            SnapAngleDrawer.DrawSnapAngles(null, false, false, true);
            _map.Redraw(RedrawType.Minimal);
        }

        private ObjectRotateData FindRotatebleItem(int x, int y)
        {
            foreach (var layer in _map.Layers.ToList())
            {
                if (layer == null || !layer.IsVector || layer.FeatureSet == null)
                    continue;
                if (layer.FeatureSet.GeometryType != GeometryType.Point)
                    continue;

                var fs = layer.FeatureSet;

                var env = new Envelope();
                _map.PixelToProj(x, y, out double projX, out double projY);
                env.SetBounds(new Coordinate(projX, projY), (_map as IMuteMap).GetProjectedMouseTolerance(), (_map as IMuteMap).GetProjectedMouseTolerance());

                // Try to find a point feature
                if (FindPointFeature(fs, env) is int featureIndex)
                    return CreateObjectRotateDataForPoint(_map, layer, featureIndex);
            }

            return null;
        }

        private ObjectRotateData CreateObjectRotateDataForPoint(IMuteMap map, ILayer layer, int featureIndex)
        {
            IFeature feature = layer.FeatureSet.Features[featureIndex];
            if (feature == null)
            {
                Clear();
                return CurrentObject;
            }

            var point = feature.Geometry.Points.First();
            var data = new SymbolRotateData(map, layer.Handle, featureIndex, point.X, point.Y) {
                OriginalRotation = feature.Rotation,
            };

            string rotationExpression = layer.FeatureSet?.Style?.Marker?.RotationExpression ?? "";
            if (feature.CategoryIndex > 0)
                rotationExpression = feature.Category?.Style?.Marker?.RotationExpression ?? "";
            var rotationFieldIndex = GetRotationFieldIndex(rotationExpression, layer);
            if (rotationFieldIndex > 0)
            {
                data.HasBackingRotationField = true;
                data.RotationField = rotationFieldIndex;
                data.OriginalRotation = feature.GetAsDouble(rotationFieldIndex);
            }

            return data;
        }

        private int GetRotationFieldIndex(string expression, ILayer layer)
        {
            var result = Regex.Match(expression, @"^\s*\[(\w+)\]\s*$");
            if (result.Success)
            {
                var fieldName = result.Groups[1].Value;
                return layer.FeatureSet.Fields.IndexByName(fieldName);
            }
            return -1;
        }

        private int? FindPointFeature(IFeatureSet fs, IEnvelope envelope)
        {
            var results = new int[] { };
            if (fs.GetRelatedShapes(envelope.ToGeometry(), SpatialRelation.Intersects, ref results))
                return results[results.Length - 1];
            return null;
        }
    }

    public class SnapAngleDrawer
    {

        const double toRadiansFactor = Math.PI / 180.0;

        private int layerHandle = -1;
        private bool lastSnapShiftDown;
        private bool lastSnapCtrlDown;

        public IMuteMap Map { get; }
        public AppConfig Config { get; }


        public SnapAngleDrawer(IMuteMap _map, Concrete.AppConfig config)
        {
            Map = _map;
            Config = config;
        }

        public void DrawSnapAngles(ObjectRotateData currentObject, bool shiftDown, bool ctrlDown, bool force = false)
        {
            if ((!shiftDown && !ctrlDown) || currentObject.LayerHandle == -1)
            {
                ClearSnapAngleDrawings();
                return;
            }

            if (!force && lastSnapShiftDown == shiftDown && lastSnapCtrlDown == ctrlDown)
                return;

            if (shiftDown || ctrlDown)
                ForceDrawSnapAngles(currentObject, shiftDown, ctrlDown);
        }

        private void ForceDrawSnapAngles(ObjectRotateData currentObject, bool shiftDown, bool ctrlDown)
        {
            ClearSnapAngleDrawings();

            lastSnapShiftDown = shiftDown;
            lastSnapCtrlDown = ctrlDown;

            if (ctrlDown)
                foreach (var angle in currentObject.CartesianAngles)
                    DrawSnapAngle(currentObject, angle);

            if (shiftDown)
                foreach (var angle in currentObject.SegmentAngles)
                    DrawSnapAngle(currentObject, angle);
        }

        private void DrawSnapAngle(ObjectRotateData currentObject, double angle)
        {
            double radAngle = angle * toRadiansFactor;

            Map.ProjToPixel(currentObject.X, currentObject.Y, out double x, out double y);

            x += Math.Cos(radAngle) * 25;
            y += Math.Sin(radAngle) * 25;

            double x2 = x + Math.Cos(radAngle) * 35;
            double y2 = y + Math.Sin(radAngle) * 35;
            Map.Drawing.DrawLine(layerHandle, x, y, x2, y2, 2, Config.MeasuringLineColor);
            Map.Drawing.DrawLine(layerHandle, x, y, x2, y2, 2, Config.MeasuringLineColor);
        }

        private void ClearSnapAngleDrawings()
        {
            lastSnapShiftDown = false;
            lastSnapCtrlDown = false;

            if (layerHandle >= 0)
                Map.Drawing.RemoveLayer(layerHandle);
            layerHandle = Map.Drawing.AddLayer(DrawReferenceList.ScreenReferencedList);
        }
    }
}
