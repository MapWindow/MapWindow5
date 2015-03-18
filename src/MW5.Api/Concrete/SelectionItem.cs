using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace MW5.Api.Concrete
{
    public class SelectionItem
    {
        private readonly SelectionList _selectionList;
        private int _index;

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

        public int LayerHandle
        {
            get { return _selectionList.LayerHandle[_index]; }
        }

        public int ShapeIndex
        {
            get { return _selectionList.ShapeIndex[_index]; }
        }
    }
}
