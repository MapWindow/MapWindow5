// -------------------------------------------------------------------------------------------
// <copyright file="GisTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared.Log;
using MW5.Tools.Helpers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Base class for GIS tool.
    /// </summary>
    public abstract class GisTool : GisToolBase
    {
        private readonly ToolConfiguration _config = new ToolConfiguration();
        private readonly IToolLogger _logger = new ToolLogger();
        private IAppContext _context;
        private OutputManager _outputManager;
        private ParameterCollection _parameters;

        public override IToolLogger Log
        {
            get { return _logger; }
        }

        public override bool SupportsCancel
        {
            get { return true; }
        }

        protected IAppContext AppContext
        {
            get { return _context; }
        }

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

        internal ToolConfiguration Config
        {
            get { return _config; }
        }

        /// <summary>
        /// Gets combined list of required and optional parameters.
        /// </summary>
        internal ParameterCollection Parameters
        {
            get { return _parameters ?? (_parameters = new ParameterCollection(this)); }
        }

        public override bool AfterRun()
        {
            bool success = true;

            foreach (var p in Parameters.OfType<OutputLayerParameter>())
            {
                var info = p.GetValue();

                if (info.Result == null)
                {
                    Log.Error("There is no output for parameter: ", null, info.Name);
                    success = false;
                }
                else if (!OutputManager.Save(info.Result, info))
                {
                    Log.Error("Failed to save output: {0}", null, info.Name);
                    success = false;
                }
            }

            return success;
        }

        public override void CleanUp()
        {
            Parameters.CleanUp();
        }

        /// <summary>
        /// Initializes the tool with application context.
        /// Can be overriden in derived classes to provide additional logic.
        /// </summary>
        public override void Initialize(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            Parameters.Initialize(context);

            Configure(_config, context);

            var builder = new ToolBuilder();
            builder.Build(_config, Parameters);
        }

        public override void SetCallback(IApplicationCallback callback)
        {
            Parameters.SetCallback(callback);
        }

        /// <summary>
        /// Before the run.
        /// </summary>
        protected virtual bool BeforeRun()
        {
            return true;
        }

        protected virtual void Configure(ToolConfiguration configuration, IAppContext context)
        {
            // do nothing, should be overriden if necessary
        }

        internal bool Validate()
        {
            if (!Parameters.Validate())
            {
                return false;
            }

            Parameters.Apply();

            return BeforeRun();
        }
    }
}