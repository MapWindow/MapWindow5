// -------------------------------------------------------------------------------------------
// <copyright file="QueryBuilderModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Api.Interfaces;

namespace MW5.Attributes.Views
{
    public class QueryBuilderModel
    {
        public QueryBuilderModel(ILayer layer, string expression)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            Layer = layer;
            Expression = expression;
        }

        public string Expression { get; set; }

        public ILayer Layer { get; private set; }
    }
}