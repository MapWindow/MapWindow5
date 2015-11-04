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

        public bool LoadLayout(LayoutControl layoutControl, string filename)
        {
            var layout = ReadLayout(filename);

            if (layout == null) return false;

            ApplyLayout(layoutControl, layout);

            layoutControl.Filename = filename;

            return true;
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
            var types = Assembly.GetAssembly(GetType()).GetDerivedTypes(typeof(LayoutElement)).ToList();
            types.Add(typeof(Envelope));
            return types;
        }
    }
}
