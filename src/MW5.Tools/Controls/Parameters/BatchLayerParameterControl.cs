// -------------------------------------------------------------------------------------------
// <copyright file="BatchLayerParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Controls.Parameters.Interfaces;
using MW5.Tools.Model.Layers;
using MW5.UI.Helpers;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents listbox like control for selection of multiple datasource for batch mode processing.
    /// </summary>
    internal partial class BatchLayerParameterControl : ParameterControlBase, IInputParameterControl
    {
        private readonly IFileDialogService _dialogService;
        private readonly ISelectLayerService _layerService;
        private readonly BindingList<InputLayerGridAdapter> _layers = new BindingList<InputLayerGridAdapter>();
        private DataSourceType _layerType = DataSourceType.All;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchLayerParameterControl"/> class.
        /// </summary>
        public BatchLayerParameterControl(IFileDialogService dialogService, ISelectLayerService layerService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            if (layerService == null) throw new ArgumentNullException("layerService");
            _dialogService = dialogService;
            _layerService = layerService;

            InitializeComponent();

            _inputLayerGrid1.DataSource = _layers;

            HideSelectedOnly();
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
        /// Gets list of selected layers.
        /// </summary>
        public IEnumerable<IDatasourceInput> Layers
        {
            get { return _layers.Select(w => w.Source).ToList(); }
        }

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return _inputLayerGrid1; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public override object GetValue()
        {
            return null;
        }

        /// <summary>
        /// Initializes control with the specified data source type.
        /// </summary>
        /// <param name="dataSourceType">Type of the data source.</param>
        public void Initialize(DataSourceType dataSourceType)
        {
            _layerType = dataSourceType;
        }

        /// <summary>
        /// Gets a value indicating whether control allows selection of multiple files (batch mode).
        /// </summary>
        public bool BatchMode 
        {
            get { return true; } 
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            throw new NotSupportedException("SetValue isn't supported.");
        }

        /// <summary>
        /// Adds layers to the control.
        /// </summary>
        private void AddLayers(IEnumerable<InputLayerGridAdapter> layers)
        {
            foreach (var item in layers)
            {
                _layers.Add(item);
            }

            _inputLayerGrid1.AdjustColumnWidths();
        }

        private void HideSelectedOnly()
        {
            panel1.Height = 0;
            panel1.Visible = false;
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            AddLayers(_layerService.Select(_layerType).Select(l => new InputLayerGridAdapter(l)));
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Remove all layers?"))
            {
                _layers.Clear();
            }
        }

        private void OnOpenClick(object sender, EventArgs e)
        {
            string[] filenames;

            if (_dialogService.OpenFiles(_layerType, out filenames))
            {
                AddLayers(filenames.Select(f => new InputLayerGridAdapter(f)));
            }
        }
    }
}