// -------------------------------------------------------------------------------------------
// <copyright file="DeleteFieldsView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class DeleteFieldsView : DeleteFieldsViewBase, IDeleteFieldsView
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
                for (var i = clb.Items.Count - 1; i >= 0; i--)
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

            if (clb.Items.Count > 0)
            {
                clb.SelectedIndex = 0;
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

    public class DeleteFieldsViewBase : MapWindowView<IAttributeTable>
    {
    }
}