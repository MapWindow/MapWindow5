using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Properties;

namespace MW5.Tools.Tools.Database
{
    [GisTool("Import layer", typeof(Resources))]
    public class ImportLayerTool : GisToolBase
    {
        [RequiredParameter("Input layer", 0)]
        public LayerParameter InputLayer { get; set; }

        [RequiredParameter("Database", 1)]
        public OptionsParameter<DatabaseConnection> Database { get; set; }

        [RequiredParameter("Schema", 2)]
        public StringParameter Schema { get; set; }

        [RequiredParameter("New layer name", 3)]
        public StringParameter NewLayerName { get; set; }

        [RequiredParameter("Overwrite", 4)]
        public BooleanParameter Overwrite { get; set; }

        /// <summary>
        /// Initializes lists of options.
        /// </summary>
        public override void Initialize(IAppContext context)
        {
            Database.Options = context.Repository.Connections;

            Database.ValueChanged += Database_ValueChanged;
        }

        private void Database_ValueChanged()
        {
            //Schema.Options = Database.Value.GetSchemas().ToList();
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run()
        {
            var cs = Database.Value.ConnectionString;

            var fs = InputLayer.Value.FeatureSet;

            string newLayerName = NewLayerName.Value;

            string options = PrepareOptions();

            return RunCore(cs, fs, newLayerName, options);
        }

        /// <summary>
        /// Preparing format specific options.
        /// </summary>
        private string PrepareOptions()
        {
            var list = new List<string>();

            if (!string.IsNullOrWhiteSpace(Schema.Value))
            {
                list.Add("SCHEMA=" + Schema.Value);
            }

            if (Database.Value != null && Database.Value.DatabaseType == Plugins.Enums.GeoDatabaseType.MySql)
            {
                list.Add("ENGINE=MyISAM ");    // Spatial indexes aren't supported otherwise http ://stackoverflow.com/questions/18379808/the-used-table-type-doesnt-support-spatial-indexes
            }

            if (Overwrite.Value)
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

        /// <summary>
        /// Core processing.
        /// </summary>
        private bool RunCore(string connectionString, IFeatureSet inputLayer, string newLayerName, string options )
        {
            var ds = new VectorDatasource();
            if (ds.Open(connectionString))
            {
                if (!ds.ImportLayer(inputLayer, newLayerName, options))
                {
                    MessageService.Current.Warn("Failed to import shapefile: " + ds.GdalLastErrorMsg);
                    return false;
                }
                
                MessageService.Current.Info("Layer was imported: " + newLayerName);
                return true;
            }

            return false;
        }
    }
}
