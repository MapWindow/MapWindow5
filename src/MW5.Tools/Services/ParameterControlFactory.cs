// -------------------------------------------------------------------------------------------
// <copyright file="ParameterControlFactory.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Api.Enums;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Controls.Parameters.Interfaces;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;

namespace MW5.Tools.Services
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

        /// <summary>
        /// Creates a control for the parameter.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">parameter</exception>
        /// <exception cref="System.ApplicationException">Failed to created control for parameter:  + parameter.DisplayName</exception>
        public ParameterControlBase CreateControl(BaseParameter parameter, bool batchMode = false)
        {
            if (parameter == null) throw new ArgumentNullException("parameter");

            ParameterControlBase control = null;

            if (parameter is OutputNameParameter)
            {
                control = new OutputNameParameterControl(batchMode);
            }
            else if (parameter is GeoProjectionParameter)
            {
                control = _context.Container.GetInstance<ProjectionParameterControl>();
            }
            else if (parameter is FilenameParameter)
            {
                var dataType = (parameter as FilenameParameter).DataType;
                control = CreateInputControl(batchMode, dataType, true);
            }
            else if (parameter is FieldParameter)
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
                bool multiLine = (parameter as StringParameter).MultiLine;
                control = new StringParameterControl(multiLine);
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
                var op = parameter as OutputLayerParameter;
                control = CreateOutputControl(batchMode, op.LayerType, op.SupportInMemory);
            }
            else if (parameter is OptionsParameter)
            {
                control = new ComboParameterControl();
            }
            else if (parameter is LayerParameterBase)
            {
                var lp = parameter as LayerParameterBase;
                control = CreateInputControl(batchMode, lp.DataSourceType, false);
            }

            if (control == null)
            {
                throw new ApplicationException("Failed to created control for parameter: " + parameter.DisplayName);
            }

            control.ParameterName = parameter.Name;

            return control;
        }

        /// <summary>
        /// Creates the output control of the appropriate type.
        /// </summary>
        private ParameterControlBase CreateOutputControl(bool batchMode, LayerType layerType, bool supportsInMemory)
        {
            IOuputputParameterControl control;

            if (batchMode)
            {
                control = _context.Container.GetInstance<BatchOutputParameterControl>();
            }
            else
            {
                control = _context.Container.GetInstance<OutputLayerParameterControl>();
            }

            control.Initialize(layerType, supportsInMemory);

            return control as ParameterControlBase;
        }

        /// <summary>
        /// Creates input control of the appropriate type.
        /// </summary>
        private ParameterControlBase CreateInputControl(bool batchMode, DataSourceType dataType, bool isFilename)
        {
            IInputParameterControl input = null;

            if (isFilename)
            {
                if (batchMode)
                {
                    input = _context.Container.GetInstance<BatchFilenameParameterControl>();
                }
                else
                {
                    input = _context.Container.GetInstance<FilenameParameterControl>();
                }
            }
            else
            {
                if (batchMode)
                {
                    input = _context.Container.GetInstance<BatchLayerParameterControl>();
                }
                else
                {
                    input = _context.Container.GetInstance<LayerParameterControl>();
                }
            }

            input.Initialize(dataType);

            return input as ParameterControlBase;
        }
    }
}