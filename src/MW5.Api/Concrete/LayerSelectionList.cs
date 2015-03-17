using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace MW5.Api.Concrete
{
    public class LayerSelectionList: IEnumerable<LayerSelection>
    {
        private readonly SelectionList _list;

        public LayerSelectionList(SelectionList list)
        {
            if (list == null) throw new ArgumentNullException("list");
            _list = list;
        }

        public void Add(int layerHandle, int shapeIndex)
        {
            _list.Add(layerHandle, shapeIndex);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int NumLayers
        {
            get { return _list.NumLayers; }
        }

        public IEnumerator<LayerSelection> GetEnumerator()
        {
            for (int i = 0; i < _list.NumLayers; i++)
            {
                yield return new LayerSelection(_list, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
