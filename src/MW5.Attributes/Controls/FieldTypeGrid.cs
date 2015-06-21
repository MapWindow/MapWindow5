// -------------------------------------------------------------------------------------------
// <copyright file="FieldTypeGrid.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;
using MW5.Attributes.Model;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Grid;

namespace MW5.Attributes.Controls
{
    public class FieldTypeGrid : StronglyTypedGrid<FieldTypeWrapper>
    {
        public FieldTypeGrid()
        {
            Adapter.HotTracking = false;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;
        }

        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;
                UpdateColumns();
            }
        }

        private void UpdateColumns()
        {
            Adapter.HideColumns();

            Adapter.ShowColumn(f => f.Type);
            Adapter.ShowColumn(f => f.Name);

            const int scrollbarWidth = 40;
            const int typeWidth = 40;

            var cmn = Adapter.GetColumn(f => f.Type);
            cmn.Width = typeWidth;
            cmn.Appearance.AnyCell.Borders.Right = new GridBorder(GridBorderStyle.Solid, Color.LightGray);

            cmn = Adapter.GetColumn(f => f.Name);
            cmn.Width = Width - typeWidth - scrollbarWidth;
        }
    }
}