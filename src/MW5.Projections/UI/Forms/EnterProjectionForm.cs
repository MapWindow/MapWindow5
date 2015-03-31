using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces.Projections;
using MW5.Plugins.Services;
using MW5.UI;

namespace MW5.Projections.UI.Forms
{
    public partial class EnterProjectionForm : MapWindowForm
    {
        // Projections already present in the list
        readonly IEnumerable<string> _existingList;

        // the base coordinate system
        readonly ICoordinateSystem _coordinateSystem;

        // reference to projection database
        readonly IProjectionDatabase _database;
        
        /// <summary>
        /// Creates a new instance of the frmEnterProjection class
        /// </summary>
        public EnterProjectionForm(ICoordinateSystem coordSystem, IEnumerable<string> list, IProjectionDatabase database)
        {
            InitializeComponent();

            _existingList = list;
            _coordinateSystem = coordSystem;
            _database = database;
        }

        /// <summary>
        /// Analyzes user input. Closes the dialog if needed.
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text.Trim();
            ISpatialReference proj = new SpatialReference();

            if (!proj.ImportFromProj4(text))
            {
                if (!proj.ImportFromWkt(text))
                {
                    MessageService.Current.Info("No valid proj4 or WKT string was entered.");
                    return;
                }
            }
            
            ISpatialReference projBase= new SpatialReference();
            if (!projBase.ImportFromEpsg(_coordinateSystem.Code))
            {
                MessageService.Current.Warn("Failed to initialize the base projection.");
                return;
            }
            
            if (projBase.ExportToProj4() == text || projBase.ExportToWkt() == text)
            {
                MessageService.Current.Info("The dialect string is the same as base string");
                return;
            }

            // do we have this string already?
            if (_existingList.Contains(text))
            {
                MessageService.Current.Info("The entered string is already present in the list.");
                return;
            }
            
            // do we have this string as a base one?
            IEnumerable<ICoordinateSystem> list = _database.CoordinateSystems.Where(s => s.Proj4 == text).ToList();
            if (list.Any())
            {
                // no sense try to save it, base strings are processed first on loading all the same
                MessageService.Current.Info("Current string is aready bound to another EPSG code as the base one: " + list.First().Name + "(" + list.First().Code + ")");
                return;
            }

            // is this really a dialect; user will be allowed to save as dialect CS with different parameters, 
            // as sometimes they differ insignificantly because of the rounding
            if (!proj.IsSameExt(projBase, _coordinateSystem.Extents, 5))
            {
                if (!MessageService.Current.Ask("The base projection and its dialect have different transformation parameters." +
                                    "This can lead to incorrect disaply of data." + Environment.NewLine +
                                    "Do you want to save the dialect all the same?"))
                {
                    return;
                }
            }

            // TODO: check whether this dialect is used for some other EPSG code
            DialogResult = DialogResult.OK;
        }
    }
}
