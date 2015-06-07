using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.TableEditor.Model;

namespace MW5.Plugins.TableEditor.Controls
{
    public partial class FieldsListView : ListView
    {
        public FieldsListView()
        {
            InitializeComponent();

            View = View.SmallIcon;
        }

        public void SetFields(IEnumerable<FieldWrapper> fields) 
        {
            if (fields == null)
            {
                return;
            }

            Items.Clear();
            foreach (var fld in fields)
            {
                Items.Add(new ListViewItem()
                {
                    Text = fld.Name,
                    Checked = fld.Selected
                });
            }
        }
    }
}
