using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Plugins.Mvp;
using MW5.UI.Forms;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public partial class DriversView : DriversViewBase, IDriversView
    {
        public DriversView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            driversGrid1.DataSource = Model.OrderBy(d => d.Description).ToList();
        }

        public override ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                {
                    Modal = true,
                    Sizable = true
                };
            }
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }
    }

    public class DriversViewBase : MapWindowView<DriverManager> { }
}
