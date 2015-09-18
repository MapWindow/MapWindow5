using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.Helpers;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents control that allow to edit geoprojection parameter.
    /// </summary>
    public partial class ProjectionParameterControl : ParameterControlBase
    {
        private readonly IAppContext _context;

        public ProjectionParameterControl(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets control caption.
        /// </summary>
        public override string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return textBoxExt1; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>Value type that must match the type of parameter the control was generated for.</returns>
        public override object GetValue()
        {
            var sr = new SpatialReference();
            bool result = sr.ImportFromAutoDetect(textBoxExt1.Text);
            return result ? sr : null;
        }

        /// <summary>
        /// Sets the value. 
        /// </summary>
        /// <param name="value">Value type must match the type of parameter the control was generated for.</param>
        public override void SetValue(object value)
        {
            var sr = value as ISpatialReference;
            if (sr != null)
            {
                textBoxExt1.Text = sr.ExportToWkt();
                return;
            }

            var s = value as string ?? string.Empty;
            textBoxExt1.Text = s;
        }

        /// <summary>
        /// Opens dialog to choose a projection.
        /// </summary>
        private void OnEditClick(object sender, EventArgs e)
        {
            int epsg = _context.ChooseEpsgProjection();
            if (epsg == -1)
            {
                return;
            }

            var sr = new SpatialReference();
            if (!sr.ImportFromEpsg(epsg))
            {
                MessageService.Current.Warn("Failed to initialize selected projection.");
                return;
            }

            textBoxExt1.Text = sr.ExportToWkt();
        }
    }
}
