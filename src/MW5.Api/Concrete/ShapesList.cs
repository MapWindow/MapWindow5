using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    public class ShapesList: IShapesList
    {
        private readonly SelectionList _list;

        public ShapesList(SelectionList list)
        {
            if (list == null) throw new ArgumentNullException("list");
            _list = list;
        }

        public void Add(int layerHandle, int shapeIndex)
        {
            _list.AddShape(layerHandle, shapeIndex);
        }

        public void AddPixel(int layerHandle, int rasterX, int rasterY)
        {
            _list.AddPixel(layerHandle, rasterX, rasterY);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public void RemoveByLayerHandle(int layerHandle)
        {
            _list.RemoveByLayerHandle(layerHandle);
        }

        public IEnumerator<SelectionItem> GetEnumerator()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                yield return new SelectionItem(_list, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
