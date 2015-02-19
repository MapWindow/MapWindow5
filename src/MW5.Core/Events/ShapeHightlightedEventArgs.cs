using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MapWinGIS;

namespace MW5.Core.Events
{
    public class ShapeHightlightedEventArgs: EventArgs
    {
        private readonly _DMapEvents_ShapeHighlightedEvent _args;

        internal ShapeHightlightedEventArgs(_DMapEvents_ShapeHighlightedEvent args)
        {
            _args = args;
            if (args == null)
            {
                throw new NullReferenceException("Internal reference is null.");
            }
        }

        public int LayerHandle
        {
            get { return _args.layerHandle; }
        }

        public int ShapeIndex
        {
            get { return _args.shapeIndex; }
        }
    }
}
