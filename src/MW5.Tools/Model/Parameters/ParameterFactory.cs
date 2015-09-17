using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Enums;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters.Layers;

namespace MW5.Tools.Model.Parameters
{
    public static class ParameterFactory
    {
        /// <summary>
        /// Creates tool parameter for a property of a given type.
        /// </summary>
        public static BaseParameter CreateParameter(Type type, ControlHint customType)
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

            // options
            throw new ApplicationException("Unexpected parameter type for the tool: " + type.Name);
        }
    }
}
