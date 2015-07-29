using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Services;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Views.Controls
{
    /// <summary>
    /// Creates and assigns controls for parameters.
    /// </summary>
    public class ParameterControlFactory
    {
        private readonly IFileDialogService _dialogService;

        public ParameterControlFactory(IFileDialogService dialogService)
        {
            if (dialogService == null) throw new ArgumentNullException("dialogService");
            _dialogService = dialogService;
        }

        public IParameterControl CreateControl(BaseParameter parameter)
        {
            if (parameter == null) throw new ArgumentNullException("parameter");

            IParameterControl control = null;
            if (parameter is StringParameter)
            {
                control = new StringParameterControl();
            }

            if (parameter is BooleanParameter)
            {
                control = new BooleanParameterControl();
            }

            if (parameter is IntegerParameter)
            {
                control = new IntegerParameterControl();
            }

            if (parameter is DoubleParameter)
            {
                control = new DoubleParameterControl();
            }

            if (parameter is OutputLayerParameter)
            {
                control = new OutputParameterControl(_dialogService);
            }

            if (parameter is OptionsParameter)
            {
                control = new ComboParameterControl { ButtonVisible = false };

                // ensure that previously specified options are applied
                (control as ComboParameterControl).SetOptions((parameter as OptionsParameter).OptionsSource);     
            }

            if (parameter is LayerParameterBase)
            {
                var lp = parameter as LayerParameterBase;
                control = new LayerParameterControl(lp.Layers, lp.DataSourceType, _dialogService);
            }

            if (control == null)
            {
                throw new ApplicationException("Failed to created control for parameter: " + parameter.DisplayName);
            }

            var value = parameter.GetDefaultValue();
            if (value != null)
            {
                control.SetValue(value);
            }

            return control;
        }
    }
}
