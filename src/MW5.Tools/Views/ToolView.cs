// -------------------------------------------------------------------------------------------
// <copyright file="ToolView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;
using MW5.Tools.Services;
using MW5.Tools.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The gis tool view.
    /// </summary>
    public partial class ToolView : GisToolViewBase, IToolView
    {
        private readonly IAppContext _context;
        private readonly ParameterControlGenerator _generator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolView"/> class.
        /// </summary>
        public ToolView(IAppContext context, ParameterControlGenerator controlGenerator)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (controlGenerator == null) throw new ArgumentNullException("controlGenerator");

            _context = context;
            _generator = controlGenerator;

            InitializeComponent();

            panelOptional.Controls.Clear();

            panelRequired.Controls.Clear();
        }

        public override ViewStyle Style
        {
            get { return new ViewStyle()
                             {
                                 Modal = true,
                                 Sizable = true,
                             }; }
        }

        /// <summary>
        /// Gets the ok button.
        /// </summary>
        public ButtonBase OkButton
        {
            get { return btnRun; }
        }

        public bool RunInBackground
        {
            get { return chkBackground.Checked; }
        }

        /// <summary>
        /// Generates controls for parameters.
        /// </summary>
        public void GenerateControls()
        {
            var tool = Model.Tool as IParametrizedTool;
            if (tool == null)
            {
                throw new ApplicationException(
                    "Tool must support IParameterized tool interface for automatic UI generation.");
            }

            var parameters = tool.Parameters.ToList();

            if (Model.BatchMode)
            {
                _generator.Generate(panelRequired, "Output", parameters.Where(p => p is OutputLayerParameter), true);

                _generator.Generate(panelRequired, "Input", parameters.Where(p => p is LayerParameterBase), true);

                _generator.Generate(panelOptional, "Optional", parameters.Where(p => !p.Required && !p.HasDatasource), true);

                _generator.Generate(panelOptional, "Required", parameters.Where(p => p.Required && !p.HasDatasource), true);

                tabRequired.Text = "Input";

                tabOptional.Text = "Parameters";
            }
            else
            {
                _generator.Generate(panelRequired, "Output", parameters.Where(p => p is OutputLayerParameter));

                _generator.Generate(panelRequired, "Input", parameters.Where(p => p.Required && !(p is OutputLayerParameter)));

                _generator.Generate(panelOptional, "Optional", parameters.Where(p => !p.Required));
            }

            panelOptional.Visible = panelOptional.Controls.Count > 0;

            _generator.AddVerticalPadding(new List<Control>() { panelRequired, panelOptional });

            _generator.EventManager.Bind(tool.Configuration);
        }

        public void Initialize()
        {
            chkBackground.Visible = !Model.BatchMode;
            chkBackground.Checked =  AppConfig.Instance.TaskRunInBackground;

            var tool = Model.Tool;

            Text = tool.Name;

            webBrowser1.DocumentText = tool.LoadManual();
        }

        public override void BeforeClose()
        {
            AppConfig.Instance.TaskRunInBackground = chkBackground.Checked;
        }

        private void OnCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class GisToolViewBase : MapWindowView<ToolViewModel>
    {
    }
}