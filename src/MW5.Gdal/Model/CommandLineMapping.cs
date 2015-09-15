using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MW5.Gdal.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Gdal.Model
{
    public class CommandLineMapping
    {
        private readonly Dictionary<string, string> _keys = new Dictionary<string, string>();

        public Dictionary<string, string> Keys
        {
            get { return _keys; } 
        }

        public CommandLineMapping<T> Get<T>()
            where T : GdalTool
        {
            return new CommandLineMapping<T>(this);
        }

        public string Complile(GdalTool tool)
        {
            var sb = new StringBuilder();

            foreach (var p in tool.Parameters.Where(p => p.IsInput && _keys.ContainsKey(p.Name)))
            {
                string key = _keys[p.Name];

                if (p.Value == null || p.IsEmpty || Equals(p.Value, p.DefaultValue))
                {
                    continue;
                }

                if (p is BooleanParameter)
                {
                    sb.AppendFormat("{0} ", key );
                }
                else if (p is StringParameter || p is OptionsParameter)
                {
                    string s = p.Value.ToString().Trim();
                    if (!s.StartsWith("<"))   // this a special values used in the UI
                    {
                        sb.AppendFormat("{0} {1} ", key, p.Value);
                    }
                }
            }

            return sb.ToString();
        }
    }

    public class CommandLineMapping<T>
        where T: GdalTool
    {
        private readonly CommandLineMapping _mapping;

        public CommandLineMapping(CommandLineMapping mapping)
        {
            if (mapping == null) throw new ArgumentNullException("mapping");
            _mapping = mapping;
        }

        public CommandLineMapping<T> SetKey<TT>(Expression<Func<T, TT>> property, string key)
        {
            var name = (property.Body as MemberExpression).Member.Name;
            _mapping.Keys.Add(name, key);
            return this;
        }
    }
}
