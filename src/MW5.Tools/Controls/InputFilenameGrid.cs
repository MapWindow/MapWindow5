using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Services.Helpers;
using MW5.Services.Views;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Tools.Controls
{
    internal partial class InputFilenameGrid : StronglyTypedGrid<InputFilenameGridAdapter>
    {
        public InputFilenameGrid()
        {
            InitializeComponent();

            Adapter.HotTracking = false;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;

            ShowColumnHeaders = false;
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = null;
                base.DataSource = value;
                UpdateColumns();
            }
        }

        private void UpdateColumns()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(f => f.Filename);
            Adapter.GetColumn(f => f.Filename).Width = Width - 30;
        }
    }
}
