using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Plugins.TableEditor.Properties;
using MW5.Shared;
using MW5.UI.Controls;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.TableEditor.Controls
{
    public partial class FunctionTreeView : TreeViewBase
    {
        private readonly ExpressionEvaluator _eval = new ExpressionEvaluator();

        public FunctionTreeView()
        {
            InitializeComponent();

            ShowSuperTooltip = true;

            ToolTipDuration = 5000;

            PrepareToolTip += OnPrepareToolTip;
        }

        private void OnPrepareToolTip(object sender, ToolTipEventArgs e)
        {
            var fn = SelectedFunction;
            if (fn == null)
            {
                e.Cancel = true;
                return;
            }

            e.ToolTip.Header.Text = fn.Signature;

            string s = fn.Description + Environment.NewLine;
            
            if (fn.NumParameters > 0)
            {
                s += Environment.NewLine + "Parameters: ";

                for (int i = 0; i < fn.NumParameters; i++)
                {
                    s += Environment.NewLine;
                    s += "   " + fn.GetParameterName(i) + ": " + fn.GetParameterDescription(i).Replace(".", ";").ToLower();
                }
            }
            else
            {
                s += Environment.NewLine + "<no parameters>";
            }
            
            e.ToolTip.Body.Text = s;
        }

        public void Initialize()
        {
            PopulateTree(string.Empty);
        }

        private void PopulateTree(string searchToken)
        {
            Nodes.Clear();

            var groups = _eval.GroupBy(fn => fn.Group);

            bool empty = string.IsNullOrWhiteSpace(searchToken);

            foreach (var g in groups)
            {
                var node = new TreeNodeAdv
                {
                    Text = g.Key.ToString(),
                    LeftImageIndices = new[] { 0 }
                };

                foreach (var fn in g.OrderBy(fn => fn.Name))
                {
                    if (empty || fn.Name.ContainsIgnoreCase(searchToken))
                    {
                        var nodeFn = new TreeNodeAdv {Text = fn.Name, Tag = fn};
                        node.Nodes.Add(nodeFn);
                    }
                }

                node.Expanded = true;

                if (node.Nodes.Count > 0)
                {
                    Nodes.Add(node);
                }
            }
        }

        public ExpressionFunction SelectedFunction
        {
            get { return SelectedNode != null ? SelectedNode.Tag as ExpressionFunction : null; }
        }

        public void Filter(string searchToken)
        {
            PopulateTree(searchToken);
        }

        protected override IEnumerable<Bitmap> OnCreateImageList()
        {
            return new List<Bitmap>()
            {
                Resources.img_folder_open
            };
        }
    }
}
