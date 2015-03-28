using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Plugins.Interfaces;
using MW5.Plugins.TableEditor.Editor;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class TableEditorView : MapWindowView, ITableEditorView
    {
        public TableEditorView(IAppContext context, RowManager rowManager): base(context)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (rowManager == null) throw new ArgumentNullException("rowManager");

            InitializeComponent();

            _grid.RowManager = rowManager;
            _grid.SelectionChanged += (s, e) => Invoke(SelectionChanged);
        }

        public event Action SelectionChanged;

        private RowManager RowManager
        {
            get { return _grid.RowManager; }
        }

        public new void Hide()
        {
            Clear();
            base.Hide();
        }

        private void Clear()
        {
            _grid.TableSource = null;
        }

        public void SetDatasource(Shapefile sf)
        {
            _grid.TableSource = sf;

            UpdateView();
        }

        public void UpdateView()
        {
            int count = RowManager.Count;
            if (count == 0)
            {
                _grid.CurrentCell = null;
            }

            _grid.RowCount = 0;     // this will clear all rows at once or else it will try to remove them one by one (veeeery slow)
            _grid.RowCount = RowManager.Count;

            _grid.Invalidate();

            bool editing = _grid.TableSource.EditingTable;
            btnStartEdit.Enabled = !editing;
            mnuAddField.Enabled = editing;
            mnuRemoveField.Enabled = editing;
            mnuRenameField.Enabled = editing;

            UpdateSelectedCount(_grid.SelectedCount);
        }

        private void UpdateSelectedCount(int numSelected)
        {
            string msg = string.Format("{0} of {1} selected", numSelected, _grid.TableSource.NumShapes);
            _lblAmountSelected.Text = msg;
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get {
                return from ToolStripMenuItem item in menuStrip1.Items select item.DropDownItems;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                foreach (var item in panel1.Controls)
                {
                    if (item is ButtonBase)
                    {
                        yield return item as Control;
                    }
                }
            }
        }

        public IEnumerable<IToolbar> Toolbars
        {
            get { yield break; }
        }
    }
}
