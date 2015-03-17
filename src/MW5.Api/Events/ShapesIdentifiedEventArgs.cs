using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxMapWinGIS;
using MW5.Api.Concrete;

namespace MW5.Api.Events
{
    public class ShapesIdentifiedEventArgs: EventArgs
    {
        private readonly _DMapEvents_ShapesIdentifiedEvent _args;

        public ShapesIdentifiedEventArgs(_DMapEvents_ShapesIdentifiedEvent args)
        {
            if (args == null) throw new ArgumentNullException("args");
            _args = args;
        }

        public LayerSelectionList SelectionList
        {
            get { return new LayerSelectionList(_args.selectedShapes); }
        }
    }
}
