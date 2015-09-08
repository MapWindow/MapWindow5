using System;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Creates and assigns controls for parameters.
    /// </summary>
    public class ParameterControlFactory
    {
        private readonly IAppContext _context;

        public ParameterControlFactory(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public ParameterControlBase CreateControl(BaseParameter parameter, bool batchMode = false)
        {
            if (parameter == null) throw new ArgumentNullException("parameter");

            ParameterControlBase control = null;

            if (parameter is FieldParameter)
            {
                control = new FieldParameterControl();
            }
            else if (parameter is DistanceParameter)
            {
                control = new DistanceParameterControl();
            }
            else if (parameter is DoubleParameter)
            {
                control = new DoubleParameterControl();
            }
            else if (parameter is StringParameter)
            {
                control = new StringParameterControl();
            }
            else if (parameter is BooleanParameter)
            {
                control = new BooleanParameterControl();
            }
            else if (parameter is IntegerParameter)
            {
                control = new IntegerParameterControl();
            }
            else if (parameter is OutputLayerParameter)
            {
                var layerType = (parameter as OutputLayerParameter).LayerType;

                if (batchMode)
                {
                    var opc = _context.Container.GetInstance<BatchOutputParameterControl>();
                    opc.Initialize(layerType);
                    control = opc;
                }
                else
                {
                    var opc = _context.Container.GetInstance<OutputParameterControl>();
                    opc.Initialize(layerType);
                    control = opc;
                }
            }
            else if (parameter is OptionsParameter)
            {
                control = new ComboParameterControl { ButtonVisible = false };
            }
            else if (parameter is LayerParameterBase)
            {
                var lp = parameter as LayerParameterBase;
                
                if (batchMode)
                {
                    var blpc = _context.Container.GetInstance<BatchLayerParameterControl>();
                    blpc.Initialize(lp.DataSourceType);
                    control = blpc;
                }
                else
                {
                    var lpc = _context.Container.GetInstance<LayerParameterControl>();
                    lpc.Initialize(lp.DataSourceType);
                    control = lpc;
                }
            }

            if (control == null)
            {
                throw new ApplicationException("Failed to created control for parameter: " + parameter.DisplayName);
            }

            var init = parameter.InitialValue;
            if (init != null)
            {
                control.SetValue(init);
            }

            control.ParameterName = parameter.Name;

            return control;
        }
    }
}
