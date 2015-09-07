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
    public class ParameterControlGenerator
    {
        private readonly ParameterControlFactory _factory;
        private readonly EventManager _manager = new EventManager();

        public ParameterControlGenerator(ParameterControlFactory factory)
        {
            if (factory == null) throw new ArgumentNullException();

            _factory = factory;
            ShowSections = true;
        }

        public EventManager EventManager
        {
            get { return _manager; }
        }

        private bool ShowSections { get; set; }

        public void Generate(Control panel, string sectionName, IEnumerable<BaseParameter> parameters, bool batchMode = false)
        {
            var list = parameters.OrderByDescending(p => p.Index).ToList();

            if (!list.Any())
            {
                return ;
            }

            GenerateControls(panel, list, batchMode);

            GenerateHeader(sectionName, panel);
        }

        public void AddVerticalPadding(IEnumerable<Control> panels)
        {
            foreach (var panel in panels)
            {
                AddVerticalPadding(panel);
            }
        }

        private void AddVerticalPadding(Control panel)
        {
            foreach (var ctrl in panel.Controls.Cast<Control>().Where(c => !(c is BooleanParameterControl)))
            {
                ctrl.Height += 10;
                ctrl.Padding = new Padding(0, 10, 0, 0);
            }
        }

        private void GenerateControls(Control panel, IEnumerable<BaseParameter> parameters, bool batchMode)
        {
            foreach (var p in parameters)
            {
                var ctrl = _factory.CreateControl(p, batchMode);
                if (ctrl != null)
                {
                    ctrl.SetCaption(p.DisplayName);
                    ctrl.Dock = DockStyle.Top;
                    p.Control = ctrl;

                    panel.Controls.Add(ctrl);

                    _manager.AddControl(ctrl);
                }
            }
        }

        private void GenerateHeader(string sectionName, Control panel)
        {
            if (ShowSections)
            {
                var section = new ConfigPanelControl { HeaderText = sectionName, Dock = DockStyle.Top };
                section.ShowCaptionOnly();
                panel.Controls.Add(section);
            }
        }
    }
}