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
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class DeleteFieldsView : MapWindowView<IAttributeTable>, IDeleteFieldsView
    {
        public DeleteFieldsView()
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

        public void Initialize()
        {
            clb.Items.Clear();
            foreach (var fld in Model.Fields)
            {
                clb.Items.Add(fld.Name);
            }
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
