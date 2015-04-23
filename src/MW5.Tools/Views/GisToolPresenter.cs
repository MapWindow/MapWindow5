using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Views
{
    public class GisToolPresenter: BasePresenter<IGisToolView, GisToolBase>
    {
        private readonly IAppContext _context;
        private bool _initialized;

        public GisToolPresenter(IGisToolView view, IAppContext context) : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override void Initialize()
        {
            var parameters = Parameters.ToList();

            InitParameters(parameters);

            View.GenerateControls(parameters);
        }

        private void InitParameters(IEnumerable<BaseParameter> parameters)
        {
            foreach (var p in parameters)
            {
                var layerParameter = p as LayerParameter;
                if (layerParameter != null)
                {
                    layerParameter.SetLayers(_context.Layers);
                }
            }

            Model.Initialize(_context);
        }

        private IEnumerable<BaseParameter> Parameters
        {
            get
            {
                if (_initialized)
                {
                    throw new ApplicationException("Parameters must be read only once");
                }

                var properties = Model.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    if (typeof (BaseParameter).IsAssignableFrom(prop.PropertyType))
                    {
                        var param = Activator.CreateInstance(prop.PropertyType) as BaseParameter;
                        if (param != null)
                        {
                            prop.SetValue(Model, param);

                            var attr = Attribute.GetCustomAttribute(prop, typeof (RequiredParameterAttribute)) as RequiredParameterAttribute;
                            if (attr != null)
                            {
                                param.Index = attr.Index;
                                param.DisplayName = attr.DisplayName;
                            }
                        }

                        yield return param;
                    }
                }

                _initialized = true;
            }
        }

        public override bool ViewOkClicked()
        {
            // TODO: validate

            Model.Run();

            return true;
        }
    }
}
