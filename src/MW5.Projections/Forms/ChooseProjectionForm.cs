
using System;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.Projections.Services;
using MW5.UI;

namespace MW5.Projections.Forms
{
    /// <summary>
    /// Simple GUI fro choosing projection
    /// </summary>
    public partial class ChooseProjectionForm : MapWindowForm
    {
        /// <summary>
        /// Creates a new instance of frmProjectionChooser class
        /// It's assumed that database isn't read yet
        /// </summary>
        public ChooseProjectionForm(IAppContext context):
            base(context)
        {
            InitializeComponent();
            if (_projectionTreeView1.InitializeByExePath(Application.ExecutablePath, context))
            {
                _projectionTreeView1.RefreshList();
            }
        }
        
        /// <summary>
        /// Creates a new instance of frmProjectionChooser class. 
        /// It's assumed that database is read already.
        /// </summary>
        public ChooseProjectionForm(IProjectionDatabase database, IAppContext mapWin)
        {
            InitializeComponent();
            if (_projectionTreeView1.Initialize(database, mapWin))
            {
                _projectionTreeView1.RefreshList();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_projectionTreeView1.SelectedCoordinateSystem != null)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageService.Current.Info("No projection is selected");
            }
        }
    }
}
