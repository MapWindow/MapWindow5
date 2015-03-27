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
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms;

namespace MW5.Services.Views
{
    public partial class CreateLayerView : MapWindowView, ICreateLayerView
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

            _okButton.Click += (s, e) => FireOkClicked();
        }

        public void UpdateView()
        {
            
        }

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
            get
            {
                if (optM.Checked)
                {
                    return ZValueType.M;
                }
                if (optZ.Checked)
                {
                    return ZValueType.Z;
                }
                return ZValueType.None;
            }
            set
            {
                switch (value)
                {
                    case ZValueType.M:
                        optM.Checked = true;
                        break;
                    case ZValueType.Z:
                        optZ.Checked = true;
                        break;
                    case ZValueType.None:
                        opt2D.Checked = true;
                        break;
                }
            }
        }
    }


}
