// -------------------------------------------------------------------------------------------
// <copyright file="WmsStyleView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Shared;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Views
{
    public partial class WmsStyleView : WmsStyleViewBase, IWmsStyleView
    {
        private readonly IAppContext _context;
        private static int _lastTabIndex = -1;

        public WmsStyleView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            InitControls();

            tabControl1.SelectedIndex = _lastTabIndex;

            FormClosed += (s, e) => _lastTabIndex = tabControl1.SelectedIndex;
        }

        private void InitControls()
        {
            cboVersion.AddItemsFromEnum<WmsVersion>();
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnProjection;
                yield return btnApply;
                yield return btnClearCache;
                yield return btnClearColorAdjustments;
            }
        }

        public void ApplyChanges()
        {
            var wms = Model.WmsSource;

            wms.Brightness = tbrBrightness.Value / 20.0f;
            wms.Contrast = tbrConstrast.Value / 20.0f;
            wms.Saturation = tbrSaturation.Value / 20.0f;
            wms.Hue = tbrHue.Value;
            wms.Gamma = tbrGamma.Value / 20.0f;
            wms.Opacity = (byte)tbrTransparency.Value;
            wms.UseTransparentColor = chkUseTransparentColor.Checked;
            wms.TransparentColor = clpTransparent.Color;

            wms.UseCache = chkUseCache.Checked;
            wms.DoCaching = chkDoCaching.Checked;

            wms.Version = cboVersion.GetValue<WmsVersion>();

            Model.Name = txtLayerName.Text;
            Model.Visible = chkLayerVisible.Checked;
            dynamicVisibilityControl1.ApplyChanges();
        }

        public void ClearColorAdjustments()
        {
            tbrBrightness.Value = 0;
            tbrConstrast.Value = 20;
            tbrSaturation.Value = 20;
            tbrHue.Value = 0;
            tbrGamma.Value = 20;
            tbrTransparency.Value = 255;
            chkUseTransparentColor.Checked = false;
            clpTransparent.Color = Color.White;
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            var wms = Model.WmsSource;

            txtInfo.Text = "Layers: " + wms.Layers;

            txtLayerName.Text = Model.Name;
            txtUrl.Text = wms.BaseUrl;
            txtProjection.Text = wms.Projection.Name;
            chkLayerVisible.Checked = Model.Visible;

            chkUseCache.Checked = wms.UseCache;
            chkDoCaching.Checked = wms.DoCaching;

            lblCacheId.Text = "Cache ID: " + wms.Id;

            double size = _context.Map.Tiles.get_CacheSize(CacheType.Disk, wms.Id);
            lblCacheSize.Text = string.Format("Disk cache size: {0} MB", size.ToString("0.0"));

            DisplayColorAdjustmentParameters(wms);

            DisplayRequestParameters(wms);

            dynamicVisibilityControl1.Initialize(Model, _context.Map.CurrentZoom, _context.Map.CurrentScale);
            //dynamicVisibilityControl1.ValueChanged += (s, e) => MarkStateChanged();
        }

        private void DisplayColorAdjustmentParameters(WmsSource wms)
        {
            tbrBrightness.SetValue(wms.Brightness * 20.0f);
            tbrConstrast.SetValue(wms.Contrast * 20.0f);
            tbrSaturation.SetValue(wms.Saturation * 20.0f);
            tbrHue.SetValue(wms.Hue);
            tbrGamma.SetValue(wms.Gamma * 20.0f);
            tbrTransparency.Value = wms.Opacity;
            chkUseTransparentColor.Checked = wms.UseTransparentColor;
            clpTransparent.Color = wms.TransparentColor;
        }

        private void DisplayRequestParameters(WmsSource wms)
        {
            cboVersion.SetValue(wms.Version);

            cboFormat.Items.Add(wms.Format);
            cboFormat.SelectedIndex = 0;

            cboLayers.Items.Add(wms.Layers);
            cboLayers.SelectedIndex = 0;

            cboSize.Items.Add("256 × 256");
            cboSize.SelectedIndex = 0;

            cboStyles.Items.Add("<empty>");
            cboStyles.SelectedIndex = 0;

            cboCrs.Items.Add(wms.Epsg > 0 ? "EPSG:" + wms.Epsg : "<not defined>");
            cboCrs.SelectedIndex = 0;
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtLayerName.Text))
            {
                MessageService.Current.Info("Empty layer name is not allowed.");
                return false;
            }

            return true;
        }
    }

    public class WmsStyleViewBase : MapWindowView<ILegendLayer> { }
}