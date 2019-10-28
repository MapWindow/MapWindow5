using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Services
{
    /// <summary>
    /// Holds information about the currently selected label (probably beter move to another file)
    /// </summary>
    internal class ObjectMoveData
    {
        internal int LayerHandle;
        internal int ObjectIndex;
        internal int PartIndex;
        internal int X;   // in screen coordinates
        internal int Y;   // in screen coordinates
        internal Rectangle Rect;
        internal bool IsChart;  // label or chart

        internal bool HasBackingOffsetFields;
        internal int OffsetXField;
        internal int OffsetYField;

        internal void Clear()
        {
            LayerHandle = -1;
            ObjectIndex = -1;
            PartIndex = -1;
            OffsetXField = -1;
            OffsetYField = -1;
            X = 0;
            Y = 0;
        }

        internal ObjectMoveData()
        {
            Clear();
        }
    }
}
