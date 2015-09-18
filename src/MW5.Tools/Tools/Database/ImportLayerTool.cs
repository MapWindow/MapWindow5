using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MW5.Api.Concrete;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Tools.Database
{
    [CustomMemberLayout]
    [GisTool(GroupKeys.GeoDatabases, ToolIcon.Database)]
    public class ImportLayerTool : GisTool
    {
        [Input("Input layer", 0)]
        public IVectorInput InputLayer { get; set; }

        [Output("Database", 0)]
        [ControlHint(ControlHint.Combo)]
        public DatabaseConnection Database { get; set; }

        [Output("Schema", 1)]
        public string Schema { get; set; }

        [Output("New layer name", 2)]
        [ControlHint(ControlHint.OutputName)]
        public string NewLayerName { get; set; }

        [Output("Overwrite", 3)]
        public bool Overwrite { get; set; }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Import layer"; }
        }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Imports layer in the geodatabase."; }
        }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<ImportLayerTool>()
                .AddComboList(t => t.Database, context.Repository.Connections)
                .SetDefault(t => t.NewLayerName, "{input}_imported");
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            string options = PrepareOptions();

            var ds = new VectorDatasource();

            if (ds.Open(Database.ConnectionString))
            {
                if (!ds.ImportLayer(InputLayer.Datasource, NewLayerName, options))
                {
                    Log.Warn("Failed to import shapefile: " + ds.GdalLastErrorMsg, null);
                    return false;
                }

                Log.Info("Layer was imported: " + NewLayerName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Gets a value indicating whether tasks should be executed
        /// in sequence rather than in parallel when running in batch mode.
        /// </summary>
        public override bool SequentialBatchExecution
        {
            get { return true; }
        }

        public override bool SupportsBatchExecution
        {
            get { return true; }
        }

        /// <summary>
        /// Preparing format specific options.
        /// </summary>
        private string PrepareOptions()
        {
            var list = new List<string>();

            if (!string.IsNullOrWhiteSpace(Schema))
            {
                list.Add("SCHEMA=" + Schema);
            }

            if (Database != null && Database.DatabaseType == GeoDatabaseType.MySql)
            {
                list.Add("ENGINE=MyISAM ");    // Spatial indexes aren't supported otherwise http ://stackoverflow.com/questions/18379808/the-used-table-type-doesnt-support-spatial-indexes
            }

            if (Overwrite)
            {
                list.Add("OVERWRITE=TRUE");
            }

            string s = string.Empty;
            foreach (var item in list)
            {
                s += item + ";";
            }

            return s;
        }
    }
}
