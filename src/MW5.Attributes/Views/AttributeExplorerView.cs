// -------------------------------------------------------------------------------------------
// <copyright file="AttributeExplorerView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Attributes.Helpers;
using MW5.Attributes.Model;
using MW5.Attributes.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Forms;

namespace MW5.Attributes.Views
{
    public partial class AttributeExplorerView : AttributeExplorerViewBase, IAttributeExplorer
    {
        private readonly IAppContext _context;
        private IAttributeTable _table;

        public AttributeExplorerView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            KeyPreview = true;

            KeyDown += OnFormKeyDown;

            recordNavigationBar1.CurrentRecordChanged += (s, e) => Invoke(CurrentFeatureChanged);
        }

        public int CurrentFeatureIndex
        {
            get { return recordNavigationBar1.CurrentRecord; }
        }

        private void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
            {
                txtSearch.Focus();
            }

            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private string Expression
        {
            get
            {
                int fieldIndex = FieldIndex;
                if (fieldIndex == -1 || SelectedValue == null)
                {
                    return string.Empty;
                }

                var fld = _table.Fields[FieldIndex];
                return string.Format("[{0}]={1}", fld.Name, SelectedValue);
            }
        }

        private int FieldIndex
        {
            get
            {
                var fld = cboField.SelectedItem as FieldTypeWrapper;
                return fld != null ? fld.Index : -1;
            }
        }

        private string SelectedValue
        {
            get
            {
                var item = valueCountGrid1.Adapter.SelectedItem;
                if (item != null)
                {
                    return item.Value;
                }

                return null;
            }
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            _table = Model.FeatureSet.Table;

            InitFieldGrid();

            InitValuesGrid();

            ShowValues();
        }

        public override ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                {
                    Modal = true,
                    Sizable = true
                };
            }
        }

        public ButtonBase OkButton { get; private set; }

        private void InitFieldGrid()
        {
            var fields = Model.FeatureSet.Fields;
            var list = fields.Select(f => new FieldTypeWrapper(f)).ToList();
            cboField.DataSource = list;
            cboField.SelectedIndexChanged += (s, e) => ShowValues();
        }

        private void InitValuesGrid()
        {
            valueCountGrid1.SelectedRecordsChanged += (s, e) => UpdateSelection();
        }

        private void ShowValues()
        {
            txtSearch.Text = string.Empty;

            if (FieldIndex == -1) return;

            var list = _table.GetUniqueValues(FieldIndex).ToList();

            valueCountGrid1.DataSource = list;

            valueCountGrid1.ShowColumnHeaders = true;
        }

        private void UpdateNavigation()
        {
            var value = valueCountGrid1.Adapter.SelectedItem;
            if (value != null)
            {
                recordNavigationBar1.Visible = value.Count > 1;
                recordNavigationBar1.MaxLabel = "of " + value.Count.ToString(CultureInfo.InvariantCulture);
                recordNavigationBar1.MaxRecord = value.Count;
                recordNavigationBar1.MoveFirst();
            }
        }

        private void UpdateSelection()
        {
            string expression = Expression;

            string err;
            int[] arr;

            if (_table.Query(expression, out arr, out err))
            {
                Model.UpdateSelection(arr, SelectionOperation.New);
            }

            UpdateNavigation();

            FireZoomTo();
        }

        public event Action ZoomTo;

        public event Action CurrentFeatureChanged;

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            valueCountGrid1.Adapter.ClearFilter();
            valueCountGrid1.Adapter.AddFilterLike(item => item.Value, txtSearch.Text);
        }

        private void OnZoomToChanged(object sender, EventArgs e)
        {
            FireZoomTo();
        }

        private void FireZoomTo()
        {
            if (chkZoomTo.Checked)
            {
                Invoke(ZoomTo);
            }
        }
    }

    public class AttributeExplorerViewBase : MapWindowView<ILayer>
    {
    }
}