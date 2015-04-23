using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Views.Controls;
using MW5.UI.Forms;
using Syncfusion.Windows.Forms;

namespace MW5.Tools.Views
{
    public partial class GisToolView: GisToolViewBase, IGisToolView
    {
        private readonly IAppContext _context;
        private const int HorizontalPadding = 40;
        private const int VerticalPadding = 3;

        public GisToolView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();
        }

        public void Initialize()
        {
            
        }

        public void GenerateControls(IEnumerable<BaseParameter> parameters)
        {
            panelRequired.Controls.Clear();

            foreach (var p in parameters.OrderByDescending(p => p.Index))
            {
                var ctrl = p.CreateControl() as Control;

                if (ctrl != null)
                {
                    ctrl.Dock = DockStyle.Top;
                    var paramControl = (IParameterControl) ctrl;
                    paramControl.Caption = p.DisplayName;
                    panelRequired.Controls.Add(ctrl);
                }
            }

            AdjustVerticalPadding();
        }

        private void AdjustVerticalPadding()
        {
            foreach (Control ctrl in panelRequired.Controls)
            {
                if (!(ctrl is BooleanParameterControl))
                {
                    ctrl.Height += 10;
                }
            }
        }

        public void UpdateView()
        {
            
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class GisToolViewBase:  MapWindowView<GisToolBase> { }
}
