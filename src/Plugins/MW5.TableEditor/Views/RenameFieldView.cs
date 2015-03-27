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

namespace MW5.Plugins.TableEditor.Views
{
    public partial class RenameFieldView : MapWindowView, IRenameFieldView
    {
        public RenameFieldView(IAppContext context): 
            base(context)
        {
            InitializeComponent();

            btnOK.Click += (s, e) => FireOkClicked();
        }

        public void Init(IAttributeTable table)
        {
            cboField.Items.Clear();

            foreach (var fld in table.Fields)
            {
                cboField.Items.Add(fld.Name);
            }
        }

        public int FieldIndex
        {
            get { return cboField.SelectedIndex; }
        }

        public string NewName
        {
            get { return txtNewName.Text; }
        }

        public void UpdateView()
        {
        }
    }
}
