using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Services.Controls;
using MW5.Services.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Services.Views
{
    public partial class MissingLayersView : MissingLayersViewBase, IMissingLayersView
    {
        public MissingLayersView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            missingLayersGrid1.DataSource = Model;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class MissingLayersViewBase: MapWindowView<List<MissingLayer>> { }
}
