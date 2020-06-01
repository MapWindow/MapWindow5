using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
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
    class SymbolRotater
    {
        private readonly IAppContext _context;
        private readonly SymbologyPlugin _plugin;
        private readonly IMuteMap _map;
        private ObjectRotateData _currentObject;

        public SymbolRotater(IAppContext context, SymbologyPlugin plugin)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _plugin = plugin ?? throw new ArgumentNullException("plugin");
            _map = context.Map;

            _currentObject = new SymbolRotateData(_map, -1, -1);

            plugin.MouseDown += MapMouseDown;
            plugin.MouseUp += MapMouseUp;
            plugin.MouseMove += MapMouseMove;
        }

        /// <summary>
        /// Gets value indicating whether label mover is currently active.
        /// </summary>
        public bool Active
        {
            get { return _map.CustomCursor == SymbolRotaterCursor.Instance; }
        }

        /// <summary>
        /// Start the dragging operation.
        /// </summary>
        private void MapMouseDown(IMuteMap map, MouseEventArgs e)
        {
            if (!Active)
                return;

            var data = FindRotatebleItem(e.X, e.Y);
            if (data == null)
                return;

            _currentObject = data;
        }

        private void MapMouseMove(IMuteMap map, MouseEventArgs e)
        {
            if (!Active || _currentObject.LayerHandle == -1)
                return;

            if (e.X == _currentObject.X && e.Y == _currentObject.Y)
                return;

            var ctrlDown = Control.ModifierKeys.HasFlag(Keys.Control);
            var shiftDown = Control.ModifierKeys.HasFlag(Keys.Shift);

            // Move the object
            RotateSymbol(map, e.X, e.Y, shiftDown, ctrlDown);

        }

        /// <summary>
        /// Finishes the moving operation.
        /// </summary>
        private void MapMouseUp(IMuteMap map, MouseEventArgs e)
        {
            if (!Active || _currentObject.LayerHandle == -1)
            {
                return;
            }

            if (e.X == _currentObject.X || e.Y == _currentObject.Y)
            {
                ResetRotation();
                Clear();
                return;
            }

            if (!map.EventWithinMap(e))
            {
                ResetRotation();
                Clear();
                return;
            }

            var ctrlDown = Control.ModifierKeys.HasFlag(Keys.Control);
            var shiftDown = Control.ModifierKeys.HasFlag(Keys.Shift);

            RotateSymbol(map, e.X, e.Y, shiftDown, ctrlDown);
            Clear();
        }

        private void ResetRotation()
        {
            if (_currentObject == null)
                return;

            var layer = _context.Map.GetLayer(_currentObject.LayerHandle);
            var fs = layer.FeatureSet;
            var feature = fs.Features[_currentObject.ObjectIndex];
            if (feature == null)
                return;

            feature.Rotation = _currentObject.OriginalRotation;
        }

        /// <summary>
        /// Rotates the current symbol
        /// </summary>
        private void RotateSymbol(IMuteMap map, double dx, double dy,
            bool snapToFeatures = false, bool snapToAxes = false)
        {
            var layer = map.GetLayer(_currentObject.LayerHandle);
            var fs = layer.FeatureSet;
            var feature = fs.Features[_currentObject.ObjectIndex];
            if (feature == null)
                return;     
            
            // Check if the featureset has setup offset x or y fields & store the new offset if so
            if (_currentObject.HasBackingRotationField)
                _currentObject.UpdateRotationField(layer, dx, dy, snapToFeatures, snapToAxes);
            map.Redraw();
        }

        private void Clear()
        {
            _currentObject.Clear();
            _map.FocusRectangle.Visible = false;
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
                    return CreateObjectRotateDataForPoint(x, y, _map, layer, featureIndex);
            }

            return null;
        }

        private ObjectRotateData CreateObjectRotateDataForPoint(int x, int y, IMuteMap map, ILayer layer, int featureIndex)
        {
            IFeature feature = layer.FeatureSet.Features[featureIndex];
            if (feature == null)
            {
                Clear();
                return _currentObject;
            }

            var data = new SymbolRotateData(map, layer.Handle, featureIndex) {
                X = x, 
                Y = y,
                OriginalRotation = feature.Rotation
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
            else
            {
                MessageBox.Show("This feature does not have a single field rotation expression - can not rotate symbol.");
                Clear();
                return _currentObject;
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
}
