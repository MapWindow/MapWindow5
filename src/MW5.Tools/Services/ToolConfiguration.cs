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
        private readonly List<KeyValuePair<string, string>> _fields = new List<KeyValuePair<string, string>>();

        public ToolConfiguration<T> Get<T>()
            where T: GisToolBase
        {
            return new ToolConfiguration<T>(this);
        }

        public List<KeyValuePair<string, string>> Fields
        {
            get { return _fields; }
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

            _config.Fields.Add(new KeyValuePair<string, string>(fieldName, layerName));

            return this;
        }
    }
}
