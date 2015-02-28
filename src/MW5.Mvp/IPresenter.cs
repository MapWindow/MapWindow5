using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Mvp
{
    public interface IPresenter
    {
        void Run();
    }

    public interface IPresenter<in TArg>
    {
        void Run(TArg argument);
    }

    //public interface IPresenter<in TModel> where TModel : class
    //{
    //    void Run(TModel model);
    //}
}
