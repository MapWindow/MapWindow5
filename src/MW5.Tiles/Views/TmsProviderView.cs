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
        private static int _lastTabIndex = -1;

        public TmsProviderView()
        {
            InitializeComponent();

            InitControls();

            tabControlAdv1.SelectedIndex = _lastTabIndex;

            FormClosing += (s, e) => _lastTabIndex = tabControlAdv1.SelectedIndex;
        }

        private void InitControls()
        {
            cboProjection.AddItemsFromEnum<TileProjection>();
            InitZoomCombo(cboMinZoom);
            InitZoomCombo(cboMaxZoom);

            txtMinLat.DataBindings.Add("Enabled", chkBoundingBox, "Checked");
            txtMaxLat.DataBindings.Add("Enabled", chkBoundingBox, "Checked");
            txtMinLng.DataBindings.Add("Enabled", chkBoundingBox, "Checked");
            txtMaxLng.DataBindings.Add("Enabled", chkBoundingBox, "Checked");
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

            chkBoundingBox.Checked = Model.UseBounds;

            txtMinLat.DoubleValue = Model.Bounds.MinY;
            txtMaxLat.DoubleValue = Model.Bounds.MaxY;
            txtMinLng.DoubleValue = Model.Bounds.MinX;
            txtMaxLng.DoubleValue = Model.Bounds.MaxX;

            txtDescription.Text = Model.Description;

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

        public bool UseBounds
        {
            get { return chkBoundingBox.Checked; }
        }

        public double MinLat
        {
            get { return txtMinLat.DoubleValue; }
        }

        public double MaxLat
        {
            get { return txtMaxLat.DoubleValue; }
        }

        public double MinLng
        {
            get { return txtMinLng.DoubleValue; }
        }

        public double MaxLng
        {
            get { return txtMaxLng.DoubleValue; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
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
