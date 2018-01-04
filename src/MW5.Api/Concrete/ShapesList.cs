using System;
using System.Collections;
using System.Collections.Generic;
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

        public void AddShape(int layerHandle, int shapeIndex)
        {
            _list.AddShape(layerHandle, shapeIndex);
        }

        public void AddPixel(int layerHandle, int column, int row)
        {
            _list.AddPixel(layerHandle, column, row);
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
