using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Events;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Views;
using MW5.Tools.Model.Layers;
using MW5.UI.Helpers;

namespace MW5.Tools.Controls.Parameters
{
    internal partial class BatchLayerParameterControl : ParameterControlBase
    {
        private readonly IFileDialogService _dialogService;
        private readonly ISelectLayerService _layerService;
        private DataSourceType _layerType = DataSourceType.All;
        private readonly BindingList<InputSourceGridAdapter> _layers = new BindingList<InputSourceGridAdapter>();

        public BatchLayerParameterControl(IFileDialogService dialogService,
                                          ISelectLayerService layerService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            if (layerService == null) throw new ArgumentNullException("layerService");
            _dialogService = dialogService;
            _layerService = layerService;

            InitializeComponent();

            toolParameterGrid1.DataSource = _layers;

            HideSelectedOnly();
        }

        private void HideSelectedOnly()
        {
            panel1.Height = 0;
            panel1.Visible = false;
        }

        public void Initialize(DataSourceType dataSourceType)
        {
            _layerType = dataSourceType;
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        public override string Caption 
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// The get table.
        /// </summary>
        public override TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public override object GetValue()
        {
            return null;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            throw new NotSupportedException("SetValue isn't supported.");
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            AddLayers(_layerService.Select(_layerType).Select(l => new InputSourceGridAdapter(l)));
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            string[] filenames;

            if (_dialogService.OpenFiles(_layerType, out filenames))
            {
                AddLayers(filenames.Select(f => new InputSourceGridAdapter(f)));
            }
        }

        private void AddLayers(IEnumerable<InputSourceGridAdapter> layers)
        {
            foreach (var item in layers)
            {
                _layers.Add(item);
            }

            toolParameterGrid1.AdjustColumnWidths();
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Remove all layers?"))
            {
                _layers.Clear();
            }
        }

        public IEnumerable<ILayerInfo> Layers
        {
            get { return _layers.Select(w => w.Source).ToList(); }
        }
    }
}
