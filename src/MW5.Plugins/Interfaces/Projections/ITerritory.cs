using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces.Projections
{
    public interface ITerritory
    {
        /// <summary>
        /// The code of territory (coordinate system , country or region)
        /// </summary>
        int Code { get; }

        /// <summary>
        /// The name of territory
        /// </summary>
        string Name { get;  }

        /// <summary>
        /// The left bound
        /// </summary>
        double Left { get;  }

        /// <summary>
        /// The right bound
        /// </summary>
        double Right { get;  }

        /// <summary>
        /// The top bound
        /// </summary>
        double Top { get;  }

        /// <summary>
        /// The bottom bound
        /// </summary>
        double Bottom { get;  }

        /// <summary>
        /// Settings name as string representation
        /// </summary>
        string ToString();

        bool IsActive { get; }
    }
}
