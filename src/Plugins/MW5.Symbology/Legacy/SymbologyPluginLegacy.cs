using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology
{
    /// <summary>
    /// Implementation of IPlug-in interface
    /// </summary>
    //internal class SymbologyPlugin
    //{
    //    #region Member variables

    //    // The starting form of the plugin
    //    public MWLite.Symbology.Forms.SymbologyMainForm m_mainForm = null;

    //    // The handle of the main app window
    //    public int m_parentWindowHandle;

    //    // The name of toolbar to add to the MW. Temporary
    //    private const string TOOLBAR_NAME = "mwLabels";

    //    // Then name of the button
    //    private const string BUTTON_LABELS_MOVE = "Label Mover";

    //    // Then name of the button
    //    private const string BUTTON_QUERY_BUILDER = "Query";

    //    // Then name of the button
    //    private const string BUTTON_CATEGORIES = "Categories";

    //    // A flag showing whether label moving tool was selected
    //    private bool m_labelMovingMode = false;

    //    // The label being moved currently
    //    private LabelData m_CurrentLabel;

    //    // List of color schemes for layer
    //    public ColorSchemes LayerColors = null;

    //    // List of color schemes for charts
    //    public ColorSchemes ChartColors = null;

    //    #endregion

    //    public string get_MapWindowVersion()
    //    {
    //        Form mapForm = (Form)System.Windows.Forms.Control.FromHandle((System.IntPtr)m_parentWindowHandle);
    //        return System.Diagnostics.FileVersionInfo.GetVersionInfo(mapForm.GetType().Assembly.Location).FileVersion.ToString();
    //    }

    //    #region Plugin description
    //    public string Author
    //    {
    //        get { return "Sergei Leschinski"; }
    //    }

    //    public string BuildDate
    //    {
    //        get { return System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location).ToString(); }
    //    }

    //    public string Description
    //    {
    //        get { return "Provides functionality for setting visualization schemes for vector layers"; }
    //    }

    //    public string Name
    //    {
    //        get { return "MapWindow Symbology Plug-in"; }
    //    }

    //    public string SerialNumber
    //    {
    //        get { return ""; }
    //    }

    //    public string Version
    //    {
    //        get
    //        {
    //            string major = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMajorPart.ToString();
    //            string minor = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMinorPart.ToString();
    //            string build = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileBuildPart.ToString();

    //            return major + "." + minor + "." + build;
    //        }
    //    }
    //    #endregion

    //    /// <summary>
    //    /// Plugin initialization
    //    /// </summary>
    //    /// <param name="MapWin">The reference to the main app</param>
    //    /// <param name="ParentHandle">The handle of the main application window</param>
    //    public void Initialize(int ParentHandle)
    //    {
    //        try
    //        {
    //            m_parentWindowHandle = ParentHandle;

    //            //m_mapWin.CustomObjectLoaded += new MapWindow.Interfaces.CustomObjectLoadedDelegate(m_mapWin_CustomObjectLoaded);

    //            // label moving init
    //            m_CurrentLabel = new LabelData();

    //            // shapefile color schemes
    //            LayerColors = new ColorSchemes(ColorSchemeType.Layer);
    //            LayerColors.ReadFromXML();

    //            // charts color schemes
    //            ChartColors = new ColorSchemes(ColorSchemeType.Charts);
    //            ChartColors.ReadFromXML();
    //        }
    //        catch (System.Exception ex)
    //        {
    //            MessageBoxError("Exception in Globals.Initialize()" + Environment.NewLine + ex.Message);
    //        }
    //    }
    //    #region Message
    //    /// <summary>
    //    ///  Initializing the labeling session (plug-in specific event not defined in interface)
    //    /// </summary>
    //    public void Message(string msg, ref bool Handled)
    //    {
    //        if (msg == null)
    //            return;

    //        // messages mustn't be processed in case old symbology is uesd
    //        if (m_legend.AxMap.ShapeDrawingMethod != tkShapeDrawingMethod.dmNewSymbology)
    //        {
    //            return;
    //        }

    //        if (msg.Contains("LABEL_RELABEL"))
    //        {
    //            // generates labels for new shapes
    //            Handled = true;
    //            string sub = msg.Substring(14);
    //            int handle = -1;
    //            if (Int32.TryParse(sub, out handle))
    //            {
    //                MapWinGIS.Shapefile sf = m_legend.AxMap.get_GetObject(handle) as Shapefile;
    //                if (sf != null)
    //                {
    //                    {
    //                        if (sf.Labels.Synchronized)
    //                        {
    //                            string expr = sf.Labels.Expression;
    //                            sf.Labels.Expression = "";
    //                            sf.Labels.Expression = expr;
    //                            m_legend.AxMap.Redraw();
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        else if (msg.Contains("SYMBOLOGY_MANAGER:"))
    //        {
    //            Handled = true;
    //            string sub = msg.Substring(18);
    //            int handle = -1;
    //            if (Int32.TryParse(sub, out handle))
    //            {
    //                frmOptionsManager form = new frmOptionsManager(handle);
    //                if (form.ShowDialog() == DialogResult.OK)
    //                {
    //                    // do nothing
    //                }
    //                form.Dispose();
    //            }
    //        }
    //        else if (msg.Contains("SYMBOLOGY_CHOOSE:"))
    //        {
    //            Handled = true;
    //            int handle = -1;
    //            string filename = "";

    //            // it was not necessary to pass filename (it can be obtained from layer handle)
    //            string sub = msg.Substring(17);
    //            for (int i = 0; i < sub.Length - 1; i++)
    //            {
    //                if (sub[i] == '!')
    //                {
    //                    string buf = sub.Substring(0, i);
    //                    if (!Int32.TryParse(buf, out handle))
    //                    {
    //                        throw new Exception("Invalid message");
    //                    }
    //                    filename = sub.Substring(i + 1);
    //                    break;
    //                }
    //            }

    //            if (handle != -1 && System.IO.File.Exists(filename))
    //            {
    //                frmOptionsChooser form = new frmOptionsChooser(filename, handle);
    //                Form mapForm = (Form)System.Windows.Forms.Control.FromHandle((System.IntPtr)m_parentWindowHandle);
    //                mapForm.AddOwnedForm(form);

    //                if (form.ShowDialog() == DialogResult.Cancel)
    //                {
    //                    //m_mapWin.Layers.Remove(handle);
    //                }
    //            }
    //        }
    //        else if (msg.Contains("SYMBOLOGY_EDIT"))
    //        {
    //            Handled = true;
    //            int handle = Convert.ToInt32(msg.Substring(14, msg.Length - 14));

    //            MapWinGIS.Shapefile sf = m_legend.AxMap.get_GetObject(handle) as Shapefile;
    //            if (sf != null)
    //            {
    //                if (m_mainForm != null)
    //                {
    //                    m_mainForm.Dispose();
    //                    m_mainForm = null;
    //                    GC.Collect();
    //                }
    //                m_mainForm = new Forms.SymbologyMainForm(this, handle);
    //                Form mapForm = (Form)System.Windows.Forms.Control.FromHandle((System.IntPtr)m_parentWindowHandle);
    //                mapForm.AddOwnedForm(m_mainForm);

    //                if (m_mainForm.ShowDialog() == DialogResult.OK)
    //                {
    //                    //m_mapWin.Plugins.BroadcastMessage("SYMBOLOGY_DONE" + Convert.ToString(handle));
    //                }
    //                m_mainForm.Dispose();
    //            }
    //        }

    //        else if (msg.Contains("LABEL_EDIT"))
    //        {
    //            Handled = true;
    //            int handle = Convert.ToInt32(msg.Substring(11, msg.Length - 11));

    //            MapWinGIS.Shapefile sf = m_legend.AxMap.get_GetObject(handle) as Shapefile;
    //            if (sf != null)
    //            {
    //                MWLite.Symbology.Layer layer = m_legend.Layers.ItemByHandle(handle);
    //                LabelStyleForm form = new LabelStyleForm(sf, handle);
    //                Form mapForm = (Form)System.Windows.Forms.Control.FromHandle((System.IntPtr)m_parentWindowHandle);
    //                mapForm.AddOwnedForm(form);

    //                if (form.ShowDialog() == DialogResult.OK)
    //                {
    //                    //m_mapWin.Plugins.BroadcastMessage("LABEL_DONE" + Convert.ToString(handle));
    //                    m_legend.AxMap.Redraw();
    //                }
    //                form.Dispose();
    //            }
    //        }
    //        else if (msg.Contains("LAYER_EDIT_SYMBOLOGY"))
    //        {
    //            Handled = true;
    //            string sub = msg.Substring(20, msg.Length - 20);

    //            int handle = -1;
    //            int category = -1;
    //            for (int i = 0; i < sub.Length; i++)
    //            {
    //                if (sub.Substring(i, 1) == "!")
    //                {
    //                    handle = Convert.ToInt32(sub.Substring(0, i));
    //                    category = Convert.ToInt32(sub.Substring(i + 1));
    //                    break;
    //                }
    //            }

    //            if (handle == -1)
    //            {
    //                handle = Convert.ToInt32(sub);
    //            }

    //            MapWinGIS.Shapefile sf = m_legend.AxMap.get_GetObject(handle) as Shapefile;
    //            if (sf != null)
    //            {
    //                IGeometryStyle options;
    //                if (category == -1)
    //                {
    //                    options = sf.Style;
    //                }
    //                else
    //                {
    //                    options = sf.Categories.get_Item(category).Style;
    //                }

    //                if (options == null)
    //                {
    //                    return;
    //                }

    //                Form form = GetSymbologyForm(handle, sf.ShapefileType, options, false);
    //                if (form != null)
    //                {
    //                    Form mapForm = (Form)System.Windows.Forms.Control.FromHandle((System.IntPtr)m_parentWindowHandle);
    //                    mapForm.AddOwnedForm(form);

    //                    if (form.ShowDialog() == DialogResult.OK)
    //                    {
    //                        //m_mapWin.Plugins.BroadcastMessage("Ok" + Convert.ToString(handle));
    //                        m_legend.AxMap.Redraw();
    //                    }
    //                    form.Dispose();
    //                }
    //            }
    //        }
    //        else if (msg.Contains("CHARTS_EDIT"))
    //        {
    //            Handled = true;
    //            string sub = msg.Substring(11, msg.Length - 11);

    //            int handle = -1;
    //            int fieldIndex = -1;
    //            for (int i = 0; i < sub.Length; i++)
    //            {
    //                if (sub.Substring(i, 1) == "!")
    //                {
    //                    handle = Convert.ToInt32(sub.Substring(0, i));
    //                    fieldIndex = Convert.ToInt32(sub.Substring(i + 1));
    //                    break;
    //                }
    //            }

    //            if (handle == -1)
    //            {
    //                handle = Convert.ToInt32(sub);
    //            }

    //            MapWinGIS.Shapefile sf = m_legend.AxMap.get_GetObject(handle) as Shapefile;
    //            if (sf != null)
    //            {
    //                if (fieldIndex == -1)
    //                {
    //                    Forms.ChartStyleForm form = new MWLite.Symbology.Forms.ChartStyleForm(this, sf, true, handle);

    //                    Form mapForm = (Form)System.Windows.Forms.Control.FromHandle((System.IntPtr)m_parentWindowHandle);
    //                    mapForm.AddOwnedForm(form);

    //                    if (form.ShowDialog() == DialogResult.OK)
    //                    {
    //                        //m_mapWin.Plugins.BroadcastMessage("Ok" + Convert.ToString(handle));
    //                        m_legend.AxMap.Redraw();
    //                    }
    //                    form.Dispose();
    //                }
    //                else
    //                {
    //                    MapWinGIS.ChartField field = sf.Charts.get_Field(fieldIndex);
    //                    if (field != null)
    //                    {
    //                        ColorDialog dialog = new ColorDialog();
    //                        dialog.Color =  field.Color);
    //                        dialog.FullOpen = true;
    //                        if (dialog.ShowDialog() == DialogResult.OK)
    //                        {
    //                            field.Color = Convert.ToUInt32(Colors.ColorToInteger(dialog.Color));
    //                            m_legend.AxMap.Redraw();
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        else if (msg.Contains("SHAPEFILE_CATEGORIES_EDIT"))
    //        {
    //            // displaying categories
    //            Handled = true;
    //            int handle = Convert.ToInt32(msg.Substring(25, msg.Length - 25));

    //            MapWinGIS.Shapefile sf = m_legend.AxMap.get_GetObject(handle) as Shapefile;
    //            if (sf != null)
    //            {
    //                CategoriesForm form = new CategoriesForm(this, sf, handle);

    //                Form mapForm = (Form)System.Windows.Forms.Control.FromHandle((System.IntPtr)m_parentWindowHandle);
    //                mapForm.AddOwnedForm(form);

    //                if (form.ShowDialog() == DialogResult.OK)
    //                {
    //                    m_legend.AxMap.Redraw();
    //                    //Globals.Legend.Refresh();
    //                }

    //                form.Dispose();
    //            }
    //        }
    //        else if (msg.Contains("QUERY_SHAPEFILE"))
    //        {
    //            // displaying categories
    //            Handled = true;
    //            int handle = Convert.ToInt32(msg.Substring(15, msg.Length - 15));

    //            MapWinGIS.Shapefile sf = m_legend.AxMap.get_GetObject(handle) as Shapefile;
    //            if (sf != null)
    //            {
    //                frmQueryBuilder form = new frmQueryBuilder(sf, handle, "", true);

    //                Form mapForm = (Form)System.Windows.Forms.Control.FromHandle((System.IntPtr)m_parentWindowHandle);
    //                mapForm.AddOwnedForm(form);

    //                if (form.ShowDialog() == DialogResult.OK)
    //                {
    //                    // do nothing
    //                    // Globals.Map.Redraw();
    //                }

    //                form.Dispose();
    //            }

    //        }
    //    }



    //    #endregion

    //    #region Implemented members
    //    // ----------------------------------------------------------------
    //    //  Implemented members of IPlugin interface
    //    // ----------------------------------------------------------------
    //    public void LayerRemoved(int Handle)
    //    {
    //        if (m_mainForm != null && !m_mainForm.IsDisposed)
    //        {
    //            try
    //            {
    //                m_mainForm.Close();
    //            }
    //            catch
    //            { }
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="selShapes"></param>
    //    public void AddSelectShapes(object selShapes)
    //    {
    //        try
    //        {
    //            int[] shapes = (int[])selShapes;
    //            int size = shapes.GetUpperBound(0);
    //            for (int i = 0; i <= size; i++)
    //            {
    //                //m_mapWin.View.SelectedShapes.AddByIndex(shapes[i], Color.Yellow);
    //            }
    //        }
    //        catch (System.Exception ex)
    //        {
    //            MessageBoxError("SelectShapes()" + Environment.NewLine + ex.Message);
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="Handle"></param>
    //    public void LayerSelected(int Handle)
    //    {
    //        if (m_mainForm != null && !m_mainForm.IsDisposed)
    //        {
    //            try
    //            {
    //                if (m_mainForm._layerHandle != Handle)
    //                    m_mainForm.Close();
    //            }
    //            catch { }
    //        }
    //    }
    //    #endregion

    //    #region Label/charts moving

    //    /// <summary>
    //    /// Occurs when a user clicks on a toolbar button or menu item.
    //    /// </summary>
    //    /// <param name="ItemName">The name of the item clicked.</param>
    //    /// <param name="handled">Reference parameter. Setting Handled to true prevents other plugins from receiving this event.</param>
    //    //public void ItemClicked(string ItemName, ref bool Handled)
    //    //{
    //    //    if (((AxMapWinGIS.AxMap)m_mapWin.GetOCX).ShapeDrawingMethod != tkShapeDrawingMethod.dmNewSymbology)
    //    //    {
    //    //        return;
    //    //    }


    //    //    switch (ItemName)
    //    //    {
    //    //        case BUTTON_LABELS_MOVE:
    //    //            m_mapWin.Toolbar.ButtonItem(ItemName).Pressed = !m_mapWin.Toolbar.ButtonItem(ItemName).Pressed;
    //    //            ((AxMapWinGIS.AxMap)m_mapWin.GetOCX).CursorMode = tkCursorMode.cmNone;
    //    //            m_labelMovingMode = m_mapWin.Toolbar.ButtonItem(ItemName).Pressed;
    //    //            if (!m_labelMovingMode)
    //    //            {
    //    //                m_CurrentLabel.Clear();
    //    //            }
    //    //            break;
    //    //        case BUTTON_QUERY_BUILDER:
    //    //            int handle = m_mapWin.Layers.CurrentLayer;
    //    //            MapWinGIS.Shapefile sf = ((AxMapWinGIS.AxMap)m_mapWin.GetOCX).get_GetObject(handle) as Shapefile;
    //    //            if (sf != null)
    //    //            {
    //    //                frmQueryBuilder form = new frmQueryBuilder(sf, handle, "", true, m_mapWin);
    //    //                if (form.ShowDialog() == DialogResult.OK)
    //    //                {
    //    //                    // do nothing
    //    //                }
    //    //                form.Dispose();
    //    //            }
    //    //            else
    //    //            {
    //    //                SymbologyPlugin.Msg.Info("Active layer should be a shapefile");
    //    //            }
    //    //            break;
    //    //        case BUTTON_CATEGORIES:
    //    //            handle = m_mapWin.Layers.CurrentLayer;
    //    //            sf = ((AxMapWinGIS.AxMap)m_mapWin.GetOCX).get_GetObject(handle) as Shapefile;
    //    //            if (sf != null)
    //    //            {
    //    //                CategoriesForm form = new CategoriesForm(m_mapWin, this, sf, handle);
    //    //                if (form.ShowDialog() == DialogResult.OK)
    //    //                {
    //    //                    // do nothing
    //    //                }
    //    //            }
    //    //            else
    //    //            {
    //    //                SymbologyPlugin.Msg.Info("Active layer should be a shapefile");
    //    //            }
    //    //            break;
    //    //        default:
    //    //            MapWindow.Interfaces.ToolbarButton button = m_mapWin.Toolbar.ButtonItem(BUTTON_LABELS_MOVE);
    //    //            if (button != null)
    //    //            {
    //    //                m_mapWin.Toolbar.ButtonItem(BUTTON_LABELS_MOVE).Pressed = false;
    //    //                ((AxMapWinGIS.AxMap)m_mapWin.GetOCX).Refresh();
    //    //                m_labelMovingMode = false;
    //    //                m_CurrentLabel.Clear();
    //    //            }
    //    //            break;
    //    //    }
    //    //}
    //    #endregion

    //    /// <summary>
    //    /// Applying default settings for the layer
    //    /// </summary>
    //    /// <param name="Layers"></param>
    //    public void LayersAdded(MWLite.Symbology.Layer[] Layers)
    //    {
    //        foreach (MWLite.Symbology.Layer layer in Layers)
    //        {
    //            MapWinGIS.Shapefile sf = layer.GetObject() as MapWinGIS.Shapefile;
    //            if (sf != null)
    //            {
    //                if (layer.GetCustomObject("SymbologyPluginSettings") == null)
    //                {
    //                    // no settings from project file was loaded
    //                    SymbologySettings settings = new SymbologySettings();
    //                    settings.ShowLayerPreview = (sf.NumShapes < 10000);
    //                    settings.UpdateMapAtOnce = (sf.NumShapes < 5000);
    //                    settings.ShowQueryValues = (sf.NumShapes < 1000);
    //                }
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Logs the error through standard interface
    //    /// </summary>
    //    /// <param name="functionName"></param>
    //    /// <param name="errorMsg"></param>
    //    public void ShowErrorBox(string functionName, string errorMsg)
    //    {
    //        MapWinUtility.Logger.Message("Error in " + functionName + ", Message: " + errorMsg, "Label Editor", MessageBoxButtons.OK, MessageBoxIcon.Error, DialogResult.OK);
    //    }

    //    /// <summary>
    //    /// Returns 2D representation of shape type to simplify conditions
    //    /// </summary>
    //    /// <param name="shpType"></param>
    //    internal static MapWinGIS.ShpfileType ShapefileType2D(MapWinGIS.ShpfileType shpType)
    //    {
    //        if (shpType == ShpfileType.SHP_POLYGON || shpType == ShpfileType.SHP_POLYGONM || shpType == ShpfileType.SHP_POLYGONZ)
    //        {
    //            return ShpfileType.SHP_POLYGON;
    //        }
    //        else if (shpType == ShpfileType.SHP_POLYLINE || shpType == ShpfileType.SHP_POLYLINEM || shpType == ShpfileType.SHP_POLYLINEZ)
    //        {
    //            return ShpfileType.SHP_POLYLINE;
    //        }
    //        else if (shpType == ShpfileType.SHP_POINT || shpType == ShpfileType.SHP_POINTM || shpType == ShpfileType.SHP_POINTZ ||
    //                 shpType == ShpfileType.SHP_MULTIPOINT || shpType == ShpfileType.SHP_MULTIPOINTM || shpType == ShpfileType.SHP_MULTIPOINTZ)
    //        {
    //            return ShpfileType.SHP_POINT;
    //        }
    //        else
    //        {
    //            return ShpfileType.SHP_NULLSHAPE;
    //        }
    //    }

    //    /// <summary>
    //    /// Retruns short string with map units
    //    /// </summary>
    //    internal static string get_MapUnits()
    //    {
    //        string s = " ";

    //        tkUnitsOfMeasure units = m_legend.AxMap.MapUnits;
    //        switch (units)
    //        {
    //            case tkUnitsOfMeasure.umDecimalDegrees: s = " deg."; break;
    //            case tkUnitsOfMeasure.umMeters: s = " m"; break;
    //            case tkUnitsOfMeasure.umKilometers: s = " km"; break;
    //            case tkUnitsOfMeasure.umFeets: s = " ft."; break;
    //            default: s = " "; break;
    //        }
    //        return s;
    //    }

    //    /// <summary>
    //    /// Saves options of the layer in .mwsymb file
    //    /// </summary>
    //    internal static void SaveLayerOptions(int LayerHandle)
    //    {
    //        //if (mapWin.ApplicationInfo.SymbologyLoadingBehavior == MapWindow.Interfaces.SymbologyBehavior.DefaultOptions)
    //        //{
    //        //    AxMapWinGIS.AxMap map = Globals.Map;
    //        //    if (map != null)
    //        //    {
    //        //        map.SaveLayerOptions(LayerHandle, "", true, "");
    //        //    }
    //        //}
    //    }

    //    /// <summary>
    //    /// Returns descriptions of the standard types of symbology (random and default)
    //    /// </summary>
    //    internal static string GetSymbologyDescription(SymbologyType symbologyType)
    //    {
    //        string s = "";
    //        if (symbologyType == SymbologyType.Default)  //name.ToLower() == "default options" || name.ToLower() == "")
    //        {

    //            s = "Default options stored in the .mwsymb or .mwsr files";
    //        }
    //        else if (symbologyType == SymbologyType.Random)
    //        {
    //            s = "Options set randomly by MapWinGIS ActiveX control";
    //        }
    //        return s;
    //    }

    //    /// <summary>
    //    /// Returns path to the default directory with icons
    //    /// </summary>
    //    internal static string GetIconsPath()
    //    {
    //        string filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    //        filename = Directory.GetParent(filename).FullName;
    //        return filename + "\\Styles\\Icons\\";
    //    }

    //    /// <summary>
    //    /// Returns path to the default directory with icons
    //    /// </summary>
    //    internal static string GetTexturesPath()
    //    {
    //        string filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    //        filename = Directory.GetParent(filename).FullName;
    //        return filename + "\\Styles\\Textures\\";
    //    }

    //    /// <summary>
    //    /// Build list of available options for the layer (.mwsymb, .mwsr files)
    //    /// </summary>
    //    /// <param name="dgv"></param>
    //    /// <param name="filename"></param>
    //    /// <param name="manager"></param>
    //    internal static void FillSymbologyList(ListView listView, string filename, bool manager, ref bool noEvents)
    //    {
    //        noEvents = true;

    //        listView.Items.Clear();

    //        // always available
    //        if (!manager)
    //        {
    //            ListViewItem item = listView.Items.Add("[random]");
    //            item.Tag = SymbologyType.Random;
    //        }

    //        string path = filename + ".mwsymb";
    //        if (System.IO.File.Exists(path))
    //        {
    //            ListViewItem item = listView.Items.Add("[default]");
    //            item.Tag = SymbologyType.Default;
    //        }

    //        // cities.shp.default.mwsymb
    //        path = System.IO.Path.GetDirectoryName(filename);
    //        string[] names = System.IO.Directory.GetFiles(path, System.IO.Path.GetFileName(filename) + "*");
    //        for (int i = 0; i < names.Length; i++)
    //        {
    //            if (names[i].ToLower().EndsWith(".mwsymb"))
    //            {
    //                string name = names[i].Substring(filename.Length);
    //                if (name.ToLower() == ".mwsymb")
    //                {
    //                    // was added before
    //                }
    //                else
    //                {
    //                    name = name.Substring(1, name.Length - 8);
    //                    ListViewItem item = listView.Items.Add(name);
    //                    item.Tag = SymbologyType.Custom;
    //                }
    //            }
    //        }

    //        if (listView.Items.Count > 0)
    //        {
    //            listView.SelectedIndices.Add(0);
    //        }

    //        noEvents = false;
    //    }


    //    internal static SymbologySettings get_LayerSettings(int layerHandle)
    //    {
    //        SymbologySettings settings = null;
    //        MWLite.Symbology.Layer layer = Legend.GetLayer(layerHandle);
    //        if (layer != null)
    //        {
    //            settings = (SymbologySettings)layer.GetCustomObject("SymbologyPluginSettings");
    //        }
    //        if (settings == null)
    //            settings = new SymbologySettings();

    //        return settings;
    //    }

    //    /// <summary>
    //    /// Saves symbology settings for the layer
    //    /// </summary>
    //    internal static void SaveLayerSettings(int layerHandle, SymbologySettings settings)
    //    {
    //        MWLite.Symbology.Layer layer = Legend.GetLayer(layerHandle);
    //        if (layer != null)
    //        {
    //            layer.SetCustomObject(settings, "SymbologyPluginSettings");
    //        }
    //    }

    //    /// <summary>
    //    /// Restores the state of custom object associated with layer
    //    /// </summary>
    //    void m_mapWin_CustomObjectLoaded(int layerHandle, string key, string state, ref bool handled)
    //    {
    //        if (key == "SymbologyPluginSettings")
    //        {
    //            SymbologySettings settings = MapWinUtility.Serialization.Deserialize(state, typeof(SymbologySettings)) as SymbologySettings;
    //            if (settings != null)
    //            {
    //                SaveLayerSettings(layerHandle, settings);
    //            }
    //        }

    //    }
    //}

    //#region Classes
    ///// <summary>
    ///// A class to hold information about dynamic visibility settings of layer, labels or charts
    ///// </summary>
    //internal class DynamicVisibility
    //{
    //    public bool Visibility;
    //    public double MaxScale;
    //    public double MinScale;
    //    public double CurrentScale;

    //    public DynamicVisibility()
    //    {
    //        Visibility = false;
    //        MaxScale = 100000000.0;
    //        MinScale = 0.0;
    //        CurrentScale = 0.0;
    //    }
    //}
    //#endregion
}
