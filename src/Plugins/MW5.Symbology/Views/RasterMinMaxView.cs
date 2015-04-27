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
        public event Action CalculateClicked;

        public RasterMinMaxView()
        {
            InitializeComponent();

            btnCalculate.Click += (s, e) => Invoke(CalculateClicked);
        }

        public void Initialize()
        {
            
        }

        public void UpdateView()
        {
            
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class RasterMinMaxViewBase : MapWindowView<IRasterSource> {  }
}
