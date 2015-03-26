using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MapWinGIS;

namespace MW5.Plugins.TableEditor.Editor
{
    internal class RowManager
    {
        private RowInfo[] _rows;
        private int _lastIndex = -1;

        public void Init(Shapefile sf)
        {
            int numRows = sf.Table.NumRows;
            _rows = new RowInfo[sf.Table.NumRows];

            for (int i = 0; i < numRows; i++)
            {
                _rows[i].RealIndex = i;
                _rows[i].Selected = sf.ShapeSelected[i];
            }
        }

        public void OnDatasourceSelectionChanged(Shapefile sf)
        {
            int numRows = sf.Table.NumRows;

            for (int i = 0; i < numRows; i++)
            {
                _rows[i].Selected = sf.ShapeSelected[i];
            }
        }

        public int SelectedCount
        {
            get { return _rows.Count(r => r.Selected); }
        }

        public RowInfo this[int rowIndex]
        {
            get { return _rows[rowIndex]; } 
        }

        public IEnumerable<int> SelectedIndices
        {
            get { return _rows.Where(r => r.Selected).Select(r => r.RealIndex); }
        }

        public void ClearSelection()
        {
            for (int i = 0; i < _rows.Length; i++)
            {
                _rows[i].Selected = false;
            }
        }

        public void OnRowHeaderClicked(int rowIndex, Keys keys)
        {
            if (keys != Keys.Shift && keys != Keys.Control)
            {
                ClearSelection();
            }

            if (keys == Keys.Shift && _lastIndex != -1)
            {
                bool state = _rows[_lastIndex].Selected;

                int min = Math.Min(_lastIndex, rowIndex);
                int max = Math.Max(_lastIndex, rowIndex);

                for (int i = min; i <= max; i++)
                {
                    _rows[i].Selected = state;
                }
            }
            else
            {
                _rows[rowIndex].Selected = !_rows[rowIndex].Selected;
            }

            _lastIndex = rowIndex;
        }
    }
}
