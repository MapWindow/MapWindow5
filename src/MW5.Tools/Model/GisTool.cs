// -------------------------------------------------------------------------------------------
// <copyright file="GisTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared.Log;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Base class for GIS tools. Supports asynchronous execution via tasks and parameter generation via reflection.
    /// </summary>
    public abstract class GisTool : IGisTool, IParametrizedTool, IXmlSerializable
    {
        private IGlobalListener _callback;
        protected IAppContext _context;
        private OutputManager _outputManager;
        private ParameterCollection _parameters;

        #region Properties

        /// <summary>
        /// Gets or sets callback object used to stop execution of MapWinGIS methods.
        /// </summary>
        public IGlobalListener Callback
        {
            get => _callback;
            set
            {
                _callback = value;
                Parameters.SetCallbackToInputs(Callback);
            }
        }

        /// <summary>
        /// Gets tool's configuration settings.
        /// </summary>
        public ToolConfiguration Configuration { get; } = new ToolConfiguration();

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Gets the logger associated with tool.
        /// </summary>
        public IToolLogger Log { get; } = new ToolLogger();

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets combined list of required and optional parameters.
        /// </summary>
        public ParameterCollection Parameters => _parameters ?? (_parameters = new ParameterCollection(this));

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public abstract PluginIdentity PluginIdentity { get; }

        /// <summary>
        /// Gets a value indicating whether tasks should be executed
        /// in sequence rather than in parallel when running in batch mode.
        /// </summary>
        public virtual bool SequentialBatchExecution => false;

        /// <summary>
        /// Gets a value indicating whether the tool supports batch execution.
        /// </summary>
        public virtual bool SupportsBatchExecution => true;

        /// <summary>
        /// Gets a value indicating whether the tool supports canceling.
        /// </summary>
        public virtual bool SupportsCancel => false;

        /// <summary>
        /// Returns true if a tool can be executed asynchronously using tasks.
        /// </summary>
        public bool SupportsTasks => true;

        /// <summary>
        /// Gets the name to be displayed as a name of the task.
        /// </summary>
        public virtual string TaskName
        {
            get
            {
                var name = Name;
                var input = Parameters.OfType<LayerParameterBase>().ToList();

                if (input.Count == 1)
                {
                    var layerParameterBase = input.FirstOrDefault();
                    if (layerParameterBase != null) name += ": " + layerParameterBase.DatasourceName;
                    return name;
                }

                var output = Parameters.OfType<OutputLayerInfo>().ToList();
                if (output.Count != 1) return name;

                var outputLayerInfo = output.FirstOrDefault();
                if (outputLayerInfo != null) name += ": " + outputLayerInfo.Name;
                return name;
            }
        }

        protected IAppContext Context => _context;

        /// <summary>
        /// Gets the output manager which can be used to save results of tool execution.
        /// </summary>
        protected OutputManager OutputManager
        {
            get
            {
                if (_outputManager != null) return _outputManager;

                var layerService = _context.Container.Resolve<ILayerService>();
                _outputManager = new OutputManager(layerService);

                return _outputManager;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// A method called after the main IGisTool.Run method is successfully finished.
        /// Is executed on the UI thread. Typically used to save output datasources.
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        public virtual bool AfterRun()
        {
            var success = true;

            foreach (var info in this.GetOutputs())
            {
                if (info.Result == null)
                {
                    Log.Error("There is no output for parameter: ", null, info.Filename);
                    success = false;
                }
                else
                {
                    if (OutputManager.Save(info.Result, info)) continue;

                    Log.Error("Failed to save output: {0}", null, info.Filename);
                    success = false;
                }
            }

            return success;
        }

        /// <summary>
        /// Clears callbacks and closes inputs datasources.
        /// </summary>
        public void CleanUp()
        {
            Parameters.CleanUp();
        }

        /// <summary>
        /// Strongly typed method to find parameter corresponding to particular property of the tool.
        /// </summary>
        public BaseParameter FindParameter<TTool, T>(Expression<Func<TTool, T>> parameter)
        {
            if (!(parameter.Body is MemberExpression memberExpression)) return null;

            var name = memberExpression.Member.Name;
            return Parameters.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Initializes the tool with application context.
        /// Can be overriden in derived classes to provide additional logic.
        /// </summary>
        public void Initialize(IAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Configure(_context, Configuration);

            // a) default values set in attributes will be stored in BaseParameter.DefaultValue
            // on first call of Parameters property;
            // b) default values set in configuration will be applied in ToolConfigurationManager.Apply method;
            var builder = new ToolConfigurationManager();
            builder.Apply(Configuration, Parameters);
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public abstract bool Run(ITaskHandle task);

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public bool Run()
        {
            return Run(new EmptyTaskHandle());
        }

        /// <summary>
        /// Validates the values of parameters.
        /// </summary>
        public virtual bool Validate()
        {
            if (!Parameters.Validate())
            {
                return false;
            }

            Parameters.SaveControlValues();

            if (!BeforeRun())
            {
                return false;
            }

            Parameters.ExtractDatasources();

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Is called on the UI thread before execution of the IGisTool.Run method.
        /// </summary>
        protected virtual bool BeforeRun()
        {
            return true;
        }

        /// <summary>
        /// Adds tool configuration which can be used for generation of the UI for tool.
        /// </summary>
        protected virtual void Configure(IAppContext context, ToolConfiguration configuration)
        {
            configuration.Layers = context.Layers;
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadParameters(Parameters);
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteParameters(Parameters);
        }

        #endregion
    }
}