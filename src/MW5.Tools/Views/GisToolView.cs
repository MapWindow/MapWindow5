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
using MW5.Plugins.Services;
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
        private readonly ParameterControlFactory _controlFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GisToolView"/> class.
        /// </summary>
        public GisToolView(IAppContext context, ParameterControlFactory controlFactory)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (controlFactory == null) throw new ArgumentNullException("controlFactory");

            _context = context;
            _controlFactory = controlFactory;

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
        /// Generates controls for parameters.
        /// </summary>
        public void GenerateControls(IEnumerable<BaseParameter> parameters)
        {
            parameters = parameters.ToList();

            GenerateControlsWithinPanel(panelRequired, parameters.Where(p => p.Required));

            if (parameters.All(p => p.Required))
            {
                tabOptional.TabVisible = false;
            }
            else
            {
                GenerateControlsWithinPanel(panelOptional, parameters.Where(p => !p.Required));
            }
        }

        public void Initialize()
        {
            Text = Model.Name;
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

        private void GenerateControlsWithinPanel(Control panel, IEnumerable<BaseParameter> parameters)
        {
            panel.Controls.Clear();

            foreach (var p in parameters.OrderByDescending(p => p.Index))
            {
                var ctrl = _controlFactory.CreateControl(p);
                if (ctrl == null) continue;

                ctrl.Caption = p.DisplayName;
                p.Control = ctrl as ParameterControlBase;

                var userControl = ctrl as UserControl;
                if (userControl == null)
                {
                    throw new InvalidCastException("IParameterControl must be implemented by class derived from UserControl.");
                }

                userControl.Dock = DockStyle.Top;
                panel.Controls.Add(userControl);
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