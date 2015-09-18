using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters.Layers;

namespace MW5.Tools.Model.Parameters
{
    /// <summary>
    /// Creates parameters for each property of the tool marked as Input or Output.
    /// </summary>
    /// <remarks>
    /// Uses attributes: 
    /// - InputAttribute;
    /// - OutputAttribute;
    /// - OutputLayerParameterAttribute;
    /// - ControlHintAttribute;
    /// - RangeAttribute;
    /// - DefaultValueAttribute.
    /// </remarks>
    public static class ParameterFactory
    {
        /// <summary>
        /// Creates parameter object for each property of the tool marked as input or output.
        /// </summary>
        public static IEnumerable<BaseParameter> CreateParameters(this GisTool tool)
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

        /// <summary>
        /// Creates a new instance of output parameter for the given property.
        /// </summary>
        private static BaseParameter CreateOutputParameter(GisTool tool, PropertyInfo prop, OutputAttribute attr)
        {
            var param = CreateParameter(prop.PropertyType, GetParameterHint(prop));

            param.Tool = tool;
            param.ToolProperty = prop;

            param.Name = prop.Name;
            param.DisplayName = attr.DisplayName;
            param.Required = true;
            param.IsInput = false;
            param.Index = attr.Index;

            var olp = param as OutputLayerParameter;
            if (olp != null)
            {
                var layerAttr = prop.GetAttribute<OutputLayerAttribute>();
                if (layerAttr != null)
                {
                    olp.DefaultValue = layerAttr.NameTemplate;
                    olp.SupportInMemory = layerAttr.SupportsInMemory;
                    olp.LayerType = layerAttr.LayerType;
                }
            }

            return param;
        }

        /// <summary>
        /// Creates a new instance of the input parameter for the property.
        /// </summary>
        private static BaseParameter CreateInputParameter(GisTool tool, PropertyInfo prop, InputAttribute attr)
        {
            var param = CreateParameter(prop.PropertyType, GetParameterHint(prop));

            param.IsInput = true;
            param.Tool = tool;
            param.ToolProperty = prop;
            param.Name = prop.Name;
            param.Index = attr.Index;
            param.DisplayName = attr.DisplayName;
            param.Required = !attr.Optional;
            param.SectionName = attr.SectionName;

            HandleRangeAttribute(param, prop);

            HandleDefaultValueAttribute(param, prop);

            return param;
        }

        /// <summary>
        /// Gets the control hint for the property.
        /// </summary>
        private static ControlHint GetParameterHint(PropertyInfo prop)
        {
            var paramAttr = prop.GetAttribute<ControlHintAttribute>();
            return paramAttr != null ? paramAttr.ControlHint : ControlHint.Auto;
        }

        /// <summary>
        /// Applies range attribute to the parameter.
        /// </summary>
        private static void HandleRangeAttribute(BaseParameter param, PropertyInfo prop)
        {
            var range = prop.GetAttribute<RangeAttribute>();
            if (range == null)
            {
                return;
            }

            var p = param as NumericParameter;
            if (p != null)
            {
                p.SetRange(range.Minimum, range.Maximum);
            }
        }

        /// <summary>
        /// Applies default value attribute to the parameter.
        /// </summary>
        private static void HandleDefaultValueAttribute(BaseParameter param, PropertyInfo prop)
        {
            var attr = prop.GetAttribute<DefaultValueAttribute>();
            if (attr != null)
            {
                param.DefaultValue = attr.Value;
            }
        }

        /// <summary>
        /// Creates tool parameter for a property of a given type.
        /// </summary>
        private static BaseParameter CreateParameter(Type type, ControlHint customType)
        {
            switch (customType)
            {
                case ControlHint.Field:
                    return new FieldParameter();
                case ControlHint.Combo:
                    return new OptionsParameter();
                case ControlHint.Filename:
                    return new FilenameParameter(DataSourceType.All);
                case ControlHint.VectorFilename:
                    return new FilenameParameter(DataSourceType.Vector);
                case ControlHint.RasterFilename:
                    return new FilenameParameter(DataSourceType.Raster);
                case ControlHint.MultiLineString:
                    return new StringParameter(true);
                case ControlHint.OutputName:
                    return new OutputNameParameter();
            }

            if (customType != ControlHint.Auto)
            {
                throw new IndexOutOfRangeException("No handler for parameter type: " + customType);
            }

            if (type == typeof(double))
            {
                return new DoubleParameter();
            }

            if (type == typeof(int))
            {
                return new IntegerParameter();
            }

            if (type == typeof(string))
            {
                return new StringParameter();
            }

            if (type == typeof(bool))
            {
                return new BooleanParameter();
            }

            if (type == typeof(IRasterInput))
            {
                return new RasterLayerParameter();
            }

            if (type == typeof(IVectorInput))
            {
                return new VectorLayerParameter();
            }

            if (type == typeof(IRasterSource))
            {
                return new RasterLayerParameter();
            }

            if (type == typeof(IDatasourceInput))
            {
                return new GenericLayerParameter();
            }

            if (type == typeof(Distance))
            {
                return new DistanceParameter();
            }

            if (type == typeof(OutputLayerInfo))
            {
                return new OutputLayerParameter();
            }

            throw new ApplicationException("Unexpected parameter type for the tool: " + type.Name);
        }
    }
}
