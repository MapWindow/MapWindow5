using System;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.UI;

namespace MW5.Projections.UI.Forms
{
    public partial class CompareProjectionForm : MapWindowForm
    {
        private readonly ISpatialReference _layerProj;

        /// <summary>
        /// Creates a new instance of the frmProjectionCompare class
        /// </summary>
        public CompareProjectionForm(IAppContext context, ISpatialReference projectProj, ISpatialReference layerProj)
            : base(context)
        {
            if (context == null) throw new ArgumentNullException("context");
            InitializeComponent();

            _layerProj = layerProj;

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
            {
                return;
            }

            ICoordinateSystem cs = null;
            if (_context.Projections != null)
            {
                cs = _context.Projections.GetCoordinateSystem(proj, ProjectionSearchType.Enhanced);
            }

            if (cs != null)
            {
                using (var form = new ProjectionPropertiesForm(cs, _context.Projections))
                {
                    _context.View.ShowChildView(form, this);
                }
            }
            else
            {
                using (var form = new ProjectionPropertiesForm(proj))
                {
                    _context.View.ShowChildView(form, this);
                }
            }
        }
    }
}
