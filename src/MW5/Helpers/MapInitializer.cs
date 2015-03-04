using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Api.Interfaces;

namespace MW5.Helpers
{
    public static class MapInitializer
    {
        public static void Initialize(this IMap map)
        {
            map.GrabProjectionFromData = true;
            map.MapCursor = MapCursor.ZoomIn;
            map.InertiaOnPanning = AutoToggle.Auto;
            map.ShowRedrawTime = false;
            map.Identifier.IdentifierMode = IdentifierMode.SingleLayer;
            map.Identifier.HotTracking = true;
            map.GeometryEditor.HighlightVertices = LayerSelection.NoLayer;
            map.GeometryEditor.SnapBehavior = LayerSelection.NoLayer;
        }
    }
}
