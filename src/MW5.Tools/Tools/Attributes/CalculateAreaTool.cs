using System;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Tools.Attributes
{
    [CustomLayout]
    [GisTool(GroupKeys.Attributes)]
    public class CalculateAreaTool: GisTool
    {
        [Input("Input layer", 0)]
        public IVectorInput Input { get; set; }

        [Input("Area units", 1)]
        [ControlHint(ControlHint.Combo)]
        public AreaUnits Units { get; set; }

        [Output("Field name", 0)]
        public string FieldName { get; set; }

        [Output("Overwrite", 1)]
        public bool Overwrite { get; set; }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected override void Configure(IAppContext context, Services.ToolConfiguration configuration)
        {
            base.Configure(context, configuration);

            configuration.Get<CalculateAreaTool>()
                .AddComboList(t => t.Units, EnumHelper.GetValues<AreaUnits>())
                .SetDefault(t => t.Units, AreaUnits.Hectares)
                .SetDefault(t => t.FieldName, "Area")
                .SetDefault(t => t.Overwrite, true);
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Calculate area"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Calculates area of polygons and writes results in the attribute table."; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected override bool BeforeRun()
        {
            if (Input.Datasource.GeometryType != GeometryType.Polygon)
            {
                MessageService.Current.Info("Polygon datasource is expected.");
                return false;
            }

            if (Input.Datasource.Fields.Exists(FieldName) && !Overwrite)
            {
                MessageService.Current.Info("Field with such name already exists while no override flag was set.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            var fs = Input.Datasource;
            bool editing = fs.EditingTable;

            if (!editing)
            {
                fs.StartEditingTable();
            }

            bool result = false;

            try
            {
                if (!fs.Fields.Exists(FieldName))
                {
                    fs.Fields.Add(new AttributeField()
                                      {
                                          Name = FieldName, 
                                          Type = AttributeType.Double,
                                          Alias = FieldName + ", " + UnitsHelper.GetAbbreviatedName(Units)
                                      });
                }

                result = Calcualte(task);
            }
            catch(Exception ex)
            {
                if (!editing)
                {
                    fs.StopEditingTable(false);
                }

                throw;
            }

            if (!editing)
            {
                fs.StopEditingTable();
            }

            return result;
        }

        /// <summary>
        /// Performs the main calculation.
        /// </summary>
        private bool Calcualte(ITaskHandle task)
        {
            var fs = GetWgs84FeatureSet();
            if (fs == null)
            {
                string proj = Input.Datasource.Projection.ExportToProj4();
                Log.Warn("Failed to reproject datasource to WGS84: {0}", null, proj);
                return false;
            }
            
            var features = fs.GetFeatures(Input.SelectedOnly);

            int lastPercent = 0;

            var table = Input.Datasource.Table;
            int fieldIndex = table.Fields.IndexByName(FieldName);

            for (int i = 0; i < features.Count; i++)
            {
                task.CheckPauseAndCancel();
                task.Progress.TryUpdate("Calculating...", i, features.Count, ref lastPercent);

                var ft = features[i];

                double area = GeodesicUtils.GeodesicArea(ft.Geometry);

                area = UnitConversionHelper.Convert(AreaUnits.SquareMeters, Units, area);

                table.EditCellValue(fieldIndex, ft.Index, area);
            }

            if (fs.InternalObject != Input.Datasource.InternalObject)
            {
                // it's a reprojected one
                fs.Dispose();
            }

            return true;
        }

        /// <summary>
        /// Gets feature set in WGS84 coordinate system (reprojects if needed).
        /// </summary>
        private IFeatureSet GetWgs84FeatureSet()
        {
            // TODO: to optimize memory usage would be better to reproject shapes one at a time
            var sr = new SpatialReference();
            sr.SetWgs84();

            var fs = Input.Datasource;

            if (!fs.Projection.IsSameExt(sr, fs.Envelope))
            {
                int count;
                return fs.Reproject(sr, out count);
            }

            return fs;
        }
    }
}
