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
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Views.Custom.Abstract;
using MW5.UI.Forms;

namespace MW5.Tools.Views.Custom
{
    public partial class RandomPointsView : RandomPointsViewBase, IRandomPointsView
    {
        private readonly IAppContext _context;

        public RandomPointsView(IAppContext context)
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
            var layers = _context.Layers.Where(l => l.LayerType == Api.Enums.LayerType.Shapefile).ToList();
            cboLayers.DataSource = layers;
        }

        public ButtonBase OkButton
        {
            get { return btnRun; }
        }

        public int NumPoints
        {
            get { return (int)txtNumPoints.IntegerValue; }
        }

        public ILayerSource Input
        {
            get
            {
                var layer = cboLayers.SelectedItem as ILayer;
                return layer != null ? layer.LayerSource : null;
            }
        }

        public string OutputName
        {
            get { return txtOutputName.Text; }
        }
    }

    public class RandomPointsViewBase : MapWindowView<ToolViewModel> { }
}
