// -------------------------------------------------------------------------------------------
// <copyright file="GisTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Base class for GIS tool.
    /// </summary>
    [HasRegions]
    public abstract class GisTool : GisToolBase
    {
        private readonly IToolLogger _logger = new ToolLogger();
        private IAppContext _context;
        private List<BaseParameter> _parameters;
        private ToolConfiguration _config;

        #region Properties

        public override IToolLogger Log
        {
            get { return _logger; }
        }

        /// <summary>
        /// Gets combined list of required and optional parameters.
        /// </summary>
        public IEnumerable<BaseParameter> Parameters
        {
            get { return _parameters ?? (_parameters = GetParameters().ToList()); }
        }

        protected IAppContext AppContext
        {
            get { return _context; }
        }

        // TODO: revisit
        protected SynchronizationContext UiThread
        {
            get { return _context.SynchronizationContext; }
        }

        private ILayerService LayerService
        {
            get { return _context.Container.Resolve<ILayerService>(); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Initializes the tool with application context.
        /// Can be overriden in derived classes to provide additional logic.
        /// </summary>
        public override void Initialize(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            foreach (var layerParameter in Parameters.OfType<LayerParameterBase>())
            {
                layerParameter.Initialize(context.Layers);
            }

            _config = new ToolConfiguration();
            Configure(_config);
        }

        public void ApplyConfig()
        {
            var builder = new ToolBuilder();
            builder.Build(_config, Parameters);
        }

        protected virtual void Configure(ToolConfiguration configuration)
        {
            // do nothing, should be overriden if necessary
        }

        public override void SetCallback(IApplicationCallback callback)
        {
            foreach (var p in Parameters.OfType<LayerParameterBase>())
            {
                var layer = p.SelectedLayer;
                if (layer != null)
                {
                    layer.Source.Callback = callback;
                }
            }
        }

        public override void CleanUp()
        {
            ClearCallbacks();
            CloseDatasources();
        }

        private void CloseDatasources()
        {
            foreach (var p in Parameters.OfType<LayerParameterBase>())
            {
                if (!p.SelectedLayer.Opened)
                {
                    var layer = p.ToolProperty.GetValue(this) as ILayerSource;
                    if (layer != null)
                    {
                        layer.Dispose();
                    }
                }
            }
        }

        private void ClearCallbacks()
        {
            var properties = GetType().GetProperties();
            foreach (PropertyInfo p in properties)
            {
                if (p.GetType().IsAssignableFrom(typeof(ILayerSource)))
                {
                    var layerSource = p.GetValue(this) as ILayerSource;
                    if (layerSource != null)
                    {
                        layerSource.Callback = null;
                    }
                }
            }
        }

        public bool ValidateParameters()
        {
            foreach (var p in Parameters)
            {
                var layerParameter = p as LayerParameter;
                if (layerParameter != null)
                {
                    if (layerParameter.Datasource == null)
                    {
                        MessageService.Current.Info("Input datasource isn't selected.");
                        return false;
                    }
                }

                var outputParameter = p as OutputLayerParameter;
                if (outputParameter != null)
                {
                    string errorMessage;
                    if (!outputParameter.Value.Validate(out errorMessage))
                    {
                        MessageService.Current.Info(errorMessage);
                        return false;
                    }
                }

                var value = p as ValueParameter;
                if (value != null)
                {
                    string errorMessage;
                    if (!value.Validate(out errorMessage))
                    {
                        MessageService.Current.Info(errorMessage);
                        return false;
                    }
                }
            }

            return true;
        }

        public void ApplyParameters()
        {
            // validation must be called first

            foreach (var p in Parameters)
            {
                p.ToolProperty.SetValue(this, p.Value);
            }
        }

        internal virtual bool BeforeRun()
        {
            return true;
        }

        #endregion

        #region Methods

        protected void SaveOutput(IDatasource ds, OutputLayerInfo outputInfo)
        {
            SendOrPostCallback action = p =>
                {
                    ds.Callback = null;

                    if (outputInfo.MemoryLayer)
                    {
                        HandleMemoryOutput(ds, outputInfo);
                        return;
                    }

                    HandleDiskOutput(ds, outputInfo);
                };

            UiThread.Send(action, null);
        }

        private IEnumerable<BaseParameter> GetParameters()
        {
            var properties = GetType().GetProperties();
            foreach (var prop in properties)
            {
                var attr = prop.GetAttribute<ParameterAttribute>();
                if (attr == null) continue;

                var param = ParameterFactory.CreateParameter(prop.PropertyType, attr.ParameterType);
                if (param != null)
                {
                    param.ToolProperty = prop;
                    param.Name = prop.Name;
                    param.Index = attr.Index;
                    param.DisplayName = attr.DisplayName;
                    param.Required = attr is InputAttribute;

                    HandleRangeAttribute(param, prop);

                    HandleDefaultValueAttribute(param, prop);

                    yield return param;
                }
            }
        }

        private void HandleDefaultValueAttribute(BaseParameter param, PropertyInfo prop)
        {
            var attr = prop.GetAttribute<DefaultValueAttribute>();
            if (attr != null)
            {
                param.SetDefaultValue(attr.Value);
            }
        }

        private bool HandleDiskOutput(IDatasource ds, OutputLayerInfo outputInfo)
        {
            string filename = outputInfo.Name;

            if (File.Exists(filename) && !outputInfo.Overwrite)
            {
                return HandleOverwriteFailure();
            }

            bool result = SaveDatasource(ds, filename);

            ds.Dispose();

            if (!result)
            {
                return false;
            }

            if (outputInfo.AddToMap)
            {
                return LayerService.AddLayersFromFilename(filename);
            }

            return true;
        }

        private bool HandleMemoryOutput(IDatasource ds, OutputLayerInfo outputInfo)
        {
            if (!ds.IsVector)
            {
                throw new ApplicationException("Memory layers can only be used for vector datasources.");
            }

            if (!outputInfo.AddToMap)
            {
                throw new ApplicationException("Memory layer option can only be used with add to map option.");
            }

            return LayerService.AddDatasource(ds, outputInfo.Name);
        }

        private bool HandleOverwriteFailure()
        {
            // TODO: implement
            return false;
        }

        private void HandleRangeAttribute(BaseParameter param, PropertyInfo prop)
        {
            var vp = param as ValueParameter;
            if (vp != null && vp.Numeric)
            {
                var range = prop.GetAttribute<RangeAttribute>();
                if (range != null)
                {
                    if (param is IntegerParameter)
                    {
                        (param as IntegerParameter).MinValue = (int)range.Minimum;
                        (param as IntegerParameter).MaxValue = (int)range.Maximum;
                        (param as IntegerParameter).HasRange = true;
                    }
                    else if (param is DoubleParameter)
                    {
                        (param as DoubleParameter).MinValue = (double)range.Minimum;
                        (param as DoubleParameter).MaxValue = (double)range.Maximum;
                        (param as DoubleParameter).HasRange = true;
                    }
                }
            }
        }

        private bool SaveDatasource(IDatasource ds, string filename)
        {
            if (!GeoSource.Remove(filename))
            {
                return HandleOverwriteFailure();
            }

            if (LayerSourceHelper.Save(ds, filename))
            {
                Logger.Current.Info("Layer ({0}) is created.", filename);
                return true;
            }

            Logger.Current.Error("Failed to save datasource: " + ds.LastError);
            return false;
        }

        #endregion

        public override bool SupportsCancel
        {
            get { return true; }
        }
    }
}