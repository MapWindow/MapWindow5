using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Properties;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Services
{

    public class MapObjectMover
    {
        private const int MOUSE_TOLERANCE = 0;

        private readonly IAppContext _context;
        private readonly SymbologyPlugin _plugin;
        private readonly IMuteMap _map;
        private ObjectMoveData _currentObject;        // The object being moved currently

        public MapObjectMover(IAppContext context, SymbologyPlugin plugin)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _plugin = plugin ?? throw new ArgumentNullException("plugin");
            _map = context.Map;

            plugin.MouseDown += MapMouseDown;
            plugin.MouseUp += MapMouseUp;
            plugin.MouseMove += MapMouseMove;
        }

        /// <summary>
        /// Gets value indicating whether label mover is currently active.
        /// </summary>
        public bool Active
        {
            get { return _map.CustomCursor == LabelMoverCursor.Instance; }
        }

        /// <summary>
        /// Start the dragging operation.
        /// </summary>
        private void MapMouseDown(IMuteMap map, MouseEventArgs e)
        {
            if (!Active)
            {
                return;
            }

            var data = FindMovableItem(e.X, e.Y);

            if (data == null)
            {
                return;
            }

            _currentObject = data;

            var fs = _map.GetFeatureSet(_currentObject.LayerHandle);
            if (fs == null)
            {
                return;
            }

            IEnvelope env = null;
            if (_currentObject.IsChart)
            {
                var chart = fs.Diagrams[_currentObject.ObjectIndex];
                env = chart.ScreenExtents;
            }
            else
            {
                var label = fs.Labels.Items[_currentObject.ObjectIndex, _currentObject.PartIndex];
                env = label.ScreenExtents;
            }

            _currentObject.Rect = env.ToRectangle();

            DrawLabelRectangle(_currentObject.Rect);
        }

        private void MapMouseMove(IMuteMap map, MouseEventArgs e)
        {
            if (!Active || _currentObject.LayerHandle == -1)
            {
                return;
            }

            if (e.X != _currentObject.X || e.Y != _currentObject.Y)
            {
                int dx, dy;
                _currentObject.GetEventDelta(e, out dx, out dy);
                var r = _currentObject.Rect.CloneWithOffset(dx, dy);
                DrawLabelRectangle(r);
            }
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
                Clear();
                return;
            }

            if (!map.EventWithinMap(e))
            {
                Clear();
                return;
            }

            // Get the distance the object was moved (in projected coordinates)
            _currentObject.GetProjectedEventDelta(map, e, out double dx, out double dy);

            // Move the object
            if (_currentObject.IsChart)
                MoveChart(map, dx, dy);
            else
                MoveLabel(map, dx, dy);

            // Clear the mover
            Clear();
        }

        /// <summary>
        /// Moves the current label
        /// </summary>
        private void MoveLabel(IMuteMap map, double dx, double dy)
        {
            var layer = map.GetLayer(_currentObject.LayerHandle);
            var fs = layer.FeatureSet;
            var label = fs.Labels.Items[_currentObject.ObjectIndex, _currentObject.PartIndex];
            if (label == null)
                return;
            
            // Check if the featureset has setup offset x or y fields & store the new offset if so
            if (_currentObject is ObjectTranslateData translateData && translateData.HasBackingOffsetFields)
            {
                // We add the existing offset to the new offset & store it in the tabe of the shapefile
                dx += label.OffsetX;
                dy += label.OffsetY;
                translateData.UpdateOffsetFields(layer, dx, dy);
            }
            else // in case offsets are not backed by fields, just store the new position directly
            {
                label.X += dx;
                label.Y += dy;
                fs.Labels.SavingMode = PersistenceType.XmlOverwrite; // .lbl file should be overwritten
            }
            _context.Project.SetModified();
            map.Redraw();
        }

        /// <summary>
        /// Moves the current chart
        /// </summary>
        private void MoveChart(IMuteMap map, double dx, double dy)
        {
            var fs = map.GetFeatureSet(_currentObject.LayerHandle);
            var chart = fs.Diagrams[_currentObject.ObjectIndex];
            if (chart != null)
            {
                chart.PositionX = chart.PositionX + dx;
                chart.PositionY = chart.PositionY + dy;
                fs.Diagrams.SavingMode = PersistenceType.XmlOverwrite; // .chart file should be overwritten
                _context.Project.SetModified();
                map.Redraw();
            }
        }

        private void Clear()
        {
            _currentObject.Clear();
            _map.FocusRectangle.Visible = false;
            _map.Redraw(RedrawType.Minimal);
        }

        private ObjectMoveData FindMovableItem(int x, int y)
        {
            // Actually, collision avoidance is turned on for all layers now
            // and Labels.Select, Charts.Select return only visible objects
            // so it's not possible to have 2 candidate labels for draging
            // so we can have much easier code here, but better still to consider 
            // thу more difficult situation in case somebody will turn off collision
            // avoidance form plugin

            // 1 - vpAboveAll layers (considered first)                                                    
            // 0 - above current layer

            for (int z = 1; z >= 0; z--)        // Considering position above the layer and above all layers
            {
                int layerCount = _map.Layers.Count;

                for (int i = layerCount - 1; i >= 0; i--)    // we are starting from the layers which were drawn last
                {
                    var layer = _map.Layers[i];
                    if (layer == null || !layer.IsVector || layer.FeatureSet == null)
                        continue;

                    var fs = layer.FeatureSet;

                    var env = new Envelope();
                    env.SetBounds(x, x, y, y);

                    var position = (VerticalPosition)z;

                    // Try to find a chart
                    if (FindChart(fs, env, position) is int chartIndex)
                        return CreateObjectMoveDataForChart(x, y, layer, chartIndex);

                    // Try to find a label
                    if (FindLabel(fs, env, position) is LabelInfo info)
                        return CreateObjectMoveDataForLabel(x, y, layer, fs, info);
                }
            }

            return null;
        }

        private ObjectMoveData CreateObjectMoveDataForChart(int x, int y, ILayer layer, int chartIndex)
        {
            var data = new ChartMoveData() { X = x, Y = y };
            data.LayerHandle = layer.Handle;
            data.ObjectIndex = chartIndex;
            return data;
        }

        private ObjectMoveData CreateObjectMoveDataForLabel(int x, int y, ILayer layer, IFeatureSet fs, LabelInfo info)
        {
            var data = new LabelMoveData() { X = x, Y = y };
            data.LayerHandle = layer.Handle;
            data.ObjectIndex = info.LabelIndex;
            data.PartIndex = info.PartIndex;

            var label = fs.Labels.Items[data.ObjectIndex, data.PartIndex];
            ILabelStyle labelStyle = fs.Labels.GetStyle(label);
            if (fs.Labels.Synchronized && (labelStyle.OffsetXField != -1 || labelStyle.OffsetYField != -1))
            {
                data.HasBackingOffsetFields = true;
                data.OffsetXField = labelStyle.OffsetXField;
                data.OffsetYField = labelStyle.OffsetYField;
            }

            return data;
        }

        private LabelInfo FindLabel(IFeatureSet fs, IEnvelope envelope, VerticalPosition position)
        {
            if (fs.Labels.VerticalPosition != position)
            {
                return null;
            }

            var lb = fs.Labels;
            var labelList = lb.Select(envelope).ToList();
            if (labelList.Any())
            {
                var info = labelList[labelList.Count - 1];
                return info;
            }

            return null;
        }

        private int? FindChart(IFeatureSet fs, IEnvelope envelope, VerticalPosition position)
        {
            // analyzing charts: they are drawn on the top of the labels
            if (position == fs.Diagrams.VerticalPosition)
            {
                int[] indices = fs.Diagrams.Select(envelope, MOUSE_TOLERANCE, MapSelectionMode.Intersection);
                if (indices != null && indices.Length > 0)
                {
                    // in case severral charts are selected we have to choose the one with the largest id
                    // as it will be drawn on the top of others
                    int index = indices[indices.Length - 1];
                    return index;
                }
            }
            return null;
        }

        /// <summary>
        /// Draws rectangle around chosen label
        /// </summary>
        private void DrawLabelRectangle(Rectangle rect)
        {
            var r = _context.Map.FocusRectangle; 
            r.Visible = true;
            r.X = rect.X;
            r.Y = rect.Y;
            r.Width = rect.Width;
            r.Height = rect.Height;
            r.FillTransparency = 150;
            _context.Map.Redraw(RedrawType.Minimal);
        }
    }
}
