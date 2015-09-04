using System.Collections.Generic;
using MW5.Api.Concrete;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Tools.Database
{
    [GisTool(GroupKeys.GeoDatabases, ToolIcon.Database)]
    public class ImportLayerTool : GisTool
    {
        [Input("Input layer", 0)]
        public IVectorLayerInfo InputLayer { get; set; }

        [Input("Database", 1, false, ParameterType.Combo)]
        public DatabaseConnection Database { get; set; }

        [Input("Schema", 2)]
        public string Schema { get; set; }

        [Input("New layer name", 3)]
        public string NewLayerName { get; set; }

        [Input("Overwrite", 4)]
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

        protected override void Configure(IAppContext context, ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<ImportLayerTool>()
                .AddComboList(t => t.Database, context.Repository.Connections);
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
