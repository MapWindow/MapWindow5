using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
    public abstract class ParameterAttribute: Attribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredParameterAttribute"/> class.
        /// </summary>
        /// <param name="displayName">The display name.</param>
        /// <param name="index">The index.</param>
        protected ParameterAttribute(string displayName, int index)
        {
            DisplayName = displayName;
            Index = index;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }

        #endregion
    }
}
