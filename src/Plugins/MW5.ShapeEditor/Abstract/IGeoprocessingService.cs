using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.ShapeEditor.Abstract
{
    public interface IGeoprocessingService
    {
        /// <summary>
        /// Merges selected shapes
        /// </summary>
        void MergeShapes();

        /// <summary>
        /// Splits selected multipart shapes
        /// </summary>
        void ExplodeShapes();

        /// <summary>
        /// Removes selected shapes
        /// </summary>
        void RemoveShapes();

        bool BufferIsEmpty { get; }
        void CopyShapes();
        void PasteShapes();
        void CutShapes();
    }

}
