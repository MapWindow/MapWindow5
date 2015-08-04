// -------------------------------------------------------------------------------------------
// <copyright file="ParameterControlGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Model.Parameters;
using MW5.UI.Controls;

namespace MW5.Tools.Helpers
{
    internal static class ParameterControlGenerator
    {
        static ParameterControlGenerator()
        {
            ShowSections = true;
        }

        private static bool ShowSections { get; set; }

        public static void Generate(
            this Control panel,
            IEnumerable<BaseParameter> parameters,
            ParameterControlFactory factory,
            bool optional)
        {
            panel.Controls.Clear();

            var list = parameters.OrderByDescending(p => p.Index).ToList();

            var arr = list.Where(p => p is OutputLayerParameter).ToList();
            GenerateSection(panel, arr, factory);

            if (!optional && arr.Any())
            {
                AddSection("Output", panel);
            }

            arr = list.Where(p => !(p is OutputLayerParameter)).ToList();
            GenerateSection(panel, arr, factory);

            if (!optional && arr.Any())
            {
                AddSection("Input", panel);
            }

            AddVerticalPadding(panel);
        }

        private static void AddSection(string sectionName, Control panel)
        {
            if (ShowSections)
            {
                var section = new ConfigPanelControl { HeaderText = sectionName, Dock = DockStyle.Top };
                section.ShowCaptionOnly();
                panel.Controls.Add(section);
            }
        }

        private static void AddVerticalPadding(Control panel)
        {
            foreach (var ctrl in panel.Controls.Cast<Control>().Where(c => !(c is BooleanParameterControl)))
            {
                ctrl.Height += 10;
                ctrl.Padding = new Padding(0, 10, 0, 0);
            }
        }

        private static void GenerateSection(
            Control panel,
            IEnumerable<BaseParameter> parameters,
            ParameterControlFactory factory)
        {
            foreach (var p in parameters)
            {
                var ctrl = factory.CreateControl(p);
                if (ctrl != null)
                {
                    ctrl.SetCaption(p.DisplayName);
                    ctrl.Dock = DockStyle.Top;
                    p.Control = ctrl;

                    panel.Controls.Add(ctrl);
                }
            }
        }
    }
}