using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model;

namespace MW5.Tools.Services
{
    public class ToolConfiguration
    {
        private readonly List<FieldWrapper> _fields = new List<FieldWrapper>();
        private readonly Dictionary<string, object> _defaultValues = new Dictionary<string, object>();

        public ToolConfiguration<T> Get<T>()
            where T: GisToolBase
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
    }

    public class ToolConfiguration<T>
        where T : GisToolBase
    {
        private readonly ToolConfiguration _config;

        public ToolConfiguration(ToolConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("config");
            _config = config;
        }

        public ToolConfiguration<T> AddField(Expression<Func<T, VectorLayerInfo>> layer, Expression<Func<T, int>> field)
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
    }
}
