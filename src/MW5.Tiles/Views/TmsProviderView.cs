using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Tiles.Model;
using MW5.Tiles.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Tiles.Views
{
    internal partial class TmsProviderView : TmsProviderViewBase, ITmsProviderView
    {
        public TmsProviderView()
        {
            InitializeComponent();

            InitControls();
        }

        private void InitControls()
        {
            cboProjection.AddItemsFromEnum<TileProjection>();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            txtId.IntegerValue = Model.Id;
            txtName.Text = Model.Name;
            txtUrl.Text = Model.Url;
            cboProjection.SetValue(Model.Projection);
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }
    }

    internal class TmsProviderViewBase: MapWindowView<TmsProvider> { }
}
