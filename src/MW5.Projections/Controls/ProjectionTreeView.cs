// ----------------------------------------------------------------------------
// MapWindow.Controls.Projections: store controls to work with EPSG projections
// database
// Author: Sergei Leschinski
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Projections.DL;
using MW5.Projections.Forms;
using MW5.Projections.Properties;
using MW5.Projections.Services;

namespace MW5.Projections.Controls
{
    /// <summary>
    /// A class derived from TreeView, which shows the list of projection of EPSG projection database
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TreeView))]
    public class ProjectionTreeView : TreeView
    {
        #region Declarations

        // database to take data from
        Plugins.Interfaces.Projections.IProjectionDatabase _database = null;

        // icons of the image list
        const int ICON_FOLDER = 0;
        const int ICON_FOLDER_OPEN = 1;
        const int ICON_GLOBE = 2;
        const int ICON_MAP = 3;
        const int ICON_PLUS = 4;
        const int ICON_MINUS = 5;

        private string SCOPE_NOT_RECOMMENDED = "Not recommended.";

        // GCS that should be classified by type (by default the option is off, to ensure performance)
        private readonly Hashtable _dctLocalWithClassification;

        // USA GCS that should be classified by state (NAD)
        private readonly Hashtable _dctUsaStates;

        // sets behavior of the set extents tool
        private readonly ProjectionSelectionMode _selectionMode = ProjectionSelectionMode.Intersection;

        // notifies about double click event to suppress collasing/expanding of nodes
        private bool _doubleClickWasDone;

        // the tab page of properties window that was opened last time
        private int _propertiesTab;

        // context menu for nodes
        private ContextMenuStrip _contextMenu;

        // Reference to MapWindow to load the list of favorite projections
        private IAppContext _context;

        // preserving selected node when context menu is showing
        private TreeNode _selectedNode;

        // top nodes keys
        private const string NODE_UNSPECIFIED_DATUMS = "Unspecified datums";
        private const string NODE_WORLD = "WORLD";
        private const string NODE_FAVORITE = "Favorite";
        private const string NODE_GEOGRAPHICAL = "Geographical";
        private const string NODE_PROJECTED = "Projected";

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new isntance of ProjectionTreeView class
        /// </summary>
        public ProjectionTreeView()
        {
            ImageList = CreateImageList();

            CreateContextMenu();

            _dctLocalWithClassification = new Hashtable();
            int[] codes = { 4617, 4214, 4490, 4555, 4610, 4612, 4301, 4755, 4283, 4200 };
            foreach (int code in codes)
                _dctLocalWithClassification.Add(code, null);

            _dctUsaStates = new Hashtable();
            int[] codes2 = { 4267, 4269, 4152, 4759 };
            foreach (int code in codes2)
                _dctUsaStates.Add(code, null);

            SetEventHandlers();
        }

        /// <summary>
        /// Sets event handling for the control
        /// </summary>
        private void SetEventHandlers()
        {
            BeforeCollapse += new TreeViewCancelEventHandler(ProjectionTreeView_BeforeCollapse);
            BeforeExpand += new TreeViewCancelEventHandler(ProjectionTreeView_BeforeExpand);
            AfterSelect += new TreeViewEventHandler(ProjectionTreeView_AfterSelect);
            NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(ProjectionTreeView_NodeMouseDoubleClick);
            NodeMouseClick += new TreeNodeMouseClickEventHandler(ProjectionTreeView_NodeMouseClick);
        }

        /// <summary>
        /// Creates image list associated with tree view
        /// </summary>
        private ImageList CreateImageList()
        {
            ImageList list = new ImageList {ColorDepth = ColorDepth.Depth24Bit};

            Bitmap bmp = new Bitmap(Resources.img_folder, new Size(16, 16));
            list.Images.Add(bmp);

            bmp = new Bitmap(Resources.img_folder_open, new Size(16, 16));
            list.Images.Add(bmp);

            bmp = new Bitmap(Resources.img_globe, new Size(16, 16));
            list.Images.Add(bmp);

            bmp = new Bitmap(Resources.img_map, new Size(16, 16));
            list.Images.Add(bmp);

            bmp = new Bitmap(Resources.img_map_add, new Size(16, 16));
            list.Images.Add(bmp);

            bmp = new Bitmap(Resources.img_map_delete, new Size(16, 16));
            list.Images.Add(bmp);

            return list;
        }
        #endregion

        #region Initialization

        /// <summary>
        /// Initializes by the pass to the executable file. \Projection folder is assumed.
        /// </summary>
        public bool InitializeByExePath(string executablePath, IAppContext context)
        {
            string path = System.IO.Path.GetDirectoryName(executablePath) + @"\Projections\";
            if (!Directory.Exists(path))
            {
                MessageService.Current.Info("Projections folder isn't found: " + path);
                return false;
            }

            string[] files = Directory.GetFiles(path, "*.mdb");
            if (files.Length != 1)
            {
                MessageService.Current.Info("A single database is expected. " + files.Length + " databases are found." + Environment.NewLine +
                                "Path : " + path + Environment.NewLine);
                return false;
            }
            
            Initialize(files[0], context);
            return true;
        }

        /// <summary>
        /// Initializes tree view
        /// </summary>
        /// <param name="databaseName">The name of the database file with projections.</param>
        /// <param name="context">Application context.</param>
        public bool Initialize(string databaseName, IAppContext context)
        {
            _context = context;  // null is acceptable as well
            try
            {
                _database = new ProjectionDatabase(databaseName, new SqliteProvider());
            }
            catch (Exception ex)
            {
                MessageService.Current.Info(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Initilizes tree view with the existing in-memory version of database
        /// </summary>
        public bool Initialize(IProjectionDatabase database, IAppContext context)
        {
            _context = context;  // null is acceptable as well

            if (database.Name == "")
            {
                return false;
            }

            _database = database;
            return true;
        }
        #endregion

        #region Context Menu
        // Context menu commands
        private const string CONTEXT_ADD_TO_FAVORITE = "Add to Favorite";
        private const string CONTEXT_REMOVE_FROM_FAVORITE = "Remove from Favorite";
        private const string CONTEXT_SHOW_PROPERTIES = "Properties";
        private const string CONTEXT_NODE_EXPAND = "Node Expand";
        private const string CONTEXT_NODE_COLLAPSE = "Node Collapse";
        
        /// <summary>
        /// Creates a context menu associated with nodes
        /// </summary>
        private void CreateContextMenu()
        {
            _contextMenu = new ContextMenuStrip();
            _contextMenu.ImageList = ImageList;
            _contextMenu.Items.Add(CONTEXT_ADD_TO_FAVORITE).ImageIndex = ICON_PLUS;
            _contextMenu.Items.Add(CONTEXT_REMOVE_FROM_FAVORITE).ImageIndex = ICON_MINUS;
            _contextMenu.Items.Add(new ToolStripSeparator());
            _contextMenu.Items.Add(CONTEXT_SHOW_PROPERTIES);
            foreach (ToolStripItem item in _contextMenu.Items)
                item.Name = item.Text;
            
            _contextMenu.ItemClicked +=new ToolStripItemClickedEventHandler(m_contextMenu_ItemClicked);
        }

        /// <summary>
        /// Showing context menu;
        /// </summary>
        void ProjectionTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node != null)
                    SelectedNode = e.Node;
                
                if (e.Node.ImageIndex == ICON_GLOBE || e.Node.ImageIndex == ICON_MAP)
                {
                    TreeNode nodeFavorite = Nodes[NODE_FAVORITE];
                    TreeNode nodeProjected = nodeFavorite.Nodes[NODE_PROJECTED];
                    TreeNode nodeGeograpical = nodeFavorite.Nodes[NODE_GEOGRAPHICAL];
                    
                    bool favorite = e.Node.Parent == nodeProjected || e.Node.Parent == nodeGeograpical;
                    _contextMenu.Items[CONTEXT_ADD_TO_FAVORITE].Visible = !favorite;
                    _contextMenu.Items[CONTEXT_REMOVE_FROM_FAVORITE].Visible = favorite;
                    
                    _selectedNode = e.Node;
                    //SelectedNode = e.Node;
                    Rectangle r = RectangleToScreen(ClientRectangle);
                    _contextMenu.Show(r.Left + e.X, r.Top + e.Y);
                }
            }
        }

        /// <summary>
        /// Executes context menu commands
        /// </summary>
        void m_contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _contextMenu.Hide();
            Application.DoEvents();
            switch (e.ClickedItem.Text)
            {
                case CONTEXT_ADD_TO_FAVORITE:
                    AddProjectionToFavorite(_selectedNode.Tag as CoordinateSystem);
                    break;
                case CONTEXT_SHOW_PROPERTIES:
                    ShowProjectionProperties(_selectedNode.Tag as CoordinateSystem);
                    break;
                case CONTEXT_REMOVE_FROM_FAVORITE:
                    RemoveFromFavorite(_selectedNode.Tag as CoordinateSystem);
                    break;
            }
        }
        #endregion

        #region Favorite
        /// <summary>
        /// Removes coordinate system from favorite list
        /// </summary>
        private void RemoveFromFavorite(CoordinateSystem cs)
        {
            if (cs != null && _context != null)
            {
                var list = _context.Config.FavoriteProjections;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == cs.Code)
                    {
                        list.RemoveAt(i);
                        break;
                    }
                }

                UpdateFavoriteList();
            }
        }

        /// <summary>
        /// Adds projection to the favorite list
        /// </summary>
        private void AddProjectionToFavorite(CoordinateSystem cs)
        {
            if (cs == null) throw new ArgumentNullException("cs");

            if (_context != null)
            {
                IList<int> list = _context.Config.FavoriteProjections;
                if (list.All(prj => prj != cs.Code))
                {
                    list.Add(cs.Code);

                    UpdateFavoriteList();
                }
                else
                {
                    MessageService.Current.Info("Projection is added to the list already.");
                }
            }
        }

        /// <summary>
        /// Adds nodes with favorite projections
        /// </summary>
        private void UpdateFavoriteList()
        {
            SuspendLayout();

            TreeNode nodeFavorite = Nodes[NODE_FAVORITE];
            if (nodeFavorite != null)
            {
                Nodes.Remove(nodeFavorite);
            }
            
            nodeFavorite = Nodes.Add(NODE_FAVORITE, NODE_FAVORITE, ICON_FOLDER);

            if (_context != null)
            {
                TreeNode nodeGeographical = nodeFavorite.Nodes.Add(NODE_GEOGRAPHICAL, NODE_GEOGRAPHICAL, ICON_FOLDER);
                TreeNode nodeProjected = nodeFavorite.Nodes.Add(NODE_PROJECTED, NODE_PROJECTED, ICON_FOLDER);

                IList<int> list  = _context.Config.FavoriteProjections;
                if (list != null)
                {
                    int count = 0;
                    // geographical
                    IEnumerable<IGeographicCs> results = from gcs in _database.GeographicCs
                                                        from code in list
                                                        orderby gcs.Name
                                                        where gcs.Code == code
                                                        select(gcs);
                    
                    foreach (GeographicCs gcs in results)
                    {
                        TreeNode nodeGcs = nodeGeographical.Nodes.Add(gcs.Code.ToString(), gcs.Name, ICON_GLOBE);
                        nodeGcs.Tag = gcs;
                        count++;
                    }

                    // projected
                    IEnumerable<IProjectedCs> results2 = from pcs in _database.ProjectedCs
                                                        from code in list
                                                        orderby pcs.Name
                                                        where pcs.Code == code
                                                        select(pcs);
                    foreach (ProjectedCs pcs in results2)
                    {
                        TreeNode nodePcs = nodeProjected.Nodes.Add(pcs.Code.ToString(), pcs.Name, ICON_MAP);
                        nodePcs.Tag = pcs;
                        count++;
                    }

                    nodeFavorite.ExpandAll();
                    TreeNode nodeWorld = Nodes[NODE_WORLD];
                    if (nodeWorld != null && count < 5)
                        nodeWorld.Expand();
                }
            }

            ResumeLayout();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the underlying projection database 
        /// </summary>
        public IProjectionDatabase Database
        {
            get { return _database; }
        }
        
        /// <summary>
        /// Gets the selected item in tree view, only coordinate systems will be returned
        /// </summary>
        public CoordinateSystem SelectedCoordinateSystem
        {
            get
            {
                if (SelectedNode == null)
                {
                    return null;
                }
                
                if (SelectedNode.ImageIndex == ICON_GLOBE || SelectedNode.ImageIndex == ICON_MAP)
                {
                    return SelectedNode.Tag as CoordinateSystem;
                }

                return null;
            }
        }

        /// <summary>
        /// Returns geoprojection initialized with selected coordinate system
        /// </summary>
        public ISpatialReference SelectedProjection
        {
            get
            {
                CoordinateSystem cs = SelectedCoordinateSystem;
                if (cs == null)
                {
                    return null;
                }
                
                ISpatialReference proj = new SpatialReference();
                if (proj.ImportFromEpsg(cs.Code))
                {
                    return proj;
                }
                
                return null;
            }
        }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        public List<IGeographicCs> CoordinateSystems
        {
            get { return _database.GeographicCs; }
        }

        /// <summary>
        /// Returns list of regions
        /// </summary>
        public List<IProjectedCs> Projections
        {
            get { return _database.ProjectedCs; }
        }
        #endregion

        #region Tree view filling
        /// <summary>
        /// Fills treeview with all CS from list
        /// </summary>
        public bool RefreshList()
        {
            int gcsCount, pcsCount;
            return RefreshList(new BoundingBox(-180.0, 180.0, -90.0, 90.0), out gcsCount, out pcsCount);
        }
        
        /// <summary>
        /// Fills treeview with all CS from list
        /// </summary>
        /// <param name="gcsCount">Number of geographic CS found</param>
        /// <param name="projCount">Number of projected CS found</param>
        public bool RefreshList(out int gcsCount, out int projCount)
        {
            return RefreshList(new BoundingBox(-180.0, 180.0, -90.0, 90.0), out gcsCount, out projCount);
        }

        /// <summary>
        /// Fills treeview with CS which fall into specified bounds
        /// </summary>
        public bool RefreshList(BoundingBox extents, out int gcsCount, out int projCount)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            gcsCount = 0;
            projCount = 0;

            if (_database == null)
                throw new Exception("No database was specified to populate tree view");

            SuspendLayout();
            Nodes.Clear();

            // limits coordinate systems to those which fall into extents
            bool showFullExtents = extents.xMin == -180.0 && extents.xMax == 180.0 && extents.yMin == -90.0 && extents.yMax == 90.0;
            ApplyExtents(extents, out gcsCount, out projCount);

            // adding top-most nodes
            TreeNode nodeUnspecified = Nodes.Add(NODE_UNSPECIFIED_DATUMS, NODE_UNSPECIFIED_DATUMS, ICON_FOLDER);
            TreeNode nodeWorld = Nodes.Add(NODE_WORLD, NODE_WORLD, ICON_FOLDER);

            // adding regions
            Hashtable dctRegions = new Hashtable();
            var listRegions = _database.Regions.Where(r => r.ParentCode == 1);
            foreach (var region in listRegions)
            {
                TreeNode nodeRegion = nodeWorld.Nodes.Add(region.Code.ToString(), region.Name.ToString(), ICON_FOLDER);
                dctRegions.Add(region.Code, nodeRegion);
            }

            // local GCS
            var listRegions2 = _database.Regions.Where(r => r.ParentCode > 1 && dctRegions.ContainsKey(r.ParentCode));
            foreach (var region in listRegions2)
            {
                TreeNode nodeRegion = dctRegions[region.ParentCode] as TreeNode;
                TreeNode nodeSubregion = nodeRegion.Nodes.Add(region.Code.ToString(), region.Name.ToString(), ICON_FOLDER);
                dctRegions.Add(region.Code, nodeSubregion);

                var listCountries = region.Countries.Where(cn => cn.IsActive).Where(c => c.GeographicCs.Where(cs => cs.IsActive).Any());
                foreach (var country in listCountries)
                {
                    TreeNode nodeCountry = null;   // it's to difficult to determine whether the country should be shown

                    foreach (GeographicCs gcs in country.GeographicCs.Where(cs => cs.IsActive).OrderBy(gcs => gcs.Name))
                    {
                        // when extents are limited, no need to show global systems for each country
                        if (!showFullExtents && gcs.Type != GeographicalCsType.Local)
                            continue;

                        if (gcs.Type != GeographicalCsType.Local || _dctLocalWithClassification.ContainsKey(gcs.Code))
                        {
                            List<ProjectedCs> projections = new List<ProjectedCs>();
                            foreach (int code in country.ProjectedCs)
                            {
                                ProjectedCs pcs = gcs.ProjectionByCode(code);
                                if (pcs != null && pcs.IsActive)
                                    projections.Add(pcs);
                            }

                            if (projections.Any())
                            {
                                // country node will be added only here
                                if (nodeCountry == null)
                                    nodeCountry = nodeSubregion.Nodes.Add(country.Code.ToString(), country.Name.ToString(), ICON_FOLDER);

                                TreeNode nodeGcs = nodeCountry.Nodes.Add(gcs.Code.ToString(), gcs.Name.ToString(), ICON_GLOBE);
                                nodeGcs.Tag = gcs;
                                AddProjections(nodeGcs, gcs, projections);
                            }
                        }
                        else
                        {
                            if (nodeCountry == null)
                                nodeCountry = nodeSubregion.Nodes.Add(country.Code.ToString(), country.Name.ToString(), ICON_FOLDER);

                            // local GCS should be added to country even if there is no projection specified
                            TreeNode nodeGcs = nodeCountry.Nodes.Add(gcs.Code.ToString(), gcs.Name.ToString(), ICON_GLOBE);
                            nodeGcs.Tag = gcs;

                            foreach (var pcs in gcs.Projections.OrderBy(cs => cs.Name))
                            {
                                TreeNode nodePcs = nodeGcs.Nodes.Add(pcs.Code.ToString(), pcs.Name, ICON_MAP);
                                nodePcs.Tag = pcs;
                            }
                        }
                    }
                }
            }

            // regional GCS
            var list1 = _database.GeographicCs.Where(cs => cs.Type == GeographicalCsType.Regional && cs.IsActive).OrderBy(cs => cs.Name);
            foreach (var gcs in list1)
            {
                TreeNode nodeRegion = dctRegions[gcs.RegionCode] as TreeNode;
                TreeNode nodeGcs = nodeRegion.Nodes.Add(gcs.Code.ToString(), gcs.Name, ICON_GLOBE);
                nodeGcs.Tag = gcs;
                AddProjections(nodeGcs, gcs, gcs.Projections.Where(cs => !cs.Local));
            }

            // global GCS
            var list2 = _database.GeographicCs.Where(cs => cs.Type == GeographicalCsType.Global && cs.IsActive).OrderBy(cs => cs.Name);
            foreach (var gcs in list2)
            {
                TreeNode nodeParent = gcs.Scope == SCOPE_NOT_RECOMMENDED || gcs.Name.ToLower().StartsWith("unspecified") ? nodeUnspecified : nodeWorld;
                TreeNode nodeGcs = nodeParent.Nodes.Add(gcs.Code.ToString(), gcs.Name.ToString(), ICON_GLOBE);
                nodeGcs.Tag = gcs;
                AddProjections(nodeGcs, gcs, gcs.Projections.Where(cs => !cs.Local));
            }

            RemoveEmptyChilds(nodeWorld);

            UpdateFavoriteList();

            return true;
        }

        /// <summary>
        /// Adding projections for a gcs node
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="gcs"></param>
        /// <param name="projections"></param>
        private void AddProjections(TreeNode parentNode, IGeographicCs gcs, IEnumerable<IProjectedCs> projections)
        {
            projections = projections.ToList();

            if (_dctUsaStates.Contains(gcs.Code))
            {
                string[] states = { "Alaska", "Alabama", "Arkansas", "Arizona", "California", "Colorado", "Connecticut", "District Columbia",
                                    "Delaware", "Florida", "Georgia", "Hawaii", "Iowa", "Idaho", "Illinois", "Indiana", "Kansas", "Kentucky",
                                    "Louisiana", "Massachusetts", "Maryland", "Maine", "Michigan", "Minnesota", "Missouri", "Mississippi",
                                    "Montana", "North Carolina", "North Dakota", "Nebraska", "New Hampshire", "New Jersey", "New Mexico",
                                    "Nevada", "New York", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina",
                                    "South Dakota", "Tennessee", "Texas", "Utah", "Virginia", "Vermont", "Washington", "Wisconsin", 
                                    "West Virginia", "Wyoming"};

                Hashtable dctStatePcs = new Hashtable();
                TreeNode nodeStates = null;
                foreach (string state in states)
                {
                    var list = projections.Where(p => p.Name.Contains(state));
                    if (list.Any())
                    {
                        if (nodeStates == null)
                        {
                            nodeStates = parentNode.Nodes.Add("States", "States", ICON_FOLDER);
                        }

                        TreeNode nodeState = nodeStates.Nodes.Add(state, state, ICON_FOLDER);
                        foreach (ProjectedCs pcs in list)
                        {
                            TreeNode node = nodeState.Nodes.Add(pcs.Code.ToString(), pcs.Name, ICON_MAP);
                            node.Tag = pcs;
                            if (!dctStatePcs.ContainsKey(pcs.Code))
                                dctStatePcs.Add(pcs.Code, null);
                        }
                    }
                }

                // now process the rest as usual
                projections = projections.Where(p => !dctStatePcs.ContainsKey(p.Code));
            }

            if (gcs.Type != GeographicalCsType.Local || _dctLocalWithClassification.ContainsKey(gcs.Code))
            {
                IEnumerable<string> uniqueTypes = projections.Select(cs => cs.ProjectionType).Distinct().OrderBy(t => t);
                if (uniqueTypes.Count() > 1)
                {
                    foreach (string type in uniqueTypes)
                    {
                        if (type != "")
                        {
                            TreeNode nodeType = parentNode.Nodes.Add(type.ToString(), type.ToString(), ICON_FOLDER);
                            var projList = projections.Select(cs => cs).Where(c => c.ProjectionType == type);
                            foreach (var val in projList)
                            {
                                TreeNode nodePcs = nodeType.Nodes.Add(val.Code.ToString(), val.Name.ToString(), ICON_MAP);
                                nodePcs.Tag = val;
                            }
                        }
                    }
                }

                // adding projections with undefined type
                IEnumerable<IProjectedCs> list = uniqueTypes.Count() > 1 ?
                                                projections.Where(c => c.ProjectionType == "").OrderBy(c => c.Name) : projections.OrderBy(c => c.Name);
                if (list.Any())
                {
                    foreach (ProjectedCs pcs in list)
                    {
                        TreeNode nodePcs = parentNode.Nodes.Add(pcs.Code.ToString(), pcs.Name.ToString(), ICON_MAP);
                        nodePcs.Tag = pcs;
                    }
                }
            }
            else
            {
                foreach (ProjectedCs pcs in projections)
                {
                    TreeNode nodePcs = parentNode.Nodes.Add(pcs.Code.ToString(), pcs.Name.ToString(), ICON_MAP);
                    nodePcs.Tag = pcs;
                }
            }
        }
        #endregion

        #region Tree view events

        /// <summary>
        /// Event fired when user selects a node with coordinate system
        /// </summary>
        public event CoordinateSystemSelectedDelegate CoordinateSystemSelected;
        
        /// <summary>
        /// A delegate for CoordinateSystemSelected event
        /// </summary>
        /// <param name="cs">Reference to the selected territory (country or coordinate system)</param>
        public delegate void CoordinateSystemSelectedDelegate(Territory cs);
        internal void FireCoordinateSystemSelected(Territory cs)
        {
            if (CoordinateSystemSelected != null)
                CoordinateSystemSelected(cs);
        }

        /// <summary>
        /// Event fired when user selects a node with geographic CS
        /// </summary>
        public event GeographicCSSelectedDelegate GeographicCSSelected;
        
        /// <summary>
        /// A delegate for FireGeographicCSSelected event
        /// </summary>
        /// <param name="gcs">Reference to the selected geographical coordinate system</param>
        public delegate void GeographicCSSelectedDelegate(GeographicCs gcs);
        internal void FireGeographicCSSelected(GeographicCs gcs)
        {
            if (GeographicCSSelected != null)
                GeographicCSSelected(gcs);
        }

        /// <summary>
        /// Event fired when user selects a node with projected CS
        /// </summary>
        public event ProjectedCSSelectedDelegate ProjectedCSSelected;
        
        /// <summary>
        /// A delegate for ProjectedCSSelected event
        /// </summary>
        /// <param name="pcs">Reference to the selected projected coordinate system</param>
        public delegate void ProjectedCSSelectedDelegate(ProjectedCs pcs);
        internal void FireProjectedCSSelected(ProjectedCs pcs)
        {
            if (ProjectedCSSelected != null)
                ProjectedCSSelected(pcs);
        }

        /// <summary>
        /// Fires selection event for coordinate systems
        /// </summary>
        private void ProjectionTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
                switch (e.Node.ImageIndex)
                {
                    case ICON_GLOBE:
                        {
                            GeographicCs gcs = e.Node.Tag as GeographicCs;
                            FireGeographicCSSelected(gcs);
                            FireCoordinateSystemSelected((Territory)gcs);
                            break;
                        }
                    case ICON_MAP:
                        {
                            ProjectedCs pcs = e.Node.Tag as ProjectedCs;
                            FireProjectedCSSelected(pcs);
                            FireCoordinateSystemSelected((Territory)pcs);
                            break;
                        }
                }
            }
        }


        /// <summary>
        /// Changes the icons for the folder
        /// </summary>
        void ProjectionTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (_doubleClickWasDone)
            {
                e.Cancel = true;
                _doubleClickWasDone = false;
                return;
            }
            
            if (e.Node != null)
            {
                if (e.Node.ImageIndex == ICON_FOLDER)
                {
                    e.Node.ImageIndex = ICON_FOLDER_OPEN;
                    e.Node.SelectedImageIndex = ICON_FOLDER_OPEN;
                }
            }
        }

        /// <summary>
        /// Changes the icons for the folder
        /// </summary>
        void ProjectionTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (_doubleClickWasDone)
            {
                e.Cancel = true;
                _doubleClickWasDone = false;
                return;
            }
            
            if (e.Node != null)
            {
                if (e.Node.ImageIndex == ICON_FOLDER_OPEN)
                {
                    e.Node.ImageIndex = ICON_FOLDER;
                    e.Node.SelectedImageIndex = ICON_FOLDER;
                }
            }
        }
        #endregion

        #region Utilities

        /// <summary>
        /// Opens all nodes to show GCS
        /// </summary>
        private void ShowGCS(TreeNode node)
        {
            if (node.ImageIndex == ICON_FOLDER || node.ImageIndex == ICON_FOLDER_OPEN)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    ShowGCS(child);
                }
                node.Expand();
            }
        }

        /// <summary>
        /// Browses through list of CS and marks them as active or not active depending on their bounds
        /// </summary>
        private void ApplyExtents(BoundingBox extents, out int gcsCount, out int projCount)
        {
            gcsCount = 0;
            projCount = 0;

            foreach (Territory cs in _database.GeographicCs)
            {
                cs.IsActive = WithinExtents(extents, cs);
                if (cs.IsActive) gcsCount++;
            }

            foreach (Territory cs in _database.ProjectedCs)
            {
                cs.IsActive = WithinExtents(extents, cs);
                if (cs.IsActive) projCount++;
            }

            foreach (Country country in _database.Countries)
            {
                country.IsActive = WithinExtents(extents, country);
            }
        }

        /// <summary>
        /// Checks whether coordinate system is located within specified extents (taking into account SelectionMode)
        /// </summary>
        private bool WithinExtents(BoundingBox extents, Territory cs)
        {
            switch (_selectionMode)
            {
                case ProjectionSelectionMode.Include:
                    // extents should cover coordinate system
                    return extents.xMin <= cs.Left && extents.xMax >= cs.Right && extents.yMin <= cs.Bottom && extents.yMax >= cs.Top;

                case ProjectionSelectionMode.IsIncluded:
                    // coordinate system should cover extents
                    return cs.Left <= extents.xMin && cs.Right >= extents.xMax && cs.Bottom <= extents.yMin && cs.Top >= extents.yMax;

                case ProjectionSelectionMode.Intersection:
                    // the case of intersection ( the non-intersection hypothesis is checked )
                    return !(cs.Left > extents.xMax || cs.Right < extents.xMin || cs.Bottom > extents.yMax || cs.Top < extents.yMin);

                default:
                    return true;
            }
        }

        /// <summary>
        /// Recusive function which removes all empty folders childs of given node
        /// </summary>
        /// <param name="node"></param>
        private void RemoveEmptyChilds(TreeNode node)
        {
            if (node == null)
                return;

            for (int i = node.Nodes.Count - 1; i >= 0; i--)
            {
                TreeNode child = node.Nodes[i];
                // the end of branch; delete it if it is a folder
                if (child.Nodes.Count == 0)
                {
                    if (child.ImageIndex == ICON_FOLDER || child.ImageIndex == ICON_FOLDER_OPEN)
                    {
                        child.Remove();
                    }
                }
                else
                {
                    RemoveEmptyChilds(child);

                    // if all the branch was removed, delete the node as well
                    if (child.Nodes.Count == 0)
                    {
                        if (child.ImageIndex == ICON_FOLDER || child.ImageIndex == ICON_FOLDER_OPEN)
                        {
                            child.Remove();
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// Suppresses standard double click behavior - expanding/collapsing
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref Message m)
        {
            _doubleClickWasDone = (m.Msg == 515);  /* WM_LBUTTONDBLCLK */
            base.DefWndProc(ref m);
        }

        /// <summary>
        /// Shows projection view for selected projection
        /// </summary>
        private void ProjectionTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowProjectionProperties(SelectedNode.Tag as CoordinateSystem);
        }

        /// <summary>
        /// Shows properties for projection with given code
        /// </summary>
        /// <param name="code"></param>
        public void ShowProjectionProperties(int code)
        {
            foreach (GeographicCs gcs in _database.GeographicCs)
            {
                if (gcs.Code == code)
                {
                    ShowProjectionProperties((CoordinateSystem)gcs);
                    return;
                }
            }

            foreach (ProjectedCs pcs in _database.ProjectedCs)
            {
                if (pcs.Code == code)
                {
                    ShowProjectionProperties(pcs);
                    return;
                }
            }
        }

        /// <summary>
        /// Shows property window for projection
        /// </summary>
        private void ShowProjectionProperties(CoordinateSystem proj)
        {
            if (proj != null)
            {
                ProjectionPropertiesForm form = new ProjectionPropertiesForm(proj, _database);
                form.tabControl1.SelectedIndex = _propertiesTab;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _propertiesTab = form.tabControl1.SelectedIndex;
                }
                form.Dispose();
            }
        }

        /// <summary>
        /// Selects node with the given EPSG code
        /// </summary>
        /// <returns></returns>
        public void SelectNodeByCode(int code)
        {
            TreeNode node = new TreeNode();
            Seek(Nodes, code, node.Nodes);

            MessageService.Current.Info("Found: " + node.Nodes.Count);
        }

        private void Seek(TreeNodeCollection nodes, int code, TreeNodeCollection results)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.ImageIndex == ICON_GLOBE || node.ImageIndex == ICON_MAP)
                {
                    //if (Convert.ToInt32(node.Tag) == code)
                    //{
                    //    results.Add(node);
                    //}
                }
                else
                { 
                    Seek(node.Nodes, code, results);
                }
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ResumeLayout(false);

        }
    }
}
