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
        private IFeatureSet _featureSet;

        public AttributesControl()
        {
            InitializeComponent();
        }

        public void Initialize(IFeatureSet featureSet)
        {
            if (featureSet == null) throw new ArgumentNullException("featureSet");
            _featureSet = featureSet;

            UpdateGrid();
        }

        private void UpdateGrid()
        {
            attributeGrid1.DataSource = _featureSet.Table.Fields.ToList();
        }

        private void toolCheckAll_Click(object sender, EventArgs e)
        {
            ChangeVisibility(true);
            UpdateGrid();
        }

        private void toolUncheckAll_Click(object sender, EventArgs e)
        {
            ChangeVisibility(false);
            UpdateGrid();
        }

        private void ChangeVisibility(bool visible)
        {
            var fields = _featureSet.Table.Fields;
            foreach (var field in fields)
            {
                field.Visible = visible;
            }
        }
    }
}
