using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Printing.Model;
using MW5.UI.Controls;

namespace MW5.Plugins.Printing.Controls
{
    public partial class TemplateGrid : StronglyTypedGrid<LayoutTemplate>
    {
        public TemplateGrid()
        {
            InitializeComponent();

            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;
            Adapter.ShowEditors = false;
        }

        protected override void UpdateColumns()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(item => item.Name);
            Adapter.ShowColumn(item => item.PaperFormat);
            Adapter.ShowColumn(item => item.Orientation);
            Adapter.ShowColumn(item => item.Pages);
        }
    }
}
