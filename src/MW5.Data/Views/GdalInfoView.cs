using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Data.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Data.Views
{
    public partial class GdalInfoView : GdalInfoViewBase, IGdalInfoView
    {
        public GdalInfoView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            Text = "Datasource info: " + Path.GetFileName(Model.Filename);
        }

        public void SetDescription(string description)
        {
            richTextBox1.Text = description;
        }

        public override Plugins.Mvp.ViewStyle Style
        {
            get { return new Plugins.Mvp.ViewStyle(true); }
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }
    }

    public partial class GdalInfoViewBase : MapWindowView<GdalInfoModel> { }
}
