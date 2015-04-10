using System;
using System.Collections;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Projections.UI.Forms
{
    /// <summary>
    /// Shows list of options to choose from
    /// </summary>
    internal partial class ProjectionMismatchForm : MapWindowForm
    {
        private new readonly IAppContext _context;
        private ISpatialReference _projectProj;
        private ISpatialReference _layerProj;

        public ProjectionMismatchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of frmProjectionMismatch class. ShowProjectionMismatch and ShowProjectionAbsence
        /// calls are needed to to the job.
        /// </summary>
        internal ProjectionMismatchForm(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            btnLayer.Click += delegate
            {
                using (var form = new CompareProjectionForm(_context, _projectProj, _layerProj))
                {
                    _context.View.ShowChildView(form, this);
                }
            };
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                DialogResult = DialogResult.OK;
            }
        }
      
        /// <summary>
        /// Shows list of options for projection mismatch situations
        /// </summary>
        public int ShowProjectionMismatch(ArrayList list, int selectedIndex, ISpatialReference projectProj, ISpatialReference layerProj, out bool useForOthers, out bool dontShow)
        {
            if (projectProj == null || layerProj == null)
            {
                throw new ArgumentException("No projections for mismatch dialog specified");
            }

            _projectProj = projectProj;
            _layerProj = layerProj;

            Text = "Projection mismatch";
            lblMessage.Text = "Layer coordinate system is different from the coordinate system of the map." + Environment.NewLine + 
                              "How do you want to handle this?";

            return ShowProjectionDialog(list, selectedIndex, out useForOthers, out dontShow);
        }

        /// <summary>
        /// Shows projection absence dialog
        /// </summary>
        public int ShowProjectionAbsence(ArrayList list, int selectedIndex, ISpatialReference projectProj, out bool useForOthers, out bool dontShow)
        {
            if (projectProj == null)
            {
                throw new ArgumentException("No projections for mismatch dialog specified");
            }

            _projectProj = projectProj;

            Text = "Missing projection file";
            lblMessage.Text = "This layer's projection is unknown" + Environment.NewLine + 
                               "How do you want to handle this?";

            btnLayer.Visible = false;
            return ShowProjectionDialog(list, selectedIndex, out useForOthers, out dontShow);
        }

        /// <summary>
        /// Shows the dialog
        /// </summary>
        private int ShowProjectionDialog(ArrayList list, int selectedIndex, out bool useForOthers, out bool neverShowDialog)
        {
            if (list.Count == 0) throw new ArgumentException("List of options must not be empty");

            listBox1.DataSource = list;
            if (selectedIndex > 0 && selectedIndex < listBox1.Items.Count)
            {
                listBox1.SelectedIndex = selectedIndex;
            }
            else if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }

            bool result = _context.View.ShowChildView(this);

            int index = result ? listBox1.SelectedIndex : -1;
            neverShowDialog = chkShowMismatchWarning.Checked;
            useForOthers = chkUseAnswerLater.Checked;

            return index;
        }        
    }
}
