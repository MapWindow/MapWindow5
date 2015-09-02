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

            ApplyFields();

            AttachHandlers();
        }

        private void AttachHandlers()
        {
            foreach (var p in _parameters.OfType<FieldParameter>())
            {
                p.AttachHandler();
            }
        }

        private void ApplyFields()
        {
            var dict = _parameters.ToDictionary(p => p.Name);

            foreach (var f in _config.Fields)
            {
                var field = dict[f.Key] as FieldParameter;
                var layer = dict[f.Value] as VectorLayerParameter;

                if (layer == null)
                {
                    throw new NullReferenceException("Couldn't find source vector layer for field parameter.");
                }

                field.Layer = layer;
            }
        }
    }
}
