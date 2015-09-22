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
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Model.Layers;
using MW5.UI.Helpers;

namespace MW5.Tools.Controls.Parameters.Input
{
    /// <summary>
    /// Represents listbox like control for selection of multiple datasource for batch mode processing.
    /// </summary>
    [TypeDescriptionProvider(typeof(ReplaceControlDescripterProvider<InputParameterControlBase, UserControl>))]
    internal partial class BatchLayerParameterControl : InputParameterControlBase 
    {
        private readonly ISelectLayerService _layerService;
        private readonly BindingList<InputLayerGridAdapter> _layers = new BindingList<InputLayerGridAdapter>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchLayerParameterControl"/> class.
        /// </summary>
        public BatchLayerParameterControl(ISelectLayerService layerService)
        {
            if (layerService == null) throw new ArgumentNullException("layerService");
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
        /// Gets a value indicating whether control allows selection of multiple files (batch mode).
        /// </summary>
        public override bool BatchMode 
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
            AddLayers(_layerService.Select(_dataType).Select(l => new InputLayerGridAdapter(l)));
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

            if (_dialogService.OpenFiles(_dataType, out filenames))
            {
                AddLayers(filenames.Select(f => new InputLayerGridAdapter(f)));
            }
        }
    }
}