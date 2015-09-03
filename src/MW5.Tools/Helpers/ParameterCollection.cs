using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Shared.Log;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Builds list of parameters for the tool via reflection.
    /// </summary>
    public class ParameterCollection: IEnumerable<BaseParameter>
    {
        private readonly List<BaseParameter> _list;
        private readonly GisTool _tool;

        public ParameterCollection(GisTool tool)
        {
            if (tool == null) throw new ArgumentNullException("tool");
            _tool = tool;
            _list = GetParameters(tool).ToList();
        }

        public void Initialize(IAppContext context)
        {
            foreach (var layerParameter in _list.OfType<LayerParameterBase>())
            {
                layerParameter.Initialize(context.Layers);
            }
        }

        private IEnumerable<BaseParameter> GetParameters(GisTool tool)
        {
            var properties = tool.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var attrInput = prop.GetAttribute<InputAttribute>();
                if (attrInput != null)
                {
                    yield return CreateInputParameter(prop, attrInput);
                }

                var attrOutput = prop.GetAttribute<OutputAttribute>();
                if (attrOutput != null)
                {
                    yield return CreateOutputParameter(prop, attrOutput);
                }
            }
        }

        private BaseParameter CreateOutputParameter(PropertyInfo prop, OutputAttribute attr)
        {
            var param = ParameterFactory.CreateParameter(prop.PropertyType, Enums.ParameterType.Auto) as OutputLayerParameter;
            
            param.ToolProperty = prop;
            param.Name = prop.Name;
            param.DisplayName = attr.DisplayName;
            param.SetDefaultValue(attr.Filename);
            param.Required = true;
            param.LayerType = attr.LayerType;

            return param;
        }

        private BaseParameter CreateInputParameter(PropertyInfo prop, InputAttribute attr)
        {
            var param = ParameterFactory.CreateParameter(prop.PropertyType, attr.ParameterType);

            param.ToolProperty = prop;
            param.Name = prop.Name;
            param.Index = attr.Index;
            param.DisplayName = attr.DisplayName;
            param.Required = !attr.Optional;

            HandleRangeAttribute(param, prop);

            HandleDefaultValueAttribute(param, prop);

            return param;
        }

        private void HandleRangeAttribute(BaseParameter param, PropertyInfo prop)
        {
            var vp = param as ValueParameter;
            if (vp != null && vp.Numeric)
            {
                var range = prop.GetAttribute<RangeAttribute>();
                if (range != null)
                {
                    if (param is IntegerParameter)
                    {
                        (param as IntegerParameter).MinValue = (int)range.Minimum;
                        (param as IntegerParameter).MaxValue = (int)range.Maximum;
                        (param as IntegerParameter).HasRange = true;
                    }
                    else if (param is DoubleParameter)
                    {
                        (param as DoubleParameter).MinValue = (double)range.Minimum;
                        (param as DoubleParameter).MaxValue = (double)range.Maximum;
                        (param as DoubleParameter).HasRange = true;
                    }
                }
            }
        }

        private void HandleDefaultValueAttribute(BaseParameter param, PropertyInfo prop)
        {
            var attr = prop.GetAttribute<DefaultValueAttribute>();
            if (attr != null)
            {
                param.SetDefaultValue(attr.Value);
            }
        }

        public void Apply()
        {
            foreach (var p in _list)
            {
                p.ToolProperty.SetValue(_tool, p.Value);
            }
        }

        public bool Validate()
        {
            foreach (var p in _list)
            {
                var layerParameter = p as LayerParameter;
                if (layerParameter != null)
                {
                    if (layerParameter.Datasource == null)
                    {
                        MessageService.Current.Info("Input datasource isn't selected.");
                        return false;
                    }
                }

                var outputParameter = p as OutputLayerParameter;
                if (outputParameter != null)
                {
                    string errorMessage;
                    if (!outputParameter.GetValue().Validate(out errorMessage))
                    {
                        MessageService.Current.Info(errorMessage);
                        return false;
                    }
                }

                var value = p as ValueParameter;
                if (value != null)
                {
                    string errorMessage;
                    if (!value.Validate(out errorMessage))
                    {
                        MessageService.Current.Info(errorMessage);
                        return false;
                    }
                }
            }

            return true;
        }

        public void SetCallback(IApplicationCallback callback)
        {
            foreach (var p in _list.OfType<LayerParameterBase>())
            {
                var layer = p.SelectedLayer;
                if (layer != null)
                {
                    layer.Source.Callback = callback;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<BaseParameter> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CleanUp()
        {
            ClearCallbacks();
            CloseDatasources();
        }

        public void ClearCallbacks()
        {
            foreach (var p in _list.OfType<LayerParameterBase>())
            {
                var layerSource = p.ToolProperty.GetValue(_tool) as ILayerSource;
                if (layerSource != null)
                {
                    layerSource.Callback = null;
                }
            }
        }

        public void CloseDatasources()
        {
            foreach (var p in _list.OfType<LayerParameterBase>())
            {
                if (!p.SelectedLayer.Opened)
                {
                    var layer = p.ToolProperty.GetValue(_tool) as ILayerSource;
                    if (layer != null)
                    {
                        layer.Dispose();
                    }
                }
            }
        }
    }
}
