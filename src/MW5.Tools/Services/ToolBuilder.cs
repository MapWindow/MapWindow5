using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Services
{
    internal class ToolBuilder
    {
        private IEnumerable<BaseParameter> _parameters;
        private ToolConfiguration _config;

        public void Build(ToolConfiguration config, IEnumerable<BaseParameter> parameters)
        {
            if (config == null) throw new ArgumentNullException("config");
            if (parameters == null) throw new ArgumentNullException("parameters");

            _config = config;
            _parameters = parameters;

            ApplyDefaults();
        }

        private void ApplyDefaults()
        {
            foreach (var p in _parameters)
            {
                if (_config.DefaultValues.ContainsKey(p.Name))
                {
                    p.SetDefaultValue(_config.DefaultValues[p.Name]);
                }
            }
        }
    }
}
