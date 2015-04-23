using System;
using System.Linq;
using System.Collections.Generic;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Model
{
    public abstract class GisToolBase
    {
        protected List<BaseParameter> Parameters = new List<BaseParameter>();

        protected GisToolBase()
        {
        }

        public abstract void Initialize(IAppContext context);

        public abstract bool Run();

        public string Name { get; private set; }
    }
}
