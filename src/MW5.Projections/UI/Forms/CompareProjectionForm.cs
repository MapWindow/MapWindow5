using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Interfaces.Projections;
using MW5.UI;

namespace MW5.Projections.UI.Forms
{
    public partial class CompareProjectionForm : MapWindowForm
    {
        // project projection
        private readonly ISpatialReference _projectProj;

        // layer projection
        private readonly ISpatialReference _layerProj;

        private readonly IProjectionDatabase _database;

        /// <summary>
        /// Creates a new instance of the frmProjectionCompare class
        /// </summary>
        public CompareProjectionForm(ISpatialReference projectProj, ISpatialReference layerProj, IProjectionDatabase database)
        {
            InitializeComponent();

            _projectProj = projectProj;
            _layerProj = layerProj;
            _database = database;

            lblProject.Text = "Project: " + projectProj.Name;
            lblLayer.Text = "Layer: " + layerProj.Name;

            txtProject.Text = projectProj.ExportToProj4();
            txtLayer.Text = layerProj.ExportToProj4();

            btnLayer.Click += (s, e) => ShowProjectionProperties(_layerProj);

            btnProject.Click += (s, e) => ShowProjectionProperties(_layerProj);
        }

        /// <summary>
        /// Shows properties for the selected projection
        /// </summary>
        private void ShowProjectionProperties(ISpatialReference proj)
        {
            if (proj == null || proj.IsEmpty)
                return;

            ICoordinateSystem cs = null;
            if (_database != null)
            {
                cs = _database.GetCoordinateSystem(proj, ProjectionSearchType.Enhanced);
            }

            if (cs != null)
            {
                using (var form = new ProjectionPropertiesForm(cs, _database))
                {
                    form.ShowDialog(this);
                }
            }
            else
            {
                using (var form = new ProjectionPropertiesForm(proj))
                {
                    form.ShowDialog(this);
                }
            }
        }
    }
}
