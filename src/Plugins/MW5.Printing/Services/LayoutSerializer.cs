// -------------------------------------------------------------------------------------------
// <copyright file="LayoutSerializer.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Helpers;
using MW5.Plugins.Printing.Model.Elements;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins.Printing.Services
{
    /// <summary>
    /// Serializes / deserializes the state of the layout.
    /// </summary>
    internal class LayoutSerializer
    {
        public static XmlLayoutBase DeserializeLite(string xml)
        {
            return xml.Deserialize(typeof(XmlLayoutBase), null) as XmlLayoutBase;
        }

        /// <summary>
        /// Loads layout from file without saving changes to the existing one.
        /// </summary>
        public bool LoadLayout(
            IAppContext context,
            LayoutControl layoutControl,
            string filename,
            IEnvelope extents,
            PrinterSettings settings)
        {
            var layout = ReadLayout(filename);

            if (layout == null) return false;

            ApplyLayout(layoutControl, layout, settings);

            InitializeElements(context, layoutControl);

            if (extents != null)
            {
                UpdateMapElement(layoutControl, extents);
            }

            layoutControl.Filename = filename;

            layoutControl.ZoomFitToScreen();

            return true;
        }

        /// <summary>
        /// Loads layout, prompting to save changes to the exiting one if needed.
        /// </summary>
        public void LoadNewLayout(
            LayoutControl layoutControl,
            IAppContext context,
            IEnvelope extents,
            IWin32Window parent)
        {
            if (!PromptToSaveChanges(layoutControl, parent))
            {
                return;
            }

            string filename = GetLoadFilename(parent);
            if (string.IsNullOrWhiteSpace(filename))
            {
                return;
            }

            var serializer = new LayoutSerializer();

            var settings = layoutControl.PrinterSettings;

            if (serializer.LoadLayout(context, layoutControl, filename, extents, settings))
            {
                MessageService.Current.Info("Layout was loaded successfully.");
            }
        }

        /// <summary>
        /// Promps user to save changes to the existing layout and does the saving if selected.
        /// </summary>
        public bool PromptToSaveChanges(LayoutControl layoutControl, IWin32Window parent)
        {
            var ls = new LayoutSerializer();

            if (ls.LayoutChanged(layoutControl, layoutControl.PrinterSettings, layoutControl.Filename))
            {
                var result = MessageService.Current.AskWithCancel("Do you want to save changes to the current layout?");

                switch (result)
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Yes:
                        ls.SaveLayout(layoutControl, false, parent, true);
                        break;
                    case DialogResult.No:
                        // do nothing
                        break;
                }
            }

            return true;
        }

        /// <summary>
        /// Saves the layout prompting using for a filename if needed.
        /// </summary>
        public bool SaveLayout(LayoutControl layoutControl, bool saveAs, IWin32Window parent, bool silent = false)
        {
            string filename = layoutControl.Filename;

            if (saveAs || string.IsNullOrWhiteSpace(filename))
            {
                filename = GetSaveFilename(parent);
            }

            if (string.IsNullOrWhiteSpace(filename))
            {
                return false;
            }

            var serializer = new LayoutSerializer();
            if (serializer.SaveLayout(layoutControl, layoutControl.PrinterSettings, filename))
            {
                if (!silent)
                {
                    MessageService.Current.Info("Layout was saved successfully.");
                }

                return true;
            }

            return false;
        }

        private void ApplyLayout(LayoutControl layoutControl, XmlLayout layout, PrinterSettings settings)
        {
            layoutControl.ClearLayout();
            layoutControl.AddToLayout(layout.Elements);

            layout.Paper.UpdatePageSettings(settings);
            layoutControl.UpdatePageSettings();

            layoutControl.Pages.Resize(layout.Paper.PageCountX, layout.Paper.PageCountY);
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
            list.Add(typeof(FontStyle));
            list.Add(typeof(GraphicsUnit));

            return list;
        }

        private string GetLoadFilename(IWin32Window parent)
        {
            using (var dlg = new OpenFileDialog { Filter = PrintingConstants.TemplateFilter })
            {
                if (dlg.ShowDialog(parent) == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }

            return string.Empty;
        }

        private LayoutMap GetMapByGuid(LayoutControl layoutControl, Guid guid)
        {
            return layoutControl.LayoutElements.OfType<LayoutMap>().FirstOrDefault(item => item.Guid == guid);
        }

        private string GetSaveFilename(IWin32Window parent)
        {
            using (var dlg = new SaveFileDialog { Filter = PrintingConstants.TemplateFilter })
            {
                dlg.InitialDirectory = ConfigPathHelper.GetLayoutPath();

                if (dlg.ShowDialog(parent) == DialogResult.OK)
                {
                    return dlg.FileName;
                }
            }

            return string.Empty;
        }

        private void InitializeElements(IAppContext context, LayoutControl layoutControl)
        {
            foreach (var el in layoutControl.LayoutElements)
            {
                switch (el.Type)
                {
                    case ElementType.Map:
                        var map = el as LayoutMap;
                        if (map != null)
                        {
                            map.Initialize(context.Map, layoutControl);
                        }
                        break;
                    case ElementType.Legend:
                        var legend = el as LayoutLegend;
                        if (legend != null)
                        {
                            legend.Initialize(layoutControl, context.Legend);
                            legend.Map = GetMapByGuid(layoutControl, legend.MapGuid);
                        }
                        break;
                    case ElementType.ScaleBar:
                        var scaleBar = el as LayoutScaleBar;
                        if (scaleBar != null)
                        {
                            scaleBar.LayoutControl = layoutControl;
                            scaleBar.Map = GetMapByGuid(layoutControl, scaleBar.MapGuid);
                        }
                        break;
                }
            }

            foreach (var el in layoutControl.LayoutElements)
            {
                el.Initialized = true;
            }
        }

        /// <summary>
        /// Checks for layout changes and returns true if they did occur.
        /// </summary>
        private bool LayoutChanged(LayoutControl layoutControl, PrinterSettings settings, string filename)
        {
            if (!File.Exists(filename))
            {
                return layoutControl.LayoutElements.Any();
            }

            try
            {
                string oldXml = File.ReadAllText(filename);

                string xml = Serialize(layoutControl, settings);

                return !xml.EqualsIgnoreCase(oldXml);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Errror on checking for layout changes.", ex);
            }

            return true;
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

        /// <summary>
        /// Saves the layout.
        /// </summary>
        private bool SaveLayout(LayoutControl layoutControl, PrinterSettings settings, string filename)
        {
            string s = Serialize(layoutControl, settings);

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

        private string Serialize(LayoutControl layout, PrinterSettings settings)
        {
            var xml = new XmlLayout();

            xml.Paper = new XmlPaper(settings.DefaultPageSettings, layout.Pages);

            xml.Elements.AddRange(layout.LayoutElements);

            return xml.Serialize(GetKnownTypes(), false);
        }

        /// <summary>
        /// Updates the extents of the map element taking into account its size of screen and scale.
        /// </summary>
        private void UpdateMapElement(LayoutControl layoutControl, IEnvelope extents)
        {
            var map = layoutControl.GetMainMap();

            if (map != null)
            {
                map.Envelope = extents;
                map.Initialized = true;

                layoutControl.ClearSelection();
                layoutControl.AddToSelection(map);
            }
        }
    }
}