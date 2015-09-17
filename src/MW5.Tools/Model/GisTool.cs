// -------------------------------------------------------------------------------------------
// <copyright file="GisTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
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
using MW5.Shared;
using MW5.Shared.Log;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Base class for GIS tool.
    /// </summary>
    public abstract class GisTool : IGisTool, IParametrizedTool, IXmlSerializable
    {
        private readonly ToolConfiguration _config = new ToolConfiguration();
        private readonly IToolLogger _logger = new ToolLogger();
        private IApplicationCallback _callback;
        private IAppContext _context;
        private OutputManager _outputManager;
        private ParameterCollection _parameters;

        protected OutputManager OutputManager
        {
            get
            {
                if (_outputManager == null)
                {
                    var layerService = _context.Container.Resolve<ILayerService>();
                    _outputManager = new OutputManager(layerService);
                }

                return _outputManager;
            }
        }

        protected IAppContext Context
        {
            get { return _context;  }
        }

        public IToolLogger Log
        {
            get { return _logger; }
        }

        public virtual bool SupportsCancel
        {
            get { return true; }
        }

        /// <summary>
        /// Can be used to save results of the processing or display messages. 
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        /// <returns>True on success.</returns>
        public virtual bool AfterRun()
        {
            bool success = true;

            foreach (var info in Parameters.Outputs)
            {
                if (info.Result == null)
                {
                    Log.Error("There is no output for parameter: ", null, info.Filename);
                    success = false;
                }
                else
                {
                    if (!OutputManager.Save(info.Result, info))
                    { 
                        Log.Error("Failed to save output: {0}", null, info.Filename);
                        success = false;
                    }
                }
            }

            return success;
        }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public abstract string Description { get; }

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
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public abstract PluginIdentity PluginIdentity { get; }

        /// <summary>
        /// Initializes the tool with application context.
        /// Can be overriden in derived classes to provide additional logic.
        /// </summary>
        public virtual void Initialize(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            Configure(_context, _config);

            // a) default values set in attributes will be stored in BaseParameter.DefaultValue
            // on first call of Parameters property;
            // b) default values set in configuration will be applied in ToolBuilder.Build method;
            var builder = new ToolBuilder();
            builder.Build(_config, Parameters);
        }

        /// <summary>
        /// Returns true if a tool can be executed asynchronously using tasks.
        /// </summary>
        public bool SupportsTasks
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the tool supports batch execution.
        /// </summary>
        public virtual bool SupportsBatchExecution
        {
            get { return false; }
        }

        public IApplicationCallback Callback
        {
            get { return _callback; }
            set
            {
                _callback = value;
                Parameters.SetCallback(Callback);
            }
        }

        public void CleanUp()
        {
            Parameters.CleanUp();
        }

        public bool Validate()
        {
            if (!Parameters.Validate())
            {
                return false;
            }

            Parameters.Apply();

            return BeforeRun();
        }

        /// <summary>
        /// Gets the name to be displayed as a name of the task.
        /// </summary>
        public virtual string TaskName
        {
            get
            {
                string name = Name;

                var input = Parameters.OfType<LayerParameterBase>().ToList();
                
                if (input.Count() == 1)
                {
                    name += ": " + input.FirstOrDefault().DatasourceName;
                    return name;
                }

                var output = Parameters.OfType<OutputLayerInfo>().ToList();
                if (output.Count() == 1)
                {
                    name += ": " + output.FirstOrDefault().Name;
                    return name;
                }

                return name;
            }
        }

        /// <summary>
        /// Gets a value indicating whether tasks should be executed
        /// in sequence rather than in parallel when running in batch mode.
        /// </summary>
        public virtual bool SequentialBatchExecution
        {
            get { return false; }
        }

        /// <summary>
        /// Gets combined list of required and optional parameters.
        /// </summary>
        public ParameterCollection Parameters
        {
            get { return _parameters ?? (_parameters = new ParameterCollection(this)); }
        }

        public ToolConfiguration Configuration
        {
            get { return _config; }
        }

        public BaseParameter FindParameter<TTool, T>(Expression<Func<TTool, T>> layer)
        {
            var name = (layer.Body as MemberExpression).Member.Name;
            return Parameters.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Before the run.
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
            configuration.AddLayers(context.Layers);
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
    }
}