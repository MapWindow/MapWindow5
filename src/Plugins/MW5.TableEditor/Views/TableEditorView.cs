using System;
using System.Collections.Generic;
using System.Drawing;
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
        public TableEditorView(IAppView appView, RowManager rowManager)
            : base(appView)
        {
            if (rowManager == null) throw new ArgumentNullException("rowManager");

            InitializeComponent();

            _grid.CurrentCellBorderColor = Color.LightGreen;
            _grid.RowManager = rowManager;
            _grid.SelectionChanged += (s, e) =>
            {
                Invoke(SelectionChanged);
                UpdateSelectedCount();
            };
        }

        public override Mvp.ViewStyle Style
        {
            get
            {
                return new Mvp.ViewStyle()
                {
                    Modal = false,
                    Sizable = true,
                };
            }
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

        public void UpdateDatasource()
        {
            SetDatasource(_grid.TableSource);
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

            bool editing = _grid.TableSource.EditingTable;
            _grid.ReadOnly = !editing;

            _grid.Invalidate();
            
            btnStartEdit.Enabled = !editing;
            mnuAddField.Enabled = editing;
            mnuRemoveField.Enabled = editing;
            mnuRenameField.Enabled = editing;
            btnCalculateField.Enabled = editing;

            btnSaveChanges.Enabled = _grid.TableSource.EditingTable;

            UpdateSelectedCount();
        }

        private void UpdateSelectedCount()
        {
            string msg = string.Format("{0} of {1} selected", _grid.TableSource.NumSelected, _grid.TableSource.NumShapes);
            _lblAmountSelected.Text = msg;
        }

        public IEnumerable<ToolStripItemCollection> Toolstrips
        {
            get { return from ToolStripMenuItem item in menuStrip1.Items select item.DropDownItems; }
        }

        public IEnumerable<Control> Buttons
        {
            get 
            { 
                var list =panel1.Controls.OfType<ButtonBase>().Select(item => item as Control);
                return list.Except(new List<Control>() { OkButton });
            }
        }

        public IEnumerable<IToolbar> Toolbars
        {
            get { yield break; }
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }
    }
}
