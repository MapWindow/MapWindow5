
using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Projections.Services;
using MW5.UI;

namespace MW5.Projections.Forms
{
    /// <summary>
    /// Provides GUI for identification of unknown projection (finding exiting EPSG code for it)
    /// </summary>
    public partial class IdentifyProjectionForm : MapWindowForm
    {
        private readonly IAppContext _context;

        // Bounds to compare projection
        private readonly IEnvelope _bounds;

        // prevents undesired events on loading        
        private readonly bool _noEvents;

        #region Initilization
        /// <summary>
        /// Creates a new instance of the frmIdentifyProjection class
        /// </summary>
        public IdentifyProjectionForm(IAppContext context): this(context, null)
        {
        }

        /// <summary>
        /// Constructor with bounds
        /// </summary>
        public IdentifyProjectionForm(IAppContext context, Envelope bounds):
            base(context)
        {
            InitializeComponent();

            _bounds = bounds;

            _noEvents = true;
            cboLayer.DataSource = _context.Legend.Layers.Where(l => !l.HideFromLegend).ToList();
            cboLayer.DisplayMember = "Name";
            cboLayer.ValueMember = "Handle";
            _noEvents = false;

            if (cboLayer.Items.Count > 0)
            {
                cboLayer.SelectedIndex = 0;
                cboLayer_SelectedIndexChanged(null, null);
            }
        }
        #endregion

        #region Interaction
        /// <summary>
        /// Displays projection for the layer
        /// </summary>
        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noEvents)
                return;

            var layer = _context.Layers[(int)cboLayer.SelectedValue];
            if (layer != null)
            {
                textBox1.Text = layer.Projection.ToString();
            }
        }

        /// <summary>
        /// Shows properties for the selected CS
        /// </summary>
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }
            
            var cs = listBox1.SelectedItem as CoordinateSystem;
            using (var form = new ProjectionPropertiesForm(cs, _context.Projections))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // do something
                }
            }
        }
        #endregion

        #region Identification
        /// <summary>
        /// Starts identification
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageService.Current.Info("No input projection is specified");
                return;
            }
            
            ISpatialReference proj = new SpatialReference();
            if (!proj.ImportFromProj4(textBox1.Text))
            {
                if (!proj.ImportFromWkt(textBox1.Text))
                {
                    if (!proj.ImportFromEsri(textBox1.Text))
                    {
                        MessageService.Current.Info("The string can't be identified as one of the following formats: proj4, OGC WKT, ESRI WKT.");
                        return;
                    }
                }
            }

            var db = _context.Projections;
            if (db == null)
            {
                MessageService.Current.Info("Projection database wasn't loaded");
                return;
            }

            listBox1.Items.Clear();
                
            var cs = db.GetCoordinateSystem(proj, ProjectionSearchType.UseDialects);
            if (cs != null)
            {
                // easy case - it was found by name
                listBox1.Items.Add(cs);
                MessageService.Current.Warn("Projection was identified.");
                return;
            }

            if (listBox1.Items.Count == 0 || !chkBreak.Checked)
            {
                Cursor oldCursor = Cursor;
                Cursor = Cursors.WaitCursor;

                try
                {
                    // difficult one
                    ISpatialReference projTest = new SpatialReference();
                    bool isSame = false;

                    if (proj.IsGeographic)
                    {
                        foreach (IGeographicCs gcs in db.GeographicCs)
                        {
                            if (projTest.ImportFromProj4(gcs.Proj4))
                            {
                                isSame = _bounds != null ? projTest.IsSameExt(proj, _bounds, 6) : projTest.IsSame(proj);

                                if (isSame)
                                {
                                    listBox1.Items.Add(gcs);
                                    if (chkBreak.Checked)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (proj.IsProjected)
                    {
                        var watch = new System.Diagnostics.Stopwatch();
                        watch.Start();
                        
                        int count = 0;

                        foreach (IProjectedCs pcs in db.ProjectedCs)
                        {
                            if (projTest.ImportFromProj4(pcs.Proj4))
                            {
                                count++;

                                isSame = _bounds != null ? projTest.IsSameExt(proj, _bounds, 6) : projTest.IsSame(proj);

                                if (isSame)
                                {
                                    listBox1.Items.Add(pcs);
                                    if (chkBreak.Checked)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Cursor = oldCursor;
                }
            }

            MessageService.Current.Warn(listBox1.Items.Count == 0
                ? "Projection isn't present in the database."
                : "Projection was identified. One of the listed projections should be the right one.");
        }
        #endregion

        #region Additional
        /// <summary>
        /// Adds proj4 string for database
        /// </summary>
        private void btnUpdateDb_Click(object sender, EventArgs e)
        {
            var db = _context.Projections;
            if (db != null)
            {
                db.UpdateProj4Strings(db.Name);
            }
        }
        #endregion
    }
}
