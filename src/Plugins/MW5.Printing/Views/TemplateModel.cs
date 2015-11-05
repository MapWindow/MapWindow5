// -------------------------------------------------------------------------------------------
// <copyright file="TemplateModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Helpers;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Model;
using MW5.Shared;

namespace MW5.Plugins.Printing.Views
{
    internal class TemplateModel
    {
        private TemplateModel()
        {
            Valid = true;
            Templates = new List<LayoutTemplate>();
        }

        public TemplateModel(PrintArea area)
            : this()
        {
            PrintArea = area;
            Extents = null;
        }

        public TemplateModel(IEnvelope extents)
            : this()
        {
            if (extents == null) throw new ArgumentNullException("extents");
            Extents = extents;
            PrintArea = PrintArea.Selection;
        }

        public IEnvelope Extents { get; set; }

        public int PageCountX { get; set; }

        public int PageCountY { get; set; }

        public string PaperFormat { get; set; }

        public Orientation PaperOrientation { get; set; }

        public PrintArea PrintArea { get; set; }

        public int Scale { get; set; }

        public string TemplateName { get; set; }

        public bool Valid { get; set; }

        public List<LayoutTemplate> Templates { get; private set;  }

        public bool HasTemplate
        {
            get { return !string.IsNullOrWhiteSpace(TemplateName); }
        }

        public void LoadTemplates(string path)
        {
            Templates.Clear();

            try
            {
                string[] names = Directory.GetFiles(path, "*.xml");

                foreach (var name in names)
                {
                    Templates.Add(new LayoutTemplate(name));
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to load layout templates: " + path, ex);
            }
        }
    }
}