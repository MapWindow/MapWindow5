using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Controls.Parameters.Interfaces;
using MW5.Tools.Model.Layers;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Allows to choose group operations for fields of vector datasource.
    /// </summary>
    public partial class FieldOperationParameterControl : ParameterControlBase, IInputListener
    {
        private readonly BindingList<FieldOperationGridAdapter> _fields = new BindingList<FieldOperationGridAdapter>();
        private IFeatureSet _featureSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldOperationParameterControl"/> class.
        /// </summary>
        public FieldOperationParameterControl()
        {
            InitializeComponent();
            _fields.ListChanged += (s, e) => RefreshControls();

            fieldOperationGrid1.TableControlPushButtonClick += OnTableControlPushButtonClick;
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
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return fieldOperationGrid1; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>Value type that must match the type of parameter the control was generated for.</returns>
        public override object GetValue()
        {
            var list = new FieldOperationList();

            foreach (var f in _fields)
            {
                list.AddFieldName(f.Field.Name, f.GroupOperation);
            }

            return list;
        }

        /// <summary>
        /// Sets the value. 
        /// </summary>
        /// <param name="value">Value type must match the type of parameter the control was generated for.</param>
        public override void SetValue(object value)
        {
            // do nothing
        }

        /// <summary>
        /// Assigns list of fields from particular vector datasource.
        /// </summary>
        public void OnLayerChanged(IDatasourceInput input)
        {
            // let the exception be thrown, we are supposed to have only vector datasouce at this stage
            _featureSet = (input as IVectorInput).Datasource;

            // we can try to preserve the fields that are also present in new datasource            
            _fields.Clear();

            fieldOperationGrid1.DataSource = _fields;
            fieldOperationGrid1.UpdateFieldCombo(_featureSet);

            RefreshControls();
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            if (_featureSet.Fields.Any())
            {
                var f = new FieldOperationGridAdapter(_featureSet.Fields.FirstOrDefault());
                _fields.Add(f);
            }
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            if (MessageService.Current.Ask("Remove all group operations?"))
            {
                _fields.Clear();
            }
        }

        private void OnTableControlPushButtonClick(object sender, GridTableControlCellPushButtonClickEventArgs e)
        {
            int index = fieldOperationGrid1.Adapter.RowIndexToRecordIndex(e.Inner.RowIndex);
            var field = fieldOperationGrid1.Adapter[index];
            if (field != null)
            {
                if (MessageService.Current.Ask("Remove group operation?"))
                {
                    _fields.Remove(field);
                }
            }
        }

        private void RefreshControls()
        {
            btnAdd.Enabled = _featureSet != null && _featureSet.Fields.Any();
            btnClear.Enabled = _fields.Any();
        }

        private void OnAddAllClick(object sender, EventArgs e)
        {
            if (!MessageService.Current.Ask("Generate group operations for all numeric fields?"))
            {
                return;
            }

            _fields.Clear();

            var operations = new[] { GroupOperation.Sum, GroupOperation.Avg };
            var list = _featureSet.Fields.Where(f => f.Type != AttributeType.String);
                
            foreach (var field in list)
            {
                foreach (var op in operations)
                {
                    var item = new FieldOperationGridAdapter(field) { GroupOperation = op };
                    _fields.Add(item);
                }
            }
        }
    }
}
