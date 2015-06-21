using MW5.Attributes.Views.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Attributes.Views
{
    public class QueryBuilderPresenter: BasePresenter<IQueryBuilderView, QueryBuilderModel>
    {
        public QueryBuilderPresenter(IQueryBuilderView view)
            : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
