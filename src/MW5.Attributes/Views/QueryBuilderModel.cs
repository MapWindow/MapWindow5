// -------------------------------------------------------------------------------------------
// <copyright file="QueryBuilderModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Attributes.Views
{
    public class QueryBuilderModel : BaseExpressionBuilderModel
    {
        public QueryBuilderModel(ILayer layer, string expression, bool query = true)
            : base(layer, expression, query, TableValueType.Boolean) { }
    }
}