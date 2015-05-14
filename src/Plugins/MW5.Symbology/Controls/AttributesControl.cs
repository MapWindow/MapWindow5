using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class AttributesControl : UserControl
    {
        public AttributesControl()
        {
            InitializeComponent();
            attributeGrid1.Adapter.ShowEditors = false;
            attributeGrid1.Adapter.HotTracking = true;
        }

        public void Initialize(IFeatureSet featureSet)
        {
            attributeGrid1.DataSource = featureSet.Table.Fields.ToList();

            int index = attributeGrid1.Adapter.GetRelativeColumnIndex(f => f.Name);
            if (index != -1)
            {
                attributeGrid1.TableDescriptor.Columns.Move(index, 0);
            }

            attributeGrid1.Adapter.GetColumn(f => f.Name).Width = 100;
        }
    }
}
