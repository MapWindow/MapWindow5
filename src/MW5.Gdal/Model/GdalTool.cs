// -------------------------------------------------------------------------------------------
// <copyright file="GdalTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Linq;
using MW5.Api.Concrete;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Gdal.Model
{
    public abstract class GdalTool : GisTool, IGdalTool
    {
        protected readonly CommandLineMapping _commandLine = new CommandLineMapping();

        public GdalTool()
        {
            InitCommandLine();
        }

        public virtual OutputLayerInfo Output { get; set; }

        [Input("Additional options", -1)]
        [ParameterType(ParameterType.MultiLineString)]
        public string AdditionalOptions { get; set; }

        // The UI for them will be generated dynamically depending on driver
        public string DriverOptions { get; set; }

        /// <summary>
        /// Gets command line options.
        /// </summary>
        public abstract string GetOptions(bool mainOnly = false);

        /// <summary>
        /// Initializes the command line options. Use _commandLine variable to do it.
        /// </summary>
        protected abstract void InitCommandLine();

        /// <summary>
        /// Gets a value indicating whether current tool can specify driver creation options.
        /// </summary>
        public virtual bool SupportDriverCreationOptions
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the list of drivers that support the creation of new datasources.
        /// </summary>
        protected abstract bool DriverFilter(DatasourceDriver driver);

        /// <summary>
        /// Can be used to save results of the processing or display messages.
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        public override bool AfterRun()
        {
            return OutputManager.HandleGdalOutput(Output);
        }
    }
}