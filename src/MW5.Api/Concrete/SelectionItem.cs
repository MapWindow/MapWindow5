using System;
using MapWinGIS;
using MW5.Api.Enums;

namespace MW5.Api.Concrete
{
    public class SelectionItem
    {
        private readonly SelectionList _selectionList;
        private readonly int _index;

        internal SelectionItem(SelectionList selectionList, int index)
        {
            if (selectionList == null) throw new ArgumentNullException("selectionList");
            _selectionList = selectionList;
            _index = index;

            if (_index < 0 || _index >= selectionList.Count)
            {
                throw new IndexOutOfRangeException("Invalid layer index");
            }
        }

        public SelectedLayerType LayerType
        {
            get { return (SelectedLayerType)_selectionList.LayerType[_index]; }
        }

        public int LayerHandle
        {
            get { return _selectionList.LayerHandle[_index]; }
        }

        public int ShapeIndex
        {
            get { return _selectionList.ShapeIndex[_index]; }
        }

        [Obsolete("RasterX is deprecated, please use Column instead.")]
        public int RasterX
        {
            get { return _selectionList.RasterX[_index]; }
        }

        [Obsolete("RasterY is deprecated, please use Row instead.")]
        public int RasterY
        {
            get { return _selectionList.RasterY[_index]; }
        }

        public int Row
        {
            get { return _selectionList.Row[_index]; }
        }

        public int Column
        {
            get { return _selectionList.Column[_index]; }
        }
    }
}
