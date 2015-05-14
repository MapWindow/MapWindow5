using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.UI.Controls;

namespace MW5.Data.Views.Controls
{
    public class DatabaseLayersGrid: StronglyTypedGrid<VectorLayerInfo>
    {
        public DatabaseLayersGrid()
        {
            KeyDown += DatabaseLayersGrid_KeyDown;
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
