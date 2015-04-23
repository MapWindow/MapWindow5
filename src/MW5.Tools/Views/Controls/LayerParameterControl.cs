using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Tools.Views.Controls
{
    public partial class LayerParameterControl : ParameterControlBase, IParameterControl
    {
        private readonly IEnumerable<ILayer> _layers;

        public LayerParameterControl(IEnumerable<ILayer> layers)
        {
            if (layers == null) throw new ArgumentNullException("layers");
            _layers = layers;

            InitializeComponent();

            // TODO: would be great to display some more info like icons or number of features
            comboBoxAdv1.DataSource = _layers.ToList();
        }

        public object GetValue()
        {
            return comboBoxAdv1.SelectedItem as ILayer;
        }

        public TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        private void buttonAdv1_Click(object sender, EventArgs e)
        {
            MessageService.Current.Info("Not implemented");
        }
    }
}
