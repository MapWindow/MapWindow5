using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.Model;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.TableEditor.Views
{
    public partial class FindReplaceView : FindReplaceViewBase, IFindReplaceView
    {
        private bool _forceClose;

        public event Action Find;
        public event Action Replace;
        public event Action ReplaceAll;

        public FindReplaceView()
        {
            InitializeComponent();

            KeyPreview = true;
            KeyDown += FindReplaceView_KeyDown;
            FormClosing += OnFormClosing;

            InitControls();

            AttachEvents();
        }

        public void ForceClose()
        {
            _forceClose = true;
            Close();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_forceClose)
            {
                e.Cancel = true;
                Visible = false; // user may want to open search once more; so let's not dispose it
            }
        }

        public override Mvp.ViewStyle Style
        {
            get
            {
                return new Mvp.ViewStyle()
                {
                    Modal = false,
                    Sizable = false,
                };
            }
        }

        void FindReplaceView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    Invoke(Find);
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void AttachEvents()
        {
            btnFind.Click += (s, e) => Invoke(Find);
            btnReplace.Click += (s, e) => Invoke(Replace);
            btnReplaceAll.Click += (s, e) => Invoke(ReplaceAll);
            btnClose.Click += (s, e) => Close();
        }

        private void InitControls()
        {
            cboMatch.AddItemsFromEnum<MatchType>();
        }

        public void Initialize()
        {
            Text = Model.DialogCaption;

            cboMatch.SetValue(MatchType.Contains);

            btnReplace.Visible = Model.Replace;
            btnReplaceAll.Visible = Model.Replace;
            lblReplaceWith.Enabled = Model.Replace;
            cboReplace.Enabled = Model.Replace;

            InitFields();

            if (!Model.Replace)
            {
                // hiding replace section
                const int offset = 36;
                panel1.Top -= offset;
                Height -= offset;
            }
        }

        private void InitFields()
        {
            var list = Model.Table.Fields.Select(f => new FindReplaceFieldWrapper(f)).ToList();
            list.Insert(0, new FindReplaceFieldWrapper());
            cboFields.DataSource = list;
            cboFields.SelectedIndex = 0;
        }

        private int GetFieldIndex()
        {
            var fld = cboFields.SelectedItem as FindReplaceFieldWrapper;
            if (fld != null)
            {
                if (fld.FieldType == FindReplaceFieldType.Regular)
                {
                    return fld.Field.Index;
                }
            }

            return -1;
        }

        public void UpdateSearchInfo()
        {
            var info = Model.SearchInfo;
            info.NewSearch = false;
            info.CaseSensitive = chkCaseSensitive.Checked;
            info.MatchType = cboMatch.GetValue<MatchType>();
            info.Token = cboFind.Text;
            info.ReplaceWith = cboReplace.Text;
            info.FieldIndex = GetFieldIndex();
        }

        public string SearchToken
        {
            get { return cboFind.Text; }
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }
    }

    public class FindReplaceViewBase : MapWindowView<FindReplaceModel> { }
}
