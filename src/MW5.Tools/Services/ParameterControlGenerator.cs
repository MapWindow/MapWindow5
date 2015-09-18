// -------------------------------------------------------------------------------------------
// <copyright file="ParameterControlGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Parameters;
using MW5.UI.Controls;

namespace MW5.Tools.Services
{
    /// <summary>
    /// Generates controls for tool parameters and optinally adds them to the specified UI container.
    /// </summary>
    public class ParameterControlGenerator
    {
        private readonly ParameterControlFactory _factory;
        private readonly EventManager _manager = new EventManager();

        public ParameterControlGenerator(ParameterControlFactory factory)
        {
            if (factory == null) throw new ArgumentNullException();

            _factory = factory;
        }

        /// <summary>
        /// Gets the event manager holding all the generated controls.
        /// </summary>
        public EventManager EventManager
        {
            get { return _manager; }
        }

        /// <summary>
        /// Generates controls for parameters and adds them to the specified panel.
        /// </summary>
        public void GenerateIntoPanel(Control panel, string sectionName, IEnumerable<BaseParameter> parameters, bool batchMode = false)
        {
            var list = parameters.OrderByDescending(p => p.Index).ToList();

            if (!list.Any())
            {
                return ;
            }

            GenerateIntoPanel(panel, list, batchMode);

            GenerateHeader(sectionName, panel);
        }

        /// <summary>
        /// Generates controls for parameters without adding them to any form or panel
        /// </summary>
        public void GenerateControls(IEnumerable<BaseParameter> parameters, bool batchMode)
        {
            foreach (var p in parameters)
            {
                GenerateControl(p, batchMode);
            }
        }

        /// <summary>
        /// Generates the controls into panel.
        /// </summary>
        private void GenerateIntoPanel(Control panel, IEnumerable<BaseParameter> parameters, bool batchMode)
        {
            foreach (var p in parameters)
            {
                var ctrl = GenerateControl(p, batchMode);

                if (ctrl != null)
                {
                    panel.Controls.Add(ctrl);

                    // value changed handler will be assigned here
                    _manager.AddControl(ctrl);
                }
            }
        }

        /// <summary>
        /// Generates the control.
        /// </summary>
        private ParameterControlBase GenerateControl(BaseParameter parameter, bool batchMode)
        {
            var ctrl = _factory.CreateControl(parameter, batchMode);
            ctrl.SetCaption(parameter.DisplayName);
            ctrl.Dock = DockStyle.Top;
            parameter.Control = ctrl;
            return ctrl;
        }

        /// <summary>
        /// Generates a header for a section of tool dialog.
        /// </summary>
        private void GenerateHeader(string sectionName, Control panel)
        {
            var section = new ConfigPanelControl { HeaderText = sectionName, Dock = DockStyle.Top };
            section.ShowCaptionOnly();
            panel.Controls.Add(section);
        }
    }
}