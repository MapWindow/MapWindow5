using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.UI.Controls;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class InfoGrid : StronglyTypedGrid<NodeData>
    {
        public InfoGrid()
        {
            InitializeComponent();

            Adapter.ReadOnly = true;
            ShowColumnHeaders = false;
            TopLevelGroupOptions.ShowCaption = false;

            ChildGroupOptions.ShowCaptionPlusMinus = false;
            ChildGroupOptions.ShowCaptionSummaryCells = false;
            ChildGroupOptions.CaptionText = "{Category}";
            ChildGroupOptions.ShowAddNewRecordAfterDetails = true;
            ChildGroupOptions.ShowAddNewRecordBeforeDetails = false;

            WrapWithPanel = false;
        }

        public new object DataSource
        {
            get { return base.DataSource;  }
            set
            {
                base.DataSource = value;
                InitializeColumns();
                
            }
        }

        private void InitializeColumns()
        {
            Adapter.ClearGrouping();

            this.AdjustRowHeights();

            Adapter.HideColumns();
            Adapter.ShowColumn(item => item.Name);
            Adapter.ShowColumn(item => item.Value);

            Adapter.GroupBy(item => item.Category);

            Adapter.GetColumn(item => item.Value).Width = Width - 200;
        }
    }
}
