using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class JoinTableView : JoinDbfViewBase, IJoinTableView
    {
        public event Action OpenClicked;
        public event Action TryJoin;
        private bool _ignoreEvents = false;

        public JoinTableView()
        {
            InitializeComponent();

            btnOpen.Click += (s, e) => Invoke(OpenClicked);

            Shown += JoinTableView_Shown;
        }

        private void JoinTableView_Shown(object sender, EventArgs e)
        {
            if (Model.Editing)
            {
                fieldsGrid1.Focus();
            }
            else
            {
                btnOpen.Focus();
            }
        }

        public void Initialize()
        {
            BindCurrentFieldCombo();

            cboCurrent.SelectedIndexChanged += (s, e) => Invoke(TryJoin);
            cboExternal.SelectedIndexChanged += (s, e) => Invoke(TryJoin);
            cboOptions.SelectedIndexChanged += (s, e) => LoadExternalTable();

            if (!Model.Editing) return;

            SetDatasource();

            btnOpen.Enabled = false;
            btnOk.Text = "Update";
        }

        /// <summary>
        /// Sets datasource and populates a list of tables (options) available for it.
        /// </summary>
        public void SetDatasource()
        {
            txtDatasource.Text = Model.Filename;
            lblOptions.Text = GetOptionName(Model.SourceType);

            _ignoreEvents = true;
            cboOptions.DataSource = Model.Options;

            if (!string.IsNullOrWhiteSpace(Model.SelectedOption))
            {
                foreach (var item in cboOptions.Items)
                {
                    if (item.ToString().StartsWith(Model.SelectedOption))
                    {
                        cboOptions.SelectedItem = item;
                        break;
                    }
                }
            }

            _ignoreEvents = false;

            LoadExternalTable();
        }

        /// <summary>
        /// Loads table from datasource based on selected option.
        /// </summary>
        private void LoadExternalTable()
        {
            if (_ignoreEvents) return;

            Model.SelectedOption = cboOptions.Text;

            Model.ReloadExternal();

            BindExternalFieldList();

            BindExternalCombo();

            Invoke(TryJoin);

            bool hasDatasource = Model.External != null;

            panel1.Enabled = hasDatasource;
            groupKeys.Enabled = hasDatasource;
        }

        /// <summary>
        /// Populates a list of fields from current table.
        /// </summary>
        private void BindCurrentFieldCombo()
        {
            var list2 = Model.Table.NativeFields.Select(f => new FieldWrapper(f)).ToList();
            cboCurrent.DataSource = list2.ToList();

            if (Model.Join != null)
            {
                cboCurrent.SelectedItem =
                    list2.FirstOrDefault(f => f.Name.EqualsIgnoreCase(Model.Join.ToField));
            }
        }

        /// <summary>
        /// Populates list of fields from external table.
        /// </summary>
        private void BindExternalCombo()
        {
            if (Model.External == null)
            {
                cboExternal.DataSource = null;
                return;
            }

            var list = Model.External.NativeFields.Select(f => new FieldWrapper(f)).ToList();
            cboExternal.DataSource = list;

            if (Model.Join != null)
            {
                cboExternal.SelectedItem = list.FirstOrDefault(f => f.Name.EqualsIgnoreCase(Model.Join.FromField));
            }
        }

        /// <summary>
        /// Populates list of fields from external datasource to be copied to be copied.
        /// </summary>
        private void BindExternalFieldList()
        {
            if (Model.External == null)
            {
                fieldsGrid1.DataSource = new List<FieldWrapper>();
                return;
            }

            var list = Model.External.Fields.Select(f => new FieldWrapper(f)).ToList();

            // which of the fields are currently selected
            if (Model.Join != null && Model.Join.Fields != null)
            {
                var fields = Model.Join.Fields;

                foreach (var name in fields)
                {
                    var field = list.FirstOrDefault(f => f.Name.EqualsIgnoreCase(name));
                    if (field != null)
                    {
                        field.Selected = true;
                    }
                }
            }
            else
            {
                foreach (var item in list)
                {
                    item.Selected = true;
                }
            }

            fieldsGrid1.DataSource = list;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            fieldsGrid1.Adapter.SetPropertyForEach(item => item.Selected, chkAll.Checked);
        }

        public FieldWrapper FieldFrom
        {
            get { return cboExternal.SelectedItem as FieldWrapper; }
        }

        public FieldWrapper FieldTo
        {
            get { return cboCurrent.SelectedItem as FieldWrapper; }
        }

        public IEnumerable<FieldWrapper> SelectedFields
        {
            get { return fieldsGrid1.Adapter.Items.Where(f => f.Selected); }
        }

        public void SetRowCount(int rowCount, int joinRowCount)
        {
            lblMatch.Text = "Matching rows: " + rowCount;
            lblMatchJoin.Text = "Matching rows: " + joinRowCount;
        }

        private static string GetOptionName(JoinSourceType type)
        {
            switch (type)
            {
                case JoinSourceType.Dbf:
                    return "Table";
                case JoinSourceType.Xls:
                    return "Worksheet";
                case JoinSourceType.Csv:
                    return "Separator";
            }

            return "Table";
        }
    }

    public class JoinDbfViewBase : MapWindowView<JoinViewModel> { }
}
