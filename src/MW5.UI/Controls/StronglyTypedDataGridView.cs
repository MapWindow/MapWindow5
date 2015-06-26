using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.UI.Controls
{
    public class StronglyTypedDataGridView<T>: DataGridView
        where T: class
    {
        public DataGridViewAdapter<T> Adapter { get; protected set; }

      protected StronglyTypedDataGridView()
        {
            Adapter = new DataGridViewAdapter<T>(this);
        }
    }
}
