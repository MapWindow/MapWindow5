using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Gdal.Helpers;
using MW5.Gdal.Model;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;
using MW5.UI.Style;

namespace MW5.Gdal.Views
{
    /// <summary>
    /// UI for tools that perform conversion. 
    /// </summary>
    /// <remarks>Sets output extension and list of output types depending on the selected driver.</remarks>
    public partial class GdalConvertView : GdalDriverOptionsView, IGdalConvertView
    {
        public GdalConvertView(IAppContext context, ParameterControlGenerator controlGenerator, IStyleService styleService)
            : base(context, controlGenerator, styleService)
        {
            InitializeComponent();
        }

        protected override void OnDriverChanged(DatasourceDriver driver)
        {
            base.OnDriverChanged(driver);

            var tool = Model.Tool as IParametrizedTool;
            if (tool == null)
            {
                return;
            }

            // update output name
            UpdateOutputFilename(tool, driver);

            // updating list of datatypes
            UpdateDataTypes(driver);
        }

        private void UpdateDataTypes(DatasourceDriver driver)
        {
            var tool = Model.Tool as GisTool;
            if (tool == null)
            {
                return;
            }

            var p = tool.FindParameter<GdalRasterTool, string>(t => t.OutputType) as OptionsParameter;
            if (p == null)
            {
                return;
            }

            var ctrl = p.Control as ComboParameterControl;
            if (ctrl != null)
            {
                var types = driver.GetCreationDataTypes();
                ctrl.SetOptions(types);
            }
        }

        /// <summary>
        /// Updates output extension when active driver changes.
        /// </summary>
        private void UpdateOutputFilename(IParametrizedTool tool, DatasourceDriver driver)
        {
            var input = tool.GetInputParameter() as FilenameParameter;
            if (input == null)
            {
                return;
            }

            foreach (var p in tool.Parameters.OfType<OutputLayerParameter>())
            {
                var ctrl = p.Control as IOuputputParameterControl;
                if (ctrl != null)
                {
                    string ext = driver.Extension;
                    if (string.IsNullOrWhiteSpace(ext))
                    {
                        // sometimes there is no extension in the driver metadata
                        ext = "???";
                    }

                    ctrl.SetExtension(ext);
                }
            }
        }
    }
}
