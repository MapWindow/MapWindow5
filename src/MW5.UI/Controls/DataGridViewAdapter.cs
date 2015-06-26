using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using MW5.UI.Helpers;

namespace MW5.UI.Controls
{
    /// <summary>
    /// Strongly typed methods for DataGridView control.
    /// </summary>
    public class DataGridViewAdapter<T>
        where T: class
    {
        private readonly Dictionary<int, Func<T, Bitmap>> _iconSelectors = new Dictionary<int, Func<T, Bitmap>>();
        private readonly DataGridView _grid;
        private IList<T> _list;
        private BindingListView<T> _bindingSource;

        public DataGridViewAdapter(DataGridView grid)
        {
            if (grid == null) throw new ArgumentNullException("grid");
            _grid = grid;
            _grid.CellFormatting += OnCellFormatting;
        }

        private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Func<T, Bitmap> fn;
            if (_iconSelectors.TryGetValue(e.ColumnIndex, out fn))
            {
                var row = _grid.Rows[e.RowIndex];
                
                var item = row.DataBoundItem as T;
                if (item == null)
                {
                    // BindingListView wraps items in ObjectView<T>
                    var o = row.DataBoundItem as ObjectView<T>;
                    if (o != null)
                    {
                        item = o.Object;
                    }
                }

                if (item != null)
                {
                    e.Value = fn(item);
                    e.FormattingApplied = true;
                }
            }
        }

        public void SetDatasource(BindingListView<T> ds)
        {
            _grid.DataSource = ds;
            _bindingSource = ds;

            if (ds != null)
            {
                _list = ds.DataSource as IList<T>;

                if (_list == null)
                {
                    throw new ApplicationException("Binding source with strongly typed list is expected here.");
                }
            }
            else
            {
                _list = null;
            }
        }

        public void SetDatasource(IList<T> list)
        {
            _grid.DataSource = list;
            _list = list;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _list.Count)
                {
                    return default(T);
                }

                return _list[index];
            }
        }

        public T SelectedItem
        {
            get
            {
                if (_grid.SelectedRows.Count == 1)
                {
                    return _grid.SelectedRows[0].DataBoundItem as T;
                }

                return default(T);
            }
        }

        public BindingListView<T> BindingSource
        {
            get { return _bindingSource; }
        }

        public DataGridViewColumn GetColumn(Expression<Func<T, object>> propertySelector)
        {
            string name = GenericHelper.GetPropertyName(propertySelector);
            return name != string.Empty ? _grid.Columns[name] : null;
        }

        public int GetColumnIndex(Expression<Func<T, object>> propertySelector)
        {
            string name = GenericHelper.GetPropertyName(propertySelector);
            if (name != string.Empty)
            {
                var cmn = _grid.Columns[name];
                if (cmn != null)
                {
                    return cmn.Index;
                }
            }

            return -1;
        }

        public void SetColumnIcon(Expression<Func<T, object>> propertySelector, Func<T, Bitmap> imageSelector)
        {
            var cmn = GetColumn(propertySelector);
            if (!(cmn is DataGridViewImageColumn))
            {
                return;
            }

            _iconSelectors.Add(cmn.Index, imageSelector);
        }
    }
}
