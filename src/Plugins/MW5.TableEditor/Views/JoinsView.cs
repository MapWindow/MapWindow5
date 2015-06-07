using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class JoinsView : JoinsBaseView, IJoinsView
    {
        public event Action JoinDoubleClicked
        {
            add { joinsGrid1.JoinDoubleClicked += value; }
            remove { joinsGrid1.JoinDoubleClicked -= value; }
        }

        public JoinsView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            UpdateView();
        }

        public override Mvp.ViewStyle Style
        {
            get
            {
                return new Mvp.ViewStyle()
                {
                    Modal = true,
                    Sizable = true,
                };
            }
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get { yield break; }
        }

        public IEnumerable<Control> Buttons
        {
            get
            {
                yield return btnJoin;
                yield return btnEditJoin;
                yield return btnStop;
                yield return btnStopAll;
            }
        }

        /// <summary>
        /// Updates state of the buttons after user actions
        /// </summary>
        public override void UpdateView()
        {
            var list = Model.Joins.ToList();
            joinsGrid1.DataSource = list;

            var t = joinsGrid1.Table;
            if (t.Records.Count > 0)
            {
                var r = t.Records[t.Records.Count - 1];
                joinsGrid1.Table.SelectedRecords.Add(r);
            }

            var item = joinsGrid1.Adapter.SelectedItem;
            btnStop.Enabled =  item != null;
            btnEditJoin.Enabled = item != null;
            btnStopAll.Enabled = joinsGrid1.Adapter.Items.Any();
        }

        public FieldJoin SelectedJoin
        {
            get { return joinsGrid1.Adapter.SelectedItem; }
        }
    }

    public class JoinsBaseView : MapWindowView<IAttributeTable> { }
}
