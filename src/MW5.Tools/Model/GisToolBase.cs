// -------------------------------------------------------------------------------------------
// <copyright file="GisToolBase.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Views;

namespace MW5.Tools.Model
{
    /// <summary>
    /// Base class for GIS tool.
    /// </summary>
    public abstract class GisToolBase: IGisTool
    {
        private List<BaseParameter> _parameters;

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public PluginIdentity PluginIdentity { get; private set; }

        public abstract void Initialize(IAppContext context);

        /// <summary>
        /// Initializes the tool.
        /// </summary>
        protected void InitializeBase(IAppContext context)
        {
            foreach (var layerParameter in Parameters.OfType<LayerParameter>())
            {
                layerParameter.SetLayers(context.Layers);
            }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public abstract bool Run();

        /// <summary>
        /// Gets combined list of required and optional parameters.
        /// </summary>
        public IEnumerable<BaseParameter> Parameters
        {
            get { return _parameters ?? (_parameters = GetParameters().ToList()); }
        }

        private IEnumerable<BaseParameter> GetParameters()
        {
            var properties = GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (!typeof(BaseParameter).IsAssignableFrom(prop.PropertyType))
                {
                    continue;
                }

                var attr = Attribute.GetCustomAttribute(prop, typeof(ParameterAttribute)) as ParameterAttribute;

                if (attr == null) continue;

                var param = Activator.CreateInstance(prop.PropertyType) as BaseParameter;
                if (param != null)
                {
                    prop.SetValue(this, param);
                    param.Index = attr.Index;
                    param.DisplayName = attr.DisplayName;
                    param.Required = attr is RequiredParameterAttribute;
                    yield return param;
                }
            }
        }
    }
}