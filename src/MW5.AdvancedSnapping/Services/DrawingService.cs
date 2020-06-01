using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.AdvancedSnapping.Services
{
    public class DrawingService : IDrawingService
    {
        private readonly IAppContext _context;
        private readonly IMap _map;

        public Color FillColor { get; set; } = Color.Black;
        public Color StrokeColor { get; set; } = Color.Black;
        public Color HighlightColor { get; set; } = Color.FromArgb(128, Color.DarkOrange);

        private IDictionary<string, int> contextLayers;

        public DrawingService(IAppContext context)
        {
            _context = context ?? throw new ArgumentNullException("context");

            _map = _context.Map as IMap;
            contextLayers = new Dictionary<string, int>();
        }

        private int EnsureContextLayer(string context)
        {
            if (!contextLayers.TryGetValue(context, out int handle))
            {
                contextLayers[context] = handle = _map.Drawing.AddLayer(Api.Enums.DrawReferenceList.SpatiallyReferencedList);
            }

            return handle;
        }

        public void DrawPoint(string context, ICoordinate poi, int size, short strokeWidth)
        {
            int handle = EnsureContextLayer(context);

            _map.Drawing.DrawPoint(handle, poi.X, poi.Y, size, StrokeColor);
        }

        public void DrawCircle(string context, ICoordinate poi, double radius, short strokeWidth, bool fill = false)
        {

            int handle = EnsureContextLayer(context);

            _map.Drawing.DrawCircle(handle, poi.X, poi.Y, radius, StrokeColor, false, strokeWidth);
            if (fill)
                _map.Drawing.DrawCircle(handle, poi.X, poi.Y, radius, FillColor, true, strokeWidth);
        }

        public void DrawLine(string context, ICoordinate from, ICoordinate to, short strokeWidth)
        {
            int handle = EnsureContextLayer(context);

            _map.Drawing.DrawLine(handle, from.X, from.Y, to.X, to.Y, strokeWidth, StrokeColor);
        }

        public void Remove(string context)
        {
            if (!contextLayers.ContainsKey(context))
                return;
            _map.Drawing.RemoveLayer(contextLayers[context]);
            contextLayers.Remove(context);
        }
    }
}
