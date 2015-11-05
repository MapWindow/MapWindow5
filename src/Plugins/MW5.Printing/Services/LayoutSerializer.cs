using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Shared;

namespace MW5.Plugins.Printing.Services
{
    /// <summary>
    /// Serializes / deserializes the state of the layout.
    /// </summary>
    internal class LayoutSerializer
    {
        /// <summary>
        /// Saves the layout.
        /// </summary>
        public bool SaveLayout(LayoutControl layoutControl, PrinterSettings settings, string filename)
        {
            var serializer = new LayoutSerializer();
            string s = serializer.Serialize(layoutControl, settings);

            try
            {
                File.WriteAllText(filename, s);

                return true;
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to save printing layout.", ex);
            }

            return false;
        }

        public bool LoadLayout(IAppContext context, LayoutControl layoutControl, string filename, IEnvelope extents)
        {
            var layout = ReadLayout(filename);

            if (layout == null) return false;

            ApplyLayout(layoutControl, layout);

            InitializeElements(context, layoutControl);

            if (extents != null)    
            {
                layoutControl.UpdateMapElement(extents);
            }

            layoutControl.Filename = filename;

            return true;
        }

        private void InitializeElements(IAppContext context, LayoutControl layoutControl)
        {
            // TODO: choose particular map element
            var mapEl = layoutControl.LayoutElements.OfType<LayoutMap>().FirstOrDefault();

            foreach (var el in layoutControl.LayoutElements)
            {
                switch (el.Type)
                {
                    case Enums.ElementType.Map:
                        var map = el as LayoutMap;
                        if (map != null)
                        {
                            map.Initialize(context.Map);
                        }
                        break;
                    case Enums.ElementType.Legend:
                        var legend = el as LayoutLegend;
                        if (legend != null)
                        {
                            legend.Initialize(layoutControl, context.Legend);
                            legend.Map = mapEl;
                        }
                        break;

                    case Enums.ElementType.ScaleBar:
                        var scaleBar = el as LayoutScaleBar;
                        if (scaleBar != null)
                        {
                            scaleBar.LayoutControl = layoutControl;
                            scaleBar.Map = mapEl;
                        }
                        break;
                }
            }

            foreach (var el in layoutControl.LayoutElements)
            {
                el.Initialized = true;
            }
        }

        private void ApplyLayout(LayoutControl layoutControl, XmlLayout layout)
        {
            layoutControl.ClearLayout();
            layoutControl.LayoutElements.AddRange(layout.Elements);

            // TODO: apply paper size
            var page = layoutControl.PrinterSettings.DefaultPageSettings;        
        }

        private XmlLayout ReadLayout(string filename)
        {
            try
            {
                string xml = File.ReadAllText(filename);
                return Deserialize(xml);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to load printing layout.", ex);
            }

            return null;
        }

        private string Serialize(LayoutControl layout, PrinterSettings settings)
        {
            var xml = new XmlLayout();

            xml.PaperFormat.PaperName = settings.DefaultPageSettings.PaperSize.PaperName;

            xml.Elements.AddRange(layout.LayoutElements);

            return xml.Serialize(GetKnownTypes(), false);
        }

        private XmlLayout Deserialize(string xml)
        {
            return xml.Deserialize(typeof(XmlLayout), GetKnownTypes()) as XmlLayout;
        }

        private IEnumerable<Type> GetKnownTypes()
        {
            var list = Assembly.GetAssembly(GetType()).GetDerivedTypes(typeof(LayoutElement)).ToList();

            // DataContract serializer doesn't automatically include types for properties of
            // nested classes like Font, therefore we do it manually
            list.Add(typeof(System.Drawing.FontStyle));
            list.Add(typeof(System.Drawing.GraphicsUnit));

            return list;
        }
    }
}
