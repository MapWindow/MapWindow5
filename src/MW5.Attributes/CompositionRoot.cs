using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Attributes.Views;
using MW5.Attributes.Views.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Attributes
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<IQueryBuilderView, QueryBuilderView>();
        }
    }
}
