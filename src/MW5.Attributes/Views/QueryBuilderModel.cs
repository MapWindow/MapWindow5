using System;
using MW5.Api.Legend.Abstract;

namespace MW5.Attributes.Views
{
    public class QueryBuilderModel
    {
        public QueryBuilderModel(ILegendLayer layer, string expression)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            Layer = layer;
            Expression = expression;
        }

        public ILegendLayer Layer { get; private set; }
        public string Expression { get; private set;}
    }
}
