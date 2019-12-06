// -------------------------------------------------------------------------------------------
// <copyright file="QueryBuilderModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Attributes.Views
{
    public abstract class BaseExpressionBuilderModel : IExpressionBuilderModel
    {
        protected BaseExpressionBuilderModel(ILayer layer, string expression, bool query = true, TableValueType outputType = TableValueType.Boolean)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            Layer = layer;
            Expression = expression;
            IsQuery = query;
            OutputType = outputType;
        }

        public bool IsQuery { get; private set; }

        public TableValueType OutputType { get; private set; }

        public string Expression { get; set; }

        public ILayer Layer { get; private set; }
    }
}