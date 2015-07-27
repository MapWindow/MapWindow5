using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Model;

namespace MW5.Tools.Views.Controls
{
    /// <summary>
    /// Represents combobox with a list of layers and a button to open datasource from disk.
    /// </summary>
    public partial class LayerParameterControl : ParameterControlBase, IParameterControl
    {
        private readonly List<LayerWrapper> _layers = new List<LayerWrapper>();
        private readonly IFileDialogService _dialogService;
        private readonly DataSourceType _dataSourceType;

        public LayerParameterControl(IEnumerable<LayerWrapper> layers, DataSourceType dataSourceType, IFileDialogService dialogService)
        {
            if (layers == null) throw new ArgumentNullException("layers");
            if (dialogService == null) throw new ArgumentNullException("dialogService");

            _dialogService = dialogService;
            _dataSourceType = dataSourceType;

            InitializeComponent();

            // TODO: would be great to display some more info like icons or number of features
            _layers = layers.ToList();
            comboBoxAdv1.DataSource = layers;
        }

        public object GetValue()
        {
            return comboBoxAdv1.SelectedItem as LayerWrapper;
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

        private void OpenClick(object sender, EventArgs e)
        {
            OpenDatasource();
        }

        private void OpenDatasource()
        {
            string filename;
            if (_dialogService.OpenFile(_dataSourceType, out filename))
            {
                var identity = new LayerIdentity(filename);
                var wrapper = new LayerWrapper(identity);
                _layers.Add(wrapper);
                comboBoxAdv1.DataSource = _layers;
                comboBoxAdv1.SelectedItem = wrapper;
            }
        }
    }
}
