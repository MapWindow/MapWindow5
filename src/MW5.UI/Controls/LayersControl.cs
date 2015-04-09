// ----------------------------------------------------------------------------
// MapWindow.Controls.SelectLayerDialog: 
// Author: Sergei Leschinski
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Static;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.UI.Controls
{
    /// <summary>
    /// A dialog for layer selection (either from disk or from project)
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
    [ToolboxBitmap(typeof(OpenFileDialog))]
    public partial class LayersControl : UserControl
    {
        /// <summary>
        /// The type of the control (additional information that is to be displayed)
        /// </summary>
        public enum CustomType
        {
            Default = 0,
            Projection = 1,
        }
        
        #region Declarations
        
        private IAppContext _context;

        // whether it's allowed to select multiple files
        private bool _multiselect;

        // list of selected names
        private IEnumerable<string> _filenames;

        // data grid view columns
        private const int CMN_CHECK = 0;
        private const int CMN_NAME = 1;
        private const int CMN_CUSTOM = 2;

        // The type of the control (addtional info to be displayed)
        private CustomType _controlType = CustomType.Default;
        
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets multiselect property for Open file dialog
        /// </summary>
        public bool Multiselect
        {
            get { return _multiselect; }
            set { _multiselect = value; }
        }

        /// <summary>
        /// Gets index of the custom column
        /// </summary>
        public int CustomColumnIndex
        {
            get { return CMN_CUSTOM; }
        }

        /// <summary>
        /// Gets or sets the type of the control
        /// </summary>
        public CustomType ControlType
        {
            get { return _controlType; }
            set 
            {
                dgv.Columns[CMN_CUSTOM].Visible = (value != CustomType.Default);
                _controlType = value;
                if (_controlType == CustomType.Projection)
                {
                    dgv.Columns[CMN_CUSTOM].HeaderText = "Projection";
                }
            }
        }

        /// <summary>
        /// Returns the list of selected filenames
        /// </summary>
        public IEnumerable<string> Filenames
        {
            get 
            {
                IEnumerable<DataGridViewRow> rows = dgv.Rows.Cast<DataGridViewRow>().Where(row => (bool)row.Cells[CMN_CHECK].Value);
                return rows.Select(row => (string)row.Tag);
            }
        }
        #endregion

        /// <summary>
        /// Creates a new instance of SelectLayerDilaog dialog
        /// </summary>
        public LayersControl()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Initializes the control with the instance of MapWindow class
        /// </summary>
        public void Initialize(IAppContext mapWin)
        {
            _context = mapWin;
            _multiselect = true;
            _controlType = CustomType.Default;
            LayerAdded += LayersControl_LayerAdded;
        }

        #region Adding files
        
        /// <summary>
        /// Opens files from the folder
        /// </summary>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog {Filter = GeoSource.VectorFilter, Multiselect = _multiselect})
            { 
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _filenames = dlg.FileNames;
                    FillGrid();
                }
            }
        }

        /// <summary>
        /// Adds project layers from dialog
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GeometryType[] types = { GeometryType.Polyline, GeometryType.Point, GeometryType.Polygon };
           
            IEnumerable<string> existingNames = from DataGridViewRow row in dgv.Rows select (string)row.Tag;

            LayersDialog dlg = new LayersDialog(_context, types, existingNames);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // first we remove non selected layers if any
                if (dlg.NonSelectedLayers != null)
                {
                    List<DataGridViewRow> deleteList = new List<DataGridViewRow>();
                    var layers = dlg.NonSelectedLayers.Select(l => l.Filename);
                    
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (layers.Contains((string)row.Tag))
                            deleteList.Add(row);
                    }

                    foreach (DataGridViewRow row in deleteList)
                        dgv.Rows.Remove(row);
                }
                
               // the we add any selected ones if there are not here:
                if (dlg.SelectedLayers != null)
                {
                    var layers = dlg.SelectedLayers.Select(l => l.Filename).Where(l => !existingNames.Contains(l));
                    foreach (string filename in layers)
                    {
                        int index = dgv.Rows.Add();
                        dgv[CMN_CHECK, index].Value = true;
                        dgv[CMN_NAME, index].Value = System.IO.Path.GetFileName(filename);
                        dgv.Rows[index].Tag = filename;
                        FireLayerAdded(filename, dgv, index);
                    }
                }

               AutoResizeColumns();
            }
            dlg.Dispose();
        }

        /// <summary>
        /// Fills the list with the filenames
        /// </summary>
        private void FillGrid()
        {
            if (_filenames == null)
            {
                return;
            }

            // prevents duplicated names
            var existingNames = (from DataGridViewRow row in dgv.Rows select (string)row.Tag).ToList();
            var duplicates = _filenames.Where(name => existingNames.Contains(name)).ToList();

            // notifiing the user about duplicates
            if (duplicates.Any())
            {
                string s = "";
                foreach (string name in duplicates)
                {
                    s += Environment.NewLine + name;
                }

                MessageService.Current.Info("Some of the layers are already present in the list:" + s);
            }
            
            foreach (string filename in _filenames)
            {
                if (existingNames.Contains(filename))
                {
                    continue;
                }

                int index = dgv.Rows.Add();
                dgv[CMN_CHECK, index].Value = true;
                dgv[CMN_NAME, index].Value = System.IO.Path.GetFileName(filename);
                dgv.Rows[index].Tag = filename;
                FireLayerAdded(filename, dgv, index);
            }
            _filenames = null;

            AutoResizeColumns();
        }

        /// <summary>
        /// Autosizes the width of colums
        /// </summary>
        private void AutoResizeColumns()
        {
            dgv.AutoResizeColumn(CMN_NAME, DataGridViewAutoSizeColumnMode.AllCells);
            dgv.AutoResizeColumn(CMN_CUSTOM, DataGridViewAutoSizeColumnMode.AllCells);
        }

        /// <summary>
        /// A delegate for LayerAdded event
        /// </summary>
        /// <param name="filename">Filename of the datasource</param>
        /// <param name="rowIndex">Row index</param>
        public delegate void LayerAddedDelegate(string filename, DataGridView dgv, int rowIndex);

        /// <summary>
        /// A delegate for layer removed event. No paramters so far, the goal is just to be able to update the buttons on the client form
        /// </summary>
        public delegate void LayerRemovedDelegate();

        /// <summary>
        /// Event fired when a layer is added to the control
        /// </summary>
        public event LayerAddedDelegate LayerAdded;

        /// <summary>
        /// Event which occurs wien layer is removed from control
        /// </summary>
        public event LayerRemovedDelegate LayerRemoved;

        /// <summary>
        /// Sends LayerAdded event to all listeners
        /// </summary>
        private void FireLayerAdded(string filename, DataGridView dgv,  int rowIndex)
        {
            if (LayerAdded != null)
                LayerAdded(filename, dgv, rowIndex);
        }

        /// <summary>
        /// Sends LayerAdded event to all listeners
        /// </summary>
        private void FireLayerRemoved()
        {
            if (LayerRemoved != null)
                LayerRemoved();
        }

        /// <summary>
        /// Fills custom information
        /// </summary>
        void LayersControl_LayerAdded(string filename, DataGridView dgv, int rowIndex)
        {
            UpdateProjection(filename, dgv, rowIndex);
        }
        #endregion

        
        /// <summary>
        /// Update projection column for a specified layers
        /// </summary>
        private void UpdateProjection(string filename, DataGridView dgv, int rowIndex)
        {
            if (ControlType != CustomType.Projection)
            {
                return;
            }
            
            string name = "" ;
            var sf = new FeatureSet(filename);

            name = sf.Projection.Name;

            var db = _context.Projections;
            if (db != null)
            {
                var cs = db.GetCoordinateSystem(sf.Projection, ProjectionSearchType.UseDialects);
                if (cs != null)
                {
                    name = cs.Name;
                }
            }

            dgv[CustomColumnIndex, rowIndex].Value = name;
            sf.Close();

            if (name == "")
            {
                dgv[CustomColumnIndex, rowIndex].Value = "Undefined";
            }
        }

        /// <summary>
        /// Update projection column for all layers
        /// </summary>
        public void UpdateProjections()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                UpdateProjection(dgv.Rows[i].Tag as string, dgv, i);
            }
        }

        /// <summary>
        /// Clears all the layers from the control
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            FireLayerRemoved();
            AutoResizeColumns();
        }

        /// <summary>
        /// Removes the selected file
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentCell != null)
            {
                dgv.Rows.RemoveAt(dgv.CurrentCell.RowIndex);
                FireLayerRemoved();
                AutoResizeColumns();
            }
        }

        /// <summary>
        /// Gets the name of the selected file in the control ot "" if no file is selected
        /// </summary>
        public string SelectedFilename
        {
            get
            {
                if (dgv.CurrentCell != null)
                {
                    return dgv.Rows[dgv.CurrentCell.RowIndex].Tag.ToString();
                }
                return "";
            }
        }
    }
}
