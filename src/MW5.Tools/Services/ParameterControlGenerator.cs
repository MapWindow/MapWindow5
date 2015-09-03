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
        private readonly List<ParameterControlBase> _controls = new List<ParameterControlBase>();
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

        public void Generate(Control panel, IEnumerable<BaseParameter> parameters, bool optional)
        {
            panel.Controls.Clear();

            var list = parameters.OrderByDescending(p => p.Index).ToList();

            GenerateOutput(panel, list, optional);

            GenerateInput(panel, list, optional);

            AddVerticalPadding(panel);
        }

        private void GenerateOutput(Control panel, List<BaseParameter> list, bool optional)
        {
            // output parameters
            var arr = list.Where(p => p is OutputLayerParameter).ToList();
            GenerateSection(panel, arr);

            if (arr.Any())
            {
                AddSection("Output", panel);
            }
        }

        private void GenerateInput(Control panel, List<BaseParameter> list, bool optional)
        {
            // input parameters
            var arr = list.Where(p => !(p is OutputLayerParameter)).ToList();
            GenerateSection(panel, arr);

            if (!optional && arr.Any())
            {
                AddSection("Input", panel);
            }
        }

        private void AddSection(string sectionName, Control panel)
        {
            if (ShowSections)
            {
                var section = new ConfigPanelControl { HeaderText = sectionName, Dock = DockStyle.Top };
                section.ShowCaptionOnly();
                panel.Controls.Add(section);
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

        private void GenerateSection(Control panel, IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters)
            {
                var ctrl = _factory.CreateControl(p);
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
    }
}