// -------------------------------------------------------------------------------------------
// <copyright file="GisToolView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Views.Controls;
using MW5.UI.Forms;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The gis tool view.
    /// </summary>
    public partial class GisToolView : GisToolViewBase, IGisToolView
    {
        private const int HorizontalPadding = 40;
        private const int VerticalPadding = 3;

        private readonly IAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GisToolView"/> class.
        /// </summary>
        public GisToolView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

            InitializeComponent();
        }

        /// <summary>
        /// Gets the ok button.
        /// </summary>
        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        /// <summary>
        /// The generate controls.
        /// </summary>
        /// <param name="parameters"></param>
        public void GenerateControls(IEnumerable<BaseParameter> parameters)
        {
            parameters = parameters.ToList();

            GenerateControlsOnPanel(panelRequired, parameters.Where(p => p.Required));
            GenerateControlsOnPanel(panelOptional, parameters.Where(p => !p.Required));
        }

        public void Initialize()
        {
        }

        private static void AdjustVerticalPadding(Control panel)
        {
            foreach (Control ctrl in panel.Controls)
            {
                if (!(ctrl is BooleanParameterControl))
                {
                    ctrl.Height += 10;
                }
            }
        }

        private static void GenerateControlsOnPanel(Control panel, IEnumerable<BaseParameter> parameters)
        {
            panel.Controls.Clear();
            foreach (var parameter in parameters.OrderByDescending(p => p.Index))
            {
                var ctrl = parameter.CreateControl() as Control;

                if (ctrl == null || parameter.DisplayName == null)
                {
                    continue;
                }

                ctrl.Dock = DockStyle.Top;
                var paramControl = (IParameterControl)ctrl;
                paramControl.Caption = parameter.DisplayName;

                panel.Controls.Add(ctrl);
            }

            AdjustVerticalPadding(panel);
        }
    }

    /// <summary>
    /// The gis tool view base.
    /// </summary>
    public class GisToolViewBase : MapWindowView<GisToolBase>
    {
    }
}