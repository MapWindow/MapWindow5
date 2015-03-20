using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Properties;

namespace MW5.Plugins.Symbology.Helpers
{
    internal static class Globals
    {
        private static IAppContext _context;

        internal static ColorSchemeProvider LayerColors;
        
        internal static ColorSchemeProvider ChartColors;

        /// <summary>
        /// Static constructor for Globals class
        /// </summary>
        static Globals()
        {
            LayerColors = new ColorSchemeProvider(ColorSchemeType.Layer);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Resources.colorschemes);
            LayerColors.LoadXml(doc);
        }

        internal static void Init(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        internal static IMessageService Message
        {
            get { return _context.Container.GetSingleton<IMessageService>(); }
        }

        /// <summary>
        /// Returns descriptions of the standard types of symbology (random and default)
        /// </summary>
        internal static string GetSymbologyDescription(SymbologyType symbologyType)
        {
            string s = "";
            if (symbologyType == SymbologyType.Default)
            {
                s = "Default options stored in the .mwsymb or .mwsr files";
            }
            else if (symbologyType == SymbologyType.Random)
            {
                s = "Options set randomly by MapWinGIS ActiveX control";
            }
            return s;
        }

        /// <summary>
        /// Build list of available options for the layer (.mwsymb, .mwsr files)
        /// </summary>
        internal static void FillSymbologyList(ListView listView, string filename, bool manager, ref bool noEvents)
        {
            noEvents = true;
            listView.Items.Clear();

            // always available
            if (!manager)
            {
                ListViewItem item = listView.Items.Add("[random]");
                item.Tag = SymbologyType.Random;
            }

            string path = filename + ".mwsymb";
            if (File.Exists(path))
            {
                ListViewItem item = listView.Items.Add("[default]");
                item.Tag = SymbologyType.Default;
            }

            // cities.shp.default.mwsymb
            path = Path.GetDirectoryName(filename);
            string[] names = Directory.GetFiles(path, Path.GetFileName(filename) + "*");
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower().EndsWith(".mwsymb"))
                {
                    string name = names[i].Substring(filename.Length);
                    if (name.ToLower() == ".mwsymb")
                    {
                        // was added before
                    }
                    else
                    {
                        name = name.Substring(1, name.Length - 8);
                        ListViewItem item = listView.Items.Add(name);
                        item.Tag = SymbologyType.Custom;
                    }
                }
            }

            if (listView.Items.Count > 0)
                listView.SelectedIndices.Add(0);
            noEvents = false;
        }

        private static Dictionary<int, SymbologySettings> _settings = new Dictionary<int, SymbologySettings>();

        #region Obsolete
        internal static SymbologySettings get_LayerSettings(int layerHandle)
        {
            
            // TODO: restore
            //SymbologySettings settings = null;
            //MWLite.Symbology.Layer layer = Legend.GetLayer(layerHandle);
            //if (layer != null)
            //{
            //    settings = (SymbologySettings)layer.GetCustomObject("SymbologyPluginSettings");
            //}
            if (_settings.ContainsKey(layerHandle))
            {
                return _settings[layerHandle];
            }
            else
            {
                var settings = new SymbologySettings();
                _settings[layerHandle] = settings;
                return settings;
            }
        }

        /// <summary>
        /// Saves symbology settings for the layer
        /// </summary>
        internal static void SaveLayerSettings(int layerHandle, SymbologySettings settings)
        {
            // TODO: restore
            //MWLite.Symbology.Layer layer = Legend.GetLayer(layerHandle);
            //if (layer != null)
            //{
            //    layer.SetCustomObject(settings, "SymbologyPluginSettings");
            //}
        }

        internal static void SaveLayerOptions(int LayerHandle)
        {
            // TODO: restore
            //if (mapWin.ApplicationInfo.SymbologyLoadingBehavior == MapWindow.Interfaces.SymbologyBehavior.DefaultOptions)
            //{
            //    AxMapWinGIS.AxMap map = Globals.Map;
            //    if (map != null)
            //    {
            //        map.SaveLayerOptions(LayerHandle, "", true, "");
            //    }
            //}
        }
        #endregion

        // move files to the project resources
        #region Path
        /// <summary>
        /// Returns path to the default directory with icons
        /// </summary>
        internal static string GetIconsPath()
        {
            string filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //filename = Directory.GetParent(filename).FullName;
            return filename + "\\Styles\\Icons\\";
        }

        /// <summary>
        /// Returns path to the default directory with icons
        /// </summary>
        internal static string GetTexturesPath()
        {
            string filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            filename = Directory.GetParent(filename).FullName;
            return filename + "\\Styles\\Textures\\";
        }
        #endregion
    }

    #region Callbacks
    /// <summary>
    /// Implementation of callback interface to return progress information
    /// </summary>
    //internal class Callback : MapWinGIS.ICallback
    //{
    //    public void Error(string KeyOfSender, string ErrorMsg)
    //    {
    //        return;
    //    }
    //    public void Progress(string KeyOfSender, int Percent, string Message)
    //    {
    //        if (string.IsNullOrEmpty(Message)) {
    //            //MapWinUtility.Logger.Progress(Percent, 100);
    //        }
    //        else
    //            //MapWinUtility.Logger.Progress(Message, Percent, 100);
    //            Debug.Print("{0}: {1}", Message, Percent);
    //    }
    //    public void Clear()
    //    {
    //        //MapWinUtility.Logger.Progress("", 100, 100);
    //    }
    //}

    ///// <summary>
    ///// Implementation of callback interface to return progress information
    ///// </summary>
    //internal class CallbackLocal : MapWinGIS.ICallback
    //{
    //    ProgressBar _progress = null;
    //    public CallbackLocal(ProgressBar progress)
    //    {
    //        _progress = progress;
    //    }
    //    public void Error(string KeyOfSender, string ErrorMsg)
    //    {
    //        return;
    //    }
    //    public void Progress(string KeyOfSender, int Percent, string Message)
    //    {
    //        if (!_progress.Visible)
    //        {
    //            _progress.Visible = true;
    //        }
    //        _progress.Value = Percent;
    //        Application.DoEvents();
    //        if (Percent == 100)
    //        {
    //            this.Clear();
    //        }
    //    }
    //    public void Clear()
    //    {
    //        _progress.Value = 0;
    //        _progress.Visible = false;
    //        Application.DoEvents();
    //    }
    //}
    #endregion
}
