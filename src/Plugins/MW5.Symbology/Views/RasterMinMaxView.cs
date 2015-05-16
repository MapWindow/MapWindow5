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
        private static MinMaxCalculationType _lastType = MinMaxCalculationType.Precise;

        public RasterMinMaxView()
        {
            InitializeComponent();

            CalculationType = _lastType;

            FormClosed += (s, e) => _lastType = CalculationType;
        }

        public void Initialize()
        {
            //optPrecise.Checked = Model.CalculationType == MinMaxCalculationType.Precise;
            //optRange.Checked = Model.CalculationType == MinMaxCalculationType.PercentRange;
            //optStdDev.Checked = Model.CalculationType == MinMaxCalculationType.StdDev;

            txtRangeMin.DoubleValue = Model.RangeLowPercent;
            txtRangeMax.DoubleValue = Model.RangeHightPercent;
            txtStdDev.DoubleValue = Model.StdDevRange;
        }

        private MinMaxCalculationType CalculationType
        {
            get
            {
                if (optPrecise.Checked)
                {
                    return MinMaxCalculationType.Precise;
                }

                if (optRange.Checked)
                {
                    return MinMaxCalculationType.PercentRange;
                }

                if (optStdDev.Checked)
                {
                    return MinMaxCalculationType.StdDev;
                }

                return MinMaxCalculationType.Precise;
            }

            set
            {
                optPrecise.Checked = value == MinMaxCalculationType.Precise;
                optRange.Checked = value == MinMaxCalculationType.PercentRange;
                optStdDev.Checked = value == MinMaxCalculationType.StdDev;
            }
        }

        public void UiToModel()
        {
            Model.CalculationType = CalculationType;
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
