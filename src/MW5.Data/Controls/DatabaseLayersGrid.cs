using System.Windows.Forms;
using MW5.Data.Model;
using MW5.UI.Controls;

namespace MW5.Data.Controls
{
    public class DatabaseLayersGrid: StronglyTypedGrid<VectorLayerGridAdapter>
    {
        public DatabaseLayersGrid()
        {
            KeyDown += DatabaseLayersGrid_KeyDown;

            Adapter.AllowCurrentCell = false;
        }

        void DatabaseLayersGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Adapter.ToggleProperty(info => info.Selected);
            }
        }
    }
}
