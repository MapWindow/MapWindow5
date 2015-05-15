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
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Views
{
    public partial class RasterColorSchemeView : RasterColorSchemeViewBase, IRasterColorSchemeView
    {
        private BindingList<RasterInterval> _intervals;

        public RasterColorSchemeView()
        {
            InitializeComponent();
            rasterColorSchemeGrid1.Extended = true;
            rasterColorSchemeGrid1.Adapter.ReadOnly = false;
            rasterColorSchemeGrid1.ShowDropDowns(true);
        }

        public override ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                {
                    Modal = true,
                    Sizable = true,
                };
            }
        }

        public void Initialize()
        {
            _intervals = Model != null ? new BindingList<RasterInterval>(Model.ToList()) : null;
            rasterColorSchemeGrid1.DataSource = _intervals;
        }

        public BindingList<RasterInterval> Intervals
        {
            get { return _intervals; }
        }

        public RasterInterval SelectedInterval
        {
            get { return rasterColorSchemeGrid1.Adapter.SelectedItem; }
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
                yield return btnAddInterval;
                yield return btnRemoveInterval;
                yield return btnClear;
            }
        }
    }

    public class RasterColorSchemeViewBase : MapWindowView<RasterColorScheme> { }
}
