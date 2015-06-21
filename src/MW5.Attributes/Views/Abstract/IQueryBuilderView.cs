using System;
using MW5.Plugins.Mvp;

namespace MW5.Attributes.Views.Abstract
{
    public interface IQueryBuilderView: IView<QueryBuilderModel>
    {
        event Action TestClicked;
        
        event Action RunClicked;

        bool ValidateOnTheFly(bool silent);

        string Expression { get; }

        string ValidationResults { get; set; }
    }
}
