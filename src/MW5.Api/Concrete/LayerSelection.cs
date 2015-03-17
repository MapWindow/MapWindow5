using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace MW5.Api.Concrete
{
    public class LayerSelection
    {
        private readonly SelectionList _selectionList;
        private int _index;

        internal LayerSelection(SelectionList selectionList, int index)
        {
            if (selectionList == null) throw new ArgumentNullException("selectionList");
            _selectionList = selectionList;
            _index = index;

            if (_index < 0 || _index >= selectionList.NumLayers)
            {
                throw new IndexOutOfRangeException("Invalid layer index");
            }
        }

        public int LayerHandle
        {
            get { return _selectionList.LayerHandle[_index]; }
        }

        public List<int> ShapeIndices
        {
            get
            {
                object o = null;
                _selectionList.get_ShapeIndices(_index, ref o);
                var indices = o as int[];
                if (indices != null && indices.Length > 0)
                {
                    return indices.ToList();
                }
                return new List<int>();
            }
        }
    }
}
