using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Data.Enums;
using MW5.Data.Properties;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Data.Views.Controls
{
    public class DriversTreeView: TreeViewBase
    {
        private List<DatasourceDriver> _drivers;
        private string _filterToken = string.Empty;
        private DriverFilter _driverFilter = DriverFilter.All;

        public DriversTreeView()
        {
            ShowSuperTooltip = false;
        }

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            return new List<Bitmap>()
            {
                Resources.img_geometry,
                Resources.img_raster
            };
        }

        public void Initialize(DriverManager manager)
        {
            _drivers = manager.ToList();

            BuildList();
        }

        private void BuildList()
        {
            Nodes.Clear();

            AddDrivers(false);

            AddDrivers(true);

            SelectFirstVisibleNode();
        }

        private void AddDrivers(bool vector)
        {
            var vectorNode = new TreeNodeAdv(vector ? "Vector formats" : "Raster formats");

            AddDriverNodes(vectorNode, vector);

            vectorNode.Expanded = true;

            if (vectorNode.Nodes.Count > 0)
            {
                Nodes.Add(vectorNode);
            }
        }

        private void AddDriverNodes(TreeNodeAdv parentNode, bool vector)
        {
            foreach (var driver in _drivers.Where(item => vector && item.IsVector || !vector && item.IsRaster)
                                           .OrderBy(item => item.Name))
            {
                if (driver.MatchesFilter(_filterToken) && driver.MatchesFilter(_driverFilter))
                {
                    parentNode.Nodes.Add(CreateDriverNode(driver, vector));
                }
            }
        }

        private TreeNodeAdv CreateDriverNode(DatasourceDriver driver, bool vector)
        {
            var node = new TreeNodeAdv {Text = driver.Name, Tag = driver};
            node.LeftImageIndices = new[] { vector ? 0 : 1 };
            return node;
        }

        public DatasourceDriver SelectedDriver
        {
            get
            {
                var node = SelectedNode;
                return node != null ? DriverFromNode(node) : null;
            }
        }

        private IEnumerable<TreeNodeAdv> DriverNodes
        {
            get
            {
                foreach (TreeNodeAdv parent in Nodes)
                {
                    foreach (TreeNodeAdv node in parent.Nodes)
                    {
                        yield return node;
                    }    
                }
            }
        }

        private DatasourceDriver DriverFromNode(TreeNodeAdv node)
        {
            return node.Tag as DatasourceDriver;
        }

        public void Filter(string token, DriverFilter filter)
        {
            _filterToken = token;
            _driverFilter = filter;

            BuildList();

            SelectFirstVisibleNode();
        }

        private void SelectFirstVisibleNode()
        {
            var node = DriverNodes.FirstOrDefault(item => item.Height > 0);
            if (node != null)
            {
                SelectedNode = node;
            }
        }
    }
}
