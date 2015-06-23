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
            attributeGrid1.WrapWithPanel = false;
        }

        public void Initialize(IFeatureSet featureSet)
        {
            if (featureSet == null) throw new ArgumentNullException("featureSet");
            _featureSet = featureSet;

            chkVisibility.Checked = featureSet.Table.Fields.All(f => f.Visible);

            UpdateView();
        }

        public void UpdateView()
        {
            attributeGrid1.DataSource = _featureSet.Table.Fields.ToList();
        }

        private void ChangeVisibility(bool visible)
        {
            var fields = _featureSet.Table.Fields;
            foreach (var field in fields)
            {
                field.Visible = visible;
            }
        }

        private void OnVisibilityCheckedChanged(object sender, EventArgs e)
        {
            ChangeVisibility(chkVisibility.Checked);
            UpdateView();
        }
    }
}
