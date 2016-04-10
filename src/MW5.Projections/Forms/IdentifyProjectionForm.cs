// -------------------------------------------------------------------------------------------
// <copyright file="IdentifyProjectionForm.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.Projections.BL;
using MW5.Projections.Helpers;
using MW5.UI.Forms;

namespace MW5.Projections.Forms
{
    /// <summary>
    /// Provides GUI for identification of unknown projection (finding exiting EPSG code for it)
    /// </summary>
    public partial class IdentifyProjectionForm : MapWindowForm
    {
        // Bounds to compare projection
        private readonly IEnvelope _bounds;

        // prevents undesired events on loading        
        private readonly bool _noEvents;

        /// <summary>
        /// Creates a new instance of the frmIdentifyProjection class
        /// </summary>
        public IdentifyProjectionForm(IAppContext context)
            : this(context, null)
        {
        }

        /// <summary>
        /// Constructor with bounds
        /// </summary>
        public IdentifyProjectionForm(IAppContext context, Envelope bounds)
            : base(context)
        {
            InitializeComponent();

            _bounds = bounds;

            _noEvents = true;
            cboLayer.DataSource = _context.Legend.Layers.Where(l => !l.HideFromLegend).OfType<ILayer>().ToList();
            cboLayer.DisplayMember = "Name";
            _noEvents = false;

            if (cboLayer.Items.Count > 0)
            {
                cboLayer.SelectedIndex = 0;
                cboLayer_SelectedIndexChanged(null, null);
            }

            listBox1.DoubleClick += listBox1_MouseDoubleClick;
        }

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
                        MessageService.Current.Info(
                            "The string can't be identified as one of the following formats: proj4, OGC WKT, ESRI WKT.");
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
                listBox1.Items.Add(cs);
                MessageService.Current.Info("Projection was identified.");
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
                        var watch = new Stopwatch();
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

        private void IdentifyProjectionForm_Load(object sender, EventArgs e)
        {
            // Fixing CORE-160
            CaptionFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        #region Interaction

        /// <summary>
        /// Displays projection for the layer
        /// </summary>
        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noEvents)
            {
                return;
            }

            var layer = cboLayer.SelectedValue as ILayer;
            if (layer != null)
            {
                textBox1.Text = layer.Projection.ExportToProj4();
            }
        }

        /// <summary>
        /// Shows properties for the selected CS
        /// </summary>
        private void listBox1_MouseDoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            var cs = listBox1.SelectedItem as CoordinateSystem;
            _context.ShowProjectionProperties(cs, this);
        }

        #endregion
    }
}