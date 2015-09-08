using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Services
{
    public class ToolConfiguration
    {
        private readonly List<FieldWrapper> _fields = new List<FieldWrapper>();
        private readonly Dictionary<string, object> _defaultValues = new Dictionary<string, object>();
        private readonly Dictionary<string, object> _comboLists = new Dictionary<string, object>();
        private readonly Dictionary<string, Range> _ranges = new Dictionary<string, Range>();
        private IEnumerable<ILayer> _layers;

        public ToolConfiguration<T> Get<T>()
            where T: GisTool
        {
            return new ToolConfiguration<T>(this);
        }

        /// <summary>
        /// Gets pairs of field name (key) as layer name (value).
        /// </summary>
        public List<FieldWrapper> Fields
        {
            get { return _fields; }
        }

        public Dictionary<string, object> DefaultValues
        {
            get { return _defaultValues; }
        }

        public Dictionary<string, object> ComboLists
        {
            get { return _comboLists; }
        }

        public IEnumerable<ILayer> Layers
        {
            get { return _layers;  }
        }

        public Dictionary<string, Range> Ranges
        {
            get { return _ranges; }
        }

        public void AddLayers(IEnumerable<ILayer> layers)
        {
            _layers = layers;
        }
    }

    public class ToolConfiguration<T>
        where T : GisTool
    {
        private readonly ToolConfiguration _config;

        public ToolConfiguration(ToolConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("config");
            _config = config;
        }

        public ToolConfiguration<T> AddField(Expression<Func<T, IVectorLayerInfo>> layer, Expression<Func<T, int>> field)
        {
            // let the exceptions be thrown, we want to catch bugs ASAP
            var layerName = (layer.Body as MemberExpression).Member.Name;
            var fieldName = (field.Body as MemberExpression).Member.Name;

            _config.Fields.Add(new FieldWrapper(layerName, fieldName));

            return this;
        }

        public ToolConfiguration<T> SetDefault<TT>(Expression<Func<T, TT>> number, TT value)
        {
            var name = (number.Body as MemberExpression).Member.Name;
            _config.DefaultValues.Add(name, value);
            return this;
        }

        public ToolConfiguration<T> SetDefault(Expression<Func<T, Distance>> distance, double value)
        {
            var name = (distance.Body as MemberExpression).Member.Name;
            _config.DefaultValues.Add(name, value);
            return this;
        }

        public ToolConfiguration<T> AddComboList<TT>(Expression<Func<T, TT>> parameter, IEnumerable<TT> list)
        {
            var name = (parameter.Body as MemberExpression).Member.Name;
            _config.ComboLists.Add(name, list);
            return this;
        }

        public ToolConfiguration<T> AddLayers(IEnumerable<ILayer> layers)
        {
            _config.AddLayers(layers);
            return this;
        }

        public ToolConfiguration<T> SetRange<TT>(Expression<Func<T, TT>> number, TT min, TT max)
        {
            var name = (number.Body as MemberExpression).Member.Name;
            _config.Ranges.Add(name, new Range(min, max));
            return this;
        }
    }
}
