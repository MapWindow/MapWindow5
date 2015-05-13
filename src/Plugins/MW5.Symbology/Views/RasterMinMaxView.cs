using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterMinMaxView : RasterMinMaxViewBase, IRasterMinMaxView
    {
        public RasterMinMaxView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            optPrecise.Checked = Model.CalculationType == MinMaxCalculationType.Precise;
            optRange.Checked = Model.CalculationType == MinMaxCalculationType.PercentRange;
            optStdDev.Checked = Model.CalculationType == MinMaxCalculationType.StdDev;

            txtRangeMin.DoubleValue = Model.RangeLowPercent;
            txtRangeMax.DoubleValue = Model.RangeHightPercent;
            txtStdDev.DoubleValue = Model.StdDevRange;
        }

        public void UiToModel()
        {
            if (optPrecise.Checked)
            {
                Model.CalculationType = MinMaxCalculationType.Precise;
            }

            if (optRange.Checked)
            {
                Model.CalculationType = MinMaxCalculationType.PercentRange;
            }

            if (optStdDev.Checked)
            {
                Model.CalculationType = MinMaxCalculationType.StdDev;
            }

            Model.RangeLowPercent = txtRangeMin.DoubleValue;
            Model.RangeHightPercent = txtRangeMax.DoubleValue;
            Model.StdDevRange = txtStdDev.DoubleValue;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class RasterMinMaxViewBase : MapWindowView<RasterMinMaxModel> {  }
}
