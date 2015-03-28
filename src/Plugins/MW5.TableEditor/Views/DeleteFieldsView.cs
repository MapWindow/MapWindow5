using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.UI;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class DeleteFieldsView : MapWindowView, IDeleteFieldsView
    {
        private IAttributeTable _table;

        public DeleteFieldsView(IAppView appView):
            base(appView)
        {
            InitializeComponent();

            clb.ItemCheck += clb_ItemCheck;
        }

        public IEnumerable<int> FieldsToRemove
        {
            get
            {
                for (var i = clb.Items.Count - 1; i >= 0 ; i--)
                {
                    if (clb.GetItemChecked(i))
                    {
                        yield return i;
                    }
                }
            }
        }

        public IAttributeTable Table
        {
            get { return _table; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _table = value;
                InitList();
            }
        }

        private void InitList()
        {
            clb.Items.Clear();
            foreach (var fld in Table.Fields)
            {
                clb.Items.Add(fld.Name);
            }
        }

        public void UpdateView()
        {

        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        private void clb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnOk.Enabled = clb.SelectedItems.Count > 0;
        }
    }
}
