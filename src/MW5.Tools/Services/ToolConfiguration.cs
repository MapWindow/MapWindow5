// -------------------------------------------------------------------------------------------
// <copyright file="ToolConfiguration.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MW5.Api.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Services
{
    /// <summary>
    /// Holds configuration options for the tool which affect the generation and behavior of UI.
    /// </summary>
    public class ToolConfiguration
    {
        private readonly Dictionary<string, object> _comboLists = new Dictionary<string, object>();
        private readonly Dictionary<string, object> _defaultValues = new Dictionary<string, object>();
        private readonly List<FieldWrapper> _fields = new List<FieldWrapper>();
        private readonly Dictionary<string, Range> _ranges = new Dictionary<string, Range>();

        /// <summary>
        /// Gets list of values for parameters with parameter name as key.
        /// </summary>
        public Dictionary<string, object> ComboLists
        {
            get { return _comboLists; }
        }

        /// <summary>
        /// Gets default values for parameters with parameter name as a key.
        /// </summary>
        public Dictionary<string, object> DefaultValues
        {
            get { return _defaultValues; }
        }

        /// <summary>
        /// Gets pairs of field name (key) as layer name (value).
        /// </summary>
        public List<FieldWrapper> Fields
        {
            get { return _fields; }
        }

        /// <summary>
        /// Gets or sets list of layers to be used for input selection.
        /// </summary>
        public IEnumerable<ILayer> Layers { get; set; }

        /// <summary>
        /// Gets minimum and maximum values for parameters with parameter name as a key.
        /// </summary>
        public Dictionary<string, Range> Ranges
        {
            get { return _ranges; }
        }

        /// <summary>
        /// Gets strongly typed version of ToolConfiguration associated with particular tool.
        /// </summary>
        public ToolConfiguration<T> Get<T>() where T : GisTool
        {
            return new ToolConfiguration<T>(this);
        }
    }

    /// <summary>
    /// Provides strongly typed methods to set configuration options for the tool.
    /// </summary>
    /// <typeparam name="T">GisTool</typeparam>
    public class ToolConfiguration<T>
        where T : GisTool
    {
        private readonly ToolConfiguration _config;

        public ToolConfiguration(ToolConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("config");
            _config = config;
        }

        /// <summary>
        /// Adds ComboBox values for the parameter.
        /// </summary>
        public ToolConfiguration<T> AddComboList<TT>(Expression<Func<T, TT>> parameter, IEnumerable<TT> list)
        {
            var name = (parameter.Body as MemberExpression).Member.Name;
            _config.ComboLists.Add(name, list);
            return this;
        }

        /// <summary>
        /// Specifies that field parameter belongs to a certain layer.
        /// </summary>
        public ToolConfiguration<T> AddField(Expression<Func<T, IVectorInput>> layer, Expression<Func<T, int>> field)
        {
            // let the exceptions be thrown, we want to catch bugs ASAP
            var layerName = (layer.Body as MemberExpression).Member.Name;
            var fieldName = (field.Body as MemberExpression).Member.Name;

            _config.Fields.Add(new FieldWrapper(layerName, fieldName));

            return this;
        }

        /// <summary>
        /// Adds map layers to be displayed for input selection.
        /// </summary>
        public ToolConfiguration<T> AddLayers(IEnumerable<ILayer> layers)
        {
            _config.Layers = layers;
            return this;
        }

        /// <summary>
        /// Sets default value for the parameter.
        /// </summary>
        public ToolConfiguration<T> SetDefault<TT>(Expression<Func<T, TT>> number, TT value)
        {
            var name = (number.Body as MemberExpression).Member.Name;
            _config.DefaultValues.Add(name, value);
            return this;
        }

        /// <summary>
        /// Sets default value for distance parameter.
        /// </summary>
        public ToolConfiguration<T> SetDefault(Expression<Func<T, Distance>> distance, double value)
        {
            var name = (distance.Body as MemberExpression).Member.Name;
            _config.DefaultValues.Add(name, value);
            return this;
        }

        /// <summary>
        /// Sets the minimum and maximum values for the parameter.
        /// </summary>
        public ToolConfiguration<T> SetRange<TT>(Expression<Func<T, TT>> number, TT min, TT max)
        {
            var name = (number.Body as MemberExpression).Member.Name;
            _config.Ranges.Add(name, new Range(min, max));
            return this;
        }
    }
}