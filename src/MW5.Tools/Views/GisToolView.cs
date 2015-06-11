// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GisToolView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The gis tool view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Tools.Views
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;

    using MW5.Plugins.Interfaces;
    using MW5.Tools.Model;
    using MW5.Tools.Model.Parameters;
    using MW5.Tools.Views.Controls;
    using MW5.UI.Forms;

    #endregion

    /// <summary>
    /// The gis tool view.
    /// </summary>
    public partial class GisToolView : GisToolViewBase, IGisToolView
    {
        #region Constants

        private const int HorizontalPadding = 40;
        private const int VerticalPadding = 3;

        #endregion

        #region Fields

        private readonly IAppContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GisToolView"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public GisToolView(IAppContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;

            InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the ok button.
        /// </summary>
        public ButtonBase OkButton
        {
            get
            {
                return btnOk;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The generate controls.
        /// </summary>
        /// <param name="requiredParameters"></param>
        /// <param name="optionalParameters"></param>
        public void GenerateControls(IEnumerable<BaseParameter> requiredParameters, IEnumerable<BaseParameter> optionalParameters)
        {
            // Add controls to the panels:
            GenerateControlsOnPanel(panelRequired, requiredParameters);
            GenerateControlsOnPanel(panelOptional, optionalParameters);
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        public void Initialize()
        {
        }

        #endregion

        #region Methods

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

        #endregion
    }

    /// <summary>
    /// The gis tool view base.
    /// </summary>
    public class GisToolViewBase : MapWindowView<GisToolBase>
    {
    }
}