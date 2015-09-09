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
using MW5.Tools.Helpers;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;

namespace MW5.Tools.Model
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

        private IEnumerable<BaseParameter> GetParameters(GisTool tool)
        {
            var properties = tool.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var attrInput = prop.GetAttribute<InputAttribute>();
                if (attrInput != null)
                {
                    yield return CreateInputParameter(tool, prop, attrInput);
                }

                var attrOutput = prop.GetAttribute<OutputAttribute>();
                if (attrOutput != null)
                {
                    yield return CreateOutputParameter(tool, prop, attrOutput);
                }
            }
        }

        private BaseParameter CreateOutputParameter(GisTool tool, PropertyInfo prop, OutputAttribute attr)
        {
            var param = ParameterFactory.CreateParameter(prop.PropertyType, Enums.ParameterType.Auto) as OutputLayerParameter;

            param.Tool = tool;
            param.ToolProperty = prop;

            param.Name = prop.Name;
            param.DisplayName = attr.DisplayName;
            param.DefaultValue = attr.NameTemplate;
            param.Required = true;
            param.LayerType = attr.LayerType;

            return param;
        }

        private BaseParameter CreateInputParameter(GisTool tool, PropertyInfo prop, InputAttribute attr)
        {
            var param = ParameterFactory.CreateParameter(prop.PropertyType, attr.ParameterType);

            param.Tool = tool;
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
            var range = prop.GetAttribute<RangeAttribute>();
            if (range != null)
            {
                var np = param as NumericParameter;
                if (np != null)
                {
                    np.SetRange(range.Minimum, range.Maximum);
                }
            }
        }

        private void HandleDefaultValueAttribute(BaseParameter param, PropertyInfo prop)
        {
            var attr = prop.GetAttribute<DefaultValueAttribute>();
            if (attr != null)
            {
                param.DefaultValue = attr.Value;
            }
        }

        /// <summary>
        /// Copies values from UI controls to the properties of the tool.
        /// </summary>
        public void Apply()
        {
            foreach (var p in _list.Where(p => p.Control != null))
            {
                p.ToolProperty.SetValue(_tool, p.Value);
            }
        }

        public void DetachControls()
        {
            foreach (var p in _list.Where(p => p.Control != null))
            {
                p.Control = null;
            }
        }

        /// <summary>
        /// Clones parameters to the new instance of the GisTool of the same type.
        /// </summary>
        public GisTool Clone()
        {
            var tool = Activator.CreateInstance(_tool.GetType()) as GisTool;

            foreach (var p in _list)
            {
                p.ToolProperty.SetValue(tool, p.Value);
            }

            return tool;
        }

        public bool Validate()
        {
            foreach (var p in _list)
            {
                var layerParameter = p as GenericLayerParameter;
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

                var value = p as ISupportsValidation;
                if (value != null)
                {
                    string errorMessage;
                    if (!value.Validate(out errorMessage))
                    {
                        MessageService.Current.Info(errorMessage);
                        return false;
                    }
                }

                var field = p as FieldParameter;
                if (field != null)
                {
                    if ((int)field.Value == -1)
                    {
                        MessageService.Current.Info(p.Name + " parameter is empty.");
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
                var ds = p.Datasource;
                if (ds != null)
                {
                    ds.Callback = callback;
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
            SetCallback(null);

            CloseDatasources();
        }

        private void CloseDatasources()
        {
            foreach (var p in _list.OfType<LayerParameterBase>())
            {
                var info = p.Value as IDatasourceInput;
                if (info != null)
                {
                    p.ClosedPointer = info.Pointer;
                    info.Close();
                }
            }
        }

        public bool ReopenDatasources(IAppContext context)
        {
            foreach (var p in _list.OfType<LayerParameterBase>())
            {
                var info = p.Value as IDatasourceInput;
                if (info == null)
                {
                    throw new ApplicationException("Invalid call to ParameterCollection.ReopenDatasources.");
                }

                var newInfo = p.ClosedPointer.ReopenDatasource(context, info);
                if (newInfo == null)
                {
                    MessageService.Current.Warn("Failed to reopen datasource for parameter: " + p.Name);
                    CloseDatasources();
                    return false;
                }

                p.SetToolValue(newInfo);
            }

            return true;
        }

        public IEnumerable<OutputLayerInfo> Outputs
        {
            get { 
                return _list.OfType<OutputLayerParameter>().Select(p => p.Value as OutputLayerInfo);
            }
        }
    }
}
