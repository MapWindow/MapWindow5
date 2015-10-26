// -------------------------------------------------------------------------------------------
// <copyright file="TableView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MW5.Plugins.Mvp;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Model.Table;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.UI.Forms;

namespace MW5.Plugins.Printing.Views
{
    internal partial class TableView : TableViewBase, ITableView
    {
        private readonly BindingList<Column> _columns = new BindingList<Column>();

        public TableView()
        {
            InitializeComponent();

            InitializeControls();

            AttachHandlers();
        }

        private ColumnWidthType WidthType
        {
            get
            {
                if (optAuto.Checked)
                {
                    return ColumnWidthType.Auto;
                }

                return optFixed.Checked ? ColumnWidthType.Fixed : ColumnWidthType.Relative;
            }
        }

        public event Action ApplyClicked;

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            CopyColumns(Model.Table.Data.Columns, _columns);

            FillTable();

            FillColumns();

            btnApply.Visible = !Model.Adding;
        }

        public void Save()
        {
            var tableData = Model.Table.Data;
            tableData.Columns.Clear();
            tableData.ClearRows();

            CopyColumns(_columns, tableData.Columns);

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                var data = new RowData();

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    var val = dataGridView1[j, i].Value;
                    data.Add(val != null ? val.ToString() : "");
                }

                tableData.AddRow(data);
            }
        }

        public override ViewStyle Style
        {
            get { return new ViewStyle(true); }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        private void AttachHandlers()
        {
            optAuto.CheckedChanged += OptAutoCheckedChanged;

            udWidth.ValueChanged += UdWidthValueChanged;

            udRelWidth.ValueChanged += UdRelWidthValueChanged;

            btnApply.Click += (s, e) => Invoke(ApplyClicked);
        }

        private void CopyColumns(IEnumerable<Column> from, ICollection<Column> to)
        {
            to.Clear();

            foreach (var cmn in from)
            {
                to.Add(new Column(cmn.Name) { Width = cmn.Width, WidthType = cmn.WidthType, RelWidth = cmn.RelWidth });
            }
        }

        private void FillColumns()
        {
            listBoxColumns.DataSource = _columns;
        }

        private void FillTable()
        {
            foreach (var cmn in _columns)
            {
                dataGridView1.Columns.Add("", "");
            }

            foreach (var row in Model.Table.Data)
            {
                dataGridView1.Rows.Add(row.ToObjectArray());
            }
        }

        private void InitializeControls()
        {
            // temporary disabled
            //udWidth.DataBindings.Add("Enabled", optFixed, "Checked");
            //udRelWidth.DataBindings.Add("Enabled", optRelative, "Checked");
            //lblPercent.DataBindings.Add("Enabled", optRelative, "Checked");
        }

        private void OnAddField(object sender, EventArgs e)
        {
            _columns.Add(new Column("Column " + _columns.Count));

            FillColumns();

            dataGridView1.Columns.Add("", "");

            if (listBoxColumns.Items.Count > 0)
            {
                listBoxColumns.SelectedIndex = listBoxColumns.Items.Count - 1;
            }
        }

        private void OnRemoveField(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("The selected column will be removed. Continue?"))
            {
                int rowIndex = listBoxColumns.SelectedIndex;

                _columns.RemoveAt(rowIndex);

                dataGridView1.Columns.RemoveAt(rowIndex);

                FillColumns();
            }
        }

        private void OnSelectedColumnChanged(object sender, EventArgs e)
        {
            int rowIndex = listBoxColumns.SelectedIndex;
            var cmn = _columns[rowIndex];

            udWidth.SetValue(cmn.Width);
            udRelWidth.SetValue(cmn.RelWidth);

            switch (cmn.WidthType)
            {
                case ColumnWidthType.Auto:
                    optAuto.Checked = true;
                    break;
                case ColumnWidthType.Fixed:
                    optFixed.Checked = true;
                    break;
                case ColumnWidthType.Relative:
                    optRelative.Checked = true;
                    break;
            }
        }

        private void OptAutoCheckedChanged(object sender, EventArgs e)
        {
            int rowIndex = listBoxColumns.SelectedIndex;
            _columns[rowIndex].WidthType = WidthType;
        }

        private void UdRelWidthValueChanged(object sender, EventArgs e)
        {
            int rowIndex = listBoxColumns.SelectedIndex;
            _columns[rowIndex].RelWidth = (int)udRelWidth.Value;
        }

        private void UdWidthValueChanged(object sender, EventArgs e)
        {
            int rowIndex = listBoxColumns.SelectedIndex;
            _columns[rowIndex].Width = (int)udWidth.Value;
        }
    }

    internal class TableViewBase : MapWindowView<TableViewModel>
    {
    }
}