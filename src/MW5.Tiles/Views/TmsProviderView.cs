using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Plugins.Model;
using MW5.Shared;
using MW5.Tiles.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;
using Action = System.Action;

namespace MW5.Tiles.Views
{
    internal partial class TmsProviderView : TmsProviderViewBase, ITmsProviderView
    {
        public TmsProviderView()
        {
            InitializeComponent();

            InitControls();

            btnChooseProjection.Click += (s, e) => Invoke(ChooseProjection);
        }

        private void InitControls()
        {
            cboProjection.AddItemsFromEnum<TileProjection>();
            InitZoomCombo(cboMinZoom);
            InitZoomCombo(cboMaxZoom);
        }

        private void InitZoomCombo(ComboBoxAdv combo)
        {
            combo.Items.Clear();

            for (int i = 0; i <= 25; i++)
            {
                combo.Items.Add(i);
            }
        }

        public override Plugins.Mvp.ViewStyle Style
        {
            get { return new Plugins.Mvp.ViewStyle(false); }
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            txtId.IntegerValue = Model.Id;
            txtName.Text = Model.Name;
            txtUrl.Text = Model.Url;

            cboMinZoom.SetValue(Model.MinZoom.ToString(CultureInfo.InvariantCulture));
            cboMaxZoom.SetValue(Model.MaxZoom.ToString(CultureInfo.InvariantCulture));

            cboProjection.SetValue(Model.Projection);
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public int Id
        {
            get { return (int)txtId.IntegerValue; }
        }

        public string Url
        {
            get { return txtUrl.Text; }
        }

        public string ProviderName
        {
            get { return txtName.Text; }
        }

        public TileProjection Projection
        {
            get { return cboProjection.GetValue<TileProjection>(); }
        }

        public int MinZoom
        {
            get { return GetZoom(cboMinZoom); }
        }

        public int MaxZoom
        {
            get { return GetZoom(cboMaxZoom); }
        }

        public event Action ChooseProjection;

        private int GetZoom(ComboBoxAdv combo)
        {
            int zoom;
            if (Int32.TryParse(combo.Text, out zoom))
            {
                return zoom;
            }

            return -1;
        }
    }

    internal class TmsProviderViewBase: MapWindowView<TmsProvider> { }
}
