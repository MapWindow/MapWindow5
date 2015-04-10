// ----------------------------------------------------------------------------
// MapWindow.Controls.Projections: store controls to work with EPSG projections
// database
// Author: Sergei Leschinski
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Projections.Properties;
using MW5.Projections.UI.Forms;
using MW5.UI.Controls;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.MultiColumnTreeView;
using TreeNodeAdv = Syncfusion.Windows.Forms.Tools.TreeNodeAdv;
using TreeNodeAdvCollection = Syncfusion.Windows.Forms.Tools.TreeNodeAdvCollection;
using TreeViewAdvCancelableNodeEventArgs = Syncfusion.Windows.Forms.Tools.TreeViewAdvCancelableNodeEventArgs;

namespace MW5.Projections.UI.Controls
{
    /// <summary>
    /// A class derived from TreeView, which shows the list of projection of EPSG projection database
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TreeView))]
    public sealed class ProjectionTreeView : TreeViewBase
    {
        #region Declarations

        IProjectionDatabase _database;

        // GCS that should be classified by type (by default the option is off, to ensure performance)
        private readonly Hashtable _dctLocalWithClassification;

        // USA GCS that should be classified by state (NAD)
        private readonly Hashtable _dctUsaStates;

        private ProjectionSelectionMode _selectionMode = ProjectionSelectionMode.Intersection;

        private bool _doubleClickWasDone;

        private ContextMenuStripEx _contextMenu;

        private IAppContext _context;

        private TreeNodeAdv _selectedNode;  // preserving selected node when context menu is showing

        private List<IGeographicCs> _geographicList;

        private TreeNodeAdv _nodeByRegion;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new isntance of ProjectionTreeView class
        /// </summary>
        public ProjectionTreeView()
        {
            //ThemesEnabled = true;         // to show + -

            CreateContextMenu();

            _dctLocalWithClassification = new Hashtable();
            int[] codes = { 4617, 4214, 4490, 4555, 4610, 4612, 4301, 4755, 4283, 4200 };
            foreach (int code in codes)
            {
                _dctLocalWithClassification.Add(code, null);
            }

            _dctUsaStates = new Hashtable();
            int[] codes2 = { 4267, 4269, 4152, 4759 };
            foreach (int code in codes2)
            {
                _dctUsaStates.Add(code, null);
            }

            MouseUp += ProjectionTreeView_MouseUp;
            NodeMouseDoubleClick += (s, e) => ShowProjectionProperties();
            KeyDown += ProjectionTreeView_KeyDown;
            CoordinateSystemPropertiesRequested += ProjectionTreeView_CoordinateSystemPropertiesRequested;
            PrepareToolTip += ProjectionTreeView_PrepareToolTip;

            SetEventHandlers();
        }

        /// <summary>
        /// Sets event handling for the control
        /// </summary>
        private void SetEventHandlers()
        {
            BeforeCollapse += ProjectionTreeView_BeforeCollapse;
            BeforeExpand += ProjectionTreeView_BeforeExpand;
            AfterSelect += ProjectionTreeView_AfterSelect;
        }

        private void ProjectionTreeView_CoordinateSystemPropertiesRequested(object sender, CoordinateSystemEventArgs e)
        {
            var proj = e.CoordinateSystem;
            if (proj != null)
            {
                using (var form = new ProjectionPropertiesForm(proj, _database))
                {
                    if (_context != null)
                    {
                        _context.View.ShowChildView(form, FindForm());
                    }
                    else
                    {
                        form.ShowDialog(FindForm());
                    }
                }
            }
        }

        private void ProjectionTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowProjectionProperties();
            }
        }

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            return new[]
            {
                Resources.img_folder,
                Resources.img_folder_open,
                Resources.img_globe,
                Resources.img_map,
                Resources.img_map_add,
                Resources.img_map_delete
            };
        }

        #endregion

        #region Initialization

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

            _geographicList = _database.GeographicCs;
            _geographicList.Sort((cs1, cs2) => cs1.Name.CompareTo(cs2.Name));

            return true;
        }

        #endregion

        #region Double buffering
        
        //http ://stackoverflow.com/questions/10362988/treeview-flickering

        protected override void OnHandleCreated(EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }
        
        // Pinvoke:
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        #endregion

        #region Context Menu
        
        /// <summary>
        /// Creates a context menu associated with nodes
        /// </summary>
        private void CreateContextMenu()
        {
            _contextMenu = new ContextMenuStripEx
            {
                ImageList = LeftImageList,
                Style = ContextMenuStripEx.ContextMenuStyle.Metro,
                RenderMode = ToolStripRenderMode.Professional
            };
            _contextMenu.Items.Add(Constants.ContextAddToFavorite).ImageIndex = Constants.IconPlus;
            _contextMenu.Items.Add(Constants.ContextRemoveFromFavorite).ImageIndex = Constants.IconMinus;
            _contextMenu.Items.Add(new ToolStripSeparator());
            _contextMenu.Items.Add(Constants.ContextShowProperties);

            foreach (ToolStripItem item in _contextMenu.Items)
            {
                item.Name = item.Text;
            }

            _contextMenu.ItemClicked +=ContextMenuItemClicked;
        }

        void ProjectionTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            var node = PointToNode(new Point(e.X, e.Y));
            if (node == null)
            {
                return;
            }

            HideToolTip();

            SelectedNode = node;

            if (IsProjectionNode(node))
            {
                var nodeFavorite = Nodes.Find(Constants.NodeFavorite);

                bool favorite = node.Parent == nodeFavorite;
                _contextMenu.Items[Constants.ContextAddToFavorite].Visible = !favorite;
                _contextMenu.Items[Constants.ContextRemoveFromFavorite].Visible = favorite;

                _selectedNode = node;
                Rectangle r = RectangleToScreen(ClientRectangle);
                _contextMenu.Show(r.Left + e.X, r.Top + e.Y);
            }
        }

        /// <summary>
        /// Executes context menu commands
        /// </summary>
        private void ContextMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _contextMenu.Hide();
            Application.DoEvents();
            switch (e.ClickedItem.Text)
            {
                case Constants.ContextAddToFavorite:
                    AddProjectionToFavorite(_selectedNode.Tag as CoordinateSystem);
                    break;
                case Constants.ContextShowProperties:
                    FireCoordinateSystemPropertiesRequested(_selectedNode.Tag as CoordinateSystem);
                    break;
                case Constants.ContextRemoveFromFavorite:
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

            var nodeFavorite = Nodes.Find(Constants.NodeFavorite);
            if (nodeFavorite != null)
            {
                Nodes.Remove(nodeFavorite);
            }

            nodeFavorite = Nodes.CreateNode(Constants.NodeFavorite, Constants.NodeFavorite, Constants.IconFolder);
            Nodes.Insert(0, nodeFavorite);

            if (_context != null)
            {
                var list  = _context.Config.FavoriteProjections;
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
                        var nodeGcs = nodeFavorite.Nodes.Add(gcs.Code.ToString(), gcs.Name, Constants.IconGlobe);
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
                        var nodePcs = nodeFavorite.Nodes.Add(pcs.Code.ToString(), pcs.Name, Constants.IconMap);
                        nodePcs.Tag = pcs;
                        count++;
                    }

                    nodeFavorite.ExpandAll();

                    var nodeWorld = Nodes.Find(Constants.NodeByRegion);
                    if (nodeWorld != null && count < 5)
                    {
                        nodeWorld.Expand();
                    }
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

                if (IsProjectionNode(SelectedNode))
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
            gcsCount = 0;
            projCount = 0;

            if (_database == null)
            {
                throw new Exception("No database was specified to populate tree view");
            }

            BeginUpdate();
            Nodes.Clear();

            // limits coordinate systems to those which fall into extents
            bool showFullExtents = extents.xMin == -180.0 && extents.xMax == 180.0 && extents.yMin == -90.0 && extents.yMax == 90.0;

            ApplyExtents(extents, out gcsCount, out projCount);

            // adding top-most nodes
            _nodeByRegion = Nodes.Add(Constants.NodeByRegion, Constants.NodeByRegion, Constants.IconFolder);
            

            FillRegions(_nodeByRegion, showFullExtents);

            // global GCS
            var list2 = _database.GeographicCs.Where(cs => cs.Type == GeographicalCsType.Global && cs.IsActive).OrderBy(cs => cs.Name);
            foreach (var gcs in list2)
            {
                if (gcs.Scope == Constants.ScopeNotRecommended || gcs.Name.ToLower().StartsWith("unspecified"))
                {
                    continue;
                }

                var nodeGcs = _nodeByRegion.Nodes.Add(gcs.Code.ToString(), gcs.Name, Constants.IconGlobe);
                nodeGcs.Tag = gcs;
                AddProjections(nodeGcs, gcs, gcs.Projections.Where(cs => !cs.Local));
            }

            RemoveEmptyChildren(_nodeByRegion);

            UpdateFavoriteList();

            EndUpdate();

            return true;
        }

        private void FillSearchResults(TreeNodeAdv nodeAll, string token)
        {
            foreach (var cs in _geographicList)
            {
                var node = nodeAll.Nodes.CreateNode(cs.Code.ToString(), cs.Name, Constants.IconGlobe);
                node.Tag = cs;

                foreach (var p in cs.Projections)
                {
                    if (p.Filter(token))
                    {
                        var childNode = node.Nodes.Add(p.Code.ToString(), p.Name, Constants.IconMap);
                        childNode.Tag = p;
                    }
                }

                if (node.Nodes.Count > 0 || cs.Filter(token))
                {
                    nodeAll.Nodes.Add(node);
                    node.Expanded = true;
                }
            }
        }

        private void FillRegions(TreeNodeAdv nodeWorld, bool showFullExtents)
        {
            // adding regions
            Hashtable dctRegions = new Hashtable();
            var listRegions = _database.Regions.Where(r => r.ParentCode == 1);
            foreach (var region in listRegions)
            {
                var nodeRegion = nodeWorld.Nodes.Add(region.Code.ToString(), region.Name, Constants.IconFolder);
                dctRegions.Add(region.Code, nodeRegion);
            }

            // local GCS
            var listRegions2 = _database.Regions.Where(r => r.ParentCode > 1 && dctRegions.ContainsKey(r.ParentCode));
            foreach (var region in listRegions2)
            {
                var nodeRegion = dctRegions[region.ParentCode] as TreeNodeAdv;
                var nodeSubregion = nodeRegion.Nodes.Add(region.Code.ToString(), region.Name, Constants.IconFolder);
                dctRegions.Add(region.Code, nodeSubregion);

                var listCountries = region.Countries.Where(cn => cn.IsActive).Where(c => c.GeographicCs.Any(cs => cs.IsActive));
                foreach (var country in listCountries)
                {
                    TreeNodeAdv nodeCountry = null;   // it's to difficult to determine whether the country should be shown

                    foreach (GeographicCs gcs in country.GeographicCs.Where(cs => cs.IsActive).OrderBy(gcs => gcs.Name))
                    {
                        // when extents are limited, no need to show global systems for each country
                        if (!showFullExtents && gcs.Type != GeographicalCsType.Local)
                        {
                            continue;
                        }

                        if (gcs.Type != GeographicalCsType.Local || _dctLocalWithClassification.ContainsKey(gcs.Code))
                        {
                            var projections = new List<ProjectedCs>();
                            foreach (int code in country.ProjectedCs)
                            {
                                ProjectedCs pcs = gcs.ProjectionByCode(code);
                                if (pcs != null && pcs.IsActive)
                                {
                                    projections.Add(pcs);
                                }
                            }

                            if (projections.Any())
                            {
                                // country node will be added only here
                                if (nodeCountry == null)
                                {
                                    nodeCountry = nodeSubregion.Nodes.Add(country.Code.ToString(), country.Name, Constants.IconFolder);
                                }

                                var nodeGcs = nodeCountry.Nodes.Add(gcs.Code.ToString(), gcs.Name, Constants.IconGlobe);
                                nodeGcs.Tag = gcs;
                                AddProjections(nodeGcs, gcs, projections);
                            }
                        }
                        else
                        {
                            if (nodeCountry == null)
                            {
                                nodeCountry = nodeSubregion.Nodes.Add(country.Code.ToString(), country.Name, Constants.IconFolder);
                            }

                            // local GCS should be added to country even if there is no projection specified
                            var nodeGcs = nodeCountry.Nodes.Add(gcs.Code.ToString(), gcs.Name, Constants.IconGlobe);
                            nodeGcs.Tag = gcs;

                            foreach (var pcs in gcs.Projections.OrderBy(cs => cs.Name))
                            {
                                var nodePcs = nodeGcs.Nodes.Add(pcs.Code.ToString(), pcs.Name, Constants.IconMap);
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
                var nodeRegion = dctRegions[gcs.RegionCode] as TreeNodeAdv;
                var nodeGcs = nodeRegion.Nodes.Add(gcs.Code.ToString(), gcs.Name, Constants.IconGlobe);
                nodeGcs.Tag = gcs;
                AddProjections(nodeGcs, gcs, gcs.Projections.Where(cs => !cs.Local));
            }
        }

        /// <summary>
        /// Adding projections for a gcs node
        /// </summary>
        private void AddProjections(TreeNodeAdv parentNode, IGeographicCs gcs, IEnumerable<IProjectedCs> projections)
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
                TreeNodeAdv nodeStates = null;

                foreach (string state in states)
                {
                    var list = projections.Where(p => p.Name.Contains(state));
                    if (list.Any())
                    {
                        if (nodeStates == null)
                        {
                            nodeStates = parentNode.Nodes.Add("States", "States", Constants.IconFolder);
                        }

                        var nodeState = nodeStates.Nodes.Add(state, state, Constants.IconFolder);
                        foreach (ProjectedCs pcs in list)
                        {
                            var node = nodeState.Nodes.Add(pcs.Code.ToString(), pcs.Name, Constants.IconMap);
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
                            var nodeType = parentNode.Nodes.Add(type, type, Constants.IconFolder);
                            var projList = projections.Select(cs => cs).Where(c => c.ProjectionType == type);
                            foreach (var val in projList)
                            {
                                var nodePcs = nodeType.Nodes.Add(val.Code.ToString(), val.Name, Constants.IconMap);
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
                        var nodePcs = parentNode.Nodes.Add(pcs.Code.ToString(), pcs.Name, Constants.IconMap);
                        nodePcs.Tag = pcs;
                    }
                }
            }
            else
            {
                foreach (ProjectedCs pcs in projections)
                {
                    var nodePcs = parentNode.Nodes.Add(pcs.Code.ToString(), pcs.Name, Constants.IconMap);
                    nodePcs.Tag = pcs;
                }
            }
        }
        #endregion

        #region Tree view events

        /// <summary>
        /// Event fired when user selects a node with coordinate system
        /// </summary>
        public event EventHandler<CoordinateSystemEventArgs> CoordinateSystemSelected;

        public event EventHandler<CoordinateSystemEventArgs> CoordinateSystemPropertiesRequested;

        private void FireCoordinateSystemPropertiesRequested(CoordinateSystem cs)
        {
            var handler = CoordinateSystemPropertiesRequested;
            if (handler != null)
            {
                handler(this, new CoordinateSystemEventArgs() { CoordinateSystem = cs });
            }
        }

        private void FireCoordinateSystemSelected(CoordinateSystem cs)
        {
            var handler = CoordinateSystemSelected;
            if (handler != null)
            {
                handler(this, new CoordinateSystemEventArgs() { CoordinateSystem = cs });
            }
        }
        
        /// <summary>
        /// Fires selection event for coordinate systems
        /// </summary>
        private void ProjectionTreeView_AfterSelect(object sender, EventArgs e)
        {
            var node = SelectedNode;

            switch (node.GetImageIndex())
            {
                case Constants.IconGlobe:
                {
                    var gcs = node.Tag as GeographicCs;
                    FireCoordinateSystemSelected(gcs);
                    break;
                }
                case Constants.IconMap:
                {
                    var pcs = node.Tag as ProjectedCs;
                    FireCoordinateSystemSelected(pcs);
                    break;
                }
            }
        }

        /// <summary>
        /// Changes the icons for the folder
        /// </summary>
        private void ProjectionTreeView_BeforeExpand(object sender, TreeViewAdvCancelableNodeEventArgs e)
        {
            if (_doubleClickWasDone)
            {
                e.Cancel = true;
                _doubleClickWasDone = false;
                return;
            }

            if (e.Node != null)
            {
                if (e.Node.GetImageIndex() == Constants.IconFolder)
                {
                    e.Node.LeftImageIndices = new[] {Constants.IconFolderOpen };
                }
            }
        }

        /// <summary>
        /// Changes the icons for the folder
        /// </summary>
        private void ProjectionTreeView_BeforeCollapse(object sender, TreeViewAdvCancelableNodeEventArgs e)
        {
            if (_doubleClickWasDone)
            {
                e.Cancel = true;
                _doubleClickWasDone = false;
                return;
            }

            if (e.Node != null)
            {
                if (e.Node.GetImageIndex() == Constants.IconFolderOpen)
                {
                    e.Node.LeftImageIndices = new[] {Constants.IconFolder};
                }
            }
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Opens all nodes to show GCS
        /// </summary>
        private void ShowGcs(TreeNode node)
        {
            if (node.ImageIndex == Constants.IconFolder || node.ImageIndex == Constants.IconFolderOpen)
            {
                foreach (TreeNode child in node.Nodes)
                {
                    ShowGcs(child);
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
        /// Recursively removes all empty folders childs of given node
        /// </summary>
        private void RemoveEmptyChildren(TreeNodeAdv node)
        {
            if (node == null)
            { 
                return;
            }

            for (int i = node.Nodes.Count - 1; i >= 0; i--)
            {
                var child = node.Nodes[i];
                
                // the end of branch; delete it if it is a folder
                if (child.Nodes.Count == 0)
                {
                    if (child.GetImageIndex() == Constants.IconFolder || child.GetImageIndex() == Constants.IconFolderOpen)
                    {
                        child.Remove();
                    }
                }
                else
                {
                    RemoveEmptyChildren(child);

                    // if all the branch was removed, delete the node as well
                    if (child.Nodes.Count == 0)
                    {
                        if (child.GetImageIndex() == Constants.IconFolder || child.GetImageIndex() == Constants.IconFolderOpen)
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
        protected override void DefWndProc(ref Message m)
        {
            _doubleClickWasDone = (m.Msg == 515);  /* WM_LBUTTONDBLCLK */
            base.DefWndProc(ref m);
        }

        private void ShowProjectionProperties()
        {
            HideToolTip();
            FireCoordinateSystemPropertiesRequested(SelectedCoordinateSystem);
        }

        /// <summary>
        /// Shows properties for projection with given code
        /// </summary>
        public void ShowProjectionProperties(int code)
        {
            foreach (GeographicCs gcs in _database.GeographicCs)
            {
                if (gcs.Code == code)
                {
                    FireCoordinateSystemPropertiesRequested(gcs);
                    return;
                }
            }

            foreach (ProjectedCs pcs in _database.ProjectedCs)
            {
                if (pcs.Code == code)
                {
                    FireCoordinateSystemPropertiesRequested(pcs);
                    return;
                }
            }
        }


        public void Filter(string text, bool force = false)
        {
            BeginUpdate();

            try
            {
                bool empty = string.IsNullOrWhiteSpace(text) || (!force && text.Length <= 2);

                var nodeRegion = Nodes.Find(Constants.NodeByRegion);
                if (!empty && nodeRegion.Expanded)
                {
                    nodeRegion.Expanded = false;
                }
                nodeRegion.Height = empty ? Constants.NodeHeight : 0;    // removing and adding the node works much slower

                var nodeSearch = Nodes.Find(Constants.SearchResults);
                
                if (empty && nodeSearch != null)
                {
                    Nodes.Remove(nodeSearch);
                }

                if (!empty)
                {
                    if (nodeSearch == null)
                    {
                        nodeSearch = Nodes.Add(Constants.SearchResults, Constants.SearchResults, Constants.IconFolder);
                    }
                    else
                    {
                        nodeSearch.Nodes.Clear();        
                    }
                }

                if (!empty)
                {
                    FillSearchResults(nodeSearch, text);
                    nodeSearch.Expanded = true;
                }
            }
            finally
            {
                EndUpdate();
            }
        }

        private bool IsProjectionNode(TreeNodeAdv node)
        {
            return node.GetImageIndex() == Constants.IconGlobe || node.GetImageIndex() == Constants.IconMap;
        }

        private void ProjectionTreeView_PrepareToolTip(object sender, ToolTipEventArgs e)
        {
            var cs = SelectedCoordinateSystem;
            if (cs == null)
            {
                e.Cancel = true;
                return;
            }

            var info = e.ToolTip;
            info.Header.Text = cs.Name;
            info.Body.Text = cs.Scope + Environment.NewLine + cs.Proj4;
            info.Footer.Text = "EPSG: " + cs.Code;
        }
    }
}
