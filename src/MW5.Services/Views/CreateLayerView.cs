using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api;
using MW5.Mvp;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms;

namespace MW5.Services.Views
{
    public partial class CreateLayerView : MapWindowForm, ICreateLayerView
    {
        public CreateLayerView(IAppContext context) : base(context)
        {
            InitializeComponent();

            var items = EnumHelper.GetComboItems(new[]
            {
                GeometryType.Point,
                GeometryType.Polyline,
                GeometryType.Polygon,
                GeometryType.MultiPoint,
            });

            foreach (var item in items)
            {
                _layerTypeComboBox.Items.Add(item);
            }
            _layerTypeComboBox.SetValue(GeometryType.Point);

            _okButton.Click += (s, e) => Invoke(OkClicked);
        }

        public void UpdateView()
        {
            
        }

        public event Action OkClicked;

        public string LayerName
        {
            get { return _layerNameTextbox.Text; }
            set { _layerNameTextbox.Text = value; }
        }

        public GeometryType GeometryType
        {
            get { return _layerTypeComboBox.GetValue<GeometryType>(); }
            set { _layerTypeComboBox.SetValue(value); }
        }

        public ZValueType ZValueType
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }

    public interface ICreateLayerView: IView
    {
        event Action OkClicked;
        string LayerName { get; set; }
        GeometryType GeometryType { get; set; }
        ZValueType ZValueType { get; set; }
    }
}
