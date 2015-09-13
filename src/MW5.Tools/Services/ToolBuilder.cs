using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Controls.Parameters;
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

            ApplyRanges();

            BindComboLists();
        }

        private void BindComboLists()
        {
            foreach (var p in _parameters.OfType<OptionsParameter>())
            {
                if (_config.ComboLists.ContainsKey(p.Name))
                {
                    p.Options = _config.ComboLists[p.Name];
                }
            }
        }

        private void ApplyDefaults()
        {
            foreach (var p in _parameters)
            {
                if (_config.DefaultValues.ContainsKey(p.Name))
                {
                    p.DefaultValue = _config.DefaultValues[p.Name];
                }
            }
        }

        private void ApplyRanges()
        {
            foreach (var p in _parameters.OfType<NumericParameter>())
            {
                if (_config.Ranges.ContainsKey(p.Name))
                {
                    var range = _config.Ranges[p.Name];
                    p.SetRange(range.Min, range.Max);
                }
            }
        }
    }
}
