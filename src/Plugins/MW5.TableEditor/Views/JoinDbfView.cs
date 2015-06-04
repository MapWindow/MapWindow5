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
    public partial class JoinDbfView : JoinDbfViewBase, IJoinDbfView
    {
        public event Action TryJoin;

        public JoinDbfView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            if (Model.External == null) return;

            BindFields();

            BindCombos();

            AttachListeners();

            Invoke(TryJoin);
        }

        private void BindFields()
        {
            var list = Model.External.Fields.Select(f => new FieldWrapper(f)).ToList();

            if (Model.EditJoin != null && Model.EditJoin.Fields != null)
            {
                var fields = Model.EditJoin.Fields;

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

            fieldsGrid1.DataSource = list.ToList();
        }

        private void BindCombos()
        {
            var list = Model.External.NativeFields.Select(f => new FieldWrapper(f)).ToList();
            cboExternal.DataSource = list;

            var list2 = Model.Table.NativeFields.Select(f => new FieldWrapper(f)).ToList();
            cboCurrent.DataSource = list2.ToList();

            if (Model.EditJoin != null)
            {
                cboExternal.SelectedItem =
                    list.FirstOrDefault(f => f.Name.EqualsIgnoreCase(Model.EditJoin.FromField));

                cboCurrent.SelectedItem =
                    list2.FirstOrDefault(f => f.Name.EqualsIgnoreCase(Model.EditJoin.ToField));
            }
        }

        private void AttachListeners()
        {
            cboCurrent.SelectedIndexChanged += (s, e) => Invoke(TryJoin);
            cboExternal.SelectedIndexChanged += (s, e) => Invoke(TryJoin);
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
    }

    public class JoinDbfViewBase : MapWindowView<JoinDbfModel> { }
}
