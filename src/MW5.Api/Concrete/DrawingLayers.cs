using System;
using System.Drawing;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    public class DrawingLayers
    {
        private readonly AxMap _map;

        public DrawingLayers(AxMap map)
        {
            _map = map;
            if (map == null)
            {
                throw new NullReferenceException("Internal reference is null");
            }
        }

        public int AddLayer(DrawReferenceList projection)
        {
            return _map.NewDrawing((tkDrawReferenceList)projection);
        }

        public void RemoveLayer(int drawHandle)
        {
            _map.ClearDrawing(drawHandle);
        }

        public void Clear()
        {
            _map.ClearDrawings();
        }

        public int DrawLabel(string text, double x, double y, double rotation)
        {
            return _map.DrawLabel(text, x, y, rotation);
        }

        public int DrawLabel(int drawHandle, string text, double x, double y, double rotation)
        {
            return _map.DrawLabelEx(drawHandle, text, x, y, rotation);
        }

        public void DrawLine(double x1, double y1, double x2, double y2, int pixelWidth, Color color)
        {
            _map.DrawLine(x1, y1, x2, y2, pixelWidth, ColorHelper.ColorToUInt(color));
        }

        public void DrawLine(int layerHandle, double x1, double y1, double x2, double y2, int pixelWidth, Color color)
        {
            _map.DrawLineEx(layerHandle, x1, y1, x2, y2, pixelWidth, ColorHelper.ColorToUInt(color));
        }

        public void DrawPoint(double x, double y, int pixelSize, Color color)
        {
            _map.DrawPoint(x, y, pixelSize, ColorHelper.ColorToUInt(color));
        }

        public void DrawPoint(int layerHandle, double x, double y, int pixelSize, Color color)
        {
            _map.DrawPointEx(layerHandle, x, y, pixelSize, ColorHelper.ColorToUInt(color));
        }

        public void DrawCircle(double x, double y, double pixelRadius, Color color, bool fill = true, short outlineWidth = 1)
        {
            _map.DrawWideCircle(x, y, pixelRadius, ColorHelper.ColorToUInt(color), fill, outlineWidth);
        }

        public void DrawCircle(int layerHandle, double x, double y, double pixelRadius, Color color, bool fill = true,
            short outlineWidth = 1)
        {
            _map.DrawWideCircleEx(layerHandle, x, y, pixelRadius, ColorHelper.ColorToUInt(color), fill, outlineWidth);
        }

        public void DrawPolygon(double[] xPoints, double[] yPoints, int numPoints, Color color, bool fill, short width)
        {
            // TODO: test it
            object x = xPoints;
            object y = yPoints;
            _map.DrawWidePolygon(ref x, ref y, numPoints, ColorHelper.ColorToUInt(color), fill, width);
        }

        public void DrawPolygon(int layerHandle, ref object xPoints, ref object yPoints, int numPoints, Color color,
            bool fill, short width)
        {
            object x = xPoints;
            object y = yPoints;
            _map.DrawWidePolygonEx(layerHandle, ref x, ref y, numPoints, ColorHelper.ColorToUInt(color), fill, width);
        }

        public LabelsLayer GetLabels(int drawingLayerIndex)
        {
            var labels = _map.get_DrawingLabels(drawingLayerIndex);
            return labels != null ? new LabelsLayer(labels) : null;
        }

        public void SetLayerVisible(int layerHandle, bool visible)
        {
            // TODO: and where is getter in ocx?
            _map.SetDrawingLayerVisible(layerHandle, visible);
        }

        public string get_DrawingKey(int drawHandle)
        {
            return _map.get_DrawingKey(drawHandle);
        }

        public void set_DrawingKey(int drawHandle, string key)
        {
            _map.set_DrawingKey(drawHandle,key);
        }
    }
}
