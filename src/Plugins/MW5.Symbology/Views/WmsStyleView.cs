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
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Views
{
    public partial class WmsStyleView : WmsStyleViewBase, IWmsStyleView
    {
        private readonly IAppContext _context;
        private WmsSource _wmsSource;

        public WmsStyleView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            _wmsSource = Model.WmsSource;

            txtLayerName.Text = Model.Name;
            txtUrl.Text = _wmsSource.BaseUrl;
            txtProjection.Text = _wmsSource.Projection.Name;
            chkLayerVisible.Checked = Model.Visible;

            dynamicVisibilityControl1.Initialize(Model, _context.Map.CurrentZoom, _context.Map.CurrentScale);
            //dynamicVisibilityControl1.ValueChanged += (s, e) => MarkStateChanged();
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
            }
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

        public void ApplyChanges()
        {
            // TODO: allow to choose another layer
            Model.Name = txtLayerName.Text;
            Model.Visible = chkLayerVisible.Checked;
            dynamicVisibilityControl1.ApplyChanges();
        }
    }

    public class WmsStyleViewBase : MapWindowView<ILegendLayer> { }
}
