using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Views
{
    public partial class HistogramOptionsView : HistogramOptionsViewBase, IHistogramOptionsView
    {
        public HistogramOptionsView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            txtMin.DoubleValue = Model.Mimimum;
            txtMax.DoubleValue = Model.Maximum;

            if (Model.NumBuckets > udNumberBuckets.Value)
            {
                udNumberBuckets.Value = Model.NumBuckets;
            }

            udNumberBuckets.Value = Model.NumBuckets;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public override void BeforeClose()
        {
            Model.Mimimum = txtMin.DoubleValue;
            Model.Maximum = txtMax.DoubleValue;
            Model.NumBuckets = (int) udNumberBuckets.Value;
        }
    }

    public class HistogramOptionsViewBase : MapWindowView<HistogramOptionsModel> { }
}
