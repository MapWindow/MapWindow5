// -------------------------------------------------------------------------------------------
// <copyright file="FieldOperationGrid.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.UI.Controls;
using Syncfusion.Grouping;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Tools.Controls
{
    /// <summary>
    /// A grid control to choose field operation for attribute field of vector datasource.
    /// </summary>
    internal partial class FieldOperationGrid : StronglyTypedGrid<FieldOperationGridAdapter>
    {
        private List<GridComboItem> _stringOperations;

        public FieldOperationGrid()
        {
            InitializeComponent();

            Adapter.HotTracking = false;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;
            TableOptions.ListBoxSelectionMode = SelectionMode.None;

            QueryCellStyleInfo += OnQueryCellStyleInfo;

            Engine.ShowNestedPropertiesFields = false;

            RecordValueChanging += OnRecordValueChanging;
        }

        public void UpdateFieldCombo(IFeatureSet fs)
        {
            var fields = GetFieldItems(fs);
            var cmn = Adapter.GetColumn(f => f.Field);
            Adapter.AddComboBox(cmn, fields.ToList());
        }

        protected override void UpdateColumns()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(f => f.Field);
            Adapter.ShowColumn(f => f.GroupOperation);
            Adapter.ShowColumn(f => f.Delete);

            Adapter.GetColumn(f => f.Field).Width = 150;
            AddOperationComboBox();

            Adapter.AddDeleteButton(Adapter.GetColumn(f => f.Delete));

            BuildStringOperationList();
        }

        private void AddOperationComboBox()
        {
            var items = GridComboItem.CreateForEnum<GroupOperation>().ToList();
            var cmn = Adapter.GetColumn(f => f.GroupOperation);
            Adapter.AddComboBox(cmn, items);
        }

        private void BuildStringOperationList()
        {
            var operations = new[] { GroupOperation.Max, GroupOperation.Min, GroupOperation.Mode };
            _stringOperations = GridComboItem.CreateForEnum(operations).ToList();
        }

        private IEnumerable<GridComboItem> GetFieldItems(IFeatureSet fs)
        {
            var fields = fs.Fields;
            foreach (var f in fields)
            {
                yield return new GridComboItem(f.Name, f);
            }
        }

        /// <summary>
        /// Displaying limited list of operations of string columns.
        /// </summary>
        private void OnQueryCellStyleInfo(object sender, GridTableCellStyleInfoEventArgs e)
        {
            int index = Adapter.RowIndexToRecordIndex(e.TableCellIdentity.RowIndex);
            var field = Adapter[index];

            if (field != null && field.Field.Type == AttributeType.String)
            {
                var cmnIndex = Adapter.GetColumnIndex(item => item.GroupOperation);

                if (cmnIndex == e.TableCellIdentity.ColIndex)
                {
                    e.Style.DataSource = _stringOperations;
                }
            }
        }

        /// <summary>
        /// Forcing grid to save value immediately.
        /// </summary>
        private void OnRecordValueChanging(object sender, RecordValueChangingEventArgs e)
        {
            TableControl.CurrentCell.Lock();

            // without this line the underlying business object won't be update until we leave the record
            e.FieldDescriptor.ForceImmediateSaveValue = true;

            e.Record.SetValue(e.Column, e.NewValue);

            // without this line, it appears that changes aren't saved to underlying object at all
            e.FieldDescriptor.ForceImmediateSaveValue = false;

            TableControl.CurrentCell.Unlock();
        }
    }
}