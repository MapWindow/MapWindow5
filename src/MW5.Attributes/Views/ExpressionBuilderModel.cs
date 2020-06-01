// -------------------------------------------------------------------------------------------
// <copyright file="QueryBuilderModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Attributes.Views
{
    public class ExpressionBuilderModel : BaseExpressionBuilderModel
    {
        public ExpressionBuilderModel(ILayer layer, string expression, TableValueType outputType) 
            : base(layer, expression, false, outputType) { }
    }
}