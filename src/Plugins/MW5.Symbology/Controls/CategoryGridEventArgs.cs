using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Controls
{
    public class CategoryGridEventArgs : EventArgs
    {
        public CategoryGridEventArgs(CategoriesGrid grid, int categoryIndex)
        {
            if (grid == null) throw new ArgumentNullException("grid");

            CategoryIndex = categoryIndex;
            Grid = grid;
        }

        public CategoriesGrid Grid { get; private set; }

        public int CategoryIndex { get; private set; }
    }
}
