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

            if (parameter is StringParameter)
            {
                return new StringParameterControl();
            }

            if (parameter is BooleanParameter)
            {
                return new BooleanParameterControl();
            }

            if (parameter is IntegerParameter)
            {
                return new IntegerParameterControl();
            }

            if (parameter is DoubleParameter)
            {
                return new DoubleParameterControl();
            }

            if (parameter is OutputLayerParameter)
            {
                return new OutputParameterControl(_dialogService);
            }

            if (parameter is OptionsParameter)
            {
                var control = new ComboParameterControl { ButtonVisible = false };

                // ensure that previously specified options are applied
                control.SetOptions((parameter as OptionsParameter).OptionsSource);     
                return control;
            }

            if (parameter is LayerParameterBase)
            {
                var lp = parameter as LayerParameterBase;
                return new LayerParameterControl(lp.Layers, lp.DataSourceType, _dialogService);
            }

            throw new ApplicationException("Failed to created control for parameter: " + parameter.DisplayName);
        }
    }
}
