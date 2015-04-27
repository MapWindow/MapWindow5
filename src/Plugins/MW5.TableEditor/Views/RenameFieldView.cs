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
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class RenameFieldView : MapWindowView<IAttributeTable>, IRenameFieldView
    {
        public RenameFieldView()
        {
            InitializeComponent();
        }

        public int FieldIndex
        {
            get { return cboField.SelectedIndex; }
        }

        public string NewName
        {
            get { return txtNewName.Text; }
        }

        public void Initialize()
        {
            cboField.Items.Clear();

            foreach (var fld in Model.Fields)
            {
                cboField.Items.Add(fld.Name);
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }
}
