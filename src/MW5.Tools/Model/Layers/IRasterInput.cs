using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Tools.Model.Layers
{
    public interface IRasterInput: IDatasourceInput
    {
        /// <summary>
        /// Gets or sets the datasource serving as input for GIS task.
        /// </summary>
        new IRasterSource Datasource { get; set; }
    }
}
