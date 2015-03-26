using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MapWinGIS;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Editor
{
    public partial class TableEditorView : MapWindowForm, ITableEditorView
    {
        private ILayer _layer;

        public TableEditorView(IAppContext context): base(context)
        {
            if (context == null) throw new ArgumentNullException("context");

            InitializeComponent();

            _grid.SelectionChanged += (s, e) => Invoke(SelectionChanged);
        }

        public event Action SelectionChanged;

        public new void Hide()
        {
            Clear();
            base.Hide();
        }

        private void Clear()
        {
            _grid.TableSource = null;
        }

        public void UpdateSelection()
        {
            _grid.OnDatasourceSelectionChanged();

            UpdateSelectedCount(_grid.SelectedCount);
        }

        public IEnumerable<int> SelectedIndices
        {
            get { return _grid.SelectedIndices; }
        }

        public void SetDatasource(Shapefile sf)
        {
            _grid.TableSource = sf;

            UpdateSelectedCount(_grid.SelectedCount);
        }

        public void UpdateView()
        {
            UpdateSelectedCount(_grid.SelectedCount);
        }

        private void UpdateSelectedCount(int numSelected)
        {
            // TODO: optimize, for not calling count each time
            string msg = string.Format("{0} of {1} selected", numSelected, _grid.TableSource.NumShapes);
            _lblAmountSelected.Text = msg;
        }

        public IEnumerable<ToolStripMenuItem> ToolStrips
        {
            get { yield break; }
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
    }
}
