using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Editor
{
    public class RowManager
    {
        private int[] _sortingMap;             // sorted index -> real index
        private int _sortColumnIndex = -1;
        private bool _sortAscending;

        private int[] _filterMap;           // row index -> real index
        private bool[] _filterMask;         // in real indices
        private bool _filtered;

        public int SortColumnIndex
        {
            get { return _sortColumnIndex; }
        }

        public bool SortAscending
        {
            get { return _sortAscending; }
        }

        public bool Sorted
        {
            get { return _sortColumnIndex != -1; }
        }

        public bool Filtered
        {
            get { return _filtered; }
        }

        public int Count
        {
            get { return _filtered ? _filterMap.Length : _sortingMap.Length; }
        }

        public int RealIndex(int rowIndex)
        {
            if (Filtered)
            {
                return _filterMap[rowIndex];
            }
            return _sortingMap[rowIndex];
        }

        public void Reset(IFeatureSet sf)
        {
            ClearSorting(sf);

            ClearFilter();
        }

        public void ClearSorting(IFeatureSet sf)
        {
            int numRows = sf.Table.NumRows;
            _sortingMap = new int[sf.Table.NumRows];

            for (int i = 0; i < numRows; i++)
            {
                _sortingMap[i] = i;
            }

            _sortColumnIndex = -1;
            _sortAscending = true;
        }

        public void ClearFilter()
        {
            _filtered = false;
            _filterMap = new int[0];
        }

        public void FilterSelected(IFeatureSet sf)
        {
            int numShapes = sf.Features.Count;
            _filterMap = new int[sf.NumSelected];
            _filterMask = new bool[numShapes];
            int count = 0;

            for (int i = 0; i < numShapes; i++)
            {
                int realIndex = _sortingMap[i];
                bool selected = sf.FeatureSelected(realIndex);
                if (selected)
                {
                    _filterMap[count] = realIndex;
                    _filterMask[realIndex] = true;
                    count++;
                }
            }

            _filtered = true;
        }

        public void SetSorting(int cmnIndex, bool ascending, IEnumerable<int> indices)
        {
            _sortColumnIndex = cmnIndex;
            _sortAscending = ascending;

            var arr = indices.ToArray();
            for (int i = 0; i < _sortingMap.Length; i++)
            {
                _sortingMap[i] = arr[i];
            }

            UpdateFilter();
        }

        private void UpdateFilter()
        {
            if (!_filtered)
            {
                return;
            }

            int numFiltered = _filterMask.Count(v => v);
            int count = 0;

            _filterMap = new int[numFiltered];

            for (int i = 0; i < _sortingMap.Length; i++)
            {
                int realIndex = _sortingMap[i];
                if (_filterMask[realIndex])
                {
                    _filterMap[count] = realIndex;
                    count++;
                }
            }
        }


    }
}
