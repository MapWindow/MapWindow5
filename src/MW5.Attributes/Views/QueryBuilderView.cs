using System.Linq;
using System.Windows.Forms;
using MW5.Attributes.Model;
using MW5.Attributes.Views.Abstract;
using MW5.UI.Forms;

namespace MW5.Attributes.Views
{
    public partial class QueryBuilderView : QueryBuilderViewBase, IQueryBuilderView
    {
        public QueryBuilderView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            InitTextBox();

            InitFieldGrid();
        }

        private void InitTextBox()
        {
            richTextBox1.Text = Model.Expression;
            richTextBox1.HideSelection = false;
            richTextBox1.SelectAll();
            richTextBox1.Focus();
        }

        private void InitFieldGrid()
        {
            fieldTypeGrid1.ShowColumnHeaders = false;
            var fields = Model.Layer.FeatureSet.Fields;
            var list = fields.Select(f => new FieldTypeWrapper(f)).ToList();
            fieldTypeGrid1.DataSource = list;
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }
    }

    public class QueryBuilderViewBase : MapWindowView<QueryBuilderModel> { }
}
